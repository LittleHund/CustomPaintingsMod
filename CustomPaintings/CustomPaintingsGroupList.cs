using System;
using System.Collections.Generic;
using System.Text;


namespace CustomPaintings
{
    public class CustomPaintingsGroupList
    {
        private readonly Logger logger;

        public CustomPaintingsGroupList(Logger logger)
        {
            this.logger = logger;
        }



        //add groups to dictionary
        public static readonly Dictionary<string, List<string>> MaterialNameToGroup = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
        // Landscape group
        { "Painting_H_Landscape", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "Painting_H_crow", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "Painting_H_crow_0", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "PaintingMedium", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "Painting_Danish_Flag", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "Painting_Board", new List<string> {"Landscape", "Normal", "Chaos" } },
        { "Shop Outside Billboard Ad", new List<string> {"Landscape", "Normal", "Chaos" } },

        // Square group
        { "Painting_S_Creep", new List<string> {"Square", "Normal", "Chaos" } },
        { "Painting_S_Creep 2_0", new List<string> {"Square", "Normal", "Chaos" } },
        { "Painting_S_Creep 2", new List<string> {"Square", "Normal", "Chaos" } },
        { "Painting Wizard Class", new List<string> {"Square", "Normal", "Chaos" } },
        { "Picture Frame - Picture 01", new List<string> {"Square", "Normal", "Chaos" } },
        { "Painting_Aurora", new List<string> {"Square", "Normal", "Chaos" } },
        { "Painting_McJannek", new List<string> {"Square", "Normal", "Chaos" } },

        // Portrait group
        { "Painting_V_jannk", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Painting_V_Furman", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Painting_V_surrealistic", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Painting_V_surrealistic_0", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "painting teacher01", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "painting teacher02", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "painting teacher03", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "painting teacher04", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Painting_S_Tree", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Painting Calendar", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Magazine01", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Magazine02", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Magazine03", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Magazine04", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Magazine05", new List<string> {"Portrait", "Normal", "Chaos" } },
        { "Valuable_Painting", new List<string> {"Portrait", "Normal", "Chaos" } },

        // Chaos group
        { "regular material 01", new List<string> {"Chaos", "Square" } },
        { "Arctic Sign Accounting",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Bathroom",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Botanical Research",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Brige 4B",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Brige 8N",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Cafeteria",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Cargo processing",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Catwalk L5",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Cooling Center",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Epsilon Station",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Exotic Materials Division",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Infirmary",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Kitchen",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Living Quarters",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Loading Dock",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Maintenance2",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Observation Platform",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Recreation",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Research Lab",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Storage Yard",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Testing Lab",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Vehicle Maintenance",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Ventilation Chamber",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign Warehouse",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Sign",new List<string> {"Chaos", "Landscape" } },
        { "Lobby Sign - Closed Road",new List<string> {"Chaos", "Square" } },
        { "Lobby Sign - No stopping",new List<string> {"Chaos", "Square" } },
        { "Robot Company Sign 2",new List<string> {"Chaos", "Square" } },
        { "Robot Company Sign 3",new List<string> {"Chaos", "Landscape" } },
        { "Robot Company Sign 4",new List<string> {"Chaos", "Portrait" } },
        { "Robot Company Sign 5",new List<string> {"Chaos", "Landscape" } },
        { "Robot Company Sign 6",new List<string> {"Chaos", "Portrait" } },
        { "Robot Company Sign 7",new List<string> {"Chaos", "Square" } },
        { "Robot Company Sign",new List<string> {"Chaos", "Square" } },
        { "Wizard Sign Cauldron Storage",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Common Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Courtyard",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Dark Arts",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Deathpit Corridor",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Dining Hall",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Dormatory",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Dungeon",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign East Wing Lobby",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Enchanted Lava Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Gnome Alley",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Headmasters Study",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Lecture Hall",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Magic Plant School",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Potions And Spells",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Relaxation Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Sludge Pits of Joy",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Sludge Pits",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Sorcery Class",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Storage Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign The Great Library",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign Thinking Chamber",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Sign West Wing Garden",new List<string> {"Chaos", "Landscape" } },
        { "Rug",new List<string> {"Chaos", "Square" } },
        { "shop rug",new List<string> {"Chaos", "Square" } },
        { "Bathroom Rug",new List<string> {"Chaos", "Square" } },
        { "Wizard Wall Flag",new List<string> {"Chaos", "Portrait" } },
        { "upgrade_throw",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_strength",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_speed",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_health",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_grab range",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_energy",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_tumble_launch",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_map_player_count",new List<string> {"Chaos", "Landscape" } },
        { "upgrade_extra_jump",new List<string> {"Chaos", "Landscape" } },
        { "Welcome_Flag_Front",new List<string> {"Chaos", "Landscape" } },
        { "Welcome_Flag_Back",new List<string> {"Chaos", "Landscape" } },
        { "Wizard Door Double",new List<string> {"Chaos", "Portrait" } },
        { "Wizard Door Double Blocked",new List<string> {"Chaos", "Portrait" } },
        { "Wizard Door Double Blocked Lock",new List<string> {"Chaos", "Portrait" } },
        { "Door Wizard",new List<string> {"Chaos", "Portrait" } },
        { "Shop Door",new List<string> {"Chaos", "Portrait" } },
        { "Door Shop WC",new List<string> {"Chaos", "Portrait" } },
        { "Garage Door",new List<string> {"Chaos", "Landscape" } },
        { "Arctic Door",new List<string> {"Chaos", "Portrait" } },
        { "Arctic Door Blocked",new List<string> {"Chaos", "Portrait" } },
        { "Museum Door",new List<string> {"Chaos", "Portrait" } },
        { "door base",new List<string> {"Chaos", "Portrait" } }

        };
    }
}
