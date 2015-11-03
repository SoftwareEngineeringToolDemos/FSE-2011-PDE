using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class ModelTree
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateModelTree(ValidationContext context)
        {
            if (this.SortingBehavior == LanguageDSL.SortingBehavior.Alphabetical &&
                this.CanMoveElements)
            {
                context.LogError("View.ModelTree: SortingBehavior is set to 'Alphabetical', CanMoveElements can not be set to 'true' ", "", null); //element);
            }
        }
    }
}
