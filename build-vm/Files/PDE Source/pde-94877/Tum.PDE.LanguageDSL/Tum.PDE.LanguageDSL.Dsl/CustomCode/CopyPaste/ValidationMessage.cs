namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// Basic validation message.
    /// </summary>
    public class ValidationMessage : IValidationMessage
    {
        private ModelValidationViolationType violationType;
        private string description;
        private string messageId;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageId">Message Id.</param>
        /// <param name="violationType">Type of the violation.</param>
        /// <param name="description">Description of the violation.</param>
        public ValidationMessage(string messageId, ModelValidationViolationType violationType, string description)
        {
            this.messageId = messageId;
            if (System.String.IsNullOrEmpty(this.messageId) || System.String.IsNullOrWhiteSpace(this.messageId))
                this.messageId = "UnknownMessageId";

            this.violationType = violationType;
            this.description = description;
        }

        /// <summary>
        /// Gets the type of the violation.
        /// </summary>
        public ModelValidationViolationType Type
        {
            get { return this.violationType; }
        }

        /// <summary>
        /// Gets the description of the violation.
        /// </summary>
        public string Description
        {
            get { return this.description; }
        }


        /// <summary>
        /// Gets the MessageId of this validation message.
        /// </summary>
        public string MessageId
        {
            get { return this.messageId; }
        }
    }
}
