using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class ImportedDiagramClassViewModel : BaseModelElementViewModel
    {
        DesignerDiagramClass diagramClass;
        Guid linkId;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public ImportedDiagramClassViewModel(ViewModelStore viewModelStore, DiagramClass element, DesignerDiagramClass diagramClass)
            : base(viewModelStore, element, true)
        {
            this.diagramClass = diagramClass;
            this.linkId = GetHostedElement().Id;

            this.IsLocked = false;
        }

        public Guid LinkId
        {
            get
            {
                return linkId;
            }
        }

        public DesignerDiagramClass ParentDesignerClass
        {
            get
            {
                return this.diagramClass;
            }
        }

        public override Microsoft.VisualStudio.Modeling.ModelElement GetHostedElement()
        {
            if (this.IsDisposed)
                return null;

            return DesignerDiagramClassReferencesImportedDiagramClasses.GetLink(diagramClass, this.Element as DiagramClass);
        }


        public string DomainElementContextName
        {
            get
            {
                return (this.Element as DiagramClass).ModelContext.Name;
            }
        }

        public string DomainElementDslName
        {
            get
            {
                return (this.Element as DiagramClass).ModelContext.MetaModel.Name;
            }
        }
    }
}
