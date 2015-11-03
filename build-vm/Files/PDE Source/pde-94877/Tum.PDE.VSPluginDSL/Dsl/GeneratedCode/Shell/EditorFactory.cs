 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[global::System.Runtime.InteropServices.Guid(Constants.VSPluginDSLEditorFactoryId)]
	internal partial class VSPluginDSLEditorFactory : VSPluginDSLEditorFactoryBase
	{
		/// <summary>
		/// Constructs a new VSPluginDSLEditorFactory.
		/// </summary>
		public VSPluginDSLEditorFactory(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
		}
	}

	/// <summary>
	/// Factory for creating our editors
	/// </summary>
	internal abstract class VSPluginDSLEditorFactoryBase : DslEditorShell::ModelEditorFactory
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="serviceProvider">Service provider used to access VS services.</param>
		protected VSPluginDSLEditorFactoryBase(global::System.IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}

        /// <summary>
        /// Called by the shell to ask the editor to create a new document object.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="hierarchy"></param>
        /// <param name="itemId"></param>
		public override DslShell::ModelingDocData CreateDocData(string fileName, VSShellInterop::IVsHierarchy hierarchy, uint itemId)
		{
			// Create the document type supported by this editor.
			
			// Create model data
			global::Tum.PDE.VSPluginDSL.VSPluginDSLDocumentData modelData = new global::Tum.PDE.VSPluginDSL.VSPluginDSLDocumentData();
			
			// Create shell model data
			VSPluginDSLDocData shellModelData = new VSPluginDSLDocData(modelData, this.ServiceProvider, typeof(VSPluginDSLEditorFactory).GUID);
			this.ModelData = shellModelData;
			
			// Set file name properties
			System.IO.FileInfo info = new System.IO.FileInfo(fileName);
			shellModelData.FullFileName = fileName;
			shellModelData.FileName = info.Name;
			
			return shellModelData;
		}

		/// <summary>
		/// Called by the shell to ask the editor to create a new view object.
		/// </summary>
		protected override DslShell::ModelingDocView CreateDocView(DslShell::ModelingDocData docData, string physicalView, out string editorCaption)
		{
			// Create the view type supported by this editor.
			editorCaption = string.Empty;
			return new VSPluginDSLDocView(docData as DslEditorShell::ModelShellData, this.ServiceProvider);
		}
	}
}
