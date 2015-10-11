using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializationDomainClassAddRule : AddRule
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
                OnDomainClassAdded(domainClass);
            }
        }

        public static void OnDomainClassAdded(DomainClass domainClass)
        {
            if (domainClass.SerializedDomainClass == null)
            {
                SerializedDomainClass child = new SerializedDomainClass(domainClass.Store);
                child.DomainClass = domainClass;
                child.SerializationName = domainClass.SerializationName;

                domainClass.ModelContext.SerializationModel.Children.Add(child);
                SerializationHelper.AddSerializationDomainProperties(domainClass.Store, domainClass);
            }
        }
    }
}
