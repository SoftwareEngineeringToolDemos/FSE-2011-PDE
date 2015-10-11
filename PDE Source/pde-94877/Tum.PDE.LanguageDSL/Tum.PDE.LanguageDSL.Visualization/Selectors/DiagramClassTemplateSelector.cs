using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram;

namespace Tum.PDE.LanguageDSL.Visualization.Selectors
{
    public class DiagramClassTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate
        {
            get;
            set;
        }

        public DataTemplate DependencyDiagramTemplate
        {
            get;
            set;
        }

        public DataTemplate ModalDiagramTemplate
        {
            get;
            set;
        }

        public DataTemplate SpecificElementsDiagramTemplate
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DiagramClassViewModel)
            {
                DiagramClassViewModel vm = item as DiagramClassViewModel;

                
                if (vm.DiagramClassView.DiagramClass is DependencyDiagram)
                    return DependencyDiagramTemplate;
                else if (vm.DiagramClassView.DiagramClass is ModalDiagram)
                    return ModalDiagramTemplate;
                else if (vm.DiagramClassView.DiagramClass is SpecificElementsDiagram)
                    return SpecificElementsDiagramTemplate;
                else
                    return DefaultTemplate;
            }
            else
                return null;
        }
    }
}
