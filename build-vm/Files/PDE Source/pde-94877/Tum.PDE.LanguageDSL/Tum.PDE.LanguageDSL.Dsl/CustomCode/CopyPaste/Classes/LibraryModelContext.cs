using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.CopyPaste;

namespace Tum.PDE.LanguageDSL
{
    public partial class LibraryModelContext
    {
        public override bool ModelCanMerge(CopyPaste.ModelProtoElement protoElement, CopyPaste.ModelProtoGroup protoGroup)
        {
            if (protoElement != null)
			{
				DomainClassInfo elementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(protoElement.DomainClassId);
				if (elementDomainInfo.IsDerivedFrom(global::Tum.PDE.LanguageDSL.DomainClass.DomainClassId)) 
				{
					if( protoGroup.Operation == ModelProtoGroupOperation.Move )
					{
						foreach (global::Tum.PDE.LanguageDSL.LibraryModelContextHasClasses link in DomainRoleInfo.GetElementLinks<global::Tum.PDE.LanguageDSL.LibraryModelContextHasClasses>(this, global::Tum.PDE.LanguageDSL.LibraryModelContextHasClasses.LibraryModelContextDomainRoleId))				
							if( link.DomainClass.Id == protoElement.ElementId )
								return false;
					}
					return true;
				}
                else if (elementDomainInfo.IsDerivedFrom(global::Tum.PDE.LanguageDSL.DomainRelationship.DomainClassId))
                {
                    if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                    {
                        foreach (global::Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships link in DomainRoleInfo.GetElementLinks<global::Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships>(this, global::Tum.PDE.LanguageDSL.LibraryModelContextHasRelationships.LibraryModelContextDomainRoleId))
                            if (link.DomainRelationship.Id == protoElement.ElementId)
                                return false;
                    }

                    // see if source and target domain classes are copied here
                    List<ModelProtoElement> elements = protoGroup.GetEmbeddedElements(this.Partition, protoElement);
                    for (int i = 0; i < elements.Count; i++)
                    {
                        if (elements[i].Name == "DomainRole")
                        {
                            List<ModelProtoLink> links = protoGroup.GetReferenceLinks(this.Partition, elements[i]);
                            foreach (ModelProtoLink link in links)

                                if (link.Name == "DomainRoleReferencesRolePlayer")
                                {
                                    ModelProtoRolePlayer rP = link.GetTargetRolePlayer(this.Partition);
                                    // see if the target element is beeing copied or is already in the model
                                    if (!protoGroup.HasProtoElementFor(rP.RolePlayerId, this.Partition))
                                    {
                                        ModelElement m = this.Store.ElementDirectory.FindElement(rP.RolePlayerId);
                                        if (m == null)
                                        {
                                            if (!this.MetaModel.HasElement(rP.ElementName))
                                                return false;
                                        }
                                    }
                                }
                        }
                    }

                    return true;
                }
			}
            return false;
        }
        public override void ModelFinalizeMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            base.ModelFinalizeMerge(protoElement, groupMerger);

            if (protoElement.Name == "DomainClass")
                FinalizeDomainClassMerge(protoElement, groupMerger);
        }

        private void FinalizeDomainClassMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            DomainClass domainClass = this.Store.ElementDirectory.FindElement(groupMerger.GetIdMapping(protoElement.ElementId)) as DomainClass;
            if (domainClass == null)
                return;

            if (protoElement.CustomArguments != null)
                if (protoElement.CustomArguments is DomainClassSerializationInfo)
                {
                    DomainClassSerializationInfo info = (DomainClassSerializationInfo)protoElement.CustomArguments;
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
                            for (int y = 0; y < domainClass.SerializedDomainClass.Attributes.Count; y++)
                            {
                                if (domainClass.SerializedDomainClass.Attributes[y] is SerializedIdProperty && eInfo.ElementName == "SerializedIdProperty")
                                {
                                    (domainClass.SerializedDomainClass.Attributes[y] as SerializedIdProperty).OmitIdProperty = eInfo.OmitElement;
                                    if (y != i)
                                        domainClass.SerializedDomainClass.Attributes.Move(y, i);
                                    break;
                                }
                                else if (eInfo.ElementName != "SerializedIdProperty" && !(domainClass.SerializedDomainClass.Attributes[y] is SerializedIdProperty))
                                {
                                    SerializedDomainProperty p = domainClass.SerializedDomainClass.Attributes[y] as SerializedDomainProperty;
                                    p.OmitProperty = eInfo.OmitElement;
                                    if (p.DomainProperty.Id == newId && y != i)
                                    {
                                        domainClass.SerializedDomainClass.Attributes.Move(y, i);
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

                            for (int y = i; y < domainClass.SerializedDomainClass.Children.Count; y++)
                            {
                                if (domainClass.SerializedDomainClass.Children[y] is SerializedReferenceRelationship)
                                {
                                    SerializedReferenceRelationship sDomainRel = domainClass.SerializedDomainClass.Children[y] as SerializedReferenceRelationship;
                                    if (sDomainRel.ReferenceRelationship.Id == newId)
                                    {
                                        sDomainRel.OmitRelationship = eInfo.OmitElement;

                                        if (y != i)
                                            domainClass.SerializedDomainClass.Children.Move(y, i);
                                        break;
                                    }
                                }
                                else if (domainClass.SerializedDomainClass.Children[y] is SerializedEmbeddingRelationship)
                                {
                                    SerializedEmbeddingRelationship sDomainRel = domainClass.SerializedDomainClass.Children[y] as SerializedEmbeddingRelationship;
                                    if (sDomainRel.EmbeddingRelationship.Id == newId)
                                    {
                                        sDomainRel.OmitRelationship = eInfo.OmitElement;

                                        if (y != i)
                                            domainClass.SerializedDomainClass.Children.Move(y, i);
                                        break;
                                    }
                                }
                                else if (domainClass.SerializedDomainClass.Children[y] is SerializedDomainProperty)
                                {
                                    SerializedDomainProperty p = domainClass.SerializedDomainClass.Children[y] as SerializedDomainProperty;
                                    if (p.DomainProperty.Id == newId)
                                    {
                                        p.OmitProperty = eInfo.OmitElement;

                                        if( y != i )
                                            domainClass.SerializedDomainClass.Children.Move(y, i);
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
        }

    }
}
