using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;

using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html;
using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.ViewModel
{
    /// <summary>
    /// This is the view model for editing html in the property grid.
    /// </summary>
    public partial class HtmlEditorViewModel : IHtmlEditorViewModel
    {
        private DelegateCommand htmlToggleBoldCommand;
        private DelegateCommand htmlToggleUnderlineCommand;
        private DelegateCommand htmlToggleItalicCommand;

        private DelegateCommand htmlIndentLessCommand;
        private DelegateCommand htmlIndentMoreCommand;

        private DelegateCommand undoCommand;
        private DelegateCommand redoCommand;

        private DelegateCommand htmlAlignLeftCommand;
        private DelegateCommand htmlAlignCenterCommand;
        private DelegateCommand htmlAlignRightCommand;
        private DelegateCommand htmlAlignJustifyCommand;

        private DelegateCommand htmlInsertBulletListCommand;
        private DelegateCommand htmlInsertNumberListCommand;
        private DelegateCommand htmlInsertHyperlinkCommand;
        private DelegateCommand htmlInsertTableCommand;
        private DelegateCommand htmlInsertImageCommand;

        private bool isSelectionTextBold = false;
        private bool isSelectionTextUnderlined = false;
        private bool isSelectionTextItalic = false;
        private bool isSelectionAlignedLeft = false;
        private bool isSelectionAlignedCenter = false;
        private bool isSelectionAlignedRight = false;
        private bool isSelectionAlignedJustified = false;

        /// <summary>
        /// Initialization.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.CanHandleMultipleElements = false;

            htmlToggleBoldCommand = new DelegateCommand(HtmlToggleBoldCommand_Executed);
            htmlToggleUnderlineCommand = new DelegateCommand(HtmlToggleUnderlineCommand_Executed);
            htmlToggleItalicCommand = new DelegateCommand(HtmlToggleItalicCommand_Executed);

            undoCommand = new DelegateCommand(UndoCommand_Executed, UndoCommand_CanExecute);
            redoCommand = new DelegateCommand(RedoCommand_Executed, RedoCommand_CanExecute);

            htmlIndentLessCommand = new DelegateCommand(HtmlIndentLessCommand_Executed);
            htmlIndentMoreCommand = new DelegateCommand(HtmlIndentMoreCommand_Executed);

            htmlAlignLeftCommand = new DelegateCommand(HtmlAlignLeftCommand_Executed);
            htmlAlignCenterCommand = new DelegateCommand(HtmlAlignCenterCommand_Executed);
            htmlAlignRightCommand = new DelegateCommand(HtmlAlignRightCommand_Executed);
            htmlAlignJustifyCommand = new DelegateCommand(HtmlAlignJustifyCommand_Executed);

            htmlInsertBulletListCommand = new DelegateCommand(HtmlInsertBulletListCommand_Executed);
            htmlInsertNumberListCommand = new DelegateCommand(HtmlInsertNumberListCommand_Executed);
            htmlInsertHyperlinkCommand = new DelegateCommand(HtmlInsertHyperlinkCommand_Executed, HtmlInsertHyperlinkCommand_CanExecute, true);
            htmlInsertTableCommand = new DelegateCommand(HtmlInsertTableCommand_Executed);
            htmlInsertImageCommand = new DelegateCommand(HtmlInsertImageCommand_Executed);
        }

        #region PropertyGridEditorViewModel
        /// <summary>
        /// Converts the property value (in respect to multiple source elements) and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        /// <remarks>
        /// Converter: All equal --> use value. One differs --> empty value.
        /// </remarks>
        public override object GetPropertyValue()
        {
            Html value = PropertyGridEditorViewModel.GetPropertyValue(this.Elements[0], this.PropertyName) as Html;
            if (value == null && this.ViewModelStore != null)
            {
                IParentModelElement parent = this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetParentModelElement(this.Elements[0] as ModelElement);
                if (parent == null)
                    throw new ArgumentNullException("Parent of element " + this.Elements[0].ToString() + " can not be null");
                string path = parent.DomainFilePath;
                string dirName = new System.IO.FileInfo(path).DirectoryName;

                value = new Html("", dirName);

                //value = new Html("", this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetDomainModelDirectory(this.Elements[0] as ModelElement));
            }
            return value;
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            // empty string values are treated as null...
            Html html = value as Html;
            if (html != null)
                if (html.HtmlData.Trim() == string.Empty)
                    html = null;

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
            {
                PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, value);
                transaction.Commit();
            }

            // handle errors
            if (html != null)
                if (html.ValidationResult.Count() > 0)
                {
                    // clear current error list
                    this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

                    // add serialization result items
                    List<BaseErrorListItemViewModel> items = new List<BaseErrorListItemViewModel>();
                    foreach (IValidationMessage validationmessage in html.ValidationResult)
                    {
                        StringErrorListItemViewModel item = new StringErrorListItemViewModel(this.ViewModelStore, validationmessage.MessageId, ModelErrorListItemViewModel.ConvertCategory(validationmessage.Type), validationmessage.Description);
                        items.Add(item);
                    }

                    // notify of change
                    this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
                }
        }
        #endregion

        #region IHtmlEditorViewModel
        /// <summary>
        /// Html rich text editor, that is used in the view.
        /// </summary>
        public IHtmlRichTextEditor HtmlRichTextEditor { get; set; }

        /// <summary>
        /// Gets or sets whether the the current selection has its font set to bold.
        /// </summary>
        public bool IsSelectionTextBold
        {
            get
            {
                return this.isSelectionTextBold;
            }
            set
            {
                this.isSelectionTextBold = value;
                OnPropertyChanged("IsSelectionTextBold");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its font decoration set to underline.
        /// </summary>
        public bool IsSelectionTextUnderlined
        {
            get
            {
                return this.isSelectionTextUnderlined;
            }
            set
            {
                this.isSelectionTextUnderlined = value;
                OnPropertyChanged("IsSelectionTextUnderlined");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its font style set to italic.
        /// </summary>
        public bool IsSelectionTextItalic
        {
            get
            {
                return this.isSelectionTextItalic;
            }
            set
            {
                this.isSelectionTextItalic = value;
                OnPropertyChanged("IsSelectionTextItalic");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to left.
        /// </summary>
        public bool IsSelectionAlignedLeft
        {
            get
            {
                return this.isSelectionAlignedLeft;
            }
            set
            {
                this.isSelectionAlignedLeft = value;
                OnPropertyChanged("IsSelectionAlignedLeft");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to center.
        /// </summary>
        public bool IsSelectionAlignedCenter
        {
            get
            {
                return this.isSelectionAlignedCenter;
            }
            set
            {
                this.isSelectionAlignedCenter = value;
                OnPropertyChanged("IsSelectionAlignedCenter");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to right.
        /// </summary>
        public bool IsSelectionAlignedRight
        {
            get
            {
                return this.isSelectionAlignedRight;
            }
            set
            {
                this.isSelectionAlignedRight = value;
                OnPropertyChanged("IsSelectionAlignedRight");
            }
        }

        /// <summary>
        /// Gets whether the the current selection has its alignment set to justify.
        /// </summary>
        public bool IsSelectionAlignedJustified
        {
            get
            {
                return this.isSelectionAlignedJustified;
            }
            set
            {
                this.isSelectionAlignedJustified = value;
                OnPropertyChanged("IsSelectionAlignedJustified");
            }
        }

        /// <summary>
        /// Execute the Html navigation command.
        /// </summary>
        public void NavigateToHtmlHyperlink(HtmlHyperlink hyperlink)
        {
            if (hyperlink.TargetName.Length == 0)
                return;

            bool bFoundTarget = false;
            if (hyperlink.TargetName[0] == '#')
            {
                string href = hyperlink.TargetName.Substring(1, hyperlink.TargetName.Length - 1);
                if (KeyGenerator.Instance.CanConvertVModellIDToGuid(href))
                {
                    Guid id = KeyGenerator.Instance.ConvertVModellIDToGuid(href);
                    ModelElement modelElement = this.Store.ElementDirectory.FindElement(id);
                    if (modelElement != null)
                    {
                        bFoundTarget = true;

                        SelectedItemsCollection col = new SelectedItemsCollection();
                        col.Add(modelElement);
                        EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));

                    }
                }
            }

            if (!bFoundTarget)
                System.Windows.MessageBox.Show(hyperlink.TargetName);
        }

        /// <summary>
        /// Modify the given hyperlink.
        /// </summary>
        public void ModifyHtmlHyperlink(HtmlHyperlink hyperlink)
        {
            using (HtmlSelectHyperlinkViewModel vm = new HtmlSelectHyperlinkViewModel(this.ViewModelStore))
            {
            vm.Title = "Edit a hyperlink";

            if (hyperlink.TargetName.Length > 0)
            {
                bool bFoundTarget = false;
                if (hyperlink.TargetName[0] == '#')
                {
                    string href = hyperlink.TargetName.Substring(1, hyperlink.TargetName.Length - 1);
                    if (KeyGenerator.Instance.CanConvertVModellIDToGuid(href))
                    {
                        Guid id = KeyGenerator.Instance.ConvertVModellIDToGuid(href);
                        ModelElement modelElement = this.Store.ElementDirectory.FindElement(id);
                        if (modelElement != null)
                        {
                            bFoundTarget = true;
                            vm.SetSelectedElement(modelElement);
                        }
                    }
                }

                if (!bFoundTarget)
                {
                    if (!String.IsNullOrEmpty(hyperlink.TargetName))
                        vm.SetSelectedElement(hyperlink.TargetName);
                }
            }

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("SelectHyperlinkPopup", vm);
            if (result == true)
            {
                if (vm.SelectedElement is string)
                {
                    hyperlink.TargetName = vm.SelectedElement as string;
                }
                else if (vm.SelectedElement is ModelElement)
                {
                    hyperlink.TargetName = "#" + KeyGenerator.Instance.ConvertGuidToVModellID(
                        (vm.SelectedElement as ModelElement).Id);
                }
            }
            }
            GC.Collect();
        }

        /// <summary>
        /// Modifies the given html image (parameterwise).
        /// </summary>
        public void ModifyHtmlImage(HtmlImage image)
        {
            IParentModelElement parent = this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetParentModelElement(this.Elements[0] as ModelElement);
            if (parent == null)
                throw new ArgumentNullException("Parent of element " + this.Elements[0].ToString() + " can not be null");
            string path = parent.DomainFilePath;
            string referencePath = new System.IO.FileInfo(path).DirectoryName;

            //string referencePath = this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetDomainModelDirectory(this.Elements[0] as ModelElement);

            using (HtmlInsertImageViewModel vm = new HtmlInsertImageViewModel(this.ViewModelStore, referencePath))
            {
            vm.RelativePath = image.RelativeSource;
            vm.AlternativeText = image.AlternativeText;
            vm.ImageId = image.Id;
            vm.ExportHeight = image.ExportHeight;
            vm.ExportWidth = image.ExportWidth;
            vm.SourcePath = referencePath + "\\" + vm.RelativePath;
            vm.IsInsertionValid = true;

            vm.Title = "Edit image";

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("InsertImagePopup", vm);
            if (result == true)
            {
                image.RelativeSource = vm.RelativePath;
                image.AlternativeText = vm.AlternativeText;
                image.Id = vm.ImageId;
                image.ExportHeight = vm.ExportHeight;
                image.ExportWidth = vm.ExportWidth;

                try
                {
                    // try to load image
                    BitmapImage bimg = new BitmapImage();
                    bimg.BeginInit();
                    bimg.UriSource = new Uri(referencePath + "\\" + image.RelativeSource, UriKind.Absolute);
                    bimg.EndInit();

                    image.Source = bimg;
                }
                catch
                {

                }
            }
            }
            GC.Collect();
        }

        /// <summary>
        /// Verifies if a data object can be dropped.
        /// </summary>
        public bool CanDragDrop(IDataObject dataObject)
        {
            bool bCanDrop = false;

            string[] formats = dataObject.GetFormats();
            foreach (string format in formats)
                if (dataObject.GetData(format) is BaseModelElementViewModel)
                {
                    bCanDrop = true;
                    break;
                }

            return bCanDrop;
        }

        /// <summary>
        /// Do drag drop.
        /// </summary>
        public void DoDragDrop(IDataObject dataObject)
        {
            try
            {
                string[] formats = dataObject.GetFormats();
                foreach (string format in formats)
                {
                    object data = dataObject.GetData(format);
                    if (data is BaseModelElementViewModel)
                    {
                        BaseModelElementViewModel vm = data as BaseModelElementViewModel;
                        ModelElement m = vm.Element as ModelElement;

                        string targetName = "#" + KeyGenerator.Instance.ConvertGuidToVModellID(m.Id);
                        string targetText = "";

                        if (m is IDomainModelOwnable)
                        {
                            if ((m as IDomainModelOwnable).DomainElementHasName)
                                targetText = (m as IDomainModelOwnable).DomainElementName;
                            else
                                targetText = (m as IDomainModelOwnable).DomainElementTypeDisplayName;
                        }
                        /*if (this.ViewModelStore.GetDomainModelServices(m).ElementNameProvider.HasName(m))
                            targetText = this.ViewModelStore.GetDomainModelServices(m).ElementNameProvider.GetName(m);
                        else
                            targetText = this.ViewModelStore.GetDomainModelServices(m).ElementTypeProvider.GetTypeDisplayName(m);
                        */

                        if (this.HtmlRichTextEditor != null)
                            this.HtmlRichTextEditor.InsertHyperlink(targetText, targetName);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                messageBox.ShowError(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Toggle bold command.
        /// </summary>
        public DelegateCommand HtmlToggleBoldCommand
        {
            get
            {
                return htmlToggleBoldCommand;
            }
        }

        /// <summary>
        /// Toggle underline command.
        /// </summary>
        public DelegateCommand HtmlToggleUnderlineCommand
        {
            get
            {
                return htmlToggleUnderlineCommand;
            }
        }

        /// <summary>
        /// Toggle italic command.
        /// </summary>
        public DelegateCommand HtmlToggleItalicCommand
        {
            get
            {
                return htmlToggleItalicCommand;
            }
        }

        /// <summary>
        /// Undo command.
        /// </summary>
        public DelegateCommand UndoCommand
        {
            get
            {
                return undoCommand;
            }
        }

        /// <summary>
        /// Redo command.
        /// </summary>
        public DelegateCommand RedoCommand
        {
            get
            {
                return redoCommand;
            }
        }

        /// <summary>
        /// Indent less command.
        /// </summary>
        public DelegateCommand HtmlIndentLessCommand
        {
            get
            {
                return htmlIndentLessCommand;
            }
        }

        /// <summary>
        /// Indent more command.
        /// </summary>
        public DelegateCommand HtmlIndentMoreCommand
        {
            get
            {
                return htmlIndentMoreCommand;
            }
        }

        /// <summary>
        /// Align left command.
        /// </summary>
        public DelegateCommand HtmlAlignLeftCommand
        {
            get
            {
                return htmlAlignLeftCommand;
            }
        }

        /// <summary>
        /// Align center command.
        /// </summary>
        public DelegateCommand HtmlAlignCenterCommand
        {
            get
            {
                return htmlAlignCenterCommand;
            }
        }

        /// <summary>
        /// Align right command.
        /// </summary>
        public DelegateCommand HtmlAlignRightCommand
        {
            get
            {
                return htmlAlignRightCommand;
            }
        }

        /// <summary>
        /// Align justify command.
        /// </summary>
        public DelegateCommand HtmlAlignJustifyCommand
        {
            get
            {
                return htmlAlignJustifyCommand;
            }
        }

        /// <summary>
        /// Insert bullet list command.
        /// </summary>
        public DelegateCommand HtmlInsertBulletListCommand
        {
            get
            {
                return htmlInsertBulletListCommand;
            }
        }

        /// <summary>
        /// Insert number list command.
        /// </summary>
        public DelegateCommand HtmlInsertNumberListCommand
        {
            get
            {
                return htmlInsertNumberListCommand;
            }
        }

        /// <summary>
        /// Insert hyperlink command.
        /// </summary>
        public DelegateCommand HtmlInsertHyperlinkCommand
        {
            get { return htmlInsertHyperlinkCommand; }
        }

        /// <summary>
        /// Insert table command.
        /// </summary>
        public DelegateCommand HtmlInsertTableCommand
        {
            get { return htmlInsertTableCommand; }
        }

        /// <summary>
        /// Insert image command.
        /// </summary>
        public DelegateCommand HtmlInsertImageCommand
        {
            get { return htmlInsertImageCommand; }
        }

        /// <summary>
        /// Toggle bold command executed.
        /// </summary>
        private void HtmlToggleBoldCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.ToggleBold();
        }

        /// <summary>
        /// Toggle underline command executed.
        /// </summary>
        private void HtmlToggleUnderlineCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.ToggleUnderline();
        }

        /// <summary>
        /// Toggle italic command executed.
        /// </summary>
        private void HtmlToggleItalicCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.ToggleItalic();
        }

        /// <summary>
        /// Undo command executed.
        /// </summary>
        private void UndoCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.Undo();
        }

        /// <summary>
        /// Undo command can execute.
        /// </summary>
        private bool UndoCommand_CanExecute()
        {
            if (this.HtmlRichTextEditor != null)
                return this.HtmlRichTextEditor.CanUndo;
            else
                return false;
        }

        /// <summary>
        /// Undo command executed.
        /// </summary>
        private void RedoCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.Redo();
        }

        /// <summary>
        /// Undo command can execute.
        /// </summary>
        private bool RedoCommand_CanExecute()
        {
            if (this.HtmlRichTextEditor != null)
                return this.HtmlRichTextEditor.CanRedo;
            else
                return false;
        }

        /// <summary>
        /// Indent less command executed.
        /// </summary>
        private void HtmlIndentLessCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.DecreaseIndentation();
        }

        /// <summary>
        /// Indent more command executed.
        /// </summary>
        private void HtmlIndentMoreCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.IncreaseIndentation();
        }

        /// <summary>
        /// Align left command executed.
        /// </summary>
        private void HtmlAlignLeftCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.AlignLeft();
        }

        /// <summary>
        /// Align center command executed.
        /// </summary>
        private void HtmlAlignCenterCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.AlignCenter();
        }

        /// <summary>
        /// Align right command executed.
        /// </summary>
        private void HtmlAlignRightCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.AlignRight();
        }

        /// <summary>
        /// Align justify command executed.
        /// </summary>
        private void HtmlAlignJustifyCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.AlignJustify();
        }

        /// <summary>
        /// Insert bullet list command executed.
        /// </summary>
        private void HtmlInsertBulletListCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.InsertBulletList();
        }

        /// <summary>
        /// Insert number list command executed.
        /// </summary>
        private void HtmlInsertNumberListCommand_Executed()
        {
            if (this.HtmlRichTextEditor != null)
                this.HtmlRichTextEditor.InsertNumberList();
        }

        /// <summary>
        /// Insert hyperlink command executed.
        /// </summary>
        private void HtmlInsertHyperlinkCommand_Executed()
        {
            using (HtmlSelectHyperlinkViewModel vm = new HtmlSelectHyperlinkViewModel(this.ViewModelStore))
            {
                vm.Title = "Select a hyperlink to an existing element or as a web hyperlink.";

                bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("SelectHyperlinkPopup", vm);
                if (result == true)
                {
                    string targetName = null;
                    string targetText = null;
                    if (vm.SelectedElement is string)
                    {
                        targetName = vm.SelectedElement as string;
                        targetText = "Link";
                    }
                    else if (vm.SelectedElement is ModelElement)
                    {
                        ModelElement m = vm.SelectedElement as ModelElement;

                        targetName = "#" + KeyGenerator.Instance.ConvertGuidToVModellID(m.Id);
                        if (m is IDomainModelOwnable)
                        {
                            if ((m as IDomainModelOwnable).DomainElementHasName)
                                targetText = (m as IDomainModelOwnable).DomainElementName;
                            else
                                targetText = (m as IDomainModelOwnable).DomainElementTypeDisplayName;
                        }
                    }

                    if (targetName != null)
                    {
                        if (this.HtmlRichTextEditor != null)
                            this.HtmlRichTextEditor.InsertHyperlink(targetText, targetName);
                    }
                }
            }
            GC.Collect();
        }

        /// <summary>
        /// Insert hyperlink command can execute.
        /// </summary>
        private bool HtmlInsertHyperlinkCommand_CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Insert table command executed.
        /// </summary>
        private void HtmlInsertTableCommand_Executed()
        {
            using (HtmlInsertTableViewModel vm = new HtmlInsertTableViewModel(this.ViewModelStore))
            {
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("InsertTablePopup", vm);
            if (result == true)
            {
                if (this.HtmlRichTextEditor != null)
                    this.HtmlRichTextEditor.InsertTable(vm.TableRows, vm.TableColumns, vm.TableBorder);
            }
            }
            GC.Collect();
        }

        /// <summary>
        /// Insert image command executed.
        /// </summary>
        private void HtmlInsertImageCommand_Executed()
        {
            IParentModelElement parent = this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetParentModelElement(this.Elements[0] as ModelElement);
            if (parent == null)
                throw new ArgumentNullException("Parent of element " + this.Elements[0].ToString() + " can not be null");
            string path = parent.DomainFilePath;
            string referencePath = new System.IO.FileInfo(path).DirectoryName;

            //string referencePath = this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementParentProvider.GetDomainModelDirectory(this.Elements[0] as ModelElement);
            using (HtmlInsertImageViewModel vm = new HtmlInsertImageViewModel(this.ViewModelStore, referencePath))
            {
            vm.Title = "Insert new image";

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("InsertImagePopup", vm);
            if (result == true)
            {
                HtmlImage image = new HtmlImage();
                image.RelativeSource = vm.RelativePath;
                image.AlternativeText = vm.AlternativeText;
                image.Id = vm.ImageId;
                image.ExportHeight = vm.ExportHeight;
                image.ExportWidth = vm.ExportWidth;

                try
                {
                    // try to load image
                    BitmapImage bimg = new BitmapImage();
                    bimg.BeginInit();
                    bimg.UriSource = new Uri(referencePath + "\\" + image.RelativeSource, UriKind.Absolute);
                    bimg.EndInit();

                    image.Source = bimg;
                }
                catch
                {

                }

                if (this.HtmlRichTextEditor != null)
                    this.HtmlRichTextEditor.InsertImage(image);
            }
            }
            GC.Collect();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            this.htmlAlignCenterCommand = null;
            this.htmlAlignJustifyCommand = null;
            this.htmlAlignLeftCommand = null;
            this.htmlAlignRightCommand = null;
            this.htmlIndentLessCommand = null;
            this.htmlIndentMoreCommand = null;
            this.htmlInsertBulletListCommand = null;
            this.htmlInsertHyperlinkCommand = null;
            this.htmlInsertImageCommand = null;
            this.htmlInsertNumberListCommand = null;
            this.htmlInsertTableCommand = null;
            this.htmlToggleBoldCommand = null;
            this.htmlToggleItalicCommand = null;
            this.htmlToggleUnderlineCommand = null;

            this.HtmlRichTextEditor = null;
        }
    }
}
