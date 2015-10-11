using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static string GetDomainTypeCodeName(DomainType domainType)
        {
            if (domainType.Name.Contains("?"))
            {
                // remove ? and see if we can use that name.. otherwise add "Nullable" and an integer if needed at the end to destinguish name
                ReadOnlyCollection<ModelElement> elements = domainType.Store.ElementDirectory.FindElements(DomainType.DomainClassId);
                string typeName = domainType.Name.Replace("?", "");
                string typeNameWithoutIndex = typeName;
                bool bNullableAdded = false;
                int index = 0;
                while (true)
                {
                    bool bFound = false;
                    foreach (ModelElement m in elements)
                    {
                        if (m != domainType)
                        {
                            DomainType t = m as DomainType;
                            if (t.Name == typeName)
                            {
                                bFound = true;

                                if (!bNullableAdded)
                                {
                                    typeName += "Nullable";
                                    typeNameWithoutIndex = typeName;
                                    bNullableAdded = true;
                                }
                                else
                                {
                                    typeName = typeNameWithoutIndex + (index++);
                                }

                                // need to restart again
                                break;
                            }
                        }
                    }

                    if (!bFound)
                        return typeName;
                }
            }

            return domainType.Name;
        }
    }
}
