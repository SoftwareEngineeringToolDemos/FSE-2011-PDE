namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Interface for the model data options class, which is used to store common options.
    /// </summary>
    public interface IModelDataOptions
    {
        /// <summary>
        /// Gets the application data directory for the current editor.
        /// </summary>
        string AppDataDirectory{ get; }

        /// <summary>
        /// Gets the name of the current editor.
        /// </summary>
        string AppName { get; }

        /// <summary>
        /// Gets the name of the company providing this editor.
        /// </summary>
        string Company { get; }

        /// <summary>
        /// Gets the version of the editor.
        /// </summary>
        string Version { get; }
    }
}
