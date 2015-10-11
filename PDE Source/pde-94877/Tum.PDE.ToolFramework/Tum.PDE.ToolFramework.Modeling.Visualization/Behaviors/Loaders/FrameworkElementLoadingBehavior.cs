using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Loaders;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors.Loaders
{
    /// <summary>
    /// IsLoading behavior for a framework element.
    /// </summary>
    public class FrameworkElementLoadingBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        #region Command
        /// <summary>
        /// IsLoading item dependency property.
        /// </summary>
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            "IsLoading", typeof(bool), typeof(FrameworkElementLoadingBehavior),
            new PropertyMetadata(false, new PropertyChangedCallback(OnIsLoadingChanged)));
        private static void OnIsLoadingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElementLoadingBehavior elBeh = obj as FrameworkElementLoadingBehavior;
            if (elBeh == null)
                return;

            FrameworkElement el = elBeh.AssociatedObject;
            if (el == null)
                return;

            AdornerLayer layer = AdornerLayer.GetAdornerLayer(el);
            if ((bool)args.NewValue)
            {
                if (elBeh.Decorator == null)
                {
                    ScaleTransform scaleTransform = new ScaleTransform(0.5, 0.5);
                    SkewTransform skewTransform = new SkewTransform(0, 0);
                    RotateTransform rotateTransform = new RotateTransform(0);
                    TranslateTransform translateTransform = new TranslateTransform(0, 0);

                    TransformGroup group = new TransformGroup();
                    group.Children.Add(scaleTransform);
                    group.Children.Add(skewTransform);
                    group.Children.Add(rotateTransform);
                    group.Children.Add(translateTransform);

                    DoubleAnimation doubleAnimation = new DoubleAnimation(0, 359, new TimeSpan(0, 0, 0, 1));
                    doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);

                    ResourceDictionary resourceDictionary = new ResourceDictionary();
                    resourceDictionary.Source = new Uri("Tum.PDE.ToolFramework.Modeling.Visualization;component/Controls/Loaders/ImageLoader.xaml", UriKind.Relative);
                    DrawingImage img = resourceDictionary["ImageLoading"] as DrawingImage;
                    img.Freeze();

                    Image imgControl = new Image();
                    imgControl.Source = img;
                    imgControl.Width = 84;
                    imgControl.Height = 84;
                    imgControl.RenderTransformOrigin = new Point(0.5, 0.5);
                    imgControl.RenderTransform = group;

                    elBeh.Decorator = new DecoratorAdorner(el, imgControl);
                    elBeh.Decorator.Width = 100;
                    elBeh.Decorator.Height = 100;

                }

                layer.Add(elBeh.Decorator);
            }
            else
            {
                if (elBeh.Decorator != null)
                    layer.Remove(elBeh.Decorator);
            }

            
        }

        /// <summary>
        /// Gets or sets the object that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        /// <summary>
        /// Decorator item dependency property.
        /// </summary>
        public static readonly DependencyProperty DecoratorProperty = DependencyProperty.Register(
            "Decorator", typeof(DecoratorAdorner), typeof(FrameworkElementLoadingBehavior),
            new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the object that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public DecoratorAdorner Decorator
        {
            get { return (DecoratorAdorner)GetValue(DecoratorProperty); }
            set { SetValue(DecoratorProperty, value); }
        }
        #endregion
    }
}
