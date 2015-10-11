 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;


namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// DesignerDiagram class representing a Diagram.
    /// </summary>
	[DslModeling::DomainObjectId("dd212215-f39e-4b5f-8a70-b75549507756")]
	public partial class DesignerDiagram : DslEditorDiagrams::Diagram
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("dd212215-f39e-4b5f-8a70-b75549507756");
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
				return "FamilyTreeDSLDesignerDiagram";
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
            return FamilyTreeDSLLinkForShapesAdded.FamilyTreeDSLElementForShapesFactoryHelper.Instance;
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
