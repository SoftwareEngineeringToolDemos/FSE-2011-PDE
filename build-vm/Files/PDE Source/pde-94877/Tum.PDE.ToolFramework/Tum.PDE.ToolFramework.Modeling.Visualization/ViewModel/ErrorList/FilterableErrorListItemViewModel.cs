using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// This base class represents a filterable error list item view model.
    /// </summary>
    public abstract class FilterableErrorListItemViewModel : BaseErrorListItemViewModel, IFilterableErrorListItem
    {
        private string errorId;
        private bool isFiltered = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="errorId">Error id.</param>
        /// <param name="category">Error category of the error.</param>
        /// <param name="description">Description explaining why the error occured.</param>
        protected FilterableErrorListItemViewModel(ViewModelStore viewModelStore, string errorId, ErrorListItemCategory category, string description)
            : base(viewModelStore, category, description)
        {
            this.errorId = errorId;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="errorId">Error id.</param>
        /// <param name="description">Description explaining why the error occured.</param>
        protected FilterableErrorListItemViewModel(ViewModelStore viewModelStore, string errorId, string description)
            : this(viewModelStore, errorId, ErrorListItemCategory.Error, description)
        {
        }

        /// <summary>
        /// This method provides an unique id for the item. 
        /// </summary>
        /// <returns></returns>
        public abstract string GetUniqueId();

        /// <summary>
        /// Identification of the error.
        /// </summary>
        public string ErrorId { get{ return errorId;} }

        /// <summary>
        /// Gets or set whether this item is filtered or not.
        /// </summary>
        public bool IsFiltered
        {
            get { return isFiltered; }
            set
            {
                isFiltered = value;
                OnPropertyChanged("IsFiltered");
            }
        }
    }
}
