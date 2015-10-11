using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    /*
    public partial class DomainElementTypeDescriptor
    {
        private DomainEnumPropertyDescriptor CreateDomainEnumPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement requestor, Microsoft.VisualStudio.Modeling.DomainPropertyInfo domainPropertyInfo, System.Attribute[] attributes)
        {
            DomainProperty domainProperty = requestor as DomainProperty;
            if (domainProperty == null)
                return null;
            if (domainPropertyInfo.Id != DomainProperty.DefaultValueDomainPropertyId)
                return null;
            DomainEnumeration domainEnumeration = domainProperty.Type as DomainEnumeration;
            if (domainEnumeration == null)
                return null;
            return new DomainEnumPropertyDescriptor(this, requestor, domainPropertyInfo, domainEnumeration, attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor CreatePropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement requestor, Microsoft.VisualStudio.Modeling.DomainPropertyInfo domainPropertyInfo, Attribute[] attributes)
        {
            DomainEnumPropertyDescriptor domainEnumPropertyDescriptor = CreateDomainEnumPropertyDescriptor(requestor, domainPropertyInfo, attributes);
            if (domainEnumPropertyDescriptor != null)
                return domainEnumPropertyDescriptor;

            return base.CreatePropertyDescriptor(requestor, domainPropertyInfo, attributes);
        }

        /// <summary>
        /// Returns a collection of property descriptors an instance of DomainElement.
        /// </summary>
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties();
        }
    }*/
}
