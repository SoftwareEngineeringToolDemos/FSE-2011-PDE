using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Advanced reflection info for reference relationship.
    /// </summary>
    public class ReferenceRelationshipAdvancedInfo : DomainRelationshipAdvancedInfo
    {      
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipDomainClassId">Domain relationship id.</param>
        public ReferenceRelationshipAdvancedInfo(Guid relationshipDomainClassId)
            : this(relationshipDomainClassId, false, true, true)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipDomainClassId">Relationship domain class Id.</param>
        /// <param name="propagatesCopyToSource">Propagates copy to source.</param>
        /// <param name="propagatesCopyToTarget">Propagates copy to target.</param>
        /// <param name="propagatesCopyOnDeniedElement">Propagates copy on denied element.</param>
        public ReferenceRelationshipAdvancedInfo(Guid relationshipDomainClassId, bool propagatesCopyToSource, bool propagatesCopyToTarget, bool propagatesCopyOnDeniedElement)
            : base(relationshipDomainClassId)
        {
            this.PropagatesCopyToSource = propagatesCopyToSource;
            this.PropagatesCopyToTarget = propagatesCopyToTarget;
            this.PropagatesCopyOnDeniedElement = propagatesCopyOnDeniedElement;
        }

        /// <summary>
        /// Gets the "PropagatesCopyToSource" property.
        /// </summary>
        public bool PropagatesCopyToSource
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the "PropagatesCopyToTarget" property.
        /// </summary>
        public bool PropagatesCopyToTarget
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the "PropagatesCopyOnDeniedElement" property.
        /// </summary>
        public bool PropagatesCopyOnDeniedElement
        {
            get;
            private set;
        }
    }
}
