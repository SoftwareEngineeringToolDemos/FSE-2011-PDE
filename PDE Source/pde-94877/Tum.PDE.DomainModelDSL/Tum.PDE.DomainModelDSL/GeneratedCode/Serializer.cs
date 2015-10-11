 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
	/// Serializer TestLanguageDomainModelSerializer for DomainClass DomainModel.
	/// </summary>
	public partial class TestLanguageDomainModelSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// TestLanguageDomainModelSerializer Constructor
		/// </summary>
		public TestLanguageDomainModelSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainModel.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainModel";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainModel instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainModel element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		public override void Read(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (element != null);
			if (element == null)
				throw new global::System.ArgumentNullException ("element");
			global::System.Diagnostics.Debug.Assert (reader != null);
			if (reader == null)
				throw new global::System.ArgumentNullException ("reader");
			#endregion
	
	  		// Read properties serialized as XML attributes.
			ReadPropertiesFromAttributes(serializationContext, element, reader);
			
			// Read nested XML elements.
			if (!serializationContext.Result.Failed)
			{
				if (!reader.IsEmptyElement)
				{
					// Read to the start of the first child element.
					DslModeling::SerializationUtilities.SkipToFirstChild(reader);
									
					// Read nested XML elements, they can be either properties serialized as XML elements, or child 
					// model elements.
					while (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
					{
						ReadElements(serializationContext, element, reader);
				
						if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
						{
							// Encountered one unknown XML element, skip it and keep reading.
							TestLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainModel");
							DslModeling::SerializationUtilities.Skip(reader);
						}
					}
				}
			}
		
			// Advance the reader to the next element (open tag of the next sibling, end tag of the parent, or EOF)
			DslModeling::SerializationUtilities.Skip(reader);
		
		}
		
		/// <summary>
		/// This method deserializes all properties that are serialized as XML attributes.
		/// </summary>
		/// <remarks>
		/// Because this method only handles properties serialized as XML attributes, the passed-in reader shouldn't be moved inside this method.
		/// The caller will guarantee that the reader is positioned on the open XML tag of the current element being deserialized.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.TestLanguage.DomainModel instanceOfDomainModel = element as global::Tum.TestLanguage.DomainModel;
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
		/// <param name="element">In-memory DomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.TestLanguage.DomainModel instance = element as global::Tum.TestLanguage.DomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainModel!");
	
			while (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				if(! ReadElement(serializationContext, instance, reader, reader.LocalName) )
					return;
			}
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory DomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDomainModelHasTest(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DomainModelHasTest that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasTest(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Test" )
			{
				info = global::Tum.TestLanguage.Test.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.TestLanguage.DomainModel.DomainClassId, global::Tum.TestLanguage.Test.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.TestLanguage.Test child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.TestLanguage.Test;
					if( child0 != null )
					{
						new global::Tum.TestLanguage.DomainModelHasTest(instance, child0);
						serializer0.Read(serializationContext, child0, reader);
					}
					else
						DslModeling::SerializationUtilities.Skip(reader);
				}
	
				return true;
			}
		
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DomainModel based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainModel, a new DomainModel instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainModel instance, or null if the reader is not pointing to a serialized DomainModel instance.</returns>
		public override DslModeling::ModelElement TryCreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (reader != null);
			if (reader == null)
				throw new global::System.ArgumentNullException ("reader");
			global::System.Diagnostics.Debug.Assert (partition != null);
			if (partition == null)
				throw new global::System.ArgumentNullException ("partition");
			#endregion
	
			DslModeling::ModelElement result = null;
			if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				string localName = reader.LocalName;
				if (string.Compare (localName, this.XmlTagName, global::System.StringComparison.CurrentCulture) == 0)
				{	// New "DomainModel" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainModel".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainModel(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.TestLanguage.DomainModel.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//TestLanguageDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as TestLanguageDomainModelSerializer;
						TestLanguageDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as TestLanguageDomainModelSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainModel based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainModel.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainModel instance should be created.</param>	
		/// <returns>Created DomainModel instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (TestLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = TestLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainModel)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//TestLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = TestLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.TestLanguage.DomainModel(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainModel instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="rootElementSettings">
		/// The root element settings if the passed in element is serialized as a root element in the XML. The root element contains additional
		/// information like schema target namespace, version, etc.
		/// This should only be passed for root-level elements. Null should be passed for rest elements (and ideally call the Write() method 
		/// without this parameter).
		/// </param>
		/// <param name="options">Serialization options.</param>
		public override void Write(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslModeling::RootElementSettings rootElementSettings, DslEditorModeling::SerializationOptions options)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (element != null);
			if (element == null)
				throw new global::System.ArgumentNullException ("element");
			global::System.Diagnostics.Debug.Assert (writer != null);
			if (writer == null)
				throw new global::System.ArgumentNullException ("writer");
			#endregion
	
			// Write start of element, including schema target namespace if specified.
			writer.WriteStartElement(this.XmlTagName);
			
			
			if(rootElementSettings != null )
				TestLanguageSerializationHelper.Instance.WriteSchemaDefinitions(writer, "DefaultContext", "DomainModel");
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertiesAsAttributes(serializationContext, element, writer, options);
			}
	
			if (!serializationContext.Result.Failed)
			{
				// Write 1) properties serialized as nested XML elements and 2) child model elements into XML.
				WriteElements(serializationContext, element, writer, options);
			}
			writer.WriteEndElement();
		}
	
		/// <summary>
		/// Write all properties that need to be serialized as XML attributes.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.TestLanguage.DomainModel instance = element as global::Tum.TestLanguage.DomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainModel");
			
			// Domain Element Id
			string valueId = TestLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(TestLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.TestLanguage.DomainModel instance = element as global::Tum.TestLanguage.DomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainModel");
			
			WriteEmbeddingRelationshipDomainModelHasTest(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DomainModelHasTest that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasTest(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasTest
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.TestLanguage.DomainModelHasTest> allMDomainModelHasTestInstances = global::Tum.TestLanguage.DomainModelHasTest.GetLinksToTest(instance);
			foreach(global::Tum.TestLanguage.DomainModelHasTest allMDomainModelHasTestInstance in allMDomainModelHasTestInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasTestInstance.Test;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		
		
		#endregion
	}
}
namespace Tum.TestLanguage
{
	/// <summary>
	/// Serializer TestLanguageTestSerializer for DomainClass Test.
	/// </summary>
	public partial class TestLanguageTestSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// TestLanguageTestSerializer Constructor
		/// </summary>
		public TestLanguageTestSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Test.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Test";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Test instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Test element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Test instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		public override void Read(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (element != null);
			if (element == null)
				throw new global::System.ArgumentNullException ("element");
			global::System.Diagnostics.Debug.Assert (reader != null);
			if (reader == null)
				throw new global::System.ArgumentNullException ("reader");
			#endregion
	
	  		// Read properties serialized as XML attributes.
			ReadPropertiesFromAttributes(serializationContext, element, reader);
			
			// Read nested XML elements.
			if (!serializationContext.Result.Failed)
			{
				if (!reader.IsEmptyElement)
				{
					// Read to the start of the first child element.
					DslModeling::SerializationUtilities.SkipToFirstChild(reader);
									
					// Read nested XML elements, they can be either properties serialized as XML elements, or child 
					// model elements.
					while (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
					{
						ReadElements(serializationContext, element, reader);
				
						if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
						{
							// Encountered one unknown XML element, skip it and keep reading.
							TestLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Test");
							DslModeling::SerializationUtilities.Skip(reader);
						}
					}
				}
			}
		
			// Advance the reader to the next element (open tag of the next sibling, end tag of the parent, or EOF)
			DslModeling::SerializationUtilities.Skip(reader);
		
		}
		
		/// <summary>
		/// This method deserializes all properties that are serialized as XML attributes.
		/// </summary>
		/// <remarks>
		/// Because this method only handles properties serialized as XML attributes, the passed-in reader shouldn't be moved inside this method.
		/// The caller will guarantee that the reader is positioned on the open XML tag of the current element being deserialized.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Test instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.TestLanguage.Test instanceOfTest = element as global::Tum.TestLanguage.Test;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfTest, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeNumber(serializationContext, instanceOfTest, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Test instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.Test instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = TestLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.TestLanguage.TestLanguageSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
			}
					
		}
		/// <summary>
		/// Read property Number that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Test instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeNumber(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.Test instance, global::System.Xml.XmlReader reader)
		{
			// Number
			if (!serializationContext.Result.Failed)
			{
				string attribValue = TestLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Number");
				if( attribValue != null )
					instance.Number = global::Tum.TestLanguage.TestLanguageSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Number", attribValue, typeof(global::System.Double?), true) as global::System.Double?;
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
		/// <param name="element">In-memory Test instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory Test instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.Test instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Test based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Test, a new Test instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Test instance, or null if the reader is not pointing to a serialized Test instance.</returns>
		public override DslModeling::ModelElement TryCreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (reader != null);
			if (reader == null)
				throw new global::System.ArgumentNullException ("reader");
			global::System.Diagnostics.Debug.Assert (partition != null);
			if (partition == null)
				throw new global::System.ArgumentNullException ("partition");
			#endregion
	
			DslModeling::ModelElement result = null;
			if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				string localName = reader.LocalName;
				if (string.Compare (localName, this.XmlTagName, global::System.StringComparison.CurrentCulture) == 0)
				{	// New "Test" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Test".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableTest(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.TestLanguage.Test.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//TestLanguageTestSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as TestLanguageTestSerializer;
						TestLanguageTestSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as TestLanguageTestSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Test based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Test.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Test instance should be created.</param>	
		/// <returns>Created Test instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (TestLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = TestLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Test)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//TestLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = TestLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.TestLanguage.Test(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				TestLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Test instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Test instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="rootElementSettings">
		/// The root element settings if the passed in element is serialized as a root element in the XML. The root element contains additional
		/// information like schema target namespace, version, etc.
		/// This should only be passed for root-level elements. Null should be passed for rest elements (and ideally call the Write() method 
		/// without this parameter).
		/// </param>
		/// <param name="options">Serialization options.</param>
		public override void Write(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslModeling::RootElementSettings rootElementSettings, DslEditorModeling::SerializationOptions options)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert (serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException ("serializationContext");
			global::System.Diagnostics.Debug.Assert (element != null);
			if (element == null)
				throw new global::System.ArgumentNullException ("element");
			global::System.Diagnostics.Debug.Assert (writer != null);
			if (writer == null)
				throw new global::System.ArgumentNullException ("writer");
			#endregion
	
			// Write start of element, including schema target namespace if specified.
			writer.WriteStartElement(this.XmlTagName);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertiesAsAttributes(serializationContext, element, writer, options);
			}
	
			if (!serializationContext.Result.Failed)
			{
				// Write 1) properties serialized as nested XML elements and 2) child model elements into XML.
				WriteElements(serializationContext, element, writer, options);
			}
			writer.WriteEndElement();
		}
	
		/// <summary>
		/// Write all properties that need to be serialized as XML attributes.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Test instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.TestLanguage.Test instance = element as global::Tum.TestLanguage.Test;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Test");
			
			// Domain Element Id
			string valueId = TestLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(TestLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeNumber(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Test instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.Test instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.TestLanguage.TestLanguageSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				TestLanguageSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		/// <summary>
		/// Write property Number that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Test instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeNumber(DslModeling::SerializationContext serializationContext, global::Tum.TestLanguage.Test instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Number
			object valueNumber = global::Tum.TestLanguage.TestLanguageSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Number" ,instance.Number, typeof(global::System.Double?), true);
			if( valueNumber != null )
			{
				TestLanguageSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Number", valueNumber.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Test instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.TestLanguage.Test instance = element as global::Tum.TestLanguage.Test;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Test");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.TestLanguage
{
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior TestLanguageSerializationBehavior.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class TestLanguageSerializationBehavior : TestLanguageSerializationBehaviorBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static TestLanguageSerializationBehavior instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static TestLanguageSerializationBehavior Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (TestLanguageSerializationBehavior.instance == null)
					TestLanguageSerializationBehavior.instance = new TestLanguageSerializationBehavior ();
				return TestLanguageSerializationBehavior.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private TestLanguageSerializationBehavior() : base() { }
		#endregion
	}
	
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior TestLanguageSerializationBehavior.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class TestLanguageSerializationBehaviorBase : DslModeling::DomainXmlSerializationBehavior
	{
		///<summary>
		/// The xml namespace used by this domain model when serializing
		///</summary>
		public const string DomainModelXmlNamespace = @"http://schemas.microsoft.com/dsltools/DomainModel";
		
		#region Member Variables
		/// <summary>
		/// A list of DomainClass Ids mapped to DomainClassXmlSerializer types.
		/// </summary>
		private static global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry> serializerTypes;
	
		/// <summary>
		/// A list of xml namespaces mapped to domain model types.
		/// </summary>
		private static global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry> namespaceEntries;
	
		#endregion
		
		#region Constructor
		/// <summary>
		/// Protected constructor to prevent public instantiation.
		/// </summary>
		protected TestLanguageSerializationBehaviorBase() : base() { }
		#endregion
		
		#region Protected Methods
		/// <summary>
		/// Allows custom serializers to be added.
		/// Base implementation doesn't do anything.
		/// </summary>
		/// <returns>Custom serializer types, null or empty list if there's no custom serializer types.</returns>
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
		protected virtual global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> CustomSerializerTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return null; }
		}
		#endregion
	
		#region Public Methods
		/// <summary>
		/// This provides a mapping from DomainClass Id to DomainXmlSerializer implementation types.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]		
		public override global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> AllSerializers
		{
			get
			{
				if (TestLanguageSerializationBehavior.serializerTypes == null)
				{
					global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> customSerializerTypes = this.CustomSerializerTypes;
					int customSerializerCount = (customSerializerTypes == null ? 0 : customSerializerTypes.Count);
					TestLanguageSerializationBehavior.serializerTypes = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry>(2 + customSerializerCount);

					#region Serializers defined in this model
					TestLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainModel.DomainClassId, typeof(TestLanguageDomainModelSerializer)));
					TestLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Test.DomainClassId, typeof(TestLanguageTestSerializer)));
					#endregion
				
					#region Serializers of the diagram model defined in this model
					TestLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagram.DomainClassId, typeof(TestLanguageDesignerDiagramSerializer)));					
					TestLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(TestShape.DomainClassId, typeof(TestLanguageTestShapeSerializer)));					
	
					#endregion
				
					// Custom ones
					if (customSerializerCount > 0)
					{
						TestLanguageSerializationBehavior.serializerTypes.AddRange(customSerializerTypes);
					}
				}
				return TestLanguageSerializationBehavior.serializerTypes.AsReadOnly();
			}
		}
		
		/// <summary>
		/// This provides a mapping from xml namespaces to domain model implementation types.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public override global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerNamespaceEntry> AllNamespaces
		{
			get
			{
				if (TestLanguageSerializationBehavior.namespaceEntries == null)
				{
					TestLanguageSerializationBehavior.namespaceEntries = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry>();
				}
				return TestLanguageSerializationBehavior.namespaceEntries.AsReadOnly();
			}
		}
		#endregion
		
		#region Public Virtual Properties
		/// <summary>
        /// Id-Serialization name.
        /// </summary>
		public virtual string IdSerializationNameDefaultContext
		{
			get{ return "Id"; }
		}
		#endregion
	}
}

