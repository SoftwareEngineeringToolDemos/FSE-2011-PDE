using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Loaders
{
    /// <summary>
    /// Adorner displaying 1 child element.
    /// </summary>
    public class DecoratorAdorner : Adorner
    {
        private FrameworkElement _child;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Element the adorner is added to (on the adorner layer).</param>
        /// <param name="adorner">Child element to display on the adorner.</param>
        public DecoratorAdorner(FrameworkElement source, FrameworkElement adorner)
            : base(source)
        {
            _child = adorner;

            AddVisualChild(_child);
        }

        /// <summary>
        /// Child hosted by the adorner.
        /// </summary>
        public FrameworkElement Child
        {
            get
            {
                return this._child;
            }
        }

        private FrameworkElement Source
        {
            get { return AdornedElement as FrameworkElement; }
        }

        /// <summary>
        /// Arrange override implementation.
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            _child.Arrange(new Rect(new Point(), finalSize));
            return new Size(_child.ActualWidth, _child.ActualHeight);
        }

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            if (index != 0)
                throw new ArgumentOutOfRangeException("index");

            return _child;
        }

        /// <summary>
        /// Gets the count of visual children (always 1).
        /// </summary>
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
    }
}
