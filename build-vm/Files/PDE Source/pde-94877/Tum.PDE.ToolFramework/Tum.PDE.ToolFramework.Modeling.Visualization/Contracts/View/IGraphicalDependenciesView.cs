using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View
{   
    /// <summary>
    /// Interface specifying a GraphicalDependenciesView.
    /// </summary>
    public interface IGraphicalDependenciesView
    {
        /// <summary>
        /// Gets the actual size of the view.
        /// </summary>
        /// <returns></returns>
        SizeD GetSize();
    }
}
