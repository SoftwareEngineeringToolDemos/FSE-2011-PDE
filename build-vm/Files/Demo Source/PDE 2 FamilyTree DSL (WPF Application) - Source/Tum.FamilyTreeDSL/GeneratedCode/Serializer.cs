 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer FamilyTreeDSLFamilyTreeModelSerializer for DomainClass FamilyTreeModel.
	/// </summary>
	public partial class FamilyTreeDSLFamilyTreeModelSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// FamilyTreeDSLFamilyTreeModelSerializer Constructor
		/// </summary>
		public FamilyTreeDSLFamilyTreeModelSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of FamilyTreeModel.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "FamilyTreeModel";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one FamilyTreeModel instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the FamilyTreeModel element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory FamilyTreeModel instance that will get the deserialized data.</param>
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
							FamilyTreeDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "FamilyTreeModel");
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
		/// <param name="element">In-memory FamilyTreeModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.FamilyTreeModel instanceOfFamilyTreeModel = element as global::Tum.FamilyTreeDSL.FamilyTreeModel;
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
		/// <param name="element">In-memory FamilyTreeModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.FamilyTreeModel instance = element as global::Tum.FamilyTreeDSL.FamilyTreeModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreeModel!");
	
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
		/// <param name="instance">In-memory FamilyTreeModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreeModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipFamilyTreeModelHasFamilyTreePerson(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel FamilyTreeModelHasFamilyTreePerson that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreeModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipFamilyTreeModelHasFamilyTreePerson(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreeModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "FamilyTreePerson" )
			{
				info = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId, global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.FamilyTreeDSL.FamilyTreePerson child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.FamilyTreeDSL.FamilyTreePerson;
					if( child0 != null )
					{
						new global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson(instance, child0);
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
		/// This method creates a correct instance of FamilyTreeModel based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized FamilyTreeModel, a new FamilyTreeModel instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created FamilyTreeModel instance, or null if the reader is not pointing to a serialized FamilyTreeModel instance.</returns>
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
				{	// New "FamilyTreeModel" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "FamilyTreeModel".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableFamilyTreeModel(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//FamilyTreeDSLFamilyTreeModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as FamilyTreeDSLFamilyTreeModelSerializer;
						FamilyTreeDSLFamilyTreeModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as FamilyTreeDSLFamilyTreeModelSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of FamilyTreeModel based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of FamilyTreeModel.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new FamilyTreeModel instance should be created.</param>	
		/// <returns>Created FamilyTreeModel instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = FamilyTreeDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (FamilyTreeModel)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//FamilyTreeDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = FamilyTreeDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.FamilyTreeDSL.FamilyTreeModel(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one FamilyTreeModel instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">FamilyTreeModel instance to be serialized.</param>
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
				FamilyTreeDSLSerializationHelper.Instance.WriteSchemaDefinitions(writer, "DefaultContext", "FamilyTreeModel");
			
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
		/// <param name="element">FamilyTreeModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.FamilyTreeModel instance = element as global::Tum.FamilyTreeDSL.FamilyTreeModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreeModel");
			
			// Domain Element Id
			string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">FamilyTreeModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.FamilyTreeModel instance = element as global::Tum.FamilyTreeDSL.FamilyTreeModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreeModel");
			
			WriteEmbeddingRelationshipFamilyTreeModelHasFamilyTreePerson(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel FamilyTreeModelHasFamilyTreePerson that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreeModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipFamilyTreeModelHasFamilyTreePerson(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreeModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship FamilyTreeModelHasFamilyTreePerson
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> allMFamilyTreeModelHasFamilyTreePersonInstances = global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.GetLinksToFamilyTreePerson(instance);
			foreach(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson allMFamilyTreeModelHasFamilyTreePersonInstance in allMFamilyTreeModelHasFamilyTreePersonInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMFamilyTreeModelHasFamilyTreePersonInstance.FamilyTreePerson;
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
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer FamilyTreeDSLPersonSerializer for DomainClass Person.
	/// </summary>
	public partial class FamilyTreeDSLPersonSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// FamilyTreeDSLPersonSerializer Constructor
		/// </summary>
		public FamilyTreeDSLPersonSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// Cannot be serialized.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return string.Empty; }
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Person instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Person element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Person instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		public override void Read(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			throw new global::System.NotSupportedException();
		
		}
		
		/// <summary>
		/// This method deserializes all properties that are serialized as XML attributes.
		/// </summary>
		/// <remarks>
		/// Because this method only handles properties serialized as XML attributes, the passed-in reader shouldn't be moved inside this method.
		/// The caller will guarantee that the reader is positioned on the open XML tag of the current element being deserialized.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Person instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.Person instanceOfPerson = element as global::Tum.FamilyTreeDSL.Person;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeGender(serializationContext, instanceOfPerson, reader);
			}
		}
		
		/// <summary>
		/// Read property Gender that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeGender(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlReader reader)
		{
			// Gender
			if (!serializationContext.Result.Failed)
			{
				string attribValue = FamilyTreeDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Gender");
				if( attribValue != null )
					instance.Gender = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Gender", attribValue, typeof(global::Tum.FamilyTreeDSL.Gender?), true) as global::Tum.FamilyTreeDSL.Gender?;
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
		/// <param name="element">In-memory Person instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.Person instance = element as global::Tum.FamilyTreeDSL.Person;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Person!");
	
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
		/// <param name="instance">In-memory Person instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Hobbies" )
			{
				ReadPropertyAsElementHobbies(serializationContext, instance, reader);
				return true;
			}
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = FamilyTreeDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Hobbies that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementHobbies(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strHobbies = FamilyTreeDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfHobbies = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Hobbies", strHobbies, typeof(global::System.String), false) as global::System.String;
				instance.Hobbies = valueOfHobbies;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Person based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Person, a new Person instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Person instance, or null if the reader is not pointing to a serialized Person instance.</returns>
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
				// Check for derived classes of "Person".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTablePerson(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.FamilyTreeDSL.Person.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//FamilyTreeDSLPersonSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as FamilyTreeDSLPersonSerializer;
					FamilyTreeDSLPersonSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as FamilyTreeDSLPersonSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Person based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Person.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Person instance should be created.</param>	
		/// <returns>Created Person instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Person instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Person instance to be serialized.</param>
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
			throw new global::System.NotSupportedException();
		}
	
		/// <summary>
		/// Write all properties that need to be serialized as XML attributes.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Person instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.Person instance = element as global::Tum.FamilyTreeDSL.Person;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Person");
			
			// Domain Element Id
			string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeGender(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Gender that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeGender(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Gender
			object valueGender = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Gender" ,instance.Gender, typeof(global::Tum.FamilyTreeDSL.Gender?), true);
			if( valueGender != null )
				FamilyTreeDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Gender", valueGender.ToString());
			else
				FamilyTreeDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Gender", "");
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Person instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.Person instance = element as global::Tum.FamilyTreeDSL.Person;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Person");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementHobbies(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					FamilyTreeDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Hobbies that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Person instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementHobbies(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Person instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Hobbies
				object valueHobbies = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Hobbies", instance.Hobbies, typeof(global::System.String), false);
	
				if( valueHobbies != null )
				{
					FamilyTreeDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Hobbies", valueHobbies.ToString());
				}
				
			}		
		}
		
		
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer FamilyTreeDSLFamilyTreePersonSerializer for DomainClass FamilyTreePerson.
	/// </summary>
	public partial class FamilyTreeDSLFamilyTreePersonSerializer : Tum.FamilyTreeDSL.FamilyTreeDSLPersonSerializer
	{
		#region Constructor
		/// <summary>
		/// FamilyTreeDSLFamilyTreePersonSerializer Constructor
		/// </summary>
		public FamilyTreeDSLFamilyTreePersonSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of FamilyTreePerson.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "FamilyTreePerson";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one FamilyTreePerson instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the FamilyTreePerson element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory FamilyTreePerson instance that will get the deserialized data.</param>
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
							FamilyTreeDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "FamilyTreePerson");
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
		/// <param name="element">In-memory FamilyTreePerson instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.FamilyTreePerson instanceOfFamilyTreePerson = element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeGender(serializationContext, instanceOfFamilyTreePerson, reader);
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
		/// <param name="element">In-memory FamilyTreePerson instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.FamilyTreePerson instance = element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreePerson!");
	
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
		/// <param name="instance">In-memory FamilyTreePerson instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Hobbies" )
			{
				ReadPropertyAsElementHobbies(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipFamilyTreePersonHasPet(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipParentOf(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipMarriedTo(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel FamilyTreePersonHasPet that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipFamilyTreePersonHasPet(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Pet" )
			{
				info = global::Tum.FamilyTreeDSL.Pet.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId, global::Tum.FamilyTreeDSL.Pet.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.FamilyTreeDSL.Pet child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.FamilyTreeDSL.Pet;
					if( child0 != null )
					{
						new global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet(instance, child0);
						serializer0.Read(serializationContext, child0, reader);
					}
					else
						DslModeling::SerializationUtilities.Skip(reader);
				}
	
				return true;
			}
		
			return false;
		}
		/// <summary>
		/// Read ref. rel ParentOf that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipParentOf(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "ChildRef")
			{
				string attribValueChild0 = FamilyTreeDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueChild0 != null )
				{
					System.Guid id = FamilyTreeDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueChild0);
					if( id != System.Guid.Empty)
					{
						Tum.FamilyTreeDSL.FamilyTreeDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.FamilyTreeDSL.ParentOf.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		/// <summary>
		/// Read ref. rel MarriedTo that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipMarriedTo(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "WifeRef")
			{
				string attribValueWife0 = FamilyTreeDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueWife0 != null )
				{
					System.Guid id = FamilyTreeDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueWife0);
					if( id != System.Guid.Empty)
					{
						Tum.FamilyTreeDSL.FamilyTreeDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.FamilyTreeDSL.MarriedTo.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of FamilyTreePerson based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized FamilyTreePerson, a new FamilyTreePerson instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created FamilyTreePerson instance, or null if the reader is not pointing to a serialized FamilyTreePerson instance.</returns>
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
				{	// New "FamilyTreePerson" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "FamilyTreePerson".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableFamilyTreePerson(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//FamilyTreeDSLFamilyTreePersonSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as FamilyTreeDSLFamilyTreePersonSerializer;
						FamilyTreeDSLFamilyTreePersonSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as FamilyTreeDSLFamilyTreePersonSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of FamilyTreePerson based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of FamilyTreePerson.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new FamilyTreePerson instance should be created.</param>	
		/// <returns>Created FamilyTreePerson instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = FamilyTreeDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (FamilyTreePerson)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//FamilyTreeDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = FamilyTreeDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.FamilyTreeDSL.FamilyTreePerson(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one FamilyTreePerson instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">FamilyTreePerson instance to be serialized.</param>
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
		/// <param name="element">FamilyTreePerson instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.FamilyTreePerson instance = element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreePerson");
			
			// Domain Element Id
			string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeGender(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">FamilyTreePerson instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.FamilyTreePerson instance = element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of FamilyTreePerson");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementHobbies(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipFamilyTreePersonHasPet(serializationContext, instance, writer, options);
			WriteReferenceRelationshipParentOf(serializationContext, instance, writer, options);
			WriteReferenceRelationshipMarriedTo(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel FamilyTreePersonHasPet that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipFamilyTreePersonHasPet(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship FamilyTreePersonHasPet
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> allMFamilyTreePersonHasPetInstances = global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.GetLinksToPet(instance);
			foreach(global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet allMFamilyTreePersonHasPetInstance in allMFamilyTreePersonHasPetInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMFamilyTreePersonHasPetInstance.Pet;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel ParentOf that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipParentOf(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ParentOf
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.ParentOf> allMParentOfInstances = global::Tum.FamilyTreeDSL.ParentOf.GetLinksToChildren(instance);
			foreach(global::Tum.FamilyTreeDSL.ParentOf allMParentOfInstance in allMParentOfInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("ChildRef");
					string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMParentOfInstance ).Child.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		/// <summary>
		/// Write ref. rel MarriedTo that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">FamilyTreePerson instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipMarriedTo(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.FamilyTreePerson instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship MarriedTo
			global::Tum.FamilyTreeDSL.MarriedTo allMMarriedToInstance = global::Tum.FamilyTreeDSL.MarriedTo.GetLinkToWife(instance);
			if( allMMarriedToInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("WifeRef");
					string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMMarriedToInstance ).Wife.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer FamilyTreeDSLPetSerializer for DomainClass Pet.
	/// </summary>
	public partial class FamilyTreeDSLPetSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// FamilyTreeDSLPetSerializer Constructor
		/// </summary>
		public FamilyTreeDSLPetSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Pet.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Pet";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Pet instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Pet element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Pet instance that will get the deserialized data.</param>
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
							FamilyTreeDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Pet");
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
		/// <param name="element">In-memory Pet instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.FamilyTreeDSL.Pet instanceOfPet = element as global::Tum.FamilyTreeDSL.Pet;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfPet, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Pet instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Pet instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = FamilyTreeDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory Pet instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory Pet instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Pet instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Pet based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Pet, a new Pet instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Pet instance, or null if the reader is not pointing to a serialized Pet instance.</returns>
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
				{	// New "Pet" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Pet".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTablePet(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.FamilyTreeDSL.Pet.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//FamilyTreeDSLPetSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as FamilyTreeDSLPetSerializer;
						FamilyTreeDSLPetSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as FamilyTreeDSLPetSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Pet based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Pet.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Pet instance should be created.</param>	
		/// <returns>Created Pet instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = FamilyTreeDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Pet)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//FamilyTreeDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = FamilyTreeDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.FamilyTreeDSL.Pet(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				FamilyTreeDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Pet instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Pet instance to be serialized.</param>
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
		/// <param name="element">Pet instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.Pet instance = element as global::Tum.FamilyTreeDSL.Pet;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Pet");
			
			// Domain Element Id
			string valueId = FamilyTreeDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(FamilyTreeDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Pet instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.FamilyTreeDSL.Pet instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.FamilyTreeDSL.FamilyTreeDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				FamilyTreeDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Pet instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.FamilyTreeDSL.Pet instance = element as global::Tum.FamilyTreeDSL.Pet;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Pet");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior FamilyTreeDSLSerializationBehavior.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class FamilyTreeDSLSerializationBehavior : FamilyTreeDSLSerializationBehaviorBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static FamilyTreeDSLSerializationBehavior instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static FamilyTreeDSLSerializationBehavior Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (FamilyTreeDSLSerializationBehavior.instance == null)
					FamilyTreeDSLSerializationBehavior.instance = new FamilyTreeDSLSerializationBehavior ();
				return FamilyTreeDSLSerializationBehavior.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private FamilyTreeDSLSerializationBehavior() : base() { }
		#endregion
	}
	
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior FamilyTreeDSLSerializationBehavior.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class FamilyTreeDSLSerializationBehaviorBase : DslModeling::DomainXmlSerializationBehavior
	{
		///<summary>
		/// The xml namespace used by this domain model when serializing
		///</summary>
		public const string DomainModelXmlNamespace = @"http://schemas.microsoft.com/dsltools/FamilyTreeModel";
		
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
		protected FamilyTreeDSLSerializationBehaviorBase() : base() { }
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
				if (FamilyTreeDSLSerializationBehavior.serializerTypes == null)
				{
					global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> customSerializerTypes = this.CustomSerializerTypes;
					int customSerializerCount = (customSerializerTypes == null ? 0 : customSerializerTypes.Count);
					FamilyTreeDSLSerializationBehavior.serializerTypes = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry>(4 + customSerializerCount);

					#region Serializers defined in this model
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(FamilyTreeModel.DomainClassId, typeof(FamilyTreeDSLFamilyTreeModelSerializer)));
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Person.DomainClassId, typeof(FamilyTreeDSLPersonSerializer)));
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(FamilyTreePerson.DomainClassId, typeof(FamilyTreeDSLFamilyTreePersonSerializer)));
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Pet.DomainClassId, typeof(FamilyTreeDSLPetSerializer)));
					#endregion
				
					#region Serializers of the diagram model defined in this model
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagram.DomainClassId, typeof(FamilyTreeDSLDesignerDiagramSerializer)));					
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(PersonShape.DomainClassId, typeof(FamilyTreeDSLPersonShapeSerializer)));					
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ParentOfShape.DomainClassId, typeof(FamilyTreeDSLParentOfShapeSerializer)));					
					FamilyTreeDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(MarriedToShape.DomainClassId, typeof(FamilyTreeDSLMarriedToShapeSerializer)));					
	
					#endregion
				
					// Custom ones
					if (customSerializerCount > 0)
					{
						FamilyTreeDSLSerializationBehavior.serializerTypes.AddRange(customSerializerTypes);
					}
				}
				return FamilyTreeDSLSerializationBehavior.serializerTypes.AsReadOnly();
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
				if (FamilyTreeDSLSerializationBehavior.namespaceEntries == null)
				{
					FamilyTreeDSLSerializationBehavior.namespaceEntries = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry>();
				}
				return FamilyTreeDSLSerializationBehavior.namespaceEntries.AsReadOnly();
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

namespace Tum.FamilyTreeDSL
{
    /// <summary>
    /// Utility class to provide serialization messages
    /// </summary>
    public static partial class FamilyTreeDSLSerializationBehaviorSerializationMessages
    {
    	/// <summary>
    	/// ResourceManager to get serialization messages from.
    	/// </summary>
    	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
    	public static global::System.Resources.ResourceManager ResourceManager
    	{
    		[global::System.Diagnostics.DebuggerStepThrough]
    		get { return FamilyTreeDSLDomainModel.SingletonResourceManager; }
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

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// A ModelDataSerializationPostProcessor implementation.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class FamilyTreeDSLSerializationPostProcessor : DslEditorModeling::ModelDataSerializationPostProcessor
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static FamilyTreeDSLSerializationPostProcessor instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static FamilyTreeDSLSerializationPostProcessor Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (FamilyTreeDSLSerializationPostProcessor.instance == null)
					FamilyTreeDSLSerializationPostProcessor.instance = new FamilyTreeDSLSerializationPostProcessor ();
				return FamilyTreeDSLSerializationPostProcessor.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private FamilyTreeDSLSerializationPostProcessor() : base() { }
		#endregion
	
		#region Methods
		/// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already reseted models.</param>
        public override void Reset(System.Collections.Generic.List<string> alreadyProcessedModels)
        {
			dictionary.Clear();
			alreadyProcessedModels.Add("FamilyTreeDSL");

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
			
			alreadyProcessedModels.Add("FamilyTreeDSL");
		}
		#endregion
	}
}
