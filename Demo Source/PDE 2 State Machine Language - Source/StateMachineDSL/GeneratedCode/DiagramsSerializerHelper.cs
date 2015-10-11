 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Helper class for serializing and deserializing DiagramsDSL models.
	/// </summary>
	public sealed partial class StateMachineLanguageDiagramsDSLSerializationHelper : StateMachineLanguageDiagramsDSLSerializationHelperBase
	{
		#region Constructor
		/// <summary>
		/// Private constructor to prevent direct instantiation.
		/// </summary>
		private StateMachineLanguageDiagramsDSLSerializationHelper() : base () { }
		#endregion
		
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static StateMachineLanguageDiagramsDSLSerializationHelper instance;
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
		public static StateMachineLanguageDiagramsDSLSerializationHelper Instance
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (StateMachineLanguageDiagramsDSLSerializationHelper.instance == null)
					StateMachineLanguageDiagramsDSLSerializationHelper.instance = new StateMachineLanguageDiagramsDSLSerializationHelper();
				return StateMachineLanguageDiagramsDSLSerializationHelper.instance;
			}
		}
		#endregion
	}

	/// <summary>
	/// Helper class for serializing and deserializing DiagramsDSL models.
	///
	/// This is the base abstract class.
	/// </summary>
	public abstract partial class StateMachineLanguageDiagramsDSLSerializationHelperBase : DslEditorDiagrams::DiagramsDSLSerializationHelperBase
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		protected StateMachineLanguageDiagramsDSLSerializationHelperBase() { }
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
