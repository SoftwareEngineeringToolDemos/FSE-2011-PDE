using System;
using System.Collections.ObjectModel;
using System.Linq;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

using PDEResources = Tum.PDE.ToolFramework.Modeling.Visualization.Properties;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search
{
    /// <summary>
    /// This class represents a search result view model.
    /// </summary>
    public abstract class SearchResultViewModel : BaseDockingViewModel
    {
        private ObservableCollection<SearchResultItemViewModel> searchResultViewModels;
        private SearchResultItemViewModel searchSelectedElement = null;
        
        private string searchOptionsSummary;
        private string searchResultSummary;

        private SearchResultSortOrder sortOrder;
        private bool isAscending;

        private DelegateCommand navigateCommand;
        private DelegateCommand sortByNameCommand;
        private DelegateCommand sortByReasonCommand;
        private DelegateCommand sortByPathCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SearchResultViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            searchResultViewModels = new ObservableCollection<SearchResultItemViewModel>();

            this.sortOrder = Search.SearchResultSortOrder.Name;
            this.isAscending = true;

            navigateCommand = new DelegateCommand(NavigateCommand_Executed);
            sortByNameCommand = new DelegateCommand(SortByNameCommand_Executed);
            sortByReasonCommand = new DelegateCommand(SortByReasonCommand_Executed);
            sortByPathCommand = new DelegateCommand(SortByPathCommand_Executed);

            this.PreInitialize();
        }
        
        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName { get { return "SearchResultViewModel"; } }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle 
        { 
            get 
            { 
                return PDEResources.Resources.SearchResultViewModel_FindResults;
            } 
        }
        #endregion

        /// <summary>
        /// Gets the search result list.
        /// </summary>
        public ObservableCollection<SearchResultItemViewModel> SearchResults
        {
            get
            {
                return this.searchResultViewModels;
            }
        }

        /// <summary>
        /// Gets or sets the selected search result item.
        /// </summary>
        public SearchResultItemViewModel SelectedSearchResultItem
        {
            get
            {
                return this.searchSelectedElement;
            }
            set
            {
                this.searchSelectedElement = value;
                OnPropertyChanged("SelectedSearchResultItem");
            }
        }

        /// <summary>
        /// Gets or sets the search options summary.
        /// </summary>
        public string SearchOptionsSummary
        {
            get
            {
                return this.searchOptionsSummary;
            }
            set
            {
                this.searchOptionsSummary = value;
                OnPropertyChanged("SearchOptionsSummary");
            }
        }

        /// <summary>
        /// Gets or sets the search result summary.
        /// </summary>
        public string SearchResultSummary
        {
            get
            {
                return this.searchResultSummary;
            }
            set
            {
                this.searchResultSummary = value;
                OnPropertyChanged("SearchResultSummary");
            }
        }

        /// <summary>
        /// Sort order in the search result view model.
        /// </summary>
        public SearchResultSortOrder SortOrder
        {
            get
            {
                return this.sortOrder;
            }
            protected set
            {
                this.sortOrder = value;
                OnPropertyChanged("SortOrder");
            }
        }

        /// <summary>
        /// Ascending or descending sort order.
        /// </summary>
        public bool IsSortedAscending
        {
            get { return this.isAscending; }
            protected set
            {
                this.isAscending = value;
                OnPropertyChanged("IsSortedAscending");
            }
        }

        /// <summary>
        /// Navigate Command.
        /// </summary>
        public DelegateCommand NavigateCommand
        {
            get { return this.navigateCommand; }
        }

        /// <summary>
        /// SortByNameCommand Command.
        /// </summary>
        public DelegateCommand SortByNameCommand
        {
            get { return this.sortByNameCommand; }
        }

        /// <summary>
        /// SortByReasonCommand Command.
        /// </summary>
        public DelegateCommand SortByReasonCommand
        {
            get { return this.sortByReasonCommand; }
        }

        /// <summary>
        /// SortByPathCommand Command.
        /// </summary>
        public DelegateCommand SortByPathCommand
        {
            get { return this.sortByPathCommand; }
        }

        /// <summary>
        /// SortByNumberCommand Executed
        /// </summary>
        private void SortByNameCommand_Executed()
        {
            if (SortOrder == SearchResultSortOrder.Name)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = SearchResultSortOrder.Name;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByReason Executed
        /// </summary>
        private void SortByReasonCommand_Executed()
        {
            if (SortOrder == SearchResultSortOrder.Reason)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = SearchResultSortOrder.Reason;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByPathCommand Executed
        /// </summary>
        private void SortByPathCommand_Executed()
        {
            if (SortOrder == SearchResultSortOrder.Path)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = SearchResultSortOrder.Path;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// NvigateToSourceCommand Executed
        /// </summary>
        private void NavigateCommand_Executed()
        {
            if (this.SelectedSearchResultItem != null)
            {
                this.SelectedSearchResultItem.Navigate();
            }
        }

        /// <summary>
        /// Sorts the dependencies list.
        /// </summary>
        /// <param name="order">Order to sort the dependencies list by.</param>
        /// <param name="bAscending">Ascending or descending order.</param>
        public void Sort(SearchResultSortOrder order, bool bAscending)
        {
            IOrderedEnumerable<SearchResultItemViewModel> items = null;
            switch (order)
            {
                case SearchResultSortOrder.Name:
                    if (bAscending)
                        items = this.SearchResults.OrderBy<SearchResultItemViewModel, string>((x) => (x.DomainElementFullName));
                    else
                        items = this.SearchResults.OrderByDescending<SearchResultItemViewModel, string>((x) => (x.DomainElementFullName));
                    break;

                case SearchResultSortOrder.Reason:
                    if (bAscending)
                        items = this.SearchResults.OrderBy<SearchResultItemViewModel, string>((x) => (x.Reason));
                    else
                        items = this.SearchResults.OrderByDescending<SearchResultItemViewModel, string>((x) => (x.Reason));
                    break;

                case SearchResultSortOrder.Path:
                    if (bAscending)
                        items = this.SearchResults.OrderBy<SearchResultItemViewModel, string>((x) => (x.DomainElementParentFullPath));
                    else
                        items = this.SearchResults.OrderByDescending<SearchResultItemViewModel, string>((x) => (x.DomainElementParentFullPath));
                    break;

                default:
                    throw new NotSupportedException();
            }

            ObservableCollection<SearchResultItemViewModel> temp = new ObservableCollection<SearchResultItemViewModel>();
            foreach (SearchResultItemViewModel item in items)
                temp.Add(item);

            this.searchResultViewModels = temp;
            OnPropertyChanged("SearchResults");
        }

        /// <summary>
        /// Reset vm.
        /// </summary>
        protected override void OnReset()
        {
            SearchResults.Clear();
            SelectedSearchResultItem = null;

            base.OnReset();
        }
    }
}
