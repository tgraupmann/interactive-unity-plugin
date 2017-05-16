namespace Xbox.Services.Beam
{
    public class ParticipantLeaveEventArgs : BeamEventArgs
    {
        public BeamParticipant Participant
        {
            get;
            private set;
        }
    }
}
