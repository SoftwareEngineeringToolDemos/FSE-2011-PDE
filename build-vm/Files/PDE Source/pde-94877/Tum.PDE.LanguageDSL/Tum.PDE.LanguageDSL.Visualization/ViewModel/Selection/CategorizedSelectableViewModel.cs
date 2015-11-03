using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class CategorizedSelectableViewModel : BaseViewModel
    {
        List<SelectableViewModel> selectableVMs;
        string categoryName;
                
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public CategorizedSelectableViewModel(ViewModelStore viewModelStore, string categoryName, List<SelectableViewModel> selectableVMs)
            : base(viewModelStore)
        {
            this.selectableVMs = selectableVMs;
            this.categoryName = categoryName;
        }

        /// <summary>
        /// Gets the list of selectable view models.
        /// </summary>
        public List<SelectableViewModel> SelectableViewModels
        {
            get
            {
                return this.selectableVMs;
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
