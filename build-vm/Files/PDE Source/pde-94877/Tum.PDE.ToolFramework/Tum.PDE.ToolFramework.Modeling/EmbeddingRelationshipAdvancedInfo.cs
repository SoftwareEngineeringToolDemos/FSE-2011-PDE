using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Advanced reflection info for reference relationship.
    /// </summary>
    public class EmbeddingRelationshipAdvancedInfo : DomainRelationshipAdvancedInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipDomainClassId">Domain relationship id.</param>
        public EmbeddingRelationshipAdvancedInfo(Guid relationshipDomainClassId)
            : this(relationshipDomainClassId, true, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipDomainClassId">Relationship domain class Id.</param>
        /// <param name="propagatesCopyToChild">Propagates copy to child.</param>
        /// <param name="isTargetIncludedSubmodel"></param>
        public EmbeddingRelationshipAdvancedInfo(Guid relationshipDomainClassId, bool propagatesCopyToChild, bool isTargetIncludedSubmodel)
            : base(relationshipDomainClassId)
        {
            this.PropagatesCopyToChild = propagatesCopyToChild;
            this.IsTargetIncludedSubmodel = isTargetIncludedSubmodel;
        }

        /// <summary>
        /// Gets the "PropagatesCopyToChild" property.
        /// </summary>
        public bool PropagatesCopyToChild
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the "IsTargetIncludedSubmodel" property.
        /// </summary>
        public bool IsTargetIncludedSubmodel
        {
            get;
            private set;
        }

    }
}
