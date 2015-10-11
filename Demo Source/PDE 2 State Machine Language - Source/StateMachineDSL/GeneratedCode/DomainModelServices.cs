 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Domain model services specific to StateMachineLanguage.
    /// </summary>
	public partial class StateMachineLanguageDomainModelServices : DslEditorModeling::DomainModelServices
	{
		#region Singleton Instance
		private static StateMachineLanguageDomainModelServices dmainModelServices = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageDomainModelServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dmainModelServices == null )
				{
					dmainModelServices = new StateMachineLanguageDomainModelServices();
				}
				
				return dmainModelServices;
            }
        }
		
		private StateMachineLanguageDomainModelServices()
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
				return StateMachineLanguageDomainModelExtensionServices.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementIdProvider ElementIdProvider
		{
			get
			{
				return StateMachineLanguageDomainModelIdProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementNameProvider ElementNameProvider 
		{ 
			get
			{
				return StateMachineLanguageElementNameProvider.Instance;
			}
		}

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementTypeProvider ElementTypeProvider 
		{ 
			get
			{
				return StateMachineLanguageElementTypeProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element shape provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementShapeProvider ShapeProvider
		{ 
			get
			{
				return StateMachineLanguageElementShapeProvider.Instance;
			}
		}

		/// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementParentProvider ElementParentProvider
		{ 
			get
			{
				return StateMachineLanguageElementParentProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementChildrenProvider ElementChildrenProvider
		{ 
			get
			{
				return StateMachineLanguageElementChildrenProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IDependenciesItemsProvider DependenciesItemsProvider
		{ 
			get
			{
				return StateMachineLanguageDependenciesItemsProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the model data options.
        /// </summary>
        public override DslEditorModeling::IModelDataOptions ModelDataOptions 
		{ 
			get
			{
				return StateMachineLanguageModelDataOptions.Instance;
			} 
		}
		
		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementSearchProcessor SearchProcessor 
		{ 
			get
			{
				return StateMachineLanguageSearchProcessor.Instance;
			}
		}

		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::ModelValidationController ValidationController 
		{ 
			get
			{
				return StateMachineLanguageValidationController.Instance;
			}
		}	
		#endregion
	}

	/// <summary>
    /// Domain model extension services specific to StateMachineLanguage.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class StateMachineLanguageDomainModelExtensionServices : StateMachineLanguageDomainModelExtensionServicesBase
	{	
		#region Singleton Instance
		private static StateMachineLanguageDomainModelExtensionServices dmainModelServices = null;
        private static object domainModelServicesLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageDomainModelExtensionServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
			 	lock (domainModelServicesLock)
                {
                    if (dmainModelServices == null)
                        dmainModelServices = new StateMachineLanguageDomainModelExtensionServices();
                }
				
				return dmainModelServices;
            }
        }
		
		private StateMachineLanguageDomainModelExtensionServices() : base()
		{
		}
		
	
        #endregion	
	}
	
	/// <summary>
    /// Domain model extension services specific to StateMachineLanguage.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class StateMachineLanguageDomainModelExtensionServicesBase : DslEditorModeling::DomainModelExtensionServices
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected StateMachineLanguageDomainModelExtensionServicesBase() : base(Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance)
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
			this.SetTopMostService(Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance);
		}	

		#endregion
	}

	/// <summary>
	/// Class which provides names and display names for domain classes as well as methods to create names for new domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class StateMachineLanguageElementNameProvider : DslEditorModeling::ModelElementNameProvider
	{
		#region Singleton Instance
		private static StateMachineLanguageElementNameProvider elementNameProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageElementNameProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementNameProvider == null )
				{
					elementNameProvider = new StateMachineLanguageElementNameProvider();
				}
				
				return elementNameProvider;
            }
        }
		
		private StateMachineLanguageElementNameProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides type names and type display names for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class StateMachineLanguageElementTypeProvider : DslEditorModeling::ModelElementTypeProvider
    {
		#region Singleton Instance
		private static StateMachineLanguageElementTypeProvider elementTypeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageElementTypeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementTypeProvider == null )
				{
					elementTypeProvider = new StateMachineLanguageElementTypeProvider();
				}
				
				return elementTypeProvider;
            }
        }
		
		private StateMachineLanguageElementTypeProvider() : base()
		{
		}
        #endregion
	}

	/// <summary>
	/// Class which retrieves parent elements for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class StateMachineLanguageElementParentProvider : DslEditorModeling::ModelElementParentProvider
    {
		#region Singleton Instance
		private static StateMachineLanguageElementParentProvider elementParentProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageElementParentProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementParentProvider == null )
				{
					elementParentProvider = new StateMachineLanguageElementParentProvider();
				}
				
				return elementParentProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private StateMachineLanguageElementParentProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves children elements domain classes.
    /// </summary>
	public partial class StateMachineLanguageElementChildrenProvider : DslEditorModeling::ModelElementChildrenProvider
    {
		#region Singleton Instance
		private static StateMachineLanguageElementChildrenProvider elementChildrenProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageElementChildrenProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementChildrenProvider == null )
				{
					elementChildrenProvider = new StateMachineLanguageElementChildrenProvider();
				}
				
				return elementChildrenProvider;
            }
        }
		
		private StateMachineLanguageElementChildrenProvider() : base()
		{
		}
        #endregion
	}	
	
	/// <summary>
	/// Class which retrieves parent shape for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class StateMachineLanguageElementShapeProvider : StateMachineLanguageElementShapeProviderBase
    {
		#region Singleton Instance
		private static StateMachineLanguageElementShapeProvider elementShapeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageElementShapeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementShapeProvider == null )
				{
					elementShapeProvider = new StateMachineLanguageElementShapeProvider();
				}
				
				return elementShapeProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private StateMachineLanguageElementShapeProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves shape elements for domain classes.
	///
	/// This is the base abstract class.
    /// </summary>
	public partial class StateMachineLanguageElementShapeProviderBase : DslEditorModeling::ModelElementShapeProvider
    {	
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected StateMachineLanguageElementShapeProviderBase()
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
				createShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(3);
				createShapeMap.Add(global::Tum.StateMachineDSL.StateShape.DomainClassId, 0);
				createShapeMap.Add(global::Tum.StateMachineDSL.StartStateShape.DomainClassId, 1);
				createShapeMap.Add(global::Tum.StateMachineDSL.EndStateShape.DomainClassId, 2);
			}
			int index;
			if (!createShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.StateMachineDSL.StateShape(modelElement.Store, assignments); break;
				case 1: nodeShape = new global::Tum.StateMachineDSL.StartStateShape(modelElement.Store, assignments); break;
				case 2: nodeShape = new global::Tum.StateMachineDSL.EndStateShape(modelElement.Store, assignments); break;
				
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
				createRSShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(1);
				createRSShapeMap.Add(global::Tum.StateMachineDSL.TransitionShape.DomainClassId, 0);
			}
			int index;
			if (!createRSShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.StateMachineDSL.TransitionShape(modelElement.Store, assignments); break;
				
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
	public partial class StateMachineLanguageModelDataOptions : StateMachineLanguageModelDataOptionsBase
	{
		#region Singleton Instance
		private static StateMachineLanguageModelDataOptions modelDataOptions = null;
		
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
					modelDataOptions = new StateMachineLanguageModelDataOptions();
				}
				
				return modelDataOptions;
            }
        }
		
		private StateMachineLanguageModelDataOptions() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// This class is used to store common options. 
    /// </summary>
	public abstract partial class StateMachineLanguageModelDataOptionsBase : DslEditorModeling::IModelDataOptions
	{
		#region Constructor
		/// <summary>
		/// Constructs a new StateMachineLanguageModelDataOptionsBase.
		/// </summary>	
		protected StateMachineLanguageModelDataOptionsBase()
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
                return "StateMachineLanguage";
            }
        }
		
		/// <summary>
        /// Gets the name of the company providing this editor.
        /// </summary>
        public virtual string Company
		{
	        get
    	    {
        	    return "TUM";
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