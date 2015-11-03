using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Drop target interface.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public interface IDropTarget
    {
        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        void DragOver(DropInfo dropInfo);

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        void Drop(DropInfo dropInfo);
    }
}
