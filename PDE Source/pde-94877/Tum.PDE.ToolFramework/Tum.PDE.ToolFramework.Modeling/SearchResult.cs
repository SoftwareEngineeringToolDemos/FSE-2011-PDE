using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class represents a search result.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets or sets whether this search result represents a successfull search query or not.
        /// </summary>
        public bool IsSuccessFull
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SearchResult()
        {
            IsSuccessFull = false;
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public ModelElement Source
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        public string Reason
        {
            get;
            set;
        }
    }
}
