using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DiagramTreeOperations
    {
        public static void UnparentShape(ShapeClass shapeClass)
        {
            EmbeddingDiagramNode node = shapeClass.DiagramTreeNode as EmbeddingDiagramNode;
            if (node == null)
                return;

            if (shapeClass != null)
            {
                shapeClass.Parent.Children.Remove(shapeClass);
                //shapeClass.DiagramTreeNode = null;
            }

            RootDiagramNode rootNode = new RootDiagramNode(shapeClass.Store);

            List<EmbeddingDiagramNode> nodesToMove = new List<EmbeddingDiagramNode>();
            foreach (EmbeddingDiagramNode n in node.EmbeddingDiagramNodes)
                nodesToMove.Add(n);
            foreach (EmbeddingDiagramNode n in nodesToMove)
            {
                n.SourceEmbeddingDiagramNode = rootNode;
            }

            shapeClass.DiagramTreeNode = rootNode;
            shapeClass.DiagramClass.DiagramClassView.RootDiagramNodes.Add(rootNode);
        }

        public static RelationshipShapeClass CreateRelationshipShapeClass(DiagramClass diagramClass)
        {
            RelationshipShapeClass shapeClass = diagramClass.Store.ElementFactory.CreateElement(RelationshipShapeClass.DomainClassId) as RelationshipShapeClass;
            Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(diagramClass.Store as IServiceProvider, diagramClass.Store.DefaultPartition);
            Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(diagramClass.Store.DefaultPartition);
            elementGroup.Add(shapeClass);
            elementGroup.MarkAsRoot(shapeClass);
            elementOperations.MergeElementGroup(diagramClass, elementGroup);
            shapeClass.Name = NameHelper.GetUniqueName(diagramClass.Store, RelationshipShapeClass.DomainClassId);
            return shapeClass;
        }
        public static ShapeClass CreateShapeClass(DiagramClass diagramClass)
        {
            ShapeClass shapeClass = diagramClass.Store.ElementFactory.CreateElement(ShapeClass.DomainClassId) as ShapeClass;
            Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(diagramClass.Store as IServiceProvider, diagramClass.Store.DefaultPartition);
            Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(diagramClass.Store.DefaultPartition);
            elementGroup.Add(shapeClass);
            elementGroup.MarkAsRoot(shapeClass);
            elementOperations.MergeElementGroup(diagramClass, elementGroup);
            shapeClass.Name = NameHelper.GetUniqueName(diagramClass.Store, ShapeClass.DomainClassId);
            return shapeClass;
        }
        public static MappingRelationshipShapeClass CreateMappingRelationshipShapeClass(DiagramClass diagramClass)
        {
            MappingRelationshipShapeClass shapeClass = diagramClass.Store.ElementFactory.CreateElement(MappingRelationshipShapeClass.DomainClassId) as MappingRelationshipShapeClass;
            Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(diagramClass.Store as IServiceProvider, diagramClass.Store.DefaultPartition);
            Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(diagramClass.Store.DefaultPartition);
            elementGroup.Add(shapeClass);
            elementGroup.MarkAsRoot(shapeClass);
            elementOperations.MergeElementGroup(diagramClass, elementGroup);
            shapeClass.Name = NameHelper.GetUniqueName(diagramClass.Store, MappingRelationshipShapeClass.DomainClassId);
            return shapeClass;
        }
    }
}
