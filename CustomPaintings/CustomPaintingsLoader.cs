using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using JetBrains.Annotations;
using UnityEngine;
using static CustomPaintings.CustomPaintingsConfig;

namespace CustomPaintings
{
    public class CustomPaintingsLoader
    {
        //assign dedicated folder name
        private const string IMAGE_FOLDER_NAME = "CustomPaintings";

        private readonly Logger logger;

        //create a dictionary for the different image groups
        public Dictionary<string, List<Material>> MaterialGroups = new Dictionary<string, List<Material>>();

        // Loaded materials list
        public List<Material> LoadedMaterials { get; } = new List<Material>();

        // Grunge materials (Seperate materials to avoid stretching
        private const string GRUNGE_ASSET_BUNDLE           = "GrungeAssets";
        private const string MATERIAL_LANDSCAPE_ASSET_NAME = "GrungeHorizontalMaterial";
        private const string MATERIAL_PORTRAIT_ASSET_NAME  = "GrungeVerticalMaterial";
        static Material _LandscapeMaterial;
        static Material _PortraitMaterial;

        // Constructor to initialize the logger
        public CustomPaintingsLoader(Logger logger)
        {
            this.logger = logger;
        }

        // Load images from all plugins
        public void LoadImagesFromAllPlugins()
        {
            string pluginsPath = Path.Combine(Paths.PluginPath);
            if (!Directory.Exists(pluginsPath))
            {
                logger.LogWarning($"Plugins directory not found: {pluginsPath}");
                return;
            }

            string[] directories = Directory.GetDirectories(pluginsPath, IMAGE_FOLDER_NAME, SearchOption.AllDirectories);

            LoadGrungeMaterials();
            BindGrungeConfigUpdates();

            if (directories.Length == 0)
            {
                logger.LogWarning("No 'CustomPaintings' folders found in plugins.");
                return;
            }

            foreach (string directoryPath in directories)
            {
                logger.LogInfo($"Loading images from: {directoryPath}");
                LoadImagesFromDirectory(directoryPath);
            }
        }

        // Load images from a specific directory
        private void LoadImagesFromDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                logger.LogWarning($"Directory does not exist: {directoryPath}");
                return;
            }

            string[] validExtensions = { ".png", ".jpg", ".jpeg", ".bmp" };

