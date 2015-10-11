 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VModellXTDocumentData : VModellXTDocumentDataBase
	{
		#region Constructor
		/// <summary>
		/// Constructs a new VModellXTDocumentData.
		/// </summary>	
		public VModellXTDocumentData() : base()
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
					modelDatainstance = new VModellXTDocumentData();
				}
				
				return modelDatainstance;
            }
        }
        #endregion*/
	}
	
	/// <summary>
	/// Class which represents a VModellXT document in memory.
	/// </summary>
	public abstract partial class VModellXTDocumentDataBase : DslEditorModeling::ModelData
	{
		/// <summary>
		/// Singleton instance.
        /// </summary>
        protected static DslEditorModeling::ModelData modelDatainstance;
		
		#region Constructor
		/// <summary>
		/// Constructs a new VModellXTDocumentDataBase.
		/// </summary>	
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected VModellXTDocumentDataBase() : base(true, false)
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
			if( VModellXTDomainModelExtensionServices.Instance == null )
				throw new System.ArgumentNullException("ExtensionServices are not initialized");
				
			if( VModellXTValidationController.Instance == null )
				throw new System.ArgumentNullException("ValidationController is not initialized");
		}

		/// <summary>
        /// Initializes the model contexts collection.
        /// </summary>
        protected override void InitializeModelContexts()
		{
			
			// VModellXT
			ModelContextVModellXT = new VModellXTModelContext(this);
			this.availableModelContexts.Add(ModelContextVModellXT);
			this.currentModelContext = ModelContextVModellXT;
			
			// VModellXTMustertexte
			ModelContextVModellXTMustertexte = new VModellXTMustertexteModelContext(this);
			this.availableModelContexts.Add(ModelContextVModellXTMustertexte);
			
			// Variantenkonfig
			ModelContextVariantenkonfig = new VariantenkonfigModelContext(this);
			this.availableModelContexts.Add(ModelContextVariantenkonfig);
		}	
		
        /// <summary>
        /// Serialization initialization.
        /// </summary>
        protected override void InitializeSerialization(DslEditorModeling.DomainModelStore store)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);
			
			// initiliaze serialization for the domains model
			VModellXTDiagramsDSLSerializationHelper.Instance.InitializeSerialization(store);
			
			// initialize serializers directory
			VModellXTSerializationHelper.InitializeSerializers(store.SerializerDirectory, store.DomainDataDirectory);
		}
		#endregion

		/// <summary>
        /// Gets the model context VModellXT.
        /// </summary>
		public VModellXTModelContext ModelContextVModellXT
		{
			get;
			private set;
		}

		/// <summary>
        /// Gets the model context VModellXTMustertexte.
        /// </summary>
		public VModellXTMustertexteModelContext ModelContextVModellXTMustertexte
		{
			get;
			private set;
		}

		/// <summary>
        /// Gets the model context Variantenkonfig.
        /// </summary>
		public VariantenkonfigModelContext ModelContextVariantenkonfig
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
                return VModellXTDomainModel.SingletonResourceManager;
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
				typeof(VModellXTDomainModel),
				typeof(global::Tum.VModellXT.Basis.VModellXTBasisDomainModel),
				typeof(global::Tum.VModellXT.Statik.VModellXTStatikDomainModel),
				typeof(global::Tum.VModellXT.Dynamik.VModellXTDynamikDomainModel),
				typeof(global::Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModel),
				typeof(global::Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModel),
				typeof(global::Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModel),
			};
        }
		
		/// <summary>
        /// Resets the current document data.
        /// </summary>
        public override void Reset()
        {
			base.Reset();
			
			VModellXTDomainModelIdProvider.Instance.Reset();
        }
		
		/// <summary>
        /// Gets the services, which belong to the current domain model.
        /// </summary>
        /// <returns>DomainModel services.</returns>
        public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return VModellXTDomainModelServices.Instance;
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
