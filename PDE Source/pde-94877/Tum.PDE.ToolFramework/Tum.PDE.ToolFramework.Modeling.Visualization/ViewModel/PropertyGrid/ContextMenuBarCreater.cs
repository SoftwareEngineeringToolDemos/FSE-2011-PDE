using Fluent;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Context menu bar creater for property grid editors.
    /// </summary>
    public abstract class ContextMenuBarCreater
    {
        /// <summary>
        /// This method needs to overriden in the actual instances of this class to create contextual
        /// or regular ribbon bars if required.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public abstract void CreateRibbonMenuBar(Ribbon ribbonMenu);
    }
}
