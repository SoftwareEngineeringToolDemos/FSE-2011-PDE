using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface ensures the methods an element name provider is bound to have. This includes
    /// methods to create names for new elements as well as methods to verify if an element has a name
    /// as well as methods to retrieve an existing name or assign a new name.
    /// </summary>
    public interface IModelElementNameProvider
    {
        /// <summary>
        /// Verifies if a given modelElement has a name property or not.
        /// </summary>
        /// <param name="modelElement">ModelElement to verify.</param>
        /// <returns>
        /// True if the given model element has a property marked with "IsElementName" set to true. False otherwise.
        /// </returns>
        bool HasName(ModelElement modelElement);

        /// <summary>
        /// Gets the element name from the property that is marked as "IsElementName".
        /// </summary>
        /// <param name="modelElement">Domain class to get the name for.</param>
        /// <returns>Name of the domain class as string if found. Null otherwise.</returns>
        string GetName(ModelElement modelElement);

        /// <summary>
        /// Sets a new name property value for the given element.
        /// </summary>
        /// <param name="modelElement">ModelElement to assign a new value for the name property.</param>
        /// <param name="name">New value to assign to the name property.</param>
        void SetName(ModelElement modelElement, string name);

        /// <summary>
        /// Method used to create a new element's name based on the range of available names. 
        /// Excluded are names used by the child elements embedded in the given parent element.
        /// </summary>
        /// <param name="parent">Parent element, embedding the model element.</param>
        /// <param name="modelElement">ModelElement to create the name for.</param>
        /// <returns>Created name for the given ModelElement. Null if the method did not succeed. </returns>
        string CreateName(ModelElement parent, ModelElement modelElement);

        /// <summary>
        /// Method used to create a new elements nam'e based on the range of available names and assign it to the element. 
        /// Excluded are names used by the child elements embedded in the given parent element.
        /// </summary>
        /// <param name="parent">Parent element, embedding the model element.</param>
        /// <param name="modelElement">ModelElement to create and assign the name for.</param>
        /// <returns>Created name for the given ModelElement. Null if the method did not succeed. </returns>
        string CreateAndAssignName(ModelElement parent, ModelElement modelElement);

        /// <summary>
        /// Gets the name property info for a given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the name property info for.</param>
        /// <returns>DomainPropertyInfo for the name property if found. Null otherwise.</returns>
        DomainPropertyInfo GetNamePropertyInfo(ModelElement modelElement);
    }
}
