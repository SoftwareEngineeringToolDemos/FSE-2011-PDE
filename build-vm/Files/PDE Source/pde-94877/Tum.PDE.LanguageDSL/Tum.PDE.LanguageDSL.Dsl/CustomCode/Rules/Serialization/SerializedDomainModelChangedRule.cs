using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedDomainModel), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializedDomainModelChangedRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            SerializedDomainModel serializedDomainModel = e.ModelElement as SerializedDomainModel;
            if (serializedDomainModel != null)
            {
                /*string idElementName = serializedDomainModel.SerializedIdAttributeName;
                ReadOnlyCollection<ModelElement> elements = serializedDomainModel.Store.ElementDirectory.FindElements(SerializedIdProperty.DomainClassId);
                foreach (ModelElement m in elements)
                    (m as SerializedIdProperty).SerializationName = idElementName;
                 * */
                serializedDomainModel.Model.SerializedIdAttributeName = serializedDomainModel.SerializedIdAttributeName;
            }
        }
    }
}
