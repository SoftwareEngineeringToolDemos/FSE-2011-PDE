using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static List<MetaModel> GetAllLibraries(MetaModel metaModel)
        {
            List<MetaModel> models = new List<MetaModel>();
            GetAllLibraries(metaModel, metaModel, models);
            return models;
        }
        private static void GetAllLibraries(MetaModel metaModel, MetaModel topMost, List<MetaModel> models)
        {
            foreach (MetaModelLibrary lib in metaModel.MetaModelLibraries)
            {
                MetaModel m = lib.ImportedLibrary as MetaModel;
                if (m != null)
                {
                    if (m != topMost && !models.Contains(m))
                    {
                        models.Add(m);
                        GetAllLibraries(m, topMost, models);
                    }
                }
            }
        }
    }
}
