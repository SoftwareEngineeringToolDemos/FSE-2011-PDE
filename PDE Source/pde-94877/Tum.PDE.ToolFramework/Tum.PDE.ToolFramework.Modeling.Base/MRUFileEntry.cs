namespace Tum.PDE.ToolFramework.Modeling.Base
{
    /// <summary>
    /// This class is used to represent a most recently used file.
    /// </summary>
    public class MRUFileEntry
    {
        private string fileName;
        private string shortName;
        private string modelContextName;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="modelContextName">Model context name.</param>
        public MRUFileEntry(string fileName, string modelContextName)
        {
            this.fileName = fileName;
            this.modelContextName = modelContextName;

            try
            {
                this.shortName = new System.IO.FileInfo(this.fileName).Name;
            }
            catch
            {
                this.shortName = this.fileName;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MRUFileEntry()
        {
        }

        /// <summary>
        /// Gets or sets the file name (full path).
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// Gets the short name of the file.
        /// </summary>
        public string ShortName
        {
            get
            {
                return this.shortName;
            }
            set
            {
                this.shortName = value;
            }
        }

        /// <summary>
        /// Gets the short name of the file.
        /// </summary>
        public string ModelContextName
        {
            get
            {
                return this.modelContextName;
            }
            set
            {
                this.modelContextName = value;
            }
        }
    }
}
