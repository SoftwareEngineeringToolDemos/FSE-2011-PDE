using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// CultureInfo changed event arguments.
    /// </summary>
    public class CultureInfoChangedEventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="oldCultureInfo">Old CultureInfo.</param>
        /// <param name="newCultureInfo">New CultureInfo.</param>
        public CultureInfoChangedEventArgs(CultureInfo oldCultureInfo, CultureInfo newCultureInfo)
        {
            this.OldCultureInfo = oldCultureInfo;
            this.NewCultureInfo = newCultureInfo;
        }

        /// <summary>
        /// Old culture info.
        /// </summary>
        public CultureInfo OldCultureInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// New culture info.
        /// </summary>
        public CultureInfo NewCultureInfo
        {
            get;
            private set;
        }
    }
}
