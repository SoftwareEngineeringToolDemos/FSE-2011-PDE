using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Data for the CloseViewModelRequestEvent.
    /// </summary>
    public class CloseViewModelRequestEventArgs : ViewModelEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        public CloseViewModelRequestEventArgs(BaseDockingViewModel sourceViewModel)
            : this(sourceViewModel, false)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        /// <param name="bRemove"></param>
        public CloseViewModelRequestEventArgs(BaseDockingViewModel sourceViewModel, bool bRemove)
            : base(sourceViewModel)
        {
            this.ShouldRemoveVM = bRemove;
        }

        /// <summary>
        /// Gets wether the specified VM should be removed or not.
        /// </summary>
        public bool ShouldRemoveVM
        {
            get;
            private set;
        }
    }
}
