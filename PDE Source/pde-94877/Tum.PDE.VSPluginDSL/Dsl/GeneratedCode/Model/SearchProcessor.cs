 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class VSPluginDSLSearchProcessor : VSPluginDSLSearchProcessorBase
	{
		#region Singleton Instance
		private static VSPluginDSLSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new VSPluginDSLSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private VSPluginDSLSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class VSPluginDSLSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLSearchProcessorBase()
		{
		}
        #endregion
	}	
}
