namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes a class that can be validated.
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Gets the result of the validation.
        /// </summary>
        IValidationResult ValidationResult { get; }

        /// <summary>
        /// Method to start validation.
        /// </summary>
        void Validate();
    }
}
