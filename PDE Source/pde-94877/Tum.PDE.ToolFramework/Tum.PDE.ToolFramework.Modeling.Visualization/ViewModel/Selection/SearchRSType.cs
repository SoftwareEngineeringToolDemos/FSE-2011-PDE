using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Helper class to search within elements of type SearchRSType.
    /// </summary>
    public class SearchRSType
    {
        /// <summary>
        /// Struct to define elements that we want to search within. Those elements
        /// are defined via a model element VM and a specific relationship type.
        /// </summary>
        public struct SearchRSTypeStruct
        {
            private string relationshipType;
            private string relationshipShapeType;
            private Guid domainClassId;

            /// <summary>
            /// Gets the relationship type.
            /// </summary>
            public string RelationshipType
            {
                get { return relationshipType; }
            }

            /// <summary>
            /// Gets the relationship shape type.
            /// </summary>
            public string RelationshipShapeType
            {
                get { return relationshipShapeType; }
            }

            /// <summary>
            /// Gets the full name.
            /// </summary>
            public string FullName
            {
                get
                {
                    return this.RelationshipType + " (" + this.RelationshipShapeType + ")";
                }
            }

            /// <summary>
            /// Gets the domain class Id of the relationship.
            /// </summary>
            public Guid DomainClassId
            {
                get
                {
                    return this.domainClassId;
                }
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="domainClassId">Domain class ID specifying the type of RS.</param>
            /// <param name="relationshipTypeDisplayName">Display name of RS.</param>
            /// <param name="relationshipShapeDisplayName">Display name of the RS shape.</param>
            public SearchRSTypeStruct(Guid domainClassId, string relationshipTypeDisplayName, string relationshipShapeDisplayName)
            {
                this.domainClassId = domainClassId;
                this.relationshipType = relationshipTypeDisplayName;
                this.relationshipShapeType = relationshipShapeDisplayName;
            }
        }

        /// <summary>
        /// Function that can be used as a delegate to execute the search.
        /// </summary>
        /// <param name="textToSearch">Text to search for.</param>
        /// <param name="itemsToSearchWithin">List to search within.</param>
        /// <returns></returns>
        public static List<SearchRSTypeStruct> Search(string textToSearch, IEnumerable<SearchRSTypeStruct> itemsToSearchWithin)
        {
            List<SearchRSTypeStruct> foundItems = new List<SearchRSTypeStruct>();

            string searchString = textToSearch.Trim();
            foreach (SearchRSTypeStruct element in itemsToSearchWithin)
            {
                if (searchString == String.Empty)
                {
                    foundItems.Add(element);
                    continue;
                }

                if (element.FullName != null)
                    if (element.FullName.Contains(searchString))
                        foundItems.Add(element);
            }

            return foundItems;
        }

        /// <summary>
        /// Function that can be used to sort item list of type SearchElementWithRSTypeStruct.
        /// </summary>
        /// <param name="items">List to sort.</param>
        public static IEnumerable<SearchRSTypeStruct> Sort(ObservableCollection<SearchRSTypeStruct> items)
        {
            IOrderedEnumerable<SearchRSTypeStruct> itemsSorted = items.OrderBy<SearchRSTypeStruct, string>((x) => (x.RelationshipType));
            return itemsSorted;
        }
    }
}
