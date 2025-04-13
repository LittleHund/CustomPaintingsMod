using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace CustomPaintings
{
    public class Logger
    {
        private readonly string logFilePath;
        private readonly ManualLogSource logSource;

        // Constructor that initializes the log file path
        public Logger(string modName)
        {
            // Set the log file to be created in the same directory as the DLL
            string dllDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            logFilePath = Path.Combine(dllDirectory, $"{modName}_log.txt");

            // Ensure the log file is overwritten each time the game starts
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modName);
        }

        // Log general information
        public void LogDebug(string message)
        {
            WriteLog("DEBUG", message);
            logSource.LogDebug(message);
        }

        // Log general information
        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
            logSource.LogInfo(message);
        }

        // Log warnings
        public void LogWarning(string message)
        {
            WriteLog("WARNING", message);
            logSource.LogWarning(message);
        }

        // Log errors
        public void LogError(string message)
        {
            WriteLog("ERROR", message);
            logSource.LogError(message);
        }

        // Write log to the log file
        private void WriteLog(string level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        // Log material name containing "painting"
        public void LogMaterial(Material material)
        {
            if (material != null && material.name.ToLower().Contains("painting"))
            {
                LogInfo($"Material containing 'painting': {material.name}");
            }
        }

        // Clear log file (optional method for cleanup or testing)
        public void ClearLog()
        {
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }
        }
    }
}