using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class SelectionViewModel : BaseWindowViewModel
    {
        private List<SelectableViewModel> selectableViewModels;
        private SelectableViewModel selectedViewModel = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SelectionViewModel(ViewModelStore viewModelStore, List<SelectableViewModel> selectableViewModels)
            : base(viewModelStore)
        {
            this.selectableViewModels = selectableViewModels;
        }

        /// <summary>
        /// Gets the list of selectable view models.
        /// </summary>
        public List<SelectableViewModel> SelectableViewModels
        {
            get
            {
                return this.selectableViewModels;
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
                this.selectedViewModel = value;

                OnPropertyChanged("SelectedViewModel");
            }
        }
    }
}
