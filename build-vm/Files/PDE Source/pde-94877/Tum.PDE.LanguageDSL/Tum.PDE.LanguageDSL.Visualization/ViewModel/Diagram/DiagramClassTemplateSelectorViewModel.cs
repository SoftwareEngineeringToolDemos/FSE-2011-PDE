using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DiagramClassTemplateSelectorViewModel : BaseWindowViewModel
    {
        ObservableCollection<DiagramClassTemplateViewModel> templateVMs;
        DiagramClassTemplateViewModel selectedTemplateVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public DiagramClassTemplateSelectorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            templateVMs = new ObservableCollection<DiagramClassTemplateViewModel>();

            DiagramClassTemplateViewModel vm = new DiagramClassTemplateViewModel(this.ViewModelStore,
                DiagramClassTemplateIds.GeneralGraphicalDependencyTemplate, "GeneralGrDependencyTemplate", "Graphical Dependencies");
            vm.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/config.icon.48.png";
            vm.ImageUriBig = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/GrDependencies.png";
            vm.Description = "This template adds a view to display dependencies graphicaly, which also lets you navigate the dependencies network and create new dependencies via drag and drop.";
            this.TemplateVMs.Add(vm);


            DiagramClassTemplateViewModel vm2 = new DiagramClassTemplateViewModel(this.ViewModelStore,
                DiagramClassTemplateIds.SpecificGraphicalDependencyTemplate, "SpecificGrDependencyTemplate", "Specific Graphical Dependencies");
            vm2.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/config.icon.48.png";
            vm2.ImageUriBig = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/SpecificGrDependencies.png";
            vm2.Description = "This template adds a view to display a list of specific items as well as their dependencies graphicaly and also lets you navigate the dependencies network and create new dependencies via drag and drop.";
            this.TemplateVMs.Add(vm2);

            DiagramClassTemplateViewModel vm3 = new DiagramClassTemplateViewModel(this.ViewModelStore,
                DiagramClassTemplateIds.ModalDiagramTemplate, "ModalDiagramTemplate", "Modal View");
            vm3.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/Presentation-32x32.png";
            vm3.ImageUriBig = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/ModalView.png";
            vm3.Description = "A modal diagram in PDE is a diagram that can be opened to host a specific element. There can be multiple instances of modal diagrams at the same time. Additionally, a context menu is automatically added to the ModelTree to open the diagrams for their hosted elements.";
            this.TemplateVMs.Add(vm3);

            DiagramClassTemplateViewModel vm4 = new DiagramClassTemplateViewModel(this.ViewModelStore,
                DiagramClassTemplateIds.SpecificElementsDiagramTemplate, "SpecificElementsDiagramTemplate", "Specific Elements View");
            vm4.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/Presentation-32x32.png";
            vm4.ImageUriBig = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/SpecificElementsView.png";
            vm4.Description = "The 'Specific Elements View' is a diagram that is designed to react visually on the selection of certain elements. Those elements need to be specified in the designer. The view itself can be opened from the ribbon menu (Views).";
            this.TemplateVMs.Add(vm4);

            //DiagramClassTemplateViewModel vm5 = new DiagramClassTemplateViewModel(this.ViewModelStore,
            //    DiagramClassTemplateIds.DesignerSurfaceDiagramTemplate, "DesignerSurfaceDiagramTemplate", "Designer Diagram View");
            //vm5.ImageUri = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/config.icon.48.png";
            //vm5.ImageUriBig = "/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Templates/SpecificGrDependencies.png";
            //vm5.Description = "TODO";
            //this.TemplateVMs.Add(vm5);
        }

        public ObservableCollection<DiagramClassTemplateViewModel> TemplateVMs
        {
            get
            {
                return this.templateVMs;
            }
        }
        public DiagramClassTemplateViewModel SelectedTemplateVM
        {
            get
            {
                if (this.selectedTemplateVM == null && this.templateVMs.Count > 0)
                    this.selectedTemplateVM = this.templateVMs[0];

                return this.selectedTemplateVM;
            }
            set
            {
                if (this.selectedTemplateVM != value)
                {
                    this.selectedTemplateVM = value;
                    OnPropertyChanged("SelectedTemplateVM");
                    OnPropertyChanged("IsItemSelected");
                }
            }
        }
        public bool IsItemSelected
        {
            get
            {
                if (this.SelectedTemplateVM != null)
                    return true;
                
                return false;
            }
        }
    }
}
