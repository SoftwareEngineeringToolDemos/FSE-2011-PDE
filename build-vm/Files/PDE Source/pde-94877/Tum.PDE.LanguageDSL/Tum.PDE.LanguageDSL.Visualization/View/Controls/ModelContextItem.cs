using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class ModelContextItem : TreeViewItem, ISelectable
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ModelContextItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ModelContextItem;
        }

       /*
        #region ISelectable
 
        /// <summary>
        /// Property to notify the control that it is selected.
        /// </summary>
        public new bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
        public static new readonly DependencyProperty IsSelectedProperty =
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
                            if (!designer.SelectionService.CurrentSelection.Contains(item))
                                designer.SelectionService.AddToSelection(item, false);
                        }
                        else
                        {
                            if (designer.SelectionService.CurrentSelection.Contains(item))
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
        */
    }
}
