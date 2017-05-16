using System;
using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Class representing a user currently viewing a Beam Interactive stream.
    /// </summary>
    public class BeamParticipant
    {
        /// <summary>
        /// The user's Beam level.
        /// </summary>
        public uint BeamLevel
        {
            get;
            private set;
        }

        /// <summary>
        /// The the beam user id associated with this participant.
        /// </summary>
        public uint BeamID
        {
            get;
            private set;
        }

        /// <summary>
        /// The user's name on Beam.
        /// </summary>
        public string BeamUserName
        {
            get;
            private set;
        }

        /// <summary>
        /// UTC time at which this participant connected to this Beam stream.
        /// </summary>
        public DateTime ConnectedAt
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the group that this participant is assigned to. This
        /// also updates the participant list of the referenced group.
        /// </summary>
        public BeamGroup Group
        {
            get
            {
                List<BeamGroup> allGroups = BeamManager.SingletonInstance.Groups as List<BeamGroup>;
                foreach (BeamGroup group in allGroups)
                {
                    if (group.GroupID == groupID)
                    {
                        return group;
                    }
                }
                return new BeamGroup("default");
            }
            set
            {
                groupID = value.GroupID;
                BeamManager.SingletonInstance.SendUpdateParticipantsMessage(this);
            }
        }

        /// <summary>
        /// UTC time at which this participant last had interactive control input.
        /// </summary>
        public DateTime LastInputAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// Set to true if the user's input has been disabled.
        /// </summary>
        public bool InputDisabled
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns an array button objects this participant has interacted with.
        /// </summary>
        public IList<BeamButtonControl> Buttons
        {
            get
            {
                List<BeamButtonControl> buttonsForParticipant = new List<BeamButtonControl>();
                var buttonStatesByParticipantKeys = BeamManager._buttonStatesByParticipant[BeamID].Keys;
                foreach (string key in buttonStatesByParticipantKeys)
                {
                    var allButtons = BeamManager.SingletonInstance.Buttons;
                    foreach (BeamButtonControl button in allButtons)
                    {
                        if (key == button.ControlID)
                        {
                            buttonsForParticipant.Add(button);
                            break;
                        }
                    }
                }
                return buttonsForParticipant;
            }
        }

        /// <summary>
        /// Returns an array of control IDs of the joysticks this participant has interacted with.
        /// </summary>
        public IList<BeamJoystickControl> Joysticks
        {
            get
            {
                List<BeamJoystickControl> joysticksForParticipant = new List<BeamJoystickControl>();
                var buttonStatesByParticipantKeys = BeamManager._buttonStatesByParticipant[BeamID].Keys;
                foreach (string key in buttonStatesByParticipantKeys)
                {
                    var allJoysticks = BeamManager.SingletonInstance.Joysticks;
                    foreach (BeamJoystickControl joystick in allJoysticks)
                    {
                        if (key == joystick.ControlID)
                        {
                            joysticksForParticipant.Add(joystick);
                            break;
                        }
                    }
                }
                return joysticksForParticipant;
            }
        }

        /// <summary>
        /// The participant's current state.
        /// </summary>
        public BeamParticipantState State
        {
            get;
            internal set;
        }

        internal string etag;
        internal string groupID;
        internal string sessionID;

        internal BeamParticipant(string newSessionID, string newEtag, uint beamID, string newGroupID, string beamUserName, uint beamLevel, DateTime lastInputAt, DateTime connectedAt, bool inputDisabled, BeamParticipantState state)
        {
            sessionID = newSessionID;
            BeamID = beamID;
            BeamUserName = beamUserName;
            BeamLevel = beamLevel;
            LastInputAt = lastInputAt;
            ConnectedAt = connectedAt;
            InputDisabled = inputDisabled;
            State = state;
            groupID = newGroupID;
            etag = newEtag;
        }
    }
}
