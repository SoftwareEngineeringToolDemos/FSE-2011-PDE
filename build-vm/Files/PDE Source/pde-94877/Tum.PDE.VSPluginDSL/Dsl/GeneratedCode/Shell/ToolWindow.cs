 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using VSTextTemplatingHost = global::Microsoft.VisualStudio.TextTemplating.VSHost;

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.PDE.VSPluginDSL
{
	#region ModelTree
	/// <summary>
	/// This class represents the model tree tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("60e483f0-9659-4368-b3e2-f34952d1e3cc")]	
	public partial class VSPluginDSLModelTreeToolWindow: VSPluginDSLModelTreeToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLModelTreeToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLModelTreeToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLModelTreeToolWindowBase()
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
	/// This class represents the property grid tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("9c92c7e3-2059-49ff-b924-10244df21f87")]	
	public partial class VSPluginDSLPropertyGridToolWindow: VSPluginDSLPropertyGridToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLPropertyGridToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid tool window of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLPropertyGridToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLPropertyGridToolWindowBase()
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
	/// This class represents the error list tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("d38b9a7a-fff9-4955-8341-d41838759972")]	
	public partial class VSPluginDSLErrorListToolWindow: VSPluginDSLErrorListToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLErrorListToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLErrorListToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLErrorListToolWindowBase()
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
	/// This class represents the dependencies tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("f79c95fd-9a23-4d54-8a85-fb1b9d1d7a0a")]	
	public partial class VSPluginDSLDependenciesToolWindow: VSPluginDSLDependenciesToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLDependenciesToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLDependenciesToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLDependenciesToolWindowBase()
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
	/// This class represents the search tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("b3048730-f136-4dd8-bd5c-102caae22312")]	
	public partial class VSPluginDSLSearchToolWindow: VSPluginDSLSearchToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLSearchToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLSearchToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLSearchToolWindowBase()
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
	/// This class represents the search result tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("bc8d249a-6f4b-4f9d-8493-3852fcc81bfb")]	
	public partial class VSPluginDSLSearchResultToolWindow: VSPluginDSLSearchResultToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLSearchResultToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search result tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLSearchResultToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLSearchResultToolWindowBase()
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
	/// This class represents the DesignerDiagram tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("ee637228-f59a-4ab2-b309-1756eb2bef95")]	
	public partial class VSPluginDSLDesignerDiagramToolWindow: VSPluginDSLDesignerDiagramToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLDesignerDiagramToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the DesignerDiagram tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLDesignerDiagramToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLDesignerDiagramToolWindowBase()
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

	/// <summary>
	/// This class represents the SpecificElementsDiagramTemplate tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("4c700bc9-73ff-4f10-92ad-71d9e7d4d683")]	
	public partial class VSPluginDSLSpecificElementsDiagramTemplateToolWindow: VSPluginDSLSpecificElementsDiagramTemplateToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLSpecificElementsDiagramTemplateToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the SpecificElementsDiagramTemplate tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLSpecificElementsDiagramTemplateToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLSpecificElementsDiagramTemplateToolWindowBase()
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

	/// <summary>
	/// This class represents the ModalDiagramTemplate tool window of the VSPluginDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("157b7e5c-da1c-494f-a445-bb16467c9c6a")]	
	public partial class VSPluginDSLModalDiagramTemplateToolWindow: VSPluginDSLModalDiagramTemplateToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLModalDiagramTemplateToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the ModalDiagramTemplate tool window  of the VSPluginDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLModalDiagramTemplateToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLModalDiagramTemplateToolWindowBase()
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
	/// This class represents the tool window of the VSPluginDSL that is used for plugins.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("b12f5608-b42c-48ac-802e-9b0e902012a1")]	
	public partial class VSPluginDSLPluginsVMToolWindow: VSPluginDSLPluginsVMToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public VSPluginDSLPluginsVMToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the tool window of the VSPluginDSL that is used for plugins.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class VSPluginDSLPluginsVMToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected VSPluginDSLPluginsVMToolWindowBase()
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