 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLDocumentData : PDEModelingDSLDocumentDataBase
	{
		#region Constructor
		/// <summary>
		/// Constructs a new PDEModelingDSLDocumentData.
		/// </summary>	
		public PDEModelingDSLDocumentData() : base()
		{
			if( PDEModelingDSLDomainModelExtensionServices.Instance == null )
				throw new System.ArgumentNullException("ExtensionServices are not initialized");
		}
		#endregion
	}
	
	/// <summary>
	/// Class which represents a PDEModelingDSL document in memory.
	/// </summary>
	public abstract partial class PDEModelingDSLDocumentDataBase : DslEditorModeling::ModelData
	{
		#region Constructor
		/// <summary>
		/// Constructs a new PDEModelingDSLDocumentDataBase.
		/// </summary>	
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected PDEModelingDSLDocumentDataBase() : base()
		{
			// Call the partial method to allow any required serialization setup to be done.
			//this.InitializeSerialization(this.Store);
			
			// initiliaze serialization for the domains model
			//PDEModelingDSLDiagramsDSLSerializationHelper.Instance.InitializeSerialization(this.Store);
		
			/*
			System.Threading.Tasks.Task<bool> task1 = System.Threading.Tasks.Task.Factory.StartNew<bool>(() =>    // Begin task
            {
				// Call the partial method to allow any required serialization setup to be done.
				this.InitializeSerialization(this.Store);
			
				// initiliaze serialization for the domains model
				PDEModelingDSLDiagramsDSLSerializationHelper.Instance.InitializeSerialization(this.Store);

                return true;
            });
			*/
			
			//initialize and verify providers
			/*
			System.Threading.Tasks.Task<bool> task2 = System.Threading.Tasks.Task.Factory.StartNew<bool>(() =>    // Begin task
            {
				#region PDEModelingDSL
				if (Tum.PDE.ModelingDSL.PDEModelingDSLElementNameProvider.Instance == null)
        	        throw new System.ArgumentNullException("Tum.PDE.ModelingDSL.PDEModelingDSLElementNameProvider");
				if (Tum.PDE.ModelingDSL.PDEModelingDSLElementTypeProvider.Instance == null)
        	        throw new System.ArgumentNullException("Tum.PDE.ModelingDSL.PDEModelingDSLElementTypeProvider");
				if (Tum.PDE.ModelingDSL.PDEModelingDSLElementParentProvider.Instance == null)
        	        throw new System.ArgumentNullException("Tum.PDE.ModelingDSL.PDEModelingDSLElementParentProvider");
				if (Tum.PDE.ModelingDSL.PDEModelingDSLElementChildrenProvider.Instance == null)
        	        throw new System.ArgumentNullException("Tum.PDE.ModelingDSL.PDEModelingDSLElementChildrenProvider");				
				if (Tum.PDE.ModelingDSL.PDEModelingDSLDependenciesItemsProvider.Instance == null)
        	        throw new System.ArgumentNullException("Tum.PDE.ModelingDSL.PDEModelingDSLDependenciesItemsProvider");								
				#endregion
			

                return true;
            });
			
			System.Threading.Tasks.Task<bool> task3 = System.Threading.Tasks.Task.Factory.StartNew<bool>(() =>    // Begin task
            {
				PDEModelingDSLSerializationHelper.InitializeSerializers(this.Store.SerializerDirectory, this.Store.DomainDataDirectory);
				
				 return true;
            });*/
			
			//PDEModelingDSLSerializationHelper.InitializeSerializers(this.Store.SerializerDirectory, this.Store.DomainDataDirectory);
			
			//InitializeModelContexts();
			
			//bool bDone = task1.Result && task2.Result && task3.Result;
            //if (!bDone)
            //    throw new System.InvalidOperationException("Task parallelism failed!");			
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
			PDEModelingDSLDiagramsDSLSerializationHelper.Instance.InitializeSerialization(store);
			
			// initialize serializers directory
			PDEModelingDSLSerializationHelper.InitializeSerializers(store.SerializerDirectory, store.DomainDataDirectory);
		}		
		
        /// <summary>
        /// Initializes services.
        /// </summary>
        protected override void InitializeServices()
		{			
			if( PDEModelingDSLDomainModelExtensionServices.Instance == null )
				throw new System.ArgumentNullException("ExtensionServices are not initialized");
				
			if( PDEModelingDSLValidationController.Instance == null )
				throw new System.ArgumentNullException("ValidationController is not initialized");
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
                return PDEModelingDSLDomainModel.SingletonResourceManager;
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
				typeof(PDEModelingDSLDomainModel),
			};
        }
		
		/// <summary>
        /// Resets the current document data.
        /// </summary>
        public override void Reset()
        {
			base.Reset();
			
			PDEModelingDSLDomainModelIdProvider.Instance.Reset();
        }
		
		/// <summary>
        /// Gets the services, which belong to the current domain model.
        /// </summary>
        /// <returns>DomainModel services.</returns>
        public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return PDEModelingDSLDomainModelServices.Instance;
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
