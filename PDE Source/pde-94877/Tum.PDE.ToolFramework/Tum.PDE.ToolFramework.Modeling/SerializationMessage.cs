namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Message notifying of information gathered during serialization.
    /// </summary>
    public class SerializationMessage : ValidationMessage
    {
        string source;
        int line;
        int column;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageId">Message Id.</param>
        /// <param name="violationType">Type of the violation.</param>
        /// <param name="description">Description of the violation.</param>
        /// <param name="source"></param>
        /// <param name="line"></param>
        /// <param name="column"></param>
        public SerializationMessage(string messageId, ModelValidationViolationType violationType, string description, string source, int line, int column)
            : base(messageId, violationType, description)
        {
            this.source = source;
            this.line = line;
            this.column = column;
        }

        /// <summary>
        /// Source (e.g.: source file name).
        /// </summary>
        public string Source
        {
            get { return this.source; }
        }

        /// <summary>
        /// Line number.
        /// </summary>
        public int Line
        {
            get { return this.line; }
        }

        /// <summary>
        /// Column number.
        /// </summary>
        public int Column
        {
            get { return this.column; }
        }
    }
}
