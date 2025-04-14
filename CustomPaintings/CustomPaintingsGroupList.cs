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
        { "regular_material_01", new List<string> {"Chaos" } },
        { "Robot_company_sign", new List<string> {"Chaos" } },
        { "Robot_company_sign2", new List<string> {"Chaos" } },
        { "Robot_company_sign3_1", new List<string> {"Chaos" } },
        { "Robot_company_sign4", new List<string> {"Chaos" } },
        { "robot_company_sign5", new List<string> {"Chaos" } },
        { "robot_company_sign6", new List<string> {"Chaos" } },
        { "robot_company_sign7", new List<string> {"Chaos" } },
        { "Rug", new List<string> {"Chaos" } },
        { "Sign_Closed_Road_Albedo", new List<string> {"Chaos" } },
        { "Sign_No_stopping_Albedo", new List<string> {"Chaos" } },
        { "arctic_sign_accounting", new List<string> {"Chaos" } },
        { "arctic_sign_bathroom", new List<string> {"Chaos" } },
        { "arctic_sign_botanical_research", new List<string> {"Chaos" } },
        { "arctic_sign_brige_4b", new List<string> {"Chaos" } },
        { "arctic_sign_brige_8n", new List<string> {"Chaos" } },
        { "arctic_sign_cafeteria", new List<string> {"Chaos" } },
        { "arctic_sign_cargo_processing", new List<string> {"Chaos" } },
        { "arctic_sign_catwalk", new List<string> {"Chaos" }  },
        { "arctic_sign_cooling_center", new List<string> {"Chaos" }  },
        { "arctic_sign_epsilon_station", new List<string> {"Chaos" }  },
        { "arctic_sign_exotic_materials_division", new List<string> {"Chaos" }  },
        { "arctic_sign_infirmary", new List<string> {"Chaos" }  },
        { "arctic_sign_kitchen", new List<string> {"Chaos" }  },
        { "arctic_sign_living_quarters", new List<string> {"Chaos" }  },
        { "arctic_sign_loading_dock", new List<string> {"Chaos" }  },
        { "arctic_sign_maintenance2", new List<string> {"Chaos" }  },
        { "arctic_sign_observation_platform", new List<string> {"Chaos" }  },
        { "arctic_sign_recreation", new List<string> {"Chaos" }  },
        { "arctic_sign_research_lab", new List<string> {"Chaos" }  },
        { "Arctic_Sign_Specimen", new List<string> {"Chaos" }  },
        { "arctic_sign_staging_area", new List<string> {"Chaos" }  },
        { "arctic_sign_testing_lab", new List<string> {"Chaos" }  },
        { "arctic_sign_vehicle_maintenance", new List<string> {"Chaos" }  },
        { "arctic_sign_ventilation_chamber", new List<string> {"Chaos" }  },
        { "arctic_sign_warehouse2", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Cauldron_Storage", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Common_Room", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Courtyard", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Dark_Arts", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Deathpit_Corridor", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Dining_Hall", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Dormatory", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Dungeon", new List<string> {"Chaos" }  },
        { "Wizard_Sign_East_Wing_Lobby", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Enchanted_Lava_Room", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Gnome_Alley", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Headmasters_Study", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Lecture_Hall", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Magic_Plant_School", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Potions_And_Spells", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Relaxation_Room", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Sludge_Pits_of_Joy", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Sludge_Pits", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Sorcery_Class", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Storage_Room", new List<string> {"Chaos" }  },
        { "Wizard_Sign_The_Great_Library", new List<string> {"Chaos" }  },
        { "Wizard_Sign_Thinking_Chamber", new List<string> {"Chaos" }  },
        { "Wizard_Sign_West_Wing_Garden", new List<string> {"Chaos" }  }
        };
    }
}
