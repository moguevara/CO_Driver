using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFB_Tool_Suite
{
    class global_data
    {
        public static string CURRENT_VERSION = "0.0.1.2";

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

        public static string DB_PATH = "Data Source=log_database.db;Version=3;New=True;Compress=True;";
    }
}
