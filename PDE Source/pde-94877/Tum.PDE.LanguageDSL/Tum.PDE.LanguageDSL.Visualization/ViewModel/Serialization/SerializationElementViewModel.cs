using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts an serialization element.
    /// </summary>
    public class SerializationElementViewModel : BaseModelElementViewModel
    {
        private SerializationElement serializationElement;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationElement">SerializationElement.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        protected SerializationElementViewModel(ViewModelStore viewModelStore, SerializationElement serializationElement, ModelElement referencedElement)
            : base(viewModelStore, referencedElement)
        {
            this.serializationElement = serializationElement;
        }

        /// <summary>
        /// This constrcutor is used to create the dummy type used for lazy loading.
        /// </summary>
        public SerializationElementViewModel()
            : base(null, null)
        {
        }

        /// <summary>
        /// Gets the serialization element.
        /// </summary>
        public SerializationElement SerializationElement
        {
            get
            {
                return this.serializationElement;
            }
        }

        /// <summary>
        /// Gets the serialization element type.
        /// </summary>
        public virtual SerializationElementType SerializationElementType
        {
            get
            {
                return LanguageDSL.SerializationElementType.DomainClass;
            }
        }
    }
}
