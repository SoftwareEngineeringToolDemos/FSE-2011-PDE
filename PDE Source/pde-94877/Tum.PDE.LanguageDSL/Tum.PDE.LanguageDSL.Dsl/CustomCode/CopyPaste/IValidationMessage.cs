namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// This interface describes a validation message.
    /// </summary>
    public interface IValidationMessage
    {
        /// <summary>
        /// Description of the message.
        /// </summary>
        string Description {get;} 

        /// <summary>
        /// Identification of the message.
        /// </summary>
        string MessageId { get; } 

        /// <summary>
        /// Violation type of the message.
        /// </summary>
        ModelValidationViolationType Type { get; } 

    }
}
