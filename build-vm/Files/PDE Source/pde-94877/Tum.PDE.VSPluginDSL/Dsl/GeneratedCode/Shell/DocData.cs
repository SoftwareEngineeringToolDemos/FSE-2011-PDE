 

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

using global::System.Linq;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class VSPluginDSLDocData : VSPluginDSLDocDataBase
	{
		/// <summary>
		/// Constructs a new VSPluginDSLDocData.
		/// </summary>
        /// <param name="modelData">Model data.</param>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="editorFactoryId">EditorFactory id.</param>
		public VSPluginDSLDocData(DslEditorModeling::ModelData modelData, global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId) 
			: base(modelData, serviceProvider, editorFactoryId)
		{
		}
	}

	/// <summary>
	/// Class which represents a VSPluginDSL document in memory.
	/// </summary>
	internal abstract partial class VSPluginDSLDocDataBase : DslEditorShell::ModelShellData
	{
		/// <summary>
		/// Constructs a new VSPluginDSLDocDataBase.
		/// </summary>
		/// <param name="modelData">Model data.</param>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="editorFactoryId">EditorFactory id.</param>
		protected VSPluginDSLDocDataBase(DslEditorModeling::ModelData modelData, global::System.IServiceProvider serviceProvider, global::System.Guid editorFactoryId)
			: base(modelData, serviceProvider, editorFactoryId)
		{
		}
	}
}