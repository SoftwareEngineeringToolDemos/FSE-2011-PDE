using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.PropertyGrid
{
    /// <summary>
    /// This class represents the property grid.
    /// </summary>
    public class PropertyGrid : ContentControl
    {
        /// <summary>
        /// Default width of the header.
        /// </summary>
        public const double HeaderDefaultWidth = 50;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PropertyGrid()
        {
        }

        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static PropertyGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGrid),
                new FrameworkPropertyMetadata(typeof(PropertyGrid)));
        }

        private PropertyGridItem selectedPropertyGridItem = null;

        /// <summary>
        /// Gets or sets the selected editor in the property grid. Can be null.
        /// </summary>
        public PropertyGridItem SelectedPropertyGridItem
        {
            get
            {
                return selectedPropertyGridItem;
            }
            set
            {
                if (selectedPropertyGridItem != value)
                {
                    selectedPropertyGridItem = value;
                    if (selectedPropertyGridItem != null)
                    {
                        SelectedEditor = selectedPropertyGridItem.DataContext;
                    }
                    else
                    {
                        SelectedEditor = null;
                    }
                }
            }
        }        

        /// <summary>
        /// Gets the property grid selected editor data object.
        /// </summary>
        public object SelectedEditor
        {
            get { return GetValue(SelectedEditorProperty); }
            set { SetValue(SelectedEditorProperty, value); }
        }

        /// <summary>
        /// Selected editor dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedEditorProperty =
            DependencyProperty.Register("SelectedEditor", typeof(object), typeof(PropertyGrid), new PropertyMetadata(null, OnSelectedEditorPropertyChanged));
        private static void OnSelectedEditorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PropertyGrid grid = d as PropertyGrid;
            if (grid != null)
            {
               
            }           
        }
        
        /// <summary>
        /// Set the selected editor.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            DependencyObject obj = GetParentFromVisualTree((DependencyObject)e.MouseDevice.DirectlyOver);
            if (obj is PropertyGridItem)
            {
                SelectedPropertyGridItem = obj as PropertyGridItem;
            }
        }
       
        /// <summary>
        /// Gets the parent object of the type PropertyGridItem starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        private DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of the given control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is PropertyGridItem)
                    break;
                else if (parent is PropertyGrid)
                    return null;
                else if( parent is FrameworkContentElement )
                    parent = (parent as FrameworkContentElement).Parent;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }
    }
}
