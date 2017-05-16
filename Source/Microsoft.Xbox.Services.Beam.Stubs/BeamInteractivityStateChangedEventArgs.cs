namespace Xbox.Services.Beam
{
    public class BeamInteractivityStateChangedEventArgs : BeamEventArgs
    {
        public BeamInteractivityState State
        {
            get;
            private set;
        }
    }
}
