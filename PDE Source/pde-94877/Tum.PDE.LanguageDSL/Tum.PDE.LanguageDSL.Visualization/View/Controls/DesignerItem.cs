using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class DesignerItem : ContentControl, ISelectable
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DesignerItem()
        {
            //this.RequestBringIntoView += new RequestBringIntoViewEventHandler(DesignerItem_RequestBringIntoView);
        }

        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static DesignerItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DesignerItem),
                new FrameworkPropertyMetadata(typeof(DesignerItem)));
        }

        /*
        void DesignerItem_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }*/

        /// <summary>
        /// Update selection.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            if (DesignerHelper.GetDesignerItem((DependencyObject)e.MouseDevice.DirectlyOver) == this)
            {
                UpdateSelection(true);
                if (!this.IsFocused)
                    this.Focus();

                e.Handled = false;
            }
        }

        /// <summary>
        /// Updates the selection for this item.
        /// </summary>
        /// <param name="bSelect">True if this item should be selected; false otherwise.</param>
        protected virtual void UpdateSelection(bool bSelect)
        {
            DesignerCanvas designer = DesignerHelper.GetDesignerCanvas(this) as DesignerCanvas;

            // update selection
            if (designer != null)
            {
                if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != ModifierKeys.None)
                {
                    if (bSelect && this.IsSelected)
                    {
                        designer.SelectionService.RemoveFromSelection(this);
                    }
                    else if (!this.IsSelected)
                    {
                        designer.SelectionService.AddToSelection(this);
                    }
                }
                else if (!this.IsSelected && bSelect)
                {
                    designer.SelectionService.SelectItem(this);
                }
                else if (this.IsSelected && !bSelect)
                {
                    designer.SelectionService.RemoveFromSelection(this);
                }
            }
        }

        #region ISelectable
        /// <summary>
        /// Property to notify the control that it is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected", typeof(bool), typeof(DesignerItem), new PropertyMetadata(false, new PropertyChangedCallback(IsSelectedPropertyChanged)));
        private static void IsSelectedPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DesignerItem item = obj as DesignerItem;
            if (item.DataContext != null)
                if (item != null)
                {
                    DesignerCanvas designer = DesignerHelper.GetDesignerCanvas(item) as DesignerCanvas;
                    if (designer != null)
                    {
                        if ((bool)args.NewValue)
                        {
                            //if (!designer.SelectionService.CurrentSelection.Contains(item))
                            if (!designer.SelectionService.ContainsInSelection(item))
                                designer.SelectionService.AddToSelection(item, false);

                            item.BringIntoView();
                        }
                        else
                        {
                            //if (designer.SelectionService.CurrentSelection.Contains(item))
                            if (designer.SelectionService.ContainsInSelection(item))
                                designer.SelectionService.RemoveFromSelection(item, false);
                        }
                    }
                }
        }

        /// <summary>
        /// Gets the selected data.
        /// </summary>
        public virtual object SelectedData
        {
            get
            {
                return this.DataContext;
            }
        }
        #endregion
    }
}
