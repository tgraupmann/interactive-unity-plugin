namespace Microsoft.Mixer
{
    public class ParticipantLeaveEventArgs : InteractiveEventArgs
    {
        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        internal ParticipantLeaveEventArgs(InteractiveParticipant participant)
        {
        }
    }
}
