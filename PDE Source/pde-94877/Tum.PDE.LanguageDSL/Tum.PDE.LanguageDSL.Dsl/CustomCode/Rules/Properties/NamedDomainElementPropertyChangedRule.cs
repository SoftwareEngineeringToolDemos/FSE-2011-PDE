using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// This rule is used to update the display name or the display name tracking value of a NamedDomainElement.
    /// </summary>
    [RuleOn(typeof(NamedDomainElement), FireTime = TimeToFire.TopLevelCommit)]
    public class NamedDomainElementPropertyChangedRule : ChangeRule
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

            NamedDomainElement namedDomainElement = e.ModelElement as NamedDomainElement;
            if (namedDomainElement != null)
            {
                if (namedDomainElement.IsDeleting || namedDomainElement.IsDeleted)
                    return;

                if (e.DomainProperty.Id == NamedDomainElement.NameDomainPropertyId)
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
                else if (e.DomainProperty.Id == NamedDomainElement.DisplayNameDomainPropertyId)
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
