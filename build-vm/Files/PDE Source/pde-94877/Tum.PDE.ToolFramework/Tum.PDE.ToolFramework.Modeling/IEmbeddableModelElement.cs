using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes an embeddable domain model element.
    /// </summary>
    public interface IEmbeddableModelElement
    {
        /// <summary>
        /// True if parent element has a name.
        /// </summary>
        bool DomainElementParentHasName
        {
            get;
        }

        /// <summary>
        /// Returns the parent name (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        string DomainElementParentName
        {
            get;
        }

        /// <summary>
        /// Returns the parent name + (type name) (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        string DomainElementParentFullName
        {
            get;
        }

        /// <summary>
        /// True if there is a first parent element, which has a DomainElementName name.
        /// </summary>
        bool DomainElementParentHasFirstExistingName
        {
            get;
        }

        /// <summary>
        /// Returns the DomainElementName of the first parent to actually have a name.
        /// </summary>
        string DomainElementParentFirstExistingName
        {
            get;
        }

        /// <summary>
        /// Returns true if this elements parent has an embedding full path.
        /// </summary>
        bool DomainElementHasParentFullPath
        {
            get;
        }

        /// <summary>
        /// Returns the full path of the parent element relative to the domain model element.
        /// </summary>
        string DomainElementParentFullPath
        {
            get;
        }
    }
}
