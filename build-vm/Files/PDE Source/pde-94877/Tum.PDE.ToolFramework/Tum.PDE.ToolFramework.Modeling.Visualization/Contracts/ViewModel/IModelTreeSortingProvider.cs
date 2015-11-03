using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface describing a modeltree sorting priovider.
    /// </summary>
    public interface IModelTreeSortingProvider
    {
        /// <summary>
        /// Method used to add a element into a sorted collection without destroying the sorting order.
        /// </summary>
        /// <param name="parent">Parent model element vm.</param>
        /// <param name="collection">Sorted collection to add the new view models to.</param>
        /// <param name="link">Embedding relationship including the model element as the child (target).</param>
        /// <param name="c">View model representing the model element to be added to the collection.</param>
        void InsertElement(BaseModelElementTreeViewModel parent, ObservableCollection<BaseModelElementTreeViewModel> collection, ElementLink link, BaseModelElementTreeViewModel c);

        /// <summary>
        /// Gets or sets the sorting state of the model tree.
        /// </summary>
        ModelTreeSortingState ModelTreeSortingState
        {
            get;
            set;
        }
    }
}
