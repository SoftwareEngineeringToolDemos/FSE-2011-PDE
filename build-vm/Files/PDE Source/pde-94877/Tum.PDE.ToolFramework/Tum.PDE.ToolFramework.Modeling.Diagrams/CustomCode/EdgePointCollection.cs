using System;
using System.Collections;
using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Edge point collection.
    /// </summary>
    [CLSCompliant(true)]
    [Serializable]
    [TypeConverter(typeof(Converters.EdgePointCollectionConverter))]
    public class EdgePointCollection : ArrayList
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EdgePointCollection()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="collection"></param>
        public EdgePointCollection(System.Collections.ICollection collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="count"></param>
        public EdgePointCollection(int count)
            : base(count)
        {
        }

        /// <summary>
        /// Edge point specified by the index.
        /// </summary>
        /// <param name="index">Index of the edge point.</param>
        /// <returns>Edge point at the specified index.</returns>
        public virtual new EdgePoint this[int index]
        {
            get
            {
                return (EdgePoint)base[index];
            }
            set
            {
                base[index] = value;
            }
        }
    }
}
