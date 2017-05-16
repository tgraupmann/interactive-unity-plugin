namespace Xbox.Services.Beam
{
    public class ParticipantJoinEventArgs : BeamEventArgs
    {
        public BeamParticipant Participant
        {
            get;
            private set;
        }
    }
}
