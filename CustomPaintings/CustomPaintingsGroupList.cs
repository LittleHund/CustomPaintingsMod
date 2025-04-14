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
        { "Painting_H_Landscape", new List<string> {"Landscape", "Normal" } },
        { "Painting_H_crow", new List<string> {"Landscape", "Normal" } },
        { "Painting_H_crow_0", new List<string> {"Landscape", "Normal" } },
        { "PaintingMedium", new List<string> {"Landscape", "Normal" } },
        { "Painting_Danish_Flag", new List<string> {"Landscape", "Normal" } },
        { "Painting_Board", new List<string> {"Landscape", "Normal" } },
        { "Shop_Outside_Billboard_Ad", new List<string> {"Landscape", "Normal" } },

        // Square group
        { "Painting_S_Creep", new List<string> {"Square", "Normal" } },
        { "Painting_S_Creep 2_0", new List<string> {"Square", "Normal" } },
        { "Painting_S_Creep 2", new List<string> {"Square", "Normal" } },
        { "Painting Wizard Class", new List<string> {"Square", "Normal" } },
        { "Picture_Frame_-_Picture_01", new List<string> {"Square", "Normal" } },

        // Portrait group
        { "Painting_V_jannk", new List<string> {"Portrait", "Normal" } },
        { "Painting_V_Furman", new List<string> {"Portrait", "Normal" } },
        { "Painting_V_surrealistic", new List<string> {"Portrait", "Normal" } },
        { "Painting_V_surrealistic_0", new List<string> {"Portrait", "Normal" } },
        { "painting teacher01", new List<string> {"Portrait", "Normal" } },
        { "painting teacher02", new List<string> {"Portrait", "Normal" } },
        { "painting teacher03", new List<string> {"Portrait", "Normal" } },
        { "painting teacher04", new List<string> {"Portrait", "Normal" } },
        { "Painting_S_Tree", new List<string> {"Portrait", "Normal" } },
        { "Painting_Calendar", new List<string> {"Portrait", "Normal" } },
        { "Magazine01", new List<string> {"Portrait", "Normal" } },
        { "Magazine02", new List<string> {"Portrait", "Normal" } },
        { "Magazine03", new List<string> {"Portrait", "Normal" } },
        { "Magazine04", new List<string> {"Portrait", "Normal" } },
        { "Magazine05", new List<string> {"Portrait", "Normal" } },
        { "Valuable_Painting", new List<string> {"Portrait", "Normal" } },

        // Chaos group
        { "regular_material_01", new List<string> {"Chaos", "Square" } },
        { "Arctic_Sign_Accounting",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Bathroom",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Botanical_Research",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Brige_4B",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Brige_8N",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Cafeteria",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Cargo_processing",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Catwalk_L5",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Cooling_Center",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Epsilon_Station",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Exotic_Materials_Division",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Infirmary",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Kitchen",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Living_Quarters",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Loading_Dock",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Maintenance2",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Observation_Platform",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Recreation",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Research_Lab",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Storage_Yard",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Testing_Lab",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Vehicle_Maintenance",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Ventilation_Chamber",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign_Warehouse",new List<string> {"Chaos", "Landscape" } },
        { "Arctic_Sign",new List<string> {"Chaos", "Landscape" } },
        { "Lobby_Sign_-_Closed_Road",new List<string> {"Chaos", "Square" } },
        { "Lobby_Sign_-_No_stopping",new List<string> {"Chaos", "Square" } },
        { "Robot_Company_Sign_2",new List<string> {"Chaos", "Square" } },
        { "Robot_Company_Sign_3",new List<string> {"Chaos", "Landscape" } },
        { "Robot_Company_Sign_4",new List<string> {"Chaos", "Portrait" } },
        { "Robot_Company_Sign_5",new List<string> {"Chaos", "Landscape" } },
        { "Robot_Company_Sign_6",new List<string> {"Chaos", "Portrait" } },
        { "Robot_Company_Sign_7",new List<string> {"Chaos", "Square" } },
        { "Robot_Company_Sign",new List<string> {"Chaos", "Square" } },
        { "Wizard_Sign_Cauldron_Storage",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Common_Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Courtyard",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Dark_Arts",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Deathpit_Corridor",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Dining_Hall",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Dormatory",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Dungeon",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_East_Wing_Lobby",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Enchanted_Lava_Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Gnome_Alley",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Headmasters_Study",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Lecture_Hall",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Magic_Plant_School",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Potions_And_Spells",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Relaxation_Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Sludge_Pits_of_Joy",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Sludge_Pits",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Sorcery_Class",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Storage_Room",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_The_Great_Library",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_Thinking_Chamber",new List<string> {"Chaos", "Landscape" } },
        { "Wizard_Sign_West_Wing_Garden",new List<string> {"Chaos", "Landscape" } }

        };
    }
}
