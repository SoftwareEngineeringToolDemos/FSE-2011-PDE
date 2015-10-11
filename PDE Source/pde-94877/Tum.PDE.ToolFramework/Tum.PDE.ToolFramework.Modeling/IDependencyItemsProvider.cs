using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface specifies a dependency items provider, which is used to gather
    /// dependency items for a specific model element. As such, this provider is bound
    /// to return a collection of dependency items that are active in the current 
    /// domain model on a specific model element.
    /// </summary>
    public interface IDependencyItemsProvider
    {
        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="dependenciesData">Dependencies data to add new dependency and origin items to.</param>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        void GetDependencies(DependenciesData dependenciesData, ModelElement modelElement);

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="dependenciesData">Dependencies data to add new dependency and origin items to.</param>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <param name="options">Options</param>
        void GetDependencies(DependenciesData dependenciesData, ModelElement modelElement, DependenciesRetrivalOptions options);
    }
}
