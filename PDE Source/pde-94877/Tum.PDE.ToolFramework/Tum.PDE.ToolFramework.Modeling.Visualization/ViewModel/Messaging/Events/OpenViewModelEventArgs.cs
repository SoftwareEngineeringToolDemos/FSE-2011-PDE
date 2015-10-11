using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Data for the ShowViewModelRequestEvent.
    /// </summary>
    public class OpenViewModelEventArgs : ViewModelEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModelToOpen">View model that needs to be opened.</param>
        public OpenViewModelEventArgs(BaseDockingViewModel viewModelToOpen)
            : this(null, viewModelToOpen)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        /// <param name="viewModelToOpen">View model that needs to be opened.</param>
        public OpenViewModelEventArgs(BaseDockingViewModel sourceViewModel, BaseDockingViewModel viewModelToOpen)
            : base(sourceViewModel)
        {
            DockingPaneStyle = DockingPaneStyle.Docked;
            DockingPaneAnchorStyle = DockingPaneAnchorStyle.None;

            this.ViewModelToOpen = viewModelToOpen;
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
        /// Gets or sets the view model that needs to be opened.
        /// </summary>
        public BaseDockingViewModel ViewModelToOpen
        {
            get;
            set;
        }
    }
}
