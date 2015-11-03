using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(AttributedDomainElement), FireTime = TimeToFire.TopLevelCommit)]
    public class AttributedDomainElementAddRule : AddRule
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

            AttributedDomainElement attributedDomainElement = e.ModelElement as AttributedDomainElement;

            if (attributedDomainElement != null)
            {
                if (attributedDomainElement.IsDeleted || attributedDomainElement.IsDeleting)
                    return;

                if (attributedDomainElement is DomainRelationship)
                {
                    string name;
                    if (attributedDomainElement is EmbeddingRelationship)
                        name = EmbeddingRelationship.GenerateDomainRelationshipName((attributedDomainElement as DomainRelationship));
                    else
                        name = ReferenceRelationship.GenerateDomainRelationshipName((attributedDomainElement as DomainRelationship));

                    
                    if (attributedDomainElement.Name == "")
                    {
                        attributedDomainElement.Name = name;
                        (attributedDomainElement as DomainRelationship).IsNameTracking = TrackingEnum.IgnoreOnce;
                    }
                }

                //if (attributedDomainElement.SerializationName != attributedDomainElement.Name)
                if (attributedDomainElement.SerializationName == "" || attributedDomainElement.SerializationName == null)
                {
                    attributedDomainElement.SerializationName = attributedDomainElement.Name;
                    attributedDomainElement.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
                }

                attributedDomainElement.Namespace = attributedDomainElement.ParentModelContext.MetaModel.Namespace;
            }
        }
    }
}
