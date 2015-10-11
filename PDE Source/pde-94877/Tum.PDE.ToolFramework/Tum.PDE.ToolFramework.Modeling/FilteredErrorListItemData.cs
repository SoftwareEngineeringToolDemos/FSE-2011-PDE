namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Filtered error list item data representation.
    /// </summary>
    public class FilteredErrorListItemData
    {
        private string errorId;
        private string uniqueId;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FilteredErrorListItemData()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="errorId">Error id.</param>
        /// <param name="uniqueId">Unique item id.</param>
        public FilteredErrorListItemData(string errorId, string uniqueId)
        {
            this.errorId = errorId;
            this.uniqueId = uniqueId;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="errorListItem">Error list item to filter.</param>
        public FilteredErrorListItemData(IFilterableErrorListItem errorListItem)
            : this(errorListItem.ErrorId, errorListItem.GetUniqueId())
        {
            
        }

        /// <summary>
        /// Returns the error id of the filtered element(s).
        /// </summary>
        public string ErrorId
        {
            get { return this.errorId; }
            set
            {
                this.errorId = value;
            }
        }

        /// <summary>
        /// Returns the unique identification of the filtered element.
        /// </summary>
        public string UniqueId
        {
            get { return this.uniqueId; }
            set
            {
                this.uniqueId = value;
            }
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>true if the specified System.Object is equal to the current System.Object;
        /// otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is FilteredErrorListItemData)
                return (obj as FilteredErrorListItemData).UniqueId == this.UniqueId;
            else
                return base.Equals(obj);
        }
        /// <summary>
        /// Returns the hash code for this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.uniqueId.GetHashCode();
        }
    }
}
