using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling;

using VMXExt = Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions;

namespace $LanguageNamespace$
{
    public partial class $LanguageName$DomainModelIdProvider
    {
        private List<string> VMXIDList = new List<string>();

        /// <summary>
        /// Generates a unique V-Modell XT key.
        /// </summary>
        /// <returns>V-Modell XT key formatted as a Guid.</returns>
        public override Guid GenerateNewKey()
        {
            string guidString = VMXExt::KeyGenerator.Instance.GenerateKey();
            //while (VMXIDList.Contains(guidString))
            //    guidString = VMXExt::KeyGenerator.Instance.GenerateKey();

            Guid guid = VMXExt::KeyGenerator.Instance.ConvertVModellIDToGuid(guidString);
            //if (base.HasKey(guid))
            //return GenerateNewKey();
            //else
            //{
            return guid;
            //}
        }


        /// <summary>
        /// Adds a new key to the ID list. 
        /// </summary>
        /// <param name="modelElement">Domain model element to add the Id for.</param>
        public override void AddKey(ModelElement modelElement)
        {
            base.AddKey(modelElement);

            if (!(modelElement is IDableElement)) 
                return;

            string vmxKey = VMXExt::KeyGenerator.Instance.ConvertGuidToVModellID(modelElement.Id);
            try
            {
                VMXIDList.Add(vmxKey);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Duplicate ID: modelID already in IDList! " + vmxKey + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Gets whether a certain key has already been assigned.
        /// </summary>
        /// <param name="key">VModell key.</param>
        /// <returns>True if the given id has already been assigned; false otherwise.</returns>
        public bool HasVModellKey(string key)
        {
            Guid guid = VMXExt::KeyGenerator.Instance.ConvertVModellIDToGuid(key);
            return base.HasKey(guid);

            //if (VMXIDList.Contains(key))
            //    return true;

            //return false;
        }

        /// <summary>
        /// Removes a specific key.
        /// </summary>
        /// <param name="modelElement">Domain model element to remove the key for.</param>
        public override void RemoveKey(ModelElement modelElement)
        {
            base.RemoveKey(modelElement);

            if (!(modelElement is IDableElement))
                return;

            string vmxKey = VMXExt::KeyGenerator.Instance.ConvertGuidToVModellID(modelElement.Id);
            try
            {
                VMXIDList.Remove(vmxKey);
            }
            catch { }
        }

        /// <summary>
        /// Resets the id provider.
        /// </summary>
        public override void Reset()
        {
            VMXIDList.Clear();

            base.Reset();
        }
    }
}
