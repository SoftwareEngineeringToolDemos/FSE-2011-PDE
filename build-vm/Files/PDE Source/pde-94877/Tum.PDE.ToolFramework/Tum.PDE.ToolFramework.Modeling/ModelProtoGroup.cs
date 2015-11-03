using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// ProtoGroups contain the information to recreate element in any given store.
    /// </summary>
    /// <remarks>
    /// Source: DSL-Tools framework for the most part.
    /// </remarks>
    [System.Serializable]
    public class ModelProtoGroup : ISerializable, IDeserializationCallback
    {
        /// <summary>
        /// Default data format name to use in the clipboard.
        /// </summary>
        public static readonly string DefaultDataFormatName;

        /// <summary>
        /// Name identifying the id parameter of the proto group, used in the clipboard.
        /// </summary>
        public static readonly string DefaultDataIdentifierName;

        private List<ModelProtoElement> protoElements;
        private List<ModelProtoElement> protoRootElements;

        private List<ModelProtoLink> protoReferenceLinks;
        private List<ModelProtoLink> protoEmbeddingLinks;
        
        private ModelProtoGroupOperation protoOperation;
        //private Store store;
        private SerializationInfo serializationInfo;

        private Dictionary<Guid, List<ModelProtoElement>> embeddingMapping;
        private Dictionary<Guid, List<ModelProtoLink>> referencingMapping;
        private Dictionary<Guid, List<ModelProtoLink>> referencingMappingTarget;
        private Dictionary<Guid, ModelProtoElement> elementMapping;
        private bool bNeedsInitialization = true;

        static ModelProtoGroup()
        {
            DefaultDataFormatName = typeof(ModelProtoGroup).FullName;
            DefaultDataIdentifierName = "GPInstanceId";
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="elements">Model element to create proto elements for.</param>
        /// <param name="operation">Operation.</param>
        public ModelProtoGroup(ICollection<ModelElement> elements, ModelProtoGroupOperation operation)
        {
            if (elements.Count == 0)
                throw new ArgumentNullException("elements");

            this.protoElements = new List<ModelProtoElement>(6000);
            this.protoRootElements = new List<ModelProtoElement>(6000);

            this.protoEmbeddingLinks = new List<ModelProtoLink>(6000);
            this.protoReferenceLinks = new List<ModelProtoLink>(6000);

            this.protoOperation = operation;

            foreach (ModelElement modelElement in elements)
            {
                if (modelElement is IModelMergeElements)
                {
                    ModelProtoElement root;
                    if (operation == ModelProtoGroupOperation.Copy)
                    {
                        root = (modelElement as IModelMergeElements).ModelCreateMergeCopy(this);
                    }
                    else
                        root = (modelElement as IModelMergeElements).ModelCreateMoveCopy(this);
                    if (root == null)
                        throw new ArgumentNullException("root");
                    this.protoRootElements.Insert(0, root);
                }
            }

            InitDictionaries(elements.ElementAt(0).Partition);
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ModelProtoGroup(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            serializationInfo = info;
        }

        /// <summary>
        /// Deserialize.
        /// </summary>
        public void OnDeserialization(object sender)
        {
            protoElements = (List<ModelProtoElement>)serializationInfo.GetValue("protoElements", typeof(List<ModelProtoElement>));
            protoRootElements = (List<ModelProtoElement>)serializationInfo.GetValue("protoRootElements", typeof(List<ModelProtoElement>));

            protoReferenceLinks = (List<ModelProtoLink>)serializationInfo.GetValue("protoReferenceLinks", typeof(List<ModelProtoLink>));
            protoEmbeddingLinks = (List<ModelProtoLink>)serializationInfo.GetValue("protoEmbeddingLinks", typeof(List<ModelProtoLink>));
            
            //protoElements = new List<ModelProtoElement>((ModelProtoElement[])serializationInfo.GetValue("protoElements", typeof(ModelProtoElement[])));
            //protoRootElements = new List<ModelProtoElement>((ModelProtoElement[])serializationInfo.GetValue("protoRootElements", typeof(ModelProtoElement[])));

            //protoReferenceLinks = new List<ModelProtoLink>((ModelProtoLink[])serializationInfo.GetValue("protoReferenceLinks", typeof(ModelProtoLink[])));
            //protoEmbeddingLinks = new List<ModelProtoLink>((ModelProtoLink[])serializationInfo.GetValue("protoEmbeddingLinks", typeof(ModelProtoLink[])));

            protoOperation = (ModelProtoGroupOperation)serializationInfo.GetValue("protoOperation", typeof(ModelProtoGroupOperation));

            bNeedsInitialization = true;
        }

        /// <summary>
        /// Gets the operation type.
        /// </summary>
        public ModelProtoGroupOperation Operation
        {
            get
            {
                return protoOperation;
            }
        }

        private void InitDictionaries(Partition partition)
        {
            bNeedsInitialization = false;

            this.embeddingMapping = new Dictionary<Guid, List<ModelProtoElement>>();
            this.referencingMapping = new Dictionary<Guid, List<ModelProtoLink>>();
            this.referencingMappingTarget = new Dictionary<Guid, List<ModelProtoLink>>();
            this.elementMapping = new Dictionary<Guid, ModelProtoElement>();

            foreach (ModelProtoElement element in this.ProtoElements)
            {
                embeddingMapping.Add(element.ElementId, new List<ModelProtoElement>());
                referencingMapping.Add(element.ElementId, new List<ModelProtoLink>());
                referencingMappingTarget.Add(element.ElementId, new List<ModelProtoLink>());
                elementMapping.Add(element.ElementId, element);
            }
            foreach (ModelProtoLink link in this.ProtoEmbeddingLinks)
            {
                ModelProtoRolePlayer rolePlayer = link.GetSourceRolePlayer(partition);
                ModelProtoElement p = GetElementById(rolePlayer.RolePlayerId);
                if (p != null)
                {
                    embeddingMapping[p.ElementId].Add(
                       GetElementById(link.GetTargetRolePlayer(partition).RolePlayerId));
                }
            }

            foreach (ModelProtoLink link in this.ProtoReferenceLinks)
            {
                ModelProtoRolePlayer sourceRP = link.GetSourceRolePlayer(partition);
                ModelProtoElement p = GetElementById(sourceRP.RolePlayerId);
                if (p != null)
                    referencingMapping[p.ElementId].Add(link);

                ModelProtoRolePlayer targetRP = link.GetTargetRolePlayer(partition);
                p = GetElementById(targetRP.RolePlayerId);
                if (p != null)
                    referencingMappingTarget[p.ElementId].Add(link);
            }
        }

        /// <summary>
        /// Gets an elements of a specific Id.
        /// </summary>
        /// <param name="elementId">Id of the element to retrieve.</param>
        /// <returns>Element of the specific Id or null.</returns>
        private ModelProtoElement GetElementById(Guid elementId)
        {
            ModelProtoElement element;
            this.elementMapping.TryGetValue(elementId, out element);
            return element;
        }

        /// <summary>
        /// Verifies if there is a proto element for the specified element id.
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public bool HasProtoElementFor(Guid elementId, Partition partition)
        {
            if (bNeedsInitialization)
                InitDictionaries(partition);

            if (GetElementById(elementId) == null)
                return false;

            return true;
        }

        /// <summary>
        /// Verifies if there is a proto element for the specified element id.
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="partition"></param>
        /// <returns>Protoelement if found; Null otherwise.</returns>
        public ModelProtoElement GetProtoElementFor(Guid elementId, Partition partition)
        {
            if (bNeedsInitialization)
                InitDictionaries(partition);

            return GetElementById(elementId);
        }

        /// <summary>
        /// Get all embedded proto elements for the given element.
        /// </summary>
        /// <param name="partition">Partition.</param>
        /// <param name="protoElement">Proto element to get all embedded elements for.</param>
        /// <returns>List of embedded proto elements.</returns>
        public List<ModelProtoElement> GetEmbeddedElements(Partition partition, ModelProtoElement protoElement)
        {
            if (bNeedsInitialization)
                InitDictionaries(partition);

            List<ModelProtoElement> elements;
            this.embeddingMapping.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Gets the source proto links.
        /// </summary>
        /// <param name="partition"></param>
        /// <param name="protoElement"></param>
        /// <returns></returns>
        public List<ModelProtoLink> GetReferenceLinks(Partition partition, ModelProtoElement protoElement)
        {
            if (bNeedsInitialization)
                InitDictionaries(partition);

            List<ModelProtoLink> elements;
            this.referencingMapping.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Gets the target proto links.
        /// </summary>
        /// <param name="partition"></param>
        /// <param name="protoElement"></param>
        /// <returns></returns>
        public List<ModelProtoLink> GetReferenceLinksTarget(Partition partition, ModelProtoElement protoElement)
        {
            if (bNeedsInitialization)
                InitDictionaries(partition);

            List<ModelProtoLink> elements;
            this.referencingMappingTarget.TryGetValue(protoElement.ElementId, out elements);
            return elements;
        }

        /// <summary>
        /// Adds a proto element to the proto elements collection.
        /// </summary>
        /// <param name="protoElement">Proto element to add to the collection.</param>
        public void AddNewElement(ModelProtoElement protoElement)
        {
            if (!protoElements.Contains(protoElement))
                protoElements.Add(protoElement);
        }

        /// <summary>
        /// Adds a proto element to the proto elements collection.
        /// </summary>
        /// <param name="protoElement">Proto element to add to the collection.</param>
        /// <param name="index">Index.</param>
        public void InsertNewElement(ModelProtoElement protoElement, int index)
        {
            if (!this.protoElements.Contains(protoElement))
                protoElements.Insert(index, protoElement);
        }

        /// <summary>
        /// Sort the proto elements collection
        /// </summary>
        /// <param name="comparer"></param>
        public void SortProtoElements(Comparison<ModelProtoElement> comparer)
        {
            this.protoElements.Sort(comparer);
        }

        /// <summary>
        /// Sort the proto elements root collection
        /// </summary>
        /// <param name="comparer"></param>
        public void SortProtoRootElements(Comparison<ModelProtoElement> comparer)
        {
            this.protoRootElements.Sort(comparer);
        }

        /// <summary>
        /// Adds a proto element to the proto elements collection.
        /// </summary>
        /// <param name="protoElement">Proto element to add to the collection.</param>
        public void AddNewRootElement(ModelProtoElement protoElement)
        {
            if( !this.protoRootElements.Contains(protoElement))
                protoRootElements.Add(protoElement);
        }

        /// <summary>
        /// Adds a proto element to the proto elements collection.
        /// </summary>
        /// <param name="protoElement">Proto element to add to the collection.</param>
        /// <param name="index">Index.</param>
        public void InsertNewRootElement(ModelProtoElement protoElement, int index)
        {
            if (!this.protoRootElements.Contains(protoElement))
                protoRootElements.Insert(index, protoElement);
        }

        /// <summary>
        /// Add new proto link representing a reference relationship to this proto group.
        /// </summary>
        /// <param name="protoLink">Proto link to add this proto group.</param>
        public void AddNewReferenceLink(ModelProtoLink protoLink)
        {
            if (!protoReferenceLinks.Contains(protoLink))
                protoReferenceLinks.Add(protoLink);
        }

        /// <summary>
        /// Add new proto link representing a embedding relationship to this proto group.
        /// </summary>
        /// <param name="protoLink">Proto link to add this proto group.</param>
        public void AddNewEmbeddingLink(ModelProtoLink protoLink)
        {
            if (!protoEmbeddingLinks.Contains(protoLink))
                protoEmbeddingLinks.Add(protoLink);
        }

        /// <summary>
        /// Gets all embedding proto element links.
        /// </summary>
        public ReadOnlyCollection<ModelProtoLink> ProtoEmbeddingLinks
        {
            get
            {
                return protoEmbeddingLinks.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all reference proto element links.
        /// </summary>
        public ReadOnlyCollection<ModelProtoLink> ProtoReferenceLinks
        {
            get
            {
                return protoReferenceLinks.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all proto elements.
        /// </summary>
        public ReadOnlyCollection<ModelProtoElement> ProtoElements
        {
            get
            {
                return protoElements.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all proto root elements.
        /// </summary>
        public ReadOnlyCollection<ModelProtoElement> ProtoRootElements
        {
            get
            {
                return protoRootElements.AsReadOnly();
            }
        }

        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("protoElements", protoElements, typeof(List<ModelProtoElement>));
            info.AddValue("protoRootElements", protoRootElements, typeof(List<ModelProtoElement>));

            info.AddValue("protoReferenceLinks", protoReferenceLinks, typeof(List<ModelProtoLink>));
            info.AddValue("protoEmbeddingLinks", protoEmbeddingLinks, typeof(List<ModelProtoLink>));

            //info.AddValue("protoElements", protoElements.ToArray(), typeof(ModelProtoElement[]));
            //info.AddValue("protoRootElements", protoRootElements.ToArray(), typeof(ModelProtoElement[]));

            //info.AddValue("protoReferenceLinks", protoReferenceLinks.ToArray(), typeof(ModelProtoLink[]));
            //info.AddValue("protoEmbeddingLinks", protoEmbeddingLinks.ToArray(), typeof(ModelProtoLink[]));

            info.AddValue("protoOperation", protoOperation, typeof(ModelProtoGroupOperation));
        }
    }
}
