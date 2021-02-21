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
            public List<MatchRecord> match_history { get; set; }
            public Dictionary<string, BuildRecord> build_records { get; set; }
        }

        public class MatchHistoryResponse
        {
            public List<MatchRecord> match_history { get; set; }
        }

        public class MatchEndResponse
        {
            public MatchData last_match { get; set; }
            public BuildRecord last_build { get; set; }
        }
        public class BuildRecordResponse
        {
            public Dictionary<string, BuildRecord> build_records { get; set; }
        }

        public class StaticRecordResponse
        {
            public StaticRecordDB master_static_records { get; set; }
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
            public bool in_garage { get; set; }
            public string local_user { get; set; }
            public int local_user_uid { get; set; }
            public int current_event { get; set; }
            public string client_version { get; set; }
            public MatchData current_match { get; set; }
            public FileData file_data { get; set; }
            public GarageData garage_data { get; set; }
            public Dictionary<string, BuildRecord> player_build_records { get; set; }
            public List<MatchRecord> match_history { get; set; }
            public StaticRecordDB static_records { get; set; }
        }
        public class MatchRecord
        {
            public string team_1 { get; set; }
            public string team_2 { get; set; }
            public MatchData match_data { get; set; }
        }

        public class MatchData
        {
            public string map_name { get; set; }
            public int match_type { get; set; }
            public string match_type_desc { get; set; }
            public int winning_team { get; set; }
            public string game_result { get; set; }
            public string game_play_value { get; set; }
            public string client_version { get; set; }
            public DateTime match_start { get; set; }
            public DateTime match_end { get; set; }
            public double match_duration_seconds { get; set; }
            public string nemesis { get; set; }
            public List<string> victims { get; set; }
            public List<MatchAttribute> match_attributes { get; set; }
            public Dictionary<string, int> match_rewards { get; set; }
            public Player local_player { get; set; }
            public List<DamageRecord> damage_record { get; set; }
            public Dictionary<string, Player> player_records { get; set; }
            
        }

        public class GarageData 
        {
            public DateTime garage_start { get; set; }
            public GarageDamageRecord damage_record { get; set; }
        }

        public class GarageDamageRecord
        {
            public string attacker { get; set; }
            public DateTime time { get; set; }
            public string weapon { get; set; }
            public double damage { get; set; }
            public string flags { get; set; }
        }

        public class DamageRecord
        {
            public string attacker { get; set; }
            public string victim { get; set; }
            public string weapon { get; set; }
            public double damage { get; set; }
        }
        public class Player
        {
            public string nickname { get; set; }
            public int uid { get; set; }
            public int party_id { get; set; }
            public string build_hash { get; set; }
            public int power_score { get; set; }
            public int bot { get; set; }
            public int team { get; set; }
            public Stats stats { get; set; }
            public List<string> stripes { get; set; }
        }

        public class PlayerMatchRecord
        {
            public string nickname { get; set; }
            public int uid { get; set; }
            public int party_id { get; set; }
            public string build_hash { get; set; }
            public int power_score { get; set; }
            public int bot { get; set; }
            public int team { get; set; }
            public Stats stats { get; set; }
            public List<string> stripes { get; set; }
        }

        public class Stats
        {
            public int kills { get; set; }
            public int assists { get; set; }
            public int deaths { get; set; }
            public int drone_kills { get; set; }
            public int score { get; set; }
            public double damage { get; set; }
            public double damage_taken { get; set; }
            public int games { get; set; }
            public int rounds { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
        }
        public class Stripe
        {
            public string description { get; set; }
            public int count { get; set; }
        }
        public class FileData
        {
            public string log_file_location { get; set; }
            public string historic_file_location { get; set; }
            public string stream_overlay_output_location { get; set; }
            public FileInfo processing_combat_session_file { get; set; }
            public FileInfo processing_game_session_file { get; set; }
            public DateTime processing_combat_session_file_day { get; set; }
            public List<LogSession> historic_file_session_list { get; set; }
        }

        public class LogSession
        {
            public bool processed { get; set; }
            public FileInfo combat_log { get; set; }
            public FileInfo game_log { get; set; }
        }

        public class MatchAttribute
        {
            public string attribute { get; set; }
            public string value { get; set; }
        }
        public class BuildRecord
        {
            public string build_hash { get; set; }
            public string full_description { get; set; }
            public string short_description { get; set; }
            public string archetype_description { get; set; }
            public int power_score { get; set; }
            public part_loader.Cabin cabin { get; set; }
            public part_loader.Engine engine { get; set; }
            public List<part_loader.Weapon> weapons { get; set; }
            public List<part_loader.Module> modules { get; set; }
            public List<part_loader.Explosive> explosives { get; set; }
            public List<part_loader.Movement> movement { get; set; }
            public List<string> parts { get; set; }
        }

        public class StaticRecordDB
        {
            public List<part_loader.Part> global_parts_list { get; set; }
            public Dictionary<string, part_loader.Weapon> global_weapon_dict { get; set; }
            public Dictionary<string, part_loader.Cabin> global_cabin_dict { get; set; }
            public Dictionary<string, part_loader.Engine> global_engine_dict { get; set; }
            public Dictionary<string, part_loader.Module> global_module_dict { get; set; }
            public Dictionary<string, part_loader.Explosive> global_explosives_dict { get; set; }
            public Dictionary<string, part_loader.Movement> global_movement_dict { get; set; }
            public Dictionary<string, part_loader.Reward> global_reward_dict { get; set; }
            public List<part_loader.EventTime> global_event_times { get; set; }
        }
        #endregion
        #region session_managment
        public void initialize_session_stats(SessionStats Current_session, log_file_managment.session_variables local_session_variables)
        {
            Current_session.live_trace_data = false;
            Current_session.in_match = false;
            Current_session.in_garage = false;
            Current_session.current_match = new_match_data();
            Current_session.local_user = local_session_variables.local_user_name;
            Current_session.local_user_uid = local_session_variables.local_user_uid;
            Current_session.current_event = 0;
            Current_session.garage_data = new GarageData { };
            Current_session.garage_data.garage_start = new DateTime { };
            Current_session.file_data = new FileData { };
            Current_session.file_data.log_file_location = local_session_variables.log_file_location;
            Current_session.file_data.historic_file_location = local_session_variables.historic_file_location;
            Current_session.file_data.stream_overlay_output_location = local_session_variables.stream_file_location;
            Current_session.file_data.historic_file_session_list = load_historic_file_list(local_session_variables.historic_file_location);
            Current_session.player_build_records = new Dictionary<string, BuildRecord> { };
            Current_session.static_records = new StaticRecordDB { };
            Current_session.static_records.global_parts_list = new List<part_loader.Part> { };
            Current_session.static_records.global_cabin_dict = new Dictionary<string, part_loader.Cabin> { };
            Current_session.static_records.global_engine_dict = new Dictionary<string, part_loader.Engine> { };
            Current_session.static_records.global_explosives_dict = new Dictionary<string, part_loader.Explosive> { };
            Current_session.static_records.global_movement_dict = new Dictionary<string, part_loader.Movement> { };
            Current_session.static_records.global_module_dict = new Dictionary<string, part_loader.Module> { };
            Current_session.static_records.global_weapon_dict = new Dictionary<string, part_loader.Weapon> { };
            Current_session.static_records.global_reward_dict = new Dictionary<string, part_loader.Reward> { };
            Current_session.static_records.global_event_times = new List<part_loader.EventTime> { };
            Current_session.match_history = new List<MatchRecord> { };

            part_loader.populate_global_parts_list(Current_session);
            part_loader.populate_weapon_list(Current_session);
            part_loader.populate_module_list(Current_session);
            part_loader.populate_cabin_list(Current_session);
            part_loader.populate_engine_list(Current_session);
            part_loader.populate_explosive_list(Current_session);
            part_loader.populate_movement_list(Current_session);
            part_loader.populate_reward_list(Current_session);
            part_loader.load_event_schedule(Current_session);
        }

        private List<LogSession> load_historic_file_list(string historic_file_location)
        {
            List<LogSession> temp_list = new List<LogSession> { };
            FileInfo[] files = new DirectoryInfo(historic_file_location).GetFiles("*.*", SearchOption.AllDirectories).Where(s => (s.Name.StartsWith("combat") || s.Name.StartsWith("game")) && s.Name.EndsWith("log")).OrderByDescending(p => p.LastWriteTime).ToArray();

            foreach (FileInfo file in files)
            {
                if (file.Name.Contains("combat"))
                {
                    DateTime combat_time = DateTime.ParseExact(file.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                    for (int i = 0; i < files.Count(); i++)
                    {
                        if (files[i].Name.Contains("game"))
                        {
                            DateTime game_time = DateTime.ParseExact(files[i].Name.Substring(5, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                            if (combat_time.Ticks > game_time.AddMinutes(-1).Ticks && combat_time.Ticks < game_time.AddMinutes(1).Ticks)
                            {
                                temp_list.Add(new_log_session(file, files[i]));
                                break;
                            }
                        }
                    }
                        
                }
            }

            return temp_list;
        }

        public static void assign_current_game_event(string line, SessionStats Current_session)
        {
            int event_id = 0;

            if (line.Substring(0,9) == "--- Date:")
                event_id = global_data.DATE_ASSIGNMENT_EVENT;
            else
            if (line.Contains("expFactionTotal"))
                event_id = global_data.MATCH_REWARD_EVENT;
            else
            if (line.Contains("\"queueTag\"") || line.Contains("\"minUR\"") || line.Contains("\"maxUR\"") || line.Contains("\"botlist\"") || line.Contains("\"custom_game\""))
                event_id = global_data.MATCH_PROPERTY_EVENT;
            else
            if (line.Contains("| client: ADD_PLAYER"))
                event_id = global_data.ADD_PLAYER_EVENT;
            else
            if (line.Contains("| client: UPDATE_PLAYER"))
                event_id = global_data.UPDATE_PLAYER_EVENT;
            else
            if (line.Contains("         | // Build:"))
                event_id = global_data.ASSIGN_CLIENT_VERSION_EVENT;
            else
            if (line.Contains("|      quest "))
                event_id = global_data.QUEST_EVENT;

            Current_session.current_event = event_id;
        }

        public static void assign_current_combat_event(string line, SessionStats Current_session)
        {
            int event_id = 0;

            if (line.Contains("| Damage."))
                event_id = global_data.DAMAGE_EVENT;
            else
            if (line.Contains("| Score:"))
                event_id = global_data.SCORE_EVENT;
            else
            if (line.Contains("| ===== Gameplay '"))
                event_id = global_data.MATCH_START_EVENT;
            else
            if (line.Contains("| 	player"))
                event_id = global_data.LOAD_PLAYER_EVENT;
            else
            if (line.Contains("| Stripe "))
                event_id = global_data.STRIPE_EVENT;
            else
            if (line.Contains("| Kill."))
                event_id = global_data.KILL_EVENT;
            else
            if (line.Contains("| 	 assist by"))
                event_id = global_data.ASSIST_EVENT;
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

        public static void main_menu_event(string line, SessionStats Current_session)
        {
            clear_in_game_stats(Current_session);
            Current_session.in_garage = false;
        }

        public static void test_drive_event(string line, SessionStats Current_session)
        {
            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\|");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.garage_data.garage_start = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_combat_session_file_day.ToString("yyyyMMdd", CultureInfo.CurrentCulture), line_results.Groups["hour"].Value, line_results.Groups["minute"].Value, line_results.Groups["second"].Value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture).AddMilliseconds(Convert.ToDouble(line_results.Groups["milisecond"].Value));
            Current_session.in_garage = true;
        }
        public static void match_start_event(string line, SessionStats Current_session)
        {
            clear_in_game_stats(Current_session);
            Current_session.current_match = new_match_data();

            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| ===== Gameplay '(?<gameplay_type>.+)' started, map '(?<map_name>.+)' ======$");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.current_match.map_name = line_results.Groups["map_name"].Value;
            Current_session.current_match.client_version = Current_session.client_version;
            Current_session.current_match.game_play_value = line_results.Groups["gameplay_type"].Value;
            Current_session.current_match.match_start = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_combat_session_file_day.ToString("yyyyMMdd", CultureInfo.CurrentCulture), line_results.Groups["hour"].Value, line_results.Groups["minute"].Value, line_results.Groups["second"].Value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Current_session.in_match = true;
            Current_session.in_garage = false;
        }

        public static void clan_war_round_end_event(string line, SessionStats Current_session)
        {
            foreach (KeyValuePair<string, Player> entry in Current_session.current_match.player_records)
                entry.Value.stats.rounds = entry.Value.stats.rounds + 1;
        }

        public static void match_end_event(string line, SessionStats Current_session)
        {
            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| ===== Gameplay finish, reason: (?<gameplay_reason>.+), winner team (?<winning_team>[0-9]+), win reason: (?<win_reason>.+), battle time: (?<battle_time>.+?) sec =====$");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.current_match.winning_team = Int32.Parse(line_results.Groups["winning_team"].Value);
            Current_session.current_match.match_duration_seconds = Convert.ToDouble(line_results.Groups["battle_time"].Value);

            clear_in_game_stats(Current_session);
        }

        public static void match_reward_event(string line, SessionStats Current_session)
        {

            //TODO:MAKE THIS SUCK LESS
            Dictionary<string, int> match_rewards = new Dictionary<string, int> { };
            if (line.Contains("expFactionTotal"))
                match_rewards.Add("expFactionTotal", Int32.Parse(Regex.Match(line, @"expFactionTotal (.+?)$").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("expBaseFactionTotal"))
                match_rewards.Add("expBaseFactionTotal", Int32.Parse(Regex.Match(line, @"expBaseFactionTotal (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("ClanMoney"))
                match_rewards.Add("ClanMoney", Int32.Parse(Regex.Match(line, @"ClanMoney (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Scrap_Common"))
                match_rewards.Add("Scrap_Common", Int32.Parse(Regex.Match(line, @"Scrap_Common (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Scrap_Rare"))
                match_rewards.Add("Scrap_Rare", Int32.Parse(Regex.Match(line, @"Scrap_Rare (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Scrap_Epic"))
                match_rewards.Add("Scrap_Epic", Int32.Parse(Regex.Match(line, @"Scrap_Epic (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Accumulators"))
                match_rewards.Add("Accumulators", Int32.Parse(Regex.Match(line, @"Accumulators (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("HalloweenMoney"))
                match_rewards.Add("HalloweenMoney", Int32.Parse(Regex.Match(line, @"HalloweenMoney (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Supply"))
                match_rewards.Add("Supply", Int32.Parse(Regex.Match(line, @"Supply (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("Platinum"))
                match_rewards.Add("Platinum", Int32.Parse(Regex.Match(line, @"Platinum (.+?),").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("NewYearMoney"))
                match_rewards.Add("NewYearMoney", Int32.Parse(Regex.Match(line, @"NewYearMoney (.+?),").Groups[1].Value.Replace(" ", "")));

            Current_session.current_match.match_rewards = match_rewards;
        }

        private static void clear_in_game_stats(SessionStats Current_session)
        {
            if (!Current_session.in_match)
                return;

            Current_session.in_match = false;

            if (!Current_session.current_match.player_records.ContainsKey(Current_session.local_user))
                return;

            if (Current_session.current_match.match_start > Current_session.current_match.match_end)
            {
                Current_session.file_data.processing_combat_session_file_day = Current_session.file_data.processing_combat_session_file_day.AddDays(1.0);
                Current_session.current_match.match_end = Current_session.current_match.match_end.AddDays(1.0);
            }

            classify_match(Current_session);
            classify_local_user_build(Current_session);

            foreach (KeyValuePair<string, Player> entry in Current_session.current_match.player_records)
            {
                entry.Value.stats.games += 1;

                if (entry.Value.team == Current_session.current_match.winning_team)
                    entry.Value.stats.wins += 1;
                else
                    entry.Value.stats.losses += 1;
            }

            finalize_match_record(Current_session);
        }

        private static void classify_match(SessionStats Current_session)
        {
            int player_count = 0;
            int highest_power_score = 0;
            Current_session.current_match.match_type = global_data.UNDEFINED_MATCH;

            foreach (KeyValuePair<string, Player> entry in Current_session.current_match.player_records)
            {
                if (entry.Value.power_score > highest_power_score)
                    highest_power_score = entry.Value.power_score;
            }

            player_count = Current_session.current_match.player_records.Count();

            if ((Current_session.current_match.game_play_value.Contains("Conquer") ||
                 Current_session.current_match.game_play_value.Contains("Domination") ||
                 Current_session.current_match.game_play_value.Contains("Assault")) && player_count == 16)
                Current_session.current_match.match_type = global_data.STANDARD_MATCH;

            if (Current_session.current_match.match_attributes.Where(x => x.attribute.Contains("queueTag") && x.value == "Default").Count() > 0 && 
                (Current_session.current_match.game_play_value.Contains("Conquer") ||
                 Current_session.current_match.game_play_value.Contains("Domination") ||
                 Current_session.current_match.game_play_value.Contains("Assault")) && player_count == 16)
                Current_session.current_match.match_type = global_data.STANDARD_RESTRICTED_MATCH;

            if ((Current_session.current_match.game_play_value.Contains("ConquerCoopVsAi") ||
                 Current_session.current_match.game_play_value.Contains("DominationCoopVsAi") ||
                 Current_session.current_match.game_play_value.Contains("AssaultCoopVsAi")) && player_count == 16)
                Current_session.current_match.match_type = global_data.PATROL_MATCH;

            if (Current_session.current_match.game_play_value.Contains("BestOf3"))
                Current_session.current_match.match_type = global_data.STANDARD_CW_MATCH;

            if (Current_session.current_match.game_play_value.Contains("BestOf3") && highest_power_score > 22000)
                Current_session.current_match.match_type = global_data.LEVIATHIAN_CW_MATCH;

            if (Current_session.current_match.map_name.Contains("red_rocks_battle_royale"))
                Current_session.current_match.match_type = global_data.BATTLE_ROYALE_MATCH;

            if (Current_session.current_match.match_attributes.Where(x => x.attribute.Contains("queueTag") && x.value.ToLower().Contains("pve_easy")).Count() > 0)
                Current_session.current_match.match_type = global_data.EASY_RAID_MATCH;

            if (Current_session.current_match.match_attributes.Where(x => x.attribute.Contains("queueTag") && x.value.ToLower().Contains("pve_medium")).Count() > 0)
                Current_session.current_match.match_type = global_data.MED_RAID_MATCH;

            if (Current_session.current_match.game_play_value.Contains("Pve_Greatescape"))
                Current_session.current_match.match_type = global_data.MED_RAID_MATCH;

            if (Current_session.current_match.match_attributes.Where(x => x.attribute.Contains("queueTag") && x.value.ToLower().Contains("pve_hard")).Count() > 0)
                Current_session.current_match.match_type = global_data.HARD_RAID_MATCH;

            if ((Current_session.current_match.game_play_value.Contains("Conquer") ||
                 Current_session.current_match.game_play_value.Contains("Domination") ||
                 Current_session.current_match.game_play_value.Contains("Assault")) && player_count == 12)
                Current_session.current_match.match_type = global_data.LEAGUE_6_v_6_MATCH;

            if (Current_session.current_match.match_attributes.Where(x => x.attribute.Contains("custom_game")).Count() > 0)
                Current_session.current_match.match_type = global_data.CUSTOM_MATCH;

            if(Current_session.current_match.game_play_value.Contains("FreePlay"))
                Current_session.current_match.match_type = global_data.BEDLAM_MATCH;

            if (Current_session.current_match.game_play_value.Contains("Exploration"))
                Current_session.current_match.match_type = global_data.ADVENTURE_MATCH;

            if (Current_session.current_match.game_play_value.Contains("Brawl_NewYear_Convoy"))
                Current_session.current_match.match_type = global_data.PRESENT_HEIST_MATCH;

            if (Current_session.current_match.game_play_value.Contains("Brawl_AssaultAllCannons"))
                Current_session.current_match.match_type = global_data.CANNON_BRAWL_MATCH;

            if (Current_session.current_match.game_play_value.Contains("Brawl_FieldBattle"))
                Current_session.current_match.match_type = global_data.WINTER_MAYHAM_MATCH;

            //if (Current_session.current_match.match_type == global_data.UNDEFINED_MATCH)
            //    MessageBox.Show(string.Format(@"Unable to define match gameplay:{0} player_count:{1} map:{2}", Current_session.current_match.game_play_value, player_count, Current_session.current_match.map_name));

            Current_session.current_match.match_type_desc = decode_match_type(Current_session.current_match.match_type);
        }

        private static void finalize_match_record(SessionStats Current_session)
        {
            MatchRecord match_record = new_match_record();

            Current_session.current_match.local_player = Current_session.current_match.player_records[Current_session.local_user];
            if (Current_session.current_match.match_type == global_data.BEDLAM_MATCH || Current_session.current_match.match_type == global_data.ADVENTURE_MATCH)
            {
                Current_session.current_match.game_result = "";
            }
            else if (Current_session.current_match.player_records[Current_session.local_user].team == Current_session.current_match.winning_team)
            {
                Current_session.current_match.game_result = "Win";
            }
            else if (Current_session.current_match.winning_team == -1)
            {
                Current_session.current_match.game_result = "Unfinished";
            }
            else
            {
                Current_session.current_match.game_result = "Loss";
            }

            if (Current_session.current_match.match_duration_seconds > 0.1)
            {
                Current_session.current_match.match_end = Current_session.current_match.match_start.AddSeconds(Current_session.current_match.match_duration_seconds);
            }
            else
            {
                Current_session.current_match.match_end = Current_session.current_match.match_end;
            }

            match_record.match_data = Current_session.current_match;
            Current_session.match_history.Add(match_record);
        }

        private static void assign_local_user_build_parts(SessionStats Current_session)
        {
            BuildRecord local_build = Current_session.player_build_records[Current_session.current_match.player_records[Current_session.local_user].build_hash];

            foreach (string part in Current_session.player_build_records[Current_session.current_match.player_records[Current_session.local_user].build_hash].parts)
            {
                if (Current_session.static_records.global_cabin_dict.ContainsKey(part))
                    local_build.cabin = Current_session.static_records.global_cabin_dict[part];
                else
                if (Current_session.static_records.global_engine_dict.ContainsKey(part))
                    local_build.engine = Current_session.static_records.global_engine_dict[part];
                else
                if (Current_session.static_records.global_weapon_dict.ContainsKey(part) && local_build.weapons.Where(x => x.name == part).Count() == 0)
                    local_build.weapons.Add(Current_session.static_records.global_weapon_dict[part]);
                else
                if (Current_session.static_records.global_movement_dict.ContainsKey(part) && local_build.movement.Where(x => x.name == part).Count() == 0)
                    local_build.movement.Add(Current_session.static_records.global_movement_dict[part]);
                else
                if (Current_session.static_records.global_module_dict.ContainsKey(part) && local_build.modules.Where(x => x.name == part).Count() == 0)
                    local_build.modules.Add(Current_session.static_records.global_module_dict[part]);
                else
                if (Current_session.static_records.global_explosives_dict.ContainsKey(part) && local_build.explosives.Where(x => x.name == part).Count() == 0)
                    local_build.explosives.Add(Current_session.static_records.global_explosives_dict[part]);
            }

            Current_session.player_build_records[Current_session.current_match.player_records[Current_session.local_user].build_hash] = local_build;
        }

        public static void assign_client_version_event(string line, SessionStats Current_session)
        {
            Match line_results = Regex.Match(line, @"\| // Build: Crossout x64 (?<client_version>.+)$");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.client_version = line_results.Groups["client_version"].Value;
        }

        public static void load_player_event(string line, SessionStats Current_session)
        {
            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| 	player (?<player_id>.+), uid (?<uid>[0-9]{8}), party (?<party_id>[0-9]{8}), nickname: (?<nickname>.+?), team: (?<team>[0-9]+), bot: (?<bot>[0-9]{1}), ur: (?<power_score>[0-9]+), mmHash: (?<build_hash>.{8})$");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
               return;
            }

            string player_name = line_results.Groups["nickname"].Value.Replace(" ", "");
            string build_hash = line_results.Groups["build_hash"].Value;
            int uid = Int32.Parse(line_results.Groups["uid"].Value);
            int bot = Int32.Parse(line_results.Groups["bot"].Value);
            int party_id = Int32.Parse(line_results.Groups["party_id"].Value);
            int team = Int32.Parse(line_results.Groups["team"].Value);
            int power_score = Int32.Parse(line_results.Groups["power_score"].Value);

            if (Current_session.current_match.player_records.ContainsKey(player_name))
            {
                Current_session.current_match.player_records[player_name].uid = uid;
                Current_session.current_match.player_records[player_name].bot = bot;
                Current_session.current_match.player_records[player_name].party_id = party_id;
                Current_session.current_match.player_records[player_name].build_hash = build_hash;
                Current_session.current_match.player_records[player_name].power_score = power_score;
                Current_session.current_match.player_records[player_name].team = team;
            }
            else
            {
                Player current_player = new_player();
                current_player.nickname = player_name;
                current_player.uid = uid;
                current_player.bot = bot;
                current_player.party_id = party_id;
                current_player.build_hash = build_hash;
                current_player.power_score = power_score;
                current_player.team = team;
                Current_session.current_match.player_records.Add(player_name, current_player);
            }

            if (player_name == Current_session.local_user)
            {
                if (!Current_session.player_build_records.ContainsKey(build_hash))
                {
                    BuildRecord new_build = new_build_record();
                    new_build.build_hash = build_hash;
                    new_build.power_score = power_score;
                    Current_session.player_build_records.Add(build_hash, new_build);
                }
            }
        }

        public static void stripe_event(string line, SessionStats Current_session)
        {
            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| Stripe '(?<stripe>[^']+)' value increased by (?<increment>[^\s]+) for player (?<player_number>[^\s]+) \[(?<player_name>.*)\]");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.current_match.match_end = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_combat_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line_results.Groups["hour"].Value, line_results.Groups["minute"].Value, line_results.Groups["second"].Value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            string stripe_desc = line_results.Groups["stripe"].Value;
            int stripe_increment = Int32.Parse(line_results.Groups["increment"].Value);
            string player_name = line_results.Groups["player_name"].Value;

            if (!Current_session.current_match.player_records.ContainsKey(player_name))
                return;

            if (stripe_desc == "PvpAssist")
            {
                Current_session.current_match.player_records[player_name].stats.assists += 1;
            }

            if (stripe_desc == "PvpTurretKill")
            {
                Current_session.current_match.player_records[player_name].stats.drone_kills += 1;
            }
            Current_session.current_match.player_records[player_name].stripes.Add(stripe_desc);
        }
        public static void damage_event(string line, SessionStats Current_session)
        {
            if (!Current_session.in_match && !Current_session.live_trace_data)
                return;

            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| Damage\. Victim: (?<victim>[^,]+), attacker: (?<attacker>[^,]+), weapon '(?<weapon>[^']+)', damage: (?<damage>[^\s]+) (?<flags>.+)$");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            Current_session.current_match.match_end = DateTime.ParseExact(string.Format("{0}{1}{2}{3}", Current_session.file_data.processing_combat_session_file_day.ToString("yyyyMMdd", CultureInfo.InvariantCulture), line_results.Groups["hour"].Value, line_results.Groups["minute"].Value, line_results.Groups["second"].Value), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            string attacker = line_results.Groups["attacker"].Value.Replace(" ", "");
            string victim = line_results.Groups["victim"].Value.Replace(" ", "");
            double damage = Convert.ToDouble(line_results.Groups["damage"].Value);
            string weapon = line_results.Groups["weapon"].Value;
            string weapon_name = "";
            string flags = line_results.Groups["flags"].Value;
            bool found_damage_record = false;

            weapon = weapon.Substring(0, weapon.IndexOf(':') > 0 ? weapon.IndexOf(':') : weapon.Length);

            if (attacker.IndexOf(":") > 0)
                return;

            if (victim.IndexOf(":") > 0)
                return;

            if (Current_session.static_records.global_weapon_dict.ContainsKey(weapon))
                weapon_name = Current_session.static_records.global_weapon_dict[weapon].description;
            else
            if (Current_session.static_records.global_explosives_dict.ContainsKey(weapon))
                weapon_name = Current_session.static_records.global_explosives_dict[weapon].description;
            else
                weapon_name = "Ramming";

            if (Current_session.in_garage)
            {
                Current_session.garage_data.damage_record = new GarageDamageRecord{ attacker = attacker, time = Current_session.current_match.match_end.AddMilliseconds(Convert.ToDouble(line_results.Groups["milisecond"].Value)), weapon = weapon_name, damage = damage, flags = flags };
                return;
            }

            if (!Current_session.current_match.player_records.ContainsKey(attacker))
                return;

            if (!Current_session.current_match.player_records.ContainsKey(victim))
                return;

            foreach (DamageRecord record in Current_session.current_match.damage_record)
            {
                if (attacker == record.attacker &&
                    victim == record.victim &&
                    weapon_name == record.weapon)
                {
                    found_damage_record = true;
                    record.damage += damage;
                    break;
                }
            }

            if (!found_damage_record)
                Current_session.current_match.damage_record.Add(new DamageRecord { attacker = attacker, victim = victim, weapon = weapon_name, damage = damage });

            if (attacker != victim)
            {
                if (attacker == Current_session.local_user)
                {
                    if (!Current_session.player_build_records[Current_session.current_match.player_records[attacker].build_hash].parts.Contains(weapon) &&
                        !Current_session.static_records.global_explosives_dict.ContainsKey(weapon))
                    {
                        Current_session.player_build_records[Current_session.current_match.player_records[attacker].build_hash].parts.Add(weapon);
                    }
                }

                Current_session.current_match.player_records[attacker].stats.damage += damage;
                Current_session.current_match.player_records[victim].stats.damage_taken += damage;
            }
        }

        public static void kill_event(string line, SessionStats Current_session)
        {
            if (!Current_session.in_match)
                return;

            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| Kill. Victim: (?<victim>.*) killer: (?<killer>.+)");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string killer = line_results.Groups["killer"].Value.Replace(" ", "");
            string victim = line_results.Groups["victim"].Value.Replace(" ", "");

            if (killer.IndexOf(":") > 0)
                return;
            if (victim.IndexOf(":") > 0)
                return;

            if (!Current_session.current_match.player_records.ContainsKey(killer))
                return;

            if (!Current_session.current_match.player_records.ContainsKey(victim))
                return;

            if (killer == Current_session.local_user && Current_session.current_match.player_records[victim].bot == 0)
                Current_session.current_match.victims.Add(victim);

            if (victim == Current_session.local_user && Current_session.current_match.player_records[killer].bot == 0)
                Current_session.current_match.nemesis = killer;

            Current_session.current_match.player_records[killer].stats.kills++;
            Current_session.current_match.player_records[victim].stats.deaths++;
        }

        public static void kill_assist_event(string line, SessionStats Current_session)
        {
        }

        public static void score_event(string line, SessionStats Current_session)
        {
            if (!Current_session.in_match)
                return;

            Match line_results = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<milisecond>[0-9]{3})\| Score:		player: (?<player_number>.+?),		nick:(?<nickname>.*),		Got:(?<score>.+?),		reason: (?<score_reason>.+?)");

            if (line_results.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string scorer = line_results.Groups["nickname"].Value.Replace(" ", "");
            int points = Int32.Parse(line_results.Groups["score"].Value);

            if (!Current_session.current_match.player_records.ContainsKey(scorer))
                return;

            Current_session.current_match.player_records[scorer].stats.score += points;
        }

        
        public static void assign_match_property(string line, SessionStats Current_session)
        {
            if (line.Contains("custom_game"))
                Current_session.current_match.match_attributes.Add(new_match_attribute("custom_game", Regex.Match(line, @": (.+?)$").Groups[1].Value.Replace(" ", "")));
            if (line.Contains("queueTag"))
                Current_session.current_match.match_attributes.Add(new_match_attribute("queueTag", Regex.Match(line, @": (.+?)$").Groups[1].Value.Replace(" ", "")));
        }

        public static string decode_match_type(int match_type)
        {
            switch (match_type)
            {
                case global_data.ALL_MATCHS:
                    return "Total";
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
                case global_data.EASY_RAID_MATCH:
                    return "Easy Raid";
                case global_data.MED_RAID_MATCH:
                    return "Medium Raid";
                case global_data.HARD_RAID_MATCH:
                    return "Hard Raid";
                case global_data.CUSTOM_MATCH:
                    return "Custom Game";
                case global_data.BEDLAM_MATCH:
                    return "Bedlam";
                case global_data.PRESENT_HEIST_MATCH:
                    return "Present Heist";
                case global_data.ADVENTURE_MATCH:
                    return "Adventure";
                case global_data.PATROL_MATCH:
                    return "Patrol";
                case global_data.STANDARD_RESTRICTED_MATCH:
                    return "Restricted 8v8";
                case global_data.CANNON_BRAWL_MATCH:
                    return "Cannon Brawl";
                case global_data.WINTER_MAYHAM_MATCH:
                    return "Winter Mayham";
                case global_data.UNDEFINED_MATCH:
                    return "Undefined";
                default:
                    return match_type.ToString();
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
        private static void classify_local_user_build(SessionStats Current_session)
        {
            string long_description = "";
            string short_description = "";

            assign_local_user_build_parts(Current_session);

            BuildRecord local_build = Current_session.player_build_records[Current_session.current_match.player_records[Current_session.local_user].build_hash];

            //CABIN NAMING
            if (local_build.cabin.description.Length > 0)
            {
                long_description += local_build.cabin.description;
                long_description += " cabin ";
            }

            //WEAPON NAMING
            if (local_build.weapons.Count() == 0)
            {
                long_description += "weaponless build ";
                if (local_build.cabin.description.Length > 0)
                {
                    short_description += local_build.cabin.description;
                }
            }
            else
            if (local_build.weapons.Count() == 1)
            {
                long_description += string.Format(@"{0} ", local_build.weapons[0].description);
                short_description += string.Format(@"{0} ", local_build.weapons[0].description);
            }
            else
            {
                //determine if all weapons are of the same category
                string expected_category = local_build.weapons[0].weapon_class;
                bool class_flag = false;
                foreach (part_loader.Weapon weapon in local_build.weapons)
                {
                    if (weapon.weapon_class != expected_category)
                        class_flag = true;
                }
                if (class_flag == false)
                {
                    List<part_loader.Weapon> sorted_weapons = local_build.weapons.OrderByDescending(x => x.rarity).ToList();
                    foreach (part_loader.Weapon weapon in sorted_weapons)
                    {
                        long_description += string.Format(@"{0} ", weapon.description);
                    }
                    short_description += string.Format(@"{0} ", local_build.weapons[0].weapon_class);
                }
                else
                {
                    //order weapon names correctly for builds with mixed weapons
                    List<part_loader.Weapon> sorted_weapons = local_build.weapons.OrderByDescending(x => x.rarity).ToList();
                    List<part_loader.Weapon> sorted_supports = new List<part_loader.Weapon>();
                    foreach (part_loader.Weapon weapon in sorted_weapons)
                    {
                        if (weapon.weapon_class == "tesla emitter" || weapon.weapon_class == "drone" || weapon.weapon_class == "turret"
                            || weapon.weapon_class == "harpoon" || weapon.weapon_class == "explosive melee" || weapon.weapon_class == "laser minigun")
                        {
                            sorted_supports.Add(weapon);
                        }
                        else
                        {
                            long_description += string.Format(@"{0} ", weapon.description);
                            short_description += string.Format(@"{0} ", weapon.description);
                        }
                    }
                    foreach (part_loader.Weapon weapon in sorted_supports)
                    {
                        long_description += string.Format(@"{0} ", weapon.description);
                    }
                }
            }

            //MOVEMENT PART NAMING
            if (local_build.movement.Count() == 0)
            {
                long_description += "";
            }
            else
            if (local_build.movement.Count() == 1)
            {
                long_description += string.Format(@"on {0}s ", local_build.movement[0].description);
                short_description += string.Format(@"on {0}s ", local_build.movement[0].description);
            }
            else
            {
                long_description += "on ";
                int movement_count = 1;
                foreach (part_loader.Movement movement in local_build.movement) //long description stuff
                {
                    long_description += movement.description;
                    if (movement_count < local_build.movement.Count() - 1)
                    {
                        long_description += ", ";
                    }
                    else
                    if (movement_count < local_build.movement.Count())
                    {
                        long_description += " and ";
                    }
                    else
                    {
                        long_description += " ";
                    }
                    movement_count++;
                }
                string expected_category = local_build.movement[0].category; //short description stuff
                bool class_flag = false;
                foreach (part_loader.Movement movement in local_build.movement)
                {
                    if (movement.category != expected_category)
                    {
                        class_flag = true;
                    }
                }
                if (class_flag == false)
                {
                    short_description += local_build.movement[0].category;
                }
                else
                {
                    string short_movement_desc = "";
                    if (local_build.movement.Select(x => x.category.Contains("wheel")).Count() > 0)
                    {
                        short_movement_desc = "wheels";
                    }
                    if (local_build.movement.Select(x => x.category.Contains("track")).Count() > 0)
                    {
                        short_movement_desc = "tracks";
                    }
                    if (local_build.movement.Select(x => x.category == "auger").Count() > 0)
                    {
                        short_movement_desc = "augers";
                    }
                    if (local_build.movement.Select(x => x.category == "hover").Count() > 0)
                    {
                        short_movement_desc = "hovers";
                    }
                    if (local_build.movement.Select(x => x.description == "Bigram").Count() > 0)
                    {
                        if (local_build.movement.Select(x => x.category.Contains("wheel")).Count() > 0)
                        {
                            short_movement_desc = "wheels";
                        }
                        else
                        {
                            short_movement_desc = "legs";
                        }
                    }
                    if (local_build.movement.Select(x => x.description == "ML 200").Count() > 0)
                    {
                        short_movement_desc = "legs";
                    }
                    short_description += short_movement_desc;
                }

            }

            //MODULE NAMING
            if (local_build.modules.Count() == 0)
            {
                long_description += "";
            }
            else
            {
                long_description += "with ";
                int module_count = 1;
                foreach (part_loader.Module module in local_build.modules)
                {
                    if (module.module_class != "connector" && module.name != "CarPart_ModuleRadio")
                    {
                        long_description += module.description;
                        if (module_count < local_build.modules.Count() - 1)
                        {
                            long_description += ", ";
                        }
                        else
                        if (module_count < local_build.modules.Count())
                        {
                            long_description += " and ";
                        }
                        else
                        {
                            long_description += " ";
                        }
                    }
                    module_count++;
                }
            }
            //ENGINE NAMING
            if (local_build.engine.description == "")
            {
                long_description += "";
            }
            else
            {
                if (local_build.modules.Count() == 0)
                {
                    long_description += "with ";
                }
                else
                {
                    long_description += "and ";
                }
                long_description += local_build.engine.description;
                long_description += " engine";
            }

            local_build.archetype_description = "";
            local_build.full_description = long_description;
            local_build.short_description = short_description;
            Current_session.player_build_records[Current_session.current_match.player_records[Current_session.local_user].build_hash] = local_build;
        }

        public static void generate_stat_card(SessionStats Current_session)
        {
            if (!Current_session.current_match.player_records.ContainsKey(Current_session.local_user))
                return;

            int game_mode = global_data.STANDARD_MATCH;
            int total_wins;
            int total_losses;
            int total_games;
            double total_damage;
            int total_kills;
            int total_deaths;

            total_wins = 0;
            total_losses = 0;
            total_games = 0;

            if (total_games == 0)
                return;

            total_damage = 0;
            total_kills = 0;
            total_deaths = 0;

            List<String> lines = new List<String> { };

            lines.Add(String.Format(" {0} STATS", decode_match_type(game_mode)));
            lines.Add(String.Format("---------------------------------"));
            lines.Add(String.Format(" Games            {0,15}", total_games));
            lines.Add(String.Format(" W/L (%)         {0,4}/{1,-4} ({2,4:N2})", total_wins, total_losses, (double)total_wins / (double)total_games));
            lines.Add(String.Format(" K/D (%)         {0,4}/{1,-4} ({2,4:N2})", total_kills, total_deaths, (double)total_kills / (double)total_deaths));
            lines.Add(String.Format(" K/G (%)         {0,4}/{1,-4} ({2,4:N2})", total_kills, total_games, (double)total_kills / (double)total_games));
            lines.Add(String.Format(" Avg Dmg          {0,15:N1}", total_damage / total_games));

            //File.WriteAllLines(Current_session.file_data.stat_card_file, lines);
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
                party_id = 0,
                build_hash = "",
                power_score = 0,
                team = 0,
                stats = new_stats(),
                stripes = new List<string> { }
            };

            return player;
        }

        private static PlayerMatchRecord assign_match_player_record(Player player)
        {
            return new PlayerMatchRecord
            {
                nickname = player.nickname,
                uid = player.uid,
                bot = player.bot,
                party_id = player.party_id,
                build_hash = player.build_hash,
                power_score = player.power_score,
                team = player.team,
                stats = player.stats,
                stripes = player.stripes
            };
        }

        private static LogSession new_log_session( FileInfo combat, FileInfo game)
        {
            return new LogSession
            {
                processed = false,
                combat_log = combat,
                game_log = game
            };
        }

        public static Stats new_stats()
        {
            return new Stats
            {
                kills = 0,
                assists = 0,
                deaths = 0,
                drone_kills = 0,
                score = 0,
                damage = 0.0,
                damage_taken = 0.0,
                games = 0,
                rounds = 1,
                wins = 0,
                losses = 0
            };
        }

        private static Stripe new_stripe(string desc, int count)
        {
            return new Stripe
            {
                description = desc,
                count = count
            };
        }

        public static Stats sum_stats(Stats a, Stats b)
        {
            return new Stats
            {
                games = a.games + b.games,
                rounds = a.rounds + b.rounds,
                kills = a.kills + b.kills,
                assists = a.assists + b.assists,
                deaths = a.deaths + b.deaths,
                drone_kills = a.drone_kills + b.drone_kills,
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
                team_1 = "",
                team_2 = "",
                match_data = new_match_data()
            };
        }

        public static MatchData new_match_data()
        {
            return new MatchData
            {
                map_name = "",
                match_type = global_data.UNDEFINED_MATCH,
                match_type_desc = "",
                winning_team = -1,
                game_result = "",
                game_play_value = "",
                client_version = "UNDEFINED_CLIENT_VERSION",
                match_start = new DateTime { },
                match_end = new DateTime { },
                match_duration_seconds = 0.0,
                nemesis = "",
                victims = new List<string> { },
                match_attributes = new List<MatchAttribute> { },
                match_rewards = new Dictionary<string, int> { },
                local_player = new_player(),
                damage_record = new List<DamageRecord> { },
                player_records = new Dictionary<string, Player> { }
            };
        }

        public static BuildRecord new_build_record()
        {
            BuildRecord build = new BuildRecord
            {
                build_hash = "",
                full_description = "",
                short_description = "",
                archetype_description = "",
                power_score = 0,
                cabin = part_loader.new_cabin(),
                engine = part_loader.new_engine(),
                weapons = new List<part_loader.Weapon> { },
                modules = new List<part_loader.Module> { },
                movement = new List<part_loader.Movement> { },
                explosives = new List<part_loader.Explosive> { },
                parts = new List<string> { }
            };

            return build;
        }

        public static MatchAttribute new_match_attribute(string attribute, string value)
        {
            return new MatchAttribute
            {
                attribute = attribute,
                value = value
            };
        }

        public static MatchAttribute new_match_attribute()
        {
            return new MatchAttribute
            {
                attribute = "",
                value = ""
            };
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

        public UserProfileResponse new_user_profile(List<MatchRecord> matches, Dictionary<string, BuildRecord> builds)
        {
            return new UserProfileResponse
            {
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

        public MatchEndResponse new_match_end_response(MatchData last_match, BuildRecord last_build)
        {
            return new MatchEndResponse
            {
                last_match = last_match,
                last_build = last_build
            };
        }

        public BuildRecordResponse new_build_record_response(Dictionary<string, BuildRecord> build_dict)
        {
            return new BuildRecordResponse
            {
                build_records = build_dict
            };
        }

        public StaticRecordResponse new_static_element_response(StaticRecordDB part_list)
        {
            return new StaticRecordResponse
            {
                 master_static_records = part_list
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
