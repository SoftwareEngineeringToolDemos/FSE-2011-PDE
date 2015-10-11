﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services
{
    /// <summary>
    /// This interface defines a UI controller which can be used to display dialogs
    /// in either modal or modaless form from a ViewModel.
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public interface IUIVisualizerService
    {
        /// <summary>
        /// Registers a type through a key.
        /// </summary>
        /// <param name="key">Key for the UI dialog</param>
        /// <param name="winType">Type which implements dialog</param>
        void Register(string key, Type winType);

        /// <summary>
        /// Registers a type through a key. If a given key already exists, no action is taken.
        /// </summary>
        /// <param name="key">Key for the UI dialog</param>
        /// <param name="winType">Type which implements dialog</param>
        /// <returns>True if the registration succeeded. False otherwise.</returns>
        bool TryRegister(string key, Type winType);

        /// <summary>
        /// This unregisters a type and removes it from the mapping
        /// </summary>
        /// <param name="key">Key to remove</param>
        /// <returns>True/False success</returns>
        bool Unregister(string key);

        /// <summary>
        /// This method displays a modaless dialog associated with the given key.
        /// </summary>
        /// <param name="key">Key previously registered with the UI controller.</param>
        /// <param name="state">Object state to associate with the dialog</param>
        /// <param name="setOwner">Set the owner of the window</param>
        /// <param name="completedProc">Callback used when UI closes (may be null)</param>
        /// <returns>True/False if UI is displayed</returns>
        bool Show(string key, object state, bool setOwner,
            EventHandler<UICompletedEventArgs> completedProc);

        /// <summary>
        /// This method displays a modal dialog associated with the given key.
        /// </summary>
        /// <param name="key">Key previously registered with the UI controller.</param>
        /// <param name="state">Object state to associate with the dialog</param>
        /// <returns>True/False if UI is displayed.</returns>
        bool? ShowDialog(string key, object state);
    }
}
