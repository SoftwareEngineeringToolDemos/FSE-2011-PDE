using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Advanced reflection info for domain class.
    /// </summary>
    public class DomainClassAdvancedInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domainClassId">Domain class id.</param>
        public DomainClassAdvancedInfo(Guid domainClassId)
        {
            this.DomainClassId = domainClassId;
            this.IsAbstract = false;
        }

        /// <summary>
        /// Gets the domain class Id.
        /// </summary>
        public Guid DomainClassId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the DomainRelationshipInfo.
        /// </summary>
        /// <param name="store">Store to get the DomainRelationshipInfo from.</param>
        /// <returns>DomainRelationshipInfo if found; null otherwise.</returns>
        public DomainClassInfo GetInfo(Store store)
        {
            return store.DomainDataDirectory.FindDomainRelationship(DomainClassId);
        }

        /// <summary>
        /// Gets or sets whether the class is abstract or not.
        /// </summary>
        public bool IsAbstract
        {
            get;
            set;
        }
    }
}
