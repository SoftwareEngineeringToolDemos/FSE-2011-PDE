using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Model merge custom arguments.
    /// </summary>
    public interface IModelMergeCustomArguments : ISerializable
    {
        /// <summary>
        /// Gets serializer type.
        /// </summary>
        /// <returns></returns>
        Type GetSerializerType();
    }
}
