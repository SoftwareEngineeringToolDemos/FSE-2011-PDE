using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface specifying a GraphicalDependenciesViewModel.
    /// </summary>
    public interface IGraphicalDependenciesViewModel
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        IGraphicalDependenciesView View { get; set; }
    }
}
