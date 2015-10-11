using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainClassPropertyChangedRule : ChangeRule
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

            DomainClass domainClass = e.ModelElement as DomainClass;
            if (domainClass != null)
            {
                if (e.DomainProperty.Id == DomainClass.SerializationNameDomainPropertyId)
                {
                    SerializedDomainClass c = domainClass.SerializedDomainClass;
                    if (c != null)
                        if (c.SerializationName != domainClass.SerializationName)
                        {
                            c.SerializationName = domainClass.SerializationName;
                            if (domainClass.IsSerializationNameTracking != TrackingEnum.False)
                                c.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                            else
                                c.IsSerializationNameTracking = TrackingEnum.False;
                        }
                }
                else if (e.DomainProperty.Id == DomainClass.NameDomainPropertyId)
                {
                    foreach (DomainRole role in domainClass.RolesPlayed)
                    {
                        if (ImmutabilityExtensionMethods.GetLocks(role) != Locks.None)
                            continue;

                        if (role.IsNameTracking == TrackingEnum.True)
                        {
                            if (role.Name != domainClass.Name)
                            {
                                if (role.RolePlayer == role.Opposite.RolePlayer)
                                {
                                    if (role.Relationship.Source == role)
                                        role.Name = domainClass.Name + "Source";
                                    else
                                        role.Name = domainClass.Name + "Target";
                                }
                                else
                                    role.Name = domainClass.Name;
                                role.IsNameTracking = TrackingEnum.IgnoreOnce;
                            }
                        }
                    }
                }
            }
        }
    }
}
