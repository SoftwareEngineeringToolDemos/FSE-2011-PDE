// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PleaseWaitWindow.xaml.cs" company="Catel development team">
//   Copyright (c) 2008 - 2011 Catel development team. All rights reserved.
// </copyright>
// <summary>
//   Please wait window to show a please wait window with the option to customize the text.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Tum.PDE.ToolFramework.Modeling.Visualization.Extensions;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Loaders
{
    /// <summary>
    /// Please wait window to show a please wait window with the option to customize the text.
    /// </summary>
    /// <remarks>
    /// Parts of this code comes from this blog: http://blogs.msdn.com/b/dwayneneed/archive/2007/04/26/multithreaded-ui-hostvisual.aspx
    /// </remarks>
    public partial class PleaseWaitWindow
    {
        #region Variables    


        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        private Thread _thread;

        private readonly Storyboard _dimmStoryboard = new Storyboard();
        private const double DimmedValue = 0.75d;
        private readonly Storyboard _undimmStoryboard = new Storyboard();
        private const double UndimmedValue = 1d;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PleaseWaitWindow"/> class.
        /// </summary>
        public PleaseWaitWindow()
            : this("Please wait...") { }

        /// <summary>
        /// Initializes a please wait window with default text.
        /// </summary>
        /// <param name="text">Text to display in the window.</param>
        public PleaseWaitWindow(string text)
        {
            InitializeComponent();

            DoubleAnimation dimmAnimation = new DoubleAnimation(DimmedValue, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            dimmAnimation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("Opacity"));
            _dimmStoryboard.Children.Add(dimmAnimation);

            DoubleAnimation undimmAnimation = new DoubleAnimation(UndimmedValue, new Duration(new TimeSpan(0, 0, 0, 0, 200)));
            undimmAnimation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("Opacity"));
            _undimmStoryboard.Children.Add(undimmAnimation);

            _dimmStoryboard.Completed += delegate
            {
                IsOwnerDimmed = true;

                UpdateLayout();
            };
            _undimmStoryboard.Completed += delegate
            {
                IsOwnerDimmed = false;
                Owner.IsHitTestVisible = true;

                UpdateLayout();

                Close();
            };

            this.SetOwnerWindow();

            Loaded += OnLoaded;
            LayoutUpdated += OnLayoutUpdated;

            Text = text;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        /// <remarks>
        /// Wrapper for the Text dependency property.
        /// </remarks>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// DependencyProperty definition as the backing store for Text.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PleaseWaitWindow), new UIPropertyMetadata("Please wait..."));
        #endregion

        #region Methods
        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this <see cref="T:System.Windows.FrameworkElement"/> has been updated. The specific dependency property that changed is reported in the arguments parameter. Overrides <see cref="M:System.Windows.DependencyObject.OnPropertyChanged(System.Windows.DependencyPropertyChangedEventArgs)"/>.
        /// </summary>
        /// <param name="e">The event data that describes the property that changed, as well as old and new values.</param>
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name == VisibilityProperty.Name)
            {
                // Update the layout to prevent resizing while showing
                UpdateLayout();

                switch (Visibility)
                {
                    case Visibility.Visible:
                        if (Owner != null)
                        {
                            Left = (Owner.Left + (Owner.ActualWidth / 2)) - (ActualWidth / 2);
                            Top = (Owner.Top + (Owner.ActualHeight / 2)) - (ActualHeight / 2);
                        }

                        ChangeOwnerDimming(true);
                        break;

                    case Visibility.Hidden:
                    case Visibility.Collapsed:
                        ChangeOwnerDimming(false);
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dimmed.
        /// </summary>
        /// <value><c>true</c> if this instance is dimmed; otherwise, <c>false</c>.</value>
        public bool IsOwnerDimmed { get; private set; }

        /// <summary>
        /// Changes the owner dimming.
        /// </summary>
        /// <param name="dimm">if set to <c>true</c>, the owner should be dimmed.</param>
        private void ChangeOwnerDimming(bool dimm)
        {
            if (Owner != null)
            {
                Owner.IsHitTestVisible = false;
                Owner.BeginStoryboard(dimm ? _dimmStoryboard : _undimmStoryboard);
            }
        }

        /// <summary>
        /// Called when the window is loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            visualWrapper.Child = CreateMediaElementOnWorkerThread();
        }

        /// <summary>
        /// Called when the layout of the window is updated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.UpdateLayout();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            Loaded -= OnLoaded;
            LayoutUpdated -= OnLayoutUpdated;

            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }

            // Make sure we are not leaving the owner window dimmed in case a direct call to Close is invoked
            // instead of Hide
            if (Owner != null)
            {
                Owner.IsHitTestVisible = true;
                Owner.Opacity = 1d;

                Owner.Focus();
            }

            base.OnClosed(e);
        }

        /// <summary>
        /// Creates the media element on worker thread.
        /// </summary>
        /// <returns></returns>
        private HostVisual CreateMediaElementOnWorkerThread()
        {
            var hostVisual = new HostVisual();

            _thread = new Thread(MediaWorkerThread);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.IsBackground = true;
            _thread.Start(hostVisual);

            _autoResetEvent.WaitOne();

            return hostVisual;
        }

        /// <summary>
        /// Medias the worker thread.
        /// </summary>
        /// <param name="arg">The arg.</param>
        private static void MediaWorkerThread(object arg)
        {
            try
            {
                var hostVisual = (HostVisual)arg;
                var visualTargetPS = new VisualTargetPresentationSource(hostVisual);
                _autoResetEvent.Set();
                visualTargetPS.RootVisual = CreateMediaElement();
                Dispatcher.Run();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Creates the media element.
        /// </summary>
        /// <returns></returns>
        private static FrameworkElement CreateMediaElement()
        {
            return new LoaderAnimation { Width = 32, Height = 32 };
        }
        #endregion
    }

    /// <summary>
    /// PleaseWait window Helper class.
    /// </summary>
    public class PleaseWaitHelper
    {
        #region Variables       
        /// <summary>
        /// Please wait work delegate.
        /// </summary>
        public delegate void PleaseWaitWorkDelegate();

        private static PleaseWaitHelper _instance;
        private static readonly object _padlock = new object();

        private static readonly object _visibleStopwatchLock = new object();
        private static Stopwatch _visibleStopwatch;

        private string _currentStatusText = "Please wait...";
        private double _currentWindowWidth = 0.0d;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PleaseWaitHelper"/> class.
        /// </summary>
        private PleaseWaitHelper()
        {
            MinimumDurationBeforeShow = 500;
            MinimumShowTime = 1000;
        }
        #endregion

        #region Delegates
        /// <summary>
        /// Delegate that allows this class to re-invoke the HideWindow method.
        /// </summary>
        protected delegate void HideWindowDelegate();

        /// <summary>
        /// Delegate to update the status text of the <see cref="PleaseWaitWindow"/>.
        /// </summary>
        private delegate void UpdateStatusTextDelegate(string text, double windowWidth);
        #endregion

        #region Properties
        /// <summary>
        /// Gets the instance of this singleton class.
        /// </summary>
        protected static PleaseWaitHelper Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new PleaseWaitHelper();
                    }

                    return _instance;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="PleaseWaitWindow"/> instance.
        /// </summary>
        private PleaseWaitWindow PleaseWaitWindow { get; set; }

        /// <summary>
        /// Gets or sets the minimum duration in milliseconds that an operation must take before the window is actually shown.
        /// </summary>
        /// <value>The minimum duration in milliseconds that an operation must take before the window is actually shown.</value>
        public static int MinimumDurationBeforeShow { get; set; }

        /// <summary>
        /// Gets or sets the minimum show time in milliseconds.
        /// </summary>
        /// <value>The minimum show time in milliseconds.</value>
        public static int MinimumShowTime { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Shows the please wait window with the default status text.
        /// </summary>
        /// <remarks>
        /// When this method is used, the <see cref="Hide"/> method must be called to hide the window again.
        /// </remarks>
        public static void Show()
        {
            Show("Please wait..");
        }

        /// <summary>
        /// Shows the please wait window with the specified status text.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <remarks>
        /// When this method is used, the <see cref="Hide"/> method must be called to hide the window again.
        /// </remarks>
        public static void Show(string status)
        {
            UpdateStatus(status);

            Instance.ShowWindow();
        }

        /// <summary>
        /// Shows the please wait window with the default status text and executes the work delegate (in a background thread). When the work
        /// is finished, the please wait window will be automatically closed.
        /// </summary>
        /// <param name="workDelegate">The work delegate.</param>
        public static void Show(PleaseWaitWorkDelegate workDelegate)
        {
            Show(workDelegate, null, "Please wait...", double.NaN);
        }

        /// <summary>
        /// Shows the please wait window with the default status text and executes the work delegate (in a background thread). When the work
        /// is finished, the please wait window will be automatically closed. This method will also subscribe to the
        /// <see cref="BackgroundWorker.RunWorkerCompleted"/> event.
        /// </summary>
        /// <param name="workDelegate">The work delegate.</param>
        /// <param name="runWorkerCompletedDelegate">The run worker completed delegate.</param>
        public static void Show(PleaseWaitWorkDelegate workDelegate, RunWorkerCompletedEventHandler runWorkerCompletedDelegate)
        {
            Show(workDelegate, runWorkerCompletedDelegate, "Please wait...", double.NaN);
        }

        /// <summary>
        /// Shows the please wait window with the specified status text and executes the work delegate (in a background thread). When the work 
        /// is finished, the please wait window will be automatically closed.
        /// </summary>
        /// <param name="workDelegate">The work delegate.</param>
        /// <param name="status">The status.</param>
        public static void Show(PleaseWaitWorkDelegate workDelegate, string status)
        {
            Show(workDelegate, null, status, double.NaN);
        }

        /// <summary>
        /// Shows the please wait window with the specified status text and executes the work delegate (in a background thread). When the work 
        /// is finished, the please wait window will be automatically closed.
        /// </summary>
        /// <param name="workDelegate">The work delegate.</param>
        /// <param name="status">The status.</param>
        /// <param name="windowWidth">Width of the window.</param>
        public static void Show(PleaseWaitWorkDelegate workDelegate, string status, double windowWidth)
        {
            Show(workDelegate, null, status, windowWidth);
        }

        /// <summary>
        /// Shows the please wait window with the default status text and executes the work delegate (in a background thread). When the work
        /// is finished, the please wait window will be automatically closed. This method will also subscribe to the
        /// <see cref="BackgroundWorker.RunWorkerCompleted"/> event.
        /// </summary>
        /// <param name="workDelegate">The work delegate.</param>
        /// <param name="runWorkerCompletedDelegate">The run worker completed delegate.</param>
        /// <param name="status">The status.</param>
        /// <param name="windowWidth">Width of the window.</param>
        public static void Show(PleaseWaitWorkDelegate workDelegate, RunWorkerCompletedEventHandler runWorkerCompletedDelegate, string status, double windowWidth)
        {
            UpdateStatus(status, windowWidth);

            Instance.ShowWindow();

            if (workDelegate != null)
            {
                workDelegate();

                lock (_visibleStopwatchLock)
                {
                    // Make sure the window is shown for a minimum duration
                    int milliSecondsLeftToShow = 0;
                    if (_visibleStopwatch != null)
                    {
                        _visibleStopwatch.Stop();
                        milliSecondsLeftToShow = MinimumShowTime - (int)_visibleStopwatch.ElapsedMilliseconds;
                        _visibleStopwatch = null;
                    }

                    if (milliSecondsLeftToShow > 0)
                    {
                        Thread.Sleep(milliSecondsLeftToShow);
                    }
                }
            }

            if (runWorkerCompletedDelegate != null)
            {
                runWorkerCompletedDelegate(null, null);
            }

            Hide();
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="status">The status.</param>
        public static void UpdateStatus(string status)
        {
            Instance.UpdateStatusText(status, double.NaN);
        }

        /// <summary>
        /// Updates the status text.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="width">The width.</param>
        public static void UpdateStatus(string status, double width)
        {
            Instance.UpdateStatusText(status, width);
        }

        /// <summary>
        /// Hides the Please Wait window.
        /// </summary>
        public static void Hide()
        {
            Instance.HideWindow();
        }

        /// <summary>
        /// Updates the status text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="windowWidth">Width of the window.</param>
        private void UpdateStatusText(string text, double windowWidth)
        {
            _currentStatusText = text;
            _currentWindowWidth = windowWidth;

            if (PleaseWaitWindow == null)
            {
                return;
            }

            if (!PleaseWaitWindow.Dispatcher.CheckAccess())
            {
                PleaseWaitWindow.Dispatcher.Invoke(new UpdateStatusTextDelegate(UpdateStatusText), new object[] { text, windowWidth });
                return;
            }

            PleaseWaitWindow.Text = _currentStatusText;
            PleaseWaitWindow.MinWidth = double.IsNaN(_currentWindowWidth) ? 0d : _currentWindowWidth;
            PleaseWaitWindow.UpdateLayout();
        }

        /// <summary>
        /// Shows the window delayed by using the <see cref="MinimumDurationBeforeShow"/>.
        /// </summary>
        private void ShowWindow()
        {
            if (PleaseWaitWindow != null)
            {
                return;
            }

            PleaseWaitWindow = new PleaseWaitWindow();
            PleaseWaitWindow.Text = _currentStatusText;
            PleaseWaitWindow.MinWidth = double.IsNaN(_currentWindowWidth) ? 0d : _currentWindowWidth;
            
            PleaseWaitWindow.Show();

            while (!PleaseWaitWindow.IsOwnerDimmed)
            {
                // It's a bad practice to use this "equivalent" of DoEvents in WPF, but I don't see another choice
                // to wait until the animation of the ShowWindow has finished without blocking the UI
                PleaseWaitWindow.Dispatcher.Invoke(DispatcherPriority.Background, (ThreadStart)delegate { });
                PleaseWaitWindow.UpdateLayout();
            }

            lock (_visibleStopwatchLock)
            {
                if (_visibleStopwatch == null)
                {
                    _visibleStopwatch = new Stopwatch();
                    _visibleStopwatch.Start();
                }
                else
                {
                    _visibleStopwatch.Reset();
                    _visibleStopwatch.Start();
                }
            }
        }

        /// <summary>
        /// Hides the window.
        /// </summary>
        private void HideWindow()
        {
            if (PleaseWaitWindow == null)
            {
                return;
            }

            if (!PleaseWaitWindow.Dispatcher.CheckAccess())
            {
                PleaseWaitWindow.Dispatcher.Invoke((HideWindowDelegate)HideWindow, new object[] { });
                return;
            }


            // Hide the window, this will start the animation to undimm the parent and then the please wait window
            // will close itself
            PleaseWaitWindow.Hide();
            PleaseWaitWindow = null;

            _currentStatusText = "Please wait...";
            _currentWindowWidth = 0d;
        }
        #endregion
    }
}