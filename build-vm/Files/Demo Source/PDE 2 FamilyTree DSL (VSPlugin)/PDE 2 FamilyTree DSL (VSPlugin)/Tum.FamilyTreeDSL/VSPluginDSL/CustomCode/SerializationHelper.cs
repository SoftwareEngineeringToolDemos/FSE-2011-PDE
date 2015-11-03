using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslEditorModeling = Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
    public partial class FamilyTreeDSLSerializationHelper
    {
        /// <summary>
        /// This method is called during deserialization to convert a given value to a specific typed value (Double?).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Type, the object is to be converted to.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>
        public override global::System.Double? ConvertTypedObjectDoubleFrom(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired)
        {
            if (value is string)
            {
                if (String.IsNullOrEmpty(value as string))
                    return null;

                if (String.IsNullOrWhiteSpace(value as string))
                    return null;

                try
                {
                    System.Double? d = Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture);
                    return d;
                }
                catch (Exception ex)
                {
                    serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                         DslModeling::SerializationMessageKind.Error, "Couldnt convert " + value + " to Double: " + ex.ToString(), "", 0, 0, null));
                }
            }

            return null;
        }

        /// <summary>
        /// This method is called during serialization to convert a given typed value (Double?) to a specific value (string).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Typed value to convert.</param>
        /// <param name="sourceType">Type of the value.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>		
        public override object ConvertTypedObjectDoubleTo(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired)
        {
            if (value != null)
            {
                if (value is Double)
                {
                    return ((Double)value).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            return "";
        }

        /// <summary>
        /// This method is called during deserialization to convert a given value to a specific typed value (Int32?).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Type, the object is to be converted to.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>
        public override global::System.Int32? ConvertTypedObjectInt32From(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired)
        {
            if (value is string)
            {
                if (String.IsNullOrEmpty(value as string))
                    return null;

                if (String.IsNullOrWhiteSpace(value as string))
                    return null;

                try
                {
                    System.Int32? d = Convert.ToInt32(value, System.Globalization.CultureInfo.InvariantCulture);
                    return d;
                }
                catch (Exception ex)
                {
                    serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                         DslModeling::SerializationMessageKind.Error, "Couldnt convert " + value + " to Int: " + ex.ToString(), "", 0, 0, null));
                }
            }

            return null;
        }

        /// <summary>
        /// This method is called during serialization to convert a given typed value (Int32?) to a specific value (string).
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
        /// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Typed value to convert.</param>
        /// <param name="sourceType">Type of the value.</param>
        /// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>		
        public override object ConvertTypedObjectInt32To(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired)
        {
            if (value != null)
            {
                if (value is Int32)
                {
                    return ((Int32)value).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            return "";
        }
    }
}
