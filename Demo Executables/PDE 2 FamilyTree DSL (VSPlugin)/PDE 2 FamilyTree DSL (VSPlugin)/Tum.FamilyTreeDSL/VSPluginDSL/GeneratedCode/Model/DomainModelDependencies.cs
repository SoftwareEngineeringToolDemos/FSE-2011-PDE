 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class FamilyTreeDSLDependenciesRetrivalOptions : FamilyTreeDSLDependenciesRetrivalOptionsBase
	{
		#region Singleton Instance
		private static FamilyTreeDSLDependenciesRetrivalOptions dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLDependenciesRetrivalOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new FamilyTreeDSLDependenciesRetrivalOptions();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		private FamilyTreeDSLDependenciesRetrivalOptions() : base()
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
	public abstract class FamilyTreeDSLDependenciesRetrivalOptionsBase : DslEditorModeling::DependenciesRetrivalOptions
	{
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLDependenciesRetrivalOptionsBase()
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
	public partial class FamilyTreeDSLDependenciesItemsProvider : FamilyTreeDSLDependenciesItemsProviderBase
	{
		#region Singleton Instance
		private static FamilyTreeDSLDependenciesItemsProvider dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLDependenciesItemsProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new FamilyTreeDSLDependenciesItemsProvider();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLDependenciesItemsProvider() : base()
		{
		}
        #endregion
	
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLDependenciesItemsProviderBase : DslEditorModeling::DependenciesItemsProvider
	{		
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLDependenciesItemsProviderBase()
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
				return FamilyTreeDSLDependenciesRetrivalOptions.Instance;
			}
        }
	}
}

