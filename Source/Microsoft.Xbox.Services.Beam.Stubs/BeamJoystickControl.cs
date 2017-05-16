namespace Xbox.Services.Beam
{
    public class BeamJoystickControl : BeamControl
    {
        public double X
        {
            get
            {
                return 0;
            }
        }

        public double Y
        {
            get
            {
                return 0;
            }
        }

        public double Intensity
        {
            get;
            private set;
        }

        public double GetX(uint beamID)
        {
            return 0;
        }

        public double GetY(uint beamID)
        {
            return 0;
        }

        public BeamJoystickControl(string controlID, bool disabled, string helpText, string eTag, string sceneID) : base(controlID, disabled, helpText, eTag, sceneID)
        {
        }
    }
}
