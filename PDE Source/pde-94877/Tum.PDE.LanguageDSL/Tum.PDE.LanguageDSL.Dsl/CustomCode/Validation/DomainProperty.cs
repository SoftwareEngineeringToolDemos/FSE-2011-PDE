using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class DomainProperty
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateDomainProperty(ValidationContext context)
        {
            if( this.Type == null )
                context.LogError(this.Name + " on " + this.Element.Name + " needs to reference a DomainType", "", null);

            if (this.Type != null)
                if (this.SerializationRepresentationType == LanguageDSL.SerializationRepresentationType.Attribute)
                    if (this.Type.SerializationStyle == SerializationStyle.CDATA)
                    {
                        context.LogError(this.Name + " on " + this.Element.Name + " can not be serialized as attibute, because its referenced type is serialized as CDATA", "", null);
                    }
        }
    }
}
