using System.ComponentModel;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Represents an ordered pair of double x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    [System.Serializable]
    [TypeConverter(typeof(Converters.PointDConverter))]
    public struct PointD
    {
        public static readonly PointD Empty = new PointD(0.0, 0.0);

        private double x;
        private double y;

        /// <summary>
        /// Is the PointD instance equal to PointD.Empty?
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (SizeD.FuzzZero(x, SizeD.FuzzDistance))
                    return SizeD.FuzzZero(y, SizeD.FuzzDistance);
                return false;
            }
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// == Operator.
        /// </summary>
        public static bool operator ==(PointD left, PointD right)
        {
            if (SizeD.FuzzEqual(left.X, right.X, SizeD.FuzzDistance))
                return SizeD.FuzzEqual(left.Y, right.Y, SizeD.FuzzDistance);
            return false;
        }

        /// <summary>
        /// != Operator.
        /// </summary>
        public static bool operator !=(PointD left, PointD right)
        {
            return !(left == right);
        }

        /// <summary>
        /// - Operator.
        /// </summary>
        public static PointD operator -(PointD point, SizeD size)
        {
            return new PointD(point.X - size.Width, point.Y - size.Height);
        }

        /// <summary>
        /// + Operator.
        /// </summary>
        public static PointD operator +(PointD point, SizeD size)
        {
            return new PointD(point.X + size.Width, point.Y + size.Height);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">X-Coordinate.</param>
        /// <param name="y">Y-Coordinate.</param>
        public PointD(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="point"></param>
        public PointD(Point point)
        {
            this.x = point.X;
            this.y = point.Y;
        }

        /// <summary>
        /// Translates the Point by the specified amount.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="y">Y</param>
        public void Offset(double x, double y)
        {
            this.x += x;
            this.y += y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointD))
                return false;
            PointD pointD = (PointD)obj;
            if (SizeD.FuzzEqual(X, pointD.X, SizeD.FuzzDistance) && SizeD.FuzzEqual(Y, pointD.Y, SizeD.FuzzDistance))
                return pointD.GetType().Equals(this.GetType());
            return false;
        }

        /// <summary>
        /// GetHashCode implementation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        /// <summary>
        /// ToString implementation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X=" + X + ", Y=" + Y;
        }

        /// <summary>
        /// Adds the specified size to the specified point.
        /// </summary>
        /// <param name="point">Point to add the size to.</param>
        /// <param name="size">Size to add.</param>
        /// <returns>Point with the added size.</returns>
        public static PointD Add(PointD point, SizeD size)
        {
            return new PointD(point.X + size.Width, point.Y + size.Height);
        }

        /// <summary>
        /// Substracts the specified size from the specified point.
        /// </summary>
        /// <param name="point">Point to substract the size from.</param>
        /// <param name="size">Size to substract.</param>
        /// <returns>Returns the result of subtracting specified Size from the specified Point.</returns>
        public static PointD Subtract(PointD point, SizeD size)
        {
            return new PointD(point.X - size.Width, point.Y - size.Height);
        }

        /// <summary>
        /// Converts this PointD instance to a Point instance.
        /// </summary>
        /// <returns>Point intance of this PointD instance.</returns>
        public Point ToPoint()
        {
            return new Point(this.X, this.Y);
        }
        

    }
}
