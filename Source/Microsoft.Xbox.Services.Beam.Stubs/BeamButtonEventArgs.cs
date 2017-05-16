namespace Xbox.Services.Beam
{
    public class BeamButtonEventArgs : BeamEventArgs
    {
        public string ControlID
        {
            get;
            private set;
        }

        public BeamParticipant Participant
        {
            get;
            private set;
        }
        
        public bool IsPressed
        {
            get;
            private set;
        }
    }
}
