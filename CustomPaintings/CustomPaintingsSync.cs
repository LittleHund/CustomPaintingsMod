using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using CustomPaintings;
using static CustomPaintings.CustomPaintingsSwap;

namespace CustomPaintings
{
    public class CustomPaintingsSync : MonoBehaviourPunCallbacks, IOnEventCallback
    {

        private readonly Logger logger;

        // assign a specific code to different events
        public const byte SeedEventCode = 1;
        public const byte HostSettingsCode = 2;


        public CustomPaintingsSync(Logger logger)
        {
            this.logger = logger;
        }

        public void SendSeed(int seed)
        {
            // Create an event data object that will carry the seed information
            object[] content = new object[] { seed };

            logger.LogInfo("sharing seed with other clients");

            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All, // Send to everyone, including yourself
                CachingOption = EventCaching.AddToRoomCache // cache data for late joiners
            };

            // Raise the event to all clients (using the custom event code)
            PhotonNetwork.RaiseEvent(SeedEventCode, content, options, SendOptions.SendReliable);

        }

        public void SendHostSettings(string HostSeperateState, bool HostRBState, bool Chaosstate)
        {


            // Create an event data object that will carry the seperation state information
            object[] content = new object[] { HostSeperateState, HostRBState, Chaosstate };

            logger.LogInfo("sharing seperation setting");

            RaiseEventOptions options = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.All, // Send to everyone, including yourself
                CachingOption = EventCaching.AddToRoomCache // cache data for late joiners
            };

            // Raise the event to all clients (using the custom event code)
            PhotonNetwork.RaiseEvent(HostSettingsCode, content, options, SendOptions.SendReliable);

        }



        public void OnEvent(EventData photonEvent)
        {
            //retrieve seed data from event
            if (photonEvent.Code == SeedEventCode)
            {
                object[] data = (object[])photonEvent.CustomData;
                int seed = (int)data[0];

                logger.LogInfo($"Received seed: {seed}");
                ReceivedSeed = seed;
            }

            //retrieve seperation state data from event
            if (photonEvent.Code == HostSettingsCode)
            {
                object[] data = (object[])photonEvent.CustomData;
                string HostSeperateState = (string)data[0];
                bool HostRBState = (bool)data[1];
                bool Chaosstate = (bool)data[2];

                logger.LogInfo($"Received seperate state: {HostSeperateState}");
                logger.LogInfo($"Received Rug and Banner state: {HostRBState}");
                logger.LogInfo($"Received chaos state: {Chaosstate}");
                SeperateState = HostSeperateState;
                RBState = HostRBState;
                ChaosState = Chaosstate;
            }

        }
    }
}