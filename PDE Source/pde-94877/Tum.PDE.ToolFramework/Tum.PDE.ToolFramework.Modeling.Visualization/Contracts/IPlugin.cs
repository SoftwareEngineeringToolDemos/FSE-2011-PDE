using System.Windows.Controls;

using Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts
{
    /// <summary>
    /// Simple plugin interface.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets the name of the menu item identifying the plugin.
        /// </summary>
        string MenuName { get; }

        /// <summary>
        /// Gets the image of the menu item identifying the plugin.
        /// </summary>
        System.Windows.Media.Imaging.BitmapImage MenuImage { get; }

        /// <summary>
        /// Gets the model context this plugin should extend.
        /// </summary>
        /// <remarks>
        /// If this value is null, this plugin is considered for every context in the model.
        /// </remarks>
        string ModelContext { get; }

        /// <summary>
        /// Executes the plugins function.
        /// </summary>
        /// <param name="modelData">
        /// Class representing the currently loaded data instance. 
        /// modelData.RootElement is the root element of the domain model.
        /// </param>
        void Execute(ModelData modelData);
    }
}
