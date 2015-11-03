using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Microsoft.VisualStudio.Modeling;
using System.Windows.Controls;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    /// <summary>
    /// Diagram connector adorners are used to create the actual relationships between diagram items.
    /// </summary>
    public class DiagramConnectorAdorner : Adorner
    {
        private PathGeometry pathGeometry;
        private DesignerCanvas diagramDesigner;
        private DiagramConnector sourceConnector;
        private Pen drawingPen;
        private Point startPoint;

        DesignerItem sourceItem = null;
        DesignerItem hitItem = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="designer">Diagram designer.</param>
        /// <param name="sourceConnector">Source item of the relationship.</param>
        public DiagramConnectorAdorner(DesignerCanvas designer, DiagramConnector sourceConnector, Point startPoint)
            : base(designer)
        {
            this.diagramDesigner = designer;
            this.sourceConnector = sourceConnector;
            this.startPoint = startPoint;

            sourceItem = sourceConnector.DiagramItem;

            drawingPen = new Pen(Brushes.LightSlateGray, 1);
            drawingPen.LineJoin = PenLineJoin.Round;

            this.Cursor = Cursors.Cross;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                HitTesting(e.GetPosition(this));

                //if (hitItem == null)
                //    this.Cursor = Cursors.No;
                //else
                    this.Cursor = Cursors.Cross;

                this.pathGeometry = GetPathGeometry(e.GetPosition(diagramDesigner));
                this.InvalidateVisual();
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (sourceItem != null)
            {
                ModelTreeViewModel vm = this.diagramDesigner.DataContext as ModelTreeViewModel;
                if (sourceItem.SelectedData is TreeNodeViewModel)
                    if ((sourceItem.SelectedData as TreeNodeViewModel).Element is DomainClass)
                    {
                        List<DomainClass> domainClassesSrc = new List<DomainClass>();
                        domainClassesSrc.Add((sourceItem.SelectedData as TreeNodeViewModel).Element as DomainClass);

                        bool bDone = false;
                        if (hitItem != null)
                            if (hitItem.SelectedData is TreeNodeViewModel)
                                if ((hitItem.SelectedData as TreeNodeViewModel).Element is DomainClass)
                                {
                                    bDone = true;
                                    
                                    // reference or embedding?
                                    if( Keyboard.Modifiers == ModifierKeys.Shift )
                                        ModelTreeOperations.AddNewEmbeddingRelationship(domainClassesSrc, (hitItem.SelectedData as TreeNodeViewModel).Element as DomainClass);
                                    else if (Keyboard.Modifiers == ModifierKeys.Control)
                                        ModelTreeOperations.AddNewReferenceRelationship(domainClassesSrc, (hitItem.SelectedData as TreeNodeViewModel).Element as DomainClass);
                                    else
                                    {
                                        Forms.RelationshipTypeSelector dlg = new Forms.RelationshipTypeSelector();
                                        if (dlg.ShowDialog() == true)
                                        {
                                            if( dlg.EmbeddedRelationshipSelected == true )
                                                ModelTreeOperations.AddNewEmbeddingRelationship(domainClassesSrc, (hitItem.SelectedData as TreeNodeViewModel).Element as DomainClass);
                                            else if (dlg.EmbeddedRelationshipSelected == false)
                                                ModelTreeOperations.AddNewReferenceRelationship(domainClassesSrc, (hitItem.SelectedData as TreeNodeViewModel).Element as DomainClass);
                                        }
                                    }
                                }

                        if( !bDone )
                            ModelTreeOperations.AddNewEmbeddingRelationship(domainClassesSrc);
                    }
            }
            

            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.diagramDesigner);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this);
            }
        }
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

        /// <summary>
        /// Hit testing.
        /// </summary>
        /// <param name="hitPoint">Location to do a hit test at.</param>
        private void HitTesting(Point hitPoint)
        {
            DependencyObject hitObject = diagramDesigner.InputHitTest(hitPoint) as DependencyObject;
            while (hitObject != null)
            {
                if (hitObject is DesignerItem)
                {
                    hitItem = hitObject as DesignerItem;
                    if ((hitItem as DesignerItem).DataContext is TreeNodeViewModel)
                    {
                        if (sourceItem != null && hitItem != null)
                        {
                            return;
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
