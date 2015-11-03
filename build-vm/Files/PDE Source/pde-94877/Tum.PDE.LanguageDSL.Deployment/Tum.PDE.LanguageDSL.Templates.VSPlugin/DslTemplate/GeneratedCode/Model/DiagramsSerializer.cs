 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer DesignerDiagramSerializer for DesignerDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class PDEModelingDSLDesignerDiagramSerializer : PDEModelingDSLDesignerDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializer Constructor
		/// </summary>
		public PDEModelingDSLDesignerDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramSerializerBase for DesignerDiagram.
	/// </summary>
	public abstract partial class PDEModelingDSLDesignerDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializerBase Constructor
		/// </summary>
		protected PDEModelingDSLDesignerDiagramSerializerBase ()
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
					PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLdesignerDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLdesignerDiagramMoniker"; }
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

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer ReferenceShapeSerializer for ReferenceShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class PDEModelingDSLReferenceShapeSerializer : PDEModelingDSLReferenceShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// ReferenceShapeSerializer Constructor
		/// </summary>
		public PDEModelingDSLReferenceShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer ReferenceShapeSerializerBase for ReferenceShape.
	/// </summary>
	public abstract partial class PDEModelingDSLReferenceShapeSerializerBase : DslEditorDiagrams::LinkShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// ReferenceShapeSerializerBase Constructor
		/// </summary>
		protected PDEModelingDSLReferenceShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ReferenceShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLreferenceShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of ReferenceShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLreferenceShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of ReferenceShape in a serialized monikerized instance.
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
            return global::Tum.PDE.ModelingDSL.ReferenceShape.DomainClassId;
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
	
		#region Shape Helpers

        /// <summary>
        /// Finds out if a relationship can be assigned automatically between the given source
		/// and target element.
        /// </summary>
        /// <remarks>
        /// This method is required becase reference relationship do not need to be serialized
		/// with an id. But shapes still need to be created for them if a visual information
		/// is provided in the diagrams model.
        /// </remarks>
        protected override DslModeling::ModelElement CanAssignRelationship(DslModeling::ModelElement source, DslModeling::ModelElement target)
        {
			if( source == null || target == null )
				return null;

			global::Tum.PDE.ModelingDSL.ReferenceRelationship instanceToReturn = null;

			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.ReferenceRelationship> allMReferenceRelationshipInstances =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.ReferenceRelationship>(source, global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId);
			foreach(global::Tum.PDE.ModelingDSL.ReferenceRelationship instance in allMReferenceRelationshipInstances )
			{
				if( instance.Target.Id == target.Id )
				{
					if( instanceToReturn == null )
						instanceToReturn = instance;
					else
						return null;
				}
			}
			
			return instanceToReturn;
        }		
		#endregion
				
	}
}

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer EmbeddingShapeSerializer for EmbeddingShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class PDEModelingDSLEmbeddingShapeSerializer : PDEModelingDSLEmbeddingShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// EmbeddingShapeSerializer Constructor
		/// </summary>
		public PDEModelingDSLEmbeddingShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer EmbeddingShapeSerializerBase for EmbeddingShape.
	/// </summary>
	public abstract partial class PDEModelingDSLEmbeddingShapeSerializerBase : DslEditorDiagrams::LinkShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// EmbeddingShapeSerializerBase Constructor
		/// </summary>
		protected PDEModelingDSLEmbeddingShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EmbeddingShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLembeddingShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of EmbeddingShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLembeddingShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of EmbeddingShape in a serialized monikerized instance.
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
            return global::Tum.PDE.ModelingDSL.EmbeddingShape.DomainClassId;
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
	
		#region Shape Helpers

        /// <summary>
        /// Finds out if a relationship can be assigned automatically between the given source
		/// and target element.
        /// </summary>
        /// <remarks>
        /// This method is required becase reference relationship do not need to be serialized
		/// with an id. But shapes still need to be created for them if a visual information
		/// is provided in the diagrams model.
        /// </remarks>
        protected override DslModeling::ModelElement CanAssignRelationship(DslModeling::ModelElement source, DslModeling::ModelElement target)
        {
			if( source == null || target == null )
				return null;

			global::Tum.PDE.ModelingDSL.EmbeddingRelationship instanceToReturn = null;

			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> allMEmbeddingRelationshipInstances =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(source, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId);
			foreach(global::Tum.PDE.ModelingDSL.EmbeddingRelationship instance in allMEmbeddingRelationshipInstances )
			{
				if( instance.Parent.Id == target.Id )
				{
					if( instanceToReturn == null )
						instanceToReturn = instance;
					else
						return null;
				}
			}
			
			return instanceToReturn;
        }		
		#endregion
				
	}
}

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer DomainElementShapeSerializer for DomainElementShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class PDEModelingDSLDomainElementShapeSerializer : PDEModelingDSLDomainElementShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DomainElementShapeSerializer Constructor
		/// </summary>
		public PDEModelingDSLDomainElementShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DomainElementShapeSerializerBase for DomainElementShape.
	/// </summary>
	public abstract partial class PDEModelingDSLDomainElementShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// DomainElementShapeSerializerBase Constructor
		/// </summary>
		protected PDEModelingDSLDomainElementShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DomainElementShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLdomainElementShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DomainElementShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLdomainElementShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of DomainElementShape in a serialized monikerized instance.
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
            return global::Tum.PDE.ModelingDSL.DomainElementShape.DomainClassId;
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

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Serializer ConversionDiagramSerializer for ConversionDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class PDEModelingDSLConversionDiagramSerializer : PDEModelingDSLConversionDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// ConversionDiagramSerializer Constructor
		/// </summary>
		public PDEModelingDSLConversionDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer ConversionDiagramSerializerBase for ConversionDiagram.
	/// </summary>
	public abstract partial class PDEModelingDSLConversionDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// ConversionDiagramSerializerBase Constructor
		/// </summary>
		protected PDEModelingDSLConversionDiagramSerializerBase ()
			: base ()
		{
		}
		#endregion
	
		#region Create Instance
		/// <summary>
		/// This method creates an instance of ConversionDiagram based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
		/// to be pointed at a serialized instance of ConversionDiagram.
		/// </summary>
		/// <remarks>
		/// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
		/// not move the reader; the reader should remain at the same position when this method returns.
		/// </remarks>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="partition">Partition in which new ConversionDiagram instance should be created.</param>	
		/// <returns>Created ConversionDiagram instance.</returns>
		protected override DslModeling::ModelElement CreateInstance(DslModeling::SerializationContext serializationContext, global::System.Xml.XmlReader reader, DslModeling::Partition partition)
		{
			string idStr = reader.GetAttribute ("Id");
			try
			{
				global::System.Guid id;
				if (string.IsNullOrEmpty(idStr))
				{	// Create a default Id.
					id = global::System.Guid.NewGuid();
					PDEModelingDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new ConversionDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ConversionDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLconversionDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of ConversionDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"PDEModelingDSLconversionDiagramMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of ConversionDiagram in a serialized monikerized instance.
		/// </summary>
		public override string MonikerAttributeName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"Id"; }
		}
		#endregion		
	}
}


