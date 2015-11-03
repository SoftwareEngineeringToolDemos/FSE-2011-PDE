using System;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ModelContext), FireTime = TimeToFire.TopLevelCommit)]
    public class ModelContextAddRule : AddRule
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

            ModelContext modelContext = e.ModelElement as ModelContext;
            if (modelContext != null)
            {
                if (modelContext.ViewContext == null)
                {
                    ViewContext viewContext = new ViewContext(modelContext.Store);
                    viewContext.DomainModelTreeView = new DomainModelTreeView(modelContext.Store);
                    viewContext.DiagramView = new DiagramView(modelContext.Store);
                    modelContext.ViewContext = viewContext;
                    modelContext.MetaModel.View.ViewContexts.Add(viewContext);
                }

                if (modelContext.DiagramClasses.Count == 0)
                {
                    DesignerDiagramClass ddC = new DesignerDiagramClass(modelContext.Store);
                    //ddC.Name = "DesignerDiagram";
                    ddC.Name = NameHelper.GetUniqueName(modelContext.Store, DesignerDiagramClass.DomainClassId);
                    ddC.Title = "Designer";
                    modelContext.DiagramClasses.Add(ddC);

                    DiagramClassView vm = new DiagramClassView(modelContext.Store);
                    vm.IsExpanded = true;
                    vm.DiagramClass = ddC;
                    modelContext.ViewContext.DiagramView.DiagramClassViews.Add(vm);
                }

                DomainClass domainClass = modelContext.Store.ElementFactory.CreateElement(DomainClass.DomainClassId) as DomainClass;
                domainClass.IsDomainModel = true;
                Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(modelContext.Store as IServiceProvider, modelContext.Store.DefaultPartition);
                Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(modelContext.Store.DefaultPartition);
                elementGroup.Add(domainClass);
                elementGroup.MarkAsRoot(domainClass);
                elementOperations.MergeElementGroup(modelContext, elementGroup);
                domainClass.Name = NameHelper.GetUniqueName(modelContext.Store, DomainClass.DomainClassId);

                SerializedDomainModel child = new SerializedDomainModel(domainClass.Store);
                child.DomainClass = domainClass;
                child.SerializationName = domainClass.SerializationName;

                if (modelContext.SerializationModel == null)
                {
                    modelContext.SerializationModel = new SerializationModel(modelContext.Store);
                }

                modelContext.SerializationModel.SerializedDomainModel = child;
                SerializationHelper.AddSerializationDomainProperties(domainClass.Store, domainClass);
            }
        }
    }
}
