using System;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// Represents a collection of values that identify types or severity of error
    /// messages that can appear in the Error List.
    /// </summary>
    [Flags]
    public enum ModelValidationViolationType
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
