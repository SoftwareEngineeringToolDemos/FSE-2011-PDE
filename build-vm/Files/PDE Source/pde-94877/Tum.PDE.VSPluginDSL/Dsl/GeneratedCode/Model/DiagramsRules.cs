 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.VSPluginDSL.DomainClass2), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class VSPluginDSLElementForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public VSPluginDSLElementForShapesAdded() 
			: base(VSPluginDSLElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class VSPluginDSLElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForShapes.ShapesFactoryHelper
        {
			private static VSPluginDSLElementForShapesFactoryHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static VSPluginDSLElementForShapesFactoryHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new VSPluginDSLElementForShapesFactoryHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}

    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
	/// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class VSPluginDSLElementForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public VSPluginDSLElementForShapesChanged() 
			: base(VSPluginDSLRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class VSPluginDSLRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes.RolePlayerChangeHelper
        {
			private static VSPluginDSLRolePlayerChangeHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static VSPluginDSLRolePlayerChangeHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new VSPluginDSLRolePlayerChangeHelper();

    	            return instanceHolder;
    	        }
    	    }
		
			/// <summary>
        	/// Constructor.
        	/// </summary>
			public VSPluginDSLRolePlayerChangeHelper() 
				: base(VSPluginDSLElementForShapesAdded.VSPluginDSLElementForShapesFactoryHelper.Instance,
					   VSPluginDSLElementForShapesDeleted.VSPluginDSLShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring element deletin that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.VSPluginDSL.DomainClass2), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class VSPluginDSLElementForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public VSPluginDSLElementForShapesDeleted() 
			: base(VSPluginDSLShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class VSPluginDSLShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForShapes.ShapeDeletionHelper
        {
			private static VSPluginDSLShapeDeletionHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static VSPluginDSLShapeDeletionHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new VSPluginDSLShapeDeletionHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}
}