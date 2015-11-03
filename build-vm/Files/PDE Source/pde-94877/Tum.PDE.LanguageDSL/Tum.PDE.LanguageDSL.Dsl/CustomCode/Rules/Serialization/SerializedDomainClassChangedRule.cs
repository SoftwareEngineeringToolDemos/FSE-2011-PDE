using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedDomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializedDomainClassChangedRule : ChangeRule
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

            SerializedDomainClass serializedDomainClass = e.ModelElement as SerializedDomainClass;
            if (serializedDomainClass != null)
            {
                if (e.DomainProperty.Id == SerializedDomainClass.SerializationNameDomainPropertyId)
                {
                    if (serializedDomainClass.IsSerializationNameTracking == TrackingEnum.True)
                        serializedDomainClass.IsSerializationNameTracking = TrackingEnum.False;
                    else if (serializedDomainClass.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        serializedDomainClass.IsSerializationNameTracking = TrackingEnum.True;

                    if (serializedDomainClass.DomainClass.SerializationName != serializedDomainClass.SerializationName)
                    {
                        serializedDomainClass.DomainClass.SerializationName = serializedDomainClass.SerializationName;
                        serializedDomainClass.DomainClass.IsSerializationNameTracking = serializedDomainClass.IsSerializationNameTracking;
                    }
                }
            }
        }
    }
}
