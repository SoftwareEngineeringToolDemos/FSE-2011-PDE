using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fluent;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface specifying that the vm can create ribbon menus.
    /// </summary>
    public interface IRibbonDockableViewModel
    {
        /// <summary>
        /// This method needs to overriden in the actual instances of this class to create contextual
        /// or regular ribbon bars if required.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        void CreateRibbonMenu(Ribbon ribbonMenu);

        /// <summary>
        /// Gets or sets wether the ribbon menu has been initialized or not.
        /// </summary>
        bool IsRibbonMenuInitialized
        {
            get;
            set;
        }
    }
}
