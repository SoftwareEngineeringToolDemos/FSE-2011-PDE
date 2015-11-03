using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DslModeling = global::Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// Extension: Exclude view part from saving. Basically this was just copied and pasted from the generated MetaModelSerializer.
    /// The serialization of the view part was just commented out.
    /// </summary>
    public partial class MetaModelSerializer
    {
        /// <summary>
        /// This methods serializes 1) properties serialized as nested XML elements and 2) child model elements into XML. 
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">MetaModel instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>        
        protected override void WriteElements(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer)
        {
            // Always call the base class so any extensions are serialized
            //base.WriteElements(serializationContext, element, writer);

            // Write any additional element data under this XML element
            WriteAdditionalElementData(serializationContext, element, writer);

            MetaModel instance = element as MetaModel;
            global::System.Diagnostics.Debug.Assert(instance != null, "Expecting an instance of MetaModel!");

            // Write child model elements (which are always serialized as nested XML elements).
            if (!serializationContext.Result.Failed)
                WriteChildElementsExtended(serializationContext, instance, writer);
        }

        /// <summary>
        /// Serialize all child model elements.
        /// </summary>
        /// <param name="serializationContext">Serialization context.</param>
        /// <param name="element">MetaModel instance to be serialized.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Generated code.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
        private void WriteChildElementsExtended(DslModeling::SerializationContext serializationContext, MetaModel element, global::System.Xml.XmlWriter writer)
        {
           // MetaModelHasDomainTypes
			global::System.Collections.ObjectModel.ReadOnlyCollection<MetaModelHasDomainTypes> allMetaModelHasDomainTypesInstances = MetaModelHasDomainTypes.GetLinksToDomainTypes(element);
			if (!serializationContext.Result.Failed && allMetaModelHasDomainTypesInstances.Count > 0)
			{
				writer.WriteStartElement("domainTypes");
				global::System.Type typeofMetaModelHasDomainTypes = typeof(MetaModelHasDomainTypes);
				foreach (MetaModelHasDomainTypes eachMetaModelHasDomainTypesInstance in allMetaModelHasDomainTypesInstances)
				{
					if (serializationContext.Result.Failed)
						break;
	
					if (eachMetaModelHasDomainTypesInstance.GetType() != typeofMetaModelHasDomainTypes)
					{	// Derived relationships will be serialized in full-form.
						DslModeling::DomainClassXmlSerializer derivedRelSerializer = serializationContext.Directory.GetSerializer(eachMetaModelHasDomainTypesInstance.GetDomainClass().Id);
						global::System.Diagnostics.Debug.Assert(derivedRelSerializer != null, "Cannot find serializer for " + eachMetaModelHasDomainTypesInstance.GetDomainClass().Name + "!");			
						derivedRelSerializer.Write(serializationContext, eachMetaModelHasDomainTypesInstance, writer);
					}
					else
					{	// No need to serialize the relationship itself, just serialize the role-player directly.
						DslModeling::ModelElement targetElement = eachMetaModelHasDomainTypesInstance.DomainType;
						DslModeling::DomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id);
						global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
						targetSerializer.Write(serializationContext, targetElement, writer);
					}
				}
				writer.WriteEndElement();
			}
	
			// MetaModelHasValidation
			MetaModelHasValidation theMetaModelHasValidationInstance = MetaModelHasValidation.GetLinkToValidation(element);
			if (!serializationContext.Result.Failed && theMetaModelHasValidationInstance != null)
			{
				writer.WriteStartElement("validation");
				DslModeling::DomainClassXmlSerializer relSerializer = serializationContext.Directory.GetSerializer(theMetaModelHasValidationInstance.GetDomainClass().Id);
				global::System.Diagnostics.Debug.Assert(relSerializer != null, "Cannot find serializer for " + theMetaModelHasValidationInstance.GetDomainClass().Name + "!");
				relSerializer.Write(serializationContext, theMetaModelHasValidationInstance, writer);
				writer.WriteEndElement();
			}
	
			// MetaModelHasAdditionalInformation
			MetaModelHasAdditionalInformation theMetaModelHasAdditionalInformationInstance = MetaModelHasAdditionalInformation.GetLinkToAdditionalInformation(element);
			if (!serializationContext.Result.Failed && theMetaModelHasAdditionalInformationInstance != null)
			{
				writer.WriteStartElement("additionalInformation");
				DslModeling::DomainClassXmlSerializer relSerializer = serializationContext.Directory.GetSerializer(theMetaModelHasAdditionalInformationInstance.GetDomainClass().Id);
				global::System.Diagnostics.Debug.Assert(relSerializer != null, "Cannot find serializer for " + theMetaModelHasAdditionalInformationInstance.GetDomainClass().Name + "!");
				relSerializer.Write(serializationContext, theMetaModelHasAdditionalInformationInstance, writer);
				writer.WriteEndElement();
			}
	
			// MetaModelHasMetaModelLibraries
			global::System.Collections.ObjectModel.ReadOnlyCollection<MetaModelHasMetaModelLibraries> allMetaModelHasMetaModelLibrariesInstances = MetaModelHasMetaModelLibraries.GetLinksToMetaModelLibraries(element);
			if (!serializationContext.Result.Failed && allMetaModelHasMetaModelLibrariesInstances.Count > 0)
			{
				writer.WriteStartElement("metaModelLibraries");
				foreach (MetaModelHasMetaModelLibraries eachMetaModelHasMetaModelLibrariesInstance in allMetaModelHasMetaModelLibrariesInstances)
				{
					if (serializationContext.Result.Failed)
						break;
	
					DslModeling::DomainClassXmlSerializer relSerializer = serializationContext.Directory.GetSerializer(eachMetaModelHasMetaModelLibrariesInstance.GetDomainClass().Id);
					global::System.Diagnostics.Debug.Assert(relSerializer != null, "Cannot find serializer for " + eachMetaModelHasMetaModelLibrariesInstance.GetDomainClass().Name + "!");
					relSerializer.Write(serializationContext, eachMetaModelHasMetaModelLibrariesInstance, writer);
				}
				writer.WriteEndElement();
			}
	
            /*
			// MetaModelHasView
			MetaModelHasView theMetaModelHasViewInstance = MetaModelHasView.GetLinkToView(element);
			if (!serializationContext.Result.Failed && theMetaModelHasViewInstance != null)
			{
				DslModeling::DomainClassXmlSerializer relSerializer = serializationContext.Directory.GetSerializer(theMetaModelHasViewInstance.GetDomainClass().Id);
				global::System.Diagnostics.Debug.Assert(relSerializer != null, "Cannot find serializer for " + theMetaModelHasViewInstance.GetDomainClass().Name + "!");
				relSerializer.Write(serializationContext, theMetaModelHasViewInstance, writer);
			}*/
	
			// MetaModelHasModelContexts
			global::System.Collections.ObjectModel.ReadOnlyCollection<MetaModelHasModelContexts> allMetaModelHasModelContextsInstances = MetaModelHasModelContexts.GetLinksToModelContexts(element);
			if (!serializationContext.Result.Failed && allMetaModelHasModelContextsInstances.Count > 0)
			{
				writer.WriteStartElement("modelContexts");
				foreach (MetaModelHasModelContexts eachMetaModelHasModelContextsInstance in allMetaModelHasModelContextsInstances)
				{
					if (serializationContext.Result.Failed)
						break;
	
					DslModeling::DomainClassXmlSerializer relSerializer = serializationContext.Directory.GetSerializer(eachMetaModelHasModelContextsInstance.GetDomainClass().Id);
					global::System.Diagnostics.Debug.Assert(relSerializer != null, "Cannot find serializer for " + eachMetaModelHasModelContextsInstance.GetDomainClass().Name + "!");
					relSerializer.Write(serializationContext, eachMetaModelHasModelContextsInstance, writer);
				}
				writer.WriteEndElement();
			}
	
			// MetaModelHasPropertyGridEditors
			global::System.Collections.ObjectModel.ReadOnlyCollection<MetaModelHasPropertyGridEditors> allMetaModelHasPropertyGridEditorsInstances = MetaModelHasPropertyGridEditors.GetLinksToPropertyGridEditors(element);
			if (!serializationContext.Result.Failed && allMetaModelHasPropertyGridEditorsInstances.Count > 0)
			{
				writer.WriteStartElement("propertyGridEditors");
				global::System.Type typeofMetaModelHasPropertyGridEditors = typeof(MetaModelHasPropertyGridEditors);
				foreach (MetaModelHasPropertyGridEditors eachMetaModelHasPropertyGridEditorsInstance in allMetaModelHasPropertyGridEditorsInstances)
				{
					if (serializationContext.Result.Failed)
						break;
	
					if (eachMetaModelHasPropertyGridEditorsInstance.GetType() != typeofMetaModelHasPropertyGridEditors)
					{	// Derived relationships will be serialized in full-form.
						DslModeling::DomainClassXmlSerializer derivedRelSerializer = serializationContext.Directory.GetSerializer(eachMetaModelHasPropertyGridEditorsInstance.GetDomainClass().Id);
						global::System.Diagnostics.Debug.Assert(derivedRelSerializer != null, "Cannot find serializer for " + eachMetaModelHasPropertyGridEditorsInstance.GetDomainClass().Name + "!");			
						derivedRelSerializer.Write(serializationContext, eachMetaModelHasPropertyGridEditorsInstance, writer);
					}
					else
					{	// No need to serialize the relationship itself, just serialize the role-player directly.
						DslModeling::ModelElement targetElement = eachMetaModelHasPropertyGridEditorsInstance.PropertyGridEditor;
						DslModeling::DomainClassXmlSerializer targetSerializer = serializationContext.Directory.GetSerializer(targetElement.GetDomainClass().Id);
						global::System.Diagnostics.Debug.Assert(targetSerializer != null, "Cannot find serializer for " + targetElement.GetDomainClass().Name + "!");			
						targetSerializer.Write(serializationContext, targetElement, writer);
					}
				}
				writer.WriteEndElement();
			}

        }
    }
}
