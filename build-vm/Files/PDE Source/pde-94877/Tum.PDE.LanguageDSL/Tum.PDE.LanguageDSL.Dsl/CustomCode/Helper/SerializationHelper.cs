using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Adds serialized domain properties to reflect the existing domain properties onto the serialization model.
        /// </summary>
        /// <param name="store">Store containing the domain model.</param>
        /// <param name="domainElement">Element to get the domain properties from.</param>
        public static void AddSerializationDomainProperties(Store store, AttributedDomainElement domainElement)
        {
            //if( domainElement.ParentModelContext.MetaModel.IsTopMost )
                UpdateSerializationDomainPropertiesOnCurrentLevel(store, domainElement);
        }

        private static SerializedDomainProperty CreateSerializedDomainProperty(DomainProperty domainProperty)
        {
            SerializedDomainProperty serializedDomainProperty = new SerializedDomainProperty(domainProperty.Store);
            serializedDomainProperty.DomainProperty = domainProperty;
            if (serializedDomainProperty.SerializationName != domainProperty.SerializationName)
            {
                serializedDomainProperty.SerializationName = domainProperty.SerializationName;
                serializedDomainProperty.SerializationRepresentationType = domainProperty.SerializationRepresentationType;
                if (domainProperty.IsSerializationNameTracking == TrackingEnum.True)
                    serializedDomainProperty.IsSerializationNameTracking = TrackingEnum.IgnoreOnce;
            }

            serializedDomainProperty.SerializationRepresentationType = serializedDomainProperty.SerializationRepresentationType;

            return serializedDomainProperty;
        }
        private static SerializedIdProperty CreateSerializedIdProperty(Store store, AttributedDomainElement domainElement)
        {
            SerializedIdProperty idProperty = new SerializedIdProperty(store);
            idProperty.Name = "Id";
            idProperty.SerializationName = domainElement.ParentModelContext.SerializationModel.SerializedIdAttributeName;

            /*
            string idSerializationName = "Id";
            System.Collections.ObjectModel.ReadOnlyCollection<ModelElement> elements = store.ElementDirectory.FindElements(SerializedDomainModel.DomainClassId);
            foreach (ModelElement m in elements)
            {
                idSerializationName = (m as SerializedDomainModel).SerializedIdAttributeName;
                break;
            }
            idProperty.SerializationName = idSerializationName;
            */

            return idProperty;
        }

        /// <summary>
        /// Updaates serialized domain properties (add/remove) to reflect the existing domain properties onto the serialization model.
        /// </summary>
        /// <param name="store">Store containing the domain model.</param>
        /// <param name="serializationElement">Element to add or remove the serialized domain properties to.</param>
        /// <param name="domainElement">Element to get the domain properties from.</param>
        public static void UpdateSerializationDomainPropertiesOnCurrentLevel(Store store, AttributedDomainElement domainElement)
        {
            SerializationClass serializationClass;

            if (domainElement is DomainClass)            
                serializationClass = (domainElement as DomainClass).SerializedDomainClass;            
            else if (domainElement is ReferenceRelationship)
                serializationClass = (domainElement as ReferenceRelationship).SerializedReferenceRelationship;
            
            else if (domainElement is EmbeddingRelationship)
                serializationClass = (domainElement as EmbeddingRelationship).SerializedEmbeddingRelationship;
            else
                throw new NotSupportedException();

            if (serializationClass == null)
                throw new ArgumentNullException("serializationClass");

            // gather serialized properties (and create if required)
            List<SerializedDomainProperty> serializedAttributeProperty = new List<SerializedDomainProperty>();
            List<SerializedDomainProperty> serializedElementProperty = new List<SerializedDomainProperty>();
            foreach (DomainProperty domainProperty in domainElement.Properties)
            {
                if (domainProperty.SerializedDomainProperty == null)
                {
                    domainProperty.SerializedDomainProperty = CreateSerializedDomainProperty(domainProperty);
                    serializationClass.Properties.Add(domainProperty.SerializedDomainProperty);
                }

                if( domainProperty.SerializationRepresentationType == SerializationRepresentationType.Attribute )
                    serializedAttributeProperty.Add(domainProperty.SerializedDomainProperty);
                else
                    serializedElementProperty.Add(domainProperty.SerializedDomainProperty);
            }
            if (serializationClass.IdProperty == null)
            {
                serializationClass.IdProperty = CreateSerializedIdProperty(serializationClass.Store, domainElement);
                serializationClass.Attributes.Add(serializationClass.IdProperty);
            }

            // see what properties are missing or not required any more
            List<SerializedDomainProperty> serializedAttributePropertyToAdd = new List<SerializedDomainProperty>();
            List<SerializedDomainProperty> serializedElementPropertyToAdd = new List<SerializedDomainProperty>();

            foreach (SerializedDomainProperty p in serializedAttributeProperty)
                if (!serializationClass.Attributes.Contains(p))
                    serializedAttributePropertyToAdd.Add(p);

            foreach (SerializedDomainProperty p in serializedElementProperty)
                if (!serializationClass.Children.Contains(p))
                    serializedElementPropertyToAdd.Add(p);

            // add missing properties
            foreach (SerializedDomainProperty p in serializedAttributePropertyToAdd)
                serializationClass.Attributes.Add(p);

            foreach (SerializedDomainProperty p in serializedElementPropertyToAdd)
                serializationClass.Children.Add(p);
        }

        /// <summary>
        /// Updaates serialized domain properties (add/remove) to reflect the existing domain properties onto the serialization model.
        /// </summary>
        /// <param name="store">Store containing the domain model.</param>
        /// <param name="serializationElement">Element to add or remove the serialized domain properties to.</param>
        /// <param name="domainElement">Element to get the domain properties from.</param>
        public static void UpdateSerializationDomainProperties(Store store, SerializationClass serializationClass, AttributedDomainElement domainElement)
        {
            if (serializationClass == null || domainElement == null)
                return;

            //if (!domainElement.ParentModelContext.MetaModel.IsTopMost)
            //    return;

            // update serialization properties on the current level: --> add missing
            UpdateSerializationDomainPropertiesOnCurrentLevel(store, domainElement);

            List<SerializedDomainProperty> serializedAttributePropertyToAdd = new List<SerializedDomainProperty>();
            List<SerializedDomainProperty> serializedElementPropertyToAdd = new List<SerializedDomainProperty>();

            AttributedDomainElement element = domainElement;
            while (element != null)
            {
                foreach (DomainProperty domainProperty in element.Properties)
                {
                    if (domainProperty.SerializedDomainProperty != null)
                    {
                        if (domainProperty.SerializedDomainProperty.SerializationRepresentationType == SerializationRepresentationType.Attribute)
                            serializedAttributePropertyToAdd.Add(domainProperty.SerializedDomainProperty);
                        else if( domainProperty.SerializedDomainProperty.SerializationRepresentationType == SerializationRepresentationType.Element )
                            serializedElementPropertyToAdd.Add(domainProperty.SerializedDomainProperty);
                    }
                }
                element = element.BaseElement;
            }

            // 1. add missing
            foreach (SerializedDomainProperty p in serializedAttributePropertyToAdd)
                if(!serializationClass.Attributes.Contains(p))
                    serializationClass.Attributes.Add(p);

            foreach (SerializedDomainProperty p in serializedElementPropertyToAdd)
                if (!serializationClass.Children.Contains(p))
                    serializationClass.Children.Add(p);

            // 2. remove unneeded ones
            for(int i = serializationClass.Attributes.Count-1; i>=0; i-- )
                if( serializationClass.Attributes[i] is SerializedDomainProperty)
                    if(!serializedAttributePropertyToAdd.Contains(serializationClass.Attributes[i] as SerializedDomainProperty))
                        serializationClass.Attributes.RemoveAt(i);

            for (int i = serializationClass.Children.Count - 1; i >= 0; i--)
                if (serializationClass.Children[i] is SerializedDomainProperty)
                    if (!serializedElementPropertyToAdd.Contains(serializationClass.Children[i] as SerializedDomainProperty))
                        serializationClass.Children.RemoveAt(i);
        }

        /// <summary>
        /// Updates current element properties as well as the properties of all derived elements as well as properties of derived elements of derived elements
        /// </summary>
        /// <param name="element"></param>
        public static void UpdateDerivedElementsSerializationProperties(AttributedDomainElement element)
        {
            if (element is DomainClass)
            {
                UpdateSerializationDomainProperties(element.Store, (element as DomainClass).SerializedDomainClass, element);

                LinkedElementCollection<DomainClass> classes = DomainClassReferencesBaseClass.GetDerivedClasses(element as DomainClass);
                foreach (DomainClass domainClass in classes)
                    UpdateDerivedElementsSerializationProperties(domainClass);
            }
            else if (element is DomainRelationship)
            {
                if (element is ReferenceRelationship)
                    UpdateSerializationDomainProperties(element.Store, (element as ReferenceRelationship).SerializedReferenceRelationship, element);

                if (element is EmbeddingRelationship)
                    UpdateSerializationDomainProperties(element.Store, (element as EmbeddingRelationship).SerializedEmbeddingRelationship, element);

                LinkedElementCollection<DomainRelationship> classes = DomainRelationshipReferencesBaseRelationship.GetDerivedRelationships(element as DomainRelationship);
                foreach (DomainRelationship d in classes)
                    UpdateDerivedElementsSerializationProperties(d);
            }
        }

        /// <summary>
        /// Updates the domain roles of the given element. (Roles from derived elements are included here).
        /// </summary>
        /// <param name="store">Store containing the domain model.</param>
        /// <param name="serializationElement"></param>
        /// <param name="domainClass"></param>
        public static void UpdateSerializationDomainRoles(Store store, SerializedDomainClass serializationElement, DomainClass domainClass)
        {
            if (serializationElement == null || domainClass == null)
                return;

            //if (!serializationElement.DomainClass.ParentModelContext.MetaModel.IsTopMost)
            //    return;

            List<SerializationElement> handledRS = new List<SerializationElement>();

            // get roles
            DomainClass temp = domainClass;
            SerializedDomainClass tempElement = serializationElement;
            while (temp != null && tempElement != null)
            {
                foreach (SerializationElement sP in tempElement.Children)
                {
                    if (sP is SerializedReferenceRelationship || sP is SerializedEmbeddingRelationship)
                    {
                        // see whether the relationship is abstract or not. If it is abstract, than we dont
                        // need to add its role players
                        DomainRelationship relationship = null;
                        SerializedReferenceRelationship s = sP as SerializedReferenceRelationship;
                        if (s != null)
                        {
                            relationship = s.ReferenceRelationship;
                            if (s.ReferenceRelationship.InheritanceModifier == InheritanceModifier.Abstract && s.ReferenceRelationship.Source.RolePlayer != domainClass)
                                continue;
                        }

                        SerializedEmbeddingRelationship sE = sP as SerializedEmbeddingRelationship;
                        if (sE != null)
                        {
                            relationship = sE.EmbeddingRelationship;
                            if (sE.EmbeddingRelationship.InheritanceModifier == InheritanceModifier.Abstract && sE.EmbeddingRelationship.Source.RolePlayer != domainClass)
                                continue;

                        }

                        // see if the current element is still active
                        bool bActive = false;
                        foreach (DomainRole role in temp.RolesPlayed)
                        {
                            if (role.Relationship.Source == role && role.Relationship == relationship)
                            {
                                bActive = true;
                                continue;
                            }
                        }
                        if (!bActive)
                            continue;

                        handledRS.Add(sP);

                        if (tempElement != serializationElement)
                        {
                            // see if we already have this element embedded
                            bool bAdd = true;
                            foreach (SerializationElement elem in serializationElement.Children)
                                if (elem == sP)
                                {
                                    bAdd = false;
                                    break;
                                }

                            if (bAdd)
                            {
                                serializationElement.Children.Add(sP);
                            }
                        }
                    }
                }

                temp = temp.BaseClass;
                if (temp != null)
                    tempElement = temp.SerializedDomainClass;
                else
                    tempElement = null;
            }

            // remove unneded rs
            List<SerializationElement> toRemove = new List<SerializationElement>();
            foreach (SerializationElement sP in serializationElement.Children)
            {
                if (sP is SerializedReferenceRelationship || sP is SerializedEmbeddingRelationship)
                    if (!handledRS.Contains(sP))
                    {
                        toRemove.Add(sP);
                    }
            }

            foreach (SerializationElement sP in toRemove)
                serializationElement.Children.Remove(sP);
        }

        /// <summary>
        /// Updates current element roles as well as domain roles of all derived elements as well as roles of derived elements of derived elements
        /// </summary>
        /// <param name="element"></param>
        public static void UpdateDerivedElementsSerializationDomainRoles(AttributedDomainElement element)
        {
            if (element is DomainClass)
            {
                UpdateSerializationDomainRoles(element.Store, (element as DomainClass).SerializedDomainClass, element as DomainClass);

                LinkedElementCollection<DomainClass> classes = DomainClassReferencesBaseClass.GetDerivedClasses(element as DomainClass);
                foreach (DomainClass domainClass in classes)
                    UpdateDerivedElementsSerializationDomainRoles(domainClass);
            }
        }
    }
}
