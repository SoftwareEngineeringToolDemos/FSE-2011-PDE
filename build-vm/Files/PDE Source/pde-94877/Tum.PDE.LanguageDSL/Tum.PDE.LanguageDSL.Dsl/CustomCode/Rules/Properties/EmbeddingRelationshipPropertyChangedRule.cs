using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(EmbeddingRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class EmbeddingRelationshipPropertyChangedRule : ChangeRule
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

            EmbeddingRelationship embeddingRelationship = e.ModelElement as EmbeddingRelationship;
            if (embeddingRelationship != null)
            {
                if (e.DomainProperty.Id == EmbeddingRelationship.SerializationNameDomainPropertyId)
                {
                    SerializedEmbeddingRelationship c = embeddingRelationship.SerializedEmbeddingRelationship;
                    if (c.SerializationName != embeddingRelationship.SerializationName)
                    {
                        c.SerializationName = embeddingRelationship.SerializationName;
                        if (embeddingRelationship.IsSerializationNameTracking != TrackingEnum.False)
                            c.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                        else
                            c.IsSerializationNameTracking = TrackingEnum.False;
                    }
                }
            }
        }
    }
}
