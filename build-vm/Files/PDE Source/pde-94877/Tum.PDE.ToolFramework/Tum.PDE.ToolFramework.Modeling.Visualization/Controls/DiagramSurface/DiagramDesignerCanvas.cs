using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This is used as the panel in the DiagramDesignerItems control.
    /// </summary>
    public class DiagramDesignerCanvas : Canvas
    {
        //private Point? rubberbandSelectionStartPoint = null;

        /*
        /// <summary>
        /// Cancels the rubberband selection.
        /// </summary>
        public void CancelRubberbandSelection()
        {
            this.rubberbandSelectionStartPoint = null;
        }*/

        /// <summary>
        /// Set the starting point for a possible rubberband selection. Clear selection if
        /// this is the top most container.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Source == this && e.LeftButton == MouseButtonState.Pressed)
            {
                // in case that this click is the start of a 
                // drag operation we cache the start point
                //this.rubberbandSelectionStartPoint = new Point?(e.GetPosition(this));
                DiagramRubberbandSelector.RubberbandSelectionStartPoint = new Point?(e.GetPosition(this));
            }
            if (e.Source == this && IsTopMostContainer())
            {
                DiagramDesigner designer = DiagramHelper.GetDiagramDesigner(this);
                if (designer != null)
                {
                    if (designer.SelectionService.CurrentSelection.Count > 0)
                        designer.SelectionService.ClearSelection(true);
                    Focus();
                }
            }
        }

        /// <summary>
        /// Start rubberband selection if mouse button is still pressed.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.LeftButton != MouseButtonState.Pressed)
                DiagramRubberbandSelector.CancelRubberbandSelection();
            else
                DiagramRubberbandSelector.DrawOnMouseMove(e, this);

            /*
            if (this.rubberbandSelectionStartPoint.HasValue)
            {
                // if mouse button is not pressed we have no drag operation, ...
                if (e.LeftButton != MouseButtonState.Pressed || IgnoreRubberbandSelection)

                    CancelRubberbandSelection();

                // ... but if mouse button is pressed and start
                // point value is set we do have one
                else
                {
                    Point pCurrent = e.GetPosition(this);
                    if (Math.Abs(pCurrent.X - rubberbandSelectionStartPoint.Value.X) > 5 ||
                        Math.Abs(pCurrent.Y - rubberbandSelectionStartPoint.Value.Y) > 5)
                    {
                        // create rubberband adorner
                        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                        if (adornerLayer != null)
                        {
                            DiagramDesignerRubberbandAdorner adorner = new DiagramDesignerRubberbandAdorner(this, rubberbandSelectionStartPoint);
                            if (adorner != null)
                            {
                                adornerLayer.Add(adorner);
                            }
                        }
                    }
                }
            }*/
            e.Handled = true;
        }

        /// <summary>
        /// Verifies if this is the top most container in the canvas hierarchy.
        /// </summary>
        /// <returns>True if this is the top most container; False otherwise.</returns>
        public virtual bool IsTopMostContainer()
        {
            if (DiagramHelper.GetDiagramDesignerItem(this) == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Calculate the actual size because it is unknown otherwise, since we
        /// are using a canvas.
        /// </summary>
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }


    }
}
