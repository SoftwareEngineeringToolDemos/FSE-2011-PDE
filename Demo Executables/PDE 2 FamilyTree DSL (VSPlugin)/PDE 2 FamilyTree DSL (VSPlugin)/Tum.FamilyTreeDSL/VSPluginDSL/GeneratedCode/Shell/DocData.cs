 

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

using global::System.Linq;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class FamilyTreeDSLDocData : FamilyTreeDSLDocDataBase
	{
		/// <summary>
		/// Constructs a new FamilyTreeDSLDocData.
		/// </summary>
        /// <param name="modelData">Model data.</param>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="editorFactoryId">EditorFactory id.</param>
		public FamilyTreeDSLDocData(DslEditorModeling::ModelData modelData, global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId) 
			: base(modelData, serviceProvider, editorFactoryId)
		{
		}
	}

	/// <summary>
	/// Class which represents a FamilyTreeDSL document in memory.
	/// </summary>
	internal abstract partial class FamilyTreeDSLDocDataBase : DslEditorShell::ModelShellData
	{
		/// <summary>
		/// Constructs a new FamilyTreeDSLDocDataBase.
		/// </summary>
		/// <param name="modelData">Model data.</param>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="editorFactoryId">EditorFactory id.</param>
		protected FamilyTreeDSLDocDataBase(DslEditorModeling::ModelData modelData, global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId)
			: base(modelData, serviceProvider, editorFactoryId)
		{
		}
	}
}