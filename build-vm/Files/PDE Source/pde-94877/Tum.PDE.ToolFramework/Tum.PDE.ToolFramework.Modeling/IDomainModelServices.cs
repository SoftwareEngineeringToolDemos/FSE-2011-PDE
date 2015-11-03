using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes domain model services.
    /// </summary>
    public interface IDomainModelServices
    {
        /// <summary>
        /// Gets or sets the top most service.
        /// </summary>
        IDomainModelServices TopMostService
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the extension services.
        /// </summary>
        IDomainModelExtensionServices ExtensionServices { get; }

        /// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        IModelElementIdProvider ElementIdProvider { get; }

        /// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        IModelElementNameProvider ElementNameProvider { get; }

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        IModelElementTypeProvider ElementTypeProvider { get; }

        /// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        IModelElementParentProvider ElementParentProvider { get; }

        /// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        IModelElementChildrenProvider ElementChildrenProvider { get; }

        /// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        IDependenciesItemsProvider DependenciesItemsProvider { get; }

        /// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        IModelElementSearchProcessor SearchProcessor { get; }

        /// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        IModelElementShapeProvider ShapeProvider { get; }
        
        /// <summary>
        /// Gets the validation controller.
        /// </summary>
        ModelValidationController ValidationController { get; }

        /// <summary>
        /// Gets the model data options.
        /// </summary>
        IModelDataOptions ModelDataOptions { get; }
    }
}
