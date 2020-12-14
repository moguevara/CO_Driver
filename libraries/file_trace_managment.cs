using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CO_Driver.Properties;
using System.Globalization;

namespace CO_Driver
{
    public class file_trace_managment
    {
        #region response_classes
        public class FileCompleteResponse
        {
            public double historic_percent_processed { get; set; }
            public string load_desc { get; set; }
        }
        public class UserProfileResponse
        {
            public Player local_player_record { get; set; }
            public List<MatchRecord> match_history { get; set; }
            public Dictionary<string, BuildRecord> build_records { get; set; }
        }

        public class MatchHistoryResponse
        {
            public List<MatchRecord> match_history { get; set; }
        }

        public class MatchEndResponse
        {
            public MatchRecord last_match { get; set; }
        }
        public class BuildRecordResponse
        {
            public Dictionary<string, BuildRecord> build_records { get; set; }
        }

        public class PartOptResponse
        {
            public List<Part> master_list { get; set; }
        }

        public class DebugResponse
        {
            public int event_type { get; set; }
            public string line { get; set; }
        }

        #endregion
        #region session_classes
        public class SessionStats
        {
            public bool live_trace_data { get; set; }
            public bool in_match { get; set; }
            public string local_user { get; set; }
            public int local_user_uid { get; set; }
            public int current_event { get; set; }
            public string map_name { get; set; }
            public int current_match_type { get; set; }
            public bool add_match_to_record { get; set; }
            public DateTime current_match_start { get; set; }
            public DateTime current_match_end { get; set; }
            public FileData file_data { get; set; }
            public Dictionary<string, Player> player_records { get; set; }
            public Dictionary<string, BuildRecord> player_build_records { get; set; }
            public List<Part> global_parts_list { get; set; }
            public List<MatchRecord> match_history { get; set; }
        }
        public class Player
        {
            public string nickname { get; set; }
            public int uid { get; set; }
            public int party_id { get; set; }
            public string build_hash { get; set; }
            public int power_score { get; set; }
            public int bot { get; set; }
            public bool in_game { get; set; }
            public int current_team { get; set; }
            public Stats in_game_stats { get; set; }
            public Stats total_stats { get; set; }
            public Dictionary<int, Stats> category_stats { get; set; }
        }
        public class Stats
        {
            public int kills { get; set; }
            public int assists { get; set; }
            public int deaths { get; set; }
            public int weapon_strips { get; set; }
            public int score { get; set; }
            public double damage { get; set; }
            public double damage_taken { get; set; }
            public int games { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
        }
        public class FileData
        {
            public string log_file_location { get; set; }
            public string historic_file_location { get; set; }
            public FileInfo processing_session_file { get; set; }
            public DateTime processing_session_file_day { get; set; }
            public List<LogFile> historic_file_list { get; set; }
        }

        public class LogFile
        {
            public bool processed { get; set; }
            public int file_type { get; set; }
            public FileInfo log_file { get; set; }
            
        }

        public class MatchRecord
        {
            public DateTime start_time { get; set; }
            public DateTime stop_time { get; set; }
            public string map_name { get; set; }
            public int match_type { get; set; }
            public string build_hash { get; set; }
            public int power_score { get; set; }
            public string game_result { get; set; }
            public string team_1 { get; set; }
            public string team_2 { get; set; }
            public string rewards { get; set; }
            public Stats local_player_stats { get; set; }
        }

        public class BuildRecord
        {
            public string build_hash { get; set; }
            public string build_desc { get; set; }
            public List<string> parts { get; set; }
            public Stats total_build_stats { get; set; }
            public Dictionary<int, Stats> build_stats { get; set; }
        }

        public class Part
        {
            public string description { get; set; }
            public int faction { get; set; }
            public int level { get; set; }
            public int hull_durability { get; set; }
            public int part_durability { get; set; }
            public int mass { get; set; }
            public int power_score { get; set; }
            public bool pass_through { get; set; }
            public double bullet_resistance { get; set; }
            public double melee_resistance { get; set; }
        }

        #endregion
        #region session_managment
        public void initialize_session_stats(SessionStats Current_session)
        {
            Current_session.live_trace_data = false;
            Current_session.in_match = false;
            Current_session.current_match_type = global_data.UNDEFINED_MATCH;
            Current_session.add_match_to_record = false;
            Current_session.local_user =  Settings.Default["local_user_name"].ToString();
            Current_session.local_user_uid = Convert.ToInt32(Settings.Default["local_user_uid"]);
            Current_session.current_event = 0;
            Current_session.file_data = new FileData { };
            Current_session.file_data.log_file_location = Settings.Default["log_file_location"].ToString();
            Current_session.file_data.historic_file_location = Settings.Default["historic_file_location"].ToString();
            Current_session.file_data.historic_file_list = load_historic_file_list();
            Current_session.player_records = new Dictionary<string, Player> { };
            Current_session.player_build_records = new Dictionary<string, BuildRecord> { };
            Current_session.global_parts_list = new List<Part> { };
            Current_session.match_history = new List<MatchRecord> { };

            populate_global_parts_list(Current_session);
        }

       


        private List<LogFile> load_historic_file_list()
        {
            List<LogFile> temp_list = new List<LogFile> { };
            FileInfo[] files = new DirectoryInfo(Settings.Default["historic_file_location"].ToString()).GetFiles("*.*", SearchOption.AllDirectories).Where(s => s.Name.StartsWith("combat") && s.Name.EndsWith("log")).OrderByDescending(p => p.CreationTime).ToArray();

            foreach (FileInfo file in files)
                temp_list.Add(new LogFile {processed = false, file_type = global_data.COMBAT_LOG_FILE, log_file = file });

            return temp_list;
        }
        
        public static void assign_current_event(string line, SessionStats Current_session)
        {
            int event_id = 0;

            if (line.Contains("===== Gameplay '"))
                event_id = global_data.MATCH_START_EVENT;
            else
            if (line.Contains("| 	player"))
                event_id = global_data.LOAD_PLAYER_EVENT;
            else
            if (line.Contains("| Damage."))
                event_id = global_data.DAMAGE_EVENT;
            else
            if (line.Contains("| Kill."))
                event_id = global_data.KILL_EVENT;
            else
            if (line.Contains("| 	 assist by"))
                event_id = global_data.ASSIST_EVENT;
            else
            if (line.Contains("| Score:"))
                event_id = global_data.SCORE_EVENT;
            else
            if (line.Contains("===== Gameplay finish"))
                event_id = global_data.MATCH_END_EVENT;
            else
            if ((line.Contains("| ====== starting level ") && line.Contains("levels/maps/hangar")) || line.Contains("| ====== TestDrive finish ======"))
                event_id = global_data.MAIN_MENU_EVENT;
            else
            if (line.Contains("| ====== TestDrive started ======"))
                event_id = global_data.TEST_DRIVE_EVENT;
            else
            if (line.Contains("| ===== Best Of N round"))
                event_id = global_data.CW_ROUND_END_EVENT;

            Current_session.current_event = event_id;
        }

