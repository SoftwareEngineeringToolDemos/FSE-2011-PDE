 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelPGrid = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.TestLanguage.ViewModel.PropertyGrid
{
	/// <summary>
    /// Property grid view model for Test
    /// </summary>
	public partial class PropertyGridTestViewModel : DslEditorViewModelPGrid::PropertyGridViewModel
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element of type Test for which this property grid view model is created.</param>	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public PropertyGridTestViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, global::Tum.TestLanguage.Test element) : base(viewModelStore, element)
		{
			// subscribe to Test.Name changes
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.TestLanguage.Test.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			
			// set name property value
			this.elementFullNameStorage = element.Name + " (Test)";
		}
		#endregion
		
		#region Properties
		private void NamePropertyChanged(DslModeling::ElementPropertyChangedEventArgs args)
		{
			if( args.NewValue != null )
				this.ElementFullName = args.NewValue.ToString() + " (Test)";
			else
				this.ElementFullName = "Test";
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
				return TestLanguageDomainModel.SingletonResourceManager.GetString("Tum.TestLanguage.Test.Description");
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
			CreateEditorViewModelForNumber(collection);

			return collection;
		}
		#endregion

		#region Editor Creation
		/// <summary>
		/// Create property grid editor view model for Test.Name
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForName(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.StringEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Name";
			editor.PropertyDisplayName = TestLanguageDomainModel.SingletonResourceManager.GetString("Tum.TestLanguage.Test/Name.DisplayName");
			editor.PropertyDescription = TestLanguageDomainModel.SingletonResourceManager.GetString("Tum.TestLanguage.Test/Name.Description");
			editor.PropertyCategory = "";
			editor.IsPropertyRequired = true;
			editor.IsPropertyReadOnly = false;		
				
			collection.Add(editor);
		}
		
		/// <summary>
		/// Create property grid editor view model for Test.Number
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		protected virtual void CreateEditorViewModelForNumber(System.Collections.Generic.List<DslEditorViewModelPGrid::PropertyGridEditorViewModel> collection)
		{
			Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.DoubleEditorViewModel editor = new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid.DoubleEditorViewModel(this.ViewModelStore);
			
            editor.PropertyName = "Number";
			editor.PropertyDisplayName = TestLanguageDomainModel.SingletonResourceManager.GetString("Tum.TestLanguage.Test/Number.DisplayName");
			editor.PropertyDescription = TestLanguageDomainModel.SingletonResourceManager.GetString("Tum.TestLanguage.Test/Number.Description");
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
			this.EventManager.GetEvent<DslEditorViewModelEvents::ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.TestLanguage.Test.NameDomainPropertyId), this.Element.Id, new System.Action<DslModeling::ElementPropertyChangedEventArgs>(NamePropertyChanged));
			base.OnDispose();
		}
		#endregion
	}
}
