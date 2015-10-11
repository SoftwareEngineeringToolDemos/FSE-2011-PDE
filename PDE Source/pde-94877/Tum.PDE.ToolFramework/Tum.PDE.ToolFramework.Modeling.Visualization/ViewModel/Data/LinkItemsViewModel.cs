using System;
using System.Collections.ObjectModel;
using System.Linq;
using Tum.PDE.ToolFramework.Modeling.Base;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// Base abstract view model class for displaying link items.
    /// </summary>
    public abstract class LinkItemsViewModel : BaseViewModel
    {
        private ObservableCollection<LinkItemViewModel> linkItemVMsWithoutCategory;
        private ObservableCollection<LinkItemCategoryViewModel> linkItemVmsCategorized;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public LinkItemsViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            this.linkItemVMsWithoutCategory = new ObservableCollection<LinkItemViewModel>();
            this.linkItemVmsCategorized = new ObservableCollection<LinkItemCategoryViewModel>();
        }

        /// <summary>
        /// Adds a new link item.
        /// </summary>
        /// <param name="linkItem">Link item to add.</param>
        public void AddLinkItem(LinkItem linkItem)
        {
            if (String.IsNullOrEmpty(linkItem.Category) || String.IsNullOrWhiteSpace(linkItem.Category))
            {
                this.linkItemVMsWithoutCategory.Add(new LinkItemViewModel(this.ViewModelStore, linkItem));

                IOrderedEnumerable<LinkItemViewModel> items = linkItemVMsWithoutCategory.OrderBy<LinkItemViewModel, string>((x) => (x.Titel));
                ObservableCollection<LinkItemViewModel> temp = new ObservableCollection<LinkItemViewModel>();
                foreach (LinkItemViewModel item in items)
                    temp.Add(item);

                this.linkItemVMsWithoutCategory = temp;

                OnPropertyChanged("LinkItemVMsWithoutCategory");
            }
            else
            {
                // find or add category
                int categoryIndex = -1;
                for (int i = 0; i < this.linkItemVmsCategorized.Count; i++)
                    if (this.linkItemVmsCategorized[i].Category == linkItem.Category)
                    {
                        categoryIndex = i;
                        break;
                    }

                if (categoryIndex == -1)
                {
                    this.linkItemVmsCategorized.Add(new LinkItemCategoryViewModel(this.ViewModelStore, linkItem.Category));
                    categoryIndex = this.linkItemVmsCategorized.Count - 1;
                }

                // add item
                this.linkItemVmsCategorized[categoryIndex].LinkItemVMs.Add(new LinkItemViewModel(this.ViewModelStore, linkItem));

                IOrderedEnumerable<LinkItemViewModel> items = this.linkItemVmsCategorized[categoryIndex].LinkItemVMs.OrderBy<LinkItemViewModel, string>((x) => (x.Titel));
                ObservableCollection<LinkItemViewModel> temp = new ObservableCollection<LinkItemViewModel>();
                foreach (LinkItemViewModel item in items)
                    temp.Add(item);

                this.linkItemVmsCategorized[categoryIndex].LinkItemVMs = temp;

                OnPropertyChanged("LinkItemVmsCategorized");
            }
        }

        /// <summary>
        /// Gets the link items vms, which don't find a specific category.
        /// </summary>
        public ObservableCollection<LinkItemViewModel> LinkItemVMsWithoutCategory
        {
            get
            {
                return this.linkItemVMsWithoutCategory;
            }
        }

        /// <summary>
        /// Gets the link item categories sorted by categories.
        /// </summary>
        public ObservableCollection<LinkItemCategoryViewModel> LinkItemVmsCategorized
        {
            get
            {
                return this.linkItemVmsCategorized;
            }
        }

        /// <summary>
        /// Gets whether this view model has any items.
        /// </summary>
        public bool HasLinkItems
        {
            get
            {
                if (HasLinkItemVMsWithoutCategory || HasLinkItemVmsCategorized)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Gets whether there are link items without a category present.
        /// </summary>
        public bool HasLinkItemVMsWithoutCategory
        {
            get
            {
                if (this.LinkItemVMsWithoutCategory.Count > 0)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Gets whether there are link items with a category present.
        /// </summary>
        public bool HasLinkItemVmsCategorized
        {
            get
            {
                if (this.LinkItemVmsCategorized.Count > 0)
                    return true;

                return false;
            }
        }

    }
}
