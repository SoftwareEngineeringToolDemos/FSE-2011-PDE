using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{

    [ValidationState(ValidationState.Enabled)]
    public partial class PropertyGridEditor
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidatePropertyGridEditor(ValidationContext context)
        {
            /*
            if (this.RequiresContextMenuBar && !this.ShouldBeGenerated)
            {
                context.LogError(this.Name + " has 'ShouldBeGenerated' set to false but 'RequiresContextMenuBar' set to tru. Change 'ShouldBeGenerated' to true also.", "", null); //this);
            }*/
        }
    }
}
