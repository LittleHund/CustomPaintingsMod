using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace CustomPaintings
{
    public class CP_Logger
    {
        private readonly string logFilePath;
        private readonly string modName;
        private readonly ManualLogSource logSource;

        // Constructor that initializes the log file path
        public CP_Logger(string modName)
        {
            this.modName = modName; // <-- Store the mod name

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

        // Log methods
        public void LogDebug(string message) => WriteLog("DEBUG", message);
        public void LogInfo(string message) => WriteLog("INFO", message);
        public void LogWarning(string message) => WriteLog("WARNING", message);
        public void LogError(string message) => WriteLog("ERROR", message);


        // Write log to the log file
        private void WriteLog(string level, string message)
        {
            string className = GetCallingClassName();
            string fullName = $"{modName}.{className}";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] [{fullName}] {message}";

            // Write to log file
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);

            // Use a consistent log source per class+mod combo
            ManualLogSource logSource = BepInEx.Logging.Logger.CreateLogSource(fullName);
            switch (level)
            {
                case "DEBUG": logSource.LogDebug(message); break;
                case "INFO": logSource.LogInfo(message); break;
                case "WARNING": logSource.LogWarning(message); break;
                case "ERROR": logSource.LogError(message); break;
            }
        }

        public void LogToFileOnly(string level, string message)
        {
            string className = GetCallingClassName();
            string fullName = $"{modName}.{className}";
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] [{fullName}] {message}";

            // Only write to your custom log file, not to BepInEx
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        // Get the name of the class that called the logger
        private string GetCallingClassName()
        {
            StackTrace stackTrace = new StackTrace();
            for (int i = 2; i < stackTrace.FrameCount; i++)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();
                var type = method.DeclaringType;

                if (type != typeof(CP_Logger) && type != null)
                    return type.Name;
            }
            return "UnknownClass";
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