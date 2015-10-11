namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class definition for C# custom attribute ValidationMethod.  This is used for marking methnods as Validator functions.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
    public sealed class ModelValidationMethodAttribute : System.Attribute
    {
        private ModelValidationCategories categories;

        /// <summary>
        /// The categories of this method.
        /// </summary>
        public ModelValidationCategories Categories
        {
            get
            {
                return categories;
            }
        }
        /// <summary>
        /// Constructor for class ValidationMethodAttribute. Specifies Menu, Open and Save by default.
        /// </summary>
        public ModelValidationMethodAttribute()
        {
            categories = ModelValidationCategories.Menu | ModelValidationCategories.Open | ModelValidationCategories.Save;
        }

        /// <summary>
        /// Constructor for class ValidationMethodAttribute.
        /// </summary>
        /// <param name="categories">The categories of this method.</param>
        public ModelValidationMethodAttribute(ModelValidationCategories categories)
        {
            this.categories = categories;
        }

    } 
}
