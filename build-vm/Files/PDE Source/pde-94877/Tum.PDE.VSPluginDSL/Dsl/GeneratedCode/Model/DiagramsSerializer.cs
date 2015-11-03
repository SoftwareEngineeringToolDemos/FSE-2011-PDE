 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Serializer DesignerDiagramSerializer for DesignerDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VSPluginDSLDesignerDiagramSerializer : VSPluginDSLDesignerDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializer Constructor
		/// </summary>
		public VSPluginDSLDesignerDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramSerializerBase for DesignerDiagram.
	/// </summary>
	public abstract partial class VSPluginDSLDesignerDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializerBase Constructor
		/// </summary>
		protected VSPluginDSLDesignerDiagramSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of DesignerDiagram based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DesignerDiagram.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DesignerDiagram instance should be created.</param>	
		/// <returns>Created DesignerDiagram instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VSPluginDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
		catch (global::System.ArgumentNullException /* anEx */)
		{	
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
		catch (global::System.FormatException /* fEx */)
		{
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
		catch (global::System.OverflowException /* ofEx */)
		{
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
			return null;
		}		
		#endregion
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLdesignerDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLdesignerDiagramMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DesignerDiagram in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Serializer DomainClass2ShapeSerializer for DomainClass2Shape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VSPluginDSLDomainClass2ShapeSerializer : VSPluginDSLDomainClass2ShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DomainClass2ShapeSerializer Constructor
		/// </summary>
		public VSPluginDSLDomainClass2ShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DomainClass2ShapeSerializerBase for DomainClass2Shape.
	/// </summary>
	public abstract partial class VSPluginDSLDomainClass2ShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// DomainClass2ShapeSerializerBase Constructor
		/// </summary>
		protected VSPluginDSLDomainClass2ShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainClass2Shape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLdomainClass2Shape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DomainClass2Shape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLdomainClass2ShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DomainClass2Shape in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		
        /// <summary>
        /// Gets the shape class Id.
        /// </summary>
        /// <returns></returns>
        public override System.Guid GetShapeClassId()
        {
            return global::Tum.PDE.VSPluginDSL.DomainClass2Shape.DomainClassId;
        }		
		#endregion		
	
        #region Read Methods
        /// <summary>
        /// This method deserializes all properties that are serialized as XML attributes.
        /// </summary>
        /// <remarks>
        /// Because this method only handles properties serialized as XML attributes, the passed-in reader shouldn't be moved inside this method.
        /// The caller will guarantee that the reader is positioned on the open XML tag of the current element being deserialized.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">In-memory NodeShape instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        protected override void ReadPropertiesFromAttributes(DslModeling.SerializationContext serializationContext, DslModeling.ModelElement element, System.Xml.XmlReader reader)
        {
            base.ReadPropertiesFromAttributes(serializationContext, element, reader);

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
        /// <param name="element">In-memory NodeShape instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        protected override void ReadElements(DslModeling.SerializationContext serializationContext, DslModeling.ModelElement element, System.Xml.XmlReader reader)
        {
            base.ReadElements(serializationContext, element, reader);
			
			while (!serializationContext.Result.Failed && !reader.EOF && reader.NodeType == global::System.Xml.XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{			
					default:
						return;  // Don't know this element.
				}
			}
        }
		
        #endregion

        #region Write Methods
        /// <summary>
        /// Write all properties that need to be serialized as XML attributes.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">NodeShape instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param> 
        protected override void WritePropertiesAsAttributes(DslModeling.SerializationContext serializationContext, DslModeling.ModelElement element, System.Xml.XmlWriter writer)
        {
            base.WritePropertiesAsAttributes(serializationContext, element, writer);

        }

		
        /// <summary>
        /// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">NodeShape instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>        
        protected override void WriteElements(DslModeling.SerializationContext serializationContext, DslModeling.ModelElement element, System.Xml.XmlWriter writer)
        {
            base.WriteElements(serializationContext, element, writer);
			
		}
		
        #endregion	
	
				
	}
}

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Serializer SpecificElementsDiagramTemplateSerializer for SpecificElementsDiagramTemplate.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VSPluginDSLSpecificElementsDiagramTemplateSerializer : VSPluginDSLSpecificElementsDiagramTemplateSerializerBase
	{
		#region Constructor
		/// <summary>
		/// SpecificElementsDiagramTemplateSerializer Constructor
		/// </summary>
		public VSPluginDSLSpecificElementsDiagramTemplateSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer SpecificElementsDiagramTemplateSerializerBase for SpecificElementsDiagramTemplate.
	/// </summary>
	public abstract partial class VSPluginDSLSpecificElementsDiagramTemplateSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// SpecificElementsDiagramTemplateSerializerBase Constructor
		/// </summary>
		protected VSPluginDSLSpecificElementsDiagramTemplateSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of SpecificElementsDiagramTemplate based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of SpecificElementsDiagramTemplate.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new SpecificElementsDiagramTemplate instance should be created.</param>	
		/// <returns>Created SpecificElementsDiagramTemplate instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VSPluginDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new SpecificElementsDiagramTemplate(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
			}
		catch (global::System.ArgumentNullException /* anEx */)
		{	
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
		catch (global::System.FormatException /* fEx */)
		{
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
		catch (global::System.OverflowException /* ofEx */)
		{
			VSPluginDSLSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
		}
			return null;
		}		
		#endregion
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of SpecificElementsDiagramTemplate.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLspecificElementsDiagramTemplate"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of SpecificElementsDiagramTemplate.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VSPluginDSLspecificElementsDiagramTemplateMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of SpecificElementsDiagramTemplate in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}


