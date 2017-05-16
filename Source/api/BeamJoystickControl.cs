using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Represents a Beam Interactivity joystick control. All controls are created and 
    /// configured using the Beam Lab.
    /// </summary>
    public class BeamJoystickControl : BeamControl
    {
        /// <summary>
        /// The current X coordinate of the joystick, in the range of [-1, 1].
        /// </summary>
        public double X
        {
            get
            {
                double x = 0;
                if (ControlID != null)
                {
                    InternalJoystickState joystickState;
                    if (BeamManager._joystickStates.TryGetValue(ControlID, out joystickState))
                    {
                        x = joystickState.X;
                    }
                }
                return x;
            }
        }

        /// <summary>
        /// The current Y coordinate of the joystick, in the range of [-1, 1].
        /// </summary>
        public double Y
        {
            get
            {
                double y = 0;
                if (ControlID != null)
                {
                    InternalJoystickState joystickState;
                    if (BeamManager._joystickStates.TryGetValue(ControlID, out joystickState))
                    {
                        y = joystickState.Y;
                    }
                }
                return y;
            }
        }

        /// <summary>
        /// The current [0,1] intensity of this joystick control
        /// </summary>
        public double Intensity
        {
            get;
            private set;
        }

        /// <summary>
        /// The X coordinate of the joystick for a given Beam user since the last call to DoWork().
        /// </summary>
        /// <param name="beamID">The ID of the Beam user who used the input control.</param>
        public double GetX(uint beamID)
        {
            return BeamManager.SingletonInstance.GetJoystickX(ControlID, beamID);
        }

        /// <summary>
        /// The Y coordinate of the joystick for a given Beam user since the last call to DoWork().
        /// </summary>
        /// <param name="beamID">The ID of the Beam user who used the input control.</param>
        public double GetY(uint beamID)
        {
            return BeamManager.SingletonInstance.GetJoystickY(ControlID, beamID);
        }

        public BeamJoystickControl(string controlID, bool enabled, string helpText, string eTag, string sceneID) : base(controlID, enabled, helpText, eTag, sceneID)
        {
        }

        internal uint BeamID;

        private bool TryGetJoystickStateByParticipant(uint beamID, string controlID, out InternalJoystickState joystickState)
        {
            joystickState = new InternalJoystickState();
            bool joystickExists = false;
            bool participantExists = false;
            Dictionary<string, InternalJoystickState> participantControls;
            participantExists = BeamManager._joystickStatesByParticipant.TryGetValue(beamID, out participantControls);
            if (participantExists)
            {
                bool controlExists = false;
                controlExists = participantControls.TryGetValue(controlID, out joystickState);
                if (controlExists)
                {
                    joystickExists = true;
                }
            }
            return joystickExists;
        }
    }
}
