using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Selection changed event data.
    /// </summary>
    public class SelectionChangedEventArgs : ViewModelEventArgs
    {
        SelectedItemsCollection selectedItems;
        object userData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceViewModel">View model that triggers the event.</param>
        /// <param name="selectedComponents">Selected components in that view model.</param>
        public SelectionChangedEventArgs(BaseViewModel sourceViewModel, SelectedItemsCollection selectedItems)
            : base(sourceViewModel)
        {
            this.selectedItems = selectedItems;
            this.userData = null;
        }

        /// <summary>
        /// Gets the selected components.
        /// </summary>
        public SelectedItemsCollection SelectedItems
        {
            get { return this.selectedItems; }
        }

        /// <summary>
        /// Gets or sets specific user data.
        /// </summary>
        public object UserData
        {
            get { return userData; }
            set { userData = value; }
        }
    }
}
