using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Diagram connectors are used to create new relationships between diagram items. They are
    /// the source elements, where such creations can be initiated.
    /// </summary>
    public class DiagramConnector : Control
    {
        /// <summary>
        /// Drag start point, relative to the DesignerCanvas.
        /// </summary>
        private Point? dragStartPoint = null;

        /// <summary>
        /// Get start point of the possible selection operation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DiagramDesigner designer = DiagramHelper.GetDiagramDesigner(this);
            if (designer != null)
            {
                // position relative to DesignerCanvas
                this.dragStartPoint = new Point?(e.GetPosition(designer));
                e.Handled = true;
            }
        }

        /// <summary>
        /// Process selection operation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.dragStartPoint = null;

            // but if mouse button is pressed and start point value is set we do have one
            if (this.dragStartPoint.HasValue)
            {
                // create connection adorner 
                DiagramDesigner designer = DiagramHelper.GetDiagramDesigner(this);
                if (designer != null)
                {
                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(designer);
                    if (adornerLayer != null)
                    {
                        DiagramConnectorAdorner adorner = new DiagramConnectorAdorner(designer, this, this.dragStartPoint.Value);
                        if (adorner != null)
                        {
                            adornerLayer.Add(adorner);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the diagram item, to which this connector belongs.
        /// </summary>
        public DiagramDesignerItem DiagramItem
        {
            get
            {
                return DiagramHelper.GetDiagramDesignerItem(this);
            }
        }
    }
}
