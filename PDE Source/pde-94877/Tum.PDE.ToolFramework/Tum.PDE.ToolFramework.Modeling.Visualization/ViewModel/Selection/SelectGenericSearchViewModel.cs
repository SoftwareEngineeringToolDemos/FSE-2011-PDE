using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// View model, that allows to search within a generic items collection and select an item.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectGenericSearchViewModel<T> : BaseViewModel, ISelectGenericSubViewModel<T>
        where T : struct
    {
        private DelegateCommand searchCommand;
        private DelegateCommand activatedCommand;

        private IEnumerable<T> selectableElements;
        private string searchText = "";
        private bool isActive = false;

        private Nullable<T> searchSelectedElement;
        private ObservableCollection<T> searchResultViewModels;

        private GenericSearchDelegate<T> searchAction;
        private GenericSortDelegate<T> sortAction;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="selectableElements">
        /// List of existing elements, that are allowed to be selected.
        /// </param>
        /// <param name="searchAction">Search action.</param>
        /// <param name="sortAction">Sort action.</param>
        public SelectGenericSearchViewModel(ViewModelStore viewModelStore, IEnumerable<T> selectableElements, GenericSearchDelegate<T> searchAction, GenericSortDelegate<T> sortAction)
            : base(viewModelStore)
        {
            searchResultViewModels = new ObservableCollection<T>();

            searchCommand = new DelegateCommand(SearchCommand_Executed);
            activatedCommand = new DelegateCommand(ActivatedCommand_Executed);

            this.searchAction = searchAction;
            this.sortAction = sortAction;

            this.selectableElements = selectableElements;

            // 'search' to display all selectableElements in the search list.
            // 'search' to display all selectableElements in the search list.
            Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(SearchCommand_Executed));
        }

        /// <summary>
        /// Gets the search results list.
        /// </summary>
        public ObservableCollection<T> SearchResultViewModels
        {
            get 
            { 
                return searchResultViewModels; 
            }
        }

        /// <summary>
        /// Gets or sets the text to search for.
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// Search command.
        /// </summary>
        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
        }

        /// <summary>
        /// Activated command.
        /// </summary>
        public DelegateCommand ActivatedCommand
        {
            get { return activatedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is active or not.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// Gets or sets the element, that is selected in the search list.
        /// </summary>
        public Nullable<T> SearchSelectedElement
        {
            get
            {
                return searchSelectedElement;
            }
            set
            {
                searchSelectedElement = value;
                OnPropertyChanged("SearchSelectedElement");
                OnPropertyChanged("SelectedElement");
            }
        }

        /// <summary>
        /// Gets the selected model element.
        /// </summary>
        public Nullable<T> SelectedElement
        {
            get
            {
                return this.SearchSelectedElement;
            }
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void SearchCommand_Executed()
        {
            if (this.IsDisposed)
                return;

            this.SearchResultViewModels.Clear();
            SearchSelectedElement = null;

            List<T> elements = searchAction(this.SearchText, this.selectableElements);
            foreach (T item in elements)
                this.SearchResultViewModels.Add(item);

            Sort();
        }

        /// <summary>
        /// Sorts the current results list.
        /// </summary>
        private void Sort()
        {
            IEnumerable<T> sortedList = sortAction(this.SearchResultViewModels);

            ObservableCollection<T> temp = new ObservableCollection<T>();
            foreach (T item in sortedList)
                temp.Add(item);

            this.searchResultViewModels = temp;
            OnPropertyChanged("SearchResultViewModels"); 
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void ActivatedCommand_Executed()
        {
            if (!IsActive)
                IsActive = true;
        }

        /// <summary>
        /// Tries to set the selection to the given element.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public void SetSelectedElement(T element)
        {
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            if (searchResultViewModels != null)
            {
                searchResultViewModels.Clear();
            }
            searchResultViewModels = null;
            searchAction = null;
            sortAction = null;
        }
    }
}
