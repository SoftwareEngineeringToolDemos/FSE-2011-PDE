 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;


namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// DesignerDiagram class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("ee637228-f59a-4ab2-b309-1756eb2bef95")]
	public partial class DesignerDiagram : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("ee637228-f59a-4ab2-b309-1756eb2bef95");
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
				return "PDEModelingDSLDesignerDiagram";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }

        /// <summary>
        /// Gets the relationship shapes factory helper. Needs to be derived in the actual instance class.
        /// </summary>
        /// <returns></returns>
        public override DslEditorDiagrams::ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper GetRSShapesFactoryHelper()
        {
            return PDEModelingDSLLinkForShapesAdded.PDEModelingDSLElementForShapesFactoryHelper.Instance;
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

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// ConversionDiagram class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("30220d2a-50e8-4a0a-91ec-539df429f331")]
	public partial class ConversionDiagram : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("30220d2a-50e8-4a0a-91ec-539df429f331");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ConversionDiagram(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ConversionDiagram(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
				return "PDEModelingDSLConversionDiagram";
			}
        }
		
        /// <summary>
        /// Initialize.
        /// </summary>
        public override void Initialize()
        {
        }

        /// <summary>
        /// Gets the relationship shapes factory helper. Needs to be derived in the actual instance class.
        /// </summary>
        /// <returns></returns>
        public override DslEditorDiagrams::ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper GetRSShapesFactoryHelper()
        {
            return PDEModelingDSLLinkForShapesAdded.PDEModelingDSLElementForShapesFactoryHelper.Instance;
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
