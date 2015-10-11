using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class which provides names and display names for domain classes as well as methods to create names for new domain classes.
    /// </summary>
    public class ModelElementNameProvider : IModelElementNameProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>		
		public ModelElementNameProvider()
		{			
		}

        /// <summary>
        /// Verifies if a given modelElement has a name property or not.
        /// </summary>
        /// <param name="modelElement">ModelElement to verify.</param>
        /// <returns>
        /// True if the given model element has a property marked with "IsElementName" set to true. False otherwise.
        /// </returns>
        public virtual bool HasName(ModelElement modelElement)
		{
			if( modelElement is IDomainModelOwnable )
				return (modelElement as IDomainModelOwnable).DomainElementHasName;

			return false;
		}

        /// <summary>
        /// Gets the element name from the property that is marked as "IsElementName".
        /// </summary>
        /// <param name="modelElement">Domain class to get the name for.</param>
        /// <returns>Name of the domain class as string if found. Null otherwise.</returns>
        public virtual string GetName(ModelElement modelElement)
		{
			if( modelElement is IDomainModelOwnable )
				return (modelElement as IDomainModelOwnable).DomainElementName;
			
			return null;		
		}

        /// <summary>
        /// Sets a new name property value for the given element.
        /// </summary>
        /// <param name="modelElement">ModelElement to assign a new value for the name property.</param>
        /// <param name="name">New value to assign to the name property.</param>
        public virtual void SetName(ModelElement modelElement, string name)
		{
			if( modelElement is IDomainModelOwnable )
				(modelElement as IDomainModelOwnable).DomainElementName = name;
		}

        /// <summary>
        /// Method used to create a new element's name based on the range of available names. 
        /// Excluded are names used by the child elements embedded in the given parent element.
        /// </summary>
        /// <param name="parent">Parent element, embedding the model element.</param>
        /// <param name="modelElement">ModelElement to create the name for.</param>
        /// <returns>Created name for the given ModelElement. </returns>
        public virtual string CreateName(ModelElement parent, ModelElement modelElement)
        {
            if (parent is IDomainModelOwnable && modelElement is IDomainModelOwnable)
            {
                if (!(modelElement as IDomainModelOwnable).DomainElementHasName)
                    return null;

                DomainClassInfo infoParent = parent.GetDomainClass();
                DomainClassInfo infoChild = modelElement.GetDomainClass();

                IModelElementParentProvider parentprovider = (parent as IDomainModelOwnable).GetDomainModelServices().ElementParentProvider;
                foreach (DomainRoleInfo roleInfo in infoParent.AllDomainRolesPlayed)
                {
                    if (roleInfo.IsSource)
                        //if (roleInfo.OppositeDomainRole.RolePlayer.Id == infoChild.Id)
                        if( infoChild.IsDerivedFrom(roleInfo.OppositeDomainRole.RolePlayer) )
                            if ((modelElement as IDomainModelOwnable).Store.DomainDataAdvDirectory.IsEmbeddingRelationship(roleInfo.DomainRelationship.Id))
                            {
                                int counter = 0;
                                string name = (modelElement as IDomainModelOwnable).DomainElementTypeDisplayName;
                                while (true)
                                {
                                    bool bFound = false;
                                    IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(parent, roleInfo.Id);

                                    foreach (ElementLink c in links)
                                    {
                                        if ((DomainRoleInfo.GetTargetRolePlayer(c) as IDomainModelOwnable).DomainElementName == name + counter.ToString())
                                        {
                                            bFound = true;
                                            break;
                                        }
                                    }

                                    if (!bFound)
                                        return name + counter.ToString();

                                    counter++;
                                }
                            }
                }
            }

            return null;
        }

        /// <summary>
        /// Method used to create a new elements nam'e based on the range of available names and assign it to the element. 
        /// Excluded are names used by the child elements embedded in the given parent element.
        /// </summary>
        /// <param name="parent">Parent element, embedding the model element.</param>
        /// <param name="modelElement">ModelElement to create and assign the name for.</param>
        /// <returns>Created name for the given ModelElement. Null if the method did not succeed. </returns>
		public virtual string CreateAndAssignName(ModelElement parent, ModelElement modelElement)
        {	
			string name = CreateName(parent, modelElement);
			if( name == null )
				throw new System.NotSupportedException("modelElement: " + modelElement.ToString() + " has no name");
			
			SetName(modelElement, name);
			return name;
		}
		
		/// <summary>
        /// Gets the name property info for a given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the name property info for.</param>
        /// <returns>DomainPropertyInfo for the name property if found. Null otherwise.</returns>
        public virtual DomainPropertyInfo GetNamePropertyInfo(ModelElement modelElement)
		{		
			if( modelElement is IDomainModelOwnable )
				return (modelElement as IDomainModelOwnable).DomainElementNameInfo;
		
			return null;
		}
    }
}
