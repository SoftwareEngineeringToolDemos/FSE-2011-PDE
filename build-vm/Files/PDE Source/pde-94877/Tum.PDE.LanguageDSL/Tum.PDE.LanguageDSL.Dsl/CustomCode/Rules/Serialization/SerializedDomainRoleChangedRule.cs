using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(SerializedDomainRole), FireTime = TimeToFire.TopLevelCommit)]
    class SerializedDomainRoleChangedRule : ChangeRule
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

            SerializedDomainRole serializedDomainRole = e.ModelElement as SerializedDomainRole;
            if (serializedDomainRole != null)
            {
                if (e.DomainProperty.Id == SerializedDomainRole.SerializationNameDomainPropertyId && serializedDomainRole.DomainRole.Relationship is ReferenceRelationship)
                {
                    if (serializedDomainRole.DomainRole == serializedDomainRole.DomainRole.Relationship.Source)
                    {
                        //if ((serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationSourceName != serializedDomainRole.SerializationName)
                        //    (serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationSourceName = serializedDomainRole.SerializationName;
                    }
                    else
                    {
                        if ((serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationTargetName != serializedDomainRole.SerializationName)
                            (serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationTargetName = serializedDomainRole.SerializationName;
                    }
                }
                else if (e.DomainProperty.Id == SerializedDomainRole.SerializationAttributeNameDomainPropertyId && serializedDomainRole.DomainRole.Relationship is ReferenceRelationship)
                {
                    //if ((serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationAttributeName != serializedDomainRole.SerializationAttributeName)
                    //    (serializedDomainRole.DomainRole.Relationship as ReferenceRelationship).SerializationAttributeName = serializedDomainRole.SerializationAttributeName;
                }
            }
        }
    }
}
