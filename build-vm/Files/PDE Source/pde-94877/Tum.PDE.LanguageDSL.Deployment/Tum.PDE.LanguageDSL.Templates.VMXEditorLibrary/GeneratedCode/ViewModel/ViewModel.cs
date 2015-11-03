 
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

namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the main welcome view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTWelcomeViewModel : VModellXTWelcomeViewModelBase
	{		
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="optionsPath">Options path.</param>
		public VModellXTWelcomeViewModel(string optionsPath) : base(optionsPath)
		{
		}
	}
	
	/// <summary>
	/// This class represents the main welcome view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTWelcomeViewModelBase : Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.MainWelcomeViewModel
	{
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="optionsPath">Options path.</param>
		protected VModellXTWelcomeViewModelBase(string optionsPath) : base(optionsPath)
		{
			Initialize();
		}
		
		
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected virtual void Initialize()
        {  
			
			Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel mVModellXT = 
				new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel(this, "VModellXT", "V-Modell XT");
			this.AvailableModelModelContextViewModels.Add(mVModellXT);
			this.SelectedModelContextViewModel = mVModellXT;
			this.Load(this.SelectedModelContextViewModel.Name);
			
			Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel mVModellXTMustertexte = 
				new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel(this, "VModellXTMustertexte", "V-Modell XT Mustertexte");
			this.AvailableModelModelContextViewModels.Add(mVModellXTMustertexte);
			
			Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel mVariantenkonfig = 
				new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.BaseModelContextViewModel(this, "Variantenkonfig", "Variantenkonfig");
			this.AvailableModelModelContextViewModels.Add(mVariantenkonfig);
			this.WindowTitle = "VModellXT";
	
			#region Further Readings
			this.FurtherReadingViewModel = new Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.FurtherReadingViewModel();

			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Das V-Modell® XT an der Technischen Universität München", "Werkzeuge und Publikationen zum V-Modell® XT.", "http://v-modell-xt.in.tum.de/", ""));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Bundesstelle für Informationstechnik: V-Modell XT", "", "http://www.bit.bund.de/nn_490662/BIT/DE/Standards__Methoden/V-Modell_20XT/node.html?__nnn=true", ""));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("PDE V-Modell XT Editor", "", "http://pde.codeplex.com", "Editors"));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("V-Modell XT Editor", "", "http://sourceforge.net/projects/fourever/files/", "Editors"));
			#endregion
		}		
			
		#endregion		
	}

	/// <summary>
	/// This class represents the main view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTMainViewModel : VModellXTMainViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        public VModellXTMainViewModel(DslEditorModeling::ModelData modelData)
            : this(new VModellXTViewModelStore(modelData))
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTMainViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the main view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTMainViewModelBase : DslEditorViewModel::MainViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTMainViewModelBase(VModellXTViewModelStore viewModelStore)
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
			if( handledLibraries.Contains("VModellXT") )
				return;
			else
				handledLibraries.Add("VModellXT");
			
			System.Windows.Application.Current.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() 
            {
                Source = new System.Uri("pack://application:,,,/" + System.Reflection.Assembly.GetAssembly(typeof(VModellXTMainViewModelBase)).GetName().Name + ";component/Resources.xaml") 
            });			
			Tum.VModellXT.Basis.ViewModel.VModellXTBasisMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
			Tum.VModellXT.Statik.ViewModel.VModellXTStatikMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
			Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
			Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
			Tum.VModellXT.Konventionsabbildungen.ViewModel.VModellXTKonventionsabbildungenMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
			Tum.VModellXT.Aenderungsoperationen.ViewModel.VModellXTAenderungesoperationenMainViewModelBase.RegisterImportedLibrariesRessources(handledLibraries);
	
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
			
				if( modelContext.Name == "VModellXT")
				{
					VModellXTModelContextViewModel mVModellXT = new VModellXTModelContextViewModel(this.ViewModelStore, modelContext, this);
					this.AvailableModelModelContextViewModels.Add(mVModellXT);
					this.SelectedModelContextViewModel = mVModellXT;
				}
			
				if( modelContext.Name == "VModellXTMustertexte")
				{
					VModellXTMustertexteModelContextViewModel mVModellXTMustertexte = new VModellXTMustertexteModelContextViewModel(this.ViewModelStore, modelContext, this);
					this.AvailableModelModelContextViewModels.Add(mVModellXTMustertexte);
				}
			
				if( modelContext.Name == "Variantenkonfig")
				{
					VariantenkonfigModelContextViewModel mVariantenkonfig = new VariantenkonfigModelContextViewModel(this.ViewModelStore, modelContext, this);
					this.AvailableModelModelContextViewModels.Add(mVariantenkonfig);
				}
			}
			
			this.SearchModel = new VModellXTSearchViewModel(ViewModelStore as VModellXTViewModelStore);			
			AddViewModel(SearchModel);
			AddViewModel(SearchModel.SearchResultViewModel);				
	
			#region Credits + Further Readings
			this.CreditsViewModel = new DslEditorViewModelData::CreditsViewModel(this.ViewModelStore);
			this.FurtherReadingViewModel = new DslEditorViewModelData::FurtherReadingViewModel(this.ViewModelStore);

			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("AvalonDock", "Docking Library", "http://avalondock.codeplex.com", ""));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Fluent", "Ribbon Menu", "http://fluent.codeplex.com", ""));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Must Have Icons by VisualPharm", "http://www.visualpharm.com", "http://www.iconarchive.com/category/system/must-have-icons-by-visualpharm.html", "Icons"));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Aesthetica 2 Icons by DryIcons", "http://dryicons.com", "http://www.iconarchive.com/category/system/aesthetica-2-icons-by-dryicons.html", "Icons"));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Icons by Oxygen Team", "http://www.oxygen-icons.org", "http://www.iconfinder.com/search/?q=iconset%3Aoxygen", "Icons"));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Farm-fresh Icons by FatCow Web Hosting", "http://www.fatcow.com", "http://www.iconfinder.com/search/?q=iconset%253Afatcow", "Icons"));
			this.CreditsViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("DRF Icons by Jonas Rask", "http://jonasraskdesign.com", "http://www.iconfinder.com/search/1/?q=iconset:drf", "Icons"));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Das V-Modell® XT an der Technischen Universität München", "Werkzeuge und Publikationen zum V-Modell® XT.", "http://v-modell-xt.in.tum.de/", ""));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("Bundesstelle für Informationstechnik: V-Modell XT", "", "http://www.bit.bund.de/nn_490662/BIT/DE/Standards__Methoden/V-Modell_20XT/node.html?__nnn=true", ""));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("PDE V-Modell XT Editor", "", "http://pde.codeplex.com", "Editors"));
			this.FurtherReadingViewModel.AddLinkItem(new Tum.PDE.ToolFramework.Modeling.Base.LinkItem("V-Modell XT Editor", "", "http://sourceforge.net/projects/fourever/files/", "Editors"));
	
			#endregion
		}		
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {        				
			base.Initialize();
						
			// register services
			VModellXTServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Basis.ViewModel.VModellXTBasisServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Statik.ViewModel.VModellXTStatikServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Konventionsabbildungen.ViewModel.VModellXTKonventionsabbildungenServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);
			Tum.VModellXT.Aenderungsoperationen.ViewModel.VModellXTAenderungesoperationenServiceRegistrar.Instance.RegisterServices(this.ViewModelStore);

			// ensure context menu provider are initialized
			if( Tum.VModellXT.ViewModel.ModelTree.VModellXTModelTreeContextMenuProvider.Instance == null )
				throw new System.ArgumentNullException("Context menu provider");
			
			this.ModelTreeModel = new VModellXTModelTreeViewModel(ViewModelStore as VModellXTViewModelStore);
			AddViewModel(ModelTreeModel);

			this.ErrorListModel = new VModellXTErrorListViewModel(ViewModelStore as VModellXTViewModelStore);
			AddViewModel(ErrorListModel);

			this.PropertyGridModel = new VModellXTPropertyGridViewModel(ViewModelStore as VModellXTViewModelStore);
			AddViewModel(PropertyGridModel);

			this.DependenciesModel = new VModellXTDependenciesViewModel(ViewModelStore as VModellXTViewModelStore);
			AddViewModel(DependenciesModel);

			this.LayoutManager = new VModellXTDockingLayoutManager();
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
            VModellXTMainViewModelBase.RegisterImportedLibrariesRessources(new System.Collections.Generic.List<string>());
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
	
	#region VModellXT
	/// <summary>
    /// This is a view model for the model context VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.	
    /// </summary>
	public partial class VModellXTModelContextViewModel : VModellXTModelContextViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VModellXTModelContextViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
            : base(viewModelStore, modelContext, mainViewModel)
        {

        }	
		#endregion
	}
	
	/// <summary>
    /// This is a view model for the model context VModellXT.
	/// 
	/// This is the abstract base class.
    /// </summary>
	public abstract class VModellXTModelContextViewModelBase : DslEditorViewModel::ModelContextViewModel
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VModellXTModelContextViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
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
			
            this.EditorTitle = "VModellXT";			
		}	
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void Initialize()
        {
			base.Initialize();	
			
			// diagram surface vm
			this.DiagramSurfaceModel = new VModellXTDesignerDiagramSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(DiagramSurfaceModel);
			
			
			// imported diagram TailoringSED
			Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungTailoringSEDSurfaceViewModel diagramTailoringSED = new Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungTailoringSEDSurfaceViewModel(this.ViewModelStore.GetExternViewModelStore(typeof(Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungViewModelStore)) as Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramTailoringSED);
		
			
			VModellXTGeneralGrDependencyTemplateSurfaceViewModel diagramGeneralGrDependencyTemplate = new VModellXTGeneralGrDependencyTemplateSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramGeneralGrDependencyTemplate);
			VModellXTRolleDependencyTemplateSurfaceViewModel diagramRolleDependencyTemplate = new VModellXTRolleDependencyTemplateSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramRolleDependencyTemplate);
			VModellXTDisziplinGrDependencyTemplateSurfaceViewModel diagramDisziplinGrDependencyTemplate = new VModellXTDisziplinGrDependencyTemplateSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramDisziplinGrDependencyTemplate);
			VModellXTErzAbhGrDependencyTemplateSurfaceViewModel diagramErzAbhGrDependencyTemplate = new VModellXTErzAbhGrDependencyTemplateSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(diagramErzAbhGrDependencyTemplate);
			
		}
		#endregion
	
	}
	#endregion
	#region VModellXTMustertexte
	/// <summary>
    /// This is a view model for the model context VModellXTMustertexte.
	/// 
	/// Double-derived class to allow easier code customization.	
    /// </summary>
	public partial class VModellXTMustertexteModelContextViewModel : VModellXTMustertexteModelContextViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VModellXTMustertexteModelContextViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
            : base(viewModelStore, modelContext, mainViewModel)
        {

        }	
		#endregion
	}
	
	/// <summary>
    /// This is a view model for the model context VModellXTMustertexte.
	/// 
	/// This is the abstract base class.
    /// </summary>
	public abstract class VModellXTMustertexteModelContextViewModelBase : DslEditorViewModel::ModelContextViewModel
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VModellXTMustertexteModelContextViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
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
			
            this.EditorTitle = "VModellXT";			
		}	
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void Initialize()
        {
			base.Initialize();	
			
			// diagram surface vm
			this.DiagramSurfaceModel = new VModellXTDesignerDiagramMustertexteSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(DiagramSurfaceModel);
			
		
			
			
		}
		#endregion
	
	}
	#endregion
	#region Variantenkonfig
	/// <summary>
    /// This is a view model for the model context Variantenkonfig.
	/// 
	/// Double-derived class to allow easier code customization.	
    /// </summary>
	public partial class VariantenkonfigModelContextViewModel : VariantenkonfigModelContextViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VariantenkonfigModelContextViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
            : base(viewModelStore, modelContext, mainViewModel)
        {

        }	
		#endregion
	}
	
	/// <summary>
    /// This is a view model for the model context Variantenkonfig.
	/// 
	/// This is the abstract base class.
    /// </summary>
	public abstract class VariantenkonfigModelContextViewModelBase : DslEditorViewModel::ModelContextViewModel
	{
		#region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>	
        public VariantenkonfigModelContextViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext, DslEditorViewModel::BaseMainViewModel mainViewModel)
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
			
            this.EditorTitle = "VModellXT";			
		}	
		
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void Initialize()
        {
			base.Initialize();	
			
			// diagram surface vm
			this.DiagramSurfaceModel = new VModellXTDesignerDiagramVariantenkonfigSurfaceViewModel(ViewModelStore as VModellXTViewModelStore, this.ModelContext);
			AddAdditionalViewModel(DiagramSurfaceModel);
			
		
			
			
		}
		#endregion
	
	}
	#endregion
	
	#region ModelTree
	/// <summary>
	/// This class represents the model tree view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTModelTreeViewModel : VModellXTModelTreeViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTModelTreeViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTModelTreeViewModelBase : DslEditorViewModel::MainModelTreeViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTModelTreeViewModelBase(VModellXTViewModelStore viewModelStore)
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
	/// This class represents the property grid view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTPropertyGridViewModel : VModellXTPropertyGridViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTPropertyGridViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {	
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTPropertyGridViewModelBase : DslEditorViewModel::MainPropertyGridViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTPropertyGridViewModelBase(VModellXTViewModelStore viewModelStore)
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
			
			Tum.VModellXT.Basis.ViewModel.VModellXTBasisPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
			Tum.VModellXT.Statik.ViewModel.VModellXTStatikPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
			Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
			Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
			Tum.VModellXT.Konventionsabbildungen.ViewModel.VModellXTKonventionsabbildungenPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
			Tum.VModellXT.Aenderungsoperationen.ViewModel.VModellXTAenderungesoperationenPropertyGridViewModel.CreateRibbonMenuBarForEditorsHelper(ribbonMenu);
	
        }
		
		/// <summary>
        /// Creates ribbon menu for property grid editors.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public static void CreateRibbonMenuBarForEditorsHelper(Fluent.Ribbon ribbonMenu)
		{
			global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel.HtmlEditorViewModel.HtmlEditorViewModelContextMenuBarCreater.Instance.CreateRibbonMenuBar(ribbonMenu);
	
		}
	}
	#endregion

	#region ErrorList
	/// <summary>
	/// This class represents the error list view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTErrorListViewModel : VModellXTErrorListViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTErrorListViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTErrorListViewModelBase : DslEditorViewModel::MainErrorListViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTErrorListViewModelBase(VModellXTViewModelStore viewModelStore)
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
	/// This class represents the dependencies view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDependenciesViewModel : VModellXTDependenciesViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTDependenciesViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTDependenciesViewModelBase : DslEditorViewModel::MainDependenciesViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTDependenciesViewModelBase(VModellXTViewModelStore viewModelStore)
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
	/// This class represents the search view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTSearchViewModel : VModellXTSearchViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTSearchViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTSearchViewModelBase : DslEditorViewModel::MainSearchViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTSearchViewModelBase(VModellXTViewModelStore viewModelStore)
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
			
			this.SearchResultViewModel = new VModellXTSearchResultViewModel(this.ViewModelStore as VModellXTViewModelStore);
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
	/// This class represents a search result view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTSearchResultViewModel : VModellXTSearchResultViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public VModellXTSearchResultViewModel(VModellXTViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents a search result view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTSearchResultViewModelBase : DslEditorViewModel::Search.SearchResultViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        protected VModellXTSearchResultViewModelBase(VModellXTViewModelStore viewModelStore)
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

