using System;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Flavor of the validaton categories.
    /// </summary>
    [Flags]
    public enum ModelValidationCategories
    {
        /// <summary>
        /// Validation method to be invoked when user choose from the menu
        /// </summary>
        Menu = 1,
        
        /// <summary>
        /// Validation method to be invoked when file is opened
        /// </summary>
        Open = 2,
        
        /// <summary>
        /// Validation method to be invoked when file is closed
        /// </summary>
        Save = 4
    }
}
