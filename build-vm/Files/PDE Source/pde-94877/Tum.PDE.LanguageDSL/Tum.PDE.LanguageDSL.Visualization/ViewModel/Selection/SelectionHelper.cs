using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    [Flags]
    public enum SelectionHelperTarget
    {
        DomainClass=1,
        EmbeddingRelationship=2,
        ReferenceRelationship=4,
        DiagramClass=8,
        ShapeClass=16,
        RSShapeClass=32,
        MappingShapeClass =64,
        DiagramClassWithoutDerived =128,
    }

    public class SelectionHelper
    {
        public static CategorizedSelectionViewModel CreateCategorizedVMWithoutImported(MetaModel model, ViewModelStore store, SelectionHelperTarget target)
        {
            // categories for main meta model as well as imported ones
            List<CategorizedAdvSelectableViewModel> modelCategoryVMs = new List<CategorizedAdvSelectableViewModel>();
            CategorizedAdvSelectableViewModel modelCategoryVM = CreateCategorizedAdvSelectableVM(model, model.Name, store, target);
            modelCategoryVMs.Add(modelCategoryVM);

            return new CategorizedSelectionViewModel(store, modelCategoryVMs);
        }
        public static CategorizedSelectionViewModel CreateCategorizedVM(MetaModel model, ViewModelStore store, SelectionHelperTarget target)
        {
            // categories for main meta model as well as imported ones
            List<MetaModel> handledMetaModels = new List<MetaModel>();
            List<CategorizedAdvSelectableViewModel> modelCategoryVMs = new List<CategorizedAdvSelectableViewModel>();
            CreateCategorizedVM(model, store, target, handledMetaModels, modelCategoryVMs);

            return new CategorizedSelectionViewModel(store, modelCategoryVMs);
        }

        private static void CreateCategorizedVM(MetaModel model, ViewModelStore store, SelectionHelperTarget target, List<MetaModel> handledMetaModels, List<CategorizedAdvSelectableViewModel> modelCategoryVMs)
        {
            if (!handledMetaModels.Contains(model))
            {
                CategorizedAdvSelectableViewModel modelCategoryVM = CreateCategorizedAdvSelectableVM(model, model.Name, store, target);
                modelCategoryVMs.Add(modelCategoryVM);
                handledMetaModels.Add(model);

                // imported models
                foreach (MetaModelLibrary library in model.MetaModelLibraries)
                    if (library.ImportedLibrary != null)
                        if (library.ImportedLibrary is MetaModel)
                            CreateCategorizedVM(library.ImportedLibrary as MetaModel, store, target, handledMetaModels, modelCategoryVMs);
            }
            else
                return;
        }
        private static CategorizedAdvSelectableViewModel CreateCategorizedAdvSelectableVM(MetaModel model, string categoryName, ViewModelStore store, SelectionHelperTarget target)
        {
            List<CategorizedSelectableViewModel> vms = new List<CategorizedSelectableViewModel>();
            foreach (BaseModelContext m in model.ModelContexts)
            {
                if (m is LibraryModelContext)
                {
                    vms.Add(CreateCategorizedSelectableVM(m as LibraryModelContext, m.Name, store, target));
                }
            }
            return new CategorizedAdvSelectableViewModel(store, categoryName, vms);
        }
        private static CategorizedSelectableViewModel CreateCategorizedSelectableVM(LibraryModelContext model, string categoryName, ViewModelStore store, SelectionHelperTarget target)
        {
            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            if( (target & SelectionHelperTarget.DomainClass) > 0)
                foreach (DomainClass d in model.Classes)
                {
                    vms.Add(new SelectableViewModel(store, d));
                }


            if( (target & SelectionHelperTarget.EmbeddingRelationship) > 0 ||
                (target & SelectionHelperTarget.ReferenceRelationship) > 0)
                foreach (DomainRelationship r in model.Relationships)
                {
                    if( (target & SelectionHelperTarget.EmbeddingRelationship) > 0 && r is EmbeddingRelationship )
                        vms.Add(new SelectableViewModel(store, r));

                    if ((target & SelectionHelperTarget.ReferenceRelationship) > 0 && r is ReferenceRelationship)
                        vms.Add(new SelectableViewModel(store, r));
                }

            if ((target & SelectionHelperTarget.DiagramClass) > 0 ||
                (target & SelectionHelperTarget.DiagramClassWithoutDerived) > 0)
                foreach(DiagramClass d in model.DiagramClasses)
                {
                    if ((target & SelectionHelperTarget.DiagramClassWithoutDerived) > 0)
                    {
                        if (!(d is DesignerDiagramClass))
                            vms.Add(new SelectableViewModel(store, d));
                    }
                    else
                        vms.Add(new SelectableViewModel(store, d));
                }

            if ((target & SelectionHelperTarget.ShapeClass) > 0 ||
                (target & SelectionHelperTarget.RSShapeClass) > 0 ||
                (target & SelectionHelperTarget.MappingShapeClass) > 0)
                foreach (DiagramClass d in model.DiagramClasses)
                    foreach (PresentationElementClass p in d.PresentationElements)
                    {
                        if( p is ShapeClass && (target & SelectionHelperTarget.ShapeClass) > 0 )
                            vms.Add(new SelectableViewModel(store, p));
                        if (p is RelationshipShapeClass && (target & SelectionHelperTarget.RSShapeClass) > 0)
                            vms.Add(new SelectableViewModel(store, p));
                        if (p is MappingRelationshipShapeClass && (target & SelectionHelperTarget.MappingShapeClass) > 0)
                            vms.Add(new SelectableViewModel(store, p));
                    }

            vms.Sort(CompareByName);
            return new CategorizedSelectableViewModel(store, categoryName, vms);
        }


        private static int CompareByName(SelectableViewModel x, SelectableViewModel y)
        {
            return x.DomainElementFullName.CompareTo(y.DomainElementFullName);
        }
    }
}
