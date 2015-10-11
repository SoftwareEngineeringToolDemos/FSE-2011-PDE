 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslEditorSelection = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection;
using DslEditorViewModels = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using DslEditorDependencies = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;
using DslEditorServices = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorDD = global::Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;

using DslEditorSelectionStruct = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection.SearchElementWithRSType.SearchElementWithRSTypeStruct;


namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramSurfaceViewModel : VModellXTDesignerDiagramSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        public VModellXTDesignerDiagramSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext, parentModelContext)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramSurfaceViewModelBase : DslEditorViewDiagrams::DiagramSurfaceViewModel
	{
		DslEditorModeling::ModelContext parentModelContext = null;
		
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTDesignerDiagramSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        protected VModellXTDesignerDiagramSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			this.parentModelContext = parentModelContext;
        }
		#endregion
		
		#region IDockableViewModel
        /// <summary>
        /// Gets the header image URI.
        /// </summary>
        public override string DockingPaneImageUri
        {
            get
            {
                return "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/DiagramSurface-16.png";
            }
        }

		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "DesignerDiagramSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Designer"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
            if (IsIncludedModelInstance)
                return;

			if( parentModelContext == null )
			{
				foreach(DslEditorModeling::BaseModelContext modelContext in this.ModelData.AvailableModelContexts)
				{
					if( modelContext.Name == "VModellXT")
					{
						parentModelContext = modelContext as DslEditorModeling::ModelContext;
						//parentModelContext = modelContext as Tum.VModellXT.VModellXTModelContext;
						break;
					}
				}
			}
			
			// subscribe to changes of the diagram class, that is hosted by this view model.
			if( parentModelContext != null && this.Diagram == null)
			{
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagram") as DslEditorDiagrams::Diagram;
				if( diagram != null )
				{
					this.Reset();
					InitIncludedDiagrams(diagram);
					this.Diagram = diagram;
				}

				parentModelContext.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
			}
				
        }
		
        void ModelContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if( e.PropertyName == "DesignerDiagram" )
			{
				this.Reset();
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagram") as DslEditorDiagrams::Diagram;
				InitIncludedDiagrams(diagram);
				this.Diagram = diagram;
				
				//InitIncludedDiagrams(parentModelContext.DesignerDiagram);
				//this.Diagram = parentModelContext.DesignerDiagram;				
			}
        }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		void InitIncludedDiagrams(DslEditorDiagrams::Diagram includingDiagram)
		{
			foreach(DslEditorDiagrams::Diagram diagram in includingDiagram.IncludedDiagrams)
			{
				if( diagram.UniqueName == "VModellXTDynamikDesignerDiagram")
				{
					DslEditorViewDiagrams::DiagramSurfaceViewModel dVm = new Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikDesignerDiagramSurfaceViewModel(
						this.ViewModelStore.GetExternViewModelStore(typeof(Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikViewModelStore)) as Tum.VModellXT.Dynamik.ViewModel.VModellXTDynamikViewModelStore, diagram, this.ModelContext);
					dVm.ParentDiagramSurfaceViewModel = this;
					dVm.IsIncludedModelInstance = true;
					this.AddIncludedSurfaceViewModels(dVm);
				}
			}
		
		}
			
        #endregion

		/// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public override System.Guid GetDiagramClassType()
		{
			return Tum.VModellXT.DesignerDiagram.DomainClassId;
		}

		
		#region Methods
		/// <summary>
        /// Verifies if a relationship can be created based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <returns>True if a relationship can be created. False otherwise.</returns>
        public override bool CanCreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return false;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return false;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return false;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return false;

			bool bCanCreate = false;			

			if( !bCanCreate )
			{
				foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
				{
					if( vm.CanCreateRelationship(info) )
						return true;
				}
			}

            return bCanCreate;
        }


        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return;

			// gather creatable shapes
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = this.GetCreatableRelationships(info);
			System.Guid shapeToCreate = System.Guid.Empty;

			if( shapesPossible.Count == 0 )
				return;
			else if (shapesPossible.Count == 1)
                shapeToCreate = shapesPossible[0].DomainClassId;
			else
			{
				// let user choose what shape type he wants to create
				DslEditorSelection::SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct> selectionViewModel
                            = new DslEditorSelection.SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(
                                this.ViewModelStore, shapesPossible,
                                new DslEditorSelection.GenericSearchDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Search),
                                new DslEditorSelection.GenericSortDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Sort));

                // show dialog
                bool? result = this.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>().ShowDialog("SelectRSTypePopup", selectionViewModel);
                if (result == true && selectionViewModel.SelectedElement != null)
                {
                    shapeToCreate = selectionViewModel.SelectedElement.Value.DomainClassId;
                }

                selectionViewModel.Dispose();
                System.GC.Collect();
			}
			
			if( shapeToCreate == System.Guid.Empty )
				return;
				
			this.CreateRelationship(info, shapeToCreate);
			
			
        }

        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <param name="shapeToCreate">Type of the relationship shape</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info, System.Guid shapeToCreate)
        {

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				vm.CreateRelationship(info, shapeToCreate);
			}
        }
		
        /// <summary>
        /// Gets creatable relationship shapes.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> GetCreatableRelationships(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
        {
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = base.GetCreatableRelationships(info);
			

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				shapesPossible.AddRange(vm.GetCreatableRelationships(info));
			}
			
            return shapesPossible;
        }		
        #endregion		

		#region Classes Embedding Methods
		#endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			
            if( parentModelContext != null )
            	parentModelContext.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTGeneralGrDependencyTemplateSurfaceViewModel : VModellXTGeneralGrDependencyTemplateSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTGeneralGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTGeneralGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTGeneralGrDependencyTemplateSurfaceViewModelBase : DslEditorDependencies::GraphicalDependenciesViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTGeneralGrDependencyTemplateSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		#endregion
		
		#region IDockableViewModel
		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "GeneralGrDependencyTemplateSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Graphical Dependencies"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
				
        }
			
        #endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the specific dependencies item for RolleDependencyTemplate.
	/// </summary>
	public partial class VModellXTRolleDependencyTemplateItemViewModel : DslEditorDependencies::SpecificDependenciesItemViewModel
	{
		/// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public VModellXTRolleDependencyTemplateItemViewModel(DslEditorViewModels.Data.ViewModelStore viewModelStore, DslModeling::ModelElement element)
            : base(viewModelStore, element)
        {

        }
	}
}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTRolleDependencyTemplateSurfaceViewModel : VModellXTRolleDependencyTemplateSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTRolleDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTRolleDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTRolleDependencyTemplateSurfaceViewModelBase : DslEditorDependencies::SpecificDependenciesViewModel
	{
		#region SpecificDependencyDiagram
		/// <summary>
        /// Gets the type of the model element that specifies the elements in the list of specific items.
        /// </summary>
        public override System.Guid ModelElementType
        {
            get 
			{ 
				return global::Tum.VModellXT.Statik.Rolle.DomainClassId; 
			}
        }
		
		/// <summary>
        /// Creates a specific view model for the given model element.
        /// </summary>
        /// <param name="store">Viewmodelstore.</param>
        /// <param name="modelElement">Model element to create a specific VM for.</param>
        /// <returns>Specific VM.</returns>
        protected override DslEditorDependencies::SpecificDependenciesItemViewModel CreateSpecificViewModel(DslEditorViewModels.Data.ViewModelStore store, DslModeling::ModelElement modelElement)
		{
			VModellXTRolleDependencyTemplateItemViewModel vm = new VModellXTRolleDependencyTemplateItemViewModel(store, modelElement);
			return vm;
		}
		#endregion
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTRolleDependencyTemplateSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		#endregion
		
		#region IDockableViewModel
		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "RolleDependencyTemplateSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Role Dependencies"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
				
        }
			
        #endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the specific dependencies item for DisziplinGrDependencyTemplate.
	/// </summary>
	public partial class VModellXTDisziplinGrDependencyTemplateItemViewModel : DslEditorDependencies::SpecificDependenciesItemViewModel
	{
		/// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public VModellXTDisziplinGrDependencyTemplateItemViewModel(DslEditorViewModels.Data.ViewModelStore viewModelStore, DslModeling::ModelElement element)
            : base(viewModelStore, element)
        {

        }
	}
}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDisziplinGrDependencyTemplateSurfaceViewModel : VModellXTDisziplinGrDependencyTemplateSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDisziplinGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDisziplinGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTDisziplinGrDependencyTemplateSurfaceViewModelBase : DslEditorDependencies::SpecificDependenciesViewModel
	{
		#region SpecificDependencyDiagram
		/// <summary>
        /// Gets the type of the model element that specifies the elements in the list of specific items.
        /// </summary>
        public override System.Guid ModelElementType
        {
            get 
			{ 
				return global::Tum.VModellXT.Statik.Disziplin.DomainClassId; 
			}
        }
		
		/// <summary>
        /// Creates a specific view model for the given model element.
        /// </summary>
        /// <param name="store">Viewmodelstore.</param>
        /// <param name="modelElement">Model element to create a specific VM for.</param>
        /// <returns>Specific VM.</returns>
        protected override DslEditorDependencies::SpecificDependenciesItemViewModel CreateSpecificViewModel(DslEditorViewModels.Data.ViewModelStore store, DslModeling::ModelElement modelElement)
		{
			VModellXTDisziplinGrDependencyTemplateItemViewModel vm = new VModellXTDisziplinGrDependencyTemplateItemViewModel(store, modelElement);
			return vm;
		}
		#endregion
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTDisziplinGrDependencyTemplateSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		#endregion
		
		#region IDockableViewModel
		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "DisziplinGrDependencyTemplateSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Disziplin Dependencies"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
				
        }
			
        #endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the specific dependencies item for ErzAbhGrDependencyTemplate.
	/// </summary>
	public partial class VModellXTErzAbhGrDependencyTemplateItemViewModel : DslEditorDependencies::SpecificDependenciesItemViewModel
	{
		/// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public VModellXTErzAbhGrDependencyTemplateItemViewModel(DslEditorViewModels.Data.ViewModelStore viewModelStore, DslModeling::ModelElement element)
            : base(viewModelStore, element)
        {

        }
	}
}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTErzAbhGrDependencyTemplateSurfaceViewModel : VModellXTErzAbhGrDependencyTemplateSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTErzAbhGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTErzAbhGrDependencyTemplateSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTErzAbhGrDependencyTemplateSurfaceViewModelBase : DslEditorDependencies::SpecificDependenciesViewModel
	{
		#region SpecificDependencyDiagram
		/// <summary>
        /// Gets the type of the model element that specifies the elements in the list of specific items.
        /// </summary>
        public override System.Guid ModelElementType
        {
            get 
			{ 
				return global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.DomainClassId; 
			}
        }
		
		/// <summary>
        /// Creates a specific view model for the given model element.
        /// </summary>
        /// <param name="store">Viewmodelstore.</param>
        /// <param name="modelElement">Model element to create a specific VM for.</param>
        /// <returns>Specific VM.</returns>
        protected override DslEditorDependencies::SpecificDependenciesItemViewModel CreateSpecificViewModel(DslEditorViewModels.Data.ViewModelStore store, DslModeling::ModelElement modelElement)
		{
			VModellXTErzAbhGrDependencyTemplateItemViewModel vm = new VModellXTErzAbhGrDependencyTemplateItemViewModel(store, modelElement);
			return vm;
		}
		#endregion
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTErzAbhGrDependencyTemplateSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		#endregion
		
		#region IDockableViewModel
		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "ErzAbhGrDependencyTemplateSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Erzeugende Abhängigkeiten Dependencies"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
				
        }
			
        #endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramMustertexteSurfaceViewModel : VModellXTDesignerDiagramMustertexteSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramMustertexteSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramMustertexteSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        public VModellXTDesignerDiagramMustertexteSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext, parentModelContext)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramMustertexteSurfaceViewModelBase : DslEditorViewDiagrams::DiagramSurfaceViewModel
	{
		DslEditorModeling::ModelContext parentModelContext = null;
		
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTDesignerDiagramMustertexteSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        protected VModellXTDesignerDiagramMustertexteSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			this.parentModelContext = parentModelContext;
        }
		#endregion
		
		#region IDockableViewModel
        /// <summary>
        /// Gets the header image URI.
        /// </summary>
        public override string DockingPaneImageUri
        {
            get
            {
                return "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/DiagramSurface-16.png";
            }
        }

		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "DesignerDiagramMustertexteSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Designer"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
            if (IsIncludedModelInstance)
                return;

			if( parentModelContext == null )
			{
				foreach(DslEditorModeling::BaseModelContext modelContext in this.ModelData.AvailableModelContexts)
				{
					if( modelContext.Name == "VModellXTMustertexte")
					{
						parentModelContext = modelContext as DslEditorModeling::ModelContext;
						//parentModelContext = modelContext as Tum.VModellXT.VModellXTMustertexteModelContext;
						break;
					}
				}
			}
			
			// subscribe to changes of the diagram class, that is hosted by this view model.
			if( parentModelContext != null && this.Diagram == null)
			{
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagramMustertexte") as DslEditorDiagrams::Diagram;
				if( diagram != null )
				{
					this.Reset();
					InitIncludedDiagrams(diagram);
					this.Diagram = diagram;
				}

				parentModelContext.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
			}
				
        }
		
        void ModelContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if( e.PropertyName == "DesignerDiagramMustertexte" )
			{
				this.Reset();
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagramMustertexte") as DslEditorDiagrams::Diagram;
				InitIncludedDiagrams(diagram);
				this.Diagram = diagram;
				
				//InitIncludedDiagrams(parentModelContext.DesignerDiagramMustertexte);
				//this.Diagram = parentModelContext.DesignerDiagramMustertexte;				
			}
        }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		void InitIncludedDiagrams(DslEditorDiagrams::Diagram includingDiagram)
		{
		
		}
			
        #endregion

		/// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public override System.Guid GetDiagramClassType()
		{
			return Tum.VModellXT.DesignerDiagramMustertexte.DomainClassId;
		}

		
		#region Methods
		/// <summary>
        /// Verifies if a relationship can be created based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <returns>True if a relationship can be created. False otherwise.</returns>
        public override bool CanCreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return false;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return false;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return false;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return false;

			bool bCanCreate = false;			

			if( !bCanCreate )
			{
				foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
				{
					if( vm.CanCreateRelationship(info) )
						return true;
				}
			}

            return bCanCreate;
        }


        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return;

			// gather creatable shapes
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = this.GetCreatableRelationships(info);
			System.Guid shapeToCreate = System.Guid.Empty;

			if( shapesPossible.Count == 0 )
				return;
			else if (shapesPossible.Count == 1)
                shapeToCreate = shapesPossible[0].DomainClassId;
			else
			{
				// let user choose what shape type he wants to create
				DslEditorSelection::SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct> selectionViewModel
                            = new DslEditorSelection.SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(
                                this.ViewModelStore, shapesPossible,
                                new DslEditorSelection.GenericSearchDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Search),
                                new DslEditorSelection.GenericSortDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Sort));

                // show dialog
                bool? result = this.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>().ShowDialog("SelectRSTypePopup", selectionViewModel);
                if (result == true && selectionViewModel.SelectedElement != null)
                {
                    shapeToCreate = selectionViewModel.SelectedElement.Value.DomainClassId;
                }

                selectionViewModel.Dispose();
                System.GC.Collect();
			}
			
			if( shapeToCreate == System.Guid.Empty )
				return;
				
			this.CreateRelationship(info, shapeToCreate);
			
			
        }

        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <param name="shapeToCreate">Type of the relationship shape</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info, System.Guid shapeToCreate)
        {

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				vm.CreateRelationship(info, shapeToCreate);
			}
        }
		
        /// <summary>
        /// Gets creatable relationship shapes.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> GetCreatableRelationships(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
        {
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = base.GetCreatableRelationships(info);
			

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				shapesPossible.AddRange(vm.GetCreatableRelationships(info));
			}
			
            return shapesPossible;
        }		
        #endregion		

		#region Classes Embedding Methods
		#endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			
            if( parentModelContext != null )
            	parentModelContext.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
					
				
            base.OnDispose();
        }
        #endregion
	}

}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramVariantenkonfigSurfaceViewModel : VModellXTDesignerDiagramVariantenkonfigSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramVariantenkonfigSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public VModellXTDesignerDiagramVariantenkonfigSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        public VModellXTDesignerDiagramVariantenkonfigSurfaceViewModel(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext, parentModelContext)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the VModellXT.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramVariantenkonfigSurfaceViewModelBase : DslEditorViewDiagrams::DiagramSurfaceViewModel
	{
		DslEditorModeling::ModelContext parentModelContext = null;
		
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected VModellXTDesignerDiagramVariantenkonfigSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			
        }

		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
		/// <param name="parentModelContext">Parent model context.</param>
        protected VModellXTDesignerDiagramVariantenkonfigSurfaceViewModelBase(VModellXTViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext)
        {
			this.parentModelContext = parentModelContext;
        }
		#endregion
		
		#region IDockableViewModel
        /// <summary>
        /// Gets the header image URI.
        /// </summary>
        public override string DockingPaneImageUri
        {
            get
            {
                return "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/DiagramSurface-16.png";
            }
        }

		/// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "DesignerDiagramVariantenkonfigSurfaceDockWindowPane"; }
        }

		/// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Designer"; }
        }
        		
		/// <summary>
		/// Gets the docking pane style. 
		/// </summary>
		public override global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion		
		
		#region Initialization
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
			
            if (IsIncludedModelInstance)
                return;

			if( parentModelContext == null )
			{
				foreach(DslEditorModeling::BaseModelContext modelContext in this.ModelData.AvailableModelContexts)
				{
					if( modelContext.Name == "Variantenkonfig")
					{
						parentModelContext = modelContext as DslEditorModeling::ModelContext;
						//parentModelContext = modelContext as Tum.VModellXT.VariantenkonfigModelContext;
						break;
					}
				}
			}
			
			// subscribe to changes of the diagram class, that is hosted by this view model.
			if( parentModelContext != null && this.Diagram == null)
			{
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagramVariantenkonfig") as DslEditorDiagrams::Diagram;
				if( diagram != null )
				{
					this.Reset();
					InitIncludedDiagrams(diagram);
					this.Diagram = diagram;
				}

				parentModelContext.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
			}
				
        }
		
        void ModelContext_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if( e.PropertyName == "DesignerDiagramVariantenkonfig" )
			{
				this.Reset();
				DslEditorDiagrams::Diagram diagram = parentModelContext.GetDiagram("DesignerDiagramVariantenkonfig") as DslEditorDiagrams::Diagram;
				InitIncludedDiagrams(diagram);
				this.Diagram = diagram;
				
				//InitIncludedDiagrams(parentModelContext.DesignerDiagramVariantenkonfig);
				//this.Diagram = parentModelContext.DesignerDiagramVariantenkonfig;				
			}
        }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		void InitIncludedDiagrams(DslEditorDiagrams::Diagram includingDiagram)
		{
		
		}
			
        #endregion

		/// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public override System.Guid GetDiagramClassType()
		{
			return Tum.VModellXT.DesignerDiagramVariantenkonfig.DomainClassId;
		}

		
		#region Methods
		/// <summary>
        /// Verifies if a relationship can be created based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <returns>True if a relationship can be created. False otherwise.</returns>
        public override bool CanCreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return false;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return false;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return false;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return false;

			bool bCanCreate = false;			

			if( !bCanCreate )
			{
				foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
				{
					if( vm.CanCreateRelationship(info) )
						return true;
				}
			}

            return bCanCreate;
        }


        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source == null || info.Target == null )
				return;
				
			if( info.Source.ShapeElement == null || info.Target.ShapeElement == null )
				return;
				
			if( info.Source.ShapeElement.Element == null || info.Target.ShapeElement.Element == null )
				return;
				
			if (!info.Source.ShapeElement.TakesPartInRelationship)
                return;

			// gather creatable shapes
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = this.GetCreatableRelationships(info);
			System.Guid shapeToCreate = System.Guid.Empty;

			if( shapesPossible.Count == 0 )
				return;
			else if (shapesPossible.Count == 1)
                shapeToCreate = shapesPossible[0].DomainClassId;
			else
			{
				// let user choose what shape type he wants to create
				DslEditorSelection::SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct> selectionViewModel
                            = new DslEditorSelection.SelectGenericViewModel<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(
                                this.ViewModelStore, shapesPossible,
                                new DslEditorSelection.GenericSearchDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Search),
                                new DslEditorSelection.GenericSortDelegate<DslEditorSelection::SearchRSType.SearchRSTypeStruct>(DslEditorSelection::SearchRSType.Sort));

                // show dialog
                bool? result = this.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>().ShowDialog("SelectRSTypePopup", selectionViewModel);
                if (result == true && selectionViewModel.SelectedElement != null)
                {
                    shapeToCreate = selectionViewModel.SelectedElement.Value.DomainClassId;
                }

                selectionViewModel.Dispose();
                System.GC.Collect();
			}
			
			if( shapeToCreate == System.Guid.Empty )
				return;
				
			this.CreateRelationship(info, shapeToCreate);
			
			
        }

        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <param name="shapeToCreate">Type of the relationship shape</param>
        public override void CreateRelationship(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info, System.Guid shapeToCreate)
        {

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				vm.CreateRelationship(info, shapeToCreate);
			}
        }
		
        /// <summary>
        /// Gets creatable relationship shapes.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public override System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> GetCreatableRelationships(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
        {
			System.Collections.Generic.List<DslEditorSelection::SearchRSType.SearchRSTypeStruct> shapesPossible = base.GetCreatableRelationships(info);
			

			foreach(DslEditorViewDiagrams::DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				shapesPossible.AddRange(vm.GetCreatableRelationships(info));
			}
			
            return shapesPossible;
        }		
        #endregion		

		#region Classes Embedding Methods
		#endregion
		
		#region Dispose
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			
            if( parentModelContext != null )
            	parentModelContext.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ModelContext_PropertyChanged);
					
				
            base.OnDispose();
        }
        #endregion
	}

}
