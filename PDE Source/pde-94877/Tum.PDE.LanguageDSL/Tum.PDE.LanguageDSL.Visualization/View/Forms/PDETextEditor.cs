using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.AvalonEdit;
using System.Windows;
using ICSharpCode.AvalonEdit.Highlighting;

namespace Tum.PDE.LanguageDSL.Visualization.View.Forms
{
    public class PDETextEditor : TextEditor
    {
        /// <summary>
        /// Bindable text.
        /// </summary>
        public string BindableText
        {
            get { return GetValue(BindableTextProperty) as string; }
            set { SetValue(BindableTextProperty, value); }
        }

        /// <summary>
        /// Context menu options property.
        /// </summary>
        public static readonly DependencyProperty BindableTextProperty =
            DependencyProperty.Register("BindableText", typeof(string), typeof(PDETextEditor), new PropertyMetadata(null, new PropertyChangedCallback(BindableTextPropertyChanged)));
        private static void BindableTextPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            PDETextEditor designer = obj as PDETextEditor;
            if (designer != null)
            {
                designer.Text = args.NewValue as string;
            }
        }

        /// <summary>
        /// Bindable syntax highlighting
        /// </summary>
        public string BindableSyntaxHighlighting
        {
            get { return GetValue(BindableSyntaxHighlightingProperty) as string; }
            set { SetValue(BindableSyntaxHighlightingProperty, value); }
        }

        /// <summary>
        /// Context menu options property.
        /// </summary>
        public static readonly DependencyProperty BindableSyntaxHighlightingProperty =
            DependencyProperty.Register("BindableSyntaxHighlighting", typeof(string), typeof(PDETextEditor), new PropertyMetadata(null, new PropertyChangedCallback(BindableSyntaxHighlightingPropertyChanged)));
        private static void BindableSyntaxHighlightingPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            PDETextEditor designer = obj as PDETextEditor;
            if (designer != null)
            {
                designer.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(args.NewValue as string);
            }
        }
    }
}
