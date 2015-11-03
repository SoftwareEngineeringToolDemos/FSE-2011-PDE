namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This interface provides properties, that are required for a view model, that is presented in a dockable window pane.
    /// </summary>
    public interface IDockableViewModel
    {
        /// <summary>
        /// Unique name.
        /// </summary>
        string DockingPaneName{ get; }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        string DockingPaneTitle { get; }

        /// <summary>
        /// Is dockable window visible.
        /// </summary>
        bool IsDockingPaneVisible { get; set; }
    }
}
