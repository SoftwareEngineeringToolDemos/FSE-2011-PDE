using System.Xml;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This is the base class for all generated domain serializers.
    /// </summary>
    public abstract class SerializationDomainClassXmlSerializer : DomainClassXmlSerializer
    {
        /// <summary>
        /// Public Write() method that serializes the ModelElement instance associated with this serializer instance into XML.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance that will be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="rootElementSettings"></param>
        /// <param name="options">Serialization options.</param>
        public abstract void Write(SerializationContext serializationContext, ModelElement element, XmlWriter writer, RootElementSettings rootElementSettings, SerializationOptions options);

        /// <summary>
        /// Public Write() method that serializes the ModelElement instance associated with this serializer instance into XML.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance that will be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="options">Serialization options.</param>
        public void Write(SerializationContext serializationContext, ModelElement element, XmlWriter writer, SerializationOptions options)
        {
            Write(serializationContext, element, writer, null, options);
        }

        /// <summary>
        /// Write any additional element data associated with the element.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance that is currently being written.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="options">Serialization options.</param>
        protected virtual void WriteAdditionalElementData(SerializationContext serializationContext, ModelElement element, XmlWriter writer, SerializationOptions options)
        {
        }

        /// <summary>
        /// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="options">Serialization options.</param>
        protected virtual void WriteElements(SerializationContext serializationContext, ModelElement element, XmlWriter writer, SerializationOptions options)
        {
        }

        /// <summary>
        /// Write all properties that need to be serialized as XML attributes.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="options">Serialization options.</param>
        protected virtual void WritePropertiesAsAttributes(SerializationContext serializationContext, ModelElement element, XmlWriter writer, SerializationOptions options)
        {
        }
       
        /// <summary>
        /// Public WriteRootElement() method that serializes a root-level element to XML.  
        /// The difference between root-level element and the rest elements in the XML is that the root may carry 
        /// additional information like schema, version, etc. The default implementation just calls Write() method 
        /// with no RootElementSettings, it's up to the derived implementations to do any additional checks.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">ModelElement instance that will be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="options">Serialization options.</param>
        public virtual void WriteRootElement(SerializationContext serializationContext, ModelElement element, XmlWriter writer, SerializationOptions options)
        {
            Write(serializationContext, element, writer, null, options);
        }
    }
}
