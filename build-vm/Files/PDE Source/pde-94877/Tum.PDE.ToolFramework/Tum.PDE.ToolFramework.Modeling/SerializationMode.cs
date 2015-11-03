namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Specifies how serialization should be processed.
    /// </summary>
    public enum SerializationMode
    {
        /// <summary>
        /// Default serialization routine.
        /// </summary>
        Normal,

        /// <summary>
        /// Temporarly saves the model to a given location. The current model is not updated (meaning,
        /// we still work on the current file).
        /// </summary>
        Temporarly,

        /// <summary>
        /// Serializes the model to string, default serialization routine is executed here.
        /// </summary>
        InternalToString,

        /// <summary>
        /// Serializes the model to string. All referenced models, that are not serialized explicitly in
        /// the current file should be included in that serialization as if they were.
        /// </summary>
        InternalFullToString
    }
}
