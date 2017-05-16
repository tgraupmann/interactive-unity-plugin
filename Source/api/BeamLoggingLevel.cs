namespace Xbox.Services.Beam
{
    /// <summary>
    /// A list of possible levels of logging from the Beam SDK.
    /// </summary>
    public enum BeamLoggingLevel
    {
        /// <summary>
        /// No debug output.
        /// </summary>
        None,

        /// <summary>
        /// Only errors and warnings.
        /// </summary>
        Minimal,

        /// <summary>
        /// All events, including every websocket and HTTP message.
        /// </summary>
        Verbose
    }
}
