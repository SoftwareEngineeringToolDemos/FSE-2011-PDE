 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// This class represents the dependencies retrieval options for the domain model.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class StateMachineLanguageDependenciesRetrivalOptions : StateMachineLanguageDependenciesRetrivalOptionsBase
	{
		#region Singleton Instance
		private static StateMachineLanguageDependenciesRetrivalOptions dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageDependenciesRetrivalOptions Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new StateMachineLanguageDependenciesRetrivalOptions();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		private StateMachineLanguageDependenciesRetrivalOptions() : base()
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
	public abstract class StateMachineLanguageDependenciesRetrivalOptionsBase : DslEditorModeling::DependenciesRetrivalOptions
	{
		/// <summary>
        /// Constructor.
        /// </summary>
		protected StateMachineLanguageDependenciesRetrivalOptionsBase()
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
	public partial class StateMachineLanguageDependenciesItemsProvider : StateMachineLanguageDependenciesItemsProviderBase
	{
		#region Singleton Instance
		private static StateMachineLanguageDependenciesItemsProvider dependenciesProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageDependenciesItemsProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( dependenciesProvider == null )
				{
					dependenciesProvider = new StateMachineLanguageDependenciesItemsProvider();
				}
				
				return dependenciesProvider;
            }
        }
		
		/// <summary>
        /// Constructor.
        /// </summary>
		protected StateMachineLanguageDependenciesItemsProvider() : base()
		{
		}
        #endregion
	
	}

	/// <summary>
	/// This class represents the dependencies provider for the domain model.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class StateMachineLanguageDependenciesItemsProviderBase : DslEditorModeling::DependenciesItemsProvider
	{		
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected StateMachineLanguageDependenciesItemsProviderBase()
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
				return StateMachineLanguageDependenciesRetrivalOptions.Instance;
			}
        }
	}
}

