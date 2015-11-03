using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializationModel), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializationModelPropertyChangeRule : ChangeRule
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

            SerializationModel serializationModel = e.ModelElement as SerializationModel;
            if (serializationModel != null)
            {
                string idElementName = serializationModel.SerializedIdAttributeName;
                if (serializationModel.SerializedDomainModel != null)
                    serializationModel.SerializedDomainModel.SerializedIdAttributeName = idElementName;

                foreach(SerializationClass s in serializationModel.Children )
                    if( s.IdProperty != null )
                        s.IdProperty.SerializationName = idElementName;

                if (serializationModel.SerializedDomainModel != null)
                    if( serializationModel.SerializedDomainModel.IdProperty != null )
                        serializationModel.SerializedDomainModel.IdProperty.SerializationName = idElementName;
                /*
                
                ReadOnlyCollection<ModelElement> elements = serializationModel.Store.ElementDirectory.FindElements(SerializedIdProperty.DomainClassId);
                foreach (ModelElement m in elements)
                    (m as SerializedIdProperty).SerializationName = idElementName;

                
                */
            }
        }
    }
}
