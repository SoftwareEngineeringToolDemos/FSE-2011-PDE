using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class ShapeClass
    {
        public override void ModelFinalize(CopyPaste.ModelProtoElement protoElement, CopyPaste.ModelProtoGroupMerger groupMerger)
        {
            base.ModelFinalize(protoElement, groupMerger);

            RootDiagramNode node = new RootDiagramNode(this.Store);
            node.PresentationElementClass = this;

            this.DiagramClass.DiagramClassView.RootDiagramNodes.Add(node);
        }
    }
}
