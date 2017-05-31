using System;

namespace Microsoft.Mixer
{
    public class InteractiveParticipantStateChangedEventArgs : InteractiveEventArgs
    {
        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        public InteractiveParticipantState State
        {
            get;
            private set;
        }

        internal InteractiveParticipantStateChangedEventArgs(InteractiveEventType type, InteractiveParticipant participant, InteractiveParticipantState state) : base(type)
        {
        }
    }
}
