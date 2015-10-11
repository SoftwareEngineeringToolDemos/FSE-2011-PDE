 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class PDEModelingDSLSearchProcessor : PDEModelingDSLSearchProcessorBase
	{
		#region Singleton Instance
		private static PDEModelingDSLSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new PDEModelingDSLSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private PDEModelingDSLSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class PDEModelingDSLSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected PDEModelingDSLSearchProcessorBase()
		{
		}
        #endregion
	}	
}
