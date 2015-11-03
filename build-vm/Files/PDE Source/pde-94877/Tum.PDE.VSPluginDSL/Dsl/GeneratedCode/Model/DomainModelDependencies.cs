 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VSPluginDSLDependenciesRetrivalOptions : VSPluginDSLDependenciesRetrivalOptionsBase
	{
		#region Singleton Instance
		private static VSPluginDSLDependenciesRetrivalOptions dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLDependenciesRetrivalOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new VSPluginDSLDependenciesRetrivalOptions();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		private VSPluginDSLDependenciesRetrivalOptions() : base()
		{
			Initialize();
		}
        #endregion
	}
	
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLDependenciesRetrivalOptionsBase : DslEditorModeling::DependenciesRetrivalOptions
	{
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLDependenciesRetrivalOptionsBase()
		{			
		}
	
        /// <summary>
        /// Initialization.
        /// </summary>
        protected virtual void Initialize()
        {
        }
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VSPluginDSLDependenciesItemsProvider : VSPluginDSLDependenciesItemsProviderBase
	{
		#region Singleton Instance
		private static VSPluginDSLDependenciesItemsProvider dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLDependenciesItemsProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new VSPluginDSLDependenciesItemsProvider();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLDependenciesItemsProvider() : base()
		{
		}
        #endregion
	
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLDependenciesItemsProviderBase : DslEditorModeling::DependenciesItemsProvider
	{		
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLDependenciesItemsProviderBase()
		{
	
		}
		#endregion
		
		/// <summary>
        /// Gets the retrival options.
        /// </summary>
        public override DslEditorModeling::DependenciesRetrivalOptions RetrivalOptions
        {
            get
			{
				return VSPluginDSLDependenciesRetrivalOptions.Instance;
			}
        }
	}
}

