using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// Specific dependencies item vm.
    /// </summary>
    public class SpecificDependenciesItemViewModel : BaseModelElementViewModel
    {
        private int? index = null;

        /// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public SpecificDependenciesItemViewModel(ViewModelStore viewModelStore, ModelElement element)
            : base(viewModelStore, element, true)
        {

        }

        /// <summary>
        /// Index of the element.
        /// </summary>
        public int? Index
        {
            get
            {
                return index;
            }
            set
            {
                if (index != value)
                {
                    index = value;
                    OnPropertyChanged("Index");
                    OnPropertyChanged("DomainElementIndexedName");
                    OnPropertyChanged("DomainElementIndexedFullName");
                }
            }
        }

        /// <summary>
        /// Indexed name of the element. (e.g.: 1. Role)
        /// </summary>
        public string DomainElementIndexedName
        {
            get
            {
                if (this.Index != null)
                    return this.Index.Value.ToString() + ". " + this.DomainElementName;

                return this.DomainElementName;
            }
        }

        /// <summary>
        /// Indexed full name of the element. (e.g.: 1. Role (RolePlayer))
        /// </summary>
        public string DomainElementIndexedFullName
        {
            get
            {
                if (this.Index != null)
                    return this.Index.Value.ToString() + ". " + this.DomainElementFullName;

                return this.DomainElementFullName;
            }
        }
    }
}
