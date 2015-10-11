 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;

using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainModel StateMachineLanguageDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineLanguageDomainModel.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineLanguageDomainModel.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("c8b20757-5769-49c5-8eb2-d26de1b97594")]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorDiagrams::DiagramsDSLDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(DslEditorModeling::DomainModelDslEditorModeling))]
	public partial class StateMachineLanguageDomainModel : DslEditorModeling::DomainModelBase
	{
		#region Constructor, domain model Id

		/// <summary>
		/// StateMachineLanguageDomainModel domain model Id.
		/// </summary>
		public static readonly new global::System.Guid DomainModelId = new System.Guid("c8b20757-5769-49c5-8eb2-d26de1b97594");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public StateMachineLanguageDomainModel(DslModeling::Store store)
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
				typeof(StateMachineDomainModel),
				typeof(StateBase),
				typeof(State),
				typeof(StartState),
				typeof(EndState),
				typeof(StateShape),
				typeof(StartStateShape),
				typeof(EndStateShape),
				typeof(TransitionShape),
				typeof(StateMachineDomainModelHasState),
				typeof(StateMachineDomainModelHasStartState),
				typeof(StateMachineDomainModelHasEndState),
				typeof(Transition),
				typeof(DesignerDiagram),
				typeof(StateMachineLanguageElementForShapesAdded),
				typeof(StateMachineLanguageElementForShapesChanged),
				typeof(StateMachineLanguageElementForShapesDeleted),
				typeof(StateMachineLanguageLinkForShapesAdded),
				typeof(StateMachineLanguageLinkForShapesChanged),
				typeof(StateMachineLanguageLinkForShapesDeleted),
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
				new DomainMemberInfo(typeof(State), "Name", State.NameDomainPropertyId, typeof(State.NamePropertyHandler)),
				new DomainMemberInfo(typeof(Transition), "Condition", Transition.ConditionDomainPropertyId, typeof(Transition.ConditionPropertyHandler)),
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
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasState), "StateMachineDomainModel", StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasState), "State", StateMachineDomainModelHasState.StateDomainRoleId),
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasStartState), "StateMachineDomainModel", StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasStartState), "StartState", StateMachineDomainModelHasStartState.StartStateDomainRoleId),
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasEndState), "StateMachineDomainModel", StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(StateMachineDomainModelHasEndState), "EndState", StateMachineDomainModelHasEndState.EndStateDomainRoleId),
				new DomainRolePlayerInfo(typeof(Transition), "StateBaseSource", Transition.StateBaseSourceDomainRoleId),
				new DomainRolePlayerInfo(typeof(Transition), "StateBaseTarget", Transition.StateBaseTargetDomainRoleId),
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
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.StateMachineDSL.StateBase.DomainClassId)
				{
					IsAbstract = true
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.StateMachineDSL.State.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.StateMachineDSL.StartState.DomainClassId)
				{
					IsAbstract = false
				}
				,
				new DslEditorModeling::DomainClassAdvancedInfo(global::Tum.StateMachineDSL.EndState.DomainClassId)
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.StateMachineDSL.StateMachineDomainModelHasState.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.StateMachineDSL.State.DomainClassId,
					SourceRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId,
					TargetRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateDomainRoleId,
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.StateMachineDSL.StartState.DomainClassId,
					SourceRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId,
					TargetRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StartStateDomainRoleId,
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
				new DslEditorModeling::EmbeddingRelationshipAdvancedInfo(global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.DomainClassId, true, false)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId,
					TargetElementDomainClassId = global::Tum.StateMachineDSL.EndState.DomainClassId,
					SourceRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId,
					TargetRoleId = global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.EndStateDomainRoleId,
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
				new DslEditorModeling::ReferenceRelationshipAdvancedInfo(global::Tum.StateMachineDSL.Transition.DomainClassId, false, true, true)
				{
					IsAbstract = false,
					SourceElementDomainClassId = global::Tum.StateMachineDSL.StateBase.DomainClassId,
					TargetElementDomainClassId = global::Tum.StateMachineDSL.StateBase.DomainClassId,
					SourceRoleId = global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId,
					TargetRoleId = global::Tum.StateMachineDSL.Transition.StateBaseTargetDomainRoleId,
					SourceRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
					TargetRoleMultiplicity = DslModeling::Multiplicity.ZeroMany,
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
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
						global::Tum.StateMachineDSL.StateMachineDomainModelHasState.DomainClassId,
						global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.DomainClassId,
						global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.DomainClassId,
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.StateMachineDSL.StateBase.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.StateMachineDSL.State.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.StateMachineDSL.StartState.DomainClassId)
				{
					EmbeddingRelationships = new System.Guid[] 
					{
					},
					
					EmbeddingRelationshipsTargetIncludedSubmodel = new System.Guid[] 
					{
					}
				},
				new DslEditorModeling::EmbeddingRelationshipOrderInfo(global::Tum.StateMachineDSL.EndState.DomainClassId)
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
				new DslEditorModeling::ModelContextInfo(DefaultContextModelContext.DomainClassId, global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId),
	
			};
		}
		#endregion
		#region Diagrams model advanced reflection
		private class StateMachineLanguageDiagramDomainDataDirectory : DslEditorDiagrams::DiagramDomainDataDirectory
		{
			/// <summary>
        	/// Gets the diagram class information.
        	/// </summary>
        	/// <returns>Diagram class info.</returns>
        	public override DslEditorDiagrams::DiagramClassInfo[] GetDiagramClassInfo()
			{
				return new DslEditorDiagrams::DiagramClassInfo[]
				{
					new DslEditorDiagrams::DiagramClassInfo(Tum.StateMachineDSL.DesignerDiagram.DomainClassId, DslEditorDiagrams::DiagramVisualizationBehavior.Normal),
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
					new DslEditorDiagrams::ShapeClassInfo(Tum.StateMachineDSL.DesignerDiagram.DomainClassId, global::Tum.StateMachineDSL.StateShape.DomainClassId, global::Tum.StateMachineDSL.State.DomainClassId, false)
					{
					},
					new DslEditorDiagrams::ShapeClassInfo(Tum.StateMachineDSL.DesignerDiagram.DomainClassId, global::Tum.StateMachineDSL.StartStateShape.DomainClassId, global::Tum.StateMachineDSL.StartState.DomainClassId, false)
					{
					},
					new DslEditorDiagrams::ShapeClassInfo(Tum.StateMachineDSL.DesignerDiagram.DomainClassId, global::Tum.StateMachineDSL.EndStateShape.DomainClassId, global::Tum.StateMachineDSL.EndState.DomainClassId, false)
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
					new DslEditorDiagrams::RelationshipShapeInfo(Tum.StateMachineDSL.DesignerDiagram.DomainClassId, global::Tum.StateMachineDSL.TransitionShape.DomainClassId, global::Tum.StateMachineDSL.Transition.DomainClassId),
				
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
					global::Tum.StateMachineDSL.State.DomainClassId,
					global::Tum.StateMachineDSL.StartState.DomainClassId,
					global::Tum.StateMachineDSL.EndState.DomainClassId,
					global::Tum.StateMachineDSL.Transition.DomainClassId,
					
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
				new StateMachineLanguageDiagramDomainDataDirectory()
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
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(9);
				createElementMap.Add(typeof(StateMachineDomainModel), 0);
				createElementMap.Add(typeof(State), 1);
				createElementMap.Add(typeof(StartState), 2);
				createElementMap.Add(typeof(EndState), 3);
				createElementMap.Add(typeof(StateShape), 4);
				createElementMap.Add(typeof(StartStateShape), 5);
				createElementMap.Add(typeof(EndStateShape), 6);
				createElementMap.Add(typeof(TransitionShape), 7);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new StateMachineDomainModel(partition, propertyAssignments);
				case 1: return new State(partition, propertyAssignments);
				case 2: return new StartState(partition, propertyAssignments);
				case 3: return new EndState(partition, propertyAssignments);
				case 4: return new StateShape(partition, propertyAssignments);
				case 5: return new StartStateShape(partition, propertyAssignments);
				case 6: return new EndStateShape(partition, propertyAssignments);
				case 7: return new TransitionShape(partition, propertyAssignments);
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
				createElementLinkMap.Add(typeof(StateMachineDomainModelHasState), 0);
				createElementLinkMap.Add(typeof(StateMachineDomainModelHasStartState), 1);
				createElementLinkMap.Add(typeof(StateMachineDomainModelHasEndState), 2);
				createElementLinkMap.Add(typeof(Transition), 3);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
		
			}
			switch (index)
			{
				case 0: return new StateMachineDomainModelHasState(partition, roleAssignments, propertyAssignments);
				case 1: return new StateMachineDomainModelHasStartState(partition, roleAssignments, propertyAssignments);
				case 2: return new StateMachineDomainModelHasEndState(partition, roleAssignments, propertyAssignments);
				case 3: return new Transition(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion	
		#region Resource manager
	
		private static global::System.Resources.ResourceManager resourceManager;
	
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "StateMachineDSL.GeneratedCode.DomainModelResx";
	
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return StateMachineLanguageDomainModel.SingletonResourceManager;
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
				if (StateMachineLanguageDomainModel.resourceManager == null)
				{
					StateMachineLanguageDomainModel.resourceManager = new global::System.Resources.ResourceManager(
                        ResourceBaseName, typeof(StateMachineLanguageDomainModel).Assembly);
				}
				return StateMachineLanguageDomainModel.resourceManager;
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
					return StateMachineLanguageDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return StateMachineLanguageDomainModel.DeleteClosure;
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
				if (StateMachineLanguageDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new StateMachineLanguageCopyClosure());
					
					StateMachineLanguageDomainModel.copyClosure = copyFilter;
				}
				return StateMachineLanguageDomainModel.copyClosure;
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
				if (StateMachineLanguageDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new StateMachineLanguageDeleteClosure());
		
					StateMachineLanguageDomainModel.removeClosure = removeFilter;
				}
				return StateMachineLanguageDomainModel.removeClosure;
			}
		}
		#endregion
	}
	
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	public partial class StateMachineLanguageDeleteClosure : StateMachineLanguageDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public StateMachineLanguageDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class StateMachineLanguageDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public StateMachineLanguageDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateDomainRoleId, true);
			DomainRoles.Add(global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StartStateDomainRoleId, true);
			DomainRoles.Add(global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.EndStateDomainRoleId, true);
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
	public partial class StateMachineLanguageCopyClosure : StateMachineLanguageCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public StateMachineLanguageCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class StateMachineLanguageCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public StateMachineLanguageCopyClosureBase():base()
		{
		}
	}
	#endregion	
}


