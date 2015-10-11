using System.Collections;
using System.Collections.Generic;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    /// <summary>
    /// Class to store error, warning and information messages.
    /// </summary>
    public class ValidationResult : IValidationResult, IEnumerable<IValidationMessage>, IEnumerable
    {
        /// <summary>
        /// List of messages.
        /// </summary>
        protected List<IValidationMessage> messages;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ValidationResult()
        {
            messages = new List<IValidationMessage>();
        }

        /// <summary>
        /// Gets an enumerator that enumerates all stored messages.
        /// </summary>
        /// <returns>An enumerator that enumerates all stored messages.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator that enumerates all stored messages.
        /// </summary>
        /// <returns>An enumerator that enumerates all stored messages.</returns>
        public IEnumerator<IValidationMessage> GetEnumerator()
        {
            return messages.GetEnumerator();
        }

        /// <summary>
        /// Add a message.
        /// </summary>
        /// <param name="message">Message to add.</param>
        public virtual void AddMessage(IValidationMessage message)
        {
            if (message == null)
                throw new System.ArgumentNullException("message");

            messages.Add(message);
        }
    }
}
