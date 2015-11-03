using System;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// Selects a web hyperlink.
    /// </summary>
    public class HtmlSelectWebHyperlinkViewModel : BaseViewModel, ISelectElementSubViewModel
    {
        private DelegateCommand activatedCommand;
        private bool isActive = false;
        private string hyperlinkText = string.Empty;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public HtmlSelectWebHyperlinkViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            activatedCommand = new DelegateCommand(ActivatedCommand_Executed);
        }

        /// <summary>
        /// Activated command.
        /// </summary>
        public DelegateCommand ActivatedCommand
        {
            get { return activatedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is active or not.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void ActivatedCommand_Executed()
        {
            if (!IsActive)
                IsActive = true;
        }

        /// <summary>
        /// Gets the selected hyperlink element.
        /// </summary>
        public object SelectedElement
        {
            get
            {
                if (String.IsNullOrEmpty(HyperlinkText) || String.IsNullOrWhiteSpace(HyperlinkText))
                    return null;
                else
                    return HyperlinkText;
            }
        }

        /// <summary>
        /// Gets or sets the hyperlink as string.
        /// </summary>
        public string HyperlinkText
        {
            get
            {
                return hyperlinkText;
            }
            set
            {
                hyperlinkText = value;

                OnPropertyChanged("HyperlinkText");
                OnPropertyChanged("SelectedElement");
            }
        }

        /// <summary>
        /// Tries to set the selection to the given element.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public void SetSelectedElement(object element)
        {
            if (element is string)
            {
                HyperlinkText = element as string;
            }
        }
    }
}
