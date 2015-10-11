using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// This is the error list item view model for an model element error. This is
    /// for instance used during automatic validation to notify the error list of
    /// new errors.
    /// </summary>
    public class ModelErrorListItemViewModel : FilterableErrorListItemViewModel
    {
        private ModelValidationMessage message;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="message">Message from the model.</param>
        public ModelErrorListItemViewModel(ViewModelStore viewModelStore, ModelValidationMessage message)
            : base(viewModelStore, message.MessageId, ConvertCategory(message.Type), message.Description)
        {
            this.message = message;

            if (message.Source is IDomainModelOwnable)
            {
                if ((message.Source as IDomainModelOwnable).DomainElementHasName)
                {
                    this.SourceDisplayName = (message.Source as IDomainModelOwnable).DomainElementName;
                    
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.GetNamePropertyInfo(message.Source);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, message.Source.Id, OnNamePropertyChanged);
                }
                else
                {
                    this.SourceDisplayName = (message.Source as IDomainModelOwnable).DomainElementTypeDisplayName;
                }
            }

            /*
            if (this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.HasName(message.Source))
            {
                this.SourceDisplayName = this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.GetName(message.Source);

                DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.GetNamePropertyInfo(message.Source);
                this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, message.Source.Id, OnNamePropertyChanged);
            }
            else
                this.SourceDisplayName = this.ViewModelStore.GetDomainModelServices(message.Source).ElementTypeProvider.GetTypeDisplayName(message.Source);
            */

            this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(message.Source.Id, OnElementDeleted);
        }
        private void OnNamePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            this.SourceDisplayName = this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.GetName(message.Source);
        }
        private void OnElementDeleted(ElementDeletedEventArgs args)
        {
            this.ViewModelStore.EventManager.GetEvent<ErrorListRemoveItem>().Publish(this.Id);
        }

        /// <summary>
        /// Gets the source of the error.
        /// </summary>
        public ModelElement Source
        {
            get { return message.Source; }
        }

        /// <summary>
        /// This method provides an unique id for the current model item.
        /// </summary>
        /// <returns></returns>
        public override string GetUniqueId()
        {
            return this.ErrorId + "_" + message.Source.Id.ToString();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (message.Source is IDomainModelOwnable)
                if ((message.Source as IDomainModelOwnable).DomainElementHasName)
                {
                    try
                    {
                        DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(message.Source).ElementNameProvider.GetNamePropertyInfo(message.Source);
                        this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(info, message.Source.Id, OnNamePropertyChanged);
                    }
                    catch{}
                }

            this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(message.Source.Id, OnElementDeleted);

            this.message = null;

            base.OnDispose();
        }

        /// <summary>
        /// Navigate to model element
        /// </summary>
        public override void Navigate()
        {
            if( this.Source == null )
                return;
            if( this.Source.IsDeleted || this.Source.IsDeleting )
                return;

            SelectedItemsCollection col = new SelectedItemsCollection();
            col.Add(Source);

            // notify observers, that selection has changed
            this.EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
        }

        /// <summary>
        /// Converts a model violation type to an error list item category.
        /// </summary>
        /// <param name="kind">Violation type to convert.</param>
        /// <returns>Error list item category that is corresponding to the violation type.</returns>
        public static ErrorListItemCategory ConvertCategory(ModelValidationViolationType kind)
        {
            if (kind == ModelValidationViolationType.Error)
                return ErrorListItemCategory.Error;
            else if (kind == ModelValidationViolationType.Fatal)
                return ErrorListItemCategory.Fatal;
            else if (kind == ModelValidationViolationType.Message)
                return ErrorListItemCategory.Message;
            else
                return ErrorListItemCategory.Warning;
        }
    }
}
