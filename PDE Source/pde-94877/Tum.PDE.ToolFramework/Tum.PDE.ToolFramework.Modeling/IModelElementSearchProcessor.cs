using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Interface specifiying a search processor.
    /// </summary>
    public interface IModelElementSearchProcessor
    {
        /// <summary>
        /// Gets searchable elements as specified by search source enumeration.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="source">Search source.</param>
        /// <returns>List of searchable elements.</returns>
        List<ModelElement> GetSearchableElements(DomainModelStore store, SearchSourceEnum source);

        /// <summary>
        /// Search a specific model element by using the given search criteria.
        /// </summary>
        /// <param name="modelElement">Model element to be searched.</param>
        /// <param name="criteria">Search criteria to use.</param>
        /// <param name="searchText">Text to search.</param>
        /// <param name="options">Search options.</param>
        /// <returns>List of search results.</returns>
        List<SearchResult> Search(ModelElement modelElement, SearchCriteriaEnum criteria, string searchText, SearchOptions options);

        /// <summary>
        /// Gets whether an element is included in the domain tree and therefore should be included in the search.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="domainClassId">Domain class Id.</param>
        /// <returns>True if the element is included in the domain tree. False otherwise.</returns>
        bool IsElementIncludedInDomainTree(DomainModelStore store, Guid domainClassId);

        /// <summary>
        /// Gets whether a link is included in the domain tree and therefore should be included in the search.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="domainClassId">Domain class Id.</param>
        /// <returns>True if the link is included in the domain tree. False otherwise.</returns>
        bool IsLinkIncludedInDomainTree(DomainModelStore store, Guid domainClassId);

        /// <summary>
        /// Finds out if a specific text is contained within a string.
        /// </summary>
        /// <param name="text">Text to search within-</param>
        /// <param name="textToSearch">Text to find.</param>
        /// <param name="options">Search options.</param>
        /// <returns>True if the searched text is contained within a string.</returns>
        bool Contains(string text, string textToSearch, SearchOptions options);
    }
}
