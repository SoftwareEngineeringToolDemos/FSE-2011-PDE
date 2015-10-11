using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Edge point vm type.
    /// </summary>
    public enum EdgePointVMType
    {
        /// <summary>
        /// Start point.
        /// </summary>
        Start,

        /// <summary>
        /// End point.
        /// </summary>
        End,

        /// <summary>
        /// Normal point.
        /// </summary>
        Normal
    }

    /// <summary>
    /// Edge point vm side.
    /// </summary>
    public enum EdgePointVMSide
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Left side.
        /// </summary>
        Left,

        /// <summary>
        /// Top side.
        /// </summary>
        Top,

        /// <summary>
        /// Right side.
        /// </summary>
        Right,

        /// <summary>
        /// Bottom side.
        /// </summary>
        Bottom
    }

    
    /// <summary>
    /// Edge point vm operation.
    /// </summary>
    [Flags]
    public enum EdgePointVMOperation
    {
        /// <summary>
        /// Move operation.
        /// </summary>
        Move,

        /// <summary>
        /// Move vertical.
        /// </summary>
        MoveVertical,

        /// <summary>
        /// Move horizontal.
        /// </summary>
        MoveHorizontal
    }

    /// <summary>
    /// This is a view model for an edge point.
    /// </summary>
    public class EdgePointViewModel : BaseViewModel, IEdgePointViewModel
    {
        private EdgePointVMSide edgePointSide;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="edgePoint">Edge point.</param>
        /// <param name="edgePointType">EdgePointVMType.</param>
        public EdgePointViewModel(ViewModelStore viewModelStore, EdgePoint edgePoint, EdgePointVMType edgePointType)
            : base(viewModelStore)
        {
            this.EdgePoint = edgePoint;
            this.EdgePointType = edgePointType;
            this.EdgePointSide = EdgePointVMSide.None;
            this.EdgePointOperation = EdgePointVMOperation.Move;

            this.TranslateX = 0;
            this.TranslateY = 0;

            UpdateTranslateCoordinates();
        }

        /// <summary>
        /// Gets the edge point type.
        /// </summary>
        public EdgePointVMType EdgePointType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the edge point.
        /// </summary>
        public EdgePoint EdgePoint
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the edge point side.
        /// </summary>
        public EdgePointVMSide EdgePointSide
        {
            get
            {
                return this.edgePointSide;
            }
            set
            {
                this.edgePointSide = value;
                UpdateTranslateCoordinates();
            }
        }

        /// <summary>
        /// Gets or set the edge point operation.
        /// </summary>
        public EdgePointVMOperation EdgePointOperation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public double X
        {
            get
            {
                /*
                if (this.EdgePointType == EdgePointVMType.Start || this.EdgePointType == EdgePointVMType.End)
                    if (this.EdgePointSide != EdgePointVMSide.None)
                    {
                        if (this.EdgePointSide == EdgePointVMSide.Left)
                        {
                            return this.EdgePoint.X - 3.5;
                        }
                        else if (this.EdgePointSide == EdgePointVMSide.Right)
                        {
                            return this.EdgePoint.X + 3.5;
                        }
                    }*/

                return this.EdgePoint.X;
            }
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public double Y
        {
            get
            {
                /*
                if (this.EdgePointType == EdgePointVMType.Start || this.EdgePointType == EdgePointVMType.End)
                    if (this.EdgePointSide != EdgePointVMSide.None)
                    {
                        if (this.EdgePointSide == EdgePointVMSide.Bottom)
                        {
                            return this.EdgePoint.Y + 3.5;
                        }
                        else if (this.EdgePointSide == EdgePointVMSide.Top)
                        {
                            return this.EdgePoint.Y - 3.5;
                        }
                    }*/

                return this.EdgePoint.Y;
            }
        }

        /// <summary>
        /// Gets or sets the translate x coordinate.
        /// </summary>
        public double TranslateX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the translate y coordinate.
        /// </summary>
        public double TranslateY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the id of the edge point.
        /// </summary>
        public Guid EdgeId
        {
            get
            {
                return this.EdgePoint.Id;
            }
        }

        private void UpdateTranslateCoordinates()
        {
            if (this.EdgePointType == EdgePointVMType.Start || this.EdgePointType == EdgePointVMType.End)
            {
                if (this.EdgePointSide == EdgePointVMSide.Bottom)
                {
                    TranslateX = -3.5;
                    TranslateY = -3.5;
                }
                else if (this.EdgePointSide == EdgePointVMSide.Top)
                {
                    TranslateX = -3.5;
                    TranslateY = -3.5;
                }
                else if (this.EdgePointSide == EdgePointVMSide.Left)
                {
                    TranslateX = -3.5;
                    TranslateY = -3.5;
                }
                else
                {
                    TranslateX = -3.5;
                    TranslateY = -3.5;
                }
            }
        }
    }
}
