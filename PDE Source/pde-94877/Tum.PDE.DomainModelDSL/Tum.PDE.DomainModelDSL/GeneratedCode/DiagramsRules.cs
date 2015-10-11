 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.TestLanguage
{
	/// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.TestLanguage.Test), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class TestLanguageElementForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public TestLanguageElementForShapesAdded() 
			: base(TestLanguageElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class TestLanguageElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForShapes.ShapesFactoryHelper
        {
			private static TestLanguageElementForShapesFactoryHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static TestLanguageElementForShapesFactoryHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new TestLanguageElementForShapesFactoryHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}

    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
	/// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.TestLanguage.DomainModelHasTest), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class TestLanguageElementForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public TestLanguageElementForShapesChanged() 
			: base(TestLanguageRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class TestLanguageRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes.RolePlayerChangeHelper
        {
			private static TestLanguageRolePlayerChangeHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static TestLanguageRolePlayerChangeHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new TestLanguageRolePlayerChangeHelper();

    	            return instanceHolder;
    	        }
    	    }
		
			/// <summary>
        	/// Constructor.
        	/// </summary>
			public TestLanguageRolePlayerChangeHelper() 
				: base(TestLanguageElementForShapesAdded.TestLanguageElementForShapesFactoryHelper.Instance,
					   TestLanguageElementForShapesDeleted.TestLanguageShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring element deletin that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.TestLanguage.Test), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class TestLanguageElementForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public TestLanguageElementForShapesDeleted() 
			: base(TestLanguageShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class TestLanguageShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForShapes.ShapeDeletionHelper
        {
			private static TestLanguageShapeDeletionHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static TestLanguageShapeDeletionHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new TestLanguageShapeDeletionHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}
}