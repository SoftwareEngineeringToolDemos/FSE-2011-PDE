using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections;
using System.Windows.Input;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class DesignerCanvas : Canvas
    {
        private SelectionService selectionService;
        private Point? rubberbandSelectionStartPoint = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DesignerCanvas()
            : base()
        {
            this.selectionService = new SelectionService(this);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source == this)
            {
                // in case that this click is the start of a 
                // drag operation we cache the start point
                this.rubberbandSelectionStartPoint = new Point?(e.GetPosition(this));

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
                SelectionService.ClearSelection(true);

                this.Focus();
                e.Handled = true;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // if mouse button is not pressed we have no drag operation, ...
            if (e.LeftButton != MouseButtonState.Pressed)
                this.rubberbandSelectionStartPoint = null;

            // ... but if mouse button is pressed and start
            // point value is set we do have one
            if (this.rubberbandSelectionStartPoint.HasValue)
            {
                Point pCurrent = e.GetPosition(this);
                if (Math.Abs(pCurrent.X - rubberbandSelectionStartPoint.Value.X) > 5 ||
                    Math.Abs(pCurrent.Y - rubberbandSelectionStartPoint.Value.Y) > 5)
                {
                    // create rubberband adorner
                    /*AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                    if (adornerLayer != null)
                    {
                        RubberbandAdorner adorner = new RubberbandAdorner(this, rubberbandSelectionStartPoint);
                        if (adorner != null)
                        {
                            adornerLayer.Add(adorner);
                        }
                    }*/
                }
            }
            e.Handled = true;
        }

        protected override void OnContextMenuOpening(ContextMenuEventArgs e)
        {
            this.ContextMenu.ItemsSource = ContextMenuOptions;

            if (this.ContextMenu.Items.Count == 0)
                e.Handled = true;

            base.OnContextMenuOpening(e);
        }

        /// <summary>
        /// Gets the selection service, that is active for this diagram.
        /// </summary>
        public SelectionService SelectionService
        {
            get { return selectionService; }
        }

        /// <summary>
        /// Property to notify of selected items.
        /// </summary>
        public Collection<object> SelectedItems
        {
            get { return GetValue(SelectedItemsProperty) as Collection<object>; }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        /// <summary>
        /// Selected items property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
          DependencyProperty.Register("SelectedItems", typeof(Collection<object>), typeof(DesignerCanvas), new PropertyMetadata(null, new PropertyChangedCallback(SelectedItemsPropertyChanged)));
        private static void SelectedItemsPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DesignerCanvas designer = obj as DesignerCanvas;
            if (designer != null)
            {
                if (designer.SelectedItems == null)
                    designer.SelectionService.ClearSelection(false);
                else
                {
                    if (designer.SelectedItems.Count == 0)
                        designer.SelectionService.ClearSelection(false);
                    else
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Context menu options.
        /// </summary>
        public IEnumerable ContextMenuOptions
        {
            get { return GetValue(ContextMenuOptionsProperty) as IEnumerable; }
            set { SetValue(ContextMenuOptionsProperty, value); }
        }

        /// <summary>
        /// Context menu options property.
        /// </summary>
        public static readonly DependencyProperty ContextMenuOptionsProperty =
            DependencyProperty.Register("ContextMenuOptions", typeof(IEnumerable), typeof(DesignerCanvas), new PropertyMetadata(null));
        
        /// <summary>
        /// Calculate the actual size because it is unknown otherwise, since we
        /// are using a canvas.
        /// </summary>
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }
    }
}
