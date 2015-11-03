 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ModelingDSL.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class PDEModelingDSLServiceRegistrar : PDEModelingDSLServiceRegistrarBase
    {
		#region Singleton Instance
		private static PDEModelingDSLServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private PDEModelingDSLServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static PDEModelingDSLServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new PDEModelingDSLServiceRegistrar();
					
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
	public partial class PDEModelingDSLServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected PDEModelingDSLServiceRegistrarBase() : base()
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
