using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainClassAddRule : AddRule
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

            DomainClass domainClass = e.ModelElement as DomainClass;
            if (domainClass != null)
            {
                if (domainClass.DomainModelTreeNodes.Count == 0)
                {
                    RootNode node = new RootNode(domainClass.Store);
                    node.DomainElement = domainClass;
                    node.IsElementHolder = true;

                    // add to the domain model diagram tree
                    domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(node);
                    domainClass.ModelContext.ViewContext.DomainModelTreeView.RootNodes.Add(node);
                }
            }
        }
    }
}
