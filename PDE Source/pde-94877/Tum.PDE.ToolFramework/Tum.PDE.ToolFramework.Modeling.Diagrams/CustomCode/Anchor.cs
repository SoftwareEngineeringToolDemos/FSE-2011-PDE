using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class Anchor
    {
        /// <summary>
        /// Discard location changes.
        /// </summary>
        internal bool DiscardLocationChange = false;
    }

    /// <summary>
    /// Source anchor class.
    /// </summary>
    public partial class SourceAnchor
    {
        /// <summary>
        /// Gets the relative location (to the from shape absolute location).
        /// </summary>
        /// <returns></returns>
        public PointD GetRelativeLocation()
        {
            PointD ret = new PointD();
            ret.X = this.AbsoluteLocation.X - this.FromShape.AbsoluteLocation.X;
            ret.Y = this.AbsoluteLocation.Y - this.FromShape.AbsoluteLocation.Y;
            return ret;
        }

        /// <summary>
        /// Sets the relative location (to the from shape absolute location).
        /// </summary>
        /// <returns></returns>
        public void SetRelativeLocation(PointD relativeLocation)
        {
            PointD p = new PointD(
                this.FromShape.AbsoluteLocation.X + relativeLocation.X,
                 this.FromShape.AbsoluteLocation.Y + relativeLocation.Y);

            this.AbsoluteLocation = p;
            this.LinkShape.UpdateLinkPlacementStart();
        }
    }

    public partial class TargetAnchor
    {
        /// <summary>
        /// Gets the relative location (to the to shape absolute location).
        /// </summary>
        /// <returns></returns>
        public PointD GetRelativeLocation()
        {
            PointD ret = new PointD();
            ret.X = this.AbsoluteLocation.X - this.ToShape.AbsoluteLocation.X;
            ret.Y = this.AbsoluteLocation.Y - this.ToShape.AbsoluteLocation.Y;
            return ret;
        }

        /// <summary>
        /// Sets the relative location (to the to shape absolute location).
        /// </summary>
        /// <returns></returns>
        public void SetRelativeLocation(PointD relativeLocation)
        {
            PointD p = new PointD(
                this.ToShape.AbsoluteLocation.X + relativeLocation.X,
                 this.ToShape.AbsoluteLocation.Y + relativeLocation.Y);

            this.AbsoluteLocation = p;
            this.LinkShape.UpdateLinkPlacementTarget();
        }
    }
}
