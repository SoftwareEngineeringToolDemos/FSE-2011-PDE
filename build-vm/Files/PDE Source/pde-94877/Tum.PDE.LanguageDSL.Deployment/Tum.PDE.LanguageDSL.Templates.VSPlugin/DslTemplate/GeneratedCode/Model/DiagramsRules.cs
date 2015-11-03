 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.DomainElement), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLElementForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLElementForShapesAdded() 
			: base(PDEModelingDSLElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForShapes.ShapesFactoryHelper
        {
			private static PDEModelingDSLElementForShapesFactoryHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static PDEModelingDSLElementForShapesFactoryHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new PDEModelingDSLElementForShapesFactoryHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}

    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
	/// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLElementForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLElementForShapesChanged() 
			: base(PDEModelingDSLRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes.RolePlayerChangeHelper
        {
			private static PDEModelingDSLRolePlayerChangeHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static PDEModelingDSLRolePlayerChangeHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new PDEModelingDSLRolePlayerChangeHelper();

    	            return instanceHolder;
    	        }
    	    }
		
			/// <summary>
        	/// Constructor.
        	/// </summary>
			public PDEModelingDSLRolePlayerChangeHelper() 
				: base(PDEModelingDSLElementForShapesAdded.PDEModelingDSLElementForShapesFactoryHelper.Instance,
					   PDEModelingDSLElementForShapesDeleted.PDEModelingDSLShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring element deletin that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.DomainElement), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLElementForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLElementForShapesDeleted() 
			: base(PDEModelingDSLShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForShapes.ShapeDeletionHelper
        {
			private static PDEModelingDSLShapeDeletionHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static PDEModelingDSLShapeDeletionHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new PDEModelingDSLShapeDeletionHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}
}