using System;
using System.Collections.Generic;
using System.Windows;
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
    /// This class is used to resize diagram items.
    /// </summary>
    public class DiagramDesignerItemResizeThumb : Thumb
    {
        /// <summary>
        /// Value indicating the minimal distance the dragging operation requires to have 
        /// passed before starting the actual resizing of the selected elements.
        /// </summary>
        public static double MinDistanceToStart = 3.0;

        private DiagramDesigner diagramDesigner;
        private IDiagramViewModel diagramDesignerVM;
        private List<DiagramDesignerItem> selectedItems;
        private List<IDiagramItemViewModel> selectedItemsVM;
        private DragAdorner dragAdorner;
        private Canvas dragCanvas;
        private DiagramItemsResizeDirection ?direction;
        private bool dragStarted = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiagramDesignerItemResizeThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(ResizeThumb_DragDelta);
            base.DragCompleted += new DragCompletedEventHandler(ResizeThumb_DragCompleted);
            base.DragStarted += new DragStartedEventHandler(ResizeThumb_DragStarted);
        }

        /// <summary>
        /// Dragging has started, see if VM is IDiagramDesignerItem and notify of resizing start.
        /// </summary>
        void ResizeThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            dragStarted = false;
        }
     
        /// <summary>
        /// Start the drag operation.
        /// </summary>
        private void Start()
        {
            if (direction == null)
            {
                if (base.VerticalAlignment == System.Windows.VerticalAlignment.Top)
                {
                    if (base.HorizontalAlignment == System.Windows.HorizontalAlignment.Left)
                        direction = DiagramItemsResizeDirection.LeftTop;
                    else if (base.HorizontalAlignment == System.Windows.HorizontalAlignment.Stretch)
                        direction = DiagramItemsResizeDirection.Top;
                    else
                        direction = DiagramItemsResizeDirection.RightTop;
                }
                else if (base.VerticalAlignment == System.Windows.VerticalAlignment.Bottom)
                {
                    if (base.HorizontalAlignment == System.Windows.HorizontalAlignment.Left)
                        direction = DiagramItemsResizeDirection.LeftBottom;
                    else if (base.HorizontalAlignment == System.Windows.HorizontalAlignment.Stretch)
                        direction = DiagramItemsResizeDirection.Bottom;
                    else
                        direction = DiagramItemsResizeDirection.RightBottom;
                }
                else
                {
                    if (base.HorizontalAlignment == System.Windows.HorizontalAlignment.Left)
                        direction = DiagramItemsResizeDirection.Left;
                    else
                        direction = DiagramItemsResizeDirection.Right;
                }

            }
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
            dragCanvas = new Canvas();
            foreach (DiagramDesignerItem item in selectedItems)
            {
                if (item.DataContext is IDiagramItemViewModel)
                    selectedItemsVM.Add(item.DataContext as IDiagramItemViewModel);

                Rectangle r = new Rectangle();
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.StrokeDashArray = new DoubleCollection();
                r.StrokeDashArray.Add(3);
                r.StrokeDashArray.Add(6);
                r.StrokeThickness = 1.0;
                r.Width = item.ActualWidth;
                r.Height = item.ActualHeight;
                r.Margin = new System.Windows.Thickness(item.AbsoluteLocation.X, item.AbsoluteLocation.Y, 0, 0);
                dragCanvas.Children.Add(r);
            }

            // create drag adorner 
            if (diagramDesigner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(diagramDesigner);
                if (adornerLayer != null)
                {
                    this.dragAdorner = new DragAdorner(diagramDesigner, dragCanvas, false, 1.0);
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
        /// Dragging has ended, see if VM is IDiagramDesignerItem and notify of resizing end.
        /// </summary>
        void ResizeThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (!dragStarted)
                return;
            else
                dragStarted = false;

            DiagramItemsResizeInfo resizeInfo = diagramDesignerVM.CalcResizeInfo(this.selectedItemsVM, e.HorizontalChange, e.VerticalChange, direction.Value);
            diagramDesignerVM.ResizeElements(this.selectedItemsVM, resizeInfo);

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
        /// Resize item(s).
        /// </summary>
        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
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
                DiagramItemsResizeInfo resizeInfo = diagramDesignerVM.CalcResizeInfo(this.selectedItemsVM, e.HorizontalChange, e.VerticalChange, direction.Value);
                if (selectedItemsVM.Count != dragCanvas.Children.Count)
                    return;

                for (int i = 0; i < selectedItemsVM.Count; i++)
                {
                    FrameworkElement elem = dragCanvas.Children[i] as FrameworkElement;
                    if (elem != null)
                    {
                        elem.Margin = new System.Windows.Thickness(
                            selectedItemsVM[i].AbsoluteLocation.X + resizeInfo.LeftChange,
                            selectedItemsVM[i].AbsoluteLocation.Y + resizeInfo.TopChange, 0, 0);
                        elem.Width = selectedItemsVM[i].Width + resizeInfo.WidthChange;
                        elem.Height = selectedItemsVM[i].Height + resizeInfo.HeightChange;
                    }
                }

                // update adorned element
                this.dragAdorner.Update();
            }
        }
    }
}
