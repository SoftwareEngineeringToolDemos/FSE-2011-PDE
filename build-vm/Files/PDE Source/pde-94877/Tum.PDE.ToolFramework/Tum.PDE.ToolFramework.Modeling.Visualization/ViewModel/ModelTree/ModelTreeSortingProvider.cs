using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// Sorting state.
    /// </summary>
    public enum ModelTreeSortingState
    {
        /// <summary>
        /// No sorting enabled.
        /// </summary>
        None,

        /// <summary>
        /// Sorting enabled.
        /// </summary>
        Sorted
    }

    /// <summary>
    /// Default model tree sorting provider.
    /// </summary>
    /// <remarks>
    /// We are adding elements sorted first by type and then by name.
    /// If the element doesnt have a name, we add it at the end of the list (still sorted by type).
    /// </remarks>
    public class ModelTreeSortingProvider : IModelTreeSortingProvider
    {
        private ModelTreeSortingState sortingState = ModelTreeSortingState.Sorted;

        /// <summary>
        /// Method used to add a element into a sorted collection without destroying the sorting order.
        /// </summary>
        /// <param name="parent">Parent model element vm.</param>
        /// <param name="collection">Sorted collection to add the new view models to.</param>
        /// <param name="link">Embedding relationship including the model element as the child (target).</param>
        /// <param name="c">View model representing the model element to be added to the collection.</param>
        public virtual void InsertElement(BaseModelElementTreeViewModel parent, ObservableCollection<BaseModelElementTreeViewModel> collection, ElementLink link, BaseModelElementTreeViewModel c)
        {
            // we are adding elements sorted first by type and name
            // if the element doesnt have a name, we add it at the end of the list (still sorted by type)
            if (!c.DomainElementHasName)
            {
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    BaseModelElementTreeViewModel vm = collection[i];
                    if (vm.DomainElementTypeDisplayName == c.DomainElementTypeDisplayName)
                    {
                        collection.Insert(i + 1, c);
                        return;
                    }
                }
            }
            else
            {
                if (c.DomainElementName == null)
                    throw new System.ArgumentNullException("DomainElementName can not be null");

                bool bFoundType = false;
                for (int i = 0; i < collection.Count; ++i)
                {
                    BaseModelElementTreeViewModel vm = collection[i];
                    if (vm.DomainElementTypeDisplayName == c.DomainElementTypeDisplayName)
                    {
                        bFoundType = true;
                        if (c.DomainElementName.CompareTo(vm.DomainElementName) <= 0)
                        {
                            collection.Insert(i, c);
                            return;
                        }
                    }
                    else if (bFoundType)
                    {
                        collection.Insert(i, c);
                        return;
                    }
                }
                if (bFoundType)
                {
                    collection.Add(c);
                    return;
                }
            }

            // if no element of type of c is present, we add it sorted by type
            for (int i = 0; i < collection.Count; ++i)
            {
                BaseModelElementTreeViewModel vm = collection[i];
                if (c.DomainElementTypeDisplayName.CompareTo(vm.DomainElementTypeDisplayName) <= 0)
                {
                    collection.Insert(i, c);
                    return;
                }
            }

            // if no element at all is present, add c at the end
            collection.Add(c);
        }

        /// <summary>
        /// Gets or sets the sorting state of the model tree.
        /// </summary>
        public virtual ModelTreeSortingState ModelTreeSortingState
        {
            get
            {
                return this.sortingState;
            }
            set
            {
                this.sortingState = value;
            }
        }
    }
}
