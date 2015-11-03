using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Base class for shape reflection info.
    /// </summary>
    public abstract class ShapeElementInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramClassType">Diagram class type.</param>
        protected ShapeElementInfo(Guid diagramClassType)
        {
            this.DiagramClassType = diagramClassType;
        }

        /// <summary>
        /// Gets the diagram class type.
        /// </summary>
        public Guid DiagramClassType
        {
            get;
            private set;
        }
    }
}
