 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// Domain model services specific to VSPluginDSL.
    /// </summary>
	public partial class VSPluginDSLDomainModelServices : DslEditorModeling::DomainModelServices
	{
		#region Singleton Instance
		private static VSPluginDSLDomainModelServices dmainModelServices = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLDomainModelServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dmainModelServices == null )
				{
					dmainModelServices = new VSPluginDSLDomainModelServices();
				}
				
				return dmainModelServices;
            }
        }
		
		private VSPluginDSLDomainModelServices()
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
				return VSPluginDSLDomainModelExtensionServices.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementIdProvider ElementIdProvider
		{
			get
			{
				return VSPluginDSLDomainModelIdProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementNameProvider ElementNameProvider 
		{ 
			get
			{
				return VSPluginDSLElementNameProvider.Instance;
			}
		}

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementTypeProvider ElementTypeProvider 
		{ 
			get
			{
				return VSPluginDSLElementTypeProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element shape provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementShapeProvider ShapeProvider
		{ 
			get
			{
				return VSPluginDSLElementShapeProvider.Instance;
			}
		}

		/// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementParentProvider ElementParentProvider
		{ 
			get
			{
				return VSPluginDSLElementParentProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementChildrenProvider ElementChildrenProvider
		{ 
			get
			{
				return VSPluginDSLElementChildrenProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IDependenciesItemsProvider DependenciesItemsProvider
		{ 
			get
			{
				return VSPluginDSLDependenciesItemsProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the model data options.
        /// </summary>
        public override DslEditorModeling::IModelDataOptions ModelDataOptions 
		{ 
			get
			{
				return VSPluginDSLModelDataOptions.Instance;
			} 
		}
		
		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementSearchProcessor SearchProcessor 
		{ 
			get
			{
				return VSPluginDSLSearchProcessor.Instance;
			}
		}

		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::ModelValidationController ValidationController 
		{ 
			get
			{
				return VSPluginDSLValidationController.Instance;
			}
		}	
		#endregion
	}

	/// <summary>
    /// Domain model extension services specific to VSPluginDSL.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VSPluginDSLDomainModelExtensionServices : VSPluginDSLDomainModelExtensionServicesBase
	{	
		#region Singleton Instance
		private static VSPluginDSLDomainModelExtensionServices dmainModelServices = null;
        private static object domainModelServicesLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLDomainModelExtensionServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
			 	lock (domainModelServicesLock)
                {
                    if (dmainModelServices == null)
                        dmainModelServices = new VSPluginDSLDomainModelExtensionServices();
                }
				
				return dmainModelServices;
            }
        }
		
		private VSPluginDSLDomainModelExtensionServices() : base()
		{
		}
		
	
        #endregion	
	}
	
	/// <summary>
    /// Domain model extension services specific to VSPluginDSL.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class VSPluginDSLDomainModelExtensionServicesBase : DslEditorModeling::DomainModelExtensionServices
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected VSPluginDSLDomainModelExtensionServicesBase() : base(Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelServices.Instance)
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
			this.SetTopMostService(Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelServices.Instance);
		}	

		#endregion
	}

	/// <summary>
	/// Class which provides names and display names for domain classes as well as methods to create names for new domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VSPluginDSLElementNameProvider : DslEditorModeling::ModelElementNameProvider
	{
		#region Singleton Instance
		private static VSPluginDSLElementNameProvider elementNameProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLElementNameProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementNameProvider == null )
				{
					elementNameProvider = new VSPluginDSLElementNameProvider();
				}
				
				return elementNameProvider;
            }
        }
		
		private VSPluginDSLElementNameProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides type names and type display names for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VSPluginDSLElementTypeProvider : DslEditorModeling::ModelElementTypeProvider
    {
		#region Singleton Instance
		private static VSPluginDSLElementTypeProvider elementTypeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLElementTypeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementTypeProvider == null )
				{
					elementTypeProvider = new VSPluginDSLElementTypeProvider();
				}
				
				return elementTypeProvider;
            }
        }
		
		private VSPluginDSLElementTypeProvider() : base()
		{
		}
        #endregion
	}

	/// <summary>
	/// Class which retrieves parent elements for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VSPluginDSLElementParentProvider : DslEditorModeling::ModelElementParentProvider
    {
		#region Singleton Instance
		private static VSPluginDSLElementParentProvider elementParentProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLElementParentProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementParentProvider == null )
				{
					elementParentProvider = new VSPluginDSLElementParentProvider();
				}
				
				return elementParentProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private VSPluginDSLElementParentProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves children elements domain classes.
    /// </summary>
	public partial class VSPluginDSLElementChildrenProvider : DslEditorModeling::ModelElementChildrenProvider
    {
		#region Singleton Instance
		private static VSPluginDSLElementChildrenProvider elementChildrenProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLElementChildrenProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementChildrenProvider == null )
				{
					elementChildrenProvider = new VSPluginDSLElementChildrenProvider();
				}
				
				return elementChildrenProvider;
            }
        }
		
		private VSPluginDSLElementChildrenProvider() : base()
		{
		}
        #endregion
	}	
	
	/// <summary>
	/// Class which retrieves parent shape for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VSPluginDSLElementShapeProvider : VSPluginDSLElementShapeProviderBase
    {
		#region Singleton Instance
		private static VSPluginDSLElementShapeProvider elementShapeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLElementShapeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementShapeProvider == null )
				{
					elementShapeProvider = new VSPluginDSLElementShapeProvider();
				}
				
				return elementShapeProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private VSPluginDSLElementShapeProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves shape elements for domain classes.
	///
	/// This is the base abstract class.
    /// </summary>
	public partial class VSPluginDSLElementShapeProviderBase : DslEditorModeling::ModelElementShapeProvider
    {	
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected VSPluginDSLElementShapeProviderBase()
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
				createShapeMap.Add(global::Tum.PDE.VSPluginDSL.DomainClass2Shape.DomainClassId, 0);
			}
			int index;
			if (!createShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.PDE.VSPluginDSL.DomainClass2Shape(modelElement.Store, assignments); break;
				
			}

			if( nodeShape == null )
				throw new System.InvalidOperationException("Couldn't create shape of type " + shapeTypeId.ToString() + " for model element " + modelElement.ToString());
			
			nodeShape.Element = modelElement;
			
			return nodeShape;
		
        }
		
		

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
			
			return null;
		
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
	public partial class VSPluginDSLModelDataOptions : VSPluginDSLModelDataOptionsBase
	{
		#region Singleton Instance
		private static VSPluginDSLModelDataOptions modelDataOptions = null;
		
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
					modelDataOptions = new VSPluginDSLModelDataOptions();
				}
				
				return modelDataOptions;
            }
        }
		
		private VSPluginDSLModelDataOptions() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// This class is used to store common options. 
    /// </summary>
	public abstract partial class VSPluginDSLModelDataOptionsBase : DslEditorModeling::IModelDataOptions
	{
		#region Constructor
		/// <summary>
		/// Constructs a new VSPluginDSLModelDataOptionsBase.
		/// </summary>	
		protected VSPluginDSLModelDataOptionsBase()
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
                return "VSPluginDSL";
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