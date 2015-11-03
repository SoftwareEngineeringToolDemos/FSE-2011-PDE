 
using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;
using DslEditorViewShell = global::Tum.PDE.ToolFramework.Modeling.Visualization.Shell;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// This class represents the shell package main view model of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class PDEModelingDSLShellPackageController : PDEModelingDSLShellPackageControllerBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        public PDEModelingDSLShellPackageController(DslEditorShell::ModelPackage package)
            : base(package)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the shell package controller of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLShellPackageControllerBase : DslEditorViewShell::ShellPackageController
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        protected PDEModelingDSLShellPackageControllerBase(DslEditorShell::ModelPackage package)
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

			this.LayoutManager = new Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLDockingLayoutManager(this.ModelPackage, this);
		}			
		#endregion
	}
}

