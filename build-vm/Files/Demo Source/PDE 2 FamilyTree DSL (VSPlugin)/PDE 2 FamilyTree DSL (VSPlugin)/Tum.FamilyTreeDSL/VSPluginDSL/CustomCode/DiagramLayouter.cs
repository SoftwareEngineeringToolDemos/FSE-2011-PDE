using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling;

namespace Tum.FamilyTreeDSL
{
    // just for demonstration purposes.. kinda very bad
    public class DiagramLayouter
    {
        public const double MarginRoot = 15.0;
        public const double DistanceBetweenShapes = 55.0;

        public static void Layout(Diagram diagram)
        {
            TreeNode rootNode = new TreeNode(null);
            Dictionary<Guid, TreeNode> dict = new Dictionary<Guid, TreeNode>();
            List<Guid> shapesNotLinked = new List<Guid>();
            List<TreeNode> shapesCandidatesForRemoval = new List<TreeNode>();

            // create tree nodes
            foreach (NodeShape shape in diagram.Children)
            {
                if (shape.IsDeleting || shape.IsDeleted)
                    continue;

                dict.Add(shape.Id, new TreeNode(shape));
                shapesNotLinked.Add(shape.Id);
            }

            // create tree model
            foreach (LinkShape shape in diagram.LinkShapes)
            {
                if (shape.IsDeleting || shape.IsDeleted)
                    continue;

                NodeShape source = shape.SourceAnchor.FromShape;
                NodeShape target = shape.TargetAnchor.ToShape;
                
                if (source.IsDeleting || source.IsDeleted)
                    continue;

                if (target.IsDeleting || target.IsDeleted)
                    continue;

                // set siblings
                if (shape is MarriedToShape)
                {
                    dict[source.Id].Sibling = dict[target.Id];
                    dict[target.Id].Sibling = dict[source.Id];

                    //shapesNotLinked.Remove(target.Id);
                    shapesCandidatesForRemoval.Add(dict[source.Id]);
                }
            }

            foreach (LinkShape shape in diagram.LinkShapes)
            {
                if (shape.IsDeleting || shape.IsDeleted)
                    continue;

                NodeShape source = shape.SourceAnchor.FromShape;
                NodeShape target = shape.TargetAnchor.ToShape;

                if (source.IsDeleting || source.IsDeleted)
                    continue;

                if (target.IsDeleting || target.IsDeleted)
                    continue;

                // set parent-child mappings
                if (shape is ParentOfShape)
                {
                    shapesNotLinked.Remove(target.Id);

                    if (dict[target.Id].Parents.Count > 0)
                        continue;

                    dict[target.Id].Parents.Add(dict[source.Id]);
                    dict[source.Id].Children.Add(dict[target.Id]);
                    TreeNode s = dict[source.Id].Sibling;
                    if (s != null)
                    {
                        dict[target.Id].Parents.Add(s);
                        if (!s.Children.Contains(dict[target.Id]))
                            s.Children.Add(dict[target.Id]);
                    }
                }
            }

            foreach (TreeNode n in shapesCandidatesForRemoval)
            {
                if (n.Parents.Count > 0)
                {
                    shapesNotLinked.Remove(n.Shape.Id);
                    if( n.Sibling != null )
                        shapesNotLinked.Remove(n.Sibling.Shape.Id);
                }
                else if (n.Sibling != null)
                {
                    if (n.Sibling.Parents.Count > 0)
                    {
                        shapesNotLinked.Remove(n.Shape.Id);
                        shapesNotLinked.Remove(n.Sibling.Shape.Id);
                    }
                    else
                    {
                        shapesNotLinked.Remove(n.Sibling.Shape.Id);
                        if( !shapesNotLinked.Contains(n.Shape.Id) )
                            shapesNotLinked.Add(n.Shape.Id);
                    }
                }

            }

            foreach(Guid shapeId in shapesNotLinked )
                rootNode.Children.Add(dict[shapeId]);

            // layout tree model
            LayoutChildrenFirstPass(rootNode);
            LayoutChildrenSecondPass(rootNode, MarginRoot, MarginRoot);
            LayoutChildrenThirdPass(rootNode);

            foreach (LinkShape shape in diagram.LinkShapes)
            {
                if (shape.IsDeleting || shape.IsDeleted)
                    continue;

                NodeShape source = shape.SourceAnchor.FromShape;
                NodeShape target = shape.TargetAnchor.ToShape;

                if (source.IsDeleting || source.IsDeleted)
                    continue;

                if (target.IsDeleting || target.IsDeleted)
                    continue;

                shape.Layout(FixedGeometryPoints.None);
            }
        }

