using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface for the context menu provider used to process and create additional menu items.
    /// </summary>
    public interface IModelTreeContextMenuProvider
    {
        /// <summary>
        /// Gets the injected context menu providers.
        /// </summary>
        List<IModelTreeContextMenuProvider> InjectedContextMenuProviders{ get; }

        /// <summary>
        /// Gets the context menu providers, in which this provider is injected in.
        /// </summary>
        List<IModelTreeContextMenuProvider> InjectedInContextMenuProviders { get; }

        /// <summary>
        /// Adds an context menu provider, that needs to be called whenever the methonds of this 
        /// context menu provider are invoked.
        /// </summary>
        /// <param name="provider">Context menu provider.</param>
        /// <remarks>
        /// All injected context menu provider that are included in the given provider are added
        /// to this provider as well.
        /// </remarks>
        void AddInjectedContextMenuProvider(IModelTreeContextMenuProvider provider);

        /// <summary>
        /// Adds an context menu provider, that this provider is injected in.
        /// </summary>
        /// <param name="provider">Context menu provider.</param>
        void AddInjectedInContextMenuProvider(IModelTreeContextMenuProvider provider);

        /// <summary>
        /// Should a menu item type be created for a specific domain class?
        /// </summary>
        /// <param name="menuItemType">Menu item type: e.g.: Add, Delete, ...</param>
        /// <param name="domainElementType">Domain element type in question.</param>
        /// <param name="parentElement">Parent element of the domain element to be added, or deleted, or...</param>
        /// <param name="domainElement">Domain element instance. Is null if this is an AddElementMenuItem type of menu item.</param>
        /// <returns>True, if the menu item should be created. False otherwise.</returns>
        bool ShouldCreateMenuItem(ModelTreeContextMenuItemType menuItemType, Type domainElementType, ModelElement parentElement, ModelElement domainElement);

        /// <summary>
        /// Should a menu item type be created for a specific domain class?
        /// </summary>
        /// <param name="menuItemType">Menu item type: e.g.: Add, Delete, ...</param>
        /// <param name="domainElementType">Domain element type in question.</param>
        /// <param name="parentElement">Parent element of the domain element to be added, or deleted, or...</param>
        /// <param name="domainElement">Domain element instance. Is null if this is an AddElementMenuItem type of menu item.</param>
        /// <param name="processedProviders">Providers that have already been visited.</param>
        /// <returns>True, if the menu item should be created. False otherwise.</returns>
        bool ShouldCreateMenuItem(ModelTreeContextMenuItemType menuItemType, Type domainElementType, ModelElement parentElement, ModelElement domainElement, List<IModelTreeContextMenuProvider> processedProviders);

        /// <summary>
        /// Modify the context menu view model by adding custom menu items.
        /// </summary>
        /// <param name="contextMenu">Context menu view model containing automatically added menu items.</param>
        /// <param name="element">Host element.</param>
        void ProcessContextMenu(MenuItemViewModel contextMenu, ModelElementTreeViewModel element);

        /// <summary>
        /// Modify the context menu view model by adding custom menu items.
        /// </summary>
        /// <param name="contextMenu">Context menu view model containing automatically added menu items.</param>
        /// <param name="element">Host element.</param>
        /// <param name="processedProviders">Providers that have already been visited.</param>
        void ProcessContextMenu(MenuItemViewModel contextMenu, ModelElementTreeViewModel element, List<IModelTreeContextMenuProvider> processedProviders);
    }
}
