using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(EnumerationLiteral), FireTime = TimeToFire.TopLevelCommit)]
    public class EnumerationLiteralAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
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
                if (enumerationLiteral.DisplayName == "")
                {
                    enumerationLiteral.DisplayName = StringHelper.BreakUpper(enumerationLiteral.Name);
                    enumerationLiteral.IsDisplayNameTracking = TrackingEnum.IgnoreOnce;
                }

                if (enumerationLiteral.SerializationName == "")
                {
                    enumerationLiteral.SerializationName = enumerationLiteral.Name;
                    enumerationLiteral.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                }
            }
        }
    }
}
