
namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This specifies the kind of a dependency item in the dependencies view model.
    /// </summary>
    public enum DependencyItemCategory
    {
        /// <summary>
        /// The item is embedding an item.
        /// </summary>
        Embedding,

        /// <summary>
        /// The item is embedded.
        /// </summary>
        Embedded,

        /// <summary>
        /// The item is referencing an another item.
        /// </summary>
        Referencing,
            
        /// <summary>
        /// The item is referenced by an another item.
        /// </summary>
        Referenced

        
    }
}
