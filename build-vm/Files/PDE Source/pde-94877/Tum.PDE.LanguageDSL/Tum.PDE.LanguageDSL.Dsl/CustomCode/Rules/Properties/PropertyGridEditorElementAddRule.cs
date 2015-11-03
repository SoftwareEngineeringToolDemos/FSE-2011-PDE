using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(PropertyGridEditor), FireTime = TimeToFire.TopLevelCommit)]
    public class PropertyGridEditorElementAddRule : AddRule
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

            PropertyGridEditor propertyGridEditor = e.ModelElement as PropertyGridEditor;
            if (propertyGridEditor != null)
            {
                if( System.String.IsNullOrEmpty(propertyGridEditor.Namespace) || 
                    System.String.IsNullOrWhiteSpace(propertyGridEditor.Namespace))
                    propertyGridEditor.Namespace = propertyGridEditor.MetaModel.Namespace;
            }
        }
    }
}
