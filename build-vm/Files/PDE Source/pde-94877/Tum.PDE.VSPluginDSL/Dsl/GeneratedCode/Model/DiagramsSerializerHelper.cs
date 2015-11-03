 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Helper class for serializing and deserializing DiagramsDSL models.
	/// </summary>
	public sealed partial class VSPluginDSLDiagramsDSLSerializationHelper : VSPluginDSLDiagramsDSLSerializationHelperBase
	{
		#region Constructor
		/// <summary>
		/// Private constructor to prevent direct instantiation.
		/// </summary>
		private VSPluginDSLDiagramsDSLSerializationHelper() : base () { }
		#endregion
		
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static VSPluginDSLDiagramsDSLSerializationHelper instance;
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
		public static VSPluginDSLDiagramsDSLSerializationHelper Instance
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (VSPluginDSLDiagramsDSLSerializationHelper.instance == null)
					VSPluginDSLDiagramsDSLSerializationHelper.instance = new VSPluginDSLDiagramsDSLSerializationHelper();
				return VSPluginDSLDiagramsDSLSerializationHelper.instance;
			}
		}
		#endregion
	}

	/// <summary>
	/// Helper class for serializing and deserializing DiagramsDSL models.
	///
	/// This is the base abstract class.
	/// </summary>
	public abstract partial class VSPluginDSLDiagramsDSLSerializationHelperBase : DslEditorDiagrams::DiagramsDSLSerializationHelperBase
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		protected VSPluginDSLDiagramsDSLSerializationHelperBase() { }
		#endregion
		
		#region Methods
		/// <summary>
		/// Ensure that domain element serializers are installed properly on the given store, 
		/// so that deserialization can be carried out correctly.
		/// </summary>
		/// <param name="store">Store.</param>
		public new virtual void InitializeSerialization(DslModeling::Store store)
		{
			base.Initialize(store);
		}
		#endregion
	}

}
