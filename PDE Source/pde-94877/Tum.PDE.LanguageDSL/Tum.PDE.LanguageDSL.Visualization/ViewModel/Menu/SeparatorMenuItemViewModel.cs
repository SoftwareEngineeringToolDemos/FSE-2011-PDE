using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu
{
    /// <summary>
    /// This class represents a separator menu item.
    /// </summary>
    public class SeparatorMenuItemViewModel : MenuItemViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SeparatorMenuItemViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
        }
    }

}
