using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This class represents the global diagram surface of a diagram.
    /// </summary>
    public class DiagramDesigner : ContentControl, IDiagramDesigner
    {
        private DiagramDesignerSelectionService selectionService;
        private Point mousePositionOnDrag;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DiagramDesigner()
            : base()
        {
            this.selectionService = new DiagramDesignerSelectionService(this);
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(DiagramDesigner_DataContextChanged);
        }

        void DiagramDesigner_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if( this.DataContext is IDiagramViewModel)
                (this.DataContext as IDiagramViewModel).DiagramDesigner = this;
        }

        /// <summary>
        /// Notify view model of key down.
        /// </summary>
        /// <param name="e">The System.Windows.Input.KeyEventArgs that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.DataContext is IDiagramViewModel)
            {
                e.Handled = (this.DataContext as IDiagramViewModel).HandleKeyDown(e);
            }

            base.OnKeyDown(e);
        }
        
        /// <summary>
        /// Whenever context menu opens, verify if it has items. If not, disallow opening.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContextMenuOpening(ContextMenuEventArgs e)
        {
            this.ContextMenu.ItemsSource = ContextMenuOptions;

            if (this.ContextMenu.Items.Count == 0)
                e.Handled = true;

            base.OnContextMenuOpening(e);
        }

        /// <summary>
        /// Whenever context menu closes, reset its items..
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContextMenuClosing(ContextMenuEventArgs e)
        {
            this.ContextMenu.ItemsSource = null;

            base.OnContextMenuClosing(e);
        }

        /// <summary>
        /// Updates the clicked point value, which is always relative to the source of the click event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            Point point = e.GetPosition(e.MouseDevice.DirectlyOver);
            
            ClickedPoint = new PointD(point.X, point.Y);
        }

        /// <summary>
        /// Drag enter event: Taken to track mouse location, as 
        /// Mouse.GetPosition does not work properly in GetCurrentMousePosition
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewDragEnter(DragEventArgs e)
        {
            mousePositionOnDrag = e.GetPosition(this);

            base.OnPreviewDragEnter(e);
        }

        /// <summary>
        /// Drag over event: Taken to track mouse location, as 
        /// Mouse.GetPosition does not work properly in GetCurrentMousePosition
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewDragOver(DragEventArgs e)
        {
            mousePositionOnDrag = e.GetPosition(this);

            base.OnPreviewDragOver(e);
        }

        /// <summary>
        /// Gets the parent object of the type ISelectable starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        private DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is ISelectable)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }

        /// <summary>
        /// Gets the current mouse position relative to the diagram designer.
        /// </summary>
        /// <returns>Mouse position relative to the diagram designer coordinates.</returns>
        public PointD GetCurrentMousePosition()
        {
            Point point = Mouse.GetPosition(this);    
            if( point.X< 0 || point.Y < 0 )
                return new PointD(mousePositionOnDrag.X, mousePositionOnDrag.Y);    
            return new PointD(point.X, point.Y);
        }

        /// <summary>
        /// Gets the current mouse position relative to the selected element.
        /// </summary>
        /// <returns>Mouse position relative to the selected element coordinates.</returns>
        public PointD GetCurrentMousePositionOnSelectedElement()
        {
            if (this.SelectionService.CurrentSelection.Count == 1)
            {
                Point point = Mouse.GetPosition(this.SelectionService.CurrentSelection[0] as IInputElement);
                if( point.X< 0 || point.Y < 0 )
                    return PointD.Empty;
                else
                    return new PointD(point.X, point.Y);
            }

            return PointD.Empty;
        }

        /// <summary>
        /// Gets the item that is directly under the mouse.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>Item under the mouse or null.</returns>
        public object GetItemAtPosition(PointD position)
        {
            DiagramDesignerItem hitItem = null;
            DependencyObject hitObject = this.InputHitTest(position.ToPoint()) as DependencyObject;
            while (hitObject != null)
            {
                if (hitObject is DiagramDesignerItem)
                {
                    hitItem = hitObject as DiagramDesignerItem;
                    break;
                }

                hitObject = VisualTreeHelper.GetParent(hitObject);
            }
            if (hitItem != null)
                return hitItem.DataContext;
            else
                return null;
        }

        /// <summary>
        /// Gets the selection service, that is active for this diagram.
        /// </summary>
        public DiagramDesignerSelectionService SelectionService
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
          DependencyProperty.Register("SelectedItems", typeof(Collection<object>), typeof(DiagramDesigner), new PropertyMetadata(null, new PropertyChangedCallback(SelectedItemsPropertyChanged)));
        private static void SelectedItemsPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DiagramDesigner designer = obj as DiagramDesigner;
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
                        // TODO
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the create relationship command.
        /// </summary>
        public DelegateCommand<ViewModelRelationshipCreationInfo> CreateRelationshipCommand
        {
            get { return GetValue(CreateRelationshipCommandProperty) as DelegateCommand<ViewModelRelationshipCreationInfo>; }
            set
            {
                SetValue(CreateRelationshipCommandProperty, value);
            }
        }

        /// <summary>
        /// Create relationship command property.
        /// </summary>
        public static readonly DependencyProperty CreateRelationshipCommandProperty =
          DependencyProperty.Register("CreateRelationshipCommand", typeof(DelegateCommand<ViewModelRelationshipCreationInfo>), typeof(DiagramDesigner), new PropertyMetadata(null));

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
            DependencyProperty.Register("ContextMenuOptions", typeof(IEnumerable), typeof(DiagramDesigner), new PropertyMetadata(null));

        /// <summary>
        /// Clicked point.
        /// </summary>
        public PointD ClickedPoint
        {
            get { return (PointD)GetValue(ClickedPointProperty); }
            set { SetValue(ClickedPointProperty, value); }
        }

        /// <summary>
        /// Clicked point property.
        /// </summary>
        public static readonly DependencyProperty ClickedPointProperty =
            DependencyProperty.Register("ClickedPoint", typeof(PointD), typeof(DiagramDesigner), new PropertyMetadata(PointD.Empty));
    }
}
