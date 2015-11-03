using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class which provides type names and type display names for domain classes.
    /// </summary>
    public abstract class ModelElementTypeProvider : IModelElementTypeProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>		
		protected ModelElementTypeProvider()
		{
			
		}

		/// <summary>
        /// Get the name of type of the element as string.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the type for.</param>
        /// <returns>Type name as a string.</returns>
        /// <remarks>
        /// This is essentially equal to modelElement.GetType().Name. But as this
        /// is generated, we dont required to access the actual Type of the element to get its name.
        /// </remarks>
        public string GetTypeName(ModelElement modelElement)
        {
			if( modelElement == null )
				return "";
				
			if( modelElement is IDomainModelOwnable )
				return (modelElement as IDomainModelOwnable).DomainElementType;				

			return "";
        }

        /// <summary>
        /// Get the display name of type of the element as string.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the type display name for.</param>
        /// <returns>Display name of the type as a string.</returns>
        public string GetTypeDisplayName(ModelElement modelElement)
        {
			if( modelElement == null )
				return "";
				
			if( modelElement is IDomainModelOwnable )
				return (modelElement as IDomainModelOwnable).DomainElementTypeDisplayName;				

			return "";
        }

        /// <summary>
        /// Gets the name of the type based on the given domain class Id.
        /// </summary>
        /// <param name="store">Modeling store</param>
        /// <param name="domainClassId">DomainClassId specifying the type of the element.</param>
        /// <returns>Type name as a string.</returns>
        public string GetTypeName(Store store, Guid domainClassId)
        {
            DomainClassInfo info = store.DomainDataDirectory.FindDomainClass(domainClassId);
            if (info != null)
                return info.Name;

            return "";
        }

        /// <summary>
        /// Get the display name of type that is specified by the given domain class Id as string.
        /// </summary>
        /// <param name="store">Modeling store</param>
        /// <param name="domainClassId">DomainClassId specifying the type of the element.</param>
        /// <returns>Display name of the type as a string.</returns>
        public string GetTypeDisplayName(Store store, Guid domainClassId)
        {
            DomainClassInfo info = store.DomainDataDirectory.FindDomainClass(domainClassId);
            if (info != null)
                return info.DisplayName;

            return "";
        }
    }
}
