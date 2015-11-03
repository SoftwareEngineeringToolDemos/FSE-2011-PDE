using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DiagramClassTemplateViewModel : BaseViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="uniqueID"></param>
        /// <param name="templateName"></param>
        /// <param name="templateDisplayName"></param>
        public DiagramClassTemplateViewModel(ViewModelStore viewModelStore, string uniqueID, string templateName, string templateDisplayName)
            : base(viewModelStore)
        {
            this.UniqueId = uniqueID;
            this.Name = templateName;
            this.DisplayName = templateDisplayName;
        }

        public string Name
        {
            get;
            private set;
        }

        public string DisplayName
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ImageUri
        {
            get;
            set;
        }

        public string ImageUriBig
        {
            get;
            set;
        }

        public string UniqueId
        {
            get;
            private set;
        }
    }
}
