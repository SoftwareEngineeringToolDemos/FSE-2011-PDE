 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// PersonShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("08fd5bd2-497b-4e8b-be71-221e8993b83f")]
	public partial class PersonShape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// PersonShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("08fd5bd2-497b-4e8b-be71-221e8993b83f");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public PersonShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public PersonShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
                return new DslEditorDiagrams::SizeD(100, 100);
            }
        }
		
		 /// <summary>
        /// Gets the used defined resizing behaviour value.
        /// </summary>
        /// <returns>Resizing behaviour value.</returns>
        public override DslEditorDiagrams::ShapeResizingBehaviour GetResizingBehaviourValue()
		{
			return DslEditorDiagrams::ShapeResizingBehaviour.FixedHeight;
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
namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// ParentOfShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("32694186-01cc-41a8-9734-76f6d847356a")]
	public partial class ParentOfShape : DslEditorDiagrams::LinkShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// ParentOfShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("32694186-01cc-41a8-9734-76f6d847356a");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ParentOfShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ParentOfShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// MarriedToShape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("c79ea295-9a47-4f70-824a-ef7a5c069c49")]
	public partial class MarriedToShape : DslEditorDiagrams::LinkShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// MarriedToShape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("c79ea295-9a47-4f70-824a-ef7a5c069c49");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public MarriedToShape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public MarriedToShape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
	}
}
