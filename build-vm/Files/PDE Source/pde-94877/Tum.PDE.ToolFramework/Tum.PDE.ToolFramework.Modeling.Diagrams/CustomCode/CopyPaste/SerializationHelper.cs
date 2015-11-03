using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class DiagramsDSLSerializationHelper
    {
        public LayoutInfo ConvertStringToLayoutInfo(string layoutInfo, Store store)
        {
            LayoutInfo lInfo = null;

            Microsoft.VisualStudio.Modeling.SerializationResult serializationResult = new Microsoft.VisualStudio.Modeling.SerializationResult();
            DomainXmlSerializerDirectory directory = this.GetDirectory(store);
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            Microsoft.VisualStudio.Modeling.SerializationContext serializationContext = new SerializationContext(directory, "", serializationResult);
            this.InitializeSerializationContext(store.DefaultPartition, serializationContext, false);

            DomainClassXmlSerializer rootSerializer = directory.GetSerializer(LayoutInfo.DomainClassId);
            using(System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(layoutInfo)) )
            {
                
                reader.Read(); // Move to the first node - will be the XmlDeclaration if there is one.
                serializationResult.Encoding = encoding;

                reader.MoveToContent();

                lInfo = rootSerializer.TryCreateInstance(serializationContext, reader, store.DefaultPartition) as LayoutInfo;
                rootSerializer.Read(serializationContext, lInfo, reader);
            }

            return lInfo;
        }

        public string ConvertLayoutInfoToString(LayoutInfo info)
        {
            string result = String.Empty;

            Microsoft.VisualStudio.Modeling.SerializationResult serializationResult = new Microsoft.VisualStudio.Modeling.SerializationResult();
            DomainXmlSerializerDirectory directory = this.GetDirectory(info.Store);
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            Microsoft.VisualStudio.Modeling.SerializationContext serializationContext = new SerializationContext(directory, "", serializationResult);
            this.InitializeSerializationContext(info.Partition, serializationContext, false);

            global::System.IO.MemoryStream newFileContent = new global::System.IO.MemoryStream();
            global::System.Xml.XmlWriterSettings settings = DiagramsDSLSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
            using (global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings))
            {
                DomainClassXmlSerializer rootSerializer = directory.GetSerializer(LayoutInfo.DomainClassId);
                
                RootElementSettings rootElementSettings = new RootElementSettings();
                rootElementSettings.SchemaTargetNamespace = "http://schemas.microsoft.com/dsltools/DiagramsDSL";
                rootElementSettings.Version = new global::System.Version("1.0.0.0");

                // Carry out the normal serialization.
                rootSerializer.Write(serializationContext, info, writer, rootElementSettings);
            }

            char[] chars = encoding.GetChars(newFileContent.GetBuffer());

            // search the open angle bracket and trim off the Byte Of Mark.
            result = new string(chars);
            int indexPos = result.IndexOf('<');
            if (indexPos > 0)
            {
                // strip off the leading Byte Of Mark.
                result = result.Substring(indexPos);
            }

            // trim off trailing 0s.
            result = result.TrimEnd('\0');

            return result;
        }
    }
}
