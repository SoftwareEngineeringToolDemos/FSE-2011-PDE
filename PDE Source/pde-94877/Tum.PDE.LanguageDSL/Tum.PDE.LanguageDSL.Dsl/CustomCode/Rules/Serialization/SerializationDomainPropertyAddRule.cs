using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializationDomainPropertyAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            DomainProperty domainProperty = e.ModelElement as DomainProperty;
            if (domainProperty != null)
            {
                DomainProperty p = domainProperty;
                AttributedDomainElement element = p.Element;

                if (element is DomainRelationship)
                {
                    // we have to set serialized in full form, unless it is embedded somewhere in the model
                    bool bIsEmbedded = false;
                    foreach (DomainRole role in element.RolesPlayed)
                    {
                        if (role.Relationship.Target == role && role.Relationship.InheritanceModifier != InheritanceModifier.Abstract && role.Relationship is EmbeddingRelationship)
                        {
                            bIsEmbedded = true;
                            continue;
                        }
                    }

                    if (!bIsEmbedded)
                    {
                        // we have to set is serialized in full form to true
                        if (element is EmbeddingRelationship)
                        {
                            (element as EmbeddingRelationship).SerializedEmbeddingRelationship.IsInFullSerialization = true;

                        }
                        else if (element is ReferenceRelationship)
                        {
                            (element as ReferenceRelationship).SerializedReferenceRelationship.IsInFullSerialization = true;
                        }
                    }
                }

                SerializationHelper.UpdateDerivedElementsSerializationProperties(element);
            }
        }
    }
}
