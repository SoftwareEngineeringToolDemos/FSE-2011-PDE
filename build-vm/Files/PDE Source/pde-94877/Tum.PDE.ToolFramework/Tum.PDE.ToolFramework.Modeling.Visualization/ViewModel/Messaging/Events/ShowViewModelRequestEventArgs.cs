using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Data for the ShowViewModelRequestEvent.
    /// </summary>
    public class ShowViewModelRequestEventArgs : ViewModelEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        public ShowViewModelRequestEventArgs(BaseDockingViewModel sourceViewModel)
            : base(sourceViewModel)
        {
            DockingPaneStyle = DockingPaneStyle.Docked;
            DockingPaneAnchorStyle = DockingPaneAnchorStyle.None;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewName">View model name.</param>
        public ShowViewModelRequestEventArgs(string viewName)
            : base(null)
        {
            DockingPaneStyle = DockingPaneStyle.Docked;
            DockingPaneAnchorStyle = DockingPaneAnchorStyle.None;

            this.ViewName = viewName;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        /// <param name="viewName">View model name.</param>
        public ShowViewModelRequestEventArgs(BaseDockingViewModel sourceViewModel, string viewName)
            : base(sourceViewModel)
        {
            DockingPaneStyle = DockingPaneStyle.Docked;
            DockingPaneAnchorStyle = DockingPaneAnchorStyle.None;

            this.ViewName = viewName;
        }

        /// <summary>
        /// Gets the docking pane style.
        /// </summary>
        public DockingPaneStyle DockingPaneStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the docking pane anchor style.
        /// </summary>
        public DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        public string ViewName
        {
            get;
            set;
        }
    }
}
