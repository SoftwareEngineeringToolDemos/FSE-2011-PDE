using System;

using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model for any view model that is displayed in a popup window.
    /// </summary>
    /// <remarks>
    /// Partss from the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public abstract class BaseWindowViewModel : BaseHostingViewModel
    {
        private DelegateCommand<object> closeActivePopUpCommand;
        private DelegateCommand closeCommand;

        /// <summary>
        /// This event should be raised to close the view.  Any view tied to this
        /// ViewModel should register a handler on this event and close itself when
        /// this event is raised.  If the view is not bound to the lifetime of the
        /// ViewModel then this event can be ignored.
        /// </summary>
        public event EventHandler<CloseRequestEventArgs> CloseRequest;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseWindowViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            closeCommand = new DelegateCommand(OnWindowClose);
            closeActivePopUpCommand = new DelegateCommand<object>(OnCloseActivePopUp);
        }

        /// <summary>
        /// CloseCommand : Window Lifetime command
        /// </summary>
        public DelegateCommand CloseCommand
        {
            get { return closeCommand; }
        }

        /// <summary>
        /// CloseCommand : Close popup command
        /// </summary>
        public DelegateCommand<object> CloseActivePopUpCommand
        {
            get { return closeActivePopUpCommand; }
        }

        /// <summary>
        /// This raises the CloseRequest event to close the UI.
        /// </summary>
        public virtual void RaiseCloseRequest()
        {
            EventHandler<CloseRequestEventArgs> handlers = CloseRequest;

            // Invoke the event handlers
            if (handlers != null)
            {
                try
                {
                    handlers(this, new CloseRequestEventArgs(null));
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// This raises the CloseRequest event to close the UI.
        /// </summary>
        public virtual void RaiseCloseRequest(bool? dialogResult)
        {
            EventHandler<CloseRequestEventArgs> handlers = CloseRequest;

            // Invoke the event handlers
            if (handlers != null)
            {
                try
                {
                    handlers(this, new CloseRequestEventArgs(dialogResult));
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Allows Window.Close hook
        /// </summary>
        protected virtual void OnWindowClose()
        {
            //Should be overriden if required in inheritors
        }

        /// <summary>
        /// Raises RaiseCloseRequest event, passing back correct DialogResult
        /// </summary>
        private void OnCloseActivePopUp(object param)
        {
            if (param is Boolean)
            {
                // Close the dialog using DialogResult requested
                RaiseCloseRequest((bool)param);
                return;
            }

            //param is not a bool so try and parse it to a Bool
            Boolean popupAction = true;
            Boolean result = Boolean.TryParse(param.ToString(), out popupAction);
            if (result)
            {
                // Close the dialog using DialogResult requested
                RaiseCloseRequest(popupAction);
            }
            else
            {
                // Close the dialog passing back true
                RaiseCloseRequest(true);
            }
        }
    }

    /// <summary>
    /// This is used to send result parameters to a CloseRequest
    /// </summary>
    public class CloseRequestEventArgs : EventArgs
    {
        ///<summary>
        /// Final result for ShowDialog
        ///</summary>
        public bool? Result { get; private set; }

        internal CloseRequestEventArgs(bool? result)
        {
            Result = result;
        }
    }
}
