using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [System.Serializable]
    /// <summary>
    /// Represents a rectangle based on a pair of double x- and y-coordinates as well as width and height double values.
    /// </summary>
    [TypeConverter(typeof(Converters.RectangleDConverter))]
    public class RectangleD
    {
        public static readonly RectangleD Empty;

        private double height;
        private double width;
        private double x;
        private double y;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [System.Diagnostics.DebuggerStepThrough]
        public RectangleD(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        [System.Diagnostics.DebuggerStepThrough]
        public RectangleD(PointD location, SizeD size)
        {
            x = location.X;
            y = location.Y;
            width = size.Width;
            height = size.Height;
        }

        static RectangleD()
        {
            RectangleD.Empty = new RectangleD(0.0, 0.0, 0.0, 0.0);
        }

        /// <summary>
        /// Is the RectangleD instance equal to RectangleD.Empty?
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (Width > 0.0)
                    return Height <= 0.0;
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the height value.
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
        /// Gets or sets the width.
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
        /// Gets the value of the left coordinate.
        /// </summary>
        public double Left
        {
            get
            {
                return X;
            }
        }

        /// <summary>
        /// Gets the value of the right coordinate.
        /// </summary>
        public double Right
        {
            get
            {
                return X + Width;
            }
        }

        /// <summary>
        /// Gets the value of the top coordinate.
        /// </summary>
        public double Top
        {
            get
            {
                return Y;
            }
        }

        /// <summary>
        /// Gets the value of bottom coordingate.
        /// </summary>
        public double Bottom
        {
            get
            {
                return Y + Height;
            }
        }

        /// <summary>
        /// Gets or sets the value of the X coordinate.
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
        /// Gets or sets the value of the Y coordinate.
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
        /// Gets the center location.
        /// </summary>
        public PointD Center
        {
            get
            {
                return new PointD(Left + ((Right - Left) / 2.0), Top + ((Bottom - Top) / 2.0));
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public PointD Location
        {
            get
            {
                return new PointD(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Gets the size of the rectangle.
        /// </summary>
        public SizeD Size
        {
            get
            {
                return new SizeD(Width, Height);
            }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// == operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(RectangleD left, RectangleD right)
        {
            if (SizeD.FuzzEqual(left.X, right.X, SizeD.FuzzDistance) && SizeD.FuzzEqual(left.Y, right.Y, SizeD.FuzzDistance) && SizeD.FuzzEqual(left.Width, right.Width, SizeD.FuzzDistance))
                return SizeD.FuzzEqual(left.Height, right.Height, SizeD.FuzzDistance);
            return false;
        }

        /// <summary>
        /// != operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RectangleD left, RectangleD right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Does this rectangle contain the specified point?
        /// </summary>
        /// <param name="pt">Point</param>
        /// <returns>True if the rectangle contains the specified point. False otherwise.</returns>
        public bool Contains(PointD pt)
        {
            return Contains(pt.X, pt.Y);
        }

        /// <summary>
        /// Does this rectangle contain the specified rectangle?
        /// </summary>
        /// <param name="rectangle">Rectangle</param>
        /// <returns>True if the rectangle contains the specified rectangle. False otherwise.</returns>
        public bool Contains(RectangleD rectangle)
        {
            if ((X <= rectangle.X) && ((rectangle.X + rectangle.Width) <= (X + Width)) && (Y <= rectangle.Y))
                return (rectangle.Y + rectangle.Height) <= (Y + Height);
            return false;
        }

        /// <summary>
        /// Does this rectangle contain the specified points?
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contains(double x, double y)
        {
            if ((X <= x) && (x < (X + Width)) && (Y <= y))
                return y < (Y + Height);
            return false;
        }

        /// <summary>
        /// /// Does this rectangle contain the specified point?
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool ContainsX(double x)
        {
            if (X <= x)
                return x < (X + Width);
            return false;
        }

        /// <summary>
        /// Does this rectangle contain the specified point?
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool ContainsY(double y)
        {
            if (Y <= y)
                return y < (Y + Height);
            return false;
        }

        /// <summary>
        /// Equals implementation.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is RectangleD))
                return false;

            RectangleD rectangleD = (RectangleD)obj;
            if (SizeD.FuzzEqual(X, rectangleD.X, SizeD.FuzzDistance) && SizeD.FuzzEqual(Y, rectangleD.Y, SizeD.FuzzDistance) && SizeD.FuzzEqual(Width, rectangleD.Width, SizeD.FuzzDistance))
                return SizeD.FuzzEqual(Height, rectangleD.Height, SizeD.FuzzDistance);
            return false;
        }

        /// <summary>
        /// GetHashCode implementation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)((uint)X ^ (((uint)Y << 13) | ((uint)Y >> 19)) ^ (((uint)Width << 26) | ((uint)Width >> 6))) ^ (int)(((uint)Height << 7) | ((uint)Height >> 25));
        }

        /// <summary>
        /// ToString implementation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X=" + X + ", Y=" + Y + ", Width=" + Width + ", Height= " + Height;
        }

        /// <summary>
        /// Converts this rectangle instance to a corresponding RectangleF representation.
        /// </summary>
        /// <returns>RectangleF representation.</returns>
        public RectangleF ToRectangleF()
        {
            return new RectangleF((float)this.X, (float)this.Y, (float)this.Width, (float)this.Height);
        }
    }
}
