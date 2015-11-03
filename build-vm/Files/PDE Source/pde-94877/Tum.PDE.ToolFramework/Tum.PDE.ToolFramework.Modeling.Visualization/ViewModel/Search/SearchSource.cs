namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search
{
    /// <summary>
    /// This class represents a search source.
    /// </summary>
    public class SearchSource
    {
        System.Guid id;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="displayName">Display name.</param>
        public SearchSource(SearchSourceEnum source, string displayName)
        {
            this.Source = source;
            this.DisplayName = displayName;

            this.id = System.Guid.NewGuid();
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public SearchSourceEnum Source
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
        /// Gets the id of this search source.
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
