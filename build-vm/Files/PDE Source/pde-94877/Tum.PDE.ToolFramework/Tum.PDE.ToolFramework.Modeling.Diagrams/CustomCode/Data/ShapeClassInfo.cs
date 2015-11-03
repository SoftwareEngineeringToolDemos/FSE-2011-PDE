using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Reflection info for shape classes.
    /// </summary>
    public class ShapeClassInfo : ShapeElementInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramClassType">Diagram class type.</param>
        /// <param name="shapeClassType">Shape class type.</param>
        /// <param name="domainClassType">Domain class type.</param>
        /// <param name="usedInDependencyView"></param>
        public ShapeClassInfo(Guid diagramClassType, Guid shapeClassType, Guid domainClassType, bool usedInDependencyView)
            : base(diagramClassType)
        {
            this.ShapeClassType = shapeClassType;
            this.DomainClassType = domainClassType;
            this.UsedInDependencyView = usedInDependencyView;
            this.ParentShapeClassType = null;

            this.RelationshipSourceRoleTypes = new List<Guid>();
            this.RelationshipTargetRoleTypes = new List<Guid>();
            this.MappingRelationshipSourceRoleTypes = new List<Guid>();
            this.MappingRelationshipTargetRoleTypes = new List<Guid>();
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
        /// Gets or sets whether this shape is used in the dependency view.
        /// </summary>
        public bool UsedInDependencyView
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the parent shape class type.
        /// </summary>
        public Guid? ParentShapeClassType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the relationship role types, where the current shape class is the source.
        /// </summary>
        public List<Guid> RelationshipSourceRoleTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the relationship role types, where the current shape class is the target.
        /// </summary>
        public List<Guid> RelationshipTargetRoleTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the relationship role types, where the current shape class is the source.
        /// </summary>
        public List<Guid> MappingRelationshipSourceRoleTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the relationship role types, where the current shape class is the target.
        /// </summary>
        public List<Guid> MappingRelationshipTargetRoleTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the icon url.
        /// </summary>
        public string IconURL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the base shape.
        /// </summary>
        public Guid? BaseShape
        {
            get;
            set;
        }
    }
}
