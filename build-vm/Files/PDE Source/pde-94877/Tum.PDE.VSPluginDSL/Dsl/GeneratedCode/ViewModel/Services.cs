 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.VSPluginDSL.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class VSPluginDSLServiceRegistrar : VSPluginDSLServiceRegistrarBase
    {
		#region Singleton Instance
		private static VSPluginDSLServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private VSPluginDSLServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static VSPluginDSLServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new VSPluginDSLServiceRegistrar();
					
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
	public partial class VSPluginDSLServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected VSPluginDSLServiceRegistrarBase() : base()
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
