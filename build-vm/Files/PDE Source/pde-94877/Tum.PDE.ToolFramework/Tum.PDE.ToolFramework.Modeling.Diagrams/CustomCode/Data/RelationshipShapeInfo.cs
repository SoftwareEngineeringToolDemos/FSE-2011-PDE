using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Reflection info for the relationship shape.
    /// </summary>
    public class RelationshipShapeInfo : ShapeElementInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramClassType">Diagram class type.</param>
        /// <param name="shapeClassType">Shape class type.</param>
        /// <param name="domainClassType">Domain class type.</param>
        public RelationshipShapeInfo(Guid diagramClassType, Guid shapeClassType, Guid domainClassType)
            : base(diagramClassType)
        {
            this.ShapeClassType = shapeClassType;
            this.DomainClassType = domainClassType;
        }

        /// <summary>
        /// Gets the shape class type.
        /// </summary>
        public Guid ShapeClassType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the domain class type.
        /// </summary>
        public Guid DomainClassType
        {
            get;
            private set;
        }
    }
}
