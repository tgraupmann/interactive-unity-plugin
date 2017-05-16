using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Contains the new interactivity state of the BeamManager.
    /// </summary>
    public class BeamInteractivityStateChangedEventArgs : BeamEventArgs
    {
        /// <summary>
        /// Unique string identifier for this control.
        /// </summary>
        public BeamInteractivityState State
        {
            get;
            private set;
        }

        internal BeamInteractivityStateChangedEventArgs(BeamEventType type, BeamInteractivityState state) : base(type)
        {
            State = state;
        }
}
}
