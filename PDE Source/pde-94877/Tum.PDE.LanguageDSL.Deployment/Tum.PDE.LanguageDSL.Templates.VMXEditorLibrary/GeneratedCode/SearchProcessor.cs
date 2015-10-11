 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.VModellXT
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class VModellXTSearchProcessor : VModellXTSearchProcessorBase
	{
		#region Singleton Instance
		private static VModellXTSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new VModellXTSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private VModellXTSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class VModellXTSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VModellXTSearchProcessorBase()
		{
		}
        #endregion
	}	
}
