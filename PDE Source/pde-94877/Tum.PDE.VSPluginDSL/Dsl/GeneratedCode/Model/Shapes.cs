 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// DomainClass2Shape class representing a Shape.
    /// </summary>
	[DslModeling::DomainObjectId("7b4698d6-a6a3-43d7-9327-738976f58cc6")]
	public partial class DomainClass2Shape : DslEditorDiagrams::NodeShape
	{
		#region Constructors, domain class Id

		/// <summary>
		/// DomainClass2Shape domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7b4698d6-a6a3-43d7-9327-738976f58cc6");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainClass2Shape(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainClass2Shape(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
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
			return false;
		}
		#endregion
	}
}
