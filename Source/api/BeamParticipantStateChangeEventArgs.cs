using System;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Triggered when a participant joins or leaves the Beam channel
    /// </summary>
    public class BeamParticipantStateChangedEventArgs : BeamEventArgs
    {
        /// <summary>
        /// Participant who has just joined the Beam channel
        /// </summary>
        public BeamParticipant Participant
        {
            get;
            private set;
        }

        /// <summary>
        /// The participant's current state.
        /// </summary>
        public BeamParticipantState State
        {
            get;
            private set;
        }

        internal BeamParticipantStateChangedEventArgs(BeamEventType type, BeamParticipant participant, BeamParticipantState state) : base(type)
        {
            Participant = participant;
            State = state;
        }
    }
}
