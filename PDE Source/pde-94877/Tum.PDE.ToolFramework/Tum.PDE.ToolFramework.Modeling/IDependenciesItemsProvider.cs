using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface specifies a dependency items provider, which is used to gather
    /// dependency items for specific model elements. As such, this provider is bound
    /// to return a collection of dependency items that are active in the current 
    /// domain model on specific model elements.
    /// </summary>
    public interface IDependenciesItemsProvider
    {
        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <param name="dependenciesData">Data to add found dependencies to.</param>
        /// <returns>List of dependencies.</returns>
        DependenciesData GetDependencies(List<ModelElement> modelElements, DependenciesRetrivalOptions options, DependenciesData dependenciesData);

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <returns>List of dependencies.</returns>
        DependenciesData GetDependencies(ModelElement modelElement);

        /// <summary>
        /// Gets the dependencies for a specific model element.
        /// </summary>
        /// <param name="modelElement">Model element to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <returns>List of dependencies.</returns>
        DependenciesData GetDependencies(ModelElement modelElement, DependenciesRetrivalOptions options);

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <returns>List of dependencies.</returns>
        DependenciesData GetDependencies(List<ModelElement> modelElements);

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <param name="options">Options.</param>
        /// <returns>List of dependencies.</returns>
        DependenciesData GetDependencies(List<ModelElement> modelElements, DependenciesRetrivalOptions options);
    }
}
