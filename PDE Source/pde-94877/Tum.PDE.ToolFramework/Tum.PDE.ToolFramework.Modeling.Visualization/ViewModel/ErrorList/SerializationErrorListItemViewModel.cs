using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// This is the error list item view model for an serialization error. As such, the source should be
    /// the file and line and column numbers.
    /// </summary>
    public class SerializationErrorListItemViewModel : FilterableErrorListItemViewModel
    {
        private SerializationMessage serializationMessage;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationMessage">Serialization message.</param>
        public SerializationErrorListItemViewModel(ViewModelStore viewModelStore, SerializationMessage serializationMessage)
            : base(viewModelStore, serializationMessage.MessageId, ModelErrorListItemViewModel.ConvertCategory(serializationMessage.Type), serializationMessage.Description)
        {
            this.serializationMessage = serializationMessage;

            this.SourceDisplayName = serializationMessage.Source + " - Line: " + serializationMessage.Line.ToString() + " , Column: " + serializationMessage.Column;
        }

        /// <summary>
        /// Navigate to source. In this case, just display message box.
        /// </summary>
        public override void Navigate()
        {
            // nothing special for now, maybe later...
            IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
            messageBox.ShowInformation(this.serializationMessage.Source);
        }

        /// <summary>
        /// This method provides an unique id for the current model item.
        /// </summary>
        /// <returns></returns>
        public override string GetUniqueId()
        {
            return this.ErrorId;
        }
    }
}
