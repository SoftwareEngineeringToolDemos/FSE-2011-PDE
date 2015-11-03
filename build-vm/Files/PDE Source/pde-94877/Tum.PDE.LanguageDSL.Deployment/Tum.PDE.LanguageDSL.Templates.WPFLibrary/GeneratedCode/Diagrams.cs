 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;


namespace Tum.VModellXT
{
	/// <summary>
    /// DesignerDiagram class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("f036ff02-e677-416c-b72b-1d13578515bb")]
	public partial class DesignerDiagram : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("f036ff02-e677-416c-b72b-1d13578515bb");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagram(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagram(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTDesignerDiagram";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
			AddIncludedDiagram(new Tum.VModellXT.Dynamik.DesignerDiagram(this.Store));
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
			// TODO			
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// GeneralGrDependencyTemplate class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("4e4e5f3a-896d-41c6-91b3-cf20ee814dc5")]
	public partial class GeneralGrDependencyTemplate : DslEditorDiagrams::GraphicalDependenciesDiagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("4e4e5f3a-896d-41c6-91b3-cf20ee814dc5");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public GeneralGrDependencyTemplate(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public GeneralGrDependencyTemplate(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTGeneralGrDependencyTemplate";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// RolleDependencyTemplate class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("de4fd07d-7109-48c5-8b96-c3e5467be124")]
	public partial class RolleDependencyTemplate : DslEditorDiagrams::GraphicalDependenciesDiagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("de4fd07d-7109-48c5-8b96-c3e5467be124");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RolleDependencyTemplate(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RolleDependencyTemplate(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTRolleDependencyTemplate";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// DisziplinGrDependencyTemplate class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("ee0306eb-0f24-4107-8fa3-dd7d21dcc959")]
	public partial class DisziplinGrDependencyTemplate : DslEditorDiagrams::GraphicalDependenciesDiagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("ee0306eb-0f24-4107-8fa3-dd7d21dcc959");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DisziplinGrDependencyTemplate(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DisziplinGrDependencyTemplate(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTDisziplinGrDependencyTemplate";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// ErzAbhGrDependencyTemplate class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("7d926c0d-eb8c-4123-a6ea-42749e520d8b")]
	public partial class ErzAbhGrDependencyTemplate : DslEditorDiagrams::GraphicalDependenciesDiagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7d926c0d-eb8c-4123-a6ea-42749e520d8b");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ErzAbhGrDependencyTemplate(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ErzAbhGrDependencyTemplate(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTErzAbhGrDependencyTemplate";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// DesignerDiagramMustertexte class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("3817b04e-3b8b-4a02-bb19-cae2322eb7db")]
	public partial class DesignerDiagramMustertexte : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("3817b04e-3b8b-4a02-bb19-cae2322eb7db");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagramMustertexte(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagramMustertexte(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTDesignerDiagramMustertexte";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
			// TODO			
		}
		#endregion
	}
}

namespace Tum.VModellXT
{
	/// <summary>
    /// DesignerDiagramVariantenkonfig class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("8d91852a-4c2d-4592-9399-c31a8c649255")]
	public partial class DesignerDiagramVariantenkonfig : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("8d91852a-4c2d-4592-9399-c31a8c649255");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagramVariantenkonfig(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DesignerDiagramVariantenkonfig(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		
	    /// <summary>
        /// Gets the unique name of this diagram.
        /// </summary>
        public override string UniqueName
        {
            get
			{
				return "VModellXTDesignerDiagramVariantenkonfig";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }
		
		#region Methods		
		/// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public override void ModelMerge(DslEditorModeling::ModelProtoElement protoElement, DslEditorModeling::ModelProtoGroupMerger groupMerger, bool isRoot)
		{
			// TODO			
		}
		#endregion
	}
}
