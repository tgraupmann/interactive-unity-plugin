using System;
using System.Collections.Generic;

namespace Xbox.Services.Beam
{
    /// <summary>
    /// Represents a Beam Interactivity group. Groups can be used to segment
    /// the spectating audience, with each group having a scene displayed.
    /// Each group can have an arbitrary number of participants assigned.
    /// Each group can have exactly one scene assigned. A given scene can be
    /// assigned to any number of groups. A participant can be in at most
    /// one group. There will always be a default group, if no groups are
    /// specified.
    /// </summary>
    public class BeamGroup
    {
        /// <summary>
        /// Unique string identifier for this group.
        /// </summary>
        public string GroupID
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns a shared pointer to the scene assigned to this group.
        /// </summary>
        public List<BeamParticipant> Participants
        {
            get
            {
                List<BeamParticipant> participantsInGroup = new List<BeamParticipant>();
                List<BeamParticipant> allParticipants = BeamManager.SingletonInstance.Participants as List<BeamParticipant>;
                foreach (BeamParticipant participant in allParticipants)
                {
                    if (participant.groupID == GroupID)
                    {
                        participantsInGroup.Add(participant);
                    }
                }
                return participantsInGroup;
            }
        }

        /// <summary>
        /// Returns a shared pointer to the scene assigned to this group.
        /// </summary>
        public string SceneID
        {
            get;
            private set;
        }

        /// <summary>
        /// Sets the scene assigned for this group.
        /// </summary>
        public void SetScene(string sceneID)
        {
            SceneID = sceneID;
            BeamManager.SingletonInstance.SetCurrentSceneInternal(this, sceneID);
        }

        internal string etag;

        /// <summary>
        /// Function to construct a BeamGroup object.
        /// </summary>
        public BeamGroup(string groupID)
        {
            if (BeamManager.SingletonInstance.InteractivityState != BeamInteractivityState.InteractivityEnabled &&
                BeamManager.SingletonInstance.InteractivityState != BeamInteractivityState.Initialized)
            {
                throw new Exception("Error: The BeamManager must be initialized and connected to the service to create new groups.");
            }

            GroupID = groupID;
            BeamManager.SingletonInstance.SendCreateGroupsMessage(GroupID, BeamManager.WS_MESSAGE_VALUE_DEFAULT_SCENE_ID);
        }

        /// <summary>
        /// Function to construct a BeamGroup object.
        /// </summary>
        public BeamGroup(string groupID, string sceneID)
        {
            if (BeamManager.SingletonInstance.InteractivityState != BeamInteractivityState.InteractivityEnabled &&
                BeamManager.SingletonInstance.InteractivityState != BeamInteractivityState.Initialized)
            {
                throw new Exception("Error: The BeamManager must be initialized and connected to the service to create new groups.");
            }

            GroupID = groupID;
            SceneID = sceneID;
            BeamManager.SingletonInstance.SendCreateGroupsMessage(GroupID, SceneID);
        }

        internal BeamGroup(string newEtag, string sceneID, string groupID)
        {
            etag = newEtag;
            SceneID = sceneID;
            GroupID = groupID;
        }
    }
}
