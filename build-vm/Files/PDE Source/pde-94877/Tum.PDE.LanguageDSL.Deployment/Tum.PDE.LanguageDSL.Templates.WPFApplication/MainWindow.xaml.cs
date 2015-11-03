using System;
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

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace $LanguageNamespace$
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : $LanguageNamespace$.View.DslEditorMainWindow
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
            : base()
        {
            InitializeComponent();
            Initialize();     

            // Load process:
            // if "DoLoadInBackground" is set to true (which it is by default), do not 
            // access the MainViewModel variable in the constructor --> will lead to a deadlock,
            // since the initialization of MainViewModel will start in a separate thread that is
            // invoked on the ui thread in the background

            // Load process modification:
            // DoLoadInBackground: true (default) loads assemblies in the background
            // DoLoadInBackground: false loads the main ui directly
            // DoShowWelcomeScreen: true (default) shows welcome screen instead of the main ui (only if DoLoadInBackground is set to true).

            // Ribbon modifications:
            // 1. Override methods creating specific tabs. If any of the default tab is not required,
            //    return null in the creation method
            //    protected override RibbonTabItem CreateRibbonViewTab(Ribbon ribbon) { return null; }
            // 2. Override CreateRibbon to extend the ribbon: new tabs, ...
        }

        /// <summary>
        /// Docking host control.
        /// </summary>
        public override ContentControl DockingHostControl
        {
            get { return this.dockingCtrl; }
        }

        /// <summary>
        /// Ribbon host conrtrol.
        /// </summary>
        public override ContentControl RibbonHostControl
        {
            get { return this.ribbonContentCtrl; }
        }
        
        /// <summary>
        /// Register windows..
        /// </summary>
        protected override void RegisterWindows()
        {
            base.RegisterWindows();
        }
    }
}
