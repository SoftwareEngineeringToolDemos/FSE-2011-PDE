using System;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This is the base view model for a property grid editor. A property grid editor allows to edit/view a
    /// specific property of one model element or of multiple model elements (if not, set 'CanHandleMultipleElements' to false).
    /// </summary>
    /// <remarks>
    /// Each instance of the property grid editor view model is initialized without the concrete binding to the element(s) which is/are
    /// to be edited. At this point each view model only implements the properties of the actual domain property (name, display name, etc).
    /// To supply the concrete binding to source elements, SetElement or SetElements need to be called. This is especially needed because we
    /// allow to edit equal properties of multiple elements (as long as the editor view model allows it).
    /// </remarks>
    public abstract class PropertyGridEditorViewModel : BaseViewModel, IPropertyGridEditorViewModel
    {
        private bool isSelected = false;
        private bool canHandleMultipleElements = true;

        private List<object> elements;

        private bool isInitialized = false;

        /// <summary>
        /// Property name.
        /// </summary>
        protected string propertyName;

        /// <summary>
        /// Property display name.
        /// </summary>
        protected string propertyDisplayName;

        /// <summary>
        /// Property description.
        /// </summary>
        protected string propertyDescription = "";

        /// <summary>
        /// Property category.
        /// </summary>
        protected string propertyCategory = "Misc";

        /// <summary>
        /// Is property required.
        /// </summary>
        protected bool isPropertyRequired = false;

        /// <summary>
        /// Is property readonly.
        /// </summary>
        protected bool isPropertyReadOnly = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected PropertyGridEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            elements = new List<object>();
        }

        /// <summary>
        /// Gets the property type that is edited within this view model.
        /// </summary>
        public virtual string PropertyType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Gets or sets the name or the property, which is represented by this view model.
        /// </summary>
        public virtual string PropertyName 
        {
            get { return this.propertyName; }
            set 
            { 
                this.propertyName = value;
                OnPropertyChanged("PropertyName");
            }
        }

        /// <summary>
        /// Gets or sets the display name of the property, which is represented by this view model.
        /// </summary>
        public virtual string PropertyDisplayName 
        {
            get { return this.propertyDisplayName; }
            set
            {
                this.propertyDisplayName = value;
                OnPropertyChanged("PropertyDisplayName");
            }
        }

        /// <summary>
        /// Gets or sets the description of the property, which is represented by this view model.
        /// </summary>
        public virtual string PropertyDescription
        {
            get { return this.propertyDescription; }
            set
            {
                this.propertyDescription = value;
                OnPropertyChanged("PropertyDescription");
            }
        }

        /// <summary>
        /// Gets or sets the category of the property, which is represented by this view model.
        /// </summary>
        public virtual string PropertyCategory
        {
            get { return this.propertyCategory; }
            set
            {
                this.propertyCategory = value;
                OnPropertyChanged("PropertyCategory");
            }
        }
        
        /// <summary>
        /// Gets or sets whether the property is required to have a value or not.
        /// </summary>
        public virtual bool IsPropertyRequired
        {
            get { return this.isPropertyRequired; }
            set
            {
                this.isPropertyRequired = value;
                OnPropertyChanged("IsPropertyRequired");
            }
        }

        /// <summary>
        /// Gets or sets whether this property editor is read-only (property not editable) or not (property editable).
        /// </summary>
        public virtual bool IsPropertyReadOnly
        {
            get { return this.isPropertyReadOnly; }
            set
            {
                this.isPropertyReadOnly = value;
                OnPropertyChanged("IsPropertyReadOnly");
            }
        }

        /// <summary>
        /// Gets or sets whether this property editor is the currently selected editor or not.
        /// </summary>
        public virtual bool IsSelected
        {
            get { return isSelected; }
            set
            {
                this.isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets whether this editor view model is initialized or not. A editor view model is marked as initialized,
        /// after the binding to concrete elements (SetElement, SetElements) is supplied.
        /// </summary>
        public bool IsInitialized
        {
            get { return this.isInitialized; }
        }

        /// <summary>
        /// Gets the list of objects from the model.
        /// </summary>
        public List<object> Elements
        {
            get { return this.elements; }
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        public object PropertyValue
        {
            get
            {
                return GetPropertyValue();
            }
            set
            {
                SetPropertyValue(value);
                OnPropertyChanged("PropertyValue");
            }
        }

        /// <summary>
        /// Converts the property value (in respect to multiple source elements) and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        public abstract object GetPropertyValue();

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public abstract void SetPropertyValue(object value);

        /// <summary>
        /// Subscribes to property values changes in the Model to reflect them onto the property grid. This might be 
        /// usefull for some editors, not for all.
        /// </summary>
        public virtual void SubscribeToModelChanges()
        {
        }

        /// <summary>
        /// Gets or sets whether this property editor can display/edit a property of multiple elements at the same time or not.
        /// </summary>
        public virtual bool CanHandleMultipleElements
        {
            get { return this.canHandleMultipleElements; }
            set { this.canHandleMultipleElements = value; }
        }

        /// <summary>
        /// Sets the concrete element, which property is to be added/displayed by this editor view model.
        /// </summary>
        /// <param name="element">Element</param>
        public virtual void SetElement(object element)
        {
            if (!IsInitialized)
                isInitialized = true;
            else
                return;

            this.elements.Add(element);

            SubscribeToModelChanges();
        }

        /// <summary>
        /// Sets the concrete elements, which equal property is to be added/displayed by this editor view model.
        /// </summary>
        /// <param name="elements">Elements</param>
        public virtual void SetElements(List<object> elements)
        {
            if (!IsInitialized)
                isInitialized = true;
            else
                return;

            if (!this.CanHandleMultipleElements && elements.Count > 1)
            {
                throw new NotSupportedException("Multiple elements supplied to the editor view model althout it doesnt support the editing of multiple elements!");
            }

            this.elements.AddRange(elements);

            SubscribeToModelChanges();
        }

        /// <summary>
        /// Gets the value of a specified property from the given element.
        /// </summary>
        /// <param name="element">Element to get the property value from.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Value of the property if the element has the requested property. Null otherwise.</returns>
        public static object GetPropertyValue(object element, string propertyName)
        {
            PropertyInfo propertyInfo = element.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                object value = propertyInfo.GetValue(element, null);
                if (value != null)
                    return value;
            }

            return null;
        }

        /// <summary>
        /// Gets the values of a specified property from the given elements.
        /// </summary>
        /// <param name="elements">Elements to get the property values from.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>List of values. Can be empty.</returns>
        public static List<object> GetPropertyValues(List<object> elements, string propertyName)
        {
            List<object> values = new List<object>();
            foreach (object element in elements)
            {
                object value = GetPropertyValue(element, propertyName);
                //if (value != null)
                    values.Add(value);
            }
            return values;
        }

        /// <summary>
        /// Gets the domain property id of a property on a model element.
        /// </summary>
        /// <param name="modelElement">Model element containing the named property.</param>
        /// <param name="propertyName">Property name of the property, for which to get the property domain id.</param>
        /// <returns>Domain property id if found, null otherwise.</returns>
        public static Guid? GetPropertyDomainObjectId(ModelElement modelElement, string propertyName)
        {
            PropertyInfo propertyInfo = modelElement.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                object[] obj = propertyInfo.GetCustomAttributes(typeof(DomainObjectIdAttribute), false);
                if (obj.Length == 1)
                {
                    DomainObjectIdAttribute idAttribute = (DomainObjectIdAttribute)obj[0];
                    return idAttribute.Id;
                }
            }

            return null;
        }

        /// <summary>
        /// Sets the property value to given elements property. Warning: Needs to be called in a transaction
        /// context, if the assignment of the property value to the property requires for it.
        /// </summary>
        /// <param name="element">Element, which property to assign the new value to.</param>
        /// <param name="propertyName">Property name of the property.</param>
        /// <param name="value">Value to assign to the property.</param>
        public static void SetPropertyValue(object element, string propertyName, object value)
        {
            PropertyInfo propertyInfo = element.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(element, value, null);
            }
        }

        /// <summary>
        /// Sets the property value to given elements property. Warning: Needs to be called in a transaction
        /// context, if the assignment of the property value to the property requires for it.
        /// </summary>
        /// <param name="elements">Elements, which property to assign the new value to.</param>
        /// <param name="propertyName">Property name of the property.</param>
        /// <param name="value">Value to assign to the property.</param>
        public static void SetPropertyValues(List<object> elements, string propertyName, object value)
        {
            foreach (object element in elements)
            {
                PropertyInfo propertyInfo = element.GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(element, value, null);
                }
            }
        }
    }
}