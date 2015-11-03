using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// Prototype class for an element.
    /// </summary>
    /// <remarks>
    /// Source: DSL-Tools framework for the most part.
    /// </remarks>
    [System.Serializable]
    public class ModelProtoElement : ISerializable, IDeserializationCallback
    {
        private Guid domainClassId;
        private Guid elementId;

        private System.Collections.ArrayList properties;

        private ModelProtoGroup customChildGroup = null;
        private SerializationInfo serializationInfo;

        private string name = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="element">Model element.</param>
        public ModelProtoElement(ModelElement element)
        {
            if (element == null)
                throw new System.ArgumentNullException("element");

            elementId = element.Id;
            domainClassId = element.GetDomainClass().Id;

            List<PropertyAssignment> list = GetAssignablePropertyValues(element);
            properties = new System.Collections.ArrayList(list.Count);

            foreach (PropertyAssignment propertyAssignment in list)
                properties.Add(new ModelProtoPropertyValue(propertyAssignment.PropertyId, propertyAssignment.Value));

            DomainClassInfo d = element.GetDomainClass();
            name = d.Name;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ModelProtoElement(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            serializationInfo = info;
        }

        /// <summary>
        /// Deserialize.
        /// </summary>
        public void OnDeserialization(object sender)
        {
            elementId = (Guid)serializationInfo.GetValue("elementId", typeof(Guid));
            domainClassId = (Guid)serializationInfo.GetValue("domainClassId", typeof(Guid));
            properties = (System.Collections.ArrayList)serializationInfo.GetValue("properties", typeof(System.Collections.ArrayList));
            name = (string)serializationInfo.GetValue("name", typeof(string));

            try
            {
                customChildGroup = (ModelProtoGroup)serializationInfo.GetValue("customChildGroup", typeof(ModelProtoGroup));
            }
            catch { }

            try
            {
                CustomArguments = serializationInfo.GetValue("customArguments", typeof(IModelMergeCustomArguments)) as IModelMergeCustomArguments;
            }
            catch
            {
            }
            
        }

        /// <summary>
        /// Gets the model element domain class Id.
        /// </summary>
        public Guid DomainClassId
        {
            get
            {
                return domainClassId;
            }
        }

        /// <summary>
        /// Gets the element Id.
        /// </summary>
        public Guid ElementId
        {
            get
            {
                return elementId;
            }
        }

        /// <summary>
        /// Gets the name of the domain class.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public IModelMergeCustomArguments CustomArguments
        {
            get;
            set;
        }

        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("elementId", elementId, typeof(System.Guid));
            info.AddValue("domainClassId", domainClassId, typeof(System.Guid));
            info.AddValue("properties", properties, typeof(System.Collections.ArrayList));
            info.AddValue("name", name, typeof(string));

            if (customChildGroup != null)
                info.AddValue("customChildGroup", this.customChildGroup, typeof(ModelProtoGroup));

            if( CustomArguments != null )
                info.AddValue("customArguments", CustomArguments, this.CustomArguments.GetSerializerType());
        }

        /// <summary>
        /// Gets the property assignments based on the element this proto element represents.
        /// </summary>
        /// <param name="partition">Partition to use.</param>
        /// <param name="elementId">Id to assign to the IdPropertyAssignment.</param>
        /// <returns>Array of property assignments.</returns>
        public PropertyAssignment[] GetPropertyAssignments(Partition partition, Guid elementId)
        {
            if (partition == null)
                throw new System.ArgumentNullException("partition");

            int length = properties.Count + 1;

            PropertyAssignment[] propertyAssignmentArr = new PropertyAssignment[length];
            for (int i = 0; i < properties.Count; i++)
            {
                ModelProtoPropertyValue protoPropertyValue = (ModelProtoPropertyValue)properties[i];
                DomainPropertyInfo domainPropertyInfo = partition.DomainDataDirectory.FindDomainProperty(protoPropertyValue.DomainPropertyId);
                propertyAssignmentArr[i] = new PropertyAssignment(protoPropertyValue.DomainPropertyId, protoPropertyValue.PropertyValue);
            }

            propertyAssignmentArr[properties.Count] = new PropertyAssignment(ElementFactory.IdPropertyAssignment, elementId);           

            return propertyAssignmentArr;
        }

        /// <summary>
        /// Gets or sets a custom child proto group.
        /// </summary>
        public ModelProtoGroup CustomChildGroup
        {
            get { return this.customChildGroup; }
            set
            {
                this.customChildGroup = value;
            }
        }

        /// <summary>
        /// Gets a list of PropertyAssignments for all assignable properties.
        /// </summary>
        /// <param name="element">Element to get PropertyAssignments for.</param>
        /// <returns>List of PropertyAssignment.</returns>
        public static List<PropertyAssignment> GetAssignablePropertyValues(ModelElement element)
        {
            List<PropertyAssignment> list = new List<PropertyAssignment>();
            ReadOnlyCollection<DomainPropertyInfo> readOnlyCollection = element.GetDomainClass().AllDomainProperties;
            foreach (DomainPropertyInfo domainPropertyInfo in readOnlyCollection)
            {
                if (domainPropertyInfo.Kind != Microsoft.VisualStudio.Modeling.DomainPropertyKind.Calculated)
                {
                    object obj = domainPropertyInfo.GetValue(element);
                    if (obj != null)
                        list.Add(new PropertyAssignment(domainPropertyInfo.Id, obj));
                }
            }            
            return list;
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>true if the specified System.Object is equal to the current System.Object;
        /// otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ModelProtoElement)
                return (obj as ModelProtoElement).ElementId == this.ElementId;
            else
                return base.Equals(obj);
        }

        /// <summary>
        /// Returns the hash code for this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.elementId.GetHashCode();
        }
    }
}
