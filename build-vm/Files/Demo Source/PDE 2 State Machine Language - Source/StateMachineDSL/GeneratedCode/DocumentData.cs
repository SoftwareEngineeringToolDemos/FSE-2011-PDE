 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageDocumentData : StateMachineLanguageDocumentDataBase
	{
		#region Constructor
		/// <summary>
		/// Constructs a new StateMachineLanguageDocumentData.
		/// </summary>	
		public StateMachineLanguageDocumentData() : base()
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
					modelDatainstance = new StateMachineLanguageDocumentData();
				}
				
				return modelDatainstance;
            }
        }
        #endregion*/
	}
	
	/// <summary>
	/// Class which represents a StateMachineLanguage document in memory.
	/// </summary>
	public abstract partial class StateMachineLanguageDocumentDataBase : DslEditorModeling::ModelData
	{
		/// <summary>
		/// Singleton instance.
        /// </summary>
        protected static DslEditorModeling::ModelData modelDatainstance;
		
		#region Constructor
		/// <summary>
		/// Constructs a new StateMachineLanguageDocumentDataBase.
		/// </summary>	
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected StateMachineLanguageDocumentDataBase() : base(true, false)
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
			if( StateMachineLanguageDomainModelExtensionServices.Instance == null )
				throw new System.ArgumentNullException("ExtensionServices are not initialized");
				
			if( StateMachineLanguageValidationController.Instance == null )
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
			StateMachineLanguageDiagramsDSLSerializationHelper.Instance.InitializeSerialization(store);
			
			// initialize serializers directory
			StateMachineLanguageSerializationHelper.InitializeSerializers(store.SerializerDirectory, store.DomainDataDirectory);
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
                return StateMachineLanguageDomainModel.SingletonResourceManager;
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
				typeof(StateMachineLanguageDomainModel),
			};
        }
		
		/// <summary>
        /// Resets the current document data.
        /// </summary>
        public override void Reset()
        {
			base.Reset();
			
			StateMachineLanguageDomainModelIdProvider.Instance.Reset();
        }
		
		/// <summary>
        /// Gets the services, which belong to the current domain model.
        /// </summary>
        /// <returns>DomainModel services.</returns>
        public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return StateMachineLanguageDomainModelServices.Instance;
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
