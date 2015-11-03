using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Data
{
    public class ModelData
    {
        private MetaModel metaModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="metaModel">MetaModel instance.</param>
        public ModelData(MetaModel metaModel)
        {
            this.metaModel = metaModel;
        }

        /// <summary>
        /// Gets the meta model instance.
        /// </summary>
        public MetaModel MetaModel
        {
            get
            {
                return this.metaModel;
            }
        }

        /// <summary>
        /// Gets the store containing the domain model.
        /// </summary>
        public Store Store
        {
            get { return metaModel.Store; }
        }
    }
}
