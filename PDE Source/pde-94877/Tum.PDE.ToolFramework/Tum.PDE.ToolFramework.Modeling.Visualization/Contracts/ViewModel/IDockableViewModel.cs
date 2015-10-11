using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Activate mode enumeratoin.
    /// </summary>
    public enum ActivationMode
    {
        /// <summary>
        /// Activation on click.
        /// </summary>
        Normal,

        /// <summary>
        /// Not activation.
        /// </summary>
        None
    }

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
        /// Type.
        /// </summary>
        Type DockingPaneType { get; }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        string DockingPaneTitle { get; }

        /// <summary>
        /// Gets the header image URI.
        /// </summary>
        string DockingPaneImageUri
        {
            get;
        }

        /// <summary>
        /// Is dockable window visible.
        /// </summary>
        bool IsDockingPaneVisible { get; set; }

        /// <summary>
        /// Gets the floating windows desired width;
        /// </summary>
        double FloatingWindowDesiredWidth { get; set; }

        /// <summary>
        /// Gets the floating windows desired height;
        /// </summary>
        double FloatingWindowDesiredHeight { get; set; }

        /// <summary>
        /// Gets the docked windows desired width;  Default = 0.0 --> handle automatically.
        /// </summary>
        double DockedWindowDesiredWidth { get; set; }

        /// <summary>
        /// Gets the docked windows desired height; Default = 0.0 --> handle automatically.
        /// </summary>
        double DockedWindowDesiredHeight { get; set; }

        /// <summary>
        /// Gets the activation mode.
        /// </summary>
        ActivationMode ActivationMode { get; }
        
        /// <summary>
        /// Gets the docking pane style.
        /// </summary>
        DockingPaneStyle DockingPaneStyle { get; }

        /// <summary>
        /// Gets the docking pane anchor style.
        /// </summary>
        DockingPaneAnchorStyle DockingPaneAnchorStyle { get; }

        /// <summary>
        /// Gets the context change kind.
        /// </summary>
        DockingContextChangeKind DockingContextChangeKind { get; }

        /// <summary>
        /// Gets whether this vm should only be hidden whenever its closed. Otherwise, the vm is removed.
        /// </summary>
        bool HideOnClose { get; }

        /// <summary>
        /// Initialization.
        /// </summary>
        void InitializeVM();

        /// <summary>
        /// Gets or sets whether this vm has been initialized or not.
        /// </summary>
        bool IsInitialized
        {
            get;
        }
    }
}