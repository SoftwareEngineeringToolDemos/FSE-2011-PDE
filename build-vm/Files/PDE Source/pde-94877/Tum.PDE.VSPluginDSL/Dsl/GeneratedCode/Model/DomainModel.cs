 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// DomainModel VSPluginDSLDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("adbcb32f-6ad7-4855-b8ca-3f14f4c4593a")]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorDiagrams::DiagramsDSLDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorModeling::DomainModelDslEditorModeling))]
	public partial class VSPluginDSLDomainModel : DslEditorModeling::DomainModelBase
	{
		#region Constructor, domain model Id

		/// <summary>
		/// VSPluginDSLDomainModel domain model Id.
		/// </summary>
		public static readonly new global::System.Guid DomainModelId = new System.Guid("adbcb32f-6ad7-4855-b8ca-3f14f4c4593a");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public VSPluginDSLDomainModel(DslModeling::Store store)
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
				typeof(DomainClass2),
				typeof(DomainClass2Shape),
				typeof(DomainModelHasDomainClass2),
				typeof(DesignerDiagram),
				typeof(SpecificElementsDiagramTemplate),
				typeof(VSPluginDSLElementForShapesAdded),
				typeof(VSPluginDSLElementForShapesChanged),
				typeof(VSPluginDSLElementForShapesDeleted),
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
				new DomainMemberInfo(typeof(DomainClass2), "Name", DomainClass2.NameDomainPropertyId, typeof(DomainClass2.NamePropertyHandler)),
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
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainClass2), "DomainModel", DomainModelHasDomainClass2.DomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainModelHasDomainClass2), "DomainClass2", DomainModelHasDomainClass2.DomainClass2DomainRoleId),
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
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.VSPluginDSL.DomainModel.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId)
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.PDE.VSPluginDSL.DomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId,
					SourceRoleId = global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainModelDomainRoleId,
					TargetRoleId = global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClass2DomainRoleId,
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
	
			};
		}
		
        /// <summary>
        /// Gets the embedding relationships order information (parent-child mappings in the order of the serialization model).
        /// </summary>
        public override DslEditorModeling::EmbeddingRelationshipOrderInfo[] GetEmbeddingRelationshipOrderInfo()
		{
			return new DslEditorModeling::EmbeddingRelationshipOrderInfo[] 
			{
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.VSPluginDSL.DomainModel.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId)
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
				new DslEditorModeling::ModelContextInfo(DefaultContextModelContext.DomainClassId, global::Tum.PDE.VSPluginDSL.DomainModel.DomainClassId),
	
			};
		}
		#endregion
		#region Diagrams model advanced reflection
		private class VSPluginDSLDiagramDomainDataDirectory : DslEditorDiagrams::DiagramDomainDataDirectory
		{
			/// <summary>
        	/// Gets the diagram class information.
        	/// </summary>
        	/// <returns>Diagram class info.</returns>
        	public override DslEditorDiagrams::DiagramClassInfo[] GetDiagramClassInfo()
			{
				return new DslEditorDiagrams::DiagramClassInfo[]
				{
					new DslEditorDiagrams::DiagramClassInfo(Tum.PDE.VSPluginDSL.DesignerDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
					new DslEditorDiagrams::DiagramClassInfo(Tum.PDE.VSPluginDSL.SpecificElementsDiagramTemplate.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Extended),
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
					new DslEditorDiagrams::ShapeClassInfo(Tum.PDE.VSPluginDSL.DesignerDiagram.DomainClassId, global::Tum.PDE.VSPluginDSL.DomainClass2Shape.DomainClassId, global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId, false)
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
					global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId,
					
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
				new VSPluginDSLDiagramDomainDataDirectory()
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
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(3);
				createElementMap.Add(typeof(DomainModel), 0);
				createElementMap.Add(typeof(DomainClass2), 1);
				createElementMap.Add(typeof(DomainClass2Shape), 2);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new DomainModel(partition, propertyAssignments);
				case 1: return new DomainClass2(partition, propertyAssignments);
				case 2: return new DomainClass2Shape(partition, propertyAssignments);
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
				createElementLinkMap.Add(typeof(DomainModelHasDomainClass2), 0);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
		
			}
			switch (index)
			{
				case 0: return new DomainModelHasDomainClass2(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion	
		#region Resource manager
	
		private static global::System.Resources.ResourceManager resourceManager;
	
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx";
	
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return VSPluginDSLDomainModel.SingletonResourceManager;
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
				if (VSPluginDSLDomainModel.resourceManager == null)
				{
					VSPluginDSLDomainModel.resourceManager = new global::System.Resources.ResourceManager(
                        ResourceBaseName, typeof(VSPluginDSLDomainModel).Assembly);
				}
				return VSPluginDSLDomainModel.resourceManager;
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
					return VSPluginDSLDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return VSPluginDSLDomainModel.DeleteClosure;
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
				if (VSPluginDSLDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new VSPluginDSLCopyClosure());
					
					VSPluginDSLDomainModel.copyClosure = copyFilter;
				}
				return VSPluginDSLDomainModel.copyClosure;
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
				if (VSPluginDSLDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new VSPluginDSLDeleteClosure());
		
					VSPluginDSLDomainModel.removeClosure = removeFilter;
				}
				return VSPluginDSLDomainModel.removeClosure;
			}
		}
		#endregion
	}
	
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	public partial class VSPluginDSLDeleteClosure : VSPluginDSLDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VSPluginDSLDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class VSPluginDSLDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public VSPluginDSLDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClass2DomainRoleId, true);
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
	public partial class VSPluginDSLCopyClosure : VSPluginDSLCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VSPluginDSLCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class VSPluginDSLCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VSPluginDSLCopyClosureBase():base()
		{
		}
	}
	#endregion	
}


