namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// Sort order in the error list.
    /// </summary>
    public enum ErrorListSortOrder
    {
        /// <summary>
        /// Sorted by number of error item.
        /// </summary>
        Number,

        /// <summary>
        /// Sorted by the category of error items.
        /// </summary>
        Category,

        /// <summary>
        /// Sorted by the description of error items.
        /// </summary>
        Description,

        /// <summary>
        /// Sorted by the source display name of error items.
        /// </summary>
        SourceDisplayName
    }
}
