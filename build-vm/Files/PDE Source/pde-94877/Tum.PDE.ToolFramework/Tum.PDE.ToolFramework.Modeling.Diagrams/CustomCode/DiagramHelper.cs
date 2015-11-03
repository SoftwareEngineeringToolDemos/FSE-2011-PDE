using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class DiagramHelper
    {
        /// <summary>
        /// Searches for the shape of a specific type hosting a specific element.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="shapeDomainClassType">Type of the shape.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <returns>NodeShape if found. Null otherwise.</returns>
        public static ShapeElement FindShape(Store store, Guid shapeDomainClassType, Guid elementId)
        {
             ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(shapeDomainClassType);
             foreach (ModelElement m in shapes)
             {
                 if (m is ShapeElement)
                 {
                     if ((m as ShapeElement).Element != null)
                         if ((m as ShapeElement).Element.Id == elementId)
                             return m as ShapeElement;
                 }
             }
            return null;
        }

        /// <summary>
        /// Searches for the shape of a specific type hosting a specific element.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="shapeDomainClassType">Type of the shape.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <returns>List of found NodeShapes.</returns>
        public static List<ShapeElement> FindShapes(Store store, Guid shapeDomainClassType, Guid elementId)
        {
            List<ShapeElement> ret = new List<ShapeElement>();

            ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(shapeDomainClassType);
            foreach (ModelElement m in shapes)
            {
                if (m is ShapeElement)
                {
                    if ((m as ShapeElement).Element != null)
                        if ((m as ShapeElement).Element.Id == elementId)
                            ret.Add(m as ShapeElement);
                }
            }
            return ret;
        }

        /// <summary>
        /// Searches for the shape hosting a specific element.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <returns>List of found NodeShapes.</returns>
        public static List<NodeShape> FindNodeShapes(Store store, Guid elementId)
        {
            List<NodeShape> ret = new List<NodeShape>();

            ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(NodeShape.DomainClassId);
            foreach (ModelElement m in shapes)
            {
                if (m is NodeShape)
                {
                    if ((m as NodeShape).Element != null)
                        if ((m as NodeShape).Element.Id == elementId)
                            ret.Add(m as NodeShape);
                }
            }
            return ret;
        }

        /// <summary>
        /// Searches for the shape of a specific type hosting a specific element.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="shapeDomainClassType">Type of the shape.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <returns>NodeShape if found. Null otherwise.</returns>
        public static NodeShape FindChildShape(NodeShape parentShape, Guid childShapeDomainClassType, Guid childId)
        {
            foreach (NodeShape shape in parentShape.Children)
            {
                if (shape.GetDomainClass().IsDerivedFrom(childShapeDomainClassType) && shape.Element != null)
                    if (shape.Element.Id == childId)
                        return shape;
            }

            return null;
        }

        /// <summary>
        /// Verifies if a specific model element is already displayed as a child of the specific shape.
        /// </summary>
        /// <param name="parentShape">Parent shape.</param>
        /// <param name="childShapeDomainClassType">Type of the child shape.</param>
        /// <param name="childId">Id of the child element.</param>
        /// <returns>True of the child is hosted on the parent element (shapewise). False otherwise.</returns>
        public static bool IsElementDisplayedOn(NodeShape parentShape, Guid childShapeDomainClassType, Guid childId)
        {
            foreach (NodeShape shape in parentShape.Children)
            {
                if (shape.GetDomainClass().IsDerivedFrom(childShapeDomainClassType) && shape.Element != null)
                    if (shape.Element.Id == childId)
                        return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if a specific model element is already displayed as a child of the specific shape.
        /// </summary>
        /// <param name="diagram">Parent shape.</param>
        /// <param name="childShapeDomainClassType">Type of the child shape.</param>
        /// <param name="childId">Id of the child element.</param>
        /// <returns>True of the child is hosted on the parent element (shapewise). False otherwise.</returns>
        public static bool IsElementDisplayedOn(Diagram diagram, Guid childShapeDomainClassType, Guid childId)
        {
            foreach (NodeShape shape in diagram.Children)
            {
                if (shape.GetDomainClass().IsDerivedFrom(childShapeDomainClassType) && shape.Element != null)
                    if (shape.Element.Id == childId)
                        return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if a specific model element is already displayed as a child of another specific element.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="parentShapeDomainClassType">Type of the parent shape.</param>
        /// <param name="parentId">Id of the parent element.</param>
        /// <param name="childShapeDomainClassType">Type of the child shape.</param>
        /// <param name="childId">Id of the child element.</param>
        /// <returns>True of the child is hosted on the parent element (shapewise). False otherwise.</returns>
        public static bool IsElementDisplayedOn(Store store, Guid parentShapeDomainClassType, Guid parentId, Guid childShapeDomainClassType, Guid childId)
        {
            ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(parentShapeDomainClassType);
            foreach (ModelElement m in shapes)
            {
                if (m is NodeShape)
                {
                    if ((m as NodeShape).Element != null)
                        if ((m as NodeShape).Element.Id == parentId)
                        {
                            return IsElementDisplayedOn(m as NodeShape, childShapeDomainClassType, childId);
                        }
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies if a specific link is already displayed as a child of a diagram.
        /// </summary>
        /// <param name="diagram">Diagram to search for that specific link.</param>
        /// <param name="rsShapeDomainClassType">Type of the relationship shape.</param>
        /// <param name="rsId">Relationship Id.</param>
        /// <param name="fromShapeId">From shape Id.</param>
        /// <param name="toShapeId">To shape Id.</param>
        /// <returns>True of the link is hosted on the diagram. False otherwise.</returns>
        public static bool IsLinkDisplayedOn(Diagram diagram, Guid rsShapeDomainClassType, Guid rsId, Guid fromShapeId, Guid toShapeId)
        {
            foreach(LinkShape shape in diagram.LinkShapes)
                if (shape.GetDomainClass().IsDerivedFrom(rsShapeDomainClassType))
                {
                    if (shape.Element != null && shape.FromShape != null && shape.ToShape != null)
                    {
                        if (shape.Element.Id == rsId &&
                            shape.FromShape.Id == fromShapeId &&
                            shape.ToShape.Id == toShapeId)
                            return true;
                            
                    }
                }

            return false;
        }

        /// <summary>
        /// Searches for the shape of a specific type hosting a specific element and deletes it.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="shapeDomainClassType">Type of the shape.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <remarks>Needs to be called within a modeling transaction context.</remarks>
        public static void DeleteShape(Store store, Guid shapeDomainClassType, Guid elementId)
        {
            ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(shapeDomainClassType);
            foreach (ModelElement m in shapes)
            {
                if (m is ShapeElement)
                {
                    ShapeElement shapeElement = m as ShapeElement;
                    if (shapeElement.Element != null)
                        if (shapeElement.Element.Id == elementId)
                        {
                            shapeElement.Delete();
                            return;
                        }

                }
            }
        }

        /// <summary>
        /// Searches for the shapes of a specific type hosting a specific element and deletes them.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="shapeDomainClassType">Type of the shape.</param>
        /// <param name="elementId">Model element Id.</param>
        /// <remarks>Needs to be called within a modeling transaction context.</remarks>
        public static void DeleteShapes(Store store, Guid shapeDomainClassType, Guid elementId)
        {
            ReadOnlyCollection<ModelElement> shapes = store.ElementDirectory.FindElements(shapeDomainClassType);
            for(int i = shapes.Count-1; i >= 0; i-- )
            {
                ShapeElement shapeElement = shapes[i] as ShapeElement;
                if (shapeElement != null)
                {
                    if (shapeElement.Element != null)
                        if (shapeElement.Element.Id == elementId)
                        {
                            shapeElement.Delete();
                        }
                }
            }
        }

        /// <summary>
        /// Verifies if the position of the specified shape is acceptable.
        /// </summary>
        /// <param name="shape">Node shape.</param>
        public static bool IsShapePositionAcceptable(NodeShape shape)
        {
            if (!shape.IsRelativeChildShape)
            {
                if (shape.Parent != null)
                {
                    if (shape.AbsoluteLocation.X < shape.Parent.AbsoluteLocation.X ||
                        shape.AbsoluteLocation.Y < shape.Parent.AbsoluteLocation.Y ||
                        shape.AbsoluteBounds.Right > shape.Parent.AbsoluteBounds.Right ||
                        shape.AbsoluteBounds.Bottom > shape.Parent.AbsoluteBounds.Bottom)
                        return false;

                }
            }
            else if (shape.Parent != null)
            {
                PointD location = NodeShape.CorrectPortLocation(shape.Parent, shape, shape.AbsoluteLocation);
                if (location != shape.AbsoluteLocation)
                    return false;
            }

            return true;
        }
    }
}
