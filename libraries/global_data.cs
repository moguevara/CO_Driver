using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    public class global_data
    {
        public static string CURRENT_VERSION = "0.1.0.70";

        public const int FILE_BUFFER_SIZE = 256;

        public const int MATCH_START_EVENT = 1;
        public const int LOAD_PLAYER_EVENT = 2;
        public const int DAMAGE_EVENT = 3;
        public const int KILL_EVENT = 4;
        public const int ASSIST_EVENT = 5;
        public const int SCORE_EVENT = 6;
        public const int MATCH_END_EVENT = 7;
        public const int MAIN_MENU_EVENT = 8;
        public const int TEST_DRIVE_EVENT = 9;
        public const int CW_ROUND_END_EVENT = 10;
        public const int STRIPE_EVENT = 11;
        public const int MATCH_PROPERTY_EVENT = 12;
        public const int MATCH_REWARD_EVENT = 13;
        public const int QUEST_EVENT = 14;
        public const int ADD_OR_UPDATE_PLAYER_EVENT = 15;
        public const int DATE_ASSIGNMENT_EVENT = 16;
        public const int ASSIGN_CLIENT_VERSION_EVENT = 17;
        public const int SPAWN_PLAYER_EVENT = 18;
        public const int ADD_MOB_EVENT = 19;
        public const int GAME_PLAY_START_EVENT = 20;
        public const int LOOT_EVENT = 21;
        public const int ADVENTURE_REWARD_EVENT = 22;
        public const int QUEUE_START_EVENT = 23;
        public const int QUEUE_END_EVENT = 24;
        public const int QUEUE_UPDATE_EVENT = 25;
        public const int CONNECTION_INIT_EVENT = 26;
        public const int GUID_ASSIGN_EVENT = 27;
        public const int HOST_NAME_ASSIGN_EVENT = 28;
        public const int GAME_PLAYER_SPAWN_EVENT = 29;
        public const int GAME_PLAYER_LOAD_EVENT = 30;
        public const int PLAYER_LEAVE_EVENT = 31;

        public const int STANDARD_CW = 1;
        public const int LEVIATHIAN_CW = 2;
        public const int STORM_WARNING = 3;
        public const int WHEEL_RACE = 4;
        public const int FREE_FOR_ALL = 5;
        public const int BIG_BLACK_SCORPION = 6;
        public const int BATTLE_ROYALE = 7;
        public const int STEEL_CHAMPIONSHIP = 8;
        public const int HOVER_RACE = 9;
        public const int HEAD_ON = 10;
        public const int CANNON_FODDER = 11;

        public const int UNDEFINED_MATCH = 0;
        public const int STANDARD_MATCH = 1;
        public const int STANDARD_CW_MATCH = 2;
        public const int LEVIATHIAN_CW_MATCH = 3;
        public const int BATTLE_ROYALE_MATCH = 4;
        public const int LEAGUE_6_v_6_MATCH = 5;
        public const int EASY_RAID_MATCH = 6;
        public const int MED_RAID_MATCH = 7;
        public const int HARD_RAID_MATCH = 8;
        public const int CUSTOM_MATCH = 9;
        public const int BEDLAM_MATCH = 10;
        public const int ADVENTURE_MATCH = 11;
        public const int PRESENT_HEIST_MATCH = 12;
        public const int PATROL_MATCH = 13;
        public const int STANDARD_RESTRICTED_MATCH = 14;
        public const int CANNON_BRAWL_MATCH = 15;
        public const int WINTER_MAYHAM_MATCH = 16;
        public const int FREE_FOR_ALL_MATCH = 17;
        public const int SCORPION_MATCH = 18;
        public const int BOAR_FIGHT_MATCH = 19;
        public const int BIG_BAD_BURNERS_MATCH = 20;
        public const int RACE_MATCH = 21;
        public const int STORMS_WARNING_MATCH = 22;
        public const int HALLOWEEN_MATCH = 23;
        public const int ROCKET_LEAGUE_MATCH = 24;
        public const int DRONE_BATTLE_MATCH = 25;
        public const int RACE_WHEELS_ONLY_MATCH = 26;
        public const int CROSSOUT_DAY_BRAWL_MATCH = 27;
        public const int GOZU_MATCH = 28; 
        public const int OPERATION_RED_LIGHT_MATCH = 29;
        public const int WITCH_HUNT_MATCH = 30;
        public const int BOMB_PLANT_MATCH = 31;
        public const int TEST_SERVER_MATCH = 32;
        public const int BOARS_MATCH = 33;
        public const int INVASION_MATCH = 34;
        public const int COPPER_PATROL_MATCH = 35;
        public const int ARENA_CASUAL_MATCH = 36;
        public const int ARENA_RANKED_MATCH = 37;

        public const int MATCH_CATEGORY_COUNT = UNDEFINED_MATCH + 1;

        public const int UNDEFINED_CLASSIFICATION = 0;
        public const int PVP_CLASSIFICATION = 1;
        public const int PVE_CLASSIFICATION = 2;
        public const int BRAWL_CLASSIFICATION = 3;
        public const int FREE_PLAY_CLASSIFICATION = 4;
        public const int CUSTOM_CLASSIFICATION = 5;

        public const int UNDEFINED_FILE_TYPE = 0;
        public const int COMBAT_LOG_FILE = 1;
        public const int CHAT_LOG_FILE = 2;
        public const int GAME_LOG_FILE = 3;
        public const int GFX_LOG_FILE = 4;
        public const int NET_LOG_FILE = 5;

        public const int ENGINEER_FACTION = 1;
        public const int LUNATICS_FACTION = 2;
        public const int NOMADS_FACTION = 3;
        public const int SCAVENGERS_FACTION = 4;
        public const int STEPPENWOLFS_FACTION = 5;
        public const int DAWNS_CHILDREN_FACTION = 6;
        public const int FIRESTARTERS_FACTION = 7;
        public const int FOUNDERS_FACTION = 8;
        public const int PRESTIGUE_PACK_FACTION = 9;

        public const int BASE_RARITY = 0;
        public const int COMMON_RARITY = 1;
        public const int RARE_RARITY = 2;
        public const int SPECIAL_RARITY = 3;
        public const int EPIC_RARITY = 4;
        public const int LEGENDARY_RARITY = 5;
        public const int RELIC_RARITY = 6;

        public const int TRACE_EVENT_FILE_COMPLETE = 1;
        public const int UNLOCK_MENU_BAR_EVENT = 2;
        public const int POPULATE_USER_PROFILE_EVENT = 3;
        public const int POPULATE_MATCH_HISTORY_EVENT = 4;
        public const int MATCH_END_POPULATE_EVENT = 5;
        public const int BUILD_POPULATE_EVENT = 6;
        public const int POPULATE_STATIC_ELEMENTS_EVENT = 7;
        public const int DEBUG_GIVE_LINE_UPDATE_EVENT = 8;
        public const int GARAGE_DAMAGE_EVENT = 9;
        public const int TEST_DRIVE_END_EVENT = 10;

        public const int UPLOAD_LIST_SIZE = 75;

        public const int INITIAL_SCREEN_HEIGHT = 601;
        public const int INITIAL_SCREEN_WIDTH = 1195;

        public const string GAME_MODE_FILTER_DEFAULT = "All Game Modes";
        public const string GROUP_FILTER_DEFAULT = "Solo/Grouped";
        public const string MAP_FILTER_DEFAULT = "All Maps";
        public const string POWER_SCORE_FILTER_DEFAULT = "All Power Scores";
        public const string CLIENT_VERSION_FILTER_DEFAULT = "All Versions";
        public const string WEAPONS_FILTER_DEFAULT = "All Weapons";
        public const string MOVEMENT_FILTER_DEFAULT = "All Movement";
        public const string MODULE_FILTER_DEFAULT = "All Modules";
        public const string CABIN_FILTER_DEFAULT = "All Cabins";

        public static string DB_PATH = "Data Source=log_database.db;Version=3;New=True;Compress=True;";

        public static List<string> supporters = new List<string> {  "Rot_Fish_Bandit",
                                                                    "QuickSkinner",
                                                                    "Perqq",
                                                                    "MayhemMotors",
                                                                    "blab_",
                                                                    "QuantumCanine",
                                                                    "bIorgus",
                                                                    "LordDrex"};
    }
}
