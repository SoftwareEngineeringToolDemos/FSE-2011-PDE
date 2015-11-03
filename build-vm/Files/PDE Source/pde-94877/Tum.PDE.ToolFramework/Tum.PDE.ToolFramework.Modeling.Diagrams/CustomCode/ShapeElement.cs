using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// ShapeElement class.
    /// </summary>
    public abstract partial class ShapeElement
    {
        /// <summary>
        /// Gets or sets the element, that is visualized by this shape element.
        /// </summary>
        public ModelElement Element
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if (this.InternalElementId == Guid.Empty)
                    return null;

                return this.Store.ElementDirectory.FindElement(this.InternalElementId) as ModelElement;
            }

            [global::System.Diagnostics.DebuggerStepThrough]
            set
            {
                base.InternalElementId = value.Id;
            }
        }

        private Guid? dCId = null;

        /// <summary>
        /// Get the domain class Id.
        /// </summary>
        /// <returns></returns>
        public Guid GetDomainClassId()
        {
            if (dCId == null)
                dCId = this.GetDomainClass().Id;

            return dCId.Value;
        }

        /// <summary>
        /// Gets the store.
        /// </summary>
        [CLSCompliant(false)]
        public new DomainModelStore Store
        {
            get
            {
                return base.Store as DomainModelStore;
            }
        }
    }
}
