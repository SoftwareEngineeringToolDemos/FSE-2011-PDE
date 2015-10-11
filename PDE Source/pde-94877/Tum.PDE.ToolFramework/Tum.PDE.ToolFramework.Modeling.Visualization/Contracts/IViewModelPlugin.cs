using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts
{
    /// <summary>
    /// Advanced Plugin-Interface to provide view model plugins.
    /// </summary>
    public interface IViewModelPlugin
    {
        /// <summary>
        /// Gets the model context this plugin should extend.
        /// </summary>
        /// <remarks>
        /// If this value is null, this plugin is considered for every context in the model.
        /// </remarks>
        string ModelContext { get; }

        /// <summary>
        /// Gets a diagram surface view model, that represents the plugins functions.
        /// </summary>
        /// <param name="store">View model store.</param>
        /// <returns>Diagram surface view model.</returns>
        /// <remarks>
        /// Ribbon bars can be created by overriding the CreateRibbonMenu method in the diagram surface view model.
        /// </remarks>
        BaseDiagramSurfaceViewModel GetViewModel(ViewModelStore store);

        /// <summary>
        /// Gets the resource dictionary, which contains the data template to visualize the view model plugin.
        /// </summary>
        /// <returns>Resource dictionary.</returns>
        ResourceDictionary GetViewModelRessourceDictionary();
    }
}
