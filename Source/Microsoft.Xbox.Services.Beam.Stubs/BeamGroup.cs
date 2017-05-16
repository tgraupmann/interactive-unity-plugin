using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    public class BeamGroup
    {
        public string GroupID
        {
            get;
            private set;
        }

        public List<BeamParticipant> Participants
        {
            get
            {
                return new List<BeamParticipant>();
            }
        }

        public string SceneID
        {
            get;
            private set;
        }

        public void SetScene(string sceneID)
        {
        }

        public BeamGroup(string groupID)
        {
        }

        public BeamGroup(string groupID, string sceneID)
        {
        }
    }
}
