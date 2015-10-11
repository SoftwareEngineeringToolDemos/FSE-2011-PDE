namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface describing a selection element sub view model.
    /// </summary>
    public interface ISelectElementSubViewModel
    {
        /// <summary>
        /// Gets or sets whether this view is active or not.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets the selected element.
        /// </summary>
        object SelectedElement { get; }

        /// <summary>
        /// Tries to set the selection to the given element.
        /// </summary>
        /// <param name="element">Element to select.</param>
        void SetSelectedElement(object element);
    }
}
