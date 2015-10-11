using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// ValidationMessage is used to carry validation messages. ValidationMessage are created from
    /// within user defined validation mehod.
    /// </summary>
    public class ModelValidationMessage : ValidationMessage
    {
        private ModelElement source;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageId">MessageId of this validation message.</param>
        /// <param name="violationType">Type of the violation.</param>
        /// <param name="description">Description of the violation.</param>
        /// <param name="source">Source element of the violation.</param>
        public ModelValidationMessage(string messageId, ModelValidationViolationType violationType, string description, ModelElement source)
            : base(messageId, violationType, description)
        {
            this.source = source;
        }

        /// <summary>
        /// Gets the source element of the violation.
        /// </summary>
        public ModelElement Source
        {
            get { return this.source; }
        }

    }
}
