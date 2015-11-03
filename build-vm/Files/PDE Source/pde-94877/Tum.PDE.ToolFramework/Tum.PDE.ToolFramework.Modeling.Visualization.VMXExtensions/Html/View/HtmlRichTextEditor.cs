using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View
{
    /// <summary>
    /// This class extends the rich text box by providing properties and and commands needed for html processing.
    /// </summary>
    /// <remarks>
    /// The only commands supported so far are summarizen in HtmlToXamlConverter-Class.
    /// </remarks>
    public class HtmlRichTextEditor : RichTextBox, IHtmlRichTextEditor
    {
        /// <summary>
        /// Gets or sets whether the flow document has changed and html data needs to be rebuild based on the flow document before it can be accessed.
        /// </summary>
        private bool IsFlowDocumentDirty = false;
        private bool updateSelectionPropertiesPending = false;
        private bool IsInternChange = false;

        private MenuItem copyMenuItem;
        private MenuItem cutMenuItem;
        private MenuItem pasteMenuItem;

        private MenuItem editMenuItem;

        private DependencyObject specialObjectClicked = null;
        private IHtmlEditorViewModel htmlEditorViewModel = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlRichTextEditor()
            : base()
        {
            this.SelectionChanged += new RoutedEventHandler(OnSelectionChanged);
            this.RequestBringIntoView += new RequestBringIntoViewEventHandler(HtmlRichTextEditor_RequestBringIntoView);

            // register paste command
            /*
            CommandBinding pasteCmdBinding = new CommandBinding(
                ApplicationCommands.Paste,
                OnPaste,
                OnCanExecutePaste);
            this.CommandBindings.Add(pasteCmdBinding);
            */

            this.IsDocumentEnabled = true;
            this.AcceptsTab = true;
            this.AcceptsReturn = true;
            this.AllowDrop = true;

            this.ContextMenu = new ContextMenu();

            CopyCommand = new DelegateCommand(CopyCommand_Executed, CopyCommand_CanExecute);
            CutCommand = new DelegateCommand(CutCommand_Executed, CopyCommand_CanExecute);
            PasteCommand = new DelegateCommand(PasteCommand_Executed, PasteCommand_CanExecute);

            // copy, cut, paste
            copyMenuItem = new MenuItem();
            copyMenuItem.Header = "Copy";
            copyMenuItem.Command = CopyCommand;
            copyMenuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Copy.png"))
            };

            cutMenuItem = new MenuItem();
            cutMenuItem.Header = "Cut";
            cutMenuItem.Command = CutCommand;
            cutMenuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Cut.png"))
            };

            pasteMenuItem = new MenuItem();
            pasteMenuItem.Header = "Paste";
            pasteMenuItem.Command = PasteCommand;
            pasteMenuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Paste.png"))
            };

            // additional menu items
            editMenuItem = new MenuItem();
            editMenuItem.Header = "Edit";
            editMenuItem.Icon = new System.Windows.Controls.Image
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(
                    new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;component/Resources/Images/Edit.png"))
            };
            editMenuItem.Click += new RoutedEventHandler(editMenuItem_Click);

            this.DataContextChanged += new DependencyPropertyChangedEventHandler(HtmlRichTextEditor_DataContextChanged);
            this.OnSelectionChanged(this, null);

            this.UpdateCommand = new DelegateCommand(UpdateCommandExecuted, UpdateCommandCanExecute);
            this.CancelCommand = new DelegateCommand(CancelCommandExecuted, CancelCommandCanExecute);

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }
        void HtmlRichTextEditor_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }
        void HtmlRichTextEditor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is IHtmlEditorViewModel)
            {
                htmlEditorViewModel = e.NewValue as IHtmlEditorViewModel;
                (e.NewValue as IHtmlEditorViewModel).HtmlRichTextEditor = this;
            }
        }
        
        /// <summary>
        /// Preventing ScrollViewer from handling the mouse wheel
        /// Idea: http://serialseb.blogspot.com/2007/09/wpf-tips-6-preventing-scrollviewer-from.html
        /// </summary>
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = this;

                var parent = this.Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        /*
        /// <summary>
        /// Executes the paste command.
        /// </summary>
        /// <remarks>
        /// This is primeraly used to remove control sequences that are unknown to our html editor, so that the
        /// displayed flowdocument can be converted back to html whithout introducing unknown html elements as
        /// that most likely would lead to an export error (in the current v-modell xt editor).
        /// </remarks>
        private void OnPaste(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
            //RichTextBox richTextBox = sender as RichTextBox;
            //if (richTextBox == null) { return; }

            //var dataObj = (IDataObject)Clipboard.GetDataObject();
            //if (dataObj == null) { return; }

            // TODO


            //e.Handled = true;
        }

        /// <summary>
        /// Can the paste command be executed?
        /// </summary>
        private void OnCanExecutePaste(object target, CanExecuteRoutedEventArgs args)
        {
            
        }
        */

        /// <summary>
        /// Process selection changes and update properties.
        /// </summary>
        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            updateSelectionPropertiesPending = true;
            Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(ProcessSelectionChanged));
        }

        /// <summary>
        /// Processes selection changed event.
        /// </summary>
        private void ProcessSelectionChanged()
        {
            if (this.htmlEditorViewModel == null)
                return;

            TextRange tr = new TextRange(this.Selection.Start, this.Selection.End);
            if (tr.GetPropertyValue(FontWeightProperty).ToString() == "Bold")
            {
                if (!this.htmlEditorViewModel.IsSelectionTextBold)
                    this.htmlEditorViewModel.IsSelectionTextBold = true;
            }
            else
            {
                if (this.htmlEditorViewModel.IsSelectionTextBold)
                    this.htmlEditorViewModel.IsSelectionTextBold = false;
            }

            if (tr.GetPropertyValue(FontStyleProperty).ToString() == "Italic")
            {
                if (!htmlEditorViewModel.IsSelectionTextItalic)
                    this.htmlEditorViewModel.IsSelectionTextItalic = true;
            }
            else
            {
                if (htmlEditorViewModel.IsSelectionTextItalic)
                    this.htmlEditorViewModel.IsSelectionTextItalic = false;
            }

            bool bHandledUnderline = false;
            TextDecorationCollection col = tr.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection;
            if (col != null)
            {

                foreach (TextDecoration decoration in col)
                    if (decoration == TextDecorations.Underline[0])
                    {
                        bHandledUnderline = true;
                        if (!this.htmlEditorViewModel.IsSelectionTextUnderlined)
                            this.htmlEditorViewModel.IsSelectionTextUnderlined = true;
                        break;
                    }
            }
            if (!bHandledUnderline)
                if (this.htmlEditorViewModel.IsSelectionTextUnderlined)
                    this.htmlEditorViewModel.IsSelectionTextUnderlined = false;

            // alignment
            object alignmentObj = tr.GetPropertyValue(Paragraph.TextAlignmentProperty);
            if (alignmentObj != null)
            {
                TextAlignment alignment = (TextAlignment)alignmentObj;
                bool bAlignLeft = false;
                bool bAlignCenter = false;
                bool bAlignRight = false;
                bool bAlignJustify = false;
                if (alignment == System.Windows.TextAlignment.Left)
                    bAlignLeft = true;
                else if (alignment == System.Windows.TextAlignment.Center)
                    bAlignCenter = true;
                else if (alignment == System.Windows.TextAlignment.Right)
                    bAlignRight = true;
                else if (alignment == System.Windows.TextAlignment.Justify)
                    bAlignJustify = true;

                if (htmlEditorViewModel.IsSelectionAlignedLeft != bAlignLeft)
                    htmlEditorViewModel.IsSelectionAlignedLeft = bAlignLeft;
                if (htmlEditorViewModel.IsSelectionAlignedCenter != bAlignCenter)
                    htmlEditorViewModel.IsSelectionAlignedCenter = bAlignCenter;
                if (htmlEditorViewModel.IsSelectionAlignedRight != bAlignRight)
                    htmlEditorViewModel.IsSelectionAlignedRight = bAlignRight;
                if (htmlEditorViewModel.IsSelectionAlignedJustified != bAlignJustify)
                    htmlEditorViewModel.IsSelectionAlignedJustified = bAlignJustify;
            }

            updateSelectionPropertiesPending = false;
        }

        /// <summary>
        /// Mark flow document as dirty, so we update html when we lose focus.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            //this.IsInternChange = true;
            //this.Html = new Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html(this.Document, this.Html.VModellDirectory);
            //this.IsInternChange = false;
            if (!IsFlowDocumentDirty)
            {
                IsFlowDocumentDirty = true;

                this.UpdateCommand.RaiseCanExecuteChanged();
                this.CancelCommand.RaiseCanExecuteChanged();
            }
        }

        
        /// <summary>
        /// Update document when we lose focus if IsFlowDocumentDirty=True
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            // rebuild html data if necessary
            /*if (IsFlowDocumentDirty)
                this.Html = new Html(this.Document, this.Html.VModellDirectory);
            */
        }

        private DependencyObject GetParentElement(DependencyObject obj)
        {
            while (obj != null)
            {
                if (obj is HtmlRichTextEditor)
                    return null;

                if (obj is HtmlHyperlink || obj is HtmlImage || obj is Paragraph) // TODO
                    return obj;

                if (obj is FrameworkContentElement)
                    obj = (obj as FrameworkContentElement).Parent;
                else
                    return null;
            }

            return null;
        }

        /// <summary>
        /// Navigation to hyperlink, if Ctrl+Leftclick.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            DependencyObject obj = GetParentElement((DependencyObject)e.MouseDevice.DirectlyOver);
            specialObjectClicked = GetParentElement(obj);

            if (Keyboard.Modifiers == ModifierKeys.Control && e.ChangedButton == MouseButton.Left)
            {
                // lets see if the click occured inside a hyperlink
                if (specialObjectClicked is HtmlHyperlink)
                {
                    // navigate
                    if (this.htmlEditorViewModel != null && specialObjectClicked is HtmlHyperlink)
                        this.htmlEditorViewModel.NavigateToHtmlHyperlink(specialObjectClicked as HtmlHyperlink);
                }
            }
        }
        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (specialObjectClicked is HtmlHyperlink)
            {
                if (this.htmlEditorViewModel != null)
                    this.htmlEditorViewModel.ModifyHtmlHyperlink(specialObjectClicked as HtmlHyperlink);
            }
            else if (specialObjectClicked is HtmlImage)
            {
                if (this.htmlEditorViewModel != null)
                    this.htmlEditorViewModel.ModifyHtmlImage(specialObjectClicked as HtmlImage);
            }
        }

        /// <summary>
        /// See if we need to add specific context menu items based on the location of the context menu (mouse click location):
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContextMenuOpening(ContextMenuEventArgs e)
        {
            this.ContextMenu.Items.Clear();

            if (specialObjectClicked is HtmlHyperlink)
            {
                this.ContextMenu.Items.Add(editMenuItem);
                this.ContextMenu.Items.Add(new Separator());
            }
            else if (specialObjectClicked is HtmlImage)
            {
                this.ContextMenu.Items.Add(editMenuItem);
                this.ContextMenu.Items.Add(new Separator());
            }

            this.ContextMenu.Items.Add(cutMenuItem);
            this.ContextMenu.Items.Add(copyMenuItem);
            this.ContextMenu.Items.Add(pasteMenuItem);

            base.OnContextMenuOpening(e);
        }

        /// <summary>
        /// Clear context menu.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContextMenuClosing(ContextMenuEventArgs e)
        {
            base.OnContextMenuClosing(e);

            this.ContextMenu.Items.Clear();
        }

        /// <summary>
        /// CopyCommand executed
        /// </summary>
        private void CopyCommand_Executed()
        {
            ApplicationCommands.Copy.Execute(null, this);
        }

        /// <summary>
        /// CutCommand executed
        /// </summary>
        private void CutCommand_Executed()
        {
            ApplicationCommands.Cut.Execute(null, this);
        }

        /// <summary>
        /// PasteCommand executed
        /// </summary>
        private void PasteCommand_Executed()
        {
            ApplicationCommands.Paste.Execute(null, this);
        }

        /// <summary>
        /// CopyCommand executed
        /// </summary>
        private bool CopyCommand_CanExecute()
        {
            return ApplicationCommands.Copy.CanExecute(null, this);
        }

        /// <summary>
        /// CutCommand executed
        /// </summary>
        private bool CutCommand_CanExecute()
        {
            return ApplicationCommands.Cut.CanExecute(null, this);
        }

        /// <summary>
        /// PasteCommand executed
        /// </summary>
        private bool PasteCommand_CanExecute()
        {
            return ApplicationCommands.Paste.CanExecute(null, this);
        }

        /// <summary>
        /// Gets or sets the html document to display and/or edit in the rich text box and the html source text box.
        /// </summary>
        public Html Html
        {
            get { return GetValue(HtmlProperty) as Html; }
            set { SetValue(HtmlProperty, value); }
        }

        /// <summary>
        /// Html dependency property.
        /// </summary>
        public static readonly DependencyProperty HtmlProperty =
            DependencyProperty.Register("Html", typeof(Html), typeof(HtmlRichTextEditor), new PropertyMetadata(new PropertyChangedCallback(HtmlChanged)));
        private static void HtmlChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HtmlRichTextEditor editor = obj as HtmlRichTextEditor;
            if (editor != null)
            {
                if (e.NewValue == null)
                    return;

                if (!editor.IsInternChange)
                    editor.Document = (e.NewValue as Html).FlowDocument;
                editor.IsFlowDocumentDirty = false;
            }
        }


        /// <summary>
        /// Update the data source.
        /// </summary>
        public DelegateCommand UpdateCommand
        {
            get { return GetValue(UpdateCommandProperty) as DelegateCommand; }
            set { SetValue(UpdateCommandProperty, value); }
        }
        /// <summary>
        /// Html dependency property.
        /// </summary>
        public static readonly DependencyProperty UpdateCommandProperty =
            DependencyProperty.Register("UpdateCommand", typeof(DelegateCommand), typeof(HtmlRichTextEditor), new PropertyMetadata(null));

        /// <summary>
        /// Cancel update.
        /// </summary>
        public DelegateCommand CancelCommand
        {
            get { return GetValue(CancelCommandProperty) as DelegateCommand; }
            set { SetValue(CancelCommandProperty, value); }
        }
        /// <summary>
        /// Html dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(HtmlRichTextEditor), new PropertyMetadata(null));

        private void UpdateCommandExecuted()
        {
            this.Html = new Html(this.Document, this.Html.VModellDirectory);

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }
        private bool UpdateCommandCanExecute()
        {
            if (this.IsFlowDocumentDirty)
                return true;

            return false;
        }

        private void CancelCommandExecuted()
        {
            this.Document = this.Html.FlowDocument;
            this.IsFlowDocumentDirty = false;

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }

        private bool CancelCommandCanExecute()
        {
            if (this.IsFlowDocumentDirty)
                return true;

            return false;
        }

        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            if (this.htmlEditorViewModel != null)
            {
                if (htmlEditorViewModel.CanDragDrop(e.Data))
                    e.Effects = DragDropEffects.Move;
                else
                    e.Effects = DragDropEffects.None;
            }
            else
                e.Effects = DragDropEffects.None;
        }

        /// <summary>
        /// Drag enter logic.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (this.htmlEditorViewModel != null)
            {
                if (htmlEditorViewModel.CanDragDrop(e.Data))
                    e.Effects = DragDropEffects.Move;
                else
                    e.Effects = DragDropEffects.None;
            }
            else
                e.Effects = DragDropEffects.None;
        }

        /// <summary>
        /// DragDrop logic.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            if (this.htmlEditorViewModel != null)
            {
                this.htmlEditorViewModel.DoDragDrop(e.Data);
            }
        }

        /// <summary>
        /// Gets or sets the copy command.
        /// </summary>
        public ICommand CopyCommand
        {
            get { return GetValue(CopyCommandProperty) as ICommand; }
            set { SetValue(CopyCommandProperty, value); }
        }

        /// <summary>
        /// Copy command dependency property.
        /// </summary>
        public static readonly DependencyProperty CopyCommandProperty =
            DependencyProperty.Register("CopyCommand", typeof(ICommand), typeof(HtmlRichTextEditor), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the cut command.
        /// </summary>
        public ICommand CutCommand
        {
            get { return GetValue(CutCommandProperty) as ICommand; }
            set { SetValue(CutCommandProperty, value); }
        }

        /// <summary>
        /// Cut command dependency property.
        /// </summary>
        public static readonly DependencyProperty CutCommandProperty =
            DependencyProperty.Register("CutCommand", typeof(ICommand), typeof(HtmlRichTextEditor), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the paste command.
        /// </summary>
        public ICommand PasteCommand
        {
            get { return GetValue(PasteCommandProperty) as ICommand; }
            set { SetValue(PasteCommandProperty, value); }
        }

        /// <summary>
        /// Paste command dependency property.
        /// </summary>
        public static readonly DependencyProperty PasteCommandProperty =
            DependencyProperty.Register("PasteCommand", typeof(ICommand), typeof(HtmlRichTextEditor), new PropertyMetadata(null));

        #region IHtmlRichTextEditor
        /// <summary>
        /// Toggle bold.
        /// </summary>
        public void ToggleBold()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.ToggleBold.Execute(null, this);
        }

        /// <summary>
        /// Toggle underline.
        /// </summary>
        public void ToggleUnderline()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.ToggleUnderline.Execute(null, this);
        }

        /// <summary>
        /// Toggle italic.
        /// </summary>
        public void ToggleItalic()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.ToggleItalic.Execute(null, this);
        }

        /// <summary>
        /// Increases the indentation for the current paragraph by one tab stop.
        /// </summary>
        public void IncreaseIndentation()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.IncreaseIndentation.Execute(null, this);
        }

        /// <summary>
        /// Decreases the indentation for the current paragraph by one tab stop.
        /// </summary>
        public void DecreaseIndentation()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.DecreaseIndentation.Execute(null, this);
        }

        /// <summary>
        /// Aligns the selection of content left.
        /// </summary>
        public void AlignLeft()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.AlignLeft.Execute(null, this);

            this.htmlEditorViewModel.IsSelectionAlignedLeft = true;

            if (this.htmlEditorViewModel.IsSelectionAlignedCenter)
                htmlEditorViewModel.IsSelectionAlignedCenter = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedRight)
                htmlEditorViewModel.IsSelectionAlignedRight = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedJustified)
                htmlEditorViewModel.IsSelectionAlignedJustified = false;
        }

        /// <summary>
        /// Aligns the selection of content to be centered.
        /// </summary>
        public void AlignCenter()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.AlignCenter.Execute(null, this);

            this.htmlEditorViewModel.IsSelectionAlignedCenter = true;

            if (this.htmlEditorViewModel.IsSelectionAlignedLeft)
                htmlEditorViewModel.IsSelectionAlignedLeft = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedRight)
                htmlEditorViewModel.IsSelectionAlignedRight = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedJustified)
                htmlEditorViewModel.IsSelectionAlignedJustified = false;
        }

        /// <summary>
        /// Aligns the selection of content right.
        /// </summary>
        public void AlignRight()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.AlignRight.Execute(null, this);

            this.htmlEditorViewModel.IsSelectionAlignedRight = true;

            if (this.htmlEditorViewModel.IsSelectionAlignedLeft)
                htmlEditorViewModel.IsSelectionAlignedLeft = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedCenter)
                htmlEditorViewModel.IsSelectionAlignedCenter = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedJustified)
                htmlEditorViewModel.IsSelectionAlignedJustified = false;
        }

        /// <summary>
        /// Aligns the selection of content to be justified.
        /// </summary>
        public void AlignJustify()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.AlignJustify.Execute(null, this);

            this.htmlEditorViewModel.IsSelectionAlignedJustified = true;

            if (this.htmlEditorViewModel.IsSelectionAlignedLeft)
                htmlEditorViewModel.IsSelectionAlignedLeft = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedRight)
                htmlEditorViewModel.IsSelectionAlignedRight = false;
            if (this.htmlEditorViewModel.IsSelectionAlignedCenter)
                htmlEditorViewModel.IsSelectionAlignedCenter = false;
        }

        /// <summary>
        /// Adds a numbered (ordered) list to the editor.
        /// </summary>
        public void InsertNumberList()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.ToggleNumbering.Execute(null, this);
        }

        /// <summary>
        /// Adds a bulleted list to the editor.
        /// </summary>
        public void InsertBulletList()
        {
            if (updateSelectionPropertiesPending)
                return;

            EditingCommands.ToggleBullets.Execute(null, this);
        }

        /// <summary>
        /// Inserts a new hyperlink.
        /// </summary>
        /// <param name="text">Text to display. This text will only be set in case there is no selection in the editor.</param>
        /// <param name="link">Target of the hyperlink. Can either be an www-link or the v-modell id of a model element.</param>
        public void InsertHyperlink(string text, string link)
        {
            //if (updateSelectionPropertiesPending)
            //    return;

            string targetText = text;
            if (!this.Selection.IsEmpty)
            {
                // see first if there is a hyperlink inside the selection
                /*
                TextRange range = new TextRange(this.Selection.Start, this.Selection.End);
                
                foreach (Inline inline in this.Selection.Start.Paragraph.Inlines)
                {
                    if (inline is Hyperlink)
                    {
                        MessageBox.Show("Another hyperlink already in selection! Can not include a hyperlink in an another hyperlink.");
                        return;
                    }
                }*/
            }

            HtmlHyperlink hyperlink;
            if (!this.Selection.IsEmpty)
            {
                hyperlink = new HtmlHyperlink(this.Selection.Start, this.Selection.End);
            }
            else
            {
                hyperlink = new HtmlHyperlink(this.Selection.Start, this.Selection.End);

                hyperlink.Inlines.Add(new Run(text));
                //if (this.Selection.Start.Paragraph == null)
                //{
                //    Paragraph p = new Paragraph();
                //    this.Document.Blocks.Add(p);

                //    p.Inlines.Add(hyperlink);
                //}
                //else
                //    this.Selection.Start.Paragraph.Inlines.Add(hyperlink);
                this.Focus();
            }

            hyperlink.TargetName = link;
        }

        /// <summary>
        /// Inserts an image.
        /// </summary>
        /// <param name="image">Image to insert.</param>
        public void InsertImage(HtmlImage image)
        {
            if (updateSelectionPropertiesPending)
                return;

            if (this.Selection.Start.Paragraph == null)
            {
                Paragraph p = new Paragraph();
                this.Document.Blocks.Add(p);

                p.Inlines.Add(image);
            }
            else
                this.Selection.Start.Paragraph.Inlines.Add(image);
        }

        /// <summary>
        /// Inserts a new table by first displaying a form to specify table properties and then adding it to the flow document.
        /// </summary>
        /// <param name="tableRows">Number of rows.</param>
        /// <param name="tableColumns">Number of columns.</param>
        /// <param name="tableBorder">Border width.</param>
        public void InsertTable(int tableRows, int tableColumns, double tableBorder)
        {
            if (updateSelectionPropertiesPending)
                return;

            // create table
            Table table = new Table();
            for (int columnIndex = 0; columnIndex < tableColumns; columnIndex++)
            {
                TableColumn tableColumn = new TableColumn();
                tableColumn.Width = GridLength.Auto;
                table.Columns.Add(tableColumn);
            }

            TableRowGroup rowGroup = new TableRowGroup();
            for (int rowIndex = 0; rowIndex < tableRows; rowIndex++)
            {
                TableRow row = new TableRow();

                for (int columnIndex = 0; columnIndex < tableColumns; columnIndex++)
                {
                    TableCell cell = new TableCell();
                    cell.BorderBrush = new SolidColorBrush(Colors.Black);
                    cell.BorderThickness = new Thickness(tableBorder);
                    row.Cells.Add(cell);
                }

                rowGroup.Rows.Add(row);
            }
            table.RowGroups.Add(rowGroup);

            // insert table
            if (!this.Selection.IsEmpty)
            {
                this.Selection.Text = String.Empty;
            }

            TextPointer insertionPosition = this.Selection.Start;
            Paragraph paragraph = insertionPosition.Paragraph;

            // split current paragraph at insertion position
            if (paragraph != null)
            {
                //insertionPosition = insertionPosition.InsertParagraphBreak();
                paragraph.SiblingBlocks.InsertAfter(paragraph, table);

                //paragraph = insertionPosition.Paragraph;
                //paragraph.SiblingBlocks.InsertBefore(paragraph, table);
            }
            else
                this.Document.Blocks.Add(table);


        }
        #endregion
    }
}
