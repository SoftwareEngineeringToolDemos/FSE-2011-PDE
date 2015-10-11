using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// This rule handles anchor location changes.
    /// </summary>
    [RuleOn(typeof(SourceAnchor), FireTime = TimeToFire.TopLevelCommit, Priority=1)]
    [RuleOn(typeof(TargetAnchor), FireTime = TimeToFire.TopLevelCommit, Priority=1)]
    public class AnchorAbsoluteLocationChanged : ChangeRule
    {
        /// <summary>
        /// Called whenever elements properties are changed.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);

            if (e.ModelElement == null)
                return;

            if (e.ModelElement.Store.InSerializationTransaction == true)
                return;

            if (e.ModelElement.IsDeleted || e.ModelElement.IsDeleting)
                return;
            
            SourceAnchor sourceAnchor = e.ModelElement as SourceAnchor;
            if (sourceAnchor != null)
            {
                if( sourceAnchor.LinkShape != null )
                    if (sourceAnchor.LinkShape.IsDeleted || sourceAnchor.LinkShape.IsDeleting)
                        return;

                if (e.DomainProperty.Id == Anchor.AbsoluteLocationDomainPropertyId && sourceAnchor.LinkShape != null)
                {
                    if (!sourceAnchor.LinkShape.IsLayoutInProgress)
                    {
                        if (!sourceAnchor.DiscardLocationChange)
                            sourceAnchor.LinkShape.InternalLayout(FixedGeometryPoints.Source);
                        else
                            sourceAnchor.DiscardLocationChange = false;

                    }
                }
            }
            
            TargetAnchor targetAnchor = e.ModelElement as TargetAnchor;
            if (targetAnchor != null)
            {
                if (targetAnchor.LinkShape != null)
                    if (targetAnchor.LinkShape.IsDeleted || targetAnchor.LinkShape.IsDeleting)
                        return;

                if (e.DomainProperty.Id == Anchor.AbsoluteLocationDomainPropertyId && targetAnchor.LinkShape != null)
                {
                    if (!targetAnchor.LinkShape.IsLayoutInProgress)
                    {
                        if (!targetAnchor.DiscardLocationChange)
                            targetAnchor.LinkShape.InternalLayout(FixedGeometryPoints.Target);
                        else
                            targetAnchor.DiscardLocationChange = false;
                    }
                }
            }
        }
    }
}
