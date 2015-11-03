using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents a string property style view model.
    /// </summary>
    public class StringEditorViewModel : PropertyEditorViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public StringEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }

        /// <summary>
        /// Converts the property value (in respect to multiple source elements) and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        /// <remarks>
        /// Converter: All equal --> use value. One differs --> empty value.
        /// </remarks>
        public override object GetPropertyValue()
        {
            List<object> values = PropertyGridEditorViewModel.GetPropertyValues(this.Elements, this.PropertyName);
            if (values.Count == 0)
                return "";

            string value = values[0] as string;
            foreach (object v in values)
            {
                if (value != v as string)
                {
                    value = "";
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            // empty string values are treated as null...
            if (String.IsNullOrEmpty(value as string))
                value = null;
            if (String.IsNullOrWhiteSpace(value as string))
                value = null;

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
            {
                PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, value);
                transaction.Commit();
            }
        }

        /// <summary>
        /// Gets the property type that is edited within this view model.
        /// </summary>
        public override string PropertyType
        {
            get
            {
                return "String";
            }
        }
    }
}
