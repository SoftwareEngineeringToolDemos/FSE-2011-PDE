using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{   
    /// <summary>
    /// This view model hosts a serialized domain model class.
    /// </summary>
    public class SerializedDomainModelViewModel : SerializedDomainClassViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationClass">SerializationClass.</param>
        public SerializedDomainModelViewModel(ViewModelStore viewModelStore, SerializedDomainModel serializationClass)
            : base(viewModelStore, serializationClass, null)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationClass">SerializationClass.</param>
        public SerializedDomainModelViewModel(ViewModelStore viewModelStore, SerializedDomainClass serializationClass)
            : base(viewModelStore, serializationClass, null)
        {
        }

        /*
        /// <summary>
        /// Gets the serialized domain class.
        /// </summary>
        public new SerializedDomainModel SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedDomainModel;
            }
        }*/

        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.DomainModel; }
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
