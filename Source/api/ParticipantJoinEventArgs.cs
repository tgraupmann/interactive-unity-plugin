namespace Xbox.Services.Beam
{
    /// <summary>
    /// Triggered when a participant joins the Beam channel
    /// </summary>
    public class ParticipantJoinEventArgs : BeamEventArgs
    {
        /// <summary>
        /// Participant who has just joined the Beam channel
        /// </summary>
        public BeamParticipant Participant
        {
            get;
            private set;
        }

        internal ParticipantJoinEventArgs(BeamParticipant participant): base(BeamEventType.ParticipantStateChanged)
        {
            Participant = participant;
        }
    }
}
