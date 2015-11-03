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
    public abstract class DependenciesItemsProvider : IDependenciesItemsProvider
    {
        private static DependencyItemCategory[] AllCategories = null;

        /// <summary>
        /// Returns all dependency item categories as an array.
        /// </summary>
        /// <returns>Array of dependency item categories.</returns>
        public static DependencyItemCategory[] GetAllCategories()
        {
            if (AllCategories == null)
                AllCategories = new DependencyItemCategory[]{
                    DependencyItemCategory.Embedding, DependencyItemCategory.Embedded, 
                    DependencyItemCategory.Referencing, DependencyItemCategory.Referenced};

            return AllCategories;
        }

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <returns>List of dependencies.</returns>
        public DependenciesData GetDependencies(ModelElement modelElement)
        {
            List<ModelElement> elements = new List<ModelElement>();
            elements.Add(modelElement);

            return GetDependencies(elements);
        }

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <returns>List of dependencies.</returns>
        public DependenciesData GetDependencies(ModelElement modelElement, DependenciesRetrivalOptions options)
        {
            List<ModelElement> elements = new List<ModelElement>();
            elements.Add(modelElement);

            return GetDependencies(elements, options);
        }

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <returns>List of dependencies.</returns>
        public DependenciesData GetDependencies(List<ModelElement> modelElements)
        {
            DependenciesData data = new DependenciesData();
            List<IDependenciesItemsProvider> discardProviders = new List<IDependenciesItemsProvider>();
            GetDependencies(modelElements, RetrivalOptions, data);
            return data;
        }

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <returns>List of dependencies.</returns>
        public DependenciesData GetDependencies(List<ModelElement> modelElements, DependenciesRetrivalOptions options)
        {
            DependenciesData data = new DependenciesData();
            List<IDependenciesItemsProvider> discardProviders = new List<IDependenciesItemsProvider>();
            GetDependencies(modelElements, options, data);
            return data;
        }

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <param name="dependenciesData">Data to add found dependencies to.</param>
        /// <returns>List of dependencies.</returns>
        public virtual DependenciesData GetDependencies(List<ModelElement> modelElements, DependenciesRetrivalOptions options, DependenciesData dependenciesData)
        {
            foreach (ModelElement modelElement in modelElements)
            {
                IDomainModelOwnable dmo = modelElement as IDomainModelOwnable;
                if (dmo == null)
                    continue;

                DomainClassInfo info = modelElement.GetDomainClass();
                foreach (DomainRoleInfo roleInfo in info.AllDomainRolesPlayed)
                {
                    if (roleInfo.DomainModel.Id == CoreDomainModel.DomainModelId)
                        continue;

                    if (options.ShouldExcludeDomainRelationship(roleInfo.DomainRelationship.Id, roleInfo.DomainModel.Id))
                        continue;

                    foreach (DependencyItemCategory category in GetAllCategories())
                    {
                        if (roleInfo.IsSource && category != DependencyItemCategory.Embedding &&
                            category != DependencyItemCategory.Referencing) 
                            continue;

                        if (!roleInfo.IsSource && category != DependencyItemCategory.Embedded &&
                            category != DependencyItemCategory.Referenced)
                            continue;

                        if (dmo.Store.DomainDataAdvDirectory.IsEmbeddingRelationship(roleInfo.DomainRelationship.Id))
                        {
                            if (category != DependencyItemCategory.Embedded && category != DependencyItemCategory.Embedding)
                                continue;
                        }
                        else if (category == DependencyItemCategory.Embedded || category == DependencyItemCategory.Embedding)
                            continue;

                        // add origin dependency
                        dependenciesData.OriginDependencies.Add(new DependencyOriginItem(modelElement.Id, roleInfo.DomainRelationship, roleInfo));
					
						// get link instances
						System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, roleInfo.Id);
                        if (links.Count > 0)
						{
                            foreach (ElementLink link in links)
							{
                                if (category == DependencyItemCategory.Embedding || category == DependencyItemCategory.Referencing)
                                {
                                    if (options.ShouldExcludeDomainClass(DomainRoleInfo.GetTargetRolePlayer(link)))
                                        continue;
                                }
                                else
                                    if (options.ShouldExcludeDomainClass(DomainRoleInfo.GetSourceRolePlayer(link)))
                                        continue;

                                if (options.ShouldExcludeDomainRelationship(link))
                                    continue;
							
								DependencyItem item = new DependencyItem(link, category, roleInfo.DomainRelationship, roleInfo);
								dependenciesData.ActiveDependencies.Add(item);
							}
						}
                    }
                }
            }

            return dependenciesData;
        }

        /// <summary>
        /// Gets the retrival options.
        /// </summary>
        public abstract DependenciesRetrivalOptions RetrivalOptions
        {
            get;
        }
    }
}
