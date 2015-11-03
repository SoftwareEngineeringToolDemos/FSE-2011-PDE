 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	partial class PDEModelingDSLDomainModel
	{
		///<Summary>
		/// Provide an implementation of the partial method to set up the serialization behavior for this model.
		///</Summary>
		///<remarks>
		/// This partial method is called from the constructor of the domain class.
		///</remarks>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance","CA1822:MarkMembersAsStatic", Justification="Alternative implementations might need to reference instance variables, so not marked as static.")]
		partial void InitializeSerialization(DslModeling::Store store)
		{
			// Register the serializers and moniker resolver for this model
			 PDEModelingDSLSerializationHelper.Instance.InitializeSerialization(store);	
		}
	}
}

namespace Tum.PDE.ModelingDSL
{
		
	/// <summary>
	/// Helper class for serializing and deserializing PDEModelingDSL models.
	/// </summary>
	public abstract partial class PDEModelingDSLSerializationHelperBase : DslEditorModeling::SerializationHelper
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		protected PDEModelingDSLSerializationHelperBase() { }
		#endregion
		
		#region Methods
		/// <summary>
        /// Write schema definitions.
        /// </summary>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="modelContextName">Name of the model context.</param>
		/// <param name="domainModelName">Name of the domain model.</param>
        public virtual void WriteSchemaDefinitions(global::System.Xml.XmlWriter writer, string modelContextName, string domainModelName)
        {
        }
		
		/// <summary>
		/// Return the directory of serializers to use
		/// </summary>
		protected virtual DslModeling::DomainXmlSerializerDirectory GetDirectory(DslModeling::Store store)
		{
			// Just return the default serialization directory from the store
			return store.SerializerDirectory;
		}		
	
		/// <Summary>
		/// Called by the serialization helper to allow any necessary setup to be done on each load / save.
		/// </Summary>
		/// <param name="partition">The partition being serialized.</param>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="isLoading">Flag to indicate whether the file is being loaded or saved.</param>
		/// <Remarks>The base implementation does nothing</Remarks>
		protected virtual void InitializeSerializationContext(DslModeling::Partition partition, DslModeling::SerializationContext serializationContext, bool isLoading)
		{
		}
		
