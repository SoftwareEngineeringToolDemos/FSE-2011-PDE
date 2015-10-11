using System;
using System.Collections.Generic;
using Tum.PDE.ToolFramework.Modeling.Base;
using Tum.PDE.ToolFramework.Modeling.Visualization.Base.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel
{
    /// <summary>
    /// Welcome view model that is displayed on application start.
    /// </summary>
    public class MainWelcomeViewModel : Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts.IMainWelcomeViewModel
    {
        private DelegateCommand newModelCommand;
        private DelegateCommand openModelCommand;

        /// <summary>
        /// Gets the options.
        /// </summary>
        public ViewModelOptions Options;


        /// <summary>
        /// New command, used to create a new document.
        /// </summary>
        public DelegateCommand NewModelCommand
        {
            get
            {
                return newModelCommand;
            }
        }

        /// <summary>
        /// New command, used to open an existing document.
        /// </summary>
        public DelegateCommand OpenModelCommand
        {
            get
            {
                return openModelCommand;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="optionsPath">Options path.</param>
        public MainWelcomeViewModel(string optionsPath)
        {
            this.newModelCommand = new DelegateCommand(NewModelCommandExecuted);
            this.openModelCommand = new DelegateCommand(OpenModelCommandExecuted);

            Options = new ViewModelOptions();
            Options.Deserialize(optionsPath);

            AvailableModelModelContextViewModels = new List<BaseModelContextViewModel>();
        }

        /// <summary>
        /// New command executed.
        /// </summary>
        protected virtual void NewModelCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;

            Microsoft.Win32.SaveFileDialog saveFileService = new Microsoft.Win32.SaveFileDialog();
            saveFileService.Filter = this.SelectedModelContextViewModel.Titel + " files|*.xml|All files|*.*";
            if (saveFileService.ShowDialog(null) == true)
            {
                System.IO.StreamWriter writer = System.IO.File.CreateText(saveFileService.FileName);
                writer.Close();

                OpenModel(saveFileService.FileName);
            }
        }

        /// <summary>
        /// Open command executed.
        /// </summary>
        protected virtual void OpenModelCommandExecuted()
        {
            if (this.SelectedModelContextViewModel == null)
                return;

            Microsoft.Win32.OpenFileDialog openFileService = new Microsoft.Win32.OpenFileDialog();
            openFileService.Filter = this.SelectedModelContextViewModel.Titel + " files|*.xml|All files|*.*";
            if (openFileService.ShowDialog(null) == true)
            {
                OpenModel(openFileService.FileName);
            }
        }

        /// <summary>
        /// Load options for a specific model context.
        /// </summary>
        /// <param name="modelContextName"></param>
        public void Load(string modelContextName)
        {
            this.MRUFilesViewModel = new MRUFilesViewModel(modelContextName, Options, this);
        }

        /// <summary>
        /// Model context change.
        /// </summary>
        /// <param name="modelContextName"></param>
        public void ChangeModelContext(string modelContextName)
        {
            if( MRUFilesViewModel != null )
                this.MRUFilesViewModel.InitializeMRUEntries(modelContextName);
        }

        /// <summary>
        /// Gets or sets the mru files view model.
        /// </summary>
        public MRUFilesViewModel MRUFilesViewModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the further reading vm.
        /// </summary>
        public FurtherReadingViewModel FurtherReadingViewModel
        {
            get;
            set;
        }

        private BaseModelContextViewModel selectedModelContextViewModel = null;

        /// <summary>
        /// Gets or sets the selected model context vm.
        /// </summary>
        public BaseModelContextViewModel SelectedModelContextViewModel
        {
            get
            {
                return this.selectedModelContextViewModel;
            }
            set
            {
                if (this.selectedModelContextViewModel != value)
                {
                    if (selectedModelContextViewModel != null)
                        selectedModelContextViewModel.IsSelected = false;

                    selectedModelContextViewModel = value;
                    selectedModelContextViewModel.IsSelected = true;

                    this.ChangeModelContext(selectedModelContextViewModel.Name);
                }
            }
        }

        /// <summary>
        /// Gets the list of available model context vms.
        /// </summary>
        public List<BaseModelContextViewModel> AvailableModelModelContextViewModels
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        public string WindowTitle
        {
            get;
            set;
        }

        /// <summary>
        /// Open model.
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenModel(string fileName)
        {
            OnOpenModelRequested(new OpenModelEventArgs(fileName));
        }

        /// <summary>
        /// Open model event arguments.
        /// </summary>
        public class OpenModelEventArgs :EventArgs
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="fileName">Filename to open.</param>
            public OpenModelEventArgs(string fileName)
                : base()
            {
                FileName = fileName;
            }

            /// <summary>
            /// Gets the filename to open.
            /// </summary>
            public string FileName
            {
                get;
                private set;
            }
        }

        /// <summary>
        /// Fires after the layout manager has been initialized.
        /// </summary>
        public event EventHandler<OpenModelEventArgs> OpenModelRequested;

        /// <summary>
        /// Called after the layout manager has been initialized.
        /// </summary>
        /// <param name="e"></param>
        protected void OnOpenModelRequested(OpenModelEventArgs e)
        {
            if (OpenModelRequested != null)
                OpenModelRequested(this, e);
        }
    }
}
