using System.Collections.Generic;
using System.Xml.Linq;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Management class for filtered error list items. Can (de)serialize given a file path.
    /// </summary>
    public class FilteredErrorListData
    {
        /// <summary>
        /// Completly filtered error Ids.
        /// </summary>
        public List<string> completelyFilteredErrorIds;

        /// <summary>
        /// Filtered items.
        /// </summary>
        public List<FilteredErrorListItemData> filteredItems;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FilteredErrorListData()
        {
            this.completelyFilteredErrorIds = new List<string>();
            this.filteredItems = new List<FilteredErrorListItemData>();
        }

        /// <summary>
        /// Adds an error list item identification data to the filtered list.
        /// </summary>
        /// <param name="item">Filterable error list item.</param>
        public void Add(IFilterableErrorListItem item)
        {
            Add(item.ErrorId, item.GetUniqueId());
        }

        /// <summary>
        /// Add a new filtered error list data.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        /// <param name="uniqueId">Unique source Id.</param>
        public void Add(string errorId, string uniqueId)
        {
            this.filteredItems.Add(new FilteredErrorListItemData(errorId, uniqueId));
        }

        /// <summary>
        /// Add a new filtered error list data.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        public void Add(string errorId)
        {
            completelyFilteredErrorIds.Add(errorId);
        }

        /// <summary>
        /// Verifies if a filtered error record already exists.
        /// </summary>
        /// <param name="item">Filterable error list item.</param>
        public bool Contains(IFilterableErrorListItem item)
        {
            return Contains(item.ErrorId, item.GetUniqueId());
        }

        /// <summary>
        /// Verifies if a filtered error record already exists.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        /// <param name="uniqueId">Unique source Id.</param>
        public bool Contains(string errorId, string uniqueId)
        {
            foreach (FilteredErrorListItemData item in filteredItems)
                if (item.ErrorId == errorId && item.UniqueId == uniqueId)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifies if a given errorId is already filtered.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        public bool Contains(string errorId)
        {
            return completelyFilteredErrorIds.Contains(errorId);
        }

        /// <summary>
        /// Clear the contens.
        /// </summary>
        public void Clear()
        {
            completelyFilteredErrorIds.Clear();
            filteredItems.Clear();
        }
        
        /// <summary>
        /// Removes a filtered error list data.
        /// </summary>
        /// <param name="item">Filterable error list item.</param>
        public void Remove(IFilterableErrorListItem item)
        {
            Remove(item.ErrorId, item.GetUniqueId());
        }

        /// <summary>
        /// Removes a filtered error list data.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        /// <param name="uniqueId">Unique source Id.</param>
        public void Remove(string errorId, string uniqueId)
        {
            foreach (FilteredErrorListItemData item in filteredItems)
                if (item.ErrorId == errorId && item.UniqueId == uniqueId)
                {
                    filteredItems.Remove(item);
                    break;
                }
        }

        /// <summary>
        /// Removes a filtered error list data.
        /// </summary>
        /// <param name="errorId">Error Id.</param>
        /// <param name="bRemoveAll">Remove all filterable items with the same category.</param>
        public void Remove(string errorId, bool bRemoveAll)
        {
            if (bRemoveAll)
            {
                for (int i = filteredItems.Count-1; i >= 0; --i )
                    if (filteredItems[i].ErrorId == errorId )
                    {
                        filteredItems.RemoveAt(i);
                        break;
                    }
            }
            else
                if (completelyFilteredErrorIds.Contains(errorId))
                    completelyFilteredErrorIds.Remove(errorId);
        }

        /// <summary>
        /// Saves data.
        /// </summary>
        /// <param name="fileName">File name to save data to.</param>
        /// <param name="data">Data to be serialized.</param>
        public static void Serialize(string fileName, FilteredErrorListData data)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement rootNode = new XElement("FilteredErrorListItemsConfiguration");
                doc.Add(rootNode);

                foreach(string filteredId in data.completelyFilteredErrorIds)
                {
                    XElement node = new XElement("CompletelyFilteredErrorId");
                    node.Value = filteredId;
                    rootNode.Add(node);
                }

                foreach (FilteredErrorListItemData item in data.filteredItems)
                {
                    XElement node = new XElement("FilteredItem");
                    rootNode.Add(node);

                    XElement errorIdNode = new XElement("ErrorId");
                    errorIdNode.Value = item.ErrorId;
                    node.Add(errorIdNode);

                    XElement unqIdNode = new XElement("UniqueId");
                    unqIdNode.Value = item.UniqueId;
                    node.Add(unqIdNode);
                }

                doc.Save(fileName);
            }
            catch { }

            /*
            TextWriter w = null;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(FilteredErrorListData));
                w = new StreamWriter(fileName);
                s.Serialize(w, data);
            }
            catch{ }
            finally
            {
                if (w != null)
                    w.Close();
            }*/
        }

        /// <summary>
        /// Loads data.
        /// </summary>
        /// <param name="fileName">File name to load data from.</param>
        /// <returns>Deserialized Data.</returns>
        public static FilteredErrorListData Deserialize(string fileName)
        {
            try
            { 
                XDocument doc = XDocument.Load(fileName);
                XElement rootNode = doc.Root;

                FilteredErrorListData data = new FilteredErrorListData();
                foreach (XElement node in rootNode.Elements("CompletelyFilteredErrorId"))
                {
                    string id = node.Value;
                    data.completelyFilteredErrorIds.Add(id);
                }
                foreach (XElement node in rootNode.Elements("FilteredItem"))
                {
                    FilteredErrorListItemData item = new FilteredErrorListItemData();
                    item.ErrorId = node.Element("ErrorId").Value;
                    item.UniqueId = node.Element("UniqueId").Value;
                    data.filteredItems.Add(item);
                }
                return data;
            }
            catch
            {
                return new FilteredErrorListData();
            }

            /*
            TextReader r = null;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(FilteredErrorListData));
                r = new StreamReader(fileName);
                FilteredErrorListData data = s.Deserialize(r) as FilteredErrorListData;

                return data;
            }
            catch
            {
                return new FilteredErrorListData();
            }
            finally
            {
                if( r != null )
                    r.Close();
            }*/
        }
    }
}
