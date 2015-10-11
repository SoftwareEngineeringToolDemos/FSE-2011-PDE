using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Data;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    /// <summary>
    /// This control represents an editable text block.
    /// </summary>
    /// <remarks>
    /// Inspired by http://www.codeproject.com/KB/edit/EditableTextBlock_in_WPF.aspx
    /// </remarks>
    public class EditableTextBlock : TextBlock
    {
        private EditableTextBlockAdorner _adorner;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EditableTextBlock()
        {
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.ClickCount >= 2)
            {
                if (!this.IsInEditMode)
                {
                    this.IsInEditMode = true;
                }
                e.Handled = true;
            }
        }

        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            IsInEditMode = false;
        }
        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IsInEditMode = false;
            }
            else if (e.Key == Key.Escape)
            {   
                this.IsInEditMode = false;
            }
        }

        /// <summary>
        /// True if we are in editable-mode. False otherwise.
        /// </summary>
        public bool IsInEditMode
        {
            get
            {
                return (bool)GetValue(IsInEditModeProperty);
            }
            set
            {
                SetValue(IsInEditModeProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for IsInEditMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditableTextBlock), new UIPropertyMetadata(false, IsInEditModeUpdate));

        /// <summary>
        /// Determines whether [is in edit mode update] [the specified obj].
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void IsInEditModeUpdate(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            EditableTextBlock textBlock = obj as EditableTextBlock;
            if (null != textBlock && !textBlock.IsLocked)
            {
                //Get the adorner layer of the uielement (here TextBlock)
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(textBlock);
                if (layer == null)
                    return;

                //If the IsInEditMode set to true means the user has enabled the edit mode then
                //add the adorner to the adorner layer of the TextBlock.
                if (textBlock.IsInEditMode)
                {
                    if (null == textBlock._adorner)
                    {
                        textBlock._adorner = new EditableTextBlockAdorner(textBlock);

                        //Events wired to exit edit mode when the user presses Enter key or leaves the control.
                        textBlock._adorner.TextBoxKeyUp += textBlock.TextBoxKeyUp;
                        textBlock._adorner.TextBoxLostFocus += textBlock.TextBoxLostFocus;
                    }
                    else
                    {
                        textBlock._adorner.Update();
                    }
                    layer.Add(textBlock._adorner);
                }
                else
                {
                    //Remove the adorner from the adorner layer.
                    Adorner[] adorners = layer.GetAdorners(textBlock);
                    if (adorners != null)
                    {
                        foreach (Adorner adorner in adorners)
                        {
                            if (adorner is EditableTextBlockAdorner)
                            {
                                layer.Remove(adorner);
                            }
                        }
                    }

                    //Update the textblock's text binding.
                    //BindingExpression expression = textBlock.GetBindingExpression(TextProperty);
                    //if (null != expression)
                   // {
                   //     expression.UpdateTarget();
                    // }
                }
            }
        }

        public bool IsLocked
        {
            get
            {
                return (bool)GetValue(IsLockedProperty);
            }
            set
            {
                SetValue(IsLockedProperty, value);
            }
        }
        public static readonly DependencyProperty IsLockedProperty =
            DependencyProperty.Register("IsLocked", typeof(bool), typeof(EditableTextBlock), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets the length of the max.
        /// </summary>
        /// <value>The length of the max.</value>
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }
        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(EditableTextBlock), new UIPropertyMetadata(0));

        /// <summary>
        /// Gets or sets the max size of the adorned text box.
        /// </summary>
        public double TextBoxMaxWidth
        {
            get
            {
                return (double)GetValue(TextBoxMaxWidthProperty);
            }
            set
            {
                SetValue(TextBoxMaxWidthProperty, value);
            }
        }
        public static readonly DependencyProperty TextBoxMaxWidthProperty =
            DependencyProperty.Register("TextBoxMaxWidth", typeof(double), typeof(EditableTextBlock), new UIPropertyMetadata(double.NaN));

        /// <summary>
        /// Gets or sets the min size of the adorned text box.
        /// </summary>
        public double TextBoxMinWidth
        {
            get
            {
                return (double)GetValue(TextBoxMinWidthProperty);
            }
            set
            {
                SetValue(TextBoxMinWidthProperty, value);
            }
        }
        public static readonly DependencyProperty TextBoxMinWidthProperty =
            DependencyProperty.Register("TextBoxMinWidth", typeof(double), typeof(EditableTextBlock), new UIPropertyMetadata(double.NaN));
    }
}
