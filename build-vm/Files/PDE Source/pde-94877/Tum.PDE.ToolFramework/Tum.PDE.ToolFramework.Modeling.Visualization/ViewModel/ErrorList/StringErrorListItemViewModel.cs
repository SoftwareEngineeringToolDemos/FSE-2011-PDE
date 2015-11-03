using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// Simple error list item view model for displaying string messages that can be filtered.
    /// </summary>
    public class StringErrorListItemViewModel : FilterableErrorListItemViewModel
    {
        private string errorId;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="errorId">Error id.</param>
        /// <param name="message">Description explaining why the error occured.</param>
        public StringErrorListItemViewModel(ViewModelStore viewModelStore, string errorId, string message)
            : base(viewModelStore, errorId, message)
        {
            this.errorId = errorId;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="errorId">Error id.</param>
        /// <param name="category">Error category of the error.</param>
        /// <param name="message">Description explaining why the error occured.</param>
        public StringErrorListItemViewModel(ViewModelStore viewModelStore, string errorId, ErrorListItemCategory category, string message)
            : base(viewModelStore, errorId, category, message)
        {
            this.errorId = errorId;
        }

        /// <summary>
        /// This method provides an unique id for the current model item.
        /// </summary>
        /// <returns></returns>
        public override string GetUniqueId()
        {
            return this.ErrorId;
        }
    }
}
