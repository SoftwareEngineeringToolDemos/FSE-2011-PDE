 
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


namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
	/// This class represents the default diagram surface view model of the StateMachineLanguage.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageDesignerDiagramSurfaceViewModel : StateMachineLanguageDesignerDiagramSurfaceViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="modelContext">Model context.</param>
        public StateMachineLanguageDesignerDiagramSurfaceViewModel(StateMachineLanguageViewModelStore viewModelStore, DslEditorModeling::ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        public StateMachineLanguageDesignerDiagramSurfaceViewModel(StateMachineLanguageViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
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
        public StateMachineLanguageDesignerDiagramSurfaceViewModel(StateMachineLanguageViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
            : base(viewModelStore, diagram, modelContext, parentModelContext)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the default diagram surface view model of the StateMachineLanguage.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract partial class StateMachineLanguageDesignerDiagramSurfaceViewModelBase : DslEditorViewDiagrams::DiagramSurfaceViewModel
	{
		DslEditorModeling::ModelContext parentModelContext = null;
		
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="diagram">Diagram.</param>
		/// <param name="modelContext">Model context.</param>
        protected StateMachineLanguageDesignerDiagramSurfaceViewModelBase(StateMachineLanguageViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext)
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
        protected StateMachineLanguageDesignerDiagramSurfaceViewModelBase(StateMachineLanguageViewModelStore viewModelStore, DslEditorDiagrams::Diagram diagram, DslEditorModeling::ModelContext modelContext, DslEditorModeling::ModelContext parentModelContext)
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
					if( modelContext.Name == "DefaultContext")
					{
						parentModelContext = modelContext as DslEditorModeling::ModelContext;
						//parentModelContext = modelContext as Tum.StateMachineDSL.DefaultContextModelContext;
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
		
		}
			
        #endregion

		/// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public override System.Guid GetDiagramClassType()
		{
			return Tum.StateMachineDSL.DesignerDiagram.DomainClassId;
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
				bCanCreate = CanCreateRelationshipShapeTransitionShape(info);

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
        /// Verifies if a relationship shape of type TransitionShape can be created based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <returns>True if a relationship can be created. False otherwise.</returns>
		protected virtual bool CanCreateRelationshipShapeTransitionShape(DslEditorViewDiagrams::ViewModelRelationshipCreationInfo info)
		{
			if( info.Source.Element is global::Tum.StateMachineDSL.StateBase && info.Target.Element is global::Tum.StateMachineDSL.StateBase )
			{
				// see if a relationship already exists (can not create new one of the same type as no duplicates are allowed)
				if( global::Tum.StateMachineDSL.Transition.GetLinks(info.Source.Element as global::Tum.StateMachineDSL.StateBase, info.Target.Element as global::Tum.StateMachineDSL.StateBase).Count > 0 )
					return false;

				return true;
			}
			
			return false;
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
			if( shapeToCreate == global::Tum.StateMachineDSL.TransitionShape.DomainClassId)
			{
				using(DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add global::Tum.VModellXT.Dynamik.UebergangShape ") )
				{
			
					CreateRelationship<global::Tum.StateMachineDSL.Transition>(info.Source.ShapeElement.Element, info.Target.ShapeElement.Element);
					
					transaction.Commit();
				}
			}

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
			
			if( CanCreateRelationshipShapeTransitionShape(info) )
			{
				shapesPossible.Add(new DslEditorSelection::SearchRSType.SearchRSTypeStruct(
					global::Tum.StateMachineDSL.TransitionShape.DomainClassId, "Transition", "Transition Shape"));
			}

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
