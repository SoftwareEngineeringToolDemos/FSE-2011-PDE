using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Serialization helper class.
    /// </summary>
    public class SerializationHelper
    {
        /// <summary>
        /// Event set once the dictionary TypeEmbeddedDerivedNameTypes is initialized.
        /// </summary>
        protected static System.Threading.ManualResetEvent typeDNTInitializedEvent = new System.Threading.ManualResetEvent(false);

        /// <summary>
        /// Event set once the dictionary TypeDerivedNameTypes is initialized.
        /// </summary>
        protected static System.Threading.ManualResetEvent typeEmbeddedDNTInitializedEvent = new System.Threading.ManualResetEvent(false);

        /// <summary>
        /// Dictionary required to process derived types during serialization.
        /// </summary>
        /// <remarks>
        /// First guid: domain class type.
        /// List = serializationName of a child element as well as the its domain class type.
        /// </remarks>
        protected static Dictionary<Guid, Dictionary<string, List<Guid>>> typeEmbeddedDerivedNameTypes;

        /// <summary>
        /// Dictionary required to process derived types during serialization.
        /// </summary>
        /// <remarks>
        /// First guid: domain class type.
        /// List = serializationName of a derived element as well as its domain class type.
        /// </remarks>
        protected static Dictionary<Guid, Dictionary<string, Guid>> typeDerivedNameTypes;

        /// <summary>
        /// Static initialization.
        /// </summary>
        static SerializationHelper()
        {
            typeDerivedNameTypes = new Dictionary<Guid, Dictionary<string, Guid>>();
            typeEmbeddedDerivedNameTypes = new Dictionary<Guid, Dictionary<string, List<Guid>>>();
        }

        /// <summary>
        /// Dictionary required to process derived types during serialization.
        /// </summary>
        /// <remarks>
        /// First guid: domain class type.
        /// List = serializationName of a child element as well as the its domain class type.
        /// </remarks>
        public static Dictionary<Guid, Dictionary<string, List<Guid>>> TypeEmbeddedDerivedNameTypes
        {
            get
            {
                typeEmbeddedDNTInitializedEvent.WaitOne();
                return typeEmbeddedDerivedNameTypes;
            }
        }

        /// <summary>
        /// Dictionary required to process derived types during serialization.
        /// </summary>
        /// <remarks>
        /// First guid: domain class type.
        /// List = serializationName of a derived element as well as its domain class type.
        /// </remarks>
        public static Dictionary<Guid, Dictionary<string, Guid>> TypeDerivedNameTypes
        {
            get
            {
                typeDNTInitializedEvent.WaitOne();
                return typeDerivedNameTypes;
            }
        }

        /// <summary>
        /// Gets the type of a derived class of a specified basetype that is serialized under the given name.
        /// </summary>
        /// <param name="baseType">Base type.</param>
        /// <param name="name">Serialization name.</param>
        /// <returns>Derived type if found. Guid.Empty otherwise.</returns>
        public static Guid TryGetDerivedNameType(Guid baseType, string name)
        {
            Dictionary<String, Guid> dict;
            TypeDerivedNameTypes.TryGetValue(baseType, out dict);

            Guid val;
            dict.TryGetValue(name, out val);

            return val;
        }

        /// <summary>
        /// Gets the type of a embedded derived class of a specified basetype that is serialized under the given name.
        /// </summary>
        /// <param name="parentType">Base type.</param>
        /// <param name="name">Serialization name.</param>
        /// <returns>Embedded derived type if found. Guid.Empty otherwise.</returns>
        public static System.Collections.Generic.List<Guid> TryGetEmbeddedNameTypes(Guid parentType, string name)
        {
            Dictionary<String, System.Collections.Generic.List<Guid>> dict;
            TypeEmbeddedDerivedNameTypes.TryGetValue(parentType, out dict);

            if (dict != null)
            {
                System.Collections.Generic.List<Guid> val;
                dict.TryGetValue(name, out val);

                return val;
            }
            return null;
        }

        /// <summary>
        /// Gets the first type of a embedded derived class of a specified basetype that is serialized under the given name.
        /// </summary>
        /// <param name="parentType">Parent type.</param>
        /// <param name="baseType">Base type.</param>
        /// <param name="name">Serialization name.</param>
        /// <returns>First embedded derived type if found. Guid.Empty otherwise.</returns>
        public static Guid TryGetFirstEmbeddedDerivedNameType(Guid parentType, Guid baseType, string name)
        {
            Dictionary<String, System.Collections.Generic.List<Guid>> dict;
            TypeEmbeddedDerivedNameTypes.TryGetValue(parentType, out dict);

            Dictionary<string, Guid> dictDerived;
            TypeDerivedNameTypes.TryGetValue(baseType, out dictDerived);

            if (dict != null && dictDerived != null)
                if(dict.ContainsKey(name) && dictDerived.ContainsKey(name) )
            {
                List<Guid> val1 = dict[name];
                Guid val2 = dictDerived[name];

                if (val1.Contains(val2))
                    return val2;
            }

            return System.Guid.Empty;
        }
    }
}
