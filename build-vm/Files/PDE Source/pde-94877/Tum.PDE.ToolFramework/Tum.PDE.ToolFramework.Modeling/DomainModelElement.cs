using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This is the abstract class wrapping additional functionality for the DSL-Tools ModelElement class.
    /// </summary>
    [DomainObjectId("D59DB278-1241-44ED-840C-58A029BD85DE")]
    [DomainModelOwner(typeof(DomainModelDslEditorModeling))]
    public abstract class DomainModelElement : ModelElement,
        IModelMergeElements, IDableElement, IDomainModelOwnable, IDomainModelVisualizable, IEmbeddableModelElement
    {
        /// <summary>
        /// Domain class Id.
        /// </summary>
        public static readonly new global::System.Guid DomainClassId = new System.Guid("D59DB278-1241-44ED-840C-58A029BD85DE");

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="partition">Partition of the store where element is to be created.</param>
        /// <param name="propertyAssignments">New element property assignments.</param>
        protected DomainModelElement(Partition partition, PropertyAssignment[] propertyAssignments)
            : base(partition, propertyAssignments)
        {
        }

        /// <summary>
        /// Gets the domain class Id of this element.
        /// </summary>
        /// <returns>DomainClass Id.</returns>
        public abstract Guid GetDomainClassId();

        #region IDomainModelOwnable
        /*
         /// <summary>
        /// Gets the document data
        /// </summary>
        public abstract ModelData DocumentData
        {
            get;
        }*/

        /// <summary>
        /// Gets the domain model type.
        /// </summary>
        /// <returns>Domain model type.</returns>
        public abstract System.Type GetDomainModelType();

        /// <summary>
        /// Gets the domain model services.
        /// </summary>
        /// <returns>Domain model services.</returns>
        public abstract IDomainModelServices GetDomainModelServices();

        /// <summary>
        /// Gets the domain model DomainClassId.
        /// </summary>
        /// <returns></returns>
        public abstract System.Guid GetDomainModelTypeId();

        /// <summary>
        /// Gets or sets the value of the property (which is marked as element name)
        /// </summary>
        public abstract string DomainElementName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the full name of the element.
        /// </summary>
        /// <remarks>
        /// This is either: ElementName (elemenType) or just ElementType.
        /// </remarks>
        public virtual string DomainElementFullName
        {
            get
            {
                if (this.DomainElementHasName)
                    return this.DomainElementName + " (" + this.DomainElementTypeDisplayName + ")";
                else
                    return this.DomainElementTypeDisplayName;
            }
        }

        /// <summary>
        /// Gets whether the domain element has a property marked as element name.
        /// </summary>
        public abstract bool DomainElementHasName
        {
            get;
        }

        /// <summary>
        /// Gets the domain element name info if there is one; Null otherwise.
        /// </summary>
        public abstract DomainPropertyInfo DomainElementNameInfo
        {
            get;
        }

        /// <summary>
        /// Gets the type of the ModelElement as string.
        /// </summary>
        public abstract string DomainElementType
        {
            get;
        }

        /// <summary>
        /// Gets the display name of the type of the ModelElement.
        /// </summary>
        public abstract string DomainElementTypeDisplayName
        {
            get;
        }
        #endregion

        #region IModelMergeElements
        /// <summary>
        /// Decides whether the element can be copied or not.
        /// </summary>
        /// <returns>True if the element can be copied. False otherwise.</returns>
        public virtual bool ModelIsCopyAllowed()
        {
            return true;
        }

        /// <summary>
        /// Decides whether the element can be moved or not.
        /// </summary>
        /// <returns>True if the element can be moved. False otherwise.</returns>
        public virtual bool ModelIsMoveAllowed()
        {
            return true;
        }

        /// <summary>
        /// Decides whether the element can be pasted or not based on the operation.
        /// </summary>
        /// <param name="protoGroupOperation">Proto group operation.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        public virtual bool ModelIsPasteAllowed(ModelProtoGroupOperation protoGroupOperation)
        {
            if (protoGroupOperation == ModelProtoGroupOperation.Move)
                return ModelIsMoveAllowed();

            return true;
        }
        
        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        public virtual ModelProtoElement ModelCreateMergeCopy(ModelProtoGroup protoGroup)
        {
            if (protoGroup.Operation == ModelProtoGroupOperation.Copy)
                if (!ModelIsCopyAllowed())
                    return null;

            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                return null;

            ModelProtoElement protoElement = new ModelProtoElement(this);
            protoGroup.AddNewElement(protoElement);
            ModelProcessMergeCopy(protoElement, protoGroup);

            return protoElement;
        }
        
        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        public virtual ModelProtoElement ModelCreateMoveCopy(ModelProtoGroup protoGroup)
        {
            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                if (!ModelIsMoveAllowed())
                    return null;

            if (protoGroup.Operation == ModelProtoGroupOperation.Copy)
                return null;

            ModelProtoElement protoElement = new ModelProtoElement(this);
            protoGroup.AddNewElement(protoElement);

            return protoElement;
        }

        /// <summary>
        /// Processes a proto element representation of the element and adds required proto links. 
        /// This method is called on base classes from derived classes.
        /// 
        /// Hint: Properties do not need to be added in this method.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        public virtual void ModelProcessMergeCopy(ModelProtoElement protoElement, ModelProtoGroup protoGroup)
        {
            foreach (ElementLink link in DomainRoleInfo.GetAllElementLinks(this))
                if (link is DomainModelLink)
                {
                    DomainModelLink modelLink = link as DomainModelLink;
                    DomainRelationshipAdvancedInfo info = this.Store.DomainDataAdvDirectory.GetRelationshipInfo(modelLink.GetDomainClassId());
                    if (info is ReferenceRelationshipAdvancedInfo)
                    {
                        if (DomainRoleInfo.GetSourceRolePlayer(modelLink) == this)
                        {
                            if (!(info as ReferenceRelationshipAdvancedInfo).PropagatesCopyToTarget)
                                continue;
                        }
                        else
                            if (!(info as ReferenceRelationshipAdvancedInfo).PropagatesCopyToSource)
                                continue;

                        ModelProtoLink protoLink = new ModelProtoLink(link);
                        protoGroup.AddNewReferenceLink(protoLink);
                    }
                    else
                    {
                        DomainModelElement child = DomainRoleInfo.GetTargetRolePlayer(link) as DomainModelElement;
                        if (child == this || child == null)
                            continue;
                        if ((info as EmbeddingRelationshipAdvancedInfo).PropagatesCopyToChild)
                        {
                            if (!(info as EmbeddingRelationshipAdvancedInfo).IsTargetIncludedSubmodel)
                            {
                                ModelProtoLink protoLink = new ModelProtoLink(link);
                                protoGroup.AddNewEmbeddingLink(protoLink);
                                child.ModelCreateMergeCopy(protoGroup);
                            }
                            else if( child is IParentModelElement )
                            {
                                ModelProtoLink protoLink = new ModelProtoLink(link);
                                protoLink.IsTargetIncludedSubmodel = true;
                                protoLink.DomainFilePath = (child as IParentModelElement).DomainFilePath;
                                protoGroup.AddNewReferenceLink(protoLink);
                            }
                        }
                    }
                }

            /*
            // process reference relationships
            List<ReferenceRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassSourceReferences(this.GetDomainClassId());
            if (infos != null)
                foreach (ReferenceRelationshipAdvancedInfo info in infos)
                {
                    if (info.PropagatesCopyToTarget)
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this, info.SourceRoleId);
                        foreach (ElementLink link in links)
                        {
                            ModelProtoLink protoLink = new ModelProtoLink(link);
                            protoGroup.AddNewReferenceLink(protoLink);
                        }
                    }
                }
            infos = this.Store.DomainDataAdvDirectory.FindDomainClassTargetReferences(this.GetDomainClassId());
            if (infos != null)
                foreach (ReferenceRelationshipAdvancedInfo info in infos)
                {
                    if (info.PropagatesCopyToSource)
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this, info.TargetRoleId);
                        foreach (ElementLink link in links)
                        {
                            ModelProtoLink protoLink = new ModelProtoLink(link);
                            protoGroup.AddNewReferenceLink(protoLink);
                        }
                    }
                }

            // process embedding relationships
            List<EmbeddingRelationshipAdvancedInfo> infosEmb = this.Store.DomainDataAdvDirectory.FindDomainClassSourceEmbeddings(this.GetDomainClassId());
            if (infosEmb != null)
                foreach (EmbeddingRelationshipAdvancedInfo info in infosEmb)
                {
                    if (info.PropagatesCopyToChild)
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this, info.SourceRoleId);
                        foreach (ElementLink link in links)
                        {
                            ModelProtoLink protoLink = new ModelProtoLink(link);
                            protoGroup.AddNewEmbeddingLink(protoLink);

                            DomainModelElement child = DomainRoleInfo.GetTargetRolePlayer(link) as DomainModelElement;
                            if( child != null )
                                child.ModelCreateMergeCopy(protoGroup);
                        }
                    }
                }
            */
        }

        /// <summary>
        /// Decides whether the element that is represented by the proto element can be pasted or not.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        public virtual bool ModelCanMerge(ModelProtoElement protoElement, ModelProtoGroup protoGroup)
        {
            if (protoElement != null)
            {
                DomainClassInfo elementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(protoElement.DomainClassId);
                foreach (DomainRoleInfo info in elementDomainInfo.AllDomainRolesPlayed)
                {
                    if (!info.IsSource)
                        if( info.OppositeDomainRole.RolePlayer.Id == this.GetDomainClassId() )
                            if (this.Store.DomainDataAdvDirectory.IsEmbeddingRelationship(info.DomainRelationship.Id) &&
                                !this.Store.DomainDataAdvDirectory.IsAbstractRelationship(info.DomainRelationship.Id))
                            {
                                if (info.OppositeDomainRole.Multiplicity == Multiplicity.One || info.OppositeDomainRole.Multiplicity == Multiplicity.ZeroOne)
                                {
                                    // Check that creating a link with this path doesn't cause multiplicity overflow
                                    if (DomainRoleInfo.GetLinkedElement(this, info.OppositeDomainRole.Id) != null)
                                        return false;

                                    return true;
                                }
                                else
                                {
                                    if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                                    {
                                        foreach (ElementLink link in DomainRoleInfo.GetElementLinks<ElementLink>(this, info.OppositeDomainRole.Id))
                                            if (DomainRoleInfo.GetTargetRolePlayer(link).Id == protoElement.ElementId)
                                                return false;
                                    }
                                    return true;
                                }
                            }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public virtual void ModelMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger, bool isRoot)
        {
            if (!ModelIsPasteAllowed(groupMerger.ProtoGroup.Operation))
            {
                // add warning message
                groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergePasteDisallowedId,
                             ModelValidationViolationType.Warning, "Element couldn't be addded to " + this.DomainElementFullName + " because paste is not allowed."));
                return;
            }

            if (protoElement != null)
            {
                DomainClassInfo elementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(protoElement.DomainClassId);
                foreach (DomainRoleInfo info in elementDomainInfo.AllDomainRolesPlayed)
                {
                    if (!info.IsSource)
                        if (info.OppositeDomainRole.RolePlayer.Id == this.GetDomainClassId())
                            if (this.Store.DomainDataAdvDirectory.IsEmbeddingRelationship(info.DomainRelationship.Id) &&
                                !this.Store.DomainDataAdvDirectory.IsAbstractRelationship(info.DomainRelationship.Id))
                            {
                                // create element id
                                Guid newElementId = this.GetDomainModelServices().ElementIdProvider.GenerateNewKey();

                                // create property assignments
                                PropertyAssignment[] propertyAssignemnts = protoElement.GetPropertyAssignments(this.Store.DefaultPartition, newElementId);

                                // create the actual model element
                                DomainModelElement element = this.Store.ElementFactory.CreateElement(elementDomainInfo, propertyAssignemnts) as DomainModelElement;
                                if (element == null)
                                    throw new System.ArgumentNullException("Element is null in ModelMerge: " + elementDomainInfo.Name);

                                if (!element.ModelIsPasteAllowed(groupMerger.ProtoGroup.Operation))
                                {
                                    // add warning message
                                    groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergePasteDisallowedId,
                                         ModelValidationViolationType.Warning, "Element couldn't be addded to <#= role.RolePlayer.Name #> because paste is not allowed."));

                                    element.Delete();
                                    return;
                                }

                                // set name
                                if (isRoot && groupMerger.ProtoGroup.Operation != ModelProtoGroupOperation.Move)
                                {
                                    if (element.DomainElementHasName)
                                    {
                                        element.GetDomainModelServices().ElementNameProvider.SetName(element, "Copy of " + element.DomainElementName);
                                    }
                                }

                                // update id mapping
                                groupMerger.SetIdMapping(protoElement.ElementId, newElementId);

                                // add child element
                                if (info.OppositeDomainRole.Multiplicity == Multiplicity.One || info.OppositeDomainRole.Multiplicity == Multiplicity.ZeroOne)
                                {
                                    DomainRoleInfo.SetLinkedElement(this, info.OppositeDomainRole.Id, element);
                                }
                                else
                                {
                                    RoleAssignment[] assignments = new RoleAssignment[2];
                                    assignments[0] = new RoleAssignment(info.OppositeDomainRole.Id, this);
                                    assignments[1] = new RoleAssignment(info.Id, element);


                                    this.Store.ElementFactory.CreateElementLink(info.DomainRelationship, assignments);
                                }

                                // continue with child elements (Embedding Relationship)
                                System.Collections.Generic.List<ModelProtoElement> embeddedProtoElements = groupMerger.GetEmbeddedElements(this.Store.DefaultPartition, protoElement);
                                if (embeddedProtoElements.Count > 0)
                                {
                                    foreach (ModelProtoElement p in embeddedProtoElements)
                                        (element as IModelMergeElements).ModelMerge(p, groupMerger, false);
                                }

                                return;
                            }
                }
            }
        }

        /// <summary>
        /// Adds a proto link to the current element.
        /// </summary>
        /// <param name="protoLink">Proto link representation of the element link that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelMerge(ModelProtoLink protoLink, ModelProtoGroupMerger groupMerger)
        {
            if (protoLink.IsTargetIncludedSubmodel && !String.IsNullOrEmpty(protoLink.DomainFilePath))
            {
                // TODO ...
                /*
                string file = protoLink.DomainFilePath;
                IParentModelElement parent = this.GetDomainModelServices().ElementParentProvider.GetParentModelElement(this);
                if (parent == null)
                    throw new System.ArgumentNullException("Parent of element " + this.ToString() + " can not be null");

                string path = parent.DomainFilePath;
                string vModellDirectory = new System.IO.FileInfo(path).DirectoryName;
                string curPath = vModellDirectory + System.IO.Path.DirectorySeparatorChar + path;

                // load model
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set referenced model"))
                {
                    // TODO load.
                    /*
                    global::Tum.VModellXT.VModellXTDocumentData data = global::Tum.VModellXT.VModellXTDocumentData.Instance as global::Tum.VModellXT.VModellXTDocumentData;
                    global::Tum.VModellXT.VModell referenceModel = data.ModelContextVModellXT.LoadInternal(file) as global::Tum.VModellXT.VModell;
                    model.VModell = referenceModel;
                    */
                /*
                    transaction.Commit();
                }

                return;
                */
                return;
            }

            DomainRelationshipInfo linkDomainInfo = null;
            if (protoLink != null)
            {
                linkDomainInfo = this.Partition.DomainDataDirectory.GetDomainRelationship(protoLink.DomainClassId);
            }
            else
            {
                // try getting the linkDomainInfo from name
                DomainClassInfo elementDomainInfo = this.GetDomainClass();
                foreach (DomainRoleInfo info in elementDomainInfo.AllDomainRolesPlayed)
                {
                    if (info.IsSource)
                        if (!this.Store.DomainDataAdvDirectory.IsEmbeddingRelationship(info.DomainRelationship.Id) &&
                            !this.Store.DomainDataAdvDirectory.IsAbstractRelationship(info.DomainRelationship.Id))
                        {
                            if (protoLink.Name == info.DomainRelationship.Name && linkDomainInfo == null)
                            {
                                linkDomainInfo = this.Partition.DomainDataDirectory.GetDomainRelationship(info.DomainRelationship.Id);
                            }
                        }
                }
            }

            if (linkDomainInfo == null)
            {
                groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeElementLinkDomainTypeMissingId,
                                 ModelValidationViolationType.Error, "Element link can not be created as the corresponding domain type is missing."));
                return;
            }

            ReferenceRelationshipAdvancedInfo advancedInfo = this.Store.DomainDataAdvDirectory.GetRelationshipInfo(linkDomainInfo.Id) as ReferenceRelationshipAdvancedInfo;
            if (advancedInfo == null)
                throw new InvalidOperationException("Relationship advanced info not found for " + linkDomainInfo.Name);

            // see if this element is taking part in this role
            bool bTakesPart = false;

            ModelProtoRolePlayer sourceRolePlayer = protoLink.GetSourceRolePlayer(this.Store.DefaultPartition);
            ModelProtoElement sourceProtoElement = groupMerger.GetElementById(sourceRolePlayer.RolePlayerId);
            System.Guid mappedSourceIdTP = System.Guid.Empty;
            if (sourceProtoElement != null)
            {
                mappedSourceIdTP = groupMerger.GetIdMapping(sourceRolePlayer.RolePlayerId);
                if (mappedSourceIdTP == this.Id)
                    bTakesPart = true;
            }

            if (advancedInfo.PropagatesCopyOnDeniedElement)
            {
                if (!bTakesPart && mappedSourceIdTP == System.Guid.Empty)
                    if (this.Id == sourceRolePlayer.RolePlayerId)
                        bTakesPart = true;
            }

            if (bTakesPart)
            {
                bool bExists = true;
                if (this.Store.ElementDirectory.FindElement(protoLink.ElementId) == null)
                    bExists = false;

                if (bExists && groupMerger.ProtoGroup.Operation == ModelProtoGroupOperation.Move)
                {
                    groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeElementLinkExistsOnMoveId,
                         ModelValidationViolationType.Error, "Element link exists although the operation = Move."));
                }

                #region Target
                // see if target element was copied
                ModelProtoRolePlayer targetRolePlayer = protoLink.GetTargetRolePlayer(this.Store.DefaultPartition);
                ModelProtoElement targetProtoElement = groupMerger.GetElementById(targetRolePlayer.RolePlayerId);
                Guid mappedTargetId = Guid.Empty;
                if (targetProtoElement != null)
                {
                    mappedTargetId = groupMerger.GetIdMapping(targetRolePlayer.RolePlayerId);
                }

                if (advancedInfo.PropagatesCopyOnDeniedElement)
                    if (mappedTargetId == System.Guid.Empty)
                    {
                        // try creating relationship to existing element
                        mappedTargetId = targetRolePlayer.RolePlayerId;
                    }

                if (mappedTargetId == System.Guid.Empty)
                {
                    // log warning
                    groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeLinkElementNotCopiedId,
                         ModelValidationViolationType.Error, "Referenced model element was not copied. Relationship: " + linkDomainInfo.Name));
                }
                else
                {
                    ModelElement targetElement = this.Store.ElementDirectory.FindElement(mappedTargetId);
                    if (targetElement == null)
                    {
                        // log error
                        groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeLinkElementNotFoundId,
                            ModelValidationViolationType.Error, "Referenced model element was not found. Relationship: " + linkDomainInfo.Name));
                    }
                    else
                    {

                        bool bContinue = true;

                        // check cardinalities, so we don't violate them by additing a new relationship
                        if (advancedInfo.SourceRoleMultiplicity == Multiplicity.One || advancedInfo.SourceRoleMultiplicity == Multiplicity.ZeroOne)
                        {
                            if (DomainRoleInfo.GetLinkedElement(this, advancedInfo.SourceRoleId) != null)
                            {
                                // log warning
                                groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeLinkCreationViolatesMultiplicityId,
                                    ModelValidationViolationType.Error, "Can not create relationship because one already exists. Relationship: " + linkDomainInfo.Name));

                                bContinue = false;
                            }
                        }

                        if (advancedInfo.TargetRoleMultiplicity == Multiplicity.One || advancedInfo.TargetRoleMultiplicity == Multiplicity.ZeroOne)
                        {
                            if (DomainRoleInfo.GetLinkedElement(this, advancedInfo.TargetRoleId) != null)
                            {
                                // log warning
                                groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeLinkCreationViolatesMultiplicityId,
                                    ModelValidationViolationType.Error, "Can not create relationship because one already exists. Relationship: " + linkDomainInfo.Name));

                                bContinue = false;
                            }
                        }

                        if (bContinue)
                        {
                            // create property assignments
                            PropertyAssignment[] propertyAssignemnts = protoLink.GetPropertyAssignments(this.Store.DefaultPartition,
                                this.GetDomainModelServices().ElementIdProvider.GenerateNewKey());

                            // create role assignments
                            RoleAssignment[] roleAssignments = new RoleAssignment[2];
                            roleAssignments[0] = new RoleAssignment(advancedInfo.SourceRoleId, this);
                            roleAssignments[1] = new RoleAssignment(advancedInfo.TargetRoleId, targetElement);

                            // create new relationship
                            this.Store.ElementFactory.CreateElementLink(linkDomainInfo, propertyAssignemnts, roleAssignments);
                        }
                    }
                }
                #endregion
            }

        }

        /// <summary>
        /// Moves a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelMove(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            if (!ModelIsPasteAllowed(groupMerger.ProtoGroup.Operation))
            {
                // add warning message
                groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergePasteDisallowedId,
                             ModelValidationViolationType.Warning, "Element couldn't be addded to " + this.DomainElementFullName + " because paste is not allowed."));
                return;
            }

            if (protoElement != null)
            {
                DomainClassInfo elementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(protoElement.DomainClassId);
                foreach (DomainRoleInfo info in elementDomainInfo.AllDomainRolesPlayed)
                {
                    if (!info.IsSource)
                        if (info.OppositeDomainRole.RolePlayer.Id == this.GetDomainClassId())
                            if (this.Store.DomainDataAdvDirectory.IsEmbeddingRelationship(info.DomainRelationship.Id) &&
                                !this.Store.DomainDataAdvDirectory.IsAbstractRelationship(info.DomainRelationship.Id))
                            {
                                ModelElement modelElement = this.Store.ElementDirectory.FindElement(protoElement.ElementId);
                                if (modelElement == null)
                                {
                                    groupMerger.MergeResult.AddMessage(new ValidationMessage(ModelValidationMessageIds.ModelMergeElementMissingOnMoveId, ModelValidationViolationType.Error, "Element exists although the operation = Move."));
                                    return;
                                }

                                // change parent
                                DomainRoleInfo.SetLinkedElement(modelElement, info.Id, this);
                                return;
                            }
                }
            }
        }

        /// <summary>
        /// Finalize. This method is called on each copied element once all the elements and links are processed.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelFinalize(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
        }

        /// <summary>
        /// Finalize merge.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelFinalizeMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            
        }
        #endregion

        #region IEmbeddableModelElement
        /// <summary>
        /// True if parent element has a name.
        /// </summary>
        public bool DomainElementParentHasName
        {
            get
            {
                ModelElement parentElement = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                if (parentElement == null)
                {
                    return false;
                }
                else if (parentElement is IDomainModelOwnable)
                {
                    return (parentElement as IDomainModelOwnable).GetDomainModelServices().TopMostService.ElementNameProvider.HasName(parentElement);
                }

                return false;
            }
        }

        /// <summary>
        /// Returns the parent name (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        public string DomainElementParentName
        {
            get
            {
                ModelElement parentElement = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                if (parentElement is IDomainModelOwnable)
                {
                    if ((parentElement as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.HasName(parentElement))
                        return (parentElement as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.GetName(parentElement);
                    else
                        return (parentElement as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(parentElement);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns the parent name + (type name) (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        public string DomainElementParentFullName
        {
            get
            {
                ModelElement parentElement = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                if (parentElement is IDomainModelOwnable)
                {
                    if ((parentElement as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.HasName(parentElement))
                        return (parentElement as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.GetName(parentElement) + " (" +
                            (parentElement as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(parentElement) + ")";
                    else
                        return (parentElement as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(parentElement);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// True if there is a first parent element, which has a DomainElementName name.
        /// </summary>
        public bool DomainElementParentHasFirstExistingName
        {
            get
            {
                ModelElement temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                while (temp != null)
                {
                    if (temp is IDomainModelOwnable)
                    {
                        if ((temp as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.HasName(temp))
                            return true;

                        temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(temp);
                    }
                    else
                        temp = null;
                }

                return false;
            }
        }

        /// <summary>
        /// Returns the DomainElementName of the first parent to actually have a name.
        /// </summary>
        public string DomainElementParentFirstExistingName
        {
            get
            {
                ModelElement temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                while (temp != null)
                {
                    if ((temp as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.HasName(temp))
                        return (temp as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.GetName(temp);

                    temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(temp);
                }

                return null;
            }
        }

        /// <summary>
        /// Returns true if this elements parent has an embedding full path.
        /// </summary>
        public bool DomainElementHasParentFullPath
        {
            get
            {
                ModelElement temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                if (temp != null)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Returns the full path of the parent element relative to the domain model element.
        /// </summary>
        public string DomainElementParentFullPath
        {
            get
            {
                string fullPath = "";

                ModelElement temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
                while (temp != null)
                {
                    if ((temp as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.HasName(temp))
                        fullPath = (temp as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.GetName(temp) + "/" + fullPath;
                    else
                        fullPath = (temp as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(temp) + "/" + fullPath;

                    temp = this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(temp);
                }

                return fullPath;
            }
        }
        #endregion

        #region IDomainModelVisualizable

        #endregion

        #region Helper Methods
        /// <summary>
        /// Get the parent of this element. Can be null.
        /// </summary>
        /// <returns>Parent element if one is found. Null otherwise.</returns>
        public ModelElement GetParent()
        {
            return this.GetDomainModelServices().TopMostService.ElementParentProvider.GetEmbeddingParent(this);
        }

        /// <summary>
        /// Get all children of this element.
        /// </summary>
        /// <returns>Children elements.</returns>
        public List<ModelElement> GetChildren()
        {
            return this.GetDomainModelServices().TopMostService.ElementChildrenProvider.GetChildren(this, false);
        }

        /// <summary>
        /// Get local children of this element.
        /// </summary>
        /// <returns>Children elements.</returns>
        public List<ModelElement> GetLocalChildren()
        {
            return this.GetDomainModelServices().TopMostService.ElementChildrenProvider.GetChildren(this, true);
        }
        #endregion

        /// <summary>
        /// Gets the domain model store.
        /// </summary>
        public new DomainModelStore Store
        {
            get
            {
                return base.Store as DomainModelStore;
            }
        }

        /// <summary>
        /// Get source domain role.
        /// </summary>
        /// <param name="info">Relationship info.</param>
        /// <returns>Source domain role.</returns>
        public static DomainRoleInfo GetSourceDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find source domain role in info " + info.Name);
        }

        /// <summary>
        /// Get target domain role.
        /// </summary>
        /// <param name="info">Relationship info.</param>
        /// <returns>Target domain role.</returns>
        public static DomainRoleInfo GetTargetDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (!info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find target domain role in info " + info.Name);
        }
    }
}
