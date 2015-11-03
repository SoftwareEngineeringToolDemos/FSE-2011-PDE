using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Reflection info for diagram classes.
    /// </summary>
    public class DiagramClassInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramClassType">Diagram class type.</param>
        /// <param name="behavior">Visualization behavior.</param>
        public DiagramClassInfo(Guid diagramClassType, DiagramVisualizationBehavior behavior)
        {
            this.DiagramClassType = diagramClassType;
            this.VisualizationBehavior = behavior;
        }

        /// <summary>
        /// Gets the diagram class type.
        /// </summary>
        public Guid DiagramClassType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the visualization behavior.
        /// </summary>
        public DiagramVisualizationBehavior VisualizationBehavior
        {
            get;
            private set;
        }
    }
}
