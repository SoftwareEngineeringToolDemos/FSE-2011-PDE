using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Diagram visualization behavior.
    /// </summary>
    public enum DiagramVisualizationBehavior
    {
        /// <summary>
        /// Normal behavior, root shapes are inserted automatically if possible.
        /// </summary>
        Normal,

        /// <summary>
        /// Extended behavior, root shapes are displayed selectivly (user decision).
        /// </summary>
        Extended
    }
}