		/// <summary>
		/// Attempts to return the encoding used by the reader.
		/// </summary>
		/// <remarks>
		/// The reader will be positioned at the start of the document when calling this method.
		/// </remarks>
		protected virtual bool TryGetEncoding(global::System.Xml.XmlReader reader, out global::System.Text.Encoding encoding)
		{
			global::System.Diagnostics.Debug.Assert(reader.NodeType == System.Xml.XmlNodeType.XmlDeclaration, "reader should be at the XmlDeclaration node when calling this method");
	
			encoding = null;
			// Attempt to read and parse the "encoding" attribute from the XML declaration node
			if (reader.NodeType == global::System.Xml.XmlNodeType.XmlDeclaration)
			{
				string encodingName = reader.GetAttribute("encoding");
				if (!string.IsNullOrWhiteSpace(encodingName))
				{
					encoding = global::System.Text.Encoding.GetEncoding(encodingName);
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Creates and returns the settings used when reading a file.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="isDiagram">Indicates whether a diagram or model file is currently being serialized.</param>
		internal virtual global::System.Xml.XmlReaderSettings CreateXmlReaderSettings(DslModeling::SerializationContext serializationContext, bool isDiagram)
		{
			return new global::System.Xml.XmlReaderSettings();
		}
		
		/// <summary>
		/// Creates and returns the settings used when writing a file.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="isDiagram">Indicates whether a diagram or model file is currently being serialized.</param>
		/// <param name="encoding">The encoding to use when writing the file.</param>
		internal virtual global::System.Xml.XmlWriterSettings CreateXmlWriterSettings(DslModeling::SerializationContext serializationContext, bool isDiagram, global::System.Text.Encoding encoding)
		{
			global::System.Xml.XmlWriterSettings settings = new global::System.Xml.XmlWriterSettings();
			settings.Indent = true;
			settings.Encoding = encoding;
	        settings.CheckCharacters = true;

			return settings;
		}
		
		/// <summary>
        /// This method is called to copy any existing validation messages (that were added during conversion).
        /// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="validatable">Class that can be validated.</param>
		public virtual void CopyValidationMessages(DslModeling::SerializationContext serializationContext, DslEditorModeling::IValidatable validatable)
		{
			foreach(DslEditorModeling::IValidationMessage message in validatable.ValidationResult)
			{
                DslModeling.SerializationMessageKind kind = DslModeling.SerializationMessageKind.Error;
                if (message.Type == DslEditorModeling.ModelValidationViolationType.Message)
                    kind = DslModeling.SerializationMessageKind.Info;
                else if (message.Type == DslEditorModeling.ModelValidationViolationType.Warning)
                    kind = DslModeling.SerializationMessageKind.Warning;
			    
				serializationContext.Result.AddMessage(new DslModeling.SerializationMessage(kind,
                    message.Description, validatable.ToString(), 0, 0, null));
			}
		}

		/// <summary>
        /// This method is called during deserialization to convert a given value to a specific typed value.
        /// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
		/// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Type, the object is to be converted to.</param>
		/// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>
		public virtual object ConvertTypedObjectFrom(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired)
		{
			if (targetType == typeof(global::System.Boolean?) && value is string)
            {
                if (System.String.IsNullOrEmpty(value as string))
                    return null;

                if (System.String.IsNullOrWhiteSpace(value as string))
                    return null;

                try
                {
                    System.Boolean? d = System.Convert.ToBoolean(value, System.Globalization.CultureInfo.InvariantCulture);
                    return d;
                }
                catch (System.Exception ex)
                {
                    serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                         DslModeling::SerializationMessageKind.Error, "Couldnt convert " + value + " to Boolean: " + ex.ToString(), "", 0, 0, null));
                }
            }
			if (targetType == typeof(global::System.Guid?) && value is string)
            {
				if (System.String.IsNullOrEmpty(value as string))
                    return null;

                if (System.String.IsNullOrWhiteSpace(value as string))
                    return null;
				
                try
                {
                    System.Guid? d = new System.Guid(value as string);
                    return d;
                }
                catch (System.Exception ex)
                {
                    serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                         DslModeling::SerializationMessageKind.Error, "Couldnt convert " + value + " to Guid: " + ex.ToString(), "", 0, 0, null));
                }
			}
 			if (targetType == typeof(global::System.Int32?))
			{
				return ConvertTypedObjectInt32From(serializationContext, modelELement, propertyName, value, targetType, isRequired);
			}
 			if (targetType == typeof(global::System.Double?))
			{
				return ConvertTypedObjectDoubleFrom(serializationContext, modelELement, propertyName, value, targetType, isRequired);
			}
			if( targetType == typeof(global::Tum.PDE.ModelingDSL.ShapeColorType?) && value != null )
			{
				string strValue = value.ToString();
				switch(strValue)
				{
					case "Default":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Default;
					case "Color1":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color1;
					case "Color2":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color2;
					case "Color3":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color3;
					case "Color4":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color4;
					case "Color5":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color5;
					case "Color6":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color6;
					case "Color7":
						return global::Tum.PDE.ModelingDSL.ShapeColorType.Color7;

					default:
						//throw new System.NotSupportedException("Can not convert " + strValue + " to type ShapeColorType");
						return null;
				}
			}
			if( targetType == typeof(global::Tum.PDE.ModelingDSL.ShapeStyleType?) && value != null )
			{
				string strValue = value.ToString();
				switch(strValue)
				{
					case "Default":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Default;
					case "Style1":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Style1;
					case "Style2":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Style2;
					case "Style3":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Style3;
					case "Style4":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Style4;
					case "Style5":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Style5;
					case "Image":
						return global::Tum.PDE.ModelingDSL.ShapeStyleType.Image;

					default:
						//throw new System.NotSupportedException("Can not convert " + strValue + " to type ShapeStyleType");
						return null;
				}
			}
			if( targetType == typeof(global::Tum.PDE.ModelingDSL.ShapeFormType?) && value != null )
			{
				string strValue = value.ToString();
				switch(strValue)
				{
					case "Rectangle":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Rectangle;
					case "RoundedRectangle":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.RoundedRectangle;
					case "Circle":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Circle;
					case "Decision":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Decision;
					case "RectangleAngl":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.RectangleAngl;
					case "RectangleSd":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.RectangleSd;
					case "Document":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Document;
					case "Predefined":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Predefined;
					case "StoredData":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.StoredData;
					case "InternalStorage":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.InternalStorage;
					case "Preparation":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Preparation;
					case "ManualOperation":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.ManualOperation;
					case "OffPageReference":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.OffPageReference;
					case "Star":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Star;
					case "Stop":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Stop;
					case "SequentialData":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.SequentialData;
					case "DirectData":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.DirectData;
					case "ManualInput":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.ManualInput;
					case "Card":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Card;
					case "PaperTape":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.PaperTape;
					case "Delay":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Delay;
					case "Display":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.Display;
					case "LoopLimit":
						return global::Tum.PDE.ModelingDSL.ShapeFormType.LoopLimit;

					default:
						//throw new System.NotSupportedException("Can not convert " + strValue + " to type ShapeFormType");
						return null;
				}
			}
			if( targetType == typeof(global::Tum.PDE.ModelingDSL.Multiplicity?) && value != null )
			{
				string strValue = value.ToString();
				switch(strValue)
				{
					case "One":
						return global::Tum.PDE.ModelingDSL.Multiplicity.One;
					case "ZeroOne":
						return global::Tum.PDE.ModelingDSL.Multiplicity.ZeroOne;
					case "Many":
						return global::Tum.PDE.ModelingDSL.Multiplicity.Many;
					case "ZeroMany":
						return global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany;
					case "OneMany":
						return global::Tum.PDE.ModelingDSL.Multiplicity.OneMany;

					default:
						//throw new System.NotSupportedException("Can not convert " + strValue + " to type Multiplicity");
						return null;
				}
			}

