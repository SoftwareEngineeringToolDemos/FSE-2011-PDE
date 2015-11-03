using System;

using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface ensures what methods a parent provider for domain elements is bound to have. The
    /// parent provider needs to be able to retrieve a parent element for any domain element. Further, 
    /// it also is required to map a model element to its concrete domain model (as many may be included).
    /// </summary>
    public interface IModelElementParentProvider
    {
        /// <summary>
        /// Gets the embedding domain model for a given model element. The embedding domain model
        /// is the domain model that contains the given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain model for.</param>
        /// <returns>Domain model as ModelElement if found. Null otherwise.</returns>
        IParentModelElement GetParentModelElement(ModelElement modelElement);

        /// <summary>
        /// Gets the embedding domain element for a given model element. The embedding domain element
        /// is the parent domain element that is embedding the given model domain element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain element for.</param>
        /// <returns>Domain element as ModelElement if found. Null otherwise</returns>
        ModelElement GetEmbeddingParent(ModelElement modelElement);

        /// <summary>
        /// Gets the embedding domain element of a specific type for a given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain element for.</param>
        /// <param name="parentTypeDomainClassId">Type of the embedding domain element to find.</param>
        /// <returns>Domain element as ModelElement if found. Null otherwise</returns>
        ModelElement GetEmbeddingParent(ModelElement modelElement, Guid parentTypeDomainClassId);
    }
}
