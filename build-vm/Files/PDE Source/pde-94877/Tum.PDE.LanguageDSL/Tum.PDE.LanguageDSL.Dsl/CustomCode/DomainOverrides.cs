using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tum.PDE.LanguageDSL
{
    public partial class LanguageDSLDomainModel
    {
        protected override Type[] GetCustomDomainModelTypes()
        {
            return new System.Type[] { 
                typeof(DomainClassAddRule),
                typeof(DomainClassDeleteRule),
                
                typeof(DomainRelationshipAddRule),
                typeof(DomainRelationshipChangedRule),
                typeof(DomainRelationshipDeleteRule),

                // View
                typeof(TreeNodeReferencesEmbeddingRSNodesDeleteRule),
                typeof(TreeNodeReferencesReferenceRSNodesDeleteRule),
                typeof(TreeNodeReferencesInheritanceNodesDeleteRule),
                
                typeof(ReferenceRSNodeReferencesSRNodesDeleteRule),

                typeof(ShapeClassNodeDeleteRule),
                typeof(ShapeRelationshipNodeDeleteRule),

                typeof(DiagramClassViewReferencesDCDeleteRule),
                typeof(DiagramTreeNodeReferencesPECDeleteRule),

                typeof(ShapeClassDeleteRule),
                typeof(ShapeClassReferencesDomainClassAddRule),
                typeof(ShapeClassReferencesDomainClassChangeRule),
                typeof(ShapeClassReferencesDomainClassDeleteRule),
                typeof(RelationshipShapeClassReferencesRRAddRule),
                typeof(RelationshipShapeClassReferencesRRChangeRule),
                typeof(RelationshipShapeClassReferencesRRDeleteRule),

                // Properties
                typeof(ModelContextAddRule),
                typeof(LibraryModelContextAddRule),
                typeof(LibraryModelContextDeleteRule),

                typeof(DomainRoleReferencesCPGEAddRule),
                typeof(DomainRoleReferencesCPGEChangeRule),
                typeof(PropertyGridEditorElementAddRule),
                typeof(GeneratedDomainElementAddRule),
                typeof(NamedDomainElementPropertyChangedRule),
                typeof(DomainTypePropertyChangeRule),
                typeof(DomainTypeAddRule),
                typeof(DomainEnumerationAddRule),
                typeof(DomainPropertyChangedRule),
                typeof(AttributedDomainElementPropertyChangedRule),
                typeof(DomainClassPropertyChangedRule),
                typeof(EmbeddingRelationshipPropertyChangedRule),
                typeof(ReferenceRelationshipPropertyChangedRule),
                typeof(DomainRelationshipPropertyChangedRule),
                typeof(DomainRolePropertyChangedRule),
                typeof(EnumerationLiteralPropertyChangedRule),

                typeof(EnumerationLiteralAddRule),
                typeof(AttributedDomainElementAddRule),
                typeof(DomainPropertyAddRule),

                // Serialization
                typeof(SerializationModelPropertyChangeRule),

                typeof(SerializationDomainClassAddRule),
                typeof(SerializationDomainClassDeleteRule),
                typeof(SerializationDomainRelationshipAddRule),
                typeof(SerializationDomainRelationshipChangedRule),
                typeof(SerializationDomainRelationshipDeleteRule),
                typeof(SerializationDomainPropertyAddRule),
                typeof(SerializationDomainPropertyDeleteRule),

                typeof(SerializedDomainClassChangedRule),
                typeof(SerializedDomainModelChangedRule),
                typeof(SerializedDomainPropertyChangedRule),
                typeof(SerializedDomainRoleChangedRule),
                typeof(SerializedEmbeddingRelationshipChangedRule),
                typeof(SerializedReferenceRelationshipChangedRule),

                /*
                typeof(ElementAddRule),
                typeof(ElementChangeRule),
                typeof(ConnectionAddRule),
                typeof(ConnectionChangeRule),
                typeof(ConnectionDeleteRule),
                typeof(SerializationElementAddRule),
                typeof(SerializationElementRolePlayerChangeRule),
                typeof(SerializationElementChangeRule),
                typeof(SerializationElementDeleteRule),
                typeof(DiagramConnectionAddRule),
                typeof(DiagramConnectionChangeRule),
                typeof(DiagramConnectionDeleteRule),
                typeof(DiagramElementDeleteRule)
                */
            };
        }
    }
}
