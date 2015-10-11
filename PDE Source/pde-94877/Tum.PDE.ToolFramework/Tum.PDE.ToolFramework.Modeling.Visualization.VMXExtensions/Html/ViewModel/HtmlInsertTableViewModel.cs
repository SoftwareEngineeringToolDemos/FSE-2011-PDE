using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// View model to insert html tables.
    /// </summary>
    public class HtmlInsertTableViewModel : BaseWindowViewModel
    {
        private int tableRows = 1;
        private int tableColumns = 1;

        private double tableBorder = 1;
        private string title = "Insert table";

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public HtmlInsertTableViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {

        }

        /// <summary>
        /// Gets or sets the title of the view model.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the number of table rows.
        /// </summary>
        public int TableRows
        {
            get { return this.tableRows; }
            set
            {
                this.tableRows = value;
                OnPropertyChanged("TableRows");
            }
        }

        /// <summary>
        /// Gets or sets the number of table columns.
        /// </summary>
        public int TableColumns
        {
            get { return this.tableColumns; }
            set
            {
                this.tableColumns = value;
                OnPropertyChanged("TableColumns");
            }
        }

        /// <summary>
        /// Gets or sets the width of the table border.
        /// </summary>
        public double TableBorder
        {
            get { return this.tableBorder; }
            set
            {
                this.tableBorder = value;
                OnPropertyChanged("TableBorder");
            }
        }
    }
}
