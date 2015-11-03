using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Domain model services class.
    /// </summary>
    public abstract class DomainModelServices : IDomainModelServices
    {
        private IDomainModelServices topMostService;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected DomainModelServices()
        {
            topMostService = this;
        }

        /// <summary>
        /// Gets or sets the top most service.
        /// </summary>
        public IDomainModelServices TopMostService
        {
            get
            {
                return this.topMostService;
            }
            set
            {
                this.topMostService = value;
            }
        }

        /// <summary>
        /// Gets the extension services.
        /// </summary>
        public abstract IDomainModelExtensionServices ExtensionServices { get; }

        /// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        public abstract IModelElementIdProvider ElementIdProvider { get; }

        /// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        public abstract IModelElementNameProvider ElementNameProvider { get; }

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        public abstract IModelElementTypeProvider ElementTypeProvider { get; }

        /// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        public abstract IModelElementParentProvider ElementParentProvider { get; }

        /// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        public abstract IModelElementChildrenProvider ElementChildrenProvider { get; }

        /// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        public abstract IDependenciesItemsProvider DependenciesItemsProvider { get; }

        /// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public abstract IModelElementSearchProcessor SearchProcessor { get; }

        /// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public abstract IModelElementShapeProvider ShapeProvider { get; }

        /// <summary>
        /// Gets the validation controller.
        /// </summary>
        public abstract ModelValidationController ValidationController { get; }

        /// <summary>
        /// Gets the model data options.
        /// </summary>
        public abstract IModelDataOptions ModelDataOptions { get; }
    }
}
