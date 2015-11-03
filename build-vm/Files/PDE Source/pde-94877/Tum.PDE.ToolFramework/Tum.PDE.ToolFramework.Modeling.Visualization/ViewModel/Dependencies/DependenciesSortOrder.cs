namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// Sort order in the dependencies view model.
    /// </summary>
    public enum DependenciesSortOrder
    {
        /// <summary>
        /// Sort by number.
        /// </summary>
        NumberAdded,

        /// <summary>
        /// Sort by category.
        /// </summary>
        DependencyCategory,

        /// <summary>
        /// Sort by source element name.
        /// </summary>
        SourceModelElement,

        /// <summary>
        /// Sort by target element name.
        /// </summary>
        TargetModelElement,

        /// <summary>
        /// Sort by relationship name.
        /// </summary>
        LinkElement
    }
}
