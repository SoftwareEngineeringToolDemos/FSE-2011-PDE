using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainRoleReferencesCustomPropertyGridEditor), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRoleReferencesCPGEChangeRule : RolePlayerChangeRule
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

            DomainRoleReferencesCustomPropertyGridEditor con = e.ElementLink as DomainRoleReferencesCustomPropertyGridEditor;
            if (con != null)
            {
                if (con.DomainRole.Relationship is EmbeddingRelationship)
                    (con.DomainRole.Relationship as EmbeddingRelationship).SerializedEmbeddingRelationship.IsTargetIncludedSubmodel = true;
            }
        }
    }
}
