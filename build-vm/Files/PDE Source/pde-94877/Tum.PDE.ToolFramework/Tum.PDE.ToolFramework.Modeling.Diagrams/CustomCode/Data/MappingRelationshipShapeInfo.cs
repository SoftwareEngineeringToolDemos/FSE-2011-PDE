using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public class MappingRelationshipShapeInfo : ShapeElementInfo
    {/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramClassType">Diagram class type.</param>
        /// <param name="shapeClassType">Shape class type.</param>
        /// <param name="domainClassType">Domain class type.</param>
        /// <param name="sourceRSType">Source relationship type.</param>
        /// <param name="targetRSType">Target relationship type.</param>
        /// <param name="sourceDomainRole">Source domain role.</param>
        /// <param name="targetDomainRole">Target domain role.</param>
        public MappingRelationshipShapeInfo(Guid diagramClassType, Guid shapeClassType, Guid domainClassType, Guid sourceRSType, Guid targetRSType,
            Guid sourceDomainRole, Guid targetDomainRole)
            : base(diagramClassType)
        {
            this.ShapeClassType = shapeClassType;
            this.DomainClassType = domainClassType;
            this.SourceRelationshipType = sourceRSType;
            this.TargetRelationshipType = targetRSType;
            this.SourceDomainRole = sourceDomainRole;
            this.TargetDomainRole = targetDomainRole;
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

        /// <summary>
        /// Gets the source relationship type.
        /// </summary>
        public Guid SourceRelationshipType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the target relationship type.
        /// </summary>
        public Guid TargetRelationshipType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the source domain role type.
        /// </summary>
        public Guid SourceDomainRole
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the target domain role type.
        /// </summary>
        public Guid TargetDomainRole
        {
            get;
            private set;
        }
    }
}
