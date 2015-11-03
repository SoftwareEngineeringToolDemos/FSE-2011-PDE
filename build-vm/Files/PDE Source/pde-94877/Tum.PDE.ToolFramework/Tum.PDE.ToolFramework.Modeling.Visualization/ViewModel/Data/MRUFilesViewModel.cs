using System;
using System.Collections.ObjectModel;
using Tum.PDE.ToolFramework.Modeling.Base;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// View model for handling mru file entries.
    /// </summary>
    public class MRUFilesViewModel : BaseViewModel
    {
        private ObservableCollection<MRUFileEntryViewModel> mruFileEntries;
        private MRUFileEntryViewModel selectedMRUFileEntry = null;

        private DelegateCommand<MRUFileEntry> addCommand;
        private DelegateCommand<MRUFileEntry> removeCommand;
        private DelegateCommand<MRUFileEntry> moveToTopCommand;
        private DelegateCommand<MRUFileEntry> openCommand;

        private MainViewModel mainViewModel;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="mainViewModel">The main view model, this MRU view model belongs to.</param>
        public MRUFilesViewModel(ViewModelStore viewModelStore, MainViewModel mainViewModel)
            : base(viewModelStore)
        {
            this.mainViewModel = mainViewModel;

            this.mruFileEntries = new ObservableCollection<MRUFileEntryViewModel>();

            this.addCommand = new DelegateCommand<MRUFileEntry>(AddCommandExecuted);
            this.removeCommand = new DelegateCommand<MRUFileEntry>(RemoveCommandExecuted);
            this.moveToTopCommand = new DelegateCommand<MRUFileEntry>(MoveToTopCommandExecuted);
            this.openCommand = new DelegateCommand<MRUFileEntry>(OpenCommandExecuted);

            this.ModelData.AfterModelContextChanged += new EventHandler(ModelData_AfterModelContextChanged);
            if( this.ViewModelStore.Options.IsDeserialized )
                InitializeMRUEntries(this.ModelData.CurrentModelContext.Name);
            else
                this.ViewModelStore.Options.OptionsDeserialized += new EventHandler(Options_OptionsDeserialized);
        }

        void Options_OptionsDeserialized(object sender, EventArgs e)
        {
            this.ViewModelStore.Options.OptionsDeserialized -= new EventHandler(Options_OptionsDeserialized);
            
            InitializeMRUEntries(this.ModelData.CurrentModelContext.Name);
        }

        void ModelData_AfterModelContextChanged(object sender, EventArgs e)
        {
            InitializeMRUEntries(this.ModelData.CurrentModelContext.Name);
        }

        /// <summary>
        /// Initializes mru entries based on the given context name.
        /// </summary>
        /// <param name="modelContextName">Model context name.</param>
        public void InitializeMRUEntries(string modelContextName)
        {
            if (this.mruFileEntries.Count > 0)
                this.mruFileEntries.Clear();

            foreach (MRUFileEntry entry in this.ViewModelStore.Options.MRUFileEntries)
                if (entry.ModelContextName == modelContextName)
                    this.mruFileEntries.Add(new MRUFileEntryViewModel(this.ViewModelStore, entry));
        }

        /// <summary>
        /// Gets the mru fil entries.
        /// </summary>
        public ObservableCollection<MRUFileEntryViewModel> MRUFileEntries
        {
            get
            {
                return this.mruFileEntries;
            }
        }

        /// <summary>
        /// Gets or sets the selected mru file entry.
        /// </summary>
        public MRUFileEntryViewModel SelectedMRUFileEntry
        {
            get
            {
                return this.selectedMRUFileEntry;
            }
            set
            {
                this.selectedMRUFileEntry = value;
                OnPropertyChanged("SelectedMRUFileEntry");
            }
        }

        #region CoOmmands
        /// <summary>
        /// Gets the add command.
        /// </summary>
        public DelegateCommand<MRUFileEntry> AddCommand
        {
            get
            {
                return this.addCommand;
            }
        }

        /// <summary>
        /// Gets the remove command.
        /// </summary>
        public DelegateCommand<MRUFileEntry> RemoveCommand
        {
            get
            {
                return this.removeCommand;
            }
        }

        /// <summary>
        /// Gets the move to top command.
        /// </summary>
        public DelegateCommand<MRUFileEntry> MoveToTopCommand
        {
            get
            {
                return this.moveToTopCommand;
            }
        }

        /// <summary>
        /// Gets the open command.
        /// </summary>
        public DelegateCommand<MRUFileEntry> OpenCommand
        {
            get
            {
                return this.openCommand;
            }
        }

        /// <summary>
        /// AddCommand executed.
        /// </summary>
        /// <param name="entry">MRU file entry.</param>
        public void AddCommandExecuted(MRUFileEntry entry)
        {
            AddMRUEntry(entry);
        }

        /// <summary>
        /// Remove command executed.
        /// </summary>
        public void RemoveCommandExecuted(MRUFileEntry entry)
        {
            if (entry != null)
                RemoveMRUEntry(entry);
        }

        /// <summary>
        /// Move to top command executed.
        /// </summary>
        public void MoveToTopCommandExecuted(MRUFileEntry entry)
        {
            if (entry != null)
                MoveToTop(entry);
        }

        /// <summary>
        /// Open command executed.
        /// </summary>
        public void OpenCommandExecuted(MRUFileEntry entry)
        {
            if (entry != null && this.mainViewModel != null)
            {
                this.mainViewModel.OpenModel(entry.FileName);

                MoveToTopCommandExecuted(entry);
            }
        }
        #endregion

        /// <summary>
        /// Adds a new mru entry to the collection.
        /// </summary>
        /// <param name="entry">MRU entry to add</param>
        /// <remarks>
        /// If the given mru entry already exists in the collection --> we move it to the top of the list, making it the most recent entry.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void AddMRUEntry(MRUFileEntry entry)
        {
            if (Contains(entry))
            {
                MoveToTop(entry);
                return;
            }

            this.ViewModelStore.Options.MRUFileEntries.Insert(0, entry);
            this.MRUFileEntries.Insert(0, new MRUFileEntryViewModel(this.ViewModelStore, entry));
        }

        /// <summary>
        /// Adds a new mru entry to the collection.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void AddMRUEntry(string fileName)
        {
            AddMRUEntry(new MRUFileEntry(fileName, this.ModelData.CurrentModelContext.Name));
        }

        /// <summary>
        /// Verifies if there is a mru entry pointing at the given file name and providing the same version as given.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="modelContextName">Model context name.</param>
        /// <returns>True if a mru entry is found; False otherwise.</returns>
        public bool Contains(string fileName, string modelContextName)
        {
            foreach (MRUFileEntry entry in this.ViewModelStore.Options.MRUFileEntries)
            {
                if (entry.FileName == fileName && entry.ModelContextName == modelContextName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifies if there is a specific mru entry.
        /// </summary>
        /// <param name="mruEntry">Mru entry.</param>
        /// <returns>True if a mru entry is found; False otherwise.</returns>
        public bool Contains(MRUFileEntry mruEntry)
        {
            foreach (MRUFileEntry entry in this.ViewModelStore.Options.MRUFileEntries)
            {
                if (entry.FileName == mruEntry.FileName && 
                    entry.ModelContextName == mruEntry.ModelContextName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Moves an mru entry to the top of the list.
        /// </summary>
        /// <param name="entry">MRU entry.</param>
        public void MoveToTop(MRUFileEntry entry)
        {
            MoveToTop(entry.FileName, entry.ModelContextName);
        }

        /// <summary>
        /// Moves an mru entry to the top of the list.
        /// </summary>
        /// <param name="fileName">MRU file name.</param>
        /// <param name="modelContextName">Model context name.</param>
        public void MoveToTop(string fileName, string modelContextName)
        {
            for (int i = this.ViewModelStore.Options.MRUFileEntries.Count - 1; i >= 0; i--)
            {
                if (this.ViewModelStore.Options.MRUFileEntries[i].FileName == fileName && i > 0 &&
                    this.ViewModelStore.Options.MRUFileEntries[i].ModelContextName == modelContextName)
                {
                    MRUFileEntry entry = this.ViewModelStore.Options.MRUFileEntries[i];
                    this.ViewModelStore.Options.MRUFileEntries.RemoveAt(i);
                    this.ViewModelStore.Options.MRUFileEntries.Insert(0, entry);

                    for (int y = this.MRUFileEntries.Count - 1; y >= 0; y--)
                    {
                        if (this.MRUFileEntries[y].MRUFileEntry.FileName == fileName && y > 0 &&
                            this.MRUFileEntries[y].MRUFileEntry.ModelContextName == modelContextName)
                        {
                            this.MRUFileEntries.Move(y, 0);
                        }
                    }
                    return;
                }
            }
        }

        /// <summary>
        /// Removes an mru entry from the list.
        /// </summary>
        /// <param name="entry">MRU entry.</param>
        public void RemoveMRUEntry(MRUFileEntry entry)
        {
            RemoveMRUEntry(entry.FileName, entry.ModelContextName);
        }

        /// <summary>
        /// Removes an mru entry from the list.
        /// </summary>
        /// <param name="fileName">File name pointing to an mru entry.</param>
        /// <param name="modelContextName">Model context name.</param>
        public void RemoveMRUEntry(string fileName, string modelContextName)
        {
            for (int i = this.ViewModelStore.Options.MRUFileEntries.Count - 1; i >= 0; i--)
            {
                if (this.ViewModelStore.Options.MRUFileEntries[i].FileName == fileName &&
                    this.ViewModelStore.Options.MRUFileEntries[i].ModelContextName == modelContextName)
                {
                    this.ViewModelStore.Options.MRUFileEntries.RemoveAt(i);

                    for (int y = this.MRUFileEntries.Count - 1; y >= 0; y--)
                    {
                        if (this.MRUFileEntries[y].MRUFileEntry.FileName == fileName &&
                            this.MRUFileEntries[y].MRUFileEntry.ModelContextName == modelContextName)
                        {
                            this.MRUFileEntries.RemoveAt(y);
                            break;
                        }
                    }

                    return;
                }
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.ModelData != null )
                this.ModelData.AfterModelContextChanged -= new EventHandler(ModelData_AfterModelContextChanged);

            base.OnDispose();
        }
    }
}