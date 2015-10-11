using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(RelationshipShapeClassReferencesReferenceRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class RelationshipShapeClassReferencesRRChangeRule : RolePlayerChangeRule
    {
        public override void RolePlayerChanged(RolePlayerChangedEventArgs e)
        {
            if (e.ElementLink != null)
                if (e.ElementLink.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ElementLink.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ElementLink == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ElementLink) != Locks.None)
                return;

            RelationshipShapeClassReferencesReferenceRelationship con = e.ElementLink as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
            {
                RelationshipShapeClass shape = con.RelationshipShapeClass;
                ShapeRelationshipNode node = shape.ShapeRelationshipNode;

                // delete old
                ReferenceRelationship relOld = e.OldRolePlayer as ReferenceRelationship;
                if (relOld != null)
                {
                    ReferenceRSNode nodeOld = relOld.ReferenceRSNode;
                    if (nodeOld != null)
                    {
                        node.RelationshipShapeClass = null;

                        if (nodeOld.ShapeRelationshipNodes.Contains(node))
                            nodeOld.ShapeRelationshipNodes.Remove(node);
                    }
                    node.Delete();
                }

                // create new
                ReferenceRelationship rel = e.NewRolePlayer as ReferenceRelationship;
                if (rel != null)
                {
                    ReferenceRSNode n = rel.ReferenceRSNode;

                    // create new shape relationship node
                    ShapeRelationshipNode shapeNode = new ShapeRelationshipNode(con.Store);
                    shape.ShapeRelationshipNode = shapeNode;

                    n.ShapeRelationshipNodes.Add(shapeNode);
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
}
