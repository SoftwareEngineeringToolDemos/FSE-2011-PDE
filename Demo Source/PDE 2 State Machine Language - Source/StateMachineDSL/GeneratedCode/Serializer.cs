 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageStateMachineDomainModelSerializer for DomainClass StateMachineDomainModel.
	/// </summary>
	public partial class StateMachineLanguageStateMachineDomainModelSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageStateMachineDomainModelSerializer Constructor
		/// </summary>
		public StateMachineLanguageStateMachineDomainModelSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of StateMachineDomainModel.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "StateMachineDomainModel";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one StateMachineDomainModel instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the StateMachineDomainModel element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory StateMachineDomainModel instance that will get the deserialized data.</param>
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
							StateMachineLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "StateMachineDomainModel");
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
		/// <param name="element">In-memory StateMachineDomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StateMachineDomainModel instanceOfStateMachineDomainModel = element as global::Tum.StateMachineDSL.StateMachineDomainModel;
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
		/// <param name="element">In-memory StateMachineDomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StateMachineDomainModel instance = element as global::Tum.StateMachineDSL.StateMachineDomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateMachineDomainModel!");
	
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
		/// <param name="instance">In-memory StateMachineDomainModel instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadEmbeddingRelationshipStateMachineDomainModelHasState(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipStateMachineDomainModelHasStartState(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadEmbeddingRelationshipStateMachineDomainModelHasEndState(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read emb. rel StateMachineDomainModelHasState that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipStateMachineDomainModelHasState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "State" )
			{
				info = global::Tum.StateMachineDSL.State.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId, global::Tum.StateMachineDSL.State.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.StateMachineDSL.State child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.StateMachineDSL.State;
					if( child0 != null )
					{
						new global::Tum.StateMachineDSL.StateMachineDomainModelHasState(instance, child0);
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
		/// Read emb. rel StateMachineDomainModelHasStartState that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipStateMachineDomainModelHasStartState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "StartState" )
			{
				info = global::Tum.StateMachineDSL.StartState.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId, global::Tum.StateMachineDSL.StartState.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.StateMachineDSL.StartState child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.StateMachineDSL.StartState;
					if( child0 != null )
					{
						new global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState(instance, child0);
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
		/// Read emb. rel StateMachineDomainModelHasEndState that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadEmbeddingRelationshipStateMachineDomainModelHasEndState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			System.Guid info;
			if( readerLocalName == "EndState" )
			{
				info = global::Tum.StateMachineDSL.EndState.DomainClassId;
			}
			else // derived classes
			{
				info = DslEditorModeling::SerializationHelper.TryGetFirstEmbeddedDerivedNameType(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId, global::Tum.StateMachineDSL.EndState.DomainClassId, readerLocalName);
			}
			if( info != System.Guid.Empty )
			{
				if (!serializationContext.Result.Failed)
				{
					DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(info);
					global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for " + info + "!");
					global::Tum.StateMachineDSL.EndState child0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.StateMachineDSL.EndState;
					if( child0 != null )
					{
						new global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState(instance, child0);
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
		/// This method creates a correct instance of StateMachineDomainModel based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized StateMachineDomainModel, a new StateMachineDomainModel instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created StateMachineDomainModel instance, or null if the reader is not pointing to a serialized StateMachineDomainModel instance.</returns>
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
				{	// New "StateMachineDomainModel" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "StateMachineDomainModel".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableStateMachineDomainModel(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//StateMachineLanguageStateMachineDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageStateMachineDomainModelSerializer;
						StateMachineLanguageStateMachineDomainModelSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageStateMachineDomainModelSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of StateMachineDomainModel based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of StateMachineDomainModel.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new StateMachineDomainModel instance should be created.</param>	
		/// <returns>Created StateMachineDomainModel instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = StateMachineLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (StateMachineDomainModel)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.StateMachineDSL.StateMachineDomainModel(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one StateMachineDomainModel instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StateMachineDomainModel instance to be serialized.</param>
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
				StateMachineLanguageSerializationHelper.Instance.WriteSchemaDefinitions(writer, "DefaultContext", "StateMachineDomainModel");
			
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
		/// <param name="element">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StateMachineDomainModel instance = element as global::Tum.StateMachineDSL.StateMachineDomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateMachineDomainModel");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StateMachineDomainModel instance = element as global::Tum.StateMachineDSL.StateMachineDomainModel;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateMachineDomainModel");
			
			WriteEmbeddingRelationshipStateMachineDomainModelHasState(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipStateMachineDomainModelHasStartState(serializationContext, instance, writer, options);
			WriteEmbeddingRelationshipStateMachineDomainModelHasEndState(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write emb. rel StateMachineDomainModelHasState that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipStateMachineDomainModelHasState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship StateMachineDomainModelHasState
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> allMStateMachineDomainModelHasStateInstances = global::Tum.StateMachineDSL.StateMachineDomainModelHasState.GetLinksToState(instance);
			foreach(global::Tum.StateMachineDSL.StateMachineDomainModelHasState allMStateMachineDomainModelHasStateInstance in allMStateMachineDomainModelHasStateInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMStateMachineDomainModelHasStateInstance.State;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel StateMachineDomainModelHasStartState that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipStateMachineDomainModelHasStartState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship StateMachineDomainModelHasStartState
			global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState allMStateMachineDomainModelHasStartStateInstance = global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.GetLinkToStartState(instance);
			if( allMStateMachineDomainModelHasStartStateInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMStateMachineDomainModelHasStartStateInstance.StartState;
					DslEditorModeling::SerializationDomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
					global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
					targetSerializer.Write(serializationContext, targetElement, writer, options);
				}
			}
			#endregion		
		}
		/// <summary>
		/// Write emb. rel StateMachineDomainModelHasEndState that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateMachineDomainModel instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteEmbeddingRelationshipStateMachineDomainModelHasEndState(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateMachineDomainModel instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
		
			#region Save EmbeddingRelationship StateMachineDomainModelHasEndState
			global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState allMStateMachineDomainModelHasEndStateInstance = global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.GetLinkToEndState(instance);
			if( allMStateMachineDomainModelHasEndStateInstance != null )
			{
				if (!serializationContext.Result.Failed)
				{
					// No need to serialize the relationship itself, just serialize the role-player directly.
					DslModeling::ModelElement targetElement = allMStateMachineDomainModelHasEndStateInstance.EndState;
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
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageStateBaseSerializer for DomainClass StateBase.
	/// </summary>
	public partial class StateMachineLanguageStateBaseSerializer : DslEditorModeling::SerializationDomainClassXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageStateBaseSerializer Constructor
		/// </summary>
		public StateMachineLanguageStateBaseSerializer ()
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
		/// Public Read() method that deserializes one StateBase instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the StateBase element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory StateBase instance that will get the deserialized data.</param>
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
		/// <param name="element">In-memory StateBase instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StateBase instanceOfStateBase = element as global::Tum.StateMachineDSL.StateBase;
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
		/// <param name="element">In-memory StateBase instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StateBase instance = element as global::Tum.StateMachineDSL.StateBase;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateBase!");
	
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
		/// <param name="instance">In-memory StateBase instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateBase instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipTransition(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel Transition that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateBase instance to be serialized.</param>
		/// <param name="readr">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipTransition(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateBase instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName == "Transition")
			{
				DslModeling::DomainClassXmlSerializer serializer0 = serializationContext.Directory.GetSerializer(global::Tum.StateMachineDSL.Transition.DomainClassId);
				global::System.Diagnostics.Debug.Assert(serializer0 != null, "Cannot find serializer for Transition!");
				global::Tum.StateMachineDSL.Transition connection0 = serializer0.TryCreateInstance(serializationContext, reader, instance.Partition) as global::Tum.StateMachineDSL.Transition;
				if( connection0 != null )
				{
					connection0.StateBaseSource = instance;
					serializer0.Read(serializationContext, connection0, reader);
					
					if( connection0.StateBaseSource == null ||
						connection0.StateBaseTarget == null )
							Tum.StateMachineDSL.StateMachineLanguageSerializationPostProcessor.Instance.AddRelationshipTrackData(connection0.Id);
				}
				else
					DslModeling::SerializationUtilities.Skip(reader);
				return true;
			}
	
			return false;
		}
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of StateBase based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized StateBase, a new StateBase instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created StateBase instance, or null if the reader is not pointing to a serialized StateBase instance.</returns>
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
				// Check for derived classes of "StateBase".
				//if (derivedClasses == null)
				//	ConstructDerivedClassesLookupTableStateBase(serializationContext.Directory, partition.DomainDataDirectory);
				//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
				//DslModeling::DomainClassInfo derivedClass = null;
				System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.StateBase.DomainClassId, localName);
				if( derivedType != System.Guid.Empty )
				//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
				{	// New derived class instance.
					//StateMachineLanguageStateBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageStateBaseSerializer;
					StateMachineLanguageStateBaseSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageStateBaseSerializer;
					global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
					result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of StateBase based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of StateBase.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new StateBase instance should be created.</param>	
		/// <returns>Created StateBase instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			// Abstract class, cannot be serialized.
			throw new global::System.NotSupportedException();
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one StateBase instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StateBase instance to be serialized.</param>
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
		/// <param name="element">StateBase instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StateBase instance = element as global::Tum.StateMachineDSL.StateBase;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateBase");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StateBase instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StateBase instance = element as global::Tum.StateMachineDSL.StateBase;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StateBase");
			
			WriteReferenceRelationshipTransition(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel Transition that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">StateBase instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipTransition(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StateBase instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship Transition
			global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.Transition> allMTransitionInstances = global::Tum.StateMachineDSL.Transition.GetLinksToStateBaseTarget(instance);
			foreach(global::Tum.StateMachineDSL.Transition allMTransitionInstance in allMTransitionInstances)
			{
				if (!serializationContext.Result.Failed)
				{
					// Full serialization mode
					DslModeling::ModelElement targetElement = allMTransitionInstance;
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
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageStateSerializer for DomainClass State.
	/// </summary>
	public partial class StateMachineLanguageStateSerializer : Tum.StateMachineDSL.StateMachineLanguageStateBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageStateSerializer Constructor
		/// </summary>
		public StateMachineLanguageStateSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of State.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "State";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one State instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the State element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory State instance that will get the deserialized data.</param>
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
							StateMachineLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "State");
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
		/// <param name="element">In-memory State instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.State instanceOfState = element as global::Tum.StateMachineDSL.State;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeName(serializationContext, instanceOfState, reader);
			}
		}
		
		/// <summary>
		/// Read property Name that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">State instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.State instance, global::System.Xml.XmlReader reader)
		{
			// Name
			if (!serializationContext.Result.Failed)
			{
				string attribValue = StateMachineLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Name");
				if( attribValue != null )
					instance.Name = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Name", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory State instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.State instance = element as global::Tum.StateMachineDSL.State;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of State!");
	
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
		/// <param name="instance">In-memory State instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.State instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipTransition(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of State based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized State, a new State instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created State instance, or null if the reader is not pointing to a serialized State instance.</returns>
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
				{	// New "State" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "State".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableState(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.State.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//StateMachineLanguageStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageStateSerializer;
						StateMachineLanguageStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageStateSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of State based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of State.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new State instance should be created.</param>	
		/// <returns>Created State instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = StateMachineLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (State)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.StateMachineDSL.State(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one State instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">State instance to be serialized.</param>
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
		/// <param name="element">State instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.State instance = element as global::Tum.StateMachineDSL.State;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of State");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeName(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Name that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">State instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeName(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.State instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Name
			object valueName = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Name" ,instance.Name, typeof(global::System.String), true);
			if( valueName != null )
			{
				StateMachineLanguageSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Name", valueName.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">State instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.State instance = element as global::Tum.StateMachineDSL.State;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of State");
			
			WriteReferenceRelationshipTransition(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageStartStateSerializer for DomainClass StartState.
	/// </summary>
	public partial class StateMachineLanguageStartStateSerializer : Tum.StateMachineDSL.StateMachineLanguageStateBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageStartStateSerializer Constructor
		/// </summary>
		public StateMachineLanguageStartStateSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of StartState.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "StartState";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one StartState instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the StartState element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory StartState instance that will get the deserialized data.</param>
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
							StateMachineLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "StartState");
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
		/// <param name="element">In-memory StartState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StartState instanceOfStartState = element as global::Tum.StateMachineDSL.StartState;
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
		/// <param name="element">In-memory StartState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.StartState instance = element as global::Tum.StateMachineDSL.StartState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StartState!");
	
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
		/// <param name="instance">In-memory StartState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.StartState instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipTransition(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of StartState based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized StartState, a new StartState instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created StartState instance, or null if the reader is not pointing to a serialized StartState instance.</returns>
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
				{	// New "StartState" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "StartState".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableStartState(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.StartState.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//StateMachineLanguageStartStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageStartStateSerializer;
						StateMachineLanguageStartStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageStartStateSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of StartState based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of StartState.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new StartState instance should be created.</param>	
		/// <returns>Created StartState instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = StateMachineLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (StartState)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.StateMachineDSL.StartState(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one StartState instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StartState instance to be serialized.</param>
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
		/// <param name="element">StartState instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StartState instance = element as global::Tum.StateMachineDSL.StartState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StartState");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">StartState instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.StartState instance = element as global::Tum.StateMachineDSL.StartState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of StartState");
			
			WriteReferenceRelationshipTransition(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageEndStateSerializer for DomainClass EndState.
	/// </summary>
	public partial class StateMachineLanguageEndStateSerializer : Tum.StateMachineDSL.StateMachineLanguageStateBaseSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageEndStateSerializer Constructor
		/// </summary>
		public StateMachineLanguageEndStateSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EndState.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "EndState";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one EndState instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the EndState element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory EndState instance that will get the deserialized data.</param>
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
							StateMachineLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "EndState");
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
		/// <param name="element">In-memory EndState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.EndState instanceOfEndState = element as global::Tum.StateMachineDSL.EndState;
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
		/// <param name="element">In-memory EndState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.EndState instance = element as global::Tum.StateMachineDSL.EndState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EndState!");
	
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
		/// <param name="instance">In-memory EndState instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.EndState instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipTransition(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		
		#region TryCreateInstance
		/// <summary>
		/// This method creates a correct instance of EndState based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized EndState, a new EndState instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created EndState instance, or null if the reader is not pointing to a serialized EndState instance.</returns>
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
				{	// New "EndState" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "EndState".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableEndState(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.EndState.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived class instance.
						//StateMachineLanguageEndStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageEndStateSerializer;
						StateMachineLanguageEndStateSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageEndStateSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of EndState based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of EndState.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new EndState instance should be created.</param>	
		/// <returns>Created EndState instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = StateMachineLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (EndState)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				return new global::Tum.StateMachineDSL.EndState(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one EndState instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EndState instance to be serialized.</param>
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
		/// <param name="element">EndState instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.EndState instance = element as global::Tum.StateMachineDSL.EndState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EndState");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
		}
	
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">EndState instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.EndState instance = element as global::Tum.StateMachineDSL.EndState;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of EndState");
			
			WriteReferenceRelationshipTransition(serializationContext, instance, writer, options);
		}
		
		
		
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateMachineLanguageTransitionSerializer for DomainClass Transition.
	/// </summary>
	public partial class StateMachineLanguageTransitionSerializer : DslEditorModeling::SerializationDomainRelationshipXmlSerializer
	{
		#region Constructor
		/// <summary>
		/// StateMachineLanguageTransitionSerializer Constructor
		/// </summary>
		public StateMachineLanguageTransitionSerializer ()
			: base ()
		{
		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// This is the XML tag name used to serialize an instance of Transition.
		/// </summary>
		public override string XmlTagName
		{
			get{
				return "Transition";
			}
		}
			
		#endregion
	
		#region Read
		/// <summary>
		/// Public Read() method that deserializes one Transition instance from XML.
		/// </summary>
		/// <remarks>
		/// When this method is called, caller guarantees that the passed-in XML reader is positioned at the open XML tag
		/// of the Transition element that is about to be deserialized. 
		/// The method needs to ensure that when it returns, the reader is positioned at the open XML tag of the next sibling element,
		/// or the close tag of the parent element (or EOF).
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">In-memory Transition instance that will get the deserialized data.</param>
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
							StateMachineLanguageSerializationBehaviorSerializationMessages.UnexpectedXmlElement(serializationContext, reader, "Transition");
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
		/// <param name="element">In-memory Transition instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void ReadPropertiesFromAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.Transition instanceOfTransition = element as global::Tum.StateMachineDSL.Transition;
			if (!serializationContext.Result.Failed)
			{
				ReadPropertyAsAttributeCondition(serializationContext, instanceOfTransition, reader);
			}
		}
		
		/// <summary>
		/// Read property Condition that needed to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="reader">XmlReader.</param> 
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void ReadPropertyAsAttributeCondition(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlReader reader)
		{
			// Condition
			if (!serializationContext.Result.Failed)
			{
				string attribValue = StateMachineLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "Condition");
				if( attribValue != null )
					instance.Condition = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.ConvertTypedObjectFrom(serializationContext, instance, "Condition", attribValue, typeof(global::System.String), true) as global::System.String;
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
		/// <param name="element">In-memory Transition instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		protected override void ReadElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			global::Tum.StateMachineDSL.Transition instance = element as global::Tum.StateMachineDSL.Transition;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Transition!");
	
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
		/// <param name="instance">In-memory Transition instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="readerLocalName">Current local name the xml reader is positioned at.</param>	
		/// <returns>True if the element has been successfully deserialized. False otherwise.</returns>
		protected virtual bool ReadElement(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( ReadReferenceRelationshipRoleTransitionStateBaseSource(serializationContext, instance, reader, readerLocalName) )
				return true;
			if( ReadReferenceRelationshipRoleTransitionStateBaseTarget(serializationContext, instance, reader, readerLocalName) )
				return true;
	
			return false;  // Don't know this element.
		}
		
		/// <summary>
		/// Read ref. rel Transition role StateBaseSource that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleTransitionStateBaseSource(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "StateBaseSourceRef")
			{
				string attribValueStateBaseSource = StateMachineLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueStateBaseSource != null )
				{
					System.Guid id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueStateBaseSource);
					if( id != System.Guid.Empty)
					{
						Tum.StateMachineDSL.StateMachineLanguageSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.StateMachineDSL.Transition.DomainClassId, instance.Id, id, System.Guid.Empty);
						Tum.StateMachineDSL.StateMachineLanguageSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		/// <summary>
		/// Read ref. rel Transition role StateBaseTarget that needed to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="reader">XmlWriter to write serialized data to.</param> 
		/// <param name="readerLocalName">Local name.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual bool ReadReferenceRelationshipRoleTransitionStateBaseTarget(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlReader reader, string readerLocalName)
		{
			if( readerLocalName ==  "StateBaseTargetRef")
			{
				string attribValueStateBaseTarget = StateMachineLanguageSerializationHelper.Instance.ReadAttribute(serializationContext, instance, reader, "link");
				if( attribValueStateBaseTarget != null )
				{
					System.Guid id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, attribValueStateBaseTarget);
					if( id != System.Guid.Empty)
					{
						Tum.StateMachineDSL.StateMachineLanguageSerializationPostProcessor.Instance.AddPostProcessData(
							global::Tum.StateMachineDSL.Transition.DomainClassId, instance.Id, System.Guid.Empty, id);
						Tum.StateMachineDSL.StateMachineLanguageSerializationPostProcessor.Instance.AddRelationshipTrackData(instance.Id);
					}
				}
				DslModeling::SerializationUtilities.Skip(reader);
				return true;	
			}
				
			return false;
		}
		
		#region TryCreateInstance & TryCreateDerivedInstance
		/// <summary>
		/// This method creates a correct instance of Transition based on the tag currently pointed by the reader. If the reader
		/// is positioned at a serialized Transition, a new Transition instance will be created in the given partition, otherwise 
		/// null is returned.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>	
		/// <returns>Created Transition instance, or null if the reader is not pointing to a serialized Transition instance.</returns>
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
		/// This method creates a correct derived instance of Transition based on the tag currently pointed by the reader.
		/// Note that the difference between this method and the above one is that this method will never create an instance of the
		/// Transition type itself, only derived types are checked.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the next element being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>		
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new elements should be created.</param>
		/// <returns>Created instance that derives from Transition, or null if the reader is not pointing to such a serialized instance.</returns>
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
				{	// New "Transition" instance.
					result = this.CreateInstance(serializationContext, reader, partition);
				}
				else
				{	// Check for derived classes of "Transition".
					//if (derivedClasses == null)
					//	ConstructDerivedClassesLookupTableTransition(serializationContext.Directory, partition.DomainDataDirectory);
					//global::System.Diagnostics.Debug.Assert (derivedClasses != null);
					//DslModeling::DomainClassInfo derivedClass = null;
					System.Guid derivedType = DslEditorModeling::SerializationHelper.TryGetDerivedNameType(global::Tum.StateMachineDSL.Transition.DomainClassId, localName);
					if( derivedType != System.Guid.Empty )
					//if (derivedClasses.TryGetValue (localName, out derivedClass) && derivedClass != null)
					{	// New derived relationship instance.
						//StateMachineLanguageTransitionSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedClass.Id) as StateMachineLanguageTransitionSerializer;
						StateMachineLanguageTransitionSerializer derivedSerializer = serializationContext.Directory.GetSerializer(derivedType) as StateMachineLanguageTransitionSerializer;
						global::System.Diagnostics.Debug.Assert(derivedSerializer != null, "Cannot find serializer for " + derivedType + "!");
						result = derivedSerializer.CreateInstance(serializationContext, reader, partition);
					}
				}
			}
	
			return result;
		}
	
		/// <summary>
		/// This method creates an instance of Transition based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of Transition.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new Transition instance should be created.</param>	
		/// <returns>Created Transition instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute (StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext);
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = StateMachineLanguageDomainModelIdProvider.Instance.GenerateNewKey();
					DslModeling::SerializationUtilities.AddMessage(serializationContext,DslModeling::SerializationMessageKind.Warning,
						"Missing 'Id' attribute, a new Guid " + id.ToString() + " is auto-generated. Element type (Transition)",
		    			reader as global::System.Xml.IXmlLineInfo);
					//StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = StateMachineLanguageSerializationHelper.Instance.ConvertIdFrom(serializationContext, idStr);
				}
				
				// Create the link with place-holder role-players.
				return new global::Tum.StateMachineDSL.Transition(
					partition,
					new DslModeling::RoleAssignment[] {
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId), 
						DslModeling::RoleAssignment.CreatePlaceholderRoleAssignment (global::Tum.StateMachineDSL.Transition.StateBaseTargetDomainRoleId)
					},
					new DslModeling::PropertyAssignment[] {
						new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id)
					}
				);
			}
			catch (global::System.ArgumentNullException /* anEx */)
			{	
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.FormatException /* fEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			catch (global::System.OverflowException /* ofEx */)
			{
				StateMachineLanguageSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
			}
			return null;
		}
		#endregion
		#endregion
	
		#region Write
		/// <summary>
		/// Public Write() method that serializes one Transition instance into XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Transition instance to be serialized.</param>
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
		/// <param name="element">Transition instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected override void WritePropertiesAsAttributes(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.Transition instance = element as global::Tum.StateMachineDSL.Transition;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Transition");
			
			// Domain Element Id
			string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, element.Id);
			writer.WriteAttributeString(StateMachineLanguageSerializationBehavior.Instance.IdSerializationNameDefaultContext, valueId);
			
			if (!serializationContext.Result.Failed)
			{
				WritePropertyAsAttributeCondition(serializationContext, instance, writer, options);
			}
		}
	
		/// <summary>
		/// Write property Condition that need to be serialized as XML attribute.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WritePropertyAsAttributeCondition(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			// Condition
			object valueCondition = global::Tum.StateMachineDSL.StateMachineLanguageSerializationHelper.Instance.ConvertTypedObjectTo(serializationContext,instance, "Condition" ,instance.Condition, typeof(global::System.String), true);
			if( valueCondition != null )
			{
				StateMachineLanguageSerializationHelper.Instance.WriteAttributeString(serializationContext, instance, writer, "Condition", valueCondition.ToString());
			}
		}
		
		/// <summary>
		/// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="element">Transition instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>        
		/// <param name="options">Serialization options.</param>
		protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			global::Tum.StateMachineDSL.Transition instance = element as global::Tum.StateMachineDSL.Transition;
			global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of Transition");
			
			WriteReferenceRelationshipRoleTransitionStateBaseSource(serializationContext, instance, writer, options);
			WriteReferenceRelationshipRoleTransitionStateBaseTarget(serializationContext, instance, writer, options);
		}
		
		/// <summary>
		/// Write ref. rel Transition role StateBaseSource that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleTransitionStateBaseSource(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship Transition Roles
			if (!serializationContext.Result.Failed)
			{
				// Write StateBaseSource link id
				writer.WriteStartElement("StateBaseSourceRef");
				string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.StateBaseSource.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		/// <summary>
		/// Write ref. rel Transition role StateBaseTarget that need to be serialized as XML element.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="instance">Transition instance to be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param> 
		/// <param name="options">Serialization options.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
		protected virtual void WriteReferenceRelationshipRoleTransitionStateBaseTarget(DslModeling::SerializationContext serializationContext, global::Tum.StateMachineDSL.Transition instance, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Save ReferenceRelationship Transition Roles
			if (!serializationContext.Result.Failed)
			{
				// Write StateBaseTarget link id
				writer.WriteStartElement("StateBaseTargetRef");
				string valueId = StateMachineLanguageSerializationHelper.Instance.ConvertIdTo(serializationContext, instance.StateBaseTarget.Id);
				writer.WriteAttributeString("link", valueId);
				writer.WriteEndElement();
			}
			#endregion		
		}
		
		
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior StateMachineLanguageSerializationBehavior.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class StateMachineLanguageSerializationBehavior : StateMachineLanguageSerializationBehaviorBase
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static StateMachineLanguageSerializationBehavior instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static StateMachineLanguageSerializationBehavior Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (StateMachineLanguageSerializationBehavior.instance == null)
					StateMachineLanguageSerializationBehavior.instance = new StateMachineLanguageSerializationBehavior ();
				return StateMachineLanguageSerializationBehavior.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private StateMachineLanguageSerializationBehavior() : base() { }
		#endregion
	}
	
	/// <summary>
	/// A DomainXmlSerializationBehavior implementation for defined behavior StateMachineLanguageSerializationBehavior.
	/// This is the abstract base of the double-derived implementation.
	/// </summary>
	public abstract class StateMachineLanguageSerializationBehaviorBase : DslModeling::DomainXmlSerializationBehavior
	{
		///<summary>
		/// The xml namespace used by this domain model when serializing
		///</summary>
		public const string DomainModelXmlNamespace = @"http://schemas.microsoft.com/dsltools/StateMachineDomainModel";
		
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
		protected StateMachineLanguageSerializationBehaviorBase() : base() { }
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
				if (StateMachineLanguageSerializationBehavior.serializerTypes == null)
				{
					global::System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::DomainXmlSerializerDirectoryEntry> customSerializerTypes = this.CustomSerializerTypes;
					int customSerializerCount = (customSerializerTypes == null ? 0 : customSerializerTypes.Count);
					StateMachineLanguageSerializationBehavior.serializerTypes = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerDirectoryEntry>(6 + customSerializerCount);

					#region Serializers defined in this model
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(StateMachineDomainModel.DomainClassId, typeof(StateMachineLanguageStateMachineDomainModelSerializer)));
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(StateBase.DomainClassId, typeof(StateMachineLanguageStateBaseSerializer)));
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(State.DomainClassId, typeof(StateMachineLanguageStateSerializer)));
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(StartState.DomainClassId, typeof(StateMachineLanguageStartStateSerializer)));
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EndState.DomainClassId, typeof(StateMachineLanguageEndStateSerializer)));
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(Transition.DomainClassId, typeof(StateMachineLanguageTransitionSerializer)));
					#endregion
				
					#region Serializers of the diagram model defined in this model
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(DesignerDiagram.DomainClassId, typeof(StateMachineLanguageDesignerDiagramSerializer)));					
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(StateShape.DomainClassId, typeof(StateMachineLanguageStateShapeSerializer)));					
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(StartStateShape.DomainClassId, typeof(StateMachineLanguageStartStateShapeSerializer)));					
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(EndStateShape.DomainClassId, typeof(StateMachineLanguageEndStateShapeSerializer)));					
					StateMachineLanguageSerializationBehavior.serializerTypes.Add(new DslModeling::DomainXmlSerializerDirectoryEntry(TransitionShape.DomainClassId, typeof(StateMachineLanguageTransitionShapeSerializer)));					
	
					#endregion
				
					// Custom ones
					if (customSerializerCount > 0)
					{
						StateMachineLanguageSerializationBehavior.serializerTypes.AddRange(customSerializerTypes);
					}
				}
				return StateMachineLanguageSerializationBehavior.serializerTypes.AsReadOnly();
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
				if (StateMachineLanguageSerializationBehavior.namespaceEntries == null)
				{
					StateMachineLanguageSerializationBehavior.namespaceEntries = new global::System.Collections.Generic.List<DslModeling::DomainXmlSerializerNamespaceEntry>();
				}
				return StateMachineLanguageSerializationBehavior.namespaceEntries.AsReadOnly();
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

