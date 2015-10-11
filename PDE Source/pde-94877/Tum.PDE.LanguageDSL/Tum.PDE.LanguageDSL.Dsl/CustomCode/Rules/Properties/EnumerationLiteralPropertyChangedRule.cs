using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(EnumerationLiteral), FireTime = TimeToFire.TopLevelCommit)]
    public class EnumerationLiteralPropertyChangedRule : ChangeRule
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

            EnumerationLiteral enumerationLiteral = e.ModelElement as EnumerationLiteral;
            if (enumerationLiteral != null)
            {
                if (e.DomainProperty.Id == EnumerationLiteral.NameDomainPropertyId)
                {
                    if (enumerationLiteral.IsDisplayNameTracking == TrackingEnum.True)
                    {
                        if (enumerationLiteral.DisplayName != StringHelper.BreakUpper(enumerationLiteral.Name))
                        {
                            enumerationLiteral.DisplayName = StringHelper.BreakUpper(enumerationLiteral.Name);
                            enumerationLiteral.IsDisplayNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }
                    if (enumerationLiteral.IsSerializationNameTracking == TrackingEnum.True)
                    {
                        if (enumerationLiteral.SerializationName != enumerationLiteral.Name)
                        {
                            enumerationLiteral.SerializationName = enumerationLiteral.Name;
                            enumerationLiteral.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                        }
                    }
                }
                else if (e.DomainProperty.Id == EnumerationLiteral.DisplayNameDomainPropertyId)
                {
                    if (enumerationLiteral.IsDisplayNameTracking == TrackingEnum.IgnoreOnce)
                        enumerationLiteral.IsDisplayNameTracking = TrackingEnum.True;
                    else if (enumerationLiteral.IsDisplayNameTracking == TrackingEnum.True)
                        enumerationLiteral.IsDisplayNameTracking = TrackingEnum.False;
                }
                else if (e.DomainProperty.Id == EnumerationLiteral.SerializationNameDomainPropertyId)
                {
                    if (enumerationLiteral.IsSerializationNameTracking == TrackingEnum.IgnoreOnce)
                        enumerationLiteral.IsSerializationNameTracking = TrackingEnum.True;
                    else if (enumerationLiteral.IsSerializationNameTracking == TrackingEnum.True)
                        enumerationLiteral.IsSerializationNameTracking = TrackingEnum.False;
                }
            }
        }
    }
}