        public static void match_start_event(string line, SessionStats Current_session)
        {
            Current_session.in_match = true;
            Current_session.add_match_to_record = false;

            string map_name = Regex.Match(line, @"map '(.+?)'").Groups[1].Value.Replace(" ", "");
            string game_play = Regex.Match(line, @"Gameplay '(.+?)'").Groups[1].Value.Replace(" ", "");
            Current_session.map_name = map_name;
            
            if (!Current_session.player_records.ContainsKey(Current_session.local_user))
                return;

            

            if (game_play.Contains("BestOf3"))
                Current_session.current_match_type = global_data.STANDARD_CW_MATCH;
            else 
            if (map_name.Contains("red_rocks_battle_royale"))
                Current_session.current_match_type = global_data.BATTLE_ROYALE_MATCH;
            else 
            if ((game_play.Contains("Conquer") || game_play.Contains("Domination") || game_play.Contains("Assault")))
                Current_session.current_match_type = global_data.STANDARD_MATCH;
            else
                Current_session.current_match_type = global_data.UNDEFINED_MATCH;


            clear_in_game_stats(-1, Current_session); /* sum results if game unfinished */
            Current_session.current_match_start = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line.Substring(0, 2), line.Substring(3, 2), line.Substring(6, 2)), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        private static void clear_in_game_stats(int winning_team, SessionStats Current_session)
        {
            if (Current_session.player_records[Current_session.local_user].in_game == true)
            {
                if (Current_session.current_match_type == global_data.STANDARD_MATCH)
                {
                    int player_count = 0;
                    foreach (KeyValuePair<string, Player> entry in Current_session.player_records)
                    {
                        if (entry.Value.in_game)
                        {
                            player_count++;

                            if (entry.Value.power_score > 8000)
                                break;
                            if (entry.Value.power_score < 6000)
                                break;
                            if (player_count == 12)
                                Current_session.current_match_type = global_data.LEAGUE_6_v_6_MATCH;
                            if (player_count > 12)
                                Current_session.current_match_type = global_data.STANDARD_MATCH;
                        }
                    }
                }
                if (Current_session.current_match_type == global_data.LEAGUE_6_v_6_MATCH && Current_session.player_records[Current_session.local_user].party_id == 0)
                    Current_session.current_match_type = global_data.SOLO_LEAGUE_6_v_6_MATCH;

                
                Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].total_build_stats =
                        sum_stats(Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].total_build_stats,
                                  Current_session.player_records[Current_session.local_user].in_game_stats);

                if (Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats.ContainsKey(Current_session.current_match_type))
                {
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats[Current_session.current_match_type] =
                        sum_stats(Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats[Current_session.current_match_type],
                                  Current_session.player_records[Current_session.local_user].in_game_stats);
                }
                else
                {
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats.Add(Current_session.current_match_type, Current_session.player_records[Current_session.local_user].in_game_stats);
                }

                MatchRecord match_record = new_match_record();

                if (Current_session.current_match_start > Current_session.current_match_end)
                {
                    Current_session.file_data.processing_session_file_day = Current_session.file_data.processing_session_file_day.AddDays(1.0);
                    Current_session.current_match_end = Current_session.current_match_end.AddDays(1.0);
                }

                match_record.map_name = Current_session.map_name;
                match_record.match_type = Current_session.current_match_type;
                match_record.start_time = Current_session.current_match_start;
                match_record.stop_time = Current_session.current_match_end;
                
                match_record.local_player_stats = Current_session.player_records[Current_session.local_user].in_game_stats;
                match_record.build_hash = Current_session.player_records[Current_session.local_user].build_hash;
                match_record.build_hash = Current_session.player_records[Current_session.local_user].build_hash;
                match_record.power_score = Current_session.player_records[Current_session.local_user].power_score;

                if (Current_session.player_records[Current_session.local_user].current_team == winning_team)
                {
                    match_record.game_result = "Win";
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].total_build_stats.wins++;
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats[Current_session.current_match_type].wins++;
                }
                else if (winning_team == -1)
                {
                    match_record.game_result = "Unfinished";
                }
                else
                {
                    match_record.game_result = "Loss";
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].total_build_stats.losses++;
                    Current_session.player_build_records[Current_session.player_records[Current_session.local_user].build_hash].build_stats[Current_session.current_match_type].losses++;
                }

                Current_session.match_history.Add(match_record);

