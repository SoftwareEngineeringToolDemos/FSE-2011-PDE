 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer DesignerDiagramSerializer for DesignerDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class FamilyTreeDSLDesignerDiagramSerializer : FamilyTreeDSLDesignerDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializer Constructor
		/// </summary>
		public FamilyTreeDSLDesignerDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramSerializerBase for DesignerDiagram.
	/// </summary>
	public abstract partial class FamilyTreeDSLDesignerDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializerBase Constructor
		/// </summary>
		protected FamilyTreeDSLDesignerDiagramSerializerBase ()
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
					FamilyTreeDSLSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLdesignerDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLdesignerDiagramMoniker"; }
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

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer PersonShapeSerializer for PersonShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class FamilyTreeDSLPersonShapeSerializer : FamilyTreeDSLPersonShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// PersonShapeSerializer Constructor
		/// </summary>
		public FamilyTreeDSLPersonShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer PersonShapeSerializerBase for PersonShape.
	/// </summary>
	public abstract partial class FamilyTreeDSLPersonShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// PersonShapeSerializerBase Constructor
		/// </summary>
		protected FamilyTreeDSLPersonShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of PersonShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLpersonShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of PersonShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLpersonShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of PersonShape in a serialized monikerized instance.
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
            return global::Tum.FamilyTreeDSL.PersonShape.DomainClassId;
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

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer ParentOfShapeSerializer for ParentOfShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class FamilyTreeDSLParentOfShapeSerializer : FamilyTreeDSLParentOfShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// ParentOfShapeSerializer Constructor
		/// </summary>
		public FamilyTreeDSLParentOfShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer ParentOfShapeSerializerBase for ParentOfShape.
	/// </summary>
	public abstract partial class FamilyTreeDSLParentOfShapeSerializerBase : DslEditorDiagrams::LinkShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// ParentOfShapeSerializerBase Constructor
		/// </summary>
		protected FamilyTreeDSLParentOfShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of ParentOfShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLparentOfShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of ParentOfShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLparentOfShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of ParentOfShape in a serialized monikerized instance.
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
            return global::Tum.FamilyTreeDSL.ParentOfShape.DomainClassId;
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

			global::Tum.FamilyTreeDSL.ParentOf instanceToReturn = null;

			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.ParentOf> allMParentOfInstances =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.ParentOf>(source, global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId);
			foreach(global::Tum.FamilyTreeDSL.ParentOf instance in allMParentOfInstances )
			{
				if( instance.Child.Id == target.Id )
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

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// Serializer MarriedToShapeSerializer for MarriedToShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class FamilyTreeDSLMarriedToShapeSerializer : FamilyTreeDSLMarriedToShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// MarriedToShapeSerializer Constructor
		/// </summary>
		public FamilyTreeDSLMarriedToShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer MarriedToShapeSerializerBase for MarriedToShape.
	/// </summary>
	public abstract partial class FamilyTreeDSLMarriedToShapeSerializerBase : DslEditorDiagrams::LinkShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// MarriedToShapeSerializerBase Constructor
		/// </summary>
		protected FamilyTreeDSLMarriedToShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of MarriedToShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLmarriedToShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of MarriedToShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"FamilyTreeDSLmarriedToShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of MarriedToShape in a serialized monikerized instance.
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
            return global::Tum.FamilyTreeDSL.MarriedToShape.DomainClassId;
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

			global::Tum.FamilyTreeDSL.MarriedTo instanceToReturn = null;

			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.MarriedTo> allMMarriedToInstances =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(source, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId);
			foreach(global::Tum.FamilyTreeDSL.MarriedTo instance in allMMarriedToInstances )
			{
				if( instance.Wife.Id == target.Id )
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


