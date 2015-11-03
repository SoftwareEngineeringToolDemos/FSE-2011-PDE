using Tum.PDE.ToolFramework.Modeling.Base;
namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel
{
    /// <summary>
    /// This view model is used to represent a most recently used file entry.
    /// </summary>
    public class MRUFileEntryViewModel
    {
        private MRUFileEntry mruEntry;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="mruEntry">MRU entry.</param>
        public MRUFileEntryViewModel(MRUFileEntry mruEntry)
        {
            this.mruEntry = mruEntry;
        }

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.mruEntry.FileName;
            }
        }

        /// <summary>
        /// Gets the short name of the file.
        /// </summary>
        public string ShortName
        {
            get
            {
                return this.mruEntry.ShortName;
            }
        }

        /// <summary>
        /// Gets the mru file entry.
        /// </summary>
        public MRUFileEntry MRUFileEntry
        {
            get
            {
                return this.mruEntry;
            }
        }
    }
}
