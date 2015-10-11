using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// View model used to filter out relationships on the depedencies diagram.
    /// </summary>
    public class GraphicalDependenciesFilterItem : BaseViewModel
    {
        private bool isFiltered = false;
        private GraphicalDependenciesViewModel diagramVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramVM">Diagram vm.</param>
        /// <param name="relationshipType">Type of the relationship.</param>
        public GraphicalDependenciesFilterItem(ViewModelStore viewModelStore, GraphicalDependenciesViewModel diagramVM, Guid relationshipType)
            : base(viewModelStore)
        {
            this.RelationshipType = relationshipType;
            this.diagramVM = diagramVM;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramVM">Diagram vm.</param>
        /// <param name="customFilterInformation">Filtering information.</param>
        public GraphicalDependenciesFilterItem(ViewModelStore viewModelStore, GraphicalDependenciesViewModel diagramVM, string customFilterInformation)
            : base(viewModelStore)
        {
            this.CustomFilterInformation = customFilterInformation;
            this.diagramVM = diagramVM;
        }

        /// <summary>
        /// Gets or sets the is filtered value.
        /// </summary>
        public bool IsFiltered
        {
            get
            {
                return isFiltered;
            }
            set
            {
                if (isFiltered != value)
                {
                    isFiltered = value;
                    OnPropertyChanged("IsFiltered");

                    this.diagramVM.UpdateBasedOnFilter(this);
                }
            }
        }

        /// <summary>
        /// Gets or sets the relationship type.
        /// </summary>
        public Guid RelationshipType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the display title.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the filtering information.
        /// </summary>
        public string CustomFilterInformation
        {
            get;
            set;
        }
    }
}
