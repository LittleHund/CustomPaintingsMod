using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using UnityEngine;
using System.Reflection;

namespace CustomPaintings
{
    public class CP_GifManager
    {
        private readonly CP_Logger logger;
        private string exePath;
        public CP_GifManager(CP_Logger logger)
        {
            this.logger = logger;
            logger.LogInfo("CP_GifManager initialized.");
        }

        public void ConvertGifToMp4(string gifPath, string outputPath)
        {
            
            string exePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ffmpeg.exe");

            if (!File.Exists(gifPath))
            {
                logger.LogError($"GIF file not found: {gifPath}");
                return;
            }
            
            if (!File.Exists(exePath))
            {
                logger.LogError($"FFmpeg executable not found at: {exePath}");
                return;
            }
            
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = $"-y -i \"{gifPath}\" -c:v libx264 -crf 18 -movflags faststart -pix_fmt yuv420p \"{outputPath}\" -vsync 0",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            
            process.Start();
            string output = process.StandardError.ReadToEnd();
            process.WaitForExit();
            
            logger.LogToFileOnly("INFO", $"FFmpeg Output: {output}");
            
            if (!File.Exists(outputPath))
            {
                logger.LogError($"FFmpeg failed to create MP4 file: {outputPath}");
                return;
            }


            string originalDirectory = Path.GetDirectoryName(gifPath);
            string parentDirectory = Directory.GetParent(originalDirectory).FullName;
            string unusedDir = Path.Combine(parentDirectory, "unused_converted_gifs");

            if (!Directory.Exists(unusedDir))
                Directory.CreateDirectory(unusedDir);

            string fileName = Path.GetFileName(gifPath);
            string targetPath = Path.Combine(unusedDir, fileName);

            int i = 1;
            while (File.Exists(targetPath))
            {
                string newFileName = $"{Path.GetFileNameWithoutExtension(gifPath)}_{i}{Path.GetExtension(gifPath)}";
                targetPath = Path.Combine(unusedDir, newFileName);
                i++;
            }

            File.Move(gifPath, targetPath);
            logger.LogInfo($"Moved original GIF to: {targetPath}");
            
        }
    }
}
