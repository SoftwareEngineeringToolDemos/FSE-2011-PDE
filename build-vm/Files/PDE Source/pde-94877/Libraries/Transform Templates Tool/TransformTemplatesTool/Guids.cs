// Guids.cs
// MUST match guids.h
using System;

namespace Tum.TransformTemplatesTool
{
    static class GuidList
    {
        public const string guidTransformTemplatesToolPkgString = "f5615ff7-6125-475d-92ea-6c4beb8fd5c0";
        public const string guidTransformTemplatesToolCmdSetString = "0650ecad-5c02-478b-a986-fbd96ebf5bc6";

        public static readonly Guid guidTransformTemplatesToolCmdSet = new Guid(guidTransformTemplatesToolCmdSetString);
    };
}