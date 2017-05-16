using System;

namespace Xbox.Services.Beam
{

    /// <summary>
    /// Enum representing the current state of the participant
    /// </summary>
    public enum BeamParticipantState
    {
        /// <summary>
        /// The participant joined the channel
        /// </summary>
        Joined,

        /// <summary>
        /// The participant's input is disabled
        /// </summary>
        InputDisabled,

        /// <summary>
        /// The participant left the channel
        /// </summary>
        Left
    }
}
