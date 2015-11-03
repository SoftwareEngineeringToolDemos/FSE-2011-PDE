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

namespace Tum.TestLanguage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Tum.TestLanguage.View.DslEditorMainWindow
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
    }
}
