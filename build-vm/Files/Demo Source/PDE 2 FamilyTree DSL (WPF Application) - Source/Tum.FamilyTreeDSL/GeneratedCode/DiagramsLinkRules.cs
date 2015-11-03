 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// This AddRule is for monitoring link creation that we need to reflect
	/// onto the diagram surface by creating its specified rs shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.ParentOf), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.MarriedTo), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLLinkForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLLinkForShapesAdded() 
			: base(FamilyTreeDSLElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper
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
	/// This ChangeRule is for monitoring link role player changes that we need to reflect
	/// onto the diagram surface.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.ParentOf), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.MarriedTo), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLLinkForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLLinkForShapesChanged() 
			: base(FamilyTreeDSLRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes.RolePlayerChangeHelper
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
				: base(FamilyTreeDSLLinkForShapesAdded.FamilyTreeDSLElementForShapesFactoryHelper.Instance,
					   FamilyTreeDSLLinkForShapesDeleted.FamilyTreeDSLShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring link deletion that we need to reflect
	/// onto the diagram surface by deleting its specified rs shape clas
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.ParentOf), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.FamilyTreeDSL.MarriedTo), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class FamilyTreeDSLLinkForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public FamilyTreeDSLLinkForShapesDeleted() 
			: base(FamilyTreeDSLShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class FamilyTreeDSLShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes.ShapeDeletionHelper
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

