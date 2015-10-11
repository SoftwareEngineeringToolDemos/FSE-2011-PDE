using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class MetaModelLibrarySerializer
    {
        /// <summary>
        /// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">MetaModelLibrary instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>        
        protected override void WriteElements(SerializationContext serializationContext, ModelElement element, global::System.Xml.XmlWriter writer)
        {
            MetaModelLibrary instance = element as MetaModelLibrary;
            global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of MetaModelLibrary!");

            // Write properties serialized as nested XML elements.
            if (!serializationContext.Result.Failed)
                WritePropertiesAsElements(serializationContext, instance, writer);
        }

        /// <summary>
        /// Serialize all properties that need to be stored as nested XML elements.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">MetaModelLibrary instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
        private static void WritePropertiesAsElements(SerializationContext serializationContext, MetaModelLibrary element, global::System.Xml.XmlWriter writer)
        {
            // FilePath
            if (!serializationContext.Result.Failed)
            {
                global::System.String propValue = element.FilePath;
                if (!serializationContext.Result.Failed)
                {
                    if (!string.IsNullOrEmpty(propValue))
                        LanguageDSLSerializationHelper.Instance.WriteElementString(serializationContext, element, writer, "filePath", propValue);

                }
            }
            // Name
            if (!serializationContext.Result.Failed)
            {
                global::System.String propValue = element.Name;
                if (!serializationContext.Result.Failed)
                {
                    if (!string.IsNullOrEmpty(propValue))
                        LanguageDSLSerializationHelper.Instance.WriteElementString(serializationContext, element, writer, "name", propValue);

                }
            }
        }

        /// <summary>
        /// This methods deserializes nested XML elements inside the passed-in element.
        /// </summary>
        /// <remarks>
        /// The caller will guarantee that the current element does have nested XML elements, and the call will position the 
        /// reader at the open tag of the first child XML element.
        /// This method will read as many child XML elements as it can. It returns under three circumstances:
        /// 1) When an unknown child XML element is encountered. In this case, this method will position the reader at the open 
        ///    tag of the unknown element. This implies that if the first child XML element is unknown, this method should return 
        ///    immediately and do nothing.
        /// 2) When all child XML elemnets are read. In this case, the reader will be positioned at the end tag of the parent element.
        /// 3) EOF.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">In-memory MetaModelLibrary instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        protected override void ReadElements(SerializationContext serializationContext, ModelElement element, global::System.Xml.XmlReader reader)
        {
            base.ReadElements(serializationContext, element, reader);

            MetaModelLibrary instanceOfMetaModelLibrary = element as MetaModelLibrary;
            global::System.Diagnostics.Debug.Assert(instanceOfMetaModelLibrary != null, "Expecting an instance of MetaModelLibrary!");

            if (!String.IsNullOrEmpty(instanceOfMetaModelLibrary.FilePath) && !String.IsNullOrWhiteSpace(instanceOfMetaModelLibrary.FilePath))
            {
                instanceOfMetaModelLibrary.LoadLibrary(serializationContext);
            }
        }
    }
}
