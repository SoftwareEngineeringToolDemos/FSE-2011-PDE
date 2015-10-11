using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Data for the ActiveViewChangedEvent.
    /// </summary>
    public class ActiveViewChangedEventArgs : ViewModelEventArgs
    {
        bool isActive;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        /// <param name="isActive">True if the view model is the current active view. False otherwise.</param>
        public ActiveViewChangedEventArgs(BaseViewModel sourceViewModel, bool isActive)
            : base(sourceViewModel)
        {
            this.isActive = isActive;
        }

        /// <summary>
        /// Gets whether the view is the current active view or not.
        /// </summary>
        public bool IsActive
        {
            get { return this.isActive; }
        }
    }
}
