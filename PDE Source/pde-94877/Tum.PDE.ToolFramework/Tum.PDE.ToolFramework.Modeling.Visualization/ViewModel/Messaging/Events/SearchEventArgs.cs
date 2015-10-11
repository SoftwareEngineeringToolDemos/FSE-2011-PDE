using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Search event data.
    /// </summary>
    public class SearchEventArgs : ViewModelEventArgs
    {
        private string searchText = "";
        private string searchTextInResult = "";

        private bool doFindInResult = false;
        private bool doMatchCase = false;
        private bool doMatchWholeWord = false;

        private SearchCriteria selectedSearchCriteria;
        private SearchCriteria selectedSearchCriteriaInResult;
        private SearchSource selectedSearchSource;
        private List<ModelElement> selectedSearchSourceElements;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SearchEventArgs(string searchText, SearchSource source, SearchCriteria criteria)
            : base(null)
        {
            this.searchText = searchText;
            this.selectedSearchSource = source;
            this.selectedSearchSourceElements = null;
            this.selectedSearchCriteria = criteria;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SearchEventArgs(string searchText, List<ModelElement> source, SearchCriteria criteria)
            : base(null)
        {
            this.searchText = searchText;
            this.selectedSearchSource = new SearchSource(SearchSourceEnum.Custom, "Custom");
            this.selectedSearchSourceElements = source;
            this.selectedSearchCriteria = criteria;
        }
        
        /// <summary>
        /// Gets the selected search source.
        /// </summary>
        public SearchSource SelectedSearchSource
        {
            get
            {
                return this.selectedSearchSource;
            }
        }

        /// <summary>
        /// Gets the search source.
        /// </summary>
        public List<ModelElement> SelectedSearchSourceElements
        {
            get
            {
                return this.selectedSearchSourceElements;
            }
        }

        /// <summary>
        /// Gets the selected search criteria.
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
            }
        }

        /// <summary>
        /// Gets the selected search criteria in result.
        /// </summary>
        public SearchCriteria SelectedSearchCriteriaInResult
        {
            get
            {
                return this.selectedSearchCriteriaInResult;
            }
            set {
                this.selectedSearchCriteriaInResult = value;
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
            }
        }

    }
}
