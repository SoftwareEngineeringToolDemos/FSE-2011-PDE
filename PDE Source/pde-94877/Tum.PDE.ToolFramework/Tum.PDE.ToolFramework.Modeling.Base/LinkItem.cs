namespace Tum.PDE.ToolFramework.Modeling.Base
{
    /// <summary>
    /// Class used to store information required for a link item. This consists of: Titel,
    /// Description, Link and Category.
    /// </summary>
    public class LinkItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="titel">Titel.</param>
        public LinkItem(string titel) :
            this(titel, "")
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="titel">Titel.</param>
        /// <param name="description">Description.</param>
        public LinkItem(string titel, string description) :
            this(titel, description, null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="titel">Titel.</param>
        /// <param name="description">Description.</param>
        /// <param name="link">Link to navigate to.</param>
        public LinkItem(string titel, string description, string link) :
            this(titel, description, link, null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="titel">Titel.</param>
        /// <param name="description">Description.</param>
        /// <param name="link">Link to navigate to.</param>
        /// <param name="category">Category.</param>
        public LinkItem(string titel, string description, string link, string category)
        {
            this.Titel = titel;
            this.Description = description;
            this.Link = link;
            this.Category = category;
        }

        /// <summary>
        /// Gets the titel of the link item.
        /// </summary>
        public string Titel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description of the link item. Can be null or empty.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the link of the link item. Can be null or empty.
        /// </summary>
        public string Link
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the category of the link item. Can be null or empty.
        /// </summary>
        public string Category
        {
            get;
            private set;
        }
    }
}