namespace Tum.TestLanguage
{
    /// <summary>
    /// Utility class to provide serialization messages
    /// </summary>
    public static partial class TestLanguageSerializationBehaviorSerializationMessages
    {
    	/// <summary>
    	/// ResourceManager to get serialization messages from.
    	/// </summary>
    	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
    	public static global::System.Resources.ResourceManager ResourceManager
    	{
    		[global::System.Diagnostics.DebuggerStepThrough]
    		get { return TestLanguageDomainModel.SingletonResourceManager; }
    	}

    	#region Warnings
    	/// <summary>
    	/// Add a warning for ambiguous schemas.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="targetNamespace">Target namespace to be resolved.</param>
    	/// <param name="schemaPath">The schema that is used to resolve the definition of the target namespace.</param>
    	public static void AmbiguousSchema(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string targetNamespace, string schemaPath)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(targetNamespace));
    		if (string.IsNullOrEmpty(targetNamespace))
    			throw new global::System.ArgumentNullException("targetNamespace");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(schemaPath));
    		if (string.IsNullOrEmpty(schemaPath))
    			throw new global::System.ArgumentNullException("schemaPath");
    		#endregion

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("AmbiguousSchema"),
    				targetNamespace,
    				schemaPath
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning when a full-form relationship seems to be serialized in short-form.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="relationshipType">Type of the relationship.</param>
    	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "This is the type of the relationship, making it MemberInfo only adds confusion.")]
    	public static void ExpectingFullFormRelationship(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, global::System.Type relationshipType)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(relationshipType != null);
    		if (relationshipType == null)
    			throw new global::System.ArgumentNullException("relationshipType");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("ExpectingFullFormRelationship"),
    				reader.Name,
    				relationshipType.Name
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning when a short-form relationship seems to be serialized in full-form.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="relationshipType">Type of the relationship.</param>
    	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "This is the type of the relationship, making it MemberInfo only adds confusion.")]
    	public static void ExpectingShortFormRelationship(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, global::System.Type relationshipType)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(relationshipType != null);
    		if (relationshipType == null)
    			throw new global::System.ArgumentNullException("relationshipType");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("ExpectingShortFormRelationship"),
    				relationshipType.Name
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning for invalid property value with the given type, which will be ignored.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <param name="propertyType">Type of the property.</param>
    	/// <param name="value">Invalid value that causes this warning.</param>
    	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "This is the type of the property, making it MemberInfo only adds confusion.")]
    	public static void IgnoredPropertyValue(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string propertyName, global::System.Type propertyType, string value)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(propertyType != null);
    		if (propertyType == null)
    			throw new global::System.ArgumentNullException("propertyType");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(propertyName));
    		if (string.IsNullOrEmpty(propertyName))
    			throw new global::System.ArgumentNullException("propertyName");
    		#endregion
    		
    		if (value == null)
    			value = "<null>";

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("IgnoredPropertyValue"),
    				value,
    				propertyName,
    				propertyType.Name
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning for missing "Id" property.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="newId">Auto-generated new Id.</param>
    	public static void MissingId(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, global::System.Guid newId)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("MissingId"),
    				newId.ToString("D", global::System.Globalization.CultureInfo.CurrentCulture)
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    		
    	/// <summary>
    	/// Add an warning for moniker resolved to duplicate link. The moniker will be ignored.
    	/// </summary>
    	/// <param name="serializationResult">SerializationResult to add the error message to.</param>
    	/// <param name="moniker">Offending moniker.</param>
    	public static void MonikerResolvedToDuplicateLink(DslModeling::SerializationResult serializationResult, DslModeling::Moniker moniker)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationResult != null);
    		if (serializationResult == null)
    			throw new global::System.ArgumentNullException("serializationResult");
    		global::System.Diagnostics.Debug.Assert(moniker != null);
    		if (moniker == null)
    			throw new global::System.ArgumentNullException("moniker");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationResult,
    			moniker.Location,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("MonikerResolvedToDuplicateLink"),
    				moniker.MonikerName
    			),
    			moniker.Line,
    			moniker.Column
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning for no schema found for the given target namespace, schema validation will be skipped in this case.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="targetNamespace">Target namespace that cannot be resolved.</param>
    	public static void NoSchema(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string targetNamespace)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(targetNamespace));
    		if (string.IsNullOrEmpty(targetNamespace))
    			throw new global::System.ArgumentNullException("targetNamespace");
    		#endregion

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("NoSchema"),
    				targetNamespace
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add a warning for schema validation error.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="message">Validation message reported from schema validation.</param>
    	public static void SchemaValidationError(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string message)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(message));
    		if (string.IsNullOrEmpty(message))
    			throw new global::System.ArgumentNullException("message");
    		#endregion

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			message,
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add an warning for unexpected XML element.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the warning message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
		/// <param name="parentName"></param>
    	public static void UnexpectedXmlElement(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string parentName)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		#endregion
    			
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Warning,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("UnexpectedXmlElement"),
    				reader.Name
    			) + " Parent:" + parentName,
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	#endregion

    	#region Errors
    	/// <summary>
    	/// Add an error for ambiguous moniker.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="moniker">The ambiguous moniker string.</param>
    	/// <param name="element1">The first element using the given moniker.</param>
    	/// <param name="element2">The second element using the given moniker.</param>
    	public static void AmbiguousMoniker(DslModeling::SerializationContext serializationContext, string moniker, DslModeling::ModelElement element1, DslModeling::ModelElement element2)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(moniker != null);
    		if (moniker == null)
    			throw new global::System.ArgumentNullException("moniker");
    		global::System.Diagnostics.Debug.Assert(element1 != null);
    		if (element1 == null)
    			throw new global::System.ArgumentNullException("element1");
    		global::System.Diagnostics.Debug.Assert(element2 != null);
    		if (element2 == null)
    			throw new global::System.ArgumentNullException("element2");
    		#endregion

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("AmbiguousMoniker"),
    				moniker,
    				DslModeling::SerializationUtilities.GetElementName(element1),
    				DslModeling::SerializationUtilities.GetElementName(element2)
    			),
    			null	// No location info available
    		);
    	}
    	
    	/// <summary>
    	/// Add an error for not able to monikerize an instance of the given DomainClass.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="domainClassName">Name of the DomainClass whose instance cannot be monikerized.</param>
    	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "Generated code.")]	
    	public static void CannotMonikerizeElement(DslModeling::SerializationContext serializationContext, string domainClassName)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(domainClassName));
    		if (string.IsNullOrEmpty(domainClassName))
    			throw new global::System.ArgumentNullException("domainClassName");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext.Result,
    			null,	/* no location available for this error, because save failed. */
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("CannotMonikerizeElement"),
    				domainClassName
    			),
    			0,
    			0
    		);
    	}
    	
    	/// <summary>
    	/// Add an error for dangling relationship instance.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="relationshipType">Type name of the relationship.</param>
    	public static void DanglingRelationship(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string relationshipType)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(relationshipType));
    		if (string.IsNullOrEmpty(relationshipType))
    			throw new global::System.ArgumentNullException("relationshipType");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("DanglingRelationship"),
    				relationshipType
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add an error for invalid property value with given type.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="propertyName">Name of the property.</param>
    	/// <param name="propertyType">Type of the property.</param>
    	/// <param name="value">Invalid value that causes this error.</param>
    	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "This is the type of the property, making it MemberInfo only adds confusion.")]
    	public static void InvalidPropertyValue(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string propertyName, global::System.Type propertyType, string value)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(propertyType != null);
    		if (propertyType == null)
    			throw new global::System.ArgumentNullException("propertyType");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(propertyName));
    		if (string.IsNullOrEmpty(propertyName))
    			throw new global::System.ArgumentNullException("propertyName");
    		#endregion
    		
    		if (value == null)
    			value = "<null>";

    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("InvalidPropertyValue"),
    				value,
    				propertyName,
    				propertyType.Name
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add an error for missing moniker.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="monikerAttributeName">Name of the attribute that should hold the moniker.</param>
    	public static void MissingMoniker(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, string monikerAttributeName)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(monikerAttributeName));
    		if (string.IsNullOrEmpty(monikerAttributeName))
    			throw new global::System.ArgumentNullException("monikerAttributeName");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("MissingMoniker"),
    				monikerAttributeName
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
    	
    	/// <summary>
    	/// Add an error for unresolved moniker.
    	/// </summary>
    	/// <param name="serializationResult">SerializationResult to add the error message to.</param>
    	/// <param name="moniker">Unresolved moniker.</param>
    	public static void UnresolvedMoniker(DslModeling::SerializationResult serializationResult, DslModeling::Moniker moniker)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationResult != null);
    		if (serializationResult == null)
    			throw new global::System.ArgumentNullException("serializationResult");
    		global::System.Diagnostics.Debug.Assert(moniker != null);
    		if (moniker == null)
    			throw new global::System.ArgumentNullException("moniker");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationResult,
    			moniker.Location,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("UnresolvedMoniker"),
    				moniker.MonikerName
    			),
    			moniker.Line,
    			moniker.Column
    		);
    	}

    	/// <summary>
    	/// Add an error for Version mismatch.
    	/// </summary>
    	/// <param name="serializationContext">SerializationContext to add the error message to.</param>
    	/// <param name="reader">The reader pointing to where the message is raised.</param>
    	/// <param name="expectedVersion">The version that's expected.</param>
    	/// <param name="actualVersion">Actual version from the file.</param>
    	public static void VersionMismatch(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, global::System.Version expectedVersion, global::System.Version actualVersion)
    	{
    		#region Check Parameters
    		global::System.Diagnostics.Debug.Assert(serializationContext != null);
    		if (serializationContext == null)
    			throw new global::System.ArgumentNullException("serializationContext");
    		global::System.Diagnostics.Debug.Assert(reader != null);
    		if (reader == null)
    			throw new global::System.ArgumentNullException("reader");
    		global::System.Diagnostics.Debug.Assert(expectedVersion != null);
    		if (expectedVersion == null)
    			throw new global::System.ArgumentNullException("expectedVersion");
    		global::System.Diagnostics.Debug.Assert(actualVersion != null);
    		if (actualVersion == null)
    			throw new global::System.ArgumentNullException("actualVersion");
    		#endregion
    		
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationContext,
    			DslModeling::SerializationMessageKind.Error,
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("VersionMismatch"), 
    				actualVersion.ToString(4), 
    				expectedVersion.ToString(4)
    			),
    			reader as global::System.Xml.IXmlLineInfo
    		);
    	}
	    #endregion
		
		#region CustomErrors
		/// <summary>
    	/// Add an error for unresolved moniker.
    	/// </summary>
    	public static void UnresolvedMoniker(DslModeling::SerializationResult serializationResult, System.Guid id)
    	{
    		DslModeling::SerializationUtilities.AddMessage(
    			serializationResult,
				"",
    			DslModeling::SerializationMessageKind.Warning,	// warning just for now
    			string.Format(
    				global::System.Globalization.CultureInfo.CurrentCulture,
    				ResourceManager.GetString("UnresolvedMoniker"),
    				id.ToString()
    			),
				0,
				0
    		);
    	}
		#endregion
    }
}

