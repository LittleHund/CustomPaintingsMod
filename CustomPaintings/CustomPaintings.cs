using UnityEngine;
using BepInEx;
using HarmonyLib;
using static CustomPaintings.CP_Swapper;
using Photon.Pun;
using System.Threading.Tasks;
using BepInEx.Configuration;
using System;




namespace CustomPaintings
{
    [BepInPlugin("UnderratedJunk.CustomPaintings", "CustomPaintings", "1.1.11")]
    public class CustomPaintings : BaseUnityPlugin
    {
        // create instances for the different class files
        private static CP_Logger logger;
        private static CP_Loader loader;
        private static CP_Swapper swapper;
        private static CP_Synchroniser sync;
        private static CP_GroupList grouper;
        private static CP_Config configfile;
        private static CP_GifManager GifManager;

        public static int? receivedSeed = null;
        public static int? oldreceivedSeed = null;
        public static readonly int maxWaitTimeMs = 1000; // Max wait time for seed
        

        private readonly Harmony harmony = new Harmony("UnderratedJunk.CustomPaintings");

        // This will be the entry point when the mod is loaded
        private void Awake()
        {

            // Initialize Logger first
            logger = new CP_Logger("CustomPaintings");
            logger.LogInfo("CustomPaintings mod initialized.");

            // Initialize GifManager
            GifManager = new CP_GifManager(logger);

            // Initialize configurable settings
            CP_Config.Init(Config);

            // Initialize Loader second
            loader = new CP_Loader(logger, GifManager);
            loader.LoadImagesFromAllPlugins();

            // Initialize grouper , pass logger as dependency
            configfile = new CP_Config();

            // Initialize grouper , pass logger as dependency
            grouper = new CP_GroupList(logger);

            // Initialize Swapper last, pass loader as dependency
            swapper = new CP_Swapper(logger, loader, grouper);

            // Initialize syncer
            sync = new CP_Synchroniser(logger);

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
        [HarmonyPatch(typeof(PlayerAvatar), "LoadingLevelAnimationCompletedRPC")]
        public class PaintingSwapPatch
        {
            
            private static void Postfix()
            {                
                Task.Run(async () =>
                {
                    if (swapper.GetModState() == CP_Swapper.ModState.Client || swapper.GetModState() == CP_Swapper.ModState.Host)
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
                    }
                    

                    swapper.ReplacePaintings();
                });




            }   
            
            private static void Prefix()
            {

                if (swapper.GetModState() == CP_Swapper.ModState.Client)
                {

                    PhotonNetwork.AddCallbackTarget(sync); // Subscribe to Photon events

                }



                if (swapper.GetModState() == CP_Swapper.ModState.Host)
                {

                    HostSeed = UnityEngine.Random.Range(0, int.MaxValue);
                    logger.LogInfo($"Generated Hostseed: {HostSeed}");
                    PhotonNetwork.AddCallbackTarget(sync); // Subscribe to Photon events

                    sync.SendSeed(HostSeed);

                    if (CP_Config.SeperateImages.Value == true)
                    {
                        sync.SendHostSettings("on", CP_Config.RugsAndBanners.Value, CP_Config.ChaosMode.Value);
                    }

                    else if (CP_Config.SeperateImages.Value == false)
                    {
                        sync.SendHostSettings("off", CP_Config.RugsAndBanners.Value, CP_Config.ChaosMode.Value);
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

                if (swapper.GetModState() != CP_Swapper.ModState.Host)
                {
                    swapper.SetState(CP_Swapper.ModState.Client);

                }
            }
        }

        // HostLobby Patch change to host state
        [HarmonyPatch(typeof(SteamManager), "HostLobby")]
        public class HostLobbyPatch
        {
            private static bool Prefix()
            {
                swapper.SetState(CP_Swapper.ModState.Host);

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

                swapper.SetState(CP_Swapper.ModState.SinglePlayer);
                SeperateState = "Singleplayer";
            }
        }
    }
}