namespace Tum.VModellXT.ViewModel
{
	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public class VModellXTDockingLayoutManager : VModellXTDockingLayoutManagerBase
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		public VModellXTDockingLayoutManager() : base()
		{
		}
		#endregion
	}

	/// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
	///
	/// This is the abstract base class.
    /// </summary>
	public abstract class VModellXTDockingLayoutManagerBase : DslEditorViewModel.DockingLayoutManager
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		protected VModellXTDockingLayoutManagerBase() : base()
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
				return VModellXTModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerDV.txt";
			}
		}

        /// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveLayoutFilePath
		{ 
			get
			{
				return VModellXTModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerLayout.xml";
			}
		}
		
		/// <summary>
        /// Directory to save the layouts to.
        /// </summary>
        public override string SaveLayoutDirectory
		{ 
			get
			{
				return VModellXTModelDataOptions.Instance.AppDataDirectory;
			}
		}
		
		/// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public override string SaveConfigurationFilePath
		{ 
			get
			{
				return VModellXTModelDataOptions.Instance.AppDataDirectory + System.IO.Path.DirectorySeparatorChar + "LayoutManagerConfig.xml";
			}
		}
		
        /// <summary>
        /// Path to the embedded default layout file. By default: /GeneratedCode/UI/LayoutManagerLayout.xml.
        /// </summary>
        public override string EmbeddedLayoutFilePath
		{
			get
			{
				return "Tum.VModellXT." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerLayout.xml";
			}
		}

        /// <summary>
        /// Path to the embedded dfault visible docking panes files. By default: /GeneratedCode/UI/LayoutManagerDV.txt.
        /// </summary>
        public override string EmbeddedDockingPanesFilePath
		{
			get
			{
				return "Tum.VModellXT." + "GeneratedCode.ViewModel.WPFApplication.LayoutManagerDV.txt";
			}
		}
		#endregion
	}
}
