using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    public interface IModelMergeCustomArguments : ISerializable
    {
        /*
        /// <summary>
        /// Populates a System.Runtime.Serialization.SerializationInfo with the data
        /// needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination (see System.Runtime.Serialization.StreamingContext) for this serialization.</param>
        void Serialize(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// Deserialize.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        void Deserialize(SerializationInfo info);
        */

        Type GetSerializerType();
    }
}
