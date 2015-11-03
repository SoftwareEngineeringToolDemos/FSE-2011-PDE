using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Helper class, used to execute the paste/move command.
    /// </summary>
    public class ModelProtoGroupMerger
    {
        private Dictionary<Guid, Guid> idMapping;
        private ValidationResult validationResult;

        private ModelProtoGroup protoGroup;
        private Dictionary<Guid, List<ModelProtoElement>> embeddingMapping;
        private Dictionary<Guid, List<ModelProtoLink>> referencingMapping;
        private Dictionary<Guid, List<ModelProtoLink>> referencingMappingTarget;
        private Dictionary<Guid, ModelProtoElement> elementMapping;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="protoGroup">Proto group to paste/move.</param>
        /// <param name="rootElement">Element to execute paste/move on.</param>
        public ModelProtoGroupMerger(ModelProtoGroup protoGroup, ModelElement rootElement)
        {
            this.protoGroup = protoGroup;
            this.validationResult = new ValidationResult();

            this.idMapping = new Dictionary<Guid, Guid>();
            this.embeddingMapping = new Dictionary<Guid, List<ModelProtoElement>>();
            this.referencingMapping = new Dictionary<Guid, List<ModelProtoLink>>();
            this.referencingMappingTarget = new Dictionary<Guid, List<ModelProtoLink>>();
            this.elementMapping = new Dictionary<Guid, ModelProtoElement>();

            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
            {
                // move element
                foreach (ModelProtoElement protoElement in protoGroup.ProtoRootElements)
                {
                    (rootElement as IModelMergeElements).ModelMove(protoElement, this);
                }
                return;
            }

            foreach (ModelProtoElement element in protoGroup.ProtoElements)
            {
                idMapping.Add(element.ElementId, Guid.Empty);
                embeddingMapping.Add(element.ElementId, new List<ModelProtoElement>());
                referencingMapping.Add(element.ElementId, new List<ModelProtoLink>());
                referencingMappingTarget.Add(element.ElementId, new List<ModelProtoLink>());
                elementMapping.Add(element.ElementId, element);
            }
            foreach (ModelProtoLink link in protoGroup.ProtoEmbeddingLinks)
            {
                ModelProtoRolePlayer rolePlayer = link.GetSourceRolePlayer(rootElement.Store.DefaultPartition);
                ModelProtoElement p = GetElementById(rolePlayer.RolePlayerId);
                if (p != null)
                {
                    embeddingMapping[p.ElementId].Add(
                       GetElementById(link.GetTargetRolePlayer(rootElement.Store.DefaultPartition).RolePlayerId));
                }
            }            

            foreach (ModelProtoLink link in protoGroup.ProtoReferenceLinks)
            {
                ModelProtoRolePlayer sourceRP = link.GetSourceRolePlayer(rootElement.Store.DefaultPartition);
                ModelProtoElement p = GetElementById(sourceRP.RolePlayerId);
                if (p != null)
                    referencingMapping[p.ElementId].Add(link);

                ModelProtoRolePlayer targetRP = link.GetTargetRolePlayer(rootElement.Store.DefaultPartition);
                p = GetElementById(targetRP.RolePlayerId);
                if (p != null)
                    referencingMappingTarget[p.ElementId].Add(link);
            }

            // start merging
            foreach (ModelProtoElement protoElement in protoGroup.ProtoRootElements)
            {
                (rootElement as IModelMergeElements).ModelMerge(protoElement, this, true);
            }

            // process reference relationships
            foreach (ModelProtoLink link in protoGroup.ProtoReferenceLinks)
            {
                ModelProtoRolePlayer sourceRP = link.GetSourceRolePlayer(rootElement.Store.DefaultPartition);
                if (this.idMapping.ContainsKey(sourceRP.RolePlayerId))
                {
                    System.Guid id = this.idMapping[sourceRP.RolePlayerId];
                    if (id != Guid.Empty)
                    {
                        ModelElement copiedModelElement = rootElement.Store.ElementDirectory.FindElement(id);
                        if (copiedModelElement != null)
                            if (copiedModelElement is IModelMergeElements)
                            {
                                (copiedModelElement as IModelMergeElements).ModelMerge(link, this);
                            }
                        continue;
                    }
                }

                System.Guid elementId = sourceRP.RolePlayerId;
                ModelElement modelElement = rootElement.Store.ElementDirectory.FindElement(elementId);
                if (modelElement != null)
                    if (modelElement is IModelMergeElements)
                    {
                        (modelElement as IModelMergeElements).ModelMerge(link, this);
                    }                
            }

            // finalize merging
            foreach (ModelProtoElement protoElement in protoGroup.ProtoElements)
            {
                Guid id = Guid.Empty;
                try
                {
                    id = GetIdMapping(protoElement.ElementId);
                }
                catch
                {
                    id = Guid.Empty;
                    continue;
                }

                /*
                if (id == Guid.Empty)
                {
                    ModelElement m = rootElement.Store.ElementDirectory.FindElement(id);
                    if (m != null)
                        id = m.Id;
                    else
                        continue;
                }*/

                ModelElement m = rootElement.Store.ElementDirectory.FindElement(id);
                if( m != null )
                    (m as IModelMergeElements).ModelFinalize(protoElement, this);
            }

            // finalize merging
            foreach (ModelProtoElement protoElement in protoGroup.ProtoRootElements)
            {
                (rootElement as IModelMergeElements).ModelFinalizeMerge(protoElement, this);
            }
        }

        /// <summary>
        /// Sets the id mapping between an original and a mapped id.
        /// </summary>
        /// <param name="originalId">Original Id.</param>
        /// <param name="mappedId">Newly created Id representing the element with the original Id.</param>
        public void SetIdMapping(Guid originalId, Guid mappedId)
        {
            if (!idMapping.Keys.Contains(originalId))
                throw new InvalidOperationException("originalId is unknown");

            idMapping[originalId] = mappedId;
        }

        /// <summary>
        /// Adds an id mapping between an original and a mapped id.
        /// </summary>
        /// <param name="originalId">Original Id.</param>
        /// <param name="mappedId">Newly created Id representing the element with the original Id.</param>
        public void AddIdMapping(Guid originalId, Guid mappedId)
        {
            if (!idMapping.ContainsKey(originalId))
                idMapping.Add(originalId, mappedId);
            else
                idMapping[originalId] = mappedId;
        }

        /// <summary>
        /// Gets the mapped Id.
        /// </summary>
        /// <param name="originalId">Original Id to get the mapped Id for.</param>
        /// <returns>Mapped Id.</returns>
        public Guid GetIdMapping(Guid originalId)
        {
            if (!idMapping.Keys.Contains(originalId))
                throw new InvalidOperationException("originalId is unknown");

            return idMapping[originalId];
        }

        /// <summary>
        /// Get all embedded proto elements for the given element.
        /// </summary>
        /// <param name="partition">Partition.</param>
        /// <param name="protoElement">Proto element to get all embedded elements for.</param>
        /// <returns>List of embedded proto elements.</returns>
        public List<ModelProtoElement> GetEmbeddedElements(Partition partition, ModelProtoElement protoElement)
        {
            List<ModelProtoElement> elements;
            this.embeddingMapping.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Get source proto links.
        /// </summary>
        /// <param name="partition"></param>
        /// <param name="protoElement"></param>
        /// <returns></returns>
        public List<ModelProtoLink> GetReferenceLinks(Partition partition, ModelProtoElement protoElement)
        {
            List<ModelProtoLink> elements;
            this.referencingMapping.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Get target proto links.
        /// </summary>
        /// <param name="partition"></param>
        /// <param name="protoElement"></param>
        /// <returns></returns>
        public List<ModelProtoLink> GetReferenceLinksTarget(Partition partition, ModelProtoElement protoElement)
        {
            List<ModelProtoLink> elements;
            this.referencingMappingTarget.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Gets an elements of a specific Id.
        /// </summary>
        /// <param name="elementId">Id of the element to retrieve.</param>
        /// <returns>Element of the specific Id or null.</returns>
        public ModelProtoElement GetElementById(Guid elementId)
        {
            ModelProtoElement element;
            this.elementMapping.TryGetValue(elementId, out element);
            return element;
        }

        /// <summary>
        /// Returns the proto group.
        /// </summary>
        public ModelProtoGroup ProtoGroup
        {
            get { return protoGroup; }
        }

        /// <summary>
        /// Validation result used to keep track of warnings and errors.
        /// </summary>
        public ValidationResult MergeResult
        {
            get
            {
                return this.validationResult;
            }
        }
    }
}
