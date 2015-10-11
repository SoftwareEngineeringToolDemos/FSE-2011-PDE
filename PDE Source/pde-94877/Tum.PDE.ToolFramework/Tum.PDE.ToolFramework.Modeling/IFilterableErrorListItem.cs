namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes a filterable error list item.
    /// </summary>
    public interface IFilterableErrorListItem
    {
        /// <summary>
        /// This method provides an unique id for the item. 
        /// </summary>
        /// <returns></returns>
        string GetUniqueId();

        /// <summary>
        /// Identification of the error.
        /// </summary>
        string ErrorId { get; }
    }
}
