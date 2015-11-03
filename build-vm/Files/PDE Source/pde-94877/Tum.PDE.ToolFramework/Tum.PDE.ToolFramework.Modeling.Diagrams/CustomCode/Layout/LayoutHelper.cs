using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public class LayoutHelper
    {
        public static LayoutInfo CreateLayoutInfo(NodeShape shapeElement, Diagram diagram)
        {
            // create new layout
            List<NodeShape> allShapes = new List<NodeShape>();
            LayoutInfo l = new LayoutInfo(shapeElement.Store);
            l.HostElementId = shapeElement.Element.Id;
            l.Size = shapeElement.Size;

            foreach (NodeShape shape in shapeElement.Children)
            {
                allShapes.Add(shape);
                l.ChildrenInfos.Add(CreateNodeShapeInfo(shape, allShapes));
            }

            ProcessDiagramsLinkShapes(diagram, allShapes, l);
            return l;
        }
        public static void SaveLayout(NodeShape shapeElement, Diagram diagram)
        {
            DiagramsModel model = GetDiagramsModel(shapeElement);
            
            // see if there is already a layout for the given shape element
            foreach (LayoutInfo layout in model.LayoutInfos)
                if (layout.HostElementId == shapeElement.Element.Id)
                {
                    // delete existing layout
                    model.LayoutInfos.Remove(layout);
                    break;
                }

            // create new layout
            List<NodeShape> allShapes = new List<NodeShape>();
            LayoutInfo l = CreateLayoutInfo(shapeElement, diagram);

            model.LayoutInfos.Add(l);
        }
        private static NodeShapeInfo CreateNodeShapeInfo(NodeShape shapeElement, List<NodeShape> allShapes)
        {
            NodeShapeInfo info = new NodeShapeInfo(shapeElement.Store);
            info.ElementId = shapeElement.Element.Id;
            info.Size = shapeElement.Size;
            info.RelativeLocation = shapeElement.Location;

            foreach (NodeShape shape in shapeElement.Children)
            {
                allShapes.Add(shape);
                info.ChildrenInfos.Add(CreateNodeShapeInfo(shape, allShapes));
            }

            return info;
        }
        private static void ProcessDiagramsLinkShapes(Diagram diagram, List<NodeShape> allShapes, LayoutInfo info)
        {
            foreach (LinkShape shape in diagram.LinkShapes)
            {
                if (allShapes.Contains(shape.FromShape) &&
                    allShapes.Contains(shape.ToShape))
                {
                    LinkShapeInfo lInfo = new LinkShapeInfo(info.Store);
                    lInfo.ElementId = shape.Element.Id;
                    lInfo.SourceElementId = shape.FromShape.Element.Id;
                    lInfo.TargetElementId = shape.ToShape.Element.Id;
                    lInfo.LinkDomainClassId = shape.Element.GetDomainClass().Id;

                    lInfo.SourceLocation = shape.SourceAnchor.GetRelativeLocation();
                    lInfo.TargetLocation = shape.TargetAnchor.GetRelativeLocation();

                    lInfo.RoutingMode = shape.RoutingMode;
                    lInfo.EdgePoints = ConvertToRelativeEdgePoints(shape.EdgePoints, shape.SourceAnchor.AbsoluteLocation);

                    info.LinkShapeInfos.Add(lInfo);
                }
            }

            foreach (Diagram d in diagram.IncludedDiagrams)
                ProcessDiagramsLinkShapes(d, allShapes, info);
        }

        public static void ApplyLayout(NodeShape shapeElement, Diagram diagram, LayoutInfo layout)
        {
            // apply layout
            shapeElement.Size = layout.Size;

            // children
            foreach (NodeShape shape in shapeElement.Children)
            {
                ProcessNodeShape(shape, layout.ChildrenInfos);
            }

            RestoreLinkShapes(diagram, layout.LinkShapeInfos);

        }

        public static bool RestoreLayout(NodeShape shapeElement, Diagram diagram)
        {
            DiagramsModel model = GetDiagramsModel(shapeElement);
            foreach (LayoutInfo layout in model.LayoutInfos)
                if (layout.HostElementId == shapeElement.Element.Id)
                {
                    // apply layout
                    ApplyLayout(shapeElement, diagram, layout);

                    return true;
                }

            Tum.PDE.ToolFramework.Modeling.Diagrams.Layout.GleeLayouter.Layout(shapeElement);
            
            return false;
        }
        private static void RestoreLinkShapes(Diagram diagram, LinkedElementCollection<LinkShapeInfo> infos)
        {                   
            // links
            List<LinkShape> newShapes = new List<LinkShape>();
            foreach (LinkShape shape in diagram.LinkShapes)
            {
                if (!ProcessLinkShape(shape, infos))
                    newShapes.Add(shape);
            }

            foreach (Diagram d in diagram.IncludedDiagrams)
                RestoreLinkShapes(d, infos);

            // update layout of new link shapes
            foreach (LinkShape linkShape in newShapes)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }
        }
        private static void ProcessNodeShape(NodeShape shapeElement, LinkedElementCollection<NodeShapeInfo> infos)
        {
            // try to find NodeShapeInfo for shape element
            NodeShapeInfo info = null;
            foreach (NodeShapeInfo i in infos)
            {
                if (i.ElementId == shapeElement.Element.Id)
                {
                    info = i;
                    break;
                }
            }

            if (info == null)
            {
                shapeElement.UpdateAbsoluteLocation();
                return;
            }

            shapeElement.Size = info.Size;
            shapeElement.SetLocation(info.RelativeLocation);

            // children
            foreach (NodeShape shape in shapeElement.Children)
            {
                ProcessNodeShape(shape, info.ChildrenInfos);
            }
        }
        private static bool ProcessLinkShape(LinkShape shapeElement, LinkedElementCollection<LinkShapeInfo> infos)
        {
            // try to find NodeShapeInfo for shape element
            LinkShapeInfo info = null;
            LinkShapeInfo infoAdv = null;
            foreach (LinkShapeInfo i in infos)
            {
                if (i.ElementId == shapeElement.Element.Id)
                {
                    info = i;
                    break;
                }
                else if( shapeElement.Element.GetDomainClass().Id == i.LinkDomainClassId &&
                    shapeElement.FromShape.Element.Id == i.SourceElementId && 
                    shapeElement.ToShape.Element.Id == i.TargetElementId )
                {
                    infoAdv = i;
                }
            }

            if (info == null && infoAdv != null)
                info = infoAdv;

            if (info == null)
            {
                shapeElement.SourceAnchor.DiscardLocationChange = false;
                shapeElement.TargetAnchor.DiscardLocationChange = false;
                return false;
            }

            shapeElement.SourceAnchor.SetRelativeLocation(info.SourceLocation);
            shapeElement.TargetAnchor.SetRelativeLocation(info.TargetLocation);

            shapeElement.RoutingMode = info.RoutingMode;
            if (info.EdgePoints != null)
                shapeElement.EdgePoints = ConvertFromRelativeEdgePoints(info.EdgePoints, shapeElement.SourceAnchor.AbsoluteLocation);
            else
            {
                shapeElement.EdgePoints.Add(new EdgePoint(shapeElement.SourceAnchor.AbsoluteLocation));
                shapeElement.EdgePoints.Add(new EdgePoint(shapeElement.TargetAnchor.AbsoluteLocation));
            }

            return true;
        }
        private static void UpdateAbsoluteLocation(NodeShape shapeElement)
        {
            shapeElement.UpdateAbsoluteLocation();

            foreach (NodeShape shape in shapeElement.Children)
            {
                UpdateAbsoluteLocation(shape);
            }
        }
        
        public static DiagramsModel GetDiagramsModel(NodeShape shapeElement)
        {
            Diagram d = shapeElement.Diagram;
            while(d != null)
            {
                if( d.DiagramsModel != null )
                    return d.DiagramsModel;

                d = d.ParentDiagram;
            }

            throw new InvalidOperationException("GetDiagramsModel: Could not find DiagramsModel!");
        }

        public static EdgePointCollection ConvertToRelativeEdgePoints(EdgePointCollection col, PointD relativeTo)
        {
            EdgePointCollection retCol = new EdgePointCollection();

            foreach (EdgePoint p in col)
            {
                PointD ret = new PointD();
                ret.X = p.X - relativeTo.X;
                ret.Y = p.Y - relativeTo.Y;

                EdgePoint point = new EdgePoint(ret, p.PointType);
                retCol.Add(point);                
            }

            return retCol;
        }
        public static EdgePointCollection ConvertFromRelativeEdgePoints(EdgePointCollection col, PointD relativeTo)
        {
            EdgePointCollection retCol = new EdgePointCollection();

            foreach (EdgePoint p in col)
            {
                PointD ret = new PointD();
                ret.X = p.X + relativeTo.X;
                ret.Y = p.Y + relativeTo.Y;

                EdgePoint point = new EdgePoint(ret, p.PointType);
                retCol.Add(point);
            }

            return retCol;
        }
    }
}
