using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DataTemplateViewModel : BaseViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>

        public DataTemplateViewModel(ViewModelStore viewModelStore, string templateDisplayName, string dataTemplate)
            : base(viewModelStore)
        {
            this.DisplayName = templateDisplayName;
            this.DataTemplate = dataTemplate;
            this.SyntaxHighlighting = "C#";
        }

        public string DisplayName
        {
            get;
            private set;
        }

        public string DataTemplate
        {
            get;
            set;
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

        public string SyntaxHighlighting
        {
            get;
            set;
        }
    }
}
