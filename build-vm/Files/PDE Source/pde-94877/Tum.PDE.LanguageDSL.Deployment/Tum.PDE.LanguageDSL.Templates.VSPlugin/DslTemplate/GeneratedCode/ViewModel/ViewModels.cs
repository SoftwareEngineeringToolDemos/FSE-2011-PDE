 
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

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;
using DslEditorViewShell = global::Tum.PDE.ToolFramework.Modeling.Visualization.Shell;
using DslEditorViewModelShell = global::Tum.PDE.ToolFramework.Modeling.Visualization.Shell.ViewModel;

namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
	/// This class represents the main view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLMainViewModel : PDEModelingDSLMainViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="package">Package.</param>
        public PDEModelingDSLMainViewModel(DslEditorModeling::ModelData modelData, DslEditorShell::ModelPackage package)
            : this(new PDEModelingDSLViewModelStore(modelData), package)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="package">Package.</param>
        public PDEModelingDSLMainViewModel(PDEModelingDSLViewModelStore viewModelStore, DslEditorShell::ModelPackage package)
            : base(viewModelStore, package)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the main view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLMainViewModelBase : DslEditorViewModelShell::ShellMainViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="package">Package.</param>
        protected PDEModelingDSLMainViewModelBase(PDEModelingDSLViewModelStore viewModelStore, DslEditorShell::ModelPackage package)
            : base(viewModelStore, package)
        {

        }
		#endregion
		
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {
			base.Initialize();
			RegisterImportedLibrariesRessources();
			
			// register services
			PDEModelingDSLServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);

			// ensure context menu provider are initialized
			if( Tum.PDE.ModelingDSL.ViewModel.ModelTree.PDEModelingDSLModelTreeContextMenuProvider.Instance == null )
				throw new System.ArgumentNullException("Context menu provider");
		

			foreach(DslEditorModeling::ModelContext modelContext in this.ModelData.AvailableModelContexts)
			{
				if( modelContext.Name == "DefaultContext")
				{
					DefaultContextModelContextViewModel mDefaultContext = new DefaultContextModelContextViewModel(this.ViewModelStore, modelContext, this);
					mDefaultContext.InitializeMC();
					this.AvailableModelModelContextViewModels.Add(mDefaultContext);
					this.SelectedModelContextViewModel = mDefaultContext;
				}
			}
			
			this.ModelTreeModel = new PDEModelingDSLModelTreeViewModel(ViewModelStore as PDEModelingDSLViewModelStore);
			AddViewModel(ModelTreeModel);

			this.ErrorListModel = new PDEModelingDSLErrorListViewModel(ViewModelStore as PDEModelingDSLViewModelStore);
			AddViewModel(ErrorListModel);

			this.PropertyGridModel = new PDEModelingDSLPropertyGridViewModel(ViewModelStore as PDEModelingDSLViewModelStore);
			AddViewModel(PropertyGridModel);

			this.DependenciesModel = new PDEModelingDSLDependenciesViewModel(ViewModelStore as PDEModelingDSLViewModelStore);
			AddViewModel(DependenciesModel);

			this.SearchModel = new PDEModelingDSLSearchViewModel(ViewModelStore as PDEModelingDSLViewModelStore);			
			AddViewModel(SearchModel);
			AddViewModel(SearchModel.SearchResultViewModel);	

			#region Credits + Further Readings
			this.CreditsViewModel = new DslEditorViewModelData::CreditsViewModel(this.ViewModelStore);
			this.FurtherReadingViewModel = new DslEditorViewModelData::FurtherReadingViewModel(this.ViewModelStore);

	
			#endregion
		}	
		
        /// <summary>
        /// Registers imported libraries main ressource dictionaries.
        /// </summary>
        protected virtual void RegisterImportedLibrariesRessources()
        {
            PDEModelingDSLMainViewModelBase.RegisterImportedLibrariesRessources(new System.Collections.Generic.List<string>());
        }		
		
		/// <summary>
        /// Registers imported libraries main ressource dictionaries.
        /// </summary>
        /// <param name="handledLibraries">Already handled libraries.</param>
        public static void RegisterImportedLibrariesRessources(System.Collections.Generic.List<string> handledLibraries)
		{
			if( handledLibraries.Contains("PDEModelingDSL") )
				return;
			else
				handledLibraries.Add("PDEModelingDSL");
			
			System.Windows.Application.Current.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() 
            {
                Source = new System.Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Resources.xaml") 
            });			
	
		}
		#endregion

		#region Methods
        /// <summary>
        /// Called after the document has been saved.
        /// </summary>
		/// <remarks>
		/// This was generated because of Validation.UseSave = true.
		/// </remarks>
        protected override void OnDocumentSaved()
        {
			this.ValidateAllCommandExecuted();

            if (this.ErrorListModel != null)
                if (this.ErrorListModel.ErrorsCount > 0)
				{
					DslEditorViewModelServices::IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<DslEditorViewModelServices::IMessageBoxService>();
                    if (messageBox.ShowYesNoCancel("Validation founds errors. Are you sure you want to save the model?", DslEditorViewModelServices.CustomDialogIcons.Exclamation) != DslEditorViewModelServices.CustomDialogResults.Yes)
                        return;
                }
			
			base.OnDocumentSaved();
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
        protected override void Initialize()
        {
			base.Initialize();
			
            this.EditorTitle = "PDEModelingDSL";			
			
			// diagram surface vm
			this.DiagramSurfaceModel = new PDEModelingDSLDesignerDiagramSurfaceViewModel(ViewModelStore as PDEModelingDSLViewModelStore, this.ModelContext);
			AddAdditionalViewModel(DiagramSurfaceModel);
			
		
			
			PDEModelingDSLConversionDiagramSurfaceViewModel diagramConversionDiagram = new PDEModelingDSLConversionDiagramSurfaceViewModel(ViewModelStore as PDEModelingDSLViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramConversionDiagram);
			
		}
		#endregion
	
	}
	#endregion
	
	#region ModelTree
	/// <summary>
	/// This class represents the model tree view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLModelTreeViewModel : PDEModelingDSLModelTreeViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLModelTreeViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLModelTreeViewModelBase : DslEditorViewModel::MainModelTreeViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLModelTreeViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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
	/// This class represents the property grid view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLPropertyGridViewModel : PDEModelingDSLPropertyGridViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLPropertyGridViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {	
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLPropertyGridViewModelBase : DslEditorViewModel::MainPropertyGridViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLPropertyGridViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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
	/// This class represents the error list view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLErrorListViewModel : PDEModelingDSLErrorListViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLErrorListViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLErrorListViewModelBase : DslEditorViewModel::MainErrorListViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLErrorListViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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
	/// This class represents the dependencies view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLDependenciesViewModel : PDEModelingDSLDependenciesViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLDependenciesViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLDependenciesViewModelBase : DslEditorViewModel::MainDependenciesViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLDependenciesViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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
	/// This class represents the search view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLSearchViewModel : PDEModelingDSLSearchViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLSearchViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLSearchViewModelBase : DslEditorViewModel::MainSearchViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLSearchViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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
			
			this.SearchResultViewModel = new PDEModelingDSLSearchResultViewModel(this.ViewModelStore as PDEModelingDSLViewModelStore);
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
	/// This class represents a search result view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLSearchResultViewModel : PDEModelingDSLSearchResultViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public PDEModelingDSLSearchResultViewModel(PDEModelingDSLViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents a search result view model of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLSearchResultViewModelBase : DslEditorViewModel::Search.SearchResultViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected PDEModelingDSLSearchResultViewModelBase(PDEModelingDSLViewModelStore viewModelStore)
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

namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public class PDEModelingDSLDockingLayoutManager : PDEModelingDSLDockingLayoutManagerBase
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="package">Package.</param>
		/// <param name="c">Shell package controller.</param>
		public PDEModelingDSLDockingLayoutManager(DslEditorShell::ModelPackage package, DslEditorViewShell::ShellPackageController c)
			: base(package, c)
		{
		}
		#endregion
		
		/*
		/// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore its position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        /// <param name="dockedInDocumentPane">True if this view should be shown in the document pane window. False otherwise.</param>
		public override void ShowWindow(DslEditorViewModelContracts.IDockableViewModel view, DslEditorViewModel.DockingPaneStyle dockingStyle, DslEditorViewModel.DockingPaneAnchorStyle dockingAnchorStyle, bool dockedInDocumentPane)
        {
            if( view is VSPluginDSLDesignerDiagramSurfaceViewModel || view is VSPluginDSLSpecificElementsDiagramTemplateSurfaceViewModel || 
                view is VSPluginDSLModalDiagramTemplateSurfaceViewModel )
                base.ShowWindow(view, dockingStyle, dockingAnchorStyle, false);
            else
                base.ShowWindow(view, dockingStyle, dockingAnchorStyle, dockedInDocumentPane);
        }
		*/
	}

	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// This is the abstract base class.
    /// </summary>
	public abstract class PDEModelingDSLDockingLayoutManagerBase : DslEditorViewModelShell::ShellDockingManager
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="package">Package.</param>
		/// <param name="c">Shell package controller.</param>
		protected PDEModelingDSLDockingLayoutManagerBase(DslEditorShell::ModelPackage package, DslEditorViewShell::ShellPackageController c) 
			: base(package, c)
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
				return PDEModelingDSLModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerDV.txt";
			}
		}

        /// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveLayoutFilePath
		{ 
			get
			{
				return PDEModelingDSLModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerLayout.xml";
			}
		}
		
		/// <summary>
        /// Directory to save the layouts to.
        /// </summary>
        public override string SaveLayoutDirectory
		{ 
			get
			{
				return PDEModelingDSLModelDataOptions.Instance.AppDataDirectory;
			}
		}
		
		/// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveConfigurationFilePath
		{ 
			get
			{
				return PDEModelingDSLModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerConfig.xml";
			}
		}
		
        /// <summary>
        /// Path to the embedded default layout file. By default: /GeneratedCode/UI/LayoutManagerLayout.xml.
        /// </summary>
        public override string EmbeddedLayoutFilePath
		{
			get
			{
				return "Tum.PDE.ModelingDSL." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerLayout.xml";
			}
		}

        /// <summary>
        /// Path to the embedded dfault visible docking panes files. By default: /GeneratedCode/UI/LayoutManagerDV.txt.
        /// </summary>
        public override string EmbeddedDockingPanesFilePath
		{
			get
			{
				return "Tum.PDE.ModelingDSL." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerDV.txt";
			}
		}
		#endregion
	}
}
