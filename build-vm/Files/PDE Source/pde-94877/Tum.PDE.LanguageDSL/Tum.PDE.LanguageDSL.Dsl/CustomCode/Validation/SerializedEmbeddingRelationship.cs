using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class SerializedEmbeddingRelationship
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateSerializedEmbeddingRelationship(ValidationContext context)
        {
            if (this.IsTargetIncludedSubmodel)
            {
                DomainClass target = this.EmbeddingRelationship.Target.RolePlayer as DomainClass;
                if (target == null)
                {
                    context.LogError("IsTargetIncludedSubmodel is set to 'true' on SerializedEmbeddingRelationship of Relationship "
                        + this.EmbeddingRelationship.Name + " but target element is not a domain class!", "SerializedEmbeddingRelationship", null); //this);
                }
                else if (!target.IsDomainModel)
                {
                    context.LogError("IsTargetIncludedSubmodel is set to 'true' on SerializedEmbeddingRelationship of Relationship "
                        + this.EmbeddingRelationship.Name + " but target element is not declared as domain model!", "SerializedEmbeddingRelationship", null); //this);
                }
            }
        }
    }
}
