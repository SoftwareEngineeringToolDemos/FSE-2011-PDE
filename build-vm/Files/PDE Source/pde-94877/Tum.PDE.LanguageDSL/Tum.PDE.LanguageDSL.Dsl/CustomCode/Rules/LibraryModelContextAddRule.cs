using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(LibraryModelContext), FireTime = TimeToFire.TopLevelCommit)]
    public class LibraryModelContextAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            LibraryModelContext modelContext = e.ModelElement as LibraryModelContext;
            if (modelContext != null && !(modelContext is ModelContext))
            {
                ViewContext viewContext = new ViewContext(modelContext.Store);
                viewContext.DomainModelTreeView = new DomainModelTreeView(modelContext.Store);
                viewContext.DiagramView = new DiagramView(modelContext.Store);
                modelContext.ViewContext = viewContext;
                modelContext.MetaModel.View.ViewContexts.Add(viewContext);

                /*
                DesignerDiagramClass ddC = new DesignerDiagramClass(modelContext.Store);
                ddC.Name = NameHelper.GetUniqueName(modelContext.Store, DesignerDiagramClass.DomainClassId);
                //ddC.Name = "DesignerDiagram";
                ddC.Title = "Designer";
                modelContext.DiagramClasses.Add(ddC);

                DiagramClassView vm = new DiagramClassView(modelContext.Store);
                vm.IsExpanded = true;
                vm.DiagramClass = ddC;
                modelContext.ViewContext.DiagramView.DiagramClassViews.Add(vm);
                */

                if( modelContext.SerializationModel == null )
                    modelContext.SerializationModel = new SerializationModel(modelContext.Store);
            }
        }
    }
}
