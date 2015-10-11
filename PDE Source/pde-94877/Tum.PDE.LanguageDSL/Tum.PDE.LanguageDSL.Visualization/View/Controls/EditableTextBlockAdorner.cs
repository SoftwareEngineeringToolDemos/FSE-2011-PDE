using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    /// <summary>
    /// Adorner class which shows textbox over the text block when the Edit mode is on.
    /// </summary>
    /// <remarks>
    /// Inspired by http://www.codeproject.com/KB/edit/EditableTextBlock_in_WPF.aspx
    /// </remarks>
    public class EditableTextBlockAdorner : Adorner
    {
        private readonly VisualCollection _collection;
        private readonly TextBox _textBox;
        private readonly EditableTextBlock _textBlock;

        public EditableTextBlockAdorner(EditableTextBlock adornedElement)
            : base(adornedElement)
        {
            _collection = new VisualCollection(this);

            _textBox = new TextBox();
            _textBlock = adornedElement;
            _textBox.Text = _textBlock.Text;
            _textBox.MaxLength = adornedElement.MaxLength;
            _textBox.Margin = new Thickness(-2, -2, 0, 0);
            _textBox.Loaded += new RoutedEventHandler(_textBox_Loaded);
            _textBox.LostFocus += new RoutedEventHandler(_textBox_LostFocus);
            _textBox.KeyUp += _textBox_KeyUp;
            _collection.Add(_textBox);            
        }

        public void Update()
        {
            _textBox.Text = _textBlock.Text;
        }

        void _textBox_Loaded(object sender, RoutedEventArgs e)
        {
            _textBox.Focus();
            _textBox.SelectAll();
        }        
        void _textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _textBlock.Text = _textBox.Text;
            }
            else if (e.Key == Key.Escape)
            {
                _textBox.Text = _textBlock.Text;
            }
        }
        void _textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _textBlock.Text = _textBox.Text;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _collection[index];
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return _collection.Count;
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double width = _textBlock.DesiredSize.Width - 3;

            if (this._textBlock.TextBoxMinWidth != double.NaN)
                if (width < this._textBlock.TextBoxMinWidth)
                    width = this._textBlock.TextBoxMinWidth;

            if (this._textBlock.TextBoxMaxWidth != double.NaN)
                if (width > this._textBlock.TextBoxMaxWidth)
                    width = this._textBlock.TextBoxMaxWidth;

            _textBox.Arrange(new Rect(0, 0, width, _textBlock.DesiredSize.Height * 1.3));

            return finalSize;
        }

        public event RoutedEventHandler TextBoxLostFocus
        {
            add
            {
                _textBox.LostFocus += value;
            }
            remove
            {
                _textBox.LostFocus -= value;
            }
        }
        public event KeyEventHandler TextBoxKeyUp
        {
            add
            {
                _textBox.KeyUp += value;
            }
            remove
            {
                _textBox.KeyUp -= value;
            }
        }
    }
}
