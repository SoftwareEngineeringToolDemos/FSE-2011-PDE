 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

namespace Tum.VModellXT
{
	/// <summary>
    /// RolleDependencyShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("71ceb06d-e010-49ee-b5e7-0c46d9d692eb")]
	public partial class RolleDependencyShape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// RolleDependencyShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("71ceb06d-e010-49ee-b5e7-0c46d9d692eb");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RolleDependencyShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public RolleDependencyShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
                return new DslEditorDiagrams::SizeD(240, 40);
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
			return false;
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// DisziplinDependencyShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("e923aec6-6a73-4944-bc51-58d7f2981bb7")]
	public partial class DisziplinDependencyShape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// DisziplinDependencyShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("e923aec6-6a73-4944-bc51-58d7f2981bb7");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DisziplinDependencyShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DisziplinDependencyShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
                return new DslEditorDiagrams::SizeD(240, 40);
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
			return false;
		}
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
    /// ErzAbhDependencyShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("a8ff81cd-ff1a-4f5c-b9a5-abc19f6f3faa")]
	public partial class ErzAbhDependencyShape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// ErzAbhDependencyShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a8ff81cd-ff1a-4f5c-b9a5-abc19f6f3faa");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ErzAbhDependencyShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ErzAbhDependencyShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
                return new DslEditorDiagrams::SizeD(240, 40);
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
			return false;
		}
		#endregion
	}
}
