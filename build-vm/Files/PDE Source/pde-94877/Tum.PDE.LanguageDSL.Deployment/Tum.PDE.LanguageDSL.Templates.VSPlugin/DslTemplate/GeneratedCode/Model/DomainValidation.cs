 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class PDEModelingDSLValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static PDEModelingDSLValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static PDEModelingDSLValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new PDEModelingDSLValidationController();
						
						// initialize
						PDEModelingDSLValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private PDEModelingDSLValidationController() : base()
		{	
		}
        #endregion
	
		#region Initialization		
        /// <summary>
        /// Initializes the static Validation map as well as the Validation is enabled fields in the actual instance of this class.
        /// </summary>
        /// <param name="controller">Controller to initalize</param>
        /// <param name="discardController">Validation controllers to discard.</param>
        public static void Initialize(DslEditorModeling::ModelValidationController controller, System.Collections.Generic.List<string> discardController)
		{
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModel));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainElementBase));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.BaseElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.ReferenceableElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.EmbeddableElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.NamedDomainElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.AttributedDomainElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.BaseDomainElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainPropertyBase));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainProperty));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainElements));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainTypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.ExternalType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainEnumeration));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.EnumerationLiteral));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DETypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRTypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DEType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.BaseDomainElementType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.ReferencingDRType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.EmbeddingDRType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.ConversionModelInfo));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.ReferenceRelationship));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.EmbeddingRelationshipBase));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.EmbeddingRelationship));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTargetBase));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModelHasDETypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DETypesHasDEType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRTypesHasDRType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget));
			InitializeType(controller, typeof(global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo));

			// extern controller
			discardController.Add("global::Tum.PDE.ModelingDSL.PDEModelingDSL");

		}
		#endregion
	}
}

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class PDEModelingDSLValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// NamedDomainElement_Name error ID
    	/// </summary>
		public const string NamedDomainElement_Name = "NamedDomainElement.Name";
		/// <summary>
    	/// DomainProperty_Name error ID
    	/// </summary>
		public const string DomainProperty_Name = "DomainProperty.Name";
		/// <summary>
    	/// DomainProperty_Value error ID
    	/// </summary>
		public const string DomainProperty_Value = "DomainProperty.Value";
		/// <summary>
    	/// DomainType_Name error ID
    	/// </summary>
		public const string DomainType_Name = "DomainType.Name";
		/// <summary>
    	/// ExternalType_Namespace error ID
    	/// </summary>
		public const string ExternalType_Namespace = "ExternalType.Namespace";
		/// <summary>
    	/// DomainEnumeration_IsFlags error ID
    	/// </summary>
		public const string DomainEnumeration_IsFlags = "DomainEnumeration.IsFlags";
		/// <summary>
    	/// EnumerationLiteral_Name error ID
    	/// </summary>
		public const string EnumerationLiteral_Name = "EnumerationLiteral.Name";
		/// <summary>
    	/// BaseDomainElementType_Name error ID
    	/// </summary>
		public const string BaseDomainElementType_Name = "BaseDomainElementType.Name";
		/// <summary>
    	/// ConversionModelInfo_HasModelChanged error ID
    	/// </summary>
		public const string ConversionModelInfo_HasModelChanged = "ConversionModelInfo.HasModelChanged";
		/// <summary>
    	/// ReferenceRelationship_SourceMultiplicity error ID
    	/// </summary>
		public const string ReferenceRelationship_SourceMultiplicity = "ReferenceRelationship.SourceMultiplicity";
		/// <summary>
    	/// ReferenceRelationship_TargetMultiplicity error ID
    	/// </summary>
		public const string ReferenceRelationship_TargetMultiplicity = "ReferenceRelationship.TargetMultiplicity";
		#endregion
		
		#region Relationship Ids
		/// <summary>
    	/// DomainModelHasDomainElements_DomainElements error ID
    	/// </summary>
		public const string DomainModelHasDomainElements_DomainElements = "DomainModelHasDomainElements.DomainElements";
		/// <summary>
    	/// DomainModelHasDomainTypes_DomainTypes error ID
    	/// </summary>
		public const string DomainModelHasDomainTypes_DomainTypes = "DomainModelHasDomainTypes.DomainTypes";
		/// <summary>
    	/// DomainModelHasDETypes_DETypes error ID
    	/// </summary>
		public const string DomainModelHasDETypes_DETypes = "DomainModelHasDETypes.DETypes";
		/// <summary>
    	/// DomainModelHasDRTypes_DRTypes error ID
    	/// </summary>
		public const string DomainModelHasDRTypes_DRTypes = "DomainModelHasDRTypes.DRTypes";
		/// <summary>
    	/// DomainModelHasConversionModelInfo_ConversionModelInfo error ID
    	/// </summary>
		public const string DomainModelHasConversionModelInfo_ConversionModelInfo = "DomainModelHasConversionModelInfo.ConversionModelInfo";
		/// <summary>
    	/// DomainElementReferencesDEType_DEType error ID
    	/// </summary>
		public const string DomainElementReferencesDEType_DEType = "DomainElementReferencesDEType.DEType";
		/// <summary>
    	/// EmbeddingRelationship_Parent error ID
    	/// </summary>
		public const string EmbeddingRelationship_Parent = "EmbeddingRelationship.Parent";
		/// <summary>
    	/// DomainPropertyReferencesDomainType_DomainType error ID
    	/// </summary>
		public const string DomainPropertyReferencesDomainType_DomainType = "DomainPropertyReferencesDomainType.DomainType";
		/// <summary>
    	/// DRTypeReferencesDETypeSource_DETypeSource error ID
    	/// </summary>
		public const string DRTypeReferencesDETypeSource_DETypeSource = "DRTypeReferencesDETypeSource.DETypeSource";
		/// <summary>
    	/// DRTypeReferencesDETypeTarget_DETypeTarget error ID
    	/// </summary>
		public const string DRTypeReferencesDETypeTarget_DETypeTarget = "DRTypeReferencesDETypeTarget.DETypeTarget";
		#endregion		
	}
}

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DomainModel.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class DomainModel
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainModel.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainModel(DslEditorModeling::ModelValidationContext context)
		{

			// validate embedding relationship from DomainModel to DomainElements
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> allMDomainModelHasDomainElementsInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMDomainModelHasDomainElementsInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainModelHasDomainElements_DomainElements, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type DomainElements is missing, although it is required.", this));
			}

			// validate embedding relationship from DomainModel to DomainTypes
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> allMDomainModelHasDomainTypesInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMDomainModelHasDomainTypesInstances1.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainModelHasDomainTypes_DomainTypes, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type DomainTypes is missing, although it is required.", this));
			}

			// validate embedding relationship from DomainModel to DETypes
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> allMDomainModelHasDETypesInstances2 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>(this, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMDomainModelHasDETypesInstances2.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainModelHasDETypes_DETypes, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type DETypes is missing, although it is required.", this));
			}

			// validate embedding relationship from DomainModel to DRTypes
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> allMDomainModelHasDRTypesInstances3 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>(this, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMDomainModelHasDRTypesInstances3.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainModelHasDRTypes_DRTypes, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type DRTypes is missing, although it is required.", this));
			}

			// validate embedding relationship from DomainModel to ConversionModelInfo
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> allMDomainModelHasConversionModelInfoInstances4 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>(this, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMDomainModelHasConversionModelInfoInstances4.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainModelHasConversionModelInfo_ConversionModelInfo, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type ConversionModelInfo is missing, although it is required.", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DomainElement.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class DomainElementBase
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainElement.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainElement(DslEditorModeling::ModelValidationContext context)
		{

			// validate reference relationship from DomainElement to DEType (Side: DomainElement)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> allMDomainElementReferencesDETypeInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>(this, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMDomainElementReferencesDETypeInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainElementReferencesDEType_DEType, DslEditorModeling::ModelValidationViolationType.Error, "Reference to element of type DEType is missing, although it is required. Role name: + ElementType", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate EmbeddableElement.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class EmbeddableElement
	{
		#region Validate
		/// <summary>
   		/// Automatically validates EmbeddableElement.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateEmbeddableElement(DslEditorModeling::ModelValidationContext context)
		{

			// validate reference relationship from Child to Parent (Side: Child)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> allMEmbeddingRelationshipInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(this, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMEmbeddingRelationshipInstances0.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.EmbeddingRelationship_Parent, DslEditorModeling::ModelValidationViolationType.Error, "There are multiple references to elements of type Embeddable Element, although only one is allowed. Role name: + Parent", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate NamedDomainElement.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class NamedDomainElement
	{
		#region Validate
		/// <summary>
   		/// Automatically validates NamedDomainElement.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateNamedDomainElement(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.NamedDomainElement_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DomainProperty.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class DomainPropertyBase
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainProperty.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainProperty(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainProperty_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Value
			if( System.String.IsNullOrEmpty(this.Value) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainProperty_Value, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Value' has no value although it is required", this));
			}

			// validate reference relationship from DomainProperty to DomainType (Side: DomainProperty)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> allMDomainPropertyReferencesDomainTypeInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>(this, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMDomainPropertyReferencesDomainTypeInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainPropertyReferencesDomainType_DomainType, DslEditorModeling::ModelValidationViolationType.Error, "Reference to element of type Domain Type is missing, although it is required. Role name: + DomainType", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DomainType.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class DomainType
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainType.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainType(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainType_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate ExternalType.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class ExternalType
	{
		#region Validate
		/// <summary>
   		/// Automatically validates ExternalType.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateExternalType(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Namespace
			if( System.String.IsNullOrEmpty(this.Namespace) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.ExternalType_Namespace, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Namespace' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DomainEnumeration.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class DomainEnumeration
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainEnumeration.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainEnumeration(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute IsFlags
			if( this.IsFlags == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DomainEnumeration_IsFlags, DslEditorModeling::ModelValidationViolationType.Error, "Property 'IsFlags' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate EnumerationLiteral.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class EnumerationLiteral
	{
		#region Validate
		/// <summary>
   		/// Automatically validates EnumerationLiteral.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateEnumerationLiteral(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.EnumerationLiteral_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate DRType.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class DRType
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DRType.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDRType(DslEditorModeling::ModelValidationContext context)
		{

			// validate reference relationship from DRTypeS to DETypeSource (Side: DRTypeS)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> allMDRTypeReferencesDETypeSourceInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMDRTypeReferencesDETypeSourceInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DRTypeReferencesDETypeSource_DETypeSource, DslEditorModeling::ModelValidationViolationType.Error, "Reference to element of type DEType is missing, although it is required. Role name: + Source", this));
			}

			// validate reference relationship from DRTypeT to DETypeTarget (Side: DRTypeT)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> allMDRTypeReferencesDETypeTargetInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMDRTypeReferencesDETypeTargetInstances1.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.DRTypeReferencesDETypeTarget_DETypeTarget, DslEditorModeling::ModelValidationViolationType.Error, "Reference to element of type DEType is missing, although it is required. Role name: + Target", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate BaseDomainElementType.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public abstract partial class BaseDomainElementType
	{
		#region Validate
		/// <summary>
   		/// Automatically validates BaseDomainElementType.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateBaseDomainElementType(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.BaseDomainElementType_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate ConversionModelInfo.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class ConversionModelInfo
	{
		#region Validate
		/// <summary>
   		/// Automatically validates ConversionModelInfo.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateConversionModelInfo(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute HasModelChanged
			if( this.HasModelChanged == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.ConversionModelInfo_HasModelChanged, DslEditorModeling::ModelValidationViolationType.Error, "Property 'HasModelChanged' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
    /// Partial class used to validate ReferenceRelationship.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class ReferenceRelationship
	{
		#region Validate
		/// <summary>
   		/// Automatically validates ReferenceRelationship.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateReferenceRelationship(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute SourceMultiplicity
			if( this.SourceMultiplicity == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.ReferenceRelationship_SourceMultiplicity, DslEditorModeling::ModelValidationViolationType.Error, "Property 'SourceMultiplicity' has no value although it is required", this));
			}
			// validate required attribute TargetMultiplicity
			if( this.TargetMultiplicity == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.ModelingDSL.PDEModelingDSLValidationMessageIds.ReferenceRelationship_TargetMultiplicity, DslEditorModeling::ModelValidationViolationType.Error, "Property 'TargetMultiplicity' has no value although it is required", this));
			}
		}
		#endregion
	}
}
