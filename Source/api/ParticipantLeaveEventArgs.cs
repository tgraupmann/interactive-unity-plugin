namespace Xbox.Services.Beam
{
    /// <summary>
    /// Triggered when a participant leaves the Beam channel
    /// </summary>
    public class ParticipantLeaveEventArgs : BeamEventArgs
    {
        /// <summary>
        /// Participant who has just left the Beam channel
        /// </summary>
        public BeamParticipant Participant
        {
            get;
            private set;
        }

        internal ParticipantLeaveEventArgs(BeamParticipant participant)
        {
            Participant = participant;
        }
    }
}
