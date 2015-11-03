using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Drop target adorners class.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DropTargetAdorners
    {
        /// <summary>
        /// Gets the highlight class type.
        /// </summary>
        public static Type Highlight
        {
            get { return typeof(DropTargetHighlightAdorner); }
        }

        /// <summary>
        /// Gets the insert class type.
        /// </summary>
        public static Type Insert
        {
            get { return typeof(DropTargetInsertionAdorner); }
        }
    }
}
