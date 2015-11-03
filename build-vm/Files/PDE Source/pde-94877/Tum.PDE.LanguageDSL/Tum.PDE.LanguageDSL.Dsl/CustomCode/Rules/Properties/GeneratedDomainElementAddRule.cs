using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(GeneratedDomainElement), FireTime = TimeToFire.TopLevelCommit)]
    public class GeneratedDomainElementAddRule : AddRule
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

            GeneratedDomainElement generatedDomainElement = e.ModelElement as GeneratedDomainElement;
            if (generatedDomainElement != null)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<ModelElement> elements = generatedDomainElement.Store.ElementDirectory.FindElements(DomainClass.DomainClassId);
                foreach (ModelElement m in elements)
                    if (m is DomainClass)
                        if ((m as DomainClass).IsDomainModel)
                        {
                            generatedDomainElement.Namespace = (m as DomainClass).Namespace;

                            return;
                        }
            }
        }
    }
}
