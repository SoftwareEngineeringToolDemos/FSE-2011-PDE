 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

// DesignerDiagram
namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
    /// View model for TransitionShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class TransitionShapeDiagramItemLinkViewModel : TransitionShapeDiagramItemLinkViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public TransitionShapeDiagramItemLinkViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for TransitionShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class TransitionShapeDiagramItemLinkViewModelBase : DslEditorViewDiagrams::BaseDiagramItemLinkViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected TransitionShapeDiagramItemLinkViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion

		#region Element Properties
		/// <summary>
		/// Gets or sets the value of Condition domain property.
		/// </summary>
		public global::System.String Element_Condition
		{
			get
			{
				return (this.Element as global::Tum.StateMachineDSL.Transition).Condition;
			}
			set
			{
				if( (this.Element as global::Tum.StateMachineDSL.Transition).Condition != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Condition") )
					{
						(this.Element as global::Tum.StateMachineDSL.Transition).Condition = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
		/// Called whenever properties change.
		/// </summary>
		/// <param name="args"></param>
		protected virtual void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( this.IsDisposed )
				return;
		
			if( args.DomainProperty.Id == global::Tum.StateMachineDSL.Transition.ConditionDomainPropertyId )
				OnPropertyChanged("Element_Condition");
		}
		
		/// <summary>
		/// Subscribes to model element property change events.
		/// </summary>
		protected override void Subscribe()
		{
			base.Subscribe();
			
			if( this.Element != null )
			{
				this.EventManager.GetEvent<DslEditorEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
			}
			
			if( this.ShapeElement != null )
			{
				this.EventManager.GetEvent<DslEditorEvents::ModelElementPropertyChangedEvent>().Subscribe(this.ShapeElement.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
			}
		}
		
		/// <summary>
		/// Unsubscribes from model element property change events.
		/// </summary>
		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			
			if( this.Element != null )
			{
				this.EventManager.GetEvent<DslEditorEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
			}
			
			if( this.ShapeElement != null )
			{
				this.EventManager.GetEvent<DslEditorEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.ShapeElement.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
			}	
		}
		#endregion
		
	}
	
		
}
