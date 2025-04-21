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
    [BepInPlugin("UnderratedJunk.CustomPaintings", "CustomPaintings", "1.1.6")]
    public class CustomPaintings : BaseUnityPlugin
    {
        // create instances for the different class files
        private static Logger logger;
        private static CustomPaintingsLoader loader;
        private static CustomPaintingsSwap swapper;
        private static CustomPaintingsSync sync;
        private static CustomPaintingsGroupList grouper;
        private static CustomPaintingsConfig configfile;

        public static int? receivedSeed = null;
        public static int? oldreceivedSeed = null;
        public static readonly int maxWaitTimeMs = 1000; // Max wait time for seed
        

        private readonly Harmony harmony = new Harmony("UnderratedJunk.CustomPaintings");

        // This will be the entry point when the mod is loaded
        private void Awake()
        {

            // Initialize Logger first
            logger = new Logger("CustomPaintings");
            logger.LogInfo("CustomPaintings mod initialized.");

            // Initialize configurable settings
            CustomPaintingsConfig.Init(Config);

            // Initialize Loader second
            loader = new CustomPaintingsLoader(logger);
            loader.LoadImagesFromAllPlugins();

            // Initialize grouper , pass logger as dependency
            configfile = new CustomPaintingsConfig();

            // Initialize grouper , pass logger as dependency
            grouper = new CustomPaintingsGroupList(logger);

            // Initialize Swapper last, pass loader as dependency
            swapper = new CustomPaintingsSwap(logger, loader, grouper);

            // Initialize syncer
            sync = new CustomPaintingsSync(logger);

            harmony.PatchAll();
        }

        public void Update()
        {
            if (Input.GetKeyDown(configfile.ForceSwapKey))
            {
                swapper.ReplacePaintings();
            }
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

                    // wait to receive a code
                    while (!receivedSeed.HasValue && waited < maxWaitTimeMs)
                    {
                        await Task.Delay(interval);
                        waited += interval;
                    }

                    if (receivedSeed.HasValue)
                    {
                        logger.LogInfo($"[Postfix] Client using received seed: {receivedSeed.Value}");
                        oldreceivedSeed = ReceivedSeed;
                        ReceivedSeed = receivedSeed.Value;
                        receivedSeed = null; //reset receivedseed for while loop above to work correctly
                    }
                    else if (ReceivedSeed == oldreceivedSeed)
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

                    if (CustomPaintingsConfig.SeperateImages.Value == true)
                    {
                        sync.SendHostSettings("on", CustomPaintingsConfig.RugsAndBanners.Value, CustomPaintingsConfig.ChaosMode.Value);
                    }

                    else if (CustomPaintingsConfig.SeperateImages.Value == false)
                    {
                        sync.SendHostSettings("off", CustomPaintingsConfig.RugsAndBanners.Value, CustomPaintingsConfig.ChaosMode.Value);
                    }

                }

                // Update 
                loader.UpdateGrungeMaterialParameters();
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
                SeperateState = "Singleplayer";
            }
        }
    }
}