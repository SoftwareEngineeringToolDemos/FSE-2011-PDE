 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT.ViewModel
{
}
namespace Tum.VModellXT.ViewModel
{
}
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
    /// View model for RolleDependencyShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class RolleDependencyShapeDiagramItemViewModel : RolleDependencyShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public RolleDependencyShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for RolleDependencyShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class RolleDependencyShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected RolleDependencyShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
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
		/// Gets or sets the value of Beschreibung domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_Beschreibung
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Beschreibung;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Beschreibung != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Beschreibung") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Beschreibung = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of AufgabenUndBefugnisse domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_AufgabenUndBefugnisse
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).AufgabenUndBefugnisse;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).AufgabenUndBefugnisse != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of AufgabenUndBefugnisse") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).AufgabenUndBefugnisse = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Faehigkeitsprofil domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_Faehigkeitsprofil
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Faehigkeitsprofil;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Faehigkeitsprofil != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Faehigkeitsprofil") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Faehigkeitsprofil = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Rollenbesetzung domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_Rollenbesetzung
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Rollenbesetzung;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Rollenbesetzung != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Rollenbesetzung") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Rollenbesetzung = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Klasse domain property.
		/// </summary>
		public global::Tum.VModellXT.RollenKlasse? Element_Klasse
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Klasse;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Klasse != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Klasse") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Klasse = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_Version domain property.
		/// </summary>
		public global::System.String Element_Intern_Version
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_Version;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_Version != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_Version") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_Version = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_ConsistentToVersion domain property.
		/// </summary>
		public global::System.String Element_Intern_ConsistentToVersion
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_ConsistentToVersion;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_ConsistentToVersion != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_ConsistentToVersion") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_ConsistentToVersion = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_RefersToId domain property.
		/// </summary>
		public global::System.String Element_Intern_RefersToId
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_RefersToId;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_RefersToId != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_RefersToId") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Rolle).Intern_RefersToId = value;
						
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
		
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.NameDomainPropertyId )
				OnPropertyChanged("Element_Name");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.BeschreibungDomainPropertyId )
				OnPropertyChanged("Element_Beschreibung");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.AufgabenUndBefugnisseDomainPropertyId )
				OnPropertyChanged("Element_AufgabenUndBefugnisse");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.FaehigkeitsprofilDomainPropertyId )
				OnPropertyChanged("Element_Faehigkeitsprofil");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.RollenbesetzungDomainPropertyId )
				OnPropertyChanged("Element_Rollenbesetzung");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Rolle.KlasseDomainPropertyId )
				OnPropertyChanged("Element_Klasse");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_VersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_Version");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_ConsistentToVersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_ConsistentToVersion");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_RefersToIdDomainPropertyId )
				OnPropertyChanged("Element_Intern_RefersToId");
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
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
    /// View model for DisziplinDependencyShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class DisziplinDependencyShapeDiagramItemViewModel : DisziplinDependencyShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public DisziplinDependencyShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for DisziplinDependencyShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class DisziplinDependencyShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected DisziplinDependencyShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
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
		/// Gets or sets the value of Nummer domain property.
		/// </summary>
		public global::System.String Element_Nummer
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Disziplin).Nummer;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Disziplin).Nummer != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Nummer") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Disziplin).Nummer = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of SinnUndZweck domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_SinnUndZweck
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Disziplin).SinnUndZweck;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Disziplin).SinnUndZweck != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of SinnUndZweck") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Disziplin).SinnUndZweck = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_Version domain property.
		/// </summary>
		public global::System.String Element_Intern_Version
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_Version;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_Version != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_Version") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_Version = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_ConsistentToVersion domain property.
		/// </summary>
		public global::System.String Element_Intern_ConsistentToVersion
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_ConsistentToVersion;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_ConsistentToVersion != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_ConsistentToVersion") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_ConsistentToVersion = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_RefersToId domain property.
		/// </summary>
		public global::System.String Element_Intern_RefersToId
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_RefersToId;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_RefersToId != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_RefersToId") )
					{
						(this.Element as global::Tum.VModellXT.Statik.Disziplin).Intern_RefersToId = value;
						
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
		
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Disziplin.NameDomainPropertyId )
				OnPropertyChanged("Element_Name");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Disziplin.NummerDomainPropertyId )
				OnPropertyChanged("Element_Nummer");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.Disziplin.SinnUndZweckDomainPropertyId )
				OnPropertyChanged("Element_SinnUndZweck");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_VersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_Version");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_ConsistentToVersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_ConsistentToVersion");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_RefersToIdDomainPropertyId )
				OnPropertyChanged("Element_Intern_RefersToId");
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
namespace Tum.VModellXT.ViewModel
{
	/// <summary>
    /// View model for ErzAbhDependencyShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class ErzAbhDependencyShapeDiagramItemViewModel : ErzAbhDependencyShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public ErzAbhDependencyShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for ErzAbhDependencyShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class ErzAbhDependencyShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected ErzAbhDependencyShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
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
		/// Gets or sets the value of Nummer domain property.
		/// </summary>
		public global::System.String Element_Nummer
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Nummer;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Nummer != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Nummer") )
					{
						(this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Nummer = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Beschreibung domain property.
		/// </summary>
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Element_Beschreibung
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Beschreibung;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Beschreibung != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Beschreibung") )
					{
						(this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Beschreibung = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_Version domain property.
		/// </summary>
		public global::System.String Element_Intern_Version
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_Version;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_Version != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_Version") )
					{
						(this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_Version = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_ConsistentToVersion domain property.
		/// </summary>
		public global::System.String Element_Intern_ConsistentToVersion
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_ConsistentToVersion;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_ConsistentToVersion != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_ConsistentToVersion") )
					{
						(this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_ConsistentToVersion = value;
						
						transaction.Commit();
					}
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the value of Intern_RefersToId domain property.
		/// </summary>
		public global::System.String Element_Intern_RefersToId
		{
			get
			{
				return (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_RefersToId;
			}
			set
			{
				if( (this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_RefersToId != value )
				{
					using( DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update value of Intern_RefersToId") )
					{
						(this.Element as global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit).Intern_RefersToId = value;
						
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
		
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.NameDomainPropertyId )
				OnPropertyChanged("Element_Name");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.NummerDomainPropertyId )
				OnPropertyChanged("Element_Nummer");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Statik.ErzeugendeAbhaengigkeit.BeschreibungDomainPropertyId )
				OnPropertyChanged("Element_Beschreibung");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_VersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_Version");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_ConsistentToVersionDomainPropertyId )
				OnPropertyChanged("Element_Intern_ConsistentToVersion");
			if( args.DomainProperty.Id == global::Tum.VModellXT.Basis.BaseElement.Intern_RefersToIdDomainPropertyId )
				OnPropertyChanged("Element_Intern_RefersToId");
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
namespace Tum.VModellXT.ViewModel
{
}
namespace Tum.VModellXT.ViewModel
{
}
