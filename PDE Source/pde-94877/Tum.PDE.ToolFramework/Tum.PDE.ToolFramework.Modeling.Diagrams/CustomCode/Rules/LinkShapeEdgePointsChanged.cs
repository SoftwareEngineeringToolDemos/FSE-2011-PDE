using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(LinkShape), FireTime = TimeToFire.TopLevelCommit)]
    public class LinkShapeEdgePointsChanged : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);

            if (e.ModelElement == null)
                return;

            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            if (e.ModelElement.IsDeleting || e.ModelElement.IsDeleted)
                return;

            LinkShape linkShape = e.ModelElement as LinkShape;
            if (linkShape != null)
            {
                if (e.DomainProperty.Id == LinkShape.EdgePointsDomainPropertyId)
                {
                    linkShape.UpdateAnchorPlacement();
                }
            }
        }
    }
}
