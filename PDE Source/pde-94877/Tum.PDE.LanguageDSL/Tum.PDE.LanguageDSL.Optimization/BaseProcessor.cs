using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Optimization
{
    public abstract class BaseProcessor
    {       
        /// <summary>
        /// Gets the metamodel.
        /// </summary>
        public MetaModel MetaModel
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public LibraryModelContext ModelContext
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <param name="modelContext"></param>
        protected BaseProcessor(MetaModel metaModel, LibraryModelContext modelContext)
        {
            this.MetaModel = metaModel;
            this.ModelContext = modelContext;
        }

        /// <summary>
        /// Gets optimizations.
        /// </summary>
        /// <returns></returns>
        public abstract List<BaseOptimization> GetOptimizations();
    }
}
