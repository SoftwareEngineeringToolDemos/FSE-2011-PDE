using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents a boolean property style view model. As such it allows the selection
    /// of a null value (NullElement), a true (TrueElement) and an false (FalseElement) value. 
    /// </summary>
    public class BooleanEditorViewModel : LookupListEditorViewModel
    {
        /// <summary>
        /// Null element name.
        /// </summary>
        public static string NullElement = "(none)";

        /// <summary>
        /// True element name.
        /// </summary>
        public static string TrueElement = "True";

        /// <summary>
        /// False element name.
        /// </summary>
        public static string FalseElement = "False";

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public BooleanEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }

        /// <summary>
        /// Return the default value list for boolean editing.
        /// </summary>
        /// <returns>Default values list.</returns>
        protected override List<object> GetDefaultValues()
        {
            List<object> defaultValues = new List<object>();
            
            defaultValues.Add(TrueElement);
            defaultValues.Add(FalseElement);

            return defaultValues;
        }

        /// <summary>
        /// Insert sentinel item.
        /// </summary>
        protected override void InsertSentinelDefaultValue(List<object> dValues)
        {
            dValues.Insert(0, NullElement);
        }

        /// <summary>
        /// Converts the property value (in respect to multiple source elements) and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        /// <remarks>
        /// Converter: All equal --> use value. One differs --> null value.
        /// </remarks>
        public override object GetPropertyValue()
        {
            List<object> values = PropertyGridEditorViewModel.GetPropertyValues(this.Elements, this.PropertyName);
            if (values.Count == 0)
                return NullElement;

            bool? value = values[0] as bool?;
            foreach (object v in values)
            {
                if (value != v as bool?)
                {
                    value = null;
                    break;
                }
            }

            if (value == null)
                return NullElement;
            else if (value == true)
                return TrueElement;
            else
                return FalseElement;
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            bool? bValue = null;
            if (value as string == TrueElement)
                bValue = true;
            else if (value as string == FalseElement)
                bValue = false;

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
            {
                PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, bValue);
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
                return "Boolean";
            }
        }
    }
}
