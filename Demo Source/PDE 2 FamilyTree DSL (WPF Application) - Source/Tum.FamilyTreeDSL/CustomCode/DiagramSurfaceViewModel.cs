using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Diagrams.Layout;
using Microsoft.VisualStudio.Modeling;

namespace Tum.FamilyTreeDSL.ViewModel
{
    public partial class FamilyTreeDSLDesignerDiagramSurfaceViewModel
    {
        /*
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnUndoCommandExecuted()
        {
            base.OnUndoCommandExecuted();

            //this.Layout();
        }

        protected override void OnRedoCommandExecuted()
        {
            base.OnRedoCommandExecuted();

            //this.Layout();
        }

        private void Layout()
        {
            if (this.Store.InUndoRedoOrRollback)
            {
                return;
            }

            // disable undo manager
            this.Store.UndoManager.UndoState = UndoState.DisabledNoFlush;

            // create transation to apply layout information
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("Layout"))
            {
                // layout diagram    
                DiagramLayouter.Layout(this.Diagram);

                t.Commit();
            }

            // enable undo manager
            this.Store.UndoManager.UndoState = UndoState.Enabled;
        }

        public override void OnChildShapeElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs args)
        {
            base.OnChildShapeElementAdded(args);

            this.Layout();
        }

        public override void OnChildShapeElementRemoved(ElementDeletedEventArgs args)
        {
            base.OnChildShapeElementRemoved(args);

            this.Layout();
        }

        public override void OnLinkShapeElementAdded(ElementAddedEventArgs args)
        {
            base.OnLinkShapeElementAdded(args);

            this.Layout();
        }

        public override void OnLinkShapeElementRemoved(ElementDeletedEventArgs args)
        {
            base.OnLinkShapeElementRemoved(args);

            this.Layout();
        }

        */

        protected override bool CanCreateRelationshipShapeMarriedToShape(PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface.ViewModelRelationshipCreationInfo info)
        {
            FamilyTreePerson source = info.Source.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
            FamilyTreePerson target = info.Target.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson;

            if (source == null || target == null)
                return false;

            if (source.Husband != null || source.Wife != null)
                return false;

            if (target.Husband != null || target.Wife != null)
                return false;

            if (source == target)
                return false;

            return base.CanCreateRelationshipShapeMarriedToShape(info);
        }

        protected override bool CanCreateRelationshipShapeParentOfShape(PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface.ViewModelRelationshipCreationInfo info)
        {
            FamilyTreePerson source = info.Source.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson;
            FamilyTreePerson target = info.Target.Element as global::Tum.FamilyTreeDSL.FamilyTreePerson;

            if (source == null || target == null)
                return false;

            if (source == target)
                return false;

            if (HasChild(target, source))
                return false;

            return base.CanCreateRelationshipShapeParentOfShape(info);
        }

        private bool HasChild(FamilyTreePerson parent, FamilyTreePerson child)
        {
            if (parent.Children.Contains(child))
                return true;

            foreach (FamilyTreePerson c in parent.Children)
                if (HasChild(c, child))
                    return true;

            return false;
        }
    }
}