namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This enumeration represents the search source criteria.
    /// </summary>
    public enum SearchSourceEnum
    {
        /// <summary>
        /// Search within all elements.
        /// </summary>
        Elements,

        /// <summary>
        /// Search within all reference relationships.
        /// </summary>
        ReferenceRelationships,

        /// <summary>
        /// Search within all elements and reference relationships.
        /// </summary>
        ElementsAndReferenceRelationships,

        /// <summary>
        /// This is used for extensions.
        /// </summary>
        Custom
    }
}
