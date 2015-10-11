using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainRole), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRolePropertyChangedRule : ChangeRule
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

            DomainRole domainRole = e.ModelElement as DomainRole;
            

            if (domainRole != null)
            {
                if (domainRole.IsDeleted || domainRole.IsDeleting)
                    return;

                if (domainRole.Relationship.IsDeleted || domainRole.Relationship.IsDeleting)
                    return;

                if (e.DomainProperty.Id == DomainRole.NameDomainPropertyId)
                {
                    // display name tracking is already handled by NamedDomainElement
                    if (domainRole.IsNameTracking == TrackingEnum.True)
                        domainRole.IsNameTracking = TrackingEnum.False;
                    else if (domainRole.IsNameTracking == TrackingEnum.IgnoreOnce)
                        domainRole.IsNameTracking = TrackingEnum.True;

                    if (domainRole.Opposite != null)
                    {
                        if (domainRole.Opposite.IsPropertyNameTracking == TrackingEnum.True)
                        {
                            if (domainRole.Opposite.PropertyName != domainRole.Name)
                            {
                                domainRole.Opposite.PropertyName = domainRole.Name;
                                domainRole.Opposite.IsPropertyNameTracking = TrackingEnum.IgnoreOnce;
                            }
                        }
                    }

                    if (domainRole.Relationship.IsNameTracking == TrackingEnum.True)
                    {
                        string name;
                        if (domainRole.Relationship is EmbeddingRelationship)
                            name = EmbeddingRelationship.GenerateDomainRelationshipName(domainRole.Relationship);
                        else
                            name = ReferenceRelationship.GenerateDomainRelationshipName(domainRole.Relationship);

                        if (domainRole.Relationship.Name != name)
                        {
                            domainRole.Relationship.Name = name;
                            domainRole.Relationship.IsNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }

                    if (domainRole.Relationship is ReferenceRelationship)
                    {
                        ReferenceRelationship r = domainRole.Relationship as ReferenceRelationship;
                        if (domainRole == domainRole.Relationship.Source)
                        {
                            if (r.IsSerializationSourceNameTracking == TrackingEnum.True)
                            {
                                string name = domainRole.Name + "Ref";
                                if (domainRole.Name == domainRole.Opposite.Name)
                                    name = domainRole.Name + "Source" + "Ref";

                                if (name != r.SerializationSourceName)
                                {
                                    r.SerializationSourceName = name;
                                    r.IsSerializationSourceNameTracking = TrackingEnum.IgnoreOnce;
                                }
                            }
                        }
                        else
                        {
                            if (r.IsSerializationTargetNameTracking == TrackingEnum.True)
                            {
                                string name = domainRole.Name + "Ref";
                                if (domainRole.Name == domainRole.Opposite.Name)
                                    name = domainRole.Name + "Target" + "Ref";

                                if (name != r.SerializationTargetName)
                                {
                                    r.SerializationTargetName = name;
                                    r.IsSerializationTargetNameTracking = TrackingEnum.IgnoreOnce;
                                }
                            }
                        }
                    }
                }
                else if (e.DomainProperty.Id == DomainRole.PropertyNameDomainPropertyId)
                {
                    if (domainRole.IsPropertyNameTracking == TrackingEnum.True)
                        domainRole.IsPropertyNameTracking = TrackingEnum.False;
                    else if (domainRole.IsPropertyNameTracking == TrackingEnum.IgnoreOnce)
                        domainRole.IsPropertyNameTracking = TrackingEnum.True;

                    if (domainRole.IsPropertyDisplayNameTracking == TrackingEnum.True)
                    {
                        if (domainRole.PropertyDisplayName != StringHelper.BreakUpper(domainRole.PropertyName))
                        {
                            domainRole.PropertyDisplayName = StringHelper.BreakUpper(domainRole.PropertyName);
                            domainRole.IsPropertyDisplayNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }
                }
                else if (e.DomainProperty.Id == DomainRole.PropertyDisplayNameDomainPropertyId)
                {
                    if (domainRole.IsPropertyDisplayNameTracking == TrackingEnum.True)
                        domainRole.IsPropertyDisplayNameTracking = TrackingEnum.False;
                    else if (domainRole.IsPropertyDisplayNameTracking == TrackingEnum.IgnoreOnce)
                        domainRole.IsPropertyDisplayNameTracking = TrackingEnum.True;
                }
            }
        }
    }
}