                Current_session.current_match_start = new DateTime { };
                Current_session.current_match_end = new DateTime { };
                Current_session.add_match_to_record = true;
            }

            foreach (KeyValuePair<string, Player> entry in Current_session.player_records)
            {
                if (entry.Value.in_game)
                {
                    entry.Value.total_stats = sum_stats(entry.Value.total_stats, entry.Value.in_game_stats);

                    if (entry.Value.category_stats.ContainsKey(Current_session.current_match_type))
                    {
                        entry.Value.category_stats[Current_session.current_match_type] = sum_stats(entry.Value.category_stats[Current_session.current_match_type], entry.Value.in_game_stats);
                    }
                    else
                    {
                        entry.Value.category_stats.Add(Current_session.current_match_type, entry.Value.in_game_stats);
                    }

                    if (entry.Value.current_team == winning_team) 
                    {
                        entry.Value.total_stats.wins++;
                        entry.Value.category_stats[Current_session.current_match_type].wins++;
                    }
                    else 
                    {
                        entry.Value.total_stats.losses++;
                        entry.Value.category_stats[Current_session.current_match_type].losses++;
                    }

                    entry.Value.in_game = false;
                    entry.Value.in_game_stats = new_stats();
                    entry.Value.party_id = 0;
                }
            }
        }

        public static void load_player_event(string line, SessionStats Current_session)
        {
            string player_name = Regex.Match(line, @"nickname: (.+?),").Groups[1].Value.Replace(" ", "");
            string build_hash = Regex.Match(line, @"mmHash: (.+?)$").Groups[1].Value.Replace(" ", "");
            int uid = Int32.Parse(Regex.Match(line, @"uid (.+?),").Groups[1].Value.Replace(" ", ""));
            int bot = Int32.Parse(Regex.Match(line, @"bot: (.+?),").Groups[1].Value.Replace(" ", ""));
            int party_id = Int32.Parse(Regex.Match(line, @"party (.+?),").Groups[1].Value);
            int current_team = Int32.Parse(Regex.Match(line, @"team: (.+?),").Groups[1].Value.Replace(" ", ""));
            int power_score = Int32.Parse(Regex.Match(line, @", ur: (.+?),").Groups[1].Value.Replace(" ", ""));

            if (Current_session.current_match_type == global_data.STANDARD_CW_MATCH && power_score > 22000)
                Current_session.current_match_type = global_data.LEVIATHIAN_CW_MATCH;

            

            if (Current_session.player_records.ContainsKey(player_name))
            {
                Current_session.player_records[player_name].uid = uid;
                Current_session.player_records[player_name].bot = bot;
                Current_session.player_records[player_name].in_game = true;
                Current_session.player_records[player_name].party_id = party_id;
                Current_session.player_records[player_name].build_hash = build_hash;
                Current_session.player_records[player_name].power_score = power_score;
                Current_session.player_records[player_name].current_team = current_team;
            }
            else
            {
                Player current_player = new_player();
                current_player.nickname = player_name;
                current_player.uid = uid;
                current_player.bot = bot;
                current_player.in_game = true;
                current_player.party_id = party_id;
                current_player.build_hash = build_hash;
                current_player.power_score = power_score;
                current_player.current_team = current_team;
                Current_session.player_records.Add(player_name, current_player);
            }

            if (player_name == Current_session.local_user)
            {
                if (!Current_session.player_build_records.ContainsKey(build_hash))
                {
                    BuildRecord new_build = new_build_record();
                    new_build.build_hash = build_hash;
                    Current_session.player_build_records.Add(build_hash, new_build_record());
                }
            }
        }

        public static void damage_event(string line, SessionStats Current_session)
        {
            string attacker = Regex.Match(line, @"attacker: (.+?),").Groups[1].Value.Replace(" ", "");
            string victim = Regex.Match(line, @"Victim: (.+?),").Groups[1].Value.Replace(" ", "");
            double damage = Convert.ToDouble(Regex.Match(line, @"damage: (.+?) ").Groups[1].Value.Replace(" ", ""));
            string weapon = Regex.Match(line, @"weapon '(.+?)',").Groups[1].Value.Replace(" ", "");

            weapon = weapon.Substring(0, weapon.IndexOf(':') > 0 ? weapon.IndexOf(':') : weapon.Length);

            if (!Current_session.in_match)
                return;

            Current_session.current_match_end = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line.Substring(0, 2), line.Substring(3, 2), line.Substring(6, 2)), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            if (attacker.IndexOf(":") > 0)
                return;

            if (victim.IndexOf(":") > 0)
                return;

            if (!Current_session.player_records.ContainsKey(attacker))
                return;

            if (!Current_session.player_records.ContainsKey(victim))
                return;

            if (attacker != victim)
            {
                Current_session.player_records[attacker].in_game_stats.damage += damage;
                Current_session.player_records[victim].in_game_stats.damage_taken += damage;
            }
            if (attacker == Current_session.local_user) {
                if (!Current_session.player_build_records[Current_session.player_records[attacker].build_hash].parts.Contains(weapon))
                {
                    Current_session.player_build_records[Current_session.player_records[attacker].build_hash].parts.Add(weapon);
                }
            }
                    
        }

        public static void kill_event(string line, SessionStats Current_session)
        {
            string killer = Regex.Match(line, @"killer: (.+?)$").Groups[1].Value.Replace(" ", "");
            string victim = Regex.Match(line, @"Victim: (.+?) killer:").Groups[1].Value.Replace(" ", "");

            //ignore test drive
            if (!Current_session.in_match)
                return;

            if (killer.IndexOf(":") > 0)
                return;
            if (victim.IndexOf(":") > 0)
                return;

            if (!Current_session.player_records.ContainsKey(killer))
                return;

            if (!Current_session.player_records.ContainsKey(victim))
                return;

            Current_session.player_records[killer].in_game_stats.kills++;
            Current_session.player_records[victim].in_game_stats.deaths++;
        }

        public static void kill_assist_event(string line, SessionStats Current_session)
        {
            string assistant = Regex.Match(line, @"assist by (.+?)weapon").Groups[1].Value.Replace(" ", "");
            string weapon = Regex.Match(line, @"weapon: (.+?),").Groups[1].Value.Replace(" ", "");

            if (assistant.IndexOf(":") > 0)
                return;

            if (!Current_session.in_match)
                return;

            if (!Current_session.player_records.ContainsKey(assistant)) /* map elements count as players for assist*/
                return;

            if (weapon != "n/a")
                Current_session.player_records[assistant].in_game_stats.assists++;
        }

        public static void score_event(string line, SessionStats Current_session)
        {
            string scorer = Regex.Match(line, @"nick: (.+?),").Groups[1].Value.Replace(" ", "");
            int points = Int32.Parse(Regex.Match(line, @"Got:(.+?),").Groups[1].Value);

            if (!Current_session.in_match)
                return;

            if (!Current_session.player_records.ContainsKey(scorer))
                return;

            Current_session.player_records[scorer].in_game_stats.score += points;
        }

        public static void match_end_event(string line, SessionStats Current_session)
        {
            int winning_team = Int32.Parse(Regex.Match(line, @"winner team (.+?),").Groups[1].Value);
            Current_session.current_match_end = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line.Substring(0, 2), line.Substring(3, 2), line.Substring(6, 2)), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Current_session.in_match = false;
            clear_in_game_stats(winning_team, Current_session);
        }

        public string decode_match_type(int match_type)
        {
            switch (match_type)
            {
                case global_data.STANDARD_MATCH:
                    return "8v8";
                case global_data.STANDARD_CW_MATCH:
                    return "CW";
                case global_data.LEVIATHIAN_CW_MATCH:
                    return "Levi CW";
                case global_data.BATTLE_ROYALE_MATCH:
                    return "Battle Royal";
                case global_data.LEAGUE_6_v_6_MATCH:
                    return "6v6";
                case global_data.SOLO_LEAGUE_6_v_6_MATCH:
                    return "Solo 6v6";
                default:
                    return "Undefined";
            }
        }

        private void populate_global_parts_list(SessionStats Current_session)
        {
            //ENGINEER 1
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 1, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 1, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 1, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 2
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.ENGINEER_FACTION, 2, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Catch", global_data.ENGINEER_FACTION, 2, 0, 53, 72, 21, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.ENGINEER_FACTION, 2, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.ENGINEER_FACTION, 2, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 2, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 2, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 2, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 2, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 2, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 2, 13, 13, 28, 11, false, 0, 0));
            //ENGINEER 3
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.ENGINEER_FACTION, 3, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 3, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 3, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 3, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.ENGINEER_FACTION, 3, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 3, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 3, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 3, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 3, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 3, 23, 23, 51, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 3, 23, 23, 51, 20, false, 0, 0));
            //ENGINEER 4
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 4, 0, 38, 43, 133, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 4, 0, 31, 42, 12, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 4, 0, 31, 42, 12, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 4, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 4, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 5
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 5, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 5, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 5, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 5, 60, 60, 135, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 5, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 6
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 6, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 6, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 6, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 6, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 6, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Offroad Bumper", global_data.ENGINEER_FACTION, 6, 0, 139, 192, 56, false, 0, 0.9));
            //ENGINEER 7
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 7, 86, 86, 196, 77, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 7, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 7, 6, 6, 12, 4, false, 0, 0));
            //ENGINEER 8
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 8, 0, 38, 43, 133, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 8, 23, 23, 51, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 8, 23, 23, 51, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 8, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 8, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 9
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 9, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Catch", global_data.ENGINEER_FACTION, 9, 0, 53, 72, 21, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 9, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 9, 13, 13, 28, 11, false, 0, 0));
            //ENGINEER 10
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 10, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 10, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 10, 60, 60, 135, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 10, 60, 60, 135, 53, false, 0, 0));
            //ENGINEER 11
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 11, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 11, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Offroad Bumper", global_data.ENGINEER_FACTION, 11, 0, 139, 192, 56, false, 0, 0.9));
            //ENGINEER 12 
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 12, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 12, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 12, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 12, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 12, 60, 60, 135, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 12, 60, 60, 135, 53, false, 0, 0));
            //ENGINEER 13
            Current_session.global_parts_list.Add(new_part("Buggy Floor", global_data.ENGINEER_FACTION, 13, 0, 16, 18, 56, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Floor", global_data.ENGINEER_FACTION, 13, 0, 16, 18, 56, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 13, 86, 86, 196, 77, false, 0, 0));
            //ENGINEER 14
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 14, 0, 5, 5, 14, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 14, 0, 5, 5, 14, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 14, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Sideboard", global_data.ENGINEER_FACTION, 14, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 15
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 15, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 15, 6, 6, 12, 4, false, 0, 0));
            //ENGINEER 16
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 16, 0, 5, 5, 14, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Engine Cover", global_data.ENGINEER_FACTION, 16, 0, 5, 5, 14, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 16, 0, 31, 42, 12, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hatchet", global_data.ENGINEER_FACTION, 16, 0, 31, 42, 12, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Gun Mount", global_data.ENGINEER_FACTION, 16, 0, 38, 43, 133, true, 0.9, 0));
            //ENGINEER 17
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 17, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 17, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 17, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Small Buggy Floor", global_data.ENGINEER_FACTION, 17, 0, 8, 9, 28, true, 0.9, 0));
            //ENGINEER 18
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 18, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 18, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 18, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 18, 0, 8, 9, 28, true, 0.9, 0));
            //ENGINEER 19
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 19, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 19, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 19, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Running Board", global_data.ENGINEER_FACTION, 19, 15, 15, 34, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 19, 23, 23, 51, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 19, 23, 23, 51, 20, false, 0, 0));
            //ENGINEER 20
            Current_session.global_parts_list.Add(new_part("Torino Rear", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Nosecut", global_data.ENGINEER_FACTION, 20, 40, 40, 90, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fender", global_data.ENGINEER_FACTION, 20, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 21
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 21, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Radiator Grille", global_data.ENGINEER_FACTION, 21, 0, 7, 7, 21, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 21, 23, 23, 51, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Window", global_data.ENGINEER_FACTION, 21, 23, 23, 51, 20, false, 0, 0));
            //ENGINEER 22
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 22, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Trunk", global_data.ENGINEER_FACTION, 22, 0, 8, 9, 28, true, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 22, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 22, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 23
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 23, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 23, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Door", global_data.ENGINEER_FACTION, 23, 86, 86, 196, 77, false, 0, 0));
            //ENGINEER 24
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 24, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 24, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 24, 60, 60, 135, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Canvas Roof", global_data.ENGINEER_FACTION, 24, 60, 60, 135, 53, false, 0, 0));
            //ENGINEER 25
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 25, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 25, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Bonnet", global_data.ENGINEER_FACTION, 25, 94, 94, 213, 84, false, 0, 0));
            //ENGINEER 26
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 26, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 26, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Nosecut", global_data.ENGINEER_FACTION, 26, 40, 40, 90, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 26, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Side", global_data.ENGINEER_FACTION, 26, 20, 20, 45, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Rear", global_data.ENGINEER_FACTION, 26, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 27
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Strut", global_data.ENGINEER_FACTION, 27, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 27, 25, 25, 56, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Fender", global_data.ENGINEER_FACTION, 27, 25, 25, 56, 22, false, 0, 0));
            //ENGINEER 28
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 28, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Medium Strut", global_data.ENGINEER_FACTION, 28, 13, 13, 28, 11, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Torino Bonnet", global_data.ENGINEER_FACTION, 28, 94, 94, 213, 84, false, 0, 0));
            //ENGINEER 29
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 29, 6, 6, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Van Ramp", global_data.ENGINEER_FACTION, 29, 6, 6, 12, 4, false, 0, 0));
            //ENGINEER 30
            //ENGINEER PRESTIGE
            Current_session.global_parts_list.Add(new_part("Hot Rod Grille", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 23, 23, 54, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Hood", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 50, 50, 121, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Left Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 22, 22, 51, 17, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Left Rear Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 34, 34, 81, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Right Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 22, 22, 51, 17, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Right Rear Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 34, 34, 81, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hot Rod Trunk", global_data.PRESTIGUE_PACK_FACTION, global_data.ENGINEER_FACTION, 36, 36, 85, 28, false, 0, 0));
            //LUNATICS 1
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 1, 28, 28, 54, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 1, 28, 28, 54, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 1, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 1, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 1, 4, 4, 7, 4, false, 0, 0));
            //LUNATICS 2
            Current_session.global_parts_list.Add(new_part("Bullbar", global_data.LUNATICS_FACTION, 2, 0, 95, 101, 49, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 2, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 2, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 2, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 2, 14, 14, 27, 18, false, 0, 0));
            //LUNATICS 3
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 3, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 3, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 3, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 3, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 3, 0, 55, 58, 28, false, 0, 0.9));
            //LUNATICS 4
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 4, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 4, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 4, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 4, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 4, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 4, 14, 14, 27, 18, false, 0, 0));
            //LUNATICS 5
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 5, 28, 28, 54, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 5, 28, 28, 54, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 5, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 5, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 5, 41, 41, 80, 52, false, 0, 0));
            //LUNATICS 6
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 6, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 6, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 6, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 6, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 6, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 6, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 6, 10, 10, 19, 12, false, 0, 0));
            //LUNATICS 7
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Brazier", global_data.LUNATICS_FACTION, 7, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Frontal Protection System", global_data.LUNATICS_FACTION, 7, 0, 68, 72, 35, false, 0, 0.9));
            //LUNATICS 8
            Current_session.global_parts_list.Add(new_part("Bullbar", global_data.LUNATICS_FACTION, 8, 0, 95, 101, 49, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 8, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 8, 28, 28, 54, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Fryer", global_data.LUNATICS_FACTION, 8, 28, 28, 54, 35, false, 0, 0));
            //LUNATICS 9
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 9, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dryer", global_data.LUNATICS_FACTION, 9, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 9, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 9, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 9, 0, 55, 58, 28, false, 0, 0.9));
            //LUNATICS 10
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Crutch", global_data.LUNATICS_FACTION, 10, 10, 10, 19, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 10, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 10, 41, 41, 80, 52, false, 0, 0));
            //LUNATICS 11
            Current_session.global_parts_list.Add(new_part("Buggy Fender Left", global_data.LUNATICS_FACTION, 11, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Fender Right", global_data.LUNATICS_FACTION, 11, 6, 6, 11, 7, false, 0, 0));
            //LUNATICS 12
            Current_session.global_parts_list.Add(new_part("Buggy Bumper", global_data.LUNATICS_FACTION, 12, 0, 81, 86, 42, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 12, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Dipper", global_data.LUNATICS_FACTION, 12, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Comb", global_data.LUNATICS_FACTION, 12, 4, 4, 7, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 12, 8, 8, 14, 9, false, 0, 0));
            //LUNATICS 13
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 13, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Rear", global_data.LUNATICS_FACTION, 13, 44, 44, 86, 56, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Grater", global_data.LUNATICS_FACTION, 13, 6, 6, 11, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bumper Spike", global_data.LUNATICS_FACTION, 13, 0, 55, 58, 28, false, 0, 0.9));
            //LUNATICS 14
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 14, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Buggy Step Plate", global_data.LUNATICS_FACTION, 14, 8, 8, 14, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 14, 41, 41, 80, 52, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Whaleback", global_data.LUNATICS_FACTION, 14, 41, 41, 80, 52, false, 0, 0));
            //LUNATICS 15
            Current_session.global_parts_list.Add(new_part("Buggy Bumper", global_data.LUNATICS_FACTION, 15, 0, 81, 86, 42, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Frontal Protection System", global_data.LUNATICS_FACTION, 15, 0, 68, 72, 35, false, 0, 0.9));
            //LUNATICS PRESTIGE
            Current_session.global_parts_list.Add(new_part("Powerslide", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 68, 68, 138, 88, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Shielded Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 7, 7, 12, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Shielded Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 7, 7, 12, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Side Guard Right", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 11, 11, 21, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Side Guard Left", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 11, 11, 21, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bully Nosecut", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bully Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 0, 68, 72, 35, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Pole Position", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 0, 89, 94, 46, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Backmarker", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 18, 18, 34, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Backmaker", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 18, 18, 34, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Bend", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Bend", global_data.PRESTIGUE_PACK_FACTION, global_data.LUNATICS_FACTION, 14, 14, 27, 18, false, 0, 0));
            //NOMADS 1
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 1, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 1, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 1, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 1, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 1, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 1, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 1, 10, 10, 24, 8, false, 0, 0));
            //NOMADS 2
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 2, 0, 216, 492, 155, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 2, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 2, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 2, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 2, 23, 23, 54, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 2, 23, 23, 54, 18, false, 0, 0));
            //NOMADS 3
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 3, 0, 28, 43, 17, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 3, 0, 28, 43, 17, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 3, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 3, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 3, 54, 54, 130, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 3, 54, 54, 130, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 3, 8, 8, 19, 6, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 3, 8, 8, 19, 6, false, 0, 0));
            //NOMADS 4
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 4, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 4, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 4, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 4, 50, 50, 121, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 4, 50, 50, 121, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 4, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 4, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 4, 23, 23, 54, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 4, 23, 23, 54, 18, false, 0, 0));
            //NOMADS 5
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 5, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 5, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 5, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 5, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 5, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 5, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 5, 50, 50, 121, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Narrow Wing", global_data.NOMADS_FACTION, 5, 50, 50, 121, 40, false, 0, 0));
            //NOMAD 6
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 6, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 6, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 6, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 6, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 6, 31, 31, 74, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 6, 31, 31, 74, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 6, 10, 10, 24, 8, false, 0, 0));
            //NOMAD 7
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 7, 37, 37, 88, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 7, 37, 37, 88, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 7, 12, 12, 27, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 7, 12, 12, 27, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 7, 0, 28, 43, 17, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 7, 23, 23, 54, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel", global_data.NOMADS_FACTION, 7, 23, 23, 54, 18, false, 0, 0));
            //NOMAD 8
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 8, 8, 8, 19, 6, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 8, 8, 8, 19, 6, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 8, 10, 10, 22, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 8, 10, 10, 22, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 8, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Large", global_data.NOMADS_FACTION, 8, 45, 45, 108, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 8, 0, 216, 492, 155, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 8, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 8, 10, 10, 24, 8, false, 0, 0));
            //NOMAD 9
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 9, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 9, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin BladeWing", global_data.NOMADS_FACTION, 9, 0, 56, 86, 34, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Twin BladeWing", global_data.NOMADS_FACTION, 9, 0, 56, 86, 34, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 9, 54, 54, 130, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Double Slope", global_data.NOMADS_FACTION, 9, 54, 54, 130, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 9, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 9, 20, 20, 48, 15, false, 0, 0));
            //NOMAD 10
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 10, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 10, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 10, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 10, 53, 53, 128, 42, false, 0, 0));
            //NOMAD 11
            Current_session.global_parts_list.Add(new_part("Blade Wing", global_data.NOMADS_FACTION, 11, 0, 28, 43, 17, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 11, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 11, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 11, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Wide Slope", global_data.NOMADS_FACTION, 11, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 11, 5, 5, 12, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Narrow Slope", global_data.NOMADS_FACTION, 11, 5, 5, 12, 4, false, 0, 0));
            //NOMAD 12
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 12, 37, 37, 88, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Wide", global_data.NOMADS_FACTION, 12, 37, 37, 88, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 12, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 12, 12, 12, 27, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Panel Small", global_data.NOMADS_FACTION, 12, 12, 12, 27, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 12, 10, 10, 24, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Slope", global_data.NOMADS_FACTION, 12, 10, 10, 24, 8, false, 0, 0));
            //NOMAD 13
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 13, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Strut", global_data.NOMADS_FACTION, 13, 16, 16, 37, 12, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 13, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Nose", global_data.NOMADS_FACTION, 13, 13, 13, 31, 10, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 13, 31, 31, 74, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Plane Air Intake", global_data.NOMADS_FACTION, 13, 31, 31, 74, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 13, 10, 10, 22, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope Narrow", global_data.NOMADS_FACTION, 13, 10, 10, 22, 7, false, 0, 0));
            //NOMAD 14
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Oblique Slope", global_data.NOMADS_FACTION, 14, 19, 19, 44, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Avia Fender", global_data.NOMADS_FACTION, 14, 53, 53, 128, 42, false, 0, 0));
            //NOMAD 15
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 15, 8, 8, 19, 6, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Avia Strut", global_data.NOMADS_FACTION, 15, 8, 8, 19, 6, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 15, 0, 216, 492, 155, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Plow", global_data.NOMADS_FACTION, 15, 0, 216, 492, 155, false, 0, 0.9));
            //NOMAD PRESTIGE
            Current_session.global_parts_list.Add(new_part("Mariposa", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 0, 75, 115, 28, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Shoulder", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 7, 7, 16, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Shoulder", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 7, 7, 16, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Right Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 56, 56, 142, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Nosecut", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 68, 68, 173, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Corrida Left Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 56, 56, 142, 40, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Splitter", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 0, 72, 110, 28, false, 0.0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Side Air Intake", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 20, 20, 48, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Side Air", global_data.PRESTIGUE_PACK_FACTION, global_data.NOMADS_FACTION, 20, 20, 48, 15, false, 0, 0));
            //SCAVENGERS 1
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 1, 57, 57, 162, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 1, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 1, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 1, 9, 9, 23, 5, false, 0, 0));
            //SCAVENGERS 2
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 2, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 2, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Terribull Bar", global_data.SCAVENGERS_FACTION, 2, 0, 161, 324, 102, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 2, 22, 22, 61, 13, false, 0, 0));
            //SCAVENGERS 3
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 3, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 3, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 3, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 3, 9, 9, 23, 5, false, 0, 0));
            //SCAVENGERS 4
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 4, 114, 114, 323, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 4, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 4, 22, 22, 61, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 4, 11, 11, 31, 7, false, 0, 0));
            //SCAVENGERS 5
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Door", global_data.SCAVENGERS_FACTION, 5, 114, 114, 323, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 5, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 5, 57, 57, 162, 35, false, 0, 0));
            //SCAVENGERS 6
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 6, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 6, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 6, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 6, 11, 11, 31, 7, false, 0, 0));
            //SCAVENGERS 7
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 7, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 7, 24, 24, 66, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Train Plow", global_data.SCAVENGERS_FACTION, 7, 0, 416, 952, 300, false, 0, 0.9));
            //SCAVENGERS 8
            Current_session.global_parts_list.Add(new_part("Terribull Bar", global_data.SCAVENGERS_FACTION, 8, 0, 161, 324, 102, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wide Slope", global_data.SCAVENGERS_FACTION, 8, 22, 22, 61, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 8, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Half-Wall", global_data.SCAVENGERS_FACTION, 8, 57, 57, 162, 35, false, 0, 0));
            //SCAVENGERS 9
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 9, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Metal Box", global_data.SCAVENGERS_FACTION, 9, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 9, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 9, 22, 22, 61, 13, false, 0, 0));
            //SCAVENGERS 10
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 10, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 10, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 10, 43, 43, 121, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 10, 9, 9, 23, 5, false, 0, 0));
            //SCAVENGERS 11
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Quarter Wall", global_data.SCAVENGERS_FACTION, 11, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 11, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("T-Pipe", global_data.SCAVENGERS_FACTION, 11, 8, 8, 21, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Curved Pipe", global_data.SCAVENGERS_FACTION, 11, 9, 9, 23, 5, false, 0, 0));
            //SCAVENGERS 12
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 12, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Barrel Quarter", global_data.SCAVENGERS_FACTION, 12, 12, 12, 32, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Slope", global_data.SCAVENGERS_FACTION, 12, 36, 36, 101, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Container Wall", global_data.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Container Wall", global_data.SCAVENGERS_FACTION, 12, 114, 114, 323, 70, false, 0, 0));
            //SCAVENGERS 13
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Long Pipe Shield", global_data.SCAVENGERS_FACTION, 13, 43, 43, 121, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Truck Slope", global_data.SCAVENGERS_FACTION, 13, 11, 11, 31, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Straight Pipe", global_data.SCAVENGERS_FACTION, 13, 15, 15, 41, 9, false, 0, 0));
            //SCAVENGERS 14
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Fender", global_data.SCAVENGERS_FACTION, 14, 93, 93, 263, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipe Shield", global_data.SCAVENGERS_FACTION, 14, 29, 29, 81, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Twin Slope", global_data.SCAVENGERS_FACTION, 14, 22, 22, 61, 13, false, 0, 0));
            //SCAVENGERS 15
            Current_session.global_parts_list.Add(new_part("Train Plow", global_data.SCAVENGERS_FACTION, 15, 0, 416, 952, 300, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thick Pipe Mudguard", global_data.SCAVENGERS_FACTION, 15, 24, 24, 66, 14, false, 0, 0));
            //SCAVENGERS PRESTIGE
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bartizan", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Veil", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 0, 97, 194, 32, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Phantom Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 89, 89, 252, 55, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Phantom Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 89, 89, 252, 55, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rear Cover", global_data.PRESTIGUE_PACK_FACTION, global_data.SCAVENGERS_FACTION, 48, 48, 137, 30, false, 0, 0));
            //STEPPENWOLF 1
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 1, 120, 120, 359, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 1, 8, 8, 23, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 1, 49, 49, 146, 29, false, 0, 0));
            //STEPENWOLF 2
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 2, 94, 94, 280, 55, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 2, 23, 23, 68, 13, false, 0, 0));
            //STEPENWOLF 3
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 120, 120, 359, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 3, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 3, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 3, 8, 8, 23, 4, false, 0, 0));
            //STEPENWOLF 4
            Current_session.global_parts_list.Add(new_part("Defence Perimeter", global_data.STEPPENWOLFS_FACTION, 4, 0, 133, 288, 42, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 4, 94, 94, 280, 55, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 4, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 4, 49, 49, 146, 29, false, 0, 0));
            //STEPENWOLF 5
            Current_session.global_parts_list.Add(new_part("APC Rear", global_data.STEPPENWOLFS_FACTION, 5, 105, 105, 314, 62, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 5, 12, 12, 34, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 5, 23, 23, 68, 13, false, 0, 0));
            //STEPENWOLF 6
            Current_session.global_parts_list.Add(new_part("Defence Line", global_data.STEPPENWOLFS_FACTION, 6, 0, 89, 192, 28, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 6, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 6, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Slope", global_data.STEPPENWOLFS_FACTION, 6, 49, 49, 146, 29, false, 0, 0));
            //STEPENWOLF 7
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Thin Strike Plate", global_data.STEPPENWOLFS_FACTION, 7, 8, 8, 23, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Armored Hatch", global_data.STEPPENWOLFS_FACTION, 7, 98, 98, 293, 58, false, 0, 0));
            //STEPENWOLF 8
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 120, 120, 359, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Tank Side Part", global_data.STEPPENWOLFS_FACTION, 8, 23, 23, 68, 13, false, 0, 0));
            //STEPENWOLF 9
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 9, 53, 53, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 9, 94, 94, 280, 55, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Ventilation Slope", global_data.STEPPENWOLFS_FACTION, 9, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Strengthened Twin Slope", global_data.STEPPENWOLFS_FACTION, 9, 12, 12, 34, 7, false, 0, 0));
            //STEPENWOLF 10
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 120, 120, 359, 70, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 10, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Defence Perimeter", global_data.STEPPENWOLFS_FACTION, 10, 0, 133, 288, 42, false, 0, 0.9));
            //STEPENWOLF 11
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Door", global_data.STEPPENWOLFS_FACTION, 11, 53, 53, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 11, 61, 61, 180, 35, false, 0, 0));
            //STEPENWOLF 12
            Current_session.global_parts_list.Add(new_part("APC Rear", global_data.STEPPENWOLFS_FACTION, 12, 105, 105, 314, 62, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Roof Part", global_data.STEPPENWOLFS_FACTION, 12, 120, 120, 359, 70, false, 0, 0));
            //STEPENWOLF 13
            Current_session.global_parts_list.Add(new_part("Defence Line", global_data.STEPPENWOLFS_FACTION, 13, 0, 89, 192, 28, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("APC Side Part", global_data.STEPPENWOLFS_FACTION, 13, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 13, 23, 23, 68, 13, false, 0, 0));
            //STEPENWOLF 14
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Tank Side Part", global_data.STEPPENWOLFS_FACTION, 14, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Armored Hatch", global_data.STEPPENWOLFS_FACTION, 14, 98, 98, 293, 58, false, 0, 0));
            //STEPENWOLF 15
            Current_session.global_parts_list.Add(new_part("Small APC Roof Part", global_data.STEPPENWOLFS_FACTION, 15, 23, 23, 68, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hard Module", global_data.STEPPENWOLFS_FACTION, 15, 94, 94, 280, 55, false, 0, 0));
            //STEPENWOLF PRESTIGE
            Current_session.global_parts_list.Add(new_part("Line of Defence", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Line of Defence", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 75, 75, 224, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Vanguard", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 31, 31, 90, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Western Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Eastern Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 46, 46, 135, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Wedge", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 61, 61, 180, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Home Front", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 105, 105, 314, 62, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Barrier", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 14, 14, 40, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Barrier", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 14, 14, 40, 8, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sentry Line", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 122, 264, 39, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Rampart", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 38, 38, 112, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Rampart", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 38, 38, 112, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Military Truck Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 34, 34, 101, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 98, 98, 292, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 90, 90, 269, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large APC Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 90, 90, 269, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Right Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 76, 165, 24, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Flail", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 80, 96, 56, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Right APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left APC Bumper", global_data.PRESTIGUE_PACK_FACTION, global_data.STEPPENWOLFS_FACTION, 0, 155, 336, 49, false, 0, 0.9));
            //DAWNS CHILDREN 1
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 1, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 1, 31, 31, 79, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 1, 4, 4, 8, 2, false, 0, 0));
            //DAWNS CHILDREN 2
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 2, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 2, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 2, 10, 10, 24, 7, false, 0, 0));
            //DAWNS CHILDREN 3
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 3, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 3, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 3, 19, 19, 48, 13, false, 0, 0));
            //DAWNS CHILDREN 4
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 4, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 4, 31, 31, 79, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 4, 10, 10, 24, 7, false, 0, 0));
            //DAWNS CHILDREN 5
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 5, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 5, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 5, 19, 19, 48, 13, false, 0, 0));
            //DAWNS CHILDREN 6
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 6, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 6, 10, 10, 24, 7, false, 0, 0));
            //DAWNS CHILDREN 7
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 7, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Shock Absorber", global_data.DAWNS_CHILDREN_FACTION, 7, 0, 132, 202, 77, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 7, 19, 19, 48, 13, false, 0, 0));
            //DAWNS CHILDREN 8
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 8, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 8, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 8, 10, 10, 24, 7, false, 0, 0));
            //DAWNS CHILDREN 9
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 9, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 9, 62, 62, 157, 44, false, 0, 0));
            //DAWNS CHILDREN 10
            Current_session.global_parts_list.Add(new_part("Hull Part", global_data.DAWNS_CHILDREN_FACTION, 10, 10, 10, 24, 7, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 10, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Broken Radiator", global_data.DAWNS_CHILDREN_FACTION, 10, 19, 19, 48, 13, false, 0, 0));
            //DAWNS CHILDREN 11
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Control Module", global_data.DAWNS_CHILDREN_FACTION, 11, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 11, 31, 31, 79, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 11, 4, 4, 8, 2, false, 0, 0));
            //DAWNS CHILDREN 12
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 12, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 12, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 12, 28, 28, 71, 20, false, 0, 0));
            //DAWNS CHILDREN 13
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 13, 31, 31, 79, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Air Intake", global_data.DAWNS_CHILDREN_FACTION, 13, 4, 4, 8, 2, false, 0, 0));
            //DAWNS CHILDREN 14
            Current_session.global_parts_list.Add(new_part("Hull Back", global_data.DAWNS_CHILDREN_FACTION, 14, 53, 53, 134, 37, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Ventilation Box", global_data.DAWNS_CHILDREN_FACTION, 14, 28, 28, 71, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Observation Pod", global_data.DAWNS_CHILDREN_FACTION, 14, 31, 31, 79, 22, false, 0, 0));
            //DAWNS CHILDREN 15
            Current_session.global_parts_list.Add(new_part("Cooling System", global_data.DAWNS_CHILDREN_FACTION, 15, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Shock Absorber", global_data.DAWNS_CHILDREN_FACTION, 15, 0, 132, 202, 77, false, 0.25, 0.9));
            //DAWNS CHILDREN PRESTIGE
            Current_session.global_parts_list.Add(new_part("Rump", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 25, 25, 48, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Phalanx", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Phalanx", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 13, 13, 24, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Rib", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Rib", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 19, 19, 37, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cranium", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 55, 58, 28, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Reflector", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 62, 62, 157, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Screener", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 141, 216, 83, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Incisor", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 0, 50, 84, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Assembly Section", global_data.PRESTIGUE_PACK_FACTION, global_data.DAWNS_CHILDREN_FACTION, 80, 80, 204, 57, false, 0, 0));
            //FIRESTARTER 1
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 1, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 1, 15, 15, 32, 15, false, 0, 0));
            //FIRESTARTER 2
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 2, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Nibbler", global_data.FIRESTARTERS_FACTION, 2, 0, 71, 86, 32, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 2, 22, 22, 45, 22, false, 0, 0));
            //FIRESTARTER 3
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 3, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 3, 0, 44, 53, 19, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 3, 30, 30, 63, 31, false, 0, 0));
            //FIRESTARTER 4
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 4, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 4, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 4, 28, 28, 59, 29, false, 0, 0));
            //FIRESTARTER 5
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 5, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 5, 45, 45, 95, 46, false, 0, 0));
            //FIRESTARTER 6
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 6, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 6, 28, 28, 59, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 6, 30, 30, 63, 31, false, 0, 0));
            //FIRESTARTER 7
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 7, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 7, 13, 13, 27, 13, false, 0, 0));
            //FIRESTARTER 8
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 8, 0, 44, 53, 19, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 8, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 8, 45, 45, 95, 46, false, 0, 0));
            //FIRESTARTER 9
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Peaky Blinder", global_data.FIRESTARTERS_FACTION, 9, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Stranglehold", global_data.FIRESTARTERS_FACTION, 9, 0, 79, 96, 35, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 9, 30, 30, 63, 31, false, 0, 0));
            //FIRESTARTER 10
            Current_session.global_parts_list.Add(new_part("Nibbler", global_data.FIRESTARTERS_FACTION, 10, 0, 71, 86, 32, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 10, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 10, 28, 28, 59, 29, false, 0, 0));
            //FIRESTARTER 11
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 11, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 11, 45, 45, 95, 46, false, 0, 0));
            //FIRESTARTER 12
            Current_session.global_parts_list.Add(new_part("Scorched", global_data.FIRESTARTERS_FACTION, 12, 47, 47, 99, 48, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Pipetooth", global_data.FIRESTARTERS_FACTION, 12, 0, 44, 53, 19, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Flaming Rakes", global_data.FIRESTARTERS_FACTION, 12, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Devilry", global_data.FIRESTARTERS_FACTION, 12, 30, 30, 63, 31, false, 0, 0));
            //FIRESTARTER 13
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Downstream", global_data.FIRESTARTERS_FACTION, 13, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Left", global_data.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Cover Your Right", global_data.FIRESTARTERS_FACTION, 13, 15, 15, 32, 15, false, 0, 0));
            //FIRESTARTER 14
            Current_session.global_parts_list.Add(new_part("Boar", global_data.FIRESTARTERS_FACTION, 14, 45, 45, 95, 46, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Stranglehold", global_data.FIRESTARTERS_FACTION, 14, 0, 79, 96, 35, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Rollover", global_data.FIRESTARTERS_FACTION, 14, 28, 28, 59, 29, false, 0, 0));
            //FIRESTARTER 15
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Thorn", global_data.FIRESTARTERS_FACTION, 15, 13, 13, 27, 13, false, 0, 0));
            //FIRESTARTER PRESTIGE
            Current_session.global_parts_list.Add(new_part("The Omen", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 71, 86, 32, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Left Death Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Death Fender", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 19, 19, 48, 13, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Finale", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 56, 56, 135, 44, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Catheter", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 5, 5, 9, 4, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Right Plaster", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Left Plaster", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 15, 15, 32, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bandage", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 26, 26, 54, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bandage", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 26, 26, 54, 26, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Vial", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0.9, 0));
            Current_session.global_parts_list.Add(new_part("Pill", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 17, 17, 36, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Aura", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 22, 22, 45, 22, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Bus Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 51, 51, 108, 53, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 64, 64, 135, 66, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Minivan Panel", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 64, 64, 135, 66, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 20, 24, 14, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Small Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 20, 24, 14, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 40, 48, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Medium Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 40, 48, 28, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Flayer", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 95, 115, 42, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Flayer", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 95, 115, 42, false, 0, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 80, 96, 56, false, 0.25, 0.9));
            Current_session.global_parts_list.Add(new_part("Large Thorn", global_data.PRESTIGUE_PACK_FACTION, global_data.FIRESTARTERS_FACTION, 0, 80, 96, 56, false, 0.25, 0.9));
            //FOUNDERS
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Left", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Hull Right", global_data.FOUNDERS_FACTION, 1, 30, 30, 81, 20, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Left", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Plug Right", global_data.FOUNDERS_FACTION, 1, 14, 14, 36, 9, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Left", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Crane Side Right", global_data.FOUNDERS_FACTION, 1, 120, 120, 323, 79, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Hull", global_data.FOUNDERS_FACTION, 1, 70, 70, 189, 46, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Digger Side", global_data.FOUNDERS_FACTION, 1, 62, 62, 157, 31, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Large Platform", global_data.FOUNDERS_FACTION, 1, 54, 54, 144, 35, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Sloped Platform", global_data.FOUNDERS_FACTION, 1, 24, 24, 63, 15, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Digger Side", global_data.FOUNDERS_FACTION, 1, 37, 37, 99, 24, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, false, 0, 0));
            Current_session.global_parts_list.Add(new_part("Small Platform", global_data.FOUNDERS_FACTION, 1, 27, 27, 72, 18, false, 0, 0));
        }

        #endregion
        #region class_managment
        private static Player new_player()
        {
            Player player = new Player
            {
                nickname = "",
                uid = 0,
                bot = 0,
                in_game = true,
                party_id = 0,
                build_hash = "",
                power_score = 0,
                current_team = 0,
                in_game_stats = new_stats(),
                total_stats = new_stats(),
                category_stats = new Dictionary<int, Stats> { }
            };

            return player;
        }

        public static Part new_part(string desc, int faction, int level, int hull, int part_dura, int mass, int power_score, bool pass_through, double bullet_resist, double melee_resist)
        {
            return new Part
            {
                description = desc,
                faction = faction,
                level = level, 
                hull_durability = hull,
                part_durability = part_dura,
                mass = mass,
                power_score = power_score,
                pass_through = pass_through,
                bullet_resistance = bullet_resist,
                melee_resistance = melee_resist
            };
        }

        private static Stats new_stats()
        {
            return new Stats
            {
                kills = 0,
                assists = 0,
                deaths = 0,
                weapon_strips = 0,
                score = 0,
                damage = 0.0,
                damage_taken = 0.0,
                games = 0,
                wins = 0,
                losses = 0
            };
        }

        private static Stats sum_stats(Stats a, Stats b)
        {
            return new Stats
            {
                games = a.games + 1,
                kills = a.kills + b.kills,
                assists = a.assists + b.assists,
                deaths = a.deaths + b.deaths,
                weapon_strips = a.weapon_strips + b.weapon_strips,
                score = a.score + b.score,
                damage = a.damage + b.damage,
                damage_taken = a.damage_taken + b.damage_taken,
                wins = a.wins + b.wins,
                losses = a.losses + b.losses
            };
        }

        private static MatchRecord new_match_record()
        {
            return new MatchRecord
            {
                start_time = new DateTime { },
                stop_time = new DateTime { },
                build_hash = "",
                rewards = "",
                map_name = "",
                game_result = "",
                power_score = 0,
                match_type = 0,
                team_1 = "",
                team_2 = "",
                local_player_stats = new_stats()
            };
        }

        public static BuildRecord new_build_record()
        {
            BuildRecord build = new BuildRecord
            {
                build_hash = "",
                build_desc = "",
                parts = new List<string> { },
                total_build_stats = new_stats(),
                build_stats = new Dictionary<int, Stats> { }
            };

            return build;
        }

        public FileCompleteResponse new_worker_response()
        {
            return new FileCompleteResponse
            {
                historic_percent_processed = 0.0,
                load_desc = ""
            };
        }
        public FileCompleteResponse new_worker_response(double percent, string str)
        {
            return new FileCompleteResponse
            {
                historic_percent_processed = percent,
                load_desc = str
            };
        }

        public UserProfileResponse new_user_profile(Player local_player, List<MatchRecord> matches, Dictionary<string, BuildRecord> builds)
        {
            return new UserProfileResponse
            {
                local_player_record = local_player,
                match_history = matches,
                build_records = builds
            };
        }
        public MatchHistoryResponse new_match_history_list(List<MatchRecord> match_history)
        {
            return new MatchHistoryResponse
            {
                match_history = match_history
            };
        }

        public MatchEndResponse new_match_end_response(MatchRecord last_match)
        {
            return new MatchEndResponse
            {
                last_match = last_match
            };
        }

        public BuildRecordResponse new_build_record_response(Dictionary<string, BuildRecord> build_dict)
        {
            return new BuildRecordResponse
            {
                build_records = build_dict
            };
        }

        public PartOptResponse new_part_opt_response(List<Part> part_list)
        {
            return new PartOptResponse
            {
                master_list = part_list
            };
        }

        public DebugResponse new_debug_response(int event_id, string line)
        {
            return new DebugResponse
            {
                event_type = event_id,
                line = line
            };
        }

        #endregion
    }
}
