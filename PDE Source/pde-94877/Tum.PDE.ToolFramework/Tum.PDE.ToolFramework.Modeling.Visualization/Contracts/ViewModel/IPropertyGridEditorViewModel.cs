namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// This interfaces ensures necessary properties and methods an implementation of an editor view model is bound to have.
    /// </summary>
    public interface IPropertyGridEditorViewModel
    {
        /// <summary>
        /// Gets the name or the property, which is represented by this view model.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets the display name of the property, which is represented by this view model.
        /// </summary>
        string PropertyDisplayName { get; }

        /// <summary>
        /// Gets or sets the category of the property, which is represented by this view model.
        /// </summary>
        string PropertyCategory { get; }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        object PropertyValue{ get; set; }
    }
}
