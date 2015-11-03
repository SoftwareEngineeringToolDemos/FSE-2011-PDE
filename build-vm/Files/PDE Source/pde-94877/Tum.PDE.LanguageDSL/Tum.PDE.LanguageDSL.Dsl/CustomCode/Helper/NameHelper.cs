using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL
{
    public class NameHelper
    {
        public static string GetUniqueName(Store store, Guid domainClassId)
        {
            string nameFree = LanguageDSLElementTypeProvider.Instance.GetTypeName(domainClassId);
            int counter = 1;

            List<string> usedNames = new List<string>();
            ReadOnlyCollection<ModelElement> elements = store.ElementDirectory.FindElements(domainClassId);
            foreach (ModelElement element in elements)
            {
                if (LanguageDSLElementNameProvider.Instance.HasName(element))
                {
                    string s = LanguageDSLElementNameProvider.Instance.GetName(element);
                    usedNames.Add(s);
                }
            }

            while (true)
            {
                if( usedNames.Contains(nameFree + counter.ToString()) )
                    counter++;
                else
                    break;
            }

            return nameFree + counter.ToString();
        }
    }
}
