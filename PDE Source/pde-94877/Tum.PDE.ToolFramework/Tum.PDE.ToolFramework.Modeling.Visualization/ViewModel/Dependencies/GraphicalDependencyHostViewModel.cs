using System;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This vm is used to group dependency shapes together.
    /// </summary>
    public class GraphicalDependencyHostViewModel : DiagramItemElementViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GraphicalDependencyHostViewModel(ViewModelStore viewModelStore, GraphicalDependenciesViewModel diagram, GraphicalDependencyShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }

        /// <summary>
        /// Never delete hosted element.
        /// </summary>
        public override bool AutomaticallyDeletesHostedElement
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the diagram this item belongs to.
        /// </summary>
        public new GraphicalDependenciesViewModel Diagram
        {
            get { return base.Diagram as GraphicalDependenciesViewModel; }
        }

        /// <summary>
        /// Add nested children.
        /// </summary>
        /// <param name="con"></param>
        protected override void OnNestedChildShapeElementAdded(NodeShapeReferencesNestedChildren con)
        {
            DomainClassInfo info = con.ChildShape.GetDomainClass();
            if (info.Id != NodeShape.DomainClassId)
            {
                DiagramItemElementViewModel elementVM = this.ViewModelStore.Factory.CreateDiagramItemViewModel(
                    info.Id, this.Diagram, con.ChildShape);

                if (elementVM != null)
                {
                    this.Diagram.AddElement(elementVM);
                    return;
                }
            }

            GraphicalDependencyItemViewModel vm = new GraphicalDependencyItemViewModel(
                                    this.ViewModelStore, this.Diagram, con.ChildShape);
            this.Diagram.AddElement(vm);
        }

        /// <summary>
        /// Remove nested children.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnNestedChildShapeElementRemoved(Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs args)
        {
            NodeShapeReferencesNestedChildren con = args.ModelElement as NodeShapeReferencesNestedChildren;
            NodeShape nodeShape = con.ChildShape;
            if (nodeShape != null)
            {
                for (int i = this.Diagram.Children.Count - 1; i >= 0; i--)
                {
                    if (this.Diagram.Children[i].ShapeElement.Id == nodeShape.Id)
                    {
                        this.Diagram.RemoveElement(this.Diagram.Children[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="con"></param>
        protected override void OnRelativeChildShapeElementAdded(NodeShapeReferencesRelativeChildren con)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Cant have relative children.
        /// </summary>
        public override bool CanHaveRelativeChildren
        {
            get { return false; }
        }

        /// <summary>
        /// Has nested children.
        /// </summary>
        public override bool CanHaveNestedChildren
        {
            get { return true; }
        }

        /// <summary>
        /// Name of the represented relationship.
        /// </summary>
        public string RelationshipName
        {
            get
            {
                if (this.ShapeElement is GraphicalDependencyShape)
                {
                    return (this.ShapeElement as GraphicalDependencyShape).RelationshipName;
                }

                return "";
            }
        }
    }
}
