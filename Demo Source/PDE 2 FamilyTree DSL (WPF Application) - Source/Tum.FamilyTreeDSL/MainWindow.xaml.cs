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

namespace Tum.FamilyTreeDSL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Tum.FamilyTreeDSL.View.DslEditorMainWindow
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
            : base()
        {
            InitializeComponent();
            Initialize();
        }

        public override ContentControl DockingHostControl
        {
            get { return this.dockingCtrl; }
        }
        public override ContentControl RibbonHostControl
        {
            get { return this.ribbonContentCtrl; }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (Tum.PDE.ToolFramework.Modeling.Base.ModelState.IsInDebugState)
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.DumpLog("!!!test.txt");

            base.OnClosing(e);
        }
    }
}
