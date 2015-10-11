namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Collection of messages notifying of information gathered during serialization.
    /// </summary>
    public class SerializationResult : ValidationResult
    {
        private bool failed = false;

        /// <summary>
        /// Add a message.
        /// </summary>
        /// <param name="message">Message to add.</param>
        public virtual void AddMessage(SerializationMessage message)
        {
            if (message == null)
                throw new System.ArgumentNullException("message");

            base.messages.Add(message);
        }

        /// <summary>
        /// Gets or sets whether the serialization result has failed or not.
        /// </summary>
        public bool Failed
        {
            get { return failed; }
            set
            {
                failed = value;
            }
        }
    }
}
