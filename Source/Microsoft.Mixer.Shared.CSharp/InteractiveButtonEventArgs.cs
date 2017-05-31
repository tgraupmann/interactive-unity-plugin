using System.Collections.Generic;

namespace Microsoft.Mixer
{
    /// <summary>
    /// Arguments for a button event.
    /// </summary>
    public class InteractiveButtonEventArgs : InteractiveEventArgs
    {
        /// <summary>
        /// Unique string identifier for this control
        /// </summary>
        public string ControlID
        {
            get;
            private set;
        }

        /// <summary>
        /// The participant who triggered this event.
        /// </summary>
        public InteractiveParticipant Participant
        {
            get;
            private set;
        }

        /// <summary>
        /// Boolean to indicate if the button is pressed down or not.
        /// Returns TRUE if button is pressed down.
        /// </summary
        public bool IsPressed
        {
            get;
            private set;
        }

        internal InteractiveButtonEventArgs(InteractiveEventType type, string id, InteractiveParticipant participant, bool isPressed) : base(type)
        {
            ControlID = id;
            Participant = participant;
            IsPressed = isPressed;
        }
    }
}
