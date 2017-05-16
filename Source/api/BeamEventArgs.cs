using System;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Beam Interactivity is an event-driven service. This class is the base
    /// class for all Beam Interactivity events.
    /// </summary>
    public class BeamEventArgs: EventArgs
    {
        /// <summary>
        /// Function to construct a BeamEventArgs.
        /// </summary>
        public BeamEventArgs()
        {
            Time = DateTime.UtcNow;
            ErrorCode = 0;
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// The time (in UTC) when this event is triggered.
        /// </summary>
        public DateTime Time
        {
            get;
            private set;
        }

        /// <summary>
        /// The error code indicating the result of the operation.
        /// </summary>
        public int ErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns call specific error message with debug information.
        /// Message is not localized as it is meant to be used for debugging only.
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }

        /// <summary>
        /// Type of the event triggered.
        /// </summary>
        public BeamEventType EventType
        {
            get;
            private set;
        }

        internal BeamEventArgs(BeamEventType type)
        {
            Time = DateTime.UtcNow;
            ErrorCode = 0;
            ErrorMessage = string.Empty;
            EventType = type;
        }

        internal BeamEventArgs(BeamEventType type, int errorCode, string errorMessage)
        {
            Time = DateTime.UtcNow;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            EventType = type;
        }
    }
}
