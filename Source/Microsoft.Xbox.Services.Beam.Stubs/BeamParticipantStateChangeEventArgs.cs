namespace Xbox.Services.Beam
{
    public class BeamParticipantStateChangedEventArgs : BeamEventArgs
    {
        public BeamParticipant Participant
        {
            get;
            private set;
        }
        public BeamParticipantState State
        {
            get;
            private set;
        }
    }
}
