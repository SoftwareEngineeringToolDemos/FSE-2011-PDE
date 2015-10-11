 
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
 
using Tum.StateMachineDSL.ViewModel.ModelTree;
using Tum.StateMachineDSL.ViewModel.PropertyGrid;

namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
	/// This class represents the view model store of StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageViewModelStore : StateMachineLanguageViewModelStoreBase
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        public StateMachineLanguageViewModelStore(DslEditorModeling::ModelData modelData)
            : this(modelData, true)
        {

        }
		
	
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        /// <param name="options">Options.</param>
        public StateMachineLanguageViewModelStore(DslEditorModeling::ModelData modelData, Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options)
            : base(modelData, options)
        {
		}
		
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        public StateMachineLanguageViewModelStore(DslEditorModeling::ModelData modelData, bool bHookUpEvents)
            : this(modelData, bHookUpEvents, null)
        {

        }		
		
		/// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="ownedByStore">Store owning this store.</param>
        public StateMachineLanguageViewModelStore(DslEditorModeling::ModelData modelData, bool bHookUpEvents, DslEditorViewModelData::ViewModelStore ownedByStore)
            : base(modelData, bHookUpEvents, ownedByStore)
        {
        }			
		#endregion
	}
	
	/// <summary>
	/// This class represents the view model store of StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageViewModelStoreBase : DslEditorViewModelData::ViewModelStore
	{
		#region Constructor
			
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="options">Options.</param>
        protected StateMachineLanguageViewModelStoreBase(DslEditorModeling::ModelData modelData, Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options)
            : base(modelData, true, null)
        {
			this.Options = options;
			if( this.Options == null )
				this.Options = new StateMachineLanguageViewModelOptions();
        }
			
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        protected StateMachineLanguageViewModelStoreBase(DslEditorModeling::ModelData modelData, bool bHookUpEvents)
            : this(modelData, bHookUpEvents, null)
        {
        }		
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
		/// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
		/// <param name="ownedByStore">Store owning this store.</param>
        protected StateMachineLanguageViewModelStoreBase(DslEditorModeling::ModelData modelData, bool bHookUpEvents, DslEditorViewModelData::ViewModelStore ownedByStore)
            : base(modelData, bHookUpEvents, ownedByStore)
        {
			
			this.Options = new StateMachineLanguageViewModelOptions();
			
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
		}
		
        /// <summary>
        /// Gets the view model factory which provides methods for the creation of view models for model elements from the model.
        /// </summary>
        public override DslEditorViewModelData::ViewModelFactory Factory 
		{ 
			get
			{
				return new StateMachineLanguageViewModelFactory(this);
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
        /// Called to load options when the application starts.
        /// </summary>
        public override void LoadOptions(DslEditorViewModelServices::IMessageBoxService messageBox)
        {
			this.Options = new StateMachineLanguageViewModelOptions();
			
			try
			{
            	string directory = this.ModelData.GetDomainModelServices().ModelDataOptions.AppDataDirectory;
				string path = directory + System.IO.Path.DirectorySeparatorChar + StateMachineLanguageViewModelOptions.OptionsFileName;
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
				string path = directory + System.IO.Path.DirectorySeparatorChar + StateMachineLanguageViewModelOptions.OptionsFileName;
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
	/// This class represents the view model factory of StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageViewModelFactory : StateMachineLanguageViewModelFactoryBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store.</param>
        public StateMachineLanguageViewModelFactory(DslEditorViewModelData::ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the view model factory of StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageViewModelFactoryBase : DslEditorViewModelData::ViewModelFactory
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store.</param>
        public StateMachineLanguageViewModelFactoryBase(DslEditorViewModelData::ViewModelStore viewModelStore)
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
			if( nodeShapeType == global::Tum.StateMachineDSL.TransitionShape.DomainClassId )
				return new Tum.StateMachineDSL.ViewModel.TransitionShapeDiagramItemLinkViewModel(this.Store, diagram, nodeShape);


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
			if( nodeShapeType == global::Tum.StateMachineDSL.StateShape.DomainClassId )
				return new Tum.StateMachineDSL.ViewModel.StateShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.StateMachineDSL.StartStateShape.DomainClassId )
				return new Tum.StateMachineDSL.ViewModel.StartStateShapeDiagramItemViewModel(this.Store, diagram, nodeShape);

			if( nodeShapeType == global::Tum.StateMachineDSL.EndStateShape.DomainClassId )
				return new Tum.StateMachineDSL.ViewModel.EndStateShapeDiagramItemViewModel(this.Store, diagram, nodeShape);


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
				if( global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId == (modelElement as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.StateMachineDSL.ViewModel.ModelTree.ModelTreeStateMachineLanguageViewModel(this.Store, modelElement, null, System.Guid.Empty, null, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
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
				if( global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId == (element as DslEditorModeling::IDomainModelOwnable).GetDomainModelTypeId() )
					return new Tum.StateMachineDSL.ViewModel.ModelTree.ModelTreeStateMachineLanguageViewModel(this.Store, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm); 
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

			if( modelElement.GetDomainClass().Id == global::Tum.StateMachineDSL.EndState.DomainClassId )
			{
				models.Add(new PropertyGridEndStateViewModel(this.Store, modelElement as global::Tum.StateMachineDSL.EndState));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.StateMachineDSL.State.DomainClassId )
			{
				models.Add(new PropertyGridStateViewModel(this.Store, modelElement as global::Tum.StateMachineDSL.State));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.StateMachineDSL.StartState.DomainClassId )
			{
				models.Add(new PropertyGridStartStateViewModel(this.Store, modelElement as global::Tum.StateMachineDSL.StartState));
				return true;
			}
			else if( modelElement.GetDomainClass().Id == global::Tum.StateMachineDSL.Transition.DomainClassId )
			{
				models.Add(new PropertyGridTransitionViewModel(this.Store, modelElement as global::Tum.StateMachineDSL.Transition));
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
