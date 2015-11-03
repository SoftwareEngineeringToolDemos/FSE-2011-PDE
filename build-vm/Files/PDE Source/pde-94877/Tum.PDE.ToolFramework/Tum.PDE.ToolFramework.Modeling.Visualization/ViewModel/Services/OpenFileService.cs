using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services
{
    /// <summary>
    /// This class implements the IOpenFileService for WPF purposes.
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public class OpenFileService : IOpenFileService
    {
        /// <summary>
        /// Embedded OpenFileDialog to pass back correctly selected
        /// values to ViewModel
        /// </summary>
        private OpenFileDialog ofd = new OpenFileDialog();

        #region IOpenFileService Members
        /// <summary>
        /// This method should show a window that allows a file to be selected
        /// </summary>
        /// <param name="owner">The owner window of the dialog</param>
        /// <returns>A bool from the ShowDialog call</returns>
        public bool? ShowDialog(Window owner)
        {
            //Set embedded OpenFileDialog.Filter
            if (!String.IsNullOrEmpty(this.Filter))
                ofd.Filter = this.Filter;

            //Set embedded OpenFileDialog.InitialDirectory
            if (!String.IsNullOrEmpty(this.InitialDirectory))
                ofd.InitialDirectory = this.InitialDirectory;

            //return results
            return ofd.ShowDialog(owner);
        }

        /// <summary>
        /// FileName : Simply use embedded OpenFileDialog.FileName
        /// But DO NOT allow a Set as it will ONLY come from user
        /// picking a file
        /// </summary>
        public string FileName
        {
            get { return ofd.FileName; }
            set
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Filter : Simply use embedded OpenFileDialog.Filter
        /// </summary>
        public string Filter
        {
            get { return ofd.Filter; }
            set { ofd.Filter = value; }
        }

        /// <summary>
        /// Filter : Simply use embedded OpenFileDialog.InitialDirectory
        /// </summary>
        public string InitialDirectory
        {
            get { return ofd.InitialDirectory; }
            set { ofd.InitialDirectory = value; }
        }

        #endregion
    }
}
