 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainModelSerializer for DomainClass DomainModel.
	/// </summary>
	public partial class PDEModelingDSLDomainModelSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainModelSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainModelSerializer ()
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainModel");
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
			global::Tum.PDE.ModelingDSL.DomainModel instanceOfDomainModel = element as global::Tum.PDE.ModelingDSL.DomainModel;
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
			global::Tum.PDE.ModelingDSL.DomainModel instance = element as global::Tum.PDE.ModelingDSL.DomainModel;
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
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDomainModelHasDomainElements(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipDomainModelHasDomainTypes(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipDomainModelHasDETypes(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipDomainModelHasDRTypes(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipDomainModelHasConversionModelInfo(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DomainModelHasDomainElements that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasDomainElements(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DomainElements" )
			{
				info = global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DomainElements child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DomainElements;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements(instance, child0);
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
		/// Read emb. rel DomainModelHasDomainTypes that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasDomainTypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DomainTypes" )
			{
				info = global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DomainTypes child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DomainTypes;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes(instance, child0);
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
		/// Read emb. rel DomainModelHasDETypes that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasDETypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DETypes" )
			{
				info = global::Tum.PDE.ModelingDSL.DETypes.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, global::Tum.PDE.ModelingDSL.DETypes.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DETypes child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DETypes;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainModelHasDETypes(instance, child0);
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
		/// Read emb. rel DomainModelHasDRTypes that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasDRTypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DRTypes" )
			{
				info = global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DRTypes child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DRTypes;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes(instance, child0);
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
		/// Read emb. rel DomainModelHasConversionModelInfo that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainModelHasConversionModelInfo(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "ConversionModelInfo" )
			{
				info = global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.ConversionModelInfo child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.ConversionModelInfo;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo(instance, child0);
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
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainModelSerializer;
						PDEModelingDSLDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainModelSerializer;
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
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainModel)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainModel(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
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
				PDEModelingDSLSerializationHelper.Instance.WriteSchemaDefinitions(writer, "DefaultContext", "DomainModel");
			
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
			global::Tum.PDE.ModelingDSL.DomainModel instance = element as global::Tum.PDE.ModelingDSL.DomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainModel");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
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
			global::Tum.PDE.ModelingDSL.DomainModel instance = element as global::Tum.PDE.ModelingDSL.DomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainModel");
			
			WriteEmbeddingRelationshipDomainModelHasDomainElements(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipDomainModelHasDomainTypes(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipDomainModelHasDETypes(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipDomainModelHasDRTypes(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipDomainModelHasConversionModelInfo(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DomainModelHasDomainElements that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasDomainElements(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasDomainElements
			global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements allMDomainModelHasDomainElementsInstance = global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.GetLinkToDomainElements(instance);
			if( allMDomainModelHasDomainElementsInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasDomainElementsInstance.DomainElements;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel DomainModelHasDomainTypes that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasDomainTypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasDomainTypes
			global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes allMDomainModelHasDomainTypesInstance = global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.GetLinkToDomainTypes(instance);
			if( allMDomainModelHasDomainTypesInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasDomainTypesInstance.DomainTypes;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel DomainModelHasDETypes that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasDETypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasDETypes
			global::Tum.PDE.ModelingDSL.DomainModelHasDETypes allMDomainModelHasDETypesInstance = global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.GetLinkToDETypes(instance);
			if( allMDomainModelHasDETypesInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasDETypesInstance.DETypes;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel DomainModelHasDRTypes that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasDRTypes(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasDRTypes
			global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes allMDomainModelHasDRTypesInstance = global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.GetLinkToDRTypes(instance);
			if( allMDomainModelHasDRTypesInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasDRTypesInstance.DRTypes;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel DomainModelHasConversionModelInfo that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainModelHasConversionModelInfo(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainModelHasConversionModelInfo
			global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo allMDomainModelHasConversionModelInfoInstance = global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.GetLinkToConversionModelInfo(instance);
			if( allMDomainModelHasConversionModelInfoInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainModelHasConversionModelInfoInstance.ConversionModelInfo;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainElementBaseSerializer for DomainClass DomainElement.
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
	public abstract partial class PDEModelingDSLDomainElementBaseSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseDomainElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainElementBaseSerializer Constructor
		/// </summary>
		protected PDEModelingDSLDomainElementBaseSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainElement.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainElement";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainElement instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainElement");
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
		/// <param name="element">In-memory DomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainElement instanceOfDomainElement = element as global::Tum.PDE.ModelingDSL.DomainElement;
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
		/// <param name="element">In-memory DomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainElement instance = element as global::Tum.PDE.ModelingDSL.DomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElement!");
	
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
		/// <param name="instance">In-memory DomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipReferenceRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipEmbeddingRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDomainElementReferencesDEType(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel DomainElementReferencesDEType that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainElement instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipDomainElementReferencesDEType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "DETypeRef")
			{
				string attribValueDEType0 = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueDEType0 != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueDEType0);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DomainElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainElement, a new DomainElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainElement instance, or null if the reader is not pointing to a serialized DomainElement instance.</returns>
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
				{	// New "DomainElement" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainElement".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainElement(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainElementBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainElementBaseSerializer;
						PDEModelingDSLDomainElementBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainElementBaseSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainElement instance should be created.</param>	
		/// <returns>Created DomainElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainElement)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainElement(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainElement instance to be serialized.</param>
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
		/// <param name="element">DomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainElement instance = element as global::Tum.PDE.ModelingDSL.DomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainElement instance = element as global::Tum.PDE.ModelingDSL.DomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElement");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, writer, options);
			WriteReferenceRelationshipReferenceRelationship(serializationContext, instance, writer, options);
			WriteReferenceRelationshipEmbeddingRelationship(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDomainElementReferencesDEType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel DomainElementReferencesDEType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipDomainElementReferencesDEType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship DomainElementReferencesDEType
			global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType allMDomainElementReferencesDETypeInstance = global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.GetLinkToElementType(instance);
			if( allMDomainElementReferencesDETypeInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("DETypeRef");
					string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMDomainElementReferencesDETypeInstance ).DEType.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
	
	/// <summary>
	/// Serializer PDEModelingDSLDomainElementSerializer for DomainClass DomainElement.
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
	public partial class PDEModelingDSLDomainElementSerializer : PDEModelingDSLDomainElementBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainElementSerializer ()
			: base ()
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLBaseElementSerializer for DomainClass BaseElement.
	/// </summary>
	public partial class PDEModelingDSLBaseElementSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLBaseElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLBaseElementSerializer ()
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
		/// Public Read() method that deserializes one BaseElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the BaseElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory BaseElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory BaseElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseElement instanceOfBaseElement = element as global::Tum.PDE.ModelingDSL.BaseElement;
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
		/// <param name="element">In-memory BaseElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseElement instance = element as global::Tum.PDE.ModelingDSL.BaseElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElement!");
	
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
		/// <param name="instance">In-memory BaseElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel BaseElementSourceReferencesBaseElementTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElement instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipBaseElementSourceReferencesBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "BaseElementSourceReferencesBaseElementTarget")
			{
				DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId);
				global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for BaseElementSourceReferencesBaseElementTarget!");
				global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget connection0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget;
				if( connection0 != null )
				{
					connection0.BaseElementSource = instance;
					serializer0.Read(serializationContext, connection0, reader);
					
					if( connection0.BaseElementSource == null ||
						connection0.BaseElementTarget == null )
							Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(connection0.Id);
				}
				else
					DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of BaseElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized BaseElement, a new BaseElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created BaseElement instance, or null if the reader is not pointing to a serialized BaseElement instance.</returns>
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
				// Check for derived classes of "BaseElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableBaseElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLBaseElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLBaseElementSerializer;
					PDEModelingDSLBaseElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLBaseElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of BaseElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of BaseElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new BaseElement instance should be created.</param>	
		/// <returns>Created BaseElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one BaseElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseElement instance to be serialized.</param>
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
		/// <param name="element">BaseElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseElement instance = element as global::Tum.PDE.ModelingDSL.BaseElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseElement instance = element as global::Tum.PDE.ModelingDSL.BaseElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElement");
			
			WriteReferenceRelationshipBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel BaseElementSourceReferencesBaseElementTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipBaseElementSourceReferencesBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship BaseElementSourceReferencesBaseElementTarget
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> allMBaseElementSourceReferencesBaseElementTargetInstances = global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.GetLinksToBaseElementTarget(instance);
			foreach(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget allMBaseElementSourceReferencesBaseElementTargetInstance in allMBaseElementSourceReferencesBaseElementTargetInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Full serialization mode
					DslModeling::ModelElement targetElement = allMBaseElementSourceReferencesBaseElementTargetInstance;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLReferenceableElementSerializer for DomainClass ReferenceableElement.
	/// </summary>
	public partial class PDEModelingDSLReferenceableElementSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLAttributedDomainElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLReferenceableElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLReferenceableElementSerializer ()
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
		/// Public Read() method that deserializes one ReferenceableElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the ReferenceableElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory ReferenceableElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory ReferenceableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferenceableElement instanceOfReferenceableElement = element as global::Tum.PDE.ModelingDSL.ReferenceableElement;
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
		/// <param name="element">In-memory ReferenceableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferenceableElement instance = element as global::Tum.PDE.ModelingDSL.ReferenceableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceableElement!");
	
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
		/// <param name="instance">In-memory ReferenceableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceableElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipReferenceRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel ReferenceRelationship that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceableElement instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipReferenceRelationship(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceableElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "ReferenceRelationship")
			{
				DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId);
				global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for ReferenceRelationship!");
				global::Tum.PDE.ModelingDSL.ReferenceRelationship connection0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
				if( connection0 != null )
				{
					connection0.Source = instance;
					serializer0.Read(serializationContext, connection0, reader);
					
					if( connection0.Source == null ||
						connection0.Target == null )
							Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(connection0.Id);
				}
				else
					DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of ReferenceableElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized ReferenceableElement, a new ReferenceableElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created ReferenceableElement instance, or null if the reader is not pointing to a serialized ReferenceableElement instance.</returns>
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
				// Check for derived classes of "ReferenceableElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableReferenceableElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLReferenceableElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLReferenceableElementSerializer;
					PDEModelingDSLReferenceableElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLReferenceableElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of ReferenceableElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ReferenceableElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ReferenceableElement instance should be created.</param>	
		/// <returns>Created ReferenceableElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one ReferenceableElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferenceableElement instance to be serialized.</param>
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
		/// <param name="element">ReferenceableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferenceableElement instance = element as global::Tum.PDE.ModelingDSL.ReferenceableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceableElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferenceableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferenceableElement instance = element as global::Tum.PDE.ModelingDSL.ReferenceableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceableElement");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, writer, options);
			WriteReferenceRelationshipReferenceRelationship(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel ReferenceRelationship that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipReferenceRelationship(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceableElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ReferenceRelationship
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.ReferenceRelationship> allMReferenceRelationshipInstances = global::Tum.PDE.ModelingDSL.ReferenceRelationship.GetLinksToTargets(instance);
			foreach(global::Tum.PDE.ModelingDSL.ReferenceRelationship allMReferenceRelationshipInstance in allMReferenceRelationshipInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Full serialization mode
					DslModeling::ModelElement targetElement = allMReferenceRelationshipInstance;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLEmbeddableElementSerializer for DomainClass EmbeddableElement.
	/// </summary>
	public partial class PDEModelingDSLEmbeddableElementSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLReferenceableElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLEmbeddableElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLEmbeddableElementSerializer ()
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
		/// Public Read() method that deserializes one EmbeddableElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the EmbeddableElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory EmbeddableElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory EmbeddableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddableElement instanceOfEmbeddableElement = element as global::Tum.PDE.ModelingDSL.EmbeddableElement;
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
		/// <param name="element">In-memory EmbeddableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddableElement instance = element as global::Tum.PDE.ModelingDSL.EmbeddableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddableElement!");
	
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
		/// <param name="instance">In-memory EmbeddableElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddableElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipReferenceRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipEmbeddingRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel EmbeddingRelationship that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddableElement instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipEmbeddingRelationship(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddableElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "EmbeddingRelationship")
			{
				DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId);
				global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for EmbeddingRelationship!");
				global::Tum.PDE.ModelingDSL.EmbeddingRelationship connection0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
				if( connection0 != null )
				{
					connection0.Child = instance;
					serializer0.Read(serializationContext, connection0, reader);
					
					if( connection0.Child == null ||
						connection0.Parent == null )
							Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(connection0.Id);
				}
				else
					DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of EmbeddableElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized EmbeddableElement, a new EmbeddableElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created EmbeddableElement instance, or null if the reader is not pointing to a serialized EmbeddableElement instance.</returns>
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
				// Check for derived classes of "EmbeddableElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableEmbeddableElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLEmbeddableElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLEmbeddableElementSerializer;
					PDEModelingDSLEmbeddableElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLEmbeddableElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of EmbeddableElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of EmbeddableElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new EmbeddableElement instance should be created.</param>	
		/// <returns>Created EmbeddableElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one EmbeddableElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddableElement instance to be serialized.</param>
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
		/// <param name="element">EmbeddableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddableElement instance = element as global::Tum.PDE.ModelingDSL.EmbeddableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddableElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddableElement instance = element as global::Tum.PDE.ModelingDSL.EmbeddableElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddableElement");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, writer, options);
			WriteReferenceRelationshipReferenceRelationship(serializationContext, instance, writer, options);
			WriteReferenceRelationshipEmbeddingRelationship(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel EmbeddingRelationship that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddableElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipEmbeddingRelationship(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddableElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship EmbeddingRelationship
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship allMEmbeddingRelationshipInstance = global::Tum.PDE.ModelingDSL.EmbeddingRelationship.GetLinkToParent(instance);
			if( allMEmbeddingRelationshipInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Full serialization mode
					DslModeling::ModelElement targetElement = allMEmbeddingRelationshipInstance;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLNamedDomainElementSerializer for DomainClass NamedDomainElement.
	/// </summary>
	public partial class PDEModelingDSLNamedDomainElementSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLNamedDomainElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLNamedDomainElementSerializer ()
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
		/// Public Read() method that deserializes one NamedDomainElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the NamedDomainElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory NamedDomainElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory NamedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.NamedDomainElement instanceOfNamedDomainElement = element as global::Tum.PDE.ModelingDSL.NamedDomainElement;
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
		/// <param name="element">In-memory NamedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.NamedDomainElement instance = element as global::Tum.PDE.ModelingDSL.NamedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of NamedDomainElement!");
	
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
		/// <param name="instance">In-memory NamedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.NamedDomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property Description that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">NamedDomainElement instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementDescription(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.NamedDomainElement instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strDescription = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfDescription = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Description", strDescription, typeof(global::System.String), false) as global::System.String;
				instance.Description = valueOfDescription;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">NamedDomainElement instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.NamedDomainElement instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strName = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", strName, typeof(global::System.String), true) as global::System.String;
				instance.Name = valueOfName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of NamedDomainElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized NamedDomainElement, a new NamedDomainElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created NamedDomainElement instance, or null if the reader is not pointing to a serialized NamedDomainElement instance.</returns>
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
				// Check for derived classes of "NamedDomainElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableNamedDomainElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLNamedDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLNamedDomainElementSerializer;
					PDEModelingDSLNamedDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLNamedDomainElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of NamedDomainElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of NamedDomainElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new NamedDomainElement instance should be created.</param>	
		/// <returns>Created NamedDomainElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one NamedDomainElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">NamedDomainElement instance to be serialized.</param>
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
		/// <param name="element">NamedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.NamedDomainElement instance = element as global::Tum.PDE.ModelingDSL.NamedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of NamedDomainElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">NamedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.NamedDomainElement instance = element as global::Tum.PDE.ModelingDSL.NamedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of NamedDomainElement");
			
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WritePropertyAsElementName(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property Description that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">NamedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementDescription(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.NamedDomainElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Description
				object valueDescription = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Description", instance.Description, typeof(global::System.String), false);
	
				if( valueDescription != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Description", valueDescription.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property Name that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">NamedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.NamedDomainElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// Name
				object valueName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name", instance.Name, typeof(global::System.String), true);
	
				if( valueName != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "Name", valueName.ToString());
				}
				
			}		
		}
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLAttributedDomainElementSerializer for DomainClass AttributedDomainElement.
	/// </summary>
	public partial class PDEModelingDSLAttributedDomainElementSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLNamedDomainElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLAttributedDomainElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLAttributedDomainElementSerializer ()
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
		/// Public Read() method that deserializes one AttributedDomainElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the AttributedDomainElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory AttributedDomainElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory AttributedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElement instanceOfAttributedDomainElement = element as global::Tum.PDE.ModelingDSL.AttributedDomainElement;
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
		/// <param name="element">In-memory AttributedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElement instance = element as global::Tum.PDE.ModelingDSL.AttributedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of AttributedDomainElement!");
	
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
		/// <param name="instance">In-memory AttributedDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.AttributedDomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel AttributedDomainElementHasDomainProperty that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">AttributedDomainElement instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.AttributedDomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DomainProperty" )
			{
				info = global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId, global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DomainProperty child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DomainProperty;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty(instance, child0);
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
		/// This method creates a correct instance of AttributedDomainElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized AttributedDomainElement, a new AttributedDomainElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created AttributedDomainElement instance, or null if the reader is not pointing to a serialized AttributedDomainElement instance.</returns>
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
				// Check for derived classes of "AttributedDomainElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableAttributedDomainElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLAttributedDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLAttributedDomainElementSerializer;
					PDEModelingDSLAttributedDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLAttributedDomainElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of AttributedDomainElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of AttributedDomainElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new AttributedDomainElement instance should be created.</param>	
		/// <returns>Created AttributedDomainElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one AttributedDomainElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">AttributedDomainElement instance to be serialized.</param>
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
		/// <param name="element">AttributedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElement instance = element as global::Tum.PDE.ModelingDSL.AttributedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of AttributedDomainElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">AttributedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.AttributedDomainElement instance = element as global::Tum.PDE.ModelingDSL.AttributedDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of AttributedDomainElement");
			
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel AttributedDomainElementHasDomainProperty that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">AttributedDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.AttributedDomainElement instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship AttributedDomainElementHasDomainProperty
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> allMAttributedDomainElementHasDomainPropertyInstances = global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.GetLinksToDomainProperty(instance);
			foreach(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty allMAttributedDomainElementHasDomainPropertyInstance in allMAttributedDomainElementHasDomainPropertyInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMAttributedDomainElementHasDomainPropertyInstance.DomainProperty;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLBaseDomainElementSerializer for DomainClass BaseDomainElement.
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
	public partial class PDEModelingDSLBaseDomainElementSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLEmbeddableElementSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLBaseDomainElementSerializer Constructor
		/// </summary>
		public PDEModelingDSLBaseDomainElementSerializer ()
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
		/// Public Read() method that deserializes one BaseDomainElement instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the BaseDomainElement element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory BaseDomainElement instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory BaseDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElement instanceOfBaseDomainElement = element as global::Tum.PDE.ModelingDSL.BaseDomainElement;
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
		/// <param name="element">In-memory BaseDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElement instance = element as global::Tum.PDE.ModelingDSL.BaseDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseDomainElement!");
	
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
		/// <param name="instance">In-memory BaseDomainElement instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseDomainElement instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Name" )
			{
				ReadPropertyAsElementName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "Description" )
			{
				ReadPropertyAsElementDescription(serializationContext, instance, reader);
				return true;
			}
			if( ReadEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipReferenceRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipEmbeddingRelationship(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of BaseDomainElement based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized BaseDomainElement, a new BaseDomainElement instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created BaseDomainElement instance, or null if the reader is not pointing to a serialized BaseDomainElement instance.</returns>
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
				// Check for derived classes of "BaseDomainElement".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableBaseDomainElement(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLBaseDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLBaseDomainElementSerializer;
					PDEModelingDSLBaseDomainElementSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLBaseDomainElementSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of BaseDomainElement based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of BaseDomainElement.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new BaseDomainElement instance should be created.</param>	
		/// <returns>Created BaseDomainElement instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one BaseDomainElement instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseDomainElement instance to be serialized.</param>
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
		/// <param name="element">BaseDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElement instance = element as global::Tum.PDE.ModelingDSL.BaseDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseDomainElement");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseDomainElement instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElement instance = element as global::Tum.PDE.ModelingDSL.BaseDomainElement;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseDomainElement");
			
			WritePropertyAsElementName(serializationContext, instance, writer, options);
			WritePropertyAsElementDescription(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipAttributedDomainElementHasDomainProperty(serializationContext, instance, writer, options);
			WriteReferenceRelationshipReferenceRelationship(serializationContext, instance, writer, options);
			WriteReferenceRelationshipEmbeddingRelationship(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainPropertyBaseSerializer for DomainClass DomainProperty.
	/// </summary>
	public abstract partial class PDEModelingDSLDomainPropertyBaseSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainPropertyBaseSerializer Constructor
		/// </summary>
		protected PDEModelingDSLDomainPropertyBaseSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainProperty.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainProperty";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainProperty instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainProperty element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainProperty instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainProperty");
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
		/// <param name="element">In-memory DomainProperty instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainProperty instanceOfDomainProperty = element as global::Tum.PDE.ModelingDSL.DomainProperty;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfDomainProperty, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeValue(serializationContext, instanceOfDomainProperty, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
			}
					
		}
		/// <summary>
		/// Read property Value that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeValue(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlReader reader)
		{
			// Value
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Value");
				if( attribValue != null )
					instance.Value = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Value", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory DomainProperty instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainProperty instance = element as global::Tum.PDE.ModelingDSL.DomainProperty;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainProperty!");
	
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
		/// <param name="instance">In-memory DomainProperty instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipDomainPropertyReferencesDomainType(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel DomainPropertyReferencesDomainType that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipDomainPropertyReferencesDomainType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "DomainTypeRef")
			{
				string attribValueDomainType0 = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueDomainType0 != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueDomainType0);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DomainProperty based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainProperty, a new DomainProperty instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainProperty instance, or null if the reader is not pointing to a serialized DomainProperty instance.</returns>
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
				{	// New "DomainProperty" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainProperty".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainProperty(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainPropertyBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainPropertyBaseSerializer;
						PDEModelingDSLDomainPropertyBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainPropertyBaseSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainProperty based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainProperty.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainProperty instance should be created.</param>	
		/// <returns>Created DomainProperty instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainProperty)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainProperty(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainProperty instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainProperty instance to be serialized.</param>
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
		/// <param name="element">DomainProperty instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainProperty instance = element as global::Tum.PDE.ModelingDSL.DomainProperty;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainProperty");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeValue(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		/// <summary>
		/// Write property Value that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeValue(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Value
			object valueValue = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Value" ,instance.Value, typeof(global::System.String), true);
			if( valueValue != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Value", valueValue.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainProperty instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainProperty instance = element as global::Tum.PDE.ModelingDSL.DomainProperty;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainProperty");
			
			WriteReferenceRelationshipDomainPropertyReferencesDomainType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel DomainPropertyReferencesDomainType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainProperty instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipDomainPropertyReferencesDomainType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainProperty instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship DomainPropertyReferencesDomainType
			global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType allMDomainPropertyReferencesDomainTypeInstance = global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.GetLinkToDomainType(instance);
			if( allMDomainPropertyReferencesDomainTypeInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("DomainTypeRef");
					string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMDomainPropertyReferencesDomainTypeInstance ).DomainType.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
	
	/// <summary>
	/// Serializer PDEModelingDSLDomainPropertySerializer for DomainClass DomainProperty.
	/// </summary>
	public partial class PDEModelingDSLDomainPropertySerializer : PDEModelingDSLDomainPropertyBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainPropertySerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainPropertySerializer ()
			: base ()
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainElementsSerializer for DomainClass DomainElements.
	/// </summary>
	public partial class PDEModelingDSLDomainElementsSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainElementsSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainElementsSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainElements.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainElements";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainElements instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainElements element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainElements instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainElements");
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
		/// <param name="element">In-memory DomainElements instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainElements instanceOfDomainElements = element as global::Tum.PDE.ModelingDSL.DomainElements;
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
		/// <param name="element">In-memory DomainElements instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainElements instance = element as global::Tum.PDE.ModelingDSL.DomainElements;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElements!");
	
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
		/// <param name="instance">In-memory DomainElements instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElements instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDomainElementsHasDomainElement(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DomainElementsHasDomainElement that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainElements instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainElementsHasDomainElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElements instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DomainElement" )
			{
				info = global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId, global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DomainElement child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DomainElement;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement(instance, child0);
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
		/// This method creates a correct instance of DomainElements based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainElements, a new DomainElements instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainElements instance, or null if the reader is not pointing to a serialized DomainElements instance.</returns>
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
				{	// New "DomainElements" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainElements".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainElements(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainElementsSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainElementsSerializer;
						PDEModelingDSLDomainElementsSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainElementsSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainElements based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainElements.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainElements instance should be created.</param>	
		/// <returns>Created DomainElements instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainElements)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainElements(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainElements instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainElements instance to be serialized.</param>
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
		/// <param name="element">DomainElements instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainElements instance = element as global::Tum.PDE.ModelingDSL.DomainElements;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElements");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainElements instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainElements instance = element as global::Tum.PDE.ModelingDSL.DomainElements;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainElements");
			
			WriteEmbeddingRelationshipDomainElementsHasDomainElement(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DomainElementsHasDomainElement that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainElements instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainElementsHasDomainElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainElements instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainElementsHasDomainElement
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> allMDomainElementsHasDomainElementInstances = global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.GetLinksToDomainElement(instance);
			foreach(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement allMDomainElementsHasDomainElementInstance in allMDomainElementsHasDomainElementInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainElementsHasDomainElementInstance.DomainElement;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainTypesSerializer for DomainClass DomainTypes.
	/// </summary>
	public partial class PDEModelingDSLDomainTypesSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainTypesSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainTypesSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainTypes.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainTypes";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainTypes instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainTypes element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainTypes instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainTypes");
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
		/// <param name="element">In-memory DomainTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainTypes instanceOfDomainTypes = element as global::Tum.PDE.ModelingDSL.DomainTypes;
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
		/// <param name="element">In-memory DomainTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainTypes instance = element as global::Tum.PDE.ModelingDSL.DomainTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainTypes!");
	
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
		/// <param name="instance">In-memory DomainTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainTypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDomainTypesHasDomainType(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DomainTypesHasDomainType that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainTypes instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainTypesHasDomainType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainTypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DomainType" )
			{
				info = global::Tum.PDE.ModelingDSL.DomainType.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, global::Tum.PDE.ModelingDSL.DomainType.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DomainType child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DomainType;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType(instance, child0);
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
		/// This method creates a correct instance of DomainTypes based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainTypes, a new DomainTypes instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainTypes instance, or null if the reader is not pointing to a serialized DomainTypes instance.</returns>
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
				{	// New "DomainTypes" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainTypes".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainTypes(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainTypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainTypesSerializer;
						PDEModelingDSLDomainTypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainTypesSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainTypes based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainTypes.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainTypes instance should be created.</param>	
		/// <returns>Created DomainTypes instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainTypes)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainTypes(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainTypes instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainTypes instance to be serialized.</param>
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
		/// <param name="element">DomainTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainTypes instance = element as global::Tum.PDE.ModelingDSL.DomainTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainTypes");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainTypes instance = element as global::Tum.PDE.ModelingDSL.DomainTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainTypes");
			
			WriteEmbeddingRelationshipDomainTypesHasDomainType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DomainTypesHasDomainType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainTypesHasDomainType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainTypes instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainTypesHasDomainType
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> allMDomainTypesHasDomainTypeInstances = global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.GetLinksToDomainType(instance);
			foreach(global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType allMDomainTypesHasDomainTypeInstance in allMDomainTypesHasDomainTypeInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainTypesHasDomainTypeInstance.DomainType;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainTypeSerializer for DomainClass DomainType.
	/// </summary>
	public partial class PDEModelingDSLDomainTypeSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainTypeSerializer ()
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
		/// Public Read() method that deserializes one DomainType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainType instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory DomainType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainType instanceOfDomainType = element as global::Tum.PDE.ModelingDSL.DomainType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfDomainType, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainType instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainType instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory DomainType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory DomainType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DomainType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainType, a new DomainType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainType instance, or null if the reader is not pointing to a serialized DomainType instance.</returns>
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
				// Check for derived classes of "DomainType".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableDomainType(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLDomainTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainTypeSerializer;
					PDEModelingDSLDomainTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainTypeSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainType instance should be created.</param>	
		/// <returns>Created DomainType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainType instance to be serialized.</param>
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
		/// <param name="element">DomainType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainType instance = element as global::Tum.PDE.ModelingDSL.DomainType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainType instance = element as global::Tum.PDE.ModelingDSL.DomainType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainType");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLExternalTypeSerializer for DomainClass ExternalType.
	/// </summary>
	public partial class PDEModelingDSLExternalTypeSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLDomainTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLExternalTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLExternalTypeSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ExternalType.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "ExternalType";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one ExternalType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the ExternalType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory ExternalType instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "ExternalType");
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
		/// <param name="element">In-memory ExternalType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ExternalType instanceOfExternalType = element as global::Tum.PDE.ModelingDSL.ExternalType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfExternalType, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeNamespace(serializationContext, instanceOfExternalType, reader);
			}
		}
		
		/// <summary>
		/// Read property Namespace that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ExternalType instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeNamespace(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ExternalType instance, global::System.Xml.XmlReader reader)
		{
			// Namespace
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Namespace");
				if( attribValue != null )
					instance.Namespace = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Namespace", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory ExternalType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory ExternalType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ExternalType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of ExternalType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized ExternalType, a new ExternalType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created ExternalType instance, or null if the reader is not pointing to a serialized ExternalType instance.</returns>
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
				{	// New "ExternalType" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "ExternalType".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableExternalType(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLExternalTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLExternalTypeSerializer;
						PDEModelingDSLExternalTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLExternalTypeSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of ExternalType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ExternalType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ExternalType instance should be created.</param>	
		/// <returns>Created ExternalType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (ExternalType)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.ExternalType(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one ExternalType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ExternalType instance to be serialized.</param>
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
		/// <param name="element">ExternalType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ExternalType instance = element as global::Tum.PDE.ModelingDSL.ExternalType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ExternalType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeNamespace(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Namespace that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ExternalType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeNamespace(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ExternalType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Namespace
			object valueNamespace = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Namespace" ,instance.Namespace, typeof(global::System.String), true);
			if( valueNamespace != null )
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Namespace", valueNamespace.ToString());
			else
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Namespace", "");
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ExternalType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ExternalType instance = element as global::Tum.PDE.ModelingDSL.ExternalType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ExternalType");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDomainEnumerationSerializer for DomainClass DomainEnumeration.
	/// </summary>
	public partial class PDEModelingDSLDomainEnumerationSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLDomainTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDomainEnumerationSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainEnumerationSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainEnumeration.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DomainEnumeration";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DomainEnumeration instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DomainEnumeration element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DomainEnumeration instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DomainEnumeration");
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
		/// <param name="element">In-memory DomainEnumeration instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainEnumeration instanceOfDomainEnumeration = element as global::Tum.PDE.ModelingDSL.DomainEnumeration;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfDomainEnumeration, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeIsFlags(serializationContext, instanceOfDomainEnumeration, reader);
			}
		}
		
		/// <summary>
		/// Read property IsFlags that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainEnumeration instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeIsFlags(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainEnumeration instance, global::System.Xml.XmlReader reader)
		{
			// IsFlags
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "IsFlags");
				if( attribValue != null )
					instance.IsFlags = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "IsFlags", attribValue, typeof(global::System.Boolean?), true) as global::System.Boolean?;
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
		/// <param name="element">In-memory DomainEnumeration instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DomainEnumeration instance = element as global::Tum.PDE.ModelingDSL.DomainEnumeration;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainEnumeration!");
	
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
		/// <param name="instance">In-memory DomainEnumeration instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainEnumeration instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDomainEnumerationHasEnumerationLiteral(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DomainEnumerationHasEnumerationLiteral that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainEnumeration instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDomainEnumerationHasEnumerationLiteral(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainEnumeration instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "EnumerationLiteral" )
			{
				info = global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId, global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.EnumerationLiteral child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.EnumerationLiteral;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral(instance, child0);
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
		/// This method creates a correct instance of DomainEnumeration based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DomainEnumeration, a new DomainEnumeration instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DomainEnumeration instance, or null if the reader is not pointing to a serialized DomainEnumeration instance.</returns>
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
				{	// New "DomainEnumeration" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DomainEnumeration".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDomainEnumeration(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDomainEnumerationSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDomainEnumerationSerializer;
						PDEModelingDSLDomainEnumerationSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDomainEnumerationSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DomainEnumeration based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DomainEnumeration.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DomainEnumeration instance should be created.</param>	
		/// <returns>Created DomainEnumeration instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DomainEnumeration)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DomainEnumeration(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DomainEnumeration instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainEnumeration instance to be serialized.</param>
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
		/// <param name="element">DomainEnumeration instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainEnumeration instance = element as global::Tum.PDE.ModelingDSL.DomainEnumeration;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainEnumeration");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeIsFlags(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property IsFlags that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainEnumeration instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeIsFlags(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainEnumeration instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// IsFlags
			object valueIsFlags = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "IsFlags" ,instance.IsFlags, typeof(global::System.Boolean?), true);
			if( valueIsFlags != null )
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "IsFlags", valueIsFlags.ToString());
			else
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "IsFlags", "");
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DomainEnumeration instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DomainEnumeration instance = element as global::Tum.PDE.ModelingDSL.DomainEnumeration;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DomainEnumeration");
			
			WriteEmbeddingRelationshipDomainEnumerationHasEnumerationLiteral(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DomainEnumerationHasEnumerationLiteral that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DomainEnumeration instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDomainEnumerationHasEnumerationLiteral(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DomainEnumeration instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DomainEnumerationHasEnumerationLiteral
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> allMDomainEnumerationHasEnumerationLiteralInstances = global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.GetLinksToEnumerationLiteral(instance);
			foreach(global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral allMDomainEnumerationHasEnumerationLiteralInstance in allMDomainEnumerationHasEnumerationLiteralInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDomainEnumerationHasEnumerationLiteralInstance.EnumerationLiteral;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLEnumerationLiteralSerializer for DomainClass EnumerationLiteral.
	/// </summary>
	public partial class PDEModelingDSLEnumerationLiteralSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLEnumerationLiteralSerializer Constructor
		/// </summary>
		public PDEModelingDSLEnumerationLiteralSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EnumerationLiteral.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "EnumerationLiteral";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one EnumerationLiteral instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the EnumerationLiteral element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory EnumerationLiteral instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "EnumerationLiteral");
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
		/// <param name="element">In-memory EnumerationLiteral instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EnumerationLiteral instanceOfEnumerationLiteral = element as global::Tum.PDE.ModelingDSL.EnumerationLiteral;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfEnumerationLiteral, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeValue(serializationContext, instanceOfEnumerationLiteral, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EnumerationLiteral instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EnumerationLiteral instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
			}
					
		}
		/// <summary>
		/// Read property Value that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EnumerationLiteral instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeValue(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EnumerationLiteral instance, global::System.Xml.XmlReader reader)
		{
			// Value
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Value");
				if( attribValue != null )
					instance.Value = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Value", attribValue, typeof(global::System.String), false) as global::System.String;
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
		/// <param name="element">In-memory EnumerationLiteral instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory EnumerationLiteral instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EnumerationLiteral instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of EnumerationLiteral based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized EnumerationLiteral, a new EnumerationLiteral instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created EnumerationLiteral instance, or null if the reader is not pointing to a serialized EnumerationLiteral instance.</returns>
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
				{	// New "EnumerationLiteral" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "EnumerationLiteral".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableEnumerationLiteral(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLEnumerationLiteralSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLEnumerationLiteralSerializer;
						PDEModelingDSLEnumerationLiteralSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLEnumerationLiteralSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of EnumerationLiteral based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of EnumerationLiteral.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new EnumerationLiteral instance should be created.</param>	
		/// <returns>Created EnumerationLiteral instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (EnumerationLiteral)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.EnumerationLiteral(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one EnumerationLiteral instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EnumerationLiteral instance to be serialized.</param>
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
		/// <param name="element">EnumerationLiteral instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EnumerationLiteral instance = element as global::Tum.PDE.ModelingDSL.EnumerationLiteral;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EnumerationLiteral");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeValue(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EnumerationLiteral instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EnumerationLiteral instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		/// <summary>
		/// Write property Value that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EnumerationLiteral instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeValue(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EnumerationLiteral instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Value
			object valueValue = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Value" ,instance.Value, typeof(global::System.String), false);
			if( valueValue != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Value", valueValue.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EnumerationLiteral instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EnumerationLiteral instance = element as global::Tum.PDE.ModelingDSL.EnumerationLiteral;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EnumerationLiteral");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDETypesSerializer for DomainClass DETypes.
	/// </summary>
	public partial class PDEModelingDSLDETypesSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDETypesSerializer Constructor
		/// </summary>
		public PDEModelingDSLDETypesSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DETypes.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DETypes";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DETypes instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DETypes element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DETypes instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DETypes");
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
		/// <param name="element">In-memory DETypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DETypes instanceOfDETypes = element as global::Tum.PDE.ModelingDSL.DETypes;
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
		/// <param name="element">In-memory DETypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DETypes instance = element as global::Tum.PDE.ModelingDSL.DETypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DETypes!");
	
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
		/// <param name="instance">In-memory DETypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DETypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDETypesHasDEType(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DETypesHasDEType that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DETypes instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDETypesHasDEType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DETypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DEType" )
			{
				info = global::Tum.PDE.ModelingDSL.DEType.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DETypes.DomainClassId, global::Tum.PDE.ModelingDSL.DEType.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DEType child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DEType;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DETypesHasDEType(instance, child0);
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
		/// This method creates a correct instance of DETypes based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DETypes, a new DETypes instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DETypes instance, or null if the reader is not pointing to a serialized DETypes instance.</returns>
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
				{	// New "DETypes" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DETypes".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDETypes(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DETypes.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDETypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDETypesSerializer;
						PDEModelingDSLDETypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDETypesSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DETypes based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DETypes.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DETypes instance should be created.</param>	
		/// <returns>Created DETypes instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DETypes)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DETypes(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DETypes instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DETypes instance to be serialized.</param>
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
		/// <param name="element">DETypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DETypes instance = element as global::Tum.PDE.ModelingDSL.DETypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DETypes");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DETypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DETypes instance = element as global::Tum.PDE.ModelingDSL.DETypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DETypes");
			
			WriteEmbeddingRelationshipDETypesHasDEType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DETypesHasDEType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DETypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDETypesHasDEType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DETypes instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DETypesHasDEType
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DETypesHasDEType> allMDETypesHasDETypeInstances = global::Tum.PDE.ModelingDSL.DETypesHasDEType.GetLinksToDomainElementTypes(instance);
			foreach(global::Tum.PDE.ModelingDSL.DETypesHasDEType allMDETypesHasDETypeInstance in allMDETypesHasDETypeInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDETypesHasDETypeInstance.DEType;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDRTypesSerializer for DomainClass DRTypes.
	/// </summary>
	public partial class PDEModelingDSLDRTypesSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDRTypesSerializer Constructor
		/// </summary>
		public PDEModelingDSLDRTypesSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DRTypes.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DRTypes";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DRTypes instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DRTypes element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DRTypes instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DRTypes");
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
		/// <param name="element">In-memory DRTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DRTypes instanceOfDRTypes = element as global::Tum.PDE.ModelingDSL.DRTypes;
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
		/// <param name="element">In-memory DRTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DRTypes instance = element as global::Tum.PDE.ModelingDSL.DRTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRTypes!");
	
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
		/// <param name="instance">In-memory DRTypes instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRTypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipDRTypesHasDRType(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel DRTypesHasDRType that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRTypes instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipDRTypesHasDRType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRTypes instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "DRType" )
			{
				info = global::Tum.PDE.ModelingDSL.DRType.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, global::Tum.PDE.ModelingDSL.DRType.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.PDE.ModelingDSL.DRType child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.PDE.ModelingDSL.DRType;
					if( child0 != null )
					{
						new global::Tum.PDE.ModelingDSL.DRTypesHasDRType(instance, child0);
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
		/// This method creates a correct instance of DRTypes based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DRTypes, a new DRTypes instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DRTypes instance, or null if the reader is not pointing to a serialized DRTypes instance.</returns>
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
				{	// New "DRTypes" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DRTypes".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDRTypes(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDRTypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDRTypesSerializer;
						PDEModelingDSLDRTypesSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDRTypesSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DRTypes based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DRTypes.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DRTypes instance should be created.</param>	
		/// <returns>Created DRTypes instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DRTypes)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DRTypes(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DRTypes instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DRTypes instance to be serialized.</param>
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
		/// <param name="element">DRTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DRTypes instance = element as global::Tum.PDE.ModelingDSL.DRTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRTypes");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DRTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DRTypes instance = element as global::Tum.PDE.ModelingDSL.DRTypes;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRTypes");
			
			WriteEmbeddingRelationshipDRTypesHasDRType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel DRTypesHasDRType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRTypes instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipDRTypesHasDRType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRTypes instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship DRTypesHasDRType
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> allMDRTypesHasDRTypeInstances = global::Tum.PDE.ModelingDSL.DRTypesHasDRType.GetLinksToDomainRelationshipTypes(instance);
			foreach(global::Tum.PDE.ModelingDSL.DRTypesHasDRType allMDRTypesHasDRTypeInstance in allMDRTypesHasDRTypeInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMDRTypesHasDRTypeInstance.DRType;
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
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDETypeSerializer for DomainClass DEType.
	/// </summary>
	public partial class PDEModelingDSLDETypeSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseDomainElementTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDETypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLDETypeSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DEType.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "DEType";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one DEType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DEType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DEType instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "DEType");
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
		/// <param name="element">In-memory DEType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DEType instanceOfDEType = element as global::Tum.PDE.ModelingDSL.DEType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfDEType, reader);
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
		/// <param name="element">In-memory DEType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DEType instance = element as global::Tum.PDE.ModelingDSL.DEType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DEType!");
	
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
		/// <param name="instance">In-memory DEType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "StyleType" )
			{
				ReadPropertyAsElementStyleType(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "FileName" )
			{
				ReadPropertyAsElementFileName(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "FormType" )
			{
				ReadPropertyAsElementFormType(serializationContext, instance, reader);
				return true;
			}
			if( readerLocalName == "ColorType" )
			{
				ReadPropertyAsElementColorType(serializationContext, instance, reader);
				return true;
			}
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Write property StyleType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementStyleType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strStyleType = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::Tum.PDE.ModelingDSL.ShapeStyleType? valueOfStyleType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "StyleType", strStyleType, typeof(global::Tum.PDE.ModelingDSL.ShapeStyleType?), false) as global::Tum.PDE.ModelingDSL.ShapeStyleType?;
				instance.StyleType = valueOfStyleType;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property FileName that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementFileName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strFileName = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::System.String valueOfFileName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "FileName", strFileName, typeof(global::System.String), false) as global::System.String;
				instance.FileName = valueOfFileName;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property FormType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementFormType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strFormType = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::Tum.PDE.ModelingDSL.ShapeFormType? valueOfFormType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "FormType", strFormType, typeof(global::Tum.PDE.ModelingDSL.ShapeFormType?), false) as global::Tum.PDE.ModelingDSL.ShapeFormType?;
				instance.FormType = valueOfFormType;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		/// <summary>
		/// Write property ColorType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsElementColorType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlReader reader)
		{
			if (reader.IsEmptyElement)
			{	// No serialized value, must be default one.
				DslModeling::SerializationUtilities.Skip(reader);  // Skip this tag.
			}
			else
			{
				string strColorType = PDEModelingDSLSerializationHelper.Instance.ReadElementContentAsString(serializationContext, instance, reader);
							
				global::Tum.PDE.ModelingDSL.ShapeColorType? valueOfColorType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "ColorType", strColorType, typeof(global::Tum.PDE.ModelingDSL.ShapeColorType?), false) as global::Tum.PDE.ModelingDSL.ShapeColorType?;
				instance.ColorType = valueOfColorType;
				//DslModeling::SerializationUtilities.SkipToNextElement(reader);
				DslModeling::SerializationUtilities.Skip(reader);
			}
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DEType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DEType, a new DEType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DEType instance, or null if the reader is not pointing to a serialized DEType instance.</returns>
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
				{	// New "DEType" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "DEType".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableDEType(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DEType.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLDETypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDETypeSerializer;
						PDEModelingDSLDETypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDETypeSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DEType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DEType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DEType instance should be created.</param>	
		/// <returns>Created DEType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (DEType)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.DEType(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DEType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DEType instance to be serialized.</param>
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
		/// <param name="element">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DEType instance = element as global::Tum.PDE.ModelingDSL.DEType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DEType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DEType instance = element as global::Tum.PDE.ModelingDSL.DEType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DEType");
			
			WritePropertyAsElementStyleType(serializationContext, instance, writer, options);
			WritePropertyAsElementFileName(serializationContext, instance, writer, options);
			WritePropertyAsElementFormType(serializationContext, instance, writer, options);
			WritePropertyAsElementColorType(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write property StyleType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementStyleType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// StyleType
				object valueStyleType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "StyleType", instance.StyleType, typeof(global::Tum.PDE.ModelingDSL.ShapeStyleType?), false);
	
				if( valueStyleType != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "StyleType", valueStyleType.ToString());
				}
				else
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "StyleType", "");
					
				}
				
			}		
		}
		/// <summary>
		/// Write property FileName that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementFileName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// FileName
				object valueFileName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "FileName", instance.FileName, typeof(global::System.String), false);
	
				if( valueFileName != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "FileName", valueFileName.ToString());
				}
				
			}		
		}
		/// <summary>
		/// Write property FormType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementFormType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// FormType
				object valueFormType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "FormType", instance.FormType, typeof(global::Tum.PDE.ModelingDSL.ShapeFormType?), false);
	
				if( valueFormType != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "FormType", valueFormType.ToString());
				}
				else
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "FormType", "");
					
				}
				
			}		
		}
		/// <summary>
		/// Write property ColorType that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DEType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsElementColorType(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DEType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			if (!serializationContext.Result.Failed)
			{
				// ColorType
				object valueColorType = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "ColorType", instance.ColorType, typeof(global::Tum.PDE.ModelingDSL.ShapeColorType?), false);
	
				if( valueColorType != null )
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "ColorType", valueColorType.ToString());
				}
				else
				{
					PDEModelingDSLSerializationHelper.Instance.WriteElementString(serializationContext, instance, writer, "ColorType", "");
					
				}
				
			}		
		}
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLDRTypeSerializer for DomainClass DRType.
	/// </summary>
	public partial class PDEModelingDSLDRTypeSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseDomainElementTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLDRTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLDRTypeSerializer ()
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
		/// Public Read() method that deserializes one DRType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the DRType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory DRType instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory DRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DRType instanceOfDRType = element as global::Tum.PDE.ModelingDSL.DRType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfDRType, reader);
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
		/// <param name="element">In-memory DRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.DRType instance = element as global::Tum.PDE.ModelingDSL.DRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRType!");
	
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
		/// <param name="instance">In-memory DRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel DRTypeReferencesBaseElementSourceReferencesBaseElementTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "BaseElementSourceReferencesBaseElementTargetRef")
			{
				string attribValueBaseElementSourceReferencesBaseElementTarget0 = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueBaseElementSourceReferencesBaseElementTarget0 != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueBaseElementSourceReferencesBaseElementTarget0);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		/// <summary>
		/// Read ref. rel DRTypeReferencesDETypeSource that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipDRTypeReferencesDETypeSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "DETypeSourceRef")
			{
				string attribValueDETypeSource0 = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueDETypeSource0 != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueDETypeSource0);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		/// <summary>
		/// Read ref. rel DRTypeReferencesDETypeTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipDRTypeReferencesDETypeTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "DETypeTargetRef")
			{
				string attribValueDETypeTarget0 = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueDETypeTarget0 != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueDETypeTarget0);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DomainClassId, System.Guid.Empty, instance.Id, id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of DRType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized DRType, a new DRType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created DRType instance, or null if the reader is not pointing to a serialized DRType instance.</returns>
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
				// Check for derived classes of "DRType".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableDRType(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.DRType.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLDRTypeSerializer;
					PDEModelingDSLDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLDRTypeSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of DRType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DRType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DRType instance should be created.</param>	
		/// <returns>Created DRType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one DRType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DRType instance to be serialized.</param>
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
		/// <param name="element">DRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DRType instance = element as global::Tum.PDE.ModelingDSL.DRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">DRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.DRType instance = element as global::Tum.PDE.ModelingDSL.DRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of DRType");
			
			WriteReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel DRTypeReferencesBaseElementSourceReferencesBaseElementTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship DRTypeReferencesBaseElementSourceReferencesBaseElementTarget
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> allMDRTypeReferencesBaseElementSourceReferencesBaseElementTargetInstances = global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.GetLinksToReferencedRelationships(instance);
			foreach(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget allMDRTypeReferencesBaseElementSourceReferencesBaseElementTargetInstance in allMDRTypeReferencesBaseElementSourceReferencesBaseElementTargetInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("BaseElementSourceReferencesBaseElementTargetRef");
					string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMDRTypeReferencesBaseElementSourceReferencesBaseElementTargetInstance ).BaseElementSourceReferencesBaseElementTarget.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		/// <summary>
		/// Write ref. rel DRTypeReferencesDETypeSource that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipDRTypeReferencesDETypeSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship DRTypeReferencesDETypeSource
			global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource allMDRTypeReferencesDETypeSourceInstance = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.GetLinkToSource(instance);
			if( allMDRTypeReferencesDETypeSourceInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("DETypeSourceRef");
					string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMDRTypeReferencesDETypeSourceInstance ).DETypeSource.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		/// <summary>
		/// Write ref. rel DRTypeReferencesDETypeTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">DRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipDRTypeReferencesDETypeTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.DRType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship DRTypeReferencesDETypeTarget
			global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget allMDRTypeReferencesDETypeTargetInstance = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.GetLinkToTarget(instance);
			if( allMDRTypeReferencesDETypeTargetInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// Write target link
					writer.WriteStartElement("DETypeTargetRef");
					string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, (allMDRTypeReferencesDETypeTargetInstance ).DETypeTarget.Id);
					writer.WriteAttributeString("link", valueId);
					writer.WriteEndElement();
				}
			}
			#endregion	
		}
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLBaseDomainElementTypeSerializer for DomainClass BaseDomainElementType.
	/// </summary>
	public partial class PDEModelingDSLBaseDomainElementTypeSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLBaseDomainElementTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLBaseDomainElementTypeSerializer ()
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
		/// Public Read() method that deserializes one BaseDomainElementType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the BaseDomainElementType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory BaseDomainElementType instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory BaseDomainElementType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElementType instanceOfBaseDomainElementType = element as global::Tum.PDE.ModelingDSL.BaseDomainElementType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfBaseDomainElementType, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseDomainElementType instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseDomainElementType instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory BaseDomainElementType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory BaseDomainElementType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseDomainElementType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of BaseDomainElementType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized BaseDomainElementType, a new BaseDomainElementType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created BaseDomainElementType instance, or null if the reader is not pointing to a serialized BaseDomainElementType instance.</returns>
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
				// Check for derived classes of "BaseDomainElementType".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableBaseDomainElementType(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//PDEModelingDSLBaseDomainElementTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLBaseDomainElementTypeSerializer;
					PDEModelingDSLBaseDomainElementTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLBaseDomainElementTypeSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of BaseDomainElementType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of BaseDomainElementType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new BaseDomainElementType instance should be created.</param>	
		/// <returns>Created BaseDomainElementType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one BaseDomainElementType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseDomainElementType instance to be serialized.</param>
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
		/// <param name="element">BaseDomainElementType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElementType instance = element as global::Tum.PDE.ModelingDSL.BaseDomainElementType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseDomainElementType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseDomainElementType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseDomainElementType instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseDomainElementType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseDomainElementType instance = element as global::Tum.PDE.ModelingDSL.BaseDomainElementType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseDomainElementType");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLReferencingDRTypeSerializer for DomainClass ReferencingDRType.
	/// </summary>
	public partial class PDEModelingDSLReferencingDRTypeSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLDRTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLReferencingDRTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLReferencingDRTypeSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ReferencingDRType.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "ReferencingDRType";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one ReferencingDRType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the ReferencingDRType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory ReferencingDRType instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "ReferencingDRType");
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
		/// <param name="element">In-memory ReferencingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferencingDRType instanceOfReferencingDRType = element as global::Tum.PDE.ModelingDSL.ReferencingDRType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfReferencingDRType, reader);
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
		/// <param name="element">In-memory ReferencingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferencingDRType instance = element as global::Tum.PDE.ModelingDSL.ReferencingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferencingDRType!");
	
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
		/// <param name="instance">In-memory ReferencingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferencingDRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of ReferencingDRType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized ReferencingDRType, a new ReferencingDRType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created ReferencingDRType instance, or null if the reader is not pointing to a serialized ReferencingDRType instance.</returns>
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
				{	// New "ReferencingDRType" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "ReferencingDRType".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableReferencingDRType(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLReferencingDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLReferencingDRTypeSerializer;
						PDEModelingDSLReferencingDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLReferencingDRTypeSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of ReferencingDRType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ReferencingDRType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ReferencingDRType instance should be created.</param>	
		/// <returns>Created ReferencingDRType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (ReferencingDRType)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.ReferencingDRType(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one ReferencingDRType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferencingDRType instance to be serialized.</param>
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
		/// <param name="element">ReferencingDRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferencingDRType instance = element as global::Tum.PDE.ModelingDSL.ReferencingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferencingDRType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferencingDRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferencingDRType instance = element as global::Tum.PDE.ModelingDSL.ReferencingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferencingDRType");
			
			WriteReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLEmbeddingDRTypeSerializer for DomainClass EmbeddingDRType.
	/// </summary>
	public partial class PDEModelingDSLEmbeddingDRTypeSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLDRTypeSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLEmbeddingDRTypeSerializer Constructor
		/// </summary>
		public PDEModelingDSLEmbeddingDRTypeSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EmbeddingDRType.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "EmbeddingDRType";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one EmbeddingDRType instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the EmbeddingDRType element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory EmbeddingDRType instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "EmbeddingDRType");
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
		/// <param name="element">In-memory EmbeddingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingDRType instanceOfEmbeddingDRType = element as global::Tum.PDE.ModelingDSL.EmbeddingDRType;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfEmbeddingDRType, reader);
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
		/// <param name="element">In-memory EmbeddingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingDRType instance = element as global::Tum.PDE.ModelingDSL.EmbeddingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingDRType!");
	
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
		/// <param name="instance">In-memory EmbeddingDRType instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingDRType instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of EmbeddingDRType based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized EmbeddingDRType, a new EmbeddingDRType instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created EmbeddingDRType instance, or null if the reader is not pointing to a serialized EmbeddingDRType instance.</returns>
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
				{	// New "EmbeddingDRType" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "EmbeddingDRType".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableEmbeddingDRType(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLEmbeddingDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLEmbeddingDRTypeSerializer;
						PDEModelingDSLEmbeddingDRTypeSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLEmbeddingDRTypeSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of EmbeddingDRType based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of EmbeddingDRType.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new EmbeddingDRType instance should be created.</param>	
		/// <returns>Created EmbeddingDRType instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (EmbeddingDRType)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.EmbeddingDRType(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one EmbeddingDRType instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddingDRType instance to be serialized.</param>
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
		/// <param name="element">EmbeddingDRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingDRType instance = element as global::Tum.PDE.ModelingDSL.EmbeddingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingDRType");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddingDRType instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingDRType instance = element as global::Tum.PDE.ModelingDSL.EmbeddingDRType;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingDRType");
			
			WriteReferenceRelationshipDRTypeReferencesBaseElementSourceReferencesBaseElementTarget(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipDRTypeReferencesDETypeTarget(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLConversionModelInfoSerializer for DomainClass ConversionModelInfo.
	/// </summary>
	public partial class PDEModelingDSLConversionModelInfoSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLConversionModelInfoSerializer Constructor
		/// </summary>
		public PDEModelingDSLConversionModelInfoSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ConversionModelInfo.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "ConversionModelInfo";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one ConversionModelInfo instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the ConversionModelInfo element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory ConversionModelInfo instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "ConversionModelInfo");
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
		/// <param name="element">In-memory ConversionModelInfo instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ConversionModelInfo instanceOfConversionModelInfo = element as global::Tum.PDE.ModelingDSL.ConversionModelInfo;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeHasModelChanged(serializationContext, instanceOfConversionModelInfo, reader);
			}
		}
		
		/// <summary>
		/// Read property HasModelChanged that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ConversionModelInfo instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeHasModelChanged(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ConversionModelInfo instance, global::System.Xml.XmlReader reader)
		{
			// HasModelChanged
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "HasModelChanged");
				if( attribValue != null )
					instance.HasModelChanged = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "HasModelChanged", attribValue, typeof(global::System.Boolean?), true) as global::System.Boolean?;
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
		/// <param name="element">In-memory ConversionModelInfo instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
		}
		
		/// <summary>
		/// This methods deserializes nested XML elements inside the passed-in element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">In-memory ConversionModelInfo instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ConversionModelInfo instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of ConversionModelInfo based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized ConversionModelInfo, a new ConversionModelInfo instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created ConversionModelInfo instance, or null if the reader is not pointing to a serialized ConversionModelInfo instance.</returns>
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
				{	// New "ConversionModelInfo" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "ConversionModelInfo".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableConversionModelInfo(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//PDEModelingDSLConversionModelInfoSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLConversionModelInfoSerializer;
						PDEModelingDSLConversionModelInfoSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLConversionModelInfoSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of ConversionModelInfo based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ConversionModelInfo.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ConversionModelInfo instance should be created.</param>	
		/// <returns>Created ConversionModelInfo instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (ConversionModelInfo)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.PDE.ModelingDSL.ConversionModelInfo(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one ConversionModelInfo instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ConversionModelInfo instance to be serialized.</param>
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
		/// <param name="element">ConversionModelInfo instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ConversionModelInfo instance = element as global::Tum.PDE.ModelingDSL.ConversionModelInfo;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ConversionModelInfo");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeHasModelChanged(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property HasModelChanged that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ConversionModelInfo instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeHasModelChanged(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ConversionModelInfo instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// HasModelChanged
			object valueHasModelChanged = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "HasModelChanged" ,instance.HasModelChanged, typeof(global::System.Boolean?), true);
			if( valueHasModelChanged != null )
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "HasModelChanged", valueHasModelChanged.ToString());
			else
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "HasModelChanged", "");
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ConversionModelInfo instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ConversionModelInfo instance = element as global::Tum.PDE.ModelingDSL.ConversionModelInfo;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ConversionModelInfo");
			
		}
		
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLReferenceRelationshipSerializer for DomainClass ReferenceRelationship.
	/// </summary>
	public partial class PDEModelingDSLReferenceRelationshipSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLReferenceRelationshipSerializer Constructor
		/// </summary>
		public PDEModelingDSLReferenceRelationshipSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ReferenceRelationship.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "ReferenceRelationship";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one ReferenceRelationship instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the ReferenceRelationship element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory ReferenceRelationship instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "ReferenceRelationship");
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
		/// <param name="element">In-memory ReferenceRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship instanceOfReferenceRelationship = element as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeSourceMultiplicity(serializationContext, instanceOfReferenceRelationship, reader);
			}
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeTargetMultiplicity(serializationContext, instanceOfReferenceRelationship, reader);
			}
		}
		
		/// <summary>
		/// Read property SourceMultiplicity that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeSourceMultiplicity(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlReader reader)
		{
			// SourceMultiplicity
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "SourceMultiplicity");
				if( attribValue != null )
					instance.SourceMultiplicity = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "SourceMultiplicity", attribValue, typeof(global::Tum.PDE.ModelingDSL.Multiplicity?), true) as global::Tum.PDE.ModelingDSL.Multiplicity?;
			}
					
		}
		/// <summary>
		/// Read property TargetMultiplicity that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeTargetMultiplicity(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlReader reader)
		{
			// TargetMultiplicity
			if (!serializationContext.Result.Failed)
			{
				string attribValue = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "TargetMultiplicity");
				if( attribValue != null )
					instance.TargetMultiplicity = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "TargetMultiplicity", attribValue, typeof(global::Tum.PDE.ModelingDSL.Multiplicity?), true) as global::Tum.PDE.ModelingDSL.Multiplicity?;
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
		/// <param name="element">In-memory ReferenceRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship instance = element as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceRelationship!");
	
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
		/// <param name="instance">In-memory ReferenceRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipRoleReferenceRelationshipSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipRoleReferenceRelationshipTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel ReferenceRelationship role Source that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleReferenceRelationshipSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "SourceRef")
			{
				string attribValueSource = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueSource != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueSource);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId, instance.Id, id, System.Guid.Empty);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		/// <summary>
		/// Read ref. rel ReferenceRelationship role Target that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleReferenceRelationshipTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "TargetRef")
			{
				string attribValueTarget = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueTarget != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueTarget);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId, instance.Id, System.Guid.Empty, id);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		
		#region TryCreateInstance & TryCreateDerivedInstance
		/// <summary>
		/// This method creates a correct instance of ReferenceRelationship based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized ReferenceRelationship, a new ReferenceRelationship instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created ReferenceRelationship instance, or null if the reader is not pointing to a serialized ReferenceRelationship instance.</returns>
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
	
			return this.InternalTryCreateInstance(serializationContext, reader, partition, false /* include the type itself */);
		}
	
		/// <summary>
		/// This method creates a correct derived instance of ReferenceRelationship based on the tag currently pointed by the reader.
		/// Note that the difference between this method and the above one is that this method will never create an instance of the
		/// ReferenceRelationship type itself, only derived types are checked.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>		
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <returns>Created instance that derives from ReferenceRelationship, or null if the reader is not pointing to such a serialized instance.</returns>
		public override DslModeling::ElementLink TryCreateDerivedInstance (DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
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
	
			return this.InternalTryCreateInstance(serializationContext, reader, partition, true /* derived types only */) as DslModeling::ElementLink;
		}
	
		/// <summary>
		/// Internal helper method for TryCreateInstance() and TryCreateDerivedInstance().
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <param name="derivedTypesOnly">If true, this method will only check derived types, but not the domain class iitself.</param>
		private DslModeling::ModelElement InternalTryCreateInstance (DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition, bool derivedTypesOnly)
		{
			DslModeling::ModelElement result = null;
			if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				string localName = reader.LocalName;
				if (!derivedTypesOnly && string.Compare (localName, this.XmlTagName, global::System.StringComparison.CurrentCulture) == 0)
				{	// New "ReferenceRelationship" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "ReferenceRelationship".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableReferenceRelationship(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived relationship instance.
						//PDEModelingDSLReferenceRelationshipSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLReferenceRelationshipSerializer;
						PDEModelingDSLReferenceRelationshipSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLReferenceRelationshipSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of ReferenceRelationship based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ReferenceRelationship.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ReferenceRelationship instance should be created.</param>	
		/// <returns>Created ReferenceRelationship instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (ReferenceRelationship)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				
				// Create the link with place-holder role-players.
				return new global::Tum.PDE.ModelingDSL.ReferenceRelationship(
					partition,
					new DslModeling::RoleAssignment[] {
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId), 
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId)
					},
					new DslModeling::PropertyAssignment[] {
						new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id)
					}
				);
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one ReferenceRelationship instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferenceRelationship instance to be serialized.</param>
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
		/// <param name="element">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship instance = element as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceRelationship");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeSourceMultiplicity(serializationContext, instance, writer, options);
			}
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeTargetMultiplicity(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property SourceMultiplicity that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeSourceMultiplicity(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// SourceMultiplicity
			object valueSourceMultiplicity = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "SourceMultiplicity" ,instance.SourceMultiplicity, typeof(global::Tum.PDE.ModelingDSL.Multiplicity?), true);
			if( valueSourceMultiplicity != null )
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "SourceMultiplicity", valueSourceMultiplicity.ToString());
			else
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "SourceMultiplicity", "");
		}
		/// <summary>
		/// Write property TargetMultiplicity that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeTargetMultiplicity(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// TargetMultiplicity
			object valueTargetMultiplicity = global::Tum.PDE.ModelingDSL.PDEModelingDSLSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "TargetMultiplicity" ,instance.TargetMultiplicity, typeof(global::Tum.PDE.ModelingDSL.Multiplicity?), true);
			if( valueTargetMultiplicity != null )
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "TargetMultiplicity", valueTargetMultiplicity.ToString());
			else
				PDEModelingDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "TargetMultiplicity", "");
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.ReferenceRelationship instance = element as global::Tum.PDE.ModelingDSL.ReferenceRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of ReferenceRelationship");
			
			WriteReferenceRelationshipRoleReferenceRelationshipSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipRoleReferenceRelationshipTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel ReferenceRelationship role Source that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleReferenceRelationshipSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ReferenceRelationship Roles
			if (!serializationContext.Result.Failed)
			{
				// Write Source link id
				writer.WriteStartElement("SourceRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.Source.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel ReferenceRelationship role Target that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">ReferenceRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleReferenceRelationshipTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.ReferenceRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship ReferenceRelationship Roles
			if (!serializationContext.Result.Failed)
			{
				// Write Target link id
				writer.WriteStartElement("TargetRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.Target.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		
		
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLEmbeddingRelationshipBaseSerializer for DomainClass EmbeddingRelationship.
	/// </summary>
	public abstract partial class PDEModelingDSLEmbeddingRelationshipBaseSerializer : Tum.PDE.ModelingDSL.PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLEmbeddingRelationshipBaseSerializer Constructor
		/// </summary>
		protected PDEModelingDSLEmbeddingRelationshipBaseSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EmbeddingRelationship.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "EmbeddingRelationship";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one EmbeddingRelationship instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the EmbeddingRelationship element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory EmbeddingRelationship instance that will get the deserialized data.</param>
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
							PDEModelingDSLSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "EmbeddingRelationship");
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
		/// <param name="element">In-memory EmbeddingRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship instanceOfEmbeddingRelationship = element as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
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
		/// <param name="element">In-memory EmbeddingRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance = element as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingRelationship!");
	
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
		/// <param name="instance">In-memory EmbeddingRelationship instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipRoleEmbeddingRelationshipChild(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipRoleEmbeddingRelationshipParent(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel EmbeddingRelationship role Child that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleEmbeddingRelationshipChild(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "ChildRef")
			{
				string attribValueChild = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueChild != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueChild);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId, instance.Id, id, System.Guid.Empty);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		/// <summary>
		/// Read ref. rel EmbeddingRelationship role Parent that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleEmbeddingRelationshipParent(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "ParentRef")
			{
				string attribValueParent = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueParent != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueParent);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId, instance.Id, System.Guid.Empty, id);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		
		#region TryCreateInstance & TryCreateDerivedInstance
		/// <summary>
		/// This method creates a correct instance of EmbeddingRelationship based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized EmbeddingRelationship, a new EmbeddingRelationship instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created EmbeddingRelationship instance, or null if the reader is not pointing to a serialized EmbeddingRelationship instance.</returns>
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
	
			return this.InternalTryCreateInstance(serializationContext, reader, partition, false /* include the type itself */);
		}
	
		/// <summary>
		/// This method creates a correct derived instance of EmbeddingRelationship based on the tag currently pointed by the reader.
		/// Note that the difference between this method and the above one is that this method will never create an instance of the
		/// EmbeddingRelationship type itself, only derived types are checked.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>		
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <returns>Created instance that derives from EmbeddingRelationship, or null if the reader is not pointing to such a serialized instance.</returns>
		public override DslModeling::ElementLink TryCreateDerivedInstance (DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
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
	
			return this.InternalTryCreateInstance(serializationContext, reader, partition, true /* derived types only */) as DslModeling::ElementLink;
		}
	
		/// <summary>
		/// Internal helper method for TryCreateInstance() and TryCreateDerivedInstance().
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <param name="derivedTypesOnly">If true, this method will only check derived types, but not the domain class iitself.</param>
		private DslModeling::ModelElement InternalTryCreateInstance (DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition, bool derivedTypesOnly)
		{
			DslModeling::ModelElement result = null;
			if (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				string localName = reader.LocalName;
				if (!derivedTypesOnly && string.Compare (localName, this.XmlTagName, global::System.StringComparison.CurrentCulture) == 0)
				{	// New "EmbeddingRelationship" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "EmbeddingRelationship".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableEmbeddingRelationship(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived relationship instance.
						//PDEModelingDSLEmbeddingRelationshipBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLEmbeddingRelationshipBaseSerializer;
						PDEModelingDSLEmbeddingRelationshipBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLEmbeddingRelationshipBaseSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of EmbeddingRelationship based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of EmbeddingRelationship.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new EmbeddingRelationship instance should be created.</param>	
		/// <returns>Created EmbeddingRelationship instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = PDEModelingDSLDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (EmbeddingRelationship)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				
				// Create the link with place-holder role-players.
				return new global::Tum.PDE.ModelingDSL.EmbeddingRelationship(
					partition,
					new DslModeling::RoleAssignment[] {
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId), 
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId)
					},
					new DslModeling::PropertyAssignment[] {
						new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id)
					}
				);
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				PDEModelingDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one EmbeddingRelationship instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddingRelationship instance to be serialized.</param>
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
		/// <param name="element">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance = element as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingRelationship");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance = element as global::Tum.PDE.ModelingDSL.EmbeddingRelationship;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EmbeddingRelationship");
			
			WriteReferenceRelationshipRoleEmbeddingRelationshipChild(serializationContext, instance, writer, options);
			WriteReferenceRelationshipRoleEmbeddingRelationshipParent(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel EmbeddingRelationship role Child that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleEmbeddingRelationshipChild(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship EmbeddingRelationship Roles
			if (!serializationContext.Result.Failed)
			{
				// Write Child link id
				writer.WriteStartElement("ChildRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.Child.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel EmbeddingRelationship role Parent that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">EmbeddingRelationship instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleEmbeddingRelationshipParent(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship EmbeddingRelationship Roles
			if (!serializationContext.Result.Failed)
			{
				// Write Parent link id
				writer.WriteStartElement("ParentRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.Parent.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		
		
		#endregion
	}
	
	/// <summary>
	/// Serializer PDEModelingDSLEmbeddingRelationshipSerializer for DomainClass EmbeddingRelationship.
	/// </summary>
	public partial class PDEModelingDSLEmbeddingRelationshipSerializer : PDEModelingDSLEmbeddingRelationshipBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLEmbeddingRelationshipSerializer Constructor
		/// </summary>
		public PDEModelingDSLEmbeddingRelationshipSerializer ()
			: base ()
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer for DomainClass BaseElementSourceReferencesBaseElementTarget.
	/// </summary>
	public abstract partial class PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer : DslEditorModeling::SerializationDomainRelationshipXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer Constructor
		/// </summary>
		protected PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer ()
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
		/// Public Read() method that deserializes one BaseElementSourceReferencesBaseElementTarget instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the BaseElementSourceReferencesBaseElementTarget element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory BaseElementSourceReferencesBaseElementTarget instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory BaseElementSourceReferencesBaseElementTarget instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instanceOfBaseElementSourceReferencesBaseElementTarget = element as global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget;
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
		/// <param name="element">In-memory BaseElementSourceReferencesBaseElementTarget instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance = element as global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElementSourceReferencesBaseElementTarget!");
	
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
		/// <param name="instance">In-memory BaseElementSourceReferencesBaseElementTarget instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel BaseElementSourceReferencesBaseElementTarget role BaseElementSource that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "BaseElementSourceRef")
			{
				string attribValueBaseElementSource = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueBaseElementSource != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueBaseElementSource);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId, instance.Id, id, System.Guid.Empty);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		/// <summary>
		/// Read ref. rel BaseElementSourceReferencesBaseElementTarget role BaseElementTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "BaseElementTargetRef")
			{
				string attribValueBaseElementTarget = PDEModelingDSLSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueBaseElementTarget != null )
				{
					System.Guid id = PDEModelingDSLSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueBaseElementTarget);
					if( id != System.Guid.Empty)
					{
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId, instance.Id, System.Guid.Empty, id);
						Tum.PDE.ModelingDSL.PDEModelingDSLSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		
		#region TryCreateInstance & TryCreateDerivedInstance
		/// <summary>
		/// This method creates a correct instance of BaseElementSourceReferencesBaseElementTarget based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized BaseElementSourceReferencesBaseElementTarget, a new BaseElementSourceReferencesBaseElementTarget instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created BaseElementSourceReferencesBaseElementTarget instance, or null if the reader is not pointing to a serialized BaseElementSourceReferencesBaseElementTarget instance.</returns>
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
				// Check for derived classes of "BaseElementSourceReferencesBaseElementTarget".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableBaseElementSourceReferencesBaseElementTarget(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived relationship instance.
					//PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer;
					PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of BaseElementSourceReferencesBaseElementTarget based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of BaseElementSourceReferencesBaseElementTarget.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new BaseElementSourceReferencesBaseElementTarget instance should be created.</param>	
		/// <returns>Created BaseElementSourceReferencesBaseElementTarget instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
	
		/// <summary>
		/// This method creates a correct derived instance of BaseElementSourceReferencesBaseElementTarget based on the tag currently pointed by the reader.
		/// Note that the difference between this method and the above one is that this method will never create an instance of the
		/// BaseElementSourceReferencesBaseElementTarget type itself, only derived types are checked.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>		
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <returns>Created instance that derives from BaseElementSourceReferencesBaseElementTarget, or null if the reader is not pointing to such a serialized instance.</returns>
		public override DslModeling::ElementLink TryCreateDerivedInstance (DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{	// Abstract relationship, so it's the same as TryCreateInstance().
			return this.TryCreateInstance(serializationContext, reader, partition) as DslModeling::ElementLink;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one BaseElementSourceReferencesBaseElementTarget instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
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
		/// <param name="element">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance = element as global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElementSourceReferencesBaseElementTarget");
			
			// Domain Element Id
			string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(PDEModelingDSLSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance = element as global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of BaseElementSourceReferencesBaseElementTarget");
			
			WriteReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel BaseElementSourceReferencesBaseElementTarget role BaseElementSource that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementSource(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship BaseElementSourceReferencesBaseElementTarget Roles
			if (!serializationContext.Result.Failed)
			{
				// Write BaseElementSource link id
				writer.WriteStartElement("BaseElementSourceRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.BaseElementSource.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel BaseElementSourceReferencesBaseElementTarget role BaseElementTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">BaseElementSourceReferencesBaseElementTarget instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleBaseElementSourceReferencesBaseElementTargetBaseElementTarget(DslModeling::SerializationContext serializationContext, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship BaseElementSourceReferencesBaseElementTarget Roles
			if (!serializationContext.Result.Failed)
			{
				// Write BaseElementTarget link id
				writer.WriteStartElement("BaseElementTargetRef");
				string valueId = PDEModelingDSLSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.BaseElementTarget.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		
		
		#endregion
	}
	
	/// <summary>
	/// Serializer PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer for DomainClass BaseElementSourceReferencesBaseElementTarget.
	/// </summary>
	public partial class PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer : PDEModelingDSLBaseElementSourceReferencesBaseElementTargetBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer Constructor
		/// </summary>
		public PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer ()
			: base ()
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior PDEModelingDSLSerializationBehavior.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class PDEModelingDSLSerializationBehavior : PDEModelingDSLSerializationBehaviorBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static PDEModelingDSLSerializationBehavior instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static PDEModelingDSLSerializationBehavior Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (PDEModelingDSLSerializationBehavior.instance == null)
					PDEModelingDSLSerializationBehavior.instance = new PDEModelingDSLSerializationBehavior ();
				return PDEModelingDSLSerializationBehavior.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private PDEModelingDSLSerializationBehavior() : base() { }
		#endregion
	}
	
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior PDEModelingDSLSerializationBehavior.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class PDEModelingDSLSerializationBehaviorBase : DslModeling::DomainXmlSerializationBehavior
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
		protected PDEModelingDSLSerializationBehaviorBase() : base() { }
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
				if (PDEModelingDSLSerializationBehavior.serializerTypes == null)
				{
					global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> customSerializerTypes = this.CustomSerializerTypes;
					int customSerializerCount = (customSerializerTypes == null ? 0 : customSerializerTypes.Count);
					PDEModelingDSLSerializationBehavior.serializerTypes = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry>(26 + customSerializerCount);

					#region Serializers defined in this model
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainModel.DomainClassId, typeof(PDEModelingDSLDomainModelSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainElement.DomainClassId, typeof(PDEModelingDSLDomainElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(BaseElement.DomainClassId, typeof(PDEModelingDSLBaseElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ReferenceableElement.DomainClassId, typeof(PDEModelingDSLReferenceableElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EmbeddableElement.DomainClassId, typeof(PDEModelingDSLEmbeddableElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(NamedDomainElement.DomainClassId, typeof(PDEModelingDSLNamedDomainElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(AttributedDomainElement.DomainClassId, typeof(PDEModelingDSLAttributedDomainElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(BaseDomainElement.DomainClassId, typeof(PDEModelingDSLBaseDomainElementSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainProperty.DomainClassId, typeof(PDEModelingDSLDomainPropertySerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainElements.DomainClassId, typeof(PDEModelingDSLDomainElementsSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainTypes.DomainClassId, typeof(PDEModelingDSLDomainTypesSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainType.DomainClassId, typeof(PDEModelingDSLDomainTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ExternalType.DomainClassId, typeof(PDEModelingDSLExternalTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainEnumeration.DomainClassId, typeof(PDEModelingDSLDomainEnumerationSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EnumerationLiteral.DomainClassId, typeof(PDEModelingDSLEnumerationLiteralSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DETypes.DomainClassId, typeof(PDEModelingDSLDETypesSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DRTypes.DomainClassId, typeof(PDEModelingDSLDRTypesSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DEType.DomainClassId, typeof(PDEModelingDSLDETypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DRType.DomainClassId, typeof(PDEModelingDSLDRTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(BaseDomainElementType.DomainClassId, typeof(PDEModelingDSLBaseDomainElementTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ReferencingDRType.DomainClassId, typeof(PDEModelingDSLReferencingDRTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EmbeddingDRType.DomainClassId, typeof(PDEModelingDSLEmbeddingDRTypeSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ConversionModelInfo.DomainClassId, typeof(PDEModelingDSLConversionModelInfoSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ReferenceRelationship.DomainClassId, typeof(PDEModelingDSLReferenceRelationshipSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EmbeddingRelationship.DomainClassId, typeof(PDEModelingDSLEmbeddingRelationshipSerializer)));
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(BaseElementSourceReferencesBaseElementTarget.DomainClassId, typeof(PDEModelingDSLBaseElementSourceReferencesBaseElementTargetSerializer)));
					#endregion
				
					#region Serializers of the diagram model defined in this model
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagram.DomainClassId, typeof(PDEModelingDSLDesignerDiagramSerializer)));					
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ReferenceShape.DomainClassId, typeof(PDEModelingDSLReferenceShapeSerializer)));					
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EmbeddingShape.DomainClassId, typeof(PDEModelingDSLEmbeddingShapeSerializer)));					
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DomainElementShape.DomainClassId, typeof(PDEModelingDSLDomainElementShapeSerializer)));					
					PDEModelingDSLSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(ConversionDiagram.DomainClassId, typeof(PDEModelingDSLConversionDiagramSerializer)));					
	
					#endregion
				
					// Custom ones
					if (customSerializerCount > 0)
					{
						PDEModelingDSLSerializationBehavior.serializerTypes.AddRange(customSerializerTypes);
					}
				}
				return PDEModelingDSLSerializationBehavior.serializerTypes.AsReadOnly();
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
				if (PDEModelingDSLSerializationBehavior.namespaceEntries == null)
				{
					PDEModelingDSLSerializationBehavior.namespaceEntries = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry>();
				}
				return PDEModelingDSLSerializationBehavior.namespaceEntries.AsReadOnly();
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

namespace Tum.PDE.ModelingDSL
{
    /// <summary>
    /// Utility class to provide serialization messages
    /// </summary>
    public static partial class PDEModelingDSLSerializationBehaviorSerializationMessages
    {
    	/// <summary>
    	/// ResourceManager to get serialization messages from.
    	/// </summary>
    	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
    	public static global::System.Resources.ResourceManager ResourceManager
    	{
    		[global::System.Diagnostics.DebuggerStepThrough]
    		get { return PDEModelingDSLDomainModel.SingletonResourceManager; }
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

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// A ModelDataSerializationPostProcessor implementation.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class PDEModelingDSLSerializationPostProcessor : DslEditorModeling::ModelDataSerializationPostProcessor
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static PDEModelingDSLSerializationPostProcessor instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static PDEModelingDSLSerializationPostProcessor Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (PDEModelingDSLSerializationPostProcessor.instance == null)
					PDEModelingDSLSerializationPostProcessor.instance = new PDEModelingDSLSerializationPostProcessor ();
				return PDEModelingDSLSerializationPostProcessor.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private PDEModelingDSLSerializationPostProcessor() : base() { }
		#endregion
	
		#region Methods
		/// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already reseted models.</param>
        public override void Reset(System.Collections.Generic.List<string> alreadyProcessedModels)
        {
			dictionary.Clear();
			alreadyProcessedModels.Add("PDEModelingDSL");

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
			
			alreadyProcessedModels.Add("PDEModelingDSL");
		}
		#endregion
	}
}
