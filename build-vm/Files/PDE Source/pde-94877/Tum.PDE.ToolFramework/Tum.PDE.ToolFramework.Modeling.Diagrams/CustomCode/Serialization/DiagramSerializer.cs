using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class DiagramSerializer
    {
        /// <summary>
        /// This methods deserializes nested XML elements inside the passed-in element.
        /// </summary>
        /// <remarks>
        /// The caller will guarantee that the current element does have nested XML elements, and the call will position the 
        /// reader at the open tag of the first child XML element.
        /// This method will read as many child XML elements as it can. It returns under three circumstances:
        /// 1) When an unknown child XML element is encountered. In this case, this method will position the reader at the open 
        ///    tag of the unknown element. This implies that if the first child XML element is unknown, this method should return 
        ///    immediately and do nothing.
        /// 2) When all child XML elemnets are read. In this case, the reader will be positioned at the end tag of the parent element.
        /// 3) EOF.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">In-memory Diagram instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        protected override void ReadElements(SerializationContext serializationContext, ModelElement element, global::System.Xml.XmlReader reader)
        {
            // Always call the base class so any extensions are deserialized
            base.ReadElements(serializationContext, element, reader);

            Diagram instanceOfDiagram = element as Diagram;

            foreach (Diagram d in instanceOfDiagram.IncludedDiagrams)
                instanceOfDiagram.AddIncludedDiagram(d);

            bool bRet = false;
            using (Transaction tShape = element.Store.TransactionManager.BeginTransaction("Correct children", true))
            {
                bRet = instanceOfDiagram.CorrectChildren();
                tShape.Commit();
            }

            // post process element shapes and their positions
            if (bRet)
            {
                // delete link shapes with FromShape or ToShape set to null
                for (int i = instanceOfDiagram.LinkShapes.Count - 1; i >= 0; i--)
                    if (instanceOfDiagram.LinkShapes[i].ToShape == null ||
                        instanceOfDiagram.LinkShapes[i].FromShape == null)
                        instanceOfDiagram.LinkShapes[i].Delete();

                // fixup shapes
                using (Transaction tShape = element.Store.TransactionManager.BeginTransaction("Fixup missing shapes", true))
                {
                    foreach (NodeShape shape in instanceOfDiagram.Children)
                        shape.FixUpMissingShapes();
                    tShape.Commit();
                }

                // fixup link shapes
                using (Transaction tShape = element.Store.TransactionManager.BeginTransaction("Fixup link shapes shape", true))
                {
                    foreach(NodeShape shape in instanceOfDiagram.Children)
                        shape.FixUpMissingLinkShapes();
                    tShape.Commit();
                }
            }

            // post process link shapes and anchor locations
            foreach (LinkShape shape in instanceOfDiagram.LinkShapes)
                if (shape.EdgePoints.Count > 1)
                {
                    if (shape.SourceAnchor.AbsoluteLocation == PointD.Empty)
                        shape.SourceAnchor.AbsoluteLocation = shape.EdgePoints[0].Point;

                    if (shape.TargetAnchor.AbsoluteLocation == PointD.Empty)
                        shape.TargetAnchor.AbsoluteLocation = shape.EdgePoints[shape.EdgePoints.Count-1].Point;
                }
        }
    }
}
