using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClass), FireTime = TimeToFire.Inline)]
    public class DomainClassDeleteRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            DomainClass domainClass = e.ModelElement as DomainClass;
            if (domainClass != null)
            {
                for (int i = domainClass.DomainModelTreeNodes.Count - 1; i >= 0; i--)
                    if (i < domainClass.DomainModelTreeNodes.Count)
                        domainClass.DomainModelTreeNodes[i].Delete();
            }

            List<DomainRole> roles = new List<DomainRole>();
            foreach (DomainRole role in domainClass.RolesPlayed)
                roles.Add(role);

            for (int i = roles.Count - 1; i >= 0; i--)
                if (roles[i] != null)
                    if (roles[i].Relationship != null)
                        roles[i].Relationship.Delete();
        }
    }
}
