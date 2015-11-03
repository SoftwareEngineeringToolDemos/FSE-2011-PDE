using System;
using System.ComponentModel.Composition;
using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Plugins.BreadcrumbNavigation
{
    /// <summary>
    /// Breadcrumb navigation plugin for PDE.
    /// </summary>
    [Export(typeof(IViewModelPlugin))]
    public class BreadcrumbNavigationPlugin : IViewModelPlugin
    {
        /// <summary>
        /// Create an instance of the BaseDiagramSurfaceViewModel class and returns it.
        /// </summary>
        /// <param name="store">View Model store.</param>
        /// <returns>Instance of KonformatorDiagramSurfaceViewModel.</returns>
        public BaseDiagramSurfaceViewModel GetViewModel(ViewModelStore store)
        {
            return new BreadcrumbNavigationViewModel(store);
        }

        /// <summary>
        /// Gets the resource dictionary, which contains the data template to visualize the view model plugin.
        /// </summary>
        /// <returns>Resource dictionary.</returns>
        public ResourceDictionary GetViewModelRessourceDictionary()
        {
            Uri uri = new Uri("Tum.PDE.ToolFramework.Plugins.BreadcrumbNavigation;component/Resources.xaml", UriKind.Relative);
            return Application.LoadComponent(uri) as ResourceDictionary;
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public string ModelContext
        {
            get { return null; }
        }
    }
}
