using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon
{
    /// <summary>
    /// Ribbon tab item providing late initialization.
    /// </summary>
    public class RibbonTabItemLateInit : Fluent.RibbonTabItem
    {
        bool bVisibleFirstTimeInitialized = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RibbonTabItemLateInit()
        {
            this.IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(RibbonTabItem_IsVisibleChanged);
        }

        void RibbonTabItem_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (!bVisibleFirstTimeInitialized)
            {
                bVisibleFirstTimeInitialized = true;
                this.IsVisibleChanged -= new System.Windows.DependencyPropertyChangedEventHandler(RibbonTabItem_IsVisibleChanged);
                
                // Call event to initialize the control
                OnLateInitializationTriggered(new EventArgs());
            }
        }

        /// <summary>
        /// Fires when the tab item needs to initialize itself.
        /// </summary>
        public event EventHandler LateInitializationTriggered;

        /// <summary>
        /// Called when initialization should processed.
        /// </summary>
        /// <param name="e"></param>
        protected void OnLateInitializationTriggered(EventArgs e)
        {
            if (LateInitializationTriggered != null)
                LateInitializationTriggered(this, e);
        }
    }
}
