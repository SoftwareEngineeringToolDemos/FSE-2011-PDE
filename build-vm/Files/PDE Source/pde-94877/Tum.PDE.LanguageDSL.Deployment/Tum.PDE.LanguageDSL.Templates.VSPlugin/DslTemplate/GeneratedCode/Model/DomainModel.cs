 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainModel PDEModelingDSLDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("adbcb32f-6ad7-4855-b8ca-3f14f4c4593a")]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorDiagrams::DiagramsDSLDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorModeling::DomainModelDslEditorModeling))]
	public partial class PDEModelingDSLDomainModel : DslEditorModeling::DomainModelBase
	{
		#region Constructor, domain model Id

		/// <summary>
		/// PDEModelingDSLDomainModel domain model Id.
		/// </summary>
		public static readonly new global::System.Guid DomainModelId = new System.Guid("adbcb32f-6ad7-4855-b8ca-3f14f4c4593a");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public PDEModelingDSLDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
	

		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
		#endregion	
		#region Domain model reflection
		
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(DomainModel),
				typeof(DomainElement),
				typeof(BaseElement),
				typeof(ReferenceableElement),
				typeof(EmbeddableElement),
				typeof(NamedDomainElement),
				typeof(AttributedDomainElement),
				typeof(BaseDomainElement),
				typeof(DomainProperty),
				typeof(DomainElements),
				typeof(DomainTypes),
				typeof(DomainType),
				typeof(ExternalType),
				typeof(DomainEnumeration),
				typeof(EnumerationLiteral),
				typeof(DETypes),
				typeof(DRTypes),
				typeof(DEType),
				typeof(DRType),
				typeof(BaseDomainElementType),
				typeof(ReferencingDRType),
				typeof(EmbeddingDRType),
				typeof(ConversionModelInfo),
				typeof(ReferenceShape),
				typeof(EmbeddingShape),
				typeof(DomainElementShape),
				typeof(AttributedDomainElementHasDomainProperty),
				typeof(ReferenceRelationship),
				typeof(EmbeddingRelationship),
				typeof(BaseElementSourceReferencesBaseElementTarget),
				typeof(DomainModelHasDomainElements),
				typeof(DomainElementsHasDomainElement),
				typeof(DomainModelHasDomainTypes),
				typeof(DomainTypesHasDomainType),
				typeof(DomainEnumerationHasEnumerationLiteral),
				typeof(DomainPropertyReferencesDomainType),
				typeof(DomainModelHasDETypes),
				typeof(DomainModelHasDRTypes),
				typeof(DETypesHasDEType),
				typeof(DRTypesHasDRType),
				typeof(DomainElementReferencesDEType),
				typeof(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget),
				typeof(DRTypeReferencesDETypeSource),
				typeof(DRTypeReferencesDETypeTarget),
				typeof(DomainModelHasConversionModelInfo),
				typeof(DesignerDiagram),
				typeof(ConversionDiagram),
				typeof(PDEModelingDSLElementForShapesAdded),
				typeof(PDEModelingDSLElementForShapesChanged),
				typeof(PDEModelingDSLElementForShapesDeleted),
				typeof(PDEModelingDSLLinkForShapesAdded),
				typeof(PDEModelingDSLLinkForShapesChanged),
				typeof(PDEModelingDSLLinkForShapesDeleted),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(NamedDomainElement), "Name", NamedDomainElement.NameDomainPropertyId, typeof(NamedDomainElement.NamePropertyHandler)),
				new DomainMemberInfo(typeof(NamedDomainElement), "Description", NamedDomainElement.DescriptionDomainPropertyId, typeof(NamedDomainElement.DescriptionPropertyHandler)),
				new DomainMemberInfo(typeof(DomainProperty), "Name", DomainProperty.NameDomainPropertyId, typeof(DomainProperty.NamePropertyHandler)),
				new DomainMemberInfo(typeof(DomainProperty), "Value", DomainProperty.ValueDomainPropertyId, typeof(DomainProperty.ValuePropertyHandler)),
				new DomainMemberInfo(typeof(DomainType), "Name", DomainType.NameDomainPropertyId, typeof(DomainType.NamePropertyHandler)),
				new DomainMemberInfo(typeof(ExternalType), "Namespace", ExternalType.NamespaceDomainPropertyId, typeof(ExternalType.NamespacePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEnumeration), "IsFlags", DomainEnumeration.IsFlagsDomainPropertyId, typeof(DomainEnumeration.IsFlagsPropertyHandler)),
				new DomainMemberInfo(typeof(EnumerationLiteral), "Name", EnumerationLiteral.NameDomainPropertyId, typeof(EnumerationLiteral.NamePropertyHandler)),
				new DomainMemberInfo(typeof(EnumerationLiteral), "Value", EnumerationLiteral.ValueDomainPropertyId, typeof(EnumerationLiteral.ValuePropertyHandler)),
				new DomainMemberInfo(typeof(DEType), "StyleType", DEType.StyleTypeDomainPropertyId, typeof(DEType.StyleTypePropertyHandler)),
				new DomainMemberInfo(typeof(DEType), "ColorType", DEType.ColorTypeDomainPropertyId, typeof(DEType.ColorTypePropertyHandler)),
				new DomainMemberInfo(typeof(DEType), "FormType", DEType.FormTypeDomainPropertyId, typeof(DEType.FormTypePropertyHandler)),
				new DomainMemberInfo(typeof(DEType), "FileName", DEType.FileNameDomainPropertyId, typeof(DEType.FileNamePropertyHandler)),
				new DomainMemberInfo(typeof(BaseDomainElementType), "Name", BaseDomainElementType.NameDomainPropertyId, typeof(BaseDomainElementType.NamePropertyHandler)),
				new DomainMemberInfo(typeof(ConversionModelInfo), "HasModelChanged", ConversionModelInfo.HasModelChangedDomainPropertyId, typeof(ConversionModelInfo.HasModelChangedPropertyHandler)),
				new DomainMemberInfo(typeof(ReferenceRelationship), "SourceMultiplicity", ReferenceRelationship.SourceMultiplicityDomainPropertyId, typeof(ReferenceRelationship.SourceMultiplicityPropertyHandler)),
				new DomainMemberInfo(typeof(ReferenceRelationship), "TargetMultiplicity", ReferenceRelationship.TargetMultiplicityDomainPropertyId, typeof(ReferenceRelationship.TargetMultiplicityPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(AttributedDomainElementHasDomainProperty), "AttributedDomainElement", AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId),
				new DomainRolePlayerInfo(typeof(AttributedDomainElementHasDomainProperty), "DomainProperty", AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenceRelationship), "Source", ReferenceRelationship.SourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(ReferenceRelationship), "Target", ReferenceRelationship.TargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(EmbeddingRelationship), "Child", EmbeddingRelationship.ChildDomainRoleId),
				new DomainRolePlayerInfo(typeof(EmbeddingRelationship), "Parent", EmbeddingRelationship.ParentDomainRoleId),
				new DomainRolePlayerInfo(typeof(BaseElementSourceReferencesBaseElementTarget), "BaseElementSource", BaseElementSourceReferencesBaseElementTarget.BaseElementSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(BaseElementSourceReferencesBaseElementTarget), "BaseElementTarget", BaseElementSourceReferencesBaseElementTarget.BaseElementTargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainElements), "DomainModel", DomainModelHasDomainElements.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainElements), "DomainElements", DomainModelHasDomainElements.DomainElementsDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainElementsHasDomainElement), "DomainElements", DomainElementsHasDomainElement.DomainElementsDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainElementsHasDomainElement), "DomainElement", DomainElementsHasDomainElement.DomainElementDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainTypes), "DomainModel", DomainModelHasDomainTypes.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainTypes), "DomainTypes", DomainModelHasDomainTypes.DomainTypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainTypesHasDomainType), "DomainTypes", DomainTypesHasDomainType.DomainTypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainTypesHasDomainType), "DomainType", DomainTypesHasDomainType.DomainTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEnumerationHasEnumerationLiteral), "DomainEnumeration", DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEnumerationHasEnumerationLiteral), "EnumerationLiteral", DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainPropertyReferencesDomainType), "DomainProperty", DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainPropertyReferencesDomainType), "DomainType", DomainPropertyReferencesDomainType.DomainTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDETypes), "DomainModel", DomainModelHasDETypes.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDETypes), "DETypes", DomainModelHasDETypes.DETypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDRTypes), "DomainModel", DomainModelHasDRTypes.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDRTypes), "DRTypes", DomainModelHasDRTypes.DRTypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DETypesHasDEType), "DETypes", DETypesHasDEType.DETypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DETypesHasDEType), "DEType", DETypesHasDEType.DETypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypesHasDRType), "DRTypes", DRTypesHasDRType.DRTypesDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypesHasDRType), "DRType", DRTypesHasDRType.DRTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainElementReferencesDEType), "DomainElement", DomainElementReferencesDEType.DomainElementDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainElementReferencesDEType), "DEType", DomainElementReferencesDEType.DETypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget), "DRType", DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget), "BaseElementSourceReferencesBaseElementTarget", DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.BaseElementSourceReferencesBaseElementTargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesDETypeSource), "DRTypeS", DRTypeReferencesDETypeSource.DRTypeSDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesDETypeSource), "DETypeSource", DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesDETypeTarget), "DRTypeT", DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId),
				new DomainRolePlayerInfo(typeof(DRTypeReferencesDETypeTarget), "DETypeTarget", DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasConversionModelInfo), "DomainModel", DomainModelHasConversionModelInfo.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasConversionModelInfo), "ConversionModelInfo", DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId),
			};
		}
		#endregion
		#region Domain model advanced reflection
		/// <summary>
        /// Gets domain classes advanced reflection information.
        /// </summary>
        public override DslEditorModeling::DomainClassAdvancedInfo[] GetDomainClassAdvancedInfo()
		{
			return new DslEditorModeling::DomainClassAdvancedInfo[]
			{
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DETypes.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DEType.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.DRType.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId)
				{
					IsAbstract = false
				}
				,
	
			};
		}
		
        /// <summary>
        /// Gets domain relationships advanced reflection information.
        /// </summary>
        public override DslEditorModeling::DomainRelationshipAdvancedInfo[] GetDomainRelationshipAdvancedInfo()
		{
			return new DslEditorModeling::DomainRelationshipAdvancedInfo[]
			{
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = false,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = false,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = false,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = false,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId, false, true, true)
				{
					IsAbstract = true,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.BaseElementSourceDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.BaseElementTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = false,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = false,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainElementsDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementsDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainTypesDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypesDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainTypeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = false,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DETypes.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DETypesDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = true,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DRTypesDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = true,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DETypesHasDEType.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DETypes.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DEType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypesDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DRType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypesDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DEType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DRType.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.BaseElementSourceReferencesBaseElementTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DRType.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DEType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DRType.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.DEType.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId,
					SourceRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.One,
					TargetRoleMultiplicity = DslModeling::Multiplicity.One,
					SourceRoleIsUIBrowsable = true,
					SourceRoleIsUIReadOnly = false,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = true,
					TargetRoleIsUIReadOnly = false,
					TargetRoleIsGenerated = true,
				}
				,
	
			};
		}
		
        /// <summary>
        /// Gets the embedding relationships order information (parent-child mappings in the order of the serialization model).
        /// </summary>
        public override DslEditorModeling::EmbeddingRelationshipOrderInfo[] GetEmbeddingRelationshipOrderInfo()
		{
			return new DslEditorModeling::EmbeddingRelationshipOrderInfo[] 
			{
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainClassId,
						global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainClassId,
						global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainClassId,
						global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainClassId,
						global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DETypes.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DETypesHasDEType.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DEType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.DRType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
			};
		}

        /// <summary>
        /// Gets the model context informations.
        /// </summary>
        public override DslEditorModeling::ModelContextInfo[] GetModelContextInfo()
		{
			return new DslEditorModeling::ModelContextInfo[] 
			{
				new DslEditorModeling::ModelContextInfo(DefaultContextModelContext.DomainClassId, global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId),
	
			};
		}
		#endregion
		#region Diagrams model advanced reflection
		private class PDEModelingDSLDiagramDomainDataDirectory : DslEditorDiagrams::DiagramDomainDataDirectory
		{
			/// <summary>
        	/// Gets the diagram class information.
        	/// </summary>
        	/// <returns>Diagram class info.</returns>
        	public override DslEditorDiagrams::DiagramClassInfo[] GetDiagramClassInfo()
			{
				return new DslEditorDiagrams::DiagramClassInfo[]
				{
					new DslEditorDiagrams::DiagramClassInfo(Tum.PDE.ModelingDSL.DesignerDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Normal),
					new DslEditorDiagrams::DiagramClassInfo(Tum.PDE.ModelingDSL.ConversionDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Normal),
				};
			}

			/// <summary>
        	/// Gets the shape class information.
        	/// </summary>
        	/// <returns>Shape class info.</returns>
        	public override DslEditorDiagrams::ShapeClassInfo[] GetShapeClassInfo()
			{
				return new DslEditorDiagrams::ShapeClassInfo[]
				{
					new DslEditorDiagrams::ShapeClassInfo(Tum.PDE.ModelingDSL.DesignerDiagram.DomainClassId, global::Tum.PDE.ModelingDSL.DomainElementShape.DomainClassId, global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId, false)
					{
					},
				
				};
			}

        	/// <summary>
        	/// Gets the rs shape class information.
        	/// </summary>
        	/// <returns>RSShape class info.</returns>
        	public override DslEditorDiagrams::RelationshipShapeInfo[] GetRelationshipShapeInfo()
			{
				return new DslEditorDiagrams::RelationshipShapeInfo[]
				{
					new DslEditorDiagrams::RelationshipShapeInfo(Tum.PDE.ModelingDSL.DesignerDiagram.DomainClassId, global::Tum.PDE.ModelingDSL.ReferenceShape.DomainClassId, global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId),
					new DslEditorDiagrams::RelationshipShapeInfo(Tum.PDE.ModelingDSL.DesignerDiagram.DomainClassId, global::Tum.PDE.ModelingDSL.EmbeddingShape.DomainClassId, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId),
				
				};
			}
			
        	/// <summary>
        	/// Gets the mapping rs shape class information.
        	/// </summary>
        	/// <returns>MappingRSShape class info.</returns>
        	public override DslEditorDiagrams::MappingRelationshipShapeInfo[] GetMappingRelationshipShapeInfo()
			{
				return new DslEditorDiagrams::MappingRelationshipShapeInfo[]
				{
					
				};
			}
			
        	/// <summary>
        	/// Gets the shape class information.
        	/// </summary>
        	/// <returns>Shape class info.</returns>
        	public override System.Guid[] GetClassesRelevantForSM()
			{
				return new System.Guid[]
				{
					global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId,
					global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId,
					global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId,
					
				};
			}
		}
		
		/// <summary>
        /// Gets data extensions.
        /// </summary>
        /// <returns>List of data extensions or null.</returns>
		public override DslEditorModeling::IDomainDataExtensionDirectory[] GetDataExtensions()
        {
            return new DslEditorModeling::IDomainDataExtensionDirectory[]
			{
				new PDEModelingDSLDiagramDomainDataDirectory()
			};
        }
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;

		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
			
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(26);
				createElementMap.Add(typeof(DomainModel), 0);
				createElementMap.Add(typeof(DomainElement), 1);
				createElementMap.Add(typeof(DomainProperty), 2);
				createElementMap.Add(typeof(DomainElements), 3);
				createElementMap.Add(typeof(DomainTypes), 4);
				createElementMap.Add(typeof(ExternalType), 5);
				createElementMap.Add(typeof(DomainEnumeration), 6);
				createElementMap.Add(typeof(EnumerationLiteral), 7);
				createElementMap.Add(typeof(DETypes), 8);
				createElementMap.Add(typeof(DRTypes), 9);
				createElementMap.Add(typeof(DEType), 10);
				createElementMap.Add(typeof(ReferencingDRType), 11);
				createElementMap.Add(typeof(EmbeddingDRType), 12);
				createElementMap.Add(typeof(ConversionModelInfo), 13);
				createElementMap.Add(typeof(ReferenceShape), 14);
				createElementMap.Add(typeof(EmbeddingShape), 15);
				createElementMap.Add(typeof(DomainElementShape), 16);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new DomainModel(partition, propertyAssignments);
				case 1: return new DomainElement(partition, propertyAssignments);
				case 2: return new DomainProperty(partition, propertyAssignments);
				case 3: return new DomainElements(partition, propertyAssignments);
				case 4: return new DomainTypes(partition, propertyAssignments);
				case 5: return new ExternalType(partition, propertyAssignments);
				case 6: return new DomainEnumeration(partition, propertyAssignments);
				case 7: return new EnumerationLiteral(partition, propertyAssignments);
				case 8: return new DETypes(partition, propertyAssignments);
				case 9: return new DRTypes(partition, propertyAssignments);
				case 10: return new DEType(partition, propertyAssignments);
				case 11: return new ReferencingDRType(partition, propertyAssignments);
				case 12: return new EmbeddingDRType(partition, propertyAssignments);
				case 13: return new ConversionModelInfo(partition, propertyAssignments);
				case 14: return new ReferenceShape(partition, propertyAssignments);
				case 15: return new EmbeddingShape(partition, propertyAssignments);
				case 16: return new DomainElementShape(partition, propertyAssignments);
				default: return null;
			}
		}

		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;

		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
			
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(0);
				createElementLinkMap.Add(typeof(AttributedDomainElementHasDomainProperty), 0);
				createElementLinkMap.Add(typeof(ReferenceRelationship), 1);
				createElementLinkMap.Add(typeof(EmbeddingRelationship), 2);
				createElementLinkMap.Add(typeof(DomainModelHasDomainElements), 3);
				createElementLinkMap.Add(typeof(DomainElementsHasDomainElement), 4);
				createElementLinkMap.Add(typeof(DomainModelHasDomainTypes), 5);
				createElementLinkMap.Add(typeof(DomainTypesHasDomainType), 6);
				createElementLinkMap.Add(typeof(DomainEnumerationHasEnumerationLiteral), 7);
				createElementLinkMap.Add(typeof(DomainPropertyReferencesDomainType), 8);
				createElementLinkMap.Add(typeof(DomainModelHasDETypes), 9);
				createElementLinkMap.Add(typeof(DomainModelHasDRTypes), 10);
				createElementLinkMap.Add(typeof(DETypesHasDEType), 11);
				createElementLinkMap.Add(typeof(DRTypesHasDRType), 12);
				createElementLinkMap.Add(typeof(DomainElementReferencesDEType), 13);
				createElementLinkMap.Add(typeof(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget), 14);
				createElementLinkMap.Add(typeof(DRTypeReferencesDETypeSource), 15);
				createElementLinkMap.Add(typeof(DRTypeReferencesDETypeTarget), 16);
				createElementLinkMap.Add(typeof(DomainModelHasConversionModelInfo), 17);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
		
			}
			switch (index)
			{
				case 0: return new AttributedDomainElementHasDomainProperty(partition, roleAssignments, propertyAssignments);
				case 1: return new ReferenceRelationship(partition, roleAssignments, propertyAssignments);
				case 2: return new EmbeddingRelationship(partition, roleAssignments, propertyAssignments);
				case 3: return new DomainModelHasDomainElements(partition, roleAssignments, propertyAssignments);
				case 4: return new DomainElementsHasDomainElement(partition, roleAssignments, propertyAssignments);
				case 5: return new DomainModelHasDomainTypes(partition, roleAssignments, propertyAssignments);
				case 6: return new DomainTypesHasDomainType(partition, roleAssignments, propertyAssignments);
				case 7: return new DomainEnumerationHasEnumerationLiteral(partition, roleAssignments, propertyAssignments);
				case 8: return new DomainPropertyReferencesDomainType(partition, roleAssignments, propertyAssignments);
				case 9: return new DomainModelHasDETypes(partition, roleAssignments, propertyAssignments);
				case 10: return new DomainModelHasDRTypes(partition, roleAssignments, propertyAssignments);
				case 11: return new DETypesHasDEType(partition, roleAssignments, propertyAssignments);
				case 12: return new DRTypesHasDRType(partition, roleAssignments, propertyAssignments);
				case 13: return new DomainElementReferencesDEType(partition, roleAssignments, propertyAssignments);
				case 14: return new DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(partition, roleAssignments, propertyAssignments);
				case 15: return new DRTypeReferencesDETypeSource(partition, roleAssignments, propertyAssignments);
				case 16: return new DRTypeReferencesDETypeTarget(partition, roleAssignments, propertyAssignments);
				case 17: return new DomainModelHasConversionModelInfo(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion	
		#region Resource manager
	
		private static global::System.Resources.ResourceManager resourceManager;
	
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx";
	
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return PDEModelingDSLDomainModel.SingletonResourceManager;
			}
		}

		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (PDEModelingDSLDomainModel.resourceManager == null)
				{
					PDEModelingDSLDomainModel.resourceManager = new global::System.Resources.ResourceManager(
                        ResourceBaseName, typeof(PDEModelingDSLDomainModel).Assembly);
				}
				return PDEModelingDSLDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return PDEModelingDSLDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return PDEModelingDSLDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (PDEModelingDSLDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new PDEModelingDSLCopyClosure());
					
					PDEModelingDSLDomainModel.copyClosure = copyFilter;
				}
				return PDEModelingDSLDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (PDEModelingDSLDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new PDEModelingDSLDeleteClosure());
		
					PDEModelingDSLDomainModel.removeClosure = removeFilter;
				}
				return PDEModelingDSLDomainModel.removeClosure;
			}
		}
		#endregion
	}
	
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	public partial class PDEModelingDSLDeleteClosure : PDEModelingDSLDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public PDEModelingDSLDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class PDEModelingDSLDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public PDEModelingDSLDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainElementsDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainTypesDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypeDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DETypesDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DRTypesDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypeDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypeDomainRoleId, true);
			DomainRoles.Add(global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	public partial class PDEModelingDSLCopyClosure : PDEModelingDSLCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public PDEModelingDSLCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class PDEModelingDSLCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public PDEModelingDSLCopyClosureBase():base()
		{
		}
	}
	#endregion	
}

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainEnumeration: ShapeColorType
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(ShapeColorTypeEnumConverter))]
	public enum ShapeColorType
	{
		/// <summary>
		/// Default
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Default.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Default,
		/// <summary>
		/// Color1
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color1.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color1,
		/// <summary>
		/// Color2
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color2.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color2,
		/// <summary>
		/// Color3
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color3.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color3,
		/// <summary>
		/// Color4
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color4.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color4,
		/// <summary>
		/// Color5
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color5.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color5,
		/// <summary>
		/// Color6
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color6.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color6,
		/// <summary>
		/// Color7
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeColorType/Color7.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Color7,
	}
	/// <summary>
	/// Type converter for ShapeColorType enumeration.
	/// </summary>
	public class ShapeColorTypeEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<ShapeColorType, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public ShapeColorTypeEnumConverter() : base(typeof(ShapeColorType))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<ShapeColorType, string>();
			dictionary.Add(ShapeColorType.Default, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Default.DisplayName"));
			dictionary.Add(ShapeColorType.Color1, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color1.DisplayName"));
			dictionary.Add(ShapeColorType.Color2, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color2.DisplayName"));
			dictionary.Add(ShapeColorType.Color3, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color3.DisplayName"));
			dictionary.Add(ShapeColorType.Color4, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color4.DisplayName"));
			dictionary.Add(ShapeColorType.Color5, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color5.DisplayName"));
			dictionary.Add(ShapeColorType.Color6, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color6.DisplayName"));
			dictionary.Add(ShapeColorType.Color7, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeColorType/Color7.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to ShapeColorType.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>ShapeColorType object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(ShapeColorType d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			ShapeColorType? strValue = value as ShapeColorType?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainEnumeration: ShapeStyleType
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(ShapeStyleTypeEnumConverter))]
	public enum ShapeStyleType
	{
		/// <summary>
		/// Default
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Default.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Default,
		/// <summary>
		/// Style1
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Style1.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Style1,
		/// <summary>
		/// Style2
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Style2.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Style2,
		/// <summary>
		/// Style3
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Style3.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Style3,
		/// <summary>
		/// Style4
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Style4.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Style4,
		/// <summary>
		/// Style5
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Style5.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Style5,
		/// <summary>
		/// Image
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeStyleType/Image.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Image,
	}
	/// <summary>
	/// Type converter for ShapeStyleType enumeration.
	/// </summary>
	public class ShapeStyleTypeEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<ShapeStyleType, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public ShapeStyleTypeEnumConverter() : base(typeof(ShapeStyleType))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<ShapeStyleType, string>();
			dictionary.Add(ShapeStyleType.Default, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Default.DisplayName"));
			dictionary.Add(ShapeStyleType.Style1, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Style1.DisplayName"));
			dictionary.Add(ShapeStyleType.Style2, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Style2.DisplayName"));
			dictionary.Add(ShapeStyleType.Style3, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Style3.DisplayName"));
			dictionary.Add(ShapeStyleType.Style4, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Style4.DisplayName"));
			dictionary.Add(ShapeStyleType.Style5, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Style5.DisplayName"));
			dictionary.Add(ShapeStyleType.Image, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeStyleType/Image.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to ShapeStyleType.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>ShapeStyleType object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(ShapeStyleType d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			ShapeStyleType? strValue = value as ShapeStyleType?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainEnumeration: ShapeFormType
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(ShapeFormTypeEnumConverter))]
	public enum ShapeFormType
	{
		/// <summary>
		/// Rectangle
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Rectangle.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Rectangle,
		/// <summary>
		/// RoundedRectangle
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/RoundedRectangle.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		RoundedRectangle,
		/// <summary>
		/// Circle
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Circle.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Circle,
		/// <summary>
		/// Decision
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Decision.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Decision,
		/// <summary>
		/// RectangleAngl
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/RectangleAngl.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		RectangleAngl,
		/// <summary>
		/// RectangleSd
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/RectangleSd.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		RectangleSd,
		/// <summary>
		/// Document
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Document.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Document,
		/// <summary>
		/// Predefined
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Predefined.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Predefined,
		/// <summary>
		/// StoredData
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/StoredData.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		StoredData,
		/// <summary>
		/// InternalStorage
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/InternalStorage.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		InternalStorage,
		/// <summary>
		/// Preparation
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Preparation.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Preparation,
		/// <summary>
		/// ManualOperation
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/ManualOperation.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		ManualOperation,
		/// <summary>
		/// OffPageReference
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/OffPageReference.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		OffPageReference,
		/// <summary>
		/// Star
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Star.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Star,
		/// <summary>
		/// Stop
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Stop.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Stop,
		/// <summary>
		/// SequentialData
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/SequentialData.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		SequentialData,
		/// <summary>
		/// DirectData
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/DirectData.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		DirectData,
		/// <summary>
		/// ManualInput
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/ManualInput.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		ManualInput,
		/// <summary>
		/// Card
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Card.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Card,
		/// <summary>
		/// PaperTape
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/PaperTape.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		PaperTape,
		/// <summary>
		/// Delay
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Delay.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Delay,
		/// <summary>
		/// Display
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/Display.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Display,
		/// <summary>
		/// LoopLimit
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ShapeFormType/LoopLimit.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		LoopLimit,
	}
	/// <summary>
	/// Type converter for ShapeFormType enumeration.
	/// </summary>
	public class ShapeFormTypeEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<ShapeFormType, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public ShapeFormTypeEnumConverter() : base(typeof(ShapeFormType))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<ShapeFormType, string>();
			dictionary.Add(ShapeFormType.Rectangle, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Rectangle.DisplayName"));
			dictionary.Add(ShapeFormType.RoundedRectangle, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/RoundedRectangle.DisplayName"));
			dictionary.Add(ShapeFormType.Circle, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Circle.DisplayName"));
			dictionary.Add(ShapeFormType.Decision, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Decision.DisplayName"));
			dictionary.Add(ShapeFormType.RectangleAngl, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/RectangleAngl.DisplayName"));
			dictionary.Add(ShapeFormType.RectangleSd, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/RectangleSd.DisplayName"));
			dictionary.Add(ShapeFormType.Document, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Document.DisplayName"));
			dictionary.Add(ShapeFormType.Predefined, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Predefined.DisplayName"));
			dictionary.Add(ShapeFormType.StoredData, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/StoredData.DisplayName"));
			dictionary.Add(ShapeFormType.InternalStorage, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/InternalStorage.DisplayName"));
			dictionary.Add(ShapeFormType.Preparation, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Preparation.DisplayName"));
			dictionary.Add(ShapeFormType.ManualOperation, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/ManualOperation.DisplayName"));
			dictionary.Add(ShapeFormType.OffPageReference, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/OffPageReference.DisplayName"));
			dictionary.Add(ShapeFormType.Star, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Star.DisplayName"));
			dictionary.Add(ShapeFormType.Stop, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Stop.DisplayName"));
			dictionary.Add(ShapeFormType.SequentialData, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/SequentialData.DisplayName"));
			dictionary.Add(ShapeFormType.DirectData, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/DirectData.DisplayName"));
			dictionary.Add(ShapeFormType.ManualInput, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/ManualInput.DisplayName"));
			dictionary.Add(ShapeFormType.Card, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Card.DisplayName"));
			dictionary.Add(ShapeFormType.PaperTape, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/PaperTape.DisplayName"));
			dictionary.Add(ShapeFormType.Delay, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Delay.DisplayName"));
			dictionary.Add(ShapeFormType.Display, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/Display.DisplayName"));
			dictionary.Add(ShapeFormType.LoopLimit, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.ShapeFormType/LoopLimit.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to ShapeFormType.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>ShapeFormType object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(ShapeFormType d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			ShapeFormType? strValue = value as ShapeFormType?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainEnumeration: Multiplicity
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(MultiplicityEnumConverter))]
	public enum Multiplicity
	{
		/// <summary>
		/// One
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.Multiplicity/One.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		One,
		/// <summary>
		/// ZeroOne
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.Multiplicity/ZeroOne.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		ZeroOne,
		/// <summary>
		/// Many
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.Multiplicity/Many.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		Many,
		/// <summary>
		/// ZeroMany
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.Multiplicity/ZeroMany.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		ZeroMany,
		/// <summary>
		/// OneMany
		/// </summary>
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.Multiplicity/OneMany.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		OneMany,
	}
	/// <summary>
	/// Type converter for Multiplicity enumeration.
	/// </summary>
	public class MultiplicityEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<Multiplicity, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public MultiplicityEnumConverter() : base(typeof(Multiplicity))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<Multiplicity, string>();
			dictionary.Add(Multiplicity.One, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.Multiplicity/One.DisplayName"));
			dictionary.Add(Multiplicity.ZeroOne, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.Multiplicity/ZeroOne.DisplayName"));
			dictionary.Add(Multiplicity.Many, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.Multiplicity/Many.DisplayName"));
			dictionary.Add(Multiplicity.ZeroMany, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.Multiplicity/ZeroMany.DisplayName"));
			dictionary.Add(Multiplicity.OneMany, global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.SingletonResourceManager.GetString("Tum.PDE.ModelingDSL.Multiplicity/OneMany.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to Multiplicity.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>Multiplicity object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(Multiplicity d in dictionary.Keys )
				{
					if( dictionary[d] == strValue )
						return d;
				}
	
			}
	        return base.ConvertFrom(context, culture, value);
	    }
	
		/// <summary>
	    /// Converts the given value object to the specified destination type.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value"> System.Object to convert.</param>
	    /// <param name="destinationType">The System.Type to convert the value to.</param>
	    /// <returns>An System.Object that represents the converted value.</returns>
	    public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
	    {
			Multiplicity? strValue = value as Multiplicity?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}

