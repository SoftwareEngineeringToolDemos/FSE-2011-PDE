using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainEnumeration), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainEnumerationAddRule : AddRule
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

            DomainEnumeration domainEnumeration = e.ModelElement as DomainEnumeration;
            if (domainEnumeration != null)
            {
                foreach(PropertyGridEditor pEditor in domainEnumeration.MetaModel.PropertyGridEditors)
                    if (pEditor.Name == "EnumerationEditorViewModel")
                    {
                        domainEnumeration.PropertyGridEditor = pEditor;
                        break;
                    }
            }
        }
    }
}
