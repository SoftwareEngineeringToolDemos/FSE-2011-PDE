 
using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;
using DslEditorViewShell = global::Tum.PDE.ToolFramework.Modeling.Visualization.Shell;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// This class represents the shell package main view model of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class VSPluginDSLShellPackageController : VSPluginDSLShellPackageControllerBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        public VSPluginDSLShellPackageController(DslEditorShell::ModelPackage package)
            : base(package)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the shell package controller of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLShellPackageControllerBase : DslEditorViewShell::ShellPackageController
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        protected VSPluginDSLShellPackageControllerBase(DslEditorShell::ModelPackage package)
            : base(package)
        {

        }
		#endregion
		
		#region Initialization
        /// <summary>
        /// This method is used to initialize the view model and can be overriden for customization.
        /// </summary>
        protected override void Initialize()
        {
			base.Initialize();

			this.LayoutManager = new Tum.PDE.VSPluginDSL.ViewModel.VSPluginDSLDockingLayoutManager(this.ModelPackage, this);
		}			
		#endregion
	}
}

