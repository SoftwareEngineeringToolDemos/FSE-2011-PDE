﻿#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Fluent
{
    /// <summary>
    /// Represents spinner control
    /// </summary>
    [ContentProperty("Value")]
    [TemplatePart(Name="PART_TextBox", Type=typeof(System.Windows.Controls.TextBox))]
    [TemplatePart(Name = "PART_ButtonUp", Type = typeof(System.Windows.Controls.Primitives.RepeatButton))]
    [TemplatePart(Name = "PART_ButtonDown", Type = typeof(System.Windows.Controls.Primitives.RepeatButton))]
    public class Spinner : RibbonControl
    {
        #region Events

        /// <summary>
        /// Occurs when value has been changed
        /// </summary>
        public event RoutedPropertyChangedEventHandler<double> ValueChanged;

        #endregion

        #region Fields

        // Parts of the control (must be in control template)
        System.Windows.Controls.TextBox textBox;
        System.Windows.Controls.Primitives.RepeatButton buttonUp;
        System.Windows.Controls.Primitives.RepeatButton buttonDown;

        #endregion

        #region Properties

        #region Value

        /// <summary>
        /// Gets or sets current value
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721")]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Value.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Spinner), new UIPropertyMetadata(0.0d, OnValueChanged, CoerseValue));

        static object CoerseValue(DependencyObject d, object basevalue)
        {
            Spinner spinner = (Spinner)d;
            double value = (double) basevalue;
            value = Math.Max(spinner.Minimum, value);
            value = Math.Min(spinner.Maximum, value);
            return value;
        }

        static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Spinner spinner = (Spinner)d;
            spinner.ValueToTextBoxText();

            if (spinner.ValueChanged != null) spinner.ValueChanged(spinner, new RoutedPropertyChangedEventArgs<double>((double)e.OldValue, (double)e.NewValue));
        }

        void ValueToTextBoxText()
        {
            if (IsTemplateValid())
            {
                textBox.Text = Value.ToString(Format, CultureInfo.CurrentCulture);
            }
        }

        #endregion

        #region Increment
        
        /// <summary>
        /// Gets or sets a value added or subtracted from the value property
        /// </summary>
        public double Increment
        {
            get { return (double)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Increment.
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(double), typeof(Spinner), new UIPropertyMetadata(1.0d));

        #endregion

        #region Minimum
        
        /// <summary>
        /// Gets or sets minimun value
        /// </summary>
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Minimum.
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(Spinner), new UIPropertyMetadata(0.0d, OnMinimumChanged, CoerseMinimum));

        static object CoerseMinimum(DependencyObject d, object basevalue)
        {
            Spinner spinner = (Spinner) d;
            double value = (double)basevalue;
            if (spinner.Maximum < value) return spinner.Maximum;
            return value;
        }

        static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Spinner spinner = (Spinner) d;
            double value = (double) CoerseValue(d, spinner.Value);
            if (value != spinner.Value) spinner.Value = value;
        }

        #endregion

        #region Maximum
        
        /// <summary>
        /// Gets or sets maximum value
        /// </summary>
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Maximum.
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(Spinner), new UIPropertyMetadata(10.0d, OnMaximumChanged, CoerseMaximum));

        static object CoerseMaximum(DependencyObject d, object basevalue)
        {
            Spinner spinner = (Spinner)d;
            double value = (double)basevalue;
            if (spinner.Minimum > value) return spinner.Minimum;
            return value;
        }

        static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Spinner spinner = (Spinner)d;
            double value = (double)CoerseValue(d, spinner.Value);
            if (value != spinner.Value) spinner.Value = value;
        }

        #endregion

        #region Format

        /// <summary>
        /// Gets or sets string format of value
        /// </summary>
        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Format.
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty FormatProperty =
            DependencyProperty.Register("Format", typeof(string), typeof(Spinner), new UIPropertyMetadata("F1", OnFormatChanged));

        static void OnFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Spinner spinner = (Spinner)d;
            spinner.ValueToTextBoxText();
        }

        #endregion

        #region Delay

        /// <summary>
        /// Gets or sets the amount of time, in milliseconds, 
        /// the Spinner waits while it is pressed before it starts repeating. 
        /// The value must be non-negative. This is a dependency property.
        /// </summary>
        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Delay.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(int), typeof(Spinner), 
            new UIPropertyMetadata(400));

        #endregion

        #region Interval

        /// <summary>
        /// Gets or sets the amount of time, in milliseconds, 
        /// between repeats once repeating starts. The value must be non-negative. 
        /// This is a dependency property.
        /// </summary>
        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Interval.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(int), typeof(Spinner), new UIPropertyMetadata(80));

        #endregion

        #region InputWidth

        /// <summary>
        /// Gets or sets width of the value input part of spinner
        /// </summary>               
        public double InputWidth
        {
            get { return (double)GetValue(InputWidthProperty); }
            set { SetValue(InputWidthProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for InputWidth.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty InputWidthProperty =
            DependencyProperty.Register("InputWidth", typeof (double), typeof (Spinner), new UIPropertyMetadata(double.NaN));



        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static Spinner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Spinner), new FrameworkPropertyMetadata(typeof(Spinner)));            
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Spinner()
        {

        }

        #endregion

        #region Overrides

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            if (IsTemplateValid())
            {
                buttonUp.Click -= OnButtonUpClick;
                buttonDown.Click -= OnButtonDownClick;
                BindingOperations.ClearAllBindings(buttonDown);
                BindingOperations.ClearAllBindings(buttonUp);
            }

            // Get template childs
            textBox = GetTemplateChild("PART_TextBox") as System.Windows.Controls.TextBox;
            buttonUp = GetTemplateChild("PART_ButtonUp") as System.Windows.Controls.Primitives.RepeatButton;
            buttonDown = GetTemplateChild("PART_ButtonDown") as System.Windows.Controls.Primitives.RepeatButton;

            // Check template
            if (!IsTemplateValid())
            {
                Debug.WriteLine("Template for Spinner control is invalid");
                return;
            }

            // Bindings
            Bind(this, buttonUp, "Delay", System.Windows.Controls.Primitives.RepeatButton.DelayProperty, BindingMode.OneWay);
            Bind(this, buttonDown, "Delay", System.Windows.Controls.Primitives.RepeatButton.DelayProperty, BindingMode.OneWay);
            Bind(this, buttonUp, "Interval", System.Windows.Controls.Primitives.RepeatButton.IntervalProperty, BindingMode.OneWay);
            Bind(this, buttonDown, "Interval", System.Windows.Controls.Primitives.RepeatButton.IntervalProperty, BindingMode.OneWay);
            

            // Events subscribing
            buttonUp.Click += OnButtonUpClick;
            buttonDown.Click += OnButtonDownClick;
            textBox.LostKeyboardFocus += OnTextBoxLostKeyboardFocus;
            textBox.PreviewKeyDown += OnTextBoxPreviewKeyDown;

            ValueToTextBoxText();
        }

        bool IsTemplateValid()
        {
            return textBox != null && buttonUp != null && buttonDown != null;
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Handles click
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClick(RoutedEventArgs args)
        {
            if (!IsTemplateValid()) return;

            // Use dispatcher to avoid focus moving to backup'ed element 
            // (focused element before keytips processing)
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                (ThreadStart) (() =>
                  {
                      textBox.SelectAll();
                      textBox.Focus();
                  }));
            args.Handled = true;
        }

        /// <summary>
        /// Invoked when an unhandled System.Windows.Input.Keyboard.KeyUp�attached event reaches 
        /// an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.KeyEventArgs that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            // Avoid Click invocation (from RibbonControl)
            if (e.Key == Key.Enter || e.Key == Key.Space) return;
            base.OnKeyUp(e);
        }

        void OnButtonUpClick(object sender, RoutedEventArgs e)
        {
            Value += Increment;
        }

        void OnButtonDownClick(object sender, RoutedEventArgs e)
        {
            Value -= Increment;
        }


        void OnTextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBoxTextToValue();
        }
        
        void OnTextBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) TextBoxTextToValue();
            if (e.Key == Key.Escape) ValueToTextBoxText();
            if ((e.Key == Key.Enter) || (e.Key == Key.Escape))
            {
                // Move Focus
                textBox.Focusable = false;
                Focus();
                textBox.Focusable = true;
                e.Handled = true;
            }

            if (e.Key == Key.Up)
            {
                buttonUp.RaiseEvent(new RoutedEventArgs(
                    System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
            if (e.Key == Key.Down)
            {
                buttonDown.RaiseEvent(new RoutedEventArgs(
                    System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        void TextBoxTextToValue()
        {
            string text = textBox.Text;

            // Remove all except digits, signs and commas
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (Char.IsDigit(symbol) || 
                    symbol == ',' ||
                    symbol == '+' ||
                    symbol == '-' || 
                    symbol == '.') stringBuilder.Append(symbol);
            }
            text = stringBuilder.ToString();

            double value;
            if (Double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
            {
                Value = value;
            }
            ValueToTextBoxText();
        }

        #endregion

        #region Quick Access Item Creating

        /// <summary>
        /// Gets control which represents shortcut item.
        /// This item MUST be syncronized with the original 
        /// and send command to original one control.
        /// </summary>
        /// <returns>Control which represents shortcut item</returns>
        public override FrameworkElement CreateQuickAccessItem()
        {
            Spinner spinner = new Spinner();
            BindQuickAccessItem(spinner);
            return spinner;
        }

        /// <summary>
        /// This method must be overriden to bind properties to use in quick access creating
        /// </summary>
        /// <param name="element">Toolbar item</param>
        protected override void BindQuickAccessItem(FrameworkElement element)
        {
            Spinner spinner = (Spinner)element;

            spinner.Width = Width;
            spinner.InputWidth = InputWidth;

            Bind(this, spinner, "Value", ValueProperty, BindingMode.TwoWay);
            Bind(this, spinner, "Increment", IncrementProperty, BindingMode.OneWay);
            Bind(this, spinner, "Minimum", MinimumProperty, BindingMode.OneWay);
            Bind(this, spinner, "Maximum", MaximumProperty, BindingMode.OneWay);
            Bind(this, spinner, "Format", FormatProperty, BindingMode.OneWay);
            Bind(this, spinner, "Delay", DelayProperty, BindingMode.OneWay);
            Bind(this, spinner, "Interval", IntervalProperty, BindingMode.OneWay);
            
            base.BindQuickAccessItem(element);
        }

        #endregion
    }
}
