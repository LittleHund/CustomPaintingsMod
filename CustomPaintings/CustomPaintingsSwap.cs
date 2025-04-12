using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine.Device;
using System;

namespace CustomPaintings
{
    public class CustomPaintingsSwap
    {
        // Enum for mod states: host, client, and singleplayer
        public enum ModState
        {
            Host,        // Host state (no action for now)
            Client,      // Client state (no action for now)
            SinglePlayer // Singleplayer state (default behavior)
        }

        private readonly Logger logger;
        private readonly CustomPaintingsLoader loader;

        private static int randomSeed = 0;      // Seed for random image selection in singleplayer
        public static int HostSeed = 0;         // Seed for random image selection as host
        public static int ReceivedSeed = 0;     // Seed for random image selection received from host
        public static int Seed = 0;

        private int paintingsChangedCount = 0;  // Counter for how many paintings were changed

        private static ModState currentState = ModState.SinglePlayer; // Default to Singleplayer

        private static readonly Dictionary<string, string> MaterialNameToGroup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
        // Landscape group
        { "Painting_H_Landscape", "Landscape" },
        { "Painting_H_crow", "Landscape" },
        { "Painting_H_crow_0", "Landscape" },
        { "PaintingMedium", "Landscape" },
        { "Painting_Danish_Flag", "Landscape" },
        { "Painting_Board", "Landscape" },

        // Square group
        { "Painting_S_Creep", "Square" },
        { "Painting_S_Creep 2_0", "Square" },
        { "Painting_S_Creep 2", "Square" },
        { "Painting Wizard Class", "Square" },

        // Portrait group
        { "Painting_V_jannk", "Portrait" },
        { "Painting_V_Furman", "Portrait" },
        { "Painting_V_surrealistic", "Portrait" },
        { "Painting_V_surrealistic_0", "Portrait" },
        { "painting teacher01", "Portrait" },
        { "painting teacher02", "Portrait" },
        { "painting teacher03", "Portrait" },
        { "painting teacher04", "Portrait" },
        { "Painting_S_Tree", "Portrait" },
        { "Painting_Calendar", "Portrait" }
        };

        public ModState GetModState()
        {
            return currentState;
        }

        // Constructor to initialize the logger and loader
        public CustomPaintingsSwap(Logger logger, CustomPaintingsLoader loader)
        {
            this.logger = logger;
            this.loader = loader; // Initialize loader instance

            // Log the current state on initialization
            logger.LogInfo($"Initial ModState: {currentState}");

            // Log seed generation for the first scene load (if the seed was not generated in the first call)
            if (randomSeed == 0)
            {
                randomSeed = UnityEngine.Random.Range(0, int.MaxValue);
                logger.LogInfo($"Generated initial random seed: {randomSeed}");
            }
        }



        // Perform the painting swap operation
        public void ReplacePaintings()
        {
            if (currentState == ModState.SinglePlayer)
            {
                //use singleplayer seed
                Seed = randomSeed;
            }


            if (currentState == ModState.Host)
            {
                //use host seed
                Seed = HostSeed;
            }


            if (currentState == ModState.Client)
            {
                //use client seed
                Seed = ReceivedSeed;
            }


            Scene scene = SceneManager.GetActiveScene();

            logger.LogInfo($"Applying seed {Seed} for painting swaps in scene: {scene.name}");

            logger.LogInfo("Replacing all paintings with custom images...");

            paintingsChangedCount = 0;  // Reset the paintings changed counter for this scene

            int materialsChecked = 0;  // Count materials checked in the scene

            if (CustomPaintings.SeperateImages.Value == false)
            {
                foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>())
                    {
                        Material[] materials = renderer.sharedMaterials;

                        for (int i = 0; i < materials.Length; i++)
                        {



                            materialsChecked++;  // Increment checked materials count

                            if (materials[i] != null && materials[i].name.ToLower().Contains("painting"))
                            {

                                // Exclude specific materials (e.g., frames that we don't want to swap)
                                if (materials[i].name.Contains("Painting Frame Vertical Gold") || materials[i].name.Contains("Painting Frame Horizontal Gold"))
                                {

                                    continue; // Skip this material
                                }



                                if (loader.LoadedMaterials.Count > 0)
                                {

                                    // Use the seed to pick the image based on the index
                                    int index = Mathf.Abs((Seed + paintingsChangedCount) % loader.LoadedMaterials.Count);
                                    materials[i] = loader.LoadedMaterials[index];
                                    paintingsChangedCount++;  // Increment the count of paintings changed                               


                                }
                            }
                        }

                        renderer.sharedMaterials = materials;
                    }
                }
            }
            else if (CustomPaintings.SeperateImages.Value == true)
            {
                foreach (GameObject obj in SceneManager.GetActiveScene().GetRootGameObjects())
                {
                    foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>())
                    {
                        Material[] materials = renderer.sharedMaterials;

                        for (int i = 0; i < materials.Length; i++)
                        {



                            materialsChecked++;  // Increment checked materials count


                            if (materials[i] != null && materials[i].name.ToLower().Contains("painting"))
                            {

                                // Exclude specific materials (e.g., frames that we don't want to swap)
                                if (materials[i].name.Contains("Painting Frame Vertical Gold") || materials[i].name.Contains("Painting Frame Horizontal Gold"))
                                {

                                    continue; // Skip this material
                                }

                                string matName = materials[i].name.Trim();

                                if (MaterialNameToGroup.TryGetValue(matName, out string groupName))
                                {
                                    if (groupName == "Landscape")
                                    {
                                        int index = Mathf.Abs((Seed + paintingsChangedCount) % loader.MaterialGroups["Landscape"].Count);
                                        materials[i] = loader.MaterialGroups["Landscape"][index];
                                        paintingsChangedCount++;  // Increment the count of paintings changed 

                                    }
                                    else if (groupName == "Square")
                                    {
                                        int index = Mathf.Abs((Seed + paintingsChangedCount) % loader.MaterialGroups["Square"].Count);
                                        materials[i] = loader.MaterialGroups["Square"][index];
                                        paintingsChangedCount++;  // Increment the count of paintings changed 
                                    }
                                    else if (groupName == "Portrait")
                                    {
                                        int index = Mathf.Abs((Seed + paintingsChangedCount) % loader.MaterialGroups["Portrait"].Count);
                                        materials[i] = loader.MaterialGroups["Portrait"][index];
                                        paintingsChangedCount++;  // Increment the count of paintings changed 
                                    }
                                }
                            }

                            renderer.sharedMaterials = materials;
                        }
                    }
                }


                // Log the count of checked materials
                logger.LogInfo($"Total materials checked: {materialsChecked}");

                // Log how many paintings were changed in this scene
                logger.LogInfo($"Total paintings changed in this scene: {paintingsChangedCount}");


                logger.LogInfo($"RandomSeed = {randomSeed}");
                logger.LogInfo($"HostSeed = {HostSeed}");
                logger.LogInfo($"ReceivedSeed = {ReceivedSeed}");
            }
        }

        // Set the current mod state
        public void SetState(ModState newState)
        {
            currentState = newState;

            // Log the current state
            logger.LogInfo($"Mod state set to: {currentState}");

        }
    }
}