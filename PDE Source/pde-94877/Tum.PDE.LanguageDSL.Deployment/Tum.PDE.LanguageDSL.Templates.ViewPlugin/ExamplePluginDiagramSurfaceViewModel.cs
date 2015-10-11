using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Fluent;

using Tum.PDE.ToolFramework.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Converters;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace $safeprojectname$
{
    public class ExamplePluginDiagramSurfaceViewModel : BaseDiagramSurfaceViewModel
    {
        private DelegateCommand command;
        private ExampleElementViewModel selectedItemViewModel;
        private SelectedItemsCollection selectedItemsCollection = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        public ExamplePluginDiagramSurfaceViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, "")
        {
            command = new DelegateCommand(Command_Executed);
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">eventArgs.</param>
        protected override void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            this.selectedItemsCollection = eventArgs.SelectedItems;
            this.SelectedItemViewModel = null;
            

            if (this.IsInitialized && this.IsDockingPaneVisible)
                Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateVM));
        }

        private void UpdateVM()
        {
            if (selectedItemsCollection != null)
                if (selectedItemsCollection.Count == 1)
                    this.SelectedItemViewModel = new ExampleElementViewModel(this.ViewModelStore, selectedItemsCollection[0] as DomainModelElement);
        }

        /// <summary>
        /// Gets or sets the selected item view model.
        /// </summary>
        public ExampleElementViewModel SelectedItemViewModel
        {
            get
            {
                return selectedItemViewModel;
            }
            private set
            {
                this.selectedItemViewModel = value;
                OnPropertyChanged("SelectedItemViewModel");
            }
        }

        /// <summary>
        /// Visibility changed.
        /// </summary>
        /// <param name="bVisible"></param>
        protected override void OnVisibilityChanged(bool bVisible)
        {
            base.OnVisibilityChanged(bVisible);

            if (this.IsDockingPaneVisible && this.IsInitialized)
                Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateVM));
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "ExamplePluginDiagramSurfaceViewModel"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Example View"; }
        }

        /// <summary>
        /// Gets the docking pane style.
        /// </summary>
        public override Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle DockingPaneStyle
        {
            get
            {
                return Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            }
        }
        #endregion

        #region Ribbon
        private RibbonContextualTabGroup exampleTabGroup;

        /// <summary>
        /// Show ribbon menu.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void ShowRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.ShowRibbonMenu(ribbonMenu);
            if (exampleTabGroup != null)
                exampleTabGroup.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Hide ribbon menu.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void HideRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.HideRibbonMenu(ribbonMenu);

            if (exampleTabGroup != null)
                exampleTabGroup.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Create ribbon menus.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void CreateRibbonMenu(Ribbon ribbonMenu)
        {
            base.CreateRibbonMenu(ribbonMenu);

            // in case the tab group is used for multiple vms, prevent multiple tabs beeing created
            foreach (Fluent.RibbonContextualTabGroup t in ribbonMenu.ContextualGroups)
                if (t.Name == "tabGroupExamplePlugin")
                {
                    exampleTabGroup = t;
                    return;
                }

            // contextual tab, which should only be visible when the example diagram surface is active
            exampleTabGroup = new RibbonContextualTabGroup();
            exampleTabGroup.Header = "Example Tab Group";
            exampleTabGroup.BorderBrush = new SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            exampleTabGroup.Background = new SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            exampleTabGroup.Name = "tabGroupExamplePlugin";

            // create ribbon bar and associate it with the contextual group
            RibbonTabItem exampleTab = new RibbonTabItem();
            exampleTab.Header = "Example View Operations";
            exampleTab.Group = exampleTabGroup;

            // Analyze group
            RibbonGroupBox analyzeGroup = new RibbonGroupBox();
            analyzeGroup.Header = "Analyze";
            exampleTab.Groups.Add(analyzeGroup);

            Fluent.Button buttonAnalyze = new Fluent.Button();
            buttonAnalyze.Text = "Analyze";
            buttonAnalyze.Command = this.command;
            buttonAnalyze.Size = RibbonControlSize.Large;
            buttonAnalyze.LargeIcon = GetImage("prepare_32.png");
            analyzeGroup.Items.Add(buttonAnalyze);

            // View group
            RibbonGroupBox viewGroup = new RibbonGroupBox();
            viewGroup.Header = "View";
            exampleTab.Groups.Add(viewGroup);

            Fluent.ToggleButton buttonTree = new Fluent.ToggleButton();
            buttonTree.Text = "Tree";
            buttonTree.LargeIcon = GetImage("tree-32.png");
            viewGroup.Items.Add(buttonTree);

            Fluent.ToggleButton buttonTable = new Fluent.ToggleButton();
            buttonTable.Text = "Table";
            buttonTable.LargeIcon = GetImage("table-32.png");
            viewGroup.Items.Add(buttonTable);

            // Export group
            RibbonGroupBox exportGroup = new RibbonGroupBox();
            exportGroup.Header = "Export";
            exampleTab.Groups.Add(exportGroup);

            Fluent.Button buttonExportCSV = new Fluent.Button();
            buttonExportCSV.Text = "Export as CSV-File";
            buttonExportCSV.Size = RibbonControlSize.Large;
            buttonExportCSV.LargeIcon = GetImage("csv_32x32.png");
            buttonExportCSV.Command = this.command;
            exportGroup.Items.Add(buttonExportCSV);

            Fluent.Button buttonExportHTML = new Fluent.Button();
            buttonExportHTML.Text = "Export as HTML Website";
            buttonExportHTML.Size = RibbonControlSize.Large;
            buttonExportHTML.LargeIcon = GetImage("html_32x32.png");
            buttonExportHTML.Command = this.command;
            exportGroup.Items.Add(buttonExportHTML);

            Fluent.Button buttonExportPDF = new Fluent.Button();
            buttonExportPDF.Text = "Export as PDF Document";
            buttonExportPDF.Size = RibbonControlSize.Large;
            buttonExportPDF.LargeIcon = GetImage("pdf_32x32.png");
            buttonExportPDF.Command = this.command;
            exportGroup.Items.Add(buttonExportPDF);

            ribbonMenu.ContextualGroups.Add(exampleTabGroup);
            ribbonMenu.Tabs.Add(exampleTab);
        }
        private BitmapImage GetImage(string name)
        {
            try
            {
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Width = 32;
                img.Height = 32;
                return new BitmapImage(new Uri("pack://application:,,,/$safeprojectname$;component/Images/" + name, UriKind.Absolute));
            }
            catch
            {
                return null;
            }
        }
        private void Command_Executed()
        {
            IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
            messageBox.ShowInformation("Command executed");
        }
        #endregion
    }
}
