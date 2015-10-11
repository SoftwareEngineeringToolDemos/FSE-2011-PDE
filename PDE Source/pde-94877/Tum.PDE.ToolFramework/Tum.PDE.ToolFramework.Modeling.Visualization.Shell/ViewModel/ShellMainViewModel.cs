using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Tum.PDE.ToolFramework.Modeling.Shell;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Shell.ViewModel
{
    /// <summary>
    /// This is the main view model for the Visual Studio shell.
    /// </summary>
    public abstract class ShellMainViewModel : BaseMainViewModel
    {
        private DelegateCommand showModelTreeCommand;
        private DelegateCommand showPropertiesCommand;
        private DelegateCommand showErrorListCommand;
        private DelegateCommand showDependenciesCommand;
        private DelegateCommand showDiagramSurfaceCommand;

        private DelegateCommand pluginInformationCommand;

        private MainModelTreeViewModel modelTreeModel = null;
        private MainErrorListViewModel errorListModel = null;
        private MainPropertyGridViewModel propertyGridModel = null;
        private MainDependenciesViewModel dependenciesModel = null;
        private MainSearchViewModel searchModel = null;

        private ModelPackage modelPackage;

        private ObservableCollection<IDockableViewModel> visibleCollection;
        private ObservableCollection<IDockableViewModel> hiddenCollection;

        private bool isDockingPaneActive = false;
        private bool triggerDockingPaneActivated = true;
        private IDockableViewModel selectedDocumentPane;

        private DelegateCommand saveModelCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="package">Package</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected ShellMainViewModel(ViewModelStore viewModelStore, ModelPackage package)
            : base(viewModelStore, false)
        {
            if (!this.ViewModelStore.CustomDataBag.ContainsKey(ShellViewModelStoreIds.ModelPackageId))
                this.ViewModelStore.CustomDataBag.Add(ShellViewModelStoreIds.ModelPackageId, package);

            if (!this.Store.CustomDataBag.ContainsKey(ShellViewModelStoreIds.ModelPackageId))
                this.Store.CustomDataBag.Add(ShellViewModelStoreIds.ModelPackageId, package);

            if (!this.Store.CustomDataBag.ContainsKey(ShellViewModelStoreIds.ViewModelStoreId))
                this.Store.CustomDataBag.Add(ShellViewModelStoreIds.ViewModelStoreId, this.ViewModelStore);

            this.saveModelCommand = new DelegateCommand(SaveModelCommandExecuted);

            this.modelPackage = package;

            this.EventManager.GetEvent<DocumentClosingEvent>().Subscribe(this.OnDocumentClosingEvent);
            this.EventManager.GetEvent<DocumentSavedEvent>().Subscribe(this.OnDocumentSavedEvent);

            this.showModelTreeCommand = new DelegateCommand(ShowModelTreeCommandExecuted);
            this.showPropertiesCommand = new DelegateCommand(ShowPropertiesCommandExecuted);
            this.showErrorListCommand = new DelegateCommand(ShowErrorListCommandExecuted);
            this.showDependenciesCommand = new DelegateCommand(ShowDependenciesCommandExecuted);
            this.showDiagramSurfaceCommand = new DelegateCommand(ShowDiagramSurfaceCommandCommandExecuted);

            this.pluginInformationCommand = new DelegateCommand(PluginInformationCommandExecuted);

            this.visibleCollection = new ObservableCollection<IDockableViewModel>();
            this.hiddenCollection = new ObservableCollection<IDockableViewModel>();

            this.Initialize();
        }
        
        /// <summary>
        /// Gets the visible document panes.
        /// </summary>
        public ObservableCollection<IDockableViewModel> VisibleDocumentPanes
        {
            get
            {
                return this.visibleCollection;
            }
        }

        /// <summary>
        /// Gets the hidden document panes.
        /// </summary>
        public ObservableCollection<IDockableViewModel> HiddenDocumentPanes
        {
            get
            {
                return this.hiddenCollection;
            }
        }

        /// <summary>
        /// Gets or sets whether this docking pane is active or not.
        /// </summary>
        public bool IsDockingPaneActive
        {
            get 
            {
                return this.isDockingPaneActive;
            }
            set
            {
                if (this.isDockingPaneActive != value)
                {
                    this.isDockingPaneActive = value;
                    this.OnPropertyChanged("IsDockingPaneActive");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether this docking pane is active or not.
        /// </summary>
        public bool TriggerDockingPaneActivated
        {
            get 
            {
                return this.triggerDockingPaneActivated;
            }
            set
            {
                if (this.triggerDockingPaneActivated != value)
                {
                    this.triggerDockingPaneActivated = value;
                    this.OnPropertyChanged("TriggerDockingPaneActivated");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected document pane.
        /// </summary>
        public IDockableViewModel SelectedDocumentPane
        {
            get
            {
                return this.selectedDocumentPane;
            }
            /*set
            {
                if (this.selectedDocumentPane != value)
                {
                    this.selectedDocumentPane = value;
                    this.OnPropertyChanged("SelectedDocumentPane");
                }
            }*/
            set
            {
                if (value == null && this.selectedDocumentPane != null)
                    if (this.selectedDocumentPane is BaseDockingViewModel)
                        (this.selectedDocumentPane as BaseDockingViewModel).IsActiveView = false;

                if (this.selectedDocumentPane != value)
                {
                    this.selectedDocumentPane = value;
                    this.OnPropertyChanged("SelectedDocumentPane");

                    if (this.selectedDocumentPane is BaseDockingViewModel)
                        (this.selectedDocumentPane as BaseDockingViewModel).IsActiveView = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the package main controller.
        /// </summary>
        public ShellPackageController PackageController
        {
            get;
            set;
        }

        /// <summary>
        /// Find view model of a specific type.
        /// </summary>
        /// <param name="type">Type of the vm.</param>
        /// <returns>Vm or null if not found.</returns>
        public BaseDockingViewModel FindViewModel(Type type)
        {
            if (type.IsSubclassOf(typeof(MainModelTreeViewModel)))
                return this.ModelTreeModel;
            if (type.IsSubclassOf(typeof(MainErrorListViewModel)))
                return this.ErrorListModel;
            if (type.IsSubclassOf(typeof(MainPropertyGridViewModel)))
                return this.PropertyGridModel;
            if (type.IsSubclassOf(typeof(MainDependenciesViewModel)))
                return this.DependenciesModel;

            foreach (BaseDockingViewModel vm in this.AllViewModels)
                if (vm.GetType().IsSubclassOf(type) || vm.GetType() == type)
                    return vm;

            return null;
        }

        /// <summary>
        /// Gets or sets the full file name.
        /// </summary>
        public string FullFileName
        {
            get;
            set;
        }

        /// <summary>
        /// New command, used to save an opened document.
        /// </summary>
        public DelegateCommand SaveModelCommand
        {
            get
            {
                return saveModelCommand;
            }
        }

        /// <summary>
        /// Save command executed.
        /// </summary>
        protected virtual void SaveModelCommandExecuted()
        {
            this.modelPackage.EditorFactory.ModelData.Save((this.SelectedModelContextViewModel.ModelContext.RootElement as IParentModelElement).DomainFilePath, 1, 0);

            /*
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;

            using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                this.SelectedModelContextViewModel.ModelContext.Save((this.SelectedModelContextViewModel.ModelContext.RootElement as IParentModelElement).DomainFilePath);
                //this.SelectedModelContextViewModel.ModelContext.Save(this.ViewModelStore.GetDomainModelServices(this.SelectedModelContextViewModel.ModelContext.RootElement).ElementParentProvider.GetDomainModelFilePath(this.SelectedModelContextViewModel.ModelContext.RootElement));

                if (this.SelectedModelContextViewModel.ModelContext.SerializationResult.Count() > 0)
                {
                    // clear current error list
                    this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

                    // add serialization result items
                    List<BaseErrorListItemViewModel> items = new List<BaseErrorListItemViewModel>();
                    foreach (SerializationMessage serializationMessage in this.SelectedModelContextViewModel.ModelContext.SerializationResult)
                    {
                        SerializationErrorListItemViewModel item = new SerializationErrorListItemViewModel(this.ViewModelStore, serializationMessage);
                        items.Add(item);
                    }

                    // notify of change
                    this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
                }
            }*/
        }

        #region Model Events
        private void OnDocumentClosingEvent(DocumentEventArgs args)
        {
            this.OnDocumentClosing();
        }
        private void OnDocumentSavedEvent(DocumentEventArgs args)
        {
            this.OnDocumentClosing();
        }

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();


            // clear current error list
            this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

            List<BaseErrorListItemViewModel> items = new List<BaseErrorListItemViewModel>();
            if (this.SelectedModelContextViewModel.ModelContext.SerializationResult.Count() > 0)
            {
                // add serialization result items

                foreach (SerializationMessage serializationMessage in this.SelectedModelContextViewModel.ModelContext.SerializationResult)
                {
                    SerializationErrorListItemViewModel item = new SerializationErrorListItemViewModel(this.ViewModelStore, serializationMessage);
                    items.Add(item);
                }
            }

            if (this.SelectedModelContextViewModel.ModelContext.ValidationResult.Count > 0)
            {
                foreach (IValidationMessage message in this.SelectedModelContextViewModel.ModelContext.ValidationResult)
                {
                    if (message is ModelValidationMessage)
                    {
                        ModelErrorListItemViewModel item = new ModelErrorListItemViewModel(this.ViewModelStore, message as ModelValidationMessage);
                        items.Add(item);
                    }
                    else if (message is ValidationMessage)
                    {
                        StringErrorListItemViewModel item = new StringErrorListItemViewModel(this.ViewModelStore, message.MessageId, ModelErrorListItemViewModel.ConvertCategory(message.Type), message.Description);
                        items.Add(item);
                    }
                }
            }

            // notify of change
            if (items.Count > 0)
                this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
        }

        /// <summary>
        /// Called during the document closing process.
        /// </summary>
        protected virtual void OnDocumentClosing()
        {
        }

        /// <summary>
        /// Called after the document has been saved.
        /// </summary>
        protected virtual void OnDocumentSaved()
        {

        }
        #endregion

        #region Method: Events
        /// <summary>
        /// Called whenver a subview becomes active. This is used to track what subview is currently active.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void ReactOnViewActivation(ActiveViewChangedEventArgs eventArgs)
        {
            if (eventArgs.SourceViewModel == null)
                return;

            if (!this.AllViewModels.Contains(eventArgs.SourceViewModel) && !this.UnknownOpenedModels.Contains(eventArgs.SourceViewModel))
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            if (eventArgs.IsActive)
            {
                // System.Windows.MessageBox.Show("Active view is: " + eventArgs.SourceViewModel);

                if (this.ActiveViewModel != null && this.ActiveViewModel != eventArgs.SourceViewModel)
                    this.ActiveViewModel.IsActiveView = false;

                //this.LayoutManager.Activate(eventArgs.SourceViewModel as IDockableViewModel);
                this.ActiveViewModel = eventArgs.SourceViewModel as BaseDockingViewModel;

                if (this.ActiveViewModel.IsActiveView != true)
                {
                    this.ActiveViewModel.IsActiveView = true;
                }
            }
            else
            {
                this.ActiveViewModel = NullDockingViewModel.GetNullDockingVM(this.ViewModelStore);

                //this.ActiveViewModel = null;
                //System.Windows.MessageBox.Show("Deactivated view is: " + eventArgs.SourceViewModel);
            }
        }

        /// <summary>
        /// Reacts on the OpenViewModel event.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void OpenViewModel(OpenViewModelEventArgs args)
        {
            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.OpenViewModel(args);
        }

        /// <summary>
        /// Reacts on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void ShowViewModel(ShowViewModelRequestEventArgs args)
        {
            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.ShowViewModel(args);
        }

        /// <summary>
        /// React on CloseViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void CloseViewModel(CloseViewModelRequestEventArgs args)
        {
            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.CloseViewModel(args);
        }

        /// <summary>
        /// React on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void BringtToFrontViewModel(BringToFrontViewModelRequestEventArgs args)
        {
            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.BringtToFrontViewModel(args);
        }
        #endregion

        #region Properties: VMs
        /// <summary>
        /// Gets or sets the view model used for the model tree.
        /// </summary>
        public MainModelTreeViewModel ModelTreeModel
        {
            get { return this.modelTreeModel; }
            set { this.modelTreeModel = value; }
        }

        /// <summary>
        /// Gets or sets the view model used for the error list.
        /// </summary>
        public MainErrorListViewModel ErrorListModel
        {
            get { return this.errorListModel; }
            set { this.errorListModel = value; }
        }

        /// <summary>
        /// Gets or sets the view model used for the property grid.
        /// </summary>
        public MainPropertyGridViewModel PropertyGridModel
        {
            get { return this.propertyGridModel; }
            set { this.propertyGridModel = value; }
        }

        /// <summary>
        /// Gets or sets the view model used to manage dependencies.
        /// </summary>
        public MainDependenciesViewModel DependenciesModel
        {
            get { return this.dependenciesModel; }
            set { this.dependenciesModel = value; }
        }

        /// <summary>
        /// Gets or sets the view model used for searching the domain model.
        /// </summary>
        public MainSearchViewModel SearchModel
        {
            get { return this.searchModel; }
            set { this.searchModel = value; }
        }
        #endregion
        
        #region Ribbon Commands
        /// <summary>
        /// ShowModelTreeview command, used to show the model tree docking window.
        /// </summary>
        public DelegateCommand ShowModelTreeCommand
        {
            get
            {
                return showModelTreeCommand;
            }
        }

        /// <summary>
        /// ShowProperties command, used to show the properties docking window.
        /// </summary>
        public DelegateCommand ShowPropertiesCommand
        {
            get
            {
                return showPropertiesCommand;
            }
        }

        /// <summary>
        /// ShowDependencies command, used to show the dependencies docking window.
        /// </summary>
        public DelegateCommand ShowDependenciesCommand
        {
            get
            {
                return showDependenciesCommand;
            }
        }

        /// <summary>
        /// ShowErrorList command, used to show the error list docking window.
        /// </summary>
        public DelegateCommand ShowErrorListCommand
        {
            get
            {
                return showErrorListCommand;
            }
        }

        /// <summary>
        /// ShowDiagramSurface command, used to show the default diagram surface docking window.
        /// </summary>
        public DelegateCommand ShowDiagramSurfaceCommand
        {
            get
            {
                return showDiagramSurfaceCommand;
            }
        }

        /// <summary>
        /// PluginInformationCommand.
        /// </summary>
        public DelegateCommand PluginInformationCommand
        {
            get
            {
                return this.pluginInformationCommand;
            }
        }
        #endregion

        #region Ribbon Methods
        /// <summary>
        /// ShowModelTreeview command executed.
        /// </summary>
        protected virtual void ShowModelTreeCommandExecuted()
        {
            if (this.ModelTreeModel == null)
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.LayoutManager.ShowWindow(this.ModelTreeModel, this.ModelTreeModel.DockingPaneStyle, this.ModelTreeModel.DockingPaneAnchorStyle);
            this.ModelTreeModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowProperties command executed.
        /// </summary>
        protected virtual void ShowPropertiesCommandExecuted()
        {
            if (this.PropertyGridModel == null)
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.LayoutManager.ShowWindow(this.PropertyGridModel, this.PropertyGridModel.DockingPaneStyle, this.PropertyGridModel.DockingPaneAnchorStyle);
            this.PropertyGridModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowProperties command executed.
        /// </summary>
        protected virtual void ShowDependenciesCommandExecuted()
        {
            if (this.DependenciesModel == null)
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.LayoutManager.ShowWindow(this.DependenciesModel, this.DependenciesModel.DockingPaneStyle, this.DependenciesModel.DockingPaneAnchorStyle);
            this.DependenciesModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowErrorList command executed.
        /// </summary>
        protected virtual void ShowErrorListCommandExecuted()
        {
            if (this.ErrorListModel == null)
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.LayoutManager.ShowWindow(this.ErrorListModel, this.ErrorListModel.DockingPaneStyle, this.ErrorListModel.DockingPaneAnchorStyle);
            this.ErrorListModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowDiagramSurface command executed.
        /// </summary>
        protected virtual void ShowDiagramSurfaceCommandCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;

            if (this.PackageController == null)
                return;

            if (this.PackageController.CurrentShellViewModel != this)
                return;

            this.PackageController.LayoutManager.ShowWindow(this.SelectedModelContextViewModel.DiagramSurfaceModel, this.SelectedModelContextViewModel.DiagramSurfaceModel.DockingPaneStyle, this.SelectedModelContextViewModel.DiagramSurfaceModel.DockingPaneAnchorStyle);
            this.SelectedModelContextViewModel.DiagramSurfaceModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// Navigate forward command executed.
        /// </summary>
        protected virtual void PluginInformationCommandExecuted()
        {
            IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
            messageBox.ShowInformation("Plugins need to be placed at the location of the editor in the '/plugins' directory");
        }
        #endregion

        /// <summary>
        /// Ribbon.
        /// </summary>
        public override Fluent.Ribbon Ribbon
        {
            get
            {
                return base.Ribbon;
            }
            set
            {
                base.Ribbon = value;

                if (value != null)
                    foreach (BaseDockingViewModel vm in this.AllViewModels)
                        if (!vm.IsRibbonMenuInitialized)
                        {
                            vm.CreateRibbonMenu(value);
                        }
            }
        }

        /// <summary>
        /// Restore layout.
        /// </summary>
        /// <returns></returns>
        public void RestoreLayout()
        {
            if (this.PackageController != null)
                this.PackageController.RestoreLayout(this.FullFileName, this.AllViewModels);
                //this.PackageController.RestoreLayoutIfRequired();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<DocumentClosingEvent>().Unsubscribe(this.OnDocumentClosingEvent);
            this.EventManager.GetEvent<DocumentSavedEvent>().Unsubscribe(this.OnDocumentSavedEvent);

            if (this.PackageController != null)
                this.PackageController.RemoveShellViewModel(this);

            base.OnDispose();
        }
    }
}
