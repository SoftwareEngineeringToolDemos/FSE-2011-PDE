 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.VModellXT.ViewModel.PropertyGrid
{
	/// <summary>
    /// Property grid view model for VModellvariante
    /// </summary>
	public partial class PropertyGridVModellvarianteViewModel : Tum.VModellXT.Basis.ViewModel.PropertyGrid.PropertyGridBaseElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type VModellvariante for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridVModellvarianteViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.VModellvariante element) : base(viewModelStore, element)
		{
			// subscribe to VModellvariante.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.VModellvariante.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (V-Modellvariante)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (V-Modellvariante)";
			else
				this.ElementFullName = "V-Modellvariante";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante.Description");
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
			CreateEditorViewModelForVersion(collection);
			CreateEditorViewModelForVersionIntern(collection);
			CreateEditorViewModelForCopyrightKurz(collection);
			CreateEditorViewModelForCopyrightLang(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for VModellvariante.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for VModellvariante.Version
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVersion(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Version";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/Version.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/Version.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for VModellvariante.VersionIntern
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVersionIntern(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "VersionIntern";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/VersionIntern.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/VersionIntern.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for VModellvariante.CopyrightKurz
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForCopyrightKurz(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "CopyrightKurz";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/CopyrightKurz.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/CopyrightKurz.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for VModellvariante.CopyrightLang
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForCopyrightLang(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel.HtmlEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel.HtmlEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "CopyrightLang";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/CopyrightLang.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModellvariante/CopyrightLang.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.VModellvariante.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for VModell
    /// </summary>
	public partial class PropertyGridVModellViewModel : Tum.VModellXT.Basis.ViewModel.PropertyGrid.PropertyGridBaseElementViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type VModell for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridVModellViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.VModell element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "VModell"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModell.Description");
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
			
			CreateEditorViewModelForMaster(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for VModell.Master
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForMaster(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Master";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModell/Master.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VModell/Master.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
				
		#endregion		
	}
	/// <summary>
    /// Property grid view model for ReferenzmodellReferencesVModellvariante
    /// </summary>
	public partial class PropertyGridReferenzmodellReferencesVModellvarianteViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ReferenzmodellReferencesVModellvariante for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridReferenzmodellReferencesVModellvarianteViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Referenzmodell References VModellvariante"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ReferenzmodellReferencesVModellvariante.Description");
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
    /// Property grid view model for Variante
    /// </summary>
	public partial class PropertyGridVarianteViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Variante for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridVarianteViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Variante element) : base(viewModelStore, element)
		{
			// subscribe to Variante.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Variante.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Variante)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Variante)";
			else
				this.ElementFullName = "Variante";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante.Description");
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
			CreateEditorViewModelForVerzeichnis(collection);
			CreateEditorViewModelForDateiname(collection);
			CreateEditorViewModelForReferenzvarianteRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Variante.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Variante.Verzeichnis
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVerzeichnis(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Verzeichnis";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Verzeichnis.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Verzeichnis.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Variante.Dateiname
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForDateiname(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Dateiname";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Dateiname.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Variante/Dateiname.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Variante.Referenzvariante
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForReferenzvarianteRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DomainClassId),
					   				global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId);
			
			editor.PropertyName = "Referenzvariante";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteSource.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteTarget.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Variante.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for ThemenmusterReferencesThema
    /// </summary>
	public partial class PropertyGridThemenmusterReferencesThemaViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ThemenmusterReferencesThema for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridThemenmusterReferencesThemaViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.ThemenmusterReferencesThema element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Themenmuster References Thema"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesThema.Description");
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
    /// Property grid view model for VarianteSourceReferencesVarianteTarget
    /// </summary>
	public partial class PropertyGridVarianteSourceReferencesVarianteTargetViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type VarianteSourceReferencesVarianteTarget for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridVarianteSourceReferencesVarianteTargetViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Variante Source References Variante Target"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.VarianteSourceReferencesVarianteTarget.Description");
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
    /// Property grid view model for ThemenmusterReferencesUnterthema
    /// </summary>
	public partial class PropertyGridThemenmusterReferencesUnterthemaViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type ThemenmusterReferencesUnterthema for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridThemenmusterReferencesUnterthemaViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.ThemenmusterReferencesUnterthema element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Themenmuster References Unterthema"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesUnterthema.Description");
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
    /// Property grid view model for Zusatzthema
    /// </summary>
	public partial class PropertyGridZusatzthemaViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Zusatzthema for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridZusatzthemaViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Zusatzthema element) : base(viewModelStore, element)
		{
			// subscribe to Zusatzthema.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Zusatzthema.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Zusatzthema)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Zusatzthema)";
			else
				this.ElementFullName = "Zusatzthema";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Zusatzthema.Description");
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
			CreateEditorViewModelForStandardauswahl(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Zusatzthema.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Zusatzthema/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Zusatzthema/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Zusatzthema.Standardauswahl
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForStandardauswahl(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.VModellXT.TypStandard), false);
			
            editor.PropertyName = "Standardauswahl";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Zusatzthema/Standardauswahl.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Zusatzthema/Standardauswahl.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Zusatzthema.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Musterbibliothek
    /// </summary>
	public partial class PropertyGridMusterbibliothekViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Musterbibliothek for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridMusterbibliothekViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Musterbibliothek element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Musterbibliothek"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Musterbibliothek.Description");
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
			
			CreateEditorViewModelForVModellRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Musterbibliothek.VModell
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVModellRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			MusterbibliothekHasVModellVModellRMRViewModel editor = new MusterbibliothekHasVModellVModellRMRViewModel(this.ViewModelStore);
			
			editor.PropertyName = "VModell";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.MusterbibliothekHasVModell/Musterbibliothek.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.MusterbibliothekHasVModell/VModell.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;
		
			collection.Add(editor);
		}
				
		#endregion		
	}
	/// <summary>
    /// Property grid view model for Referenzmodell
    /// </summary>
	public partial class PropertyGridReferenzmodellViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Referenzmodell for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridReferenzmodellViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Referenzmodell element) : base(viewModelStore, element)
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or set the full name of the element, which properties are to be added.
        /// </summary>
        public override string ElementFullName 
		{ 
			get{ return "Referenzmodell"; }
			set{}
		}	


        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public override string ElementDescription 
		{ 
			get
			{
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Referenzmodell.Description");
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
			
			CreateEditorViewModelForVModellRole(collection);
			CreateEditorViewModelForVModellvarianteRefRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Referenzmodell.VModell
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVModellRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			ReferenzmodellHasVModellVModellRMRViewModel editor = new ReferenzmodellHasVModellVModellRMRViewModel(this.ViewModelStore);
			
			editor.PropertyName = "VModell";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ReferenzmodellHasVModell/Referenzmodell.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ReferenzmodellHasVModell/VModell.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for Referenzmodell.VModellvarianteRef
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForVModellvarianteRefRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.UnaryRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DomainClassId),
					   				global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId);
			
			editor.PropertyName = "VModellvarianteRef";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/Referenzmodell.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/VModellvariante.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
				
		#endregion		
	}
	/// <summary>
    /// Property grid view model for Mustergruppe
    /// </summary>
	public partial class PropertyGridMustergruppeViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Mustergruppe for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridMustergruppeViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Mustergruppe element) : base(viewModelStore, element)
		{
			// subscribe to Mustergruppe.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustergruppe.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Mustergruppe)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Mustergruppe)";
			else
				this.ElementFullName = "Mustergruppe";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustergruppe.Description");
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
		/// Create property grid editor view model for Mustergruppe.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustergruppe/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustergruppe/Name.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustergruppe.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Mustertext
    /// </summary>
	public partial class PropertyGridMustertextViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Mustertext for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridMustertextViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Mustertext element) : base(viewModelStore, element)
		{
			// subscribe to Mustertext.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustertext.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Mustertext)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Mustertext)";
			else
				this.ElementFullName = "Mustertext";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext.Description");
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
			CreateEditorViewModelForStandardauswahl(collection);
			CreateEditorViewModelForText(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Mustertext.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Mustertext.Standardauswahl
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForStandardauswahl(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.EnumerationEditorViewModel(this.ViewModelStore , typeof(global::Tum.VModellXT.TypStandard), false);
			
            editor.PropertyName = "Standardauswahl";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Standardauswahl.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Standardauswahl.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Mustertext.Text
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForText(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel.HtmlEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel.HtmlEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Text";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Text.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Mustertext/Text.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustertext.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
	/// <summary>
    /// Property grid view model for Themenmuster
    /// </summary>
	public partial class PropertyGridThemenmusterViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Themenmuster for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridThemenmusterViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.VModellXT.Themenmuster element) : base(viewModelStore, element)
		{
			// subscribe to Themenmuster.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Themenmuster.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Themenmuster)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Themenmuster)";
			else
				this.ElementFullName = "Themenmuster";
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
				return VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Themenmuster.Description");
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
			CreateEditorViewModelForThemaRole(collection);
			CreateEditorViewModelForUnterthemaRole(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Themenmuster.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Themenmuster/Name.DisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.Themenmuster/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Themenmuster.Thema
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForThemaRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.VModellXT.ThemenmusterReferencesThema.DomainClassId),
					   				global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId);
			
			editor.PropertyName = "Thema";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesThema/Themenmuster.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesThema/Thema.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = false;
			editor.IsPropertyReadOnly = false;			
		
			collection.Add(editor);
		}
		/// <summary>
		/// Create property grid editor view model for Themenmuster.Unterthema
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForUnterthemaRole(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.MultipleRoleEditorViewModel(this.ViewModelStore, 
									this.Store.DomainDataDirectory.GetDomainRelationship(global::Tum.VModellXT.ThemenmusterReferencesUnterthema.DomainClassId),
					   				global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId);
			
			editor.PropertyName = "Unterthema";
			editor.PropertyDisplayName = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesUnterthema/Themenmuster.PropertyDisplayName");
			editor.PropertyDescription = VModellXTDomainModel.SingletonResourceManager.GetString("Tum.VModellXT.ThemenmusterReferencesUnterthema/Unterthema.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Themenmuster.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
}
