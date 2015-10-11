 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTVModellSerializer for DomainClass VModell.
	/// </summary>
	public partial class VModellXTVModellSerializer : Tum.VModellXT.Basis.VModellXTBasisBaseElementSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTVModellSerializer Constructor
		/// </summary>
		public VModellXTVModellSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of VModell.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "V-Modell";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one VModell instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the VModell element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory VModell instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "VModell");
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
		/// <param name="element">In-memory VModell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.VModell instanceOfVModell = element as global::Tum.VModellXT.VModell;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_Version(serializationContext, instanceOfVModell, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_ConsistentToVersion(serializationContext, instanceOfVModell, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_RefersToId(serializationContext, instanceOfVModell, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeMaster(serializationContext, instanceOfVModell, reader);
			}
		}
		
		/// <summary>
		/// Read property Master that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModell instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeMaster(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModell instance, global::System.Xml.XmlReader reader)
		{
			// Master
			if (!serializationContext.Result.Failed)
			{
				string attribValue = VModellXTSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "master");
				if( attribValue != null )
					instance.Master = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Master", attribValue, typeof(global::System.String), false) as global::System.String;
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
		/// <param name="element">In-memory VModell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.VModell instance = element as global::Tum.VModellXT.VModell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModell!");
	
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
		/// <param name="instance">In-memory VModell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModell instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipVModellHasVModellvariante(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel VModellHasVModellvariante that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModell instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellHasVModellvariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModell instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "V-Modellvariante" )
			{
				info = global::Tum.VModellXT.VModellvariante.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModell.DomainClassId, global::Tum.VModellXT.VModellvariante.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.VModellvariante child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.VModellvariante;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellHasVModellvariante(instance, child0);
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
		/// This method creates a correct instance of VModell based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized VModell, a new VModell instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created VModell instance, or null if the reader is not pointing to a serialized VModell instance.</returns>
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
				{	// New "VModell" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "VModell".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableVModell(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.VModell.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTVModellSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTVModellSerializer;
						VModellXTVModellSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTVModellSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of VModell based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of VModell.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new VModell instance should be created.</param>	
		/// <returns>Created VModell instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXT);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (VModell)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.VModell(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one VModell instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">VModell instance to be serialized.</param>
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
				VModellXTSerializationHelper.Instance.WriteSchemaDefinitions(writer, "VModellXT", "VModell");
			
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
		/// <param name="element">VModell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.VModell instance = element as global::Tum.VModellXT.VModell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModell");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXT, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_Version(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_ConsistentToVersion(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_RefersToId(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeMaster(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Master that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeMaster(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModell instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Master
			object valueMaster = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Master" ,instance.Master, typeof(global::System.String), false);
			if( valueMaster != null )
			{
				VModellXTSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "master", valueMaster.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">VModell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.VModell instance = element as global::Tum.VModellXT.VModell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModell");
			
			WriteEmbeddingRelationshipVModellHasVModellvariante(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel VModellHasVModellvariante that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellHasVModellvariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModell instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellHasVModellvariante
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellHasVModellvariante> allMVModellHasVModellvarianteInstances = global::Tum.VModellXT.VModellHasVModellvariante.GetLinksToVModellvariante(instance);
			foreach(global::Tum.VModellXT.VModellHasVModellvariante allMVModellHasVModellvarianteInstance in allMVModellHasVModellvarianteInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellHasVModellvarianteInstance.VModellvariante;
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
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTVModellvarianteSerializer for DomainClass VModellvariante.
	/// </summary>
	public partial class VModellXTVModellvarianteSerializer : Tum.VModellXT.Basis.VModellXTBasisBaseElementSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTVModellvarianteSerializer Constructor
		/// </summary>
		public VModellXTVModellvarianteSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of VModellvariante.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "V-Modellvariante";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one VModellvariante instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the VModellvariante element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory VModellvariante instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "VModellvariante");
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
		/// <param name="element">In-memory VModellvariante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.VModellvariante instanceOfVModellvariante = element as global::Tum.VModellXT.VModellvariante;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_Version(serializationContext, instanceOfVModellvariante, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_ConsistentToVersion(serializationContext, instanceOfVModellvariante, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIntern_RefersToId(serializationContext, instanceOfVModellvariante, reader);
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
		/// <param name="element">In-memory VModellvariante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.VModellvariante instance = element as global::Tum.VModellXT.VModellvariante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModellvariante!");
	
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
		/// <param name="instance">In-memory VModellvariante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Version" )
			{
				ReadPropertyAsElementVersion(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Version_intern" )
			{
				ReadPropertyAsElementVersionIntern(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Copyright_kurz" )
			{
				ReadPropertyAsElementCopyrightKurz(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Copyright_lang" )
			{
				ReadPropertyAsElementCopyrightLang(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipVModellvarianteHasVModellStruktur(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasTextbausteine(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasVorgehensbausteine(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasRollen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasPDSSpezifikationen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasAblaufbausteine(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasAblaufbausteinspezifikationen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasProjekttypen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasProjekttypvarianten(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasVortailoring(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasEntscheidungspunkte(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasProjektmerkmale(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasKonventionsabbildungen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasMethodenreferenzen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasWerkzeugreferenzen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasGlossar(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasAbkuerzungen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasQuellen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasAenderungsoperationen(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipVModellvarianteHasReferenzmodell(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Version that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementVersion(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strVersion = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfVersion = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Version", strVersion, typeof(global::System.String), true) as global::System.String;
				instance.Version = valueOfVersion;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property VersionIntern that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementVersionIntern(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strVersionIntern = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfVersionIntern = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "VersionIntern", strVersionIntern, typeof(global::System.String), true) as global::System.String;
				instance.VersionIntern = valueOfVersionIntern;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property CopyrightKurz that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementCopyrightKurz(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strCopyrightKurz = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfCopyrightKurz = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "CopyrightKurz", strCopyrightKurz, typeof(global::System.String), true) as global::System.String;
				instance.CopyrightKurz = valueOfCopyrightKurz;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property CopyrightLang that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementCopyrightLang(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strCopyrightLang = VModellXTSerializationHelper.Instance.ReadElementCDATAContentAsString(serializationContext, instance, reader);
							
				global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html valueOfCopyrightLang = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "CopyrightLang", strCopyrightLang, typeof(global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html), true) as global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html;
				instance.CopyrightLang = valueOfCopyrightLang;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Read emb. rel VModellvarianteHasVModellStruktur that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasVModellStruktur(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "V-Modell-Struktur" )
			{
				info = global::Tum.VModellXT.Basis.VModellStruktur.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.VModellStruktur.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.VModellStruktur child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.VModellStruktur;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasVModellStruktur(instance, child0);
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
		/// Read emb. rel VModellvarianteHasTextbausteine that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasTextbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Textbausteine" )
			{
				info = global::Tum.VModellXT.Basis.Textbausteine.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Textbausteine.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Textbausteine child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Textbausteine;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasTextbausteine(instance, child0);
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
		/// Read emb. rel VModellvarianteHasVorgehensbausteine that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasVorgehensbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Vorgehensbausteine" )
			{
				info = global::Tum.VModellXT.Statik.Vorgehensbausteine.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Statik.Vorgehensbausteine.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Statik.Vorgehensbausteine child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Statik.Vorgehensbausteine;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine(instance, child0);
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
		/// Read emb. rel VModellvarianteHasRollen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasRollen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Rollen" )
			{
				info = global::Tum.VModellXT.Statik.Rollen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Statik.Rollen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Statik.Rollen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Statik.Rollen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasRollen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasPDSSpezifikationen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasPDSSpezifikationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "PDS-Spezifikationen" )
			{
				info = global::Tum.VModellXT.Dynamik.PDSSpezifikationen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Dynamik.PDSSpezifikationen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Dynamik.PDSSpezifikationen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Dynamik.PDSSpezifikationen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasAblaufbausteine that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasAblaufbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Ablaufbausteine" )
			{
				info = global::Tum.VModellXT.Dynamik.Ablaufbausteine.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Dynamik.Ablaufbausteine.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Dynamik.Ablaufbausteine child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Dynamik.Ablaufbausteine;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasAblaufbausteine(instance, child0);
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
		/// Read emb. rel VModellvarianteHasAblaufbausteinspezifikationen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasAblaufbausteinspezifikationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Ablaufbausteinspezifikationen" )
			{
				info = global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasProjekttypen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasProjekttypen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Projekttypen" )
			{
				info = global::Tum.VModellXT.Anpassung.Projekttypen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Anpassung.Projekttypen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Anpassung.Projekttypen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Anpassung.Projekttypen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasProjekttypen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasProjekttypvarianten that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasProjekttypvarianten(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Projekttypvarianten" )
			{
				info = global::Tum.VModellXT.Anpassung.Projekttypvarianten.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Anpassung.Projekttypvarianten.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Anpassung.Projekttypvarianten child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Anpassung.Projekttypvarianten;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten(instance, child0);
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
		/// Read emb. rel VModellvarianteHasVortailoring that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasVortailoring(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Vortailoring" )
			{
				info = global::Tum.VModellXT.Anpassung.Vortailoring.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Anpassung.Vortailoring.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Anpassung.Vortailoring child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Anpassung.Vortailoring;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasVortailoring(instance, child0);
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
		/// Read emb. rel VModellvarianteHasEntscheidungspunkte that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasEntscheidungspunkte(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Entscheidungspunkte" )
			{
				info = global::Tum.VModellXT.Statik.Entscheidungspunkte.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Statik.Entscheidungspunkte.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Statik.Entscheidungspunkte child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Statik.Entscheidungspunkte;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte(instance, child0);
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
		/// Read emb. rel VModellvarianteHasProjektmerkmale that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasProjektmerkmale(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Projektmerkmale" )
			{
				info = global::Tum.VModellXT.Anpassung.Projektmerkmale.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Anpassung.Projektmerkmale.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Anpassung.Projektmerkmale child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Anpassung.Projektmerkmale;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasProjektmerkmale(instance, child0);
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
		/// Read emb. rel VModellvarianteHasKonventionsabbildungen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasKonventionsabbildungen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Konventionsabbildungen" )
			{
				info = global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasMethodenreferenzen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasMethodenreferenzen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Methodenreferenzen" )
			{
				info = global::Tum.VModellXT.Basis.Methodenreferenzen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Methodenreferenzen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Methodenreferenzen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Methodenreferenzen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasWerkzeugreferenzen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasWerkzeugreferenzen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Werkzeugreferenzen" )
			{
				info = global::Tum.VModellXT.Basis.Werkzeugreferenzen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Werkzeugreferenzen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Werkzeugreferenzen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Werkzeugreferenzen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasGlossar that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasGlossar(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Glossar" )
			{
				info = global::Tum.VModellXT.Basis.Glossar.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Glossar.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Glossar child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Glossar;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasGlossar(instance, child0);
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
		/// Read emb. rel VModellvarianteHasAbkuerzungen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasAbkuerzungen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Abkürzungen" )
			{
				info = global::Tum.VModellXT.Basis.Abkuerzungen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Abkuerzungen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Abkuerzungen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Abkuerzungen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasAbkuerzungen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasQuellen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasQuellen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Quellen" )
			{
				info = global::Tum.VModellXT.Basis.Quellen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Basis.Quellen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Basis.Quellen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Basis.Quellen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasQuellen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasAenderungsoperationen that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasAenderungsoperationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Änderungsoperationen" )
			{
				info = global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen(instance, child0);
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
		/// Read emb. rel VModellvarianteHasReferenzmodell that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVModellvarianteHasReferenzmodell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Referenzmodell" )
			{
				info = global::Tum.VModellXT.Referenzmodell.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, global::Tum.VModellXT.Referenzmodell.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Referenzmodell child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Referenzmodell;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VModellvarianteHasReferenzmodell(instance, child0);
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
		/// This method creates a correct instance of VModellvariante based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized VModellvariante, a new VModellvariante instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created VModellvariante instance, or null if the reader is not pointing to a serialized VModellvariante instance.</returns>
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
				{	// New "VModellvariante" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "VModellvariante".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableVModellvariante(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.VModellvariante.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTVModellvarianteSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTVModellvarianteSerializer;
						VModellXTVModellvarianteSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTVModellvarianteSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of VModellvariante based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of VModellvariante.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new VModellvariante instance should be created.</param>	
		/// <returns>Created VModellvariante instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXT);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (VModellvariante)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.VModellvariante(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one VModellvariante instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">VModellvariante instance to be serialized.</param>
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
		/// <param name="element">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.VModellvariante instance = element as global::Tum.VModellXT.VModellvariante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModellvariante");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXT, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_Version(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_ConsistentToVersion(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIntern_RefersToId(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.VModellvariante instance = element as global::Tum.VModellXT.VModellvariante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of VModellvariante");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementVersion(serializationContext, instance, writer, options);
			WritePropertyAsElementVersionIntern(serializationContext, instance, writer, options);
			WritePropertyAsElementCopyrightKurz(serializationContext, instance, writer, options);
			WritePropertyAsElementCopyrightLang(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasVModellStruktur(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasTextbausteine(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasVorgehensbausteine(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasRollen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasPDSSpezifikationen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasAblaufbausteine(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasAblaufbausteinspezifikationen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasProjekttypen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasProjekttypvarianten(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasVortailoring(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasEntscheidungspunkte(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasProjektmerkmale(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasKonventionsabbildungen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasMethodenreferenzen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasWerkzeugreferenzen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasGlossar(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasAbkuerzungen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasQuellen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasAenderungsoperationen(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipVModellvarianteHasReferenzmodell(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Version that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementVersion(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Version
				object valueVersion = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Version", instance.Version, typeof(global::System.String), true);
	
				if( valueVersion != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Version", valueVersion.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property VersionIntern that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementVersionIntern(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// VersionIntern
				object valueVersionIntern = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "VersionIntern", instance.VersionIntern, typeof(global::System.String), true);
	
				if( valueVersionIntern != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Version_intern", valueVersionIntern.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property CopyrightKurz that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementCopyrightKurz(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// CopyrightKurz
				object valueCopyrightKurz = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "CopyrightKurz", instance.CopyrightKurz, typeof(global::System.String), true);
	
				if( valueCopyrightKurz != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Copyright_kurz", valueCopyrightKurz.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property CopyrightLang that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementCopyrightLang(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// CopyrightLang
				object valueCopyrightLang = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "CopyrightLang", instance.CopyrightLang, typeof(global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html), true);
	
				if( valueCopyrightLang != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementCDATAString(serializationContext, instance, writer, "Copyright_lang", valueCopyrightLang.ToString());				
				}
				
			}		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasVModellStruktur that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasVModellStruktur(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasVModellStruktur
			global::Tum.VModellXT.VModellvarianteHasVModellStruktur allMVModellvarianteHasVModellStrukturInstance = global::Tum.VModellXT.VModellvarianteHasVModellStruktur.GetLinkToVModellStruktur(instance);
			if( allMVModellvarianteHasVModellStrukturInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasVModellStrukturInstance.VModellStruktur;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasTextbausteine that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasTextbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasTextbausteine
			global::Tum.VModellXT.VModellvarianteHasTextbausteine allMVModellvarianteHasTextbausteineInstance = global::Tum.VModellXT.VModellvarianteHasTextbausteine.GetLinkToTextbausteine(instance);
			if( allMVModellvarianteHasTextbausteineInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasTextbausteineInstance.Textbausteine;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasVorgehensbausteine that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasVorgehensbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasVorgehensbausteine
			global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine allMVModellvarianteHasVorgehensbausteineInstance = global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.GetLinkToVorgehensbausteine(instance);
			if( allMVModellvarianteHasVorgehensbausteineInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasVorgehensbausteineInstance.Vorgehensbausteine;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasRollen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasRollen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasRollen
			global::Tum.VModellXT.VModellvarianteHasRollen allMVModellvarianteHasRollenInstance = global::Tum.VModellXT.VModellvarianteHasRollen.GetLinkToRollen(instance);
			if( allMVModellvarianteHasRollenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasRollenInstance.Rollen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasPDSSpezifikationen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasPDSSpezifikationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasPDSSpezifikationen
			global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen allMVModellvarianteHasPDSSpezifikationenInstance = global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.GetLinkToPDSSpezifikationen(instance);
			if( allMVModellvarianteHasPDSSpezifikationenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasPDSSpezifikationenInstance.PDSSpezifikationen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasAblaufbausteine that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasAblaufbausteine(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasAblaufbausteine
			global::Tum.VModellXT.VModellvarianteHasAblaufbausteine allMVModellvarianteHasAblaufbausteineInstance = global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.GetLinkToAblaufbausteine(instance);
			if( allMVModellvarianteHasAblaufbausteineInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasAblaufbausteineInstance.Ablaufbausteine;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasAblaufbausteinspezifikationen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasAblaufbausteinspezifikationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasAblaufbausteinspezifikationen
			global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen allMVModellvarianteHasAblaufbausteinspezifikationenInstance = global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.GetLinkToAblaufbausteinspezifikationen(instance);
			if( allMVModellvarianteHasAblaufbausteinspezifikationenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasAblaufbausteinspezifikationenInstance.Ablaufbausteinspezifikationen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasProjekttypen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasProjekttypen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasProjekttypen
			global::Tum.VModellXT.VModellvarianteHasProjekttypen allMVModellvarianteHasProjekttypenInstance = global::Tum.VModellXT.VModellvarianteHasProjekttypen.GetLinkToProjekttypen(instance);
			if( allMVModellvarianteHasProjekttypenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasProjekttypenInstance.Projekttypen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasProjekttypvarianten that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasProjekttypvarianten(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasProjekttypvarianten
			global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten allMVModellvarianteHasProjekttypvariantenInstance = global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.GetLinkToProjekttypvarianten(instance);
			if( allMVModellvarianteHasProjekttypvariantenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasProjekttypvariantenInstance.Projekttypvarianten;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasVortailoring that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasVortailoring(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasVortailoring
			global::Tum.VModellXT.VModellvarianteHasVortailoring allMVModellvarianteHasVortailoringInstance = global::Tum.VModellXT.VModellvarianteHasVortailoring.GetLinkToVortailoring(instance);
			if( allMVModellvarianteHasVortailoringInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasVortailoringInstance.Vortailoring;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasEntscheidungspunkte that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasEntscheidungspunkte(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasEntscheidungspunkte
			global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte allMVModellvarianteHasEntscheidungspunkteInstance = global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.GetLinkToEntscheidungspunkte(instance);
			if( allMVModellvarianteHasEntscheidungspunkteInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasEntscheidungspunkteInstance.Entscheidungspunkte;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasProjektmerkmale that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasProjektmerkmale(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasProjektmerkmale
			global::Tum.VModellXT.VModellvarianteHasProjektmerkmale allMVModellvarianteHasProjektmerkmaleInstance = global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.GetLinkToProjektmerkmale(instance);
			if( allMVModellvarianteHasProjektmerkmaleInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasProjektmerkmaleInstance.Projektmerkmale;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasKonventionsabbildungen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasKonventionsabbildungen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasKonventionsabbildungen
			global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen allMVModellvarianteHasKonventionsabbildungenInstance = global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.GetLinkToKonventionsabbildungen(instance);
			if( allMVModellvarianteHasKonventionsabbildungenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasKonventionsabbildungenInstance.Konventionsabbildungen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasMethodenreferenzen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasMethodenreferenzen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasMethodenreferenzen
			global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen allMVModellvarianteHasMethodenreferenzenInstance = global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.GetLinkToMethodenreferenzen(instance);
			if( allMVModellvarianteHasMethodenreferenzenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasMethodenreferenzenInstance.Methodenreferenzen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasWerkzeugreferenzen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasWerkzeugreferenzen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasWerkzeugreferenzen
			global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen allMVModellvarianteHasWerkzeugreferenzenInstance = global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.GetLinkToWerkzeugreferenzen(instance);
			if( allMVModellvarianteHasWerkzeugreferenzenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasWerkzeugreferenzenInstance.Werkzeugreferenzen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasGlossar that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasGlossar(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasGlossar
			global::Tum.VModellXT.VModellvarianteHasGlossar allMVModellvarianteHasGlossarInstance = global::Tum.VModellXT.VModellvarianteHasGlossar.GetLinkToGlossar(instance);
			if( allMVModellvarianteHasGlossarInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasGlossarInstance.Glossar;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasAbkuerzungen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasAbkuerzungen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasAbkuerzungen
			global::Tum.VModellXT.VModellvarianteHasAbkuerzungen allMVModellvarianteHasAbkuerzungenInstance = global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.GetLinkToAbkuerzungen(instance);
			if( allMVModellvarianteHasAbkuerzungenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasAbkuerzungenInstance.Abkuerzungen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasQuellen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasQuellen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasQuellen
			global::Tum.VModellXT.VModellvarianteHasQuellen allMVModellvarianteHasQuellenInstance = global::Tum.VModellXT.VModellvarianteHasQuellen.GetLinkToQuellen(instance);
			if( allMVModellvarianteHasQuellenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasQuellenInstance.Quellen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasAenderungsoperationen that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasAenderungsoperationen(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasAenderungsoperationen
			global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen allMVModellvarianteHasAenderungsoperationenInstance = global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.GetLinkToAenderungsoperationen(instance);
			if( allMVModellvarianteHasAenderungsoperationenInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasAenderungsoperationenInstance.Aenderungsoperationen;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel VModellvarianteHasReferenzmodell that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">VModellvariante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVModellvarianteHasReferenzmodell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.VModellvariante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VModellvarianteHasReferenzmodell
			global::Tum.VModellXT.VModellvarianteHasReferenzmodell allMVModellvarianteHasReferenzmodellInstance = global::Tum.VModellXT.VModellvarianteHasReferenzmodell.GetLinkToReferenzmodell(instance);
			if( allMVModellvarianteHasReferenzmodellInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVModellvarianteHasReferenzmodellInstance.Referenzmodell;
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
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTReferenzmodellSerializer for DomainClass Referenzmodell.
	/// </summary>
	public partial class VModellXTReferenzmodellSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTReferenzmodellSerializer Constructor
		/// </summary>
		public VModellXTReferenzmodellSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Referenzmodell.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Referenzmodell";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Referenzmodell instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Referenzmodell element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Referenzmodell instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Referenzmodell");
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
		/// <param name="element">In-memory Referenzmodell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Referenzmodell instanceOfReferenzmodell = element as global::Tum.VModellXT.Referenzmodell;
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
		/// <param name="element">In-memory Referenzmodell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Referenzmodell instance = element as global::Tum.VModellXT.Referenzmodell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Referenzmodell!");
	
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
		/// <param name="instance">In-memory Referenzmodell instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Referenzmodell instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipReferenzmodellReferencesVModellvariante(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipReferenzmodellHasVModell(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel ReferenzmodellHasVModell that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Referenzmodell instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipReferenzmodellHasVModell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Referenzmodell instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if (reader.LocalName == "include")
	        {
	 			string attributeValue = reader.GetAttribute("href");
	            if (attributeValue != null)
	            {
					try 
					{
	            	    // get parent's path
	   	    			DslEditorModeling::IParentModelElement parent = instance.GetDomainModelServices().ElementParentProvider.GetParentModelElement(instance);
	            		if (parent == null)
	                		throw new System.ArgumentNullException("Parent of element " + instance.ToString() + " can not be null");
				
						string path = parent.DomainFilePath;
	            		string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
						
	            	    // get current's path
	            	    string curPath = attributeValue;
	            	    if( !curPath.Contains(System.IO.Path.VolumeSeparatorChar.ToString()))
	            	    {
	            	        curPath = vModellDirectory + System.IO.Path.DirectorySeparatorChar + curPath;
	            	    }
	
	            	    if (System.IO.File.Exists(curPath))
	            	    {
	            	        // load VModell file
							global::Tum.VModellXT.VModell target = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVModell(serializationContext.Result, instance.Store.DefaultPartition, curPath, null, null, null);
							new global::Tum.VModellXT.ReferenzmodellHasVModell(instance, target);
	            	    }
	            	    else
	            	    {
	            	        DslModeling::SerializationUtilities.AddMessage(serializationContext, DslModeling::SerializationMessageKind.Error,
	            	            "Could not include referenced Model: File not found", reader as global::System.Xml.IXmlLineInfo);
	            	    }
				
						DslModeling::SerializationUtilities.Skip(reader);
						return true;
					}
					catch {}
	            }
	
	            DslModeling::SerializationUtilities.Skip(reader);
			}
		
			return false;
		}
		/// <summary>
		/// Read ref. rel ReferenzmodellReferencesVModellvariante that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Referenzmodell instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipReferenzmodellReferencesVModellvariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Referenzmodell instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "V-ModellvarianteRef")
			{
				string attribValueVModellvariante0 = VModellXTSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueVModellvariante0 != null )
				{
					System.Guid id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueVModellvariante0);
					if( id != System.Guid.Empty)
					{
						Tum.VModellXT.VModellXTSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Referenzmodell based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Referenzmodell, a new Referenzmodell instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Referenzmodell instance, or null if the reader is not pointing to a serialized Referenzmodell instance.</returns>
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
				{	// New "Referenzmodell" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Referenzmodell".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableReferenzmodell(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Referenzmodell.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTReferenzmodellSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTReferenzmodellSerializer;
						VModellXTReferenzmodellSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTReferenzmodellSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Referenzmodell based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Referenzmodell.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Referenzmodell instance should be created.</param>	
		/// <returns>Created Referenzmodell instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXT);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Referenzmodell(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Referenzmodell instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Referenzmodell instance to be serialized.</param>
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
		/// <param name="element">Referenzmodell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Referenzmodell instance = element as global::Tum.VModellXT.Referenzmodell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Referenzmodell");
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Referenzmodell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Referenzmodell instance = element as global::Tum.VModellXT.Referenzmodell;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Referenzmodell");
			
			WriteReferenceRelationshipReferenzmodellReferencesVModellvariante(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipReferenzmodellHasVModell(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel ReferenzmodellHasVModell that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Referenzmodell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipReferenzmodellHasVModell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Referenzmodell instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.ReferenzmodellHasVModell allMReferenzmodellHasVModellInstance = global::Tum.VModellXT.ReferenzmodellHasVModell.GetLinkToVModell(instance);
	        if( allMReferenzmodellHasVModellInstance != null )
			{
				DslEditorModeling::IParentModelElement parent = instance.GetDomainModelServices().ElementParentProvider.GetParentModelElement(instance);
	            if (parent == null)
	                throw new System.ArgumentNullException("Parent of element " + instance.ToString() + " can not be null");
				
				string path = parent.DomainFilePath;
	            string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
	            
				// get current path
	            string curPath = (allMReferenzmodellHasVModellInstance.VModell as DslEditorModeling::IParentModelElement).DomainFilePath;
	
	            // update v-modell path
	            string relPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
	                vModellDirectory, curPath);
	
	            // remove all DirectorySeparatorChars on the left, so we dont get a path like ////name/name.xml
	            while(relPath.Length > 0 )
	            {
	                if (relPath[0] == System.IO.Path.DirectorySeparatorChar)
	                    relPath = relPath.Remove(0, 1);
	                else
	                    break;
	            }
				
				writer.WriteStartElement("xi", "include", null);
	            writer.WriteAttributeString("href", relPath);
	            writer.WriteEndElement();
	
	            if (options.SerializationMode == DslEditorModeling::SerializationMode.Normal)
	            {
	                // save
	                global::Tum.VModellXT.VModellXTSerializationHelper.Instance.SaveModelVModell(serializationContext.Result, allMReferenzmodellHasVModellInstance.VModell, curPath, writer.Settings.Encoding, false);
	            }			
			}
		}
		/// <summary>
		/// Write ref. rel ReferenzmodellReferencesVModellvariante that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Referenzmodell instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipReferenzmodellReferencesVModellvariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Referenzmodell instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ReferenzmodellReferencesVModellvariante
			global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante allMReferenzmodellReferencesVModellvarianteInstance = global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.GetLinkToVModellvarianteRef(instance);
			if( allMReferenzmodellReferencesVModellvarianteInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("V-ModellvarianteRef");
					string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMReferenzmodellReferencesVModellvarianteInstance ).VModellvariante.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTMusterbibliothekSerializer for DomainClass Musterbibliothek.
	/// </summary>
	public partial class VModellXTMusterbibliothekSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTMusterbibliothekSerializer Constructor
		/// </summary>
		public VModellXTMusterbibliothekSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Musterbibliothek.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Musterbibliothek";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Musterbibliothek instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Musterbibliothek element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Musterbibliothek instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Musterbibliothek");
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
		/// <param name="element">In-memory Musterbibliothek instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Musterbibliothek instanceOfMusterbibliothek = element as global::Tum.VModellXT.Musterbibliothek;
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
		/// <param name="element">In-memory Musterbibliothek instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Musterbibliothek instance = element as global::Tum.VModellXT.Musterbibliothek;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Musterbibliothek!");
	
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
		/// <param name="instance">In-memory Musterbibliothek instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Musterbibliothek instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipMusterbibliothekHasMustergruppe(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipMusterbibliothekHasVModell(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel MusterbibliothekHasMustergruppe that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Musterbibliothek instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipMusterbibliothekHasMustergruppe(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Musterbibliothek instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Mustergruppe" )
			{
				info = global::Tum.VModellXT.Mustergruppe.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Musterbibliothek.DomainClassId, global::Tum.VModellXT.Mustergruppe.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Mustergruppe child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Mustergruppe;
					if( child0 != null )
					{
						new global::Tum.VModellXT.MusterbibliothekHasMustergruppe(instance, child0);
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
		/// Read emb. rel MusterbibliothekHasVModell that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Musterbibliothek instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipMusterbibliothekHasVModell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Musterbibliothek instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if (reader.LocalName == "include")
	        {
	 			string attributeValue = reader.GetAttribute("href");
	            if (attributeValue != null)
	            {
					try 
					{
	            	    // get parent's path
	   	    			DslEditorModeling::IParentModelElement parent = instance.GetDomainModelServices().ElementParentProvider.GetParentModelElement(instance);
	            		if (parent == null)
	                		throw new System.ArgumentNullException("Parent of element " + instance.ToString() + " can not be null");
				
						string path = parent.DomainFilePath;
	            		string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
						
	            	    // get current's path
	            	    string curPath = attributeValue;
	            	    if( !curPath.Contains(System.IO.Path.VolumeSeparatorChar.ToString()))
	            	    {
	            	        curPath = vModellDirectory + System.IO.Path.DirectorySeparatorChar + curPath;
	            	    }
	
	            	    if (System.IO.File.Exists(curPath))
	            	    {
	            	        // load VModell file
							global::Tum.VModellXT.VModell target = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.LoadModelVModell(serializationContext.Result, instance.Store.DefaultPartition, curPath, null, null, null);
							new global::Tum.VModellXT.MusterbibliothekHasVModell(instance, target);
	            	    }
	            	    else
	            	    {
	            	        DslModeling::SerializationUtilities.AddMessage(serializationContext, DslModeling::SerializationMessageKind.Error,
	            	            "Could not include referenced Model: File not found", reader as global::System.Xml.IXmlLineInfo);
	            	    }
				
						DslModeling::SerializationUtilities.Skip(reader);
						return true;
					}
					catch {}
	            }
	
	            DslModeling::SerializationUtilities.Skip(reader);
			}
		
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Musterbibliothek based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Musterbibliothek, a new Musterbibliothek instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Musterbibliothek instance, or null if the reader is not pointing to a serialized Musterbibliothek instance.</returns>
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
				{	// New "Musterbibliothek" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Musterbibliothek".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableMusterbibliothek(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Musterbibliothek.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTMusterbibliothekSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTMusterbibliothekSerializer;
						VModellXTMusterbibliothekSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTMusterbibliothekSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Musterbibliothek based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Musterbibliothek.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Musterbibliothek instance should be created.</param>	
		/// <returns>Created Musterbibliothek instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Musterbibliothek(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Musterbibliothek instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Musterbibliothek instance to be serialized.</param>
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
				VModellXTSerializationHelper.Instance.WriteSchemaDefinitions(writer, "VModellXTMustertexte", "Musterbibliothek");
			
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
		/// <param name="element">Musterbibliothek instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Musterbibliothek instance = element as global::Tum.VModellXT.Musterbibliothek;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Musterbibliothek");
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Musterbibliothek instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Musterbibliothek instance = element as global::Tum.VModellXT.Musterbibliothek;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Musterbibliothek");
			
			WriteEmbeddingRelationshipMusterbibliothekHasMustergruppe(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipMusterbibliothekHasVModell(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel MusterbibliothekHasMustergruppe that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Musterbibliothek instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipMusterbibliothekHasMustergruppe(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Musterbibliothek instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship MusterbibliothekHasMustergruppe
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> allMMusterbibliothekHasMustergruppeInstances = global::Tum.VModellXT.MusterbibliothekHasMustergruppe.GetLinksToMustergruppe(instance);
			foreach(global::Tum.VModellXT.MusterbibliothekHasMustergruppe allMMusterbibliothekHasMustergruppeInstance in allMMusterbibliothekHasMustergruppeInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMMusterbibliothekHasMustergruppeInstance.Mustergruppe;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel MusterbibliothekHasVModell that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Musterbibliothek instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipMusterbibliothekHasVModell(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Musterbibliothek instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.MusterbibliothekHasVModell allMMusterbibliothekHasVModellInstance = global::Tum.VModellXT.MusterbibliothekHasVModell.GetLinkToVModell(instance);
	        if( allMMusterbibliothekHasVModellInstance != null )
			{
				DslEditorModeling::IParentModelElement parent = instance.GetDomainModelServices().ElementParentProvider.GetParentModelElement(instance);
	            if (parent == null)
	                throw new System.ArgumentNullException("Parent of element " + instance.ToString() + " can not be null");
				
				string path = parent.DomainFilePath;
	            string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
	            
				// get current path
	            string curPath = (allMMusterbibliothekHasVModellInstance.VModell as DslEditorModeling::IParentModelElement).DomainFilePath;
	
	            // update v-modell path
	            string relPath = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path.PathHelper.EvaluateRelativePath(
	                vModellDirectory, curPath);
	
	            // remove all DirectorySeparatorChars on the left, so we dont get a path like ////name/name.xml
	            while(relPath.Length > 0 )
	            {
	                if (relPath[0] == System.IO.Path.DirectorySeparatorChar)
	                    relPath = relPath.Remove(0, 1);
	                else
	                    break;
	            }
				
				writer.WriteStartElement("xi", "include", null);
	            writer.WriteAttributeString("href", relPath);
	            writer.WriteEndElement();
	
	            if (options.SerializationMode == DslEditorModeling::SerializationMode.Normal)
	            {
	                // save
	                global::Tum.VModellXT.VModellXTSerializationHelper.Instance.SaveModelVModell(serializationContext.Result, allMMusterbibliothekHasVModellInstance.VModell, curPath, writer.Settings.Encoding, false);
	            }			
			}
		}
		
		
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTMustergruppeSerializer for DomainClass Mustergruppe.
	/// </summary>
	public partial class VModellXTMustergruppeSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTMustergruppeSerializer Constructor
		/// </summary>
		public VModellXTMustergruppeSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Mustergruppe.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Mustergruppe";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Mustergruppe instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Mustergruppe element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Mustergruppe instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Mustergruppe");
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
		/// <param name="element">In-memory Mustergruppe instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Mustergruppe instanceOfMustergruppe = element as global::Tum.VModellXT.Mustergruppe;
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
		/// <param name="element">In-memory Mustergruppe instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Mustergruppe instance = element as global::Tum.VModellXT.Mustergruppe;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustergruppe!");
	
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
		/// <param name="instance">In-memory Mustergruppe instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustergruppe instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipMustergruppeHasThemenmuster(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustergruppe instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustergruppe instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Read emb. rel MustergruppeHasThemenmuster that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustergruppe instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipMustergruppeHasThemenmuster(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustergruppe instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Themenmuster" )
			{
				info = global::Tum.VModellXT.Themenmuster.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Mustergruppe.DomainClassId, global::Tum.VModellXT.Themenmuster.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Themenmuster child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Themenmuster;
					if( child0 != null )
					{
						new global::Tum.VModellXT.MustergruppeHasThemenmuster(instance, child0);
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
		/// This method creates a correct instance of Mustergruppe based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Mustergruppe, a new Mustergruppe instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Mustergruppe instance, or null if the reader is not pointing to a serialized Mustergruppe instance.</returns>
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
				{	// New "Mustergruppe" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Mustergruppe".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableMustergruppe(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Mustergruppe.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTMustergruppeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTMustergruppeSerializer;
						VModellXTMustergruppeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTMustergruppeSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Mustergruppe based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Mustergruppe.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Mustergruppe instance should be created.</param>	
		/// <returns>Created Mustergruppe instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Mustergruppe(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Mustergruppe instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Mustergruppe instance to be serialized.</param>
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
		/// <param name="element">Mustergruppe instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Mustergruppe instance = element as global::Tum.VModellXT.Mustergruppe;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustergruppe");
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Mustergruppe instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Mustergruppe instance = element as global::Tum.VModellXT.Mustergruppe;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustergruppe");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipMustergruppeHasThemenmuster(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustergruppe instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustergruppe instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write emb. rel MustergruppeHasThemenmuster that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustergruppe instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipMustergruppeHasThemenmuster(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustergruppe instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship MustergruppeHasThemenmuster
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MustergruppeHasThemenmuster> allMMustergruppeHasThemenmusterInstances = global::Tum.VModellXT.MustergruppeHasThemenmuster.GetLinksToThemenmuster(instance);
			foreach(global::Tum.VModellXT.MustergruppeHasThemenmuster allMMustergruppeHasThemenmusterInstance in allMMustergruppeHasThemenmusterInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMMustergruppeHasThemenmusterInstance.Themenmuster;
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
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTThemenmusterSerializer for DomainClass Themenmuster.
	/// </summary>
	public partial class VModellXTThemenmusterSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTThemenmusterSerializer Constructor
		/// </summary>
		public VModellXTThemenmusterSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Themenmuster.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Themenmuster";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Themenmuster instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Themenmuster element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Themenmuster instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Themenmuster");
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
		/// <param name="element">In-memory Themenmuster instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Themenmuster instanceOfThemenmuster = element as global::Tum.VModellXT.Themenmuster;
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
		/// <param name="element">In-memory Themenmuster instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Themenmuster instance = element as global::Tum.VModellXT.Themenmuster;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Themenmuster!");
	
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
		/// <param name="instance">In-memory Themenmuster instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( ReadReferenceRelationshipThemenmusterReferencesThema(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipThemenmusterReferencesUnterthema(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipThemenmusterHasMustertext(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipThemenmusterSourceHasThemenmusterTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipThemenmusterHasZusatzthema(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Read emb. rel ThemenmusterHasMustertext that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipThemenmusterHasMustertext(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Mustertext" )
			{
				info = global::Tum.VModellXT.Mustertext.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Themenmuster.DomainClassId, global::Tum.VModellXT.Mustertext.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Mustertext child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Mustertext;
					if( child0 != null )
					{
						new global::Tum.VModellXT.ThemenmusterHasMustertext(instance, child0);
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
		/// Read emb. rel ThemenmusterSourceHasThemenmusterTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipThemenmusterSourceHasThemenmusterTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Themenmuster" )
			{
				info = global::Tum.VModellXT.Themenmuster.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Themenmuster.DomainClassId, global::Tum.VModellXT.Themenmuster.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Themenmuster child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Themenmuster;
					if( child0 != null )
					{
						new global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget(instance, child0);
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
		/// Read emb. rel ThemenmusterHasZusatzthema that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipThemenmusterHasZusatzthema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Zusatzthema" )
			{
				info = global::Tum.VModellXT.Zusatzthema.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Themenmuster.DomainClassId, global::Tum.VModellXT.Zusatzthema.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Zusatzthema child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Zusatzthema;
					if( child0 != null )
					{
						new global::Tum.VModellXT.ThemenmusterHasZusatzthema(instance, child0);
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
		/// Read ref. rel ThemenmusterReferencesThema that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipThemenmusterReferencesThema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "VMThemaRef")
			{
				string attribValueThema0 = VModellXTSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueThema0 != null )
				{
					System.Guid id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueThema0);
					if( id != System.Guid.Empty)
					{
						Tum.VModellXT.VModellXTSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.VModellXT.ThemenmusterReferencesThema.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		/// <summary>
		/// Read ref. rel ThemenmusterReferencesUnterthema that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipThemenmusterReferencesUnterthema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "VMUnterthemaRef")
			{
				string attribValueUnterthema0 = VModellXTSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueUnterthema0 != null )
				{
					System.Guid id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueUnterthema0);
					if( id != System.Guid.Empty)
					{
						Tum.VModellXT.VModellXTSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.VModellXT.ThemenmusterReferencesUnterthema.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Themenmuster based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Themenmuster, a new Themenmuster instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Themenmuster instance, or null if the reader is not pointing to a serialized Themenmuster instance.</returns>
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
				{	// New "Themenmuster" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Themenmuster".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableThemenmuster(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Themenmuster.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTThemenmusterSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTThemenmusterSerializer;
						VModellXTThemenmusterSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTThemenmusterSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Themenmuster based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Themenmuster.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Themenmuster instance should be created.</param>	
		/// <returns>Created Themenmuster instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Themenmuster)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Themenmuster(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Themenmuster instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Themenmuster instance to be serialized.</param>
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
		/// <param name="element">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Themenmuster instance = element as global::Tum.VModellXT.Themenmuster;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Themenmuster");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Themenmuster instance = element as global::Tum.VModellXT.Themenmuster;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Themenmuster");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WriteReferenceRelationshipThemenmusterReferencesThema(serializationContext, instance, writer, options);
			WriteReferenceRelationshipThemenmusterReferencesUnterthema(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipThemenmusterHasMustertext(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipThemenmusterSourceHasThemenmusterTarget(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipThemenmusterHasZusatzthema(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write emb. rel ThemenmusterHasMustertext that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipThemenmusterHasMustertext(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship ThemenmusterHasMustertext
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasMustertext> allMThemenmusterHasMustertextInstances = global::Tum.VModellXT.ThemenmusterHasMustertext.GetLinksToMustertext(instance);
			foreach(global::Tum.VModellXT.ThemenmusterHasMustertext allMThemenmusterHasMustertextInstance in allMThemenmusterHasMustertextInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMThemenmusterHasMustertextInstance.Mustertext;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel ThemenmusterSourceHasThemenmusterTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipThemenmusterSourceHasThemenmusterTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship ThemenmusterSourceHasThemenmusterTarget
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> allMThemenmusterSourceHasThemenmusterTargetInstances = global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.GetLinksToThemenmusterTarget(instance);
			foreach(global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget allMThemenmusterSourceHasThemenmusterTargetInstance in allMThemenmusterSourceHasThemenmusterTargetInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMThemenmusterSourceHasThemenmusterTargetInstance.ThemenmusterTarget;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel ThemenmusterHasZusatzthema that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipThemenmusterHasZusatzthema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship ThemenmusterHasZusatzthema
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasZusatzthema> allMThemenmusterHasZusatzthemaInstances = global::Tum.VModellXT.ThemenmusterHasZusatzthema.GetLinksToZusatzthema(instance);
			foreach(global::Tum.VModellXT.ThemenmusterHasZusatzthema allMThemenmusterHasZusatzthemaInstance in allMThemenmusterHasZusatzthemaInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMThemenmusterHasZusatzthemaInstance.Zusatzthema;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel ThemenmusterReferencesThema that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipThemenmusterReferencesThema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ThemenmusterReferencesThema
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesThema> allMThemenmusterReferencesThemaInstances = global::Tum.VModellXT.ThemenmusterReferencesThema.GetLinksToThema(instance);
			foreach(global::Tum.VModellXT.ThemenmusterReferencesThema allMThemenmusterReferencesThemaInstance in allMThemenmusterReferencesThemaInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("VMThemaRef");
					string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMThemenmusterReferencesThemaInstance ).Thema.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		/// <summary>
		/// Write ref. rel ThemenmusterReferencesUnterthema that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Themenmuster instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipThemenmusterReferencesUnterthema(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Themenmuster instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ThemenmusterReferencesUnterthema
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> allMThemenmusterReferencesUnterthemaInstances = global::Tum.VModellXT.ThemenmusterReferencesUnterthema.GetLinksToUnterthema(instance);
			foreach(global::Tum.VModellXT.ThemenmusterReferencesUnterthema allMThemenmusterReferencesUnterthemaInstance in allMThemenmusterReferencesUnterthemaInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("VMUnterthemaRef");
					string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMThemenmusterReferencesUnterthemaInstance ).Unterthema.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTMustertextSerializer for DomainClass Mustertext.
	/// </summary>
	public partial class VModellXTMustertextSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTMustertextSerializer Constructor
		/// </summary>
		public VModellXTMustertextSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Mustertext.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Mustertext";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Mustertext instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Mustertext element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Mustertext instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Mustertext");
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
		/// <param name="element">In-memory Mustertext instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Mustertext instanceOfMustertext = element as global::Tum.VModellXT.Mustertext;
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
		/// <param name="element">In-memory Mustertext instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Mustertext instance = element as global::Tum.VModellXT.Mustertext;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustertext!");
	
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
		/// <param name="instance">In-memory Mustertext instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Standardauswahl" )
			{
				ReadPropertyAsElementStandardauswahl(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Text" )
			{
				ReadPropertyAsElementText(serializationContext, instance, reader);
				return true;
			}
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Standardauswahl that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementStandardauswahl(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strStandardauswahl = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::Tum.VModellXT.TypStandard? valueOfStandardauswahl = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Standardauswahl", strStandardauswahl, typeof(global::Tum.VModellXT.TypStandard?), true) as global::Tum.VModellXT.TypStandard?;
				instance.Standardauswahl = valueOfStandardauswahl;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Text that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementText(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strText = VModellXTSerializationHelper.Instance.ReadElementCDATAContentAsString(serializationContext, instance, reader);
							
				global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html valueOfText = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Text", strText, typeof(global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html), true) as global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html;
				instance.Text = valueOfText;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Mustertext based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Mustertext, a new Mustertext instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Mustertext instance, or null if the reader is not pointing to a serialized Mustertext instance.</returns>
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
				{	// New "Mustertext" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Mustertext".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableMustertext(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Mustertext.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTMustertextSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTMustertextSerializer;
						VModellXTMustertextSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTMustertextSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Mustertext based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Mustertext.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Mustertext instance should be created.</param>	
		/// <returns>Created Mustertext instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Mustertext)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Mustertext(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Mustertext instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Mustertext instance to be serialized.</param>
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
		/// <param name="element">Mustertext instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Mustertext instance = element as global::Tum.VModellXT.Mustertext;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustertext");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Mustertext instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Mustertext instance = element as global::Tum.VModellXT.Mustertext;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Mustertext");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementStandardauswahl(serializationContext, instance, writer, options);
			WritePropertyAsElementText(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Standardauswahl that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementStandardauswahl(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Standardauswahl
				object valueStandardauswahl = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Standardauswahl", instance.Standardauswahl, typeof(global::Tum.VModellXT.TypStandard?), true);
	
				if( valueStandardauswahl != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Standardauswahl", valueStandardauswahl.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Text that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Mustertext instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementText(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Mustertext instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Text
				object valueText = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Text", instance.Text, typeof(global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html), true);
	
				if( valueText != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementCDATAString(serializationContext, instance, writer, "Text", valueText.ToString());				
				}
				
			}		
		}
		
		
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTZusatzthemaSerializer for DomainClass Zusatzthema.
	/// </summary>
	public partial class VModellXTZusatzthemaSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTZusatzthemaSerializer Constructor
		/// </summary>
		public VModellXTZusatzthemaSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Zusatzthema.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Zusatzthema";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Zusatzthema instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Zusatzthema element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Zusatzthema instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Zusatzthema");
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
		/// <param name="element">In-memory Zusatzthema instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Zusatzthema instanceOfZusatzthema = element as global::Tum.VModellXT.Zusatzthema;
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
		/// <param name="element">In-memory Zusatzthema instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Zusatzthema instance = element as global::Tum.VModellXT.Zusatzthema;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Zusatzthema!");
	
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
		/// <param name="instance">In-memory Zusatzthema instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Standardauswahl" )
			{
				ReadPropertyAsElementStandardauswahl(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipZusatzthemaHasMustertext(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipZusatzthemaSourceHasZusatzthemaTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Standardauswahl that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementStandardauswahl(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strStandardauswahl = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::Tum.VModellXT.TypStandard? valueOfStandardauswahl = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Standardauswahl", strStandardauswahl, typeof(global::Tum.VModellXT.TypStandard?), true) as global::Tum.VModellXT.TypStandard?;
				instance.Standardauswahl = valueOfStandardauswahl;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Read emb. rel ZusatzthemaHasMustertext that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipZusatzthemaHasMustertext(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Mustertext" )
			{
				info = global::Tum.VModellXT.Mustertext.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Zusatzthema.DomainClassId, global::Tum.VModellXT.Mustertext.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Mustertext child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Mustertext;
					if( child0 != null )
					{
						new global::Tum.VModellXT.ZusatzthemaHasMustertext(instance, child0);
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
		/// Read emb. rel ZusatzthemaSourceHasZusatzthemaTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipZusatzthemaSourceHasZusatzthemaTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Zusatzthema" )
			{
				info = global::Tum.VModellXT.Zusatzthema.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Zusatzthema.DomainClassId, global::Tum.VModellXT.Zusatzthema.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Zusatzthema child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Zusatzthema;
					if( child0 != null )
					{
						new global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget(instance, child0);
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
		/// This method creates a correct instance of Zusatzthema based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Zusatzthema, a new Zusatzthema instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Zusatzthema instance, or null if the reader is not pointing to a serialized Zusatzthema instance.</returns>
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
				{	// New "Zusatzthema" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Zusatzthema".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableZusatzthema(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Zusatzthema.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTZusatzthemaSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTZusatzthemaSerializer;
						VModellXTZusatzthemaSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTZusatzthemaSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Zusatzthema based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Zusatzthema.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Zusatzthema instance should be created.</param>	
		/// <returns>Created Zusatzthema instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Zusatzthema)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Zusatzthema(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Zusatzthema instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Zusatzthema instance to be serialized.</param>
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
		/// <param name="element">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Zusatzthema instance = element as global::Tum.VModellXT.Zusatzthema;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Zusatzthema");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVModellXTMustertexte, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Zusatzthema instance = element as global::Tum.VModellXT.Zusatzthema;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Zusatzthema");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementStandardauswahl(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipZusatzthemaHasMustertext(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipZusatzthemaSourceHasZusatzthemaTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Standardauswahl that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementStandardauswahl(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Standardauswahl
				object valueStandardauswahl = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Standardauswahl", instance.Standardauswahl, typeof(global::Tum.VModellXT.TypStandard?), true);
	
				if( valueStandardauswahl != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Standardauswahl", valueStandardauswahl.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write emb. rel ZusatzthemaHasMustertext that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipZusatzthemaHasMustertext(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship ZusatzthemaHasMustertext
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaHasMustertext> allMZusatzthemaHasMustertextInstances = global::Tum.VModellXT.ZusatzthemaHasMustertext.GetLinksToMustertext(instance);
			foreach(global::Tum.VModellXT.ZusatzthemaHasMustertext allMZusatzthemaHasMustertextInstance in allMZusatzthemaHasMustertextInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMZusatzthemaHasMustertextInstance.Mustertext;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel ZusatzthemaSourceHasZusatzthemaTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Zusatzthema instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipZusatzthemaSourceHasZusatzthemaTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Zusatzthema instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship ZusatzthemaSourceHasZusatzthemaTarget
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> allMZusatzthemaSourceHasZusatzthemaTargetInstances = global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.GetLinksToZusatzthemaTarget(instance);
			foreach(global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget allMZusatzthemaSourceHasZusatzthemaTargetInstance in allMZusatzthemaSourceHasZusatzthemaTargetInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMZusatzthemaSourceHasZusatzthemaTargetInstance.ZusatzthemaTarget;
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
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTVariantenSerializer for DomainClass Varianten.
	/// </summary>
	public partial class VModellXTVariantenSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTVariantenSerializer Constructor
		/// </summary>
		public VModellXTVariantenSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Varianten.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Varianten";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Varianten instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Varianten element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Varianten instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Varianten");
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
		/// <param name="element">In-memory Varianten instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Varianten instanceOfVarianten = element as global::Tum.VModellXT.Varianten;
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
		/// <param name="element">In-memory Varianten instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Varianten instance = element as global::Tum.VModellXT.Varianten;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Varianten!");
	
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
		/// <param name="instance">In-memory Varianten instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Varianten instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipVariantenHasVariante(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel VariantenHasVariante that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Varianten instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipVariantenHasVariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Varianten instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "Variante" )
			{
				info = global::Tum.VModellXT.Variante.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.VModellXT.Varianten.DomainClassId, global::Tum.VModellXT.Variante.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.VModellXT.Variante child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.VModellXT.Variante;
					if( child0 != null )
					{
						new global::Tum.VModellXT.VariantenHasVariante(instance, child0);
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
		/// This method creates a correct instance of Varianten based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Varianten, a new Varianten instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Varianten instance, or null if the reader is not pointing to a serialized Varianten instance.</returns>
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
				{	// New "Varianten" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Varianten".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableVarianten(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Varianten.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTVariantenSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTVariantenSerializer;
						VModellXTVariantenSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTVariantenSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Varianten based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Varianten.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Varianten instance should be created.</param>	
		/// <returns>Created Varianten instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVariantenkonfig);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Varianten(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Varianten instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Varianten instance to be serialized.</param>
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
				VModellXTSerializationHelper.Instance.WriteSchemaDefinitions(writer, "Variantenkonfig", "Varianten");
			
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
		/// <param name="element">Varianten instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Varianten instance = element as global::Tum.VModellXT.Varianten;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Varianten");
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Varianten instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Varianten instance = element as global::Tum.VModellXT.Varianten;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Varianten");
			
			WriteEmbeddingRelationshipVariantenHasVariante(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel VariantenHasVariante that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Varianten instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipVariantenHasVariante(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Varianten instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship VariantenHasVariante
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VariantenHasVariante> allMVariantenHasVarianteInstances = global::Tum.VModellXT.VariantenHasVariante.GetLinksToVariante(instance);
			foreach(global::Tum.VModellXT.VariantenHasVariante allMVariantenHasVarianteInstance in allMVariantenHasVarianteInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMVariantenHasVarianteInstance.Variante;
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
namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer VModellXTVarianteSerializer for DomainClass Variante.
	/// </summary>
	public partial class VModellXTVarianteSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// VModellXTVarianteSerializer Constructor
		/// </summary>
		public VModellXTVarianteSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Variante.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Variante";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Variante instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Variante element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Variante instance that will get the deserialized data.</param>
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
							VModellXTSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Variante");
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
		/// <param name="element">In-memory Variante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Variante instanceOfVariante = element as global::Tum.VModellXT.Variante;
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
		/// <param name="element">In-memory Variante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.VModellXT.Variante instance = element as global::Tum.VModellXT.Variante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Variante!");
	
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
		/// <param name="instance">In-memory Variante instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Verzeichnis" )
			{
				ReadPropertyAsElementVerzeichnis(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Dateiname" )
			{
				ReadPropertyAsElementDateiname(serializationContext, instance, reader);
				return true;
			}
			if( ReadReferenceRelationshipVarianteSourceReferencesVarianteTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Verzeichnis that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementVerzeichnis(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strVerzeichnis = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfVerzeichnis = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Verzeichnis", strVerzeichnis, typeof(global::System.String), true) as global::System.String;
				instance.Verzeichnis = valueOfVerzeichnis;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Dateiname that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementDateiname(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strDateiname = VModellXTSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfDateiname = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Dateiname", strDateiname, typeof(global::System.String), true) as global::System.String;
				instance.Dateiname = valueOfDateiname;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Read ref. rel VarianteSourceReferencesVarianteTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipVarianteSourceReferencesVarianteTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "ReferenzvarianteRef")
			{
				string attribValueVarianteTarget0 = VModellXTSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueVarianteTarget0 != null )
				{
					System.Guid id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueVarianteTarget0);
					if( id != System.Guid.Empty)
					{
						Tum.VModellXT.VModellXTSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of Variante based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Variante, a new Variante instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Variante instance, or null if the reader is not pointing to a serialized Variante instance.</returns>
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
				{	// New "Variante" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Variante".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableVariante(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.VModellXT.Variante.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//VModellXTVarianteSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as VModellXTVarianteSerializer;
						VModellXTVarianteSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as VModellXTVarianteSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Variante based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Variante.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Variante instance should be created.</param>	
		/// <returns>Created Variante instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (VModellXTSerializationBehavior.Instance.IdSerializationNameVariantenkonfig);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = VModellXTDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Variante)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = VModellXTSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.VModellXT.Variante(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				VModellXTSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Variante instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Variante instance to be serialized.</param>
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
		/// <param name="element">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Variante instance = element as global::Tum.VModellXT.Variante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Variante");
			
			// Domain Element Id
			string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(VModellXTSerializationBehavior.Instance.IdSerializationNameVariantenkonfig, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.VModellXT.Variante instance = element as global::Tum.VModellXT.Variante;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Variante");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementVerzeichnis(serializationContext, instance, writer, options);
			WritePropertyAsElementDateiname(serializationContext, instance, writer, options);
			WriteReferenceRelationshipVarianteSourceReferencesVarianteTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Verzeichnis that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementVerzeichnis(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Verzeichnis
				object valueVerzeichnis = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Verzeichnis", instance.Verzeichnis, typeof(global::System.String), true);
	
				if( valueVerzeichnis != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Verzeichnis", valueVerzeichnis.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Dateiname that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementDateiname(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Dateiname
				object valueDateiname = global::Tum.VModellXT.VModellXTSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Dateiname", instance.Dateiname, typeof(global::System.String), true);
	
				if( valueDateiname != null )
				{
					VModellXTSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Dateiname", valueDateiname.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write ref. rel VarianteSourceReferencesVarianteTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Variante instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipVarianteSourceReferencesVarianteTarget(DslModeling::SerializationContext serializationContext, global::Tum.VModellXT.Variante instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship VarianteSourceReferencesVarianteTarget
			global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget allMVarianteSourceReferencesVarianteTargetInstance = global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.GetLinkToReferenzvariante(instance);
			if( allMVarianteSourceReferencesVarianteTargetInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("ReferenzvarianteRef");
					string valueId = VModellXTSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMVarianteSourceReferencesVarianteTargetInstance ).VarianteTarget.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior VModellXTSerializationBehavior.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class VModellXTSerializationBehavior : VModellXTSerializationBehaviorBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static VModellXTSerializationBehavior instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static VModellXTSerializationBehavior Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (VModellXTSerializationBehavior.instance == null)
					VModellXTSerializationBehavior.instance = new VModellXTSerializationBehavior ();
				return VModellXTSerializationBehavior.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private VModellXTSerializationBehavior() : base() { }
		#endregion
	}
	
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior VModellXTSerializationBehavior.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class VModellXTSerializationBehaviorBase : DslModeling::DomainXmlSerializationBehavior
	{
		///<summary>
		/// The xml namespace used by this domain model when serializing
		///</summary>
		public const string DomainModelXmlNamespace = @"http://schemas.microsoft.com/dsltools/VModell";
		
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
		protected VModellXTSerializationBehaviorBase() : base() { }
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
				if (VModellXTSerializationBehavior.serializerTypes == null)
				{
					global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> customSerializerTypes = this.CustomSerializerTypes;
					int customSerializerCount = (customSerializerTypes == null ? 0 : customSerializerTypes.Count);
					VModellXTSerializationBehavior.serializerTypes = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry>(10 + customSerializerCount);

					#region Serializers defined in this model
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(VModell.DomainClassId, typeof(VModellXTVModellSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(VModellvariante.DomainClassId, typeof(VModellXTVModellvarianteSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Referenzmodell.DomainClassId, typeof(VModellXTReferenzmodellSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Musterbibliothek.DomainClassId, typeof(VModellXTMusterbibliothekSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Mustergruppe.DomainClassId, typeof(VModellXTMustergruppeSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Themenmuster.DomainClassId, typeof(VModellXTThemenmusterSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Mustertext.DomainClassId, typeof(VModellXTMustertextSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Zusatzthema.DomainClassId, typeof(VModellXTZusatzthemaSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Varianten.DomainClassId, typeof(VModellXTVariantenSerializer)));
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Variante.DomainClassId, typeof(VModellXTVarianteSerializer)));
					#endregion
				
					#region Serializers of the diagram model defined in this model
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagram.DomainClassId, typeof(VModellXTDesignerDiagramSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(GeneralGrDependencyTemplate.DomainClassId, typeof(VModellXTGeneralGrDependencyTemplateSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(RolleDependencyTemplate.DomainClassId, typeof(VModellXTRolleDependencyTemplateSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(RolleDependencyShape.DomainClassId, typeof(VModellXTRolleDependencyShapeSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DisziplinGrDependencyTemplate.DomainClassId, typeof(VModellXTDisziplinGrDependencyTemplateSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DisziplinDependencyShape.DomainClassId, typeof(VModellXTDisziplinDependencyShapeSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ErzAbhGrDependencyTemplate.DomainClassId, typeof(VModellXTErzAbhGrDependencyTemplateSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ErzAbhDependencyShape.DomainClassId, typeof(VModellXTErzAbhDependencyShapeSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagramMustertexte.DomainClassId, typeof(VModellXTDesignerDiagramMustertexteSerializer)));					
					VModellXTSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagramVariantenkonfig.DomainClassId, typeof(VModellXTDesignerDiagramVariantenkonfigSerializer)));					
	
					#endregion
				
					// Custom ones
					if (customSerializerCount > 0)
					{
						VModellXTSerializationBehavior.serializerTypes.AddRange(customSerializerTypes);
					}
				}
				return VModellXTSerializationBehavior.serializerTypes.AsReadOnly();
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
				if (VModellXTSerializationBehavior.namespaceEntries == null)
				{
					VModellXTSerializationBehavior.namespaceEntries = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry>();
				}
				return VModellXTSerializationBehavior.namespaceEntries.AsReadOnly();
			}
		}
		#endregion
		
		#region Public Virtual Properties
		/// <summary>
        /// Id-Serialization name.
        /// </summary>
		public virtual string IdSerializationNameVModellXT
		{
			get{ return "id"; }
		}
		/// <summary>
        /// Id-Serialization name.
        /// </summary>
		public virtual string IdSerializationNameVModellXTMustertexte
		{
			get{ return "id"; }
		}
		/// <summary>
        /// Id-Serialization name.
        /// </summary>
		public virtual string IdSerializationNameVariantenkonfig
		{
			get{ return "id"; }
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
    /// <summary>
    /// Utility class to provide serialization messages
    /// </summary>
    public static partial class VModellXTSerializationBehaviorSerializationMessages
    {
    	/// <summary>
    	/// ResourceManager to get serialization messages from.
    	/// </summary>
    	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
    	public static global::System.Resources.ResourceManager ResourceManager
    	{
    		[global::System.Diagnostics.DebuggerStepThrough]
    		get { return VModellXTDomainModel.SingletonResourceManager; }
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

namespace Tum.VModellXT
{
	/// <summary>
	/// A ModelDataSerializationPostProcessor implementation.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class VModellXTSerializationPostProcessor : DslEditorModeling::ModelDataSerializationPostProcessor
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static VModellXTSerializationPostProcessor instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static VModellXTSerializationPostProcessor Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (VModellXTSerializationPostProcessor.instance == null)
					VModellXTSerializationPostProcessor.instance = new VModellXTSerializationPostProcessor ();
				return VModellXTSerializationPostProcessor.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private VModellXTSerializationPostProcessor() : base() { }
		#endregion
	
		#region Methods
		/// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already reseted models.</param>
        public override void Reset(System.Collections.Generic.List<string> alreadyProcessedModels)
        {
			dictionary.Clear();
			alreadyProcessedModels.Add("VModellXT");
			if( !alreadyProcessedModels.Contains("VModellXTBasis") )
				Tum.VModellXT.Basis.VModellXTBasisSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);
			if( !alreadyProcessedModels.Contains("VModellXTStatik") )
				Tum.VModellXT.Statik.VModellXTStatikSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);
			if( !alreadyProcessedModels.Contains("VModellXTDynamik") )
				Tum.VModellXT.Dynamik.VModellXTDynamikSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);
			if( !alreadyProcessedModels.Contains("VModellXTAnpassung") )
				Tum.VModellXT.Anpassung.VModellXTAnpassungSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);
			if( !alreadyProcessedModels.Contains("VModellXTKonventionsabbildungen") )
				Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);
			if( !alreadyProcessedModels.Contains("VModellXTAenderungesoperationen") )
				Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenSerializationPostProcessor.Instance.Reset(alreadyProcessedModels);

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
			
			alreadyProcessedModels.Add("VModellXT");
			if( !alreadyProcessedModels.Contains("VModellXTBasis") )
				Tum.VModellXT.Basis.VModellXTBasisSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
			if( !alreadyProcessedModels.Contains("VModellXTStatik") )
				Tum.VModellXT.Statik.VModellXTStatikSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
			if( !alreadyProcessedModels.Contains("VModellXTDynamik") )
				Tum.VModellXT.Dynamik.VModellXTDynamikSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
			if( !alreadyProcessedModels.Contains("VModellXTAnpassung") )
				Tum.VModellXT.Anpassung.VModellXTAnpassungSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
			if( !alreadyProcessedModels.Contains("VModellXTKonventionsabbildungen") )
				Tum.VModellXT.Konventionsabbildungen.VModellXTKonventionsabbildungenSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
			if( !alreadyProcessedModels.Contains("VModellXTAenderungesoperationen") )
				Tum.VModellXT.Aenderungsoperationen.VModellXTAenderungesoperationenSerializationPostProcessor.Instance.DoPostProcess(alreadyProcessedModels, serializationResult, store);
		}
		#endregion
	}
}
