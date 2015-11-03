using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Glee;
using Microsoft.Glee.Splines;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams.Layout
{
    /// <summary>
    /// This class uses the GLEE-Library to layout the diagram. 
    /// </summary>
    /// <remarks>
    /// The GLEE-Library doesn't support hierarchical graphs, therefore we layout every component
    /// individually, before layouting the whole diagram. As such, the GLEE layouter can as well be
    /// used to layout subgraphs (children and their relations) of single nodes.
    /// 
    /// The layouting process itself always layouts one hierarchy-level after another.
    /// </remarks>
    public class GleeLayouter
    {
        public const double HostMargin = 15.0;
        public const double MinNodeWidth = 16.0;
        public const double MinNodeHeight = 16.0;
        public const double GraphMargins = 5.0;
        public const double NodePadding = 10.0;
        public const double NodePaddingRelativeOnEdge = 0.0;

        /// <summary>
        /// Layouts the diagram by using the GLEE library.
        /// </summary>
        /// <param name="diagram">Diagram.</param>
        public static void Layout(Diagram diagram)
        {
            Dictionary<string, NodeShape> shapesMap = new Dictionary<string, NodeShape>();
            List<LinkShape> dEdges = new List<LinkShape>();
            List<LinkShape> edges = new List<LinkShape>();
            List<LinkShape> edgesLocal = new List<LinkShape>();

            // create glee graph
            GleeGraph g = new GleeGraph();
            g.Margins = GraphMargins;
            g.MinNodeHeight = MinNodeHeight;
            g.MinNodeWidth = GraphMargins;

            foreach (NodeShape shape in diagram.Children)
            {
                // layout shape if it has children
                if (shape.Children.Count > 0)
                    LayoutShape(shape, edges, dEdges);

                // collect edges on the same level
                foreach (LinkShape linkShape in shape.OutgoingLinkShapes)
                {
                    if (linkShape.ToShape.Parent == null)
                        edgesLocal.Add(linkShape);
                    else
                        dEdges.Add(linkShape);
                }

                AddNode(g, shape, shapesMap);
            }

            // 2. add edges
            foreach (LinkShape linkShape in edgesLocal)
            {
                g.AddEdge(new Edge(
                    g.NodeMap[linkShape.FromShape.Id.ToString()],
                    g.NodeMap[linkShape.ToShape.Id.ToString()]));
            }
            edges.AddRange(edgesLocal);

            // layout graph
            g.CalculateLayout();

            // apply layout information to diagram
            double left = g.Left;
            double top = g.Top;

            ApplyShapesLayout(g, shapesMap, left, top);

            // update absolute location of shapes
            UpdateAbsoluteLocation(diagram);

            // update layout of link shapes
            foreach (LinkShape linkShape in edges)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }

            // update layout of discarded link shapes
            foreach (LinkShape linkShape in dEdges)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }

            // layout included diagrams
            foreach (Diagram incD in diagram.IncludedDiagrams)
                Layout(incD);
        }

        /// <summary>
        /// Layout a subgraph defined by a given shape by using the GLEE layout library.
        /// </summary>
        /// <param name="shape">Main shape.</param>
        /// <remarks>
        /// This method needs to be called within a modeling transaction.
        /// </remarks>
        public static void Layout(NodeShape shape)
        {

            List<LinkShape> edges = new List<LinkShape>();
            List<LinkShape> dEdges = new List<LinkShape>();

            LayoutShape(shape, edges, dEdges);

            // update layout of link shapes
            foreach (LinkShape linkShape in edges)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }

            // update layout of discarded link shapes
            foreach (LinkShape linkShape in dEdges)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }

            // this is required because of size changes of the node shape:
            // 1. outgoing link shapes of the layed out node shape
            foreach(LinkShape linkShape in shape.OutgoingLinkShapes )
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }

            // 2. incoming link shapes of the layed out node shape
            foreach (LinkShape linkShape in shape.IncomingLinkShapes)
            {
                linkShape.Layout(FixedGeometryPoints.None);

                linkShape.SourceAnchor.DiscardLocationChange = false;
                linkShape.TargetAnchor.DiscardLocationChange = false;
            }
        }

        /// <summary>
        /// Layout a subgraph defined by a given shape by using the GLEE layout library.
        /// </summary>
        /// <param name="shape">Main shape.</param>
        /// <remarks>
        /// This method needs to be called within a modeling transaction.
        /// </remarks>
        private static void LayoutShape(NodeShape shape, List<LinkShape> edges, List<LinkShape> dEdges)
        {
            Dictionary<string, NodeShape> shapesMap = new Dictionary<string, NodeShape>();

            // create glee graph
            GleeGraph g = new GleeGraph();
            g.Margins = GraphMargins;
            g.MinNodeHeight = MinNodeHeight;
            g.MinNodeWidth = GraphMargins;

            // transform the information in the diagram into the glee graph
            List<LinkShape> edgesLocal = new List<LinkShape>();
            foreach (NodeShape childShape in shape.Children)
            {
                // layout shape if it has children
                if (childShape.Children.Count > 0)
                    LayoutShape(childShape, edges, dEdges);

                // collect edges on the same level
                foreach (LinkShape linkShape in childShape.OutgoingLinkShapes)
                {
                    if (linkShape.ToShape.Parent == shape)
                        edgesLocal.Add(linkShape);
                    else
                        dEdges.Add(linkShape);
                }

                AddNode(g, childShape, shapesMap);
            }

            // 2. add edges
            foreach (LinkShape linkShape in edgesLocal)
            {
                g.AddEdge(new Edge(
                    g.NodeMap[linkShape.FromShape.Id.ToString()],
                    g.NodeMap[linkShape.ToShape.Id.ToString()]));
            }
            edges.AddRange(edgesLocal);

            // layout graph
            g.CalculateLayout();

            // apply layout information to diagram
            if (shape.Children.Count > 0)   // we have no way of knowning what min size a shape has for now..
            {
                if (shape.ResizingBehaviour == ShapeResizingBehaviour.Normal)
                    shape.SetSize(new SizeD(g.Width + HostMargin, g.Height + HostMargin));
                else if (shape.ResizingBehaviour == ShapeResizingBehaviour.FixedWidth)
                    shape.SetSize(new SizeD(shape.Size.Width, g.Height + HostMargin));
                else if (shape.ResizingBehaviour == ShapeResizingBehaviour.FixedHeight)
                    shape.SetSize(new SizeD(g.Width + HostMargin, shape.Size.Height));
            }

            ApplyShapesLayout(g, shapesMap, g.Left, g.Top);

            // update absolute location of shapes
            UpdateAbsoluteLocation(shape);
        }

        private static void AddNode(GleeGraph g, NodeShape n, Dictionary<string, NodeShape> shapesMap)
        {
            shapesMap.Add(n.Id.ToString(), n);

            Node node = new Node(n.Id.ToString(), CurveFactory.CreateBox(n.Bounds.Width, n.Bounds.Height, new Point(0.0, 0.0)));
            node.Padding = NodePadding;

            if (n.IsRelativeChildShape)
                if (n.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    if (n.Parent != null)
                        if (g.NodeMap.ContainsKey(n.Parent.Id.ToString()))
                        {
                            //node.Padding = NodePaddingRelativeOnEdge;

                            // add edge so that this shape is kept close to its parent shape
                            //g.AddEdge(new Edge(g.NodeMap[n.Parent.Id.ToString()], node));
                        }
                }


            g.AddNode(node);
        }

        private static void ApplyShapesLayout(GleeGraph g, Dictionary<string, NodeShape> shapesMap, double graphLeft, double graphTop)
        {
            // apply layout information to child shapes
            foreach (string key in shapesMap.Keys)
            {
                NodeShape nodeShape = shapesMap[key];
                Node node = g.NodeMap[key];

                // appy layout information for shape
                double shapeTop = (graphTop - node.BBox.Top) + HostMargin;
                double shapeLeft;
                if (graphLeft <= 0)
                    shapeLeft = Math.Abs(graphLeft) + node.BBox.Left + HostMargin;
                else
                    shapeLeft = node.BBox.Left - graphLeft + HostMargin;

                if (nodeShape.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    if (nodeShape.Parent != null)
                        nodeShape.SetLocation(NodeShape.CorrectPortLocation(nodeShape.Parent, nodeShape, new PointD(shapeLeft, shapeTop)));
                }
                else
                    nodeShape.SetLocation(new PointD(shapeLeft, shapeTop));
            }
        }

        private static void UpdateAbsoluteLocation(Diagram diagram)
        {
            foreach (NodeShape shape in diagram.Children)
                UpdateAbsoluteLocation(shape);

            foreach (Diagram incD in diagram.IncludedDiagrams)
                UpdateAbsoluteLocation(incD);
        }
        private static void UpdateAbsoluteLocation(NodeShape shapeElement)
        {
            shapeElement.UpdateAbsoluteLocation();

            foreach (NodeShape shape in shapeElement.Children)
            {
                UpdateAbsoluteLocation(shape);
            }
        }
  
        /*

       private static void AddNodes(Diagram diagram, GleeGraph g, Dictionary<string, NodeShape> shapesMap)
       {
           foreach (NodeShape shape in diagram.Children)
           {
               if( shape.IsRelativeChildShape )
                   if (shape.MovementBehaviour != ShapeMovementBehaviour.PositionOnEdgeOfParent)
                       continue;

               AddNode(g, shape, shapesMap);
               if (shape.Children.Count > 0)
                   AddNodes(shape, g, shapesMap);
           }

           foreach (Diagram incD in diagram.IncludedDiagrams)
               AddNodes(incD, g, shapesMap);
       }
       private static void AddNodes(NodeShape shape, GleeGraph g, Dictionary<string, NodeShape> shapesMap)
       {
           foreach (NodeShape childShape in shape.Children)
           {
               if (childShape.IsRelativeChildShape)
                   if (childShape.MovementBehaviour != ShapeMovementBehaviour.PositionOnEdgeOfParent)
                       continue;

               AddNode(g, childShape, shapesMap);
               if (childShape.Children.Count > 0)
                   AddNodes(childShape, g, shapesMap);
           }
       }
       private static void AddNode(GleeGraph g, NodeShape n, Dictionary<string, NodeShape> shapesMap)
       {
           shapesMap.Add(n.Id.ToString(), n);

           Node node = new Node(n.Id.ToString(), CurveFactory.CreateBox(n.Bounds.Width, n.Bounds.Height, new Point(0.0, 0.0)));
           node.Padding = NodePadding;

           if (n.IsRelativeChildShape )
               if (n.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
               {
                   if (n.Parent != null)
                       if (g.NodeMap.ContainsKey(n.Parent.Id.ToString()))
                       {
                           //node.Padding = NodePaddingRelativeOnEdge;

                           // add edge so that this shape is kept close to its parent shape
                           //g.AddEdge(new Edge(g.NodeMap[n.Parent.Id.ToString()], node));
                       }
               }
            

           g.AddNode(node);
       }

       private static void AddEdges(Diagram diagram, GleeGraph g)
       {
           foreach (LinkShape linkShape in diagram.LinkShapes)
           {
               g.AddEdge(new Edge(
                   g.NodeMap[linkShape.FromShape.Id.ToString()],
                   g.NodeMap[linkShape.ToShape.Id.ToString()]));
           }

           foreach (Diagram incD in diagram.IncludedDiagrams)
               AddEdges(incD, g);
       }
       private static List<LinkShape> AddEdges(Dictionary<string, NodeShape> shapesMap, Diagram diagram, GleeGraph g)
       {
           List<LinkShape> edges = new List<LinkShape>();
           foreach (LinkShape linkShape in diagram.LinkShapes)
           {
               if (shapesMap.ContainsKey(linkShape.FromShape.Id.ToString()) &&
                   shapesMap.ContainsKey(linkShape.ToShape.Id.ToString()))
               {
                   g.AddEdge(new Edge(
                       g.NodeMap[linkShape.FromShape.Id.ToString()],
                       g.NodeMap[linkShape.ToShape.Id.ToString()]));
                   edges.Add(linkShape);
               }
           }

           foreach (Diagram incD in diagram.IncludedDiagrams)
               edges.AddRange(AddEdges(shapesMap, incD, g));

           return edges;
       }


       private static void UpdateLinkShapesLayout(Diagram diagram)
       {
           foreach (LinkShape linkShape in diagram.LinkShapes)
           {
               linkShape.Layout(FixedGeometryPoints.None);

               linkShape.SourceAnchor.DiscardLocationChange = false;
               linkShape.TargetAnchor.DiscardLocationChange = false;
           }

           foreach (Diagram incD in diagram.IncludedDiagrams)
               UpdateLinkShapesLayout(incD);
       }

       
      /// <summary>
      /// Layout a subgraph defined by a given shape by using the GLEE layout library.
      /// </summary>
      /// <param name="shape">Main shape.</param>
      /// <remarks>
      /// This method needs to be called within a modeling transaction.
      /// </remarks>
      public static void Layout2(NodeShape shape)
      {
          Dictionary<string, NodeShape> shapesMap = new Dictionary<string, NodeShape>();
          List<KeyValuePair<string, string>> relationsMap = new List<KeyValuePair<string, string>>();

          // create shapes map
          // only "real" children are taken into account. We ignore relative children.
          foreach (NodeShape childShape in shape.Children)
          {
              shapesMap.Add(childShape.Id.ToString(), childShape);
          }

          // create relations map
          foreach (LinkShape linkShape in shape.Diagram.LinkShapes)
          {
              if (shapesMap.ContainsKey(linkShape.FromShape.Id.ToString()) &&
                  shapesMap.ContainsKey(linkShape.ToShape.Id.ToString()))
              {
                  relationsMap.Add(new KeyValuePair<string, string>(linkShape.FromShape.Id.ToString(), linkShape.ToShape.Id.ToString()));
              }
          }

          // create glee graph foreach shape in the shapes map
          GleeGraph g = new GleeGraph();
          g.Margins = GraphMargins;
          g.MinNodeHeight = MinNodeHeight;
          g.MinNodeWidth = GraphMargins;
          foreach (string key in shapesMap.Keys)
          {
              NodeShape nodeShape = shapesMap[key];
              Node node = new Node(key, CurveFactory.CreateBox(nodeShape.Bounds.Width, nodeShape.Bounds.Height, new Point(0.0, 0.0)));
              node.Padding = NodePadding;
              g.AddNode(node);
          }

          // add edges based on relations map
          foreach (KeyValuePair<string, string> kv in relationsMap)
          {
              g.AddEdge(new Edge(g.NodeMap[kv.Key], g.NodeMap[kv.Value]));
          }

          // layout
          g.CalculateLayout();

          // apply layout information to main shape
          shape.SetSize(new SizeD(g.Width + HostMargin, g.Height + HostMargin));

          double left = g.Left;
          double top = g.Top;

          // apply layout information to child shapes
          foreach (string key in shapesMap.Keys)
          {
              NodeShape nodeShape = shapesMap[key];
              Node node = g.NodeMap[key];

              // appy layout information for shape
              double shapeTop = (top - node.BBox.Top) + HostMargin;
              double shapeLeft;
              if (left <= 0)
                  shapeLeft = Math.Abs(left) + node.BBox.Left + HostMargin;
              else
                  shapeLeft = node.BBox.Left - left + HostMargin;

              nodeShape.SetLocation(new PointD(shapeLeft, shapeTop));
          }


          // update absolute location of shapes
          UpdateAbsoluteLocation(shape);

          // update layout of link shapes
          foreach (LinkShape linkShape in shape.Diagram.LinkShapes)
          {
              linkShape.Layout(FixedGeometryPoints.None);

              linkShape.SourceAnchor.DiscardLocationChange = false;
              linkShape.TargetAnchor.DiscardLocationChange = false;
          }
      }
       
      public static void Layout2(Diagram diagram)
      {
          Dictionary<string, NodeShape> shapesMap = new Dictionary<string, NodeShape>();
          Dictionary<string, Node> nodeMap = new Dictionary<string, Node>();
          List<KeyValuePair<string, string>> relationsMap = new List<KeyValuePair<string, string>>();

          // create relations map
          foreach (LinkShape linkShape in diagram.IncludedDiagrams[0].LinkShapes)
          {
              relationsMap.Add(new KeyValuePair<string, string>(linkShape.FromShape.Id.ToString(), linkShape.ToShape.Id.ToString()));
          }

          // create glee graph
          GleeGraph g = new GleeGraph();
          g.Margins = GraphMargins;
          g.MinNodeHeight = MinNodeHeight;
          g.MinNodeWidth = GraphMargins;

          // add nodes
          foreach (NodeShape shape in diagram.IncludedDiagrams[0].Children)
          {
              AddNode(g, shape, shapesMap, nodeMap);

              if (shape.Children.Count > 0)
                  g.AddSubgraph(CreateSubGraph(shape, shapesMap, relationsMap, nodeMap));
          }

          // add edges
          List<Node> nodes = g.CollectAllNodes();

          foreach (KeyValuePair<string, string> kv in relationsMap)
          {
              g.AddEdge(new Edge(nodeMap[kv.Key], nodeMap[kv.Value]));
          }

          // layout
          g.CalculateLayout();

          // apply layout to diagram
          foreach (NodeShape shape in diagram.Children)
          {
              //ApplyLayout(g, shape);
          }
      }

        

      /// <summary>
      /// Layout a subgraph defined by a given shape by using the GLEE layout library.
      /// </summary>
      /// <param name="shape">Main shape.</param>
      /// <remarks>
      /// This method needs to be called within a modeling transaction.
      /// </remarks>
      private static void LayoutNodeShape(NodeShape shape, Dictionary<string, NodeShape> shapesMap, List<KeyValuePair<string, string>> relationsMap)
      {

      }

      private static GleeGraph CreateSubGraph(NodeShape shape, Dictionary<string, NodeShape> shapesMap, List<KeyValuePair<string, string>> relationsMap, Dictionary<string, Node> nodeMap)
      {
          GleeGraph g = new GleeGraph();
          g.Margins = GraphMargins;
          g.MinNodeHeight = MinNodeHeight;
          g.MinNodeWidth = GraphMargins;

          foreach (NodeShape childShape in shape.Children)
          {
              AddNode(g, childShape, shapesMap, nodeMap);

              if (childShape.Children.Count > 0)
                  g.AddSubgraph(CreateSubGraph(childShape, shapesMap, relationsMap, nodeMap));
          }

          return g;
      }

      */

        
    }
}
