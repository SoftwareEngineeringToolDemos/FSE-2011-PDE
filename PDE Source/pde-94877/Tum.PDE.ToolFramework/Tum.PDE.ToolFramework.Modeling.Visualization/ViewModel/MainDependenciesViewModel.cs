using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// Main view model to display dependencies.
    /// </summary>
    public class MainDependenciesViewModel : BaseDockingViewModel
    {
        private SelectedItemsCollection selectedItemsCollection = null;
        private DependenciesViewModel dependenciesViewModel;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MainDependenciesViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            dependenciesViewModel = new DependenciesViewModel(viewModelStore, true);

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));

            this.PreInitialize();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            if (this.selectedItemsCollection != null)
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateDependenciesVM));
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "DependenciesDockWindowPane"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Dependencies"; }
        }
        #endregion

        /// <summary>
        /// Gets the currently selected items in the property grid.
        /// </summary>
        protected SelectedItemsCollection SelectedItemsCollection
        {
            get { return this.selectedItemsCollection; }
        }

        /// <summary>
        /// Gets the dependencies view model.
        /// </summary>
        public DependenciesViewModel DependenciesViewModel
        {
            get { return this.dependenciesViewModel; }
        }

        /// <summary>
        /// Callback from SelectionChangedEvent. 
        /// Executes UpdatePropertyGrid asynchronously on the thread Dispatcher.Current is associated with.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected virtual void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            this.selectedItemsCollection = eventArgs.SelectedItems;

            if (this.IsInitialized && this.IsDockingPaneVisible)
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateDependenciesVM));
        }

        /// <summary>
        /// Updates the dependencies vm, based on SelectedItemsCollection.
        /// </summary>
        protected virtual void UpdateDependenciesVM()
        {
            if (this.SelectedItemsCollection != null)
            {
                try
                {
            List<ModelElement> elements = new List<ModelElement>();
            foreach (ModelElement m in this.SelectedItemsCollection)
                elements.Add(m);
            this.dependenciesViewModel.Set(elements);
        }
                catch { }
            }
        }

        /// <summary>
        /// Reset view model.
        /// </summary>
        protected override void OnReset()
        {
            if( this.selectedItemsCollection != null )
                this.SelectedItemsCollection.Clear();
            this.DependenciesViewModel.Clear();

            base.OnReset();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.selectedItemsCollection != null)
                this.SelectedItemsCollection.Clear();
            this.DependenciesViewModel.Dispose();

            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));

            base.OnDispose();

        }

        /// <summary>
        /// Visibility changed.
        /// </summary>
        /// <param name="bVisible"></param>
        protected override void OnVisibilityChanged(bool bVisible)
        {
            base.OnVisibilityChanged(bVisible);

            if (this.IsDockingPaneVisible && this.IsInitialized)
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateDependenciesVM));
        }
    }
}
