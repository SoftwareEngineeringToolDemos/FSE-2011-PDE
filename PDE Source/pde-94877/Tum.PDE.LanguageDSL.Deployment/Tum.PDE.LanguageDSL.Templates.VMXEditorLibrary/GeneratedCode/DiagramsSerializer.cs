 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer DesignerDiagramSerializer for DesignerDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramSerializer : VModellXTDesignerDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializer Constructor
		/// </summary>
		public VModellXTDesignerDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramSerializerBase for DesignerDiagram.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializerBase Constructor
		/// </summary>
		protected VModellXTDesignerDiagramSerializerBase ()
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
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagramMoniker"; }
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

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer GeneralGrDependencyTemplateSerializer for GeneralGrDependencyTemplate.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTGeneralGrDependencyTemplateSerializer : VModellXTGeneralGrDependencyTemplateSerializerBase
	{
		#region Constructor
		/// <summary>
		/// GeneralGrDependencyTemplateSerializer Constructor
		/// </summary>
		public VModellXTGeneralGrDependencyTemplateSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer GeneralGrDependencyTemplateSerializerBase for GeneralGrDependencyTemplate.
	/// </summary>
	public abstract partial class VModellXTGeneralGrDependencyTemplateSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// GeneralGrDependencyTemplateSerializerBase Constructor
		/// </summary>
		protected VModellXTGeneralGrDependencyTemplateSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of GeneralGrDependencyTemplate based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of GeneralGrDependencyTemplate.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new GeneralGrDependencyTemplate instance should be created.</param>	
		/// <returns>Created GeneralGrDependencyTemplate instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new GeneralGrDependencyTemplate(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of GeneralGrDependencyTemplate.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTgeneralGrDependencyTemplate"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of GeneralGrDependencyTemplate.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTgeneralGrDependencyTemplateMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of GeneralGrDependencyTemplate in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer RolleDependencyTemplateSerializer for RolleDependencyTemplate.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTRolleDependencyTemplateSerializer : VModellXTRolleDependencyTemplateSerializerBase
	{
		#region Constructor
		/// <summary>
		/// RolleDependencyTemplateSerializer Constructor
		/// </summary>
		public VModellXTRolleDependencyTemplateSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer RolleDependencyTemplateSerializerBase for RolleDependencyTemplate.
	/// </summary>
	public abstract partial class VModellXTRolleDependencyTemplateSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// RolleDependencyTemplateSerializerBase Constructor
		/// </summary>
		protected VModellXTRolleDependencyTemplateSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of RolleDependencyTemplate based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of RolleDependencyTemplate.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new RolleDependencyTemplate instance should be created.</param>	
		/// <returns>Created RolleDependencyTemplate instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new RolleDependencyTemplate(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of RolleDependencyTemplate.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTrolleDependencyTemplate"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of RolleDependencyTemplate.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTrolleDependencyTemplateMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of RolleDependencyTemplate in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer RolleDependencyShapeSerializer for RolleDependencyShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTRolleDependencyShapeSerializer : VModellXTRolleDependencyShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// RolleDependencyShapeSerializer Constructor
		/// </summary>
		public VModellXTRolleDependencyShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer RolleDependencyShapeSerializerBase for RolleDependencyShape.
	/// </summary>
	public abstract partial class VModellXTRolleDependencyShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// RolleDependencyShapeSerializerBase Constructor
		/// </summary>
		protected VModellXTRolleDependencyShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of RolleDependencyShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTrolleDependencyShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of RolleDependencyShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTrolleDependencyShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of RolleDependencyShape in a serialized monikerized instance.
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
            return global::Tum.VModellXT.RolleDependencyShape.DomainClassId;
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

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer DisziplinGrDependencyTemplateSerializer for DisziplinGrDependencyTemplate.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTDisziplinGrDependencyTemplateSerializer : VModellXTDisziplinGrDependencyTemplateSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DisziplinGrDependencyTemplateSerializer Constructor
		/// </summary>
		public VModellXTDisziplinGrDependencyTemplateSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DisziplinGrDependencyTemplateSerializerBase for DisziplinGrDependencyTemplate.
	/// </summary>
	public abstract partial class VModellXTDisziplinGrDependencyTemplateSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DisziplinGrDependencyTemplateSerializerBase Constructor
		/// </summary>
		protected VModellXTDisziplinGrDependencyTemplateSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of DisziplinGrDependencyTemplate based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DisziplinGrDependencyTemplate.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DisziplinGrDependencyTemplate instance should be created.</param>	
		/// <returns>Created DisziplinGrDependencyTemplate instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DisziplinGrDependencyTemplate(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DisziplinGrDependencyTemplate.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdisziplinGrDependencyTemplate"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DisziplinGrDependencyTemplate.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdisziplinGrDependencyTemplateMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DisziplinGrDependencyTemplate in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer DisziplinDependencyShapeSerializer for DisziplinDependencyShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTDisziplinDependencyShapeSerializer : VModellXTDisziplinDependencyShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DisziplinDependencyShapeSerializer Constructor
		/// </summary>
		public VModellXTDisziplinDependencyShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DisziplinDependencyShapeSerializerBase for DisziplinDependencyShape.
	/// </summary>
	public abstract partial class VModellXTDisziplinDependencyShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// DisziplinDependencyShapeSerializerBase Constructor
		/// </summary>
		protected VModellXTDisziplinDependencyShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DisziplinDependencyShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdisziplinDependencyShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DisziplinDependencyShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdisziplinDependencyShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DisziplinDependencyShape in a serialized monikerized instance.
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
            return global::Tum.VModellXT.DisziplinDependencyShape.DomainClassId;
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

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer ErzAbhGrDependencyTemplateSerializer for ErzAbhGrDependencyTemplate.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTErzAbhGrDependencyTemplateSerializer : VModellXTErzAbhGrDependencyTemplateSerializerBase
	{
		#region Constructor
		/// <summary>
		/// ErzAbhGrDependencyTemplateSerializer Constructor
		/// </summary>
		public VModellXTErzAbhGrDependencyTemplateSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer ErzAbhGrDependencyTemplateSerializerBase for ErzAbhGrDependencyTemplate.
	/// </summary>
	public abstract partial class VModellXTErzAbhGrDependencyTemplateSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// ErzAbhGrDependencyTemplateSerializerBase Constructor
		/// </summary>
		protected VModellXTErzAbhGrDependencyTemplateSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of ErzAbhGrDependencyTemplate based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ErzAbhGrDependencyTemplate.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ErzAbhGrDependencyTemplate instance should be created.</param>	
		/// <returns>Created ErzAbhGrDependencyTemplate instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new ErzAbhGrDependencyTemplate(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ErzAbhGrDependencyTemplate.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTerzAbhGrDependencyTemplate"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of ErzAbhGrDependencyTemplate.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTerzAbhGrDependencyTemplateMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of ErzAbhGrDependencyTemplate in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer ErzAbhDependencyShapeSerializer for ErzAbhDependencyShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTErzAbhDependencyShapeSerializer : VModellXTErzAbhDependencyShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// ErzAbhDependencyShapeSerializer Constructor
		/// </summary>
		public VModellXTErzAbhDependencyShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer ErzAbhDependencyShapeSerializerBase for ErzAbhDependencyShape.
	/// </summary>
	public abstract partial class VModellXTErzAbhDependencyShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// ErzAbhDependencyShapeSerializerBase Constructor
		/// </summary>
		protected VModellXTErzAbhDependencyShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ErzAbhDependencyShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTerzAbhDependencyShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of ErzAbhDependencyShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTerzAbhDependencyShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of ErzAbhDependencyShape in a serialized monikerized instance.
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
            return global::Tum.VModellXT.ErzAbhDependencyShape.DomainClassId;
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

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer DesignerDiagramMustertexteSerializer for DesignerDiagramMustertexte.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramMustertexteSerializer : VModellXTDesignerDiagramMustertexteSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramMustertexteSerializer Constructor
		/// </summary>
		public VModellXTDesignerDiagramMustertexteSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramMustertexteSerializerBase for DesignerDiagramMustertexte.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramMustertexteSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramMustertexteSerializerBase Constructor
		/// </summary>
		protected VModellXTDesignerDiagramMustertexteSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of DesignerDiagramMustertexte based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DesignerDiagramMustertexte.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DesignerDiagramMustertexte instance should be created.</param>	
		/// <returns>Created DesignerDiagramMustertexte instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagramMustertexte(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagramMustertexte.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagramMustertexte"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagramMustertexte.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagramMustertexteMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DesignerDiagramMustertexte in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}

namespace Tum.VModellXT
{
	/// <summary>
	/// Serializer DesignerDiagramVariantenkonfigSerializer for DesignerDiagramVariantenkonfig.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class VModellXTDesignerDiagramVariantenkonfigSerializer : VModellXTDesignerDiagramVariantenkonfigSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramVariantenkonfigSerializer Constructor
		/// </summary>
		public VModellXTDesignerDiagramVariantenkonfigSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramVariantenkonfigSerializerBase for DesignerDiagramVariantenkonfig.
	/// </summary>
	public abstract partial class VModellXTDesignerDiagramVariantenkonfigSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramVariantenkonfigSerializerBase Constructor
		/// </summary>
		protected VModellXTDesignerDiagramVariantenkonfigSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of DesignerDiagramVariantenkonfig based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of DesignerDiagramVariantenkonfig.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new DesignerDiagramVariantenkonfig instance should be created.</param>	
		/// <returns>Created DesignerDiagramVariantenkonfig instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					VModellXTSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagramVariantenkonfig(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagramVariantenkonfig.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagramVariantenkonfig"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagramVariantenkonfig.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"VModellXTdesignerDiagramVariantenkonfigMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DesignerDiagramVariantenkonfig in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}


