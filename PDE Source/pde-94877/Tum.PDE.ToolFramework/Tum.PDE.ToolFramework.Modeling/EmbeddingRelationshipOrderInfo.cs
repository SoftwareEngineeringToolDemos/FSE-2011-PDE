using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class used to store parent children mapping information in the order defined in the serialization model.
    /// </summary>
    public class EmbeddingRelationshipOrderInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domainClassId">DomainClassId of the domain class acting as parent.</param>
        /// <param name="embeddingRelationships">embeddingRelationships</param>
        public EmbeddingRelationshipOrderInfo(Guid domainClassId, params Guid[] embeddingRelationships)
        {
            this.DomainClassId = domainClassId;
            this.EmbeddingRelationships = embeddingRelationships;
        }

        /// <summary>
        /// Gets the id (DomainClassId) of the domain class.
        /// </summary>
        public Guid DomainClassId
        {
            get;
            private set;
        }

        /// <summary>
        /// DomainClassIds of EmbeddingRelationships that specify the parent children mapping.
        /// </summary>
        public Guid[] EmbeddingRelationships
        {
            get;
            set;
        }

        /// <summary>
        /// DomainClassIds of EmbeddingRelationships that specify the parent children mapping as TargetIncludedSubmodel.
        /// </summary>
        public Guid[] EmbeddingRelationshipsTargetIncludedSubmodel
        {
            get;
            set;
        }
    }
}
