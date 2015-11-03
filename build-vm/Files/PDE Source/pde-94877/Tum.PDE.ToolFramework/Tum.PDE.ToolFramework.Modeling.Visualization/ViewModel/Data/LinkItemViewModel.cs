using Tum.PDE.ToolFramework.Modeling.Base;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// This viewmodel is used to display LinkItems.
    /// </summary>
    public class LinkItemViewModel : BaseViewModel
    {
        private LinkItem linkItem;
        private DelegateCommand navigateCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="linkItem">Link item to be hosted by this view model.</param>
        public LinkItemViewModel(ViewModelStore viewModelStore, LinkItem linkItem)
            : base(viewModelStore)
        {
            this.linkItem = linkItem;
            this.navigateCommand = new DelegateCommand(NavigateCommand_Executed);
        }

        /// <summary>
        /// Gets the titel of the link item.
        /// </summary>
        public string Titel
        {
            get
            {
                return this.linkItem.Titel;
            }
        }

        /// <summary>
        /// Gets the description of the link item. Can be null or empty.
        /// </summary>
        public string Description
        {
            get
            {
                return this.linkItem.Description;
            }
        }

        /// <summary>
        /// Gets the link of the link item. Can be null or empty.
        /// </summary>
        public string Link
        {
            get
            {
                return this.linkItem.Link;
            }
        }

        /// <summary>
        /// Gets the category of the link item. Can be null or empty.
        /// </summary>
        public string Category
        {
            get
            {
                return this.linkItem.Category;
            }
        }

        /// <summary>
        /// Gets the navigate command.
        /// </summary>
        public DelegateCommand NavigateCommand
        {
            get
            {
                return this.navigateCommand;
            }
        }

        /// <summary>
        /// NavigateCommand executed.
        /// </summary>
        public void NavigateCommand_Executed()
        {
            if (!System.String.IsNullOrEmpty(this.Link) && !System.String.IsNullOrWhiteSpace(this.Link))
            {
                try
                {
                    System.Diagnostics.Process.Start(this.Link);
                }
                catch(System.Exception ex)
                {
                    IMessageBoxService msgBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                    msgBox.ShowError("Could not open link " + ex.Message);
                }
            }
        }
    }
}
