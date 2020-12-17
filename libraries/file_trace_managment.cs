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
            public List<part_loader.Part> master_list { get; set; }
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
            public string current_game_play_value { get; set; }
            public bool add_match_to_record { get; set; }
            public DateTime current_match_start { get; set; }
            public DateTime current_match_end { get; set; }
            public FileData file_data { get; set; }
            public Dictionary<string, Player> player_records { get; set; }
            public Dictionary<string, BuildRecord> player_build_records { get; set; }
            public List<part_loader.Part> global_parts_list { get; set; }
            public List<part_loader.Weapon> global_weapon_list { get; set; }
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

       

        #endregion
        #region session_managment
        public void initialize_session_stats(SessionStats Current_session)
        {
            Current_session.live_trace_data = false;
            Current_session.in_match = false;
            Current_session.current_match_type = global_data.UNDEFINED_MATCH;
            Current_session.current_game_play_value = "";
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
            Current_session.global_parts_list = new List<part_loader.Part> { };
            Current_session.global_weapon_list = new List<part_loader.Weapon> { };
            Current_session.match_history = new List<MatchRecord> { };

            part_loader.populate_global_parts_list(Current_session);
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

            Current_session.current_game_play_value = game_play;

            


            clear_in_game_stats(-1, Current_session); /* sum results if game unfinished */
            Current_session.current_match_start = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line.Substring(0, 2), line.Substring(3, 2), line.Substring(6, 2)), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        }

        private static void clear_in_game_stats(int winning_team, SessionStats Current_session)
        {
            classify_match(Current_session);

            if (Current_session.player_records[Current_session.local_user].in_game == true)
            {
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

        private static void classify_match(SessionStats Current_session)
        {
            int player_count = 0;
            int highest_power_score = 0;
            Current_session.current_match_type = global_data.UNDEFINED_MATCH;

            foreach (KeyValuePair<string, Player> entry in Current_session.player_records)
            {
                if (entry.Value.in_game)
                {
                    player_count++;
                    if (entry.Value.power_score > highest_power_score)
                        highest_power_score = entry.Value.power_score;
                }
            }

            if (Current_session.current_game_play_value.Contains("BestOf3"))
            {
                Current_session.current_match_type = global_data.STANDARD_CW_MATCH;
            }
            else
            if (Current_session.map_name.Contains("red_rocks_battle_royale"))
            {
                Current_session.current_match_type = global_data.BATTLE_ROYALE_MATCH;
            }
            else
            if ((Current_session.current_game_play_value.Contains("Conquer") ||
                 Current_session.current_game_play_value.Contains("Domination") ||
                 Current_session.current_game_play_value.Contains("Assault")))
            {
                Current_session.current_match_type = global_data.STANDARD_MATCH;
            }

            if (player_count == 16)
                Current_session.current_match_type = global_data.LEAGUE_6_v_6_MATCH;

            if (Current_session.current_match_type == global_data.STANDARD_CW_MATCH && highest_power_score > 22000)
                Current_session.current_match_type = global_data.LEVIATHIAN_CW_MATCH;
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

        public string decode_faction_name(int faction)
        {
            switch (faction)
            {
                case global_data.ENGINEER_FACTION:
                    return "Engineers";
                case global_data.LUNATICS_FACTION:
                    return "Lunatics";
                case global_data.NOMADS_FACTION:
                    return "Nomads";
                case global_data.SCAVENGERS_FACTION:
                    return "Scavengers";
                case global_data.STEPPENWOLFS_FACTION:
                    return "Steppenwolfs";
                case global_data.DAWNS_CHILDREN_FACTION:
                    return "Dawns Children";
                case global_data.FIRESTARTERS_FACTION:
                    return "Firestarters";
                case global_data.FOUNDERS_FACTION:
                    return "Founders";
                default:
                    return "Undefined";
            }
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

        public PartOptResponse new_part_opt_response(List<part_loader.Part> part_list)
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
