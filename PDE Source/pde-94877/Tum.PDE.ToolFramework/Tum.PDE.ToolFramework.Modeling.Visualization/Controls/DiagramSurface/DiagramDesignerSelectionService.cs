using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Selection service for the diagram surface.
    /// </summary>
    public class DiagramDesignerSelectionService
    {
        private DiagramDesigner diagramDesigner;
        private List<ISelectable> currentSelection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="diagramDesigner">Designer for which this service is to be initialized.</param>
        public DiagramDesignerSelectionService(DiagramDesigner diagramDesigner)
        {
            this.currentSelection = new List<ISelectable>();
            this.diagramDesigner = diagramDesigner;
        }

        /// <summary>
        /// Selects an item.
        /// </summary>
        /// <param name="item">Item to be selected.</param>
        public void SelectItem(ISelectable item)
        {
            this.ClearSelection(false);
            this.AddToSelection(item);
        }

        /// <summary>
        /// Selects multiple items.
        /// </summary>
        /// <param name="itemsToSelect">Items to select.</param>
        public void SelectItems(System.Collections.ObjectModel.Collection<ISelectable> itemsToSelect)
        {
            ClearSelection(false);
            foreach (ISelectable item in itemsToSelect)
            {
                CurrentSelection.Add(item);
                item.IsSelected = true;
            }

            Notify();
        }

        /// <summary>
        /// Adds an item to selection.
        /// </summary>
        /// <param name="item">Item to add to selection.</param>
        public void AddToSelection(ISelectable item)
        {
            AddToSelection(item, true);
        }

        /// <summary>
        /// Adds an item to selection.
        /// </summary>
        /// <param name="item">Item to add to selection.</param>
        /// <param name="bNotify">True to notify of this selection change. False otherwise.</param>
        public void AddToSelection(ISelectable item, bool bNotify)
        {
            if (item is ISelectable)
            {
                if( !CurrentSelection.Contains(item) )
                    CurrentSelection.Add(item);
                item.IsSelected = true;
            }

            if( bNotify )
                Notify();
        }

        /// <summary>
        /// Removes an item from the selection.
        /// </summary>
        /// <param name="item">Item to be removed from the selection.</param>
        public void RemoveFromSelection(ISelectable item)
        {
            RemoveFromSelection(item, true);
        }

        /// <summary>
        /// Removes an item from the selection.
        /// </summary>
        /// <param name="item">Item to be removed from the selection.</param>
        /// <param name="bNotify">True to notify of this selection change. False otherwise.</param>
        public void RemoveFromSelection(ISelectable item, bool bNotify)
        {
            if (CurrentSelection.Contains(item))
                CurrentSelection.Remove(item);
            item.IsSelected = false;

            if( bNotify )
                Notify();
        }

        /// <summary>
        /// Clears selection.
        /// </summary>
        /// <param name="bNotify">True if notification of this change is required. False if this is an internal clear command.</param>
        public void ClearSelection(bool bNotify)
        {
            if (CurrentSelection.Count == 0)
                return;

            for (int i = CurrentSelection.Count - 1; i >= 0; i--)
                CurrentSelection[i].IsSelected = false;
            CurrentSelection.Clear();

            if (bNotify)
                Notify();
        }

        /// <summary>
        /// Notifies the diagram of change by updating the selected items property.
        /// </summary>
        public virtual void Notify()
        {
            Collection<object> data = new Collection<object>();
            foreach(ISelectable selectable in this.CurrentSelection)
                data.Add(selectable.SelectedData);

            //if (this.diagramDesigner.SelectedItems != null)
            //    if (this.diagramDesigner.SelectedItems.Count == 0 && data.Count == 0)
            //        return;

            this.DiagramDesigner.SelectedItems = data;
        }

        /// <summary>
        /// Gets the currently selected items.
        /// </summary>
        public List<ISelectable> CurrentSelection
        {
            get
            {
                return currentSelection;
            }
        }

        /// <summary>
        /// Gets the diagram designer, for which this selection service is active.
        /// </summary>
        public DiagramDesigner DiagramDesigner
        {
            get { return diagramDesigner; }
        }        
    }
}
