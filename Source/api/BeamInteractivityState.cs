namespace Xbox.Services.Beam
{
    /// <summary>
    /// Enum representing the current state of the interactivity service.
    /// The state transitions are:
    /// NotInitialized -> Initializing
    /// Initializing -> ShortCodeRequired
    /// ShortCodeRequired -> InteractivityPending
    /// InteractivityPending -> InteractivityEnabled
    /// InteractivityEnabled -> InteractivityDisabled
    /// </summary>
    public enum BeamInteractivityState
    {
        /// <summary>
        /// The beam manager is not initalized.
        /// </summary>
        NotInitialized,

        /// <summary>
        /// The beam manager is in the process of initializing.
        /// </summary>
        Initializing,

        /// <summary>
        /// The beam manager needs the user to enter a short code on the Beam website
        /// in order to authenticate with the service.
        /// </summary>
        ShortCodeRequired,

        /// <summary>
        /// The beam manager is initialized.
        /// </summary>
        Initialized,

        /// <summary>
        /// The beam manager is initialized, but interactivity is not enabled.
        /// </summary>
        InteractivityDisabled,

        /// <summary>
        /// Currently connecting to the beam interactivity service.
        /// </summary>
        InteractivityPending,

        /// <summary>
        /// Interactivity enabled
        /// </summary>
        InteractivityEnabled
    }
}
