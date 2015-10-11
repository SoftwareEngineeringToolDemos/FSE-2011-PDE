 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer DesignerDiagramSerializer for DesignerDiagram.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class StateMachineLanguageDesignerDiagramSerializer : StateMachineLanguageDesignerDiagramSerializerBase
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializer Constructor
		/// </summary>
		public StateMachineLanguageDesignerDiagramSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer DesignerDiagramSerializerBase for DesignerDiagram.
	/// </summary>
	public abstract partial class StateMachineLanguageDesignerDiagramSerializerBase : DslEditorDiagrams::DiagramSerializer
	{
		#region Constructor
		/// <summary>
		/// DesignerDiagramSerializerBase Constructor
		/// </summary>
		protected StateMachineLanguageDesignerDiagramSerializerBase ()
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
					StateMachineLanguageSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
				}
				else
				{
					id = new global::System.Guid (idStr);
				}
				return new DesignerDiagram(partition, new DslModeling::PropertyAssignment(DslModeling::ElementFactory.IdPropertyAssignment, id));
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
		
		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of DesignerDiagram.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagedesignerDiagram"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of DesignerDiagram.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagedesignerDiagramMoniker"; }
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

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StateShapeSerializer for StateShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class StateMachineLanguageStateShapeSerializer : StateMachineLanguageStateShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// StateShapeSerializer Constructor
		/// </summary>
		public StateMachineLanguageStateShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer StateShapeSerializerBase for StateShape.
	/// </summary>
	public abstract partial class StateMachineLanguageStateShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// StateShapeSerializerBase Constructor
		/// </summary>
		protected StateMachineLanguageStateShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of StateShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagestateShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of StateShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagestateShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of StateShape in a serialized monikerized instance.
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
            return global::Tum.StateMachineDSL.StateShape.DomainClassId;
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

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer StartStateShapeSerializer for StartStateShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class StateMachineLanguageStartStateShapeSerializer : StateMachineLanguageStartStateShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// StartStateShapeSerializer Constructor
		/// </summary>
		public StateMachineLanguageStartStateShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer StartStateShapeSerializerBase for StartStateShape.
	/// </summary>
	public abstract partial class StateMachineLanguageStartStateShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// StartStateShapeSerializerBase Constructor
		/// </summary>
		protected StateMachineLanguageStartStateShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of StartStateShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagestartStateShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of StartStateShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagestartStateShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of StartStateShape in a serialized monikerized instance.
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
            return global::Tum.StateMachineDSL.StartStateShape.DomainClassId;
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

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer EndStateShapeSerializer for EndStateShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class StateMachineLanguageEndStateShapeSerializer : StateMachineLanguageEndStateShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// EndStateShapeSerializer Constructor
		/// </summary>
		public StateMachineLanguageEndStateShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer EndStateShapeSerializerBase for EndStateShape.
	/// </summary>
	public abstract partial class StateMachineLanguageEndStateShapeSerializerBase : DslEditorDiagrams::NodeShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// EndStateShapeSerializerBase Constructor
		/// </summary>
		protected StateMachineLanguageEndStateShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of EndStateShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguageendStateShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of EndStateShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguageendStateShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of EndStateShape in a serialized monikerized instance.
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
            return global::Tum.StateMachineDSL.EndStateShape.DomainClassId;
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

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// Serializer TransitionShapeSerializer for TransitionShape.
	///
	/// This is the double derived class for easier customization.
	/// </summary>
	public partial class StateMachineLanguageTransitionShapeSerializer : StateMachineLanguageTransitionShapeSerializerBase
	{
		#region Constructor
		/// <summary>
		/// TransitionShapeSerializer Constructor
		/// </summary>
		public StateMachineLanguageTransitionShapeSerializer ()
			: base ()
		{
		}
		#endregion
	}
	
	/// <summary>
	/// Serializer TransitionShapeSerializerBase for TransitionShape.
	/// </summary>
	public abstract partial class StateMachineLanguageTransitionShapeSerializerBase : DslEditorDiagrams::LinkShapeSerializer
	{
		#region Constructor
		/// <summary>
		/// TransitionShapeSerializerBase Constructor
		/// </summary>
		protected StateMachineLanguageTransitionShapeSerializerBase ()
			: base ()
		{
		}
		#endregion

		#region Public Properties
			
		/// <summary>
		/// This is the XML tag name used to serialize an instance of TransitionShape.
		/// </summary>
		public override string XmlTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagetransitionShape"; }
		}
	
		/// <summary>
		/// This is the XML tag name used to serialize a monikerized instance of TransitionShape.
		/// </summary>
		public override string MonikerTagName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get { return @"StateMachineLanguagetransitionShapeMoniker"; }
		}
		
		/// <summary>
		/// This is the name of the XML attribute that stores the moniker of TransitionShape in a serialized monikerized instance.
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
            return global::Tum.StateMachineDSL.TransitionShape.DomainClassId;
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

			global::Tum.StateMachineDSL.Transition instanceToReturn = null;

			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.Transition> allMTransitionInstances =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.Transition>(source, global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
			foreach(global::Tum.StateMachineDSL.Transition instance in allMTransitionInstances )
			{
				if( instance.StateBaseTarget.Id == target.Id )
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


