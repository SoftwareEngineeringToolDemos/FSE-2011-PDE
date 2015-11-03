using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedDomainProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializedDomainPropertyChangedRule : ChangeRule
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

            SerializedDomainProperty serializedDomainProperty = e.ModelElement as SerializedDomainProperty;
            if (serializedDomainProperty != null)
            {
                if (e.DomainProperty.Id == SerializedDomainProperty.SerializationNameDomainPropertyId)
                {
                    if (serializedDomainProperty.IsSerializationNameTracking == TrackingEnum.True)
                        serializedDomainProperty.IsSerializationNameTracking = TrackingEnum.False;
                    else if (serializedDomainProperty.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        serializedDomainProperty.IsSerializationNameTracking = TrackingEnum.True;

                    if (serializedDomainProperty.DomainProperty.SerializationName != serializedDomainProperty.SerializationName)
                    {
                        serializedDomainProperty.DomainProperty.SerializationName = serializedDomainProperty.SerializationName;
                        serializedDomainProperty.DomainProperty.IsSerializationNameTracking = serializedDomainProperty.IsSerializationNameTracking;
                    }
                }
                else if (e.DomainProperty.Id == SerializedDomainProperty.SerializationRepresentationTypeDomainPropertyId)
                {
                    serializedDomainProperty.DomainProperty.SerializationRepresentationType = serializedDomainProperty.SerializationRepresentationType;

                    if( serializedDomainProperty.SerializationRepresentationType != SerializationRepresentationType.Attribute )
                        for (int i = serializedDomainProperty.ParentAttributedElements.Count - 1; i >= 0; i--)
                        {
                            serializedDomainProperty.ParentAttributedElements[i].Children.Add(serializedDomainProperty);
                            serializedDomainProperty.ParentAttributedElements[i].Attributes.Remove(serializedDomainProperty);
                        }

                    if (serializedDomainProperty.SerializationRepresentationType == SerializationRepresentationType.Attribute)
                        for (int i = serializedDomainProperty.ParentEmbeddedElements.Count - 1; i >= 0; i--)
                        {
                            serializedDomainProperty.ParentEmbeddedElements[i].Attributes.Add(serializedDomainProperty);
                            serializedDomainProperty.ParentEmbeddedElements[i].Children.Remove(serializedDomainProperty);
                        }
                }
            }
        }
    }
}
