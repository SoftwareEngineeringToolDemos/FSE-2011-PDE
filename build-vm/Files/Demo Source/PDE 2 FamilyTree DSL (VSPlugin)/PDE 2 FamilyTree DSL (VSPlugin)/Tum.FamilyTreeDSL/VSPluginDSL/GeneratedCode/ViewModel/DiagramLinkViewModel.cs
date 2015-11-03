 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

// DesignerDiagram
namespace Tum.FamilyTreeDSL.ViewModel
{
	/// <summary>
    /// View model for ParentOfShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class ParentOfShapeDiagramItemLinkViewModel : ParentOfShapeDiagramItemLinkViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public ParentOfShapeDiagramItemLinkViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for ParentOfShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class ParentOfShapeDiagramItemLinkViewModelBase : DslEditorViewDiagrams::BaseDiagramItemLinkViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected ParentOfShapeDiagramItemLinkViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion

		#region Element Properties
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
	
	/// <summary>
    /// View model for MarriedToShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class MarriedToShapeDiagramItemLinkViewModel : MarriedToShapeDiagramItemLinkViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public MarriedToShapeDiagramItemLinkViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for MarriedToShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class MarriedToShapeDiagramItemLinkViewModelBase : DslEditorViewDiagrams::BaseDiagramItemLinkViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected MarriedToShapeDiagramItemLinkViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion

		#region Element Properties
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
