 
using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;
using DslEditorViewShell = global::Tum.PDE.ToolFramework.Modeling.Visualization.Shell;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// This class represents the shell package main view model of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
	public partial class FamilyTreeDSLShellPackageController : FamilyTreeDSLShellPackageControllerBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        public FamilyTreeDSLShellPackageController(DslEditorShell::ModelPackage package)
            : base(package)
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the shell package controller of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLShellPackageControllerBase : DslEditorViewShell::ShellPackageController
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
		/// <param name="package">Package.</param>
        protected FamilyTreeDSLShellPackageControllerBase(DslEditorShell::ModelPackage package)
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

			this.LayoutManager = new Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLDockingLayoutManager(this.ModelPackage, this);
		}			
		#endregion
	}
}

