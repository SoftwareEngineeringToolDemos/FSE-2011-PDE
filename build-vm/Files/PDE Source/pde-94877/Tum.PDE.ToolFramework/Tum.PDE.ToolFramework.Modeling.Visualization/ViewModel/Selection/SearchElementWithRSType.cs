using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Helper class to search within elements of type SearchElementWithRSTypeStruct.
    /// </summary>
    public class SearchElementWithRSType
    {
        /// <summary>
        /// Struct to define elements that we want to search within. Those elements
        /// are defined via a model element VM and a specific relationship type.
        /// </summary>
        public struct SearchElementWithRSTypeStruct
        {
            private BaseModelElementViewModel elementViewModel;
            private string relationshipType;
            private Guid relationshipDomainClassId;

            /// <summary>
            /// Gets the element VM.
            /// </summary>
            public BaseModelElementViewModel ElementViewModel
            {
                get { return elementViewModel; }
            }

            /// <summary>
            /// Gets the relationship type.
            /// </summary>
            public string RelationshipType
            {
                get { return relationshipType; }
            }

            /// <summary>
            /// Gets the relationship type.
            /// </summary>
            public Guid RelationshipDomainClassId
            {
                get { return relationshipDomainClassId; }
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="elementVM"></param>
            /// <param name="relationshipType"></param>
            /// <param name="relationshipDomainClassId"></param>
            public SearchElementWithRSTypeStruct(BaseModelElementViewModel elementVM, string relationshipType, Guid relationshipDomainClassId)
            {
                this.elementViewModel = elementVM;
                this.relationshipType = relationshipType;
                this.relationshipDomainClassId = relationshipDomainClassId;
            }
        }

        /// <summary>
        /// Function that can be used as a delegate to execute the search.
        /// </summary>
        /// <param name="textToSearch">Text to search for.</param>
        /// <param name="itemsToSearchWithin">List to search within.</param>
        /// <returns></returns>
        public static List<SearchElementWithRSTypeStruct> Search(string textToSearch, IEnumerable<SearchElementWithRSTypeStruct> itemsToSearchWithin)
        {
            List<SearchElementWithRSTypeStruct> foundItems = new List<SearchElementWithRSTypeStruct>();

            string searchString = textToSearch.Trim();
            foreach (SearchElementWithRSTypeStruct element in itemsToSearchWithin)
            {
                if (searchString == String.Empty)
                {
                    foundItems.Add(element);
                    continue;
                }

                if( element.RelationshipType != null )
                    if (element.RelationshipType.Contains(searchString))
                        foundItems.Add(element);

                if( element.ElementViewModel != null )
                    if (element.ElementViewModel.DomainElementFullName.Contains(searchString))
                        foundItems.Add(element);
            }

            return foundItems;
        }

        /// <summary>
        /// Function that can be used to sort item list of type SearchElementWithRSTypeStruct.
        /// </summary>
        /// <param name="items">List to sort.</param>
        public static IEnumerable<SearchElementWithRSTypeStruct> Sort(ObservableCollection<SearchElementWithRSTypeStruct> items)
        {
            IOrderedEnumerable<SearchElementWithRSTypeStruct> itemsSorted = items.OrderBy<SearchElementWithRSTypeStruct, string>((x) => (x.ElementViewModel.DomainElementFullName));
            return itemsSorted;
        }
    }
}
