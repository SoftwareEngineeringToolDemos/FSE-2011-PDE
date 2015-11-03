using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface ensures what methods a shape provider for domain elements is bound to have.
    /// </summary>
    public interface IModelElementShapeProvider
    {
        /// <summary>
        /// Create a shape of the given type for the given element type.
        /// </summary>
        /// <param name="modelElement">Model element.</param>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        ModelElement CreateShapeForElement(Guid shapeTypeId, ModelElement modelElement, params PropertyAssignment[] assignments);

        /// <summary>
        /// Create a shape of the given link shape type.
        /// </summary>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="modelElement">Model element.</param>
        /// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        ModelElement CreateShapeForElementLink(Guid shapeTypeId, ModelElement modelElement, params PropertyAssignment[] assignments);

        /// <summary>
        /// Create a shape of the given link shape type.
        /// </summary>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="modelElement">Model element.</param>
        /// <param name="sourceShape">Source shape.</param>
        /// <param name="targetShape">Target shape.</param>
        /// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        ModelElement CreateShapeForElementLink(Guid shapeTypeId, ModelElement modelElement, ModelElement sourceShape, ModelElement targetShape, params PropertyAssignment[] assignments);

        /// <summary>
        /// Create a dependency shape for the given element type.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <param name="modelElement">Model element.</param>
        /// <param name="assignments">Properties for the dependencies shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        ModelElement CreateDependenciesShapeForElement(Guid modelElementTypeId, ModelElement modelElement, params PropertyAssignment[] assignments);
    }
}
