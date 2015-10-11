using System;
using System.Collections.ObjectModel;

using Tum.PDE.ToolFramework.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Plugins.BreadcrumbNavigation
{
    public class BreadcrumbNavigationViewModel : BaseDiagramSurfaceViewModel
    {
        /// <summary>
        /// Storage for the root tree item.
        /// </summary>
        protected BaseModelElementTreeViewModel rootTreeViewItemViewModelStorage = null;
        private ObservableCollection<BaseModelElementTreeViewModel> rootViewModels = null;
        private SelectedItemsCollection selectedItemsCollection = null;
        private string selectedPath = "";
        public bool notify = true;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public BreadcrumbNavigationViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, "")
        {
            this.DockedWindowDesiredHeight = 65;

            this.EventManager.GetEvent<DocumentClosingEvent>().Subscribe(OnDocumentClosing);

            if (this.ModelData.CurrentModelContext.RootElement != null)
                InitVM();
        }

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            InitVM();
        }

        private void OnDocumentClosing(DocumentEventArgs args)
        {
            ResetVM();
        }

        #region IDockableViewModel
        /// <summary>
        /// Gets the activation mode.
        /// </summary>
        public override Modeling.Visualization.Contracts.ViewModel.ActivationMode ActivationMode
        {
            get
            {
                return Modeling.Visualization.Contracts.ViewModel.ActivationMode.None;
            }
        }

        /// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "BreadcrumbNavigationDiagramSurfaceDockWindowPane"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Breadcrumb Navigation"; }
        }

        /// <summary>
        /// Gets the docking pane style.
        /// </summary>
        public override Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.Docked;
            }
        }

        /// <summary>
        /// Gets the docking pane anchor style.
        /// </summary>
        public override Modeling.Visualization.ViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return Modeling.Visualization.ViewModel.DockingPaneAnchorStyle.Top;
            }
        }
        #endregion

        private void InitVM()
        {
            if (rootViewModels == null && this.ModelData.CurrentModelContext.RootElement != null)
            {
                rootTreeViewItemViewModelStorage = this.ViewModelStore.Factory.CreateModelElementTreeViewModel(this.ModelData.CurrentModelContext.RootElement, true, true, null);
                rootViewModels = new System.Collections.ObjectModel.ObservableCollection<BaseModelElementTreeViewModel>();
                rootViewModels.Add(rootTreeViewItemViewModelStorage);
            }

            OnPropertyChanged("RootViewModels");
        }
        private void ResetVM()
        {
            SelectedPath = "";

            if (rootViewModels != null)
                rootViewModels.Clear();
            rootViewModels = null;

            if (rootTreeViewItemViewModelStorage != null)
                rootTreeViewItemViewModelStorage.Dispose();
            rootTreeViewItemViewModelStorage = null;

            OnPropertyChanged("RootViewModels");
        }

        /// <summary>
        /// Gets the root elements collection for binding to the tree view. It actually consists of only one element at all times.
        /// </summary>
        public virtual ObservableCollection<BaseModelElementTreeViewModel> RootViewModels
        {
            get
            { 
                return rootViewModels;
            }
        }

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        public string SelectedPath
        {
            get
            {
                return selectedPath;
            }
            set
            {
                if (selectedPath != value && this.RootViewModels != null)
                    if( this.RootViewModels.Count > 0 )
                {
                    selectedPath = value;
                    OnPropertyChanged("SelectedPath");

                    if (notify)
                    {
                        SelectedItemsCollection col = new SelectedItemsCollection();
                        if (value != null)
                        {
                            string[] elements = selectedPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                            BaseModelElementTreeViewModel vm = this.RootViewModels[0];
                            for(int i = 0; i < elements.Length; i++ )
                            {
                                for (int y = 0; y < vm.Children.Count; y++)
                                {
                                    if (vm.Children[y].Id.ToString() == elements[i])
                                    {
                                        vm = vm.Children[y];

                                        if (i == elements.Length - 1)
                                            col.Add(vm.Element);
                                        break;
                                    }
                                }

                            }
                        }
                        EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                    }
                }
            }
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected override void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.SourceViewModel != this)
            {
                this.selectedItemsCollection = eventArgs.SelectedItems;

                Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateSelectedElement));
            }
        }
        
        /// <summary>
        /// Updates the model tree, based on SelectedItemsCollection.
        /// </summary>
        private void UpdateSelectedElement()
        {
            if (rootTreeViewItemViewModelStorage == null)
                return;

            if (this.selectedItemsCollection.Count != 1)
                return;

            if (!(this.selectedItemsCollection[0] is ModelElement))
                return;

            string path = FindViewModel((selectedItemsCollection[0] as ModelElement).Id, this.rootTreeViewItemViewModelStorage);
            if (path != null)
            {
                notify = false;
                this.SelectedPath = path;
                notify = true;
            }
            //else
            //    path = this.rootTreeViewItemViewModelStorage.Id.ToString();

            
        }

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="elementId">Model element id.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public virtual string FindViewModel(Guid elementId, BaseModelElementTreeViewModel vm)
        {
            // search the children (without their children) first
            foreach (BaseModelElementTreeViewModel viewModel in vm.Children)
                if (viewModel.Element.Id == elementId)
                    return viewModel.Id.ToString();

            // continue search among children's children
            foreach (BaseModelElementTreeViewModel viewModel in vm.Children)
            {
                string modelFound = FindViewModel(elementId, viewModel);
                if (modelFound != null)
                    return viewModel.Id + "\\" + modelFound;
            }

            return null;
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void OnReset()
        {
            ResetVM();

            base.OnReset();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            // clean up.
            this.EventManager.GetEvent<DocumentClosingEvent>().Unsubscribe(OnDocumentClosing);

            base.OnDispose();
        }
    }
}
