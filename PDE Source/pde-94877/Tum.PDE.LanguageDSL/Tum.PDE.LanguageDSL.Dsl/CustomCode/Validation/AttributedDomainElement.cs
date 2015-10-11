using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class AttributedDomainElement
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateAttributedDomainElement(ValidationContext context)
        {
            List<string> propertyNames = new List<string>();
            foreach (DomainProperty property in this.Properties)
                if (propertyNames.Contains(property.Name))
                {
                    context.LogError(this.Name + " has multiple properties with equal names", "EqualyNamedProperties", null);
                    break;
                }
                else
                    propertyNames.Add(property.Name);
        }
    }
}
