using System;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyOriginItem
    {
        private DomainRelationshipInfo relationshipInfo;
        private DomainRoleInfo roleInfo;
        private Guid elementId;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipInfo">Relationship info.</param>
        /// <param name="roleInfo">Role info.</param>
        /// <param name="elementId">Element id.</param>
        public DependencyOriginItem(Guid elementId, DomainRelationshipInfo relationshipInfo, DomainRoleInfo roleInfo)
        {
            this.elementId = elementId;
            this.relationshipInfo = relationshipInfo;
            this.roleInfo = roleInfo;
        }

        /// <summary>
        /// Gets the relationship info.
        /// </summary>
        public DomainRelationshipInfo RelationshipInfo
        {
            get
            {
                return this.relationshipInfo;
            }
        }

        /// <summary>
        /// Gets the role info.
        /// </summary>
        public DomainRoleInfo RoleInfo
        {
            get
            {
                return this.roleInfo;
            }
        }

        /// <summary>
        /// Gets the element Id.
        /// </summary>
        public Guid ElementId
        {
            get
            {
                return this.elementId;
            }
        }
    }
}
