using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class MetaModel
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateMetaModel(ValidationContext context)
        {
            // names need to be unique
            List<ModelElement> namedElements = new List<ModelElement>();
            List<string> names = new List<string>();

            foreach(BaseModelContext m in this.ModelContexts)
                if (m is LibraryModelContext)
                {
                    LibraryModelContext ml = m as LibraryModelContext;
                    namedElements.AddRange(ml.Classes);
                    namedElements.AddRange(ml.Relationships);

                    foreach (DiagramClass element in ml.DiagramClasses)
                    {
                        if (names.Contains(element.Name))
                            context.LogError("A different diagram class is already named " + element.Name + ". Names are required to be unique.", "NameNeedsToBeUnique", null); //element);
                        else
                            names.Add(element.Name);

                        namedElements.AddRange(element.PresentationElements);
                    }
                }

            names.Clear();
            foreach (GeneratedDomainElement element in namedElements)
            {
                if (names.Contains(element.Name))
                    context.LogError("A different element is already named " + element.Name + ". Names are required to be unique.", "NameNeedsToBeUnique", null); //element);
                else
                    names.Add(element.Name);
            }

            names.Clear();
            foreach (DomainType element in this.DomainTypes)
            {
                if (names.Contains(element.Name))
                    context.LogError("A different type is already named " + element.Name + ". Names are required to be unique.", "NameNeedsToBeUnique", null); //element);
                else
                    names.Add(element.Name);
            }

            names.Clear();
            foreach (PropertyGridEditor element in this.PropertyGridEditors)
            {
                if (names.Contains(element.Name))
                    context.LogError("A different property grid editor is already named " + element.Name + ". Names are required to be unique.", "NameNeedsToBeUnique", null); //element);
                else
                    names.Add(element.Name);
            }

            bool bFoundDefaultMC = false;
            foreach (BaseModelContext m in this.ModelContexts)
                if (m.IsDefault)
                {
                    if( m is LibraryModelContext && !(m is ModelContext))
                        context.LogError("Library Model Contexts can not have the property 'IsDefault' set to 'true': MetaModel '" + this.Name + "', Context '" + m.Name + "'", "NameNeedsToBeUnique", null); //element);

                    if (!bFoundDefaultMC)
                        bFoundDefaultMC = true;
                    else
                    {
                        context.LogError("Multiple Model Contexts have the property 'IsDefault' set to 'true': MetaModel '" + this.Name + "'.", "NameNeedsToBeUnique", null); //element);

                        break;
                    }
                }

            //if( !bFoundDefaultMC )
            //    context.LogError("One Model Context needs to have the property 'IsDefault' set to 'true': MetaModel '" + this.Name + "'.", "NameNeedsToBeUnique", null); //element);
        }
    }
}
