using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace Tum.PDE.ToolFramework.Modeling
{    
    /// <summary>
    /// This class represents a base model context.
    /// </summary>
    public abstract class BaseModelContext : INotifyPropertyChanged
    {
        private ModelData modelData;
        private List<IValidationMessage> validationResult;


        /// <summary>
        /// Gets the model context id.
        /// </summary>
        public abstract System.Guid ModelContextId
        {
            get;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public BaseModelContext(ModelData modelData)
        {
            this.modelData = modelData;
            validationResult = new List<IValidationMessage>();
        }

        /// <summary>
        /// Gets the model data this context belongs to.
        /// </summary>
        public ModelData ModelData
        {
            get
            {
                return this.modelData;
            }
        }

        /// <summary>
        /// Gets the name of this model context.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the titel of the model context.
        /// </summary>
        public abstract string Titel
        {
            get;
        }

        /// <summary>
        /// Gets whether this model context is the default context or not.
        /// </summary>
        public abstract bool IsDefault
        {
            get;
        }

        /// <summary>
        /// Gets the current validation controller.
        /// </summary>
        public abstract ModelValidationController CurrentValidationController { get; }

        /// <summary>
        /// Gets the validation result.
        /// </summary>
        public ReadOnlyCollection<IValidationMessage> ValidationResult
        {
            get
            {
                return this.validationResult.AsReadOnly();
            }
        }

        /// <summary>
        /// Validates the whole store.
        /// </summary>
        /// <returns>
        /// Collection of gathered errors, warnings and information messages.
        /// </returns>
        public List<IValidationMessage> ValidateAll()
        {
            this.CurrentValidationController.ClearMessages();
            this.CurrentValidationController.Validate(this.ModelData.Store, ModelValidationCategories.Menu);

            List<IValidationMessage> messages = new List<IValidationMessage>();
            messages.AddRange(this.CurrentValidationController.FatalMessages);
            messages.AddRange(this.CurrentValidationController.ErrorMessages);
            messages.AddRange(this.CurrentValidationController.WarningMessages);
            messages.AddRange(this.CurrentValidationController.InformationalMessages);

            this.validationResult = messages;

            return messages;
        }

        /// <summary>
        /// Validates the given model element.
        /// </summary>
        /// <param name="element">ModelElement to be validated.</param>
        public List<IValidationMessage> Validate(Microsoft.VisualStudio.Modeling.ModelElement element)
        {
            this.CurrentValidationController.ClearMessages();
            this.CurrentValidationController.Validate(element, ModelValidationCategories.Menu);

            List<IValidationMessage> messages = new List<IValidationMessage>();
            messages.AddRange(this.CurrentValidationController.FatalMessages);
            messages.AddRange(this.CurrentValidationController.ErrorMessages);
            messages.AddRange(this.CurrentValidationController.WarningMessages);
            messages.AddRange(this.CurrentValidationController.InformationalMessages);

            this.validationResult = messages;

            return messages;
        }

        /// <summary>
        /// Resets the current document data.
        /// </summary>
        public virtual void Reset()
        {
            this.validationResult.Clear();
        }

        /// <summary>
        /// Called whever a transaction is commited.
        /// </summary>
        /// <param name="e"></param>
        public virtual void TransactionCommited(Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs e)
        {
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property's value changed.
        /// </summary>
        /// <param name="name">Name of the property changed.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
