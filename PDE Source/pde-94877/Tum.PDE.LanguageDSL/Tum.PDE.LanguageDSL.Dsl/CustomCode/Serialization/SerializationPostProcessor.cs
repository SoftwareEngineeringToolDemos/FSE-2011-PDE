using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public static class SerializationPostProcessor
    {
        public static void PostProcessModelLoad(MetaModel model)
        {
            // package and custom editor GUIDs
            if (model.PackageGuid == null || model.PackageGuid == Guid.Empty)
            {
                model.PackageGuid = Guid.NewGuid();
            }
            if (model.CustomExtensionGuid == null || model.CustomExtensionGuid == Guid.Empty)
            {
                model.CustomExtensionGuid = Guid.NewGuid();
            }
            

            #region relationship targets fixup
            ReadOnlyCollection<DomainRelationship> rels = model.AllRelationships;
            foreach (DomainRelationship rel in rels)
            {
                if (rel.Target.RolePlayer == null)
                {
                    ReferenceRelationship referenceRelationship = rel as ReferenceRelationship;
                    if (referenceRelationship != null)
                    {
                        if (referenceRelationship.ReferenceRSNode != null)
                            referenceRelationship.ReferenceRSNode.Delete();

                        if (referenceRelationship.SerializedReferenceRelationship != null)
                            referenceRelationship.SerializedReferenceRelationship.Delete();
                    }

                    EmbeddingRelationship embeddingRelationship = rel as EmbeddingRelationship;
                    if (embeddingRelationship != null)
                    {
                        if (embeddingRelationship.EmbeddingRSNode != null)
                            embeddingRelationship.EmbeddingRSNode.Delete();

                        if (embeddingRelationship.SerializedEmbeddingRelationship != null)
                            embeddingRelationship.SerializedEmbeddingRelationship.Delete();
                    }

                    rel.Delete();
                }
            }
            #endregion

            #region inconsistent serialization elements
            foreach (BaseModelContext context in model.ModelContexts)
                if (context is LibraryModelContext)
                {
                    LibraryModelContext lib = context as LibraryModelContext;
                    if (lib.SerializationModel != null)
                        for (int i = lib.SerializationModel.Children.Count - 1; i >= 0; i--)
                        {
                            SerializationClass c = lib.SerializationModel.Children[i];
                            if (c is SerializedDomainClass)
                            {
                                SerializedDomainClass s = c as SerializedDomainClass;
                                if (s.DomainClass == null)
                                {
                                    s.Delete();
                                }

                                continue;
                            }
                            else if (c is SerializedEmbeddingRelationship)
                            {
                                SerializedEmbeddingRelationship s = c as SerializedEmbeddingRelationship;
                                if (s.EmbeddingRelationship == null)
                                {
                                    s.Delete();
                                }

                                continue;
                            }
                            else if (c is SerializedReferenceRelationship)
                            {
                                SerializedReferenceRelationship s = c as SerializedReferenceRelationship;
                                if (s.ReferenceRelationship == null)
                                {
                                    s.Delete();
                                }

                                continue;
                            }

                            // element has not been deleted, see if its properties are ok
                            for (int y = c.Properties.Count - 1; y >= 0; y--)
                                if (c.Properties[y] == null)
                                {
                                    c.Properties[y].Delete();
                                }

                        }
                }
            #endregion

            #region derived classes serialization items fixup
            if (model.MetaModelLibraries.Count > 0)
            {
                ReadOnlyCollection<ModelElement> elements = model.Store.ElementDirectory.FindElements(DomainClassReferencesBaseClass.DomainClassId);
                foreach (ModelElement m in elements)
                {
                    DomainClassReferencesBaseClass con = m as DomainClassReferencesBaseClass;
                    if (con != null)
                        if (con.BaseClass != null)
                        {
                            if (con.BaseClass.ModelContext.MetaModel != model)
                            {
                                foreach (DomainClass derivedClass in con.BaseClass.DerivedClasses)
                                    FixUpDerivedClasses(derivedClass, model);
                            }
                        }
                }

                ReadOnlyCollection<ModelElement> elementsCon = model.Store.ElementDirectory.FindElements(DomainRelationshipReferencesBaseRelationship.DomainClassId);
                foreach (ModelElement m in elementsCon)
                {
                    DomainRelationshipReferencesBaseRelationship con = m as DomainRelationshipReferencesBaseRelationship;
                    if (con != null)
                        if (con.BaseRelationship != null)
                        {
                            if (con.BaseRelationship.ModelContext.MetaModel != model)
                            {
                                foreach (DomainRelationship derivedClass in con.BaseRelationship.DerivedRelationships)
                                    FixUpDerivedRelationships(derivedClass, model);
                            }
                        }
                }


            }
            #endregion

            #region check if model contains all required elements
            // property grid editors
            if (model.PropertyGridEditors.Count == 0)
                FixUpPropertyGridEditors(model);

            // domain types
            if (model.DomainTypes.Count == 0)
                FixUpDomainTypes(model);

            // model context
            if (model.ModelContexts.Count == 0)
                FixUpModelContext(model);

            // validation
            if (model.Validation == null)
                model.Validation = new Validation(model.Store);

            if (model.View == null)
                model.View = new View(model.Store);

            if (model.View.ModelTree == null)
                model.View.ModelTree = new ModelTree(model.Store);

            foreach (BaseModelContext mContext in model.ModelContexts)
                if (mContext is LibraryModelContext)
                {
                    LibraryModelContext m = mContext as LibraryModelContext;
                    if (m.DiagramClasses.Count == 0 && m is ModelContext)
                    {
                        DesignerDiagramClass ddC = new DesignerDiagramClass(model.Store);
                        ddC.Name = "DesignerDiagram";
                        ddC.Title = "Designer";

                        m.DiagramClasses.Add(ddC);
                    }

                    if (m.ViewContext == null)
                    {
                        m.ViewContext = new ViewContext(model.Store);
                        m.ViewContext.DomainModelTreeView = new DomainModelTreeView(model.Store);
                        m.ViewContext.DiagramView = new DiagramView(model.Store);

                        model.View.ViewContexts.Add(m.ViewContext);

                        FixUpDomainModelTreeView(m);
                        FixUpDiagramView(m);
                    }

                    if (m.ViewContext.DiagramView == null || m.ViewContext.DomainModelTreeView == null)
                    {
                        if (m.ViewContext.DomainModelTreeView == null)
                        {
                            m.ViewContext.DomainModelTreeView = new DomainModelTreeView(model.Store);
                            FixUpDomainModelTreeView(m);
                        }

                        if (m.ViewContext.DiagramView == null)
                        {
                            m.ViewContext.DiagramView = new DiagramView(model.Store);
                            FixUpDiagramView(m);
                        }
                    }

                    // diagram class view for designer diagram
                    if (m.ViewContext.DiagramView.DiagramClassViews.Count == 0 && m is ModelContext)
                    {
                        DiagramClassView vm = new DiagramClassView(model.Store);
                        vm.IsExpanded = true;
                        foreach (DiagramClass d in m.DiagramClasses)
                            if (d is DesignerDiagramClass)
                            {
                                vm.DiagramClass = d;
                                break;
                            }

                        m.ViewContext.DiagramView.DiagramClassViews.Add(vm);
                    }

                    // serialization
                    if (m.SerializationModel == null)
                        m.SerializationModel = new SerializationModel(model.Store);

                    // serialized domain model
                    if (m is ModelContext)
                        if (m.SerializationModel.SerializedDomainModel == null)
                            FixUpSerializedDomainModel(m as ModelContext);
                }
            #endregion
            
            // view ids.
            if (model.View != null)
            {
                if (model.View.ModelTreeId == null || model.View.ModelTreeId == Guid.Empty)
                    model.View.ModelTreeId = Guid.NewGuid();

                if (model.View.DependenciesViewId == null || model.View.DependenciesViewId == Guid.Empty)
                    model.View.DependenciesViewId = Guid.NewGuid();

                if (model.View.ErrorListId == null || model.View.ErrorListId == Guid.Empty)
                    model.View.ErrorListId = Guid.NewGuid();

                if (model.View.PropertyGridId == null || model.View.PropertyGridId == Guid.Empty)
                    model.View.PropertyGridId = Guid.NewGuid();

                if (model.View.SearchId == null || model.View.SearchId == Guid.Empty)
                    model.View.SearchId = Guid.NewGuid();

                if (model.View.SearchResultId == null || model.View.SearchResultId == Guid.Empty)
                    model.View.SearchResultId = Guid.NewGuid();

                if (model.View.PluginWindowId == null || model.View.PluginWindowId == Guid.Empty)
                    model.View.PluginWindowId = Guid.NewGuid();
            }
        }

        private static void FixUpDerivedClasses(DomainClass domainClass, MetaModel model)
        {
            if (domainClass.ModelContext.MetaModel == model)
            {
                SerializationHelper.UpdateSerializationDomainProperties(domainClass.Store, domainClass.SerializedDomainClass, domainClass);
                SerializationHelper.UpdateSerializationDomainRoles(domainClass.Store, domainClass.SerializedDomainClass, domainClass);
            }

            foreach (DomainClass derivedClass in domainClass.DerivedClasses)
                FixUpDerivedClasses(derivedClass, model);
        }
        private static void FixUpDerivedRelationships(DomainRelationship domainClass, MetaModel model)
        {
            if (domainClass.ModelContext.MetaModel == model)
            {
                if (domainClass is EmbeddingRelationship)
                {
                    EmbeddingRelationship con = domainClass as EmbeddingRelationship;
                    SerializationHelper.UpdateSerializationDomainProperties(domainClass.Store, con.SerializedEmbeddingRelationship, domainClass);
                }

                if (domainClass is ReferenceRelationship)
                {
                    ReferenceRelationship con = domainClass as ReferenceRelationship;
                    SerializationHelper.UpdateSerializationDomainProperties(domainClass.Store, con.SerializedReferenceRelationship, domainClass);
                }
            }

            foreach (DomainRelationship derivedClass in domainClass.DerivedRelationships)
                FixUpDerivedRelationships(derivedClass, model);
        }

        #region Helper Methods
        private static void FixUpDomainClassInTreeView(DomainClass domainClass)
        {
            // add embedding relationships
            foreach (DomainRole role in domainClass.RolesPlayed)
                if (role.Relationship.Source == role && role.Relationship is EmbeddingRelationship)
                {
                    EmbeddingRelationship emb = role.Relationship as EmbeddingRelationship;

                    if (emb.Target.RolePlayer.DomainModelTreeNodes.Count > 0)
                        ModelTreeHelper.AddNewEmbeddingRS(emb, emb.Source.RolePlayer as DomainClass, emb.Target.RolePlayer, false);
                    else
                    {
                        ModelTreeHelper.AddNewEmbeddingRS(emb, emb.Source.RolePlayer as DomainClass, emb.Target.RolePlayer, true);
                        FixUpDomainClassInTreeView(emb.Target.RolePlayer as DomainClass);

                        emb.Target.RolePlayer.DomainModelTreeNodes[0].IsEmbeddingTreeExpanded = true;
                        emb.Target.RolePlayer.DomainModelTreeNodes[0].IsReferenceTreeExpanded = true;
                        emb.Target.RolePlayer.DomainModelTreeNodes[0].IsInheritanceTreeExpanded = true;
                        emb.Target.RolePlayer.DomainModelTreeNodes[0].IsShapeMappingTreeExpanded = true;
                    }
                }
        }
        private static void FixUpDomainModelTreeView(LibraryModelContext model)
        {
            // create root nodes and embedding rs
            foreach (DomainClass domainClass in model.Classes)
            {
                if (!domainClass.HasParent())
                {
                    RootNode node = new RootNode(model.Store);
                    node.DomainElement = domainClass;
                    node.IsElementHolder = true;
                    domainClass.ModelContext.ViewContext.DomainModelTreeView.RootNodes.Add(node);
                    domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(node);

                    node.IsEmbeddingTreeExpanded = true;
                    node.IsReferenceTreeExpanded = true;
                    node.IsInheritanceTreeExpanded = true;
                    node.IsShapeMappingTreeExpanded = true;

                    FixUpDomainClassInTreeView(domainClass);
                }
            }

            // reference relationships + shapes
            foreach (DomainRelationship relationship in model.Relationships)
            {
                if (relationship is ReferenceRelationship)
                {
                    ReferenceRelationship rel = relationship as ReferenceRelationship;
                    ModelTreeHelper.AddNewReferenceRelationship(rel, rel.Source.RolePlayer as DomainClass, rel.Target.RolePlayer);

                    // shape
                    foreach (RelationshipShapeClass s in rel.RelationshipShapeClasses)
                    {
                        ReferenceRSNode node = rel.ReferenceRSNode;

                        // create new shape relationship node
                        ShapeRelationshipNode shapeNode = new ShapeRelationshipNode(rel.Store);
                        shapeNode.RelationshipShapeClass = s;

                        node.ShapeRelationshipNodes.Add(shapeNode);
                        rel.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(shapeNode);
                    }
                }
            }

            // inheritance
            foreach (DomainClass domainClass in model.Classes)
            {
                if (domainClass.BaseClass != null)
                {
                    DomainClassReferencesBaseClass refBase = DomainClassReferencesBaseClass.GetLink(domainClass, domainClass.BaseClass);
                    if (refBase != null)
                    {
                        if (domainClass.DomainModelTreeNodes.Count > 0)
                            ModelTreeHelper.AddNewInheritanceRelationship(refBase, domainClass, domainClass.BaseClass, false);
                        else
                            ModelTreeHelper.AddNewInheritanceRelationship(refBase, domainClass, domainClass.BaseClass, true);
                    }
                }
            }

            // shapes
            foreach (DomainClass domainClass in model.Classes)
                foreach (PresentationDomainClassElement p in domainClass.ShapeClasses)
                {
                    foreach (TreeNode node in domainClass.DomainModelTreeNodes)
                    {
                        if (node.IsElementHolder)
                        {
                            ShapeClassNode shapeNode = new ShapeClassNode(domainClass.Store);
                            shapeNode.ShapeClass = p;

                            node.ShapeClassNodes.Add(shapeNode);
                            domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(shapeNode);
                            break;
                        }
                    }
                }

        }
        private static void FixUpDiagramView(LibraryModelContext model)
        {
            foreach (DiagramClass diagramClass in model.DiagramClasses)
            {
                DiagramClassView vm = new DiagramClassView(model.Store);
                vm.IsExpanded = true;
                vm.DiagramClass = diagramClass;

                // add shapes views
                foreach (PresentationElementClass p in diagramClass.PresentationElements)
                {
                    if (p is ShapeClass)
                    {
                        ShapeClass shapeClass = p as ShapeClass;
                        if (shapeClass.Parent == null)
                        {
                            RootDiagramNode node = new RootDiagramNode(p.Store);
                            node.PresentationElementClass = p;

                            vm.RootDiagramNodes.Add(node);
                        }
                        else
                        {
                            EmbeddingDiagramNode newNode = new EmbeddingDiagramNode(model.Store);
                            newNode.PresentationElementClass = p;
                        }
                    }
                    else
                    {
                        RootDiagramNode node = new RootDiagramNode(p.Store);
                        node.PresentationElementClass = p;

                        vm.RootDiagramNodes.Add(node);
                    }
                }

                foreach (PresentationElementClass p in diagramClass.PresentationElements)
                {
                    if (p is ShapeClass)
                    {
                        ShapeClass shapeClass = p as ShapeClass;
                        if (shapeClass.Parent != null)
                        {
                            EmbeddingDiagramNode source = shapeClass.Parent.DiagramTreeNode as EmbeddingDiagramNode;
                            EmbeddingDiagramNode target = p.DiagramTreeNode as EmbeddingDiagramNode;

                            if (source != null && target != null)
                                new EmbeddingDiagramNodeHasEmbeddingDiagramNodes(source, target);
                        }
                    }
                }

                model.ViewContext.DiagramView.DiagramClassViews.Add(vm);
            }
        }
        private static void FixUpSerializedDomainModel(ModelContext model)
        {
            foreach (DomainClass domainClass in model.Classes)
                if (domainClass.IsDomainModel)
                {
                    SerializedDomainModel child = new SerializedDomainModel(domainClass.Store);
                    child.DomainClass = domainClass;
                    child.SerializationName = domainClass.SerializationName;

                    model.SerializationModel.SerializedDomainModel = child;
                    SerializationHelper.AddSerializationDomainProperties(domainClass.Store, domainClass);
                }
                else
                {
                    SerializationDomainClassAddRule.OnDomainClassAdded(domainClass);
                    domainClass.SerializedDomainClass.SerializationName = domainClass.SerializationName;
                }

            foreach (DomainRelationship relationship in model.Relationships)
            {
                if (relationship is EmbeddingRelationship)
                {
                    SerializationDomainRelationshipAddRule.OnEmbeddingRelationshipAdded(relationship as EmbeddingRelationship);
                    (relationship as EmbeddingRelationship).SerializedEmbeddingRelationship.SerializationName = relationship.SerializationName;
                }
                else
                {
                    SerializationDomainRelationshipAddRule.OnReferenceRelationshipAdded(relationship as ReferenceRelationship);
                    (relationship as ReferenceRelationship).SerializedReferenceRelationship.SerializationName = relationship.SerializationName;
                }
            }

            foreach (DomainClass domainClass in model.Classes)
            {
                SerializationHelper.UpdateSerializationDomainProperties(domainClass.Store, domainClass.SerializedDomainClass, domainClass);
                SerializationHelper.UpdateSerializationDomainRoles(domainClass.Store, domainClass.SerializedDomainClass, domainClass);

                foreach (DomainProperty p in domainClass.Properties)
                    p.SerializedDomainProperty.IsSerializationNameTracking = TrackingEnum.True;
            }

            foreach (DomainRelationship relationship in model.Relationships)
            {
                if (relationship is EmbeddingRelationship)
                {
                    SerializationHelper.UpdateSerializationDomainProperties(relationship.Store, (relationship as EmbeddingRelationship).SerializedEmbeddingRelationship, relationship);
                }
                else
                {
                    SerializationHelper.UpdateSerializationDomainProperties(relationship.Store, (relationship as ReferenceRelationship).SerializedReferenceRelationship, relationship);
                }

                foreach (DomainProperty p in relationship.Properties)
                    p.SerializedDomainProperty.IsSerializationNameTracking = TrackingEnum.True;
            }

            // correct IsSerializationNameTracking values

            foreach (DomainClass domainClass in model.Classes)
            {
                if (domainClass.SerializationName != domainClass.Name)
                    domainClass.IsSerializationNameTracking = TrackingEnum.False;

                domainClass.SerializedDomainClass.IsSerializationNameTracking = domainClass.IsSerializationNameTracking;

                foreach (DomainProperty p in domainClass.Properties)
                {
                    if (p.Name != p.SerializationName)
                        p.IsSerializationNameTracking = TrackingEnum.False;

                    p.SerializedDomainProperty.IsSerializationNameTracking = p.IsSerializationNameTracking;

                    if (p.Name == "DomainFilePath")
                        p.SerializedDomainProperty.OmitProperty = true;
                }
            }

            foreach (DomainRelationship relationship in model.Relationships)
            {
                if (relationship is EmbeddingRelationship)
                {
                    EmbeddingRelationship emb = relationship as EmbeddingRelationship;
                    if (emb.SerializationName != emb.Name)
                        emb.IsSerializationNameTracking = TrackingEnum.False;

                    emb.SerializedEmbeddingRelationship.IsSerializationNameTracking = emb.IsSerializationNameTracking;
                }
                else
                {
                    ReferenceRelationship refRel = relationship as ReferenceRelationship;
                    if (refRel.SerializationName != refRel.Name)
                        refRel.IsSerializationNameTracking = TrackingEnum.False;

                    refRel.SerializedReferenceRelationship.IsSerializationNameTracking = refRel.IsSerializationNameTracking;
                }

                foreach (DomainProperty p in relationship.Properties)
                {
                    if (p.Name != p.SerializationName)
                        p.IsSerializationNameTracking = TrackingEnum.True;

                    p.SerializedDomainProperty.IsSerializationNameTracking = p.IsSerializationNameTracking;
                }
            }
        }
        private static void FixUpDomainTypes(MetaModel model)
        {
            // String
            ExternalType stringType = new ExternalType(model.Store);
            stringType.Name = "String";
            stringType.Namespace = "System";
            stringType.DisplayName = "String";
            stringType.PropertyGridEditor = GetPropertyGridEditor(model, "StringEditorViewModel");
            model.DomainTypes.Add(stringType);

            // Boolean?
            ExternalType boolType = new ExternalType(model.Store);
            boolType.Name = "Boolean?";
            boolType.Namespace = "System";
            boolType.DisplayName = "Boolean";
            boolType.PropertyGridEditor = GetPropertyGridEditor(model, "BooleanEditorViewModel");
            model.DomainTypes.Add(boolType);

            // Guid?
            ExternalType guidType = new ExternalType(model.Store);
            guidType.Name = "Guid?";
            guidType.Namespace = "System";
            guidType.DisplayName = "Guid";
            model.DomainTypes.Add(guidType);

            // Int32?
            ExternalType in32Type = new ExternalType(model.Store);
            in32Type.Name = "Int32?";
            in32Type.Namespace = "System";
            in32Type.DisplayName = "Integer";
            in32Type.RequiresSerializationConversion = true;
            in32Type.PropertyGridEditor = GetPropertyGridEditor(model, "IntegerEditorViewModel");
            model.DomainTypes.Add(in32Type);

            // Double?
            ExternalType dType = new ExternalType(model.Store);
            dType.Name = "Double?";
            dType.Namespace = "System";
            dType.DisplayName = "Double";
            dType.RequiresSerializationConversion = true;
            dType.PropertyGridEditor = GetPropertyGridEditor(model, "DoubleEditorViewModel");
            model.DomainTypes.Add(dType);
        }
        private static void FixUpPropertyGridEditors(MetaModel model)
        {
            PropertyGridEditor stringEditor = new PropertyGridEditor(model.Store);
            stringEditor.Name = "StringEditorViewModel";
            stringEditor.Namespace = "Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid";
            stringEditor.ShouldBeGenerated = false;
            model.PropertyGridEditors.Add(stringEditor);

            PropertyGridEditor boolEditor = new PropertyGridEditor(model.Store);
            boolEditor.Name = "BooleanEditorViewModel";
            boolEditor.Namespace = "Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid";
            boolEditor.ShouldBeGenerated = false;
            model.PropertyGridEditors.Add(boolEditor);

            PropertyGridEditor enumEditor = new PropertyGridEditor(model.Store);
            enumEditor.Name = "EnumerationEditorViewModel";
            enumEditor.Namespace = "Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid";
            enumEditor.ShouldBeGenerated = false;
            model.PropertyGridEditors.Add(enumEditor);

            PropertyGridEditor dEditor = new PropertyGridEditor(model.Store);
            dEditor.Name = "DoubleEditorViewModel";
            dEditor.Namespace = "Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid";
            dEditor.ShouldBeGenerated = false;
            model.PropertyGridEditors.Add(dEditor);

            PropertyGridEditor iEditor = new PropertyGridEditor(model.Store);
            iEditor.Name = "IntegerEditorViewModel";
            iEditor.Namespace = "Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid";
            iEditor.ShouldBeGenerated = false;
            model.PropertyGridEditors.Add(iEditor);
        }
        private static void FixUpModelContext(MetaModel model)
        {
            ModelContext modelContext = new ModelContext(model.Store);
            modelContext.Name = "DefaultContext";
            modelContext.IsDefault = true;
            model.ModelContexts.Add(modelContext);

            DomainClass domainClass = new DomainClass(model.Store);
            domainClass.Name = "DomainModel";
            domainClass.IsDomainModel = true;
            domainClass.DisplayName = "DomainModel";
            domainClass.SerializationName = "DomainModel";
            modelContext.Classes.Add(domainClass);
        }
        private static PropertyGridEditor GetPropertyGridEditor(MetaModel model, string name)
        {
            foreach (PropertyGridEditor p in model.PropertyGridEditors)
                if (p.Name == name)
                    return p;

            return null;
        }
        #endregion
    }
}
