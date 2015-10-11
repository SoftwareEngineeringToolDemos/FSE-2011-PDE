using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This class allows the extension of the model tree context menu. It is only required to
    /// provide a mechanism to extend the context menu in multiple-component DSLs.
    /// </summary>
    /// <remarks>
    /// The idea behind this is as follows:
    /// 
    /// Component A includes components B and C. B includes D. Therefore the context menu provider of
    /// A has B and C as children. B has D as child. On the other hand, D has B as parent and B and C
    /// have A as parent.
    /// 
    /// The children are represented as injected provider. The parent is the injectedIn provider.
    /// </remarks>
    public class ModelTreeContextMenuProvider : IModelTreeContextMenuProvider
    {
        private List<IModelTreeContextMenuProvider> injectedContextMenuProvider;
        private List<IModelTreeContextMenuProvider> injectedInContextMenuProvider;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ModelTreeContextMenuProvider()
        {
            this.injectedContextMenuProvider = new List<IModelTreeContextMenuProvider>();
            this.injectedInContextMenuProvider = new List<IModelTreeContextMenuProvider>();
        }

        /// <summary>
        /// Gets the context menu providers, in which this provider is injected in.
        /// </summary>
        public List<IModelTreeContextMenuProvider> InjectedInContextMenuProviders
        {
            get
            {
                return this.injectedInContextMenuProvider;
            }
        }

        /// <summary>
        /// Gets the injected context menu providers.
        /// </summary>
        public List<IModelTreeContextMenuProvider> InjectedContextMenuProviders
        {
            get
            {
                return this.injectedContextMenuProvider;
            }
        }

        /// <summary>
        /// Adds an context menu provider, that needs to be called whenever the methonds of this 
        /// context menu provider are invoked.
        /// </summary>
        /// <param name="provider">Context menu provider.</param>
        public void AddInjectedContextMenuProvider(IModelTreeContextMenuProvider provider)
        {
            if (!this.injectedContextMenuProvider.Contains(provider))
            {
                this.injectedContextMenuProvider.Add(provider);
            }
        }

        /// <summary>
        /// Adds an context menu provider, that this provider is injected in.
        /// </summary>
        /// <param name="provider">Context menu provider.</param>
        /// <remarks>
        /// This will cause this provider to inject itself into the given provider.
        /// </remarks>
        public void AddInjectedInContextMenuProvider(IModelTreeContextMenuProvider provider)
        {
            if (!this.injectedInContextMenuProvider.Contains(provider))
            {
                this.injectedInContextMenuProvider.Add(provider);
                provider.AddInjectedContextMenuProvider(this);
            }
        }

        /// <summary>
        /// Modify the context menu view model by adding custom menu items.
        /// </summary>
        /// <param name="contextMenu">Context menu view model containing automatically added menu items.</param>
        /// <param name="element">Host element.</param>
        public void ProcessContextMenu(MenuItemViewModel contextMenu, ModelElementTreeViewModel element)
        {
            this.ProcessContextMenu(contextMenu, element, new List<IModelTreeContextMenuProvider>());
        }

        /// <summary>
        /// Modify the context menu view model by adding custom menu items.
        /// </summary>
        /// <param name="contextMenu">Context menu view model containing automatically added menu items.</param>
        /// <param name="element">Host element.</param>
        /// <param name="processedProviders">Providers that have already been visited.</param>
        public virtual void ProcessContextMenu(MenuItemViewModel contextMenu, ModelElementTreeViewModel element, List<IModelTreeContextMenuProvider> processedProviders)
        {
            processedProviders.Add(this);

            foreach (IModelTreeContextMenuProvider p in this.InjectedContextMenuProviders)
                if( !processedProviders.Contains(p) )
                    p.ProcessContextMenu(contextMenu, element, processedProviders);
        }

        /// <summary>
        /// Should a menu item type be created for a specific domain class?
        /// </summary>
        /// <param name="menuItemType">Menu item type: e.g.: Add, Delete, ...</param>
        /// <param name="domainElementType">Domain element type in question.</param>
        /// <param name="parentElement">Parent element of the domain element to be added, or deleted, or...</param>
        /// <param name="domainElement">Domain element instance. Is null if this is an AddElementMenuItem type of menu item.</param>
        /// <returns>True, if the menu item should be created. False otherwise.</returns>
        public bool ShouldCreateMenuItem(ModelTreeContextMenuItemType menuItemType, System.Type domainElementType, ModelElement parentElement, ModelElement domainElement)
        {
            return ShouldCreateMenuItem(menuItemType, domainElementType, parentElement, domainElement, new List<IModelTreeContextMenuProvider>());
        }

        /// <summary>
        /// Should a menu item type be created for a specific domain class?
        /// </summary>
        /// <param name="menuItemType">Menu item type: e.g.: Add, Delete, ...</param>
        /// <param name="domainElementType">Domain element type in question.</param>
        /// <param name="parentElement">Parent element of the domain element to be added, or deleted, or...</param>
        /// <param name="domainElement">Domain element instance. Is null if this is an AddElementMenuItem type of menu item.</param>
        /// <param name="processedProviders">Providers that have already been visited.</param>
        /// <returns>True, if the menu item should be created. False otherwise.</returns>
        public virtual bool ShouldCreateMenuItem(ModelTreeContextMenuItemType menuItemType, System.Type domainElementType, ModelElement parentElement, ModelElement domainElement, List<IModelTreeContextMenuProvider> processedProviders)
        {
            processedProviders.Add(this);

            foreach (IModelTreeContextMenuProvider p in this.InjectedContextMenuProviders)
                if (!processedProviders.Contains(p))
                    if (!p.ShouldCreateMenuItem(menuItemType, domainElementType, parentElement, domainElement, processedProviders))
                        return false;

            return true;
        }

        /// <summary>
        /// Searches for a MenuItemViewModel, which has its user data field set to the specified key.
        /// (Only the top level children of the context menu are searched).
        /// </summary>
        /// <param name="contextMenu">Context menu.</param>
        /// <param name="userDataKey">User data key.</param>
        /// <returns>MenuItemViewModel if found. Null otherwise.</returns>
        public MenuItemViewModel FindMenuViewModel(MenuItemViewModel contextMenu, string userDataKey)
        {
            foreach (MenuItemViewModel m in contextMenu.Children)
                if (m.UserData != null)
                    if (m.UserData.ToString() == userDataKey)
                        return m;

            return null;
        }
    }
}
