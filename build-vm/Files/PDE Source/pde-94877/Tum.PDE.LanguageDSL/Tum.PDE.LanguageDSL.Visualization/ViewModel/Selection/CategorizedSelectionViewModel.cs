using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class CategorizedSelectionViewModel : BaseWindowViewModel
    {
        private SelectableViewModel selectedViewModel = null;
        private List<CategorizedSelectableViewModel> selectableCategories;
        private List<CategorizedAdvSelectableViewModel> selectableAdvCategories;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public CategorizedSelectionViewModel(ViewModelStore viewModelStore, List<CategorizedSelectableViewModel> selectableCategories)
            : base(viewModelStore)
        {
            this.selectableCategories = selectableCategories;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public CategorizedSelectionViewModel(ViewModelStore viewModelStore, List<CategorizedAdvSelectableViewModel> selectableCategories)
            : base(viewModelStore)
        {
            this.selectableAdvCategories = selectableCategories;
        }

        /// <summary>
        /// Gets the selectable categories.
        /// </summary>
        public List<CategorizedSelectableViewModel> SelectableCategories
        {
            get
            {
                return this.selectableCategories;
            }
        }

        /// <summary>
        /// Gets the selectable categories.
        /// </summary>
        public List<CategorizedAdvSelectableViewModel> SelectableAdvCategories
        {
            get
            {
                return this.selectableAdvCategories;
            }
        }

        /// <summary>
        /// Gets or sets the selected view model.
        /// </summary>
        public SelectableViewModel SelectedViewModel
        {
            get
            {
                return this.selectedViewModel;
            }
            set
            {
                if (this.selectedViewModel != value)
                {
                    this.selectedViewModel = value;

                    OnPropertyChanged("SelectedViewModel");
                }
            }
        }
    }
}
