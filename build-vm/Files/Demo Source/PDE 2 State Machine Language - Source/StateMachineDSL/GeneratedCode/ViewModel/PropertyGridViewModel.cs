 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.StateMachineDSL.ViewModel.PropertyGrid
{
	/// <summary>
    /// Property grid view model for EndState
    /// </summary>
	public partial class PropertyGridEndStateViewModel : Tum.StateMachineDSL.ViewModel.PropertyGrid.PropertyGridStateBaseViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EndState for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridEndStateViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.StateMachineDSL.EndState element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "End State"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.EndState.Description");
			}
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> GetEditorViewModels()
		{
			System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel>();
			collection = base.GetEditorViewModels();
			

			return collection;
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for State
    /// </summary>
	public partial class PropertyGridStateViewModel : Tum.StateMachineDSL.ViewModel.PropertyGrid.PropertyGridStateBaseViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type State for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridStateViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.StateMachineDSL.State element) : base(viewModelStore, element)
		{
			// subscribe to State.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.StateMachineDSL.State.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (State)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (State)";
			else
				this.ElementFullName = "State";
		}

		private string elementFullNameStorage = string.Empty;
		
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get
			{
				return elementFullNameStorage;
			}
			set
			{
				elementFullNameStorage = value;
				OnPropertyChanged("ElementFullName");
			}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.State.Description");
			}
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> GetEditorViewModels()
		{
			System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel>();
			collection = base.GetEditorViewModels();
			
			CreateEditorViewModelForName(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for State.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.State/Name.DisplayName");
			editor.PropertyDescription = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.State/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
				
		#endregion		

		#region Dispose
		/// <summary>
		/// Unregister from events although they are weak.
		/// </summary>
		protected override void OnDispose()
		{
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.StateMachineDSL.State.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for StartState
    /// </summary>
	public partial class PropertyGridStartStateViewModel : Tum.StateMachineDSL.ViewModel.PropertyGrid.PropertyGridStateBaseViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type StartState for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridStartStateViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.StateMachineDSL.StartState element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Start State"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.StartState.Description");
			}
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> GetEditorViewModels()
		{
			System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel>();
			collection = base.GetEditorViewModels();
			

			return collection;
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Transition
    /// </summary>
	public partial class PropertyGridTransitionViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Transition for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridTransitionViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.StateMachineDSL.Transition element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Transition"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition.Description");
			}
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> GetEditorViewModels()
		{
			System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel>();
			
			CreateEditorViewModelForCondition(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Transition.Condition
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForCondition(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Condition";
			editor.PropertyDisplayName = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/Condition.DisplayName");
			editor.PropertyDescription = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/Condition.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
				
		#endregion		
	}
	/// <summary>
    /// Property grid view model for StateBase
    /// </summary>
	public abstract partial class PropertyGridStateBaseViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type StateBase for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridStateBaseViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.StateMachineDSL.StateBase element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "State Base"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.StateBase.Description");
			}
		}
		#endregion
		
		#region Methods
        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public override System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> GetEditorViewModels()
		{
			System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection = new System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel>();
			
			CreateEditorViewModelForStateBaseTargetRole(collection);
			CreateEditorViewModelForStateBaseSourceRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for StateBase.StateBaseTarget
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForStateBaseTargetRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.StateMachineDSL.Transition.DomainClassId),
					   				global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
			
			editor.PropertyName = "StateBaseTarget";
			editor.PropertyDisplayName = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/StateBaseSource.PropertyDisplayName");
			editor.PropertyDescription = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/StateBaseTarget.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for StateBase.StateBaseSource
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForStateBaseSourceRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.StateMachineDSL.Transition.DomainClassId),
					   				global::Tum.StateMachineDSL.Transition.StateBaseTargetDomainRoleId);
			
			editor.PropertyName = "StateBaseSource";
			editor.PropertyDisplayName = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/StateBaseTarget.PropertyDisplayName");
			editor.PropertyDescription = StateMachineLanguageDomainModel.SingletonResourceManager.GetString("Tum.StateMachineDSL.Transition/StateBaseSource.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
				
		#endregion		
	}
}
