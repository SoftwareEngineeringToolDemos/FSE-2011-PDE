using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualStudio.Modeling;
using System.Linq;
using System.Collections.Generic;
using System;
using Tum.PDE.VSPluginDSL.ViewModel;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Control enabling the visualization of the model
	/// </summary>
    public partial class MainViewControl : Tum.PDE.VSPluginDSL.View.DslPluginMainControl
	{
		/// <summary>
		/// Constructor
		/// </summary>
        public MainViewControl()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Sets view model.
        /// </summary>
        /// <param name="viewModel">VM.</param>
        public override void SetViewModel(VSPluginDSLMainViewModel viewModel)
        {
            base.SetViewModel(viewModel);

            // change ribbon behavour so that context tabs that become visible are also selected
            InitRibbonControl();
        }

        /// <summary>
        /// Gets the main ribbon.
        /// </summary>
        public override Fluent.Ribbon Ribbon
        {
            get { return this.ribbonControl; }
        }        

        #region Ribbon Control Behaviour
        private Fluent.RibbonTabItem previouslySelectedTab = null;
        void InitRibbonControl()
        {
            foreach (Fluent.RibbonTabItem tab in Ribbon.Tabs)
            {
                tab.IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(RibbonTabItem_IsVisibleChanged);
            }
            this.Ribbon.SelectedTabChanged += new EventHandler(Ribbon_SelectedTabChanged);
        }

        void Ribbon_SelectedTabChanged(object sender, EventArgs e)
        {
            if (this.Ribbon.SelectedTabIndex == -1)
                previouslySelectedTab = this.ribbonControl.SelectedTabItem;
        }
        void RibbonTabItem_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            Fluent.RibbonTabItem tab = sender as Fluent.RibbonTabItem;
            if (Ribbon.SelectedTabItem == tab && tab.Visibility != System.Windows.Visibility.Visible)
            {
                // selected tab has become invisible, so we need for a different ribbon tab to become selected
                // try to select the previously selected tab if it is visible; if not, just select the first 
                // visible ribbon tab in the collection
                if (previouslySelectedTab != null)
                {
                    if (previouslySelectedTab.IsVisible)
                    {
                        SetSelectedTab(previouslySelectedTab);
                        return;
                    }
                }
                if (Ribbon.Tabs.Count > 0)
                {
                    foreach (Fluent.RibbonTabItem t in Ribbon.Tabs)
                        if (t.Visibility == System.Windows.Visibility.Visible)
                        {
                            SetSelectedTab(t);
                            return;
                        }
                    throw new NotSupportedException("No visible tabs to select in ribbon control!");
                }
                else
                    throw new NotSupportedException("No ribbon tabs in ribbon control!");
            }
            else if (Ribbon.SelectedTabItem != tab && tab.Visibility == System.Windows.Visibility.Visible)
            {
                // a previously invisible tab has become visible, so we assume that it supplies necessary actions in
                // respect of the current context --> make this tab the selected tab of the ribbon
                SetSelectedTab(tab);
            }
        }
        private void SetSelectedTab(Fluent.RibbonTabItem item)
        {
            foreach (Fluent.RibbonTabItem t in Ribbon.Tabs)
                if (t != item)
                {
                    t.IsSelected = false;
                    t.IsOpen = false;
                }

            item.IsSelected = true;
            item.IsOpen = true;
        }
        #endregion
	}
}
