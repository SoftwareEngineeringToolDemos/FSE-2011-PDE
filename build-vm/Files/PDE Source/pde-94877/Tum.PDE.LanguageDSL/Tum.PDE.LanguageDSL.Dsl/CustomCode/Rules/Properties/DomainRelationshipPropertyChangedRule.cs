using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRelationshipPropertyChangedRule : ChangeRule
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

            DomainRelationship domainRelationship = e.ModelElement as DomainRelationship;
            if (domainRelationship != null)
            {
                if (e.DomainProperty.Id == DomainRelationship.NameDomainPropertyId)
                {
                    if (domainRelationship.IsNameTracking == TrackingEnum.True)
                        domainRelationship.IsNameTracking = TrackingEnum.False;
                    else if (domainRelationship.IsNameTracking == TrackingEnum.IgnoreOnce)
                        domainRelationship.IsNameTracking = TrackingEnum.True;
                                        
                    foreach (DomainRole role in domainRelationship.RolesPlayed)
                    {
                        if (role.IsNameTracking == TrackingEnum.True)
                        {
                            if (role.Name != domainRelationship.Name)
                            {
                                role.Name = domainRelationship.Name;
                                role.IsNameTracking = TrackingEnum.IgnoreOnce;
                            }
                        }
                    }
                }
                else if (e.DomainProperty.Id == DomainRelationship.InheritanceModifierDomainPropertyId)
                {
                    if (((InheritanceModifier)e.NewValue) == InheritanceModifier.Abstract || ((InheritanceModifier)e.OldValue) == InheritanceModifier.Abstract)
                    {
                        SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(domainRelationship.Source.RolePlayer);
                    }
                }
            }
        }
    }
}
