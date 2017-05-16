using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Arguments for a button event.
    /// </summary>
    public class BeamButtonEventArgs : BeamEventArgs
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
        /// The spectator who triggered this event.
        /// </summary>
        public BeamParticipant Participant
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

        internal BeamButtonEventArgs(BeamEventType type, string id, BeamParticipant participant, bool isPressed) : base(type)
        {
            ControlID = id;
            Participant = participant;
            IsPressed = isPressed;
        }
    }
}
