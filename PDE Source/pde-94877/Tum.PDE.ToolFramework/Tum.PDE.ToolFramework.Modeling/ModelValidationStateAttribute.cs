namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Attribute class used to mark meta-classes. A valid meta-class should have both [MetaObject] and [MetaClass] defined.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ModelValidationStateAttribute : System.Attribute
    {
        private readonly ModelValidationState validationState;

        /// <summary>
        /// Gets the constraint validation flag for the meta-class custom attribute.
        /// </summary>
        public ModelValidationState ValidationState
        {
            get
            {
                return validationState;
            }
        }

        /// <summary>
        /// Initializes a new instance of ValidationStateAttribute class.
        /// </summary>
        /// <param name="validationState">Constraint validation behavior flag.</param>
        public ModelValidationStateAttribute(ModelValidationState validationState)
        {
            this.validationState = validationState;
        }
    }
}

