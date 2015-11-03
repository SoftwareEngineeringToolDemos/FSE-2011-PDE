using System;
using System.ComponentModel.Composition;
using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace $safeprojectname$
{
    [Export(typeof(IViewModelPlugin))]
    public class ExampleViewModelPlugin : IViewModelPlugin
    {
        /// <summary>
        /// Create an instance of the KonformatorDiagramSurfaceViewModel class and returns it.
        /// </summary>
        /// <param name="store">View Model store.</param>
        /// <returns>Instance of KonformatorDiagramSurfaceViewModel.</returns>
        public BaseDiagramSurfaceViewModel GetViewModel(ViewModelStore store)
        {
            return new ExamplePluginDiagramSurfaceViewModel(store);
        }

        /// <summary>
        /// Gets the resource dictionary, which contains the data template to visualize the view model plugin.
        /// </summary>
        /// <returns>Resource dictionary.</returns>
        public ResourceDictionary GetViewModelRessourceDictionary()
        {
            Uri uri = new Uri("$safeprojectname$;component/ExampleViewModelPlugin.xaml", UriKind.Relative);
            return Application.LoadComponent(uri) as ResourceDictionary;
        }

        /// <summary>
        /// Gets the model context. Null targets all.
        /// </summary>
        public string ModelContext
        {
            get { return null; }
        }
    }
}
