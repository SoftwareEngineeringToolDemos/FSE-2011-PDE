 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

// DesignerDiagram
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// View model for ReferenceShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class ReferenceShapeDiagramItemLinkViewModel : ReferenceShapeDiagramItemLinkViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public ReferenceShapeDiagramItemLinkViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for ReferenceShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class ReferenceShapeDiagramItemLinkViewModelBase : DslEditorViewDiagrams::BaseDiagramItemLinkViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected ReferenceShapeDiagramItemLinkViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion

		#region Element Properties
		/// <summary>
		/// Gets or sets the value of SourceMultiplicity domain property.
		/// </summary>
		public global::Tum.PDE.ModelingDSL.Multiplicity? Element_SourceMultiplicity
		{
			get
			{
				return (this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).SourceMultiplicity;
			}
			set
			{
				if( (this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).SourceMultiplicity != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of SourceMultiplicity") )
					{
						(this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).SourceMultiplicity = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of TargetMultiplicity domain property.
		/// </summary>
		public global::Tum.PDE.ModelingDSL.Multiplicity? Element_TargetMultiplicity
		{
			get
			{
				return (this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).TargetMultiplicity;
			}
			set
			{
				if( (this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).TargetMultiplicity != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of TargetMultiplicity") )
					{
						(this.Element as global::Tum.PDE.ModelingDSL.ReferenceRelationship).TargetMultiplicity = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		#endregion
		#region Shape Properties
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
		
			if( args.DomainProperty.Id == global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceMultiplicityDomainPropertyId )
				OnPropertyChanged("Element_SourceMultiplicity");
			if( args.DomainProperty.Id == global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetMultiplicityDomainPropertyId )
				OnPropertyChanged("Element_TargetMultiplicity");
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
    /// View model for EmbeddingShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class EmbeddingShapeDiagramItemLinkViewModel : EmbeddingShapeDiagramItemLinkViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public EmbeddingShapeDiagramItemLinkViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for EmbeddingShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class EmbeddingShapeDiagramItemLinkViewModelBase : DslEditorViewDiagrams::BaseDiagramItemLinkViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected EmbeddingShapeDiagramItemLinkViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::LinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion

		#region Element Properties
		#endregion
		#region Shape Properties
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
// ConversionDiagram
namespace Tum.PDE.ModelingDSL.ViewModel
{
		
}
