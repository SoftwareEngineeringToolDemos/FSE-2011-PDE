 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class StateMachineLanguageServiceRegistrar : StateMachineLanguageServiceRegistrarBase
    {
		#region Singleton Instance
		private static StateMachineLanguageServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private StateMachineLanguageServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static StateMachineLanguageServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new StateMachineLanguageServiceRegistrar();
					
				return instance;
			}
		}			
		#endregion
	}
	
	/// <summary>
	/// Class to allow easy service registration.
	///
	/// This is the base abstract class.
	/// </summary>
	public partial class StateMachineLanguageServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected StateMachineLanguageServiceRegistrarBase() : base()
		{
		}
		
        /// <summary>
	   	/// Register services to the given store.
    	/// </summary>
    	/// <param name="store">ViewModelStore.</param>
    	public override void RegisterServices(DslEditorViewModelData::ViewModelStore store)
		{
			
		}
	}
}
