using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Base abstract class representing a diagram item vm.
    /// </summary>
    public abstract class BaseDiagramItemViewModel : BaseModelElementViewModel
    {
        private ShapeElement shapeElement;
        private DiagramSurfaceViewModel sufaceDiagram;

        private bool isSelected = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Shape element to be associated with this vm.</param>
        protected BaseDiagramItemViewModel(ViewModelStore viewModelStore, DiagramSurfaceViewModel diagram, ShapeElement shapeElement)
            : base(viewModelStore, shapeElement.Element, true, false)
        {
            this.sufaceDiagram = diagram;
            this.shapeElement = shapeElement;

            this.Initialize();
        }

        /// <summary>
        /// Gets the shape element, that is hosted by this view model.
        /// </summary>
        public ShapeElement ShapeElement
        {
            get { return this.shapeElement; }
            set
            {
                this.shapeElement = value;
                OnPropertyChanged("ShapeElement");
            }
        }

        /// <summary>
        /// Gets/sets whether the item is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Gets the diagram this item belongs to.
        /// </summary>
        public DiagramSurfaceViewModel Diagram
        {
            get { return this.sufaceDiagram; }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.shapeElement = null;
            this.sufaceDiagram = null;

            base.OnDispose();
        }

        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        public abstract bool AutomaticallyDeletesHostedElement { get; }
    }
}
