 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class TestLanguageDependenciesRetrivalOptions : TestLanguageDependenciesRetrivalOptionsBase
	{
		#region Singleton Instance
		private static TestLanguageDependenciesRetrivalOptions dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static TestLanguageDependenciesRetrivalOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new TestLanguageDependenciesRetrivalOptions();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		private TestLanguageDependenciesRetrivalOptions() : base()
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
	public abstract class TestLanguageDependenciesRetrivalOptionsBase : DslEditorModeling::DependenciesRetrivalOptions
	{
		/// <summary>
        /// Constructor.
        /// </summary>
		protected TestLanguageDependenciesRetrivalOptionsBase()
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
	public partial class TestLanguageDependenciesItemsProvider : TestLanguageDependenciesItemsProviderBase
	{
		#region Singleton Instance
		private static TestLanguageDependenciesItemsProvider dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static TestLanguageDependenciesItemsProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new TestLanguageDependenciesItemsProvider();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		protected TestLanguageDependenciesItemsProvider() : base()
		{
		}
        #endregion
	
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class TestLanguageDependenciesItemsProviderBase : DslEditorModeling::DependenciesItemsProvider
	{		
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected TestLanguageDependenciesItemsProviderBase()
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
				return TestLanguageDependenciesRetrivalOptions.Instance;
			}
        }
	}
}

