﻿#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright � Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace Fluent
{
    /// <summary>
    /// Represents logical sizes of a ribbon control 
    /// </summary>
    public enum RibbonControlSize
    {
        /// <summary>
        /// Large size of a control
        /// </summary>
        Large = 0,
        /// <summary>
        /// Middle size of a control
        /// </summary>
        Middle,
        /// <summary>
        /// Small size of a control
        /// </summary>
        Small
    }

    /// <summary>
    /// Represent base class for Fluent controls
    /// </summary>
    public abstract class RibbonControl:Control, ICommandSource, IQuickAccessItemProvider
    {        
        #region Size Property

        /// <summary>
        /// Using a DependencyProperty as the backing store for Size.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
          "Size",
          typeof(RibbonControlSize),
          typeof(RibbonControl),
          new FrameworkPropertyMetadata(RibbonControlSize.Large, 
              FrameworkPropertyMetadataOptions.AffectsArrange |
              FrameworkPropertyMetadataOptions.AffectsMeasure |
              FrameworkPropertyMetadataOptions.AffectsRender |
              FrameworkPropertyMetadataOptions.AffectsParentArrange |
              FrameworkPropertyMetadataOptions.AffectsParentMeasure,
              OnSizePropertyChanged)
        );

        // When the ControlSizeDefinition property changes we need to invalidate 
        // the parent chain measure so that the RibbonGroupsContainer can calculate 
        // the new size within the same MeasureOverride call.  This property
        // usually changes from RibbonGroupsContainer.MeasureOverride.
        private static void OnSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonControl ribbonControl = (RibbonControl) d;
            ribbonControl.OnSizePropertyChanged(
                (RibbonControlSize)e.OldValue, 
                (RibbonControlSize)e.NewValue);
        }

        /// <summary>
        /// Gets or sets Size for the element
        /// </summary>
        public RibbonControlSize Size
        {
            get { return (RibbonControlSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty,value);}
        }

        #endregion
        
        #region SizeDefinition Property

        /// <summary>
        /// Using a DependencyProperty as the backing store for SizeDefinition.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty SizeDefinitionProperty = DependencyProperty.Register(
          "SizeDefinition",
          typeof(string),
          typeof(RibbonControl),
          new FrameworkPropertyMetadata("Large, Middle, Small",
              FrameworkPropertyMetadataOptions.AffectsArrange |
              FrameworkPropertyMetadataOptions.AffectsMeasure |
              FrameworkPropertyMetadataOptions.AffectsRender |
              FrameworkPropertyMetadataOptions.AffectsParentArrange |
              FrameworkPropertyMetadataOptions.AffectsParentMeasure,
              OnSizeDefinitionPropertyChanged)
        );

        // Handles SizeDefinitionProperty changes
        static void OnSizeDefinitionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {            
            // Find parent group box
            RibbonGroupBox groupBox = FindParentRibbonGroupBox(d);
            UIElement element = (UIElement) d;
            if (groupBox != null)
            {
                SetAppropriateSize(element, groupBox.State);
            }
            else SetAppropriateSize(element, RibbonGroupBoxState.Large);
        }

        // Finds parent group box
        [SuppressMessage("Microsoft.Performance", "CA1800")]
        static RibbonGroupBox FindParentRibbonGroupBox(DependencyObject o)
        {
            while (!(o is RibbonGroupBox))
            {
                o = VisualTreeHelper.GetParent(o) ?? LogicalTreeHelper.GetParent(o); 
                if (o == null) break;
            }
            return (RibbonGroupBox)o;
        }

        /// <summary>
        /// Sets appropriate size of the control according to the 
        /// given group box state and control's size definition
        /// </summary>
        /// <param name="element">UI Element</param>
        /// <param name="state">Group box state</param>
        public static void SetAppropriateSize(UIElement element, RibbonGroupBoxState state)
        {
            int index = (int)state;
            if (state == RibbonGroupBoxState.Collapsed) index = 0;
            RibbonControl control = (element as RibbonControl);
            if (control!=null) control.Size = GetThreeSizeDefinition(element)[index];
        }


        /// <summary>
        /// Gets or sets SizeDefinition for element
        /// </summary>
        public string SizeDefinition
        {
            get { return (string)GetValue(SizeDefinitionProperty); }
            set { SetValue(SizeDefinitionProperty, value); }
        }

        /// <summary>
        /// Gets value of the attached property SizeDefinition of the given element
        /// </summary>
        /// <param name="element">The given element</param>
        public static RibbonControlSize[] GetThreeSizeDefinition(UIElement element)
        {
            string[] splitted = ((element as RibbonControl).SizeDefinition).Split(new char[] { ' ', ',', ';', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            
            int count = Math.Min(splitted.Length, 3);
            if (count == 0) return new RibbonControlSize[] { RibbonControlSize.Large, RibbonControlSize.Large, RibbonControlSize.Large };

            RibbonControlSize[] sizes = new RibbonControlSize[3];
            for (int i = 0; i < count; i++)
            {
                switch(splitted[i])
                {
                    case "Large": sizes[i] = RibbonControlSize.Large; break;
                    case "Middle": sizes[i] = RibbonControlSize.Middle; break;
                    case "Small": sizes[i] = RibbonControlSize.Small; break;
                    default: sizes[i] = RibbonControlSize.Large; break;
                }
            }
            for (int i = count; i < 3; i++)
            {
                sizes[i] = sizes[count - 1];
            }
            return sizes;
        }

        #endregion

        #region Text

        /// <summary>
        /// Gets or sets element Text
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Text.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RibbonControl), new UIPropertyMetadata(""));

        #endregion

        #region Icon

        /// <summary>
        /// Gets or sets Icon for the element
        /// </summary>
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(RibbonControl), new UIPropertyMetadata(null));            
        
        #endregion

        #region Click

        /// <summary>
        /// Occurs when a RibbonControl is clicked.
        /// </summary>
        [Category("Behavior")]
        public event RoutedEventHandler Click
        {
            add
            {
                RemoveHandler(ClickEvent, (RoutedEventHandler)OnClickHandle);
                AddHandler(ClickEvent, value);
                AddHandler(ClickEvent, (RoutedEventHandler)OnClickHandle);
            }
            remove
            {
                RemoveHandler(ClickEvent, value);                
            }
        }
        /// <summary>
        /// Identifies the RibbonControl.Click routed event.
        /// </summary>
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RibbonControl));

        /// <summary>
        /// Raises click event
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1030")]
        public void RaiseClick()
        {
            RoutedEventArgs eventArgs = new RoutedEventArgs(ClickEvent, this);
            RaiseEvent(eventArgs);
        }

        #endregion

        #region Command

        private bool currentCanExecute = true;

        /// <summary>
        /// Gets or sets the command to invoke when this button is pressed. This is a dependency property.
        /// </summary>
        [Category("Action"), Localizability(LocalizationCategory.NeverLocalize), Bindable(true)]
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the parameter to pass to the System.Windows.Controls.Primitives.ButtonBase.Command property. This is a dependency property.
        /// </summary>
        [Bindable(true), Localizability(LocalizationCategory.NeverLocalize), Category("Action")]
        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the element on which to raise the specified command. This is a dependency property.
        /// </summary>
        [Bindable(true), Category("Action")]
        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)GetValue(CommandTargetProperty);
            }
            set
            {
                SetValue(CommandTargetProperty, value);
            }
        }

        /// <summary>
        /// Identifies the CommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(RibbonControl), new FrameworkPropertyMetadata(null));
        /// <summary>
        /// Identifies the routed Command dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(RibbonControl), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));

        /// <summary>
        /// Identifies the CommandTarget dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(RibbonControl), new FrameworkPropertyMetadata(null));

        // Keep a copy of the handler so it doesn't get garbage collected.
        [SuppressMessage("Microsoft.Performance", "CA1823")]
        EventHandler canExecuteChangedHandler;

        /// <summary>
        /// Handles Command changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonControl control = d as RibbonControl;
            EventHandler handler = control.OnCommandCanExecuteChanged;
            if (e.OldValue != null)
            {
                (e.OldValue as ICommand).CanExecuteChanged -= handler;                
            }
            if (e.NewValue != null)
            {
                handler = new EventHandler(control.OnCommandCanExecuteChanged);
                control.canExecuteChangedHandler = handler;
                (e.NewValue as ICommand).CanExecuteChanged += handler;                

                RoutedUICommand cmd = e.NewValue as RoutedUICommand;
                if ((cmd != null) && (string.IsNullOrEmpty(control.Text))) control.Text = cmd.Text;
            }
            control.UpdateCanExecute();
        }
        /// <summary>
        /// Handles Command CanExecute changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            UpdateCanExecute();
        }

        private void UpdateCanExecute()
        {
            bool canExecute = Command != null && CanExecuteCommand();
            if (currentCanExecute != canExecute)
            {
                currentCanExecute = canExecute;
                CoerceValue(IsEnabledProperty);
            }
        }

        /// <summary>
        /// Execute command
        /// </summary>
        protected void ExecuteCommand()
        {
            ICommand command = Command;
            if (command != null)
            {
                object commandParameter = CommandParameter;
                RoutedCommand routedCommand = command as RoutedCommand;
                if (routedCommand != null)
                {
                    if (routedCommand.CanExecute(commandParameter, CommandTarget))
                    {
                        routedCommand.Execute(commandParameter, CommandTarget);
                    }
                }
                else if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            }
        }

        /// <summary>
        /// Determines whether the Command can be executed
        /// </summary>
        /// <returns>Returns Command CanExecute</returns>
        protected bool CanExecuteCommand()
        {
            ICommand command = Command;
            if (command == null)
            {
                return false;
            }
            object commandParameter = CommandParameter;
            RoutedCommand routedCommand = command as RoutedCommand;
            if (routedCommand == null)
            {
                return command.CanExecute(commandParameter);
            }
            return routedCommand.CanExecute(commandParameter, CommandTarget);
        }

        #endregion

        #region IsEnabled

        /// <summary>
        /// Gets a value that becomes the return 
        /// value of IsEnabled in derived classes. 
        /// </summary>
        /// <returns>
        /// true if the element is enabled; otherwise, false.
        /// </returns>
        protected override bool IsEnabledCore
        {
            get
            {
                return (base.IsEnabledCore && (currentCanExecute || Command == null));
            }
        }


        /// <summary>
        /// Coerces IsEnabled 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="basevalue"></param>
        /// <returns></returns>
        private static object CoerceIsEnabled(DependencyObject d, object basevalue)
        {
            RibbonControl control = (RibbonControl)d;
            UIElement parent = LogicalTreeHelper.GetParent(control) as UIElement;
            bool parentIsEnabled = parent == null || parent.IsEnabled;
            bool commandIsEnabled = control.Command == null || control.currentCanExecute;

            // We force disable if parent is disabled or command cannot be executed
            return (bool)basevalue && parentIsEnabled && commandIsEnabled;
        }

        #endregion        

        #region Focusable

        /// <summary>
        /// Handles IsEnabled changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e">The event data.</param>
        private static void OnFocusableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// Coerces IsEnabled 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="basevalue"></param>
        /// <returns></returns>
        private static object CoerceFocusable(DependencyObject d, object basevalue)
        {
            RibbonControl control = (d as RibbonControl);
            if (control!=null)
            {                
                Ribbon ribbon = control.FindParentRibbon();
                if (ribbon != null)
                {
                    return ((bool)basevalue) && ribbon.Focusable;
                }
            }
            return basevalue;
        }

        // Find parent ribbon
        private Ribbon FindParentRibbon()
        {
            DependencyObject element = this.Parent;
            while (element != null)
            {
                Ribbon ribbon = element as Ribbon;
                if (ribbon != null) return ribbon;
                element = VisualTreeHelper.GetParent(element) ??
                          LogicalTreeHelper.GetParent(element);
            }
            return null;
        }

        #endregion        

        #region Constructors

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static RibbonControl()
        {
            //IsEnabledProperty.AddOwner(typeof(RibbonControl), new FrameworkPropertyMetadata(null, CoerceIsEnabled));
            FocusableProperty.AddOwner(typeof(RibbonControl), new FrameworkPropertyMetadata(OnFocusableChanged, CoerceFocusable));

            ToolTipService.ShowOnDisabledProperty.OverrideMetadata(typeof(RibbonControl), new FrameworkPropertyMetadata(true));
            ToolTipService.InitialShowDelayProperty.OverrideMetadata(typeof(RibbonControl), new FrameworkPropertyMetadata(900));
            ToolTipService.BetweenShowDelayProperty.OverrideMetadata(typeof(RibbonControl), new FrameworkPropertyMetadata(0));
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(RibbonControl), new FrameworkPropertyMetadata(20000));            
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        protected RibbonControl()
        {
            AddHandler(ClickEvent, (RoutedEventHandler)OnBeforeClickHandle);
            AddHandler(ClickEvent, (RoutedEventHandler)OnClickHandle);
        }

        private void OnClickHandle(object sender, RoutedEventArgs e)
        {
            OnClick(e);
        }

        private void OnBeforeClickHandle(object sender, RoutedEventArgs e)
        {
            OnBeforeClick(e);
        }

        #endregion

        #region Overrides
        
        /// <summary>
        /// Invoked when an unhandled System.Windows.Input.Keyboard.KeyUp�attached event reaches 
        /// an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.KeyEventArgs that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if((e.Key==Key.Return)||(e.Key==Key.Space))
            {
                RaiseEvent(new RoutedEventArgs(RibbonControl.ClickEvent, this));
                e.Handled = true;
            }
            base.OnKeyUp(e);
        }

        #endregion

        #region QuickAccess

        /// <summary>
        /// Gets control which represents shortcut item.
        /// This item MUST be syncronized with the original 
        /// and send command to original one control.
        /// </summary>
        /// <returns>Control which represents shortcut item</returns>
        public abstract FrameworkElement CreateQuickAccessItem();

        /// <summary>
        /// This method must be overriden to bind properties to use in quick access creating
        /// </summary>
        /// <param name="element">Toolbar item</param>
        protected virtual void BindQuickAccessItem(FrameworkElement element)
        {
            Bind(this, element, "CommandParameter", RibbonControl.CommandParameterProperty, BindingMode.OneWay);
            Bind(this, element, "CommandTarget", RibbonControl.CommandTargetProperty, BindingMode.OneWay);
            Bind(this, element, "Command", RibbonControl.CommandProperty, BindingMode.OneWay);

            Bind(this, element, "ToolTip", Control.ToolTipProperty, BindingMode.OneWay);

            Bind(this, element, "FontFamily", Control.FontFamilyProperty, BindingMode.OneWay);
            Bind(this, element, "FontSize", Control.FontSizeProperty, BindingMode.OneWay);
            Bind(this, element, "FontStretch", Control.FontStretchProperty, BindingMode.OneWay);
            Bind(this, element, "FontStyle", Control.FontStyleProperty, BindingMode.OneWay);
            Bind(this, element, "FontWeight", Control.FontWeightProperty, BindingMode.OneWay);

            Bind(this, element, "Foreground", Control.ForegroundProperty, BindingMode.OneWay);
            Bind(this, element, "IsEnabled", Control.IsEnabledProperty, BindingMode.OneWay);
            Bind(this, element, "Opacity", Control.OpacityProperty, BindingMode.OneWay);
            Bind(this, element, "SnapsToDevicePixels", Control.SnapsToDevicePixelsProperty, BindingMode.OneWay);

            if (Icon != null) Bind(this, element, "Icon", RibbonControl.IconProperty, BindingMode.OneWay);
            if (Text != null) Bind(this, element, "Text", RibbonControl.TextProperty, BindingMode.OneWay);

            (element as RibbonControl).Size = RibbonControlSize.Small;
        }

        /// <summary>
        /// Gets or sets whether control can be added to quick access toolbar
        /// </summary>
        public bool CanAddToQuickAccessToolBar
        {
            get { return (bool)GetValue(CanAddToQuickAccessToolBarProperty); }
            set { SetValue(CanAddToQuickAccessToolBarProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for CanAddToQuickAccessToolBar.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CanAddToQuickAccessToolBarProperty =
            DependencyProperty.Register("CanAddToQuickAccessToolBar", typeof(bool), typeof(RibbonControl), new UIPropertyMetadata(true));

        #endregion        

        #region Binding

        /// <summary>
        /// Binds elements property
        /// </summary>
        /// <param name="source">Source element</param>
        /// <param name="target">Target element</param>
        /// <param name="path">Property path</param>
        /// <param name="property">Property to bind</param>
        /// <param name="mode">Binding mode</param>
        static protected void Bind(FrameworkElement source, FrameworkElement target, string path, DependencyProperty property, BindingMode mode)
        {
            Binding binding = new Binding();
            binding.Path = new PropertyPath(path);
            binding.Source = source;
            binding.Mode = mode;
            target.SetBinding(property, binding);
        }

        #endregion

        #region IsDefinitive

        /// <summary>
        /// Gets or sets whether ribbonc control click must close backstage
        /// </summary>
        public bool IsDefinitive
        {
            get { return (bool)GetValue(IsDefinitiveProperty); }
            set { SetValue(IsDefinitiveProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsDefinitive.  This enables animation, styling, binding, etc...
        /// </summary>
 
        public static readonly DependencyProperty IsDefinitiveProperty =
            DependencyProperty.Register("IsDefinitive", typeof(bool), typeof(RibbonControl), new UIPropertyMetadata(false));

        #endregion

        #region Proptected

        /// <summary>
        /// Handles size property changing
        /// </summary>
        /// <param name="previous">Previous value</param>
        /// <param name="current">Current value</param>
        protected virtual void OnSizePropertyChanged(RibbonControlSize previous, RibbonControlSize current)
        {
        }

        /// <summary>
        /// Handles before click
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnBeforeClick(RoutedEventArgs args)
        {
        
        }

        /// <summary>
        /// Handles click
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnClick(RoutedEventArgs args)
        {
            // Close Backstage
            if(IsDefinitive)
            {
                BackstageButton ribbon = FindOwnerRibbon();
                if(ribbon!=null) ribbon.IsOpen = false;
            }
        }
        
        /// <summary>
        /// Finds owner ribbon
        /// </summary>
        /// <returns>Owner ribbon</returns>
        protected BackstageButton FindOwnerRibbon()
        {
            DependencyObject obj = LogicalTreeHelper.GetParent(this);
            while(obj!=null)
            {
                BackstageButton ribbon = obj as BackstageButton;
                if(ribbon!=null) return ribbon;
                obj = LogicalTreeHelper.GetParent(obj);
            }
            return null;
        }

        #endregion
    }
}


