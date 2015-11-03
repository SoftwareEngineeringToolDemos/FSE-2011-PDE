using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class NodeShapeSerializer
    {
        /// <summary>
        /// This method creates an instance of AblaufbausteinShape based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
        /// to be pointed at a serialized instance of AblaufbausteinShape.
        /// </summary>
        /// <remarks>
        /// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
        /// not move the reader; the reader should remain at the same position when this method returns.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        /// <param name="partition">Partition in which new AblaufbausteinShape instance should be created.</param>	
        /// <returns>Created AblaufbausteinShape instance.</returns>
        protected override ModelElement CreateInstance(SerializationContext serializationContext, global::System.Xml.XmlReader reader, Partition partition)
        {
            string idStr = reader.GetAttribute("Id");
            try
            {
                global::System.Guid id;
                if (string.IsNullOrEmpty(idStr))
                {	// Create a default Id.
                    id = global::System.Guid.NewGuid();
                    TestDslDefinitionSerializationBehaviorSerializationMessages.MissingId(serializationContext, reader, id);
                }
                else
                {
                    id = new global::System.Guid(idStr);
                }

                string elementIdStr = reader.GetAttribute("internalElementId");
                if (string.IsNullOrEmpty(elementIdStr))
                {
                    return null;
                }
                else
                {
                    global::System.Guid elementId = new global::System.Guid(elementIdStr);
                    ModelElement element = null;
                    if (elementId != System.Guid.Empty)
                        element = partition.ElementDirectory.FindElement(elementId);

                    if (element == null || !(element is IDomainModelOwnable))
                        return null;

                    return (element as IDomainModelOwnable).GetDomainModelServices().TopMostService.ShapeProvider.CreateShapeForElement(this.GetShapeClassId(), element,
                        new PropertyAssignment[]{ new PropertyAssignment(ElementFactory.IdPropertyAssignment, id)});
                }
            }
            catch (global::System.ArgumentNullException /* anEx */)
            {
                TestDslDefinitionSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
            }
            catch (global::System.FormatException /* fEx */)
            {
                TestDslDefinitionSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
            }
            catch (global::System.OverflowException /* ofEx */)
            {
                TestDslDefinitionSerializationBehaviorSerializationMessages.InvalidPropertyValue(serializationContext, reader, "Id", typeof(global::System.Guid), idStr);
            }
            return null;
        }		

        /// <summary>
        /// Gets the shape class Id.
        /// </summary>
        /// <returns></returns>
        public virtual Guid GetShapeClassId()
        {
            return NodeShape.DomainClassId;
        }
    }
}
