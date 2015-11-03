using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This is the base class for any view model, which view is displayed in a docking tab (avalon dock).
    /// 
    /// This is used for the model tree, property grid, error list and any custom view the user provides.
    /// </summary>
    public abstract class BaseDockingViewModel : BaseHostingViewModel, IDockableViewModel
    {
        private bool isDockingPaneVisible = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseDockingViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public abstract string DockingPaneName { get; }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public abstract string DockingPaneTitle { get; }

        /// <summary>
        /// Is dockable window visible.
        /// </summary>
        public bool IsDockingPaneVisible
        {
            get { return isDockingPaneVisible; }
            set
            {
                isDockingPaneVisible = value;
                OnPropertyChanged("IsDockingPaneVisible");
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets whether this view is the currently active view in the application.
        /// </summary>
        public override bool IsActiveView
        {
            get { return base.IsActiveView; }
            set
            {
                base.IsActiveView = value;

                // notify other views of change
                EventManager.GetEvent<ActiveViewChangedEvent>().Publish(new ActiveViewChangedEventArgs(this, this.IsActiveView));
            }
        }
    }
}
