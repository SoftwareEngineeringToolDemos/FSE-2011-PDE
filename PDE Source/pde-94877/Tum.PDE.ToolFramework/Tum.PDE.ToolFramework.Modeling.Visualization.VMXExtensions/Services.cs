using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions
{
    /// <summary>
    /// Service registrar.
    /// </summary>
    public static class ServicesHelper
    {
        /// <summary>
        /// Register services to the given store.
        /// </summary>
        /// <param name="store">ViewModelStore.</param>
        public static void RegisterServices(ViewModelStore store)
        {
            IUIVisualizerService popupVisualizer = store.GlobalServiceProvider.Resolve<IUIVisualizerService>();
            try
            {
                popupVisualizer.TryRegister("SelectHyperlinkPopup", typeof(SelectHyperlinkPopup));
                popupVisualizer.TryRegister("InsertImagePopup", typeof(InsertImagePopup));
                popupVisualizer.TryRegister("InsertTablePopup", typeof(InsertTablePopup));
            }
            catch { }
        }
    }
}
