using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static bool IsDiagramGenerated(DiagramClass diagramClass)
        {
            if (diagramClass is SpecificElementsDiagram)
            {
                if ((diagramClass as SpecificElementsDiagram).DomainClasses.Count == 0)
                    return false;
            }
            else if (diagramClass is ModalDiagram)
            {
                if ((diagramClass as ModalDiagram).DomainClass == null)
                    return false;
            }
            else if (diagramClass is SpecificDependencyDiagram)
            {
                if ((diagramClass as SpecificDependencyDiagram).DomainClass == null)
                    return false;
            }

            return true;
        }

        public static bool HasProperty(ShapeClass shapeClass, string name)
        {
            if (shapeClass == null)
                return false;

            ShapeClass d = shapeClass;
            while (d != null)
            {
                foreach (DomainProperty p in d.Properties)
                    if (p.Name == name)
                        return true;

                d = d.BaseShape;
            }

            return false;
        }
    }
}
