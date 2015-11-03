using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedEmbeddingRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class SerializedEmbeddingRelationshipChangedRule : ChangeRule
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

            SerializedEmbeddingRelationship serializedEmbeddingRelationship = e.ModelElement as SerializedEmbeddingRelationship;
            if (serializedEmbeddingRelationship != null)
            {
                if (e.DomainProperty.Id == SerializedEmbeddingRelationship.SerializationNameDomainPropertyId)
                {
                    if (serializedEmbeddingRelationship.IsSerializationNameTracking == TrackingEnum.True)
                        serializedEmbeddingRelationship.IsSerializationNameTracking = TrackingEnum.False;
                    else if (serializedEmbeddingRelationship.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        serializedEmbeddingRelationship.IsSerializationNameTracking = TrackingEnum.True;

                    if (serializedEmbeddingRelationship.EmbeddingRelationship.SerializationName != serializedEmbeddingRelationship.SerializationName)
                    {
                        serializedEmbeddingRelationship.EmbeddingRelationship.SerializationName = serializedEmbeddingRelationship.SerializationName;
                        serializedEmbeddingRelationship.EmbeddingRelationship.IsSerializationNameTracking = serializedEmbeddingRelationship.IsSerializationNameTracking;
                    }
                }
            }
        }
    }
}
