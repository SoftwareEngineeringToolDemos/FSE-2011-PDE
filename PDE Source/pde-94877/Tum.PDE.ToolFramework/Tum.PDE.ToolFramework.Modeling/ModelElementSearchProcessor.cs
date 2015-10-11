using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Reflection;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class which provides search functionality.
    /// </summary>
    public abstract class ModelElementSearchProcessor : IModelElementSearchProcessor
    {
        /// <summary>
        /// Gets whether an element is included in the domain tree and therefore should be included in the search.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="domainClassId">Domain class Id.</param>
        /// <returns>True if the element is included in the domain tree. False otherwise.</returns>
        public virtual bool IsElementIncludedInDomainTree(DomainModelStore store, Guid domainClassId)
        {
            return store.DomainDataAdvDirectory.IsIncludedInModel(domainClassId);
        }

        /// <summary>
        /// Gets whether a link is included in the domain tree and therefore should be included in the search.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="domainClassId">Domain class Id.</param>
        /// <returns>True if the link is included in the domain tree. False otherwise.</returns>
        public virtual bool IsLinkIncludedInDomainTree(DomainModelStore store, Guid domainClassId)
        {
            return store.DomainDataAdvDirectory.IsReferenceIncludedInModel(domainClassId);
        }

        /// <summary>
        /// Gets searchable elements as specified by search source enumeration.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="source">Search source.</param>
        /// <returns>List of searchable elements.</returns>
        public virtual List<ModelElement> GetSearchableElements(DomainModelStore store, SearchSourceEnum source)
        {
            System.Collections.Generic.List<ModelElement> elements = new System.Collections.Generic.List<ModelElement>();
            if( source == SearchSourceEnum.Elements || source == SearchSourceEnum.ElementsAndReferenceRelationships )
            {
                    foreach (DomainModelElement modelElement in store.ElementDirectory.FindElements<DomainModelElement>())
                    {
                        if (IsElementIncludedInDomainTree(store, modelElement.GetDomainClassId()))
                            elements.Add(modelElement);
                    }
            }
            if (source == SearchSourceEnum.ReferenceRelationships || source == SearchSourceEnum.ElementsAndReferenceRelationships)
            {
                foreach (DomainModelLink modelElement in store.ElementDirectory.FindElements<DomainModelLink>())
                {
                    if (modelElement.IsEmbedding)
                        continue;

                    DomainClassInfo info = modelElement.GetDomainClass();
                    if (IsLinkIncludedInDomainTree(store, info.Id))
                        elements.Add(modelElement);
                }
            }

            return elements;
        }

        /// <summary>
        /// Search a specific model element by using the given search criteria.
        /// </summary>
        /// <param name="modelElement">Model element to be searched.</param>
        /// <param name="criteria">Search criteria to use.</param>
		/// <param name="searchText">Text to search.</param>
        /// <param name="options">Search options.</param>
        /// <returns>Search result list if any found. Empty list otherwise.</returns>
        public virtual List<SearchResult> Search(ModelElement modelElement, SearchCriteriaEnum criteria, string searchText, SearchOptions options)
        {
            List<SearchResult> results = new List<SearchResult>();
            DomainClassInfo info = modelElement.GetDomainClass();
            Type modelElementType = modelElement.GetType();

            #region properties
            if (criteria == SearchCriteriaEnum.Name ||
                criteria == SearchCriteriaEnum.NameAndType ||
                criteria == SearchCriteriaEnum.All ||
                criteria == SearchCriteriaEnum.Properties || 
				criteria == SearchCriteriaEnum.PropertiesWithoutName)
                foreach (DomainPropertyInfo propertyInfo in info.AllDomainProperties)
                {
                    if (propertyInfo == info.NameDomainProperty &&
                        criteria != SearchCriteriaEnum.Name &&
                        criteria != SearchCriteriaEnum.NameAndType &&
                        criteria != SearchCriteriaEnum.Properties &&
                        criteria != SearchCriteriaEnum.All)
                        continue;
                    else if (propertyInfo != info.NameDomainProperty &&
                        criteria != SearchCriteriaEnum.All &&
                        criteria != SearchCriteriaEnum.Properties &&
                        criteria != SearchCriteriaEnum.PropertiesWithoutName)
                        continue;

                    object nameValue = GetPropertyValue(modelElement, modelElementType, propertyInfo.Name);
                    if (nameValue == null && System.String.IsNullOrEmpty(searchText))
                    {
                        SearchResult searchResult = new SearchResult();
                        searchResult.IsSuccessFull = true;
                        searchResult.Source = modelElement;
                        searchResult.Reason = "Property " + propertyInfo.Name + " is 'null'";

                        results.Add(searchResult);
                    }
                    else if (nameValue != null && !System.String.IsNullOrEmpty(searchText))
                        if (Contains(nameValue.ToString(), searchText, options))
                        {
                            SearchResult searchResult = new SearchResult();
                            searchResult.IsSuccessFull = true;
                            searchResult.Source = modelElement;
                            searchResult.Reason = "Property " + propertyInfo.Name + " contains '" + searchText + "'";

                            results.Add(searchResult);
                        }

                }
			#endregion

            #region roles
            if (criteria == SearchCriteriaEnum.Roles ||
                criteria == SearchCriteriaEnum.All)
            {
                foreach (DomainRoleInfo roleInfo in info.AllDomainRolesPlayed)
                {
                    if (!roleInfo.IsSource)
                        continue;

                    DomainRelationshipInfo relInfo = roleInfo.DomainRelationship;
                    if (!IsLinkIncludedInDomainTree(modelElement.Store as DomainModelStore, relInfo.Id))
                        continue;

                    ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, roleInfo.Id);
                    if (links.Count == 0 && String.IsNullOrEmpty(searchText))
                    {
                        SearchResult searchResult = new SearchResult();
                        searchResult.IsSuccessFull = true;
                        searchResult.Source = modelElement;
                        searchResult.Reason = "Role " + roleInfo.PropertyName + " is empty";

                        results.Add(searchResult);
                    }

                    foreach (ElementLink link in links)
                    {
                        ModelElement m = DomainRoleInfo.GetTargetRolePlayer(link);
                        if (m == null && System.String.IsNullOrEmpty(searchText))
                        {
                            SearchResult searchResult = new SearchResult();
                            searchResult.IsSuccessFull = true;
                            searchResult.Source = modelElement;
                            searchResult.Reason = "Role " + roleInfo.PropertyName + " is null";

                            results.Add(searchResult);
                        }
                        else if (m != null && !System.String.IsNullOrEmpty(searchText))
                            if (Contains((m as IDomainModelOwnable).DomainElementFullName, searchText, options))
                            {
                                SearchResult searchResult = new SearchResult();
                                searchResult.IsSuccessFull = true;
                                searchResult.Source = modelElement;
                                searchResult.Reason = "Role " + roleInfo.PropertyName + " contains '" + searchText + "' in the Full Name property on referenced element " + (m as IDomainModelOwnable).DomainElementFullName;

                                results.Add(searchResult);
                            }
                    }
                }
            }
            #endregion

            #region type
            if (criteria == SearchCriteriaEnum.Type ||
                criteria == SearchCriteriaEnum.NameAndType ||
                criteria == SearchCriteriaEnum.All)
            {
                if (Contains((modelElement as IDomainModelOwnable).DomainElementType, searchText, options) ||
                    Contains((modelElement as IDomainModelOwnable).DomainElementTypeDisplayName, searchText, options))
                {
                    SearchResult searchResult = new SearchResult();
                    searchResult.IsSuccessFull = true;
                    searchResult.Source = modelElement;
                    searchResult.Reason = "Type '" + searchText + "' found";

                    results.Add(searchResult);
                }
            }
            #endregion

            return results;
        }

        /// <summary>
        /// Finds out if a specific text is contained within a string.
        /// </summary>
        /// <param name="text">Text to search within-</param>
        /// <param name="textToSearch">Text to find.</param>
        /// <param name="options">Search options.</param>
        /// <returns>True if the searched text is contained within a string.</returns>
        public virtual bool Contains(string text, string textToSearch, SearchOptions options)
        {
            if (System.String.IsNullOrEmpty(textToSearch))
                return false;

            if (System.String.IsNullOrEmpty(text))
                return false;

            string temp = text;
            string tempSearchString = textToSearch;

            if (!options.DoMatchCase)
            {
                temp = temp.ToLower();
                tempSearchString = tempSearchString.ToLower();
            }

            if (options.DoMatchWholeWord)
            {
                int index = temp.IndexOf(tempSearchString);
                while (index >= 0)
                {
                    if (temp.Length < index + tempSearchString.Length)
                        break;

                    bool bWordStartOk = false;
                    bool bWordEndOk = false;

                    if (index == 0)
                        bWordStartOk = true;

                    if (index + tempSearchString.Length == temp.Length)
                        bWordEndOk = true;

                    if (!bWordStartOk)
                    {
                        if (temp[index - 1] == ' ')
                            bWordStartOk = true;
                    }

                    if (!bWordEndOk)
                    {
                        if (temp[index + tempSearchString.Length - 1] == ' ')
                            bWordEndOk = true;
                    }

                    if (bWordStartOk && bWordEndOk)
                    {
                        return true;
                    }

                    if (temp.Length > index + tempSearchString.Length)
                        index = temp.IndexOf(tempSearchString, index + tempSearchString.Length);
                    else
                        break;
                }
            }
            else
            {
                if (temp.Contains(tempSearchString))
                    return true;
            }

            return false;
        }

        private object GetPropertyValue(ModelElement element, Type type, string propertyName)
        {
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                object value = propertyInfo.GetValue(element, null);
                if (value != null)
                    return value;
            }

            return null;
        }
    }
}
