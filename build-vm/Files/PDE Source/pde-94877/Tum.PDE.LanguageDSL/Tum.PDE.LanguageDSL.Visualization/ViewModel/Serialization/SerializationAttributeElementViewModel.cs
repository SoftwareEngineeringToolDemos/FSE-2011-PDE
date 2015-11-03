using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts a serialization attribute element.
    /// </summary>
    public class SerializationAttributeElementViewModel : SerializationElementViewModel
    {
        private SerializationClassViewModel parent;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationAttributeElement">SerializationAttributeElement.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        protected SerializationAttributeElementViewModel(ViewModelStore viewModelStore, SerializationAttributeElement serializationAttributeElement, ModelElement referencedElement, SerializationClassViewModel parent)
            : base(viewModelStore, serializationAttributeElement, referencedElement)
        {
            this.parent = parent;
        }

                /// <summary>
        /// This constrcutor is used to create the dummy type used for lazy loading.
        /// </summary>
        public SerializationAttributeElementViewModel()
            : base(null, null, null)
        {
        }

        /// <summary>
        /// Gets the parent view model.
        /// </summary>
        public SerializationClassViewModel Parent
        {
            get
            {
                return this.parent;
            }
        }

        /// <summary>
        /// Gets the serialization element.
        /// </summary>
        public new SerializationAttributeElement SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializationAttributeElement;
            }
        }
    }
}
