using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// Link item category vm.
    /// </summary>
    public class LinkItemCategoryViewModel : BaseViewModel
    {
        private string category;
        private ObservableCollection<LinkItemViewModel> linkItemVMs;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="category">Category.</param>
        public LinkItemCategoryViewModel(ViewModelStore viewModelStore, string category)
            : base(viewModelStore)
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
        /// Gets or sets link items vms.
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
                OnPropertyChanged("LinkItemVMs");
            }
        }
    }
}
