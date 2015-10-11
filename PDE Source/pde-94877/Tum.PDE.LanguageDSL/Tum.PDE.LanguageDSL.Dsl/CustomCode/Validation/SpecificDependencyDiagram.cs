using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class SpecificDependencyDiagram
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateSpecificDependencyDiagram(ValidationContext context)
        {
            if (this.DomainClass == null)
            {
                context.LogError("The specific diagram class " + this.Title + " needs to reference a Domain Class.", "MissingDomainClassReference", null); //this);
            }
        }
    }
}
