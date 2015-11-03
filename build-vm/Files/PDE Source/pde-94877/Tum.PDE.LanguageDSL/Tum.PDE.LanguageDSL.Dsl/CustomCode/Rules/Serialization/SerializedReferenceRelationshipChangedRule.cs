using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedReferenceRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializedReferenceRelationshipChangedRule : ChangeRule
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

            SerializedReferenceRelationship serializedReferenceRelationship = e.ModelElement as SerializedReferenceRelationship;
            if (serializedReferenceRelationship != null)
            {
                if (serializedReferenceRelationship.IsSerializationNameTracking == TrackingEnum.True)
                    serializedReferenceRelationship.IsSerializationNameTracking = TrackingEnum.False;
                else if (serializedReferenceRelationship.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                    serializedReferenceRelationship.IsSerializationNameTracking = TrackingEnum.True;

                if (serializedReferenceRelationship.ReferenceRelationship.SerializationName != serializedReferenceRelationship.SerializationName)
                {
                    serializedReferenceRelationship.ReferenceRelationship.SerializationName = serializedReferenceRelationship.SerializationName;
                    serializedReferenceRelationship.ReferenceRelationship.IsSerializationNameTracking = serializedReferenceRelationship.IsSerializationNameTracking;
                }
            }
        }
    }
}
