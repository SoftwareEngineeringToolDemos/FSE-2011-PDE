using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(AttributedDomainElement), FireTime = TimeToFire.TopLevelCommit)]
    public class AttributedDomainElementPropertyChangedRule : ChangeRule
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

            AttributedDomainElement attributedDomainElement = e.ModelElement as AttributedDomainElement;
            if (attributedDomainElement != null)
            {
                if (e.DomainProperty.Id == AttributedDomainElement.NameDomainPropertyId)
                {
                    if (attributedDomainElement.IsSerializationNameTracking == TrackingEnum.True)
                    {
                        if (attributedDomainElement.SerializationName != attributedDomainElement.Name)
                        {
                            attributedDomainElement.SerializationName = attributedDomainElement.Name;
                            attributedDomainElement.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }
                }
                else if (e.DomainProperty.Id == AttributedDomainElement.SerializationNameDomainPropertyId)
                {
                    if (attributedDomainElement.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        attributedDomainElement.IsSerializationNameTracking = TrackingEnum.True;
                    else if (attributedDomainElement.IsSerializationNameTracking == TrackingEnum.True)
                        attributedDomainElement.IsSerializationNameTracking = TrackingEnum.False;
                }
            }                 
        }
    }
}
