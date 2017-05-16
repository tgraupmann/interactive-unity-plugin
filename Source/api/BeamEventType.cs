namespace Xbox.Services.Beam
{
    /// <summary>
    /// Defines values used to indicate Beam event types.
    /// </summary>
    public enum BeamEventType
    {
        /// <summary>
        /// This event is triggered when the service or manager encounters an error.
        /// The Error and ErrorMessage members will contain pertinent info.
        /// </summary>
        Error,

        /// <summary>
        /// The interactivity state of the beam manager has changed.
        /// </summary>
        InteractivityStateChanged,

        /// <summary>
        /// Event fired when a participant's state changes, e.g., joins, leaves,
        /// has input disabled, etc.
        /// </summary>
        ParticipantStateChanged,

        /// <summary>
        /// Events representing button input.
        /// </summary>
        Button,

        /// <summary>
        /// Events representing joystick input.
        /// </summary>
        Joystick
    }
}
