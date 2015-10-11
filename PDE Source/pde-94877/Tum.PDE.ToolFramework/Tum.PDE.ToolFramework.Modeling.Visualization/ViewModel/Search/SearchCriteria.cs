namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search
{
    /// <summary>
    /// This class represents a search criteria.
    /// </summary>
    public class SearchCriteria
    {
        System.Guid id;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="criteria">Criteria.</param>
        /// <param name="displayName">Display name.</param>
        public SearchCriteria(SearchCriteriaEnum criteria, string displayName)
        {
            this.Criteria = criteria;
            this.DisplayName = displayName;

            this.id = System.Guid.NewGuid();
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public SearchCriteriaEnum Criteria
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the id of this search criteria.
        /// </summary>
        public System.Guid Id
        {
            get
            {
                return this.id;
            }
        }
    }
}
