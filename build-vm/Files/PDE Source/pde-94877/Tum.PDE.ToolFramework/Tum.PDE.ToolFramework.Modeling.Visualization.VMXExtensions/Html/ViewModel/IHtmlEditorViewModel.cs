using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// This interface ensures what an html editor view model has to expose to the view.
    /// </summary>
    public interface IHtmlEditorViewModel
    {
        /// <summary>
        /// Actual html flow document editor view.
        /// </summary>
        IHtmlRichTextEditor HtmlRichTextEditor { get; set; }

        /// <summary>
        /// Gets or sets whether the the current selection has its font set to bold.
        /// </summary>
        bool IsSelectionTextBold { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its font decoration set to underline.
        /// </summary>
        bool IsSelectionTextUnderlined { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its font style set to italic.
        /// </summary>
        bool IsSelectionTextItalic { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to left.
        /// </summary>
        bool IsSelectionAlignedLeft { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to center.
        /// </summary>
        bool IsSelectionAlignedCenter { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to right.
        /// </summary>
        bool IsSelectionAlignedRight { get; set; }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to justify.
        /// </summary>
        bool IsSelectionAlignedJustified { get; set; }

        /// <summary>
        /// Execute the Html navigation command.
        /// </summary>
        void NavigateToHtmlHyperlink(HtmlHyperlink hyperlink);

        /// <summary>
        /// Modify the given hyperlink.
        /// </summary>
        void ModifyHtmlHyperlink(HtmlHyperlink hyperlink);

        /// <summary>
        /// Modifies the given html image (parameterwise).
        /// </summary>
        void ModifyHtmlImage(HtmlImage image);

        /// <summary>
        /// Verifies if a data object can be dropped.
        /// </summary>
        bool CanDragDrop(IDataObject dataObject);

        /// <summary>
        /// Do drag drop.
        /// </summary>
        void DoDragDrop(IDataObject dataObject);
    }
}
