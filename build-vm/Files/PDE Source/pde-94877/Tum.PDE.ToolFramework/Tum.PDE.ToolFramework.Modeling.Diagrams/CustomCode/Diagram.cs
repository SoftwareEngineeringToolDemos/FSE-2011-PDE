using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tum.PDE.ToolFramework.Modeling.Diagrams.Layout;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// This base abstract class represents a diagram, which can itself contain children and links.
    /// </summary>
    /// <remarks>
    /// This class also implements the IDiagramGraph interface.
    /// </remarks>
    public partial class Diagram
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public Diagram(Store store, params PropertyAssignment[] propertyAssignments)
        	: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public Diagram(Partition partition, params PropertyAssignment[] propertyAssignments)
        	: base(partition, propertyAssignments)
        {
        }
        #endregion

        private Dictionary<Guid, List<Guid>> shapeMapping = new Dictionary<Guid, List<Guid>>();

        public static double ConnectorWidth = 7;
        public static double ConnectorHeight = 7;

        private bool isVisible = false;

        /// <summary>
        /// Adds an included diagram to this diagram.
        /// </summary>
        /// <param name="diagram">Included diagram.</param>
        public virtual void AddIncludedDiagram(Diagram diagram)
        {
            bool bFound = false;
            foreach (Diagram d in this.IncludedDiagrams)
                if (d.UniqueName == diagram.UniqueName)
                {
                    bFound = true;
                    break;
                }

            if (!bFound)
                this.IncludedDiagrams.Add(diagram);
        }

        /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public virtual string UniqueName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// Shape mapping dictionary containing the Ids of all ShapeElements that host a certain ModelElement identified by an Id.
        /// </summary>
        public Dictionary<Guid, List<Guid>> ShapeMapping
        {
            get
            {
                return this.shapeMapping;
            }
        }

        /// <summary>
        /// Adds a ShapeElement to the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to add to the shape mapping dictionary.</param>
        public virtual void AddToShapeMapping(ShapeElement shapeElement)
        {
            if (shapeElement == null)
                throw new ArgumentNullException("shapeElement");

            if (shapeElement.Element == null)
                throw new ArgumentNullException("shapeElement.Element");

            if (!shapeMapping.ContainsKey(shapeElement.Element.Id))
                shapeMapping.Add(shapeElement.Element.Id, new List<Guid>());

            if (!shapeMapping[shapeElement.Element.Id].Contains(shapeElement.Id))
                shapeMapping[shapeElement.Element.Id].Add(shapeElement.Id);
            DiagramsShapeStore.AddToStore(shapeElement.Element.Id, shapeElement.Id);
        }

        /// <summary>
        /// Removes a ShapeElement from the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to remove from the shape mapping dictionary.</param>
        public virtual void RemoveFromShapeMapping(ShapeElement shapeElement)
        {
            if (shapeElement == null)
                throw new ArgumentNullException("shapeElement");

            if (shapeElement.Element == null)
                throw new ArgumentNullException("shapeElement.Element");

            if (shapeMapping.ContainsKey(shapeElement.Element.Id))
                if (shapeMapping[shapeElement.Element.Id].Contains(shapeElement.Id))
                {
                    shapeMapping[shapeElement.Element.Id].Remove(shapeElement.Id);
                    if (shapeMapping[shapeElement.Element.Id].Count == 0)
                        shapeMapping.Remove(shapeElement.Element.Id);
                }
            DiagramsShapeStore.RemoveFromStore(shapeElement.Element.Id, shapeElement.Id);
        }

        /// <summary>
        /// Calculates a path between the source and the target point.
        /// </summary>
        /// <param name="proposedSourcePoint">Source point (Absolute location).</param>
        /// <param name="proposedTargetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        public virtual List<PointD> CalcPath(PointD proposedSourcePoint, PointD proposedTargetPoint, FixedGeometryPoints fixedPoints)
        {
            PointD sourcePoint = proposedSourcePoint;
            PointD targetPoint = proposedTargetPoint;

            if (fixedPoints != FixedGeometryPoints.SourceAndTarget &&
                fixedPoints != FixedGeometryPoints.Source)
            {
                // calculate allowed source position
                // TODO: not required yet
            }

            if (fixedPoints != FixedGeometryPoints.SourceAndTarget &&
                fixedPoints != FixedGeometryPoints.Target)
            {
                // calculate allowed target position
                // TODO: not required yet
            }

            List<PointD> edgePoints = new List<PointD>();
            edgePoints.Add(sourcePoint);
            edgePoints.Add(targetPoint);

            return edgePoints;
        }

        /// <summary>
        /// Calculates a path geometry between the source and the target point. 
        /// </summary>
        /// <param name="proposedSourcePoint">Source point (Absolute location).</param>
        /// <param name="targetShape">Target shape.</param>
        /// <param name="proposedTargetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        public virtual List<PointD> CalcPath(PointD proposedSourcePoint, NodeShape targetShape, PointD proposedTargetPoint, FixedGeometryPoints fixedPoints)
        {
            PointD sourcePoint = proposedSourcePoint;
            PointD targetPoint = proposedTargetPoint;

            if (fixedPoints != FixedGeometryPoints.SourceAndTarget &&
                fixedPoints != FixedGeometryPoints.Source)
            {
                // calculate allowed source position
                // TODO
            }

            if (fixedPoints != FixedGeometryPoints.SourceAndTarget &&
                fixedPoints != FixedGeometryPoints.Target)
            {
                // calculate allowed target position
                targetPoint = CalculateAllowedPosition(targetShape, proposedTargetPoint);
            }

            List<PointD> edgePoints = CalculatePath(sourcePoint, targetPoint);
            return edgePoints;
        }

        /// <summary>
        /// Calculates an allowed position based on the given proposed position. The Idea behind this is
        /// to correct the proposed position if we are within an target elements border.
        /// </summary>
        /// <param name="targetShape">Target shape.</param>
        /// <param name="proposedPosition">Proposed position.</param>
        /// <returns>Corrected position.</returns>
        public virtual PointD CalculateAllowedPosition(NodeShape targetShape, PointD proposedPosition)
        {
            PointD position = proposedPosition;

            RectangleD absoluteBounds = targetShape.AbsoluteBounds;
            if (position.Y > absoluteBounds.Top - ConnectorHeight && position.Y < absoluteBounds.Top + ConnectorHeight)
            {
                position.Y = absoluteBounds.Top;
            }
            else if (position.Y > absoluteBounds.Bottom - ConnectorHeight && position.Y < absoluteBounds.Bottom + ConnectorHeight)
            {
                position.Y = absoluteBounds.Bottom;
            }
            if (position.X > absoluteBounds.Left - ConnectorWidth && position.X < absoluteBounds.Left + ConnectorWidth)
            {
                position.X = absoluteBounds.Left;
            }
            else if (position.X > absoluteBounds.Right - ConnectorWidth && position.X < absoluteBounds.Right + ConnectorWidth)
            {
                position.X = absoluteBounds.Right;
            }

            return position;
        }

        /// <summary>
        /// Calculates a path between two points.
        /// </summary>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        /// <returns>Path specified by a points collection.</returns>
        public virtual List<PointD> CalculatePath(PointD startPoint, PointD endPoint)
        {
            // TODO

            List<PointD> calculatedPoints = new List<PointD>();

            calculatedPoints.Add(startPoint);
            calculatedPoints.Add(endPoint);

            return calculatedPoints;
        }

        /// <summary>
        /// Creates missing links for the added shape.
        /// </summary>
        /// <param name="shapeAdded">Shape added.</param>
        public virtual void FixUpMissingLinkShapes(NodeShape shapeAdded)
        {
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
            if (data == null)
                throw new ArgumentNullException("DiagramDomainDataDirectory can not be null");

            ShapeClassInfo info;
            data.ShapeClassInfos.TryGetValue(shapeAdded.GetDomainClass().Id, out info);
            if (info == null)
                return;

            ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper factory = this.GetRSShapesFactoryHelper();
            ModelLinkAddRuleForMappingRSShapes.RSShapesFactoryHelper factoryMapping = this.GetMappingRSShapesFactoryHelper();

            if (factory != null)
            {
                if (info.RelationshipSourceRoleTypes.Count > 0)
                    foreach (Guid rel in info.RelationshipSourceRoleTypes)
                    {
                        ReadOnlyCollection<DomainModelLink> links = DomainRoleInfo.GetElementLinks<DomainModelLink>(shapeAdded.Element, rel);
                        foreach (DomainModelLink link in links)
                            factory.AddRSShapesForElement(link);
                    }

                if (info.RelationshipTargetRoleTypes.Count > 0)
                    foreach (Guid rel in info.RelationshipTargetRoleTypes)
                    {
                        ReadOnlyCollection<DomainModelLink> links = DomainRoleInfo.GetElementLinks<DomainModelLink>(shapeAdded.Element, rel);
                        foreach (DomainModelLink link in links)
                            factory.AddRSShapesForElement(link);
                    }
            }

            if (factoryMapping != null)
            {
                if (info.MappingRelationshipSourceRoleTypes.Count > 0)
                    foreach (Guid rel in info.MappingRelationshipSourceRoleTypes)
                    {
                        ReadOnlyCollection<DomainModelLink> links = DomainRoleInfo.GetElementLinks<DomainModelLink>(shapeAdded.Element, rel);
                        foreach (DomainModelLink link in links)
                            factoryMapping.AddRSShapesForElement(link);
                    }

                if (info.MappingRelationshipTargetRoleTypes.Count > 0)
                    foreach (Guid rel in info.MappingRelationshipTargetRoleTypes)
                    {
                        ReadOnlyCollection<DomainModelLink> links = DomainRoleInfo.GetElementLinks<DomainModelLink>(shapeAdded.Element, rel);
                        foreach (DomainModelLink link in links)
                            factoryMapping.AddRSShapesForElement(link);
                    }
            }

            foreach (Diagram d in this.IncludedDiagrams)
                d.FixUpMissingLinkShapes(shapeAdded);

            foreach(NodeShape s in shapeAdded.Children)
                s.FixUpMissingLinkShapes();
        }

        /// <summary>
        /// Verifies if the current shape can host a shape of a specific type.
        /// </summary>
        /// <param name="nodeShapeDomainClassId">Type of the shape specified by the domain class ID.</param>
        /// <returns>True if that specific type of shapes can be hosted by this shape. False otherwise.</returns>
        public virtual bool CanHostShape(Guid nodeShapeDomainClassId)
        {
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
            if (data == null)
                throw new ArgumentNullException("DiagramDomainDataDirectory can not be null");

            List<Guid> vals = data.GetDiagramRootChildrenShapeTypes(this.GetDomainClass().Id);
            if (vals.Contains(nodeShapeDomainClassId))
                return true;

            foreach (Diagram d in this.IncludedDiagrams)
                if (d.CanHostShape(nodeShapeDomainClassId))
                    return true;

            return false;
        }

        /// <summary>
        /// Gets the store.
        /// </summary>
        [CLSCompliant(false)]
        public new DomainModelStore Store
        {
            get
            {
                return base.Store as DomainModelStore;
            }
        }

        /// <summary>
        /// Correct children.
        /// </summary>
        public virtual bool CorrectChildren()
        {
            bool bRet = false;
            for (int i = this.Children.Count - 1; i >= 0; i--)
            {
                NodeShape shape = this.Children[i];
                if (!this.CanHostShape(shape.GetDomainClassId()))
                {
                    shape.Delete();
                    bRet = true;
                }
                else if (shape.CorrectChildren())
                {
                    bRet = true;
                }
            }

            foreach (Diagram d in this.IncludedDiagrams)
                if (d.CorrectChildren())
                    bRet = true;

            return bRet;
        }

        /// <summary>
        /// Gets the relationship shapes factory helper. Needs to be derived in the actual instance class.
        /// </summary>
        /// <returns></returns>
        public virtual ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper GetRSShapesFactoryHelper()
        {
            return null;
        }

        /// <summary>
        /// Gets the mapping relationship shapes factory helper.  Needs to be derived in the actual instance class.
        /// </summary>
        /// <returns></returns>
        public virtual ModelLinkAddRuleForMappingRSShapes.RSShapesFactoryHelper GetMappingRSShapesFactoryHelper()
        {
            return null;
        }

        /// <summary>
        /// Gets or sets whether this diagram is visible or not. Default: False
        /// </summary>
        public virtual bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
            }
        }
    }
}
