 
using DslModeling = Microsoft.VisualStudio.Modeling;
using DslEditorViewModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for DomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class DomainElementSpecificViewModel : DomainElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public DomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public DomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public DomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for DomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class DomainElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.BaseDomainElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected DomainElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the DomainElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.DomainElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.DomainElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

				AddElementType(this.Element.ElementType);
		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnElementTypeAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnElementTypeRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnElementTypeChanged));					
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnElementTypeChanged));
					
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
        }

		#region DomainElementReferencesDEType.ElementType
		/// <summary>
        /// ElementType view model host.
        /// </summary>
		protected DslEditorViewModel::BaseSpecificModelElementViewModel ElementTypeVMHost = null;
		
		/// <summary>
        /// Gets the ElementType view model.
        /// </summary>
		public DslEditorViewModel::BaseSpecificModelElementViewModel ElementTypeVM
		{
			get
			{
				return this.ElementTypeVMHost;
			}
		}
		
		/// <summary>
        /// Adds a new DEType view model for the given DEType.
        /// </summary>
		/// <param name="element">DEType.</param>
        public virtual void AddElementType(global::Tum.PDE.ModelingDSL.DEType element)
        {
			if( element == null && !ShouldCreateVMForNullElements("Tum.PDE.ModelingDSL.DEType"))
				return;
			if( this.ElementTypeVM != null )
				if( this.ElementTypeVM.Element == element )
					return;
			
			DslEditorViewModel::BaseSpecificModelElementViewModel vm = null;
			if( element != null )
				vm= this.ViewModelStore.SpecificViewModelStore.TryGetVM("DslEditorViewModel::BaseSpecificModelElementViewModel", element.Id) as DslEditorViewModel::BaseSpecificModelElementViewModel;
			if( vm == null )
				vm = new DslEditorViewModel::BaseSpecificModelElementViewModel(this.ViewModelStore, element, this);
			//this.ViewModelStore.SpecificViewModelStore.AddVM(vm, this.Id);
			
			this.ElementTypeVMHost = vm;
					
				
			OnPropertyChanged("ElementTypeVM");				
        }

        /// <summary>
        /// Deletes the DomainElement view model that is hosting the given DomainElement.
        /// </summary>
        /// <param name="element">DomainElement.</param>
        public virtual void DeleteElementType(global::Tum.PDE.ModelingDSL.DEType element)
        {
			if( element == null )
				return;
				
			if( this.ElementTypeVM != null )
				if( this.ElementTypeVM.Element == element )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.ElementTypeVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.ElementTypeVM) )
						this.ElementTypeVM.Dispose();
                    this.ElementTypeVMHost = null;
				}
				
			OnPropertyChanged("ElementTypeVM");				
        }		
		
		/// <summary>
        /// Called whenever a relationship of type DomainElementReferencesDEType is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnElementTypeAdded(DslModeling::ElementAddedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType con = args.ModelElement as global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType;
            if (con != null)
            {
                AddElementType(con.DEType);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type DomainElementReferencesDEType is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnElementTypeRemoved(DslModeling::ElementDeletedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType con = args.ModelElement as global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType;
            if (con != null)
            {
                DeleteElementType(con.DEType);
            }
		}
		
		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnElementTypeChanged(DslModeling::RolePlayerChangedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType con = args.ElementLink as global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType;
            if (con != null)
            {
                if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.Element.Id)
                       DeleteElementType(con.DEType);

                    if (args.NewRolePlayerId == this.Element.Id)
                        AddElementType(con.DEType);
                }
				else if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteElementType(args.OldRolePlayer as global::Tum.PDE.ModelingDSL.DEType);

                    if( args.NewRolePlayer != null )
                        AddElementType(args.NewRolePlayer as global::Tum.PDE.ModelingDSL.DEType);
				}
            }
		}
		#endregion			

		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnElementTypeAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnElementTypeRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnElementTypeChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnElementTypeChanged));
			
				if( this.ElementTypeVM != null )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.ElementTypeVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.ElementTypeVM) )
						if( !this.ElementTypeVM.IsDisposed && !this.ElementTypeVM.IsDisposing )
							this.ElementTypeVM.Dispose();
                	this.ElementTypeVMHost = null;
				}
				
					
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for BaseElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class BaseElementSpecificViewModel : BaseElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public BaseElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public BaseElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public BaseElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for BaseElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class BaseElementSpecificViewModelBase : DslEditorViewModel::BaseSpecificModelElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected BaseElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the BaseElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.BaseElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.BaseElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
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
        }


		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for ReferenceableElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class ReferenceableElementSpecificViewModel : ReferenceableElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public ReferenceableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceableElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public ReferenceableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public ReferenceableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for ReferenceableElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class ReferenceableElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.AttributedDomainElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected ReferenceableElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the ReferenceableElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.ReferenceableElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.ReferenceableElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

				foreach(global::Tum.PDE.ModelingDSL.ReferenceableElement m in this.Element.Targets)
					AddTargets(m);
		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnTargetsAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnTargetsRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnTargetsChanged));					
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnTargetsChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	this.Element.Id, new System.Action<DslModeling::RolePlayerOrderChangedEventArgs>(OnTargetsMoved));
					
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
        }

		#region ReferenceRelationship.Targets
		/// <summary>
        /// Targets view models host.
        /// </summary>
		protected System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel> TargetsVMsHost = new System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel>();
		
		/// <summary>
        /// Gets the Targets view model collection.
        /// </summary>
		public System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel> TargetsVMs
		{
			get
			{
				return this.TargetsVMsHost;
			}
		}
		
		/// <summary>
        /// Adds a new ReferenceableElement view model for the given ReferenceableElement.
        /// </summary>
		/// <param name="element">ReferenceableElement.</param>
        public virtual void AddTargets(global::Tum.PDE.ModelingDSL.ReferenceableElement element)
        {
			if( element == null && !ShouldCreateVMForNullElements("Tum.PDE.ModelingDSL.ReferenceableElement"))
				return;
            // verify that element has not been added yet
            foreach (Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel viewModel in this.TargetsVMs)
                if (viewModel.Element.Id == element.Id)
                    return;
            
			Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel vm = null;
			if( element != null )
				vm= this.ViewModelStore.SpecificViewModelStore.TryGetVM("Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel", element.Id) as Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel;
			if( vm == null )
				vm = new Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel(this.ViewModelStore, element, this);
			else if( vm != null )
				this.ViewModelStore.SpecificViewModelStore.AddVM(vm, this.Id);
				
			
            this.TargetsVMs.Add(vm);

            OnPropertyChanged("TargetsVMs");
        }

        /// <summary>
        /// Deletes the ReferenceableElement view model that is hosting the given ReferenceableElement.
        /// </summary>
        /// <param name="element">ReferenceableElement.</param>
        public virtual void DeleteTargets(global::Tum.PDE.ModelingDSL.ReferenceableElement element)
        {
			if( element == null )
				return;
				
            for (int i = this.TargetsVMs.Count - 1; i >= 0; i--)
			{
				if( this.TargetsVMs[i].Element == null )
					continue;
				
                if (this.TargetsVMs[i].Element.Id == element.Id)
                {
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.TargetsVMs[i], this.Id);
					Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel vmTemp = this.TargetsVMs[i];
					this.TargetsVMs.RemoveAt(i);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(vmTemp) )
						vmTemp.Dispose();
                    
				}
			}

            OnPropertyChanged("TargetsVMs");
        }		
		
		/// <summary>
        /// Called whenever a relationship of type ReferenceRelationship is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnTargetsAdded(DslModeling::ElementAddedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship con = args.ModelElement as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
            if (con != null)
            {
                AddTargets(con.Target);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type ReferenceRelationship is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnTargetsRemoved(DslModeling::ElementDeletedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship con = args.ModelElement as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
            if (con != null)
            {
                DeleteTargets(con.Target);
            }
		}
		
		
		/// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnTargetsMoved(DslModeling::RolePlayerOrderChangedEventArgs args)
		{
			this.HandleRolePlayerMoved<Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel>(args, this.TargetsVMs);
				/*
			if (args.SourceElement == this.Element)
                this.TargetsVMs.Move(args.OldOrdinal, args.NewOrdinal);
				*/
		}

		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnTargetsChanged(DslModeling::RolePlayerChangedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship con = args.ElementLink as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
            if (con != null)
            {
                if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.Element.Id)
                       DeleteTargets(con.Target);

                    if (args.NewRolePlayerId == this.Element.Id)
                        AddTargets(con.Target);
                }
				else if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteTargets(args.OldRolePlayer as global::Tum.PDE.ModelingDSL.ReferenceableElement);

                    if( args.NewRolePlayer != null )
                        AddTargets(args.NewRolePlayer as global::Tum.PDE.ModelingDSL.ReferenceableElement);
				}
            }
		}
		#endregion			

		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnTargetsAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnTargetsRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnTargetsChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnTargetsChanged));
			
 				for( int i = this.TargetsVMs.Count-1; i>=0; i--)
                {
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.TargetsVMs[i], this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.TargetsVMs[i]) )
						if( !this.TargetsVMs[i].IsDisposed && !this.TargetsVMs[i].IsDisposing )
							this.TargetsVMs[i].Dispose();
                    this.TargetsVMs.RemoveAt(i);
				}
				
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
                	this.Element.Id, new System.Action<DslModeling::RolePlayerOrderChangedEventArgs>(OnTargetsMoved));
					
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for EmbeddableElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class EmbeddableElementSpecificViewModel : EmbeddableElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public EmbeddableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddableElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public EmbeddableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public EmbeddableElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for EmbeddableElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class EmbeddableElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.ReferenceableElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected EmbeddableElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddableElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the EmbeddableElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.EmbeddableElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.EmbeddableElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

				AddParent(this.Element.Parent);
		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnParentAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnParentRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnParentChanged));					
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnParentChanged));
					
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
        }

		#region EmbeddingRelationship.Parent
		/// <summary>
        /// Parent view model host.
        /// </summary>
		protected Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel ParentVMHost = null;
		
		/// <summary>
        /// Gets the Parent view model.
        /// </summary>
		public Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel ParentVM
		{
			get
			{
				return this.ParentVMHost;
			}
		}
		
		/// <summary>
        /// Adds a new EmbeddableElement view model for the given EmbeddableElement.
        /// </summary>
		/// <param name="element">EmbeddableElement.</param>
        public virtual void AddParent(global::Tum.PDE.ModelingDSL.EmbeddableElement element)
        {
			if( element == null && !ShouldCreateVMForNullElements("Tum.PDE.ModelingDSL.EmbeddableElement"))
				return;
			if( this.ParentVM != null )
				if( this.ParentVM.Element == element )
					return;
			
			Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel vm = null;
			if( element != null )
				vm= this.ViewModelStore.SpecificViewModelStore.TryGetVM("Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel", element.Id) as Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel;
			if( vm == null )
				vm = new Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel(this.ViewModelStore, element, this);
			//this.ViewModelStore.SpecificViewModelStore.AddVM(vm, this.Id);
			
			this.ParentVMHost = vm;
					
				
			OnPropertyChanged("ParentVM");				
        }

        /// <summary>
        /// Deletes the EmbeddableElement view model that is hosting the given EmbeddableElement.
        /// </summary>
        /// <param name="element">EmbeddableElement.</param>
        public virtual void DeleteParent(global::Tum.PDE.ModelingDSL.EmbeddableElement element)
        {
			if( element == null )
				return;
				
			if( this.ParentVM != null )
				if( this.ParentVM.Element == element )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.ParentVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.ParentVM) )
						this.ParentVM.Dispose();
                    this.ParentVMHost = null;
				}
				
			OnPropertyChanged("ParentVM");				
        }		
		
		/// <summary>
        /// Called whenever a relationship of type EmbeddingRelationship is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnParentAdded(DslModeling::ElementAddedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship con = args.ModelElement as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
            if (con != null)
            {
                AddParent(con.Parent);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type EmbeddingRelationship is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnParentRemoved(DslModeling::ElementDeletedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship con = args.ModelElement as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
            if (con != null)
            {
                DeleteParent(con.Parent);
            }
		}
		
		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnParentChanged(DslModeling::RolePlayerChangedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship con = args.ElementLink as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
            if (con != null)
            {
                if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.Element.Id)
                       DeleteParent(con.Parent);

                    if (args.NewRolePlayerId == this.Element.Id)
                        AddParent(con.Parent);
                }
				else if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteParent(args.OldRolePlayer as global::Tum.PDE.ModelingDSL.EmbeddableElement);

                    if( args.NewRolePlayer != null )
                        AddParent(args.NewRolePlayer as global::Tum.PDE.ModelingDSL.EmbeddableElement);
				}
            }
		}
		#endregion			

		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnParentAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnParentRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnParentChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnParentChanged));
			
				if( this.ParentVM != null )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.ParentVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.ParentVM) )
						if( !this.ParentVM.IsDisposed && !this.ParentVM.IsDisposing )
							this.ParentVM.Dispose();
                	this.ParentVMHost = null;
				}
				
					
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for NamedDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class NamedDomainElementSpecificViewModel : NamedDomainElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public NamedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.NamedDomainElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public NamedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.NamedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public NamedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.NamedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for NamedDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class NamedDomainElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.BaseElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected NamedDomainElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.NamedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the NamedDomainElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.NamedDomainElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.NamedDomainElement; }
        }

		/// <summary>
        /// Gets or sets the Description property.
        /// </summary>
		public global::System.String Description
		{
			get
			{
				return this.Element.Description;
			}
			set
			{
				if( this.Element.Description != value )
				{
					using(DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set the Description property."))
					{
						this.Element.Description = value;
						transaction.Commit();	
					}
				}
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
			if (args.DomainProperty.Id == global::Tum.PDE.ModelingDSL.NamedDomainElement.DescriptionDomainPropertyId)
                OnPropertyChanged("Description");
        }


		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for AttributedDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class AttributedDomainElementSpecificViewModel : AttributedDomainElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public AttributedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.AttributedDomainElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public AttributedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.AttributedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public AttributedDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.AttributedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for AttributedDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class AttributedDomainElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.NamedDomainElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected AttributedDomainElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.AttributedDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the AttributedDomainElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.AttributedDomainElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.AttributedDomainElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

				foreach(global::Tum.PDE.ModelingDSL.DomainProperty m in this.Element.DomainProperty)
					AddDomainProperty(m);
		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnDomainPropertyAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnDomainPropertyRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainPropertyChanged));					
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainPropertyChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	this.Element.Id, new System.Action<DslModeling::RolePlayerOrderChangedEventArgs>(OnDomainPropertyMoved));
					
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
        }

		#region AttributedDomainElementHasDomainProperty.DomainProperty
		/// <summary>
        /// DomainProperty view models host.
        /// </summary>
		protected System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel> DomainPropertyVMsHost = new System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel>();
		
		/// <summary>
        /// Gets the DomainProperty view model collection.
        /// </summary>
		public System.Collections.ObjectModel.ObservableCollection<Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel> DomainPropertyVMs
		{
			get
			{
				return this.DomainPropertyVMsHost;
			}
		}
		
		/// <summary>
        /// Adds a new DomainProperty view model for the given DomainProperty.
        /// </summary>
		/// <param name="element">DomainProperty.</param>
        public virtual void AddDomainProperty(global::Tum.PDE.ModelingDSL.DomainProperty element)
        {
			if( element == null && !ShouldCreateVMForNullElements("Tum.PDE.ModelingDSL.DomainProperty"))
				return;
            // verify that element has not been added yet
            foreach (Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel viewModel in this.DomainPropertyVMs)
                if (viewModel.Element.Id == element.Id)
                    return;
            
			Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel vm = null;
			if( element != null )
				vm= this.ViewModelStore.SpecificViewModelStore.TryGetVM("Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel", element.Id) as Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel;
			if( vm == null )
				vm = new Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel(this.ViewModelStore, element, this);
			else if( vm != null )
				this.ViewModelStore.SpecificViewModelStore.AddVM(vm, this.Id);
				
			
            this.DomainPropertyVMs.Add(vm);

            OnPropertyChanged("DomainPropertyVMs");
        }

        /// <summary>
        /// Deletes the AttributedDomainElement view model that is hosting the given AttributedDomainElement.
        /// </summary>
        /// <param name="element">AttributedDomainElement.</param>
        public virtual void DeleteDomainProperty(global::Tum.PDE.ModelingDSL.DomainProperty element)
        {
			if( element == null )
				return;
				
            for (int i = this.DomainPropertyVMs.Count - 1; i >= 0; i--)
			{
				if( this.DomainPropertyVMs[i].Element == null )
					continue;
				
                if (this.DomainPropertyVMs[i].Element.Id == element.Id)
                {
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.DomainPropertyVMs[i], this.Id);
					Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel vmTemp = this.DomainPropertyVMs[i];
					this.DomainPropertyVMs.RemoveAt(i);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(vmTemp) )
						vmTemp.Dispose();
                    
				}
			}

            OnPropertyChanged("DomainPropertyVMs");
        }		
		
		/// <summary>
        /// Called whenever a relationship of type AttributedDomainElementHasDomainProperty is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainPropertyAdded(DslModeling::ElementAddedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty con = args.ModelElement as global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty;
            if (con != null)
            {
                AddDomainProperty(con.DomainProperty);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type AttributedDomainElementHasDomainProperty is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainPropertyRemoved(DslModeling::ElementDeletedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty con = args.ModelElement as global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty;
            if (con != null)
            {
                DeleteDomainProperty(con.DomainProperty);
            }
		}
		
		
		/// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainPropertyMoved(DslModeling::RolePlayerOrderChangedEventArgs args)
		{
			this.HandleRolePlayerMoved<Tum.PDE.ModelingDSL.ViewModel.DomainPropertySpecificViewModel>(args, this.DomainPropertyVMs);
				/*
			if (args.SourceElement == this.Element)
                this.DomainPropertyVMs.Move(args.OldOrdinal, args.NewOrdinal);
				*/
		}

		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainPropertyChanged(DslModeling::RolePlayerChangedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty con = args.ElementLink as global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty;
            if (con != null)
            {
                if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.Element.Id)
                       DeleteDomainProperty(con.DomainProperty);

                    if (args.NewRolePlayerId == this.Element.Id)
                        AddDomainProperty(con.DomainProperty);
                }
				else if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteDomainProperty(args.OldRolePlayer as global::Tum.PDE.ModelingDSL.DomainProperty);

                    if( args.NewRolePlayer != null )
                        AddDomainProperty(args.NewRolePlayer as global::Tum.PDE.ModelingDSL.DomainProperty);
				}
            }
		}
		#endregion			

		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnDomainPropertyAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnDomainPropertyRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainPropertyChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainPropertyChanged));
			
 				for( int i = this.DomainPropertyVMs.Count-1; i>=0; i--)
                {
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.DomainPropertyVMs[i], this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.DomainPropertyVMs[i]) )
						if( !this.DomainPropertyVMs[i].IsDisposed && !this.DomainPropertyVMs[i].IsDisposing )
							this.DomainPropertyVMs[i].Dispose();
                    this.DomainPropertyVMs.RemoveAt(i);
				}
				
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId),
                	this.Element.Id, new System.Action<DslModeling::RolePlayerOrderChangedEventArgs>(OnDomainPropertyMoved));
					
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for BaseDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class BaseDomainElementSpecificViewModel : BaseDomainElementSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public BaseDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElement element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public BaseDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public BaseDomainElementSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for BaseDomainElement.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class BaseDomainElementSpecificViewModelBase : Tum.PDE.ModelingDSL.ViewModel.EmbeddableElementSpecificViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected BaseDomainElementSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElement element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the BaseDomainElement, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.BaseDomainElement Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.BaseDomainElement; }
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
			}
		}
		#endregion
		
		#region Subscription and Unsubscription
		/// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
        {
			base.OnElementPropertyChanged(args);
			
        }


		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for DomainProperty.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class DomainPropertySpecificViewModel : DomainPropertySpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public DomainPropertySpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public DomainPropertySpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public DomainPropertySpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for DomainProperty.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class DomainPropertySpecificViewModelBase : DslEditorViewModel::BaseSpecificModelElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected DomainPropertySpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the DomainProperty, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.DomainProperty Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.DomainProperty; }
        }

		/// <summary>
        /// Gets or sets the Value property.
        /// </summary>
		public global::System.String Value
		{
			get
			{
				return this.Element.Value;
			}
			set
			{
				if( this.Element.Value != value )
				{
					using(DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set the Value property."))
					{
						this.Element.Value = value;
						transaction.Commit();	
					}
				}
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

				AddDomainType(this.Element.DomainType);
		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnDomainTypeAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnDomainTypeRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainTypeChanged));					
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainTypeDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainTypeChanged));
					
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
			if (args.DomainProperty.Id == global::Tum.PDE.ModelingDSL.DomainProperty.ValueDomainPropertyId)
                OnPropertyChanged("Value");
        }

		#region DomainPropertyReferencesDomainType.DomainType
		/// <summary>
        /// DomainType view model host.
        /// </summary>
		protected DslEditorViewModel::BaseSpecificModelElementViewModel DomainTypeVMHost = null;
		
		/// <summary>
        /// Gets the DomainType view model.
        /// </summary>
		public DslEditorViewModel::BaseSpecificModelElementViewModel DomainTypeVM
		{
			get
			{
				return this.DomainTypeVMHost;
			}
		}
		
		/// <summary>
        /// Adds a new DomainType view model for the given DomainType.
        /// </summary>
		/// <param name="element">DomainType.</param>
        public virtual void AddDomainType(global::Tum.PDE.ModelingDSL.DomainType element)
        {
			if( element == null && !ShouldCreateVMForNullElements("Tum.PDE.ModelingDSL.DomainType"))
				return;
			if( this.DomainTypeVM != null )
				if( this.DomainTypeVM.Element == element )
					return;
			
			DslEditorViewModel::BaseSpecificModelElementViewModel vm = null;
			if( element != null )
				vm= this.ViewModelStore.SpecificViewModelStore.TryGetVM("DslEditorViewModel::BaseSpecificModelElementViewModel", element.Id) as DslEditorViewModel::BaseSpecificModelElementViewModel;
			if( vm == null )
				vm = new DslEditorViewModel::BaseSpecificModelElementViewModel(this.ViewModelStore, element, this);
			//this.ViewModelStore.SpecificViewModelStore.AddVM(vm, this.Id);
			
			this.DomainTypeVMHost = vm;
					
				
			OnPropertyChanged("DomainTypeVM");				
        }

        /// <summary>
        /// Deletes the DomainProperty view model that is hosting the given DomainProperty.
        /// </summary>
        /// <param name="element">DomainProperty.</param>
        public virtual void DeleteDomainType(global::Tum.PDE.ModelingDSL.DomainType element)
        {
			if( element == null )
				return;
				
			if( this.DomainTypeVM != null )
				if( this.DomainTypeVM.Element == element )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.DomainTypeVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.DomainTypeVM) )
						this.DomainTypeVM.Dispose();
                    this.DomainTypeVMHost = null;
				}
				
			OnPropertyChanged("DomainTypeVM");				
        }		
		
		/// <summary>
        /// Called whenever a relationship of type DomainPropertyReferencesDomainType is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainTypeAdded(DslModeling::ElementAddedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType con = args.ModelElement as global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType;
            if (con != null)
            {
                AddDomainType(con.DomainType);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type DomainPropertyReferencesDomainType is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainTypeRemoved(DslModeling::ElementDeletedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType con = args.ModelElement as global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType;
            if (con != null)
            {
                DeleteDomainType(con.DomainType);
            }
		}
		
		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnDomainTypeChanged(DslModeling::RolePlayerChangedEventArgs args)
		{
			global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType con = args.ElementLink as global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType;
            if (con != null)
            {
                if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.Element.Id)
                       DeleteDomainType(con.DomainType);

                    if (args.NewRolePlayerId == this.Element.Id)
                        AddDomainType(con.DomainType);
                }
				else if (args.DomainRole.Id == global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainTypeDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteDomainType(args.OldRolePlayer as global::Tum.PDE.ModelingDSL.DomainType);

                    if( args.NewRolePlayer != null )
                        AddDomainType(args.NewRolePlayer as global::Tum.PDE.ModelingDSL.DomainType);
				}
            }
		}
		#endregion			

		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementAddedEventArgs>(OnDomainTypeAdded));
            	this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId),
                	true, this.Element.Id, new System.Action<DslModeling::ElementDeletedEventArgs>(OnDomainTypeRemoved));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainTypeChanged));
				this.EventManager.GetEvent<DslEditorViewModelEvents::ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainTypeDomainRoleId),
                	new System.Action<DslModeling::RolePlayerChangedEventArgs>(OnDomainTypeChanged));
			
				if( this.DomainTypeVM != null )
				{
					this.ViewModelStore.SpecificViewModelStore.RemoveVM(this.DomainTypeVM, this.Id);
					if( !this.ViewModelStore.SpecificViewModelStore.IsVMInUse(this.DomainTypeVM) )
						if( !this.DomainTypeVM.IsDisposed && !this.DomainTypeVM.IsDisposing )
							this.DomainTypeVM.Dispose();
                	this.DomainTypeVMHost = null;
				}
				
					
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
    /// Specific view model class for ConversionModelInfo.
    /// 
    /// Double derived to allow easier custimization. This is the derived class.
    /// </summary>
	public partial class ConversionModelInfoSpecificViewModel : ConversionModelInfoSpecificViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
        public ConversionModelInfoSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ConversionModelInfo element)
            : this(viewModelStore, element, null)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public ConversionModelInfoSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ConversionModelInfo element, DslEditorViewModel::BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
		}
		
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        public ConversionModelInfoSpecificViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ConversionModelInfo element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, bCallInitialize)
        {
		}		
		
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		#endregion
		
		
	}

	/// <summary>
    /// Specific view model class for ConversionModelInfo.
    /// 
    /// Double derived to allow easier custimization. This is the base class.
    /// </summary>
	public abstract class ConversionModelInfoSpecificViewModelBase : DslEditorViewModel::BaseSpecificModelElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
		/// <param name="bCallInitialize"></param>
        protected ConversionModelInfoSpecificViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ConversionModelInfo element, DslEditorViewModel::BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, parentVM, false)
        {
			if( bCallInitialize )
			{
				this.Initialize();
				
				this.InitializeRelationships();
				this.InitializeSubscription();				
			}
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets an instance of this vm.
        /// </summary>
		public override DslEditorViewModel::BaseSpecificModelElementViewModel GetInstance()
		{
			return this;
		}
		
        /// <summary>
        /// Gets the ConversionModelInfo, which is represented by this view model.
        /// </summary>
        public new global::Tum.PDE.ModelingDSL.ConversionModelInfo Element
        {
            get { return base.Element as global::Tum.PDE.ModelingDSL.ConversionModelInfo; }
        }

		/// <summary>
        /// Gets or sets the HasModelChanged property.
        /// </summary>
		public global::System.Boolean? HasModelChanged
		{
			get
			{
				return this.Element.HasModelChanged;
			}
			set
			{
				if( this.Element.HasModelChanged != value )
				{
					using(DslModeling::Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set the HasModelChanged property."))
					{
						this.Element.HasModelChanged = value;
						transaction.Commit();	
					}
				}
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
		
		/// <summary>
        /// Initialize Relationship children.
        /// </summary>
		protected override void InitializeRelationships()
		{			
            base.InitializeRelationships();
		
			if( this.Element != null )
			{

		
			}
		
		}
		
		/// <summary>
        /// Sets up subscription.
        /// </summary>
		protected override void InitializeSubscription()
		{
			base.InitializeSubscription();
			
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
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
			if (args.DomainProperty.Id == global::Tum.PDE.ModelingDSL.ConversionModelInfo.HasModelChangedDomainPropertyId)
                OnPropertyChanged("HasModelChanged");
        }


		/// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
			if( this.Element != null )
			{
				// properties
                this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
				
			}
		
            base.OnDispose();
        }
		#endregion
	}
}
