using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslEditorModeling = Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions
{
    /// <summary>
    /// Serialization helper.
    /// </summary>
    public static class SerializationHelper
    {
        /// <summary>
        /// This method is called during deserialization to convert a given id as string to the id of type Guid as used by the domain model.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="id">Id as string.</param>
        /// <returns>Converted value, Id as Guid.</returns>
        public static Guid ConvertIdFrom(DslModeling::SerializationContext serializationContext, string id)
        {
            try
            {
                return KeyGenerator.Instance.ConvertVModellIDToGuid(id);
            }
            catch (Exception ex)
            {
                serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                     DslModeling::SerializationMessageKind.Error, "Couldnt convert " + id + " to Guid: " + ex.ToString(), "", 0, 0, null));

                return Guid.Empty;
            }
        }

        /// <summary>
        /// This method is called during serialization to convert a given id to its specific string representation.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="id">Id.</param>
        /// <returns>Converted value.</returns>
        public static string ConvertIdTo(DslModeling::SerializationContext serializationContext, Guid id)
        {
            return KeyGenerator.Instance.ConvertGuidToVModellID(id);
        }

        /// <summary>
        /// This method is called during deserialization to convert a given value to a specific typed value (Html).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Type, the object is to be converted to.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>
        public static Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html ConvertTypedObjectHtmlFrom(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired)
        {
            if (value == null)
                return null;

            string strValue = value.ToString();
            if (!String.IsNullOrEmpty(strValue) && modelELement is DslEditorModeling::IDomainModelOwnable)
            {
                DslEditorModeling::IParentModelElement parent;
                if (modelELement is DslEditorModeling::IParentModelElement)
                    parent = modelELement as DslEditorModeling::IParentModelElement;
                else
                    parent = (modelELement as DslEditorModeling::IDomainModelOwnable).GetDomainModelServices().ElementParentProvider.GetParentModelElement(modelELement);
                if (parent != null)
                {
                    string filePath = parent.DomainFilePath;
                    string directory = new System.IO.FileInfo(filePath).DirectoryName;

                    Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html html = new Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html(strValue, directory);
                    return html;
                }
                else
                {
                    serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(DslModeling::SerializationMessageKind.Error,
                        "Could not resolve domain directory path.", modelELement.ToString(), 0, 0, null));
                }

            }
            else
                return null;

            return null;
        }

        /// <summary>
        /// This method is called during serialization to convert a given typed value (Html) to a specific value (string).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Typed value to convert.</param>
        /// <param name="sourceType">Type of the value.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>		
        public static object ConvertTypedObjectHtmlTo(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired)
        {
            Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html strValue = value as Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html;
            if (strValue != null)
                return strValue.HtmlData;
            else
            {
                if (isRequired != null)
                    // Important: This is needed, otherwise export will fail! (as long as we still use this extern export)
                    if (isRequired.Value == true)
                        return "";
                return null;
            }
        }
    }
}
