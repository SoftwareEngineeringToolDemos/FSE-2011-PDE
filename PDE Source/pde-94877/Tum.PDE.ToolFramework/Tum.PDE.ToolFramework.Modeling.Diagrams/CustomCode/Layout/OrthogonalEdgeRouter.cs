using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams.Layout
{
    /// <summary>
    /// Edge routing algorithm that makes orthogonal edges.
    /// </summary>
    /// <remarks>
    /// Based on: http://www.codeproject.com/KB/WPF/WPFDiagramDesigner_Part4.aspx
    /// </remarks>
    public class OrthogonalEdgeRouter
    {
        public const double DistanceToElement = 10;

        internal static List<PointD> GetConnectionLine(LinkShape linkShape, NodeShape source, PointD startPointE, NodeShape target, PointD endPointE)
        {
            List<PointD> linePointsRet = new List<PointD>();
            List<Point> linePoints = new List<Point>();

            Rect rectSource = GetRectWithMargin(linkShape.LinkPlacementStart, source, 7.0);
            Rect rectTarget = GetRectWithMargin(linkShape.LinkPlacementEnd, target, 7.0);

            //Point startPointTemp = GetOffsetPoint(linkShape.LinkPlacementStart, linkShape.SourceAnchor, rectSource);
            //Point endPointTemp = GetOffsetPoint(linkShape.LinkPlacementEnd, linkShape.TargetAnchor, rectTarget);
            Point startPointTemp = GetOffsetPoint(linkShape.LinkPlacementStart, startPointE, rectSource);
            Point endPointTemp = GetOffsetPoint(linkShape.LinkPlacementEnd, endPointE, rectTarget);

            // Path start and end ...
            rectSource = CorrectRect(rectSource, linkShape.LinkPlacementStart, DistanceToElement);
            rectTarget = CorrectRect(rectTarget, linkShape.LinkPlacementEnd, DistanceToElement);
            
            Point startPoint, endPoint;
            CorrectStartEndpoints(linkShape, startPointTemp, endPointTemp, out startPoint, out endPoint);

            linePoints.Add(startPoint);
            Point currentPoint = startPoint;

            if (!rectTarget.Contains(currentPoint) && !rectSource.Contains(endPoint))
            {
                while (true)
                {
                    #region source node

                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource, rectTarget }))
                    {
                        linePoints.Add(endPoint);
                        currentPoint = endPoint;
                        break;
                    }

                    Point neighbour = GetNearestVisibleNeighborTarget(currentPoint, endPoint, linkShape.TargetAnchor, linkShape.LinkPlacementEnd, rectSource, rectTarget);
                    if (!double.IsNaN(neighbour.X))
                    {
                        linePoints.Add(neighbour);
                        linePoints.Add(endPoint);
                        currentPoint = endPoint;
                        break;
                    }

                    if (currentPoint == startPoint)
                    {
                        bool flag;
                        Point n = GetNearestNeighborSource(linkShape.LinkPlacementStart, endPoint, rectSource, rectTarget, out flag);
                        linePoints.Add(n);
                        currentPoint = n;

                        if (!IsRectVisible(currentPoint, rectTarget, new Rect[] { rectSource }))
                        {
                            Point n1, n2;
                            GetOppositeCorners(linkShape.LinkPlacementStart, rectSource, out n1, out n2);
                            if (flag)
                            {
                                linePoints.Add(n1);
                                currentPoint = n1;
                            }
                            else
                            {
                                linePoints.Add(n2);
                                currentPoint = n2;
                            }
                            if (!IsRectVisible(currentPoint, rectTarget, new Rect[] { rectSource }))
                            {
                                if (flag)
                                {
                                    linePoints.Add(n2);
                                    currentPoint = n2;
                                }
                                else
                                {
                                    linePoints.Add(n1);
                                    currentPoint = n1;
                                }
                            }
                        }
                    }
                    #endregion

                    #region target node

                    else // from here on we jump to the sink node
                    {
                        Point n1, n2; // neighbour corner
                        Point s1, s2; // opposite corner
                        GetNeighborCorners(linkShape.LinkPlacementEnd, rectTarget, out s1, out s2);
                        GetOppositeCorners(linkShape.LinkPlacementEnd, rectTarget, out n1, out n2);

                        bool n1Visible = IsPointVisible(currentPoint, n1, new Rect[] { rectSource, rectTarget });
                        bool n2Visible = IsPointVisible(currentPoint, n2, new Rect[] { rectSource, rectTarget });

                        if (n1Visible && n2Visible)
                        {
                            if (rectSource.Contains(n1))
                            {
                                linePoints.Add(n2);
                                if (rectSource.Contains(s2))
                                {
                                    linePoints.Add(n1);
                                    linePoints.Add(s1);
                                }
                                else
                                    linePoints.Add(s2);

                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }

                            if (rectSource.Contains(n2))
                            {
                                linePoints.Add(n1);
                                if (rectSource.Contains(s1))
                                {
                                    linePoints.Add(n2);
                                    linePoints.Add(s2);
                                }
                                else
                                    linePoints.Add(s1);

                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }

                            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
                            {
                                linePoints.Add(n1);
                                if (rectSource.Contains(s1))
                                {
                                    linePoints.Add(n2);
                                    linePoints.Add(s2);
                                }
                                else
                                    linePoints.Add(s1);
                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }
                            else
                            {
                                linePoints.Add(n2);
                                if (rectSource.Contains(s2))
                                {
                                    linePoints.Add(n1);
                                    linePoints.Add(s1);
                                }
                                else
                                    linePoints.Add(s2);
                                linePoints.Add(endPoint);
                                currentPoint = endPoint;
                                break;
                            }
                        }
                        else if (n1Visible)
                        {
                            linePoints.Add(n1);
                            if (rectSource.Contains(s1))
                            {
                                linePoints.Add(n2);
                                linePoints.Add(s2);
                            }
                            else
                                linePoints.Add(s1);
                            linePoints.Add(endPoint);
                            currentPoint = endPoint;
                            break;
                        }
                        else
                        {
                            linePoints.Add(n2);
                            if (rectSource.Contains(s2))
                            {
                                linePoints.Add(n1);
                                linePoints.Add(s1);
                            }
                            else
                                linePoints.Add(s2);
                            linePoints.Add(endPoint);
                            currentPoint = endPoint;
                            break;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                linePoints.Add(endPoint);
            }

            linePoints = OptimizeLinePoints(linePoints, new Rect[] { rectSource, rectTarget }, linkShape.LinkPlacementStart, linkShape.LinkPlacementEnd);

            // insert temp startPoints
            linePoints.Insert(0, startPointTemp);
            linePoints.Add(endPointTemp);

            foreach (Point p in linePoints)
                linePointsRet.Add(new PointD(p));

            return linePointsRet;
        }
        internal static List<PointD> GetConnectionLineSimple(LinkShape linkShape, NodeShape source, PointD startPointE, NodeShape target, PointD endPointE, LinkPlacement targetPlacement)
        {
            List<PointD> linePointsRet = new List<PointD>();
            List<Point> linePoints = new List<Point>();

            Rect rectSource = GetRectWithMargin(linkShape.LinkPlacementStart, source, 7.0);

            Point startPoint = GetOffsetPoint(linkShape.LinkPlacementStart, startPointE, rectSource);
            Point endPoint = endPointE.ToPoint();

            linePoints.Add(startPoint);
            Point currentPoint = startPoint;

            if (!rectSource.Contains(endPoint))
            {
                while (true)
                {
                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource }))
                    {
                        linePoints.Add(endPoint);
                        break;
                    }

                    bool sideFlag;
                    Point n = GetNearestNeighborSource(linkShape.LinkPlacementStart, endPoint, rectSource, out sideFlag);
                    linePoints.Add(n);
                    currentPoint = n;

                    if (IsPointVisible(currentPoint, endPoint, new Rect[] { rectSource }))
                    {
                        linePoints.Add(endPoint);
                        break;
                    }
                    else
                    {
                        Point n1, n2;
                        GetOppositeCorners(linkShape.LinkPlacementStart, rectSource, out n1, out n2);
                        if (sideFlag)
                            linePoints.Add(n1);
                        else
                            linePoints.Add(n2);

                        linePoints.Add(endPoint);
                        break;
                    }
                }
            }
            else
            {
                linePoints.Add(endPoint);
            }

            linePoints = OptimizeLinePoints(linePoints, new Rect[] { rectSource }, linkShape.LinkPlacementStart, targetPlacement);

            foreach (Point p in linePoints)
                linePointsRet.Add(new PointD(p));

            return linePointsRet;
        }


        private static List<Point> OptimizeLinePoints(List<Point> linePoints, Rect[] rectangles, LinkPlacement sourceOrientation, LinkPlacement sinkOrientation)
        {
            List<Point> points = new List<Point>();
            int cut = 0;

            for (int i = 0; i < linePoints.Count; i++)
            {
                if (i >= cut)
                {
                    for (int k = linePoints.Count - 1; k > i; k--)
                    {
                        if (IsPointVisible(linePoints[i], linePoints[k], rectangles))
                        {
                            cut = k;
                            break;
                        }
                    }
                    points.Add(linePoints[i]);
                }
            }

            #region Line
            for (int j = 0; j < points.Count - 1; j++)
            {
                if (points[j].X != points[j + 1].X && points[j].Y != points[j + 1].Y)
                {
                    LinkPlacement orientationFrom;
                    LinkPlacement orientationTo;

                    // orientation from point
                    if (j == 0)
                        orientationFrom = sourceOrientation;
                    else
                        orientationFrom = GetOrientation(points[j], points[j - 1]);

                    // orientation to pint 
                    if (j == points.Count - 2)
                        orientationTo = sinkOrientation;
                    else
                        orientationTo = GetOrientation(points[j + 1], points[j + 2]);


                    if ((orientationFrom == LinkPlacement.Left || orientationFrom == LinkPlacement.Right) &&
                        (orientationTo == LinkPlacement.Left || orientationTo == LinkPlacement.Right))
                    {
                        double centerX = Math.Min(points[j].X, points[j + 1].X) + Math.Abs(points[j].X - points[j + 1].X) / 2;
                        points.Insert(j + 1, new Point(centerX, points[j].Y));
                        points.Insert(j + 2, new Point(centerX, points[j + 2].Y));
                        if (points.Count - 1 > j + 3)
                            points.RemoveAt(j + 3);
                        return points;
                    }

                    if ((orientationFrom == LinkPlacement.Top || orientationFrom == LinkPlacement.Bottom) &&
                        (orientationTo == LinkPlacement.Top || orientationTo == LinkPlacement.Bottom))
                    {
                        double centerY = Math.Min(points[j].Y, points[j + 1].Y) + Math.Abs(points[j].Y - points[j + 1].Y) / 2;
                        points.Insert(j + 1, new Point(points[j].X, centerY));
                        points.Insert(j + 2, new Point(points[j + 2].X, centerY));
                        if (points.Count - 1 > j + 3)
                            points.RemoveAt(j + 3);
                        return points;
                    }

                    if ((orientationFrom == LinkPlacement.Left || orientationFrom == LinkPlacement.Right) &&
                        (orientationTo == LinkPlacement.Top || orientationTo == LinkPlacement.Bottom))
                    {
                        points.Insert(j + 1, new Point(points[j + 1].X, points[j].Y));
                        return points;
                    }

                    if ((orientationFrom == LinkPlacement.Top || orientationFrom == LinkPlacement.Bottom) &&
                        (orientationTo == LinkPlacement.Left || orientationTo == LinkPlacement.Right))
                    {
                        points.Insert(j + 1, new Point(points[j].X, points[j + 1].Y));
                        return points;
                    }
                }
            }
            #endregion

            return points;
        }

        private static LinkPlacement GetOrientation(Point p1, Point p2)
        {
            if (p1.X == p2.X)
            {
                if (p1.Y >= p2.Y)
                    return LinkPlacement.Bottom;
                else
                    return LinkPlacement.Top;
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X >= p2.X)
                    return LinkPlacement.Right;
                else
                    return LinkPlacement.Left;
            }
            throw new Exception("Failed to retrieve orientation");
        }
        private static Orientation GetOrientation(LinkPlacement sourceOrientation)
        {
            switch (sourceOrientation)
            {
                case LinkPlacement.Left:
                    return Orientation.Horizontal;
                case LinkPlacement.Top:
                    return Orientation.Vertical;
                case LinkPlacement.Right:
                    return Orientation.Horizontal;
                case LinkPlacement.Bottom:
                    return Orientation.Vertical;
                default:
                    throw new Exception("Unknown ConnectorOrientation");
            }
        }

        private static Point GetNearestNeighborSource(LinkPlacement placement, Point endPoint, Rect rectSource, Rect rectSink, out bool flag)
        {
            Point n1, n2; // neighbors
            GetNeighborCorners(placement, rectSource, out n1, out n2);

            if (rectSink.Contains(n1))
            {
                flag = false;
                return n2;
            }

            if (rectSink.Contains(n2))
            {
                flag = true;
                return n1;
            }

            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
            {
                flag = true;
                return n1;
            }
            else
            {
                flag = false;
                return n2;
            }
        }
        private static Point GetNearestNeighborSource(LinkPlacement placement, Point endPoint, Rect rectSource, out bool flag)
        {
            Point n1, n2; // neighbors
            GetNeighborCorners(placement, rectSource, out n1, out n2);

            if ((Distance(n1, endPoint) <= Distance(n2, endPoint)))
            {
                flag = true;
                return n1;
            }
            else
            {
                flag = false;
                return n2;
            }
        }

        private static Point GetNearestVisibleNeighborTarget(Point currentPoint, Point endPoint, Anchor target, LinkPlacement placement, Rect rectSource, Rect rectSink)
        {
            Point s1, s2; // neighbors on sink side
            GetNeighborCorners(placement, rectSink, out s1, out s2);

            bool flag1 = IsPointVisible(currentPoint, s1, new Rect[] { rectSource, rectSink });
            bool flag2 = IsPointVisible(currentPoint, s2, new Rect[] { rectSource, rectSink });

            if (flag1) // s1 visible
            {
                if (flag2) // s1 and s2 visible
                {
                    if (rectSink.Contains(s1))
                        return s2;

                    if (rectSink.Contains(s2))
                        return s1;

                    if ((Distance(s1, endPoint) <= Distance(s2, endPoint)))
                        return s1;
                    else
                        return s2;

                }
                else
                {
                    return s1;
                }
            }
            else // s1 not visible
            {
                if (flag2) // only s2 visible
                {
                    return s2;
                }
                else // s1 and s2 not visible
                {
                    return new Point(double.NaN, double.NaN);
                }
            }
        }

        private static bool IsPointVisible(Point fromPoint, Point targetPoint, Rect[] rectangles)
        {
            foreach (Rect rect in rectangles)
            {
                if (RectangleIntersectsLine(rect, fromPoint, targetPoint))
                    return false;
            }
            return true;
        }
        private static bool IsRectVisible(Point fromPoint, Rect targetRect, Rect[] rectangles)
        {
            if (IsPointVisible(fromPoint, targetRect.TopLeft, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.TopRight, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.BottomLeft, rectangles))
                return true;

            if (IsPointVisible(fromPoint, targetRect.BottomRight, rectangles))
                return true;

            return false;
        }
        private static bool RectangleIntersectsLine(Rect rect, Point startPoint, Point endPoint)
        {
            rect.Inflate(-1, -1);
            return rect.IntersectsWith(new Rect(startPoint, endPoint));
        }

        private static void GetOppositeCorners(LinkPlacement orientation, Rect rect, out Point n1, out Point n2)
        {
            switch (orientation)
            {
                case LinkPlacement.Left:
                    n1 = rect.TopRight; n2 = rect.BottomRight;
                    break;
                case LinkPlacement.Top:
                    n1 = rect.BottomLeft; n2 = rect.BottomRight;
                    break;
                case LinkPlacement.Right:
                    n1 = rect.TopLeft; n2 = rect.BottomLeft;
                    break;
                case LinkPlacement.Bottom:
                    n1 = rect.TopLeft; n2 = rect.TopRight;
                    break;
                default:
                    throw new Exception("No opposite corners found!");
            }
        }
        private static void GetNeighborCorners(LinkPlacement orientation, Rect rect, out Point n1, out Point n2)
        {
            switch (orientation)
            {
                case LinkPlacement.Left:
                    n1 = rect.TopLeft; n2 = rect.BottomLeft;
                    break;
                case LinkPlacement.Top:
                    n1 = rect.TopLeft; n2 = rect.TopRight;
                    break;
                case LinkPlacement.Right:
                    n1 = rect.TopRight; n2 = rect.BottomRight;
                    break;
                case LinkPlacement.Bottom:
                    n1 = rect.BottomLeft; n2 = rect.BottomRight;
                    break;
                default:
                    throw new Exception("No neighour corners found!");
            }
        }

        private static double Distance(Point p1, Point p2)
        {
            return Point.Subtract(p1, p2).Length;
        }
        private static Rect GetRectWithMargin(LinkPlacement placement, NodeShape sourceShape, double margin)
        {
            Rect rect = new Rect(sourceShape.AbsoluteLocation.X,
                                 sourceShape.AbsoluteLocation.Y,
                                 sourceShape.Bounds.Width,
                                 sourceShape.Bounds.Height);
            
            rect.Inflate(margin, margin);

            return rect;
        }
        private static Rect CorrectRect(Rect rect, LinkPlacement placement, double margin)
        {
            switch (placement)
            {
                case LinkPlacement.Left:
                    rect.X -= DistanceToElement;
                    break;
                case LinkPlacement.Top:
                    rect.Y -= DistanceToElement;
                    break;
                case LinkPlacement.Right:
                    rect.Width += DistanceToElement;
                    break;
                case LinkPlacement.Bottom:
                    rect.Height += DistanceToElement;
                    break;
                default:
                    break;
            }

            return rect;
        }
        private static Point GetOffsetPoint(LinkPlacement placement, Anchor anchor, Rect rect)
        {
            Point offsetPoint = new Point();

            switch (placement)
            {
                case LinkPlacement.Left:
                    offsetPoint = new Point(rect.Left, anchor.AbsoluteLocation.Y);
                    break;
                case LinkPlacement.Top:
                    offsetPoint = new Point(anchor.AbsoluteLocation.X, rect.Top);
                    break;
                case LinkPlacement.Right:
                    offsetPoint = new Point(rect.Right, anchor.AbsoluteLocation.Y);
                    break;
                case LinkPlacement.Bottom:
                    offsetPoint = new Point(anchor.AbsoluteLocation.X, rect.Bottom);
                    break;
                default:
                    break;
            }

            return offsetPoint;
        }
        private static Point GetOffsetPoint(LinkPlacement placement, PointD absoluteLocation, Rect rect)
        {
            Point offsetPoint = new Point();

            switch (placement)
            {
                case LinkPlacement.Left:
                    offsetPoint = new Point(rect.Left, absoluteLocation.Y);
                    break;
                case LinkPlacement.Top:
                    offsetPoint = new Point(absoluteLocation.X, rect.Top);
                    break;
                case LinkPlacement.Right:
                    offsetPoint = new Point(rect.Right, absoluteLocation.Y);
                    break;
                case LinkPlacement.Bottom:
                    offsetPoint = new Point(absoluteLocation.X, rect.Bottom);
                    break;
                default:
                    break;
            }

            return offsetPoint;
        }
        private static void CorrectStartEndpoints(LinkShape linkShape, Point startPointTemp, Point endPointTemp, out Point startPoint, out Point endPoint)
        {
            startPoint = startPointTemp;
            endPoint = endPointTemp;

            double marginPath = DistanceToElement;
            switch (linkShape.LinkPlacementStart)
            {
                case LinkPlacement.Left:
                    startPoint.X -= marginPath;
                    break;
                case LinkPlacement.Top:
                    startPoint.Y -= marginPath;
                    break;
                case LinkPlacement.Right:
                    startPoint.X += marginPath;
                    break;
                case LinkPlacement.Bottom:
                    startPoint.Y += marginPath;
                    break;
                default:
                    break;
            }

            switch (linkShape.LinkPlacementEnd)
            {
                case LinkPlacement.Left:
                    endPoint.X -= marginPath;
                    break;
                case LinkPlacement.Top:
                    endPoint.Y -= marginPath;
                    break;
                case LinkPlacement.Right:
                    endPoint.X += marginPath;
                    break;
                case LinkPlacement.Bottom:
                    endPoint.Y += marginPath;
                    break;
                default:
                    break;
            }
        }
        private static LinkPlacement GetOpositeOrientation(LinkPlacement connectorOrientation)
        {
            switch (connectorOrientation)
            {
                case LinkPlacement.Left:
                    return LinkPlacement.Right;
                case LinkPlacement.Top:
                    return LinkPlacement.Bottom;
                case LinkPlacement.Right:
                    return LinkPlacement.Left;
                case LinkPlacement.Bottom:
                    return LinkPlacement.Top;
                default:
                    return LinkPlacement.Top;
            }
        }


    }
}
