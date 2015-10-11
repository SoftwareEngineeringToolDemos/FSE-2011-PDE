using System;
using System.Windows;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Tum.PDE.ToolFramework.Modeling.Shell
{
    /// <summary>
    /// Tool window pane.
    /// </summary>
    public abstract class ModelToolWindowPane : ToolWindowPane, IVsWindowFrameNotify, IVsWindowFrameNotify2
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ModelToolWindowPane()
            : base()
        {
            this.Content = this.CreateControl();
        }

        /// <summary>
        /// Returns the control that should be used to display this pane's content.
        /// </summary>
        /// <returns></returns>
        public abstract FrameworkElement CreateControl();

        /// <summary>
        /// Gets or sets the content element.
        /// </summary>
        public new FrameworkElement Content
        {
            get
            {
                return base.Content as FrameworkElement;
            }
            set
            {
                base.Content = value;
            }
        }

        /// <summary>
        /// Fires after this pane has been closed.
        /// </summary>
        public event EventHandler PaneClosed;

        /// <summary>
        /// Callen after the pane has closed.
        /// </summary>
        /// <param name="e">Arguments.</param>
        protected void OnPaneClosed(EventArgs e)
        {
            if (this.PaneClosed != null)
                this.PaneClosed(this, e);
        }

        #region IVsWindowFrameNotify
        /// <summary>
        /// Notifies the VSPackage that a window's docked state is being altered.
        /// </summary>
        /// <param name="fDockable">True if the window frame is being docked.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnDockableChange(int fDockable)
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Notifies the VSPackage that a window is being moved.
        /// </summary>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnMove()
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Notifies the VSPackage of a change in the window's display state.
        /// </summary>
        /// <param name="fShow">Specifies the reason for the display state change. Value taken from the __FRAMESHOW enumeration.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnShow(int fShow)
        {
            switch (fShow)
            {

                case (int)__FRAMESHOW.FRAMESHOW_AutoHideSlideBegin:

                    break;

                case (int)__FRAMESHOW.FRAMESHOW_WinClosed:
                    //this.OnPaneClosed(new EventArgs());
                    
                    break;

                case (int)__FRAMESHOW.FRAMESHOW_WinShown:

                    break;

                case (int)__FRAMESHOW.FRAMESHOW_WinHidden:
                    //this.OnPaneClosed(new EventArgs());

                    break;

                default:

                    break;

            }
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Notifies the VSPackage that a window is being resized.
        /// </summary>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnSize()
        {
            return VSConstants.S_OK;
        }
        #endregion

        /// <summary>
        /// Notifies the VSPackage that a window frame is closing and tells the environment what action to take.
        /// </summary>
        /// <param name="pgrfSaveOptions">Specifies options for saving window content. Values are taken from the __FRAMECLOSE enumeration.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public int OnClose(ref uint pgrfSaveOptions)
        {
            this.OnPaneClosed(new EventArgs());

            return VSConstants.S_OK;
        }
    }
}
