using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace CustomPaintings;

public class CustomPaintingsConfig
{
    public static ConfigEntry<bool> HostControl;
    public static ConfigEntry<bool> SeperateImages;

    internal static class Grunge
    {

        internal static ConfigEntry<bool>  State;
        internal static ConfigEntry<float> Intensity;

        internal static ConfigEntry<Color> _BaseColor;
        internal static ConfigEntry<Color> _MainColor;
        internal static ConfigEntry<Color> _CracksColor;
        internal static ConfigEntry<Color> _OutlineColor;
    }

    internal static void Init(ConfigFile config)
    {
        // add button and sliders for different settings
        HostControl = config.Bind<bool>("Image Settings", "Host Control", true, new ConfigDescription("choose if host controls seperate state"));
        SeperateImages = config.Bind<bool>("Image Settings", "Seperate paintings", false, new ConfigDescription("seperate square, landscape and portrait images on swap"));

        Grunge.State = config.Bind
        (
            "Grunge",
            "State",
            true,
            new ConfigDescription("Whether the grunge effect is enabled")
        );

        Grunge.Intensity = config.Bind
        (
            "Grunge",
            "Grunge intensity",
            0.50f,
            new ConfigDescription("change how intense the grunge is applied", new AcceptableValueRange<float>(0.01f, 2.00f), Array.Empty<object>()));

        // Advanced config options
        Grunge._BaseColor = config.Bind
        (
            "Grunge",
            "_GrungeBaseColor",
            new Color(0, 0, 0, 1),
            new ConfigDescription("The base color of the grunge")
        );

        Grunge._MainColor = config.Bind
        (
            "Grunge",
            "_GrungeMainColor",
            new Color(0, 0, 0, 0.5f),
            new ConfigDescription("The color of the main overlay of grunge")
        );

        Grunge._CracksColor = config.Bind
        (
            "Grunge",
            "_GrungeCracksColor",
            new Color(0.25f, 0.25f, 0.25f, 1),
            new ConfigDescription("The color of the cracks in the grunge")
        );

        Grunge._OutlineColor = config.Bind
        (
            "Grunge",
            "_GrungeOutlineColor",
            new Color(0, 0, 0, 1),
            new ConfigDescription("The color of the grunge outlining the painting")
        );
    }
}
