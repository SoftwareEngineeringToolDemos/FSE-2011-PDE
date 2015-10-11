using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{ 
    [RuleOn(typeof(ReferenceRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class ReferenceRelationshipPropertyChangedRule : ChangeRule
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

            ReferenceRelationship referenceRelationship = e.ModelElement as ReferenceRelationship;
            if (referenceRelationship != null)
            {
                if (e.DomainProperty.Id == ReferenceRelationship.SerializationNameDomainPropertyId)
                {
                    SerializedReferenceRelationship c = referenceRelationship.SerializedReferenceRelationship;
                    if (c.SerializationName != referenceRelationship.SerializationName)
                    {
                        c.SerializationName = referenceRelationship.SerializationName;
                        if (referenceRelationship.IsSerializationNameTracking != TrackingEnum.False)
                            c.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                        else
                            c.IsSerializationNameTracking = TrackingEnum.False;
                    }
                }
                else if (e.DomainProperty.Id == ReferenceRelationship.SerializationAttributeNameDomainPropertyId)
                {
                    SerializedReferenceRelationship r = referenceRelationship.SerializedReferenceRelationship;
                    foreach (SerializedDomainRole domainRole in r.SerializedDomainRoles)
                        domainRole.SerializationAttributeName = referenceRelationship.SerializationAttributeName;
                }
                else if (e.DomainProperty.Id == ReferenceRelationship.SerializationSourceNameDomainPropertyId)
                {
                    if (referenceRelationship.IsSerializationSourceNameTracking == TrackingEnum.True)
                        referenceRelationship.IsSerializationSourceNameTracking = TrackingEnum.False;
                    else if( referenceRelationship.IsSerializationSourceNameTracking == TrackingEnum.IgnoreOnce)
                        referenceRelationship.IsSerializationSourceNameTracking = TrackingEnum.True;

                    foreach (SerializedDomainRole r in referenceRelationship.Source.SerializedDomainRoles)
                        r.SerializationName = referenceRelationship.SerializationSourceName;
                }
                else if (e.DomainProperty.Id == ReferenceRelationship.SerializationTargetNameDomainPropertyId)
                {
                    if (referenceRelationship.IsSerializationTargetNameTracking == TrackingEnum.True)
                        referenceRelationship.IsSerializationTargetNameTracking = TrackingEnum.False;
                    else if (referenceRelationship.IsSerializationTargetNameTracking == TrackingEnum.IgnoreOnce)
                        referenceRelationship.IsSerializationTargetNameTracking = TrackingEnum.True;

                    foreach (SerializedDomainRole r in referenceRelationship.Target.SerializedDomainRoles)
                        r.SerializationName = referenceRelationship.SerializationTargetName;
                }
            }
        }
    }
}
