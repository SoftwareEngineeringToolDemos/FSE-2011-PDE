using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Resize direction info struct.
    /// </summary>
    public enum DiagramItemsResizeDirection
    {
        /// <summary>
        /// Resize in the left directin.
        /// </summary>
        Left,

        /// <summary>
        /// Resize in the upper direction.
        /// </summary>
        Top,

        /// <summary>
        /// Resize in the right direction.
        /// </summary>
        Right,

        /// <summary>
        /// Resize in the bottom direction.
        /// </summary>
        Bottom,

        /// <summary>
        /// Resize in the left+top direction.
        /// </summary>
        LeftTop,

        /// <summary>
        /// Resize in the left+bottom direction.
        /// </summary>
        LeftBottom,

        /// <summary>
        /// Resize in the right+top direction.
        /// </summary>
        RightTop,

        /// <summary>
        /// Resize in the left+bottom direction.
        /// </summary>
        RightBottom
    }
}
