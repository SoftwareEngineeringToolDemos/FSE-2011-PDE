using System.Globalization;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainEnumerationSerializer
    {
        public override string GetMonikerQualifier(DomainXmlSerializerDirectory directory, ModelElement element)
        {
            if (directory == null)
                throw new System.ArgumentNullException("directory");
            if (element == null)
                throw new System.ArgumentNullException("element");

            DomainEnumeration domainType = element as DomainEnumeration;
            string s = domainType.MetaModel.Name;
            object[] objArr = new object[] { s };
            return System.String.Format(CultureInfo.CurrentCulture, "/{0}", objArr);
        }
        public override string CalculateQualifiedName(DomainXmlSerializerDirectory directory, ModelElement element)
        {
            if (directory == null)
                throw new System.ArgumentNullException("directory");
            if (element == null)
                throw new System.ArgumentNullException("element");

            DomainEnumeration domainType = element as DomainEnumeration;
            string s1 = this.GetMonikerQualifier(directory, domainType);
            string s2 = domainType.Namespace;
            string s3 = domainType.Name;
            object[] objArr = new object[] {
                                             s1, 
                                             s2,
                                             s3};
            return System.String.Format(CultureInfo.CurrentCulture, "{0}/{1}/{2}", objArr);
        }
    }
}
