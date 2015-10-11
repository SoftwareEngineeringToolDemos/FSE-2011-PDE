 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainModel FamilyTreeDSLDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("0c1568f1-98fa-483a-b291-2e0a3e7ac16e")]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorDiagrams::DiagramsDSLDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorModeling::DomainModelDslEditorModeling))]
	public partial class FamilyTreeDSLDomainModel : DslEditorModeling::DomainModelBase
	{
		#region Constructor, domain model Id

		/// <summary>
		/// FamilyTreeDSLDomainModel domain model Id.
		/// </summary>
		public static readonly new global::System.Guid DomainModelId = new System.Guid("0c1568f1-98fa-483a-b291-2e0a3e7ac16e");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public FamilyTreeDSLDomainModel(DslModeling::Store store)
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
				typeof(FamilyTreeModel),
				typeof(Person),
				typeof(FamilyTreePerson),
				typeof(Pet),
				typeof(PersonShape),
				typeof(ParentOfShape),
				typeof(MarriedToShape),
				typeof(FamilyTreeModelHasFamilyTreePerson),
				typeof(FamilyTreePersonHasPet),
				typeof(ParentOf),
				typeof(MarriedTo),
				typeof(DesignerDiagram),
				typeof(FamilyTreeDSLElementForShapesAdded),
				typeof(FamilyTreeDSLElementForShapesChanged),
				typeof(FamilyTreeDSLElementForShapesDeleted),
				typeof(FamilyTreeDSLLinkForShapesAdded),
				typeof(FamilyTreeDSLLinkForShapesChanged),
				typeof(FamilyTreeDSLLinkForShapesDeleted),
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
				new DomainMemberInfo(typeof(Person), "Name", Person.NameDomainPropertyId, typeof(Person.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Person), "Gender", Person.GenderDomainPropertyId, typeof(Person.GenderPropertyHandler)),
				new DomainMemberInfo(typeof(Person), "Hobbies", Person.HobbiesDomainPropertyId, typeof(Person.HobbiesPropertyHandler)),
				new DomainMemberInfo(typeof(Pet), "Name", Pet.NameDomainPropertyId, typeof(Pet.NamePropertyHandler)),
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
				new DomainRolePlayerInfo(typeof(FamilyTreeModelHasFamilyTreePerson), "FamilyTreeModel", FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(FamilyTreeModelHasFamilyTreePerson), "FamilyTreePerson", FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId),
				new DomainRolePlayerInfo(typeof(FamilyTreePersonHasPet), "FamilyTreePerson", FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId),
				new DomainRolePlayerInfo(typeof(FamilyTreePersonHasPet), "Pet", FamilyTreePersonHasPet.PetDomainRoleId),
				new DomainRolePlayerInfo(typeof(ParentOf), "Parent", ParentOf.ParentDomainRoleId),
				new DomainRolePlayerInfo(typeof(ParentOf), "Child", ParentOf.ChildDomainRoleId),
				new DomainRolePlayerInfo(typeof(MarriedTo), "Husband", MarriedTo.HusbandDomainRoleId),
				new DomainRolePlayerInfo(typeof(MarriedTo), "Wife", MarriedTo.WifeDomainRoleId),
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
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.FamilyTreeDSL.Person.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.FamilyTreeDSL.Pet.DomainClassId)
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					SourceRoleId = global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId,
					TargetRoleId = global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId,
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					TargetElementDomainClassId = global::Tum.FamilyTreeDSL.Pet.DomainClassId,
					SourceRoleId = global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId,
					TargetRoleId = global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.PetDomainRoleId,
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
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.FamilyTreeDSL.ParentOf.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					TargetElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					SourceRoleId = global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId,
					TargetRoleId = global::Tum.FamilyTreeDSL.ParentOf.ChildDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					SourceRoleIsUIBrowsable = false,
					SourceRoleIsUIReadOnly = true,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = false,
					TargetRoleIsUIReadOnly = true,
					TargetRoleIsGenerated = true,
				}
				,
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.FamilyTreeDSL.MarriedTo.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					TargetElementDomainClassId = global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					SourceRoleId = global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId,
					TargetRoleId = global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroOne,
					SourceRoleIsUIBrowsable = false,
					SourceRoleIsUIReadOnly = true,
					SourceRoleIsGenerated = true,
					TargetRoleIsUIBrowsable = false,
					TargetRoleIsUIReadOnly = true,
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
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.FamilyTreeDSL.Person.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.FamilyTreeDSL.Pet.DomainClassId)
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
				new DslEditorModeling::ModelContextInfo(DefaultContextModelContext.DomainClassId, global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId),
	
			};
		}
		#endregion
		#region Diagrams model advanced reflection
		private class FamilyTreeDSLDiagramDomainDataDirectory : DslEditorDiagrams::DiagramDomainDataDirectory
		{
			/// <summary>
        	/// Gets the diagram class information.
        	/// </summary>
        	/// <returns>Diagram class info.</returns>
        	public override DslEditorDiagrams::DiagramClassInfo[] GetDiagramClassInfo()
			{
				return new DslEditorDiagrams::DiagramClassInfo[]
				{
					new DslEditorDiagrams::DiagramClassInfo(Tum.FamilyTreeDSL.DesignerDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Normal),
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
					new DslEditorDiagrams::ShapeClassInfo(Tum.FamilyTreeDSL.DesignerDiagram.DomainClassId, global::Tum.FamilyTreeDSL.PersonShape.DomainClassId, global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId, false)
					{
						RelationshipSourceRoleTypes = new System.Collections.Generic.List<System.Guid>(new System.Guid[]
                        {
							global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId,
							global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId,
                        }),
						RelationshipTargetRoleTypes = new System.Collections.Generic.List<System.Guid>(new System.Guid[]
                        {
							global::Tum.FamilyTreeDSL.ParentOf.ChildDomainRoleId,
							global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId,
                        }),
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
					new DslEditorDiagrams::RelationshipShapeInfo(Tum.FamilyTreeDSL.DesignerDiagram.DomainClassId, global::Tum.FamilyTreeDSL.ParentOfShape.DomainClassId, global::Tum.FamilyTreeDSL.ParentOf.DomainClassId),
					new DslEditorDiagrams::RelationshipShapeInfo(Tum.FamilyTreeDSL.DesignerDiagram.DomainClassId, global::Tum.FamilyTreeDSL.MarriedToShape.DomainClassId, global::Tum.FamilyTreeDSL.MarriedTo.DomainClassId),
				
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
					global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId,
					global::Tum.FamilyTreeDSL.ParentOf.DomainClassId,
					global::Tum.FamilyTreeDSL.MarriedTo.DomainClassId,
					
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
				new FamilyTreeDSLDiagramDomainDataDirectory()
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
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(7);
				createElementMap.Add(typeof(FamilyTreeModel), 0);
				createElementMap.Add(typeof(FamilyTreePerson), 1);
				createElementMap.Add(typeof(Pet), 2);
				createElementMap.Add(typeof(PersonShape), 3);
				createElementMap.Add(typeof(ParentOfShape), 4);
				createElementMap.Add(typeof(MarriedToShape), 5);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new FamilyTreeModel(partition, propertyAssignments);
				case 1: return new FamilyTreePerson(partition, propertyAssignments);
				case 2: return new Pet(partition, propertyAssignments);
				case 3: return new PersonShape(partition, propertyAssignments);
				case 4: return new ParentOfShape(partition, propertyAssignments);
				case 5: return new MarriedToShape(partition, propertyAssignments);
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
				createElementLinkMap.Add(typeof(FamilyTreeModelHasFamilyTreePerson), 0);
				createElementLinkMap.Add(typeof(FamilyTreePersonHasPet), 1);
				createElementLinkMap.Add(typeof(ParentOf), 2);
				createElementLinkMap.Add(typeof(MarriedTo), 3);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
		
			}
			switch (index)
			{
				case 0: return new FamilyTreeModelHasFamilyTreePerson(partition, roleAssignments, propertyAssignments);
				case 1: return new FamilyTreePersonHasPet(partition, roleAssignments, propertyAssignments);
				case 2: return new ParentOf(partition, roleAssignments, propertyAssignments);
				case 3: return new MarriedTo(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion	
		#region Resource manager
	
		private static global::System.Resources.ResourceManager resourceManager;
	
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx";
	
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return FamilyTreeDSLDomainModel.SingletonResourceManager;
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
				if (FamilyTreeDSLDomainModel.resourceManager == null)
				{
					FamilyTreeDSLDomainModel.resourceManager = new global::System.Resources.ResourceManager(
                        ResourceBaseName, typeof(FamilyTreeDSLDomainModel).Assembly);
				}
				return FamilyTreeDSLDomainModel.resourceManager;
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
					return FamilyTreeDSLDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return FamilyTreeDSLDomainModel.DeleteClosure;
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
				if (FamilyTreeDSLDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new FamilyTreeDSLCopyClosure());
					
					FamilyTreeDSLDomainModel.copyClosure = copyFilter;
				}
				return FamilyTreeDSLDomainModel.copyClosure;
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
				if (FamilyTreeDSLDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new FamilyTreeDSLDeleteClosure());
		
					FamilyTreeDSLDomainModel.removeClosure = removeFilter;
				}
				return FamilyTreeDSLDomainModel.removeClosure;
			}
		}
		#endregion
	}
	
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	public partial class FamilyTreeDSLDeleteClosure : FamilyTreeDSLDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public FamilyTreeDSLDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class FamilyTreeDSLDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public FamilyTreeDSLDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId, true);
			DomainRoles.Add(global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.PetDomainRoleId, true);
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
	public partial class FamilyTreeDSLCopyClosure : FamilyTreeDSLCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public FamilyTreeDSLCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class FamilyTreeDSLCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public FamilyTreeDSLCopyClosureBase():base()
		{
		}
	}
	#endregion	
}

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainEnumeration: Gender
	/// </summary>
	[System.ComponentModel.TypeConverter(typeof(GenderEnumConverter))]
	public enum Gender
	{
		/// <summary>
		/// Male
		/// </summary>
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Gender/Male.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		Male,
		/// <summary>
		/// Female
		/// </summary>
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Gender/Female.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		Female,
	}
	/// <summary>
	/// Type converter for Gender enumeration.
	/// </summary>
	public class GenderEnumConverter : System.ComponentModel.EnumConverter
	{
		System.Collections.Generic.Dictionary<Gender, string> dictionary;
		
		/// <summary>
	    /// Constructor.
	    /// </summary>
	    public GenderEnumConverter() : base(typeof(Gender))
	    {
	        // create lookup dictionary
	        dictionary = new System.Collections.Generic.Dictionary<Gender, string>();
			dictionary.Add(Gender.Male, global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Gender/Male.DisplayName"));
			dictionary.Add(Gender.Female, global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.SingletonResourceManager.GetString("Tum.FamilyTreeDSL.Gender/Female.DisplayName"));
	    }
	
		/// <summary>
	    /// Converts the specified value object to Gender.
	    /// </summary>
	    /// <param name="context">An System.ComponentModel.ITypeDescriptorContext that provides a format context.</param>
	    /// <param name="culture">An optional System.Globalization.CultureInfo. If not supplied, the current culture is assumed.</param>
	    /// <param name="value">The System.Object to convert.</param>
	    /// <returns>Gender object that represents the converted value.</returns>
	    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
	    {
			string strValue = value as string;
			if( strValue != null )
			{
				foreach(Gender d in dictionary.Keys )
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
			Gender? strValue = value as Gender?;
			if( strValue != null )
			{
				return dictionary[strValue.Value];
			}
	
	        return base.ConvertTo(context, culture, value, destinationType);
	    }
	}
}

