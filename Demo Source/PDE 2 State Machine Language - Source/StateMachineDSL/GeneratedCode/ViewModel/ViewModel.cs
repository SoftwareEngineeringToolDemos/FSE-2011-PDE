 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorVisualization = global::Tum.PDE.ToolFramework.Modeling.Visualization;
using DslEditorViewModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using DslEditorViewModelContracts = global::Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelModelTree = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using DslEditorViewModelPropertyGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using DslEditorViewModelServices = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorCommands = Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
	/// This class represents the main welcome view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageWelcomeViewModel : StateMachineLanguageWelcomeViewModelBase
	{		
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="optionsPath">Options path.</param>
		public StateMachineLanguageWelcomeViewModel(string optionsPath) : base(optionsPath)
		{
		}
	}
	
	/// <summary>
	/// This class represents the main welcome view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageWelcomeViewModelBase : Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.MainWelcomeViewModel
	{
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="optionsPath">Options path.</param>
		protected StateMachineLanguageWelcomeViewModelBase(string optionsPath) : base(optionsPath)
		{
			Initialize();
		}
		
		
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected virtual void Initialize()
        {  
			
			Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel mDefaultContext = 
				new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel(this, "DefaultContext", "Default Context");
			this.AvailableModelModelContextViewModels.Add(mDefaultContext);
			this.SelectedModelContextViewModel = mDefaultContext;
			this.Load(this.SelectedModelContextViewModel.Name);
			this.WindowTitle = "StateMachineLanguage";
	
			#region Further Readings
			this.FurtherReadingViewModel = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.FurtherReadingViewModel();

			#endregion
		}		
			
		#endregion		
	}

	/// <summary>
	/// This class represents the main view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageMainViewModel : StateMachineLanguageMainViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        public StateMachineLanguageMainViewModel(DslEditorModeling::ModelData modelData)
            : this(new StateMachineLanguageViewModelStore(modelData))
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageMainViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the main view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageMainViewModelBase : DslEditorViewModel::MainViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageMainViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {

        }
		#endregion

		/// <summary>
        /// Registers imported libraries main ressource dictionaries.
        /// </summary>
        /// <param name="handledLibraries">Already handled libraries.</param>
        public static void RegisterImportedLibrariesRessources(System.Collections.Generic.List<string> handledLibraries)
		{
			if( handledLibraries.Contains("StateMachineLanguage") )
				return;
			else
				handledLibraries.Add("StateMachineLanguage");
			
			System.Windows.Application.Current.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() 
            {
                Source = new System.Uri("pack://application:,,,/" + System.Reflection.Assembly.GetAssembly(typeof(StateMachineLanguageMainViewModelBase)).GetName().Name + ";component/Resources.xaml") 
            });			
	
		}		
			
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void PreInitialize()
        {         
			base.PreInitialize();

			foreach(DslEditorModeling::ModelContext modelContext in this.ModelData.AvailableModelContexts)
			{
			
				if( modelContext.Name == "DefaultContext")
				{
					DefaultContextModelContextViewModel mDefaultContext = new DefaultContextModelContextViewModel(this.ViewModelStore, modelContext, this);
					this.AvailableModelModelContextViewModels.Add(mDefaultContext);
					this.SelectedModelContextViewModel = mDefaultContext;
				}
			}
			
			this.SearchModel = new StateMachineLanguageSearchViewModel(ViewModelStore as StateMachineLanguageViewModelStore);			
			AddViewModel(SearchModel);
			AddViewModel(SearchModel.SearchResultViewModel);				
	
			#region Credits + Further Readings
			this.CreditsViewModel = new DslEditorViewModelData::CreditsViewModel(this.ViewModelStore);
			this.FurtherReadingViewModel = new DslEditorViewModelData::FurtherReadingViewModel(this.ViewModelStore);

	
			#endregion
		}		
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {        				
			base.Initialize();
						
			// register services
			StateMachineLanguageServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);

			// ensure context menu provider are initialized
			if( Tum.StateMachineDSL.ViewModel.ModelTree.StateMachineLanguageModelTreeContextMenuProvider.Instance == null )
				throw new System.ArgumentNullException("Context menu provider");
			
			this.ModelTreeModel = new StateMachineLanguageModelTreeViewModel(ViewModelStore as StateMachineLanguageViewModelStore);
			AddViewModel(ModelTreeModel);

			this.ErrorListModel = new StateMachineLanguageErrorListViewModel(ViewModelStore as StateMachineLanguageViewModelStore);
			AddViewModel(ErrorListModel);

			this.PropertyGridModel = new StateMachineLanguagePropertyGridViewModel(ViewModelStore as StateMachineLanguageViewModelStore);
			AddViewModel(PropertyGridModel);

			this.DependenciesModel = new StateMachineLanguageDependenciesViewModel(ViewModelStore as StateMachineLanguageViewModelStore);
			AddViewModel(DependenciesModel);

			this.LayoutManager = new StateMachineLanguageDockingLayoutManager();
            this.LayoutManager.RestoreConfiguration(this.ViewModelStore.ModelData.CurrentModelContext.Name, this.AllViewModels);
			this.LayoutManager.ActivePaneChanged+= new DslEditorViewModel.DockingLayoutManager.ActivePaneChangedEventHandler(ReactOnActivePaneChanged);		
            this.LayoutManager.MainDockingManager.Loaded += new System.Windows.RoutedEventHandler(MainDockingManager_Loaded);

		}	      
		void MainDockingManager_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			this.EnsureViewModelVisibility();
        }
	
        /// <summary>
        /// Registers imported libraries main ressource dictionaries.
        /// </summary>
        protected virtual void RegisterImportedLibrariesRessources()
        {
            StateMachineLanguageMainViewModelBase.RegisterImportedLibrariesRessources(new System.Collections.Generic.List<string>());
        }		
		#endregion

		#region Methods
		/// <summary>
        /// Save command executed.
        /// </summary>
		/// <remarks>
		/// This was generated because of Validation.UseSave = true.
		/// </remarks>
        protected override void SaveModelCommandExecuted()
        {
			this.ValidateAllCommandExecuted();

            if (this.ErrorListModel != null)
                if (this.ErrorListModel.ErrorsCount > 0)
				{
					DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                    if (messageBox.ShowYesNoCancel("Validation founds errors. Are you sure you want to save the model?", DslEditorViewModelServices.CustomDialogIcons.Exclamation) != DslEditorViewModelServices.CustomDialogResults.Yes)
                        return;
                }
			
			base.SaveModelCommandExecuted();
		}
		#endregion
	}
	
	#region DefaultContext
	/// <summary>
    /// This is a view model for the model context DefaultContext.
	/// 
	/// Double-derived class to allow easier code customization.	
    /// </summary>
	public partial class DefaultContextModelContextViewModel : DefaultContextModelContextViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public DefaultContextModelContextViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
            : base(viewModelStore, modelContext, mainViewModel)
        {

        }	
		#endregion
	}
	
	/// <summary>
    /// This is a view model for the model context DefaultContext.
	/// 
	/// This is the abstract base class.
    /// </summary>
	public abstract class DefaultContextModelContextViewModelBase : DslEditorViewModel::ModelContextViewModel
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public DefaultContextModelContextViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
            : base(viewModelStore, modelContext, mainViewModel)
        {

        }	
		#endregion
	
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void PreInitialize()
        {
			base.PreInitialize();
			
            this.EditorTitle = "StateMachineLanguage";			
		}	
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void Initialize()
        {
			base.Initialize();	
			
			// diagram surface vm
			this.DiagramSurfaceModel = new StateMachineLanguageDesignerDiagramSurfaceViewModel(ViewModelStore as StateMachineLanguageViewModelStore, this.ModelContext);
			AddAdditionalViewModel(DiagramSurfaceModel);
			
		
			
			
		}
		#endregion
	
	}
	#endregion
	
	#region ModelTree
	/// <summary>
	/// This class represents the model tree view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageModelTreeViewModel : StateMachineLanguageModelTreeViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageModelTreeViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageModelTreeViewModelBase : DslEditorViewModel::MainModelTreeViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageModelTreeViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	
		#region Initialize

		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }
		#endregion
	
	    #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Left;
            }
        }
		
		/// <summary>
        /// Gets the context change kind. 
        /// </summary>
        public override DslEditorViewModel.DockingContextChangeKind DockingContextChangeKind
        {
            get
            {
                return DslEditorViewModel.DockingContextChangeKind.PreviewMouseUp;
            }
        }
        #endregion
	}
	#endregion

	#region PropertyGrid
	/// <summary>
	/// This class represents the property grid view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguagePropertyGridViewModel : StateMachineLanguagePropertyGridViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguagePropertyGridViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {	
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguagePropertyGridViewModelBase : DslEditorViewModel::MainPropertyGridViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguagePropertyGridViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {  
        }
		#endregion
		
        #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Right;
            }
        }
        #endregion		
		
        /// <summary>
        /// This method needs to overriden in the actual instances of this class to create contextual
        /// or regular ribbon bars if required.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public override void CreateRibbonMenuBarForEditors(Fluent.Ribbon ribbonMenu)
        {
            base.CreateRibbonMenuBarForEditors(ribbonMenu);
			
	
        }
		
		/// <summary>
        /// Creates ribbon menu for property grid editors.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public static void CreateRibbonMenuBarForEditorsHelper(Fluent.Ribbon ribbonMenu)
		{
	
		}
	}
	#endregion

	#region ErrorList
	/// <summary>
	/// This class represents the error list view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageErrorListViewModel : StateMachineLanguageErrorListViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageErrorListViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageErrorListViewModelBase : DslEditorViewModel::MainErrorListViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageErrorListViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
		
        #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Bottom;
            }
        }
        #endregion		
	}
	#endregion

	#region Dependencies
	/// <summary>
	/// This class represents the dependencies view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageDependenciesViewModel : StateMachineLanguageDependenciesViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageDependenciesViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageDependenciesViewModelBase : DslEditorViewModel::MainDependenciesViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageDependenciesViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
		
        #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Bottom;
            }
        }
        #endregion		
	}
	#endregion
	
	#region Search
	/// <summary>
	/// This class represents the search view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageSearchViewModel : StateMachineLanguageSearchViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageSearchViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageSearchViewModelBase : DslEditorViewModel::MainSearchViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageSearchViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
		
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void PreInitialize()
        {
			base.PreInitialize();
			
			this.SearchResultViewModel = new StateMachineLanguageSearchResultViewModel(this.ViewModelStore as StateMachineLanguageViewModelStore);
		}
		#endregion
		
        #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Right;
            }
        }
		
		/*
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override DslEditorViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneStyle.Floating;
            }
        }*/
        #endregion		
	}
	
	/// <summary>
	/// This class represents a search result view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageSearchResultViewModel : StateMachineLanguageSearchResultViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public StateMachineLanguageSearchResultViewModel(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents a search result view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageSearchResultViewModelBase : DslEditorViewModel::Search.SearchResultViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected StateMachineLanguageSearchResultViewModelBase(StateMachineLanguageViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
		
        #region IDockableViewModel
		/// <summary>
		/// Gets the docking pane anchor style. 
		/// </summary>
        public override DslEditorViewModel.DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DslEditorViewModel.DockingPaneAnchorStyle.Bottom;
            }
        }
        #endregion		
	}
	
	#endregion
}

namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public class StateMachineLanguageDockingLayoutManager : StateMachineLanguageDockingLayoutManagerBase
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		public StateMachineLanguageDockingLayoutManager() : base()
		{
		}
		#endregion
	}

	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// This is the abstract base class.
    /// </summary>
	public abstract class StateMachineLanguageDockingLayoutManagerBase : DslEditorViewModel.DockingLayoutManager
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		protected StateMachineLanguageDockingLayoutManagerBase() : base()
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// FilePath to save all the visible docking panes to.
        /// </summary>
        public override string SaveDockingPanesFilePath 
		{
			get
			{
				return StateMachineLanguageModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerDV.txt";
			}
		}

        /// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveLayoutFilePath
		{ 
			get
			{
				return StateMachineLanguageModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerLayout.xml";
			}
		}
		
		/// <summary>
        /// Directory to save the layouts to.
        /// </summary>
        public override string SaveLayoutDirectory
		{ 
			get
			{
				return StateMachineLanguageModelDataOptions.Instance.AppDataDirectory;
			}
		}
		
		/// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveConfigurationFilePath
		{ 
			get
			{
				return StateMachineLanguageModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerConfig.xml";
			}
		}
		
        /// <summary>
        /// Path to the embedded default layout file. By default: /GeneratedCode/UI/LayoutManagerLayout.xml.
        /// </summary>
        public override string EmbeddedLayoutFilePath
		{
			get
			{
				return "StateMachineDSL." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerLayout.xml";
			}
		}

        /// <summary>
        /// Path to the embedded dfault visible docking panes files. By default: /GeneratedCode/UI/LayoutManagerDV.txt.
        /// </summary>
        public override string EmbeddedDockingPanesFilePath
		{
			get
			{
				return "StateMachineDSL." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerDV.txt";
			}
		}
		#endregion
	}
}
