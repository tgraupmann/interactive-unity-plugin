using System.Collections.Generic;

namespace Microsoft.Mixer
{
    public class InteractivityStateChangedEventArgs : InteractiveEventArgs
    {
        public InteractivityState State
        {
            get;
            private set;
        }

        internal InteractivityStateChangedEventArgs(InteractiveEventType type, InteractivityState state) : base(type)
        {
        }
    }
}
