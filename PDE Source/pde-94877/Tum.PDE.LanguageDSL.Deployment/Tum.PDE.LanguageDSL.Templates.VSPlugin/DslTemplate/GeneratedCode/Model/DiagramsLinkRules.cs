 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// This AddRule is for monitoring link creation that we need to reflect
	/// onto the diagram surface by creating its specified rs shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.ReferenceRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.EmbeddingRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLLinkForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLLinkForShapesAdded() 
			: base(PDEModelingDSLElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper
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
	/// This ChangeRule is for monitoring link role player changes that we need to reflect
	/// onto the diagram surface.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.ReferenceRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.EmbeddingRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLLinkForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLLinkForShapesChanged() 
			: base(PDEModelingDSLRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes.RolePlayerChangeHelper
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
				: base(PDEModelingDSLLinkForShapesAdded.PDEModelingDSLElementForShapesFactoryHelper.Instance,
					   PDEModelingDSLLinkForShapesDeleted.PDEModelingDSLShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring link deletion that we need to reflect
	/// onto the diagram surface by deleting its specified rs shape clas
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.ReferenceRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.PDE.ModelingDSL.EmbeddingRelationship), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class PDEModelingDSLLinkForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public PDEModelingDSLLinkForShapesDeleted() 
			: base(PDEModelingDSLShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class PDEModelingDSLShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes.ShapeDeletionHelper
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

