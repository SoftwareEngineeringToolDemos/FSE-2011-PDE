using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// This rule is used to update the display name or the display name tracking value of a NamedDomainElement.
    /// </summary>
    [RuleOn(typeof(DomainType), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainTypePropertyChangeRule : ChangeRule
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

            DomainType namedDomainElement = e.ModelElement as DomainType;
            if (namedDomainElement != null)
            {
                if (e.DomainProperty.Id == DomainType.NameDomainPropertyId)
                {
                    if (namedDomainElement.IsDisplayNameTracking == TrackingEnum.True)
                    {
                        if (namedDomainElement.Name.Trim() != namedDomainElement.DisplayName &&
                            namedDomainElement.DisplayName != StringHelper.BreakUpper(namedDomainElement.Name))
                        {
                            namedDomainElement.DisplayName = StringHelper.BreakUpper(namedDomainElement.Name);
                            namedDomainElement.IsDisplayNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }
                }
                else if (e.DomainProperty.Id == DomainType.DisplayNameDomainPropertyId)
                {
                    if (namedDomainElement.IsDisplayNameTracking == TrackingEnum.True)
                        namedDomainElement.IsDisplayNameTracking = TrackingEnum.False;
                    else if (namedDomainElement.IsDisplayNameTracking == TrackingEnum.IgnoreOnce)
                        namedDomainElement.IsDisplayNameTracking = TrackingEnum.True;
                }
            }
        }
    }
}
