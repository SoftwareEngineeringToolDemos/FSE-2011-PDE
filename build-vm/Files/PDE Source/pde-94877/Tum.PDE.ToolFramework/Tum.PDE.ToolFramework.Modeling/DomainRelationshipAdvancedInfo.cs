using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Advanced reflection info for domain relationship.
    /// </summary>
    public abstract class DomainRelationshipAdvancedInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="relationshipDomainClassId">Domain relationship id.</param>
        protected DomainRelationshipAdvancedInfo(Guid relationshipDomainClassId)
        {
            this.RelationshipDomainClassId = relationshipDomainClassId;
            this.IsAbstract = false;

            this.SourceRoleIsUIBrowsable = true;
            this.SourceRoleIsUIReadOnly = false;
            this.SourceRoleIsGenerated = true;
            this.TargetRoleIsUIBrowsable = true;
            this.TargetRoleIsUIReadOnly = false;
            this.TargetRoleIsGenerated = true;
        }

        /// <summary>
        /// Gets the relationship domain class Id.
        /// </summary>
        public Guid RelationshipDomainClassId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the DomainRelationshipInfo.
        /// </summary>
        /// <param name="store">Store to get the DomainRelationshipInfo from.</param>
        /// <returns>DomainRelationshipInfo if found; null otherwise.</returns>
        public DomainRelationshipInfo GetInfo(Store store)
        {
            return store.DomainDataDirectory.FindDomainRelationship(RelationshipDomainClassId);
        }

        /// <summary>
        /// Gets or sets whether the relationship is abstract or not.
        /// </summary>
        public bool IsAbstract
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source element domain class Id.
        /// </summary>
        public Guid SourceElementDomainClassId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the target element domain class Id.
        /// </summary>
        public Guid TargetElementDomainClassId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source role Id.
        /// </summary>
        public Guid SourceRoleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the target role Id.
        /// </summary>
        public Guid TargetRoleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source role multiplicity.
        /// </summary>
        public Multiplicity SourceRoleMultiplicity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the target role multiplicity.
        /// </summary>
        public Multiplicity TargetRoleMultiplicity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool SourceRoleIsUIBrowsable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool SourceRoleIsUIReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool SourceRoleIsGenerated
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool TargetRoleIsUIBrowsable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool TargetRoleIsUIReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this property can be viewed in the UI.
        /// </summary>
        public bool TargetRoleIsGenerated
        {
            get;
            set;
        }
    }
}
