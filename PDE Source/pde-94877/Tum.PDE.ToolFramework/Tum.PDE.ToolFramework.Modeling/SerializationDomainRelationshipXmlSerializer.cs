using System.Xml;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This is the base class for all generated domain serializers for domain relationships.
    /// </summary>
    public abstract class SerializationDomainRelationshipXmlSerializer : SerializationDomainClassXmlSerializer
    {
        /// <summary>
        /// With the given XmlReader, check if it is currently pointing to a serialized
        /// instance that derives from the ElementLink this serializer can handle. If
        /// so, create an instance of the derived ElementLink instance in the given Partition;
        /// otherwise return NULL.  Note: The caller will guarantee that the reader is
        /// positioned at open XML tag of the element being read. This method should
        /// not move the reader; the reader should remain at the same position when this
        /// method returns.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="reader">XmlReader to read from.</param>
        /// <param name="partition">Partition in which the new link will be created.</param>
        /// <returns>The created ElementLink instance, or null if the reader is not pointing to
        /// a correct serialized instance.</returns>
        /// <remarks>
        /// Note: that this method only tries to create the derived ElementLink instance,
        /// without actually deserializing it. The deserialization will be done by the
        /// Read() methods. There are two reasons for this separation: 1) We may need
        /// to link the created link to its source role player before we can deserializing
        /// it properly.  2) The deserialization can be customized.
        /// </remarks>
        public abstract ElementLink TryCreateDerivedInstance(SerializationContext serializationContext, XmlReader reader, Partition partition);
    }
}
