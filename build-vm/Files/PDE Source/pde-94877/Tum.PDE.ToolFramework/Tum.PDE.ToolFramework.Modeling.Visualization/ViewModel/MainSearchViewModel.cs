using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This view model represents the main search view model used to search the domain model for specific elements.
    /// </summary>
    public class MainSearchViewModel : SearchViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MainSearchViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
    }
}
