 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using VSTextTemplatingHost = global::Microsoft.VisualStudio.TextTemplating.VSHost;

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.FamilyTreeDSL
{
	#region ModelTree
	/// <summary>
	/// This class represents the model tree tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("19771fbf-188e-4538-8be1-8dee14cd0a9a")]	
	public partial class FamilyTreeDSLModelTreeToolWindow: FamilyTreeDSLModelTreeToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLModelTreeToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLModelTreeToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLModelTreeToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 301;
            this.BitmapIndex = 0;
        }
	}
	#endregion

	#region PropertyGrid
	/// <summary>
	/// This class represents the property grid tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("3951623f-6d1a-4d76-b502-cca2e52c4940")]	
	public partial class FamilyTreeDSLPropertyGridToolWindow: FamilyTreeDSLPropertyGridToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLPropertyGridToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid tool window of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLPropertyGridToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLPropertyGridToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 302;
            this.BitmapIndex = 0;
        }		
	}	
	#endregion

	#region ErrorList
	/// <summary>
	/// This class represents the error list tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("f81ac446-3dc4-48af-8738-16cdf0fe05cd")]	
	public partial class FamilyTreeDSLErrorListToolWindow: FamilyTreeDSLErrorListToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLErrorListToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLErrorListToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLErrorListToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 303;
            this.BitmapIndex = 0;
        }		
	}
	#endregion

	#region Dependencies
	/// <summary>
	/// This class represents the dependencies tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("19e24a4d-1c53-4aa6-b086-2f48837b2844")]	
	public partial class FamilyTreeDSLDependenciesToolWindow: FamilyTreeDSLDependenciesToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLDependenciesToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLDependenciesToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLDependenciesToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 304;
            this.BitmapIndex = 0;
        }		
	}	
	#endregion

	#region Search
	/// <summary>
	/// This class represents the search tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("95e04c32-7b33-4a29-8a75-bc66682c5eb8")]	
	public partial class FamilyTreeDSLSearchToolWindow: FamilyTreeDSLSearchToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLSearchToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLSearchToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLSearchToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 306;
            this.BitmapIndex = 0;
        }		
	}		
	
	/// <summary>
	/// This class represents the search result tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("da4d98a2-c1ce-4ffe-80c6-9c800649caf1")]	
	public partial class FamilyTreeDSLSearchResultToolWindow: FamilyTreeDSLSearchResultToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLSearchResultToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search result tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLSearchResultToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLSearchResultToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
		
		/// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.BitmapResourceID = 305;
            this.BitmapIndex = 0;
        }		
	}		
	#endregion

	/// <summary>
	/// This class represents the DesignerDiagram tool window of the FamilyTreeDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("dd212215-f39e-4b5f-8a70-b75549507756")]	
	public partial class FamilyTreeDSLDesignerDiagramToolWindow: FamilyTreeDSLDesignerDiagramToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLDesignerDiagramToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the DesignerDiagram tool window  of the FamilyTreeDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLDesignerDiagramToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLDesignerDiagramToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
	}

	/*
	#region Plugin
	/// <summary>
	/// This class represents the tool window of the FamilyTreeDSL that is used for plugins.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("7de1151a-77ac-41e1-9385-710261430a2d")]	
	public partial class FamilyTreeDSLPluginsVMToolWindow: FamilyTreeDSLPluginsVMToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public FamilyTreeDSLPluginsVMToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the tool window of the FamilyTreeDSL that is used for plugins.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class FamilyTreeDSLPluginsVMToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected FamilyTreeDSLPluginsVMToolWindowBase()
            : base()
        {
        }
		#endregion
	
		/// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
	    public override System.Windows.FrameworkElement CreateControl()
        {
            return new Tum.PDE.ToolFramework.Modeling.Visualization.Shell.Controls.DefaultView();
        }
	}	
	#endregion
	*/
	
}