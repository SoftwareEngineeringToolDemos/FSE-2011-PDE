using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    [RuleOn(typeof(DomainRelationshipReferencesBaseRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    public class SerializationDomainRelationshipChangedRule : RolePlayerChangeRule
    {
        public override void RolePlayerChanged(RolePlayerChangedEventArgs e)
        {
            if (e.ElementLink != null)
                if (e.ElementLink.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ElementLink.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ElementLink == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ElementLink) != Locks.None)
                return;

            DomainClassReferencesBaseClass inhRelationship = e.ElementLink as DomainClassReferencesBaseClass;
            if (inhRelationship != null)
            {
                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationship.DerivedClass);
                SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(inhRelationship.DerivedClass);
            }

            DomainRelationshipReferencesBaseRelationship inhRelationshipRel = e.ElementLink as DomainRelationshipReferencesBaseRelationship;
            if (inhRelationshipRel != null)
            {
                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationshipRel.DerivedRelationship);
            }
        }
    }
}
