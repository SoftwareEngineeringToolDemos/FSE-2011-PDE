using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes a model element that is owned by a domain model.
    /// </summary>
    public interface IDomainModelOwnable
    {
        /// <summary>
        /// Gets the domain model type.
        /// </summary>
        /// <returns></returns>
        Type GetDomainModelType();

        /// <summary>
        /// Gets the domain model DomainClassId.
        /// </summary>
        /// <returns></returns>
        Guid GetDomainModelTypeId();

        /// <summary>
        /// Gets the domain model services.
        /// </summary>
        /// <returns></returns>
        IDomainModelServices GetDomainModelServices();

        /// <summary>
        /// Gets or sets the value of the property (which is marked as element name)
        /// </summary>
        string DomainElementName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the full name of the element.
        /// </summary>
        /// <remarks>
        /// This is either: ElementName (elemenType) or just ElementType.
        /// </remarks>
        string DomainElementFullName
        {
            get;
        }

        /// <summary>
        /// Gets whether the domain element has a property marked as element name.
        /// </summary>
        bool DomainElementHasName
        {
            get;
        }

        /// <summary>
        /// Gets the domain element name info if there is one; Null otherwise.
        /// </summary>
        DomainPropertyInfo DomainElementNameInfo
        {
            get;
        }

        /// <summary>
        /// Gets the type of the ModelElement as string.
        /// </summary>
        string DomainElementType
        {
            get;
        }

        /// <summary>
        /// Gets the display name of the type of the ModelElement.
        /// </summary>
        string DomainElementTypeDisplayName
        {
            get;
        }

        ///// <summary>
        ///// Gets the document data
        ///// </summary>
        //ModelData DocumentData
        //{
        //    get;
        // }

        /// <summary>
        /// Gets the domain model store.
        /// </summary>
        DomainModelStore Store
        {
            get;
        }
    }
}
