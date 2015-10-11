using System.Windows.Documents;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html
{
    /// <summary>
    /// This class extends the default flow document.
    /// </summary>
    public class HtmlFlowDocument : FlowDocument
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlFlowDocument()
        {
            this.FontSize = 12;
            this.FontFamily = new FontFamily("Segoe UI");
            this.TextAlignment = System.Windows.TextAlignment.Left;
        }
    }
}
