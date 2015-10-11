 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class StateMachineLanguageSearchProcessor : StateMachineLanguageSearchProcessorBase
	{
		#region Singleton Instance
		private static StateMachineLanguageSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new StateMachineLanguageSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private StateMachineLanguageSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class StateMachineLanguageSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected StateMachineLanguageSearchProcessorBase()
		{
		}
        #endregion
	}	
}
