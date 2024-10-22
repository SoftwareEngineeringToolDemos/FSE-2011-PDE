﻿using System;
using System.Windows.Threading;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading
{
    /// <summary>
    /// Provides a set of commonly used Dispatcher extension methods
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public static class DispatcherExtensions
    {
        /// <summary>
        /// A simple threading extension method, to invoke a delegate
        /// on the correct thread if it is not currently on the correct thread
        /// which can be used with DispatcherObject types.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher object on which to 
        /// perform the Invoke</param>
        /// <param name="action">The delegate to run</param>
        /// <param name="priority">The DispatcherPriority for the invoke.</param>
        public static void InvokeIfRequired(this Dispatcher dispatcher,
            Action action, DispatcherPriority priority)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.Invoke(priority, action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// A simple threading extension method, to invoke a delegate
        /// on the correct thread if it is not currently on the correct thread
        /// which can be used with DispatcherObject types.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher object on which to 
        /// perform the Invoke</param>
        /// <param name="action">The delegate to run</param>
        public static void InvokeIfRequired(this Dispatcher dispatcher, Action action)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.Invoke(DispatcherPriority.Normal, action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// A simple threading extension method, to invoke a delegate
        /// on the correct thread if it is not currently on the correct thread
        /// which can be used with DispatcherObject types.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher object on which to 
        /// perform the Invoke</param>
        /// <param name="action">The delegate to run</param>
        public static void InvokeInBackgroundIfRequired(
            this Dispatcher dispatcher,
            Action action)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.Invoke(DispatcherPriority.Background, action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// A simple threading extension method, to invoke a delegate
        /// on the correct thread asynchronously if it is not currently 
        /// on the correct thread which can be used with DispatcherObject types.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher object on which to 
        /// perform the Invoke</param>
        /// <param name="action">The delegate to run</param>
        public static void InvokeAsynchronouslyInBackground(
            this Dispatcher dispatcher, Action action)
        {
            if (dispatcher != null)
                dispatcher.BeginInvoke(DispatcherPriority.Background, action);
            else
                action();
        }
    }
}
