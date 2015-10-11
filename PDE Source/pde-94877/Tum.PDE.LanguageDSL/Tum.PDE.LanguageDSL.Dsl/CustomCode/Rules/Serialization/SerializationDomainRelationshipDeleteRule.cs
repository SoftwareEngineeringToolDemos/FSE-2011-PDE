using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ReferenceRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    [RuleOn(typeof(EmbeddingRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    [RuleOn(typeof(DomainRelationshipReferencesBaseRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    public class SerializationDomainRelationshipDeleteRule : DeletingRule
    {
        public override void  ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            ReferenceRelationship referenceRelationship = e.ModelElement as ReferenceRelationship;
            if (referenceRelationship != null)
            {
                if (referenceRelationship.SerializedReferenceRelationship != null)
                    referenceRelationship.SerializedReferenceRelationship.Delete();

                if (referenceRelationship.Source != null)
                    if (referenceRelationship.Source.RolePlayer != null)
                    {
                        SerializationHelper.UpdateDerivedElementsSerializationProperties(referenceRelationship.Source.RolePlayer);
                        SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(referenceRelationship.Source.RolePlayer);
                    }

                if (referenceRelationship.Target != null)
                    if (referenceRelationship.Target.RolePlayer != null)
                    {
                        SerializationHelper.UpdateDerivedElementsSerializationProperties(referenceRelationship.Target.RolePlayer);
                        SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(referenceRelationship.Target.RolePlayer);
                    }
            }

            EmbeddingRelationship embeddingRelationship = e.ModelElement as EmbeddingRelationship;
            if (embeddingRelationship != null)
            {
                if (embeddingRelationship.SerializedEmbeddingRelationship != null)
                    embeddingRelationship.SerializedEmbeddingRelationship.Delete();

                if (embeddingRelationship.Source != null)
                    if (embeddingRelationship.Source.RolePlayer != null)
                    {
                        SerializationHelper.UpdateDerivedElementsSerializationProperties(embeddingRelationship.Source.RolePlayer);
                        SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(embeddingRelationship.Source.RolePlayer);
                    }

                if( embeddingRelationship.Target != null )
                    if (embeddingRelationship.Target.RolePlayer != null)
                    {
                        SerializationHelper.UpdateDerivedElementsSerializationProperties(embeddingRelationship.Target.RolePlayer);
                        SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(embeddingRelationship.Target.RolePlayer);
                    }
            }

            DomainClassReferencesBaseClass inhRelationship = e.ModelElement as DomainClassReferencesBaseClass;
            if (inhRelationship != null)
            {
                inhRelationship.DerivedClass.BaseClass = null;

                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationship.DerivedClass);
                SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(inhRelationship.DerivedClass);
            }

            DomainRelationshipReferencesBaseRelationship inhRelationshipRel = e.ModelElement as DomainRelationshipReferencesBaseRelationship;
            if (inhRelationshipRel != null)
            {
                inhRelationshipRel.DerivedRelationship.BaseRelationship = null;

                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationshipRel.DerivedRelationship);
            }
        }
    }
    
}
