using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList
{
    /// <summary>
    /// This is the base view model class for a error list item.
    /// </summary>
    public abstract class BaseErrorListItemViewModel : BaseViewModel
    {
        private ErrorListItemCategory category;
        private string description;
        private int errorNumber = 0;
        private string sourceDisplayName;

        private DelegateCommand navigationCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="category">Error category of the error.</param>
        /// <param name="description">Description explaining why the error occured.</param>
        protected BaseErrorListItemViewModel(ViewModelStore viewModelStore, ErrorListItemCategory category, string description)
            : base(viewModelStore)
        {
            this.category = category;
            this.description = description;

            this.navigationCommand = new DelegateCommand(NavigationCommand_Executed);
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="description">Description explaining why the error occured.</param>
        protected BaseErrorListItemViewModel(ViewModelStore viewModelStore, string description)
            : this(viewModelStore, ErrorListItemCategory.Error, description)
        {
        }

        /// <summary>
        /// Gets or sets the error category.
        /// </summary>
        public ErrorListItemCategory Category
        {
            get { return this.category; }
            set
            {
                this.category = value;
                OnPropertyChanged("Category");
            }
        }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the number of this error in the error list.
        /// </summary>
        public int Number
        {
            get
            {
                return errorNumber;
            }
            set
            {
                errorNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the source display name.
        /// </summary>
        public string SourceDisplayName
        {
            get
            {
                return sourceDisplayName;
            }
            set
            {
                sourceDisplayName = value;
                OnPropertyChanged("SourceDisplayName");
            }
        }

        /// <summary>
        /// Gets the navigation command.
        /// </summary>
        public DelegateCommand NavigationCommand
        {
            get{ return this.navigationCommand; }
        }

        /// <summary>
        /// NavigationCommand executed.
        /// </summary>
        private void NavigationCommand_Executed()
        {
            Navigate();
        }

        /// <summary>
        /// Called when user double-click the item in the Error List. 
        /// Should be overriden in an actual derived instance of this class if its needed.
        /// </summary>
        public virtual void Navigate()
        {
        }
    }
}
