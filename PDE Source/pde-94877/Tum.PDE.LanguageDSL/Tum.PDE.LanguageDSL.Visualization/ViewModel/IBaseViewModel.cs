using System;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    public interface IBaseViewModel
    {     
        /// <summary>
        /// Gets the view model store this view model belongs to.
        /// </summary>
        ViewModelStore ViewModelStore
        {
            get;
        }

        /// <summary>
        /// Gets the document data containing the domain model data.
        /// </summary>
        ModelData ModelData
        {
            get;
        }

        /// <summary>
        /// Gets the store containing the domain model.
        /// </summary>
        Store Store
        {
            get;
        }

        /// <summary>
        /// Event manager.
        /// </summary>
        ViewModelEventManager EventManager
        {
            get;
        }

        /// <summary>
        /// Gets the id of this view model.
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// Gets the global service provider.
        /// </summary>
        ServiceProvider GlobalServiceProvider
        {
            get;
        }
    }
}
