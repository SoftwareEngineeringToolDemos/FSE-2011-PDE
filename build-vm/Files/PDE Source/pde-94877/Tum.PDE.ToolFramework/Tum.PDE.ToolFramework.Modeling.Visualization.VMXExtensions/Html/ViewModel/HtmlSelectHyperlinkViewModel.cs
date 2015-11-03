using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// Html hyperlink selection view model. An html hyperlink can either be a true
    /// hyperlink (web page) or a link to an existing model element.
    /// </summary>
    public class HtmlSelectHyperlinkViewModel : SelectElementViewModel
    {
        private HtmlSelectWebHyperlinkViewModel selectWebHyperlinkViewModel;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public HtmlSelectHyperlinkViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            selectWebHyperlinkViewModel = new HtmlSelectWebHyperlinkViewModel(viewModelStore);
            selectWebHyperlinkViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);
        }

        /// <summary>
        /// Tries to set the selected elements to the given object. Not all sub viewmodels might be
        /// capable of setting a selection.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public override void SetSelectedElement(object element)
        {
            SelectWebHyperlinkViewModel.SetSelectedElement(element);

            base.SetSelectedElement(element);
        }

        /// <summary>
        /// Gets the select web hyperlink view model.
        /// </summary>
        public HtmlSelectWebHyperlinkViewModel SelectWebHyperlinkViewModel
        {
            get { return this.selectWebHyperlinkViewModel; }
        }
    }
}
