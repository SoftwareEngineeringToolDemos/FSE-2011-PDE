using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainRoleReferencesCustomPropertyGridEditor), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRoleReferencesCPGEAddRule : AddRule
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

            DomainRoleReferencesCustomPropertyGridEditor con = e.ModelElement as DomainRoleReferencesCustomPropertyGridEditor;
            if (con != null)
            {
                if (con.DomainRole.Relationship is EmbeddingRelationship)
                    (con.DomainRole.Relationship as EmbeddingRelationship).SerializedEmbeddingRelationship.IsTargetIncludedSubmodel = true;
            }
        }
    }
}
