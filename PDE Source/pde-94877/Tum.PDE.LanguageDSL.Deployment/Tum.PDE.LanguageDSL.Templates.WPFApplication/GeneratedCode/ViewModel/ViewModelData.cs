 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslEditorViewModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorViewModelModelTree = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using DslEditorViewModelPropertyGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using DslEditorViewModelDependencies = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;
using DslEditorViewModelServices = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
 
using Tum.VModellXT.ViewModel.ModelTree;
using Tum.VModellXT.ViewModel.PropertyGrid;

namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the view model store of VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTViewModelStore : VModellXTViewModelStoreBase
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        public VModellXTViewModelStore(DslEditorModeling::ModelData modelData)
            : this(modelData, true)
        {

        }
		
	
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        /// <param name="options">Options.</param>
        public VModellXTViewModelStore(DslEditorModeling::ModelData modelData, Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options)
            : base(modelData, options)
        {
		}
		
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        public VModellXTViewModelStore(DslEditorModeling::ModelData modelData, bool bHookUpEvents)
            : this(modelData, bHookUpEvents, null)
        {

        }		
		
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="ownedByStore">Store owning this store.</param>
        public VModellXTViewModelStore(DslEditorModeling::ModelData modelData, bool bHookUpEvents, DslEditorViewModelData::ViewModelStore ownedByStore)
            : base(modelData, bHookUpEvents, ownedByStore)
        {
        }			
		#endregion
	}
	
	/// <summary>
	/// This class represents the view model store of VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTViewModelStoreBase : DslEditorViewModelData::ViewModelStore
	{
		#region Constructor
			
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="options">Options.</param>
        protected VModellXTViewModelStoreBase(DslEditorModeling::ModelData modelData, Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options)
            : base(modelData, true, null)
        {
			this.Options = options;
			if( this.Options == null )
				this.Options = new VModellXTViewModelOptions();
        }
			
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        protected VModellXTViewModelStoreBase(DslEditorModeling::ModelData modelData, bool bHookUpEvents)
            : this(modelData, bHookUpEvents, null)
        {
        }		
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="ownedByStore">Store owning this store.</param>
        protected VModellXTViewModelStoreBase(DslEditorModeling::ModelData modelData, bool bHookUpEvents, DslEditorViewModelData::ViewModelStore ownedByStore)
            : base(modelData, bHookUpEvents, ownedByStore)
        {
			
			this.Options = new VModellXTViewModelOptions();
			
        }		
		#endregion
		
		#region Initialization
        private DslEditorViewModelData::ViewModelStore GetExternViewModelStore(DslEditorViewModelData::ViewModelStore st, System.Type type)
        {
            foreach (DslEditorViewModelData::ViewModelStore s in st.ExternStores)
                if( s.GetType() == type )
                    return s;

            return null;
        }
		
        /// <summary>
        /// Register extern stores.
        /// </summary>
        protected override void RegisterExternStores()
		{
			DslEditorViewModelData::ViewModelStore v0 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Basis.ViewModel.VModellXTBasisViewModelStore));
			if( v0 == null )
				v0 = new Tum.VModellXT.Basis.ViewModel.VModellXTBasisViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v0);
			
			DslEditorViewModelData::ViewModelStore v1 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Statik.ViewModel.VModellXTStatikViewModelStore));
			if( v1 == null )
				v1 = new Tum.VModellXT.Statik.ViewModel.VModellXTStatikViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v1);
			
			DslEditorViewModelData::ViewModelStore v2 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikViewModelStore));
			if( v2 == null )
				v2 = new Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v2);
			
			DslEditorViewModelData::ViewModelStore v3 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungViewModelStore));
			if( v3 == null )
				v3 = new Tum.VModellXT.Anpassung.ViewModel.VModellXTAnpassungViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v3);
			
			DslEditorViewModelData::ViewModelStore v4 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Konventionsabbildungen.ViewModel.VModellXTKonventionsabbildungenViewModelStore));
			if( v4 == null )
				v4 = new Tum.VModellXT.Konventionsabbildungen.ViewModel.VModellXTKonventionsabbildungenViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v4);
			
			DslEditorViewModelData::ViewModelStore v5 = GetExternViewModelStore(this.TopMostStore, typeof(Tum.VModellXT.Aenderungsoperationen.ViewModel.VModellXTAenderungesoperationenViewModelStore));
			if( v5 == null )
				v5 = new Tum.VModellXT.Aenderungsoperationen.ViewModel.VModellXTAenderungesoperationenViewModelStore(this.ModelData, true, this);
			this.ExternStores.Add(v5);
			
		}
		
        /// <summary>
        /// Gets the view model factory which provides methods for the creation of view models for model elements from the model.
        /// </summary>
        public override DslEditorViewModelData::ViewModelFactory Factory 
		{ 
			get
			{
				return new VModellXTViewModelFactory(this);
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
        /// Called to load options when the application starts.
        /// </summary>
        public override void LoadOptions(DslEditorViewModelServices::IMessageBoxService messageBox)
        {
			this.Options = new VModellXTViewModelOptions();
			
			try
			{
            	string directory = this.ModelData.GetDomainModelServices().ModelDataOptions.AppDataDirectory;
				string path = directory + System.IO.Path.DirectorySeparatorChar + VModellXTViewModelOptions.OptionsFileName;
				this.Options.Deserialize(path);
			}
			catch(System.Exception ex)
			{
				messageBox.ShowError("Couldn't open options: " + ex.Message);
				
			}
		}
		
        /// <summary>
        /// Called to save options when the application exits.
        /// </summary>
        public override void SaveOptions(DslEditorViewModelServices::IMessageBoxService messageBox)
        {
		
			// save options
			try
			{
            	string directory = this.ModelData.GetDomainModelServices().ModelDataOptions.AppDataDirectory;
				string path = directory + System.IO.Path.DirectorySeparatorChar + VModellXTViewModelOptions.OptionsFileName;
				this.Options.Serialize(path);
			}
			catch(System.Exception ex)
			{
				messageBox.ShowError("Couldn't save options: " + ex.Message);
			}
		
		}
		#endregion
	}
	
	/// <summary>
	/// This class represents the view model factory of VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTViewModelFactory : VModellXTViewModelFactoryBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store.</param>
        public VModellXTViewModelFactory(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the view model factory of VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VModellXTViewModelFactoryBase : DslEditorViewModelData::ViewModelFactory
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store.</param>
        public VModellXTViewModelFactoryBase(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
		
		#region Methods
		
		#region CreateDiagramLinkViewModel
	    /// <summary>
        /// Creates the view model for the given link shape.
        /// </summary>
        /// <param name="nodeShapeType">Shape type for which the view model is to be created.</param>
        /// <param name="diagram">Diagram surface vm.</param>
        /// <param name="nodeShape">Link shape.</param>
        /// <returns>
        /// View model of type BaseDiagramItemLinkViewModel if a view model can be created for the given element. Null otherwise.</returns>
        public override DslEditorViewModel.DiagramSurface.BaseDiagramItemLinkViewModel CreateDiagramLinkViewModel(System.Guid nodeShapeType, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape nodeShape)
        {
			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufbausteinpunktRAblaufbausteinspezShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufbausteinpunktRAblaufbausteinspezShapeDiagramItemLinkViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufbausteinRAblaufbausteinspezShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufbausteinRAblaufbausteinspezShapeDiagramItemLinkViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.UebergangShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.UebergangShapeDiagramItemLinkViewModel(this.Store, diagram, nodeShape);


            return null;
        }

        #endregion
		
		#region CreateDiagramItemViewModel
        /// <summary>
        /// Creates the view model for the given node shape.
        /// </summary>
        /// <param name="nodeShapeType">Shape type for which the view model is to be created.</param>
		/// <param name="diagram">Diagram surface vm.</param>
		/// <param name="nodeShape">Node shape.</param>
        /// <returns>
        /// View model of type DiagramItemElementViewModel if a view model can be created for the given element. Null otherwise.
		/// </returns>
        public override DslEditorViewModel.DiagramSurface.DiagramItemElementViewModel CreateDiagramItemViewModel(System.Guid nodeShapeType, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape nodeShape)
        {
			if( nodeShapeType == global::Tum.VModellXT.RolleDependencyShape.DomainClassId )
				return new Tum.VModellXT.ViewModel.RolleDependencyShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.DisziplinDependencyShape.DomainClassId )
				return new Tum.VModellXT.ViewModel.DisziplinDependencyShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.ErzAbhDependencyShape.DomainClassId )
				return new Tum.VModellXT.ViewModel.ErzAbhDependencyShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufbausteinShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufbausteinShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.StartpunktShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.StartpunktShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.EndepunktShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.EndepunktShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufentscheidungspunktShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufentscheidungspunktShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufbausteinpunktShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufbausteinpunktShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.SplitShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.SplitShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.SplitEingangShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.SplitEingangShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.SplitAusgangShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.SplitAusgangShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.JoinShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.JoinShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.JoinEingangShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.JoinEingangShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.JoinAusgangShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.JoinAusgangShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.VModellXT.Dynamik.AblaufbausteinspezifikationShape.DomainClassId )
				return new Tum.VModellXT.Dynamik.ViewModel.AblaufbausteinspezifikationShapeDiagramItemViewModel(this.Store, diagram, nodeShape);


            return null;
        }

        #endregion
		
		#region CreateModelElementTreeViewModel
		/// <summary>
        /// Creates the tree view model for the given model element.
        /// </summary>
        /// <param name="modelElement">Model element for which the tree view model is to be created.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
		/// <param name="mainModelTreeVm">Main model tree view model.</param>
        /// <returns>
        /// View model of type BaseModelElementTreeViewModel if a view model can be created for the given element. Null otherwise.</returns>
        /// <remarks>
        /// A view model of the type BaseModelElementViewModel can obly be created for domain classes and referencing relationships, that
        /// can be embedded in the model tree.
        /// </remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override DslEditorViewModelModelTree::BaseModelElementTreeViewModel CreateModelElementTreeViewModel(DslModeling::ModelElement modelElement, bool bHookUpEvents, bool bCreateContextMenus, DslEditorViewModel::MainModelTreeViewModel mainModelTreeVm)
		{
			if( modelElement is DslEditorModeling::IDomainModelOwnable )
			{
				if( global::Tum.VModellXT.VModellXTDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.ViewModel.ModelTree.ModelTreeVModellXTViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Basis.VModellXTBasisDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Basis.ViewModel.ModelTree.ModelTreeVModellXTBasisViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Statik.VModellXTStatikDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Statik.ViewModel.ModelTree.ModelTreeVModellXTStatikViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Dynamik.VModellXTDynamikDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Dynamik.ViewModel.ModelTree.ModelTreeVModellXTDynamikViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Anpassung.ViewModel.ModelTree.ModelTreeVModellXTAnpassungViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Konventionsabbildungen.ViewModel.ModelTree.ModelTreeVModellXTKonventionsabbildungenViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Aenderungsoperationen.ViewModel.ModelTree.ModelTreeVModellXTAenderungesoperationenViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
			}
			
			
			
			return new DslEditorViewModelModelTree::ModelElementTreeViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm);
		}
		
		/// <summary>
        /// Creates the tree view model for the given model element.
        /// </summary>
        /// <param name="element">VModell represented by this view model.</param>
        /// <param name="link">Element link, targeting the hosted element.</param>
        /// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
        /// <param name="parent">Parent of this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override DslEditorViewModelModelTree::ModelElementTreeViewModel CreateModelElementTreeViewModel(DslModeling::ModelElement element, DslModeling::ElementLink link, System.Guid domainRoleId, DslEditorViewModelModelTree::ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, DslEditorViewModel::MainModelTreeViewModel mainModelTreeVm)
		{
			if( element is DslEditorModeling::IDomainModelOwnable )
			{
				if( global::Tum.VModellXT.VModellXTDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.ViewModel.ModelTree.ModelTreeVModellXTViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Basis.VModellXTBasisDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Basis.ViewModel.ModelTree.ModelTreeVModellXTBasisViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Statik.VModellXTStatikDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Statik.ViewModel.ModelTree.ModelTreeVModellXTStatikViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Dynamik.VModellXTDynamikDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Dynamik.ViewModel.ModelTree.ModelTreeVModellXTDynamikViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Anpassung.ViewModel.ModelTree.ModelTreeVModellXTAnpassungViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Konventionsabbildungen.ViewModel.ModelTree.ModelTreeVModellXTKonventionsabbildungenViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
				if( global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.VModellXT.Aenderungsoperationen.ViewModel.ModelTree.ModelTreeVModellXTAenderungesoperationenViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
			}
			
			return new DslEditorViewModelModelTree::ModelElementTreeViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
		}
		#endregion
		
		#region CreatePropertyEditorViewModels
		/// <summary>
        /// Returns a collection of property grid view models for the given selected elements.
        /// </summary>
        /// <param name="elements">Selected elements collection.</param>
        /// <returns>Collection of property view models. Can be empty.</returns>
        public override System.Collections.Generic.List<DslEditorViewModelPropertyGrid::PropertyGridViewModel> CreatePropertyEditorViewModels(DslEditorModeling::SelectedItemsCollection elements)
		{
			System.Collections.Generic.List<DslEditorViewModelPropertyGrid::PropertyGridViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPropertyGrid::PropertyGridViewModel>();

			foreach(DslModeling::ModelElement modelElement in elements )
			{
				System.Collections.Generic.List<DslEditorViewModelData::ViewModelStore> handledStores = new System.Collections.Generic.List<DslEditorViewModelData::ViewModelStore>();
				AddPropertyEditorViewModels(collection, modelElement, handledStores);
			}
			
			return collection;
		}
		
        /// <summary>
        /// Returns a collection of property view models for the given selected elements.
        /// </summary>
        /// <param name="models">Already gathered models.</param>
        /// <param name="modelElement">ModelElement.</param>
        /// <param name="handledStores">Stores that have already been processed.</param>
        /// <returns>Collection of property view models. Can be empty.</returns>
        public override bool AddPropertyEditorViewModels(System.Collections.Generic.List<DslEditorViewModelPropertyGrid::PropertyGridViewModel> models, DslModeling::ModelElement modelElement, System.Collections.Generic.List<DslEditorViewModelData::ViewModelStore> handledStores)
		{
			if( handledStores.Contains(this.Store) )
				return false;
			else 
				handledStores.Add(this.Store);

			if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.VModellvariante.DomainClassId )
			{
				models.Add(new PropertyGridVModellvarianteViewModel(this.Store, modelElement as global::Tum.VModellXT.VModellvariante));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.VModell.DomainClassId )
			{
				models.Add(new PropertyGridVModellViewModel(this.Store, modelElement as global::Tum.VModellXT.VModell));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DomainClassId )
			{
				models.Add(new PropertyGridReferenzmodellReferencesVModellvarianteViewModel(this.Store, modelElement as global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Variante.DomainClassId )
			{
				models.Add(new PropertyGridVarianteViewModel(this.Store, modelElement as global::Tum.VModellXT.Variante));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.ThemenmusterReferencesThema.DomainClassId )
			{
				models.Add(new PropertyGridThemenmusterReferencesThemaViewModel(this.Store, modelElement as global::Tum.VModellXT.ThemenmusterReferencesThema));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DomainClassId )
			{
				models.Add(new PropertyGridVarianteSourceReferencesVarianteTargetViewModel(this.Store, modelElement as global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.ThemenmusterReferencesUnterthema.DomainClassId )
			{
				models.Add(new PropertyGridThemenmusterReferencesUnterthemaViewModel(this.Store, modelElement as global::Tum.VModellXT.ThemenmusterReferencesUnterthema));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Zusatzthema.DomainClassId )
			{
				models.Add(new PropertyGridZusatzthemaViewModel(this.Store, modelElement as global::Tum.VModellXT.Zusatzthema));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Musterbibliothek.DomainClassId )
			{
				models.Add(new PropertyGridMusterbibliothekViewModel(this.Store, modelElement as global::Tum.VModellXT.Musterbibliothek));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Referenzmodell.DomainClassId )
			{
				models.Add(new PropertyGridReferenzmodellViewModel(this.Store, modelElement as global::Tum.VModellXT.Referenzmodell));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Mustergruppe.DomainClassId )
			{
				models.Add(new PropertyGridMustergruppeViewModel(this.Store, modelElement as global::Tum.VModellXT.Mustergruppe));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Mustertext.DomainClassId )
			{
				models.Add(new PropertyGridMustertextViewModel(this.Store, modelElement as global::Tum.VModellXT.Mustertext));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.VModellXT.Themenmuster.DomainClassId )
			{
				models.Add(new PropertyGridThemenmusterViewModel(this.Store, modelElement as global::Tum.VModellXT.Themenmuster));
				return true;
			}
			else
			{
				foreach(DslEditorViewModelData::ViewModelStore eS in this.Store.ExternStores)
					if( eS.Factory.AddPropertyEditorViewModels(models, modelElement, handledStores) )
						return true;
			}

			return false;
		}
		
		#endregion				
		
		#region CreateRestorableViewModel
        /// <summary>
        /// Attempts at creating a view model of a specified type. This is meant to be called for restorable VMs that are in 
        /// the process of beeing restored.
        /// </summary>
        /// <param name="vmType">Type of the vm.</param>
        /// <param name="handledStores">Stores that have already been processed.</param>
        /// <returns>VM if succeeded. Null otherwise.</returns>
        public override DslEditorViewDiagrams::BaseDiagramSurfaceViewModel CreateRestorableViewModel(string vmType, System.Collections.Generic.List<DslEditorViewModelData::ViewModelStore> handledStores)
		{
		
			foreach(DslEditorViewModelData::ViewModelStore eS in this.Store.ExternStores)
			{
				DslEditorViewDiagrams::BaseDiagramSurfaceViewModel vm = eS.Factory.CreateRestorableViewModel(vmType, handledStores);
				if( vm != null )
					return vm;
			}
			
			return null;
		}
		#endregion 
		#endregion
	}	
}
