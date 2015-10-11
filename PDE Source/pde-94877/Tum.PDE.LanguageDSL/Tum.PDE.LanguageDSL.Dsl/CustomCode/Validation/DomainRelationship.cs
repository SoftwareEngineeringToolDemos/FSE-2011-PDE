using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class DomainRelationship
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateDomainRelationship(ValidationContext context)
        {
            // Abstract relationships can only be created between abstract classes!
            if (this.InheritanceModifier == LanguageDSL.InheritanceModifier.Abstract)
            {
                if( this.Source.RolePlayer.InheritanceModifier != LanguageDSL.InheritanceModifier.Abstract )
                    context.LogError(this.Name + " can not be declared abstract because the source element is not declared abstract.", "NotAbstractSource", null); //this);

                if (this.Target.RolePlayer.InheritanceModifier != LanguageDSL.InheritanceModifier.Abstract)
                    context.LogError(this.Name + " can not be declared abstract because the target element is not declared abstract.", "NotAbstractTarget", null); // this);
            }
        }
    }
}
