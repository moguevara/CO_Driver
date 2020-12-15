using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    class global_data
    {
        public static string CURRENT_VERSION = "0.0.1.30";

        public const int MATCH_START_EVENT = 1;
        public const int LOAD_PLAYER_EVENT = 2;
        public const int DAMAGE_EVENT = 4;
        public const int KILL_EVENT = 8;
        public const int ASSIST_EVENT = 16;
        public const int SCORE_EVENT = 32;
        public const int MATCH_END_EVENT = 64;
        public const int MAIN_MENU_EVENT = 128;
        public const int TEST_DRIVE_EVENT = 256;
        public const int CW_ROUND_END_EVENT = 512;

        public const int STANDARD_CW = 1;
        public const int LEVIATHIAN_CW = 2;

        public const int UNDEFINED_MATCH = 0;
        public const int STANDARD_MATCH = 1;
        public const int STANDARD_CW_MATCH = 2;
        public const int LEVIATHIAN_CW_MATCH = 3;
        public const int BATTLE_ROYALE_MATCH = 4;
        public const int LEAGUE_6_v_6_MATCH = 5;
        public const int SOLO_LEAGUE_6_v_6_MATCH = 6;

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

        public const int TRACE_EVENT_FILE_COMPLETE = 1;
        public const int UNLOCK_MENU_BAR_EVENT = 2;
        public const int POPULATE_USER_PROFILE_EVENT = 3;
        public const int POPULATE_MATCH_HISTORY_EVENT = 4;
        public const int MATCH_END_POPULATE_EVENT = 5;
        public const int BUILD_POPULATE_EVENT = 6;
        public const int POPULATE_PART_OPT_EVENT = 7;
        public const int DEBUG_GIVE_LINE_UPDATE_EVENT = 8;

        public static string DB_PATH = "Data Source=log_database.db;Version=3;New=True;Compress=True;";
    }
}
