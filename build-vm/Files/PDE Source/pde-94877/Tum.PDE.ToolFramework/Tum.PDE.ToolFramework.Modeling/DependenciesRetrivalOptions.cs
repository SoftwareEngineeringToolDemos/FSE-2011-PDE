using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class is used to specify options to retrieve dependencies.
    /// </summary>
    public abstract class DependenciesRetrivalOptions
    {
        private DependencyItemCategory[] categories;

        private List<Guid> excludedDomainModels;
        private bool bUseExcludedDomainModels = false;

        private List<Guid> includedDomainModels;
        private bool bUseIncludedDomainModels = false;

        private List<Guid> includedDomainClasses;
        private bool bUseIncludedDomainClasses = false;

        private List<Guid> excludedDomainClasses;
        private bool bUseExcludedDomainClasses = false;

        private List<Guid> includedDomainRelationships;
        private bool bUseIncludedDomainRelationships = false;

        private List<Guid> excludedDomainRelationships;
        private bool bUseExcludedDomainRelationships = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DependenciesRetrivalOptions() :
            this(DependenciesItemsProvider.GetAllCategories())
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="categories">Categories to take into account.</param>
        public DependenciesRetrivalOptions(params DependencyItemCategory[] categories)
        {
            this.categories = categories;
            this.excludedDomainModels = new List<Guid>();
            this.includedDomainModels = new List<Guid>();
            this.excludedDomainClasses = new List<Guid>();
            this.includedDomainClasses = new List<Guid>();
            this.excludedDomainRelationships = new List<Guid>();
            this.includedDomainRelationships = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DependencyItemCategory[] Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

        #region Retrieval Options
        /// <summary>
        /// Gets the list of domain model types that should be excluded during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> ExcludedDomainModels
        {
            get
            {
                return this.excludedDomainModels.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of domain model types that should be included during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> IncludedDomainModels
        {
            get
            {
                return this.includedDomainModels.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of domain class types that should be included during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> IncludedDomainClasses
        {
            get
            {
                return this.includedDomainClasses.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of domain class types that should be excluded during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> ExcludedDomainClasses
        {
            get
            {
                return this.excludedDomainClasses.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of domain relationship types that should be included during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> IncludedDomainRelationships
        {
            get
            {
                return this.includedDomainRelationships.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the list of domain relationship types that should be excluded during the search for dependencies.
        /// </summary>
        public ReadOnlyCollection<Guid> ExcludedDomainRelationships
        {
            get
            {
                return this.excludedDomainRelationships.AsReadOnly();
            }
        }

        /// <summary>
        /// Adds an exluded domain model type.
        /// </summary>
        /// <param name="domainModelType">Domain model type to be excluded during the search for dependencies.</param>
        public void AddExcludedDomainModel(Guid domainModelType)
        {
            bUseExcludedDomainModels = true;

            if (!excludedDomainModels.Contains(domainModelType))
                excludedDomainModels.Add(domainModelType);
        }

        /// <summary>
        /// Removes an exluded domain model type.
        /// </summary>
        /// <param name="domainModelType">Domain model type to be excluded during the search for dependencies.</param>
        public void RemoveExcludedDomainModel(Guid domainModelType)
        {
            if (excludedDomainModels.Contains(domainModelType))
                excludedDomainModels.Remove(domainModelType);

            if( excludedDomainModels.Count == 0 )
                bUseExcludedDomainModels = true;
        }

        /// <summary>
        /// Adds an inluded domain model type.
        /// </summary>
        /// <param name="domainModelType">Domain model type to be included during the search for dependencies.</param>
        public void AddIncludedDomainModel(Guid domainModelType)
        {
            bUseIncludedDomainModels = true;

            if (!includedDomainModels.Contains(domainModelType))
                includedDomainModels.Add(domainModelType);
        }

        /// <summary>
        /// Removes an inluded domain model type.
        /// </summary>
        /// <param name="domainModelType">Domain model type to be inluded during the search for dependencies.</param>
        public void RemoveIncludedDomainModel(Guid domainModelType)
        {
            if (includedDomainModels.Contains(domainModelType))
                includedDomainModels.Remove(domainModelType);

            if (includedDomainModels.Count == 0)
                bUseIncludedDomainModels = true;
        }

        /// <summary>
        /// Adds an included domain class type.
        /// </summary>
        /// <param name="domainClassType">Domain model class to be included during the search for dependencies.</param>
        public void AddIncludedDomainClass(Guid domainClassType)
        {
            bUseIncludedDomainClasses = true;

            if (!includedDomainClasses.Contains(domainClassType))
                includedDomainClasses.Add(domainClassType);
        }

        /// <summary>
        /// Removes an included domain class type.
        /// </summary>
        /// <param name="domainClassType">Domain model class to be included during the search for dependencies.</param>
        public void RemoveIncludedDomainClass(Guid domainClassType)
        {
            if (includedDomainClasses.Contains(domainClassType))
                includedDomainClasses.Remove(domainClassType);

            if (includedDomainClasses.Count == 0)
                bUseIncludedDomainClasses = true;
        }

        /// <summary>
        /// Adds an excluded domain class type.
        /// </summary>
        /// <param name="domainClassType">Domain model class to be excluded during the search for dependencies.</param>
        public void AddExcludedDomainClass(Guid domainClassType)
        {
            bUseExcludedDomainClasses = true;

            if (!excludedDomainClasses.Contains(domainClassType))
                excludedDomainClasses.Add(domainClassType);
        }

        /// <summary>
        /// Removes an excluded domain class type.
        /// </summary>
        /// <param name="domainClassType">Domain model class to be excluded during the search for dependencies.</param>
        public void RemoveExcludedDomainClass(Guid domainClassType)
        {
            if (excludedDomainClasses.Contains(domainClassType))
                excludedDomainClasses.Remove(domainClassType);

            if (excludedDomainClasses.Count == 0)
                bUseExcludedDomainClasses = true;
        }

        /// <summary>
        /// Adds an included domain relationship type.
        /// </summary>
        /// <param name="domainRelationshipType">Domain relationship class to be included during the search for dependencies.</param>
        public void AddIncludedDomainRelationship(Guid domainRelationshipType)
        {
            bUseIncludedDomainRelationships = true;

            if (!includedDomainRelationships.Contains(domainRelationshipType))
                includedDomainRelationships.Add(domainRelationshipType);
        }

        /// <summary>
        /// Removes an included domain relationship type.
        /// </summary>
        /// <param name="domainRelationshipType">Domain relationship class to be included during the search for dependencies.</param>
        public void RemoveIncludedDomainRelationship(Guid domainRelationshipType)
        {
            if (includedDomainRelationships.Contains(domainRelationshipType))
                includedDomainRelationships.Remove(domainRelationshipType);

            if (includedDomainRelationships.Count == 0)
                bUseIncludedDomainRelationships = true;
        }

        /// <summary>
        /// Adds an excluded domain relationship type.
        /// </summary>
        /// <param name="domainRelationshipType">Domain relationship class to be included during the search for dependencies.</param>
        public void AddExcludedDomainRelationship(Guid domainRelationshipType)
        {
            bUseExcludedDomainRelationships = true;

            if (!excludedDomainRelationships.Contains(domainRelationshipType))
                excludedDomainRelationships.Add(domainRelationshipType);
        }

        /// <summary>
        /// Removes an excluded domain relationship type.
        /// </summary>
        /// <param name="domainRelationshipType">Domain relationship class to be included during the search for dependencies.</param>
        public void RemoveExcludedDomainRelationship(Guid domainRelationshipType)
        {
            if (excludedDomainRelationships.Contains(domainRelationshipType))
                excludedDomainRelationships.Remove(domainRelationshipType);

            if (excludedDomainRelationships.Count == 0)
                bUseExcludedDomainRelationships = true;
        }
        #endregion

        #region Retrieval Operations
        /// <summary>
        /// Verifies if a specific model element should be excluded or not.
        /// </summary>
        /// <param name="modelElement">Model element to verify</param>
        /// <returns>True if the specified element should be excluded; False otherwise.</returns>
        public virtual bool ShouldExcludeDomainClass(ModelElement modelElement)
        {
            if (bUseExcludedDomainClasses || bUseIncludedDomainClasses || bUseExcludedDomainModels || bUseIncludedDomainModels)
            {
                Guid t = modelElement.GetDomainClass().Id;
                if (bUseExcludedDomainClasses)
                    if (this.excludedDomainClasses.Contains(t))
                        return true;

                if (bUseIncludedDomainClasses)
                    if (!this.includedDomainClasses.Contains(t))
                        return true;

                if (bUseExcludedDomainModels)
                {
                    IDomainModelOwnable o = modelElement as IDomainModelOwnable;
                    if (this.excludedDomainModels.Contains(o.GetDomainModelTypeId()))
                        return true;
                }

                if (bUseIncludedDomainModels)
                {
                    IDomainModelOwnable o = modelElement as IDomainModelOwnable;
                    if (!this.includedDomainModels.Contains(o.GetDomainModelTypeId()))
                        return true;
                }                    
            }

            return false;
        }

        /// <summary>
        /// Verifies if a specific model relationship should be excluded or not.
        /// </summary>
        /// <param name="elementLinkType">Model relationship type to verify</param>
        /// <param name="domainModelType">Domain model type.</param>
        /// <returns>True if the specified relationship should be excluded; False otherwise.</returns>
        public virtual bool ShouldExcludeDomainRelationship(Guid elementLinkType, Guid domainModelType)
        {
            if (DomainModelLink.DomainClassId == elementLinkType)
                return true;

            if (bUseExcludedDomainClasses || bUseIncludedDomainClasses || bUseExcludedDomainModels || bUseIncludedDomainModels)
            {
                if (bUseExcludedDomainRelationships)
                    if (this.excludedDomainRelationships.Contains(elementLinkType))
                        return true;

                if (bUseIncludedDomainRelationships)
                    if (!this.includedDomainRelationships.Contains(elementLinkType))
                        return true;

                if (bUseExcludedDomainModels)
                {
                    if (this.excludedDomainModels.Contains(domainModelType))
                        return true;
                }

                if (bUseIncludedDomainModels)
                {
                    if (!this.includedDomainModels.Contains(domainModelType))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies if a specific model relationship should be excluded or not.
        /// </summary>
        /// <param name="elementLink">Model relationship to verify</param>
        /// <returns>True if the specified relationship should be excluded; False otherwise.</returns>
        public virtual bool ShouldExcludeDomainRelationship(ElementLink elementLink)
        {
            if (bUseExcludedDomainClasses || bUseIncludedDomainClasses || bUseExcludedDomainModels || bUseIncludedDomainModels)
            {
                Guid t = elementLink.GetDomainClass().Id;
                if (bUseExcludedDomainRelationships)
                    if (this.excludedDomainRelationships.Contains(t))
                        return true;

                if (bUseIncludedDomainRelationships)
                    if (!this.includedDomainRelationships.Contains(t))
                        return true;

                if (bUseExcludedDomainModels)
                {
                    IDomainModelOwnable o = elementLink as IDomainModelOwnable;
                    if (this.excludedDomainModels.Contains(o.GetDomainModelTypeId()))
                        return true;
                }

                if (bUseIncludedDomainModels)
                {
                    IDomainModelOwnable o = elementLink as IDomainModelOwnable;
                    if (!this.includedDomainModels.Contains(o.GetDomainModelTypeId()))
                        return true;
                }
            }

            return false;
        }
        #endregion
    }
}