namespace Tum.StateMachineDSL
{
    /// <summary>
    /// Utility class to provide serialization messages
    /// </summary>
    public static partial class StateMachineLanguageSerializationBehaviorSerializationMessages
    {
    	/// <summary>
    	/// ResourceManager to get serialization messages from.
    	/// </summary>
    	[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
    	public static global::System.Resources.ResourceManager ResourceManager
    	{
    		[global::System.Diagnostics.DebuggerStepThrough]
    		get { return StateMachineLanguageDomainModel.SingletonResourceManager; }
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

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// A ModelDataSerializationPostProcessor implementation.
	/// This is the concrete type of the double-derived implementation.
	/// </summary>
	public sealed partial class StateMachineLanguageSerializationPostProcessor : DslEditorModeling::ModelDataSerializationPostProcessor
	{
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static StateMachineLanguageSerializationPostProcessor instance;
	
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]	// Will trigger creation otherwise.
		public static StateMachineLanguageSerializationPostProcessor Instance
		{
			get
			{	// No need for synchronization. Most likely running in single-thread environment, and creating an extra instance
				// doesn't really hurt.
				if (StateMachineLanguageSerializationPostProcessor.instance == null)
					StateMachineLanguageSerializationPostProcessor.instance = new StateMachineLanguageSerializationPostProcessor ();
				return StateMachineLanguageSerializationPostProcessor.instance;
			}
		}
	
		/// <summary>
		/// Private constructor to prevent public instantiation.
		/// </summary>
		private StateMachineLanguageSerializationPostProcessor() : base() { }
		#endregion
	
		#region Methods
		/// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already reseted models.</param>
        public override void Reset(System.Collections.Generic.List<string> alreadyProcessedModels)
        {
			dictionary.Clear();
			alreadyProcessedModels.Add("StateMachineLanguage");

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
			
			alreadyProcessedModels.Add("StateMachineLanguage");
		}
		#endregion
	}
}
