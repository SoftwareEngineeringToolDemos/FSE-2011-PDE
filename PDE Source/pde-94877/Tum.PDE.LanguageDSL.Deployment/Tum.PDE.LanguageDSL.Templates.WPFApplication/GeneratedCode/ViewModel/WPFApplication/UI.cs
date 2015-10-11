 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Tum.VModellXT.ViewModel;

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorContracts = Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using DslEditorControls =  Tum.PDE.ToolFramework.Modeling.Visualization.Controls;
using DslEditorPopups   = Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Popups;
using DslEditorServices = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorCommands = Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorDiagramSurface = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;


namespace Tum.VModellXT.View
{
	/// <summary>
    /// This class is used as a base class for the main window of the editor.
    /// </summary>
	public abstract class DslEditorMainWindow : Fluent.RibbonWindow, IDisposable
	{
	    // Loading Process:
        // 1. DoLoadInBackground = true
        //    a. Create main welcome vm
        //    b. DoShowWelcomeScreen = true --> GetWelcomeWindow() as main content
        //    c. once ribbon has been created --> start loading data in background
        // 2. DoLoadInBackground = false
        //    a. Invoke loading on background ui thread
        //    b. load data, main vm --> load model (will invoke loading ui)

        // on first activated --> create ribbon control
        // once ribbon control is loaded --> check if main ui has loaded or subscribe 
        // to requests to open a model from WelcomeVM
        // --> if either of this is the case --> load main ui
	
		#region Field and Properties
        public bool DoLoadInBackground = true;
        public bool DoShowWelcomeScreen = true;
	
		private object loaderLock = new object();
        private bool hasFinishedLoading = false;
		
		/// <summary>
        /// VModellXT Modeling document data.
        /// </summary>
        public global::Tum.VModellXT.VModellXTDocumentData DocData = null;
		
        private System.Threading.ManualResetEvent viewModelInitializedEvent = new System.Threading.ManualResetEvent(false);
		private VModellXTMainViewModel mainViewModel = null;

		/// <summary>
        /// Main content host.
        /// </summary>
        public abstract System.Windows.Controls.ContentControl DockingHostControl
        {
            get;
        }
		
		/// <summary>
        /// Main content host.
        /// </summary>
        public abstract System.Windows.Controls.ContentControl RibbonHostControl
        {
            get;
        }

		/// <summary>
        /// Ribbon.
        /// </summary>
		public Fluent.Ribbon Ribbon
        {
            get;
			private set;
        }
		
        /// <summary>
        /// VModellXT Main view model.
        /// </summary>
        public VModellXTMainViewModel MainViewModel
		{
			get
			{
                if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                    if (!viewModelInitializedEvent.WaitOne(0))
                        // waiting
                        Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Waiting on ViewModel");			
			
				viewModelInitializedEvent.WaitOne();
				return mainViewModel;
			}
			set
			{
				this.mainViewModel = value;
				viewModelInitializedEvent.Set();
			}
		}
		
		/// <summary>
        /// VModellXT Welcome view model.
        /// </summary>
		public VModellXTWelcomeViewModel WelcomeViewModel
		{
			get;
			set;
		}

