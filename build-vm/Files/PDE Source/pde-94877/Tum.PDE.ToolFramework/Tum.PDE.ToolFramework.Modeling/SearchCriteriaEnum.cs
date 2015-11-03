namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This enum identifies search criterias.
    /// </summary>
    public enum SearchCriteriaEnum
    {
        /// <summary>
        /// Name property.
        /// </summary>
        Name,

        /// <summary>
        /// Type.
        /// </summary>
        Type,

        /// <summary>
        /// Name and Type.
        /// </summary>
        NameAndType,

        /// <summary>
        /// Properties.
        /// </summary>
        Properties,

        /// <summary>
        /// Properties without the Name property.
        /// </summary>
        PropertiesWithoutName,

        /// <summary>
        /// Roles
        /// </summary>
        Roles,

        /// <summary>
        /// All of the above.
        /// </summary>
        All,

        /// <summary>
        /// This is used for extensions.
        /// </summary>
        Custom
    }
}
