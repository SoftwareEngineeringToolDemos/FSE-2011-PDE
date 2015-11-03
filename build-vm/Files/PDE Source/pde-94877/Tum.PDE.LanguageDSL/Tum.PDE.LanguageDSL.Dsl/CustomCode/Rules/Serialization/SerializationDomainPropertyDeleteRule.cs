using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainProperty), FireTime = TimeToFire.Inline)]
    public class SerializationDomainPropertyDeleteRule : DeletingRule
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

            DomainProperty domainProperty = e.ModelElement as DomainProperty;
            if (domainProperty != null)
            {
                AttributedDomainElement element = domainProperty.Element;
                domainProperty.Element = null;

                // update properties
                SerializationHelper.UpdateDerivedElementsSerializationProperties(element);
            }
        }
    }
}
