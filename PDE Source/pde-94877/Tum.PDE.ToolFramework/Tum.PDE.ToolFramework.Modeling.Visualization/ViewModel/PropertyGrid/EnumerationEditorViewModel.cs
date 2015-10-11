using System;
using System.Collections.Generic;
using System.ComponentModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents an enumeration property style view model. As such it provides a list of
    /// default values that are derived from the given enumeration type as well as null element
    /// value (NullElement).
    /// 
    /// Hint: Enumerations in our domain model have a specific type onverter assigned to them:
    /// e.g.: [System.ComponentModel.TypeConverter(typeof(GenerierterInhaltEnumConverter))].
    /// That type converter provides display name values (as they are stored inside a .resx). 
    /// Should a given enumeration not have that kind of a type converter, then the 'real' names are displayed.
    /// </summary>
    public class EnumerationEditorViewModel : LookupListEditorViewModel
    {
        /// <summary>
        /// Enumeration item helper class.
        /// </summary>
        public class Item : INotifyPropertyChanged
        {
            private object item;
            private bool isChecked = false;
            private EnumerationEditorViewModel vm;
            
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="vm">Enum vm.</param>
            /// <param name="item">Enumeration literal.</param>
            public Item(EnumerationEditorViewModel vm, object item)
                : this(vm, item, false)
            {
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="vm">Enum vm.</param>
            /// <param name="item">Enumeration literal.</param>
            /// <param name="isChecked">Is checked.</param>
            public Item(EnumerationEditorViewModel vm, object item, bool isChecked)
            {
                this.item = item;
                this.isChecked = isChecked;
                this.vm = vm;
            }

            /// <summary>
            /// Gets the enumeration literal.
            /// </summary>
            public object Object
            {
                get 
                {
                    return this.item;
                }
            }

            /// <summary>
            /// Gets or sets the "IsChecked" property.
            /// </summary>
            public bool IsChecked
            {
                get
                {
                    return this.isChecked;
                }
                set
                {
                    if (this.isChecked != value)
                    {
                        this.isChecked = value;
                        OnPropertyChanged("IsChecked");

                        vm.UpdatePropertyValue();
                    }
                }
            }

            #region INotifyPropertyChanged Members
            /// <summary>
            /// Property changed event.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Called whenever a specific property changes.
            /// </summary>
            /// <param name="name">Name of the property, which value changed.</param>
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }

            #endregion
        }

        /// <summary>
        /// Null element name.
        /// </summary>
        public static string NullElement = "(none)";

        private Type enumType;
        private TypeConverter enumTypeConverter;

        private bool isFlags = false;
        private List<object> defaultValuesList;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="enumerationType">Type of the enumeration.</param>
        public EnumerationEditorViewModel(ViewModelStore viewModelStore, Type enumerationType)
            : this(viewModelStore, enumerationType, false)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="enumerationType">Type of the enumeration.</param>
        /// <param name="isFlags">IsFlags field.</param>
        public EnumerationEditorViewModel(ViewModelStore viewModelStore, Type enumerationType, bool isFlags)
            : base(viewModelStore)
        {
            enumType = enumerationType;
            enumTypeConverter = TypeDescriptor.GetConverter(this.enumType);
            this.isFlags = isFlags;

            // sort elements by real display name values. If the type converter is not provided, we sort
            // the values by name values.
            Sort = SortByRealValue;            
        }

        /// <summary>
        /// Can handle multiple elements if IsFlags=False.
        /// </summary>
        public override bool CanHandleMultipleElements
        {
            get
            {
                if (this.IsFlags)
                    return false;

                return base.CanHandleMultipleElements;
            }
            set
            {
                base.CanHandleMultipleElements = value;
            }
        }

        /// <summary>
        /// Returns the default value for the current enumeration.
        /// </summary>
        /// <returns>List of default values.</returns>
        protected override List<object> GetDefaultValues()
        {
            Array array = Enum.GetValues(enumType);
            defaultValuesList = new List<object>();

            if (this.IsFlags)
            {
                if (this.Elements.Count == 1)
                {
                    Enum val = PropertyGridEditorViewModel.GetPropertyValue(this.Elements[0], this.PropertyName) as Enum;
                    if (val != null)
                    {
                        foreach (object obj in array)
                        {
                            if (!(obj is Enum))
                                continue;

                            bool bContains = false;
                            if (val.HasFlag((Enum)obj))
                                bContains = true;

                            Item item = new Item(this, obj, bContains);
                            defaultValuesList.Add(item);
                        }
                    }
                    else
                        foreach (object obj in array)
                        {
                            Item item = new Item(this, obj, false);
                            defaultValuesList.Add(item);
                        }
                }
            }
            else
            {

                foreach (object obj in array)
                {
                    defaultValuesList.Add(obj);
                }
            }

            return defaultValuesList;
        }

        /// <summary>
        /// Gets the display text. This is only relevant if "IsFlags" is set to true.
        /// </summary>
        public string DisplayText
        {
            get
            {
                if (this.IsFlags)
                {
                    return GetDisplayText();
                }
                else
                    return "";
            }
        }

        private string GetDisplayText()
        {
            string ret = "";
            foreach (object e in this.defaultValuesList)
            {
                Item item = e as Item;
                if (item.IsChecked)
                {
                    if (ret != "")
                        ret += " | ";
                    ret += (item.Object as Enum).ToString();
                }
            }

            return ret;
        }

        /// <summary>
        /// Gets whether the edited enumeration is marked as "isFlags".
        /// </summary>
        public bool IsFlags
        {
            get
            {
                return this.isFlags;
            }
        }

        /// <summary>
        /// Insert sentinel item.
        /// </summary>
        protected override void InsertSentinelDefaultValue(List<object> dValues)
        {
            if (this.IsFlags)
                return;

            base.InsertSentinelDefaultValue(dValues);

            dValues.Insert(0, NullElement);
        }

        /// <summary>
        /// Sort the default values list.
        /// </summary>
        private int SortByRealValue(object xa, object ya)
        {
            object x = xa;
            object y = ya;

            if (this.IsFlags)
            {
                x = (xa as Item).Object;
                y = (ya as Item).Object;
            }

            if (enumTypeConverter != null)
            {
                string xS = enumTypeConverter.ConvertTo(x, typeof(string)) as string;
                string yS = enumTypeConverter.ConvertTo(y, typeof(string)) as string;

                return xS.CompareTo(yS);
            }
            else
            {
                string xS = x.ToString();
                string yS = y.ToString();

                return xS.CompareTo(yS);
            }
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
            if (this.IsFlags)
                return "";

            List<object> values = PropertyGridEditorViewModel.GetPropertyValues(this.Elements, this.PropertyName);
            if (values.Count == 0)
                return NullElement;

            Enum value = values[0] as Enum;
            foreach (object v in values)
            {
                if (value != v as Enum)
                {
                    value = null;
                    break;
                }
            }

            if (value == null)
                return NullElement;
            else
            {
                return value;
            }   
        }

        /// <summary>
        /// Updates the proeprty value;
        /// </summary>
        public void UpdatePropertyValue()
        {
            this.OnPropertyChanged("DisplayText");

            this.SetPropertyValue(this.GetDisplayText());
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            if (!this.IsFlags)
            {
                Enum eValue = value as Enum;
                if (value as string == NullElement)
                    eValue = null;

                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
                {
                    PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, eValue);
                    transaction.Commit();
                }
            }
            else
            {
                Enum eValue;

                string v = value as String;
                if (String.IsNullOrEmpty(v))
                    eValue = null;
                else
                {
                    string[] vals = v.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    string parsedVals = "";

                    foreach (string literal in vals)
                    {
                        if( parsedVals != "" )
                            parsedVals += ",";
                        parsedVals+= literal.Trim();
                        
                    }

                    eValue = (Enum)Enum.Parse(this.enumType, parsedVals);
                }

                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property value - " + this.PropertyName))
                {
                    PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, eValue);
                    transaction.Commit();
                }
            }
        }
    }
}
