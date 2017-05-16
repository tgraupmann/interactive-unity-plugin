namespace Xbox.Services.Beam
{
    /// Base class for Beam Interactivity controls. All controls are created and 
    /// configured using the Beam front end designer.
    /// </summary>
    public class BeamControl
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
        /// Indicates if control is enabled or disabled.
        /// </summary>
        public bool Disabled
        {
            get;
            private set;
        }

        /// <summary>
        /// The string of text that displays when a stream viewer (BeamParticipant) hovers over the control.
        /// </summary>
        public string HelpText
        {
            get;
            private set;
        }

        internal string ETag;
        internal string SceneID;

        /// <summary>
        /// Allow game client to disable a control.
        /// </summary>
        /// <param name="disabled">If "true", disables this control. If "false", enables this control</param>
        public void SetDisabled(bool disabled)
        {
            Disabled = disabled;
            BeamManager.SingletonInstance.SendSetControlEnabled(ControlID, disabled);
        }

        internal BeamControl(string controlID, bool disabled, string helpText, string eTag, string sceneID)
        {
            ControlID = controlID;
            Disabled = disabled;
            HelpText = helpText;
            ETag = eTag;
            SceneID = sceneID;
        }
    }
}
