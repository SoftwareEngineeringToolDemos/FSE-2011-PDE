using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class GraphicalDependencyLinkShape
    {
        /// <summary>
        /// Layouts an edge between the given points.
        /// </summary>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        /// <param name="rMode">Routing mode.</param>
        /// <returns>Edge point collection.</returns>
        public override EdgePointCollection LayoutEdge(PointD startPoint, PointD endPoint, RoutingMode rMode)
        {
            double middle = startPoint.X + (endPoint.X - startPoint.X) / 2.0;

            EdgePointCollection points = new EdgePointCollection();
            points.Add(new EdgePoint(startPoint));
            points.Add(new EdgePoint(middle, startPoint.Y));
            points.Add(new EdgePoint(middle, endPoint.Y));
            points.Add(new EdgePoint(endPoint));
            
            return points;
        }
    }
}

