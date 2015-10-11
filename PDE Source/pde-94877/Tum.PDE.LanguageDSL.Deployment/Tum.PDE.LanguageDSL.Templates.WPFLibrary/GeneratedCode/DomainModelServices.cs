 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT
{
	/// <summary>
    /// Domain model services specific to VModellXT.
    /// </summary>
	public partial class VModellXTDomainModelServices : DslEditorModeling::DomainModelServices
	{
		#region Singleton Instance
		private static VModellXTDomainModelServices dmainModelServices = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTDomainModelServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dmainModelServices == null )
				{
					dmainModelServices = new VModellXTDomainModelServices();
				}
				
				return dmainModelServices;
            }
        }
		
		private VModellXTDomainModelServices()
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
				return VModellXTDomainModelExtensionServices.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element id provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementIdProvider ElementIdProvider
		{
			get
			{
				return VModellXTDomainModelIdProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element name provider for domain model elements.
        /// </summary>
        public override DslEditorModeling::IModelElementNameProvider ElementNameProvider 
		{ 
			get
			{
				return VModellXTElementNameProvider.Instance;
			}
		}

        /// <summary>
        /// Gets the element type provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementTypeProvider ElementTypeProvider 
		{ 
			get
			{
				return VModellXTElementTypeProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element shape provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementShapeProvider ShapeProvider
		{ 
			get
			{
				return VModellXTElementShapeProvider.Instance;
			}
		}

		/// <summary>
        /// Gets the element parent provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementParentProvider ElementParentProvider
		{ 
			get
			{
				return VModellXTElementParentProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the element children provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementChildrenProvider ElementChildrenProvider
		{ 
			get
			{
				return VModellXTElementChildrenProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the dependency items provider for domain model elments.
        /// </summary>
        public override DslEditorModeling::IDependenciesItemsProvider DependenciesItemsProvider
		{ 
			get
			{
				return VModellXTDependenciesItemsProvider.Instance;
			}
		}
		
		/// <summary>
        /// Gets the model data options.
        /// </summary>
        public override DslEditorModeling::IModelDataOptions ModelDataOptions 
		{ 
			get
			{
				return VModellXTModelDataOptions.Instance;
			} 
		}
		
		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::IModelElementSearchProcessor SearchProcessor 
		{ 
			get
			{
				return VModellXTSearchProcessor.Instance;
			}
		}

		/// <summary>
        /// Gets the search processor for domain model elments.
        /// </summary>
        public override DslEditorModeling::ModelValidationController ValidationController 
		{ 
			get
			{
				return VModellXTValidationController.Instance;
			}
		}	
		#endregion
	}

	/// <summary>
    /// Domain model extension services specific to VModellXT.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VModellXTDomainModelExtensionServices : VModellXTDomainModelExtensionServicesBase
	{	
		#region Singleton Instance
		private static VModellXTDomainModelExtensionServices dmainModelServices = null;
        private static object domainModelServicesLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTDomainModelExtensionServices Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
			 	lock (domainModelServicesLock)
                {
                    if (dmainModelServices == null)
                        dmainModelServices = new VModellXTDomainModelExtensionServices();
                }
				
				return dmainModelServices;
            }
        }
		
		private VModellXTDomainModelExtensionServices() : base()
		{
		}
		
	
        #endregion	
	}
	
	/// <summary>
    /// Domain model extension services specific to VModellXT.
	///
	/// This is the base abstract class.
    /// </summary>
	public abstract class VModellXTDomainModelExtensionServicesBase : DslEditorModeling::DomainModelExtensionServices
	{
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected VModellXTDomainModelExtensionServicesBase() : base(Tum.VModellXT.VModellXTDomainModelServices.Instance)
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
			this.AddExternModelService(Tum.VModellXT.Basis.VModellXTBasisDomainModelServices.Instance);
			Tum.VModellXT.Basis.VModellXTBasisDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);
			this.AddExternModelService(Tum.VModellXT.Statik.VModellXTStatikDomainModelServices.Instance);
			Tum.VModellXT.Statik.VModellXTStatikDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);
			this.AddExternModelService(Tum.VModellXT.Dynamik.VModellXTDynamikDomainModelServices.Instance);
			Tum.VModellXT.Dynamik.VModellXTDynamikDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);
			this.AddExternModelService(Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModelServices.Instance);
			Tum.VModellXT.Anpassung.VModellXTAnpassungDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);
			this.AddExternModelService(Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModelServices.Instance);
			Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);
			this.AddExternModelService(Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModelServices.Instance);
			Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenDomainModelExtensionServices.Instance.AddExternModelService(VModellXTDomainModelServices.Instance);

			// set top most service
			this.SetTopMostService(Tum.VModellXT.VModellXTDomainModelServices.Instance);
		}	

		#endregion
	}

	/// <summary>
	/// Class which provides names and display names for domain classes as well as methods to create names for new domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VModellXTElementNameProvider : DslEditorModeling::ModelElementNameProvider
	{
		#region Singleton Instance
		private static VModellXTElementNameProvider elementNameProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTElementNameProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementNameProvider == null )
				{
					elementNameProvider = new VModellXTElementNameProvider();
				}
				
				return elementNameProvider;
            }
        }
		
		private VModellXTElementNameProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides type names and type display names for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VModellXTElementTypeProvider : DslEditorModeling::ModelElementTypeProvider
    {
		#region Singleton Instance
		private static VModellXTElementTypeProvider elementTypeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTElementTypeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementTypeProvider == null )
				{
					elementTypeProvider = new VModellXTElementTypeProvider();
				}
				
				return elementTypeProvider;
            }
        }
		
		private VModellXTElementTypeProvider() : base()
		{
		}
        #endregion
	}

	/// <summary>
	/// Class which retrieves parent elements for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VModellXTElementParentProvider : DslEditorModeling::ModelElementParentProvider
    {
		#region Singleton Instance
		private static VModellXTElementParentProvider elementParentProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTElementParentProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementParentProvider == null )
				{
					elementParentProvider = new VModellXTElementParentProvider();
				}
				
				return elementParentProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private VModellXTElementParentProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves children elements domain classes.
    /// </summary>
	public partial class VModellXTElementChildrenProvider : DslEditorModeling::ModelElementChildrenProvider
    {
		#region Singleton Instance
		private static VModellXTElementChildrenProvider elementChildrenProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTElementChildrenProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementChildrenProvider == null )
				{
					elementChildrenProvider = new VModellXTElementChildrenProvider();
				}
				
				return elementChildrenProvider;
            }
        }
		
		private VModellXTElementChildrenProvider() : base()
		{
		}
        #endregion
	}	
	
	/// <summary>
	/// Class which retrieves parent shape for domain classes.
	///
	/// Double derived to allow for easier customization.
    /// </summary>
	public partial class VModellXTElementShapeProvider : VModellXTElementShapeProviderBase
    {
		#region Singleton Instance
		private static VModellXTElementShapeProvider elementShapeProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTElementShapeProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementShapeProvider == null )
				{
					elementShapeProvider = new VModellXTElementShapeProvider();
				}
				
				return elementShapeProvider;
            }
        }
	
		/// <summary>
        /// Constructor.
        /// </summary>
		private VModellXTElementShapeProvider() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which retrieves shape elements for domain classes.
	///
	/// This is the base abstract class.
    /// </summary>
	public partial class VModellXTElementShapeProviderBase : DslEditorModeling::ModelElementShapeProvider
    {	
		#region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected VModellXTElementShapeProviderBase()
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
				createShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(15);
				createShapeMap.Add(global::Tum.VModellXT.RolleDependencyShape.DomainClassId, 0);
				createShapeMap.Add(global::Tum.VModellXT.DisziplinDependencyShape.DomainClassId, 1);
				createShapeMap.Add(global::Tum.VModellXT.ErzAbhDependencyShape.DomainClassId, 2);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufbausteinShape.DomainClassId, 3);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.StartpunktShape.DomainClassId, 4);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.EndepunktShape.DomainClassId, 5);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufentscheidungspunktShape.DomainClassId, 6);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufbausteinpunktShape.DomainClassId, 7);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.SplitShape.DomainClassId, 8);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.SplitEingangShape.DomainClassId, 9);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.SplitAusgangShape.DomainClassId, 10);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.JoinShape.DomainClassId, 11);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.JoinEingangShape.DomainClassId, 12);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.JoinAusgangShape.DomainClassId, 13);
				createShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufbausteinspezifikationShape.DomainClassId, 14);
			}
			int index;
			if (!createShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.VModellXT.RolleDependencyShape(modelElement.Store, assignments); break;
				case 1: nodeShape = new global::Tum.VModellXT.DisziplinDependencyShape(modelElement.Store, assignments); break;
				case 2: nodeShape = new global::Tum.VModellXT.ErzAbhDependencyShape(modelElement.Store, assignments); break;
				case 3: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufbausteinShape(modelElement.Store, assignments); break;
				case 4: nodeShape = new global::Tum.VModellXT.Dynamik.StartpunktShape(modelElement.Store, assignments); break;
				case 5: nodeShape = new global::Tum.VModellXT.Dynamik.EndepunktShape(modelElement.Store, assignments); break;
				case 6: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufentscheidungspunktShape(modelElement.Store, assignments); break;
				case 7: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufbausteinpunktShape(modelElement.Store, assignments); break;
				case 8: nodeShape = new global::Tum.VModellXT.Dynamik.SplitShape(modelElement.Store, assignments); break;
				case 9: nodeShape = new global::Tum.VModellXT.Dynamik.SplitEingangShape(modelElement.Store, assignments); break;
				case 10: nodeShape = new global::Tum.VModellXT.Dynamik.SplitAusgangShape(modelElement.Store, assignments); break;
				case 11: nodeShape = new global::Tum.VModellXT.Dynamik.JoinShape(modelElement.Store, assignments); break;
				case 12: nodeShape = new global::Tum.VModellXT.Dynamik.JoinEingangShape(modelElement.Store, assignments); break;
				case 13: nodeShape = new global::Tum.VModellXT.Dynamik.JoinAusgangShape(modelElement.Store, assignments); break;
				case 14: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufbausteinspezifikationShape(modelElement.Store, assignments); break;
				
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
				createRSShapeMap = new global::System.Collections.Generic.Dictionary<global::System.Guid, int>(3);
				createRSShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufbausteinpunktRAblaufbausteinspezShape.DomainClassId, 0);
				createRSShapeMap.Add(global::Tum.VModellXT.Dynamik.AblaufbausteinRAblaufbausteinspezShape.DomainClassId, 1);
				createRSShapeMap.Add(global::Tum.VModellXT.Dynamik.UebergangShape.DomainClassId, 2);
			}
			int index;
			if (!createRSShapeMap.TryGetValue(shapeTypeId, out index))
				throw new global::System.ArgumentException("Unrecognized shape type " + shapeTypeId.ToString());
			switch (index)
			{
				case 0: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufbausteinpunktRAblaufbausteinspezShape(modelElement.Store, assignments); break;
				case 1: nodeShape = new global::Tum.VModellXT.Dynamik.AblaufbausteinRAblaufbausteinspezShape(modelElement.Store, assignments); break;
				case 2: nodeShape = new global::Tum.VModellXT.Dynamik.UebergangShape(modelElement.Store, assignments); break;
				
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
	public partial class VModellXTModelDataOptions : VModellXTModelDataOptionsBase
	{
		#region Singleton Instance
		private static VModellXTModelDataOptions modelDataOptions = null;
		
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
					modelDataOptions = new VModellXTModelDataOptions();
				}
				
				return modelDataOptions;
            }
        }
		
		private VModellXTModelDataOptions() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// This class is used to store common options. 
    /// </summary>
	public abstract partial class VModellXTModelDataOptionsBase : DslEditorModeling::IModelDataOptions
	{
		#region Constructor
		/// <summary>
		/// Constructs a new VModellXTModelDataOptionsBase.
		/// </summary>	
		protected VModellXTModelDataOptionsBase()
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
                return "VModellXT";
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
			
                return "1.3";
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