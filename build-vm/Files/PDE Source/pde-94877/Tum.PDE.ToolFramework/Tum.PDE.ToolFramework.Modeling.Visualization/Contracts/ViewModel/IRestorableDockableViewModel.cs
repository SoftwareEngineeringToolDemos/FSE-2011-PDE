using System.Xml.Linq;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// This interface provides properties, that are required for a view model to be restored after it has been closed on
    /// e.g. editor exit or model context switch.
    /// </summary>
    public interface IRestorableDockableViewModel : IDockableViewModel
    {
        /// <summary>
        /// Get the necessary information to restore this vm after it has been closed.
        /// </summary>
        /// <returns>Restore information.</returns>
        XElement GetInformationForRestore();

        /// <summary>
        /// Get the docking pane type as string.
        /// </summary>
        /// <returns>Docking pane type.</returns>
        string GetDockingPaneType();

        /// <summary>
        /// Restore the VM based on stored information.
        /// </summary>
        /// <param name="element">Info.</param>
        /// <returns>
        /// True if the restore process was successful. False otherwise.
        /// </returns>
        bool Restore(XElement element);
    }
}
