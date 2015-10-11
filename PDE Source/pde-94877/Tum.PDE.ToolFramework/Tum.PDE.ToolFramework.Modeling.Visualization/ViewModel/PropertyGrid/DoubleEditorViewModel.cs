using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents a double property style view model.
    /// </summary>
    public class DoubleEditorViewModel : StringEditorViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public DoubleEditorViewModel(ViewModelStore viewModelStore)
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

            try
            {
                double value = Convert.ToDouble(values[0]);
                foreach (object v in values)
                {
                    if (value != Convert.ToDouble(v))
                    {
                        return "";
                    }
                }

                return value.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            Double? valueD = null;

            // empty string values are treated as null...
            if (String.IsNullOrEmpty(value as string))
                value = null;
            if (String.IsNullOrWhiteSpace(value as string))
                value = null;

            try
            {
                if (value != null)
                {
                    valueD = Convert.ToDouble(value);
                }
            }
            catch
            {
                IMessageBoxService messageBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                messageBox.ShowError("Could not set new value: Conversion failed");
                return;
            }

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
            {
                PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, valueD);
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
                return "Double";
            }
        }
    }
}
