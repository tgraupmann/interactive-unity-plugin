namespace Microsoft.Mixer
{
    public class ParticipantJoinEventArgs : InteractiveEventArgs
    {
        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        internal ParticipantJoinEventArgs(InteractiveParticipant participant): base(InteractiveEventType.ParticipantStateChanged)
        {
        }
    }
}
