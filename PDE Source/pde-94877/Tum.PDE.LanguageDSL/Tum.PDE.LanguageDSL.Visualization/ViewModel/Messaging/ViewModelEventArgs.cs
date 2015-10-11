using System;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging
{
    /// <summary>
    /// Viewmodel event data.
    /// </summary>
    public class ViewModelEventArgs : EventArgs
    {
        BaseViewModel sourceViewModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that is the source of the event invocation.</param>
        public ViewModelEventArgs(BaseViewModel sourceViewModel)
            : base()
        {
            this.sourceViewModel = sourceViewModel;
        }

        /// <summary>
        /// Gets the source view model which triggered the event.
        /// </summary>
        public BaseViewModel SourceViewModel
        {
            get { return this.sourceViewModel; }
        }
    }
}
