 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLDependenciesRetrivalOptions : PDEModelingDSLDependenciesRetrivalOptionsBase
	{
		#region Singleton Instance
		private static PDEModelingDSLDependenciesRetrivalOptions dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLDependenciesRetrivalOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new PDEModelingDSLDependenciesRetrivalOptions();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		private PDEModelingDSLDependenciesRetrivalOptions() : base()
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
	public abstract class PDEModelingDSLDependenciesRetrivalOptionsBase : DslEditorModeling::DependenciesRetrivalOptions
	{
		/// <summary>
        /// Constructor.
        /// </summary>
		protected PDEModelingDSLDependenciesRetrivalOptionsBase()
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
	public partial class PDEModelingDSLDependenciesItemsProvider : PDEModelingDSLDependenciesItemsProviderBase
	{
		#region Singleton Instance
		private static PDEModelingDSLDependenciesItemsProvider dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLDependenciesItemsProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new PDEModelingDSLDependenciesItemsProvider();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		protected PDEModelingDSLDependenciesItemsProvider() : base()
		{
		}
        #endregion
	
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLDependenciesItemsProviderBase : DslEditorModeling::DependenciesItemsProvider
	{		
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected PDEModelingDSLDependenciesItemsProviderBase()
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
				return PDEModelingDSLDependenciesRetrivalOptions.Instance;
			}
        }
	}
}

