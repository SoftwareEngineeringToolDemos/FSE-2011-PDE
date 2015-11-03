using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Data class for advanced reflection information.
    /// </summary>
    public class DomainDataAdvDirectory
    {
        private Dictionary<Type, IDomainDataExtensionDirectory> extensions;

        private Dictionary<Guid, DomainRelationshipAdvancedInfo> relationshipDictionary;
        private Dictionary<Guid, ModelContextInfo> modelContextDictionary;
        private Dictionary<Guid, EmbeddingRelationshipOrderInfo> embRelationshipOrderDictionary;
        private Dictionary<Guid, DomainClassAdvancedInfo> classDictionary;
        
        private Dictionary<Guid, Dictionary<Guid, List<Guid>>> parentChildrenMapping;
        private Dictionary<Guid, Dictionary<Guid, List<Guid>>> parentChildrenCMMapping;

        private DomainModelStore Store;

        /// <summary>
        /// Dictionary containing references from a domain class to reference relationship infos.
        /// Domain class is the source of reference relationships
        /// </summary>
        private Dictionary<Guid, List<ReferenceRelationshipAdvancedInfo>> domainClassSourceReferences;

        /// <summary>
        /// Dictionary containing references from a domain class to reference relationship infos.
        /// Domain class is the target of reference relationships
        /// </summary>
        private Dictionary<Guid, List<ReferenceRelationshipAdvancedInfo>> domainClassTargetReferences;

        /// <summary>
        /// Dictionary containing references from a domain class to embedding relationship infos.
        /// Domain class is the source of embedding relationships
        /// </summary>
        private Dictionary<Guid, List<EmbeddingRelationshipAdvancedInfo>> domainClassSourceEmbeddings;

        /// <summary>
        /// Dictionary containing references from a domain class to embedding relationship infos.
        /// Domain class is the target of embedding relationships
        /// </summary>
        private Dictionary<Guid, List<EmbeddingRelationshipAdvancedInfo>> domainClassTargetEmbeddings;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DomainDataAdvDirectory(DomainModelStore store)
        {
            this.Store = store;
            
            this.extensions = new Dictionary<Type, IDomainDataExtensionDirectory>();

            this.classDictionary = new Dictionary<Guid, DomainClassAdvancedInfo>();
            this.relationshipDictionary = new Dictionary<Guid, DomainRelationshipAdvancedInfo>();
            this.modelContextDictionary = new Dictionary<Guid, ModelContextInfo>();
            this.embRelationshipOrderDictionary = new Dictionary<Guid, EmbeddingRelationshipOrderInfo>();

            this.parentChildrenMapping = new Dictionary<Guid, Dictionary<Guid, List<Guid>>>();
            this.parentChildrenCMMapping = new Dictionary<Guid, Dictionary<Guid, List<Guid>>>();

            this.domainClassSourceReferences = new Dictionary<Guid, List<ReferenceRelationshipAdvancedInfo>>();
            this.domainClassTargetReferences = new Dictionary<Guid, List<ReferenceRelationshipAdvancedInfo>>();

            this.domainClassSourceEmbeddings = new Dictionary<Guid, List<EmbeddingRelationshipAdvancedInfo>>();
            this.domainClassTargetEmbeddings = new Dictionary<Guid, List<EmbeddingRelationshipAdvancedInfo>>();
        }

        #region Initialization
        internal void ProcessClassInfos(DomainClassAdvancedInfo[] infos)
        {
            if (infos == null)
                return;

            foreach (DomainClassAdvancedInfo info in infos)
                classDictionary.Add(info.DomainClassId, info);
        }
        internal void ProcessRelationshipInfos(DomainRelationshipAdvancedInfo[] infos)
        {
            if (infos == null)
                return;

            foreach (DomainRelationshipAdvancedInfo info in infos)
                relationshipDictionary.Add(info.RelationshipDomainClassId, info);
        }
        internal void ProcessEmbeddingRelationshipOrderInfo(EmbeddingRelationshipOrderInfo[] infos)
        {
            if (infos == null)
                return;

            foreach (EmbeddingRelationshipOrderInfo info in infos)
                embRelationshipOrderDictionary.Add(info.DomainClassId, info);
        }
        internal void ProcessModelContextInfos(ModelContextInfo[] infos)
        {
            if (infos == null)
                return;

            foreach (ModelContextInfo info in infos)
                modelContextDictionary.Add(info.ModelContextId, info);
        }

        internal bool IsClassRelationshipsInitialized = false;
        internal void InitializeClassRelationships()
        {
            if (IsClassRelationshipsInitialized)
                return;

            IsClassRelationshipsInitialized = true;

            foreach (Guid key in classDictionary.Keys)
            {
                domainClassSourceReferences.Add(key, new List<ReferenceRelationshipAdvancedInfo>());
                domainClassTargetReferences.Add(key, new List<ReferenceRelationshipAdvancedInfo>());
                domainClassSourceEmbeddings.Add(key, new List<EmbeddingRelationshipAdvancedInfo>());
                domainClassTargetEmbeddings.Add(key, new List<EmbeddingRelationshipAdvancedInfo>());
            }

            foreach (Guid key in relationshipDictionary.Keys)
            {
                DomainRelationshipAdvancedInfo info = relationshipDictionary[key];
                domainClassTargetReferences.Add(info.RelationshipDomainClassId, new List<ReferenceRelationshipAdvancedInfo>());
            }
            foreach (Guid key in relationshipDictionary.Keys)
            {
                DomainRelationshipAdvancedInfo info = relationshipDictionary[key];
                InitializeClassRelationships(info.SourceElementDomainClassId, info.TargetElementDomainClassId, info, true);
                /*if (info is ReferenceRelationshipAdvancedInfo)
                {
                    domainClassSourceReferences[info.SourceElementDomainClassId].Add(info as ReferenceRelationshipAdvancedInfo);
                    domainClassTargetReferences[info.TargetElementDomainClassId].Add(info as ReferenceRelationshipAdvancedInfo);
                }
                else
                {
                    domainClassSourceEmbeddings[info.SourceElementDomainClassId].Add(info as EmbeddingRelationshipAdvancedInfo);
                    domainClassTargetEmbeddings[info.TargetElementDomainClassId].Add(info as EmbeddingRelationshipAdvancedInfo);
                }*/
            }

            foreach (Guid key in classDictionary.Keys)
            {
                if (domainClassSourceReferences[key].Count == 0)
                    domainClassSourceReferences.Remove(key);
                if (domainClassTargetReferences[key].Count == 0)
                    domainClassTargetReferences.Remove(key);
                if (domainClassSourceEmbeddings[key].Count == 0)
                    domainClassSourceEmbeddings.Remove(key);
                if (domainClassTargetEmbeddings[key].Count == 0)
                    domainClassTargetEmbeddings.Remove(key);
            }
        }
        private void InitializeClassRelationships(Guid source, Guid target, DomainRelationshipAdvancedInfo info, bool bPropagateToDescendants)
        {
            if (info is ReferenceRelationshipAdvancedInfo)
            {
                domainClassSourceReferences[source].Add(info as ReferenceRelationshipAdvancedInfo);
                domainClassTargetReferences[target].Add(info as ReferenceRelationshipAdvancedInfo);
            }
            else
            {
                domainClassSourceEmbeddings[source].Add(info as EmbeddingRelationshipAdvancedInfo);
                domainClassTargetEmbeddings[target].Add(info as EmbeddingRelationshipAdvancedInfo);
            }

            if (bPropagateToDescendants)
            {
                DomainClassInfo infoSource = this.Store.DomainDataDirectory.GetDomainClass(source);
                foreach (DomainClassInfo d in infoSource.AllDescendants)
                {
                    InitializeClassRelationships(d.Id, target, info, false);
                }

                DomainClassInfo infoTarget = this.Store.DomainDataDirectory.GetDomainClass(target);
                foreach (DomainClassInfo d in infoTarget.AllDescendants)
                {
                    InitializeClassRelationships(source, d.Id, info, false);
                }
            }
        }

        internal void ProcessInfos()
        {
            // create dictionaries with specific information
            foreach (Guid modelContextId in modelContextDictionary.Keys)
            {
                parentChildrenMapping.Add(modelContextId, new Dictionary<Guid, List<Guid>>());
                parentChildrenCMMapping.Add(modelContextId, new Dictionary<Guid, List<Guid>>());

                List<Guid> parsedClasses = new List<Guid>();
                parsedClasses.Add(modelContextDictionary[modelContextId].DomainModelId);
                ProcessInitializationInfo(modelContextId, modelContextDictionary[modelContextId].DomainModelId, parsedClasses);
            }
        }
        private void ProcessInitializationInfo(Guid modelContextId, Guid domainClassId, List<Guid> processedClasses)
        {
            EmbeddingRelationshipOrderInfo info;
            this.embRelationshipOrderDictionary.TryGetValue(domainClassId, out info);

            if (info != null)
            {
                parentChildrenMapping[modelContextId].Add(domainClassId, new List<Guid>());
                parentChildrenMapping[modelContextId][domainClassId].AddRange(info.EmbeddingRelationships);

                parentChildrenCMMapping[modelContextId].Add(domainClassId, new List<Guid>());
                parentChildrenCMMapping[modelContextId][domainClassId].AddRange(info.EmbeddingRelationshipsTargetIncludedSubmodel);

                for(int i = 0; i < info.EmbeddingRelationships.Length; i++ )
                {
                    DomainRelationshipInfo rInfo = this.Store.DomainDataDirectory.GetDomainRelationship(info.EmbeddingRelationships[i]);
                    DomainClassInfo cInfo = DomainModelElement.GetTargetDomainRole(rInfo).RolePlayer;

                    if (!processedClasses.Contains(cInfo.Id))
                    {
                        processedClasses.Add(cInfo.Id);
                        ProcessInitializationInfo(modelContextId, cInfo.Id, processedClasses);
                    }

                    foreach (DomainClassInfo dInfo in cInfo.AllDescendants)
                    {
                        if (!processedClasses.Contains(dInfo.Id))
                        {
                            processedClasses.Add(dInfo.Id);
                            ProcessInitializationInfo(modelContextId, dInfo.Id, processedClasses);
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Gets the parent children mapping dictionary. The first Guid represents model context id, second a domain class ID of an element.
        /// The list is a collection of domain relationship DomainClassIds.
        /// </summary>
        /// <remarks>
        /// The content of this dictionary is provided in the initialize method of the derived model tree class.
        /// </remarks>
        public Dictionary<Guid, Dictionary<Guid, List<Guid>>> ParentChildrenMapping
        {
            get
            {
                return this.parentChildrenMapping;
            }
        }

        /// <summary>
        /// Gets the parent children mapping dictionary for context menu that should not be created. 
        /// The first Guid represents model context id, second a domain class ID of an element.
        /// The list is a collection of domain relationship DomainClassIds.
        /// </summary>
        /// <remarks>
        /// The content of this dictionary is provided in the initialize method of the derived model tree class.
        /// </remarks>
        public Dictionary<Guid, Dictionary<Guid, List<Guid>>> ParentChildrenCMMapping
        {
            get
            {
                return this.parentChildrenCMMapping;
            }
        }

        /// <summary>
        /// Verifies if the given model element belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelElement">Model element.</param>
        /// <returns>True if the element belongs to the domain model. False otherwise.</returns>
        public bool IsIncludedInModel(DomainModelElement modelElement)
        {
            return IsIncludedInModel(Guid.Empty, modelElement);
        }

        /// <summary>
        /// Verifies if the given model element belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelElementDCId">Model element domain class id.</param>
        /// <returns>True if the element belongs to the domain model. False otherwise.</returns>
        public bool IsIncludedInModel(Guid modelElementDCId)
        {
            return IsIncludedInModel(Guid.Empty, modelElementDCId);
        }
        
        /// <summary>
        /// Verifies if the given model element belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelContextId">Model context Id.</param>
        /// <param name="modelElement">Model element.</param>
        /// <returns>True if the element belongs to the domain model. False otherwise.</returns>
        public bool IsIncludedInModel(Guid modelContextId, DomainModelElement modelElement)
        {
            if (modelElement == null)
                return false;

            return IsIncludedInModel(modelContextId, modelElement.GetDomainClassId());
        }

        /// <summary>
        /// Verifies if the given model element belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelContextId">Model context Id.</param>
        /// <param name="modelElementDCId">Model element domain class id.</param>
        /// <returns>True if the element belongs to the domain model. False otherwise.</returns>
        public bool IsIncludedInModel(Guid modelContextId, Guid modelElementDCId)
        {
            foreach (Guid key in this.modelContextDictionary.Keys)
                if (key == modelContextId || modelContextId == Guid.Empty)
                {
                    if (parentChildrenMapping[key].ContainsKey(modelElementDCId))
                        return true;
                }

            return false;
        }

        /// <summary>
        /// Verifies if the given reference link belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelLink">Model link.</param>
        /// <returns>True if the refrence link belongs to the domain model. False otherwise.</returns>
        public bool IsReferenceIncludedInModel(DomainModelLink modelLink)
        {
            return IsReferenceIncludedInModel(Guid.Empty, modelLink);
        }

        /// <summary>
        /// Verifies if the given reference link belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelLinkDCId">Model link domain class Id.</param>
        /// <returns>True if the refrence link belongs to the domain model. False otherwise.</returns>
        public bool IsReferenceIncludedInModel(Guid modelLinkDCId)
        {
            if (modelLinkDCId == DomainModelLink.DomainClassId)
                return false;

            return IsReferenceIncludedInModel(Guid.Empty, modelLinkDCId);
        }

        /// <summary>
        /// Verifies if the given reference link belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelLink">Model link.</param>
        /// <param name="modelContextId">Model context Id.</param>
        /// <returns>True if the refrence link belongs to the domain model. False otherwise.</returns>
        public bool IsReferenceIncludedInModel(Guid modelContextId, DomainModelLink modelLink)
        {
            if (modelLink.IsEmbedding)
                return false;

            DomainModelElement m = DomainRoleInfo.GetSourceRolePlayer(modelLink) as DomainModelElement;
            if (IsIncludedInModel(modelContextId, m))
                return true;

            m = DomainRoleInfo.GetTargetRolePlayer(modelLink) as DomainModelElement;
            if (IsIncludedInModel(modelContextId, m))
                return true;

            return false;
        }

        /// <summary>
        /// Verifies if the given reference link belongs to the domain model (can be reached from the domain model element).
        /// </summary>
        /// <param name="modelLinkDCId">Model link domain class Id.</param>
        /// <param name="modelContextId">Model context Id.</param>
        /// <returns>True if the refrence link belongs to the domain model. False otherwise.</returns>
        public bool IsReferenceIncludedInModel(Guid modelContextId, Guid modelLinkDCId)
        {
            DomainRelationshipInfo info = this.Store.DomainDataDirectory.FindDomainRelationship(modelLinkDCId);
            if (IsIncludedInModel(modelContextId, DomainModelElement.GetSourceDomainRole(info).RolePlayer.Id))
                return true;

            if (IsIncludedInModel(modelContextId, DomainModelElement.GetTargetDomainRole(info).RolePlayer.Id))
                return true;

            return false;
        }

        /// <summary>
        /// Verifies if the given relationship is embedding or not.
        /// </summary>
        /// <param name="modelLinkDCId">Model link domain class Id.</param>
        /// <returns>True if the provided model link type is embedding. False otherwise.</returns>
        public bool IsEmbeddingRelationship(Guid modelLinkDCId)
        {
            DomainRelationshipAdvancedInfo info;
            relationshipDictionary.TryGetValue(modelLinkDCId, out info);

            if (info == null)
                return false;              //    throw new InvalidOperationException("Unknown relationship type " + modelLinkDCId.ToString());
            

            if (info is EmbeddingRelationshipAdvancedInfo)
                return true;
            return false;
        }

        /// <summary>
        /// Verifies if the given relationship is abstract or not.
        /// </summary>
        /// <param name="modelLinkDCId">Model link domain class Id.</param>
        /// <returns>True if the provided model link type is abstract. False otherwise.</returns>
        public bool IsAbstractRelationship(Guid modelLinkDCId)
        {
            DomainRelationshipAdvancedInfo info;
            relationshipDictionary.TryGetValue(modelLinkDCId, out info);

            if (info == null)
                throw new InvalidOperationException("Unknown relationship type " + modelLinkDCId.ToString());

            return info.IsAbstract;
        }

        /// <summary>
        /// Verifies if the given class is abstract or not.
        /// </summary>
        /// <param name="domainClassId">Domain class Id.</param>
        /// <returns>True if the provided model element type is abstract. False otherwise.</returns>
        public bool IsAbstractClass(Guid domainClassId)
        {
            DomainClassAdvancedInfo info;
            this.classDictionary.TryGetValue(domainClassId, out info);

            if (info == null)
                throw new InvalidOperationException("Unknown class type " + domainClassId.ToString());

            return info.IsAbstract;
        }

        /// <summary>
        /// Tries to find the DomainRelationshipAdvancedInfo for the specified relationship.
        /// </summary>
        /// <param name="domainClassId">DomainClassId of the relationship.</param>
        /// <returns>DomainRelationshipAdvancedInfo if found; null otherwise.</returns>
        public DomainRelationshipAdvancedInfo FindRelationshipInfo(Guid domainClassId)
        {
            DomainRelationshipAdvancedInfo info;
            this.relationshipDictionary.TryGetValue(domainClassId, out info);

            return info;
        }

        /// <summary>
        /// Gets the DomainRelationshipAdvancedInfo for the specified relationship.
        /// </summary>
        /// <param name="domainClassId">DomainClassId of the relationship.</param>
        /// <returns>DomainRelationshipAdvancedInfo.</returns>
        public DomainRelationshipAdvancedInfo GetRelationshipInfo(Guid domainClassId)
        {
            return relationshipDictionary[domainClassId];
        }

        /// <summary>
        /// Tries to find the DomainClassAdvancedInfo for the specified class.
        /// </summary>
        /// <param name="domainClassId">DomainClassId of the class.</param>
        /// <returns>DomainClassAdvancedInfo if found; null otherwise.</returns>
        public DomainClassAdvancedInfo FindClassInfo(Guid domainClassId)
        {
            DomainClassAdvancedInfo info;
            this.classDictionary.TryGetValue(domainClassId, out info);

            return info;
        }

        /// <summary>
        /// Gets the DomainClassAdvancedInfo for the specified class.
        /// </summary>
        /// <param name="domainClassId">DomainClassId of the class.</param>
        /// <returns>DomainClassAdvancedInfo.</returns>
        public DomainClassAdvancedInfo GetClassInfo(Guid domainClassId)
        {
            return classDictionary[domainClassId];
        }

        /// <summary>
        /// Finds references from a domain class to reference relationship infos.
        /// Domain class is the source of reference relationships.
        /// </summary>
        /// <param name="domainClassId">DomainClassId</param>
        /// <returns>List if found; null otherwise.</returns>
        public List<ReferenceRelationshipAdvancedInfo> FindDomainClassSourceReferences(Guid domainClassId)
        {
            InitializeClassRelationships();

            List<ReferenceRelationshipAdvancedInfo> infos;
            domainClassSourceReferences.TryGetValue(domainClassId, out infos);

            return infos;
        }

        /// <summary>
        /// Finds references from a domain class to reference relationship infos.
        /// Domain class is the target of reference relationships.
        /// </summary>
        /// <param name="domainClassId">DomainClassId</param>
        /// <returns>List if found; null otherwise.</returns>
        public List<ReferenceRelationshipAdvancedInfo> FindDomainClassTargetReferences(Guid domainClassId)
        {
            InitializeClassRelationships();

            List<ReferenceRelationshipAdvancedInfo> infos;
            domainClassTargetReferences.TryGetValue(domainClassId, out infos);

            return infos;
        }

        /// <summary>
        /// Finds references from a domain class to embedding relationship infos.
        /// Domain class is the source of embedding relationships.
        /// </summary>
        /// <param name="domainClassId">DomainClassId</param>
        /// <returns>List if found; null otherwise.</returns>
        public List<EmbeddingRelationshipAdvancedInfo> FindDomainClassSourceEmbeddings(Guid domainClassId)
        {
            InitializeClassRelationships();

            List<EmbeddingRelationshipAdvancedInfo> infos;
            domainClassSourceEmbeddings.TryGetValue(domainClassId, out infos);

            return infos;
        }

        /// <summary>
        /// Finds references from a domain class to embedding relationship infos.
        /// Domain class is the target of embedding relationships.
        /// </summary>
        /// <param name="domainClassId">DomainClassId</param>
        /// <returns>List if found; null otherwise.</returns>
        public List<EmbeddingRelationshipAdvancedInfo> FindDomainClassTargetEmbeddings(Guid domainClassId)
        {
            InitializeClassRelationships();

            List<EmbeddingRelationshipAdvancedInfo> infos;
            domainClassTargetEmbeddings.TryGetValue(domainClassId, out infos);

            return infos;
        }

        /// <summary>
        /// Resolves an existing extension directory.
        /// </summary>
        /// <typeparam name="T">Type of the directory.</typeparam>
        /// <returns>Directory if found; null otherwise.</returns>
        public T ResolveExtensionDirectory<T>()
             where T : IDomainDataExtensionDirectory
        {
            IDomainDataExtensionDirectory e;
            if (extensions.TryGetValue(typeof(T), out e))
                return (T)e;

            return default(T);
        }

        /// <summary>
        /// Processes the given data extensions.
        /// </summary>
        /// <param name="data">Data extensions.</param>
        public void ProcessDataExtensions(IDomainDataExtensionDirectory[] data)
        {
            if (data == null)
                return;

            foreach (IDomainDataExtensionDirectory d in data)
            {
                d.Process();

                if (this.extensions.ContainsKey(d.GetExtensionType()))
                    this.extensions[d.GetExtensionType()].Merge(d);
                else
                    this.extensions.Add(d.GetExtensionType(), d);
            }
        }
    }
}
