namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View
{
    /// <summary>
    /// This interface defines what methods and properties an html rich text editor (flow document editor) 
    /// needs to provide.
    /// </summary>
    public interface IHtmlRichTextEditor
    {
        /// <summary>
        /// Toggle bold.
        /// </summary>
        void ToggleBold();

        /// <summary>
        /// Toggle underline.
        /// </summary>
        void ToggleUnderline();

        /// <summary>
        /// Toggle italic.
        /// </summary>
        void ToggleItalic();

        /// <summary>
        /// Increases the indentation for the current paragraph by one tab stop.
        /// </summary>
        void IncreaseIndentation();

        /// <summary>
        /// Decreases the indentation for the current paragraph by one tab stop.
        /// </summary>
        void DecreaseIndentation();

        /// <summary>
        /// Aligns the selection of content left.
        /// </summary>
        void AlignLeft();

        /// <summary>
        /// Aligns the selection of content to be centered.
        /// </summary>
        void AlignCenter();

        /// <summary>
        /// Aligns the selection of content right.
        /// </summary>
        void AlignRight();

        /// <summary>
        /// Aligns the selection of content to be justified.
        /// </summary>
        void AlignJustify();

        /// <summary>
        /// Adds a numbered (ordered) list to the editor.
        /// </summary>
        void InsertNumberList();

        /// <summary>
        /// Adds a bulleted list to the editor.
        /// </summary>
        void InsertBulletList();

        /// <summary>
        /// True if the last operation can be undone.
        /// </summary>
        bool CanUndo { get; }

        /// <summary>
        /// Undo the last operation.
        /// </summary>
        bool Undo();

        /// <summary>
        /// True if the last undone operation can be redone.
        /// </summary>
        bool CanRedo { get; }

        /// <summary>
        /// Redo last undone operation.
        /// </summary>
        bool Redo();

        /// <summary>
        /// Inserts a new hyperlink.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="link">Target of the hyperlink. Can either be an www-link or the v-modell id of a model element.</param>
        void InsertHyperlink(string text, string link);

        /// <summary>
        /// Inserts a new table by first displaying a form to specify table properties and then adding it to the flow document.
        /// </summary>
        /// <param name="tableRows">Number of rows.</param>
        /// <param name="tableColumns">Number of columns.</param>
        /// <param name="tableBorder">Border width.</param>
        void InsertTable(int tableRows, int tableColumns, double tableBorder);

        /// <summary>
        /// Inserts an image.
        /// </summary>
        /// <param name="image">Image to insert.</param>
        void InsertImage(HtmlImage image);

    }
}
