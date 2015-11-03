 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public partial class FamilyTreeDSLSearchProcessor : FamilyTreeDSLSearchProcessorBase
	{
		#region Singleton Instance
		private static FamilyTreeDSLSearchProcessor elementSearchProcessor = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLSearchProcessor Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( elementSearchProcessor == null )
				{
					elementSearchProcessor = new FamilyTreeDSLSearchProcessor();
				}
				
				return elementSearchProcessor;
            }
        }
		
		private FamilyTreeDSLSearchProcessor() : base()
		{
		}
        #endregion
	}
	
	/// <summary>
	/// Class which provides search functionality.
	/// </summary>
	public abstract class FamilyTreeDSLSearchProcessorBase : DslEditorModeling::ModelElementSearchProcessor
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLSearchProcessorBase()
		{
		}
        #endregion
	}	
}
