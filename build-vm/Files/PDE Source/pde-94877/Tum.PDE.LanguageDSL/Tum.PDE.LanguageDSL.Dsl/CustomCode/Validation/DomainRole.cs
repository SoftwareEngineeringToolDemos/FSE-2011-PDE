using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class DomainRole
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateDomainRelationship(ValidationContext context)
        {
            if( this.CustomPropertyGridEditor != null )
                if (this.CustomPropertyGridEditor.Name == "ReferencedModelRoleViewModel")
                {
                    if (!(this.Relationship is EmbeddingRelationship))
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because the relationship is not an EmbeddingRelationship", "", null); //element);
                        return;
                    }

                    if (this.Relationship.Source.Multiplicity == LanguageDSL.Multiplicity.OneMany ||
                        this.Relationship.Source.Multiplicity == LanguageDSL.Multiplicity.ZeroMany)
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because the Multiplicity is required to be One or ZeroOne", "", null); //element);
                        return;
                    }

                    if (!this.Relationship.Source.IsPropertyGenerator)
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because the IsPropertyGenerator is set to 'false'", "", null); //element);
                        return;
                    }

                    if (String.IsNullOrEmpty(this.PropertyDisplayName))
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " has PropertyDisplayName 'null'", "", null); //element);
                        return;
                    }

                    if( (this.Relationship as EmbeddingRelationship).SerializedEmbeddingRelationship.IsInFullSerialization )
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because the relationship is set to be serialized in full mode", "", null); //element);
                        return;
                    }

                    DomainClass domainClass = this.RolePlayer as DomainClass;
                    if (domainClass == null)
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because its target roleplayer is not a DomainClass", "", null); //element);
                    }
                    else if (!domainClass.IsDomainModel)
                    {
                        context.LogError("DomainRole " + this.Name + " of relationship " + this.Relationship.Name + " can not have CustomPropertyGridEditor set to ReferencedModelRoleViewModel, because its target roleplayer is not marked as DomainModel", "", null); //element);
                    }
                }
        }
    }
}
