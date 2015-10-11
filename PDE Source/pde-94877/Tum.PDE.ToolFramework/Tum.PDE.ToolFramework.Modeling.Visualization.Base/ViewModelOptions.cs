using System;
using System.Collections.Generic;
using Tum.PDE.ToolFramework.Modeling.Base;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base
{
    /// <summary>
    /// View model options helper class.
    /// </summary>
    public class ViewModelOptions
    {
        private bool isDeserialized = false;

        private List<MRUFileEntry> mRUFileEntries;

        private bool errorCategoryVisible = true;
        private bool warningCategoryVisible = true;
        private bool infoCategoryVisible = true;
        private bool filteredCategoryVisible = false;

        /// <summary>
        /// Gets whether the options have already been deserialized.
        /// </summary>
        public bool IsDeserialized
        {
            get { return this.isDeserialized; }
            private set
            {
                this.isDeserialized = value;
            }
        }

        /// <summary>
        /// Filename.
        /// </summary>
        public const string OptionsFileName = "Options.xml";

        /// <summary>
        /// Gets or sets whether the error category is toggled on the error list or not.
        /// </summary>
        public bool ErrorCategoryVisible
        {
            get
            {
                return this.errorCategoryVisible;
            }
            set
            {
                this.errorCategoryVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the warning category is toggled on the error list or not.
        /// </summary>
        public bool WarningCategoryVisible
        {
            get
            {
                return this.warningCategoryVisible;
            }
            set
            {
                this.warningCategoryVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the info category is toggled on the error list or not.
        /// </summary>
        public bool InfoCategoryVisible
        {
            get
            {
                return this.infoCategoryVisible;
            }
            set
            {
                this.infoCategoryVisible = value;
            }
        }

        /// <summary>
        /// Gets or sets whether the filtered category is toggled on the error list or not.
        /// </summary>
        public bool FilteredCategoryVisible
        {
            get
            {
                return this.filteredCategoryVisible;
            }
            set
            {
                this.filteredCategoryVisible = value;
            }
        }

        /// <summary>
        /// MRU items.
        /// </summary>
        public List<MRUFileEntry> MRUFileEntries
        {
            get
            {
                return mRUFileEntries;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ViewModelOptions()
        {
            this.mRUFileEntries = new List<MRUFileEntry>();
        }

        /// <summary>
        /// Load options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        public void Deserialize(string filePath)
        {
            this.DoDeserialize(filePath);
            this.OnOptionsDeserializedHelper();
        }

        /// <summary>
        /// Load options.
        /// </summary>
        /// <param name="filePath">File name to load options from.</param>
        private void DoDeserialize(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                global::System.IO.FileStream fileStream = null;
                try
                {
                    fileStream = global::System.IO.File.OpenRead(filePath);
                    if (fileStream.Length > 5)
                    {
                        using (global::System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(fileStream))
                        {
                            try
                            {
                                reader.MoveToContent();

                                // read attributes
                                string valueE = reader.GetAttribute("errorCategoryVisible");
                                if (valueE != null)
                                    this.ErrorCategoryVisible = Boolean.Parse(valueE);

                                string valueW = reader.GetAttribute("warningCategoryVisible");
                                if (valueW != null)
                                    this.WarningCategoryVisible = Boolean.Parse(valueW);

                                string valueI = reader.GetAttribute("infoCategoryVisible");
                                if (valueI != null)
                                    this.InfoCategoryVisible = Boolean.Parse(valueI);

                                string valueF = reader.GetAttribute("filteredCategoryVisible");
                                if (valueF != null)
                                    this.FilteredCategoryVisible = Boolean.Parse(valueF);

                                while (reader.Read())
                                {
                                    switch (reader.NodeType)
                                    {
                                        case System.Xml.XmlNodeType.Element:
                                            {
                                                DeserializeElement(reader, reader.Name);
                                                break;
                                            }
                                    }
                                }
                            }
                            finally
                            {
                                fileStream = null;
                            }
                        }
                    }
                }
                finally
                {
                    if (fileStream != null)
                        fileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserialize element.
        /// </summary>
        /// <param name="reader">Xml text reader.</param>
        /// <param name="elementName">Element name.</param>
        protected virtual void DeserializeElement(System.Xml.XmlTextReader reader, string elementName)
        {
            if (elementName == "MRUFileEntries")
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            {
                                if (reader.Name == "mruFileEntries")
                                {
                                    MRUFileEntry entry = DeserializeMRUFileEntry(reader);
                                    if( entry != null )
                                        this.mRUFileEntries.Add(entry);
                                }
                                break;
                            }

                        case System.Xml.XmlNodeType.EndElement:
                            if (reader.Name == "MRUFileEntries")
                            {
                                reader.Skip();
                                return;
                            }
                            break;
                    }
                }
            }
        }
        private MRUFileEntry DeserializeMRUFileEntry(System.Xml.XmlTextReader reader)
        {
            MRUFileEntry entry = new MRUFileEntry();

            while (reader.Read())
            {
                if( reader.NodeType == System.Xml.XmlNodeType.Element )
                {
                    if (reader.Name == "fileName")
                    {
                        entry.FileName = reader.ReadElementContentAsString();
                    }
                    else if (reader.Name == "shortName")
                    {
                        entry.ShortName = reader.ReadElementContentAsString();
                    }
                    else if (reader.Name == "modelContextName")
                    {
                        entry.ModelContextName = reader.ReadElementContentAsString();
                    }                  
                }
                else if (reader.NodeType == System.Xml.XmlNodeType.EndElement)
                {
                    if (reader.Name == "mruFileEntries")
                    {
                        reader.Skip();
                        break;
                    }
                }
            }

            return entry;

        }

        /// <summary>
        /// Save options.
        /// </summary>
        /// <param name="filePath">File name to save options to.</param>
        public void Serialize(string filePath)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            global::System.IO.MemoryStream newFileContent = null;
            try
            {
                newFileContent = new global::System.IO.MemoryStream();
                global::System.Xml.XmlTextWriter xmlWriter = new System.Xml.XmlTextWriter(newFileContent, encoding);
                xmlWriter.Formatting = System.Xml.Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("ViewModelOptions");

                // write attributes
                xmlWriter.WriteAttributeString("errorCategoryVisible", this.ErrorCategoryVisible.ToString());
                xmlWriter.WriteAttributeString("warningCategoryVisible", this.WarningCategoryVisible.ToString());
                xmlWriter.WriteAttributeString("infoCategoryVisible", this.InfoCategoryVisible.ToString());
                xmlWriter.WriteAttributeString("filteredCategoryVisible", this.FilteredCategoryVisible.ToString());

                SerializeElements(xmlWriter);
                xmlWriter.WriteEndElement();

                xmlWriter.Flush();
                if (newFileContent != null)
                {
                    // Only write the content if there's no error encountered during serialization.
                    global::System.IO.FileStream fileStream = null;
                    try
                    {
                        fileStream = new global::System.IO.FileStream(filePath, global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write, global::System.IO.FileShare.None);
                        using (global::System.IO.BinaryWriter writer = new global::System.IO.BinaryWriter(fileStream, encoding))
                        {
                            try
                            {
                                writer.Write(newFileContent.ToArray());
                            }
                            finally
                            {
                                fileStream = null;
                            }
                        }
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Dispose();
                    }
                }
            }
            finally
            {
                if (newFileContent != null)
                    newFileContent.Dispose();
            }
        }

        /// <summary>
        /// Serialize.
        /// </summary>
        /// <param name="writer">Xml text writer.</param>
        protected virtual void SerializeElements(System.Xml.XmlTextWriter writer)
        {
            // serializer MRU
            writer.WriteStartElement("MRUFileEntries");

            foreach (MRUFileEntry entry in this.MRUFileEntries)
            {
                writer.WriteStartElement("mruFileEntries");

                writer.WriteElementString("fileName", entry.FileName);
                writer.WriteElementString("shortName", entry.ShortName);
                writer.WriteElementString("modelContextName", entry.ModelContextName);
                                
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        /// <summary>
        /// Fires after options have been deserialized.
        /// </summary>
        public event EventHandler OptionsDeserialized;

        /// <summary>
        /// Called after options have been deserialized.
        /// </summary>
        /// <param name="e"></param>
        protected void OnOptionsDeserialized(EventArgs e)
        {
            if (OptionsDeserialized != null)
                OptionsDeserialized(this, e);
        }
        private void OnOptionsDeserializedHelper()
        {

            this.IsDeserialized = true;
            this.OnOptionsDeserialized(new EventArgs());
        }
    }
}
