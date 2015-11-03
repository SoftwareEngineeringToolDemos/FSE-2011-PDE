using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Stores an ordered pair of doubles.
    /// </summary>
    [System.Serializable]
    [TypeConverter(typeof(Converters.SizeDConverter))]
    public struct SizeD
    {
        public static readonly SizeD Empty = new SizeD(0.0, 0.0);

        private double height;
        private double width;

        /// <summary>
        /// Gets the height.
        /// </summary>
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        /// <summary>
        /// Is this instance of SizeD equal to SizeD.Empty?
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (width == 0.0)
                    return height == 0.0;
                return false;
            }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// == Operator.
        /// </summary>
        public static bool operator ==(SizeD size1, SizeD size2)
        {
            if (FuzzEqual(size1.Width, size2.Width, SizeD.FuzzDistance))
                return SizeD.FuzzEqual(size1.Height, size2.Height, SizeD.FuzzDistance);
            return false;
        }

        /// <summary>
        /// != Operator.
        /// </summary>
        public static bool operator !=(SizeD size1, SizeD size2)
        {
            return !(size1 == size2);
        }

        public static explicit operator PointD(SizeD size)
        {
            return new PointD(size.Width, size.Height);
        }

        /// <summary>
        /// Constror.
        /// </summary>
        /// <param name="size"></param>
        public SizeD(SizeD size)
        {
            width = size.width;
            height = size.height;
        }

        /// <summary>
        /// Constructs the SizeD from a given point.
        /// </summary>
        /// <param name="pt">PointD</param>
        public SizeD(PointD pt)
        {
            width = pt.X;
            height = pt.Y;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height</param>
        public SizeD(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Equals implementation.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is SizeD))
                return false;
            SizeD sizeD = (SizeD)obj;
            if (SizeD.FuzzEqual(Width, sizeD.Width, SizeD.FuzzDistance) && SizeD.FuzzEqual(Height, sizeD.Height, SizeD.FuzzDistance))
                return sizeD.GetType().Equals(this.GetType());
            return false;
        }

        /// <summary>
        /// GetHashCode implementation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Width.GetHashCode() + this.Height.GetHashCode();
        }

        /// <summary>
        /// ToString implementation. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Width=" + Width + ", Height=" + Height;
        }

        #region Comparison Helpers
        /// <summary>
        /// Fuzz distance used for comparison.
        /// </summary>
        public static double FuzzDistance
        {
            get
            {
                return 1E-06;
            }
        }

        /// <summary>
        /// Compare two values.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="fuzz"></param>
        /// <returns></returns>
        public static bool FuzzEqual(double first, double second, double fuzz)
        {
            double d2;

            double d1 = first - second;
            if (d1 < 0.0)
                d2 = d1 * -1.0;
            else
                d2 = d1;
            return (d2 > fuzz ? false : true);
        }

        /// <summary>
        /// Compare to zero.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fuzz"></param>
        /// <returns></returns>
        public static bool FuzzZero(double value, double fuzz)
        {
            double d;

            if (value < 0.0)
                d = value * -1.0;
            else
                d = value;
            return (d > fuzz ? false : true);
        }
        #endregion
    }
}
