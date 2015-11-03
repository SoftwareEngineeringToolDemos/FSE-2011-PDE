using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This class is used to represent a diagram item on the diagram surface. 
    /// </summary>
    /// <remarks>A diagram item can represent either an element or a link.</remarks>
    public class DiagramDesignerItem : ContentControl, ISelectable, IDiagramDesignerItem
    {
        private DiagramDesigner diagramDesigner = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiagramDesignerItem()
        {
            this.RequestBringIntoView += new RequestBringIntoViewEventHandler(DiagramDesignerItem_RequestBringIntoView);
        }

        void DiagramDesignerItem_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            // no need for a diagram link to be brought into view, since it will not be done correctly anyways
            if (IsDiagramLink)
                e.Handled = true;
            else
            {
                e.Handled = false;
                DiagramRubberbandSelector.IgnoreRubberbandSelectionOnce = true;
                //ParentCanvas.CancelRubberbandSelection();
            }
        }

        #region IDiagramDesignerItem
        /// <summary>
        /// Gets whether this element represents a diagram link or not.
        /// </summary>
        public bool IsDiagramLink
        {
            get { return this.DataContext is IDiagramLinkViewModel; }
        }

        /// <summary>
        /// Gets the absolute location of this item.
        /// </summary>
        public PointD AbsoluteLocation
        {
            get
            {
                if (diagramDesigner == null)
                    diagramDesigner = DiagramHelper.GetDiagramDesigner(this);
                Point loc = this.TranslatePoint(new Point(0, 0), diagramDesigner);

                return new PointD(loc.X, loc.Y);
            }
        }
        #endregion

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

        /// <summary>
        /// Is selected dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected", typeof(bool), typeof(DiagramDesignerItem), new PropertyMetadata(false, new PropertyChangedCallback(IsSelectedPropertyChanged)));
        private static void IsSelectedPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DiagramDesignerItem item = obj as DiagramDesignerItem;
            if( item.DataContext != null )
                if (item != null)
                {
                    DiagramDesigner designer = DiagramHelper.GetDiagramDesigner(item) as DiagramDesigner;
                    if (designer != null)
                    {
                        if ((bool)args.NewValue)
                        {
                            if (!designer.SelectionService.CurrentSelection.Contains(item))
                                designer.SelectionService.AddToSelection(item, false);

                            if (item.IsSelected && !item.IsFocused)
                                item.Focus();
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

        /// <summary>
        /// Update selection.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (this.DataContext is IDiagramLinkViewModel)
            {
                if (DiagramHelper.GetDiagramDesignerLink((DependencyObject)e.MouseDevice.DirectlyOver) == this)
                {
                    UpdateSelection(true);
                    if (!this.IsFocused)
                        this.Focus();

                    e.Handled = false;
                }
            }
            else
            {
                if (DiagramHelper.GetDiagramDesignerItem((DependencyObject)e.MouseDevice.DirectlyOver) == this)
                {
                    UpdateSelection(true);
                    if (!this.IsFocused)
                        this.Focus();

                    e.Handled = false;
                }
            }

            //DiagramDesignerCanvas.IgnoreRubberbandSelection = true;
            base.OnPreviewMouseDown(e);
            //DiagramDesignerCanvas.IgnoreRubberbandSelection = false;
        }

        /// <summary>
        /// Updates the selection for this item.
        /// </summary>
        /// <param name="bSelect">True if this item should be selected; false otherwise.</param>
        protected virtual void UpdateSelection(bool bSelect)
        {
            DiagramDesigner designer = DiagramHelper.GetDiagramDesigner(this) as DiagramDesigner;

            // update selection
            if (designer != null)
            {
                if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != ModifierKeys.None)
                {
                    if (bSelect && this.IsSelected)
                    {
                        designer.SelectionService.RemoveFromSelection(this);
                    }
                    else if( !this.IsSelected)
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

        /// <summary>
        /// Gets the parent diagram designer item. If there is none, null is returned.
        /// </summary>
        public DiagramDesignerCanvas ParentCanvas
        {
            get
            {
                return DiagramHelper.GetDiagramDesignerCanvas(this);
            }
        }

        /// <summary>
        /// Gets the parent diagram designer children host. If there is none, null is returned.
        /// </summary>
        public DiagramDesignerItems ParentChildrenHost
        {
            get
            {
                return DiagramHelper.GetDiagramDesignerItems(this);
            }
        }
    }
}
