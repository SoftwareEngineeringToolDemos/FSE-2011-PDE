using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Edge point vm interface.
    /// </summary>
    public interface IEdgePointViewModel
    {
        /// <summary>
        /// Gets the edge point type.
        /// </summary>
        EdgePointVMType EdgePointType
        {
            get;
        }

        /// <summary>
        /// Gets the edge point.
        /// </summary>
        EdgePoint EdgePoint
        {
            get;
        }

        /// <summary>
        /// Gets or sets the edge point side.
        /// </summary>
        EdgePointVMSide EdgePointSide
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set the edge point operation.
        /// </summary>
        EdgePointVMOperation EdgePointOperation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the id of the edge point.
        /// </summary>
        Guid EdgeId
        {
            get;
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        double X
        {
            get;
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        double Y
        {
            get;
        }
    }
}
