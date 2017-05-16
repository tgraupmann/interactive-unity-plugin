using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Represents a Beam Interactivity scene. These scenes are configured using
    /// the Beam front end designer.
    /// </summary>
    public class BeamScene
    {
        /// <summary>
        /// Unique string identifier for this scene
        /// </summary>
        public string SceneID
        {
            get;
            internal set;
        }

        /// <summary>
        /// Retrieve a List of all of the buttons in the scene. May be empty.
        /// </summary>
        public IList<BeamButtonControl> Buttons
        {
            get
            {
                List<BeamButtonControl> buttonsInScene = new List<BeamButtonControl>();
                List<BeamButtonControl> allButtons = BeamManager.SingletonInstance.Buttons as List<BeamButtonControl>;
                foreach (BeamButtonControl button in allButtons)
                {
                    if (button.SceneID == SceneID)
                    {
                        buttonsInScene.Add(button);
                    }
                }
                return buttonsInScene;
            }
        }

        /// <summary>
        /// Retrieve a List of all of the joysticks in the scene. May be empty.
        /// </summary>
        public IList<BeamJoystickControl> Joysticks
        {
            get
            {
                List<BeamJoystickControl> joysticksInScene = new List<BeamJoystickControl>();
                List<BeamJoystickControl> allJoysticks = BeamManager.SingletonInstance.Buttons as List<BeamJoystickControl>;
                foreach (BeamJoystickControl joystick in allJoysticks)
                {
                    if (joystick.SceneID == SceneID)
                    {
                        joysticksInScene.Add(joystick);
                    }
                }
                return joysticksInScene;
            }
        }

        /// <summary>
        /// Retrieve a list of IDs of all of the groups assigned to the scene. May be empty.
        /// </summary>
        public IList<BeamGroup> Groups
        {
            get
            {
                List<BeamGroup> groupsAssignedToScene = new List<BeamGroup>();
                List<BeamGroup> allGroups = BeamManager.SingletonInstance.Groups as List<BeamGroup>;
                foreach (BeamGroup group in allGroups)
                {
                    if (group.SceneID == SceneID)
                    {
                        groupsAssignedToScene.Add(group);
                    }
                }
                return groupsAssignedToScene;
            }
        }

        /// <summary>
        /// Retrieves a reference to the specified button, if it exists.
        /// </summary>
        public BeamButtonControl GetButton(string controlID)
        {
            return BeamManager.SingletonInstance.GetButton(controlID);
        }

        /// <summary>
        /// Retrieve a vector of all of the joysticks in the scene. May be empty.
        /// </summary>
        public BeamJoystickControl GetJoystick(string controlID)
        {
            return BeamManager.SingletonInstance.GetJoystick(controlID);
        }

        internal string etag;

        internal BeamScene(string sceneID = "", string newEtag = "")
        {
            SceneID = sceneID;
            etag = newEtag;
        }
    }
}
