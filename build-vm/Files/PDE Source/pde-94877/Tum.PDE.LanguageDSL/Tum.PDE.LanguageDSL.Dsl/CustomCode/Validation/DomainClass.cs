using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling.Validation;

namespace Tum.PDE.LanguageDSL
{
    [ValidationState(ValidationState.Enabled)]
    public partial class DomainClass
    {
        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Open | ValidationCategories.Save)]
        public void ValidateDomainClass(ValidationContext context)
        {
            List<DomainRole> embeddingRoles = new List<DomainRole>();
            List<string> names = new List<string>();
            List<string> refRSTargetSerializationNames = new List<string>();
            bool bLogEmbedded = false;
            foreach (DomainRole role in this.RolesPlayed)
            {
                if (!role.IsPropertyGenerator)
                    continue;

                if (names.Contains(role.PropertyName))
                    context.LogError("PropertyName of Relationship " + role.Relationship.Name + " on " + this.Name + " is already used and needs to be altered.", "PropertyNameAlreadyUsed", null); //this);
                else
                    names.Add(role.PropertyName);

                if (role.Relationship is EmbeddingRelationship &&
                    role.Relationship.Target.RolePlayer == this)
                {
                    embeddingRoles.Add(role);

                    if (role.Multiplicity == Multiplicity.One || role.Multiplicity == Multiplicity.OneMany)
                        bLogEmbedded = true;
                }

                if (role.Relationship is ReferenceRelationship)
                    if (role.Relationship.Source == role)
                    {
                        ReferenceRelationship r = role.Relationship as ReferenceRelationship;
                        if (r.SerializedReferenceRelationship != null)
                            if (!r.SerializedReferenceRelationship.IsInFullSerialization)
                            {
                                if (refRSTargetSerializationNames.Contains(r.SerializationTargetName))
                                    context.LogError("SerializationTargetName of Relationship " + role.Relationship.Name + " on " + this.Name + " is already used and needs to be altered.", "PropertyNameAlreadyUsed", null); //this);
                                else
                                    refRSTargetSerializationNames.Add(r.SerializationTargetName);
                            }
                    }
            }

            if (bLogEmbedded && embeddingRoles.Count > 1)
            {
                string message = "The domain class " + this.Name + " is embedded at multiple places. The following relationships need to have their target role multiplicities set to '0:1' or '0:n' :";
                foreach (DomainRole role in embeddingRoles)
                {
                    message += role.Relationship.Name + "; ";
                }
                context.LogError(message, "", null);
            }

            List<string> shapeNames = new List<string>();
            foreach (PresentationElementClass shape in this.ShapeClasses)
            {
                if (shape is ShapeClass)
                {
                    if ((shape as ShapeClass).UseInDependencyView)
                        shapeNames.Add(shape.Name);
                }
            }
            if (shapeNames.Count > 1)
            {
                string message = "The domain class " + this.Name + " has multiple shape classes with UseInDependencyView='true' :";
                foreach (string n in shapeNames)
                {
                    message += n + "; ";
                }
                context.LogError(message, "", null);
            }
        }
    }
}
