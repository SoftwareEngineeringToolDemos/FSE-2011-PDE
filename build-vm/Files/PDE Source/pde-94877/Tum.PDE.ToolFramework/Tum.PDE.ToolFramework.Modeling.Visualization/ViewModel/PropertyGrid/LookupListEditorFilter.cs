namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Represents the method that decides if the given element should be removed from the collection or not.
    /// </summary>
    /// <typeparam name="T">The type of the element. </typeparam>
    /// <returns>True if the element should be removed from the collection. False otherwise.</returns>
    public delegate bool LookupListEditorFilter<T>(LookupListEditorViewModel viewModel, T currentValue, T x);

}
