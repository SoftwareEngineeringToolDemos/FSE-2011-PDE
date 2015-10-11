using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(DomainModelElement), FireTime = TimeToFire.TopLevelCommit)]
    public class ModelElementDeletingRuleForGRShapes : DeletingRule
    {        
        /// <summary>
        /// Called whenever a model element is beeing deleted.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            base.ElementDeleting(e);

            DomainModelElement modelElement = e.ModelElement as DomainModelElement;
            if (modelElement == null)
                return;

            
            List<Guid> shapes = GraphicalDependencyShapeStore.GetFromStore(modelElement.Id);
            if (shapes != null)
            {
                modelElement.Store.UndoManager.UndoState = UndoState.DisabledNoFlush;
                using (Transaction t = modelElement.Store.TransactionManager.BeginTransaction("", true))
                {

                    for (int i = shapes.Count - 1; i >= 0; i--)
                    {
                        ShapeElement shape = modelElement.Store.ElementDirectory.FindElement(shapes[i]) as ShapeElement;
                        if (shape != null)
                            shape.Delete();
                    }
                    t.Commit();
                }
                modelElement.Store.UndoManager.UndoState = UndoState.Enabled;
            }
        }
    }
}
