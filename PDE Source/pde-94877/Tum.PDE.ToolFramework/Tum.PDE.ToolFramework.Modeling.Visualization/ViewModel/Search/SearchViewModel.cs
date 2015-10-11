using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

using PDEResources = Tum.PDE.ToolFramework.Modeling.Visualization.Properties;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search
{
    /// <summary>
    /// This abstract class represents a search view model.
    /// </summary>
    public abstract class SearchViewModel : BaseDockingViewModel
    {
        private DelegateCommand searchCommand;
        private DelegateCommand searchAdvancedCommand;
        private DelegateCommand searchAndReplaceCommand;

        private SearchResultViewModel searchResultViewModel;
        private SearchModus searchModus;

        private string searchText = "";
        private string searchTextInResult = "";

        private bool doFindInResult = false;
        private bool doMatchCase = false;
        private bool doMatchWholeWord = false;

        private List<SearchCriteria> searchCriteria;
        private SearchCriteria selectedSearchCriteria;
        private SearchCriteria selectedSearchCriteriaInResult;

        private List<SearchSource> searchSource;
        private SearchSource selectedSearchSource;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SearchViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            searchCommand = new DelegateCommand(SearchCommand_Executed);
            searchAdvancedCommand = new DelegateCommand(SearchAdvancedCommand_Executed);
            searchAndReplaceCommand = new DelegateCommand(SearchAndReplaceCommand_Executed);

            this.searchModus = SearchModus.SearchAdvanced;

            this.EventManager.GetEvent<SearchEvent>().Subscribe(new Action<SearchEventArgs>(ReactOnSearchRequest));

            this.FloatingWindowDesiredHeight = 360;
            this.FloatingWindowDesiredWidth = 340;

            this.PreInitialize();
        }

        /// <summary>
        /// Preinit.
        /// </summary>
        protected override void PreInitialize()
        {
            InitializeSearchOptions();
            base.PreInitialize();
        }
        
        /// <summary>
        /// Initialize
        /// </summary>
        protected override void Initialize()
        {
            InitializeSearchOptions();
            base.Initialize();
        }

        
        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName 
        {
            get
            { 
                return "SearchViewModel"; 
            } 
        }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle
        { 
            get 
            {
                return PDEResources.Resources.SearchViewModel_FindAdvanced;
            } 
        }
        #endregion

        #region Search Options
        /// <summary>
        /// Gets the search sources.
        /// </summary>
        public List<SearchSource> SearchSource
        {
            get
            {
                return searchSource;
            }
        }

        /// <summary>
        /// Gets or sets the selected search source.
        /// </summary>
        public SearchSource SelectedSearchSource
        {
            get
            {
                return this.selectedSearchSource;
            }
            set
            {
                this.selectedSearchSource = value;
                OnPropertyChanged("SelectedSearchSource");
            }
        }

        /// <summary>
        /// Gets the search criteria.
        /// </summary>
        public List<SearchCriteria> SearchCriteria
        {
            get
            {
                return searchCriteria;
            }
        }

        /// <summary>
        /// Gets or sets the selected search criteria.
        /// </summary>
        public SearchCriteria SelectedSearchCriteria
        {
            get
            {
                return this.selectedSearchCriteria;
            }
            set
            {
                this.selectedSearchCriteria = value;
                OnPropertyChanged("SelectedSearchCriteria");
            }
        }

        /// <summary>
        /// Gets or sets the selected search criteria in result.
        /// </summary>
        public SearchCriteria SelectedSearchCriteriaInResult
        {
            get
            {
                return this.selectedSearchCriteriaInResult;
            }
            set
            {
                this.selectedSearchCriteriaInResult = value;
                OnPropertyChanged("SelectedSearchCriteriaInResult");
            }
        }

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                this.searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// Gets or sets the search text in result.
        /// </summary>
        public string SearchTextInResult
        {
            get
            {
                return this.searchTextInResult;
            }
            set
            {
                this.searchTextInResult = value;
                OnPropertyChanged("SearchTextInResult");
            }
        }

        /// <summary>
        /// Gets or sets the DoFindInResult property.
        /// </summary>
        public bool DoFindInResult
        {
            get
            {
                return this.doFindInResult;
            }
            set
            {
                this.doFindInResult = value;
                OnPropertyChanged("DoFindInResult");
            }
        }

        /// <summary>
        /// Gets or sets the DoMatchCase property.
        /// </summary>
        public bool DoMatchCase
        {
            get
            {
                return this.doMatchCase;
            }
            set
            {
                this.doMatchCase = value;
                OnPropertyChanged("DoMatchCase");
            }
        }

        /// <summary>
        /// Gets or sets the DoMatchWholeWord property.
        /// </summary>
        public bool DoMatchWholeWord
        {
            get
            {
                return this.doMatchWholeWord;
            }
            set
            {
                this.doMatchWholeWord = value;
                OnPropertyChanged("DoMatchWholeWord");
            }
        }

        /// <summary>
        /// Initializes the  search criteria list.
        /// </summary>
        protected virtual void InitializeSearchOptions()
        {
            // initiliaze search sources
            searchSource = new List<SearchSource>();

            searchSource.Add(new SearchSource(SearchSourceEnum.Elements, PDEResources.Resources.SearchSourceEnum_Elements));
            searchSource.Add(new SearchSource(SearchSourceEnum.ReferenceRelationships, PDEResources.Resources.SearchSourceEnum_ReferenceRelationships));
            searchSource.Add(new SearchSource(SearchSourceEnum.ElementsAndReferenceRelationships, PDEResources.Resources.SearchSourceEnum_ElementsAndReferenceRelationships));

            selectedSearchSource = searchSource[0];

            // initiliaze serach criteria
            searchCriteria = new List<SearchCriteria>();

            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.Name, PDEResources.Resources.SearchCriteriaEnum_Name));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.Type, PDEResources.Resources.SearchCriteriaEnum_Type));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.NameAndType, PDEResources.Resources.SearchCriteriaEnum_NameAndType));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.Properties, PDEResources.Resources.SearchCriteriaEnum_Properties));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.PropertiesWithoutName, PDEResources.Resources.SearchCriteriaEnum_PropertiesWithoutName));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.Roles, PDEResources.Resources.SearchCriteriaEnum_Roles));
            searchCriteria.Add(new SearchCriteria(SearchCriteriaEnum.All, PDEResources.Resources.SearchCriteriaEnum_All));

            selectedSearchCriteria = searchCriteria[0];
            selectedSearchCriteriaInResult = searchCriteria[0];

        }

        /// <summary>
        /// Creates an options summary as a string.
        /// </summary>
        /// <returns>Options summary as string.</returns>
        protected virtual string CreateOptionsSummary(SearchEventArgs args)
        {            
            if (!this.DoFindInResult)
                return string.Format(PDEResources.Resources.SearchViewModel_OptionsSummary, args.SearchText,
                    args.SelectedSearchSource.DisplayName, args.SelectedSearchCriteria.DisplayName);
            else
                return string.Format(PDEResources.Resources.SearchViewModel_OptionsSummaryAdv, args.SearchText,
                    args.SelectedSearchSource.DisplayName, args.SelectedSearchCriteria.DisplayName,
                    args.SearchTextInResult, args.SelectedSearchCriteriaInResult.DisplayName);

            /*
            string summary = "Find all '" + args.SearchText + "', Source: " + args.SelectedSearchSource.DisplayName + ", ";
            summary += "Criteria: " + args.SelectedSearchCriteria.DisplayName;

            if (args.DoFindInResult)
            {
                summary += " and in results find '" + args.SearchTextInResult + "', " + "Criteria: " + args.SelectedSearchCriteria.DisplayName;
            }

            return summary;
            */
        }

        /// <summary>
        /// Creates an options summary as a string.
        /// </summary>
        /// <returns>Options summary as string.</returns>
        protected virtual string CreateOptionsSummary()
        {
            //"Find all '{0}', Source: {1}, Criteria: {2}";
            //"Find all '{0}', Source: {1}, Criteria: {2} and in results find '{3}' , Criteria: {4}";

            if( !this.DoFindInResult )
                return string.Format(PDEResources.Resources.SearchViewModel_OptionsSummary, this.SearchText, 
                    this.SelectedSearchSource.DisplayName, this.SelectedSearchCriteria.DisplayName);
            else
                return string.Format(PDEResources.Resources.SearchViewModel_OptionsSummaryAdv, this.SearchText, 
                    this.SelectedSearchSource.DisplayName, this.SelectedSearchCriteria.DisplayName,
                    this.SearchTextInResult, this.SelectedSearchCriteriaInResult.DisplayName);

            /*
            string summary = "Find all '" + this.SearchText + "', Source: " + this.SelectedSearchSource.DisplayName + ", ";
            summary += "Criteria: " + this.SelectedSearchCriteria.DisplayName;

            if (this.DoFindInResult)
            {
                summary += " and in results find '" + this.SearchTextInResult + "', " + "Criteria: " + this.SelectedSearchCriteria.DisplayName;
            }

            return summary;
            */
        }
        #endregion

        /// <summary>
        /// Gets the search result view model.
        /// </summary>
        public SearchResultViewModel SearchResultViewModel
        {
            get
            {
                return this.searchResultViewModel;
            }
            protected set
            {
                this.searchResultViewModel = value;
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
        /// Search advanced command.
        /// </summary>
        public DelegateCommand SearchAdvancedCommand
        {
            get { return searchAdvancedCommand; }
        }

        /// <summary>
        /// Search and replace command.
        /// </summary>
        public DelegateCommand SearchAndReplaceCommand
        {
            get { return searchAndReplaceCommand; }
        }

        /// <summary>
        /// Reactns on a SearchEvent beeing received.
        /// </summary>
        /// <param name="args">Event data.</param>
        private void ReactOnSearchRequest(SearchEventArgs args)
        {
            Search(args);
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        protected virtual void SearchCommand_Executed()
        {
            SearchEventArgs args = new SearchEventArgs(this.SearchText, this.SelectedSearchSource, this.SelectedSearchCriteria);
            args.DoFindInResult = this.DoFindInResult;
            args.DoMatchCase = this.DoMatchCase;
            args.DoMatchWholeWord = this.DoMatchWholeWord;
            args.SearchTextInResult = this.SearchTextInResult;
            args.SelectedSearchCriteriaInResult = this.SelectedSearchCriteriaInResult;

            this.Search(args);
        }

        /// <summary>
        /// Search advanced command executed.
        /// </summary>
        protected virtual void SearchAdvancedCommand_Executed()
        {
            ShowSearchOptionsViewModel();

            // make sure search advanced is visible
            SearchModus = SearchModus.SearchAdvanced;
        }

        /// <summary>
        /// Search and replace command executed.
        /// </summary>
        protected virtual void SearchAndReplaceCommand_Executed()
        {
            ShowSearchOptionsViewModel();

            // make sure search and replace is visible
            SearchModus = SearchModus.SearchAndReplace;
        }

        /// <summary>
        /// Show search options view model.
        /// </summary>
        private void ShowSearchOptionsViewModel()
        {
            if (!this.IsDockingPaneVisible)
            {
                // show docking pane
                ShowViewModelRequestEventArgs args = new ShowViewModelRequestEventArgs(this);
                args.DockingPaneStyle = ViewModel.DockingPaneStyle.Floating;
                this.EventManager.GetEvent<ShowViewModelRequestEvent>().Publish(args);
            }
            else
            {
                // bring to front
                this.EventManager.GetEvent<BringToFrontViewModelRequestEvent>().Publish(new BringToFrontViewModelRequestEventArgs(this));
            }
        }

        /// <summary>
        /// Gets or sets the search modus.
        /// </summary>
        public SearchModus SearchModus
        {
            get
            {
                return this.searchModus;
            }
            set
            {
                this.searchModus = value;
                OnPropertyChanged("SearchModus");
            }
        }

        /// <summary>
        /// Search.
        /// </summary>
        /// <param name="args">Search data.</param>
        protected virtual void Search(SearchEventArgs args)
        {
            if (args.SelectedSearchCriteria == null || args.SelectedSearchSource == null)
                return;

            // search
            List<ModelElement> selectableElements = this.ViewModelStore.TopMostStore.GetDomainModelServices().SearchProcessor.GetSearchableElements(this.Store, this.SelectedSearchSource.Source);

            if (args.SelectedSearchSource.Source == SearchSourceEnum.Custom && args.SelectedSearchSourceElements != null &&
                args.SelectedSearchCriteria.Criteria != SearchCriteriaEnum.Custom)
            {
                selectableElements = args.SelectedSearchSourceElements;
            }
            else
                if (args.SelectedSearchCriteria.Criteria == SearchCriteriaEnum.Custom ||
                    args.SelectedSearchSource.Source == SearchSourceEnum.Custom)
                    return;

            this.SearchResultViewModel.SearchOptionsSummary = this.CreateOptionsSummary(args);
            
            if( args.SelectedSearchSource.Source != SearchSourceEnum.Custom )
                selectableElements = this.ViewModelStore.TopMostStore.GetDomainModelServices().SearchProcessor.GetSearchableElements(this.Store, args.SelectedSearchSource.Source);

            // search sources
            SearchResultViewModel.SearchResults.Clear();

            if (!args.DoFindInResult)
            {
                foreach (ModelElement modelElement in selectableElements)
                {
                    List<SearchResult> searchResults = this.ViewModelStore.TopMostStore.GetDomainModelServices().SearchProcessor.Search(modelElement, args.SelectedSearchCriteria.Criteria,
                        args.SearchText, new SearchOptions(args.DoMatchCase, args.DoMatchWholeWord));

                    if (searchResults != null)
                    {
                        foreach (SearchResult searchResult in searchResults)
                            if (searchResult.IsSuccessFull && searchResult.Source != null)
                            {
                                SearchResultViewModel.SearchResults.Add(new SearchResultItemViewModel(this.ViewModelStore, searchResult));
                            }
                    }
                }
            }
            else
            {
                List<ModelElement> temp = new List<ModelElement>();
                foreach (ModelElement modelElement in selectableElements)
                {
                    List<SearchResult> searchResults = this.ViewModelStore.TopMostStore.GetDomainModelServices().SearchProcessor.Search(modelElement, args.SelectedSearchCriteria.Criteria,
                        args.SearchText, new SearchOptions(args.DoMatchCase, args.DoMatchWholeWord));
                    if (searchResults != null)
                        foreach (SearchResult searchResult in searchResults)
                            if (searchResult.IsSuccessFull && searchResult.Source != null)
                                if (!temp.Contains(searchResult.Source))
                                    temp.Add(searchResult.Source);
                }
                foreach (ModelElement modelElement in temp)
                {
                    List<SearchResult> searchResults = this.ViewModelStore.TopMostStore.GetDomainModelServices().SearchProcessor.Search(modelElement, args.SelectedSearchCriteriaInResult.Criteria,
                        args.SearchTextInResult, new SearchOptions(args.DoMatchCase, args.DoMatchWholeWord));

                    if (searchResults != null)
                    {
                        foreach (SearchResult searchResult in searchResults)
                            if (searchResult.IsSuccessFull && searchResult.Source != null)
                            {
                                SearchResultViewModel.SearchResults.Add(new SearchResultItemViewModel(this.ViewModelStore, searchResult));
                            }
                    }
                }
            }

            // sort result
            SearchResultViewModel.Sort(SearchResultViewModel.SortOrder, SearchResultViewModel.IsSortedAscending);

            // set summary
            this.SearchResultViewModel.SearchResultSummary =

                PDEResources.Resources.SearchViewModel_ResultsFound + ": " + SearchResultViewModel.SearchResults.Count + "     " +
                PDEResources.Resources.SearchViewModel_TotalElementsSearched + ": " + selectableElements.Count;

            if (!this.SearchResultViewModel.IsDockingPaneVisible)
            {
                // show docking pane
                this.EventManager.GetEvent<ShowViewModelRequestEvent>().Publish(new ShowViewModelRequestEventArgs(this.SearchResultViewModel));
            }
            else
            {
                // bring to front
                this.EventManager.GetEvent<BringToFrontViewModelRequestEvent>().Publish(new BringToFrontViewModelRequestEventArgs(this.SearchResultViewModel));
            }
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void OnReset()
        {
            for (int i = this.SearchResultViewModel.SearchResults.Count - 1; i >= 0; i--)
                this.SearchResultViewModel.SearchResults[i].Dispose();
            this.SearchResultViewModel.SearchResults.Clear();
            this.SearchResultViewModel.SearchResultSummary = "";
            this.SearchResultViewModel.SelectedSearchResultItem = null;

            base.OnReset();
        }
    }
}
