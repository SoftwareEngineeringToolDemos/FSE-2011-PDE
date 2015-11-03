 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.VModellXT.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class VModellXTServiceRegistrar : VModellXTServiceRegistrarBase
    {
		#region Singleton Instance
		private static VModellXTServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private VModellXTServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static VModellXTServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new VModellXTServiceRegistrar();
					
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
	public partial class VModellXTServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected VModellXTServiceRegistrarBase() : base()
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
