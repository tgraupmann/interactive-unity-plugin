using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Represents a joystick control event. These events are sent down at an
    /// interval frequency configured via the Beam front end designer.
    /// </summary>
    public class BeamJoystickEventArgs : BeamEventArgs
    {
        /// <summary>
        /// Unique string identifier for this control.
        /// </summary>
        public string ControlID
        {
            get;
            private set;
        }

        /// <summary>
        /// The X coordinate of the joystick, in the range of [-1, 1].
        /// </summary>
        public double X
        {
            get;
            private set;
        }

        /// <summary>
        /// The Y coordinate of the joystick, in the range of [-1, 1].
        /// </summary>
        public double Y
        {
            get;
            private set;
        }

        /// <summary>
        /// Participant whose action this event represents
        /// </summary>
        public BeamParticipant Participant
        {
            get;
            private set;
        }

        internal BeamJoystickEventArgs(BeamEventType type, string id, BeamParticipant participant, double x, double y) : base(type)
        {
            ControlID = id;
            Participant = participant;
            X = x;
            // We invert the y-axis to match Unity conventions. In Unity up is positive and down is negative.
            Y = -1 * y;
        }
    }
}
