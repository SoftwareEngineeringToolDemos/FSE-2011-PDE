using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class CategorizedAdvSelectableViewModel : BaseViewModel
    {
        List<CategorizedSelectableViewModel> categorizedVMs;
        string categoryName;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public CategorizedAdvSelectableViewModel(ViewModelStore viewModelStore, string categoryName, List<CategorizedSelectableViewModel> categorizedVMs)
            : base(viewModelStore)
        {
            this.categorizedVMs = categorizedVMs;
            this.categoryName = categoryName;
        }

        /// <summary>
        /// Gets the list of selectable view models.
        /// </summary>
        public List<CategorizedSelectableViewModel> Categories
        {
            get
            {
                return this.categorizedVMs;
            }
        }

        /// <summary>
        /// Gets the category name.
        /// </summary>
        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
        }
    }
}
