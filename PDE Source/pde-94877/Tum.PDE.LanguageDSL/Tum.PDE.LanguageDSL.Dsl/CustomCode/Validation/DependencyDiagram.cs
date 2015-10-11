using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class DependencyDiagram
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateDependencyDiagram(ValidationContext context)
        {
            if (this.IsCustom == false)
            {
                context.LogError("The diagram class " + this.Title + " needs to have the IsCustom property set to 'true'.", "", null); //this);
            }
        }
    }
}
