using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This class is used to navigate forward and back. The "navigation" itself is simulated via
    /// selection events.
    /// </summary>
    public class NavigationManager
    {
        private ViewModelStore viewModelStore;
        private List<SelectedItemsCollection> currentHistory;
        private int currentHistoryIndex;

        private const string NavigationManagerIdentifier = "NavigationManagerIdentifiedID";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="store">View model store containing the event manager used to subscribe and publish selection events.</param>
        public NavigationManager(ViewModelStore store)
        {
            this.viewModelStore = store;
            this.currentHistory = new List<SelectedItemsCollection>();
            this.currentHistoryIndex = -1;

            // subscribe to selection event
            this.viewModelStore.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        private void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.UserData != null)
                if (eventArgs.UserData as string == NavigationManagerIdentifier)
                    return;

            // remove all elements after current history index
            currentHistory.RemoveRange(currentHistoryIndex + 1, currentHistory.Count - (currentHistoryIndex + 1));

            currentHistory.Add(eventArgs.SelectedItems);
            currentHistoryIndex++;
        }

        /// <summary>
        /// Navigates forward.
        /// </summary>
        public void NavigateForward()
        {
            if (currentHistoryIndex < currentHistory.Count && currentHistoryIndex >= 0)
            {
                // verify that none of the elements are in deleted state
                for (int i = currentHistoryIndex + 1; i < currentHistory.Count; i++)
                {
                    bool isDeleted = false;
                    SelectedItemsCollection col = currentHistory[i];
                    foreach (ModelElement m in col)
                        if (m.IsDeleted || m.IsDeleting)
                        {
                            isDeleted = true;
                            break;
                        }

                    if (!isDeleted)
                    {
                        SelectionChangedEventArgs args = new SelectionChangedEventArgs(null, col);
                        args.UserData = NavigationManagerIdentifier;
                        this.viewModelStore.EventManager.GetEvent<SelectionChangedEvent>().Publish(args);

                        currentHistoryIndex++;

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method to verify if navigation can occur. 
        /// </summary>
        /// <returns>True if navigation can occur. False otherwise.</returns>
        public bool CanNavigateForward()
        {
            if (currentHistoryIndex < currentHistory.Count && currentHistoryIndex >= 0)
            {
                // verify that none of the elements are in deleted state
                for (int i = currentHistoryIndex + 1; i < currentHistory.Count; i++)
                {
                    bool isDeleted = false;
                    SelectedItemsCollection col = currentHistory[i];
                    foreach(ModelElement m in col )
                        if (m.IsDeleted || m.IsDeleting)
                        {
                            isDeleted = true;
                            break;
                        }

                    if (!isDeleted)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Navigates backward.
        /// </summary>
        public void NavigateBackward()
        {
            if (currentHistoryIndex < 0)
                return;

            // verify that none of the elements are in deleted state
            for (int i = currentHistoryIndex - 1; i >= 0; i--)
            {
                bool isDeleted = false;
                SelectedItemsCollection col = currentHistory[i];
                foreach (ModelElement m in col)
                    if (m.IsDeleted || m.IsDeleting)
                    {
                        isDeleted = true;
                        break;
                    }

                if (!isDeleted)
                {
                    SelectionChangedEventArgs args = new SelectionChangedEventArgs(null, col);
                    args.UserData = NavigationManagerIdentifier;
                    this.viewModelStore.EventManager.GetEvent<SelectionChangedEvent>().Publish(args);

                    currentHistoryIndex--;

                    return;
                }
            }
        }

        /// <summary>
        /// Method to verify if navigation can occur. 
        /// </summary>
        /// <returns>True if navigation can occur. False otherwise.</returns>
        public bool CanNavigateBackward()
        {
            if (this.currentHistory.Count == 1 && currentHistoryIndex < 0)
                return false;

            // verify that none of the elements are in deleted state
            for (int i = currentHistoryIndex - 1; i >= 0; i--)
            {
                bool isDeleted = false;
                SelectedItemsCollection col = currentHistory[i];
                foreach (ModelElement m in col)
                    if (m.IsDeleted || m.IsDeleting)
                    {
                        isDeleted = true;
                        break;
                    }

                if (!isDeleted)
                    return true;
            }
            

            return false;
        }

        /// <summary>
        /// Resets the navigation manager.
        /// </summary>
        public void Reset()
        {
            this.currentHistory.Clear();
            this.currentHistoryIndex = -1;
        }
    }
}
