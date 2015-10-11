using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel
{
    /// <summary>
    /// Link item category vm.
    /// </summary>
    public class LinkItemCategoryViewModel : INotifyPropertyChanged
    {
        private string category;
        private ObservableCollection<LinkItemViewModel> linkItemVMs;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="category">Category.</param>
        public LinkItemCategoryViewModel(string category)
        {
            this.category = category;
            this.linkItemVMs = new ObservableCollection<LinkItemViewModel>();
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        public string Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>
        /// Gets or sets the link items vms.
        /// </summary>
        public ObservableCollection<LinkItemViewModel> LinkItemVMs
        {
            get
            {
                return this.linkItemVMs;
            }
            set
            {
                this.linkItemVMs = value;

                this.OnPropertyChanged("LinkItemVMs");
            }
        }


        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property changes.
        /// </summary>
        /// <param name="name">Name of the property, which value changed.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
