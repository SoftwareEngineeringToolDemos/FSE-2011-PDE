using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    /// <summary>
    /// Common interface for items that can be selected. It also specifies what data to propagate
    /// as beeing selected.
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// Gets or sets whether the control is selected or not.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets the selected data.
        /// </summary>
        object SelectedData { get; }
    }
}
