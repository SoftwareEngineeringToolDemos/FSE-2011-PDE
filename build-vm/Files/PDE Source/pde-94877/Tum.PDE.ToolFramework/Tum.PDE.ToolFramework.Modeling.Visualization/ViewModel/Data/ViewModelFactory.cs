using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// This abstract base class provides factory methods for the creation of view model for model elements from the model.
    /// </summary>
    public abstract class ViewModelFactory
    {
        ViewModelStore viewModelStore;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing view models.</param>
        public ViewModelFactory(ViewModelStore viewModelStore)
        {
            this.viewModelStore = viewModelStore;
        }

        /// <summary>
        /// Gets the view model store.
        /// </summary>
        public ViewModelStore Store
        {
            get { return this.viewModelStore; }
        }

        /// <summary>
        /// Creates the view model for the given node shape.
        /// </summary>
        /// <param name="nodeShapeType">Shape type for which the view model is to be created.</param>
        /// <param name="diagram">Diagram surface vm.</param>
        /// <param name="nodeShape">Node shape.</param>
        /// <returns>
        /// View model of type DiagramItemElementViewModel if a view model can be created for the given element. Null otherwise.</returns>
        public abstract DiagramItemElementViewModel CreateDiagramItemViewModel(Guid nodeShapeType, DiagramSurfaceViewModel diagram, NodeShape nodeShape);

        /// <summary>
        /// Creates the view model for the given link shape.
        /// </summary>
        /// <param name="nodeShapeType">Shape type for which the view model is to be created.</param>
        /// <param name="diagram">Diagram surface vm.</param>
        /// <param name="nodeShape">Link shape.</param>
        /// <returns>
        /// View model of type BaseDiagramItemLinkViewModel if a view model can be created for the given element. Null otherwise.</returns>
        public abstract BaseDiagramItemLinkViewModel CreateDiagramLinkViewModel(Guid nodeShapeType, DiagramSurfaceViewModel diagram, LinkShape nodeShape);

        /// <summary>
        /// Creates the view model for the given model element. Important: The name property doesnt update on changes
        /// in the model by default. Specify bHookUpEvents as true if that is needed.
        /// </summary>
        /// <param name="modelElement">Model element for which the view model is to be created.</param>
        /// <returns>
        /// View model of type BaseModelElementViewModel if a view model can be created for the given element. Null otherwise.</returns>
        public BaseModelElementViewModel CreateModelElementBaseViewModel(ModelElement modelElement)
        {
            return CreateModelElementBaseViewModel(modelElement, false);
        }

        /// <summary>
        /// Creates the view model for the given model element.
        /// </summary>
        /// <param name="modelElement">Model element for which the view model is to be created.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <returns>
        /// View model of type BaseModelElementViewModel if a view model can be created for the given element. Null otherwise.</returns>
        public BaseModelElementViewModel CreateModelElementBaseViewModel(ModelElement modelElement, bool bHookUpEvents)
        {
            return new BaseModelElementViewModel(this.Store, modelElement, bHookUpEvents);
        }

        /// <summary>
        /// Creates the tree view model for the given model element. Doesnt hook up into model events and also does not create
        /// context menus.
        /// </summary>
        /// <param name="modelElement">Model element for which the tree view model is to be created.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
        /// <returns>
        /// View model of type BaseModelElementTreeViewModel if a view model can be created for the given element. Null otherwise.</returns>
        /// <remarks>
        /// A view model of the type BaseModelElementViewModel can obly be created for domain classes and referencing relationships, that
        /// can be embedded in the model tree.
        /// </remarks>
        public BaseModelElementTreeViewModel CreateModelElementTreeViewModel(ModelElement modelElement, MainModelTreeViewModel mainModelTreeVm)
        {
            return CreateModelElementTreeViewModel(modelElement, false, false, mainModelTreeVm);
        }

        /// <summary>
        /// Creates the tree view model for the given model element.
        /// </summary>
        /// <param name="modelElement">Model element for which the tree view model is to be created.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
        /// <returns>
        /// View model of type BaseModelElementTreeViewModel if a view model can be created for the given element. Null otherwise.</returns>
        /// <remarks>
        /// A view model of the type BaseModelElementViewModel can obly be created for domain classes and referencing relationships, that
        /// can be embedded in the model tree.
        /// </remarks>
        public abstract BaseModelElementTreeViewModel CreateModelElementTreeViewModel(ModelElement modelElement, bool bHookUpEvents, bool bCreateContextMenus, MainModelTreeViewModel mainModelTreeVm);

        /// <summary>
        /// Creates the tree view model for the given model element.
        /// </summary>
        /// <param name="element">VModell represented by this view model.</param>
        /// <param name="link">Element link, targeting the hosted element.</param>
        /// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
        /// <param name="parent">Parent of this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
        public abstract ModelElementTreeViewModel CreateModelElementTreeViewModel(ModelElement element, ElementLink link, System.Guid domainRoleId, ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, MainModelTreeViewModel mainModelTreeVm);

        /// <summary>
        /// Returns a collection of property view models for the given selected elements.
        /// </summary>
        /// <param name="elements">Selected elements collection.</param>
        /// <returns>Collection of property view models. Can be empty.</returns>
        public abstract List<PropertyGridViewModel> CreatePropertyEditorViewModels(SelectedItemsCollection elements);

        /// <summary>
        /// Returns a collection of property view models for the given selected elements.
        /// </summary>
        /// <param name="models">Already gathered models.</param>
        /// <param name="m">ModelElement.</param>
        /// <param name="handledStores">Stores that have already been processed.</param>
        /// <returns>Collection of property view models. Can be empty.</returns>
        public abstract bool AddPropertyEditorViewModels(List<PropertyGridViewModel> models, ModelElement m, List<ViewModelStore> handledStores);

        /// <summary>
        /// Gets the dependencies for a specific model elements.
        /// </summary>
        /// <param name="modelElements">List of model elements to get the dependencies for.</param>
        /// <returns>List of dependency item view models.</returns>
        public virtual List<DependencyItemViewModel> CreateDependencyItemViewModels(List<ModelElement> modelElements)
        {
            List<DependencyItem> dependencies = this.Store.TopMostStore.GetDomainModelServices().DependenciesItemsProvider.GetDependencies(modelElements).ActiveDependencies;
            List<DependencyItemViewModel> dependenciesVM = new List<DependencyItemViewModel>();
            foreach(DependencyItem item in dependencies)
                dependenciesVM.Add(new DependencyItemViewModel(this.Store, item, false));

            return dependenciesVM;
        }

        /// <summary>
        /// Attempts at creating a view model of a specified type. This is meant to be called for restorable VMs that are in 
        /// the process of beeing restored.
        /// </summary>
        /// <param name="vmType">Type of the vm.</param>
        /// <returns>VM if succeeded. Null otherwise.</returns>
        public virtual BaseDiagramSurfaceViewModel CreateRestorableViewModel(string vmType)
        {
            List<ViewModelStore> handledStores = new List<ViewModelStore>();
            handledStores.Add(this.Store);

            return CreateRestorableViewModel(vmType, handledStores);
        }

        /// <summary>
        /// Attempts at creating a view model of a specified type. This is meant to be called for restorable VMs that are in 
        /// the process of beeing restored.
        /// </summary>
        /// <param name="vmType">Type of the vm.</param>
        /// <param name="handledStores">Stores that have already been processed.</param>
        /// <returns>VM if succeeded. Null otherwise.</returns>
        public abstract BaseDiagramSurfaceViewModel CreateRestorableViewModel(string vmType, List<ViewModelStore> handledStores);
    }
}
