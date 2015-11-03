using System;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Interface providing methods required for a model element id key provider.
    /// </summary>
    public interface IModelElementIdProvider
    {
        /// <summary>
        /// Generates a new unique key.
        /// </summary>
        /// <returns>New Key as a System.Guid.</returns>
        Guid GenerateNewKey();

        /// <summary>
        /// Adds a new key to the ID list. 
        /// </summary>
        /// <param name="modelElement">Domain model element to add the Id for.</param>
        void AddKey(ModelElement modelElement);

        /// <summary>
        /// Gets whether a certain key has already been assigned.
        /// </summary>
        /// <param name="modelElementId">Domain model element Id.</param>
        /// <returns>True if the given id has already been assigned; false otherwise.</returns>
        bool HasKey(Guid modelElementId);

        /// <summary>
        /// Gets whether a certain key has already been assigned.
        /// </summary>
        /// <param name="modelElementId">Domain model element Id.</param>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        /// <returns>True if the given id has already been assigned; false otherwise.</returns>
        bool HasKey(Guid modelElementId, System.Collections.Generic.List<IDomainModelServices> servicesToDiscard);

        /// <summary>
        /// Resets the id provider.
        /// </summary>
        void Reset();

        /// <summary>
        /// Resets the id provider.
        /// </summary>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        void Reset(System.Collections.Generic.List<IDomainModelServices> servicesToDiscard);

        /// <summary>
        /// Removes a specific key.
        /// </summary>
        /// <param name="modelElement">Domain model element to remove the key for.</param>
        void RemoveKey(ModelElement modelElement);

        /// <summary>
        /// Removes a specific key.
        /// </summary>
        /// <param name="modelElement">Domain model element to remove the key for.</param>
        /// <param name="servicesToDiscard">Services to ignore.</param>
        bool RemoveKey(ModelElement modelElement, System.Collections.Generic.List<IDomainModelServices> servicesToDiscard);

        /// <summary>
        /// Adds a property assignment containing the new id value if there is non yet in the array.
        /// </summary>
        /// <param name="propertyAssignments">Element property assignments.</param>
        /// <returns>Element property assignments containing an id property assignment.</returns>
        PropertyAssignment[] AssignId(PropertyAssignment[] propertyAssignments);

        /// <summary>
        /// Adds a property assignment containing the new id value if there is non yet in the array.
        /// </summary>
        /// <returns>Element property assignments containing an id property assignment.</returns>
        PropertyAssignment[] CreateId();
    }
}
