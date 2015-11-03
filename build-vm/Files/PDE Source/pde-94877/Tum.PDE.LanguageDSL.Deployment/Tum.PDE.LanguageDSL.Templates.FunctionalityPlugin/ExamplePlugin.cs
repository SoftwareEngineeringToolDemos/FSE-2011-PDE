using System;
using System.ComponentModel.Composition;
using System.Windows;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace $safeprojectname$
{    
    /// <summary>
    /// PDE-Plugin for variants configuration.
    /// </summary>
    [Export(typeof(IModelPlugin))]
    public class ExamplePlugin : IModelPlugin
    {
        private ViewModelStore vmStore;
        private DomainModelElement selectedModelElement = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ExamplePlugin()
        {
        }

        /// <summary>
        /// Gets the menu image.
        /// </summary>
        public System.Windows.Media.Imaging.BitmapImage MenuImage
        {
            get
            {
                return new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/PDEFunctionalityPlugin1;component/ExampleImage.png", UriKind.Absolute));
            }
        }

        /// <summary>
        /// Gets the menu name.
        /// </summary>
        public string MenuName
        {
            get
            {
                return "Example Plugin";
            }
        }

        /// <summary>
        /// Gets the targeted model context. null targets all.
        /// </summary>
        public string ModelContext
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the view model store.
        /// </summary>
        /// <param name="store">View model store.</param>
        public void SetViewModelStore(ViewModelStore store)
        {
            this.vmStore = store;

            this.vmStore.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        private void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            this.selectedModelElement = null;

            if (eventArgs.SelectedItems != null)
                if (eventArgs.SelectedItems.Count == 1)
                    this.selectedModelElement = eventArgs.SelectedItems[0] as DomainModelElement;
        }

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="modelData">Model data.</param>
        public void Execute(ModelData modelData)
        {
            // TODO: Change code here

            if (this.selectedModelElement != null)
            {
                ExampleElementViewModel vm = new ExampleElementViewModel(this.vmStore, this.selectedModelElement);

                ExampleWindow wnd = new ExampleWindow();
                wnd.DataContext = vm;
                wnd.ShowDialog();

                vm.Dispose();
            }
            else
                MessageBox.Show("No element selected!");
        }
    }
}
