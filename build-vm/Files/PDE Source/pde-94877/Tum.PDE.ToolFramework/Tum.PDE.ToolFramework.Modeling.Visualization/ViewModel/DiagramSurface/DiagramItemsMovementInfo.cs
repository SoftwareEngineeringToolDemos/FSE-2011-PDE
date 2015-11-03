using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Movement values struct.
    /// </summary>
    public struct DiagramItemsMovementInfo
    {
        /// <summary>
        /// Horizontal change value.
        /// </summary>
        public double HorizontalChange { get; set; }

        /// <summary>
        /// Vertical change value.
        /// </summary>
        public double VerticalChange { get; set; }
    }
}
