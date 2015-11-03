using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Base drop target adorner class.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public abstract class DropTargetAdorner : Adorner
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="adornedElement"></param>
        public DropTargetAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            m_AdornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);
            m_AdornerLayer.Add(this);
            IsHitTestVisible = false;
        }

        /// <summary>
        /// Detach.
        /// </summary>
        public void Detatch()
        {
            m_AdornerLayer.Remove(this);
        }

        /// <summary>
        /// Gets or sets the drop info.
        /// </summary>
        public DropInfo DropInfo { get; set; }

        internal static DropTargetAdorner Create(Type type, UIElement adornedElement)
        {
            if (!typeof(DropTargetAdorner).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(
                    "The requested adorner class does not derive from DropTargetAdorner.");
            }

            return (DropTargetAdorner)type.GetConstructor(new[] { typeof(UIElement) })
                .Invoke(new[] { adornedElement });
        }

        AdornerLayer m_AdornerLayer;
    }
}
