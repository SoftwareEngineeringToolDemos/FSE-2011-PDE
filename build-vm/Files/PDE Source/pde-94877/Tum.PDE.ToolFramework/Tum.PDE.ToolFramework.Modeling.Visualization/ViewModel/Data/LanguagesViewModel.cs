using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.Localization;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// View model used to represent a collection of languages.
    /// </summary>
    public class LanguagesViewModel : BaseViewModel
    {
        private List<LanguageViewModel> languages;
        private LanguageViewModel selectedLanguage;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public LanguagesViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            languages = new List<LanguageViewModel>();
            languages.Add(new LanguageViewModel(this.ViewModelStore, "en", "English"));
            languages.Add(new LanguageViewModel(this.ViewModelStore, "de", "Deutsch"));

            selectedLanguage = languages[0];
        }

        /// <summary>
        /// Gets the available languages.
        /// </summary>
        public List<LanguageViewModel> Languages
        {
            get
            {
                return this.languages;
            }
        }

        /// <summary>
        /// Gets or sets the selected language.
        /// </summary>
        public LanguageViewModel SelectedLanguage
        {
            get
            {
                return this.selectedLanguage;
            }
            set
            {
                if (this.selectedLanguage != value)
                {
                    this.selectedLanguage = value;
                    OnPropertyChanged("SelectedLanguage");

                    if (!string.IsNullOrEmpty(this.selectedLanguage.Culture))
                    {
                        CultureInfo oldCulture = CultureInfo.CurrentCulture;

                        CultureInfo ci = new CultureInfo(this.selectedLanguage.Culture);
                        Thread.CurrentThread.CurrentCulture = ci;
                        Thread.CurrentThread.CurrentUICulture = ci;

                        this.EventManager.GetEvent<CultureInfoChangedEvent>().Publish(
                                        new CultureInfoChangedEventArgs(oldCulture, CultureInfo.CurrentCulture));

                        LocalizationSettings.Current.CurrentCulture = ci;

                        IMessageBoxService msgBox = this.ResolveService<IMessageBoxService>();
                        msgBox.ShowInformation(Tum.PDE.ToolFramework.Modeling.Visualization.Properties.Resources.LanguageViewModel_LanguageChange);
                    }
                }
            }
        }
    }
}
