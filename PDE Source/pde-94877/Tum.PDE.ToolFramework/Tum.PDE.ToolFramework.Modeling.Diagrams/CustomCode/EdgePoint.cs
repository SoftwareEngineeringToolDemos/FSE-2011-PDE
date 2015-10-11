using System;
using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Edge point class.
    /// </summary>
    [CLSCompliant(true)]
    [Serializable]
    [TypeConverter(typeof(Converters.EdgePointConverter))]
    public class EdgePoint
    {
        private EdgePointType pointType;
        private PointD point;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EdgePoint()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public EdgePoint(double x, double y)
            : this(new PointD(x, y), EdgePointType.Normal)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="pointType">Point type.</param>
        public EdgePoint(double x, double y, EdgePointType pointType)
            : this(new PointD(x,y), pointType)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pt">Point.</param>
        public EdgePoint(PointD pt)
            : this(pt, EdgePointType.Normal)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pt">Point.</param>
        /// <param name="pointType">Point type-</param>
        public EdgePoint(PointD pt, EdgePointType pointType)
        {
            this.point = new PointD(pt.X, pt.Y);
            this.pointType = pointType;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public double X
        {
            get
            {
                return this.point.X;
            }
            set
            {
                this.point.X = value;
            }
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public double Y
        {
            get
            {
                return this.point.Y;
            }
            set
            {
                this.point.Y = value;
            }
        }

        /// <summary>
        /// Gets the point.
        /// </summary>
        public PointD Point
        {
            get { return this.point; }
        }

        /// <summary>
        /// Gets the point.
        /// </summary>
        public EdgePointType PointType
        {
            get { return this.pointType; }
        }

        /// <summary>
        /// Gets the id of this element.
        /// </summary>
        public Guid Id
        {
            get;
            private set;
        }
    }
}
