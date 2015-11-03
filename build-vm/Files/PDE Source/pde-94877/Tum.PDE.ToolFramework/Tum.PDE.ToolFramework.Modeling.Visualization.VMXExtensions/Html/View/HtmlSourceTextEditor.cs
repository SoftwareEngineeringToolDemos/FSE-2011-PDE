using System.Windows;
using System.Windows.Controls;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.View
{
    /// <summary>
    /// This class extends the default textbox so that we can bind our html data to text and update html data on changes.
    /// 
    /// TODO: coloring, formating
    /// </summary>
    public class HtmlSourceTextEditor : TextBox
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public HtmlSourceTextEditor()
        {
            this.UpdateCommand = new DelegateCommand(UpdateCommandExecuted, UpdateCommandCanExecute);
            this.CancelCommand = new DelegateCommand(CancelCommandExecuted, CancelCommandCanExecute);

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Gets or sets whether the flow document has changed and html data needs to be rebuild based on the flow document before it can be accessed.
        /// </summary>
        public bool IsHtmlDataDirty = false;

        /// <summary>
        /// Mark html data as dirty, so that we can update html when we lose focus.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (!IsHtmlDataDirty)
            {
                IsHtmlDataDirty = true;

                this.UpdateCommand.RaiseCanExecuteChanged();
                this.CancelCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Update html when we lose focus if IsHtmlDataDirty=True
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            // rebuild html data if necessary
            //if (IsHtmlDataDirty)
             //   this.Html = new Html(this.Text, this.Html.VModellDirectory);
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
            DependencyProperty.Register("Html", typeof(Html), typeof(HtmlSourceTextEditor), new PropertyMetadata(new PropertyChangedCallback(HtmlChanged)));
        private static void HtmlChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HtmlSourceTextEditor editor = obj as HtmlSourceTextEditor;
            if (editor != null)
            {
                editor.Text = (e.NewValue as Html).HtmlData;
                editor.IsHtmlDataDirty = false;
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
            DependencyProperty.Register("UpdateCommand", typeof(DelegateCommand), typeof(HtmlSourceTextEditor), new PropertyMetadata(null));

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
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(HtmlSourceTextEditor), new PropertyMetadata(null));

        private void UpdateCommandExecuted()
        {
            this.Html = new Html(this.Text, this.Html.VModellDirectory);

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }
        private bool UpdateCommandCanExecute()
        {
            if (this.IsHtmlDataDirty)
                return true;

            return false;
        }

        private void CancelCommandExecuted()
        {
            this.Text = this.Html.HtmlData;
            this.IsHtmlDataDirty = false;

            this.UpdateCommand.RaiseCanExecuteChanged();
            this.CancelCommand.RaiseCanExecuteChanged();
        }

        private bool CancelCommandCanExecute()
        {
            if (this.IsHtmlDataDirty)
                return true;

            return false;
        }
    }
}
