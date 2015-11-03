using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization;

namespace Tum.PDE.LanguageDSL.Visualization.Selectors
{
    public class SerializationModelTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationModelTreeHeaderDomainModelTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationClassTreeHeaderDomainClassTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationModelTreeHeaderDomainPropertyTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationModelTreeHeaderIdPropertyTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationModelTreeHeaderEmbeddingTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationModelTreeHeaderReferencingTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Template
        /// </summary>
        public DataTemplate SerializationClassTreeHeaderDomainRoleTemplate
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            SerializationElementViewModel dataItem = item as SerializationElementViewModel;
            if (dataItem == null)
                return null;

            if (dataItem.SerializationElementType == SerializationElementType.DomainModel)
                return SerializationModelTreeHeaderDomainModelTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.DomainClass)
                return SerializationClassTreeHeaderDomainClassTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.DomainProperty)
                return SerializationModelTreeHeaderDomainPropertyTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.IdProperty)
                return SerializationModelTreeHeaderIdPropertyTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.EmbeddingRelationship)
                return SerializationModelTreeHeaderEmbeddingTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.ReferenceRelationship)
                return SerializationModelTreeHeaderReferencingTemplate;
            else if (dataItem.SerializationElementType == SerializationElementType.DomainRole)
                return SerializationClassTreeHeaderDomainRoleTemplate;

            return null;
        }
    }
}
