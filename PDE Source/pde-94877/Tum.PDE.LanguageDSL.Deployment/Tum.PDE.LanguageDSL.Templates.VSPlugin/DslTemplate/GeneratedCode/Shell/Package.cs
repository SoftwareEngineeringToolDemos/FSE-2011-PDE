 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using VSTextTemplatingHost = global::Microsoft.VisualStudio.TextTemplating.VSHost;

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// This class implements the VS package that integrates this DSL into Visual Studio.
	/// </summary>
	[VSShell::DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
	[VSShell::PackageRegistration(RegisterUsing = VSShell::RegistrationMethod.Assembly, UseManagedResourcesOnly = true)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLModelTreeToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Left, Window = "{3AE79031-E1BC-11D0-8F78-00A0C9110057}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLPropertyGridToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Right, Window = "{EEFA5220-E298-11D0-8F78-00A0C9110057}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLErrorListToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLDependenciesToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	//[VSShell::ProvideToolWindow(typeof(PDEModelingDSLDesignerDiagramToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.MDI, Orientation = VSShell::ToolWindowOrientation.none, Transient = true)]
	//[VSShell::ProvideToolWindow(typeof(PDEModelingDSLConversionDiagramToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.MDI, Orientation = VSShell::ToolWindowOrientation.none, Transient = true)]
	//[VSShell::ProvideToolWindow(typeof(PDEModelingDSLPluginsVMToolWindow), MultiInstances = true, Style = VSShell::VsDockStyle.Tabbed)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLSearchToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Float)]
	[VSShell::ProvideToolWindow(typeof(PDEModelingDSLSearchResultToolWindow), MultiInstances = false, Style = VSShell::VsDockStyle.Tabbed, Orientation = VSShell::ToolWindowOrientation.Bottom, Window = "{D78612C7-9962-4B83-95D9-268046DAD23A}", Transient = true)]
	[VSShell::ProvideEditorFactory(typeof(PDEModelingDSLEditorFactory), 103, TrustLevel = VSShellInterop::__VSEDITORTRUSTLEVEL.ETL_AlwaysTrusted)]
	[VSShell::ProvideEditorExtension(typeof(PDEModelingDSLEditorFactory), "." + Constants.DesignerFileExtension, 50)]
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.CSharpProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.VisualBasicProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::RegisterAsDslToolsEditor]
	[global::System.Runtime.InteropServices.ComVisible(true)]
	[DslShell::ProvideBindingPath]
	[DslShell::ProvideXmlEditorChooserBlockSxSWithXmlEditor(@"PDEModelingDSL", typeof(PDEModelingDSLEditorFactory))]
	internal abstract partial class PDEModelingDSLPackageBase : DslEditorShell::ModelPackage
	{
		/// <summary>
        /// Gets or sets the package controller.
        /// </summary>
        public PDEModelingDSLShellPackageController PackageController
        {
            get;
            set;
        }

		/*
		/// <summary>
        /// Gets or sets the editor factory.
        /// </summary>
        public PDEModelingDSLEditorFactory EditorFactory
        {
            get;
            set;
        }*/

        /// <summary>
        /// Create package controller.
        /// </summary>
        protected virtual void CreatePackageController()
        {
            this.PackageController = new PDEModelingDSLShellPackageController(this);
        }	
	
		/// <summary>
		/// Initialization method called by the package base class when this package is loaded.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

		    // Register the editor factory used to create the DSL editor.
            this.EditorFactory = new PDEModelingDSLEditorFactory(this);
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
				return new System.Guid(Constants.PDEModelingDSLEditorFactoryId);
			}
        }

        /// <summary>
        /// Returns a list of guids identifying the tool windows contained in this package.
        /// </summary>
        /// <returns>List of guid of tool windows in this package.</returns>
        public override System.Collections.Generic.List<System.Guid> GetToolWindowIdList()
		{
			System.Collections.Generic.List<System.Guid> lst = new System.Collections.Generic.List<System.Guid>();
			lst.Add(new System.Guid("60e483f0-9659-4368-b3e2-f34952d1e3cc"));	// ModelTree
			lst.Add(new System.Guid("9c92c7e3-2059-49ff-b924-10244df21f87"));	// PropertyGrid
			lst.Add(new System.Guid("d38b9a7a-fff9-4955-8341-d41838759972"));	// ErrorList
			lst.Add(new System.Guid("f79c95fd-9a23-4d54-8a85-fb1b9d1d7a0a"));	// DependenciesView
			lst.Add(new System.Guid("ee637228-f59a-4ab2-b309-1756eb2bef95"));	// DesignerDiagram
			lst.Add(new System.Guid("30220d2a-50e8-4a0a-91ec-539df429f331"));	// ConversionDiagram
			lst.Add(new System.Guid("b3048730-f136-4dd8-bd5c-102caae22312"));	// Search
			lst.Add(new System.Guid("bc8d249a-6f4b-4f9d-8493-3852fcc81bfb"));	// SearchResult	
			
			//lst.Add(new System.Guid("2fad8b3f-bc2c-43fd-86b6-9b8b93529657"));	// Plugins			
			return lst;
		}

        /// <summary>
        /// Gets the tool window type for the given view model type if possible. Throws NotSupportedException otherwise.
        /// </summary>
        /// <param name="vmType"></param>
        /// <returns></returns>
        public override System.Type GetToolWindowType(System.Type vmType)
		{
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLModelTreeViewModel) )
				return typeof(PDEModelingDSLModelTreeToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLPropertyGridViewModel) )
				return typeof(PDEModelingDSLPropertyGridToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLErrorListViewModel) )
				return typeof(PDEModelingDSLErrorListToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLDependenciesViewModel) )
				return typeof(PDEModelingDSLDependenciesToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLDesignerDiagramSurfaceViewModel) )
				return typeof(PDEModelingDSLDesignerDiagramToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLConversionDiagramSurfaceViewModel) )
				return typeof(PDEModelingDSLConversionDiagramToolWindow);
			if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLSearchViewModel) )
				return typeof(PDEModelingDSLSearchToolWindow);				
			else if( vmType == typeof(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLSearchResultViewModel) )
				return typeof(PDEModelingDSLSearchResultToolWindow);				
				
			//return typeof(PDEModelingDSLPluginsVMToolWindow);
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[VSShell::ProvideMenuResource("1000.ctmenu", 1)]
	[VSShell::ProvideToolboxItems(1)]
	[VSTextTemplatingHost::ProvideDirectiveProcessor(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDirectiveProcessor), global::Tum.PDE.ModelingDSL.PDEModelingDSLDirectiveProcessor.PDEModelingDSLDirectiveProcessorName, "A directive processor that provides access to PDEModelingDSL files")]
	[global::System.Runtime.InteropServices.Guid(Constants.PDEModelingDSLPackageId)]
	internal sealed partial class PDEModelingDSLPackage : PDEModelingDSLPackageBase
	{
	}
}

