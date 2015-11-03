namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Type of the edge point for further implementation. NOT supported yet.
    /// </summary>
    public enum EdgePointType
    {
        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Start of a jump.
        /// </summary>
        JumpStart = 1,

        /// <summary>
        /// Middle of a jump.
        /// </summary>
        JumpMiddle = 2,

        /// <summary>
        /// End of a jump.
        /// </summary>
        JumpEnd = 3
    }
}
