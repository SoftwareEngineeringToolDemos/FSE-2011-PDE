using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public class MetamodelProcessor : BaseProcessor
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        public MetamodelProcessor(MetaModel metaModel, LibraryModelContext modelContext)
            :base(metaModel, modelContext)
        {
        }

        /// <summary>
        /// Gets optimizations.
        /// </summary>
        public override List<BaseOptimization> GetOptimizations()
        {
            List<BaseOptimization> opt = new List<BaseOptimization>();
        
            // Optimization 1:
            // Base classes for common properties
            PropertiesProcessor p = new PropertiesProcessor(this.MetaModel, this.ModelContext);
            opt.AddRange(p.GetOptimizations());

            // Optimization 2:
            // Relationships
            RelationshipProcessor rp = new RelationshipProcessor(this.MetaModel, this.ModelContext);
            opt.InsertRange(0, rp.GetOptimizations());

            return opt;
        }
    }
}
