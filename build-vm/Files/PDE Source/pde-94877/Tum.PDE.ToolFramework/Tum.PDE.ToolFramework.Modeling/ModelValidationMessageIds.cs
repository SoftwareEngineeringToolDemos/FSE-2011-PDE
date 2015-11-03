namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
    public class ModelValidationMessageIds
    {
        /// <summary>
        /// Unknown message Id.
        /// </summary>
        public const string UnknownMessageId = "UnknownId";

        /// <summary>
        /// General serialization message Id
        /// </summary>
        public const string SerializationMessageId = "Serialization";

        /// <summary>
        /// Serialization error during loading Id.
        /// </summary>
        public const string SerializationLoadErrorId = "SerializationLoadFailure";

        /// <summary>
        /// Serialization error during saving Id.
        /// </summary>
        public const string SerializationSaveErrorId = "SerializationSaveFailure";
        
        /// <summary>
        /// General validation exception Id.
        /// </summary>
        public const string ValidationExceptionErrorId = "ValidationException";

        /// <summary>
        /// Validation error during the invocation of a method Id.
        /// </summary>
        public const string ValidationIvokeMethodExceptionErrorId = "ValidationIvokeMethodException";

        /// <summary>
        /// Paste disallowed error Id.
        /// </summary>
        public const string ModelMergePasteDisallowedId = "ModelMergePasteDisallowedFailure";

        /// <summary>
        /// Move disallowed error Id.
        /// </summary>
        public const string ModelMergeMoveDisallowedId = "ModelMergeMoveDisallowedFailure";        

        /// <summary>
        /// Element exists on move Id.
        /// </summary>
        public const string ModelMergeElementExistsOnMoveId = "ModelMergeElementExistsOnMoveFailure";

        /// <summary>
        /// Elements is missing on move Id.
        /// </summary>
        public const string ModelMergeElementMissingOnMoveId = "ModelMergeElementMissingOnMoveFailure";

        /// <summary>
        /// Element Link exists on move.
        /// </summary>
        public const string ModelMergeElementLinkExistsOnMoveId = "ModelMergeElementExistsOnMoveFailure";        

        /// <summary>
        /// Link element couldn't be copied Id.
        /// </summary>
        public const string ModelMergeLinkElementNotCopiedId = "ModelLinkMergeElementNotCopied";

        /// <summary>
        /// Link element wasn't found on paste Id.
        /// </summary>
        public const string ModelMergeLinkElementNotFoundId = "ModelLinkMergeElementNotFoundFailure";

        /// <summary>
        /// Link creation violates multiplicity on paste Id.
        /// </summary>
        public const string ModelMergeLinkCreationViolatesMultiplicityId = "ModelMergeLinkCreationViolatesMultiplicity";

        /// <summary>
        /// Link creation domain type not found.
        /// </summary>
        public const string ModelMergeElementLinkDomainTypeMissingId = "ModelMergeElementLinkDomainTypeMissing";
    }
}
