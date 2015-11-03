using System;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface ensures methods a element type provider is bound to have. As such it provides
    /// names and especially display names of types. The display names should be looked up e.g. in a
    /// resx dictionary for localization purposes.
    /// </summary>
    public interface IModelElementTypeProvider
    {
        /// <summary>
        /// Get the name of type of the element as string.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the type for.</param>
        /// <returns>Type name as a string.</returns>
        /// <remarks>
        /// This is essentially equal to modelElement.GetType().Name. But as this
        /// is generated, we dont required to access the actual Type of the element to get its name.
        /// </remarks>
        string GetTypeName(ModelElement modelElement);

        /// <summary>
        /// Gets the name of the type based on the given domain class Id.
        /// </summary>
        /// <param name="store">Modeling store</param>
        /// <param name="domainClassId">DomainClassId specifying the type of the element.</param>
        /// <returns>Type name as a string.</returns>
        string GetTypeName(Store store, Guid domainClassId);

        /// <summary>
        /// Get the display name of type of the element as string.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the type display name for.</param>
        /// <returns>Display name of the type as a string.</returns>
        string GetTypeDisplayName(ModelElement modelElement);

        /// <summary>
        /// Get the display name of type that is specified by the given domain class Id as string.
        /// </summary>
        /// <param name="store">Modeling store</param>
        /// <param name="domainClassId">DomainClassId specifying the type of the element.</param>
        /// <returns>Display name of the type as a string.</returns>
        string GetTypeDisplayName(Store store, Guid domainClassId);
    }
}
