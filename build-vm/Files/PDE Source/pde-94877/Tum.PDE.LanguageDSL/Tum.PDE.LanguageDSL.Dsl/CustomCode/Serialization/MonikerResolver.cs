using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL
{
    public partial class TestDslDefinitionSerializationBehaviorMonikerResolver
    {
        private Dictionary<string, ModelElement> typeLookup = new Dictionary<string, ModelElement>();
        private Dictionary<string, ModelElement> propertyGridEditorTypeLookup = new Dictionary<string, ModelElement>();

        protected override void DeserializationComplete()
        {
            this.typeLookup.Clear();
            this.propertyGridEditorTypeLookup.Clear();

            base.DeserializationComplete();
        }
        public override bool ProcessAddedElement(ModelElement mel)
        {
            if (mel is ExternalType || mel is DomainEnumeration)
            {
                string s = CalculateQualifiedName(mel);
                if (typeLookup.ContainsKey(s))
                    return false;
                typeLookup.Add(s, null);
            }

            if (mel is PropertyGridEditor)
            {
                string s = CalculateQualifiedName(mel);
                if (propertyGridEditorTypeLookup.ContainsKey(s))
                    return false;
                propertyGridEditorTypeLookup.Add(s, null);
            }

            return base.ProcessAddedElement(mel);
        }
        protected override void OnUnresolvedMoniker(SerializationResult serializationResult, Moniker moniker)
        {
            /*
            if (moniker.Link is SerializationClassReferencesChildren ||
                moniker.Link is SerializationClassReferencesAttributes ||
                moniker.Link is DomainClassReferencesBaseClass ||
                moniker.Link is DomainRelationshipReferencesBaseRelationship ||
                moniker.Link is TreeNodeReferencesInheritanceNodes ||
                moniker.Link is TreeNodeReferencesEmbeddingRSNodes ||
                moniker.Link is TreeNodeReferencesReferenceRSNodes ||
                moniker.Link is TreeNodeReferencesShapeClassNodes)
            {*/
            if( moniker.Link != null )
            {
                // TODO
                string name = moniker.Link.ToString() + " - " + moniker.MonikerName;
                moniker.DeleteLink();

                SerializationUtilities.AddMessage(serializationResult, moniker.Location,
                    SerializationMessageKind.Warning, "Moniker could not be resolved; The link was deleted from the model. " + name,
                        moniker.Line, moniker.Column);
            }
            else
                base.OnUnresolvedMoniker(serializationResult, moniker);
        }
        public override ModelElement ResolveMoniker(Moniker moniker)
        {
            Microsoft.VisualStudio.Modeling.ModelElement modelElement;

            #region PropertyGridEditor
            if (moniker.DomainRelationshipInfo.Id == DomainTypeReferencesPropertyGridEditor.DomainClassId)
            {
                propertyGridEditorTypeLookup.TryGetValue(moniker.MonikerName, out modelElement);
                if (modelElement == null)
                {
                    string[] name = moniker.MonikerName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    if (name.Length > 1)
                    {
                        string modelName = name[0];
                        string editorName = name[1];

                        MetaModel model = FindMetaModel(moniker.Store, modelName);
                        if (model != null)
                        {
                            foreach (PropertyGridEditor editor in model.PropertyGridEditors)
                                if (editor.Name == editorName)
                                {
                                    modelElement = editor;
                                    propertyGridEditorTypeLookup[moniker.MonikerName] = editor;
                                    break;
                                }
                        }
                    }

                    return modelElement;
                }
                else 
                    return modelElement;
                
            }
            #endregion

            #region DomainEnumeration and ExternalType
            if (moniker.DomainRelationshipInfo.Id == DomainPropertyReferencesType.DomainClassId)
            {
                typeLookup.TryGetValue(moniker.MonikerName, out modelElement);
                if (modelElement == null)
                {
                    string[] name = moniker.MonikerName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    if (name.Length > 2)
                    {
                        string modelName = name[0];
                        string namespaceStr = name[1];
                        string editorName = name[2];

                        MetaModel model = FindMetaModel(moniker.Store, modelName);
                        if (model != null)
                        {
                            foreach (DomainType t in model.DomainTypes)
                                if (t.Name == editorName && t.Namespace == namespaceStr)
                                {
                                    modelElement = t;
                                    typeLookup[moniker.MonikerName] = t;
                                    break;
                                }
                        }
                    }

                    return modelElement;
                }
                else
                    return modelElement;


            }
            #endregion

            ModelElement m = base.ResolveMoniker(moniker);
            if (m == null)
            {
                try
                {
                    Guid guid = new Guid(moniker.MonikerName);
                    m = moniker.Store.ElementDirectory.FindElement(guid);
                }
                catch { }

            }
            if (m == null)
            {

            }
            return m;
        }

        private MetaModel FindMetaModel(Store store, string modelName)
        {
            ReadOnlyCollection<ModelElement> elements = store.ElementDirectory.FindElements(MetaModel.DomainClassId);
            foreach (ModelElement m in elements)
                if (m is MetaModel)
                    if ((m as MetaModel).Name == modelName)
                        return m as MetaModel;

            return null;
        }
    }
}
