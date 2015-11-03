using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Common
{
    /// <summary>
    /// Tab item.
    /// </summary>
    public class TabItemAvalonDock : TabItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TabItemAvalonDock()
        {
        }

        /// <summary>
        /// Title property.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Title property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string), typeof(TabItemAvalonDock), new PropertyMetadata(""));

        /// <summary>
        /// ImageSource property.
        /// </summary>
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// ImageSource property.
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
          DependencyProperty.Register("ImageSource", typeof(string), typeof(TabItemAvalonDock), new PropertyMetadata(null, new PropertyChangedCallback(ImageSourcePropertyChanged)));
        private static void ImageSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            TabItemAvalonDock item = obj as TabItemAvalonDock;
            if (string.IsNullOrEmpty(item.ImageSource) || string.IsNullOrWhiteSpace(item.ImageSource))
                item.HasImage = false;
            else
                item.HasImage = true;
        }

        /// <summary>
        /// HasImage property.
        /// </summary>
        public bool HasImage
        {
            get { return (bool)GetValue(HasImageProperty); }
            set
            {
                SetValue(HasImageProperty, value);
            }
        }

        /// <summary>
        /// HasImage property.
        /// </summary>
        public static readonly DependencyProperty HasImageProperty =
          DependencyProperty.Register("HasImage", typeof(bool), typeof(TabItemAvalonDock), new PropertyMetadata(false));

        /// <summary>
        /// Static constructor.
        /// </summary>
        static TabItemAvalonDock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabItemAvalonDock), new FrameworkPropertyMetadata(typeof(TabItemAvalonDock)));
        }
    }
}
