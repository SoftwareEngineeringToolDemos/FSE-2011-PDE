using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainType), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainTypeAddRule : AddRule
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
            
            DomainType domainType = e.ModelElement as DomainType;
            if (domainType != null)
            {
                if (domainType.MetaModel != null)
                    if (domainType.Namespace == "" || domainType.Namespace == null)
                        domainType.Namespace = domainType.MetaModel.Namespace;
            }
        }

    }
}
