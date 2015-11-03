using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// View model used to represent a language.
    /// </summary>
    public class LanguageViewModel : BaseViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="culture">Culture assigned to this language.</param>
        /// <param name="displayName">DisplayName for this language.</param>
        public LanguageViewModel(ViewModelStore viewModelStore, string culture, string displayName)
            : base(viewModelStore)
        {
            this.Culture = culture;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Gets the culture for this language.
        /// </summary>
        public string Culture
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the display name for this language.
        /// </summary>
        public string DisplayName
        {
            get;
            private set;
        }
    }
}
