 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.TestLanguage
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class TestLanguageDocumentData : TestLanguageDocumentDataBase
	{
		#region Constructor
		/// <summary>
		/// Constructs a new TestLanguageDocumentData.
		/// </summary>	
		public TestLanguageDocumentData() : base()
		{

		}
		#endregion
		
		/*
		#region Singleton Instance
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static DslEditorModeling::ModelData Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( modelDatainstance == null )
				{
					modelDatainstance = new TestLanguageDocumentData();
				}
				
				return modelDatainstance;
            }
        }
        #endregion*/
	}
	
	/// <summary>
	/// Class which represents a TestLanguage document in memory.
	/// </summary>
	public abstract partial class TestLanguageDocumentDataBase : DslEditorModeling::ModelData
	{
		/// <summary>
		/// Singleton instance.
        /// </summary>
        protected static DslEditorModeling::ModelData modelDatainstance;
		
		#region Constructor
		/// <summary>
		/// Constructs a new TestLanguageDocumentDataBase.
		/// </summary>	
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected TestLanguageDocumentDataBase() : base(true, false)
		{
		}
		#endregion

		#region Initialization
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);

        /// <summary>
        /// Initializes services.
        /// </summary>
        protected override void InitializeServices()
		{			
			if( TestLanguageDomainModelExtensionServices.Instance == null )
				throw new System.ArgumentNullException("ExtensionServices are not initialized");
				
			if( TestLanguageValidationController.Instance == null )
				throw new System.ArgumentNullException("ValidationController is not initialized");
		}

		/// <summary>
        /// Initializes the model contexts collection.
        /// </summary>
        protected override void InitializeModelContexts()
		{
			
			// DefaultContext
			ModelContextDefaultContext = new DefaultContextModelContext(this);
			this.availableModelContexts.Add(ModelContextDefaultContext);
			this.currentModelContext = ModelContextDefaultContext;
		}	
		
        /// <summary>
        /// Serialization initialization.
        /// </summary>
        protected override void InitializeSerializationForStore(DslEditorModeling.DomainModelStore store)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);
			
			// initiliaze serialization for the domains model
			TestLanguageDiagramsDSLSerializationHelper.Instance.InitializeSerialization(store);
			
			// initialize serializers directory
			TestLanguageSerializationHelper.InitializeSerializers(store.SerializerDirectory, store.DomainDataDirectory);
		}
		#endregion

		/// <summary>
        /// Gets the model context DefaultContext.
        /// </summary>
		public DefaultContextModelContext ModelContextDefaultContext
		{
			get;
			private set;
		}

		#region Properties
		/// <summary>
        /// Gets the DomainModel's ResourceManager.
        /// </summary>
        public override global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return TestLanguageDomainModel.SingletonResourceManager;
            }
        }
		#endregion
		
		#region Methods
		/// <summary>
        /// Returns a collection of domain models to load into the store.
        /// </summary>
        protected override System.Type[] GetDomainModels()
        {
			return new System.Type[]{
				typeof(DslEditorDiagrams::DiagramsDSLDomainModel),
				typeof(DslEditorModeling::DomainModelDslEditorModeling),
				typeof(TestLanguageDomainModel),
			};
        }
		
		/// <summary>
        /// Resets the current document data.
        /// </summary>
        public override void Reset()
        {
			base.Reset();
			
			TestLanguageDomainModelIdProvider.Instance.Reset();
        }
		
		/// <summary>
        /// Gets the services, which belong to the current domain model.
        /// </summary>
        /// <returns>DomainModel services.</returns>
        public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return TestLanguageDomainModelServices.Instance;
		}

        /// <summary>
        /// Gets the services, which are specific to the current domain model that the given element belongs to.
        /// </summary>
		/// <param name="element">Element.</param>
        /// <returns>DomainModel services</returns>
        public override DslEditorModeling::IDomainModelServices GetDomainModelServices(DslEditorModeling::IDomainModelOwnable element)
		{
			return element.GetDomainModelServices();	
		}
		
        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                modelDatainstance = null;
            }
			
			base.Dispose(disposing);
        }		
		#endregion
		
		#region Partition Support
		/// <summary>
		/// Get the Partition where model data will be loaded into.
		/// Base implementation returns the default partition of the store.
		/// </summary>
		public override DslModeling::Partition GetModelPartition()
		{
			if (this.Store != null)
			{
				return this.Store.DefaultPartition;
			}
			
			return null;
		}
		#endregion
	}
}
