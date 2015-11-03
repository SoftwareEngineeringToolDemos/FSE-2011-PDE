using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Resize info struct.
    /// </summary>
    public struct DiagramItemsResizeInfo
    {
        /// <summary>
        /// Width change value.
        /// </summary>
        public double WidthChange { get; set; }

        /// <summary>
        /// Height change value.
        /// </summary>
        public double HeightChange { get; set; }

        /// <summary>
        /// X-Position change value.
        /// </summary>
        public double LeftChange { get; set; }

        /// <summary>
        /// Y-Position change value.
        /// </summary>
        public double TopChange { get; set; }
    }
}
