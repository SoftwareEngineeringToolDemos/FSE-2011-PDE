﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2011 Catel development team. All rights reserved.
// </copyright>
// <summary>
//   Extensions for <see cref="System.Windows.Window" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// SOURCE: CATEL..
namespace Tum.PDE.ToolFramework.Modeling.Visualization.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;

    /// <summary>
    /// Extensions for <see cref="System.Windows.Window"/>.
    /// </summary>
    public static class WindowExtensions
    {
        #region Win32
        /// <summary>
        /// Extended windows styles.
        /// </summary>
        private const int GWL_EXSTYLE = -20;

        /// <summary>
        /// Window styles.
        /// </summary>
        private const int GWL_STYLE = -16;

        /// <summary>
        /// Shows or hides a system menu.
        /// </summary>
        private const int WS_SYSMENU = 0x80000;

        const int WS_EX_DLGMODALFRAME = 0x0001;

        const int SWP_NOSIZE = 0x0001;

        const int SWP_NOMOVE = 0x0002;

        const int SWP_NOZORDER = 0x0004;

        const int SWP_FRAMECHANGED = 0x0020;

        const uint WM_SETICON = 0x0080;

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        /// <summary>
        /// RECT struct for platform invokation.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// Left.
            /// </summary>
            public int Left;

            /// <summary>
            /// Top.
            /// </summary>
            public int Top;

            /// <summary>
            /// Right.
            /// </summary>
            public int Right;

            /// <summary>
            /// Bottom.
            /// </summary>
            public int Bottom;
        }
        #endregion

        #region Current process main window
        /// <summary>
        /// Sets the owner window to the main window of the current process.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        public static void SetOwnerWindow(this Window window)
        {
            // First, try to get the main window
            if ((Application.Current != null) && (Application.Current.MainWindow != null))
            {
                // Set by main window
                SetOwnerWindowByWindow(window, Application.Current.MainWindow, false, false);
            }
            else
            {
                // Set by process main window handle
                SetOwnerWindowByHandle(window, GetProcessMainWindowHandle(), false, false);
            }
        }

        /// <summary>
        /// Sets the owner window to the main window of the current process, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        public static void SetOwnerWindowAndFocus(this Window window)
        {
            // First, try to get the main window
            if ((Application.Current != null) && (Application.Current.MainWindow != null) && Application.Current.MainWindow.IsVisible)
            {
                // Set by main window
                SetOwnerWindowByWindow(window, Application.Current.MainWindow, false, true);
            }
            else
            {
                // Set by process main window handle
                SetOwnerWindowByHandle(window, GetProcessMainWindowHandle(), false, true);
            }
        }

        /// <summary>
        /// Sets the owner window to the main window of the current process.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindow(this Window window, bool forceNewOwner)
        {
            // First, try to get the main window
            if ((Application.Current != null) && (Application.Current.MainWindow != null))
            {
                // Set by main window
                SetOwnerWindowByWindow(window, Application.Current.MainWindow, forceNewOwner, false);
            }
            else
            {
                // Set by process main window handle
                SetOwnerWindowByHandle(window, GetProcessMainWindowHandle(), forceNewOwner, false);
            }
        }

        /// <summary>
        /// Sets the owner window to the main window of the current process, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindowAndFocus(this Window window, bool forceNewOwner)
        {
            // First, try to get the main window
            if ((Application.Current != null) && (Application.Current.MainWindow != null))
            {
                // Set by main window
                SetOwnerWindowByWindow(window, Application.Current.MainWindow, forceNewOwner, true);
            }
            else
            {
                // Set by process main window handle
                SetOwnerWindowByHandle(window, GetProcessMainWindowHandle(), forceNewOwner, true);
            }
        }
        #endregion

        #region Specific window - Window
        /// <summary>
        /// Sets the owner window of a specific window via the Window class.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        public static void SetOwnerWindow(this Window window, Window owner)
        {
            SetOwnerWindowByWindow(window, owner, false, false);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the Window class, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        public static void SetOwnerWindowAndFocus(this Window window, Window owner)
        {
            SetOwnerWindowByWindow(window, owner, false, true);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the Window class.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindow(this Window window, Window owner, bool forceNewOwner)
        {
            SetOwnerWindowByWindow(window, owner, forceNewOwner, false);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the Window class, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindowAndFocus(this Window window, Window owner, bool forceNewOwner)
        {
            SetOwnerWindowByWindow(window, owner, forceNewOwner, true);
        }

        /// <summary>
        /// Sets the owner window of a specific window.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        /// <param name="focusFirstControl">If true, the first control will automatically be focused.</param>
        private static void SetOwnerWindowByWindow(Window window, Window owner, bool forceNewOwner, bool focusFirstControl)
        {
            SetOwnerWindow(window, owner, IntPtr.Zero, forceNewOwner, focusFirstControl);
        }
        #endregion

        #region Specific window - IntPtr
        /// <summary>
        /// Sets the owner window of a specific window via the window handle.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        public static void SetOwnerWindow(this Window window, IntPtr owner)
        {
            SetOwnerWindowByHandle(window, owner, false, false);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the window handle, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        public static void SetOwnerWindowAndFocus(this Window window, IntPtr owner)
        {
            SetOwnerWindowByHandle(window, owner, false, true);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the window handle.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindow(this Window window, IntPtr owner, bool forceNewOwner)
        {
            SetOwnerWindowByHandle(window, owner, forceNewOwner, false);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the window handle, but
        /// also sets the focus on the first control.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        public static void SetOwnerWindowAndFocus(this Window window, IntPtr owner, bool forceNewOwner)
        {
            SetOwnerWindowByHandle(window, owner, forceNewOwner, true);
        }

        /// <summary>
        /// Sets the owner window of a specific window via the window handle.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="owner">New owner window.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        /// <param name="focusFirstControl">If true, the first control will automatically be focused.</param>
        private static void SetOwnerWindowByHandle(Window window, IntPtr owner, bool forceNewOwner, bool focusFirstControl)
        {
            SetOwnerWindow(window, null, owner, forceNewOwner, focusFirstControl);
        }
        #endregion

        /// <summary>
        /// Brings to specified window to top.
        /// </summary>
        /// <param name="window">The window to bring to top.</param>
        /// <exception cref="ArgumentNullException">when <paramref name="window"/> is <c>null</c>.</exception>
        public static void BringWindowToTop(this Window window)
        {

            WindowInteropHelper interopHelper = new WindowInteropHelper(window);
            BringWindowToTop(interopHelper.Handle);
        }

        /// <summary>
        /// Sets the owner window of a specific window. It will first try to set the owner via
        /// the <paramref name="ownerWindow"/>. If the <paramref name="ownerWindow"/> is not available,
        /// this method will use the <paramref name="ownerHandle"/> to set the parent.
        /// </summary>
        /// <param name="window">Reference to the current window.</param>
        /// <param name="ownerWindow">New owner window.</param>
        /// <param name="ownerHandle">The owner handle.</param>
        /// <param name="forceNewOwner">If true, the new owner will be forced. Otherwise, if the
        /// window currently has an owner, that owner will be respected (and thus not changed).</param>
        /// <param name="focusFirstControl">If true, the first control will automatically be focused.</param>
        private static void SetOwnerWindow(Window window, Window ownerWindow, IntPtr ownerHandle, bool forceNewOwner, bool focusFirstControl)
        {
            if (focusFirstControl)
            {
                //window.FocusFirstControl();
            }

            if (!forceNewOwner && HasOwner(window))
            {
                return;
            }

            if (ownerWindow != null)
            {
                if (ownerWindow == window)
                {
                    return;
                }

                window.Owner = ownerWindow;
            }
            else
            {
                // Set owner via interop helper
                WindowInteropHelper interopHelper = new WindowInteropHelper(window);
                interopHelper.Owner = ownerHandle;

                // Get handler (so we can nicely unsubscribe)
                RoutedEventHandler onWindowLoaded = null;
                onWindowLoaded = delegate(object sender, RoutedEventArgs e)
                {
                    // Since this owner type doesn't support WindowStartupLocation.CenterOwner, do
                    // it manually
                    if (window.WindowStartupLocation == WindowStartupLocation.CenterOwner)
                    {
                        // Get the parent window rect
                        RECT ownerRect;
                        if (GetWindowRect(ownerHandle, out ownerRect))
                        {
                            // Get some additional information
                            int ownerWidth = ownerRect.Right - ownerRect.Left;
                            int ownerHeight = ownerRect.Bottom - ownerRect.Top;
                            int ownerHorizontalCenter = (ownerWidth / 2) + ownerRect.Left;
                            int ownerVerticalCenter = (ownerHeight / 2) + ownerRect.Top;

                            // Set the location to manual
                            window.WindowStartupLocation = WindowStartupLocation.Manual;

                            // Now we know the location of the parent, center the window
                            window.Left = ownerHorizontalCenter - (window.ActualWidth / 2);
                            window.Top = ownerVerticalCenter - (window.ActualHeight / 2);
                        }
                    }

                    ((Window)sender).Loaded -= onWindowLoaded;
                };

                window.Loaded += onWindowLoaded;
            }
        }

        /// <summary>
        /// Returns the main window handle of the current process.
        /// </summary>
        /// <returns>Handle of the main window of the current process.</returns>
        private static IntPtr GetProcessMainWindowHandle()
        {
            Process process = Process.GetCurrentProcess();
            var mainWindowHandle = process.MainWindowHandle;
            process.Dispose();

            return mainWindowHandle;
        }

        /// <summary>
        /// Returns whether the window currently has an owner.
        /// </summary>
        /// <param name="window">Window to check.</param>
        /// <returns>
        /// True if the window has an owner, otherwise false.
        /// </returns>
        private static bool HasOwner(Window window)
        {
            return ((window.Owner != null) || (new WindowInteropHelper(window).Owner != IntPtr.Zero));
        }

        /// <summary>
        /// Removes the icon from the window.
        /// </summary>
        /// <param name="window">The window.</param>
        public static void RemoveIcon(this Window window)
        {
            // Get the handle of the window
            IntPtr windowHandle = new WindowInteropHelper(window).Handle;

            // Send message to hide icon
            SendMessage(windowHandle, WM_SETICON, IntPtr.Zero, IntPtr.Zero);

            // Change the extended window style to not show a window icon
            int extendedStyle = GetWindowLong(windowHandle, GWL_EXSTYLE);

            // Update the window style
            SetWindowLong(windowHandle, GWL_EXSTYLE, extendedStyle | WS_EX_DLGMODALFRAME);

            // Update the window's non-client area to reflect the changes
            SetWindowPos(windowHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
        }
    }
}
