using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Drag source interface.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public interface IDragSource
    {
        /// <summary>
        /// Start.
        /// </summary>
        /// <param name="dragInfo">Info.</param>
        void StartDrag(DragInfo dragInfo);
    }
}
