using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

using VMXExt = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;

namespace $LanguageNamespace$.ViewModel
{
    /// <summary>
    /// Service registrar.
    /// </summary>
    public partial class $LanguageName$ServiceRegistrar
    {
        /// <summary>
        /// Register services to the given store.
        /// </summary>
        /// <param name="store">ViewModelStore.</param>
        public override void RegisterServices(ViewModelStore store)
        {
            base.RegisterServices(store);

            VMXExt::ServicesHelper.RegisterServices(store);
        }
    }
}
