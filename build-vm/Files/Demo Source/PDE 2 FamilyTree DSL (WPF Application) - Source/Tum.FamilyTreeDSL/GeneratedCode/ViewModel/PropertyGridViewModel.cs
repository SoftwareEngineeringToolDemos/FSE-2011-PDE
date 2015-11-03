 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.FamilyTreeDSL.ViewModel.PropertyGrid
{
	/// <summary>
    /// Property grid view model for FamilyTreePerson
    /// </summary>
	public partial class PropertyGridFamilyTreePersonViewModel : Tum.FamilyTreeDSL.ViewModel.PropertyGrid.PropertyGridPersonViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type FamilyTreePerson for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridFamilyTreePersonViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.FamilyTreeDSL.FamilyTreePerson element) : base(viewModelStore, element)
		{
			// subscribe to FamilyTreePerson.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.FamilyTreePerson.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Family Tree Person)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Family Tree Person)";
			else
				this.ElementFullName = "Family Tree Person";
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
				return FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.FamilyTreePerson.Description");
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

		#region Dispose
		/// <summary>
		/// Unregister from events although they are weak.
		/// </summary>
		protected override void OnDispose()
		{
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.FamilyTreePerson.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ParentOf
    /// </summary>
	public partial class PropertyGridParentOfViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ParentOf for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridParentOfViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.FamilyTreeDSL.ParentOf element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Parent Of"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.ParentOf.Description");
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
			

			return collection;
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for MarriedTo
    /// </summary>
	public partial class PropertyGridMarriedToViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type MarriedTo for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridMarriedToViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.FamilyTreeDSL.MarriedTo element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Married To"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.MarriedTo.Description");
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
			

			return collection;
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Person
    /// </summary>
	public abstract partial class PropertyGridPersonViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Person for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridPersonViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.FamilyTreeDSL.Person element) : base(viewModelStore, element)
		{
			// subscribe to Person.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Person.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Person)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Person)";
			else
				this.ElementFullName = "Person";
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
				return FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person.Description");
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
			
			CreateEditorViewModelForName(collection);
			CreateEditorViewModelForGender(collection);
			CreateEditorViewModelForHobbies(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Person.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Name.DisplayName");
			editor.PropertyDescription = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Person.Gender
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForGender(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.FamilyTreeDSL.Gender), false);
			
            editor.PropertyName = "Gender";
			editor.PropertyDisplayName = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Gender.DisplayName");
			editor.PropertyDescription = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Gender.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Person.Hobbies
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForHobbies(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Hobbies";
			editor.PropertyDisplayName = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Hobbies.DisplayName");
			editor.PropertyDescription = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Person/Hobbies.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Person.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Pet
    /// </summary>
	public partial class PropertyGridPetViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Pet for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridPetViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.FamilyTreeDSL.Pet element) : base(viewModelStore, element)
		{
			// subscribe to Pet.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Pet.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Pet)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Pet)";
			else
				this.ElementFullName = "Pet";
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
				return FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Pet.Description");
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
			
			CreateEditorViewModelForName(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Pet.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Pet/Name.DisplayName");
			editor.PropertyDescription = FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Pet/Name.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Pet.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
}
