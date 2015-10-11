using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams.Layout
{
    public static class NodePlacementHelper
    {
        public const float DistanceBetweenShapes = 30.0f;

        public static void SetAtFreePositionOnParent(NodeShape shape)
        {
            IList<NodeShape> shapes;
            if (shape.Parent == null)
            {
                // free position on diagram
                Diagram diagram = shape.Diagram;
                shapes = diagram.Children;
            }
            else
            {
                if (shape.IsRelativeChildShape)
                {
                    SetPortAtFreePositionOnParent(shape);
                    return;
                }

                // free position on parent shape
                shapes = shape.Parent.NestedChildren;
            }

            // simple algo - need better?
            RectangleF rectShape = new RectangleF(0, 0, (float)shape.Size.Width, (float)shape.Size.Height);
            RectangleF completeBounds = RectangleF.Empty;
            List<RectangleF> allShapes = new List<RectangleF>();
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] == shape)
                    continue;

                RectangleF r = new RectangleF((float)shapes[i].Location.X, (float)shapes[i].Location.Y, (float)shapes[i].Size.Width, (float)shapes[i].Size.Height);

                // add DistanceBetweenShapes
                if( r.X > DistanceBetweenShapes )
                    r.X -= DistanceBetweenShapes;
                if( r.Y > DistanceBetweenShapes )
                    r.Y -= DistanceBetweenShapes;
                if (r.X > DistanceBetweenShapes)
                    r.Width += DistanceBetweenShapes * 2;
                else
                    r.Width += DistanceBetweenShapes;

                if (r.Y > DistanceBetweenShapes)
                    r.Height += DistanceBetweenShapes * 2;
                else
                    r.Height += DistanceBetweenShapes;

                allShapes.Add(r);

                if (completeBounds == RectangleF.Empty)
                {
                    // set initial complete bounds
                    completeBounds = r;
                }
                else
                {
                    // extend complete bounds
                    if (completeBounds.X > r.X)
                    {
                        completeBounds.Width += r.X - completeBounds.X;
                        completeBounds.X = r.X;
                    }
                    if (completeBounds.Y > r.Y)
                    {
                        completeBounds.Height += r.Y - completeBounds.Y;
                        completeBounds.Y = r.Y;
                    }

                    if (completeBounds.Right < r.Right)
                        completeBounds.Width += r.Right - completeBounds.Right;

                    if (completeBounds.Bottom < r.Bottom)
                        completeBounds.Height += r.Bottom - completeBounds.Bottom;
                }
            }

            //float d = DistanceTopLeft;
            //if (shape.Parent != null)
            float d = DistanceBetweenShapes;
            
            if (completeBounds == RectangleF.Empty)
                completeBounds = new RectangleF(d, d, 0, 0);            

            // 1. see if we can fit a shape over completeBounds or to the left of it
            if (completeBounds.Top - rectShape.Height - d > d)
            {
                shape.SetLocation(new PointD(d, d));
                shape.UpdateAbsoluteLocation();
            }
            else if (completeBounds.Left - rectShape.Width - d > d)
            {
                shape.SetLocation(new PointD(d, d));
                shape.UpdateAbsoluteLocation();
            }
            else
            {
                // create region and exclude existing shapes
                Region region = new Region(new RectangleF(d, d, completeBounds.Width + completeBounds.X - d, completeBounds.Height + completeBounds.Y - d));
                foreach (RectangleF r in allShapes)
                    region.Exclude(r);

                double right = completeBounds.Width + completeBounds.X;
                double bottom = completeBounds.Height + completeBounds.Y;

                /*
                foreach (LinkShape linkShape in shape.Diagram.LinkShapes)
                {
                    List<PointF> points = new List<PointF>();
                    for (int i = 0; i < linkShape.EdgePoints.Count; i++)
                    {
                        PointF p = new PointF((float)linkShape.EdgePoints[i].X, (float)linkShape.EdgePoints[i].Y);
                        if (p.X <= right && p.Y <= bottom)
                            points.Add(p);
                    }

                    //new System.Drawing.Drawing2D.GraphicsPath(points.ToArray(), 
                    if (points.Count > 1)
                    {
                        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                        path.AddLines(points.ToArray());
                        region.Exclude(path);
                    }
                }*/
                

                // get free areas
                var rects = region.GetRegionScans(new System.Drawing.Drawing2D.Matrix());
                foreach(RectangleF r in rects )
                    if (r.Width >= rectShape.Width &&
                        r.Height >= rectShape.Height)
                    {
                        shape.SetLocation(new PointD(r.Left, r.Top));
                        shape.UpdateAbsoluteLocation();
                        
                        return;
                    }

                // 4. if no free are is found, we place the shape under compleBounds or to the right of it
                if (completeBounds.Width < completeBounds.Height)
                    shape.SetLocation(new PointD(completeBounds.Right, d));
                else
                    shape.SetLocation(new PointD(d, completeBounds.Bottom));
                shape.UpdateAbsoluteLocation();
            }
        }

        private static void SetPortAtFreePositionOnParent(NodeShape shape)
        {
            float width = (float)shape.Bounds.Width;
            float height = (float)shape.Bounds.Height;

            float parentWidth = (float)shape.Parent.Bounds.Width;
            float parentHeight = (float)shape.Parent.Bounds.Height;

            Dictionary<PortPlacement, int> dict = new Dictionary<PortPlacement, int>();
            dict.Add(PortPlacement.Left, 0);
            dict.Add(PortPlacement.Top, 0);
            dict.Add(PortPlacement.Bottom, 0);
            dict.Add(PortPlacement.Right, 0);
            for (int i = 0; i < shape.Parent.RelativeChildren.Count; i++)
            {
                if (shape.Parent.RelativeChildren[i] == shape)
                    continue;

                dict[shape.Parent.RelativeChildren[i].PlacementSide]++;
            }
            List<KeyValuePair<PortPlacement, int>> myList = new List<KeyValuePair<PortPlacement, int>>(dict);
            myList.Sort((firstPair, nextPair) =>
            {
                return firstPair.Value.CompareTo(nextPair.Value);
            });

            foreach (KeyValuePair<PortPlacement, int> p in myList)
            {
                RectangleF rectH;
                switch (p.Key)
                {
                    case PortPlacement.Left:
                        rectH = new RectangleF(-width / 2, 0, width, parentHeight);
                        break;

                    case PortPlacement.Top:
                        rectH = new RectangleF(0, -height / 2, parentWidth, height);
                        break;

                    case PortPlacement.Right:
                        rectH = new RectangleF(parentWidth - width / 2, 0, width, parentHeight);
                        break;

                    case PortPlacement.Bottom:
                        rectH = new RectangleF(0, parentHeight - height / 2, parentWidth, height);
                        break;

                    default:
                        throw new NotSupportedException();
                }

                if (SetPortAtFreePositionOnParent(shape, p.Key, rectH))
                {
                    return;
                }
            }

            shape.SetLocation(NodeShape.CorrectPortLocation(shape.Parent, shape, new PointD(0, 0)));
        }
        private static bool SetPortAtFreePositionOnParent(NodeShape shape, PortPlacement side, RectangleF freeRectangle)
        {
            List<RectangleF> freeRectangles = new List<RectangleF>();
            freeRectangles.Add(freeRectangle);

            for (int i = 0; i < shape.Parent.RelativeChildren.Count; i++)
            {
                if (shape.Parent.RelativeChildren[i] == shape)
                    continue;

                if (shape.Parent.RelativeChildren[i].PlacementSide != side)
                    continue;

                RectangleF s = shape.Parent.RelativeChildren[i].Bounds.ToRectangleF();
                for (int y = freeRectangles.Count - 1; y >= 0; y--)
                {
                    RectangleF r = freeRectangles[y];
                    RectangleF t = r;
                    r.Intersect(s);

                    if (!r.IsEmpty)
                    {
                        // remove r from freeRectangley[y] --> yields <=2 rects
                        // add 2 rects to freeRectangles
                        freeRectangles.RemoveAt(y);

                        switch (side)
                        {
                            case PortPlacement.Left:
                            case PortPlacement.Right:
                                if (t.Y < r.Y)
                                {
                                    // first r
                                    RectangleF r1 = new RectangleF(t.X, t.Y, t.Width, r.Y - t.Y);
                                    freeRectangles.Add(r1);
                                }

                                if (r.Bottom < t.Bottom)
                                {
                                    // second r
                                    RectangleF r2 = new RectangleF(t.X, r.Bottom, t.Width, t.Bottom - r.Bottom);
                                    freeRectangles.Add(r2);
                                }
                                break;

                            case PortPlacement.Top:
                            case PortPlacement.Bottom:
                                if (t.X < r.X)
                                {
                                    // first r
                                    RectangleF r1 = new RectangleF(t.X, t.Y, r.X - t.X, t.Height);
                                    freeRectangles.Add(r1);
                                }

                                if (r.Right < t.Right)
                                {
                                    // second r
                                    RectangleF r2 = new RectangleF(r.Right, t.Y, t.Right - r.Right, t.Height);
                                    freeRectangles.Add(r2);
                                }
                                break;
                        }

                    }
                }
            }

            // try to place at a fitting free rectangle
            foreach (RectangleF r in freeRectangles)
            {
                if (r.Width >= shape.Bounds.Width && r.Height >= shape.Bounds.Height)
                {
                    shape.Location = new PointD(r.X, r.Y);
                    shape.PlacementSide = side;
                    shape.UpdateAbsoluteLocation();
                    return true;
                }
            }

            return false;
        }
    }
}
