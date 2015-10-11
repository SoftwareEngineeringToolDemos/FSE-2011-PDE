using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This class is used to move diagram items.
    /// </summary>
    public class DiagramDesignerItemDragThumb : Thumb
    {
        /// <summary>
        /// Value indicating the minimal distance the dragging operation requires to have 
        /// passed before starting the actual movement of the selected elements.
        /// </summary>
        public static double MinDistanceToStart = 3.0;

        private DiagramDesigner diagramDesigner;
        private IDiagramViewModel diagramDesignerVM;
        private List<DiagramDesignerItem> selectedItems;
        private List<IDiagramItemViewModel> selectedItemsVM;
        private DragAdorner dragAdorner;
        private bool dragStarted = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiagramDesignerItemDragThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(DragThumb_DragDelta);
            base.DragCompleted += new DragCompletedEventHandler(DragThumb_DragCompleted);
            base.DragStarted += new DragStartedEventHandler(DragThumb_DragStarted);
        }

        /// <summary>
        /// Dragging has started, see if VM is IDiagramDesignerItem and notify of moving start.
        /// </summary>
        void DragThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
        }

        /// <summary>
        /// Start the drag operation.
        /// </summary>
        private void Start()
        {
            diagramDesigner = DiagramHelper.GetDiagramDesigner(this);
            diagramDesignerVM = diagramDesigner.DataContext as IDiagramViewModel;
            
            selectedItems = new List<DiagramDesignerItem>();
            selectedItemsVM = new List<IDiagramItemViewModel>();

            List<ISelectable> selection = diagramDesigner.SelectionService.CurrentSelection;
            foreach (ISelectable item in selection)
            {
                if (item is DiagramDesignerItem)
                    if (!(item as DiagramDesignerItem).IsDiagramLink)
                    {
                        selectedItems.Add(item as DiagramDesignerItem);
                    }
            }

            // create control to display on the drag adorner
            Canvas canvas = new Canvas();
            foreach (DiagramDesignerItem item in selectedItems)
            {
                IDiagramItemViewModel designerItem = item.DataContext as IDiagramItemViewModel;
                if (designerItem == null)
                    continue;

                selectedItemsVM.Add(designerItem);                    

                Rectangle r = new Rectangle();
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.StrokeDashArray = new DoubleCollection();
                r.StrokeDashArray.Add(3);
                r.StrokeDashArray.Add(6);
                r.StrokeThickness = 1.0;
                r.Width = item.ActualWidth;
                r.Height = item.ActualHeight;
                r.Margin = new System.Windows.Thickness(designerItem.AbsoluteLocation.X, designerItem.AbsoluteLocation.Y, 0, 0);
                canvas.Children.Add(r);
            }

            // create drag adorner 
            if (diagramDesigner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(diagramDesigner);
                if (adornerLayer != null)
                {
                    this.dragAdorner = new DragAdorner(diagramDesigner, canvas, false, 1.0);
                    if (this.dragAdorner != null)
                    {
                        adornerLayer.Add(this.dragAdorner);
                        //e.Handled = true;
                    }
                }
            }
            //e.Handled = false;
        }

        /// <summary>
        /// Dragging has ended, see if VM is IDiagramDesignerItem and notify of moving end.
        /// </summary>
        void DragThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (!dragStarted)
                return;
            else
                dragStarted = false;

            DiagramItemsMovementInfo movementInfo = diagramDesignerVM.CalcMovementInfo(this.selectedItemsVM, e.HorizontalChange, e.VerticalChange);
            diagramDesignerVM.MoveElements(selectedItemsVM, movementInfo);

            List<DiagramDesignerCanvas> selectionParentCanvases = new List<DiagramDesignerCanvas>();
            foreach (DiagramDesignerItem item in selectedItems)
            {
                /*
                IDiagramItemViewModel designerItem = item.DataContext as IDiagramItemViewModel;
                if (designerItem == null)
                    continue;

                // apply change
                double left = designerItem.Left + dragAdorner.LeftOffset;
                double top = designerItem.Top + dragAdorner.TopOffset;
                designerItem.Location = new PointD(left, top);
                */
                DiagramDesignerCanvas canvas = (item as DiagramDesignerItem).ParentCanvas;
                if (canvas != null)
                    if (!selectionParentCanvases.Contains(canvas))
                        selectionParentCanvases.Add(canvas);
            }

            // update diagram surfaces
            foreach (DiagramDesignerCanvas canvas in selectionParentCanvases)
                if (canvas != null)
                    canvas.InvalidateMeasure();

            // remove drag adorner
            if (this.IsMouseCaptured) 
                this.ReleaseMouseCapture();

            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.diagramDesigner);
            if (adornerLayer != null)
            {
                adornerLayer.Remove(this.dragAdorner);
            }

            e.Handled = false;
        }

        /// <summary>
        /// Move item(s).
        /// </summary>
        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (!dragStarted)
            {
                if (Math.Abs(e.HorizontalChange) >= MinDistanceToStart || Math.Abs(e.VerticalChange) >= MinDistanceToStart)
                {
                    Start();
                    dragStarted = true;
                }
            }

            if (dragStarted)
            {
                if (diagramDesignerVM == null)
                    return;

                // update position of the drag adorner
                DiagramItemsMovementInfo movementInfo = diagramDesignerVM.CalcMovementInfo(this.selectedItemsVM, e.HorizontalChange, e.VerticalChange);
                this.dragAdorner.LeftOffset = movementInfo.HorizontalChange;
                this.dragAdorner.TopOffset = movementInfo.VerticalChange;
            }
        }
    }
}
