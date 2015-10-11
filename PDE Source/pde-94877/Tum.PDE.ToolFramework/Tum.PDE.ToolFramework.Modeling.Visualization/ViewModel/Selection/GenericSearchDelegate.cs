using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Delegate that can be used to search within an generic collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="text">Text to search for.</param>
    /// <param name="itemsToSearchWithin">Items to search within.</param>
    /// <returns>Found items collection.</returns>
    public delegate List<T> GenericSearchDelegate<T>(string text, IEnumerable<T> itemsToSearchWithin);
}
