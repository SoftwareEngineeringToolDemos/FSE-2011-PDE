using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DateTemplateSelectorViewModel : BaseWindowViewModel
    {
        ObservableCollection<DataTemplateViewModel> templateVMs;
        DataTemplateViewModel selectedTemplateVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public DateTemplateSelectorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            templateVMs = new ObservableCollection<DataTemplateViewModel>();
        }

        public ObservableCollection<DataTemplateViewModel> TemplateVMs
        {
            get
            {
                return this.templateVMs;
            }
        }
        public DataTemplateViewModel SelectedTemplateVM
        {
            get
            {
                if (this.selectedTemplateVM == null && templateVMs.Count > 0)
                    this.selectedTemplateVM = templateVMs[0];

                return this.selectedTemplateVM;
            }
            set
            {
                if (this.selectedTemplateVM != value)
                {
                    this.selectedTemplateVM = value;
                    OnPropertyChanged("SelectedTemplateVM");
                }
            }
        }
    }
}
