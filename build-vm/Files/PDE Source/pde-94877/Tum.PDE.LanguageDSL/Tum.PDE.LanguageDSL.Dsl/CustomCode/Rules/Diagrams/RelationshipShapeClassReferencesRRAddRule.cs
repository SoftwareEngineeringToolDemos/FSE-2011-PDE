using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(RelationshipShapeClassReferencesReferenceRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class RelationshipShapeClassReferencesRRAddRule : AddRule
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

            RelationshipShapeClassReferencesReferenceRelationship con = e.ModelElement as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
                if (con.DomainRelationship is ReferenceRelationship)
                {
                    ReferenceRelationship rel = con.DomainRelationship as ReferenceRelationship;
                    ReferenceRSNode node = rel.ReferenceRSNode;

                    // create new shape relationship node
                    ShapeRelationshipNode shapeNode = new ShapeRelationshipNode(con.Store);
                    shapeNode.RelationshipShapeClass = con.RelationshipShapeClass;

                    node.ShapeRelationshipNodes.Add(shapeNode);
                    rel.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(shapeNode);

                    if (rel.SerializedReferenceRelationship != null)
                        if (!rel.SerializedReferenceRelationship.IsInFullSerialization)
                        {
                            if (System.Windows.MessageBox.Show("Shape mapping has been defined for the ReferenceRelationship '" +
                                rel.Name + "'. The Relationship is not serialized in full form. Would you like to change the serialization of this relationship to full form (strongly adviced)?",
                                "Serialization",
                                System.Windows.MessageBoxButton.YesNo,
                                System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
                            {
                                rel.SerializedReferenceRelationship.IsInFullSerialization = true;
                            }
                        }
                }
        }
    }
}
