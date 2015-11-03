using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Rubberband selection adorner.
    /// </summary>
    public class DiagramDesignerRubberbandAdorner : Adorner
    {
        private Point? startPoint;
        private Point? endPoint;
        private Pen rubberbandPen;

        private DiagramDesignerCanvas designerCanvas;
        private DiagramDesigner designer;

        private double dragDecoratorInflateValue = 24;

        /// <summary>
        /// Used to itemBounds.Inflate(-DragDecoratorInflateValue, -DragDecoratorInflateValue). ItemBounds specify
        /// the bounds of a diagram item.
        /// </summary>
        public double DragDecoratorInflateValue
        {
            get { return this.dragDecoratorInflateValue; }
            set
            {
                this.dragDecoratorInflateValue = value;
            }
        }

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="designerCanvas">Designer items canvas.</param>
        /// <param name="dragStartPoint">Start point.</param>
        public DiagramDesignerRubberbandAdorner(DiagramDesignerCanvas designerCanvas, Point? dragStartPoint)
            : base(designerCanvas)
        {
            this.designerCanvas = designerCanvas;
            this.designer = DiagramHelper.GetDiagramDesigner(this.designerCanvas);
            this.startPoint = dragStartPoint;

            rubberbandPen = new Pen(Brushes.LightSlateGray, 1);
            rubberbandPen.DashStyle = new DashStyle(new double[] { 2 }, 1);
        }

        /// <summary>
        /// Release mouse and update selection if necessary.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                endPoint = e.GetPosition(this);
                UpdateSelection();
                this.InvalidateVisual();
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }

            e.Handled = true;
        }

        /// <summary>
        /// Remove layer.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            // release mouse capture
            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            // remove this adorner from adorner layer
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.designerCanvas);
            if (adornerLayer != null)
                adornerLayer.Remove(this);

            e.Handled = true;
        }

        /// <summary>
        /// Renders the rubberband selection adorner.
        /// </summary>
        /// <param name="dc">Drawing context.</param>
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            // without a background the OnMouseMove event would not be fired!
            // Alternative: implement a Canvas as a child of this adorner, like
            // the ConnectionAdorner does.
            dc.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            if (this.startPoint.HasValue && this.endPoint.HasValue)
                dc.DrawRectangle(Brushes.Transparent, rubberbandPen, new Rect(this.startPoint.Value, this.endPoint.Value));
        }

        /// <summary>
        /// Updates the selection.
        /// </summary>
        private void UpdateSelection()
        {
            Collection<ISelectable> itemsToSelect = new Collection<ISelectable>();
            Rect rubberBand = new Rect(startPoint.Value, endPoint.Value);

            UpdateSelection(itemsToSelect, rubberBand, designerCanvas);

            designer.SelectionService.SelectItems(itemsToSelect);
        }
        private void UpdateSelection(Collection<ISelectable> itemsToSelect, Rect rubberBand, DiagramDesignerCanvas dCanvas)
        {
            foreach (Control item in dCanvas.Children)
            {
                Rect itemRect = VisualTreeHelper.GetDescendantBounds(item);
                Rect itemBounds = item.TransformToAncestor(designerCanvas).TransformBounds(itemRect);

                // drag decorator requires this;
                itemBounds.Inflate(-DragDecoratorInflateValue, -DragDecoratorInflateValue);

                if (rubberBand.Contains(itemBounds))
                {
                    if (item is ISelectable)
                        itemsToSelect.Add(item as ISelectable);
                }

                if (item is DiagramDesignerItem)
                {
                    DiagramDesignerItem designerItem = item as DiagramDesignerItem;
                    if (designerItem.IsDiagramLink)
                        continue;

                    DiagramDesignerCanvas canvas = DiagramHelper.GetChild(designerItem, typeof(DiagramDesignerCanvas)) as DiagramDesignerCanvas;
                    if (canvas != null)
                    {
                        UpdateSelection(itemsToSelect, rubberBand, canvas);
                    }
                }
            }
        }
    }
}
