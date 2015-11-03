using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(NodeShape), FireTime = TimeToFire.TopLevelCommit, Priority= -1)]
    public class NodeShapeBoundsChangedRule : ChangeRule
    {
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);

            if (e.ModelElement == null)
                return;

            if (e.ModelElement.Store.InSerializationTransaction )
                return;

            NodeShape nodeShape = e.ModelElement as NodeShape;
            if (nodeShape != null)
            {
                if (e.DomainProperty.Id == NodeShape.LocationDomainPropertyId)
                {
                    PointD oldLocation = (PointD)e.OldValue;
                    PointD newLocation = (PointD)e.NewValue;

                    nodeShape.CorrectLinkShapesOnLocationChanged(oldLocation, newLocation);
                }
                else if(e.DomainProperty.Id == NodeShape.SizeDomainPropertyId)
                {
                    SizeD oldSize = (SizeD)e.OldValue;
                    SizeD newSize = (SizeD)e.NewValue;

                    if( oldSize.Width != 0.0 && oldSize.Height != 0.0 )
                        nodeShape.CorrectLinkShapesOnSizeChanged(oldSize, newSize);
                }
            }
        }
    }

}
