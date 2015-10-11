using System;
using System.Windows.Input;

// SOURCE: Cinch framework by Sacha Barber

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI
{
    /// <summary>
    /// This class implements a disposable WaitCursor to 
    /// show an hourglass while some long-running event occurs.
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// 
    /// using (new WaitCursor())
    /// {
    ///    .. Do work here ..
    /// }
    /// 
    /// ]]>
    /// </example>
    public class WaitCursor : IDisposable
    {
        #region Data
        private readonly Cursor oldCursor;
        #endregion

        #region Ctor
        /// <summary>
        /// Constructor
        /// </summary>
        public WaitCursor()
        {
            oldCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns the cursor to the default state.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Mouse.OverrideCursor = oldCursor;
            }
        }

        #endregion
    }
}
