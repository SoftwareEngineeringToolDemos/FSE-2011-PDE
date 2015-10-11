 
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.TestLanguage.ViewModel
{
	/// <summary>
	/// Class to allow easy service registration.
	/// </summary>
	public partial class TestLanguageServiceRegistrar : TestLanguageServiceRegistrarBase
    {
		#region Singleton Instance
		private static TestLanguageServiceRegistrar instance = null;
		
		/// <summary>
		/// Private constructor.
		/// </summary>
		private TestLanguageServiceRegistrar() : base()
		{
		}
	
		/// <summary>
		/// Singleton Instance.
		/// </summary>
		public static TestLanguageServiceRegistrar Instance
		{
			get
			{
				if( instance == null )
					instance = new TestLanguageServiceRegistrar();
					
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
	public partial class TestLanguageServiceRegistrarBase : DslEditorViewModelData::ServiceRegistrar
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		protected TestLanguageServiceRegistrarBase() : base()
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
