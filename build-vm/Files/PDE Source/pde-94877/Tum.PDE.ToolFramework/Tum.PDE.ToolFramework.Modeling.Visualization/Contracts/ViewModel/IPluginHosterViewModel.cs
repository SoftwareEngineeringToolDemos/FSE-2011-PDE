using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface for a plugin hoster vm. (A vm, that has been added as a plugin).
    /// </summary>
    public interface IPluginHosterViewModel
    {
        /// <summary>
        /// Gets or sets the vm plugin data.
        /// </summary>
        IViewModelPlugin VMPlugin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether this vm is a VM plugin.
        /// </summary>
        bool IsVMPlugin
        {
            get;
        }


        /// <summary>
        /// True if the vmplugin has a resource dictionary.
        /// </summary>
        bool VMPluginHasDictionary
        {
            get;
        }

        /// <summary>
        /// Gets or sets whether the vm plugin dictionary has been initialized.
        /// </summary>
        bool VMPluginDictionaryInitialized
        {
            get;
            set;
        }
    }
}
