using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Context for validating model elements. The constructor will take a collection
    /// of model elements intended to be validated.  Once the validaiton is done,
    /// the validation message will be staged in the CurrentViolations property.
    /// </summary>
    public class ModelValidationContext
    {
        ModelValidationCategories categories;
        private List<ModelElement> subjects;
        private List<IValidationMessage> collectedViolations;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="categories">Categories.</param>
        /// <param name="subjects">Elements to be validated.</param>
        public ModelValidationContext(ModelValidationCategories categories, IEnumerable<ModelElement> subjects)
        {
            
            this.subjects = new List<ModelElement>(subjects);
            this.categories = categories;
            this.collectedViolations = new List<IValidationMessage>();
        }

        /// <summary>
        /// Gets the validation categories.
        /// </summary>
        public ModelValidationCategories Categories
        {
            get
            {
                return categories;
            }
        }

        /// <summary>
        /// Gets the collected violations.
        /// </summary>
        public List<IValidationMessage> CollectedViolations
        {
            get
            {
                return collectedViolations;
            }
        }

        /// <summary>
        /// Gets the read-only collection of the elements, that are beeing validated.
        /// </summary>
        public ReadOnlyCollection<ModelElement> ValidationSubjects
        {
            get
            {
                return subjects.AsReadOnly();
            }
        }

        /// <summary>
        /// Adds a new validation message.
        /// </summary>
        /// <param name="message">Validation message to be added.</param>
        public void AddMessage(IValidationMessage message)
        {
            this.collectedViolations.Add(message);
        }
    }
}
