using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.ModelTree
{
    /// <summary>
    /// Scrollviewer for the model tree view.
    /// </summary>
    public class ModelTreeViewScrollViewer : ScrollViewer
    {
        private double fixedHorizontalOffset;

        
        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static ModelTreeViewScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModelTreeViewScrollViewer),
                new FrameworkPropertyMetadata(typeof(ModelTreeViewScrollViewer)));
        }

        /// <summary>
        /// Fix horizontal offset on scrolling changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnScrollChanged(ScrollChangedEventArgs e)
        {
            //if( e.HorizontalChange != 0 )
            this.ScrollToHorizontalOffset(fixedHorizontalOffset);

            base.OnScrollChanged(e);
        }

        /// <summary>
        /// Apply desired template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            ModelTreeViewScrollBar scrollBar = GetTemplateChild("PART_HorizontalScrollBar") as ModelTreeViewScrollBar;
            if (scrollBar != null)
            {
                scrollBar.Scroll += new ScrollEventHandler(scrollBarHorizontal_Scroll);
                
            }

            scrollBar = GetTemplateChild("PART_VerticalScrollBar") as ModelTreeViewScrollBar;
            if (scrollBar != null)
            {
                scrollBar.Scroll += new ScrollEventHandler(scrollBarVertical_Scroll);
                
            }

            base.OnApplyTemplate();
        }

        void scrollBarHorizontal_Scroll(object sender, ScrollEventArgs e)
        {
            fixedHorizontalOffset = e.NewValue;
            this.ScrollToHorizontalOffset(fixedHorizontalOffset);
        }
        void scrollBarVertical_Scroll(object sender, ScrollEventArgs e)
        {
            this.ScrollToVerticalOffset(e.NewValue);
        }
    }
}