			return value;
		}
		
		/// <summary>
        /// This method is called during serialization to convert a given typed value to a specific value.
        /// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="modelELement">ModdelElement, to which the property belongs to.</param>
		/// <param name="propertyName">The Property name, which value is to be converted.</param>
        /// <param name="value">Typed value to convert.</param>
        /// <param name="sourceType">Type of the value.</param>
		/// <param name="isRequired">True if this property is marked as required in the domain model. Can be null.</param>
        /// <returns>Converted value.</returns>
		public virtual object ConvertTypedObjectTo(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired)
		{
			if (sourceType == typeof(global::System.Boolean?) && value != null)
            {
                if (value is System.Boolean)
                {
                    return ((System.Boolean)value).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
            }
			if (sourceType == typeof(global::System.Guid?) && value != null)
            {
                if (value is System.Guid)
                {
                    return ((System.Guid)value).ToString();
                }
            }			
 			if (sourceType == typeof(global::System.Int32?))
            {
				return ConvertTypedObjectInt32To(serializationContext, modelELement, propertyName, value, sourceType, isRequired);
			}
 			if (sourceType == typeof(global::System.Double?))
            {
				return ConvertTypedObjectDoubleTo(serializationContext, modelELement, propertyName, value, sourceType, isRequired);
			}
			if( sourceType == typeof(global::Tum.PDE.ModelingDSL.ShapeColorType?) && value != null )
			{
				global::Tum.PDE.ModelingDSL.ShapeColorType? strValue = value as global::Tum.PDE.ModelingDSL.ShapeColorType?;
				if( strValue != null )
					switch(strValue)
					{
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Default:
							return "Default";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color1:
							return "Color1";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color2:
							return "Color2";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color3:
							return "Color3";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color4:
							return "Color4";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color5:
							return "Color5";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color6:
							return "Color6";
						case global::Tum.PDE.ModelingDSL.ShapeColorType.Color7:
							return "Color7";

						default:
							throw new System.NotSupportedException("Value of type ShapeColorType is unknown.");
					}
			}
			if( sourceType == typeof(global::Tum.PDE.ModelingDSL.ShapeStyleType?) && value != null )
			{
				global::Tum.PDE.ModelingDSL.ShapeStyleType? strValue = value as global::Tum.PDE.ModelingDSL.ShapeStyleType?;
				if( strValue != null )
					switch(strValue)
					{
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Default:
							return "Default";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Style1:
							return "Style1";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Style2:
							return "Style2";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Style3:
							return "Style3";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Style4:
							return "Style4";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Style5:
							return "Style5";
						case global::Tum.PDE.ModelingDSL.ShapeStyleType.Image:
							return "Image";

						default:
							throw new System.NotSupportedException("Value of type ShapeStyleType is unknown.");
					}
			}
			if( sourceType == typeof(global::Tum.PDE.ModelingDSL.ShapeFormType?) && value != null )
			{
				global::Tum.PDE.ModelingDSL.ShapeFormType? strValue = value as global::Tum.PDE.ModelingDSL.ShapeFormType?;
				if( strValue != null )
					switch(strValue)
					{
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Rectangle:
							return "Rectangle";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.RoundedRectangle:
							return "RoundedRectangle";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Circle:
							return "Circle";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Decision:
							return "Decision";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.RectangleAngl:
							return "RectangleAngl";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.RectangleSd:
							return "RectangleSd";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Document:
							return "Document";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Predefined:
							return "Predefined";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.StoredData:
							return "StoredData";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.InternalStorage:
							return "InternalStorage";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Preparation:
							return "Preparation";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.ManualOperation:
							return "ManualOperation";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.OffPageReference:
							return "OffPageReference";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Star:
							return "Star";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Stop:
							return "Stop";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.SequentialData:
							return "SequentialData";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.DirectData:
							return "DirectData";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.ManualInput:
							return "ManualInput";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Card:
							return "Card";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.PaperTape:
							return "PaperTape";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Delay:
							return "Delay";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.Display:
							return "Display";
						case global::Tum.PDE.ModelingDSL.ShapeFormType.LoopLimit:
							return "LoopLimit";

						default:
							throw new System.NotSupportedException("Value of type ShapeFormType is unknown.");
					}
			}
			if( sourceType == typeof(global::Tum.PDE.ModelingDSL.Multiplicity?) && value != null )
			{
				global::Tum.PDE.ModelingDSL.Multiplicity? strValue = value as global::Tum.PDE.ModelingDSL.Multiplicity?;
				if( strValue != null )
					switch(strValue)
					{
						case global::Tum.PDE.ModelingDSL.Multiplicity.One:
							return "One";
						case global::Tum.PDE.ModelingDSL.Multiplicity.ZeroOne:
							return "ZeroOne";
						case global::Tum.PDE.ModelingDSL.Multiplicity.Many:
							return "Many";
						case global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany:
							return "ZeroMany";
						case global::Tum.PDE.ModelingDSL.Multiplicity.OneMany:
							return "OneMany";

						default:
							throw new System.NotSupportedException("Value of type Multiplicity is unknown.");
					}
			}
		
			return value;
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
		public abstract global::System.Int32? ConvertTypedObjectInt32From(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired);
		
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
		public abstract object ConvertTypedObjectInt32To(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired);

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
		public abstract global::System.Double? ConvertTypedObjectDoubleFrom(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type targetType, bool? isRequired);
		
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
		public abstract object ConvertTypedObjectDoubleTo(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement modelELement, string propertyName, object value, System.Type sourceType, bool? isRequired);

		
		/// <summary>
        /// This method is called during deserialization to convert a given id as string to the id of type Guid as used by the domain model.
        /// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="id">Id as  string.</param>
        /// <returns>Converted value, Id as Guid.</returns>
		public virtual System.Guid ConvertIdFrom(DslModeling::SerializationContext serializationContext, string id)
		{
			try
			{
				return new System.Guid(id);
			}
			catch(System.Exception ex)
            {
                serializationContext.Result.AddMessage(new DslModeling::SerializationMessage(
                     DslModeling::SerializationMessageKind.Error, "Couldnt convert " + id + " to Guid: " + ex.ToString(), "", 0, 0, null));

                return System.Guid.Empty;
            }
		}
		
		/// <summary>
        /// This method is called during serialization to convert a given id to its specific string representation.
        /// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="id">Id.</param>
        /// <returns>Converted value.</returns>
		public virtual string ConvertIdTo(DslModeling::SerializationContext serializationContext, System.Guid id)
		{
			return id.ToString("D");
		}
		
		/// <summary>
		/// Writes the specified element to the file.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="element">The element whose attributes have just been written.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="elementName">Name of the element to be written.</param>
		/// <param name="elementValue">Value of the element to be written.</param>
		/// <remarks>This is an extension point to allow customisation e.g. to encode the data
		/// being written to the file.</remarks>
		internal virtual void WriteElementString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, string elementName, string elementValue)
		{
			writer.WriteElementString(elementName, elementValue);
		}
		
		internal virtual void WriteElementCDATAString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, string elementName, string elementValue)
		{
			writer.WriteStartElement(elementName);
            writer.WriteCData(elementValue);
            writer.WriteEndElement();
		}
		
		/// <summary>
		/// Writes the specified attribute to the file.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="element">The element whose attributes have just been written.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="attributeName">Name of the attribute to be written</param>
		/// <param name="attributeValue">Value of the attribute to be written</param>
		/// <remarks>This is an extension point to allow customisation e.g. to encode the data
		/// being written to the file.</remarks>
		public virtual void WriteAttributeString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, string attributeName, string attributeValue)
		{
			writer.WriteAttributeString(attributeName, attributeValue);
		}
		
		/// <summary>
		/// Reads and returns the value of an attribute.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="element">The element whose attributes have just been written.</param>
		/// <param name="reader">XmlReader to read the serialized data from.</param>
		/// <param name="attributeName">The name of the attribute to be read.</param>
		/// <returns>The value of the attribute.</returns>
		/// <remarks>This is an extension point to allow customisation e.g. to decode the data
		/// being written to the file.</remarks>
		public virtual string ReadAttribute(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader, string attributeName)
		{
			return reader.GetAttribute(attributeName);
		}
		
		/// <summary>
		/// Reads and returns the value of an element.
		/// </summary>
		/// <param name="serializationContext">The current serialization context instance.</param>
		/// <param name="element">The element whose attributes have just been written.</param>
		/// <param name="reader">XmlReader to read the serialized data from.</param>
		/// <returns>The value of the element.</returns>
		/// <remarks>This is an extension point to allow customisation e.g. to decode the data
		/// being written to the file.</remarks>
		public virtual string ReadElementContentAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			return reader.ReadElementContentAsString();
		}
		
		/// <summary>
        /// Reads and returns the value of an cdata element.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="reader">XmlReader to read the serialized data from.</param>
        /// <returns>The value of the element.</returns>
        /// <remarks>This is an extension point to allow customisation e.g. to decode the data being written to the file.</remarks>
		public virtual string ReadElementCDATAContentAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
		{
			return reader.ReadElementContentAsString();
		}
		
        /// <summary>
        /// Reads and returns the inner xml value of an element.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="reader">XmlReader to read the serialized data from.</param>
        /// <returns>The value of the element.</returns>
        /// <remarks>This is an extension point to allow customisation e.g. to decode the data being written to the file.</remarks>
        public virtual string ReadInnerXmlAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
        {
            return reader.ReadInnerXml();
        }

        /// <summary>
        /// Reads and returns the inner xml value (which is serialized as cdata) of an element.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="reader">XmlReader to read the serialized data from.</param>
        /// <returns>The value of the element.</returns>
        /// <remarks>This is an extension point to allow customisation e.g. to decode the data being written to the file.</remarks>
        public virtual string ReadCDATAFromInnerXmlAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlReader reader)
        {
            string innerXml = reader.ReadInnerXml();
            if( innerXml.Length > 9 )
            {

                if (innerXml.Substring(0, 9) == "<![CDATA[" && innerXml.Substring(innerXml.Length - 3, 3) == "]]>")
                {
                    return innerXml.Substring(9, innerXml.Length - 12);
                }
            }

            return innerXml;
        }
	
		/// <summary>
        /// Writes the specified string as the elements content to the file.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="attributeName">Name of the attribute to be written</param>
        /// <param name="attributeValue">Value of the attribute to be written</param>
        /// <remarks>This is an extension point to allow customisation e.g. to encode the data
        /// being written to the file.</remarks>
        public virtual void WriteInnerXmlAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, string attributeName, string attributeValue)
        {
            writer.WriteValue(attributeValue);
        }

        /// <summary>
        /// Writes the specified string as the elements content (formatted as CDATA) to the file.
        /// </summary>
        /// <param name="serializationContext">The current serialization context instance.</param>
        /// <param name="element">The element whose attributes have just been written.</param>
        /// <param name="writer">XmlWriter to write serialized data to.</param>
        /// <param name="attributeName">Name of the attribute to be written</param>
        /// <param name="attributeValue">Value of the attribute to be written</param>
        /// <remarks>This is an extension point to allow customisation e.g. to encode the data
        /// being written to the file.</remarks>
        public virtual void WriteCDATAFromInnerXmlAsString(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement element, global::System.Xml.XmlWriter writer, string attributeName, string attributeValue)
        {
            writer.WriteCData(attributeValue);
        }	
		#endregion
		
		#region Initialization
		
		/// <summary>
		/// Ensure that moniker resolvers and domain element serializers are installed properly on the given store, 
		/// so that deserialization can be carried out correctly.
		/// </summary>
		/// <param name="store">Store on which moniker resolvers will be set up.</param>
		internal protected virtual void InitializeSerialization(DslModeling::Store store)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert(store != null);
			if (store == null)
				throw new global::System.ArgumentNullException("store");
			#endregion
	
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(store);
		
			// Add serialization behaviors
			directory.AddBehavior(PDEModelingDSLSerializationBehavior.Instance);
		}
		
		/// <summary>
		/// Gets or set wether serializers have already been initialized or not.
		/// </summary>		
		public static bool IsInitializeSerialized = false;
		
        private static void AddTypeEmbeddedDerivedNameTypesElement(System.Guid key, string name, System.Guid id)
		{
			try
			{
				if( !typeEmbeddedDerivedNameTypes[key].ContainsKey(name) )
					typeEmbeddedDerivedNameTypes[key].Add(name, new System.Collections.Generic.List<System.Guid>());
					
				typeEmbeddedDerivedNameTypes[key][name].Add(id);
			}
			catch{}
		}
		private static void AddTypeDerivedNameTypesElement(System.Guid key, string name, System.Guid id)
		{
			try
			{
				typeDerivedNameTypes[key].Add(name, id);
			}
			catch{}
		}

		/// <summary>
		/// Initializes serializers (creates derived classes lookup dictionaries).
		/// </summary>
		/// <param name="directory">Serializer dictionary.</param>
		/// <param name="domainDataDirectory">DomainDataDirectory to be used to discover all derived classes.</param>
		public static void InitializeSerializers(DslModeling::DomainXmlSerializerDirectory directory, DslModeling::DomainDataDirectory domainDataDirectory)
		{
			if( IsInitializeSerialized )
				return;
				
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId, "DomainElement", global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId);
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			AddTypeEmbeddedDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, "ExternalType", global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId);
			AddTypeEmbeddedDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId, "DomainEnumeration", global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId);
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId, "ExternalType", global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId);
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DomainType.DomainClassId, "DomainEnumeration", global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId);
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DETypes.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
				
			typeEmbeddedDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Guid>>());
			AddTypeEmbeddedDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, "ReferencingDRType", global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId);
			AddTypeEmbeddedDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId, "EmbeddingDRType", global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId);
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.DRType.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DRType.DomainClassId, "ReferencingDRType", global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId);
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.DRType.DomainClassId, "EmbeddingDRType", global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId);
			// add dictionary informations...
			typeDerivedNameTypes.Add(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId, new System.Collections.Generic.Dictionary<string, System.Guid>());
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId, "DEType", global::Tum.PDE.ModelingDSL.DEType.DomainClassId);
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId, "ReferencingDRType", global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId);
			AddTypeDerivedNameTypesElement(global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId, "EmbeddingDRType", global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId);
			
            typeDNTInitializedEvent.Set();
			typeEmbeddedDNTInitializedEvent.Set();
			
			IsInitializeSerialized = true;

		}
		#endregion
		

		#region Serialization Methods for DomainModel
		/// <summary>
		/// Loads a DomainModel instance.
		/// </summary>
		/// <param name="serializationResult">Stores serialization result from the load operation.</param>
		/// <param name="partition">Partition in which the new DomainModel instance will be created.</param>
		/// <param name="fileName">Name of the file from which the DomainModel instance will be deserialized.</param>
		/// <param name="schemaResolver">
		/// An ISchemaResolver that allows the serializer to do schema validation on the root element (and everything inside it).
		/// If null is passed, schema validation will not be performed.
		/// </param>
		/// <param name="validationController">
		/// A ValidationController that will be used to do load-time validation (validations with validation category "Load"). If null
		/// is passed, load-time validation will not be performed.
		/// </param>
		/// <param name="serializerLocator"></param>
		/// <returns>The loaded MetaModel instance.</returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code")]
        public virtual global::Tum.PDE.ModelingDSL.DomainModel LoadModelDomainModel(DslModeling::SerializationResult serializationResult, DslModeling::Partition partition, string fileName, DslModeling::ISchemaResolver schemaResolver, DslValidation::ValidationController validationController, DslModeling::ISerializerLocator serializerLocator)
        {
            #region Check Parameters
            if (serializationResult == null)
                throw new global::System.ArgumentNullException("serializationResult");
            if (partition == null)
                throw new global::System.ArgumentNullException("partition");
            if (string.IsNullOrEmpty(fileName))
                throw new global::System.ArgumentNullException("fileName");
            #endregion

            DslEditorModeling::DomainModelStore dStore = (DslEditorModeling::DomainModelStore)partition.Store;
            if( dStore == null)
                throw new global::System.ArgumentNullException("dStore");
			//dStore.WaitForWritingLockRelease();

            // Ensure there is a transaction for this model to Load in.
            if (!partition.Store.TransactionActive)
            {
                throw new global::System.InvalidOperationException(PDEModelingDSLDomainModel.SingletonResourceManager.GetString("MissingTransaction"));
            }
			
			global::Tum.PDE.ModelingDSL.DomainModel modelRoot = null;
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(partition.Store);
			DslModeling::DomainClassXmlSerializer modelRootSerializer = directory.GetSerializer(global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId);
			global::System.Diagnostics.Debug.Assert(modelRootSerializer != null, "Cannot find serializer for DomainModel!");
			if (modelRootSerializer != null)
			{
				global::System.IO.FileStream fileStream = null;
			
				try
				{
					fileStream = global::System.IO.File.OpenRead(fileName);
					
					DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileStream.Name, serializationResult);
					this.InitializeSerializationContext(partition, serializationContext, true);
					DslModeling::TransactionContext transactionContext = new DslModeling::TransactionContext();
					transactionContext.Add(DslModeling::SerializationContext.TransactionContextKey, serializationContext);
					
					//using (DslModeling::Transaction t = partition.Store.TransactionManager.BeginTransaction("Load Model from " + fileName, true, transactionContext))
					//{
						// Ensure there is some content in the file.  Blank (or almost blank, to account for encoding header bytes, etc.)
						// files will cause a new root element to be created and returned. 
						if (fileStream.Length > 5)
						{
							global::System.Xml.XmlReaderSettings settings = PDEModelingDSLSerializationHelper.Instance.CreateXmlReaderSettings(serializationContext, false);
							using (global::System.Xml.XmlReader reader = global::System.Xml.XmlReader.Create(fileStream, settings))
							{
								try
								{	
									// Attempt to read the encoding.
									reader.Read(); // Move to the first node - will be the XmlDeclaration if there is one.
									global::System.Text.Encoding encoding;
									if (this.TryGetEncoding(reader, out encoding))
									{
										serializationResult.Encoding = encoding;
									}
	
									// Load any additional domain models that are required
									//DslModeling::SerializationUtilities.ResolveDomainModels(reader, serializerLocator, partition.Store);
								
									reader.MoveToContent();
									
									modelRoot = modelRootSerializer.TryCreateInstance(serializationContext, reader, partition) as global::Tum.PDE.ModelingDSL.DomainModel;
									if (modelRoot != null && !serializationResult.Failed)
									{
										modelRoot.DomainFilePath = fileName;
										this.ReadRootElementDomainModel(serializationContext, modelRoot, reader, schemaResolver);
									}
									
                                    fileStream.Dispose();
								}
								catch (global::System.Xml.XmlException xEx)
								{
									DslModeling::SerializationUtilities.AddMessage(
										serializationContext,
										DslModeling::SerializationMessageKind.Error,
										xEx
									);
								}
								finally
								{
									fileStream = null;
								}	
							}							
						}
				
						if(modelRoot == null && !serializationResult.Failed)
						{
							// create model root if it doesn't exist.
							modelRoot = this.CreateModelHelperDomainModel(partition);
							modelRoot.DomainFilePath = fileName;
						}
						//if (t.IsActive)
						//	t.Commit();
					//}
	
					// Do load-time validation if a ValidationController is provided.
					if (!serializationResult.Failed && validationController != null)
					{
						using (new SerializationValidationObserver(serializationResult, validationController))
						{
							validationController.Validate(partition, DslValidation::ValidationCategories.Load);
						}
					}
				}
				finally
				{
					if( fileStream != null )
						fileStream.Dispose();
				}
			}
			return modelRoot;
        }
		
		/// <summary>
		/// Helper method to create and initialize a new DomainModel.
		/// </summary>
		internal protected virtual global::Tum.PDE.ModelingDSL.DomainModel CreateModelHelperDomainModel(DslModeling::Partition modelPartition)
		{
			global::Tum.PDE.ModelingDSL.DomainModel model = new global::Tum.PDE.ModelingDSL.DomainModel(modelPartition, 
				global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(null));
			if( PDEModelingDSLElementNameProvider.Instance.HasName(model) )
				PDEModelingDSLElementNameProvider.Instance.SetName(model, "DomainModel");
				
			return model;
		}
		
		/// <summary>
		/// Read an element from the root of XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="rootElement">In-memory element instance that will get the deserialized data.</param>
		/// <param name="reader">XmlReader to read serialized data from.</param>
		/// <param name="schemaResolver">An ISchemaResolver that allows the serializer to do schema validation on the root element (and everything inside it).</param>
		protected virtual void ReadRootElementDomainModel(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement rootElement, global::System.Xml.XmlReader reader, DslModeling::ISchemaResolver schemaResolver)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert(serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException("serializationContext");
			global::System.Diagnostics.Debug.Assert(rootElement != null);
			if (rootElement == null)
				throw new global::System.ArgumentNullException("rootElement");
			global::System.Diagnostics.Debug.Assert(reader != null);
			if (reader == null)
				throw new global::System.ArgumentNullException("reader");
			#endregion
	
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(rootElement.Store);
	
			DslModeling::DomainClassXmlSerializer rootSerializer = directory.GetSerializer(rootElement.GetDomainClass().Id);
			global::System.Diagnostics.Debug.Assert(rootSerializer != null, "Cannot find serializer for " + rootElement.GetDomainClass().Name + "!");
	
			// Version check.
			//this.CheckVersion(serializationContext, reader);
			if (!serializationContext.Result.Failed)
			{	
				rootSerializer.Read(serializationContext, rootElement, reader);
			}
		}
		
		/// <summary>
		/// Saves the given model root to the given file, with specified encoding.
		/// </summary>
		/// <param name="serializationResult">Stores serialization result from the save operation.</param>
		/// <param name="modelRoot">DomainModel instance to be saved.</param>
		/// <param name="fileName">Name of the file in which the DomainModel instance will be saved.</param>
		/// <param name="encoding">Encoding to use when saving the DomainModel instance.</param>
		/// <param name="writeOptionalPropertiesWithDefaultValue">Whether optional properties with default value will be saved.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public virtual void SaveModelDomainModel(DslModeling::SerializationResult serializationResult, global::Tum.PDE.ModelingDSL.DomainModel modelRoot, string fileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue)
		{
			#region Check Parameters
			if (serializationResult == null)
				throw new global::System.ArgumentNullException("serializationResult");
			if (modelRoot == null)
				throw new global::System.ArgumentNullException("modelRoot");
			if (string.IsNullOrEmpty(fileName))
				throw new global::System.ArgumentNullException("fileName");
			#endregion
	
            //DslEditorModeling::DomainModelStore dStore = (DslEditorModeling::DomainModelStore)modelRoot.Store;
            //if( dStore == null)
            //    throw new global::System.ArgumentNullException("dStore");
				
			//dStore.WaitForWritingLockRelease();
			
			if (serializationResult.Failed)
				return;
	
			global::System.IO.MemoryStream newFileContent = null;
			try
			{
				newFileContent = new global::System.IO.MemoryStream();
			
				DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(modelRoot.Store);
	
				DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileName, serializationResult);
				this.InitializeSerializationContext(modelRoot.Partition, serializationContext, false);
				serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
				global::System.Xml.XmlWriterSettings settings = PDEModelingDSLSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
				
				global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings);
				DslEditorModeling.SerializationOptions options = new DslEditorModeling.SerializationOptions();
                options.SerializationMode = DslEditorModeling.SerializationMode.Normal;
				this.WriteRootElementDomainModel(serializationContext, modelRoot, writer, options);
				
				writer.Flush();
	
				if (!serializationResult.Failed && newFileContent != null)
				{	// Only write the content if there's no error encountered during serialization.
					global::System.IO.FileStream fileStream = null;
					try
					{
						fileStream = new global::System.IO.FileStream(fileName, global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write, global::System.IO.FileShare.None);
						using (global::System.IO.BinaryWriter writerBin = new global::System.IO.BinaryWriter(fileStream, encoding))
						{
							try
							{
								writerBin.Write(newFileContent.ToArray());
								fileStream.Dispose();
							}
							finally
							{
								fileStream = null;
							}							
						}
					}
					finally
					{
						if( fileStream != null )
							fileStream.Dispose();
					}
				}
			}
			finally
			{
				if( newFileContent != null )
					newFileContent.Dispose();
			}
		}
		
		/// <summary>
		/// Saves the given model root as a in-memory stream.
		/// This is a helper used by SaveModel() and SaveModelAndDiagram(). When saving the model and the diagram together, we want to make sure that 
		/// both can be saved without error before writing the content to disk, so we serialize the model into a in-memory stream first.
		/// </summary>
		/// <param name="serializationResult">Stores serialization result from the save operation.</param>
		/// <param name="modelRoot">DomainModel instance to be saved.</param>
		/// <param name="fileName">Name of the file in which the DomainModel instance will be saved.</param>
		/// <param name="encoding">Encoding to use when saving the DomainModel instance.</param>
		/// <param name="writeOptionalPropertiesWithDefaultValue">Whether optional properties with default value will be saved.</param>
		/// <param name="serializationMode">Serialization Mode.</param>
		/// <returns>In-memory stream containing the serialized DomainModel instance.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		private global::System.IO.MemoryStream InternalSaveModelDomainModel(DslModeling::SerializationResult serializationResult, global::Tum.PDE.ModelingDSL.DomainModel modelRoot, string fileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue, DslEditorModeling.SerializationMode serializationMode)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert(serializationResult != null);
			global::System.Diagnostics.Debug.Assert(modelRoot != null);
			global::System.Diagnostics.Debug.Assert(!serializationResult.Failed);
			#endregion
		
            //DslEditorModeling::DomainModelStore dStore = (DslEditorModeling::DomainModelStore)modelRoot.Store;
            //if( dStore == null)
            //    throw new global::System.ArgumentNullException("dStore");
				
			//dStore.WaitForWritingLockRelease();
			
			serializationResult.Encoding = encoding;
	
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(modelRoot.Store);
	
			
			global::System.IO.MemoryStream newFileContent = new global::System.IO.MemoryStream();
			
			DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileName, serializationResult);
			this.InitializeSerializationContext(modelRoot.Partition, serializationContext, false);
			// MonikerResolver shouldn't be required in Save operation, so not calling SetupMonikerResolver() here.
			serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
			global::System.Xml.XmlWriterSettings settings = PDEModelingDSLSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
			using (global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings))
			{
				DslEditorModeling.SerializationOptions options = new DslEditorModeling.SerializationOptions();
                //options.SerializationMode = DslEditorModeling.SerializationMode.InternalToString;
				options.SerializationMode = serializationMode;
                this.WriteRootElementDomainModel(serializationContext, modelRoot, writer, options);
			}
				
			return newFileContent;
		}
	
		/// <summary>
		/// Saves the given model root to the given file, with specified encoding.
		/// </summary>
		/// <param name="serializationResult">Stores serialization result from the save operation.</param>
		/// <param name="modelRoot">VModell instance to be saved.</param>
		/// <param name="fileName">Name of the file in which the VModell instance will be saved.</param>
		/// <param name="encoding">Encoding to use when saving the VModell instance.</param>
		/// <param name="writeOptionalPropertiesWithDefaultValue">Whether optional properties with default value will be saved.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public virtual void TemporarlySaveModelDomainModel(DslModeling::SerializationResult serializationResult, global::Tum.PDE.ModelingDSL.DomainModel modelRoot, string fileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue)
        {
            #region Check Parameters
            if (serializationResult == null)
                throw new global::System.ArgumentNullException("serializationResult");
            if (modelRoot == null)
                throw new global::System.ArgumentNullException("modelRoot");
            if (string.IsNullOrEmpty(fileName))
                throw new global::System.ArgumentNullException("fileName");
            #endregion

            if (serializationResult.Failed)
                return;

            //DslEditorModeling::DomainModelStore dStore = (DslEditorModeling::DomainModelStore)modelRoot.Store;
            //if( dStore == null)
            //    throw new global::System.ArgumentNullException("dStore");
				
			//dStore.WaitForWritingLockRelease();

			global::System.IO.MemoryStream newFileContent = null;
            try 
            {
				newFileContent = new global::System.IO.MemoryStream();
				
                DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(modelRoot.Store);

                DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileName, serializationResult);
                this.InitializeSerializationContext(modelRoot.Partition, serializationContext, false);
                serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
                global::System.Xml.XmlWriterSettings settings = PDEModelingDSLSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
                
				global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings);
               	DslEditorModeling::SerializationOptions options = new DslEditorModeling.SerializationOptions();
              	options.SerializationMode = DslEditorModeling.SerializationMode.Temporarly;
              	this.WriteRootElementDomainModel(serializationContext, modelRoot, writer, options);
				
				writer.Flush();

                if (!serializationResult.Failed && newFileContent != null)
                {	// Only write the content if there's no error encountered during serialization.
					global::System.IO.FileStream fileStream = null;
                    try
                    {
						fileStream = new global::System.IO.FileStream(fileName, global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write, global::System.IO.FileShare.None);
                        using (global::System.IO.BinaryWriter writerBin = new global::System.IO.BinaryWriter(fileStream, encoding))
                        {
							try
							{
                            	writerBin.Write(newFileContent.ToArray());
								fileStream.Dispose();
							}
							finally
							{
								fileStream = null;
							}							
                        }
                    }
					finally
					{
						if( fileStream != null )
							fileStream.Dispose();
					}
                }
            }
			finally
			{
				if( newFileContent != null )
					newFileContent.Dispose();
			}
        }
	
		/// <summary>
		/// Write an element as the root of XML.
		/// </summary>
		/// <param name="serializationContext">Serialization context.</param>
		/// <param name="rootElement">Root element instance that will be serialized.</param>
		/// <param name="writer">XmlWriter to write serialized data to.</param>
		/// <param name="options">Serialization options.</param>
		public virtual void WriteRootElementDomainModel(DslModeling::SerializationContext serializationContext, DslModeling::ModelElement rootElement, global::System.Xml.XmlWriter writer, DslEditorModeling::SerializationOptions options)
		{
			#region Check Parameters
			global::System.Diagnostics.Debug.Assert(serializationContext != null);
			if (serializationContext == null)
				throw new global::System.ArgumentNullException("serializationContext");
			global::System.Diagnostics.Debug.Assert(rootElement != null);
			if (rootElement == null)
				throw new global::System.ArgumentNullException("rootElement");
			global::System.Diagnostics.Debug.Assert(writer != null);
			if (writer == null)
				throw new global::System.ArgumentNullException("writer");
			#endregion
	
			DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(rootElement.Store);
	
			DslEditorModeling::SerializationDomainClassXmlSerializer rootSerializer = directory.GetSerializer(rootElement.GetDomainClass().Id) as DslEditorModeling::SerializationDomainClassXmlSerializer;
			global::System.Diagnostics.Debug.Assert(rootSerializer != null, "Cannot find serializer for " + rootElement.GetDomainClass().Name + "!");
	
			// Carry out the normal serialization.
			rootSerializer.Write(serializationContext, rootElement, writer, new DslModeling::RootElementSettings(), options);
		}
		
		/// <summary>
		/// Return the model in XML format
		/// </summary>
		/// <param name="modelRoot">Root instance to be saved.</param>
		/// <param name="encoding">Encoding to use when saving the root instance.</param>
		/// <param name="serializationMode">Serialization Mode.</param>
		/// <returns>Model in XML form</returns>
		public virtual string GetSerializedModelStringDomainModel(global::Tum.PDE.ModelingDSL.DomainModel modelRoot, global::System.Text.Encoding encoding, DslEditorModeling.SerializationMode serializationMode)
		{
			string result = string.Empty;
			if (modelRoot == null)
			{
				return result;
			}
	
	        //DslEditorModeling::DomainModelStore dStore = (DslEditorModeling::DomainModelStore)modelRoot.Store;
            //if( dStore == null)
            //    throw new global::System.ArgumentNullException("dStore");
				
			//dStore.WaitForWritingLockRelease();
	
			DslModeling::SerializationResult serializationResult = new DslModeling::SerializationResult();
			using (global::System.IO.MemoryStream modelFileContent = this.InternalSaveModelDomainModel(serializationResult, modelRoot, string.Empty, encoding, false, serializationMode))
			{
				if (!serializationResult.Failed && modelFileContent != null)
				{
					char[] chars = encoding.GetChars(modelFileContent.GetBuffer());
	
					// search the open angle bracket and trim off the Byte Of Mark.
					result = new string( chars);
					int indexPos = result.IndexOf('<');
					if (indexPos > 0)
					{
						// strip off the leading Byte Of Mark.
						result = result.Substring(indexPos);
					}
	
					// trim off trailing 0s.
					result = result.TrimEnd( '\0');
				}
			}
			return result;
		}
		#endregion
		
		#region Private/Helper Methods/Properties
		#region Class SerializationValidationObserver
		/// <summary>
		/// An utility class to collect validation messages during serialization, and store them in serialization result.
		/// </summary>
		protected sealed class SerializationValidationObserver : DslValidation::ValidationMessageObserver, global::System.IDisposable
		{
			#region Member Variables
			/// <summary>
			/// SerializationResult to store the messages.
			/// </summary>
			private DslModeling::SerializationResult serializationResult;
			/// <summary>
			/// ValidationController to get messages from.
			/// </summary>
			private DslValidation::ValidationController validationController;
			#endregion
	
			#region Constructor
			/// <summary>
			/// Constructor
			/// </summary>
			internal SerializationValidationObserver(DslModeling::SerializationResult serializationResult, DslValidation::ValidationController validationController)
			{
				#region Check Parameters
				global::System.Diagnostics.Debug.Assert(serializationResult != null);
				global::System.Diagnostics.Debug.Assert(validationController != null);
				#endregion
	
				this.serializationResult = serializationResult;
				this.validationController = validationController;
	
				// Subscribe to validation messages.
				this.validationController.AddObserver(this);
			}
	
			/// <summary>
			/// Destructor
			/// </summary>
			~SerializationValidationObserver()
			{
				this.Dispose(false);
			}
			#endregion
	
			#region Base Overrides
			/// <summary>
			/// Called with validation messages are added.
			/// </summary>
			protected override void OnValidationMessageAdded(DslValidation::ValidationMessage addedMessage)
			{
				#region Check Parameters
				global::System.Diagnostics.Debug.Assert(addedMessage != null);
				#endregion
	
				if (addedMessage != null && this.serializationResult != null)
				{	// Record the validation message as a serialization message.
					DslModeling::SerializationUtilities.AddValidationMessage(this.serializationResult, addedMessage);
				}
				base.OnValidationMessageAdded(addedMessage);
			}
			#endregion
	
			#region IDisposable Members
			/// <summary>
			/// IDisposable.Dispose().
			/// </summary>
			public void Dispose()
			{
				this.Dispose(true);
				global::System.GC.SuppressFinalize(this);
			}
	
			/// <summary>
			/// Unregister the observer on dispose.
			/// </summary>
			private void Dispose(bool disposing)
			{
				global::System.Diagnostics.Debug.Assert(disposing, "SerializationValidationObserver finalized without being disposed!");
				if (disposing && this.validationController != null)
				{
					this.validationController.RemoveObserver(this);
					this.validationController = null;
				}
				this.serializationResult = null;
			}
			#endregion
		}
		#endregion
		#endregion
	
	}
	
	/// <summary>
	/// Double derived helper class for serializing and deserializing PDEModelingDSL models.
	/// </summary>
	public sealed partial class PDEModelingDSLSerializationHelper : PDEModelingDSLSerializationHelperBase
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		private PDEModelingDSLSerializationHelper() : base() { }
		#endregion
		
		#region Singleton Instance
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static PDEModelingDSLSerializationHelper instance;
		/// <summary>
		/// Singleton instance.
		/// </summary>
		[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
		public static PDEModelingDSLSerializationHelper Instance
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (PDEModelingDSLSerializationHelper.instance == null)
					PDEModelingDSLSerializationHelper.instance = new PDEModelingDSLSerializationHelper();
				return PDEModelingDSLSerializationHelper.instance;
			}
		}
		#endregion
	}
}
