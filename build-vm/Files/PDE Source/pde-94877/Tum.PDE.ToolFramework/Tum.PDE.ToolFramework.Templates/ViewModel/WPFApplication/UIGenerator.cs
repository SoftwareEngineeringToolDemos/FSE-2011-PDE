﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Tum.PDE.ToolFramework.Templates.ViewModel.WPFApplication
{
    using Tum.PDE.LanguageDSL;
    using Microsoft.VisualStudio.Modeling;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System;
    
    
    #line 1 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class UIGenerator : BaseTemplate
    {
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
        public override string TransformText()
        {
            this.GenerationEnvironment = null;
            this.Write(" \r\n");
            
            #line 9 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
 
	GenerateUI(this.MetaModel);

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 12 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
 
public void GenerateUI(MetaModel dm)
{

        
        #line default
        #line hidden
        
        #line 15 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ");

        
        #line default
        #line hidden
        
        #line 30 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Namespace));

        
        #line default
        #line hidden
        
        #line 30 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(@".ViewModel;

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorContracts = Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using DslEditorControls =  Tum.PDE.ToolFramework.Modeling.Visualization.Controls;
using DslEditorPopups   = Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Popups;
using DslEditorServices = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorCommands = Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorDiagramSurface = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

using DslEditorContractsBase = Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts;

");

        
        #line default
        #line hidden
        
        #line 45 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"

	if( dm.LanguageType == LanguageType.WPFEditor || dm.LanguageType == LanguageType.VMXEditor)
	{

        
        #line default
        #line hidden
        
        #line 48 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\r\nnamespace ");

        
        #line default
        #line hidden
        
        #line 50 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Namespace));

        
        #line default
        #line hidden
        
        #line 50 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(".View\r\n{\r\n\t/// <summary>\r\n    /// This class is used as a base class for the main" +
        " window of the editor.\r\n    /// </summary>\r\n\tpublic abstract class DslEditorMain" +
        "Window : Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.PDEMainWindo" +
        "w\r\n\t{\r\n\t    // Loading Process:\r\n        // 1. DoLoadInBackground = true\r\n      " +
        "  //    a. Create main welcome vm\r\n        //    b. DoShowWelcomeScreen = true -" +
        "-> GetWelcomeWindow() as main content\r\n        //    c. once ribbon has been cre" +
        "ated --> start loading data in background\r\n        // 2. DoLoadInBackground = fa" +
        "lse\r\n        //    a. Invoke loading on background ui thread\r\n        //    b. l" +
        "oad data, main vm --> load model (will invoke loading ui)\r\n\r\n        // on first" +
        " activated --> create ribbon control\r\n        // once ribbon control is loaded -" +
        "-> check if main ui has loaded or subscribe \r\n        // to requests to open a m" +
        "odel from WelcomeVM\r\n        // --> if either of this is the case --> load main " +
        "ui\r\n\t\r\n\t\t#region Field and Properties\r\n        /// <summary>\r\n        /// Import" +
        "ed plugins which suffice to the IPlugin interface.\r\n        /// </summary>\r\n\t\t[S" +
        "ystem.ComponentModel.Composition.ImportMany(typeof(DslEditorContracts::IPlugin))" +
        "]\r\n        public System.Collections.Generic.List<DslEditorContracts::IPlugin> S" +
        "implePlugins { get; set; }\r\n\r\n\t\t/// <summary>\r\n        /// Imported plugins whic" +
        "h suffice to the IPlugin interface.\r\n        /// </summary>\r\n\t\t[System.Component" +
        "Model.Composition.ImportMany(typeof(DslEditorContracts::IModelPlugin))]\r\n       " +
        " public System.Collections.Generic.List<DslEditorContracts::IModelPlugin> Simple" +
        "ModelPlugins { get; set; }\r\n\t\r\n\t\t/// <summary>\r\n        /// Imported plugins whi" +
        "ch suffice to the IViewModelPlugin interface.\r\n        /// </summary>\r\n        [" +
        "System.ComponentModel.Composition.ImportMany(typeof(DslEditorContracts::IViewMod" +
        "elPlugin))]\r\n        public System.Collections.Generic.List<DslEditorContracts::" +
        "IViewModelPlugin> ViewModelPlugins { get; set; }\r\n\t\t\r\n        /// <summary>\r\n   " +
        "     /// Plugins directory.\r\n        /// </summary>\r\n        public const string" +
        " PluginsDirectory = \"plugins\";\r\n        \r\n\t\t\r\n\t\t/// <summary>\r\n        /// Gets " +
        "the name of the current editor.\r\n        /// </summary>\r\n        public override" +
        " string AppName\r\n        {\r\n            get\r\n            {\r\n                retu" +
        "rn \"");

        
        #line default
        #line hidden
        
        #line 103 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.ApplicationName));

        
        #line default
        #line hidden
        
        #line 103 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\";\r\n            }\r\n        }\r\n\t\t\r\n\t\t/// <summary>\r\n        /// Gets the name of t" +
        "he company providing this editor.\r\n        /// </summary>\r\n        public overri" +
        "de string Company\r\n\t\t{\r\n\t        get\r\n    \t    {\r\n        \t    return \"");

        
        #line default
        #line hidden
        
        #line 114 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.CompanyName));

        
        #line default
        #line hidden
        
        #line 114 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\";\r\n        \t}\t\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n        /// Gets the version of the ed" +
        "itor.\r\n        /// </summary>\r\n        public override string Version\r\n        {" +
        "\r\n            get\r\n            {\r\n");

        
        #line default
        #line hidden
        
        #line 125 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"

			string version = "";
			if( !String.IsNullOrEmpty(dm.MajorVersion) && !String.IsNullOrWhiteSpace(dm.MajorVersion))
			{
				version = dm.MajorVersion;
				if( !String.IsNullOrEmpty(dm.MinorVersion) && !String.IsNullOrWhiteSpace(dm.MinorVersion))
				{
					version += "." + dm.MinorVersion;
					if( !String.IsNullOrEmpty(dm.Build) && !String.IsNullOrWhiteSpace(dm.Build))
					{
						version += "." + dm.Build;
						if( !String.IsNullOrEmpty(dm.Revision) && !String.IsNullOrWhiteSpace(dm.Revision))
						{
							version += "." + dm.Revision;
						}
					}					
				}				
			}

        
        #line default
        #line hidden
        
        #line 143 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\t\t\t\r\n                return \"");

        
        #line default
        #line hidden
        
        #line 144 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(version));

        
        #line default
        #line hidden
        
        #line 144 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\";\r\n            }\r\n        }\r\n\t\t\r\n\t\t\r\n        /// <summary>\r\n        /// VModellX" +
        "T Main view model.\r\n        /// </summary>\r\n        public new ");

        
        #line default
        #line hidden
        
        #line 152 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 152 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("MainViewModel MainViewModel\r\n        {\r\n            get\r\n            {\r\n         " +
        "       return (");

        
        #line default
        #line hidden
        
        #line 156 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 156 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("MainViewModel)base.MainViewModel;\r\n            }\r\n            set\r\n            {\r" +
        "\n                base.MainViewModel = value;\r\n            }\r\n        }\r\n\r\n      " +
        "  /// <summary>\r\n        /// Welcome view model.\r\n        /// </summary>\r\n      " +
        "  public new ");

        
        #line default
        #line hidden
        
        #line 167 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 167 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("WelcomeViewModel WelcomeViewModel\r\n        {\r\n            get\r\n\t\t\t{\r\n\t\t\t\treturn (" +
        "");

        
        #line default
        #line hidden
        
        #line 171 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 171 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("WelcomeViewModel)base.WelcomeViewModel;\r\n\t\t\t}\r\n            set\r\n\t\t\t{\r\n\t\t\t\tbase.We" +
        "lcomeViewModel = value;\r\n\t\t\t}\r\n        }\r\n\t\t\r\n        /// <summary>\r\n        ///" +
        " Doc data.\r\n        /// </summary>\r\n        public new ");

        
        #line default
        #line hidden
        
        #line 182 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 182 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("DocumentData DocData\r\n        {\r\n            get\r\n\t\t\t{\r\n\t\t\t\treturn (");

        
        #line default
        #line hidden
        
        #line 186 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 186 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(@"DocumentData)base.DocData;
			}
            set
			{
				base.DocData = value;
			}
        }
		#endregion
		
		/// <summary>
        /// Constructor.
        /// </summary>
		public DslEditorMainWindow()
		{        
        }
		
		/// <summary>
        /// Creates the welcome vm.
        /// </summary>
        /// <returns></returns>
        protected override DslEditorContractsBase::IMainWelcomeViewModel CreateWelcomeViewModel()
		{
			return new ");

        
        #line default
        #line hidden
        
        #line 208 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 208 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("WelcomeViewModel(AppDataDirectory + System.IO.Path.DirectorySeparatorChar + ");

        
        #line default
        #line hidden
        
        #line 208 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 208 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("ViewModelOptions.OptionsFileName);\r\n\t\t}\r\n\t\t\r\n\t\t/// <summary>\r\n        /// Initial" +
        "ize services\r\n        /// </summary>\r\n        protected override void Initialize" +
        "Services()\r\n\t\t{\r\n            // Initialize base services on the main thread.\r\n  " +
        "          Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.BaseViewModel.S" +
        "etupServices(); \r\n\t\t}\r\n\r\n        /// <summary>\r\n        /// Register windows..\r\n" +
        "        /// </summary>\r\n        protected override void RegisterWindows()\r\n     " +
        "   {\r\n\t\t\t// Register known windows\r\n\t\t\tDslEditorServices::IUIVisualizerService p" +
        "opupVisualizer = MainViewModel.GlobalServiceProvider.Resolve<DslEditorServices::" +
        "IUIVisualizerService>();\t\t\t\t\r\n\t\t\tpopupVisualizer.TryRegister(\"SelectElementPopup" +
        "\", typeof(DslEditorPopups::SelectElementPopup));\r\n\t\t\tpopupVisualizer.TryRegister" +
        "(\"DeleteElementsPopup\", typeof(DslEditorPopups::DeleteElementsPopup));\t\t\t\t\r\n\t\t\tp" +
        "opupVisualizer.TryRegister(\"SelectElementWithRSTypePopup\", typeof(DslEditorPopup" +
        "s::SelectElementWithRSTypePopup));\r\n\t\t\tpopupVisualizer.TryRegister(\"SelectRSType" +
        "Popup\", typeof(DslEditorPopups::SelectRSTypePopup));\r\n        }\r\n\r\n        /// <" +
        "summary>\r\n        /// Switch model context for the main VM if required.\r\n       " +
        " /// </summary>\r\n        protected override void SwitchModelContextIfRequired()\r" +
        "\n\t\t{\r\n\t\t\t// change model context if required\r\n            if (this.WelcomeViewMo" +
        "del != null && this.DoLoadInBackground)\r\n                if (this.WelcomeViewMod" +
        "el.SelectedModelContextViewModel != null)\r\n                    for (int i = 0; i" +
        " < this.MainViewModel.AvailableModelModelContextViewModels.Count; i++)\r\n        " +
        "                if (this.MainViewModel.AvailableModelModelContextViewModels[i].M" +
        "odelContext != null)\r\n                            if (this.MainViewModel.Availab" +
        "leModelModelContextViewModels[i].ModelContext.Name == this.WelcomeViewModel.Sele" +
        "ctedModelContextViewModel.Name)\r\n                            {\r\n                " +
        "                this.MainViewModel.SelectedModelContextViewModel = this.MainView" +
        "Model.AvailableModelModelContextViewModels[i];\r\n                                " +
        "break;\r\n                            }\r\n\t\t}\r\n\t\t\t\t\r\n\t \t/// <summary>\r\n        /// " +
        "Gets the main UI control.\r\n        /// </summary>\r\n        /// <returns></return" +
        "s>\r\n        protected override System.Windows.FrameworkElement GetMainUIControl(" +
        ")\r\n\t\t{\r\n\t\t\treturn this.MainViewModel.LayoutManager.MainDockingManager;\r\n\t\t}\r\n\t\t\t" +
        "\t\r\n        /// <summary>\r\n        /// Creates and assings doc data.\r\n        ///" +
        " </summary>\r\n        protected override void CreateAndAssignDocData()\r\n\t\t{\r\n\t\t\tD" +
        "ocData = new ");

        
        #line default
        #line hidden
        
        #line 264 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 264 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("DocumentData();\r\n\t\t}\r\n\t\t        \r\n\t\t/// <summary>\r\n        /// Creates and assing" +
        "s the main view model.\r\n        /// </summary>\r\n        protected override void " +
        "CreateAndAssignMainViewModel()\r\n\t\t{\t\t\t\t\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 272 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 272 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("ViewModelStore vStore;\r\n\t\t\tif( this.WelcomeViewModel != null )\r\n\t\t\t\tvStore = new " +
        "");

        
        #line default
        #line hidden
        
        #line 274 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 274 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("ViewModelStore((");

        
        #line default
        #line hidden
        
        #line 274 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 274 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("DocumentData)DocData, WelcomeViewModel.Options);\r\n\t\t\telse\r\n\t\t\t\tvStore = new ");

        
        #line default
        #line hidden
        
        #line 276 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 276 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("ViewModelStore((");

        
        #line default
        #line hidden
        
        #line 276 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 276 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("DocumentData)DocData);\r\n\t\t\t\r\n\t        MainViewModel = new ");

        
        #line default
        #line hidden
        
        #line 278 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 278 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("MainViewModel(vStore);\r\n\t\t}\r\n\t\t\r\n        /// <summary>\r\n        /// Register impo" +
        "rted resources.\r\n        /// </summary>\r\n        protected override void Registe" +
        "rImportedResources()\r\n\t\t{\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 286 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(dm.Name));

        
        #line default
        #line hidden
        
        #line 286 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("MainViewModelBase.RegisterImportedLibrariesRessources(new System.Collections.Gene" +
        "ric.List<string>());\r\n\t\t}\r\n\t\t\r\n        /// <summary>\r\n        /// Post process m" +
        "ain vm init.\r\n        /// </summary>\r\n        /// <remarks>\r\n        /// Before " +
        "SetViewModel was called, layout manager was already initialized (possible, since" +
        " in\r\n        /// some cases, this is called on the ui thread in the background -" +
        "-> queued for execution)\r\n        /// </remarks>\r\n        protected override voi" +
        "d PostProcessLMIfRequired()\r\n\t\t{\r\n            if (this.MainViewModel.LayoutManag" +
        "er != null)\r\n                this.ViewModel_LayoutManagerInitialized(null, null)" +
        ";\t\t\t\r\n\t\t}\r\n\t\t\r\n\t\t#region Plugins\r\n\t\t/// <summary>\r\n        /// Load plugins in b" +
        "ackground.\r\n        /// </summary>\r\n        public override void LoadPlugins()\r\n" +
        "        {\r\n            // load plugins\r\n            System.ComponentModel.Backgr" +
        "oundWorker w = new System.ComponentModel.BackgroundWorker();\r\n            w.DoWo" +
        "rk += new System.ComponentModel.DoWorkEventHandler(loadPlugins_DoWork);\r\n       " +
        "     w.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHa" +
        "ndler(loadPlugins_RunWorkerCompleted);\r\n            w.RunWorkerAsync();\r\n       " +
        " }\t\r\n\t\t\r\n\t\t/// <summary>\r\n        /// Add plugins data in background.\r\n        /" +
        "// </summary>\r\n        public void LoadPluginsPostProcess()\r\n\t\t{\r\n            if" +
        " (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)\r\n              " +
        "  Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent(\"Load plugins progess: " +
        "start processing\");\r\n\r\n\t\t\tif( SimplePlugins != null )\r\n            if (SimplePlu" +
        "gins.Count > 0)\r\n            {\r\n                try\r\n                {\r\n        " +
        "            foreach (DslEditorContracts::IPlugin plugin in SimplePlugins)\r\n     " +
        "                   foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewMod" +
        "el.ModelContextViewModel mcVM in MainViewModel.AvailableModelModelContextViewMod" +
        "els)\r\n                        {\r\n                            if (plugin.ModelCon" +
        "text == mcVM.ModelContext.Name || plugin.ModelContext == null)\r\n                " +
        "                mcVM.AddPlugin(plugin);\r\n                        }\r\n            " +
        "    }\r\n                catch (System.Exception ex)\r\n                {\r\n         " +
        "           Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError(\"Load plugins " +
        "progess: simple plugins (1) processed error: \" + ex.Message);\r\n                }" +
        "\r\n\t\t\t\t\r\n\t\t\t\t\r\n\t\t\t\tif( this.tabPlugins != null )\r\n\t\t\t\t{\r\n\t\t\t\t\tif (this.tabPlugins" +
        "GrpFP != null)\r\n                \t{\r\n                    \ttabPluginsGrpFP.Visibil" +
        "ity = System.Windows.Visibility.Visible;\r\n                \t}\r\n\t\t\t\t\telse if( this" +
        ".MainViewModel.LayoutManager != null )\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tCreateRibbonFPGroup();\r\n\t\t" +
        "\t\t\t}\r\n\t\t\t\t}\r\n            }\r\n\r\n            if (Tum.PDE.ToolFramework.Modeling.Bas" +
        "e.ModelState.IsInDebugState)\r\n                Tum.PDE.ToolFramework.Modeling.Bas" +
        "e.LogHelper.LogEvent(\"Load plugins progess: simple plugins processed\");\r\n\t\t\t\r\n\t\t" +
        "\tif( SimpleModelPlugins != null )\r\n            if (SimpleModelPlugins.Count > 0)" +
        "\r\n            {\r\n                try\r\n                {\r\n                    for" +
        "each (DslEditorContracts::IModelPlugin plugin in SimpleModelPlugins)\r\n          " +
        "              foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Mo" +
        "delContextViewModel mcVM in MainViewModel.AvailableModelModelContextViewModels)\r" +
        "\n                        {\r\n                            if (plugin.ModelContext " +
        "== mcVM.ModelContext.Name || plugin.ModelContext == null)\r\n                     " +
        "           mcVM.AddPlugin(plugin);\r\n\r\n                            plugin.SetView" +
        "ModelStore(MainViewModel.ViewModelStore);\r\n                        }\r\n          " +
        "      }\r\n                catch (System.Exception ex)\r\n                {\r\n       " +
        "             Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError(\"Load plugin" +
        "s progess: simple plugins (2) processed error: \" + ex.Message);\r\n               " +
        " }\r\n                \r\n\t\t\t\tif( this.tabPlugins != null )\r\n\t\t\t\t{\r\n\t\t\t\t\tif (this.ta" +
        "bPluginsGrpFP != null)\r\n                \t{\r\n                    \ttabPluginsGrpFP" +
        ".Visibility = System.Windows.Visibility.Visible;\r\n                \t}\r\n\t\t\t\t\telse " +
        "if( this.MainViewModel.LayoutManager != null )\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\tCreateRibbonFPGrou" +
        "p();\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n            }\r\n\r\n            if (Tum.PDE.ToolFramework.Mode" +
        "ling.Base.ModelState.IsInDebugState)\r\n                Tum.PDE.ToolFramework.Mode" +
        "ling.Base.LogHelper.LogEvent(\"Load plugins progess: simple model plugins process" +
        "ed\");\r\n\t\t\t\r\n\t\t\tif( ViewModelPlugins != null )\r\n            if (ViewModelPlugins." +
        "Count > 0)\r\n            {\r\n                foreach (DslEditorContracts::IViewMod" +
        "elPlugin plugin in ViewModelPlugins)\r\n                {\r\n                    try" +
        "\r\n                    {\r\n                        DslEditorDiagramSurface::BaseDi" +
        "agramSurfaceViewModel vm = plugin.GetViewModel(MainViewModel.ViewModelStore);\r\n " +
        "                       if (vm != null)\r\n                        {\r\n             " +
        "               vm.VMPlugin = plugin;\r\n\r\n                            foreach (Tum" +
        ".PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM i" +
        "n MainViewModel.AvailableModelModelContextViewModels)\r\n                         " +
        "       if (plugin.ModelContext == null)\r\n                                    mcV" +
        "M.AddPluginViewModel(vm);\r\n                                else if (plugin.Model" +
        "Context == mcVM.ModelContext.Name)\r\n                                    mcVM.Add" +
        "PluginViewModel(vm);\r\n                        }\r\n                    }\r\n        " +
        "            catch (System.Exception ex)\r\n                    {\r\n                " +
        "        Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError(\"Load plugins pro" +
        "gess: vm plugins processed error: \" + ex.Message);\r\n                    }\r\n\r\n\r\n\t" +
        "\t\t\t\tif( this.tabPlugins != null )\r\n\t\t\t\t\t{\r\n                \t\tif (this.tabPlugins" +
        "GrpVP != null)\r\n                \t\t{\r\n\t                    \ttabPluginsGrpVP.Visib" +
        "ility = System.Windows.Visibility.Visible;\r\n                \t\t}\r\n\t\t\t\t\t\telse if( " +
        "this.MainViewModel.LayoutManager != null )\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\tCreateRibbonVPGroup(" +
        ");\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n                }\r\n            }\r\n\r\n            if (Tum.PDE" +
        ".ToolFramework.Modeling.Base.ModelState.IsInDebugState)\r\n                Tum.PDE" +
        ".ToolFramework.Modeling.Base.LogHelper.LogEvent(\"Load plugins progess: view mode" +
        "l plugins processed\");\r\n\t\t}\r\n\t\t        \r\n\t\tvoid loadPlugins_RunWorkerCompleted(o" +
        "bject sender, System.ComponentModel.RunWorkerCompletedEventArgs e)\r\n        {\r\n " +
        "           System.Windows.Application.Current.Dispatcher.Invoke(\r\n              " +
        "  System.Windows.Threading.DispatcherPriority.Background, new System.Action(Load" +
        "PluginsPostProcess));\r\n        }\r\n\r\n        void loadPlugins_DoWork(object sende" +
        "r, System.ComponentModel.DoWorkEventArgs e)\r\n        {\r\n            try\r\n       " +
        "     {\r\n\t\t\t\t// Load plugins\r\n\t\t\t\tif (!System.IO.Directory.Exists(PluginsDirector" +
        "y))\r\n                \tSystem.IO.Directory.CreateDirectory(PluginsDirectory);\r\n\t\t" +
        "\t\t\t\r\n\t\t\t\tDirectoryCatalog directoryCatalog = new DirectoryCatalog(PluginsDirecto" +
        "ry);\r\n\t\t\t\tCompositionContainer container = new CompositionContainer(directoryCat" +
        "alog);\r\n\t\t\t\t\r\n\t\t\t\tif( Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugSt" +
        "ate )\r\n\t\t\t\t\tTum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent(\"Load plugins" +
        " progess: compose parts\");\r\n\t\t\t\r\n\t\t\t\tcontainer.ComposeParts(this);\r\n\r\n          " +
        "      if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)\r\n      " +
        "              Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogEvent(\"Load plugi" +
        "ns progess: compose parts done\");\r\n\r\n            }\r\n            catch (System.Ex" +
        "ception ex)\r\n            {\r\n\t\t\t\tTum.PDE.ToolFramework.Modeling.Base.LogHelper.Lo" +
        "gError(\"Load plugins progess error: \" + ex.Message);\r\n            }\r\n\t\t\t\r\n\t\t\t// " +
        "wait for main VM\r\n\t\t\tif( this.MainViewModel != null )\r\n\t\t\t{\r\n\t\t\t}\r\n        }\r\n\t\t" +
        "#endregion\r\n\t\t\r\n\t\t#region Ribbon\r\n");

        
        #line default
        #line hidden
        
        #line 474 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
		
		this.PushIndent("\t\t");
		this.Write(RibbonGeneratorHelper.Instance.GenerateRibbon(this.MetaModel));
		this.PopIndent();		

        
        #line default
        #line hidden
        
        #line 478 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\t\t\r\n\t\t#endregion\r\n\t}\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 482 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"

	}
	else
	{

        
        #line default
        #line hidden
        
        #line 486 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"
this.Write("\r\n// Not generated since it is not required...\r\n\r\n");

        
        #line default
        #line hidden
        
        #line 490 "J:\Uni\CC Processes\Werkzeuge\PDE 2\Tum.PDE.ToolFramework\Tum.PDE.ToolFramework.Templates\ViewModel\WPFApplication\UIGenerator.tt"

	}
}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
