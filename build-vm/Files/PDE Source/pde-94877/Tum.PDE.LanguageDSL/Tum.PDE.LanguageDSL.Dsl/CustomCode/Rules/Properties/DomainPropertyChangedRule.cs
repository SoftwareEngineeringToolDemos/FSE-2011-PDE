using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// This rule is used to update the display name and the serialization name or 
    /// the display name/serialization name tracking values of a DomainProperty.
    /// </summary>
    [RuleOn(typeof(DomainProperty), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainPropertyChangedRule : ChangeRule
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

            DomainProperty domainProperty = e.ModelElement as DomainProperty;
            if (domainProperty != null)
            {
                if (e.DomainProperty.Id == DomainProperty.NameDomainPropertyId)
                {
                    if (domainProperty.IsDisplayNameTracking == TrackingEnum.True)
                    {
                        if (domainProperty.DisplayName != StringHelper.BreakUpper(domainProperty.Name))
                        {
                            domainProperty.DisplayName = StringHelper.BreakUpper(domainProperty.Name);
                            domainProperty.IsDisplayNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }

                    if (domainProperty.IsSerializationNameTracking == TrackingEnum.True)
                    {
                        domainProperty.SerializationName = domainProperty.Name;
                        domainProperty.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                    }
                }
                else if (e.DomainProperty.Id == DomainProperty.DisplayNameDomainPropertyId)
                {
                    if (domainProperty.IsDisplayNameTracking == TrackingEnum.True)
                        domainProperty.IsDisplayNameTracking = TrackingEnum.False;
                    else if (domainProperty.IsDisplayNameTracking == TrackingEnum.IgnoreOnce)
                        domainProperty.IsDisplayNameTracking = TrackingEnum.True;
                }
                else if (e.DomainProperty.Id == DomainProperty.SerializationNameDomainPropertyId)
                {
                    if (domainProperty.SerializedDomainProperty != null)
                    {
                        if (domainProperty.SerializedDomainProperty.SerializationName != domainProperty.SerializationName)
                        {
                            domainProperty.SerializedDomainProperty.SerializationName = domainProperty.SerializationName;

                            if (domainProperty.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                                domainProperty.SerializedDomainProperty.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                            else
                                domainProperty.SerializedDomainProperty.IsSerializationNameTracking = TrackingEnum.False;
                        }
                    }

                    if (domainProperty.IsSerializationNameTracking == TrackingEnum.True)
                        domainProperty.IsSerializationNameTracking = TrackingEnum.False;
                   
                    else if (domainProperty.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        domainProperty.IsSerializationNameTracking = TrackingEnum.True;
                }
                else if (e.DomainProperty.Id == DomainProperty.SerializationRepresentationTypeDomainPropertyId)
                {
                    if (domainProperty.SerializedDomainProperty != null)
                    {
                        domainProperty.SerializedDomainProperty.SerializationRepresentationType = domainProperty.SerializationRepresentationType;
                    }
                }
            }
        }
    }
}
