using System.Collections;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Data
{
    /// <summary>
    /// This class contains selected items. Usally those items are of type ModelElement.
    /// </summary>
    public class SelectedItemsCollection : ObservableCollection<object>, IEnumerable
    {
        /// <summary>
        /// Returns an enumerator that iterates through the List of ModelElements.
        /// </summary>
        /// <returns>A List.Enumerator for the List.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