        private static void LayoutChildrenFirstPass(TreeNode node)
        {
            List<TreeNode> layoutOutSiblings = new List<TreeNode>();

            double x = 0.0;
            double y = 0.0;

            foreach (TreeNode n in node.Children)
            {
                if (layoutOutSiblings.Contains(n))
                    continue;

                if (n.Children.Count > 0)
                    LayoutChildrenFirstPass(n);

                LayoutChildFirstPass(n, x, y);
                x += n.Shape.Size.Width + DistanceBetweenShapes;

                if (n.Sibling != null)
                {
                    layoutOutSiblings.Add(n.Sibling);

                    LayoutChildFirstPass(n.Sibling, x, y);
                    x += n.Sibling.Shape.Size.Width + DistanceBetweenShapes;
                }
            }
        }
        private static void LayoutChildFirstPass(TreeNode n, double x, double y)
        {
            // calculate min width of treenode
            double minWidth = n.Shape.Size.Width;
            if (n.Sibling != null)
                minWidth += DistanceBetweenShapes + n.Sibling.Shape.Size.Width;

            if (n.Children.Count > 0)
            {
                if (minWidth < n.Children[n.Children.Count - 1].X + n.Children[n.Children.Count - 1].Width)
                    minWidth = n.Children[n.Children.Count - 1].X + n.Children[n.Children.Count - 1].Width;
            }

            n.X = x;
            n.Y = y;

            n.Width = minWidth;
        }
        private static void LayoutChildrenSecondPass(TreeNode node, double x, double y)
        {
            List<TreeNode> layoutOutSiblings = new List<TreeNode>();
            foreach (TreeNode n in node.Children)
            {
                if (layoutOutSiblings.Contains(n))
                    continue;

                double temp_x = x + (n.Width - n.Shape.Size.Width) / 2.0;
                if (n.Sibling != null)
                {
                    temp_x -= (n.Sibling.Shape.Size.Width + DistanceBetweenShapes) / 2.0;
                }

                n.Shape.SetLocation(new PointD(temp_x, y));

                if (n.Sibling != null)
                {
                    layoutOutSiblings.Add(n.Sibling);

                    temp_x += n.Sibling.Shape.Size.Width + DistanceBetweenShapes;
                    n.Sibling.Shape.SetLocation(new PointD(temp_x, y));
                }

                if (n.Children.Count > 0)
                {
                    LayoutChildrenSecondPass(n, x, y + n.Shape.Size.Height + DistanceBetweenShapes);
                }

                x += n.Width + DistanceBetweenShapes;
            }
        }
        private static void LayoutChildrenThirdPass(TreeNode node)
        {
            foreach (TreeNode n in node.Children)
            {
                LayoutChildrenThirdPass(n);

                if (n.Sibling != null)
                {
                    // swap sibling possitions based on parents
                    if( n.Parents.Count > 0 && n.Sibling.Parents.Count > 0)
                        if (n.Shape.Location.X < n.Parents[0].Shape.Location.X &&
                            n.Sibling.Shape.Location.X > n.Sibling.Parents[0].Shape.Location.X)
                        {
                            PointD locationSrc = n.Shape.Location;
                            n.Shape.SetLocation(n.Sibling.Shape.Location);
                            n.Sibling.Shape.SetLocation(locationSrc);
                        }
                }
            }
        }

        private class TreeNode
        {
            public TreeNode(NodeShape shape)
            {
                this.Children = new List<TreeNode>();
                this.Parents = new List<TreeNode>();
                this.Sibling = null;

                this.Shape = shape;
            }

            public Double X
            {
                get;
                set;
            }

            public Double Y
            {
                get;
                set;
            }

            public Double Width
            {
                get;
                set;
            }

            public NodeShape Shape
            {
                get;
                private set;
            }

            public List<TreeNode> Children
            {
                get;
                set;
            }

            public List<TreeNode> Parents
            {
                get;
                set;
            }

            public TreeNode Sibling
            {
                get;
                set;
            }
        }
    }
}
