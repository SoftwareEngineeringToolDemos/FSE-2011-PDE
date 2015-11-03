 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using VSTextTemplatingHost = global::Microsoft.VisualStudio.TextTemplating.VSHost;

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// This class implements the VS package that integrates this DSL into Visual Studio.
	/// </summary>
	[VSShell::DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
	[VSShell::PackageRegistration(RegisterUsing = VSShell::RegistrationMethod.Assembly, UseManagedResourcesOnly = true)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLModelTreeToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Left, Window = "{3AE79031-E1BC-11D0-8F78-00A0C9110057}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLPropertyGridToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Right, Window = "{EEFA5220-E298-11D0-8F78-00A0C9110057}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLErrorListToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLDependenciesToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	//[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLDesignerDiagramToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.MDI, Orientation = VSShell::ToolWindowOrientation.none, Transient = true)]
	//[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLPluginsVMToolWindow), MultiInstances = true, Style = VSShell::VsDockStyle.Tabbed)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLSearchToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Float)]
	[VSShell::ProvideToolWindow(typeof(FamilyTreeDSLSearchResultToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	[VSShell::ProvideEditorFactory(typeof(FamilyTreeDSLEditorFactory), 103, TrustLevel = VSShellInterop::__VSEDITORTRUSTLEVEL.ETL_AlwaysTrusted)]
	[VSShell::ProvideEditorExtension(typeof(FamilyTreeDSLEditorFactory), "." + Constants.DesignerFileExtension, 50)]
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.CSharpProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.VisualBasicProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::RegisterAsDslToolsEditor]
	[global::System.Runtime.InteropServices.ComVisible(true)]
	[DslShell::ProvideBindingPath]
	[DslShell::ProvideXmlEditorChooserBlockSxSWithXmlEditor(@"FamilyTreeDSL", typeof(FamilyTreeDSLEditorFactory))]
	internal abstract partial class FamilyTreeDSLPackageBase : DslEditorShell::ModelPackage
	{
		/// <summary>
        /// Gets or sets the package controller.
        /// </summary>
        public FamilyTreeDSLShellPackageController PackageController
        {
            get;
            set;
        }

		/*
		/// <summary>
        /// Gets or sets the editor factory.
        /// </summary>
        public FamilyTreeDSLEditorFactory EditorFactory
        {
            get;
            set;
        }*/

        /// <summary>
        /// Create package controller.
        /// </summary>
        protected virtual void CreatePackageController()
        {
            this.PackageController = new FamilyTreeDSLShellPackageController(this);
        }	
	
		/// <summary>
		/// Initialization method called by the package base class when this package is loaded.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

		    // Register the editor factory used to create the DSL editor.
            this.EditorFactory = new FamilyTreeDSLEditorFactory(this);
            this.RegisterEditorFactory(this.EditorFactory);

            // Create package controller.
            this.CreatePackageController();

			// Initialize Extension Registars
			// this is a partial method call
			this.InitializeExtensions();

			// Add dynamic toolbox items
			this.SetupDynamicToolbox();
		}

		/// <summary>
		/// Partial method to initialize ExtensionRegistrars (if any) in the DslPackage
		/// </summary>
		partial void InitializeExtensions();
				
		#region Methods
        /// <summary>
        /// Gets the editor type id.
        /// </summary>
        public override System.Guid EditorTypeId
        {
            get
			{
				return new System.Guid(Constants.FamilyTreeDSLEditorFactoryId);
			}
        }

        /// <summary>
        /// Returns a list of guids identifying the tool windows contained in this package.
        /// </summary>
        /// <returns>List of guid of tool windows in this package.</returns>
        public override System.Collections.Generic.List<System.Guid> GetToolWindowIdList()
		{
			System.Collections.Generic.List<System.Guid> lst = new System.Collections.Generic.List<System.Guid>();
			lst.Add(new System.Guid("19771fbf-188e-4538-8be1-8dee14cd0a9a"));	// ModelTree
			lst.Add(new System.Guid("3951623f-6d1a-4d76-b502-cca2e52c4940"));	// PropertyGrid
			lst.Add(new System.Guid("f81ac446-3dc4-48af-8738-16cdf0fe05cd"));	// ErrorList
			lst.Add(new System.Guid("19e24a4d-1c53-4aa6-b086-2f48837b2844"));	// DependenciesView
			lst.Add(new System.Guid("dd212215-f39e-4b5f-8a70-b75549507756"));	// DesignerDiagram
			lst.Add(new System.Guid("95e04c32-7b33-4a29-8a75-bc66682c5eb8"));	// Search
			lst.Add(new System.Guid("da4d98a2-c1ce-4ffe-80c6-9c800649caf1"));	// SearchResult	
			
			//lst.Add(new System.Guid("7de1151a-77ac-41e1-9385-710261430a2d"));	// Plugins			
			return lst;
		}

        /// <summary>
        /// Gets the tool window type for the given view model type if possible. Throws NotSupportedException otherwise.
        /// </summary>
        /// <param name="vmType"></param>
        /// <returns></returns>
        public override System.Type GetToolWindowType(System.Type vmType)
		{
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLModelTreeViewModel) )
				return typeof(FamilyTreeDSLModelTreeToolWindow);
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLPropertyGridViewModel) )
				return typeof(FamilyTreeDSLPropertyGridToolWindow);
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLErrorListViewModel) )
				return typeof(FamilyTreeDSLErrorListToolWindow);
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLDependenciesViewModel) )
				return typeof(FamilyTreeDSLDependenciesToolWindow);
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLDesignerDiagramSurfaceViewModel) )
				return typeof(FamilyTreeDSLDesignerDiagramToolWindow);
			if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLSearchViewModel) )
				return typeof(FamilyTreeDSLSearchToolWindow);				
			else if( vmType == typeof(Tum.FamilyTreeDSL.ViewModel.FamilyTreeDSLSearchResultViewModel) )
				return typeof(FamilyTreeDSLSearchResultToolWindow);				
				
			//return typeof(FamilyTreeDSLPluginsVMToolWindow);
			throw new System.NotSupportedException("GetToolWindowType for type: " + vmType.FullName);
		}
		
		/// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.PackageController.Dispose();
            base.Dispose(disposing);
        }
		#endregion		
	}
}

//
// Package attributes which may need to change are placed on the partial class below, rather than in the main include file.
//
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[VSShell::ProvideMenuResource("1000.ctmenu", 1)]
	[VSShell::ProvideToolboxItems(1)]
	[VSTextTemplatingHost::ProvideDirectiveProcessor(typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDirectiveProcessor), global::Tum.FamilyTreeDSL.FamilyTreeDSLDirectiveProcessor.FamilyTreeDSLDirectiveProcessorName, "A directive processor that provides access to FamilyTreeDSL files")]
	[global::System.Runtime.InteropServices.Guid(Constants.FamilyTreeDSLPackageId)]
	internal sealed partial class FamilyTreeDSLPackage : FamilyTreeDSLPackageBase
	{
	}
}

