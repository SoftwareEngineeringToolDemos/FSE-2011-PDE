using Tum.PDE.ToolFramework.Modeling.Visualization.Base.Commands;
using Tum.PDE.ToolFramework.Modeling.Base;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel
{
    /// <summary>
    /// This viewmodel is used to display LinkItems.
    /// </summary>
    public class LinkItemViewModel
    {
        private LinkItem linkItem;
        private DelegateCommand navigateCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="linkItem">Link item to be hosted by this view model.</param>
        public LinkItemViewModel(LinkItem linkItem)
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
                catch
                {
                    //IMessageBoxService msgBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                    //msgBox.ShowError("Could not open link " + ex.Message);
                }
            }
        }
    }
}
