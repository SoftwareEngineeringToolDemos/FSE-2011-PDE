using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class MappingRelationshipShapeClass
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateShape(ValidationContext context)
        {
            if (this.DomainClass != null && this.Source != null && this.Target != null)
            {
                if( this.Source.Source.RolePlayer != this.DomainClass )
                    context.LogError("The source relationship of the MappingRelationshipShapeClass " + this.Name + " needs to start from the class " + this.DomainClass.Name, "", null); //element);

                if (this.Target.Source.RolePlayer != this.DomainClass)
                    context.LogError("The target relationship of the MappingRelationshipShapeClass " + this.Name + " needs to start from the class " + this.DomainClass.Name, "", null); //element);
            }
        }
    }
}