namespace Tum.TestLanguage
{
	/// <summary>
	/// A ModelDataSerializationPostProcessor implementation.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class TestLanguageSerializationPostProcessor : DslEditorModeling::ModelDataSerializationPostProcessor
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static TestLanguageSerializationPostProcessor instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static TestLanguageSerializationPostProcessor Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (TestLanguageSerializationPostProcessor.instance == null)
					TestLanguageSerializationPostProcessor.instance = new TestLanguageSerializationPostProcessor ();
				return TestLanguageSerializationPostProcessor.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private TestLanguageSerializationPostProcessor() : base() { }
		#endregion
	
		#region Methods
		/// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already reseted models.</param>
        public override void Reset(System.Collections.Generic.List<string> alreadyProcessedModels)
        {
			dictionary.Clear();
			alreadyProcessedModels.Add("TestLanguage");

        }		
		
        /// <summary>
        /// Post process gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">List of already processed imported models.</param>
        /// <param name="serializationResult">Serialization result.</param>
        /// <param name="store">Store.</param>		
		public override void DoPostProcess(System.Collections.Generic.List<string> alreadyProcessedModels, DslModeling::SerializationResult serializationResult, DslModeling::Store store)
		{
			base.DoPostProcess(serializationResult, store);
			
			alreadyProcessedModels.Add("TestLanguage");
		}
		#endregion
	}
}
