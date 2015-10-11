using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts;
using System.Windows;
using Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Base.Contracts;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls
{
    /// <summary>
    /// Main window for a PDE WPF application.
    /// </summary>
    public abstract class PDEMainWindow : Fluent.RibbonWindow, IDisposable
    {
        #region Fields
        private object loaderLock = new object();
        private bool hasFinishedLoading = false;

        /// <summary>
        /// VModellXT Modeling document data.
        /// </summary>
        public IDocData DocData = null;

        private System.Threading.ManualResetEvent viewModelInitializedEvent = new System.Threading.ManualResetEvent(false);
        private IMainViewModel mainViewModel = null;

        /// <summary>
        /// VModellXT Main view model.
        /// </summary>
        public IMainViewModel MainViewModel
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
        /// Welcome view model.
        /// </summary>
        public IMainWelcomeViewModel WelcomeViewModel
        {
            get;
            set;
        }

        /// <summary>
        /// True if the application should be initialized in background.
        /// </summary>
        public bool DoLoadInBackground = true;

        /// <summary>
        /// True if the the welcome screen should be displayed at startup. (DoLoadInBackground needs to be true for this).
        /// </summary>
        public bool DoShowWelcomeScreen = true;

        private bool isFirstActivate = false;

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
            protected set;
        }

        /// <summary>
        /// Gets the name of the current editor.
        /// </summary>
        public abstract string AppName
        {
            get;
        }

        /// <summary>
        /// Gets the name of the company providing this editor.
        /// </summary>
        public abstract string Company
        {
            get;
        }

        /// <summary>
        /// Gets the version of the editor.
        /// </summary>
        public abstract string Version
        {
            get;
        }

        private string appDataDirectory = null;

        /// <summary>
        /// Gets the application data directory for the current editor.
        /// </summary>
        public virtual string AppDataDirectory
        {
            get
            {
                if (appDataDirectory == null)
                {
                    appDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)
                                        + System.IO.Path.DirectorySeparatorChar
                                        + Company
                                        + System.IO.Path.DirectorySeparatorChar
                                        + AppName;

                    if (!System.String.IsNullOrEmpty(Version) && !System.String.IsNullOrWhiteSpace(Version))
                        appDataDirectory += " " + Version;

                    if (!System.IO.Directory.Exists(appDataDirectory))
                        System.IO.Directory.CreateDirectory(appDataDirectory);
                }
                return appDataDirectory;
            }
        }
        #endregion

        #region Welcome VM
        /// <summary>
        /// Gets the welcome window control.
        /// </summary>
        /// <returns></returns>
        protected virtual System.Windows.FrameworkElement GetWelcomeWindow()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.WelcomeWindowControl();
        }

        void WelcomeViewModel_OpenModelRequested(object sender, MainWelcomeViewModel.OpenModelEventArgs e)
        {
            // wait till background loading has finished...
            lock (loaderLock)
            {
                if (!hasFinishedLoading)
                {
                    LoadModelDataHelper();
                    SetViewModel();

                    hasFinishedLoading = true;
                }
            }

            SwitchModelContextIfRequired();

            // open model --> will automatically trigger update on ui
            MainViewModel.OpenModel(e.FileName);
        }
        
        /// <summary>
        /// Creates the welcome vm.
        /// </summary>
        /// <returns></returns>
        protected abstract IMainWelcomeViewModel CreateWelcomeViewModel();

        /// <summary>
        /// Sets the welcome window.
        /// </summary>
        /// <returns></returns>
        protected virtual void SetWelcomeViewModel()
        {
            this.DataContext = WelcomeViewModel;
        }
        #endregion

        #region Initialization Process ...
        /// <summary>
        /// Initialize
        /// </summary>		
        public virtual void Initialize()
        {
            if (DoLoadInBackground)
            {
                this.WelcomeViewModel = CreateWelcomeViewModel();
                if (this.WelcomeViewModel != null)
                {
                    this.WelcomeViewModel.OpenModelRequested += new EventHandler<MainWelcomeViewModel.OpenModelEventArgs>(WelcomeViewModel_OpenModelRequested);
                }

                if (DoShowWelcomeScreen)
                    this.DockingHostControl.Content = GetWelcomeWindow();
            }
            else
            {
                // invoke loading on background ui thread
                if (!DoLoadInBackground)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(
                        System.Windows.Threading.DispatcherPriority.Background, new System.Action(InitializeMainUIDirectly));

                }
            }
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

                OnActivated();
            }
        }

        /// <summary>
        /// Called once the application has been activated for the first time.
        /// </summary>
        protected virtual void OnActivated()
        {
            if (DoLoadInBackground)
            {
                // create ribbon control
                CreateRibbon();

                // set welcome vm.
                SetWelcomeViewModel();
            }
        }

        /// <summary>
        /// Directly loads main UI on startup.
        /// </summary>
        protected virtual void InitializeMainUIDirectly()
        {
            // Initialize base services on the main thread.
            InitializeServices();

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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ViewModel_LayoutManagerInitialized(object sender, EventArgs e)
        {
            // update ui
            this.DockingHostControl.Content = GetMainUIControl();
            this.MainViewModel.LayoutManagerInitialized -= new EventHandler(ViewModel_LayoutManagerInitialized);

            // register windows.
            if( this.DoLoadInBackground )
                this.RegisterWindows();

            // set ribbon
            this.MainViewModel.Ribbon = Ribbon;

            // set data context
            this.DataContext = this.MainViewModel;

            // update ribbon items visibility, ...
            if (this.DoLoadInBackground)
                this.SetupRibbonOnMainSolutionLoad();
        }
        #endregion

        #region Abstract Loading Helper Methods
        /// <summary>
        /// Initialize services
        /// </summary>
        protected abstract void InitializeServices();
        
        /// <summary>
        /// Register windows..
        /// </summary>
        protected abstract void RegisterWindows();

        /// <summary>
        /// Switch model context for the main VM if required.
        /// </summary>
        protected abstract void SwitchModelContextIfRequired();    
        
        /// <summary>
        /// Gets the main UI control.
        /// </summary>
        /// <returns></returns>
        protected abstract System.Windows.FrameworkElement GetMainUIControl();

        /// <summary>
        /// Creates and assings doc data.
        /// </summary>
        protected abstract void CreateAndAssignDocData();

        /// <summary>
        /// Creates and assings the main view model.
        /// </summary>
        protected abstract void CreateAndAssignMainViewModel();

        /// <summary>
        /// Register imported resources.
        /// </summary>
        protected abstract void RegisterImportedResources();

        /// <summary>
        /// Post process main vm init.
        /// </summary>
        /// <remarks>
        /// Before SetViewModel was called, layout manager was already initialized (possible, since in
        /// some cases, this is called on the ui thread in the background --> queued for execution)
        /// </remarks>
        protected abstract void PostProcessLMIfRequired();
        #endregion

        #region Background Loading
        /// <summary>
        /// Load data and plugins in background.
        /// </summary>
        public void LoadInBackground()
        {
            if (!DoLoadInBackground)
                return;

            // wait on ui
            System.Windows.Application.Current.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Background, new System.Action(LoadInBackgroundStart));
        }
        private void LoadInBackgroundStart()
        {
            // Initialize base services on the main thread.
            using (new WaitCursor())
            {
                this.InitializeServices();
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
                if (hasFinishedLoading)
                    return;

                LoadModelDataHelper();

                hasFinishedLoading = true;
            }

            System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Background, new System.Action(SetViewModel));
        }
        #endregion

        /// <summary>
        /// Load plugins in background.
        /// </summary>
        public abstract void LoadPlugins();

        private void SetViewModel()
        {
            // Initialize resources
            using (new WaitCursor())
            {
                RegisterImportedResources();
            }

            this.MainViewModel.LayoutManagerInitialized += new EventHandler(ViewModel_LayoutManagerInitialized);

            // before this was called, layout manager was already initialized (possible, since in
            // some cases, this is called on the ui thread in the background --> queued for execution)
            PostProcessLMIfRequired();
        }
        private void LoadModelDataHelper()
        {
            try
            {
                this.CreateAndAssignDocData();
                this.CreateAndAssignMainViewModel();

                this.LoadPlugins();
            }
            catch { }
            finally
            {
                viewModelInitializedEvent.Set();
            }
        }

        /// <summary>
        /// Load data.
        /// </summary>
        public void LoadData()
        {
            if (this.DocData != null)
                this.DocData.InitAsync();
        }

        #region Ribbon
        /// <summary>
        /// Create the ribbon control.
        /// </summary>
        protected virtual void CreateRibbon()
        {
            Ribbon = new Fluent.Ribbon();
            Ribbon.Loaded += new RoutedEventHandler(RibbonControl_Loaded);

            this.RibbonHostControl.Content = this.Ribbon;
        }

        void RibbonControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DoLoadInBackground)
                LoadInBackground();     // should this call not occur, the doc data will be initialized on demand (usually on model load)

            if (!this.DoLoadInBackground)
                if( this.Ribbon != null )
                    this.SetupRibbonOnMainSolutionLoad();
        }

        /// <summary>
        /// Setups the main ribbon solution on load.
        /// </summary>
        protected virtual void SetupRibbonOnMainSolutionLoad()
        {
        }	
		
        #endregion

        #region Closing + IDispose
        /// <summary>
        /// Called whenever the application is about to exit.
        /// </summary>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (this.viewModelInitializedEvent.WaitOne(0))
                if (MainViewModel != null)
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

                if (this.viewModelInitializedEvent.WaitOne(0))
                    if (MainViewModel != null)
                        MainViewModel.Dispose();

                if (DocData != null)
                    DocData.Dispose();
            }
        }
        #endregion
    }
}
