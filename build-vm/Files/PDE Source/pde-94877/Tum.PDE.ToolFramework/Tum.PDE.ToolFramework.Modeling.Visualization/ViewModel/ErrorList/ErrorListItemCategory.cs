using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// Represents a collection of values that identify types or severity of error
    /// messages that can appear in the Error List.
    /// </summary>
    [Flags]
    public enum ErrorListItemCategory
    {
        /// <summary>
        /// Represents an error.
        /// </summary>
        Error = 1,

        /// <summary>
        /// Represents a warning.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Represents an informational note.
        /// </summary>
        Message = 4,

        /// <summary>
        /// Represents an fatal error.
        /// </summary>
        Fatal = 8,
    }
}
