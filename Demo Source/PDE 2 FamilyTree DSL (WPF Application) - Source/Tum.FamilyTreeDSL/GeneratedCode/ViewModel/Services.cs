 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.FamilyTreeDSL.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class FamilyTreeDSLServiceRegistrar : FamilyTreeDSLServiceRegistrarBase
    {
		#region Singleton Instance
		private static FamilyTreeDSLServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private FamilyTreeDSLServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static FamilyTreeDSLServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new FamilyTreeDSLServiceRegistrar();
					
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
	public partial class FamilyTreeDSLServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected FamilyTreeDSLServiceRegistrarBase() : base()
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
