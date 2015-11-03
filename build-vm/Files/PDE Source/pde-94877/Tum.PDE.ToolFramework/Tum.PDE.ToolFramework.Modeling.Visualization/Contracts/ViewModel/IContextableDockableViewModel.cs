using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// This is a dockable VM that belongs to a specific model context.
    /// </summary>
    public interface IContextableDockableViewModel : IDockableViewModel
    {
        /// <summary>
        /// Gets the model context name.
        /// </summary>
        string ModelContextName { get; }
    }
}