        /// <summary>
        /// Imported plugins which suffice to the IPlugin interface.
        /// </summary>
		[System.ComponentModel.Composition.ImportMany(typeof(DslEditorContracts::IPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IPlugin> SimplePlugins { get; set; }

		/// <summary>
        /// Imported plugins which suffice to the IPlugin interface.
        /// </summary>
		[System.ComponentModel.Composition.ImportMany(typeof(DslEditorContracts::IModelPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IModelPlugin> SimpleModelPlugins { get; set; }
	
		/// <summary>
        /// Imported plugins which suffice to the IViewModelPlugin interface.
        /// </summary>
        [System.ComponentModel.Composition.ImportMany(typeof(DslEditorContracts::IViewModelPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IViewModelPlugin> ViewModelPlugins { get; set; }
		
        /// <summary>
        /// Plugins directory.
        /// </summary>
        public const string PluginsDirectory = "plugins";
        
		private bool isFirstActivate = false;
		
		/// <summary>
        /// Gets the name of the current editor.
        /// </summary>
        public virtual string AppName
        {
            get
            {
                return "VModellXT";
            }
        }
		
		/// <summary>
        /// Gets the name of the company providing this editor.
        /// </summary>
        public virtual string Company
		{
	        get
    	    {
        	    return "TUM";
        	}	
		}
		
		/// <summary>
        /// Gets the version of the editor.
        /// </summary>
        public virtual string Version
        {
            get
            {
			
                return "1.3";
            }
        }
		
		private string appDataDirectory = null;
		/// <summary>
        /// Gets the application data directory for the current editor.
        /// </summary>
		public virtual string AppDataDirectory
		{
			get
			{
				if( appDataDirectory == null )
				{
					appDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) 
										+ System.IO.Path.DirectorySeparatorChar 
										+ Company
										+ System.IO.Path.DirectorySeparatorChar
										+  AppName;
					
					if( !System.String.IsNullOrEmpty(Version) && !System.String.IsNullOrWhiteSpace(Version) )
						appDataDirectory += " " + Version;
					
	                if (!System.IO.Directory.Exists(appDataDirectory))
    	                System.IO.Directory.CreateDirectory(appDataDirectory);
				}
                return appDataDirectory;
			}
		}
		#endregion
		
		/// <summary>
        /// Constructor.
        /// </summary>
		public DslEditorMainWindow()
		{        
        }
		
        /// <summary>
        /// Gets the welcome window control.
        /// </summary>
        /// <returns></returns>
		protected virtual System.Windows.FrameworkElement GetWelcomeWindow()
		{
			return new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.WelcomeWindowControl();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            
            if (!isFirstActivate)
            {
                isFirstActivate = true;
                
				if( DoLoadInBackground )
				{
                	// create ribbon control
					CreateRibbon();
					
                    // set welcome vm.
					SetWelcomeViewModel();
				}
            }
        }
		
		/// <summary>
        /// Sets the welcome window.
        /// </summary>
        /// <returns></returns>
		protected virtual void SetWelcomeViewModel()
		{
			this.DataContext = WelcomeViewModel;
		}

		/// <summary>
        /// Initialize
        /// </summary>		
		public virtual void Initialize()
		{
			if( DoLoadInBackground )
			{
				WelcomeViewModel = new VModellXTWelcomeViewModel(AppDataDirectory + System.IO.Path.DirectorySeparatorChar + VModellXTViewModelOptions.OptionsFileName);
				WelcomeViewModel.OpenModelRequested += new EventHandler<DslEditorModeling.Visualization.Base.ViewModel.MainWelcomeViewModel.OpenModelEventArgs>(WelcomeViewModel_OpenModelRequested);
								
				if( DoShowWelcomeScreen )
					this.DockingHostControl.Content = GetWelcomeWindow();
			}
			else
			{
                // invoke loading on background ui thread
				if( !DoLoadInBackground ) 
				{
                    System.Windows.Application.Current.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Background, new System.Action(InitializeMainUI));

				}
			}
		}      
        private void InitializeMainUI()
        {
            // Initialize base services on the main thread.
            Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.BaseViewModel.SetupServices(); 

            // load data
            LoadModelDataHelper();

            // register resources and setupt main vm
            SetViewModel();

            // register windows.
            RegisterWindows();

            // create ribbon control
			CreateRibbon();

            // initialize main ui
            MainViewModel.InitializeVM();
        }
		
		void WelcomeViewModel_OpenModelRequested(object sender, DslEditorModeling.Visualization.Base.ViewModel.MainWelcomeViewModel.OpenModelEventArgs e)
        {
            // wait till background loading has finished...
		  	lock (loaderLock)
            {
				if( !hasFinishedLoading)
				{
                    LoadModelDataHelper();
                    SetViewModel();
					
					hasFinishedLoading = true;
				}
			}
			
			// change model context if required
            if (this.WelcomeViewModel != null && this.DoLoadInBackground)
                if (this.WelcomeViewModel.SelectedModelContextViewModel != null)
                    for (int i = 0; i < this.MainViewModel.AvailableModelModelContextViewModels.Count; i++)
                        if (this.MainViewModel.AvailableModelModelContextViewModels[i].ModelContext != null)
                            if (this.MainViewModel.AvailableModelModelContextViewModels[i].ModelContext.Name == this.WelcomeViewModel.SelectedModelContextViewModel.Name)
                            {
                                this.MainViewModel.SelectedModelContextViewModel = this.MainViewModel.AvailableModelModelContextViewModels[i];
                                break;
                            }
			
            // open model --> will automatically trigger update on ui
            MainViewModel.OpenModel(e.FileName);
        }
		
        void ViewModel_LayoutManagerInitialized(object sender, EventArgs e)
        {
            // update ui
            this.DockingHostControl.Content = this.MainViewModel.LayoutManager.MainDockingManager;
            this.MainViewModel.LayoutManagerInitialized -= new EventHandler(ViewModel_LayoutManagerInitialized);

			// register windows.
           	this.RegisterWindows();
			
            // set ribbon
			this.MainViewModel.Ribbon = Ribbon;
			
            // set data context
			this.DataContext = this.MainViewModel;
			
            // update ribbon items visibility, ...
            if( this.DoLoadInBackground )
                this.SetupRibbonOnMainSolutionLoad();
			
            if( Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState )
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Main solution ui loaded.");
        }
		
		#region Background Loading
		/// <summary>
        /// Load data and plugins in background.
        /// </summary>
        public void LoadInBackground()
        {
			if( !DoLoadInBackground )
				return;
				
            // wait on ui
            System.Windows.Application.Current.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Background, new System.Action(LoadInBackgroundStart));				
        }
        private void LoadInBackgroundStart()
        {
            // Initialize base services on the main thread.
            using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.BaseViewModel.SetupServices();
            }

            // load in background worker..
            System.ComponentModel.BackgroundWorker loadInBack = new System.ComponentModel.BackgroundWorker();
            loadInBack.DoWork += new System.ComponentModel.DoWorkEventHandler(loadInBack_DoWork);
            loadInBack.RunWorkerAsync();
        }
		
     	void loadInBack_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
			LoadModelData();
        }		
		private void LoadModelData()
		{
            lock (loaderLock)
            {
				if( hasFinishedLoading )
					return;
				
				LoadModelDataHelper();
				
				hasFinishedLoading = true;
            }
			
            System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Background, new System.Action(SetViewModel));
		}
		private void LoadModelDataHelper()
		{
			try{
				DocData = new VModellXTDocumentData();
				
				VModellXTViewModelStore vStore;
				if( this.WelcomeViewModel != null )
					vStore = new VModellXTViewModelStore(DocData, WelcomeViewModel.Options);
				else
					vStore = new VModellXTViewModelStore(DocData);
				
	         	MainViewModel = new VModellXTMainViewModel(vStore);
				
                this.LoadPlugins();
			}
			catch{}
			finally
			{
				viewModelInitializedEvent.Set();
			} 	
		}
		
        private void SetViewModel()
        {
			// Initialize resources
            using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                VModellXTMainViewModelBase.RegisterImportedLibrariesRessources(new System.Collections.Generic.List<string>());
            }
			
            this.MainViewModel.LayoutManagerInitialized += new EventHandler(ViewModel_LayoutManagerInitialized);
            
			// before this was called, layout manager was already initialized (possible, since in
            // some cases, this is called on the ui thread in the background --> queued for execution)
            if (this.MainViewModel.LayoutManager != null)
                this.ViewModel_LayoutManagerInitialized(null, null);			
        }

        /// <summary>
        /// Register windows..
        /// </summary>
        protected virtual void RegisterWindows()
        {
			// Register known windows
			DslEditorServices::IUIVisualizerService popupVisualizer = MainViewModel.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>();				
			popupVisualizer.TryRegister("SelectElementPopup", typeof(DslEditorPopups::SelectElementPopup));
			popupVisualizer.TryRegister("DeleteElementsPopup", typeof(DslEditorPopups::DeleteElementsPopup));				
			popupVisualizer.TryRegister("SelectElementWithRSTypePopup", typeof(DslEditorPopups::SelectElementWithRSTypePopup));
			popupVisualizer.TryRegister("SelectRSTypePopup", typeof(DslEditorPopups::SelectRSTypePopup));
        }

		#endregion
		
		#region Plugins
		/// <summary>
        /// Load plugins in background.
        /// </summary>
        public void LoadPlugins()
        {
            // load plugins
            System.ComponentModel.BackgroundWorker w = new System.ComponentModel.BackgroundWorker();
            w.DoWork += new System.ComponentModel.DoWorkEventHandler(loadPlugins_DoWork);
            w.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(loadPlugins_RunWorkerCompleted);
            w.RunWorkerAsync();
        }	
		
		/// <summary>
        /// Add plugins data in background.
        /// </summary>
        public void LoadPluginsPostProcess()
		{
            if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: start processing");

			if( SimplePlugins != null )
            if (SimplePlugins.Count > 0)
            {
                try
                {
                    foreach (DslEditorContracts::IPlugin plugin in SimplePlugins)
                        foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in MainViewModel.AvailableModelModelContextViewModels)
                        {
                            if (plugin.ModelContext == mcVM.ModelContext.Name || plugin.ModelContext == null)
                                mcVM.AddPlugin(plugin);
                        }
                }
                catch (System.Exception ex)
                {
                    Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Load plugins progess: simple plugins (1) processed error: " + ex.Message);
                }
				
				if (this.tabPluginsGrpFP != null)
                {
                    tabPluginsGrpFP.Visibility = System.Windows.Visibility.Visible;
                }
				else if( this.MainViewModel.LayoutManager != null )
				{
					CreateRibbonFPGroup();
				}
            }

            if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: simple plugins processed");
			
			if( SimpleModelPlugins != null )
            if (SimpleModelPlugins.Count > 0)
            {
                try
                {
                    foreach (DslEditorContracts::IModelPlugin plugin in SimpleModelPlugins)
                        foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in MainViewModel.AvailableModelModelContextViewModels)
                        {
                            if (plugin.ModelContext == mcVM.ModelContext.Name || plugin.ModelContext == null)
                                mcVM.AddPlugin(plugin);

                            plugin.SetViewModelStore(MainViewModel.ViewModelStore);
                        }
                }
                catch (System.Exception ex)
                {
                    Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Load plugins progess: simple plugins (2) processed error: " + ex.Message);
                }
                
				if (this.tabPluginsGrpFP != null)
                {
                    tabPluginsGrpFP.Visibility = System.Windows.Visibility.Visible;
                }
				else if( this.MainViewModel.LayoutManager != null )
				{
					CreateRibbonFPGroup();
				}
            }

            if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: simple model plugins processed");
			
			if( ViewModelPlugins != null )
            if (ViewModelPlugins.Count > 0)
            {
                foreach (DslEditorContracts::IViewModelPlugin plugin in ViewModelPlugins)
                {
                    try
                    {
                        DslEditorDiagramSurface::BaseDiagramSurfaceViewModel vm = plugin.GetViewModel(MainViewModel.ViewModelStore);
                        if (vm != null)
                        {
                            vm.VMPlugin = plugin;

                            foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in MainViewModel.AvailableModelModelContextViewModels)
                                if (plugin.ModelContext == null)
                                    mcVM.AddPluginViewModel(vm);
                                else if (plugin.ModelContext == mcVM.ModelContext.Name)
                                    mcVM.AddPluginViewModel(vm);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Load plugins progess: vm plugins processed error: " + ex.Message);
                    }

                	if (this.tabPluginsGrpVP != null)
                	{
	                    tabPluginsGrpVP.Visibility = System.Windows.Visibility.Visible;
                	}
					else if( this.MainViewModel.LayoutManager != null )
					{
						CreateRibbonVPGroup();
					}
                }
            }

            if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: view model plugins processed");
		}
		        
