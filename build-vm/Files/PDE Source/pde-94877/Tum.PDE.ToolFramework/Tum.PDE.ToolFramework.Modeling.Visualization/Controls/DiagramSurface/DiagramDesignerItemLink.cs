using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This class represents a link.
    /// </summary>
    public class DiagramDesignerItemLink : ContentControl
    {
        private DiagramLinkAnchorStyle startAnchorStyle;
        private DiagramLinkAnchorStyle endAnchorStyle;

        /// <summary>
        /// Gets or sets the start anchor style.
        /// </summary>
        public DiagramLinkAnchorStyle StartAnchorStyle
        {
            get { return this.startAnchorStyle; }
            set
            {
                this.startAnchorStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the end anchor style.
        /// </summary>
        public DiagramLinkAnchorStyle EndAnchorStyle
        {
            get { return this.endAnchorStyle; }
            set
            {
                this.endAnchorStyle = value;
            }
        }

        /// <summary>
        /// Style for the path.
        /// </summary>
        public Style PathStyle
        {
            get { return (Style)GetValue(PathStyleProperty); }
            set
            {
                SetValue(PathStyleProperty, value);
            }
        }
        
        /// <summary>
        /// Path style property.
        /// </summary>
        public static readonly DependencyProperty PathStyleProperty =
          DependencyProperty.Register("PathStyle", typeof(Style), typeof(DiagramDesignerItemLink), new PropertyMetadata(null));

        /// <summary>
        /// Style for the start arrow.
        /// </summary>
        public Style StartArrowStyle
        {
            get { return (Style)GetValue(StartArrowStyleProperty); }
            set
            {
                SetValue(StartArrowStyleProperty, value);
            }
        }

        /// <summary>
        /// Start arrow style property.
        /// </summary>
        public static readonly DependencyProperty StartArrowStyleProperty =
          DependencyProperty.Register("StartArrowStyle", typeof(Style), typeof(DiagramDesignerItemLink), new PropertyMetadata(null));

        /// <summary>
        /// Style for the end arrow.
        /// </summary>
        public Style EndArrowStyle
        {
            get { return (Style)GetValue(EndArrowStyleProperty); }
            set
            {
                SetValue(EndArrowStyleProperty, value);
            }
        }

        /// <summary>
        /// End arrow style property.
        /// </summary>
        public static readonly DependencyProperty EndArrowStyleProperty =
          DependencyProperty.Register("EndArrowStyle", typeof(Style), typeof(DiagramDesignerItemLink), new PropertyMetadata(null));
    }
}
