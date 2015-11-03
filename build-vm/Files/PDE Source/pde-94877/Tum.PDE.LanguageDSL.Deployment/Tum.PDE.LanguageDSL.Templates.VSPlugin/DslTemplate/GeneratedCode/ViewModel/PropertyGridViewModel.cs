 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.PDE.ModelingDSL.ViewModel.PropertyGrid
{
	/// <summary>
    /// Property grid view model for DomainElement
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class PropertyGridDomainElementViewModelBase : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseDomainElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected PropertyGridDomainElementViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element) : base(viewModelStore, element)
		{
			// subscribe to DomainElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Domain Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Domain Element)";
			else
				this.ElementFullName = "Domain Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElement.Description");
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
			
			CreateEditorViewModelForElementTypeRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for DomainElement.ElementType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForElementTypeRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId);
			
			editor.PropertyName = "ElementType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DomainElement.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DEType.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}

	/// <summary>
    /// Property grid view model for DomainElement
	///
	///	This is the double generated class for easier customization.
	/// </summary>
	public partial class PropertyGridDomainElementViewModel : PropertyGridDomainElementViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainElement for which this property grid view model is created.</param>		
		public PropertyGridDomainElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElement element) : base(viewModelStore, element)
		{
			
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for BaseDomainElement
    /// </summary>
	public abstract partial class PropertyGridBaseDomainElementViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridEmbeddableElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type BaseDomainElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridBaseDomainElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElement element) : base(viewModelStore, element)
		{
			// subscribe to BaseDomainElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.BaseDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Base Domain Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Base Domain Element)";
			else
				this.ElementFullName = "Base Domain Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseDomainElement.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.BaseDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for EmbeddableElement
    /// </summary>
	public abstract partial class PropertyGridEmbeddableElementViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridReferenceableElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EmbeddableElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridEmbeddableElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddableElement element) : base(viewModelStore, element)
		{
			// subscribe to EmbeddableElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EmbeddableElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Embeddable Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Embeddable Element)";
			else
				this.ElementFullName = "Embeddable Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EmbeddableElement.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EmbeddableElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ReferenceableElement
    /// </summary>
	public abstract partial class PropertyGridReferenceableElementViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridAttributedDomainElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ReferenceableElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridReferenceableElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceableElement element) : base(viewModelStore, element)
		{
			// subscribe to ReferenceableElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ReferenceableElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Referenceable Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Referenceable Element)";
			else
				this.ElementFullName = "Referenceable Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ReferenceableElement.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ReferenceableElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ReferencingDRType
    /// </summary>
	public partial class PropertyGridReferencingDRTypeViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridDRTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ReferencingDRType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridReferencingDRTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferencingDRType element) : base(viewModelStore, element)
		{
			// subscribe to ReferencingDRType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ReferencingDRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Referencing DRType)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Referencing DRType)";
			else
				this.ElementFullName = "Referencing DRType";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ReferencingDRType.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ReferencingDRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for EmbeddingDRType
    /// </summary>
	public partial class PropertyGridEmbeddingDRTypeViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridDRTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EmbeddingDRType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridEmbeddingDRTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddingDRType element) : base(viewModelStore, element)
		{
			// subscribe to EmbeddingDRType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EmbeddingDRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Embedding DRType)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Embedding DRType)";
			else
				this.ElementFullName = "Embedding DRType";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EmbeddingDRType.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EmbeddingDRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for AttributedDomainElement
    /// </summary>
	public abstract partial class PropertyGridAttributedDomainElementViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridNamedDomainElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type AttributedDomainElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridAttributedDomainElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.AttributedDomainElement element) : base(viewModelStore, element)
		{
			// subscribe to AttributedDomainElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.AttributedDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Attributed Domain Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Attributed Domain Element)";
			else
				this.ElementFullName = "Attributed Domain Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.AttributedDomainElement.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.AttributedDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DRType
    /// </summary>
	public abstract partial class PropertyGridDRTypeViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseDomainElementTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DRType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDRTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DRType element) : base(viewModelStore, element)
		{
			// subscribe to DRType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (DRType)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (DRType)";
			else
				this.ElementFullName = "DRType";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRType.Description");
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
			
			CreateEditorViewModelForReferencedRelationshipsRole(collection);
			CreateEditorViewModelForSourceRole(collection);
			CreateEditorViewModelForTargetRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for DRType.ReferencedRelationships
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForReferencedRelationshipsRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId);
			
			editor.PropertyName = "ReferencedRelationships";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/DRType.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/BaseElementSourceReferencesBaseElementTarget.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = true;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for DRType.Source
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForSourceRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId);
			
			editor.PropertyName = "Source";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DRTypeS.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DETypeSource.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for DRType.Target
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForTargetRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId);
			
			editor.PropertyName = "Target";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DRTypeT.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DETypeTarget.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DRType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DEType
    /// </summary>
	public partial class PropertyGridDETypeViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseDomainElementTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DEType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDETypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DEType element) : base(viewModelStore, element)
		{
			// subscribe to DEType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DEType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (DEType)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (DEType)";
			else
				this.ElementFullName = "DEType";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType.Description");
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
			
			CreateEditorViewModelForStyleType(collection);
			CreateEditorViewModelForColorType(collection);
			CreateEditorViewModelForFormType(collection);
			CreateEditorViewModelForFileName(collection);
			CreateEditorViewModelForDomainElementRole(collection);
			CreateEditorViewModelForDRTypeSRole(collection);
			CreateEditorViewModelForDRTypeTRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for DEType.StyleType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForStyleType(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.PDE.ModelingDSL.ShapeStyleType), false);
			
            editor.PropertyName = "StyleType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/StyleType.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/StyleType.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DEType.ColorType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForColorType(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.PDE.ModelingDSL.ShapeColorType), false);
			
            editor.PropertyName = "ColorType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/ColorType.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/ColorType.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DEType.FormType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForFormType(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.PDE.ModelingDSL.ShapeFormType), false);
			
            editor.PropertyName = "FormType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/FormType.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/FormType.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DEType.FileName
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForFileName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "FileName";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/FileName.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DEType/FileName.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DEType.DomainElement
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDomainElementRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId);
			
			editor.PropertyName = "DomainElement";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DEType.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DomainElement.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for DEType.DRTypeS
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDRTypeSRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId);
			
			editor.PropertyName = "DRTypeS";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DETypeSource.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DRTypeS.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for DEType.DRTypeT
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDRTypeTRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId);
			
			editor.PropertyName = "DRTypeT";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DETypeTarget.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DRTypeT.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DEType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ReferenceRelationship
    /// </summary>
	public partial class PropertyGridReferenceRelationshipViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseElementSourceReferencesBaseElementTargetViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ReferenceRelationship for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridReferenceRelationshipViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ReferenceRelationship element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Reference Relationship"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ReferenceRelationship.Description");
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
    /// Property grid view model for EmbeddingRelationship
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class PropertyGridEmbeddingRelationshipViewModelBase : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseElementSourceReferencesBaseElementTargetViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EmbeddingRelationship for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected PropertyGridEmbeddingRelationshipViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddingRelationship element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Embedding Relationship"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EmbeddingRelationship.Description");
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
    /// Property grid view model for EmbeddingRelationship
	///
	///	This is the double generated class for easier customization.
	/// </summary>
	public partial class PropertyGridEmbeddingRelationshipViewModel : PropertyGridEmbeddingRelationshipViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EmbeddingRelationship for which this property grid view model is created.</param>		
		public PropertyGridEmbeddingRelationshipViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EmbeddingRelationship element) : base(viewModelStore, element)
		{
			
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ExternalType
    /// </summary>
	public partial class PropertyGridExternalTypeViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridDomainTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ExternalType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridExternalTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ExternalType element) : base(viewModelStore, element)
		{
			// subscribe to ExternalType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ExternalType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (External Type)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (External Type)";
			else
				this.ElementFullName = "External Type";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ExternalType.Description");
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
			
			CreateEditorViewModelForNamespace(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for ExternalType.Namespace
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForNamespace(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Namespace";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ExternalType/Namespace.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ExternalType/Namespace.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.ExternalType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DomainEnumeration
    /// </summary>
	public partial class PropertyGridDomainEnumerationViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridDomainTypeViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainEnumeration for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDomainEnumerationViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainEnumeration element) : base(viewModelStore, element)
		{
			// subscribe to DomainEnumeration.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainEnumeration.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Domain Enumeration)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Domain Enumeration)";
			else
				this.ElementFullName = "Domain Enumeration";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainEnumeration.Description");
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
			
			CreateEditorViewModelForIsFlags(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for DomainEnumeration.IsFlags
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForIsFlags(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.BooleanEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.BooleanEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "IsFlags";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainEnumeration/IsFlags.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainEnumeration/IsFlags.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainEnumeration.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for NamedDomainElement
    /// </summary>
	public abstract partial class PropertyGridNamedDomainElementViewModel : Tum.PDE.ModelingDSL.ViewModel.PropertyGrid.PropertyGridBaseElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type NamedDomainElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridNamedDomainElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.NamedDomainElement element) : base(viewModelStore, element)
		{
			// subscribe to NamedDomainElement.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.NamedDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Named Domain Element)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Named Domain Element)";
			else
				this.ElementFullName = "Named Domain Element";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.NamedDomainElement.Description");
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
			CreateEditorViewModelForDescription(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for NamedDomainElement.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.NamedDomainElement/Name.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.NamedDomainElement/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for NamedDomainElement.Description
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDescription(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Description";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.NamedDomainElement/Description.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.NamedDomainElement/Description.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.NamedDomainElement.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DomainElementReferencesDEType
    /// </summary>
	public partial class PropertyGridDomainElementReferencesDETypeViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainElementReferencesDEType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDomainElementReferencesDETypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Domain Element References DEType"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainElementReferencesDEType.Description");
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
    /// Property grid view model for DomainPropertyReferencesDomainType
    /// </summary>
	public partial class PropertyGridDomainPropertyReferencesDomainTypeViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainPropertyReferencesDomainType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDomainPropertyReferencesDomainTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Domain Property References Domain Type"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.Description");
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
    /// Property grid view model for BaseElementSourceReferencesBaseElementTarget
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class PropertyGridBaseElementSourceReferencesBaseElementTargetViewModelBase : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type BaseElementSourceReferencesBaseElementTarget for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected PropertyGridBaseElementSourceReferencesBaseElementTargetViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Base Element Source References Base Element Target"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.Description");
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
			
			CreateEditorViewModelForRelationshipTypeRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for BaseElementSourceReferencesBaseElementTarget.RelationshipType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForRelationshipTypeRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.BaseElementSourceReferencesBaseElementTargetDomainRoleId);
			
			editor.PropertyName = "RelationshipType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/BaseElementSourceReferencesBaseElementTarget.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/DRType.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
				
		#endregion		
	}

	/// <summary>
    /// Property grid view model for BaseElementSourceReferencesBaseElementTarget
	///
	///	This is the double generated class for easier customization.
	/// </summary>
	public abstract partial class PropertyGridBaseElementSourceReferencesBaseElementTargetViewModel : PropertyGridBaseElementSourceReferencesBaseElementTargetViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type BaseElementSourceReferencesBaseElementTarget for which this property grid view model is created.</param>		
		public PropertyGridBaseElementSourceReferencesBaseElementTargetViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget element) : base(viewModelStore, element)
		{
			
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DRTypeReferencesDETypeTarget
    /// </summary>
	public partial class PropertyGridDRTypeReferencesDETypeTargetViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DRTypeReferencesDETypeTarget for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDRTypeReferencesDETypeTargetViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "DRType References DEType Target"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.Description");
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
    /// Property grid view model for DRTypeReferencesDETypeSource
    /// </summary>
	public partial class PropertyGridDRTypeReferencesDETypeSourceViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DRTypeReferencesDETypeSource for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDRTypeReferencesDETypeSourceViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "DRType References DEType Source"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.Description");
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
    /// Property grid view model for DRTypeReferencesBaseElementSourceReferencesBaseElementTarget
    /// </summary>
	public partial class PropertyGridDRTypeReferencesBaseElementSourceReferencesBaseElementTargetViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DRTypeReferencesBaseElementSourceReferencesBaseElementTarget for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDRTypeReferencesBaseElementSourceReferencesBaseElementTargetViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "DRType References Base Element Source References Base Element Target"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.Description");
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
    /// Property grid view model for DomainProperty
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class PropertyGridDomainPropertyViewModelBase : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainProperty for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected PropertyGridDomainPropertyViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element) : base(viewModelStore, element)
		{
			// subscribe to DomainProperty.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainProperty.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Domain Property)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Domain Property)";
			else
				this.ElementFullName = "Domain Property";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainProperty.Description");
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
			CreateEditorViewModelForValue(collection);
			CreateEditorViewModelForDomainTypeRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for DomainProperty.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainProperty/Name.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainProperty/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DomainProperty.Value
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForValue(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Value";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainProperty/Value.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainProperty/Value.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for DomainProperty.DomainType
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDomainTypeRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId),
					   				global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId);
			
			editor.PropertyName = "DomainType";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainProperty.PropertyDisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainType.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainProperty.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}

	/// <summary>
    /// Property grid view model for DomainProperty
	///
	///	This is the double generated class for easier customization.
	/// </summary>
	public partial class PropertyGridDomainPropertyViewModel : PropertyGridDomainPropertyViewModelBase
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainProperty for which this property grid view model is created.</param>		
		public PropertyGridDomainPropertyViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainProperty element) : base(viewModelStore, element)
		{
			
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for DomainType
    /// </summary>
	public abstract partial class PropertyGridDomainTypeViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type DomainType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridDomainTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.DomainType element) : base(viewModelStore, element)
		{
			// subscribe to DomainType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Domain Type)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Domain Type)";
			else
				this.ElementFullName = "Domain Type";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainType.Description");
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
		/// Create property grid editor view model for DomainType.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainType/Name.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.DomainType/Name.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for BaseDomainElementType
    /// </summary>
	public abstract partial class PropertyGridBaseDomainElementTypeViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type BaseDomainElementType for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridBaseDomainElementTypeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseDomainElementType element) : base(viewModelStore, element)
		{
			// subscribe to BaseDomainElementType.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.BaseDomainElementType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Base Domain Element Type)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Base Domain Element Type)";
			else
				this.ElementFullName = "Base Domain Element Type";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseDomainElementType.Description");
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
		/// Create property grid editor view model for BaseDomainElementType.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseDomainElementType/Name.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseDomainElementType/Name.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.BaseDomainElementType.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for BaseElement
    /// </summary>
	public abstract partial class PropertyGridBaseElementViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type BaseElement for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridBaseElementViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.BaseElement element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Base Element"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.BaseElement.Description");
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
    /// Property grid view model for EnumerationLiteral
    /// </summary>
	public partial class PropertyGridEnumerationLiteralViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type EnumerationLiteral for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridEnumerationLiteralViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.EnumerationLiteral element) : base(viewModelStore, element)
		{
			// subscribe to EnumerationLiteral.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EnumerationLiteral.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Enumeration Literal)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Enumeration Literal)";
			else
				this.ElementFullName = "Enumeration Literal";
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
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EnumerationLiteral.Description");
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
			CreateEditorViewModelForValue(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for EnumerationLiteral.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EnumerationLiteral/Name.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EnumerationLiteral/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for EnumerationLiteral.Value
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForValue(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Value";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EnumerationLiteral/Value.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.EnumerationLiteral/Value.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EnumerationLiteral.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ConversionModelInfo
    /// </summary>
	public partial class PropertyGridConversionModelInfoViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ConversionModelInfo for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridConversionModelInfoViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.PDE.ModelingDSL.ConversionModelInfo element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Conversion Model Info"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ConversionModelInfo.Description");
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
			
			CreateEditorViewModelForHasModelChanged(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for ConversionModelInfo.HasModelChanged
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForHasModelChanged(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.BooleanEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.BooleanEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "HasModelChanged";
			editor.PropertyDisplayName = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ConversionModelInfo/HasModelChanged.DisplayName");
			editor.PropertyDescription = PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ConversionModelInfo/HasModelChanged.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
				
		#endregion		
	}
}
