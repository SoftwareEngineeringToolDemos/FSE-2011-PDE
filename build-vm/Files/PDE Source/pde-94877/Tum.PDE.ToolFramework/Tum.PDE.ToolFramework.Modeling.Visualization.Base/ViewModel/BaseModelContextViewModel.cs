using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Base.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel
{
    /// <summary>
    /// Model context vm used at app startup in the welcome screen.
    /// </summary>
    public class BaseModelContextViewModel : INotifyPropertyChanged
    {
        MainWelcomeViewModel mainVM;

        private DelegateCommand selectModelContextCommand = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainVM"></param>
        /// <param name="contextName"></param>
        /// <param name="contextTitle"></param>
        public BaseModelContextViewModel(MainWelcomeViewModel mainVM, string contextName, string contextTitle)
        {
            this.mainVM = mainVM;
            this.Name = contextName;
            this.Titel = contextTitle;

            this.selectModelContextCommand = new DelegateCommand(SelectModelContextCommand_Executed);
        }

        /// <summary>
        /// Gets the selectModelContextCommand.
        /// </summary>
        public DelegateCommand SelectModelContextCommand
        {
            get
            {
                return this.selectModelContextCommand;
            }
        }
        private void SelectModelContextCommand_Executed()
        {
            this.IsSelected = true;
        }

        /// <summary>
        /// Gets the hosted contexts titel.
        /// </summary>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the hosted contexts titel.
        /// </summary>
        public string Titel
        {
            get;
            set;
        }

        private bool isSelected;

        /// <summary>
        /// Gets or sets whether this model context vm is the currently active model context vm.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");

                if (this.mainVM != null && value)
                    this.mainVM.SelectedModelContextViewModel = this;
            }
        }


        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property changes.
        /// </summary>
        /// <param name="name">Name of the property, which value changed.</param>
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
