using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Serializer LinkShapeSerializer for DomainClass LinkShape.
    /// </summary>
    public partial class LinkShapeSerializer : LinkShapeSerializerBase
    {
        /// <summary>
        /// This method creates an instance of AblaufbausteinpunktRAblaufbausteinspezShape based on the tag currently pointed by the reader. The reader is guaranteed (by the caller)
        /// to be pointed at a serialized instance of AblaufbausteinpunktRAblaufbausteinspezShape.
        /// </summary>
        /// <remarks>
        /// The caller will guarantee that the reader is positioned at open XML tag of the ModelRoot instance being read. This method should
        /// not move the reader; the reader should remain at the same position when this method returns.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        /// <param name="partition">Partition in which new AblaufbausteinpunktRAblaufbausteinspezShape instance should be created.</param>	
        /// <returns>Created AblaufbausteinpunktRAblaufbausteinspezShape instance.</returns>
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

                    string sourceShapeIdStr = reader.GetAttribute("sourceShapeId");
                    string targetShapeIdStr = reader.GetAttribute("targetShapeId");
                    if (string.IsNullOrEmpty(sourceShapeIdStr) || string.IsNullOrEmpty(targetShapeIdStr))
                    {
                        return null;
                    }
                    else
                    {
                        global::System.Guid sourceShapeId = new global::System.Guid(sourceShapeIdStr);
                        global::System.Guid targetShapeId = new global::System.Guid(targetShapeIdStr);

                        NodeShape source = partition.ElementDirectory.FindElement(sourceShapeId) as NodeShape;
                        NodeShape target = partition.ElementDirectory.FindElement(targetShapeId) as NodeShape;

                        if (source == null || target == null)
                        {
                            return null;
                        }


                        if (element == null)
                            element = CanAssignRelationship(source.Element, target.Element);

                        if (element == null || !(element is IDomainModelOwnable))
                            return null;

                        return (element as IDomainModelOwnable).GetDomainModelServices().TopMostService.ShapeProvider.CreateShapeForElementLink(this.GetShapeClassId(), element, new PropertyAssignment[]{ new PropertyAssignment(ElementFactory.IdPropertyAssignment, id)});
                    }
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
            return LinkShape.DomainClassId;
        }

        /// <summary>
        /// Finds out if a relationship can be assigned automatically between the given source
        /// and target element.
        /// </summary>
        /// <remarks>
        /// This method is required becase reference relationship do not need to be serialized
        /// with an id. But shapes still need to be created for them if a visual information
        /// is provided in the diagrams model.
        /// </remarks>
        protected virtual ModelElement CanAssignRelationship(ModelElement source, ModelElement target)
        {
            return null;
        }

        /// <summary>
        /// This method deserializes all properties that are serialized as XML attributes.
        /// </summary>
        /// <remarks>
        /// Because this method only handles properties serialized as XML attributes, the passed-in reader shouldn't be moved inside this method.
        /// The caller will guarantee that the reader is positioned on the open XML tag of the current element being deserialized.
        /// </remarks>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">In-memory LinkShape instance that will get the deserialized data.</param>
        /// <param name="reader">XmlReader to read serialized data from.</param>
        protected override void ReadPropertiesFromAttributes(SerializationContext serializationContext, ModelElement element, System.Xml.XmlReader reader)
        {
            LinkShape instanceOfLinkShape = element as LinkShape;
            global::System.Diagnostics.Debug.Assert(instanceOfLinkShape != null, "Expecting an instance of LinkShape");

            // DummyProperty
            if (!serializationContext.Result.Failed)
            {
                string attribDummyProperty = DiagramsDSLSerializationHelper.Instance.ReadAttribute(serializationContext, element, reader, "dummyProperty");
                if (attribDummyProperty != null)
                {
                    global::System.String valueOfDummyProperty;
                    if (SerializationUtilities.TryGetValue<global::System.String>(serializationContext, attribDummyProperty, out valueOfDummyProperty))
                    {
                        instanceOfLinkShape.DummyProperty = valueOfDummyProperty;
                    }
                    else
                    {	// Invalid property value, ignored.
                        TestDslDefinitionSerializationBehaviorSerializationMessages.IgnoredPropertyValue(serializationContext, reader, "dummyProperty", typeof(global::System.String), attribDummyProperty);
                    }
                }
            }
            // RoutingMode
            if (!serializationContext.Result.Failed)
            {
                string attribRoutingMode = DiagramsDSLSerializationHelper.Instance.ReadAttribute(serializationContext, element, reader, "routingMode");
                if (attribRoutingMode != null)
                {
                    RoutingMode valueOfRoutingMode;
                    if (SerializationUtilities.TryGetValue<RoutingMode>(serializationContext, attribRoutingMode, out valueOfRoutingMode))
                    {
                        instanceOfLinkShape.RoutingMode = valueOfRoutingMode;
                    }
                    else
                    {	// Invalid property value, ignored.
                        TestDslDefinitionSerializationBehaviorSerializationMessages.IgnoredPropertyValue(serializationContext, reader, "routingMode", typeof(RoutingMode), attribRoutingMode);
                    }
                }
            }
            //base.ReadPropertiesFromAttributes(serializationContext, element, reader);
        }

        /// <summary>
        /// Write all properties that need to be serialized as XML attributes.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">LinkShape instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param> 
        protected override void WritePropertiesAsAttributes(Microsoft.VisualStudio.Modeling.SerializationContext serializationContext, Microsoft.VisualStudio.Modeling.ModelElement element, System.Xml.XmlWriter writer)
        {
            base.WritePropertiesAsAttributes(serializationContext, element, writer);

            LinkShape instanceOfLinkShape = element as LinkShape;
            global::System.Diagnostics.Debug.Assert(instanceOfLinkShape != null, "Expecting an instance of LinkShape");

            if (!serializationContext.Result.Failed)
            {
                string serializedPropValue = SerializationUtilities.GetString<Guid>(serializationContext, instanceOfLinkShape.SourceAnchor.FromShape.Id);
                DiagramsDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, element, writer, "sourceShapeId", serializedPropValue);

                serializedPropValue = SerializationUtilities.GetString<Guid>(serializationContext, instanceOfLinkShape.TargetAnchor.ToShape.Id);
                DiagramsDSLSerializationHelper.Instance.WriteAttributeString(serializationContext, element, writer, "targetShapeId", serializedPropValue);
            }
        }
    }
}
