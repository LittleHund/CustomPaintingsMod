using UnityEngine;
using BepInEx;
using HarmonyLib;
using static CustomPaintings.CustomPaintingsSwap;
using Photon.Pun;
using System.Threading.Tasks;
using BepInEx.Configuration;
using System;




namespace CustomPaintings
{
    [BepInPlugin("UnderratedJunk.CustomPaintings", "CustomPaintings", "1.0.7")]
    public class CustomPaintings : BaseUnityPlugin
    {
        private static Logger logger;  // Logger instance
        private static CustomPaintingsLoader loader;  // Loader instance
        private static CustomPaintingsSwap swapper;  // Swapper instance
        private static CustomPaintingsSync sync;  // Syncer instance

        public static int? receivedSeed = null;
        public static readonly int maxWaitTimeMs = 1000; // Max wait time for seed

        public static ConfigEntry<bool> SeperateImages;


        private readonly Harmony harmony = new Harmony("UnderratedJunk.CustomPaintings");

        // This will be the entry point when the mod is loaded
        private void Awake()
        {

            // Initialize Logger first
            logger = new Logger("CustomPaintings");
            logger.LogInfo("CustomPaintings mod initialized.");

            // Initialize Loader second
            loader = new CustomPaintingsLoader(logger);
            loader.LoadImagesFromAllPlugins();

            // Initialize Swapper last, pass loader as dependency
            swapper = new CustomPaintingsSwap(logger, loader);

            // Initialize syncer
            sync = new CustomPaintingsSync(logger);

            SeperateImages = ((BaseUnityPlugin)this).Config.Bind<bool>("Image Settings", "Seperate paintings", false, new ConfigDescription("seperate square, landscape and portrait images on swap"));


            harmony.PatchAll();
        }



        // Patch method for replacing the paintings
        [HarmonyPatch(typeof(LoadingUI), "LevelAnimationComplete")]
        public class PaintingSwapPatch
        {

            private static void Postfix()
            {
                Task.Run(async () =>
                {
                    int waited = 0;
                    int interval = 50;

                    while (!receivedSeed.HasValue && waited < maxWaitTimeMs)
                    {
                        await Task.Delay(interval);
                        waited += interval;
                    }

                    if (receivedSeed.HasValue)
                    {
                        logger.LogInfo($"[Postfix] Client using received seed: {receivedSeed.Value}");
                        ReceivedSeed = receivedSeed.Value;
                        receivedSeed = null;
                    }
                    else
                    {
                        logger.LogWarning("[Postfix] Client did not receive seed in time. Proceeding without it.");
                    }

                    swapper.ReplacePaintings();
                });




            }
            
            private static void Prefix()
            {

                if (swapper.GetModState() == CustomPaintingsSwap.ModState.Client)
                {

                    PhotonNetwork.AddCallbackTarget(sync); // Subscribe to Photon events

                }



                if (swapper.GetModState() == CustomPaintingsSwap.ModState.Host)
                {

                    HostSeed = UnityEngine.Random.Range(0, int.MaxValue);
                    logger.LogInfo($"Generated Hostseed: {HostSeed}");
                    PhotonNetwork.AddCallbackTarget(sync); // Subscribe to Photon events

                    sync.SendSeed(HostSeed);


                }                
            }           
        }

        // JoinLobby Patch change to client state
        [HarmonyPatch(typeof(NetworkConnect), "TryJoiningRoom")]
        public class JoinLobbyPatch
        {
            private static void Prefix()
            {

                if (swapper.GetModState() != CustomPaintingsSwap.ModState.Host)
                {
                    swapper.SetState(CustomPaintingsSwap.ModState.Client);

                }
            }
        }

        // HostLobby Patch change to host state
        [HarmonyPatch(typeof(SteamManager), "HostLobby")]
        public class HostLobbyPatch
        {
            private static bool Prefix()
            {
                swapper.SetState(CustomPaintingsSwap.ModState.Host);

                return true; // Continue execution of the original method

            }
        }



        // change state to singleplayer when leaving multiplayer lobby
        [HarmonyPatch(typeof(SteamManager), "LeaveLobby")]
        public class LeaveLobbyPatch
        {
            private static void Postfix()
            {
                PhotonNetwork.RemoveCallbackTarget(sync); // Unsubscribe to Photon events

                swapper.SetState(CustomPaintingsSwap.ModState.SinglePlayer);

            }
        }
    }
}