using System.Collections.Generic;
using System.Linq;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Fluent;
using System;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Loaders;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This class represents the main view model. A main view model hosts multiple sub views of type BaseDockingViewModel.
    /// </summary>
    public abstract class MainViewModel : BaseMainViewModel, Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts.IMainViewModel
    {
        #region Fields
        private DockingLayoutManager layoutManager = null;

        private MRUFilesViewModel mruFilesViewModel;

        // default ribbon commands,  that are specific to the global view model.
        private DelegateCommand newModelCommand;
        private DelegateCommand openModelCommand;
        private DelegateCommand saveModelCommand;
        private DelegateCommand saveAsModelCommand;
        private DelegateCommand closeModelCommand;

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

        private bool isInitialyInitialized = false;
        #endregion

        // TODO ???
        private System.Threading.ManualResetEvent loadingModelEvent = new System.Threading.ManualResetEvent(false);

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            loadingModelEvent.Set();
            
            this.newModelCommand = new DelegateCommand(NewModelCommandExecuted);
            this.openModelCommand = new DelegateCommand(OpenModelCommandExecuted);
            this.saveModelCommand = new DelegateCommand(SaveModelCommandExecuted, SaveModelCommandCanExecute, true);
            this.saveAsModelCommand = new DelegateCommand(SaveAsModelCommandExecuted, SaveAsModelCommandCanExecute, true);
            this.closeModelCommand = new DelegateCommand(CloseModelCommandExecuted, CloseModelCommandCanExecute, true);

            this.showModelTreeCommand = new DelegateCommand(ShowModelTreeCommandExecuted);
            this.showPropertiesCommand = new DelegateCommand(ShowPropertiesCommandExecuted);
            this.showErrorListCommand = new DelegateCommand(ShowErrorListCommandExecuted);
            this.showDependenciesCommand = new DelegateCommand(ShowDependenciesCommandExecuted);
            this.showDiagramSurfaceCommand = new DelegateCommand(ShowDiagramSurfaceCommandCommandExecuted);

            this.pluginInformationCommand = new DelegateCommand(PluginInformationCommandExecuted);
        }

        #region Properties: VMs
        /// <summary>
        /// Gets the selected model context VM.
        /// </summary>
        public override ModelContextViewModel SelectedModelContextViewModel
        {
            get
            {
                return base.SelectedModelContextViewModel;
            }
            set
            {
                base.SelectedModelContextViewModel = value;

                if (this.LayoutManager != null)
                {
                if (value != null)
                    this.LayoutManager.CurrentContextName = value.ModelContext.Name;
                else
                    this.LayoutManager.CurrentContextName = "_None_";
            }
        }
        }

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
        
        /// <summary>
        /// Gets the mru files view model.
        /// </summary>
        public MRUFilesViewModel MRUFilesViewModel
        {
            get
            {
                return this.mruFilesViewModel;
            }
        }
        #endregion

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            if (!isInitialyInitialized)
            {
                PleaseWaitHelper.Show();
                this.Initialize();
                PleaseWaitHelper.Hide();
            }
        }

        /// <summary>
        /// This is called to preinitialize the main vm. 
        /// </summary>
        protected override void PreInitialize()
        {
            base.PreInitialize();

            // init mru files view model
            this.mruFilesViewModel = new MRUFilesViewModel(this.ViewModelStore, this);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public void InitializeVM()
        {
            this.Initialize();
        }

        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {
            if (isInitialyInitialized)
                return;

            foreach (ModelContextViewModel vm in this.AvailableModelModelContextViewModels)
            {
                vm.InitializeMC();
            }

            base.Initialize();

            this.CloseCommand.RaiseCanExecuteChanged();
            this.SaveAsModelCommand.RaiseCanExecuteChanged();
            this.SaveModelCommand.RaiseCanExecuteChanged();

            this.OnPropertyChanged("NavigationManager");
            this.NavigateBackwardCommand.RaiseCanExecuteChanged();
            this.NavigateForwardCommand.RaiseCanExecuteChanged();
            
            this.OnPropertyChanged("SelectedModelContextViewModel");
            isInitialyInitialized = true;
        }

        /// <summary>
        /// Gets or sets the main ribbon menu.
        /// </summary>
        public override Ribbon Ribbon
        {
            get
            {
                return base.Ribbon;
            }
            set
            {
                base.Ribbon = value;

                if( this.LayoutManager != null )
                    this.LayoutManager.Ribbon = value;
            }
        }

        #region Method: Events
        /// <summary>
        /// React on active window pane changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ReactOnActivePaneChanged(object sender, ActivePaneChangedEventArgs e)
        {
            (e.DockableViewModel as BaseDockingViewModel).IsActiveView = true;
        }

        /// <summary>
        /// Culture info changed
        /// </summary>
        /// <param name="args">Culture info changed event arguments.</param>
        protected override void OnCultureInfoChanged(CultureInfoChangedEventArgs args)
        {
            base.OnCultureInfoChanged(args);

            this.LayoutManager.InvalidatePaneTitles();
        }
        
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

            if (eventArgs.IsActive)
            {
                // System.Windows.MessageBox.Show("Active view is: " + eventArgs.SourceViewModel);

                if (this.ActiveViewModel != null && this.ActiveViewModel != eventArgs.SourceViewModel)
                    this.ActiveViewModel.IsActiveView = false;

                this.LayoutManager.Activate(eventArgs.SourceViewModel as IDockableViewModel);
                this.ActiveViewModel = eventArgs.SourceViewModel as BaseDockingViewModel;

                if (this.ActiveViewModel.IsActiveView != true)
                {
                    this.ActiveViewModel.IsActiveView = true;
                }
            }
            else
            {
                //System.Windows.MessageBox.Show("Deactivated view is: " + eventArgs.SourceViewModel);
            }
        }

        /// <summary>
        /// Reacts on the OpenViewModel event.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void OpenViewModel(OpenViewModelEventArgs args)
        {
            if (args.ViewModelToOpen == null)
                return;

            if (!this.AllViewModels.Contains(args.ViewModelToOpen))
            {
                this.UnknownOpenedModels.Add(args.ViewModelToOpen);
            }

            this.LayoutManager.ShowWindow(args.ViewModelToOpen, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
            this.LayoutManager.BringToFrontWindow(args.ViewModelToOpen);
            args.ViewModelToOpen.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// Reacts on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void ShowViewModel(ShowViewModelRequestEventArgs args)
        {
            if (args.ViewName != null)
            {
                IDockableViewModel vm = this.LayoutManager.ShowWindow(args.ViewName, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
                if (vm != null)
                {
                    this.LayoutManager.BringToFrontWindow(vm);
                    vm.IsDockingPaneVisible = true;
                }
            }
            else if (args.SourceViewModel is IDockableViewModel)
            {
                this.LayoutManager.ShowWindow(args.SourceViewModel as IDockableViewModel, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
                this.LayoutManager.BringToFrontWindow(args.SourceViewModel as IDockableViewModel);
                (args.SourceViewModel as IDockableViewModel).IsDockingPaneVisible = true;
            }
        }

        /// <summary>
        /// React on CloseViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void CloseViewModel(CloseViewModelRequestEventArgs args)
        {
            if (args.SourceViewModel is IDockableViewModel)
            {
                if (!args.ShouldRemoveVM)
                {
                    this.LayoutManager.CloseWindow(args.SourceViewModel as IDockableViewModel);
                    (args.SourceViewModel as IDockableViewModel).IsDockingPaneVisible = false;
                }
                else
                    this.LayoutManager.CloseWindow(args.SourceViewModel as IDockableViewModel, true);
            }
        }

        /// <summary>
        /// React on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected override void BringtToFrontViewModel(BringToFrontViewModelRequestEventArgs args)
        {
            if (args.SourceViewModel is IDockableViewModel)
            {
                this.LayoutManager.BringToFrontWindow(args.SourceViewModel as IDockableViewModel);
            }
        }
        #endregion

        #region Methods: VMs
        /// <summary>
        /// Show plugin if it was shown before (layout manager stores the information).
        /// </summary>
        /// <param name="viewModel"></param>
        public override void ShowPluginIfShownBefore(BaseDiagramSurfaceViewModel viewModel)
        {
            if (this.LayoutManager != null)
                this.LayoutManager.ShowWindowBasedOnConfiguraion(viewModel);
        }

        /// <summary>
        /// This method is called from the SwitchContexts method before a switch occurs.
        /// </summary>
        /// <param name="newContextVM">New model context vm.</param>
        /// <param name="oldContextVM">Old model context vm.</param>
        protected override void BeforeSwitchContexts(ModelContextViewModel newContextVM, ModelContextViewModel oldContextVM)
        {
            if (oldContextVM != null)
            {
                if (this.LayoutManager != null)
                this.LayoutManager.SaveCurrentConfiguration(oldContextVM.ModelContext.Name);
            }

            base.BeforeSwitchContexts(newContextVM, oldContextVM);
        }

        /// <summary>
        /// This method is called from the SwitchContexts method after a switch occurs.
        /// </summary>
        /// <param name="newContextVM">New model context vm.</param>
        /// <param name="oldContextVM">Old model context vm.</param>
        protected override void AfterSwitchContexts(ModelContextViewModel newContextVM, ModelContextViewModel oldContextVM)
        {
            base.AfterSwitchContexts(newContextVM, oldContextVM);

            if (newContextVM != null)
            {
                if (this.LayoutManager != null)
                this.LayoutManager.RestoreConfiguration(newContextVM.ModelContext.Name, this.AllViewModels);
            }

            this.CloseCommand.RaiseCanExecuteChanged();
            this.SaveAsModelCommand.RaiseCanExecuteChanged();
            this.SaveModelCommand.RaiseCanExecuteChanged();
        }
        #endregion

        /// <summary>
        /// Gets or sets the layout docking manager.
        /// </summary>
        public DockingLayoutManager LayoutManager
        {
            get { return layoutManager; }
            set 
            { 
                if( this.layoutManager != null )
                {
                    this.layoutManager.PaneClosedEvent -= new DockingLayoutManager.PaneClosedEventHandler(LayoutManager_PaneClosedEvent);
                    this.layoutManager.ActivePaneChanged -= new DockingLayoutManager.ActivePaneChangedEventHandler(this.ReactOnActivePaneChanged);
                    this.layoutManager.MainDockingManager.Loaded -= new System.Windows.RoutedEventHandler(MainDockingManager_Loaded);
                }

                this.layoutManager = value;

                if (value != null)
                {
                    this.layoutManager.PaneClosedEvent += new DockingLayoutManager.PaneClosedEventHandler(LayoutManager_PaneClosedEvent);
                    this.layoutManager.ActivePaneChanged += new DockingLayoutManager.ActivePaneChangedEventHandler(this.ReactOnActivePaneChanged);
                    this.layoutManager.MainDockingManager.Loaded += new System.Windows.RoutedEventHandler(MainDockingManager_Loaded);

                    if (this.ActiveViewModel == null)
                    {
                        if (this.ModelTreeModel != null)
                            this.LayoutManager.Activate(this.ModelTreeModel);
                        else 
                            this.LayoutManager.InitialActivate();
                    }

                    this.OnLayoutManagerInitialized(new EventArgs());

                    if (this.Ribbon != null)
                        this.LayoutManager.Ribbon = this.Ribbon;
                }
            }
        }

        void MainDockingManager_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            EnsureViewModelVisibility();
        }
        void LayoutManager_PaneClosedEvent(object sender, PaneClosedEventArgs e)
        {
            BaseViewModel vm = e.DockableViewModel as BaseViewModel;
            if (vm is BaseDockingViewModel)
            {
                if (this.AllViewModels.Contains(vm as BaseDockingViewModel))
                    this.AllViewModels.Remove(vm as BaseDockingViewModel);
                if( this.UnknownOpenedModels.Contains(vm as BaseDockingViewModel))
                    this.UnknownOpenedModels.Remove(vm as BaseDockingViewModel);
            }

            if (vm != null)
                if (!vm.IsDisposed)
                    vm.Dispose();
        }

        #region Ribbon Commands

        /// <summary>
        /// New command, used to create a new document.
        /// </summary>
        public DelegateCommand NewModelCommand
        {
            get
            {
                return newModelCommand;
            }
        }

        /// <summary>
        /// New command, used to open an existing document.
        /// </summary>
        public DelegateCommand OpenModelCommand
        {
            get
            {
                return openModelCommand;
            }
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
        /// New command, used to save an opened document to a new file.
        /// </summary>
        public DelegateCommand SaveAsModelCommand
        {
            get
            {
                return saveAsModelCommand;
            }
        }

        /// <summary>
        /// New command, used to close an opened document.
        /// </summary>
        public DelegateCommand CloseModelCommand
        {
            get
            {
                return closeModelCommand;
            }
        }

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
        /// New command executed.
        /// </summary>
        protected virtual void NewModelCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;

            if (CloseModelCommandCanExecute())
                if (!CloseModelCommandExecute())
                    return;

            ISaveFileService saveFileService = this.GlobalServiceProvider.Resolve<ISaveFileService>();
            saveFileService.Filter = this.SelectedModelContextViewModel.EditorTitle + " files|*.xml|All files|*.*";
            if (saveFileService.ShowDialog(null) == true)
            {
                System.IO.StreamWriter writer = System.IO.File.CreateText(saveFileService.FileName);
                writer.Close();

                using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
                {
                    this.Reset();
                    this.SelectedModelContextViewModel.ModelContext.Load(saveFileService.FileName, false);

                    // add to mru list
                    this.MRUFilesViewModel.AddMRUEntry(saveFileService.FileName);

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
                }
            }

            if (!this.isInitialyInitialized)
            {
                PleaseWaitHelper.Show();
                this.Initialize();
                PleaseWaitHelper.Hide();
            }

            this.CloseCommand.RaiseCanExecuteChanged();
            this.SaveAsModelCommand.RaiseCanExecuteChanged();
            this.SaveModelCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Open command executed.
        /// </summary>
        protected virtual void OpenModelCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;

            IOpenFileService openFileService = this.GlobalServiceProvider.Resolve<IOpenFileService>();
            //openFileService.InitialDirectory = System.Windows.Application.Current.StartupUri.AbsolutePath;
            openFileService.Filter = this.SelectedModelContextViewModel.EditorTitle + " files|*.xml|All files|*.*";
            if (openFileService.ShowDialog(null) == true)
            {
                OpenModel(openFileService.FileName);
            }
        }

        /// <summary>
        /// Open model.
        /// </summary>
        /// <param name="fileName">File to open.</param>
        public virtual void OpenModel(string fileName)
        {
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;
            
            if (CloseModelCommandCanExecute())
                if (!CloseModelCommandExecute())
                    return;

            if (this.Ribbon != null)
                this.Ribbon.IsBackstageOpen = false;

            if (!System.IO.File.Exists(fileName))
            {
                IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                messageBox.ShowError("File does not exists: " + fileName);
                return;
            }

            // LOAD model in background thread
            // in main UI thread, load avalondock
            // --> wait on ui thread for model load to finish...
            /*if (!this.isInitialyInitialized)
            {
                #region MT-Load
                PleaseWaitHelper.Show();

                loadingModelEvent.Reset();

                this.ViewModelStore.InLoad = true;
                this.Reset();

                System.ComponentModel.BackgroundWorker loadModel = new System.ComponentModel.BackgroundWorker();
                loadModel.DoWork += new System.ComponentModel.DoWorkEventHandler(loadModel_DoWork);
                loadModel.RunWorkerAsync(fileName);

                this.Initialize();
                this.loadingModelEvent.WaitOne();

                // add to mru list
                this.MRUFilesViewModel.AddMRUEntry(fileName);

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

                this.ViewModelStore.InLoad = false;

                // Open views based on the configuration in the layout manager
                if (this.LayoutManager != null)
                    if (this.LayoutManager.ConfigurationManager != null)
                        foreach (string paneName in this.LayoutManager.CurrentConfiguration.Configurations.Keys)
                        {
                            DockingPaneConfiguration paneConfig = this.LayoutManager.CurrentConfiguration.Configurations[paneName];
                            if (paneConfig.IsRestorable && paneConfig.RestoreInformation != null && paneConfig.DockingPaneType != null)
                            {
                                if (!this.LayoutManager.HasWindow(paneConfig.PaneName))
                                {
                                    // create new modal window
                                    BaseDiagramSurfaceViewModel vm = this.ViewModelStore.TopMostStore.Factory.CreateRestorableViewModel(paneConfig.DockingPaneType);
                                    if (vm != null && vm is IRestorableDockableViewModel)
                                    {
                                        if ((vm as IRestorableDockableViewModel).Restore(paneConfig.RestoreInformation))
                                        {
                                            OpenViewModelEventArgs args = new OpenViewModelEventArgs(vm);
                                            args.DockingPaneStyle = PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
                                            this.EventManager.GetEvent<OpenViewModelEvent>().Publish(args);
                                        }
                                        else
                                        {
                                            vm.Dispose();
                                        }
                                    }
                                }
                            }


                            // notify of change
                            if (items.Count > 0)
                                this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
                        }

                PleaseWaitHelper.Hide();
                #endregion
            }
            else
            {*/
                #region Normal Load
            using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                this.ViewModelStore.InLoad = true;
                
                this.Reset();
                this.SelectedModelContextViewModel.ModelContext.Load(fileName, false);

                // add to mru list
                this.MRUFilesViewModel.AddMRUEntry(fileName);

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

                this.ViewModelStore.InLoad = false;

                // Open views based on the configuration in the layout manager
                    if (this.LayoutManager != null)
                        if (this.LayoutManager.ConfigurationManager != null)
                foreach (string paneName in this.LayoutManager.CurrentConfiguration.Configurations.Keys)
                {
                    DockingPaneConfiguration paneConfig = this.LayoutManager.CurrentConfiguration.Configurations[paneName];
                    if (paneConfig.IsRestorable && paneConfig.RestoreInformation != null && paneConfig.DockingPaneType != null)
                    {
                        if (!this.LayoutManager.HasWindow(paneConfig.PaneName))
                        {
                            // create new modal window
                            BaseDiagramSurfaceViewModel vm = this.ViewModelStore.TopMostStore.Factory.CreateRestorableViewModel(paneConfig.DockingPaneType);
                            if (vm != null && vm is IRestorableDockableViewModel)
                            {
                                if ((vm as IRestorableDockableViewModel).Restore(paneConfig.RestoreInformation))
                                {
                                    OpenViewModelEventArgs args = new OpenViewModelEventArgs(vm);
                                    args.DockingPaneStyle = PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
                                    this.EventManager.GetEvent<OpenViewModelEvent>().Publish(args);
                                }
                                else
                                {
                                    vm.Dispose();
                                }
                            }
                        }
                    }
                }

                // notify of change
                if (items.Count > 0)
                    this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
            }
                #endregion
            //}

        }

        void loadModel_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                this.SelectedModelContextViewModel.ModelContext.Load((string)e.Argument, false);
            }
            catch { }
            finally
            {
                this.loadingModelEvent.Set();
            }
        }

        /// <summary>
        /// Save command executed.
        /// </summary>
        protected virtual void SaveModelCommandExecuted()
        {
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
            }
        }

        /// <summary>
        /// Save command can execute.
        /// </summary>
        /// <returns>True if the save command can be executed. False otherwise.</returns>
        protected virtual bool SaveModelCommandCanExecute()
        {
            if (this.SelectedModelContextViewModel == null)
                return false;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return false;

            if (this.SelectedModelContextViewModel.ModelContext.RootElement == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Save As command executed.
        /// </summary>
        protected virtual void SaveAsModelCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;

            ISaveFileService saveFileService = this.GlobalServiceProvider.Resolve<ISaveFileService>();
            saveFileService.Filter = this.SelectedModelContextViewModel.EditorTitle + " files|*.xml|All files|*.*";
            if (saveFileService.ShowDialog(null) == true)
            {
                // add to mru list
                this.MRUFilesViewModel.AddMRUEntry(saveFileService.FileName);

                //this.ViewModelStore.GetDomainModelServices(this.SelectedModelContextViewModel.ModelContext.RootElement).ElementParentProvider.SetDomainModelFilePath(this.SelectedModelContextViewModel.ModelContext.RootElement, saveFileService.FileName);
                (this.SelectedModelContextViewModel.ModelContext.RootElement as IParentModelElement).DomainFilePath = saveFileService.FileName;
                SaveModelCommandExecuted();

                this.SelectedModelContextViewModel.OnDocumentLoaded();
            }
        }

        /// <summary>
        /// Save as command can execute.
        /// </summary>
        /// <returns>True if the save as command can be executed. False otherwise.</returns>
        protected virtual bool SaveAsModelCommandCanExecute()
        {
            if (this.SelectedModelContextViewModel == null)
                return false;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return false;

            if (this.SelectedModelContextViewModel.ModelContext.RootElement == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Close command executed.
        /// </summary>
        private void CloseModelCommandExecuted()
        {
            CloseModelCommandExecute();
        }

        /// <summary>
        /// Close model command executed.
        /// </summary>
        /// <returns></returns>
        protected virtual bool CloseModelCommandExecute()
        {
            if (this.SelectedModelContextViewModel == null)
                return false;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return false;

            if (this.SelectedModelContextViewModel.ModelContext.IsDirty)
            {
                IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                CustomDialogResults dlgResult = messageBox.ShowYesNoCancel("Save changes to the current Model?", CustomDialogIcons.Question);
                if (dlgResult == CustomDialogResults.Cancel)
                    return false;
                else if (dlgResult == CustomDialogResults.Yes)
                {
                    using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
                    {
                        this.SelectedModelContextViewModel.ModelContext.Save((this.SelectedModelContextViewModel.ModelContext.RootElement as IParentModelElement).DomainFilePath);
                        //this.SelectedModelContextViewModel.ModelContext.Save(this.ViewModelStore.GetDomainModelServices(this.SelectedModelContextViewModel.ModelContext.RootElement).ElementParentProvider.GetDomainModelFilePath(this.SelectedModelContextViewModel.ModelContext.RootElement));
                    }
                }
            }
            using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                for (int i = this.UnknownOpenedModels.Count - 1; i >= 0; i--)
                {
                    BaseDiagramSurfaceViewModel vm = this.UnknownOpenedModels[i] as BaseDiagramSurfaceViewModel;
                    if (vm == null)
                        continue;

                    //foreach (BaseDiagramSurfaceViewModel vm in this.UnknownOpenedModels)
                    if (!vm.IsDisposed)
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm, true));
                }

                this.Reset();
                this.ModelData.Reset();
            }

            this.CloseCommand.RaiseCanExecuteChanged();
            this.SaveAsModelCommand.RaiseCanExecuteChanged();
            this.SaveModelCommand.RaiseCanExecuteChanged();

            this.SelectedModelContextViewModel.OnDocumentClosed();

            return true;
        }

        /// <summary>
        /// Close command can execute.
        /// </summary>
        /// <returns>True if the close command can be executed. False otherwise.</returns>
        protected virtual bool CloseModelCommandCanExecute()
        {
            if (this.SelectedModelContextViewModel == null)
                return false;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return false;

            if (this.SelectedModelContextViewModel.ModelContext.RootElement == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// ShowModelTreeview command executed.
        /// </summary>
        protected virtual void ShowModelTreeCommandExecuted()
        {
            if (this.ModelTreeModel == null)
                return;

            this.LayoutManager.ShowWindow(this.ModelTreeModel, this.ModelTreeModel.DockingPaneStyle, this.ModelTreeModel.DockingPaneAnchorStyle);
            this.ModelTreeModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowProperties command executed.
        /// </summary>
        protected virtual void ShowPropertiesCommandExecuted()
        {
            if (this.PropertyGridModel == null)
                return;

            this.LayoutManager.ShowWindow(this.PropertyGridModel, this.PropertyGridModel.DockingPaneStyle, this.PropertyGridModel.DockingPaneAnchorStyle);
            this.PropertyGridModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowProperties command executed.
        /// </summary>
        protected virtual void ShowDependenciesCommandExecuted()
        {
            if (this.DependenciesModel == null)
                return;

            this.LayoutManager.ShowWindow(this.DependenciesModel, this.DependenciesModel.DockingPaneStyle, this.DependenciesModel.DockingPaneAnchorStyle);
            this.DependenciesModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowErrorList command executed.
        /// </summary>
        protected virtual void ShowErrorListCommandExecuted()
        {
            if (this.ErrorListModel == null)
                return;

            this.LayoutManager.ShowWindow(this.ErrorListModel, this.ErrorListModel.DockingPaneStyle, this.ErrorListModel.DockingPaneAnchorStyle);
            this.ErrorListModel.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// ShowDiagramSurface command executed.
        /// </summary>
        protected virtual void ShowDiagramSurfaceCommandCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;

            if (this.SelectedModelContextViewModel.DiagramSurfaceModel == null)
                return;

            this.LayoutManager.ShowWindow(this.SelectedModelContextViewModel.DiagramSurfaceModel, this.SelectedModelContextViewModel.DiagramSurfaceModel.DockingPaneStyle, this.SelectedModelContextViewModel.DiagramSurfaceModel.DockingPaneAnchorStyle);
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
        /// Called when the application exists.
        /// </summary>
        public override void OnExit()
        {
            base.OnExit();

            // save layout
            try
            {
                if (this.LayoutManager != null)
                {
                this.LayoutManager.SaveCurrentConfiguration(this.SelectedModelContextViewModel.ModelContext.Name);
                this.LayoutManager.SaveConfiguration();
            }
            }
            catch
            { 
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.mruFilesViewModel != null)
                this.mruFilesViewModel.Dispose();
            this.mruFilesViewModel = null;

            if( this.LayoutManager != null )
                this.LayoutManager.Dispose();
            this.LayoutManager = null;

            base.OnDispose();
        }

        /// <summary>
        /// Fires after the layout manager has been initialized.
        /// </summary>
        public event EventHandler LayoutManagerInitialized;

        /// <summary>
        /// Called after the layout manager has been initialized.
        /// </summary>
        /// <param name="e"></param>
        protected void OnLayoutManagerInitialized(EventArgs e)
        {
            if (LayoutManagerInitialized != null)
                LayoutManagerInitialized(this, e);
        }
    }
}
