using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Documents;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Helper class to render the rubberband selector on the diagram surface.
    /// </summary>
    public static class DiagramRubberbandSelector
    {
        /// <summary>
        /// Start point of the selector.
        /// </summary>
        public static Point? RubberbandSelectionStartPoint;

        /// <summary>
        /// Ignore the next drawing event.
        /// </summary>
        public static bool IgnoreRubberbandSelectionOnce = false;

        /// <summary>
        /// Cancel rubberband selection.
        /// </summary>
        public static void CancelRubberbandSelection()
        {
            RubberbandSelectionStartPoint = null;
            DiagramRubberbandSelector.IgnoreRubberbandSelectionOnce = false;
        }

        /// <summary>
        /// Draw the rubberband.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="control"></param>
        public static void DrawOnMouseMove(MouseEventArgs e, DiagramDesignerCanvas control)
        {
            if (IgnoreRubberbandSelectionOnce)
            {
                IgnoreRubberbandSelectionOnce = false;
                CancelRubberbandSelection();
                return;
            }

            if (RubberbandSelectionStartPoint.HasValue)
            {
                // if mouse button is not pressed we have no drag operation, ...
                if (e.LeftButton != MouseButtonState.Pressed)

                    RubberbandSelectionStartPoint = null;

                // ... but if mouse button is pressed and start
                // point value is set we do have one
                else
                {
                    Point pCurrent = e.GetPosition(control);
                    if (Math.Abs(pCurrent.X - RubberbandSelectionStartPoint.Value.X) > 5 ||
                        Math.Abs(pCurrent.Y - RubberbandSelectionStartPoint.Value.Y) > 5)
                    {
                        // create rubberband adorner
                        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(control);
                        if (adornerLayer != null)
                        {
                            DiagramDesignerRubberbandAdorner adorner = new DiagramDesignerRubberbandAdorner(control, RubberbandSelectionStartPoint);
                            if (adorner != null)
                            {
                                adornerLayer.Add(adorner);
                            }
                        }
                    }
                }
            }

        }
    }
}
