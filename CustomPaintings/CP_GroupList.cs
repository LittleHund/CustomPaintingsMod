using System;
using System.Collections.Generic;
using System.Text;


namespace CustomPaintings
{
    public class CP_GroupList
    {
        private readonly CP_Logger logger;

        public CP_GroupList(CP_Logger logger)
        {
            this.logger = logger;
        }



        //add groups to dictionary
        public static readonly Dictionary<string, List<string>> MaterialNameToGroup = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
        // Landscape group
        { "Painting_H_Landscape"                        ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_H_crow"                             ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_H_crow_0"                           ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "PaintingMedium"                              ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_Danish_Flag"                        ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_Board"                              ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting Danish Flag"                        ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting Board"                              ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Shop Outside Billboard Ad"                   ,   new List<string>    {"Landscape"    , "Normal"  , "RugsAndBanners"  , "Chaos" } },
	
        // Square group	
        { "Painting_S_Creep"                            ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_S_Creep 2_0"                        ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_S_Creep 2"                          ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting Wizard Class"                       ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Picture Frame - Picture 01"                  ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_Aurora"                             ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_McJannek"                           ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting Aurora"                             ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting McJannek"                           ,   new List<string>    {"Square"       , "Normal"  , "RugsAndBanners"  , "Chaos" } },
	
        // Portrait group	
        { "Painting_V_jannk"                            ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_V_Furman"                           ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_V_surrealistic"                     ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_V_surrealistic_0"                   ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "painting teacher01"                          ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "painting teacher02"                          ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "painting teacher03"                          ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "painting teacher04"                          ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting_S_Tree"                             ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Painting Calendar"                           ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Magazine01"                                  ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Magazine02"                                  ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Magazine03"                                  ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Magazine04"                                  ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Magazine05"                                  ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
        { "Valuable_Painting"                           ,   new List<string>    {"Portrait"     , "Normal"  , "RugsAndBanners"  , "Chaos" } },
	
        // RugsAndBanners group	
        { "Rug"                                         ,   new List<string>    {"Square"       , "RugsAndBanners"  , "Chaos" } },
        { "shop rug"                                    ,   new List<string>    {"Square"       , "RugsAndBanners"  , "Chaos" } },
        { "Bathroom Rug"                                ,   new List<string>    {"Square"       , "RugsAndBanners"  , "Chaos" } },
        { "Rug Plain Red"                               ,   new List<string>    {"Landscape"    , "RugsAndBanners"  , "Chaos" } },
        { "Wizard Wall Flag"                            ,   new List<string>    {"Portrait"     , "RugsAndBanners"  , "Chaos" } },
        { "Rug Optimized"                               ,   new List<string>    {"Portrait"     , "RugsAndBanners"  , "Chaos" } },
	
        // Chaos group	
        { "regular material 01"                         ,   new List<string>    {"Square"       , "Chaos" } },
        { "Arctic Sign Accounting"                      ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Bathroom"                        ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Botanical Research"              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Brige 4B"                        ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Brige 8N"                        ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Cafeteria"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Cargo processing"                ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Catwalk L5"                      ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Cooling Center"                  ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Epsilon Station"                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Exotic Materials Division"       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Infirmary"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Kitchen"                         ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Living Quarters"                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Loading Dock"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Maintenance2"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Observation Platform"            ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Recreation"                      ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Research Lab"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Storage Yard"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Testing Lab"                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Vehicle Maintenance"             ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Ventilation Chamber"             ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign Warehouse"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Sign"                                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Lobby Sign - Closed Road"                    ,   new List<string>    {"Square"       , "Chaos" } },
        { "Lobby Sign - No stopping"                    ,   new List<string>    {"Square"       , "Chaos" } },
        { "Robot Company Sign 2"                        ,   new List<string>    {"Square"       , "Chaos" } },
        { "Robot Company Sign 3"                        ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Robot Company Sign 4"                        ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Robot Company Sign 5"                        ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Robot Company Sign 6"                        ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Robot Company Sign 7"                        ,   new List<string>    {"Square"       , "Chaos" } },
        { "Robot Company Sign"                          ,   new List<string>    {"Square"       , "Chaos" } },
        { "Wizard Sign Cauldron Storage"                ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Common Room"                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Courtyard"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Dark Arts"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Deathpit Corridor"               ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Dining Hall"                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Dormatory"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Dungeon"                         ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign East Wing Lobby"                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Enchanted Lava Room"             ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Gnome Alley"                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Headmasters Study"               ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Lecture Hall"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Magic Plant School"              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Potions And Spells"              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Relaxation Room"                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Sludge Pits of Joy"              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Sludge Pits"                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Sorcery Class"                   ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Storage Room"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign The Great Library"               ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign Thinking Chamber"                ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Sign West Wing Garden"                ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_throw"                               ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_strength"                            ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_speed"                               ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_health"                              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_grab range"                          ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_energy"                              ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_tumble_launch"                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_map_player_count"                    ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "upgrade_extra_jump"                          ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Welcome_Flag_Front"                          ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Welcome_Flag_Back"                           ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Wizard Door Double"                          ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Wizard Door Double Blocked"                  ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Wizard Door Double Blocked Lock"             ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Door Wizard"                                 ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Shop Door"                                   ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Door Shop WC"                                ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Garage Door"                                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Arctic Door"                                 ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Arctic Door Blocked"                         ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Museum Door"                                 ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "door base"                                   ,   new List<string>    {"Portrait"     , "Chaos" } },
        { "Kitchen Fridge"                              ,   new List<string>    {"Square"       , "Chaos" } },
        { "Inflatable Hammer"                           ,   new List<string>    {"Square"       , "Chaos" } },
        { "Moon"                                        ,   new List<string>    {"Square"       , "Chaos" } },
        { "Soda Machine"                                ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Soda Shelf Sodas"                            ,   new List<string>    {"Square"       , "Chaos" } },
        //truck items chaos group
        { "Truck Item Shelf"                            ,   new List<string>    {"Square"       , "Chaos" } },
        { "Map - Truck Wall"                            ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Map - Truck Floor"                           ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck Interior Front"                        ,   new List<string>    {"Square"       , "Chaos" } },
        { "Truck Interior Back"                         ,   new List<string>    {"Square"       , "Chaos" } },
        { "Truck Door"                                  ,   new List<string>    {"Square"       , "Chaos" } },
        { "Truck"                                       ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck_0"                                     ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck Glass Not Transparent"                 ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck Glass Not Transparent Demolished"      ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck Demolished"                            ,   new List<string>    {"Landscape"    , "Chaos" } },
        { "Truck Depot"                                 ,   new List<string>    {"Square"       , "Chaos" } },
        { "Truck Healer"                                ,   new List<string>    {"Square"       , "Chaos" } },
        //valuable items chaos group
        { "Valuable Arctic Guitar"                      ,   new List<string>    {"Landscape"    , "Chaos" } }        
        };
    }
}
