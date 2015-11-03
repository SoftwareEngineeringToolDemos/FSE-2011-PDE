using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using System.Windows.Controls;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Diagram connector adorners are used to create the actual relationships between diagram items.
    /// </summary>
    public class DiagramConnectorAdorner : Adorner
    {
        private PathGeometry pathGeometry;
        private DiagramDesigner diagramDesigner;
        private DiagramConnector sourceConnector;
        private IDiagramViewModel diagramDesignerVM = null;
        private Pen drawingPen;
        private Point startPoint;

        DiagramDesignerItem sourceItem = null;
        DiagramDesignerItem hitItem = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="designer">Diagram designer.</param>
        /// <param name="sourceConnector">Source item of the relationship.</param>
        /// <param name="startPoint">Start point.</param>
        public DiagramConnectorAdorner(DiagramDesigner designer, DiagramConnector sourceConnector, Point startPoint)
            : base(designer)
        {
            this.diagramDesigner = designer;
            if (this.diagramDesigner.DataContext is IDiagramViewModel)
                diagramDesignerVM = this.diagramDesigner.DataContext as IDiagramViewModel;
            this.sourceConnector = sourceConnector;
            this.startPoint = startPoint;

            sourceItem = sourceConnector.DiagramItem;
            //if (sourceConnector.DiagramItem is ISelectable)
            //    this.sourceElement = (sourceConnector.DiagramItem as ISelectable).SelectedData;

            drawingPen = new Pen(Brushes.LightSlateGray, 1);
            drawingPen.LineJoin = PenLineJoin.Round;
            
            this.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// See if we have found a suitable item to create a relationship during movement as long a mouse is pressed. Release mouse otherwise.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                HitTesting(e.GetPosition(this));

                if (hitItem == null)
                    this.Cursor = Cursors.No;
                else
                    this.Cursor = Cursors.Cross;

                this.pathGeometry = GetPathGeometry(e.GetPosition(diagramDesigner));
                this.InvalidateVisual();
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }
        }

        /// <summary>
        /// Create relationship if possible. Release mouse afterwards.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (hitItem != null)
            {
                object targetElement = hitItem.SelectedData;
                if (sourceItem != null && hitItem != null && this.diagramDesigner.CreateRelationshipCommand != null)
                {
                    ViewModelRelationshipCreationInfo info = new ViewModelRelationshipCreationInfo(sourceItem.SelectedData, hitItem.SelectedData);

                    // calcualte source and target points
                    if (hitItem is FrameworkElement)
                    {
                        FrameworkElement sourceFElement = sourceConnector.DiagramItem;
                        double sourceLeft = Canvas.GetLeft(sourceFElement);
                        double sourceTop = Canvas.GetTop(sourceFElement);

                        FrameworkElement targetFElement = hitItem as FrameworkElement;
                        double targetLeft = Canvas.GetLeft(targetFElement);
                        double targetTop = Canvas.GetTop(targetFElement);
                        if (!double.IsNaN(sourceLeft) && !double.IsNaN(sourceTop) && 
                            !double.IsNaN(targetLeft) && !double.IsNaN(targetTop))
                        {
                            Point proposedTarget = e.GetPosition(this.diagramDesigner);

                            PointD proposedSourcePoint = new PointD(startPoint.X, startPoint.Y);
                            PointD proposedTargetPoint = new PointD(proposedTarget.X, proposedTarget.Y);

                            // calculate points
                            //Point sourcePointT = sourceFElement.TranslatePoint(new Point(0, 0), this.diagramDesigner);
                            //Point targetPointT = targetFElement.TranslatePoint(new Point(0, 0), this.diagramDesigner);

                            Point sourcePoint = sourceFElement.TransformToAncestor(this.diagramDesigner).Transform(new Point(0, 0));
                            Point targetPoint = targetFElement.TransformToAncestor(this.diagramDesigner).Transform(new Point(0, 0));

                            // calculate side for source
                            RectangleD sourceBounds = new RectangleD(sourcePoint.X, sourcePoint.Y, sourceFElement.Width, sourceFElement.Height);
                            info.ProposedSourcePoint = LinkShape.CalculateLocation(sourceBounds, proposedSourcePoint);

                            // calculate side for target
                            RectangleD targeteBounds = new RectangleD(targetPoint.X, targetPoint.Y, targetFElement.Width, targetFElement.Height);
                            info.ProposedTargetPoint = LinkShape.CalculateLocation(targeteBounds, proposedTargetPoint);
                        }
                    }

                    this.diagramDesigner.CreateRelationshipCommand.Execute(info);
                }
            }

            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.diagramDesigner);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this);
            }
        }

        /// <summary>
        /// Render the connector adorner.
        /// </summary>
        /// <param name="dc"></param>
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            dc.DrawGeometry(null, drawingPen, this.pathGeometry);

            // without a background the OnMouseMove event would not be fired
            // Alternative: implement a Canvas as a child of this adorner, like
            // the ConnectionAdorner does.
            dc.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));
        }

        /// <summary>
        /// Updates the path geometry.
        /// </summary>
        /// <param name="position">Target position.</param>
        /// <returns>Calculates path geometry.</returns>
        private PathGeometry GetPathGeometry(Point position)
        {
            if (this.diagramDesignerVM != null )
            {
                if (hitItem != null )
                    if( hitItem.DataContext is IDiagramItemViewModel)
                        return this.diagramDesignerVM.CalcPathGeometry(new PointD(startPoint), hitItem.DataContext as IDiagramItemViewModel, new PointD(position), FixedGeometryPoints.Source);

                return this.diagramDesignerVM.CalcPathGeometry(new PointD(startPoint), new PointD(position), FixedGeometryPoints.Source);
            }
            else
            {

                PathGeometry geometry = new PathGeometry();
                PathFigure figure = new PathFigure();
                figure.StartPoint = startPoint;

                List<Point> points = new List<Point>();
                points.Add(startPoint);
                points.Add(position);
                figure.Segments.Add(new PolyLineSegment(points, true));

                geometry.Figures.Add(figure);

                return geometry;
            }
        }

        /// <summary>
        /// Hit testing.
        /// </summary>
        /// <param name="hitPoint">Location to do a hit test at.</param>
        private void HitTesting(Point hitPoint)
        {
            DependencyObject hitObject = diagramDesigner.InputHitTest(hitPoint) as DependencyObject;
            while (hitObject != null )
            {
                if (hitObject is DiagramDesignerItem)
                {
                    hitItem = hitObject as DiagramDesignerItem;
                    if (!hitItem.IsDiagramLink)
                    {
                        if (sourceItem != null && hitItem != null && this.diagramDesigner.CreateRelationshipCommand != null)
                        {
                            object sourceData = sourceItem.SelectedData;
                            object targetData = hitItem.SelectedData;
                            if (sourceData != null && targetData != null)
                            {
                                ViewModelRelationshipCreationInfo info = new ViewModelRelationshipCreationInfo(sourceData, targetData);
                                if (info.Source != null && info.Target != null)
                                    if (this.diagramDesigner.CreateRelationshipCommand.CanExecute(info))
                                    {
                                        return;
                                    }
                            }
                        }
                    }

                    hitItem = null;
                    return;
                }

                hitObject = VisualTreeHelper.GetParent(hitObject);
            }

            hitItem = null;
        }
    }
}
