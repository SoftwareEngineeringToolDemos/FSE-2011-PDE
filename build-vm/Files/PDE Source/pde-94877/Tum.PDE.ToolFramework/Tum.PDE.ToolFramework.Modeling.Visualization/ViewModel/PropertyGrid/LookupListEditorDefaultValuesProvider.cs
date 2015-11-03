using System.Collections.Generic;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Represents the method that provides a default values collection for a given view model.
    /// </summary>
    /// <typeparam name="T">The type of the element. </typeparam>
    /// <returns>List of default values.</returns>
    public delegate List<T> LookupListEditorDefaultValuesProvider<T>(LookupListEditorViewModel viewModel);
}
