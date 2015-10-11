using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Delegate that can be used to sort a generic collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="itemsToSearchWithin">Items to sort.</param>
    /// <returns>Sorted collection.</returns>
    public delegate IEnumerable<T> GenericSortDelegate<T>(ObservableCollection<T> itemsToSearchWithin);
}