            var files = Directory
                .EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Where(file => validExtensions.Contains(Path.GetExtension(file).ToLower()))
                .ToArray();
            if (files.Length == 0)
            {
                logger.LogWarning($"No images found in {directoryPath}");
                return;
            }

            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                Texture2D texture = LoadTextureFromFile(filePath);
                if (texture != null)
                {
                    Material material = AddGrungeMaterial(_LandscapeMaterial, texture);
                    LoadedMaterials.Add(material);
                    logger.LogInfo($"Loaded image #{i + 1}: {Path.GetFileName(filePath)}");
                }
                else
                {
                    logger.LogWarning($"Failed to load image #{i + 1}: {filePath}");
                }

            }

            logger.LogInfo($"Total images loaded: {LoadedMaterials.Count}");
        }

        Material AddGrungeMaterial(Material grungeMaterial, Texture2D texture)
        {
            if (grungeMaterial == null)
            {
                logger.LogWarning($"Falling back to default shader");
                return new Material(Shader.Find("Standard"));
            }

            Material material = new Material(grungeMaterial)
            {
                mainTexture = texture
            };
            return material;
        }

        // Helper method for adding grunge Material
        void AddGrungeMaterial(string paintingType, Material grungeMaterial, Texture2D texture)
        {
            if (!MaterialGroups.ContainsKey(paintingType))
            {
                MaterialGroups[paintingType] = new List<Material>(); // Create if not exists
            }

            Material material = AddGrungeMaterial(grungeMaterial, texture);
            MaterialGroups[paintingType].Add(material);  // Add material to Square group
        }

        // Helper method to load texture from file
        private Texture2D LoadTextureFromFile(string filePath)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            var texture = new Texture2D(2, 2);
            if (ImageConversion.LoadImage(texture, fileData))
            {
                texture.Apply();

                float aspectRatio = (float)texture.width / texture.height;
                if (aspectRatio >= 0.769f && aspectRatio <= 1.3f)
                {
                    AddGrungeMaterial("Square", _LandscapeMaterial, texture);
                }
                else if (aspectRatio > 1.3f)
                {
                    AddGrungeMaterial("Landscape", _LandscapeMaterial, texture);
                }
                else if (aspectRatio < 0.769f)
                {
                    AddGrungeMaterial("Portrait", _PortraitMaterial, texture);
                }



                
                return texture;
            }
            return null;
        }

        // Load the grunge materials from the asset bundle
        private void LoadGrungeMaterials()
        {
            string location      = Assembly.GetExecutingAssembly().Location;
            string directoryName = Path.GetDirectoryName(location);
            string assetName     = GRUNGE_ASSET_BUNDLE;
            string assetLocation = Path.Combine(directoryName, assetName);
            logger.LogInfo($"Loading [{assetLocation}]");
            bool assetBundleExists = File.Exists(assetLocation);
            if (assetBundleExists)
            {
                logger.LogInfo($"Grunge Asset Bundle exists");
            }
            else
            {
                logger.LogWarning($"Grunge Asset Bundle doesn't exist");

            }

            AssetBundle assetBundle = AssetBundle.LoadFromFile(assetLocation);

            if (assetBundle == null)
            {
                logger.LogError($"Failed to load [{assetName}]");
            }
            else
            {
                _LandscapeMaterial = assetBundle.LoadAsset<Material>(MATERIAL_LANDSCAPE_ASSET_NAME);
                if (_LandscapeMaterial == null)
                {
                    logger.LogError($"Could not load landscape painting material [{MATERIAL_LANDSCAPE_ASSET_NAME}]!");
                }
                _PortraitMaterial = assetBundle.LoadAsset<Material>(MATERIAL_PORTRAIT_ASSET_NAME);
                if (_PortraitMaterial == null)
                {
                    logger.LogError($"Could not load portrait painting material [{MATERIAL_PORTRAIT_ASSET_NAME}]!");
                }
            }

            if (_LandscapeMaterial != null & _PortraitMaterial != null)
            {
                logger.LogInfo($"Grunge materials successfully loaded!");
            }
        }

        internal void BindGrungeConfigUpdates()
        {
            CustomPaintingsConfig.Grunge.State.SettingChanged         += OnGrungeConfigOptionChanged;
            CustomPaintingsConfig.Grunge.Intensity.SettingChanged     += OnGrungeConfigOptionChanged;
            CustomPaintingsConfig.Grunge._BaseColor.SettingChanged    += OnGrungeConfigOptionChanged;

            CustomPaintingsConfig.Grunge._BaseColor.SettingChanged    += OnGrungeConfigOptionChanged;
            CustomPaintingsConfig.Grunge._MainColor.SettingChanged    += OnGrungeConfigOptionChanged;
            CustomPaintingsConfig.Grunge._CracksColor.SettingChanged  += OnGrungeConfigOptionChanged;
            CustomPaintingsConfig.Grunge._OutlineColor.SettingChanged += OnGrungeConfigOptionChanged;
        }

        private void OnGrungeConfigOptionChanged(object sender, EventArgs e)
        {
            UpdateGrungeMaterialParameters();
        }

        // Get config values for the material
        internal void UpdateGrungeMaterialParameters()
        {
            logger.LogDebug($"Updating Grunge Material Parameters");

            foreach (var materialGroup in MaterialGroups)
            {
                var paintingType = materialGroup.Key;
                var materials = materialGroup.Value;

                foreach (var material in materials)
                {
                    if (material == null)
                    {
                        logger.LogWarning($"No material found for [{paintingType}]!");
                        continue;
                    }

                    // Is the grunge effect enabled?
                    if (CustomPaintingsConfig.Grunge.State.Value) 
                    {
                        float grungeIntensity = CustomPaintingsConfig.Grunge.Intensity.Value;
                        Color grungeColor = new Color(1, 1, 1, grungeIntensity);
                        material.SetColor(CustomPaintingsConfig.Grunge._BaseColor.Definition.Key   , CustomPaintingsConfig.Grunge._BaseColor.Value);
                        material.SetColor(CustomPaintingsConfig.Grunge._MainColor.Definition.Key   , CustomPaintingsConfig.Grunge._MainColor.Value    * grungeColor);
                        material.SetColor(CustomPaintingsConfig.Grunge._CracksColor.Definition.Key , CustomPaintingsConfig.Grunge._CracksColor.Value  * grungeColor);
                        material.SetColor(CustomPaintingsConfig.Grunge._OutlineColor.Definition.Key, CustomPaintingsConfig.Grunge._OutlineColor.Value * grungeColor);
                    }
                    else
                    {
                        material.SetColor(CustomPaintingsConfig.Grunge._BaseColor.Definition.Key   , Color.clear);
                        material.SetColor(CustomPaintingsConfig.Grunge._MainColor.Definition.Key   , Color.clear);
                        material.SetColor(CustomPaintingsConfig.Grunge._CracksColor.Definition.Key , Color.clear);
                        material.SetColor(CustomPaintingsConfig.Grunge._OutlineColor.Definition.Key, Color.clear);
                    }
                }
            }
        }
    }
}