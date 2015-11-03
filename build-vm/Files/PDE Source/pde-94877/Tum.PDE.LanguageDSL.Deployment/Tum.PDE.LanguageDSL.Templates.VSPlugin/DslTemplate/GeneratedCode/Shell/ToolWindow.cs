 
using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using VSTextTemplatingHost = global::Microsoft.VisualStudio.TextTemplating.VSHost;

using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.PDE.ModelingDSL
{
	#region ModelTree
	/// <summary>
	/// This class represents the model tree tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("60e483f0-9659-4368-b3e2-f34952d1e3cc")]	
	public partial class PDEModelingDSLModelTreeToolWindow: PDEModelingDSLModelTreeToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLModelTreeToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the model tree tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLModelTreeToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLModelTreeToolWindowBase()
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
	/// This class represents the property grid tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("9c92c7e3-2059-49ff-b924-10244df21f87")]	
	public partial class PDEModelingDSLPropertyGridToolWindow: PDEModelingDSLPropertyGridToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLPropertyGridToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the property grid tool window of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLPropertyGridToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLPropertyGridToolWindowBase()
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
	/// This class represents the error list tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("d38b9a7a-fff9-4955-8341-d41838759972")]	
	public partial class PDEModelingDSLErrorListToolWindow: PDEModelingDSLErrorListToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLErrorListToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the error list tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLErrorListToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLErrorListToolWindowBase()
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
	/// This class represents the dependencies tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("f79c95fd-9a23-4d54-8a85-fb1b9d1d7a0a")]	
	public partial class PDEModelingDSLDependenciesToolWindow: PDEModelingDSLDependenciesToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLDependenciesToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the dependencies tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLDependenciesToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLDependenciesToolWindowBase()
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
	/// This class represents the search tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("b3048730-f136-4dd8-bd5c-102caae22312")]	
	public partial class PDEModelingDSLSearchToolWindow: PDEModelingDSLSearchToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLSearchToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLSearchToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLSearchToolWindowBase()
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
	/// This class represents the search result tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("bc8d249a-6f4b-4f9d-8493-3852fcc81bfb")]	
	public partial class PDEModelingDSLSearchResultToolWindow: PDEModelingDSLSearchResultToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLSearchResultToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the search result tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLSearchResultToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLSearchResultToolWindowBase()
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
	/// This class represents the DesignerDiagram tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("ee637228-f59a-4ab2-b309-1756eb2bef95")]	
	public partial class PDEModelingDSLDesignerDiagramToolWindow: PDEModelingDSLDesignerDiagramToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLDesignerDiagramToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the DesignerDiagram tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLDesignerDiagramToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLDesignerDiagramToolWindowBase()
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
	/// This class represents the ConversionDiagram tool window of the PDEModelingDSL.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("30220d2a-50e8-4a0a-91ec-539df429f331")]	
	public partial class PDEModelingDSLConversionDiagramToolWindow: PDEModelingDSLConversionDiagramToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLConversionDiagramToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the ConversionDiagram tool window  of the PDEModelingDSL.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLConversionDiagramToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLConversionDiagramToolWindowBase()
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
	/// This class represents the tool window of the PDEModelingDSL that is used for plugins.
	/// 
	/// Double-derived class to allow easier code customization.
	/// </summary>
    [System.Runtime.InteropServices.Guid("2fad8b3f-bc2c-43fd-86b6-9b8b93529657")]	
	public partial class PDEModelingDSLPluginsVMToolWindow: PDEModelingDSLPluginsVMToolWindowBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        public PDEModelingDSLPluginsVMToolWindow()
            : base()
        {
        }
		#endregion
	}
	
	/// <summary>
	/// This class represents the tool window of the PDEModelingDSL that is used for plugins.
	/// 
	/// This is the abstract base class.
	/// </summary>
	public abstract class PDEModelingDSLPluginsVMToolWindowBase : DslEditorShell::ModelToolWindowPane
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        protected PDEModelingDSLPluginsVMToolWindowBase()
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