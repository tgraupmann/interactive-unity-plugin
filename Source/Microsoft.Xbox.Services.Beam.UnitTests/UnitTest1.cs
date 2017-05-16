//using System;
//using Xbox.Services.Beam;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Microsoft.Xbox.Services.Beam.UnitTests
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void SingletonInstance()
//        {
//            var beamManager = BeamManager.SingletonInstance;
//            Assert.IsNotNull(beamManager);
//            Assert.IsTrue(beamManager.InteractivityState == BeamInteractivityState.NotInitialized);
//        }

//        [TestMethod]
//        public void Initialize()
//        {
//            var beamManager = BeamManager.SingletonInstance;
//            beamManager.Initialize();
//            Assert.IsTrue(beamManager.InteractivityState == BeamInteractivityState.InteractivePending);
//        }

//        //"Initialize", function(assert)
//        //"onParticipantJoin", function(assert)
//        //"onParticipantLeave", function(assert)
//        //"onGiveInputButton", function(assert)
//        //"onGiveInputJoystick", function(assert)
//        //"GivenButtonDownVerifyButtonStateIsCorrect", function(assert)
//        //"GivenButtonPressedVerifyButtonStateIsCorrect", function(assert)
//        //"GivenButtonUpVerifyButtonStateIsCorrect", function(assert)
//        //"GetButtonStateWhenButtonDoesNotExist", function(assert)
//        //"GetButtonStateByParticipantForButtonDown", function(assert)
//        //"GetButtonStateByParticipantForButtonPressed", function(assert)
//        //"GetButtonStateByParticipantForButtonUp", function(assert)
//        //"GetButtonStateByParticipantWhenButtonDoesNotExist", function(assert)
//        //"GetJoystickState", function(assert)
//        //"GetJoystickStateByParticipant", function(assert)
//        //"GetJoystickStateWhenJoystickDoesNotExist", function(assert)
//        //"GetJoystickStateWhenJoystickDoesNotExist", function(assert)
//        //"GetJoystickStateWhenJoystickDoesNotExist", function(assert)
//        //"GetControls", function(assert)
//        //"SetChannelID", function(assert)
//        //"SetChannelIDBeforeInitialized", function(assert)
//        //"StopInteractive", function(assert)
//        //"InitializeWithoutGoingInteractiveThenCallStartInteractive", function(assert)
//        //"CallInitializeTwice", function(assert)
//        //"CallStartInteractiveTwice", function(assert)
//        //"CallStartInteractiveTwice", function(assert)
//        //"CallStartAndStopInteractiveManyTimesInSequence", function(assert)
//        //"CallDoWork", function(assert)
//        //CallDoWorkTwiceInARow", function(assert)

//        // Mock messages
//        private const string participantObject =
//            "{" +
//            "    \"sessionID\": \"b2f65dea-429f-4105-a280-745fd5d75945\"," +
//            "    \"etag\": \"54600913\"," +
//            "    \"userID\": 146," +
//            "    \"username\": \"connor\"," +
//            "    \"level\": 67," +
//            "    \"lastInputAt\": 1484763854277," +
//            "    \"connectedAt\": 1484763846242," +
//            "    \"disabled\": false," +
//            "    \"groupID\": \"default\"," +
//            "    \"meta\": {" +
//            "        \"is_awesome\": {" +
//            "            \"etag\": 37849560," +
//            "            \"value\": \"true\"" +
//            "        }" +
//            "    }" +
//            "}";
//        private const string onParticipantLeaveObject =
//            "{" +
//            "    type: \"method\"," +
//            "    id: \"123\"," +
//            "    method: \"onParticipantLeave\"," +
//            "    params: {" +
//            "        participants: [" +
//            "            " + participantObject + " " +
//            "        ]" +
//            "    }," +
//            "    discard: \"true\"" +
//            "}";

//        private const string onParticipantJoinObject =
//            "{" +
//            "    type: \"method\"," +
//            "    id: \"123\"," +
//            "    method: \"onParticipantJoin\"," +
//            "    params: {" +
//            "        participants: [" +
//            "           " + participantObject + " " +
//            "        " +
//            "    }," +
//            "    discard: \"true\"" +
//            "}";
//        private const string inputObjectMousedown =
//            "{" +
//            "    \"controlID\": \"btn\"," +
//            "    \"event\": \"mousedown\"," +
//            "    \"button\": 0" +
//            "}";
//        private const string inputObjectMouseup =
//            "{" +
//            "    \"controlID\": \"btn\"," +
//            "    \"event\": \"mouseup\"," +
//            "    \"button\": 0" +
//            "}";
//        private const string inputObjectMove =
//            "{" +
//            "    \"controlID\": \"joystick\"," +
//            "    \"event\": \"move\"," +
//            "    \"x\": 0.64," +
//            "    \"y\": -0.1" +
//            "}";
//        private const string giveInputMousedownObject =
//            "{" +
//            "    type: \"method\"," +
//            "    id: \"123\"," +
//            "    method: \"giveInput\"," +
//            "    params: {" +
//            "        participantID: \"b2f65dea-429f-4105-a280-745fd5d75945\"," +
//            "        input: " + inputObjectMousedown + " " +
//            "    }," +
//            "    discard: \"true\"" +
//            "}";
//        private const string giveInputMouseupObject =
//            "{" +
//            "    type: \"method\"," +
//            "    id: \"123\"," +
//            "    method: \"giveInput\"," +
//            "    params: {" +
//            "        participantID: \"b2f65dea-429f-4105-a280-745fd5d75945\"," +
//            "        input: " + inputObjectMouseup + "" +
//            "    }," +
//            "    discard: \"true\"" +
//            "}";
//        private const string giveInputMoveObject =
//            "{" +
//            "    type: \"method\"," +
//            "    id: \"123\"," +
//            "    method: \"giveInput\"," +
//            "    params: {" +
//            "        participantID: \"b2f65dea-429f-4105-a280-745fd5d75945\"," +
//            "        input: " + inputObjectMove + "" +
//            "    }," +
//            "    discard: \"true\"" +
//            "}";
//        private const string getScenesObject =
//            "{" +
//            "    type: \"reply\"," +
//            "    id: \"123\"," +
//            "    result: {" +
//            "        scenes: [{" +
//            "                sceneID: \"red_team_scene\"," +
//            "                groups: [\"group1\", \"group2\"]," +
//            "                controls: [{" +
//            "                        controlID: \"win_the_game_btn\"," +
//            "             }]}," +
//            "        ]}," +
//            "    discard: \"true\"" +
//            "}";
//    }
//}

