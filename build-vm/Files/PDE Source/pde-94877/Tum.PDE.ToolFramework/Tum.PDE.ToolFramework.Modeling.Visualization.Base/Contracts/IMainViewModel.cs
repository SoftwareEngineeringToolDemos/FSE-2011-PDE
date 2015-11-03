using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts
{
    /// <summary>
    /// Interface identifying a main vm.
    /// </summary>
    public interface IMainViewModel
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        void InitializeVM();

        /// <summary>
        /// Event handler, called after the layout manager has been initialized.
        /// </summary>
        event EventHandler LayoutManagerInitialized;

        /// <summary>
        /// Ribbon control.
        /// </summary>
        Fluent.Ribbon Ribbon
        {
            get;
            set;
        }

        /// <summary>
        /// True if the app can exit. False otherwise.
        /// </summary>
        /// <returns></returns>
        bool CanExit();

        /// <summary>
        /// Logic to handle on app exit.
        /// </summary>
        void OnExit();

        /// <summary>
        /// Dispose.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Open the model at the specified file location.
        /// </summary>
        /// <param name="fileName"></param>
        void OpenModel(string fileName);
    }
}
