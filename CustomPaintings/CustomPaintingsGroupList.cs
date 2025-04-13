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
        public static readonly Dictionary<string, string> MaterialNameToGroup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
        // Landscape group
        { "Painting_H_Landscape", "Landscape" },
        { "Painting_H_crow", "Landscape" },
        { "Painting_H_crow_0", "Landscape" },
        { "PaintingMedium", "Landscape" },
        { "Painting_Danish_Flag", "Landscape" },
        { "Painting_Board", "Landscape" },
        { "Shop_Outside_Billboard_Ad", "Landscape" },

        // Square group
        { "Painting_S_Creep", "Square" },
        { "Painting_S_Creep 2_0", "Square" },
        { "Painting_S_Creep 2", "Square" },
        { "Painting Wizard Class", "Square" },
        { "Picture_Frame_-_Picture_01", "Square"},

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
        { "Painting_Calendar", "Portrait" },
        { "Magazine01", "Portrait" },
        { "Magazine02", "Portrait" },
        { "Magazine03", "Portrait" },
        { "Magazine04", "Portrait" },
        { "Magazine05", "Portrait" },
        { "Valuable_Painting", "Portrait" },

        // Chaos group
        { "regular_material_01", "Chaos" },
        { "Robot_company_sign", "Chaos" },
        { "Robot_company_sign2", "Chaos" },
        { "Robot_company_sign3_1", "Chaos" },
        { "Robot_company_sign4", "Chaos" },
        { "robot_company_sign5", "Chaos" },
        { "robot_company_sign6", "Chaos" },
        { "robot_company_sign7", "Chaos" },
        { "Rug", "Chaos" },
        { "Sign_Closed_Road_Albedo", "Chaos" },
        { "Sign_No_stopping_Albedo", "Chaos" },
        { "arctic_sign_accounting", "Chaos"},
        { "arctic_sign_bathroom", "Chaos"},
        { "arctic_sign_botanical_research", "Chaos"},
        { "arctic_sign_brige_4b", "Chaos"},
        { "arctic_sign_brige_8n", "Chaos"},
        { "arctic_sign_cafeteria", "Chaos"},
        { "arctic_sign_cargo_processing", "Chaos"},
        { "arctic_sign_catwalk", "Chaos"},
        { "arctic_sign_cooling_center", "Chaos"},
        { "arctic_sign_epsilon_station", "Chaos"},
        { "arctic_sign_exotic_materials_division", "Chaos"},
        { "arctic_sign_infirmary", "Chaos"},
        { "arctic_sign_kitchen", "Chaos"},
        { "arctic_sign_living_quarters", "Chaos"},
        { "arctic_sign_loading_dock", "Chaos"},
        { "arctic_sign_maintenance2", "Chaos"},
        { "arctic_sign_observation_platform", "Chaos"},
        { "arctic_sign_recreation", "Chaos"},
        { "arctic_sign_research_lab", "Chaos"},
        { "Arctic_Sign_Specimen", "Chaos"},
        { "arctic_sign_staging_area", "Chaos"},
        { "arctic_sign_testing_lab", "Chaos"},
        { "arctic_sign_vehicle_maintenance", "Chaos"},
        { "arctic_sign_ventilation_chamber", "Chaos"},
        { "arctic_sign_warehouse2", "Chaos"},
        { "Wizard_Sign_Cauldron_Storage", "Chaos"},
        { "Wizard_Sign_Common_Room", "Chaos"},
        { "Wizard_Sign_Courtyard", "Chaos"},
        { "Wizard_Sign_Dark_Arts", "Chaos"},
        { "Wizard_Sign_Deathpit_Corridor", "Chaos"},
        { "Wizard_Sign_Dining_Hall", "Chaos"},
        { "Wizard_Sign_Dormatory", "Chaos"},
        { "Wizard_Sign_Dungeon", "Chaos"},
        { "Wizard_Sign_East_Wing_Lobby", "Chaos"},
        { "Wizard_Sign_Enchanted_Lava_Room", "Chaos"},
        { "Wizard_Sign_Gnome_Alley", "Chaos"},
        { "Wizard_Sign_Headmasters_Study", "Chaos"},
        { "Wizard_Sign_Lecture_Hall", "Chaos"},
        { "Wizard_Sign_Magic_Plant_School", "Chaos"},
        { "Wizard_Sign_Potions_And_Spells", "Chaos"},
        { "Wizard_Sign_Relaxation_Room", "Chaos"},
        { "Wizard_Sign_Sludge_Pits_of_Joy", "Chaos"},
        { "Wizard_Sign_Sludge_Pits", "Chaos"},
        { "Wizard_Sign_Sorcery_Class", "Chaos"},
        { "Wizard_Sign_Storage_Room", "Chaos"},
        { "Wizard_Sign_The_Great_Library", "Chaos"},
        { "Wizard_Sign_Thinking_Chamber", "Chaos"},
        { "Wizard_Sign_West_Wing_Garden", "Chaos"}
        };
    }
}
