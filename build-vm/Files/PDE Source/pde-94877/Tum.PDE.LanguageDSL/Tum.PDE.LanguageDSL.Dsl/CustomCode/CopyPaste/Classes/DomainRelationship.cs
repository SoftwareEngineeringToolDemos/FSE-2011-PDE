using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.CopyPaste;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainRelationship
    {
        public override void ModelProcessMergeCopy(ModelProtoElement protoElement, ModelProtoGroup protoGroup)
        {
            base.ModelProcessMergeCopy(protoElement, protoGroup);

            bool isInFull = false;
            bool isTargetInc = false;
            SerializationClass sClass;
            if (this is ReferenceRelationship)
            {
                sClass = (this as ReferenceRelationship).SerializedReferenceRelationship;
                isInFull = (this as ReferenceRelationship).SerializedReferenceRelationship.IsInFullSerialization;
            }
            else
            {
                sClass = (this as EmbeddingRelationship).SerializedEmbeddingRelationship;
                isInFull = (this as EmbeddingRelationship).SerializedEmbeddingRelationship.IsInFullSerialization;
                isTargetInc = (this as EmbeddingRelationship).SerializedEmbeddingRelationship.IsTargetIncludedSubmodel;
            }

            // copy order of attributes and children
            DomainRelationshipSerializationInfo info = new DomainRelationshipSerializationInfo(
                sClass.Children.Count,
                sClass.Attributes.Count);
            info.IsInFullSerialization = isInFull;
            info.IsTargetIncludedSubmodel = isTargetInc;

            for (int i = 0; i < sClass.Attributes.Count; i++)
            {
                SerializationAttributeElement aatr = sClass.Attributes[i];
                if (aatr is SerializedDomainProperty)
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

            for (int i = 0; i < sClass.Children.Count; i++)
            {
                SerializationElement sE = sClass.Children[i];
                if (sE is SerializedDomainProperty)
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
        public override void ModelFinalize(CopyPaste.ModelProtoElement protoElement, CopyPaste.ModelProtoGroupMerger groupMerger)
        {
            base.ModelFinalize(protoElement, groupMerger);

            if (protoElement.Name == "ReferenceRelationship")
                FinalizeReferenceRelationshipMerge(protoElement, groupMerger, true);
            else if (protoElement.Name == "EmbeddingRelationship")
                FinalizeEmbeddingRelationshipsMerge(protoElement, groupMerger, true);

            FinalizeRelationshipMerge(protoElement, groupMerger);
        }

        private void FinalizeRelationshipMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            SerializationClass sClass;
            if (this is ReferenceRelationship)
            {
                sClass = (this as ReferenceRelationship).SerializedReferenceRelationship;
            }
            else
            {
                sClass = (this as EmbeddingRelationship).SerializedEmbeddingRelationship;
            }

            if (protoElement.CustomArguments != null)
                if (protoElement.CustomArguments is DomainRelationshipSerializationInfo)
                {
                    DomainRelationshipSerializationInfo info = (DomainRelationshipSerializationInfo)protoElement.CustomArguments;
                    if (this is ReferenceRelationship)
                    {
                        (this as ReferenceRelationship).SerializedReferenceRelationship.IsInFullSerialization = info.IsInFullSerialization;
                    }
                    else
                    {
                        (this as EmbeddingRelationship).SerializedEmbeddingRelationship.IsInFullSerialization = info.IsInFullSerialization;
                        (this as EmbeddingRelationship).SerializedEmbeddingRelationship.IsTargetIncludedSubmodel = info.IsTargetIncludedSubmodel;
                    }   
                    if (info != null)
                    {
                        for (int i = 0; i < info.AttributesOrder.Count; i++)
                        {
                            #region Attributes
                            ElementSerializationInfo eInfo = info.AttributesOrder[i] as ElementSerializationInfo;
                            Guid newId = Guid.Empty;
                            if (eInfo.ElementName != "SerializedIdProperty")
                            {
                                try
                                {
                                    newId = groupMerger.GetIdMapping(eInfo.ElementId);
                                }
                                catch
                                {
                                    newId = Guid.Empty;
                                }

                                if (newId == Guid.Empty)
                                {
                                    ModelElement m = this.Store.ElementDirectory.FindElement(eInfo.ElementId);
                                    if (m != null)
                                        newId = m.Id;
                                }
                            }
                            for (int y = 0; y < sClass.Attributes.Count; y++)
                            {
                                if (sClass.Attributes[y] is SerializedIdProperty && eInfo.ElementName == "SerializedIdProperty")
                                {
                                    (sClass.Attributes[y] as SerializedIdProperty).OmitIdProperty = eInfo.OmitElement;
                                    if (y != i)
                                        sClass.Attributes.Move(y, i);
                                    break;
                                }
                                else if (eInfo.ElementName != "SerializedIdProperty" && !(sClass.Attributes[y] is SerializedIdProperty))
                                {
                                    SerializedDomainProperty p = sClass.Attributes[y] as SerializedDomainProperty;
                                    p.OmitProperty = eInfo.OmitElement;
                                    if (p.DomainProperty.Id == newId && y != i)
                                    {
                                        sClass.Attributes.Move(y, i);
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }

                        for (int i = 0; i < info.ChildrenOrder.Count; i++)
                        {
                            #region Children
                            ElementSerializationInfo eInfo = info.ChildrenOrder[i] as ElementSerializationInfo;
                            Guid newId = Guid.Empty;

                            try
                            {
                                newId = groupMerger.GetIdMapping(eInfo.ElementId);
                            }
                            catch
                            {
                                newId = Guid.Empty;
                            }

                            if (newId == Guid.Empty)
                            {
                                ModelElement m = this.Store.ElementDirectory.FindElement(eInfo.ElementId);
                                if (m != null)
                                    newId = m.Id;
                            }

                            for (int y = i; y < sClass.Children.Count; y++)
                            {
                                if (sClass.Children[y] is SerializedDomainProperty)
                                {
                                    SerializedDomainProperty p = sClass.Children[y] as SerializedDomainProperty;
                                    if (p.DomainProperty.Id == newId)
                                    {
                                        p.OmitProperty = eInfo.OmitElement;

                                        if (y != i)
                                            sClass.Children.Move(y, i);
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
        }
        private void FinalizeReferenceRelationshipMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger, bool bCreateSInfo)
        {
            ReferenceRelationship refRel = this.Store.ElementDirectory.FindElement(groupMerger.GetIdMapping(protoElement.ElementId)) as ReferenceRelationship;
            if (bCreateSInfo)
                SerializationDomainRelationshipAddRule.OnReferenceRelationshipAdded(refRel);
            if (refRel == null)
                return;

            ModelTreeHelper.AddNewReferenceRelationship(refRel, refRel.Source.RolePlayer as DomainClass, refRel.Target.RolePlayer);
        }
        private void FinalizeEmbeddingRelationshipsMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger, bool bCreateSInfo)
        {
            EmbeddingRelationship embRel = this.Store.ElementDirectory.FindElement(groupMerger.GetIdMapping(protoElement.ElementId)) as EmbeddingRelationship;
            if (bCreateSInfo)
                SerializationDomainRelationshipAddRule.OnEmbeddingRelationshipAdded(embRel);
            if (embRel == null)
                return;

            ModelTreeHelper.AddNewEmbeddingRS(embRel, embRel.Source.RolePlayer as DomainClass, embRel.Target.RolePlayer, false);
        }
    }

    [System.Serializable]
    public class DomainRelationshipSerializationInfo : CopyPaste.IModelMergeCustomArguments
    {
        private System.Collections.ArrayList childrenOrder;
        private System.Collections.ArrayList attributesOrder;

        public bool IsInFullSerialization
        {
            get;
            set;
        }

        public bool IsTargetIncludedSubmodel
        {
            get;
            set;
        }

        public DomainRelationshipSerializationInfo(int countChildren, int countAttributes)
        {
            this.childrenOrder = new System.Collections.ArrayList(countChildren);
            this.attributesOrder = new System.Collections.ArrayList(countAttributes);
            this.IsInFullSerialization = false;
            this.IsTargetIncludedSubmodel = false;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("childrenOrder", childrenOrder, typeof(System.Collections.ArrayList));
            info.AddValue("attributesOrder", attributesOrder, typeof(System.Collections.ArrayList));
            info.AddValue("isInFullSerialization", this.IsInFullSerialization, typeof(bool));
            info.AddValue("isTargetIncludedSubmodel", this.IsTargetIncludedSubmodel, typeof(bool));
        }
        protected DomainRelationshipSerializationInfo(System.Runtime.Serialization.SerializationInfo info, StreamingContext context)
        {
            childrenOrder = (System.Collections.ArrayList)info.GetValue("childrenOrder", typeof(System.Collections.ArrayList));
            attributesOrder = (System.Collections.ArrayList)info.GetValue("attributesOrder", typeof(System.Collections.ArrayList));
            this.IsInFullSerialization = (bool)info.GetValue("isInFullSerialization", typeof(bool));
            this.IsTargetIncludedSubmodel = (bool)info.GetValue("isTargetIncludedSubmodel", typeof(bool));
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
}
