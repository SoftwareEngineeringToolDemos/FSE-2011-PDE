using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search
{
    /// <summary>
    /// This view model displays a search result.
    /// </summary>
    public class SearchResultItemViewModel : BaseModelElementViewModel
    {
        SearchResult searchResult;
        
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="searchResult">Search result.</param>
        public SearchResultItemViewModel(ViewModelStore viewModelStore, SearchResult searchResult)
            : base(viewModelStore, searchResult.Source)
        {
            this.searchResult = searchResult;
        }

        /// <summary>
        /// Gets the reason.
        /// </summary>
        public string Reason
        {
            get
            {
                return this.searchResult.Reason;
            }
        }

        /// <summary>
        /// Navigate to model element
        /// </summary>
        public virtual void Navigate()
        {
            if (this.Element == null)
                return;

            if (this.Element.IsDeleted || this.Element.IsDeleting)
                return;

            SelectedItemsCollection col = new SelectedItemsCollection();
            col.Add(this.Element);

            // notify observers, that selection has changed
            this.EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
        }

    }
}
