using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    public class BeamScene
    {
        public string SceneID
        {
            get;
            internal set;
        }

        public IList<BeamButtonControl> Buttons
        {
            get
            {
                return new List<BeamButtonControl>();
            }
        }

        public IList<BeamJoystickControl> Joysticks
        {
            get
            {
                return new List<BeamJoystickControl>();
            }
        }

        public IList<BeamGroup> Groups
        {
            get
            {
                return new List<BeamGroup>();
            }
        }

        public BeamButtonControl GetButton(string controlID)
        {
            return BeamManager.SingletonInstance.GetButton(controlID);
        }

        public BeamJoystickControl GetJoystick(string controlID)
        {
            return BeamManager.SingletonInstance.GetJoystick(controlID);
        }

        internal BeamScene(string sceneID = "")
        {
            SceneID = sceneID;
        }
    }
}
