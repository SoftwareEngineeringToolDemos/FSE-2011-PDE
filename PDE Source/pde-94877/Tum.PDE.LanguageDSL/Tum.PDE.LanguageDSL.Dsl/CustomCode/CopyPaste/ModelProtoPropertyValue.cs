using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// ModelProtoPropertyValue contains the information necessary to populate an attribute value for a particular ModelElement.  
    /// Two Serialization Formats are used. For primitives, strings, and arrays of primitives/strings, the same type-based 
    /// Serialization format is used. For everything else, we have a non-type based serialization format.
    /// </summary>
    /// <remarks>
    /// Source: DSL-Tools framework for the most part.
    /// </remarks>
    [System.Serializable]
    public class ModelProtoPropertyValue : ISerializable
    {
        private readonly Guid propertyId;

        private object propertyValue;
        private byte[] propertyValueBytes;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domainPropertyId">Domain property Id.</param>
        /// <param name="propertyValue">Value of the property.</param>
        public ModelProtoPropertyValue(Guid domainPropertyId, object propertyValue)
        {
            if (domainPropertyId == System.Guid.Empty)
                throw new System.ArgumentNullException("domainPropertyId");
            if (propertyValue == null)
                throw new System.ArgumentNullException("propertyValue");
            
            this.propertyId = domainPropertyId;
            this.propertyValue = propertyValue;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ModelProtoPropertyValue(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            propertyId = (System.Guid)info.GetValue("propertyId", typeof(System.Guid));

            if (UseTypeBasedDeserialization(info))
            {
                Type type = (Type)info.GetValue("propertyType", typeof(Type));
                propertyValue = info.GetValue("propertyValue", type);
                return;
            }
            propertyValueBytes = (byte[])info.GetValue("propertyValue", typeof(byte[]));
        }

        /// <summary>
        /// Gets the domain property Id.
        /// </summary>
        public Guid DomainPropertyId
        {
            get
            {
                return propertyId;
            }
        }

        /// <summary>
        /// Gets the domain property value.
        /// </summary>
        public object PropertyValue
        {
            get
            {
                if ((propertyValue == null) && (propertyValueBytes != null))
                {
                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(propertyValueBytes))
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        propertyValue = binaryFormatter.Deserialize(memoryStream);
                    }
                }
                return propertyValue;
            }
        }

        /// <summary>
        /// Creates a new property assignment.
        /// </summary>
        /// <returns>Property assignment.</returns>
        public PropertyAssignment CreatePropertyAssignment()
        {
            return new PropertyAssignment(propertyId, PropertyValue);
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

            info.AddValue("propertyId", propertyId, typeof(System.Guid));

            if (UseTypeBasedSerialization(propertyValue))
            {
                info.AddValue("propertyType", propertyValue.GetType(), typeof(System.Type));
                info.AddValue("propertyValue", propertyValue, propertyValue.GetType());
                return;
            }
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                if (propertyValue != null)
                {
                    binaryFormatter.Serialize(memoryStream, propertyValue);
                    info.AddValue("propertyValue", memoryStream.ToArray(), typeof(byte[]));
                    return;
                }
                info.AddValue("propertyValue", propertyValueBytes, typeof(byte[]));
            }
        }

        private static bool UseTypeBasedDeserialization(SerializationInfo info)
        {
            bool flag = false;
            SerializationInfoEnumerator serializationInfoEnumerator = info.GetEnumerator();
            while (serializationInfoEnumerator.MoveNext())
            {
                if (serializationInfoEnumerator.Name.Equals("propertyType") && (serializationInfoEnumerator.Value as System.Type) != null)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        private static bool UseTypeBasedSerialization(object propertyValue)
        {
            if (propertyValue == null)
                return false;
            System.Type type1 = propertyValue.GetType();
            System.Type type2 = typeof(string);
            if (!type1.IsPrimitive && !type2.Equals(type1) && (!type1.IsArray || !type1.GetElementType().IsPrimitive))
            {
                if (type1.IsArray)
                    return type2.Equals(type1.GetElementType());
                return false;
            }
            return true;
        }
    }
}
