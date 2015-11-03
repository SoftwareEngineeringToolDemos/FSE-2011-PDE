 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Domain model services specific to PDEModelingDSL.
    /// </summary>
	public partial class PDEModelingDSLDomainModelServices : DslEditorModeling::DomainModelServices
	{
		#region Singleton Instance
		private static PDEModelingDSLDomainModelServices dmainModelServices = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLDomainModelServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dmainModelServices == null )
				{
					dmainModelServices = new PDEModelingDSLDomainModelServices();
				}
				
				return dmainModelServices;
            }
        }
		
		private PDEModelingDSLDomainModelServices()
		{
		}
        #endregion
		
		#region Properties
        /// <summary>
        /// Gets the extension services.
        /// </summary>
		public override DslEditorModeling::IDomainModelExtensionServices ExtensionServices
		{
			get
			{
				return PDEModelingDSLDomainModelExtensionServices.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementIdProvider ElementIdProvider
		{
			get
			{
				return PDEModelingDSLDomainModelIdProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementNameProvider ElementNameProvider 
		{ 
			get
			{
				return PDEModelingDSLElementNameProvider.Instance;
			}
		}

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementTypeProvider ElementTypeProvider 
		{ 
			get
			{
				return PDEModelingDSLElementTypeProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element shape provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementShapeProvider ShapeProvider
		{ 
			get
			{
				return PDEModelingDSLElementShapeProvider.Instance;
			}
		}

		/// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementParentProvider ElementParentProvider
		{ 
			get
			{
				return PDEModelingDSLElementParentProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementChildrenProvider ElementChildrenProvider
		{ 
			get
			{
				return PDEModelingDSLElementChildrenProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IDependenciesItemsProvider DependenciesItemsProvider
		{ 
			get
			{
				return PDEModelingDSLDependenciesItemsProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the model data options.
        /// </summary>
        public override DslEditorModeling::IModelDataOptions ModelDataOptions 
		{ 
			get
			{
				return PDEModelingDSLModelDataOptions.Instance;
			} 
		}
		
		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementSearchProcessor SearchProcessor 
		{ 
			get
			{
				return PDEModelingDSLSearchProcessor.Instance;
			}
		}

		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::ModelValidationController ValidationController 
		{ 
			get
			{
				return PDEModelingDSLValidationController.Instance;
			}
		}	
		#endregion
	}

	/// <summary>
    /// Domain model extension services specific to PDEModelingDSL.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class PDEModelingDSLDomainModelExtensionServices : PDEModelingDSLDomainModelExtensionServicesBase
	{	
		#region Singleton Instance
		private static PDEModelingDSLDomainModelExtensionServices dmainModelServices = null;
        private static object domainModelServicesLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLDomainModelExtensionServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
			 	lock (domainModelServicesLock)
                {
                    if (dmainModelServices == null)
                        dmainModelServices = new PDEModelingDSLDomainModelExtensionServices();
                }
				
				return dmainModelServices;
            }
        }
		
		private PDEModelingDSLDomainModelExtensionServices() : base()
		{
		}
		
	
        #endregion	
	}
	
	/// <summary>
    /// Domain model extension services specific to PDEModelingDSL.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class PDEModelingDSLDomainModelExtensionServicesBase : DslEditorModeling::DomainModelExtensionServices
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected PDEModelingDSLDomainModelExtensionServicesBase() : base(Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance)
		{			
			Intialize();
		}
		#endregion
		
		#region Methods
        private bool isInitialized = false;
        /// <summary>
        /// Initialized known extern services.
        /// </summary>
        public override void Intialize()
		{
			if( isInitialized )
				return;
				
			isInitialized = true;

			// set top most service
			this.SetTopMostService(Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance);
		}	

		#endregion
	}

	/// <summary>
	/// Class which provides names and display names for domain classes as well as methods to create names for new domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class PDEModelingDSLElementNameProvider : DslEditorModeling::ModelElementNameProvider
	{
		#region Singleton Instance
		private static PDEModelingDSLElementNameProvider elementNameProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLElementNameProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementNameProvider == null )
				{
					elementNameProvider = new PDEModelingDSLElementNameProvider();
				}
				
				return elementNameProvider;
            }
        }
		
		private PDEModelingDSLElementNameProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides type names and type display names for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class PDEModelingDSLElementTypeProvider : DslEditorModeling::ModelElementTypeProvider
    {
		#region Singleton Instance
		private static PDEModelingDSLElementTypeProvider elementTypeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLElementTypeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementTypeProvider == null )
				{
					elementTypeProvider = new PDEModelingDSLElementTypeProvider();
				}
				
				return elementTypeProvider;
            }
        }
		
		private PDEModelingDSLElementTypeProvider() : base()
		{
		}
        #endregion
	}

	/// <summary>
	/// Class which retrieves parent elements for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class PDEModelingDSLElementParentProvider : DslEditorModeling::ModelElementParentProvider
    {
		#region Singleton Instance
		private static PDEModelingDSLElementParentProvider elementParentProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLElementParentProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementParentProvider == null )
				{
					elementParentProvider = new PDEModelingDSLElementParentProvider();
				}
				
				return elementParentProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private PDEModelingDSLElementParentProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves children elements domain classes.
    /// </summary>
	public partial class PDEModelingDSLElementChildrenProvider : DslEditorModeling::ModelElementChildrenProvider
    {
		#region Singleton Instance
		private static PDEModelingDSLElementChildrenProvider elementChildrenProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLElementChildrenProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementChildrenProvider == null )
				{
					elementChildrenProvider = new PDEModelingDSLElementChildrenProvider();
				}
				
				return elementChildrenProvider;
            }
        }
		
		private PDEModelingDSLElementChildrenProvider() : base()
		{
		}
        #endregion
	}	
	
	/// <summary>
	/// Class which retrieves parent shape for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class PDEModelingDSLElementShapeProvider : PDEModelingDSLElementShapeProviderBase
    {
		#region Singleton Instance
		private static PDEModelingDSLElementShapeProvider elementShapeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLElementShapeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementShapeProvider == null )
				{
					elementShapeProvider = new PDEModelingDSLElementShapeProvider();
				}
				
				return elementShapeProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private PDEModelingDSLElementShapeProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves shape elements for domain classes.
	///
	/// This is the base abstract class.
    /// </summary>
	public partial class PDEModelingDSLElementShapeProviderBase : DslEditorModeling::ModelElementShapeProvider
    {	
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected PDEModelingDSLElementShapeProviderBase()
		{
			
		}
		#endregion	

		#region Methods
		
		private static global::System.Collections.Generic.Dictionary<global::System.Guid, int> createShapeMap;
		
        /// <summary>
        /// Create a shape of the given type for the given element type.
        /// </summary>
        /// <param name="modelElement">Model element.</param>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        public override DslModeling.ModelElement CreateShapeForElement(System.Guid shapeTypeId, DslModeling::ModelElement modelElement, params DslModeling::PropertyAssignment[] assignments)
        {
			DslEditorDiagrams::NodeShape nodeShape = null;	
		
			if( createShapeMap == null )
			{
				createShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(1);
				createShapeMap.Add(global::Tum.PDE.ModelingDSL.DomainElementShape.DomainClassId, 0);
			}
			int index;
			if (!createShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.PDE.ModelingDSL.DomainElementShape(modelElement.Store, assignments); break;
				
			}

			if( nodeShape == null )
				throw new System.InvalidOperationException("Couldn't create shape of type " + shapeTypeId.ToString() + " for model element " + modelElement.ToString());
			
			nodeShape.Element = modelElement;
			
			return nodeShape;
		
        }
		
		
		private static global::System.Collections.Generic.Dictionary<global::System.Guid, int> createRSShapeMap;
		
		

		/// <summary>
        /// Create a shape of the given link shape type.
        /// </summary>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="modelElement">Model element.</param>
        /// <param name="sourceShape">Source shape.</param>
        /// <param name="targetShape">Target shape.</param>
		/// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        public override DslModeling::ModelElement CreateShapeForElementLink(System.Guid shapeTypeId, DslModeling::ModelElement modelElement, DslModeling::ModelElement sourceShape, DslModeling::ModelElement targetShape, params DslModeling::PropertyAssignment[] assignments)
		{
			if( !(sourceShape is DslEditorDiagrams::NodeShape) ||
				!(targetShape is DslEditorDiagrams::NodeShape) )
				return null;
				
			DslEditorDiagrams::LinkShape nodeShape = CreateShapeForElementLink(shapeTypeId, modelElement, assignments) as DslEditorDiagrams::LinkShape;
			if( nodeShape == null )
				return nodeShape;

			nodeShape.SourceAnchor = new DslEditorDiagrams::SourceAnchor(modelElement.Store); 
			nodeShape.SourceAnchor.FromShape = sourceShape as DslEditorDiagrams::NodeShape;
			nodeShape.TargetAnchor = new DslEditorDiagrams::TargetAnchor(modelElement.Store); 
        	nodeShape.TargetAnchor.ToShape = targetShape as DslEditorDiagrams::NodeShape;

			return nodeShape;
		}

        /// <summary>
        /// Create a shape of the given link shape type.
        /// </summary>
        /// <param name="shapeTypeId">Shape type id.</param>
        /// <param name="modelElement">Model element.</param>
		/// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        public override DslModeling::ModelElement CreateShapeForElementLink(System.Guid shapeTypeId, DslModeling::ModelElement modelElement, params DslModeling::PropertyAssignment[] assignments)
		{
			
			DslEditorDiagrams::LinkShape nodeShape = null;	
		
			if( createRSShapeMap == null )
			{
				createRSShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(2);
				createRSShapeMap.Add(global::Tum.PDE.ModelingDSL.ReferenceShape.DomainClassId, 0);
				createRSShapeMap.Add(global::Tum.PDE.ModelingDSL.EmbeddingShape.DomainClassId, 1);
			}
			int index;
			if (!createRSShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.PDE.ModelingDSL.ReferenceShape(modelElement.Store, assignments); break;
				case 1: nodeShape = new global::Tum.PDE.ModelingDSL.EmbeddingShape(modelElement.Store, assignments); break;
				
			}

			if( nodeShape == null )
				throw new System.InvalidOperationException("Couldn't create shape of type " + shapeTypeId.ToString() + " for element link " + modelElement.ToString());
			
			nodeShape.Element = modelElement;
								
			return nodeShape;
		
        }
		
		/// <summary>
        /// Create a dependency shape for the given element type.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <param name="modelElement">Model element.</param>
        /// <param name="assignments">Properties for the shape.</param>
        /// <returns>Shape if one could be created. Null otherwise.</returns>
        public override DslModeling::ModelElement CreateDependenciesShapeForElement(System.Guid modelElementTypeId, DslModeling::ModelElement modelElement, params DslModeling::PropertyAssignment[] assignments)
		{
			System.Guid id;
            if((modelElement as DslEditorModeling::DomainModelElement).Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DslEditorDiagrams::DiagramDomainDataDirectory>().ClassShapesDependenciesMapping.TryGetValue(modelElementTypeId, out id))
                return CreateShapeForElement(id, modelElement, assignments);

            return null;
		}
		#endregion
	}
	
	/// <summary>
	/// This class is used to store common options. Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLModelDataOptions : PDEModelingDSLModelDataOptionsBase
	{
		#region Singleton Instance
		private static PDEModelingDSLModelDataOptions modelDataOptions = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static DslEditorModeling::IModelDataOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( modelDataOptions == null )
				{
					modelDataOptions = new PDEModelingDSLModelDataOptions();
				}
				
				return modelDataOptions;
            }
        }
		
		private PDEModelingDSLModelDataOptions() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// This class is used to store common options. 
    /// </summary>
	public abstract partial class PDEModelingDSLModelDataOptionsBase : DslEditorModeling::IModelDataOptions
	{
		#region Constructor
		/// <summary>
		/// Constructs a new PDEModelingDSLModelDataOptionsBase.
		/// </summary>	
		protected PDEModelingDSLModelDataOptionsBase()
		{
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets the name of the current editor.
        /// </summary>
        public virtual string AppName
        {
            get
            {
                return "PDEModelingDSL";
            }
        }
		
		/// <summary>
        /// Gets the name of the company providing this editor.
        /// </summary>
        public virtual string Company
		{
	        get
    	    {
        	    return "Tum";
        	}	
		}
		
		/// <summary>
        /// Gets the version of the editor.
        /// </summary>
        public virtual string Version
        {
            get
            {
			
                return "";
            }
        }
		
		private string appDataDirectory = null;
		/// <summary>
        /// Gets the application data directory for the current editor.
        /// </summary>
		public virtual string AppDataDirectory
		{
			get
			{
				if( appDataDirectory == null )
				{
					appDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) 
										+ System.IO.Path.DirectorySeparatorChar 
										+ Company
										+ System.IO.Path.DirectorySeparatorChar
										+  AppName;
					
					if( !System.String.IsNullOrEmpty(Version) && !System.String.IsNullOrWhiteSpace(Version) )
						appDataDirectory += " " + Version;
					
	                if (!System.IO.Directory.Exists(appDataDirectory))
    	                System.IO.Directory.CreateDirectory(appDataDirectory);
				}
                return appDataDirectory;
			}
		}
		#endregion
	}	
}