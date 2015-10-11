 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL.ViewModel
{
	/// <summary>
    /// View model for PersonShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class PersonShapeDiagramItemViewModel : PersonShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public PersonShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for PersonShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class PersonShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected PersonShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
		
		#region Methods
        /// <summary>
        /// Gets whether this view model can have nested children or not.
        /// </summary>
        public override bool CanHaveNestedChildren 
		{ 
			get
			{
				return false;
			}
		}

        /// <summary>
        /// Gets whether this view model can have relative children or not.
        /// </summary>
        public override bool CanHaveRelativeChildren
		{ 
			get
			{
			
				return false;
			}
		}
		
        #endregion			

		#region Properties
        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>
		/// Items need to delete their hosted element if they are themselves not directly hosted
		/// on the diagram's surface.
		/// </remarks>
        public override bool AutomaticallyDeletesHostedElement 
        {
            get
            {

				return false;
            }
        }		
		#endregion
		
		#region Element Properties
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		public global::System.String Element_Name
		{
			get
			{
				return this.DomainElementName;
			}
			set
			{
				if( this.DomainElementName != value )
					this.DomainElementName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Gender domain property.
		/// </summary>
		public global::Tum.FamilyTreeDSL.Gender? Element_Gender
		{
			get
			{
				return (this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Gender;
			}
			set
			{
				if( (this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Gender != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Gender") )
					{
						(this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Gender = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Hobbies domain property.
		/// </summary>
		public global::System.String Element_Hobbies
		{
			get
			{
				return (this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Hobbies;
			}
			set
			{
				if( (this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Hobbies != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Hobbies") )
					{
						(this.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson).Hobbies = value;
						
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
		
			if( args.DomainProperty.Id == global::Tum.FamilyTreeDSL.Person.NameDomainPropertyId )
				OnPropertyChanged("Element_Name");
			if( args.DomainProperty.Id == global::Tum.FamilyTreeDSL.Person.GenderDomainPropertyId )
				OnPropertyChanged("Element_Gender");
			if( args.DomainProperty.Id == global::Tum.FamilyTreeDSL.Person.HobbiesDomainPropertyId )
				OnPropertyChanged("Element_Hobbies");
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