 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class TestLanguageSearchProcessor : TestLanguageSearchProcessorBase
	{
		#region Singleton Instance
		private static TestLanguageSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static TestLanguageSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new TestLanguageSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private TestLanguageSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class TestLanguageSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected TestLanguageSearchProcessorBase()
		{
		}
        #endregion
	}	
}
