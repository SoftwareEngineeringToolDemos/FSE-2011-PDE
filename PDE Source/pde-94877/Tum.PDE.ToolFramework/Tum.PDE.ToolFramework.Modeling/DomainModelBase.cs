using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Base class for domain model implementation.
    /// </summary>
    [DomainObjectId("D734426D-505A-4DB5-AC79-CD06F9140904")]
    public abstract class DomainModelBase : DomainModel
    {
        #region Constructor, domain model Id
		/// <summary>
		/// VModellXTDomainModel domain model Id.
		/// </summary>
        public static readonly global::System.Guid DomainModelId = new System.Guid("D734426D-505A-4DB5-AC79-CD06F9140904");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
        /// <param name="dModelId">Domain model Id.</param>
        protected DomainModelBase(DomainModelStore store, Guid dModelId)
            : base(store, dModelId)
		{
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="store">Store containing the domain model.</param>
        /// <param name="dModelId">Domain model Id.</param>
        protected DomainModelBase(Store store, Guid dModelId)
            : base(store, dModelId)
        {
        }
		#endregion	

        /// <summary>
        /// Gets domain classes advanced reflection information.
        /// </summary>
        public abstract DomainClassAdvancedInfo[] GetDomainClassAdvancedInfo();

        /// <summary>
        /// Gets domain relationships advanced reflection information.
        /// </summary>
        public abstract DomainRelationshipAdvancedInfo[] GetDomainRelationshipAdvancedInfo();

        /// <summary>
        /// Gets the embedding relationships order information (parent-child mappings in the order of the serialization model).
        /// </summary>
        public abstract EmbeddingRelationshipOrderInfo[] GetEmbeddingRelationshipOrderInfo();

        /// <summary>
        /// Gets the model context informations.
        /// </summary>
        public abstract ModelContextInfo[] GetModelContextInfo();

        /// <summary>
        /// Gets data extensions.
        /// </summary>
        /// <returns>List of data extensions or null.</returns>
        public virtual IDomainDataExtensionDirectory[] GetDataExtensions()
        {
            return null;
        }
    }
}
