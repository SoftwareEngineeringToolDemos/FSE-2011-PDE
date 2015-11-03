using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This base abstract class provides methods for a dependency items provder that needs to be overriden in the actual domain model instance. 
    /// </summary>
    public abstract class DependencyItemsProvider : IDependencyItemsProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        protected DependencyItemsProvider()
        {
            ExternEmbeddedInformation = new List<ExternInformation>();
            ExternReferenceInformation = new List<ExternInformation>();
        }

        /// <summary>
        /// Extern information helper struct.
        /// </summary>
        protected struct ExternInformation
        {
            /// <summary>
            /// Relationship DomainClassID.
            /// </summary>
            public Guid RelationshipDomainClassId;

            /// <summary>
            /// Domain role id;
            /// </summary>
            public Guid DomainRoleId;

            /// <summary>
            /// Domain model id.
            /// </summary>
            public Guid DomainModelId;
        }

        /// <summary>
        /// Extern embedded information.
        /// </summary>
        protected List<ExternInformation> ExternEmbeddedInformation
        {
            get;
            private set;
        }

        /// <summary>
        /// Extern reference information.
        /// </summary>
        protected List<ExternInformation> ExternReferenceInformation
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds an extern embedded information to process while searching for dependencies.
        /// </summary>
        /// <param name="relationshipDomainClassId">Rs. DomainClassID</param>
        /// <param name="domainRoleId">Domain role ID</param>
        /// <param name="domainModelId">Domain model ID</param>
        public void AddExternEmbeddedInformation(Guid relationshipDomainClassId, Guid domainRoleId, Guid domainModelId)
        {
            ExternInformation info = new ExternInformation();
            info.RelationshipDomainClassId = relationshipDomainClassId;
            info.DomainRoleId = domainRoleId;
            info.DomainModelId = domainModelId;
            this.ExternEmbeddedInformation.Add(info);
        }

        /// <summary>
        /// Adds an extern reference information to process while searching for dependencies.
        /// </summary>
        /// <param name="relationshipDomainClassId">Rs. DomainClassID</param>
        /// <param name="domainRoleId">Domain role ID</param>
        /// <param name="domainModelId">Domain model ID</param>
        public void AddExternReferencedInformation(Guid relationshipDomainClassId, Guid domainRoleId, Guid domainModelId)
        {
            ExternInformation info = new ExternInformation();
            info.RelationshipDomainClassId = relationshipDomainClassId;
            info.DomainRoleId = domainRoleId;
            info.DomainModelId = domainModelId;
            this.ExternReferenceInformation.Add(info);
        }

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="dependenciesData">Dependencies data to add new dependency and origin items to.</param>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        public abstract void GetDependencies(DependenciesData dependenciesData, ModelElement modelElement);

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="dependenciesData">Dependencies data to add new dependency and origin items to.</param>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <param name="options">Options</param>
        public abstract void GetDependencies(DependenciesData dependenciesData, ModelElement modelElement, DependenciesRetrivalOptions options);
    }
}
