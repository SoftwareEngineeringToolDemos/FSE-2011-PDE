using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Fluent;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using System.ComponentModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Loaders;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This abstract class contains the base functionality of a main view model.
    /// </summary>
    public abstract class BaseMainViewModel : BaseWindowViewModel
    {
        #region Fields
        private LanguagesViewModel languagesViewModel = null;

        private Ribbon ribbon;
        
        private ObservableCollection<BaseDockingViewModel> allModels;
        private ReadOnlyObservableCollection<BaseDockingViewModel> allModelsRO;
        private List<BaseDockingViewModel> unknownOpenedModels;

        private CreditsViewModel creditsViewModel;
        private FurtherReadingViewModel furtherReadingViewModel;
        private BaseDockingViewModel activeViewModel = null;

        private DelegateCommand validateAllCommand;
        private DelegateCommand navigateBackwardCommand;
        private DelegateCommand navigateForwardCommand;

        private NavigationManager navigationManager;

        private ModelContextViewModel selectedModelContextViewModel;
        private List<ModelContextViewModel> availableModelModelContextViewModels;
        #endregion

        private string windowTitle = "";

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        public string WindowTitle
        {
            get {
                return this.windowTitle; 
            }
            set 
            {
                if (this.windowTitle != value)
                {
                    this.windowTitle = value;
                    this.OnPropertyChanged("WindowTitle");
                }
            }
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseMainViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="bCallIntialize">True if the Initialize method should be called.</param>
        protected BaseMainViewModel(ViewModelStore viewModelStore, bool bCallIntialize)
            : base(viewModelStore, false)
        {
            this.languagesViewModel = new LanguagesViewModel(this.ViewModelStore);
            this.availableModelModelContextViewModels = new List<ModelContextViewModel>();

            this.allModels = new ObservableCollection<BaseDockingViewModel>();
            this.allModelsRO = new ReadOnlyObservableCollection<BaseDockingViewModel>(allModels);
            this.unknownOpenedModels = new List<BaseDockingViewModel>();

            this.validateAllCommand = new DelegateCommand(ValidateAllCommandExecuted);
            this.navigateBackwardCommand = new DelegateCommand(NavigateBackwardCommandExecuted, NavigateBackwardCommandCanExecute, true);
            this.navigateForwardCommand = new DelegateCommand(NavigateForwardCommandExecuted, NavigateForwardCommandCanExecute, true);

            this.ModelData.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModelData_PropertyChanged);
            this.ModelData.BeforeModelContextChanged += new EventHandler(ModelData_BeforeModelContextChanged);
            this.ModelData.AfterModelContextChanged += new EventHandler(ModelData_AfterModelContextChanged);
            
            if (this.activeViewModel == null)
                this.activeViewModel = new NullDockingViewModel(this.ViewModelStore);

            this.PreInitialize();
            if (bCallIntialize)
                this.Initialize();
        }

        /// <summary>
        /// This is called to preinitialize the main vm. 
        /// </summary>
        protected virtual void PreInitialize()
        {
            // load options
            if( this.ViewModelStore.Options ==null || !this.ViewModelStore.Options.IsDeserialized)
                this.ViewModelStore.LoadOptions(this.GlobalServiceProvider.Resolve<IMessageBoxService>());

            this.RegisterModelDataEvents();
        }

        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {
            this.navigationManager = new NavigationManager(this.ViewModelStore);

            this.EventManager.GetEvent<ShowViewModelRequestEvent>().Subscribe(new Action<ShowViewModelRequestEventArgs>(ShowViewModel));
            this.EventManager.GetEvent<OpenViewModelEvent>().Subscribe(new Action<OpenViewModelEventArgs>(OpenViewModel));
            this.EventManager.GetEvent<CloseViewModelRequestEvent>().Subscribe(new Action<CloseViewModelRequestEventArgs>(CloseViewModel));
            this.EventManager.GetEvent<BringToFrontViewModelRequestEvent>().Subscribe(new Action<BringToFrontViewModelRequestEventArgs>(BringtToFrontViewModel));
            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
            this.EventManager.GetEvent<ActiveViewChangedEvent>().Subscribe(new Action<ActiveViewChangedEventArgs>(ReactOnViewActivation));


            base.Initialize();
        }

        #region Properties: VMs
        /// <summary>
        /// Gets the selected model context vm.
        /// </summary>
        public virtual ModelContextViewModel SelectedModelContextViewModel
        {
            get
            {
                return this.selectedModelContextViewModel;
            }
            set
            {
                if (this.SelectedModelContextViewModel == value)
                    return;

                if (this.SelectedModelContextViewModel != null)
                {
                    if (SwitchContexts(value, this.SelectedModelContextViewModel))
                    {
                        this.selectedModelContextViewModel.IsSelected = false;
                        this.selectedModelContextViewModel = value;
                        this.selectedModelContextViewModel.IsSelected = true;
                    }
                    else
                    {
                        value.IsSelected = false;
                        this.selectedModelContextViewModel.IsSelected = true;
                    }
                }
                else
                {
                    this.selectedModelContextViewModel = value;
                    this.selectedModelContextViewModel.IsSelected = true;
                }

                if (this.SelectedModelContextViewModel != null)
                    this.WindowTitle = this.SelectedModelContextViewModel.WindowTitle;
                else
                    this.WindowTitle = "";

                OnPropertyChanged("SelectedModelContextViewModel");
            }
        }

        /// <summary>
        /// Gets the available model context vms.
        /// </summary>
        public List<ModelContextViewModel> AvailableModelModelContextViewModels
        {
            get { return this.availableModelModelContextViewModels; }
        }

        /// <summary>
        /// Readonly collection of all view models.
        /// </summary>
        public ReadOnlyObservableCollection<BaseDockingViewModel> AllViewModelsRO
        {
            get { return this.allModelsRO; }
        }

        /// <summary>
        /// Readonly collection of all view models.
        /// </summary>
        public ObservableCollection<BaseDockingViewModel> AllViewModels
        {
            get { return this.allModels; }
        }

        /// <summary>
        /// Gets unknown opened models (Modal VMs).
        /// </summary>
        public List<BaseDockingViewModel> UnknownOpenedModels
        {
            get
            {
                return this.unknownOpenedModels;
            }
        }

        /// <summary>
        /// Gets the languages view model.
        /// </summary>
        public LanguagesViewModel LanguagesViewModel
        {
            get
            {
                return this.languagesViewModel;
            }
        }

        /// <summary>
        /// Gets the currently active view model. Can be null if none have been activated yet.
        /// </summary>
        public BaseDockingViewModel ActiveViewModel
        {
            get { return activeViewModel; }
            protected set
            {
                if (activeViewModel != value)
                {
                    activeViewModel = value;

                    //if (activeViewModel != null)
                    //    activeViewModel.UpdateCommandsCanExecute();

                    OnPropertyChanged("ActiveViewModel");
                }
            }
        }

        /// <summary>
        /// Gets the credits view model.
        /// </summary>
        public CreditsViewModel CreditsViewModel
        {
            get
            {
                return this.creditsViewModel;
            }
            protected set
            {
                this.creditsViewModel = value;
                OnPropertyChanged("CreditsViewModel");
            }
        }

        /// <summary>
        /// Gets whether there are credits that should be displayed or not.
        /// </summary>
        public bool HasCredits
        {
            get
            {
                if (this.CreditsViewModel == null)
                    return false;

                if (!this.CreditsViewModel.HasLinkItems)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets the further reading view model.
        /// </summary>
        public FurtherReadingViewModel FurtherReadingViewModel
        {
            get
            {
                return this.furtherReadingViewModel;
            }
            protected set
            {
                this.furtherReadingViewModel = value;
                OnPropertyChanged("FurtherReadingViewModel");
            }
        }

        /// <summary>
        /// Gets whether there are further readings that should be displayed or not.
        /// </summary>
        public bool HasFurtherReadings
        {
            get
            {
                if (this.FurtherReadingViewModel == null)
                    return false;

                if (!this.FurtherReadingViewModel.HasLinkItems)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets whether the validation menu is visible or not.
        /// </summary>
        public virtual bool IsValidationMenuVisible
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region Methods: VMs
        /// <summary>
        /// Show plugin if it was shown before (layout manager stores the information).
        /// </summary>
        /// <param name="viewModel"></param>
        public virtual void ShowPluginIfShownBefore(BaseDiagramSurfaceViewModel viewModel)
        {

        }

        /// <summary>
        /// Adds a view model as a child model of this view model.
        /// </summary>
        /// <param name="viewModel">View model to add to the children collection.</param>
        public virtual void AddViewModel(BaseDockingViewModel viewModel)
        {
            if (this.allModels.Contains(viewModel))
                return;

            // create contextual ribbon bars
            if (this.Ribbon != null)
                if (!viewModel.IsRibbonMenuInitialized && viewModel.IsInitialized)
                {
                    viewModel.CreateRibbonMenu(this.Ribbon);
                }

            this.allModels.Add(viewModel);
        }

        /// <summary>
        /// Ensures that only those view models are visible, that are general to all or specific to the current vm.
        /// </summary>
        protected virtual void EnsureViewModelVisibility()
        {
            // close all view models that do not belong to the new context
            foreach (BaseDockingViewModel vm in this.AllViewModels)
                if (vm is BaseDiagramSurfaceViewModel)
                    if ((vm as BaseDiagramSurfaceViewModel).ModelContextName != this.ModelData.CurrentModelContext.Name &&
                        !String.IsNullOrEmpty((vm as BaseDiagramSurfaceViewModel).ModelContextName))
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm, true));

            if (this.SelectedModelContextViewModel != null)
            {
                if (this.SelectedModelContextViewModel.DiagramSurfaceModel != null)
                    this.EventManager.GetEvent<ShowViewModelRequestEvent>().Publish(new ShowViewModelRequestEventArgs(this.SelectedModelContextViewModel.DiagramSurfaceModel));

                this.SelectedModelContextViewModel.OnActivated();
            }
        }
        #endregion

        #region Methods: Context Switch
        /// <summary>
        /// Switch model contexts.
        /// </summary>
        /// <param name="newContextVM">New model context vm.</param>
        /// <param name="oldContextVM">Old model context vm.</param>
        /// <returns>True if a switch did occur. False otherwise.</returns>
        protected virtual bool SwitchContexts(ModelContextViewModel newContextVM, ModelContextViewModel oldContextVM)
        {
            if (this.ModelData.CurrentModelContext.RootElement != null)
            {
                // notify that the current document will be closed
                IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                if (messageBox.ShowYesNoCancel("The currently opened document will be closed in the process of a context switch! Do you want to proceed?", CustomDialogIcons.Question) != CustomDialogResults.Yes)
                {
                    return false;
                }
            }


            PleaseWaitHelper.Show();
            BeforeSwitchContexts(newContextVM, oldContextVM);

            if (this.ModelData.CurrentModelContext.RootElement != null)
            {
                this.ModelData.CurrentModelContext.Reset();
            }
            this.Reset();

            // update model data
            this.ModelData.CurrentModelContext = newContextVM.ModelContext;

            AfterSwitchContexts(newContextVM, oldContextVM);


            PleaseWaitHelper.Hide();
            return true;
        }

        /// <summary>
        /// This method is called from the SwitchContexts method before a switch occurs.
        /// </summary>
        /// <param name="newContextVM">New model context vm.</param>
        /// <param name="oldContextVM">Old model context vm.</param>
        protected virtual void BeforeSwitchContexts(ModelContextViewModel newContextVM, ModelContextViewModel oldContextVM)
        {
            if (oldContextVM != null)
            {
                foreach (BaseDiagramSurfaceViewModel vm in oldContextVM.AdditionalDiagramSurfaceModels)
                    if (vm.IsDockingPaneVisible)
                    {
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm));
                    }

                foreach (BaseDiagramSurfaceViewModel vm in oldContextVM.PluginDiagramSurfaceModels)
                    if (vm.IsDockingPaneVisible)
                    {
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm));
                    }

                for (int i = unknownOpenedModels.Count - 1; i >= 0; i--)
                {
                    BaseDockingViewModel vm = unknownOpenedModels[i];
                    if (!vm.IsDisposed)
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm, true));
                }
            }

            // close all view models that do not belong to the new context
            foreach (BaseDockingViewModel vm in this.AllViewModels)
                if (vm is BaseDiagramSurfaceViewModel)
                    if ((vm as BaseDiagramSurfaceViewModel).ModelContextName != newContextVM.ModelContext.Name &&
                         !String.IsNullOrEmpty((vm as BaseDiagramSurfaceViewModel).ModelContextName))
                        this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm));
        }

        /// <summary>
        /// This method is called from the SwitchContexts method after a switch occurs.
        /// </summary>
        /// <param name="newContextVM">New model context vm.</param>
        /// <param name="oldContextVM">Old model context vm.</param>
        protected virtual void AfterSwitchContexts(ModelContextViewModel newContextVM, ModelContextViewModel oldContextVM)
        {
            if (newContextVM != null)
            {
                //if (newContextVM.DiagramSurfaceModel != null)
                //    this.EventManager.GetEvent<ShowViewModelRequestEvent>().Publish(new ShowViewModelRequestEventArgs(newContextVM.DiagramSurfaceModel));

                newContextVM.OnActivated();
            }
        }

        #endregion

        #region Methods: Events
        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected virtual void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            if (this.ActiveViewModel != null)
                this.ActiveViewModel.UpdateCommandsCanExecute();
        }
        
        /// <summary>
        /// Called whenver a subview becomes active. This is used to track what subview is currently active.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected abstract void ReactOnViewActivation(ActiveViewChangedEventArgs eventArgs);

        /// <summary>
        /// Reacts on the OpenViewModel event.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected abstract void OpenViewModel(OpenViewModelEventArgs args);

        /// <summary>
        /// Reacts on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected abstract void ShowViewModel(ShowViewModelRequestEventArgs args);

        /// <summary>
        /// React on CloseViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected abstract void CloseViewModel(CloseViewModelRequestEventArgs args);

        /// <summary>
        /// React on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        protected abstract void BringtToFrontViewModel(BringToFrontViewModelRequestEventArgs args);
        #endregion

        #region ModelData Events
        void CurrentModelContext_DocumentSaving(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentSavingEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }
        void CurrentModelContext_DocumentSaved(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentSavedEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }
        void CurrentModelContext_DocumentLoading(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentOpeningEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }
        void CurrentModelContext_DocumentLoaded(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentOpenedEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }
        void CurrentModelContext_DocumentClosing(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentClosingEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }
        void CurrentModelContext_DocumentClosed(object sender, EventArgs e)
        {
            this.EventManager.GetEvent<DocumentClosedEvent>().Publish(new DocumentEventArgs(this.ModelData));
        }

        private void RegisterModelDataEvents()
        {
            if (this.ModelData.CurrentModelContext != null)
            {
                this.ModelData.CurrentModelContext.DocumentClosed += new EventHandler(CurrentModelContext_DocumentClosed);
                this.ModelData.CurrentModelContext.DocumentClosing += new EventHandler(CurrentModelContext_DocumentClosing);
                this.ModelData.CurrentModelContext.DocumentLoaded += new EventHandler(CurrentModelContext_DocumentLoaded);
                this.ModelData.CurrentModelContext.DocumentLoading += new EventHandler(CurrentModelContext_DocumentLoading);
                this.ModelData.CurrentModelContext.DocumentReloaded += new EventHandler(CurrentModelContext_DocumentLoaded);
                this.ModelData.CurrentModelContext.DocumentReloading += new EventHandler(CurrentModelContext_DocumentLoading);
                this.ModelData.CurrentModelContext.DocumentSaved += new EventHandler(CurrentModelContext_DocumentSaved);
                this.ModelData.CurrentModelContext.DocumentSaving += new EventHandler(CurrentModelContext_DocumentSaving);
            }
        }
        private void UnregisterModelDataEvents()
        {
            if (this.ModelData.CurrentModelContext != null)
            {
                this.ModelData.CurrentModelContext.DocumentClosed -= new EventHandler(CurrentModelContext_DocumentClosed);
                this.ModelData.CurrentModelContext.DocumentClosing -= new EventHandler(CurrentModelContext_DocumentClosing);
                this.ModelData.CurrentModelContext.DocumentLoaded -= new EventHandler(CurrentModelContext_DocumentLoaded);
                this.ModelData.CurrentModelContext.DocumentLoading -= new EventHandler(CurrentModelContext_DocumentLoading);
                this.ModelData.CurrentModelContext.DocumentReloaded -= new EventHandler(CurrentModelContext_DocumentLoaded);
                this.ModelData.CurrentModelContext.DocumentReloading -= new EventHandler(CurrentModelContext_DocumentLoading);
                this.ModelData.CurrentModelContext.DocumentSaved -= new EventHandler(CurrentModelContext_DocumentSaved);
                this.ModelData.CurrentModelContext.DocumentSaving -= new EventHandler(CurrentModelContext_DocumentSaving);
            }
        }

        void ModelData_AfterModelContextChanged(object sender, EventArgs e)
        {
            RegisterModelDataEvents();
        }
        void ModelData_BeforeModelContextChanged(object sender, EventArgs e)
        {
            UnregisterModelDataEvents();
        }

        void ModelData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.ActiveViewModel == null)
                return;

            if (this.ActiveViewModel.IsDisposed)
                return;

            if (e.PropertyName == "CanUndo")
                if( this.ActiveViewModel.UndoCommand != null )
                    this.ActiveViewModel.UndoCommand.RaiseCanExecuteChanged();
            if (e.PropertyName == "CanRedo")
                if (this.ActiveViewModel.RedoCommand != null)
                    this.ActiveViewModel.RedoCommand.RaiseCanExecuteChanged();
        }
        #endregion

        /// <summary>
        /// Gets or sets the main ribbon menu.
        /// </summary>
        public virtual Ribbon Ribbon
        {
            get
            {
                return this.ribbon;
            }
            set
            {
                this.ribbon = value;

                // create ribbon menus
                if( this.ribbon != null )
                    foreach (BaseDockingViewModel vm in this.AllViewModels)
                        if( vm.IsInitialized )
                            if (!vm.IsRibbonMenuInitialized)
                            {
                                vm.CreateRibbonMenu(this.ribbon);
                            }
            }
        }
        
        /// <summary>
        /// Gets the navigation manager.
        /// </summary>
        public NavigationManager NavigationManager
        {
            get { return this.navigationManager; }
        }

        #region Ribbon Commands
        /// <summary>
        /// Validate all command, used to validate all elements in the domain model.
        /// </summary>
        public DelegateCommand ValidateAllCommand
        {
            get
            {
                return validateAllCommand;
            }
        }

        /// <summary>
        /// NavigateBackwardCommand.
        /// </summary>
        public DelegateCommand NavigateBackwardCommand
        {
            get
            {
                return this.navigateBackwardCommand;
            }
        }

        /// <summary>
        /// NavigateForwardCommand.
        /// </summary>
        public DelegateCommand NavigateForwardCommand
        {
            get
            {
                return this.navigateForwardCommand;
            }
        }
        #endregion

        #region Ribbon Methods
        /// <summary>
        /// Validate all command executed.
        /// </summary>
        protected virtual void ValidateAllCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return;

            using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                // clear error list
                this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

                List<IValidationMessage> messages = this.SelectedModelContextViewModel.ModelContext.ValidateAll();
                List<BaseErrorListItemViewModel> items = new List<BaseErrorListItemViewModel>();
                foreach (IValidationMessage message in messages)
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

                // notify of change
                this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
            }
        }

        /// <summary>
        /// Navigate forward command executed.
        /// </summary>
        protected virtual void NavigateForwardCommandExecuted()
        {
            if (this.ActiveViewModel != null)
                this.ActiveViewModel.IsActiveView = false;

            this.NavigationManager.NavigateForward();
            this.NavigateForwardCommand.CanExecute();

            Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(ReactivateActiveViewModel));
        }

        /// <summary>
        /// Navigate forward command can execute.
        /// </summary>
        /// <returns>True if the save command can be executed. False otherwise.</returns>
        protected virtual bool NavigateForwardCommandCanExecute()
        {
            if (NavigationManager == null)
                return false;

            return this.NavigationManager.CanNavigateForward();
        }

        /// <summary>
        /// Navigate backward command executed.
        /// </summary>
        protected virtual void NavigateBackwardCommandExecuted()
        {
            if (this.ActiveViewModel != null)
                this.ActiveViewModel.IsActiveView = false;

            this.NavigationManager.NavigateBackward();
            this.NavigateBackwardCommand.CanExecute();

            Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(ReactivateActiveViewModel));
        }

        /// <summary>
        /// Navigate backward command can execute.
        /// </summary>
        /// <returns>True if the save command can be executed. False otherwise.</returns>
        protected virtual bool NavigateBackwardCommandCanExecute()
        {
            if (NavigationManager == null)
                return false;

            return this.NavigationManager.CanNavigateBackward();
        }
        
        private void ReactivateActiveViewModel()
        {
            if (this.ActiveViewModel != null)
                this.ActiveViewModel.IsActiveView = true;
        }

        #endregion


        /// <summary>
        /// Reset ressources.
        /// </summary>
        public virtual void Reset()
        {
            // notify other views to execute the reset command
            EventManager.GetEvent<ResetViewModelEvent>().Publish(new ViewModelEventArgs(this));

            using (Microsoft.VisualStudio.Modeling.Transaction t = this.Store.TransactionManager.BeginTransaction("Reset data"))
            {
                this.EventManager.GetEvent<ResetDataEvent>().Publish(new EventArgs());
                t.Commit();
            }

            if (this.SelectedModelContextViewModel != null)
            {
                this.SelectedModelContextViewModel.Reset();
            }

            if( this.NavigationManager != null )
            this.NavigationManager.Reset();

            OnPropertyChanged("ActiveViewModel");
        }

        /// <summary>
        /// Called when the application exists.
        /// </summary>
        public virtual void OnExit()
        {
            // save layout
            this.ViewModelStore.SaveOptions(this.GlobalServiceProvider.Resolve<IMessageBoxService>());
        }

        /// <summary>
        /// Called when the application is about to exist.
        /// </summary>
        /// <returns>
        /// True if the application can exit. False to abbort exit.
        /// </returns>
        public virtual bool CanExit()
        {
            if (this.SelectedModelContextViewModel == null)
                return true;
            if (this.SelectedModelContextViewModel.ModelContext == null)
                return true;

            if (this.SelectedModelContextViewModel.ModelContext.RootElement != null)
                if (this.SelectedModelContextViewModel.ModelContext.IsDirty)
                {
                    IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                    CustomDialogResults dlgResult = messageBox.ShowYesNoCancel("Save changes to the current Model?", CustomDialogIcons.Question);
                    if (dlgResult == CustomDialogResults.Cancel)
                        return false;
                    if (dlgResult == CustomDialogResults.Yes)
                    {
                        using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
                        {

                            this.SelectedModelContextViewModel.ModelContext.Save((this.SelectedModelContextViewModel.ModelContext.RootElement as IParentModelElement).DomainFilePath);
                        }
                    }
                }

            return true;
        }


        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<ShowViewModelRequestEvent>().Unsubscribe(new Action<ShowViewModelRequestEventArgs>(ShowViewModel));
            this.EventManager.GetEvent<OpenViewModelEvent>().Unsubscribe(new Action<OpenViewModelEventArgs>(OpenViewModel));
            this.EventManager.GetEvent<CloseViewModelRequestEvent>().Unsubscribe(new Action<CloseViewModelRequestEventArgs>(CloseViewModel));
            this.EventManager.GetEvent<BringToFrontViewModelRequestEvent>().Unsubscribe(new Action<BringToFrontViewModelRequestEventArgs>(BringtToFrontViewModel));
            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
            this.EventManager.GetEvent<ActiveViewChangedEvent>().Unsubscribe(new Action<ActiveViewChangedEventArgs>(ReactOnViewActivation));

            this.ModelData.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModelData_PropertyChanged);
            this.ModelData.BeforeModelContextChanged -= new EventHandler(ModelData_BeforeModelContextChanged);
            this.ModelData.AfterModelContextChanged -= new EventHandler(ModelData_AfterModelContextChanged);

            this.UnregisterModelDataEvents();

            // dispose view models
            if (this.LanguagesViewModel != null)
                this.LanguagesViewModel.Dispose();
            this.languagesViewModel = null;

            if (this.Ribbon != null)
                this.Ribbon = null;

            if (this.ActiveViewModel != null)
                this.ActiveViewModel = null;

            //if (this.SelectedModelContextViewModel != null)
            //    this.SelectedModelContextViewModel = null;

            foreach (ModelContextViewModel vm in this.availableModelModelContextViewModels)
                vm.Dispose();
            this.availableModelModelContextViewModels.Clear();

            foreach (BaseDockingViewModel vm in this.AllViewModels)
            {
                if( vm.IsDockingPaneVisible )
                    this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm));
                vm.Dispose();
            }
            this.AllViewModels.Clear();

            foreach (BaseDockingViewModel vm in this.UnknownOpenedModels)
            {
                if( vm.IsDockingPaneVisible )
                    this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(vm, true));
                vm.Dispose();
            }

            if (this.creditsViewModel != null)
                this.creditsViewModel.Dispose();
            this.creditsViewModel = null;

            if (this.furtherReadingViewModel != null)
                this.furtherReadingViewModel.Dispose();
            this.furtherReadingViewModel = null;

            this.navigationManager.Reset();

            base.OnDispose();
        }
    }
}
