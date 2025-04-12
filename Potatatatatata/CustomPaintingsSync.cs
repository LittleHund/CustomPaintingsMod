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
        public const byte SeedEventCode = 1;



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
                CachingOption = EventCaching.AddToRoomCache
            };

            // Raise the event to all clients (using the custom event code)
            PhotonNetwork.RaiseEvent(SeedEventCode, content, options, SendOptions.SendReliable);

        }


        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code == SeedEventCode)
            {
                object[] data = (object[])photonEvent.CustomData;
                int seed = (int)data[0];

                logger.LogInfo($"Received seed: {seed}");
                ReceivedSeed = seed;
            }
        }
    }
}