 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.FamilyTreePerson), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLElementForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLElementForShapesAdded() 
			: base(FamilyTreeDSLElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForShapes.ShapesFactoryHelper
        {
			private static FamilyTreeDSLElementForShapesFactoryHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static FamilyTreeDSLElementForShapesFactoryHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new FamilyTreeDSLElementForShapesFactoryHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}

    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
	/// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLElementForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLElementForShapesChanged() 
			: base(FamilyTreeDSLRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes.RolePlayerChangeHelper
        {
			private static FamilyTreeDSLRolePlayerChangeHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static FamilyTreeDSLRolePlayerChangeHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new FamilyTreeDSLRolePlayerChangeHelper();

    	            return instanceHolder;
    	        }
    	    }
		
			/// <summary>
        	/// Constructor.
        	/// </summary>
			public FamilyTreeDSLRolePlayerChangeHelper() 
				: base(FamilyTreeDSLElementForShapesAdded.FamilyTreeDSLElementForShapesFactoryHelper.Instance,
					   FamilyTreeDSLElementForShapesDeleted.FamilyTreeDSLShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring element deletin that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.FamilyTreePerson), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLElementForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLElementForShapesDeleted() 
			: base(FamilyTreeDSLShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForShapes.ShapeDeletionHelper
        {
			private static FamilyTreeDSLShapeDeletionHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static FamilyTreeDSLShapeDeletionHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new FamilyTreeDSLShapeDeletionHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}
}