		void loadPlugins_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Background, new System.Action(LoadPluginsPostProcess));
        }

        void loadPlugins_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
				// Load plugins
				if (!System.IO.Directory.Exists(PluginsDirectory))
                	System.IO.Directory.CreateDirectory(PluginsDirectory);
					
				DirectoryCatalog directoryCatalog = new DirectoryCatalog(PluginsDirectory);
				CompositionContainer container = new CompositionContainer(directoryCatalog);
				
				if( Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState )
					Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: compose parts");
			
				container.ComposeParts(this);

                if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                    Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load plugins progess: compose parts done");

            }
            catch (System.Exception ex)
            {
				Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Load plugins progess error: " + ex.Message);
            }
			
			// wait for main VM
			this.viewModelInitializedEvent.WaitOne();
        }
		#endregion
		
		#region Ribbon
		
		protected Fluent.BackstageTabItem tabItemRecent;
		protected Fluent.BackstageTabItem tabItemFI;
		protected Fluent.BackstageTabItem tabItemCredits;
		
		protected Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabHome;
		protected Fluent.RibbonGroupBox tabHomeGrpCommon;
		protected Fluent.RibbonGroupBox tabHomeGrpCommands;
		protected Fluent.RibbonGroupBox tabHomeGrpNavigation;
		protected Fluent.RibbonGroupBox tabHomeGrpView;
		protected Fluent.RibbonGroupBox tabHomeGrpValidation;
		
		protected Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabEdit;
		protected Fluent.RibbonGroupBox tabEditGrpFindAdv;
		protected Fluent.RibbonGroupBox tabEditGrpFind;
		
		protected Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabView;
		protected Fluent.RibbonGroupBox tabViewgrpMC;
		protected Fluent.RibbonGroupBox tabViewGrpAV;
		
		protected Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabPlugins;
		protected Fluent.RibbonGroupBox tabPluginsGrpInformation;
		protected Fluent.RibbonGroupBox tabPluginsGrpFP;
		protected Fluent.RibbonGroupBox tabPluginsGrpVP;
		
		protected Fluent.Button backstageSaveModelButton;
		protected Fluent.Button backstageSaveAsModelButton;
		protected Fluent.Button backstageCloseModelButton;
		
		protected virtual void CreateRibbon()
		{
		    Ribbon = new Fluent.Ribbon();
		    Ribbon.Loaded += new RoutedEventHandler(ribbonControl_Loaded);
		
		    CreateRibbonBackstage(Ribbon);
		    Ribbon.Tabs.Add(CreateRibbonHomeTab(Ribbon));
		    Ribbon.Tabs.Add(CreateRibbonEditTab(Ribbon));
		    Ribbon.Tabs.Add(CreateRibbonViewTab(Ribbon));
		    Ribbon.Tabs.Add(CreateRibbonPluginsTab(Ribbon));
			
			this.tabEdit.IsEnabled = false;
			this.tabPlugins.IsEnabled = false;
		
		    this.RibbonHostControl.Content = this.Ribbon;
		}
		void ribbonControl_Loaded(object sender, RoutedEventArgs e)
		{
			if( Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState )
				Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Ribbon loaded");
		
			if( Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState )
				Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent("Load in background start");
			
			LoadInBackground();
			
		    if( !this.DoLoadInBackground )
				this.SetupRibbonOnMainSolutionLoad();	
		}
		
		protected virtual void SetupRibbonOnMainSolutionLoad()
		{
			this.tabEdit.IsEnabled = true;
			this.tabPlugins.IsEnabled = true;
			
			this.tabHomeGrpCommon.IsEnabled = true;
			this.tabHomeGrpCommands.IsEnabled = true;
			this.tabHomeGrpNavigation.IsEnabled = true;
			this.tabHomeGrpView.IsEnabled = true;
			this.tabHomeGrpValidation.IsEnabled = true;	
			
			if( this.tabViewGrpAV == null )
				this.CreateRibbonViewTabAVGroup();
			if (this.tabPluginsGrpFP == null)
				CreateRibbonFPGroup();
			if (this.tabPluginsGrpVP == null)
				CreateRibbonVPGroup();
			
			backstageSaveModelButton.IsEnabled = true;
			backstageSaveAsModelButton.IsEnabled = true;
			backstageCloseModelButton.IsEnabled = true;
		}	
		
		protected virtual Fluent.RibbonTabItem CreateRibbonHomeTab(Fluent.Ribbon ribbon)
		{
		    tabHome = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit();
		    tabHome.Header = "Home";
		    tabHome.LateInitializationTriggered += new EventHandler(tabHome_LateInitializationTriggered);
		
		    return tabHome;
		}
		void tabHome_LateInitializationTriggered(object sender, EventArgs e)
		{
		    Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabHome = (Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit)sender;
		    tabHome.LateInitializationTriggered -= new EventHandler(tabHome_LateInitializationTriggered);
		
		    Fluent.RibbonGroupBox grpCommon = new Fluent.RibbonGroupBox();
		    grpCommon.Header = "Common";
		    grpCommon.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Delete", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Delete-32.png", "Large", "ActiveViewModel.DeleteCommand"));
		    grpCommon.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Cut", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Cut-16.png", "Middle", "ActiveViewModel.CutCommand"));
		    grpCommon.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Copy", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Copy-16.png", "Middle", "ActiveViewModel.CopyCommand"));
		    grpCommon.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Paste", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Paste-16.png", "Middle", "ActiveViewModel.PasteCommand"));
		    tabHome.Groups.Add(grpCommon);
		    tabHomeGrpCommon = grpCommon;
		
		    Fluent.RibbonGroupBox grpCommands = new Fluent.RibbonGroupBox();
		    grpCommands.Header = "Commands";
		    grpCommands.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Undo", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Undo-32.png", "Large", "ActiveViewModel.UndoCommand"));
		    grpCommands.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Redo", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Redo-32.png", "Large", "ActiveViewModel.RedoCommand"));
		    tabHome.Groups.Add(grpCommands);
		    tabHomeGrpCommands = grpCommands;
		
		    Fluent.RibbonGroupBox grpNavigation = new Fluent.RibbonGroupBox();
		    grpNavigation.Header = "Commands";
		    grpNavigation.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Back", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Back-32.png", "Large", "NavigateBackwardCommand"));
		    grpNavigation.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Forward", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Forward-32.png", "Large", "NavigateForwardCommand"));
		    tabHome.Groups.Add(grpNavigation);
		    tabHomeGrpNavigation = grpNavigation;
		
		    // check which buttons are required
		    Fluent.RibbonGroupBox grpView = new Fluent.RibbonGroupBox();
		    grpView.Header = "View";
		    grpView.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Model Tree", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/ModelTree-32.png", "Large", "ShowModelTreeCommand"));
		    grpView.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Property Window", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/PropertyGrid-32.png", "Large", "ShowPropertiesCommand"));
		    grpView.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Error List", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/ErrorList-32.png", "Large", "ShowErrorListCommand"));
		    grpView.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Dependencies   ", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Refresh-16.png", "Middle", "ShowDependenciesCommand"));
		    grpView.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Diagram Surface", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/DiagramSurface-16.png", "Middle", "ShowDiagramSurfaceCommand"));
		    tabHome.Groups.Add(grpView);
		    tabHomeGrpView = grpView;
		
		    // check if required
		    Fluent.RibbonGroupBox grpValidation = new Fluent.RibbonGroupBox();
		    grpValidation.Header = "Commands";
		    grpValidation.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Validate", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Validate-32.png", "Large", "ActiveViewModel.ValidateCommand"));
		    grpValidation.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Validate All", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/ValidateAll-32.png", "Large", "ValidateAllCommand"));
		    tabHomeGrpValidation = grpValidation;
		    tabHome.Groups.Add(grpValidation);
			
			this.tabHomeGrpCommon.IsEnabled = false;
			this.tabHomeGrpCommands.IsEnabled = false;
			this.tabHomeGrpNavigation.IsEnabled = false;
			this.tabHomeGrpView.IsEnabled = false;
			this.tabHomeGrpValidation.IsEnabled = false;
		}
		
		protected virtual Fluent.RibbonTabItem CreateRibbonEditTab(Fluent.Ribbon ribbon)
		{
		    tabEdit = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit();
		    tabEdit.Header = "Edit";
		    tabEdit.LateInitializationTriggered += new EventHandler(tabEdit_LateInitializationTriggered);
		    return tabEdit;
		}
		void tabEdit_LateInitializationTriggered(object sender, EventArgs e)
		{
		    Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabEdit = (Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit)sender;
		    tabEdit.LateInitializationTriggered -= new EventHandler(tabEdit_LateInitializationTriggered);
		    Fluent.RibbonGroupBox grpFindAdv = new Fluent.RibbonGroupBox();
		    grpFindAdv.Header = "Find Advanced";
		    grpFindAdv.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Find Advanced", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/SearchAdvanced-32.png", "Large", "SearchModel.SearchAdvancedCommand"));
		    tabEdit.Groups.Add(grpFindAdv);
		    tabEditGrpFindAdv = grpFindAdv;
		
		    Fluent.RibbonGroupBox grpFind = new Fluent.RibbonGroupBox();
		    grpFind.Header = "Quick Find";
		    System.Windows.Controls.TextBox txt = new System.Windows.Controls.TextBox();
		    txt.Width = 250;
		    txt.Margin = new Thickness(0, 0, 0, 1);
		    tabEditGrpFind = grpFind;
		
		    Binding txtBinding = new Binding("SearchModel.SearchText");
		    txtBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		    txtBinding.Mode = BindingMode.TwoWay;
		    txt.SetBinding(System.Windows.Controls.TextBox.TextProperty, txtBinding);
		    grpFind.Items.Add(txt);
		
		    Fluent.ComboBox cmb = new Fluent.ComboBox();
		    cmb.IsReadOnly = true;
		    cmb.DisplayMemberPath = "DisplayName";
		    cmb.Text = "Find where";
		    cmb.Height = 23;
		    cmb.Width = 250;
		    grpFind.Items.Add(cmb);
		    Binding itemsSourceB = new Binding("SearchModel.SearchSource");
		    itemsSourceB.Mode = BindingMode.OneWay;
		    cmb.SetBinding(Fluent.ComboBox.ItemsSourceProperty, itemsSourceB);
		    Binding selectedItemB = new Binding("SearchModel.SelectedSearchSource");
		    selectedItemB.Mode = BindingMode.TwoWay;
		    cmb.SetBinding(Fluent.ComboBox.SelectedItemProperty, selectedItemB);
		
		    Fluent.ComboBox cmb2 = new Fluent.ComboBox();
		    cmb2.IsReadOnly = true;
		    cmb2.DisplayMemberPath = "DisplayName";
		    cmb2.Text = "Find criteria";
		    cmb2.Height = 23;
		    cmb2.Width = 250;
		    Binding itemsSourceB2 = new Binding("SearchModel.SearchCriteria");
		    itemsSourceB2.Mode = BindingMode.OneWay;
		    cmb2.SetBinding(Fluent.ComboBox.ItemsSourceProperty, itemsSourceB2);
		    Binding selectedItemB2 = new Binding("SearchModel.SelectedSearchCriteria");
		    selectedItemB2.Mode = BindingMode.TwoWay;
		    cmb2.SetBinding(Fluent.ComboBox.SelectedItemProperty, selectedItemB2);
		    grpFind.Items.Add(cmb2);
		
		    grpFind.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		         "Find", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Search-32.png", "Large", "SearchModel.SearchCommand"));
		
		    tabEdit.Groups.Add(grpFind);
		}
		
		protected virtual Fluent.RibbonTabItem CreateRibbonViewTab(Fluent.Ribbon ribbon)
		{
		    tabView = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit();
		    tabView.Header = "View";
		    
			// see if required
		    Fluent.RibbonGroupBox grpMC = new Fluent.RibbonGroupBox();
		    grpMC.Header = "Model Contexts";
		
		    ContentControl c = new ContentControl();
		    c.Template = (ControlTemplate)FindResource("RibbonViewTabMCTemplate");
		    grpMC.Items.Add(c);
		    tabView.Groups.Add(grpMC);
		    tabViewgrpMC = grpMC;
			
		    return tabView;
		}
		protected virtual Fluent.RibbonGroupBox CreateRibbonViewTabAVGroup()
		{
		    // see if required
		    Fluent.RibbonGroupBox grpAV = new Fluent.RibbonGroupBox();
		    grpAV.Header = "Additional Views";
		
		    ContentControl c2 = new ContentControl();
		    c2.Template = (ControlTemplate)FindResource("RibbonViewTabAVTemplate");
		    grpAV.Items.Add(c2);
		    tabView.Groups.Add(grpAV);
		    tabViewGrpAV = grpAV;
		    return grpAV;
		}
		
		protected virtual Fluent.RibbonTabItem CreateRibbonPluginsTab(Fluent.Ribbon ribbon)
		{
		    tabPlugins = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit();
		    tabPlugins.Header = "Plugins";
		    tabPlugins.LateInitializationTriggered += new EventHandler(tabPlugins_LateInitializationTriggered);
		
		    return tabPlugins;
		}
		protected virtual Fluent.RibbonGroupBox CreateRibbonFPGroup()
		{
		    Fluent.RibbonGroupBox grpFP = new Fluent.RibbonGroupBox();
		    grpFP.Header = "Functionality Plugins";
		    ContentControl c = new ContentControl();
		    c.Template = (ControlTemplate)FindResource("RibbonPluginsTabFPTemplate");
		    grpFP.Items.Add(c);
		    tabPlugins.Groups.Add(grpFP);
		    tabPluginsGrpFP = grpFP;
			
			return grpFP;
		}
		protected virtual Fluent.RibbonGroupBox CreateRibbonVPGroup()
		{
		   Fluent.RibbonGroupBox grpVP = new Fluent.RibbonGroupBox();
		    grpVP.Header = "View Plugins";
		    ContentControl c2 = new ContentControl();
		    c2.Template = (ControlTemplate)FindResource("RibbonPluginsTabVPTemplate");
		    grpVP.Items.Add(c2);
		    tabPlugins.Groups.Add(grpVP);
		    tabPluginsGrpVP = grpVP;
			return grpVP;
		}
		void tabPlugins_LateInitializationTriggered(object sender, EventArgs e)
		{
		    Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit tabPlugins = (Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonTabItemLateInit)sender;
		    tabPlugins.LateInitializationTriggered -= new EventHandler(tabPlugins_LateInitializationTriggered);
		
		    Fluent.RibbonGroupBox grpInformation = new Fluent.RibbonGroupBox();
		    grpInformation.Header = "Information";
		    grpInformation.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Info", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Information-32x32.png", "Large", "PluginInformationCommand"));
		    tabPlugins.Groups.Add(grpInformation);
		    tabPluginsGrpInformation = grpInformation;
		}
		
		protected virtual void CreateRibbonBackstage(Fluent.Ribbon ribbon)
		{
		    ribbon.BackstageItems.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "New", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/New-16.png", "Medium", "NewModelCommand"));
		    ribbon.BackstageItems.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Open...", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Open-16.png", "Medium", "OpenModelCommand"));
		    
			backstageSaveModelButton = Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Save", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Save-16.png", "Medium", "SaveModelCommand");
			ribbon.BackstageItems.Add(backstageSaveModelButton);
			backstageSaveModelButton.IsEnabled = false;
				
			backstageSaveAsModelButton = Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Save As...", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/SaveAs-32.png", "Medium", "SaveAsModelCommand");
		    ribbon.BackstageItems.Add(backstageSaveAsModelButton);
			backstageSaveAsModelButton.IsEnabled = false;
		
		    Fluent.BackstageTabItem tabItemRecent = new Fluent.BackstageTabItem();
		    tabItemRecent.Header = "Recent";
		    ContentControl c = new ContentControl();
		    c.Template = (ControlTemplate)FindResource("RibbonBackstageRecentItemsTemplate");
		    tabItemRecent.Content = c;
		    ribbon.BackstageItems.Add(tabItemRecent);
		
		    // see if needed
		    tabItemFI = new Fluent.BackstageTabItem();
		    tabItemFI.Header = "Further Information";
		    ContentControl c2 = new ContentControl();
		    c2.Template = (ControlTemplate)FindResource("RibbonBackstageFurtherInformationTemplate");
		    tabItemFI.Content = c2;
		    ribbon.BackstageItems.Add(tabItemFI);
		
		    // see if needed
		    tabItemCredits = new Fluent.BackstageTabItem();
		    tabItemCredits.Header = "Credits";
		    ContentControl c3 = new ContentControl();
		    c3.Template = (ControlTemplate)FindResource("RibbonBackstageCreditsTemplate");
		    tabItemCredits.Content = c3;
		    ribbon.BackstageItems.Add(tabItemCredits);
		
			backstageCloseModelButton = Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
		        "Close", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/CloseDocument-32.png", "Medium", "CloseModelCommand");
		    ribbon.BackstageItems.Add(backstageCloseModelButton);
			backstageCloseModelButton.IsEnabled = false;
		
		    Fluent.Button b = new Fluent.Button();
		    b.Text = "Exit";
		    b.Click += new RoutedEventHandler(ExitButton_Click);
		    b.Icon = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Exit-16.png", UriKind.Absolute));
		
		    ribbon.BackstageItems.Add(b);
		}
		
		#endregion
		
		#region Data
		public void LoadData()
		{
			if( this.DocData != null )
				this.DocData.InitAsync();
		}
		#endregion
		
		#region Closing + IDispose
		
		/// <summary>
        /// Called whenever the application is about to exit.
        /// </summary>
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {        
			if( this.viewModelInitializedEvent.WaitOne(0) )
				if( MainViewModel != null )
				{
            		if (!MainViewModel.CanExit())
                		e.Cancel = true;
            		else
			    		MainViewModel.OnExit();
				}
			
            base.OnClosing(e);
        }		
       
		/// <summary>
        /// Exit application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        protected void ExitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
		
        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {	
			
				if( this.viewModelInitializedEvent.WaitOne(0) )
    				if( MainViewModel != null )
						MainViewModel.Dispose();
					
				if( DocData != null )
					DocData.Dispose();
            }
        }
		#endregion
	}
}
