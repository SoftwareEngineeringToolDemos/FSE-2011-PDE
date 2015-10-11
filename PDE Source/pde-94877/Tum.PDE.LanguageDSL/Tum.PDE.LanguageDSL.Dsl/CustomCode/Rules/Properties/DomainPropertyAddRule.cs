using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainPropertyAddRule : AddRule
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
                if (domainProperty.Type == null)
                    foreach (DomainType type in domainProperty.Element.ParentModelContext.MetaModel.DomainTypes)
                        if (type.Name == "String")
                        {
                            domainProperty.Type = type;
                            break;
                        }

                if (domainProperty.SerializationName == "")
                {
                    domainProperty.SerializationName = domainProperty.Name;
                    domainProperty.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                }
            }
        }
    }
}
