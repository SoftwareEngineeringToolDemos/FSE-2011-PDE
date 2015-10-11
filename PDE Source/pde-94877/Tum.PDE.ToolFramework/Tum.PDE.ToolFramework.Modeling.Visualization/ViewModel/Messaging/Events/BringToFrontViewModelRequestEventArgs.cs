using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Data for the BringToFrontViewModelRequestEvent.
    /// </summary>
    public class BringToFrontViewModelRequestEventArgs : ViewModelEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        public BringToFrontViewModelRequestEventArgs(BaseDockingViewModel sourceViewModel)
            : base(sourceViewModel)
        {
        }
    }
}
