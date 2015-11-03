using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using System.Windows;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Diagram designer link drag thumb, which is used to move source or target connector.
    /// </summary>
    public class DiagramDesignerLinkDragThumb : Thumb
    {
        private DiagramDesigner diagramDesigner;
        private IDiagramViewModel diagramDesignerVM;
        private DiagramDesignerItem selectedItem;
        private IDiagramLinkViewModel selectedItemVM;
        private DragAdorner dragAdorner;
        private Canvas dragCanvas;

        private IEdgePointViewModel edgePointVM;

        //private bool isSource = true;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiagramDesignerLinkDragThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(DragThumb_DragDelta);
            base.DragCompleted += new DragCompletedEventHandler(DragThumb_DragCompleted);
            base.DragStarted += new DragStartedEventHandler(DragThumb_DragStarted);            
        }

        /// <summary>
        /// Dragging has started, see if VM is IDiagramLinkViewModel and notify of moving start.
        /// </summary>
        void DragThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            diagramDesigner = DiagramHelper.GetDiagramDesigner(this);
            diagramDesignerVM = diagramDesigner.DataContext as IDiagramViewModel;

            selectedItem = null;
            selectedItemVM = null;

            edgePointVM = this.DataContext as IEdgePointViewModel;

            List<ISelectable> selection = diagramDesigner.SelectionService.CurrentSelection;
            if (selection.Count == 1)
            {
                foreach (ISelectable item in selection)
                {
                    if (item is DiagramDesignerItem)
                        if ((item as DiagramDesignerItem).IsDiagramLink)
                        {
                            selectedItem = item as DiagramDesignerItem;
                        }
                }

                // create control to display on the drag adorner
                dragCanvas = new Canvas();
                IDiagramLinkViewModel designerItem = selectedItem.DataContext as IDiagramLinkViewModel;
                selectedItemVM = designerItem;

                AddLinkAnchorAndShape(new PointD(designerItem.StartEdgePoint.X, designerItem.StartEdgePoint.Y),
                    new PointD(designerItem.EndEdgePoint.X, designerItem.EndEdgePoint.Y));

                // create drag adorner 
                if (diagramDesigner != null && selectedItemVM != null && selectedItem != null && edgePointVM != null)
                {
                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(diagramDesigner);
                    if (adornerLayer != null)
                    {
                        this.dragAdorner = new DragAdorner(diagramDesigner, dragCanvas, false, 1.0);
                        if (this.dragAdorner != null)
                        {
                            adornerLayer.Add(this.dragAdorner);
                            e.Handled = true;
                        }
                    }
                }
            }
            e.Handled = false;
        }

        /// <summary>
        /// Dragging has ended, see if VM is IDiagramDesignerItem and notify of moving end.
        /// </summary>
        void DragThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            diagramDesignerVM.MoveLinkAnchor(selectedItemVM, this.Id, e.HorizontalChange, e.VerticalChange);

            // remove drag adorner
            if (this.IsMouseCaptured)
                this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.diagramDesigner);
            if (adornerLayer != null)
            {
                if( this.dragAdorner != null )
                    adornerLayer.Remove(this.dragAdorner);
            }
            dragCanvas = null;

            e.Handled = false;
        }

        /// <summary>
        /// Move item(s).
        /// </summary>
        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (diagramDesignerVM == null || selectedItemVM == null ||selectedItem == null )
                return;

            if (dragCanvas.Children.Count != 1)
                return;

            if (this.EdgePointType == EdgePointVMType.Start)
            {
                PointD anchorLocation = selectedItemVM.CalcFromAnchorPosition(e.HorizontalChange, e.VerticalChange);
                UpdateLinkAnchorAndShape(
                    this.dragCanvas.Children[0] as DragItem,
                    anchorLocation,
                    new PointD(selectedItemVM.EndEdgePoint.X, selectedItemVM.EndEdgePoint.Y));
            }
            else if (this.EdgePointType == EdgePointVMType.End)
            {
                PointD anchorLocation = selectedItemVM.CalcToAnchorPosition(e.HorizontalChange, e.VerticalChange);
                UpdateLinkAnchorAndShape(
                    this.dragCanvas.Children[0] as DragItem,
                    new PointD(selectedItemVM.StartEdgePoint.X, selectedItemVM.StartEdgePoint.Y),
                    anchorLocation);
            }
            else
            {
                // TODO: Normal
            }

            // update adorned element
            this.dragAdorner.Update();
        }

        private void AddLinkAnchorAndShape(PointD locationFrom, PointD locationTo)
        {
            DragItem dragItem = new DragItem();

            Rectangle r = new Rectangle();
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.StrokeThickness = 1.0;
            r.Width = this.ActualWidth;
            r.Height = this.ActualHeight;
            if (this.EdgePointType == EdgePointVMType.Start)
                r.Margin = new System.Windows.Thickness(locationFrom.X, locationFrom.Y, 0, 0);
            else if (this.EdgePointType == EdgePointVMType.End)
                r.Margin = new System.Windows.Thickness(locationTo.X, locationTo.Y, 0, 0);
            else
            {
                //...
            }
            dragItem.Thumb = r;

            FixedGeometryPoints fixedPoints = FixedGeometryPoints.Source;
            if (this.EdgePointType == EdgePointVMType.End)
                fixedPoints = FixedGeometryPoints.Target;
            else if (this.EdgePointType == EdgePointVMType.Normal)
                fixedPoints = FixedGeometryPoints.None;

            Path path = new Path();
            path.Data = selectedItemVM.CalcPathGeometry(locationFrom, locationTo, fixedPoints, selectedItemVM.RoutingMode);
            path.Stroke = new SolidColorBrush(Colors.Black);
            path.StrokeThickness = 1.0;
            dragItem.Path = path;

            dragCanvas.Children.Add(dragItem);
        }
        private void UpdateLinkAnchorAndShape(DragItem item, PointD locationFrom, PointD locationTo)
        {
            if (item == null)
                return;

            if (this.EdgePointType == EdgePointVMType.Start)
                item.Thumb.Margin = new System.Windows.Thickness(locationFrom.X, locationFrom.Y, 0, 0);
            else if (this.EdgePointType == EdgePointVMType.End)
                item.Thumb.Margin = new System.Windows.Thickness(locationTo.X, locationTo.Y, 0, 0);
            else
            {
                //...
            }

            FixedGeometryPoints fixedPoints = FixedGeometryPoints.Source;
            if (this.EdgePointType == EdgePointVMType.End)
                fixedPoints = FixedGeometryPoints.Target;
            else if (this.EdgePointType == EdgePointVMType.Normal)
                fixedPoints = FixedGeometryPoints.None;
            item.Path.Data = selectedItemVM.CalcPathGeometry(locationFrom, locationTo, fixedPoints, selectedItemVM.RoutingMode);
        }

        /// <summary>
        /// Gets the edge point type.
        /// </summary>
        public EdgePointVMType EdgePointType
        {
            get
            {
                return edgePointVM.EdgePointType;
            }
        }

        /// <summary>
        /// Gets the edge point operation.
        /// </summary>
        public EdgePointVMOperation EdgePointOperation
        {
            get
            {
                return edgePointVM.EdgePointOperation;
            }
        }

        /// <summary>
        /// Gets or set the id of the edge point represented by this thumb.
        /// </summary>
        public Guid Id
        {
            get
            {
                return edgePointVM.EdgeId;
            }
        }

        /*
        /// <summary>
        /// Gets or sets whether this thumb represents the source or the target anchor.
        /// </summary>
        public bool IsSource
        {
            get { return this.isSource; }
            set
            {
                this.isSource = value;
            }
        }*/

        private class DragItem : Canvas
        {
            private Rectangle thumb = null;
            public Rectangle Thumb
            {
                get { return this.thumb; }
                set
                {
                    thumb = value;
                    this.Children.Add(thumb);
                }

            }

            private Path path = null;
            public Path Path
            {
                get { return this.path; }
                set
                {
                    path = value;
                    this.Children.Add(path);
                }

            }
        }
    }
}
