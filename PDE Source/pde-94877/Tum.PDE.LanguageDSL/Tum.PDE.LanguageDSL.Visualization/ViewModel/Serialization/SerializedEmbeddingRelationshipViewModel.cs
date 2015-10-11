using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts a SerializedEmbeddingRelationship.
    /// </summary>
    public class SerializedEmbeddingRelationshipViewModel : SerializedRelationshipViewModel
    {        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedRelationship">SerializedRelationship.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        public SerializedEmbeddingRelationshipViewModel(ViewModelStore viewModelStore, SerializedEmbeddingRelationship serializedRelationship, SerializationClassViewModel parent)
            : base(viewModelStore, serializedRelationship, serializedRelationship.EmbeddingRelationship, parent)
        {
            if (this.SerializationElement.EmbeddingRelationship != null)
            {
                this.sourceRoleVM = new SerializedDomainRoleViewModel(this.ViewModelStore, this.SerializationElement.EmbeddingRelationship.Source, this.SerializationElement.EmbeddingRelationship, this);
                this.targetRoleVM = new SerializedDomainRoleViewModel(this.ViewModelStore, this.SerializationElement.EmbeddingRelationship.Target, this.SerializationElement.EmbeddingRelationship, this);
            }
        }

        /// <summary>
        /// Gets the serialized rs.
        /// </summary>
        public new SerializedEmbeddingRelationship SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedEmbeddingRelationship;
            }
        }
       
        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.EmbeddingRelationship; }
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
