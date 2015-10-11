using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts a serialized domain class.
    /// </summary>
    public class SerializedDomainClassViewModel : SerializationClassViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationClass">SerializationClass.</param>
        public SerializedDomainClassViewModel(ViewModelStore viewModelStore, SerializedDomainClass serializationClass, SerializationClassViewModel parent)
            : base(viewModelStore, serializationClass, serializationClass.DomainClass, parent)
        {
        }

        /// <summary>
        /// Gets the serialized domain class.
        /// </summary>
        public new SerializedDomainClass SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedDomainClass;
            }
        }

        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.DomainClass; }
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.SerializationElement;
        }

    }
}
