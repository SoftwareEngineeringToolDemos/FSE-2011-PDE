using System;
using System.Collections.Generic;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This abstract base class represents a property, which has some sort of a list to select property value(s) from. 
    /// For this, it provides default values as well as a filter to remove unneeded entries.
    /// 
    /// To provide a default values list, you can either derive a custom view model from this view model and override the 
    /// 'GetDefaultValues' method, or provide an LookupListEditorDefaultValuesProvider, which will be called to retrieve 
    /// a default values list.
    /// 
    /// To filter a default values list after(!) it is retrieved, you can override 'FilterDefaultValues' in a custom
    /// derived class and provide an LookupListEditorFilter. First the FilterDefaultValues function is called, than
    /// the provided filter.
    /// </summary>
    /// <remarks>
    /// This is the base class for: Enumeration, Boolean and the Role editors by default. It can be used in the view to 
    /// implement e.g. a combo box or an list style editor.
    /// </remarks>
    public abstract class LookupListEditorViewModel : PropertyEditorViewModel
    {
        private List<object> defaultValues = null;

        /// <summary>
        /// Indicates a dynamic source of default values.
        /// </summary>
        protected bool isDefaultValuesSourceDynamic = false;

        private Comparison<object> sort = null;
        private LookupListEditorFilter<object> filter = null;
        private LookupListEditorDefaultValuesProvider<object> defaultValuesProvider = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected LookupListEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            
        }

        /// <summary>
        /// Updates the default values list as follows:
        /// 
        /// 1. GetDefaultValues
        /// 2. FilterDefaultValues
        /// 3. SortDefaultValues
        /// 4. InsertSentinelDefaultValue
        /// </summary>
        public void UpdateDefaultValuesList()
        {
            this.defaultValues = GetDefaultValues();

            FilterDefaultValues(this.defaultValues);
            if (Filter != null)
                Filter(this, this.GetPropertyValue(), this.defaultValues);

            SortDefaultValues(this.defaultValues);
            InsertSentinelDefaultValue(this.defaultValues);

            OnPropertyChanged("DefaultValues");
        }

        /// <summary>
        /// This method provides the default values to use in the combobox. If the source is dynamic, this
        /// will be called each time before displaying the combobox dropdown list.
        /// </summary>
        /// <returns>List of default values. If no values provider is supplied, an empty list is returned.</returns>
        protected virtual List<object> GetDefaultValues()
        {
            if (DefaultValuesProvider != null)
                return DefaultValuesProvider(this);
            else
                return new List<object>();
        }

        /// <summary>
        /// Filters the given default values list.
        /// </summary>
        /// <param name="dValues">List of values to filter.</param>
        protected virtual void FilterDefaultValues(List<object> dValues)
        {
        }

        /// <summary>
        /// Sorts the given default values list.
        /// </summary>
        /// <param name="dValues"></param>
        protected virtual void SortDefaultValues(List<object> dValues)
        {
            if (Sort != null)
                dValues.Sort(Sort);
        }

        /// <summary>
        /// Inserts an sentinel item into the default values list.
        /// </summary>
        /// <param name="dValues"></param>
        protected virtual void InsertSentinelDefaultValue(List<object> dValues)
        {
        }

        /// <summary>
        /// Gets or sets the sort function.
        /// </summary>
        public Comparison<object> Sort
        {
            get { return sort; }
            set
            {
                sort = value;
                if (IsInitialized)
                {
                    UpdateDefaultValuesList();

                    // notify of property change
                    OnPropertyChanged("DefaultValues");

                }
            }
        }

        /// <summary>
        /// Gets or sets the filter to remove entries from the default values list. Can be null
        /// </summary>
        public LookupListEditorFilter<object> Filter
        {
            get { return filter; }
            set 
            { 
                filter = value;
                if (IsInitialized)
                {
                    UpdateDefaultValuesList();

                    // notify of property change
                    OnPropertyChanged("DefaultValues");
                }
            }
        }

        /// <summary>
        /// Gets or sets the default values provider for this view model.
        /// </summary>
        public LookupListEditorDefaultValuesProvider<object> DefaultValuesProvider
        {
            get { return defaultValuesProvider; }
            set
            {
                defaultValuesProvider = value;
                if (IsInitialized)
                {
                    // if the source is not dynamic, we need to update the default values list (if it is dynamic, it is going to be updated
                    // the next time the dropdown list is about to be shown)
                    UpdateDefaultValuesList();

                    // notify of property change
                    OnPropertyChanged("DefaultValues");
                }
            }
        }

        /// <summary>
        /// Gets the default values to use in the combobox dropdown list.
        /// </summary>
        public List<object> DefaultValues
        {
            get 
            {
                if (this.defaultValues == null)
                    UpdateDefaultValuesList();

                return this.defaultValues; 
            }
        }
    }
}
