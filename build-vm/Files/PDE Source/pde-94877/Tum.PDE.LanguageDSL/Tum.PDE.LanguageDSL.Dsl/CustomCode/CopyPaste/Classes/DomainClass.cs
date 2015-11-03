using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.CopyPaste;
using Microsoft.VisualStudio.Modeling.Immutability;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainClass
    {
        public override bool ModelIsMoveAllowed()
        {
            if (this.IsDomainModel)
                return false;

            return true;
        }
        public override void ModelFinalize(CopyPaste.ModelProtoElement protoElement, CopyPaste.ModelProtoGroupMerger groupMerger)
        {
            base.ModelFinalize(protoElement, groupMerger);

            DomainClass domainClass = this.Store.ElementDirectory.FindElement(groupMerger.GetIdMapping(protoElement.ElementId)) as DomainClass;
            if (domainClass == null)
                return;

            if (domainClass.IsDomainModel)
                domainClass.IsDomainModel = false;

            if (domainClass.BaseClass != null)
            {
                ReadOnlyCollection<DomainClassReferencesBaseClass> col = DomainRoleInfo.GetElementLinks<DomainClassReferencesBaseClass>(domainClass, DomainClassReferencesBaseClass.DerivedClassDomainRoleId);
                if (col.Count != 1)
                {
                    throw new ArgumentNullException("Domain class can only reference one base class");
                }

                DomainClassReferencesBaseClass r = col[0];
                r.InhNodeId = Guid.Empty;     // otherwise node id of the source element would be used
            }

            if (domainClass.DomainModelTreeNodes.Count == 0)
            {
                RootNode node = new RootNode(domainClass.Store);
                node.DomainElement = domainClass;
                node.IsElementHolder = true;

                // add to the domain model diagram tree
                domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(node);
                domainClass.ModelContext.ViewContext.DomainModelTreeView.RootNodes.Add(node);
            }

            SerializationDomainClassAddRule.OnDomainClassAdded(domainClass);
            SerializationHelper.UpdateDerivedElementsSerializationProperties(domainClass);
        }
        public override void ModelProcessMergeCopy(CopyPaste.ModelProtoElement protoElement, CopyPaste.ModelProtoGroup protoGroup)
        {
            base.ModelProcessMergeCopy(protoElement, protoGroup);

            // copy rs and target elements if required
            if (CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyEmbeddingTree || 
                CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyAllTree ||
                CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyReferenceTree)
            {
                foreach (DomainRole role in this.RolesPlayed)
                {
                    if (role.Relationship is EmbeddingRelationship && role.Relationship.Source == role)
                    {
                        if (CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyEmbeddingTree ||
                            CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyAllTree)
                        {
                            ModelProtoElement e = (role.Relationship as IModelMergeElements).ModelCreateMergeCopy(protoGroup);
                            protoGroup.AddNewRootElement(e);

                            // continue with target element
                            if (ImmutabilityExtensionMethods.GetLocks(role.Relationship.Target.RolePlayer) == Locks.None)
                            {
                                if (!protoGroup.HasProtoElementFor(role.Relationship.Target.RolePlayer.Id, this.Partition))
                                {
                                    ModelProtoElement d = (role.Relationship.Target.RolePlayer as IModelMergeElements).ModelCreateMergeCopy(protoGroup);
                                    protoGroup.InsertNewRootElement(d, 0);
                                }
                            }
                        }
                    }
                    else if (role.Relationship is ReferenceRelationship && role.Relationship.Source == role)
                    {
                        if (CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyAllTree ||
                            CopyPaste.CopyAndPasteOperations.Operation == CopyPaste.CopyAndPasteOperation.CopyReferenceTree)
                        {
                            ModelProtoElement e = (role.Relationship as IModelMergeElements).ModelCreateMergeCopy(protoGroup);
                            protoGroup.AddNewRootElement(e);
                        }
                    }
                }

                // sort proto elements: bring domain classes to the top
                protoGroup.SortProtoElements(SortProtoElements);
            }
            
            // copy order of attributes and children
            DomainClassSerializationInfo info = new DomainClassSerializationInfo(
                this.SerializedDomainClass.Children.Count,
                this.SerializedDomainClass.Attributes.Count);

            for (int i = 0; i < this.SerializedDomainClass.Attributes.Count; i++)
            {
                SerializationAttributeElement aatr = this.SerializedDomainClass.Attributes[i];
                if( aatr is SerializedDomainProperty )
                {
                    SerializedDomainProperty sP = aatr as SerializedDomainProperty;
                    ElementSerializationInfo sInfo = new ElementSerializationInfo(
                        sP.DomainProperty.Name, sP.DomainProperty.Id);
                    if (sP.OmitProperty)
                        sInfo.OmitElement = true;

                    info.AttributesOrder.Add(sInfo); 
                }
                else if (aatr is SerializedIdProperty)
                {
                    SerializedIdProperty sI = aatr as SerializedIdProperty;
                    ElementSerializationInfo sInfo = new ElementSerializationInfo("SerializedIdProperty", Guid.Empty);
                    if (sI.OmitIdProperty)
                        sInfo.OmitElement = true;

                    info.AttributesOrder.Add(sInfo);
                }
            }

            for (int i = 0; i < this.SerializedDomainClass.Children.Count; i++)
            {
                SerializationElement sE = this.SerializedDomainClass.Children[i];
                if (sE is SerializedReferenceRelationship)
                {
                    SerializedReferenceRelationship sDomainRel = sE as SerializedReferenceRelationship;
                    ElementSerializationInfo sInfo = new ElementSerializationInfo(
                        sDomainRel.ReferenceRelationship.Name, sDomainRel.ReferenceRelationship.Id);
                    if (sDomainRel.OmitRelationship)
                        sInfo.OmitElement = true;

                    info.ChildrenOrder.Add(sInfo);
                }
                else if (sE is SerializedEmbeddingRelationship)
                {
                    SerializedEmbeddingRelationship sDomainRel = sE as SerializedEmbeddingRelationship;
                    ElementSerializationInfo sInfo = new ElementSerializationInfo(
                        sDomainRel.EmbeddingRelationship.Name, sDomainRel.EmbeddingRelationship.Id);
                    if (sDomainRel.OmitRelationship)
                        sInfo.OmitElement = true;

                    info.ChildrenOrder.Add(sInfo);
                }
                else if (sE is SerializedDomainProperty)
                {
                    SerializedDomainProperty sP = sE as SerializedDomainProperty;
                    ElementSerializationInfo sInfo = new ElementSerializationInfo(
                        sP.DomainProperty.Name, sP.DomainProperty.Id);
                    if (sP.OmitProperty)
                        sInfo.OmitElement = true;

                    info.ChildrenOrder.Add(sInfo);
                }
            }

            protoElement.CustomArguments = info;
        }

        private static int SortProtoElements(ModelProtoElement x, ModelProtoElement y)
        {
            if (x.Name == "DomainClass" && y.Name != "DomainClass")
                return -1;
            else if (x.Name != "DomainClass" && y.Name == "DomainClass")
                return 1;

            return 0;
        }
    }

    [System.Serializable]
    public class DomainClassSerializationInfo : CopyPaste.IModelMergeCustomArguments
    {
        private System.Collections.ArrayList childrenOrder;
        private System.Collections.ArrayList attributesOrder;

        public DomainClassSerializationInfo(int countChildren, int countAttributes)
        {
            this.childrenOrder = new System.Collections.ArrayList(countChildren);
            this.attributesOrder = new System.Collections.ArrayList(countAttributes);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("childrenOrder", childrenOrder, typeof(System.Collections.ArrayList));
            info.AddValue("attributesOrder", attributesOrder, typeof(System.Collections.ArrayList));
        }
        protected DomainClassSerializationInfo(System.Runtime.Serialization.SerializationInfo info, StreamingContext context)
        {
            childrenOrder = (System.Collections.ArrayList)info.GetValue("childrenOrder", typeof(System.Collections.ArrayList));
            attributesOrder = (System.Collections.ArrayList)info.GetValue("attributesOrder", typeof(System.Collections.ArrayList));
        }

        public System.Collections.ArrayList ChildrenOrder
        {
            get
            {
                return this.childrenOrder;
            }
        }
        public System.Collections.ArrayList AttributesOrder
        {
            get
            {
                return this.attributesOrder;
            }
        }

        Type CopyPaste.IModelMergeCustomArguments.GetSerializerType()
        {
            return typeof(DomainClassSerializationInfo);
        }
    }

    [System.Serializable]
    public class ElementSerializationInfo : ISerializable
    {
        private readonly System.Guid elementId;
        private string elementName;

        public bool OmitElement
        {
            get;
            set;
        }

        public ElementSerializationInfo(string name, Guid elementId)
        {
            this.elementName = name;
            this.elementId = elementId;
            this.OmitElement = false;
        }

        public string ElementName
        {
            get
            {
                return this.elementName;
            }
        }

        public Guid ElementId
        {
            get
            {
                return this.elementId;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">The SerializationInfo to get the data from.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        protected ElementSerializationInfo(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            elementId = (System.Guid)info.GetValue("elementId", typeof(Guid));
            elementName = (string)info.GetValue("elementName", typeof(string));
            this.OmitElement = (bool)info.GetValue("omitElement", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("elementId", elementId, typeof(Guid));
            info.AddValue("elementName", elementName, typeof(string));
            info.AddValue("omitElement", this.OmitElement, typeof(bool));
        }
    }
}
