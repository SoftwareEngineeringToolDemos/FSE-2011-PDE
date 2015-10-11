using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// Specific view model store. Stores view models to
    /// 1. prevent stack overflows
    /// 2. reuse view models where applicable.
    /// </summary>
    public class SpecificViewModelStore
    {
        private Dictionary<string, BaseSpecificModelElementViewModel> mapping;
        private Dictionary<string, List<Guid>> mappingElements;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SpecificViewModelStore()
        {
            mapping = new Dictionary<string, BaseSpecificModelElementViewModel>();
            mappingElements = new Dictionary<string, List<Guid>>();
        }

        /// <summary>
        /// Tries to get a vm of a specific type hosting a specific element.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public BaseSpecificModelElementViewModel TryGetVM(string type, Guid elementId)
        {
            string key = type + "_" + elementId;
            return TryGetVM(key);
        }

        /// <summary>
        /// Tries to get a vm by the given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BaseSpecificModelElementViewModel TryGetVM(string key)
        {
            if (mapping.ContainsKey(key))
            {
                if (mapping[key].IsDisposed)
                    return null;

                if (mapping[key].ParentViewModel != null)
                    if (mapping[key].ParentViewModel.IsDisposed == true)
                        return null;
             
                return mapping[key];
            }

            return null;
        }

        /// <summary>
        /// Adds a vm.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="parentId"></param>
        public void AddVM(BaseSpecificModelElementViewModel vm, Guid parentId)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");

            if (vm.Element == null)
                return;

            string key = GetKey(vm);

            if( !mapping.ContainsKey(key) )
                mapping.Add(key, vm);

            if (!mappingElements.ContainsKey(key))
                mappingElements.Add(key, new List<Guid>());

            //if( !mappingElements[key].Contains(parentId) )
            mappingElements[key].Add(parentId);
        }

        /// <summary>
        /// Removes a vm.
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="parentId"></param>
        public void RemoveVM(BaseSpecificModelElementViewModel vm, Guid parentId)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");

            if (vm.Element == null)
                return;

            string key = GetKey(vm);

            if (mappingElements.ContainsKey(key))
            {
                mappingElements[key].Remove(parentId);
                if (mappingElements[key].Count == 0)
                {
                    mapping.Remove(key);
                    mappingElements.Remove(key);
                }
            }
        }

        /// <summary>
        /// Verifies if a vm is still in use.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public bool IsVMInUse(BaseSpecificModelElementViewModel vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");

            if (vm.Element == null)
                return false;

            string key = GetKey(vm);

            if (mappingElements.ContainsKey(key))
                if (mappingElements[key].Count > 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Creates and returns a key for given vm.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private string GetKey(BaseSpecificModelElementViewModel vm)
        {
            return vm.GetType().FullName + "_" + vm.Element.Id;
        }

        /// <summary>
        /// Gets the mapping dictionary.
        /// </summary>
        public Dictionary<string, BaseSpecificModelElementViewModel> Mapping
        {
            get
            {
                return this.mapping;
            }

        }

        /// <summary>
        /// Gets the mapping elements dictionary.
        /// </summary>
        public Dictionary<string, List<Guid>> MappingElements
        {
            get
            {
                return this.mappingElements;
            }
        }
    }
}
