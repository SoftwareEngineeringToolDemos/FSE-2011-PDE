using System.Globalization;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class PropertyGridEditorSerializer
    {
        public override string GetMonikerQualifier(DomainXmlSerializerDirectory directory, ModelElement element)
        {
            if (directory == null)
                throw new System.ArgumentNullException("directory");
            if (element == null)
                throw new System.ArgumentNullException("element");

            PropertyGridEditor propertyGridEditor = element as PropertyGridEditor;

            object[] objArr = new object[] { propertyGridEditor.MetaModel.Name };
            return System.String.Format(CultureInfo.CurrentCulture, "/{0}", objArr);
        }
        public override string CalculateQualifiedName(Microsoft.VisualStudio.Modeling.DomainXmlSerializerDirectory directory, Microsoft.VisualStudio.Modeling.ModelElement element)
        {
            if (directory == null)
                throw new System.ArgumentNullException("directory");
            if (element == null)
                throw new System.ArgumentNullException("element");
            PropertyGridEditor propertyGridEditor = element as PropertyGridEditor;
            string s1 = this.GetMonikerQualifier(directory, propertyGridEditor);
            string s2 = propertyGridEditor.Name;
            object[] objArr = new object[] {
                                             s1, 
                                             s2 };
            return System.String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}/{1}", objArr);
        }
    }
}
