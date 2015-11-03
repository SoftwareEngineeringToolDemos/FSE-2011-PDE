using System;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.TopLevelCommit)]
    [RuleOn(typeof(DomainRelationshipReferencesBaseRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRelationshipAddRule : AddRule
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

            DomainClassReferencesBaseClass con = e.ModelElement as DomainClassReferencesBaseClass;
            if (con != null)
                if (con.BaseClass != null)
                {
                    InheritanceNode inhNode = con.Store.ElementDirectory.FindElement(con.InhNodeId) as InheritanceNode;
                    if (inhNode == null && ImmutabilityExtensionMethods.GetLocks(con.BaseClass) == Locks.None)
                    {
                        // connection was created using the property window and not the menu item, so create a new
                        // inheritance node to display the inheritance relationship
                        TreeNode elementHolderNode = null;
                        foreach (TreeNode node in con.BaseClass.DomainModelTreeNodes)
                            if (node.IsElementHolder)
                            {
                                elementHolderNode = node;
                                break;
                            }

                        if (elementHolderNode == null)
                            throw new ArgumentNullException("elementHolderNode");

                        // create new inheritance node
                        inhNode = new InheritanceNode(con.Store);
                        inhNode.DomainElement = con.DerivedClass;
                        inhNode.IsElementHolder = false;
                        inhNode.IsExpanded = false;
                        inhNode.InhRelationshipId = con.Id;
                        con.InhNodeId = inhNode.Id;

                        elementHolderNode.InheritanceNodes.Add(inhNode);
                        con.DerivedClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(inhNode);
                    }
                }

            DomainRelationshipReferencesBaseRelationship conRef = e.ModelElement as DomainRelationshipReferencesBaseRelationship;
            if (conRef != null)
                if (conRef.BaseRelationship is ReferenceRelationship && conRef.DerivedRelationship is ReferenceRelationship)
                {
                    ReferenceRelationship rBase = conRef.BaseRelationship as ReferenceRelationship;
                    ReferenceRelationship rDer = conRef.DerivedRelationship as ReferenceRelationship;
                    if( rBase.SerializedReferenceRelationship != null && rDer.SerializedReferenceRelationship != null)
                        if (rBase.SerializedReferenceRelationship.IsInFullSerialization)
                            if (!rDer.SerializedReferenceRelationship.IsInFullSerialization)
                            {
                                // we have to automatically change the serialization mode of the derived class to full serialization mode
                                rDer.SerializedReferenceRelationship.IsInFullSerialization = true;
                            }
                }
                else if (conRef.BaseRelationship is EmbeddingRelationship && conRef.DerivedRelationship is EmbeddingRelationship)
                {
                    EmbeddingRelationship rBase = conRef.BaseRelationship as EmbeddingRelationship;
                    EmbeddingRelationship rDer = conRef.DerivedRelationship as EmbeddingRelationship;
                    if (rBase.SerializedEmbeddingRelationship != null && rDer.SerializedEmbeddingRelationship != null)
                        if (rBase.SerializedEmbeddingRelationship.IsInFullSerialization)
                            if (!rDer.SerializedEmbeddingRelationship.IsInFullSerialization)
                            {
                                // we have to automatically change the serialization mode of the derived class to full serialization mode
                                rDer.SerializedEmbeddingRelationship.IsInFullSerialization = true;
                            }
                }            
        }
    }
}
