using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Domain data directory to reflect the diagrams model of a domain metamodel.
    /// </summary>
    [CLSCompliant(false)]
    public abstract class DiagramDomainDataDirectory : IDomainDataExtensionDirectory
    {
        private Dictionary<Guid, DiagramClassInfo> diagramClassDictionary;
        private Dictionary<Guid, ShapeClassInfo> shapeClassDictionary;
        private Dictionary<Guid, RelationshipShapeInfo> relationshipShapeDictionary;
        private Dictionary<Guid, MappingRelationshipShapeInfo> mappingRelationshipShapeDictionary;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected DiagramDomainDataDirectory()
        {
            this.ClassShapesMapping = new Dictionary<Guid, List<Guid>>();
            this.ClassShapesDependenciesMapping = new Dictionary<Guid, Guid>();
            this.DiagramChildrenShapesMapping = new Dictionary<Guid, List<Guid>>();
            this.DiagramRSChildren = new Dictionary<Guid, List<Guid>>();
            this.DiagramMappingRSChildren = new Dictionary<Guid, List<Guid>>();
            this.DiagramRootChildrenShapesMapping = new Dictionary<Guid, List<Guid>>();
            this.ParentChildrenShapesMapping = new Dictionary<Guid, List<Guid>>();

            this.diagramClassDictionary = new Dictionary<Guid, DiagramClassInfo>();
            this.shapeClassDictionary = new Dictionary<Guid, ShapeClassInfo>();
            this.relationshipShapeDictionary = new Dictionary<Guid, RelationshipShapeInfo>();
            this.mappingRelationshipShapeDictionary = new Dictionary<Guid, MappingRelationshipShapeInfo>();
        }

        /// <summary>
        /// Gets the diagram class infos.
        /// </summary>
        public Dictionary<Guid, DiagramClassInfo> DiagramClassInfos
        {
            get { return this.diagramClassDictionary; }
        }

        /// <summary>
        /// Gets the shape class infos.
        /// </summary>
        public Dictionary<Guid, ShapeClassInfo> ShapeClassInfos
        {
            get { return this.shapeClassDictionary; }
        }

        /// <summary>
        /// Gets the rsshape class infos.
        /// </summary>
        public Dictionary<Guid, RelationshipShapeInfo> RelationshipShapeInfos
        {
            get { return this.relationshipShapeDictionary; }
        }

        /// <summary>
        /// Gets the mapping rsshape class infos.
        /// </summary>
        public Dictionary<Guid, MappingRelationshipShapeInfo> MappingRelationshipShapeInfos
        {
            get { return this.mappingRelationshipShapeDictionary; }
        }

        /// <summary>
        /// Shape mapping lookup dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> ClassShapesMapping { get; private set; }

        /// <summary>
        /// Shape mapping lookup for dependencies dictionary.
        /// </summary>
        public Dictionary<Guid, Guid> ClassShapesDependenciesMapping { get; private set; }

        /// <summary>
        /// Parent children shapes mapping dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> ParentChildrenShapesMapping { get; private set; }

        /// <summary>
        /// Diagram children shapes mapping dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> DiagramChildrenShapesMapping { get; private set; }

        /// <summary>
        /// Diagram rs children shapes mapping dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> DiagramRSChildren { get; private set; }

        /// <summary>
        /// Diagram mapping rs children shapes mapping dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> DiagramMappingRSChildren { get; private set; }

        /// <summary>
        /// Diagram root children shapes mapping dictionary.
        /// </summary>
        public Dictionary<Guid, List<Guid>> DiagramRootChildrenShapesMapping { get; private set; }

        /// <summary>
        /// Process and initialize the contained data.
        /// </summary>
        public void Process()
        {
            DiagramClassInfo[] diagramInfos = GetDiagramClassInfo();
            if (diagramInfos != null)
                foreach (DiagramClassInfo info in diagramInfos)
                {
                    DiagramChildrenShapesMapping.Add(info.DiagramClassType, new List<Guid>());
                    DiagramRootChildrenShapesMapping.Add(info.DiagramClassType, new List<Guid>());
                    DiagramRSChildren.Add(info.DiagramClassType, new List<Guid>());
                    DiagramMappingRSChildren.Add(info.DiagramClassType, new List<Guid>());

                    DiagramClassInfos.Add(info.DiagramClassType, info);
                }

            Guid[] classIds = GetClassesRelevantForSM();
            if (classIds != null)
                foreach (Guid id in classIds)
                    ClassShapesMapping.Add(id, new List<Guid>());

            ShapeClassInfo[] shapeInfos = GetShapeClassInfo();
            if (shapeInfos != null)
            {
                foreach (ShapeClassInfo info in shapeInfos)
                {
                    ShapeClassInfos.Add(info.ShapeClassType, info);
                    ClassShapesMapping[info.DomainClassType].Add(info.ShapeClassType);

                    if (info.UsedInDependencyView)
                        ClassShapesDependenciesMapping.Add(info.DomainClassType, info.ShapeClassType);

                    ParentChildrenShapesMapping.Add(info.ShapeClassType, new List<Guid>());
                    
                    DiagramChildrenShapesMapping[info.DiagramClassType].Add(info.ShapeClassType);
                    if( info.ParentShapeClassType == null )
                        DiagramRootChildrenShapesMapping[info.DiagramClassType].Add(info.ShapeClassType);
                }
                foreach (ShapeClassInfo info in shapeInfos)
                {
                    if (info.ParentShapeClassType != null)
                        ParentChildrenShapesMapping[info.ParentShapeClassType.Value].Add(info.ShapeClassType);
                }
            }

            RelationshipShapeInfo[] rsInfos = GetRelationshipShapeInfo();
            if( rsInfos != null )
                foreach (RelationshipShapeInfo info in rsInfos)
                {
                    RelationshipShapeInfos.Add(info.ShapeClassType, info);
                    ClassShapesMapping[info.DomainClassType].Add(info.ShapeClassType);

                    DiagramRSChildren[info.DiagramClassType].Add(info.ShapeClassType);
                }

            MappingRelationshipShapeInfo[] mrsInfos = GetMappingRelationshipShapeInfo();
            if (rsInfos != null)
                foreach (MappingRelationshipShapeInfo info in mrsInfos)
                {
                    MappingRelationshipShapeInfos.Add(info.ShapeClassType, info);
                    ClassShapesMapping[info.DomainClassType].Add(info.ShapeClassType);

                    DiagramMappingRSChildren[info.DiagramClassType].Add(info.ShapeClassType);
                }
        }

        /// <summary>
        /// Merges the current directory with an additional directory.
        /// </summary>
        /// <param name="data">Directory</param>
        public void Merge(IDomainDataExtensionDirectory data)
        {
            if( !(data is DiagramDomainDataDirectory) )
                throw new InvalidOperationException("Can not merge with " + data.ToString());

            DiagramDomainDataDirectory domainData = data as DiagramDomainDataDirectory;

            foreach (KeyValuePair<Guid,Guid> pair in domainData.ClassShapesDependenciesMapping)
                ClassShapesDependenciesMapping.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid,List<Guid>> pair in domainData.ParentChildrenShapesMapping)
                ParentChildrenShapesMapping.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid,List<Guid>> pair in domainData.DiagramChildrenShapesMapping)
                DiagramChildrenShapesMapping.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid,List<Guid>> pair in domainData.DiagramRootChildrenShapesMapping)
                DiagramRootChildrenShapesMapping.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid, List<Guid>> pair in domainData.DiagramRSChildren)
                DiagramRSChildren.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid, List<Guid>> pair in domainData.DiagramMappingRSChildren)
                DiagramMappingRSChildren.Add(pair.Key, pair.Value);

            // class shape mappings
            foreach (KeyValuePair<Guid, List<Guid>> pair in domainData.ClassShapesMapping)
                if (ClassShapesMapping.ContainsKey(pair.Key))
                    ClassShapesMapping[pair.Key].AddRange(pair.Value);
                else
                    ClassShapesMapping.Add(pair.Key, pair.Value);


            foreach (KeyValuePair<Guid, DiagramClassInfo> pair in domainData.DiagramClassInfos)
                DiagramClassInfos.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid, ShapeClassInfo> pair in domainData.ShapeClassInfos)
                ShapeClassInfos.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid, RelationshipShapeInfo> pair in domainData.RelationshipShapeInfos)
                RelationshipShapeInfos.Add(pair.Key, pair.Value);

            foreach (KeyValuePair<Guid, MappingRelationshipShapeInfo> pair in domainData.MappingRelationshipShapeInfos)
                MappingRelationshipShapeInfos.Add(pair.Key, pair.Value);

        }

        /// <summary>
        /// Gets the type of the extension.
        /// </summary>
        /// <returns>Type of the extension.</returns>
        public Type GetExtensionType()
        {
            return typeof(DiagramDomainDataDirectory);
        }

        /// <summary>
        /// Gets the shape class information.
        /// </summary>
        /// <returns>Shape class info.</returns>
        public abstract Guid[] GetClassesRelevantForSM();

        /// <summary>
        /// Gets the diagram class information.
        /// </summary>
        /// <returns>Diagram class info.</returns>
        public abstract DiagramClassInfo[] GetDiagramClassInfo();

        /// <summary>
        /// Gets the shape class information.
        /// </summary>
        /// <returns>Shape class info.</returns>
        public abstract ShapeClassInfo[] GetShapeClassInfo();

        /// <summary>
        /// Gets the rs shape class information.
        /// </summary>
        /// <returns>RSShape class info.</returns>
        public abstract RelationshipShapeInfo[] GetRelationshipShapeInfo();

        /// <summary>
        /// Gets the mapping rs shape class information.
        /// </summary>
        /// <returns>MappingRSShape class info.</returns>
        public abstract MappingRelationshipShapeInfo[] GetMappingRelationshipShapeInfo();

        /// <summary>
        /// Verifies if there is a shape for the given element type.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <returns>True if there is a shape for the specified element type. False otherwise.</returns>
        public virtual bool HasShapeForElement(Guid modelElementTypeId)
        {
            if (ClassShapesMapping.ContainsKey(modelElementTypeId))
                if (ClassShapesMapping[modelElementTypeId].Count > 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifies if there is a dependencies shape for the given element type.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <returns>True if there is a shape for the specified element type. False otherwise.</returns>
        public virtual bool HasDependenciesShapeForElement(Guid modelElementTypeId)
        {
            if (ClassShapesDependenciesMapping.ContainsKey(modelElementTypeId))
                return true;

            return false;
        }

        /// <summary>
        /// Gets children shape types for a specific shape.
        /// </summary>
        /// <param name="parentShapeTypeId">Parent shape type.</param>
        /// <returns>List of guid for shape types or null if none are present.</returns>
        public virtual List<Guid> GetChildrenShapeTypes(Guid parentShapeTypeId)
        {
            List<Guid> retAll = new List<Guid>();

            List<Guid> ret;
            this.ParentChildrenShapesMapping.TryGetValue(parentShapeTypeId, out ret);
            if (ret != null)
                retAll.AddRange(ret);

            // see if the parentShapeTypeId has a base shape.
            ShapeClassInfo info;
            this.ShapeClassInfos.TryGetValue(parentShapeTypeId, out info);
            if (info != null)
                if (info.BaseShape != null)
                    if (info.BaseShape.Value != Guid.Empty)
                        retAll.AddRange(GetChildrenShapeTypes(info.BaseShape.Value));

            return retAll;
        }

        /// <summary>
        /// Gets children shape types for a specific diagram.
        /// </summary>
        /// <param name="diagramTypeId">Diagram type.</param>
        /// <returns>List of guid for shape types or null if none are present.</returns>
        public virtual List<Guid> GetDiagramChildrenShapeTypes(Guid diagramTypeId)
        {
            System.Collections.Generic.List<System.Guid> ret;
            DiagramChildrenShapesMapping.TryGetValue(diagramTypeId, out ret);

            if (ret == null)
                return new List<Guid>();

            return ret;
        }

        /// <summary>
        /// Gets root children shape types for a specific diagram.
        /// </summary>
        /// <param name="diagramTypeId">Diagram type.</param>
        /// <returns>List of guid for shape types or null if none are present.</returns>
        public virtual List<Guid> GetDiagramRootChildrenShapeTypes(Guid diagramTypeId)
        {
            System.Collections.Generic.List<System.Guid> ret;
            DiagramRootChildrenShapesMapping.TryGetValue(diagramTypeId, out ret);

            if (ret == null)
                return new List<Guid>();

            return ret;
        }

        /// <summary>
        /// Gets shapes for element on.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <returns>List of guid for shape types.</returns>
        public virtual List<Guid> GetShapeTypesForElement(Guid modelElementTypeId)
        {
            System.Collections.Generic.List<System.Guid> ret;
            ClassShapesMapping.TryGetValue(modelElementTypeId, out ret);

            if (ret == null)
                return new List<Guid>();

            return ret;
        }

        /// <summary>
        /// Gets shapes for element on a specific diagram.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <param name="parentShapeTypeId">Parent shape type.</param>
        /// <returns>List of guid for shape types or null if none are present.</returns>
        public virtual List<Guid> GetShapeTypesForElement(Guid modelElementTypeId, Guid parentShapeTypeId)
        {
            List<Guid> ret = new List<Guid>();

            List<Guid> elementShapes = GetShapeTypesForElement(modelElementTypeId);
            if (elementShapes == null)
                return ret;
            if (elementShapes.Count == 0)
                return ret;

            List<Guid> childrenShapes = GetChildrenShapeTypes(parentShapeTypeId);
            if (childrenShapes == null)
                return ret;
            if (childrenShapes.Count == 0)
                return ret;

            foreach (Guid elementShape in elementShapes)
                foreach (Guid childrenShape in childrenShapes)
                    if (elementShape == childrenShape)
                    {
                        ret.Add(elementShape);
                        break;
                    }

            return ret;
        }

        /// <summary>
        /// Gets shapes for element on a specific diagram.
        /// </summary>
        /// <param name="modelElementTypeId">Model element type.</param>
        /// <returns>List of guid for shape types or null if none are present.</returns>
        public virtual List<Guid> GetRootShapeTypesForElement(Guid modelElementTypeId)
        {
            System.Collections.Generic.List<System.Guid> ret;
            ClassShapesMapping.TryGetValue(modelElementTypeId, out ret);

            if (ret == null)
                return new List<Guid>();

            List<Guid> retFiltered = new List<Guid>();
            foreach (Guid d in ret)
                foreach(List<Guid> col in DiagramRootChildrenShapesMapping.Values)
                    if (col.Contains(d))
                    {
                        retFiltered.Add(d);
                        break;
                    }
            return retFiltered;
        }
    }
}
