using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using JetBrains.Annotations;
using UnityEngine;

namespace CustomPaintings
{
    public class CustomPaintingsLoader
    {
        private const string IMAGE_FOLDER_NAME = "CustomPaintings";
        private readonly Logger logger;

        public Dictionary<string, List<Material>> MaterialGroups = new Dictionary<string, List<Material>>();

        // Loaded materials list
        public List<Material> LoadedMaterials { get; } = new List<Material>();

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
                    Material material = new Material(Shader.Find("Standard"))
                    {
                        mainTexture = texture
                    };
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
                    if (!MaterialGroups.ContainsKey("Square"))
                    {
                        MaterialGroups["Square"] = new List<Material>(); // Create if not exists
                    }

                    Material material = new Material(Shader.Find("Standard"));
                    material.mainTexture = texture;
                    MaterialGroups["Square"].Add(material);  // Add material to Square group

                }
                else if (aspectRatio > 1.3f)
                {
                    if (!MaterialGroups.ContainsKey("Landscape"))
                    {
                        MaterialGroups["Landscape"] = new List<Material>(); // Create if not exists
                    }

                    Material material = new Material(Shader.Find("Standard"));
                    material.mainTexture = texture;
                    MaterialGroups["Landscape"].Add(material);  // Add material to Landscape group
 
                }
                else if (aspectRatio < 0.769f)
                {
                    if (!MaterialGroups.ContainsKey("Portrait"))
                    {
                        MaterialGroups["Portrait"] = new List<Material>(); // Create if not exists
                    }

                    Material material = new Material(Shader.Find("Standard"));
                    material.mainTexture = texture;
                    MaterialGroups["Portrait"].Add(material);  // Add material to Portrait group
                    
                }



                
                return texture;
            }
            return null;
        }
    }
}