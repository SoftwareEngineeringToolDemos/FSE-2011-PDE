 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// ReferenceShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("972aa948-62c2-4621-8362-3d572b9f5da6")]
	public partial class ReferenceShape : DslEditorDiagrams::LinkShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// ReferenceShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("972aa948-62c2-4621-8362-3d572b9f5da6");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ReferenceShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ReferenceShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// EmbeddingShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("a8cee774-9985-4b9e-a735-a7a7aa330689")]
	public partial class EmbeddingShape : DslEditorDiagrams::LinkShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// EmbeddingShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a8cee774-9985-4b9e-a735-a7a7aa330689");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EmbeddingShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EmbeddingShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// DomainElementShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("5a1503d1-1f20-4044-9d4d-d87ceeefd649")]
	public partial class DomainElementShape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// DomainElementShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("5a1503d1-1f20-4044-9d4d-d87ceeefd649");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElementShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElementShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Shape Properties/Methods
		        /// <summary>
        /// Gets if this shape is a top most item.
        /// </summary>
        public override bool IsTopMostItem 
		{ 
			get
			{
				return true;
			}
		}
		
		        /// <summary>
        /// Gets the default size of the shape.
        /// </summary>
        public override DslEditorDiagrams::SizeD DefaultSize
        {
            get
            {
                return new DslEditorDiagrams::SizeD(150, 50);
            }
        }
		
		 /// <summary>
        /// Gets the used defined resizing behaviour value.
        /// </summary>
        /// <returns>Resizing behaviour value.</returns>
        public override DslEditorDiagrams::ShapeResizingBehaviour GetResizingBehaviourValue()
		{
			return DslEditorDiagrams::ShapeResizingBehaviour.Normal;
		}

        /// <summary>
        /// Gets the used defined movement behaviour value.
        /// </summary>
        /// <returns>Movement behaviour value.</returns>
        public override DslEditorDiagrams::ShapeMovementBehaviour GetMovementBehaviourValue()
		{
			return DslEditorDiagrams::ShapeMovementBehaviour.Normal;
		}

        /// <summary>
        /// Gets whether this shape is a relative child shape or not.
        /// </summary>
        /// <returns>True if this shape is a relative child shape. False otherwise</returns>
        public override bool GetIsRelativeChildShapeValue()
		{
			return false;
		}
		
        /// <summary>
        /// Gets whether this shape takes part in any relationship or not.
        /// </summary>
        /// <returns>True if this shape takes part in any relationship. False otherwise</returns>
        public override bool GetTakesPartInRelationshipValue()
		{
			return true;
		}
		#endregion
	}
}
