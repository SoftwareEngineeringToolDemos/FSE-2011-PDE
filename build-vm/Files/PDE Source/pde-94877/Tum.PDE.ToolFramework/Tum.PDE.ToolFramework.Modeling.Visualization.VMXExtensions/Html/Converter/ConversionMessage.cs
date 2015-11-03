namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Converter
{
    /// <summary>
    /// Class used to represent an error or warning message, including message kind and message string.
    /// </summary>
    public class ConversionMessage : Tum.PDE.ToolFramework.Modeling.IValidationMessage
    {
        Tum.PDE.ToolFramework.Modeling.ModelValidationViolationType type;
        string description;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Kind of the message.</param>
        /// <param name="description">Message string.</param>
        public ConversionMessage(Tum.PDE.ToolFramework.Modeling.ModelValidationViolationType type, string description)
        {
            this.type = type;
            this.description = description;
        }

        /// <summary>
        /// Kind of the message.
        /// </summary>
        public Tum.PDE.ToolFramework.Modeling.ModelValidationViolationType Type
        {
            get
            {
                return type;
            }
        }
        //

        /// <summary>
        /// Message string.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Identification of the message.
        /// </summary>
        public string MessageId
        {
            get { return "HtmlConversionViolation"; }
        }
    }
}
