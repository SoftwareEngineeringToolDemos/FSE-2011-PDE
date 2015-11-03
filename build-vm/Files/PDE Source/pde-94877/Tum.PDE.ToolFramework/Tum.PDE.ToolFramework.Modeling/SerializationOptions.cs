using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Specifies serialization options, that might be required during domain specific serialization.
    /// </summary>
    public class SerializationOptions
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SerializationOptions()
        {
            SerializationMode = Modeling.SerializationMode.Normal;
        }

        /// <summary>
        /// Gets or sets how the serialization should be processed.
        /// </summary>
        public SerializationMode SerializationMode
        {
            get;
            set;
        }
    }
}
