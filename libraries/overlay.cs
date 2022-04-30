using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    public class Overlay
    {
        public const int STAT_CARD_OVERLAY = 1;
        public const int TEAM_PREVIEW_OVERLAY = 2;
        public const int IN_MATCH_OVERLAY = 3;

        public const string line_break      = "-----------------------------------";
        public const string line_break_long = "-----------------------------------";

        public class Overlay_action
        {
            public int overlay { get; set; }
            public List<int> draw_conditions { get; set; }
            public List<int> clear_conditions { get; set; }
        }

        public class Twitch_settings
        {
            public bool endorse_co_driver { get; set; }
            public double overview_time_range { get; set; }
            public double default_time_range { get; set; }
            public bool toggle_overview_time_ranges { get; set; }
            public double damage_update_delay { get; set; }
            public bool show_stats { get; set; }
            public bool show_revenue { get; set; }
            public int nemeisis_count { get; set; }
            public bool show_nemesis { get; set; }
            public bool show_victims { get; set; }
            public bool in_game_kad { get; set; }
            public bool in_game_dmg { get; set; }
            public bool in_game_score { get; set; }
            public bool in_game_victims { get; set; }
            public bool in_game_killer { get; set; }
            public bool toggle_to_last_gamemode { get; set; }
            public string manual_gamemode { get; set; }
            
            [System.ComponentModel.DefaultValue(OverlayWriter.Overlay_Format.txt)]
            public OverlayWriter.Overlay_Format overlay_format { get; set; }
        }
        private class Opponent
        {
            public string nickname;
            public int killed;
            public int been_killed;
        }
        public static List<string> solo_queue_names = new List<string> { "A worthy collection of players.",
                                                                        "The elite of solo queue.",
                                                                        "Crossout's finest.",
                                                                        "Crossout's best and brightest.",
                                                                        "Worthy opponents" };


        public class OverlayWriter
        {
            public enum Overlay_Format
            {
                txt,
                html,
                md
            }

            public Overlay_Format format { get; set; }
            public List<String> lines { get; set; }

            public OverlayWriter(Overlay_Format format)
            {
                this.format = format;
                lines = new List<String>();
            }

            public void Clear()
            {
                lines.Clear();
            }

            public void AddLine(String line, String htmlClass)
            {
                switch (format)
                {
                    case Overlay_Format.txt:
                        lines.Add(line);
                        break;
                    case Overlay_Format.html:
                        lines.Add(string.Format("<p class = \"{1}\">{0}</p>", line, htmlClass));
                        break;
                    case Overlay_Format.md:
                        lines.Add(line + '\\');// we neeed \ at the end of the line for a line break
                        break;
                }
            }

            public void AddHorizontalRow()
            {
                switch (format)
                {
                    case Overlay_Format.txt:
                        lines.Add("-----------------------------------");
                        break;
                    case Overlay_Format.html:
                        lines.Add("<hr>");
                        break;
                    case Overlay_Format.md:
                        lines.Add("---");
                        break;
                }
            }

            public void addEmptyRow()
            {
                switch (format)
                {
                    case Overlay_Format.txt:
                        lines.Add("");
                        break;
                    case Overlay_Format.html:
                        lines.Add("<br>");
                        break;
                    case Overlay_Format.md:
                        lines.Add("\\");
                        break;
                }
            }

            public void AddHeader(String line, String htmlClass)
            {
                switch (format)
                {
                    case Overlay_Format.txt:
                        lines.Add(line);
                        break;
                    case Overlay_Format.html:
                        lines.Add(string.Format("<h3 class = \"{1}\">{0}</h3>", line, htmlClass));
                        break;
                    case Overlay_Format.md:
                        lines.Add("###"+line);
                        break;
                }
            }

            public void WriteToFile(String path)
            {
                List<String> result = new List<String>();
                switch (format)
                {
                    case Overlay_Format.txt:
                        path = path + ".txt";
                        result = lines;
                        break;
                    case Overlay_Format.md:
                        path = path + ".md";
                        result = lines;
                        break;
                    case Overlay_Format.html:
                        result.Add("<!DOCTYPE html><html>");
                        result.Add("<head><meta http-equiv=\"refresh\" content=\"1\"><link rel=\"stylesheet\" href=\""+path+".css\"></head>");//TODO separate config for css file paths for users?
                        result.Add("<body>");
                        result.AddRange(lines);
                        result.Add("</body></html>");

                        path = path + ".html";
                        break;
                }

                if (result.Count > 0)
                {
                    File.WriteAllLines(path, result);
                }
                else
                {
                    File.WriteAllText(path, String.Empty);
                }

            }
        }


        public static string default_overlay_setup()
        {
            return JsonConvert.SerializeObject(new List<Overlay_action> { 
                new Overlay_action { 
                    overlay = STAT_CARD_OVERLAY,
                    draw_conditions = new List<int> {global_data.TEST_DRIVE_EVENT },
                    clear_conditions = new List<int> { global_data.MATCH_START_EVENT, global_data.MAIN_MENU_EVENT } 
                },
                new Overlay_action { 
                    overlay = TEAM_PREVIEW_OVERLAY, 
                    draw_conditions = new List<int> { global_data.PLAYER_LEAVE_EVENT, global_data.LOAD_PLAYER_EVENT }, 
                    clear_conditions = new List<int> { global_data.MAIN_MENU_EVENT } 
                },
                new Overlay_action { 
                    overlay = IN_MATCH_OVERLAY,
                    draw_conditions = new List<int> { global_data.MATCH_START_EVENT, global_data.KILL_EVENT, global_data.ASSIST_EVENT, global_data.DAMAGE_EVENT, global_data.SCORE_EVENT, global_data.STRIPE_EVENT}, 
                    clear_conditions = new List<int> { global_data.TEST_DRIVE_EVENT } 
                }
            });
        }

        public static string default_twitch_settings()
        {
            return JsonConvert.SerializeObject(
                new Twitch_settings { 
                    endorse_co_driver = false,
                    overview_time_range = 7.0,
                    default_time_range  = 7.0,
                    toggle_overview_time_ranges = true,
                    show_stats = true,
                    nemeisis_count = 5,
                    damage_update_delay = 1.0,
                    show_revenue = true,
                    show_nemesis = true,
                    show_victims = true,
                    in_game_kad = true,
                    in_game_dmg = true,
                    in_game_score = true,
                    in_game_killer = true,
                    in_game_victims = true,
                    toggle_to_last_gamemode = true,
                    manual_gamemode = "8v8",
                    overlay_format = OverlayWriter.Overlay_Format.txt
                });
        }

        public static void resolve_overlay_action(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            if (session.twitch_mode != true)
                return;

            if (Current_session.live_trace_data != true)
                return;


            foreach (Overlay_action action in Current_session.overlay_actions)
            {
                bool draw;

                if (action.clear_conditions.Contains(Current_session.current_event))
                    draw = false;
                else if (action.draw_conditions.Contains(Current_session.current_event))
                    draw = true;
                else
                    continue;

                switch (action.overlay)
                {
                    case IN_MATCH_OVERLAY:
                        draw_in_game_recap_card(Current_session, session, translation, draw);
                        break;
                    case STAT_CARD_OVERLAY:
                        draw_stat_card(Current_session, session, translation, draw);
                        break;
                    case TEAM_PREVIEW_OVERLAY:
                        draw_team_preview_card(Current_session, session, translation, draw);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void draw_stat_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(Current_session.twitch_settings.overlay_format);
            if (draw)
            {
                if (Current_session.twitch_settings.show_stats)
                    assign_stats(Current_session, writer, translation,  Current_session.match_history.FirstOrDefault().match_data.match_type_desc);

                if (Current_session.twitch_settings.show_revenue)
                    assign_revenue(Current_session, session, writer, translation);

                if (Current_session.twitch_settings.show_nemesis || Current_session.twitch_settings.show_victims)
                    assign_nemesis_victim(Current_session, writer, translation);

            }
            writer.WriteToFile(Current_session.file_data.stream_overlay_output_location + @"\gamemode_recap_card");
        }

        public static void draw_team_preview_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writerBlue = new OverlayWriter(Current_session.twitch_settings.overlay_format);
            OverlayWriter writerRed = new OverlayWriter(Current_session.twitch_settings.overlay_format);

            if (draw && Current_session.current_match.player_records.Any(x => x.Value.party_id != 0))
            {
                Random random_number = new Random();
                file_trace_managment.MatchData current_match = Current_session.current_match;

                if (!current_match.player_records.ContainsKey(Current_session.local_user_uid))
                    return;

                Dictionary<int, List<string>> blue_teams = new Dictionary<int, List<string>> { };
                Dictionary<int, List<string>> red_teams = new Dictionary<int, List<string>> { };

                blue_teams.Add(current_match.player_records[Current_session.local_user_uid].party_id, new List<string> { current_match.player_records[Current_session.local_user_uid].nickname });

                foreach (KeyValuePair<int, file_trace_managment.Player> player in current_match.player_records.ToList())
                {
                    if (player.Value.party_id == 0 || player.Value.nickname == current_match.player_records[Current_session.local_user_uid].nickname)
                        continue;

                    if (player.Value.team != current_match.player_records[Current_session.local_user_uid].team)
                    {
                        if (!red_teams.ContainsKey(player.Value.party_id))
                            red_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                        else
                            red_teams[player.Value.party_id].Add(player.Value.nickname);
                    }
                    else
                    {
                        if (!blue_teams.ContainsKey(player.Value.party_id))
                            blue_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                        else
                            blue_teams[player.Value.party_id].Add(player.Value.nickname);
                    }
                }

                //TODO separate methods for css purposes
                foreach (KeyValuePair<int, List<string>> team in blue_teams)
                    writerBlue.AddLine(string.Format("{0}", string.Join(",", team.Value)),"player blue_player");

                foreach (KeyValuePair<int, List<string>> team in red_teams)
                    writerRed.AddLine(string.Format("{0}", string.Join(",", team.Value)), "player red_player");

            }
            writerBlue.WriteToFile(Current_session.file_data.stream_overlay_output_location + @"\blue_team_squads");
            writerRed.WriteToFile(Current_session.file_data.stream_overlay_output_location + @"\red_team_squads");
        }

        public static void draw_in_game_recap_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(Current_session.twitch_settings.overlay_format);
            if (draw)
            {
                assign_current_match(Current_session, session, writer, translation);
            }
            writer.WriteToFile(Current_session.file_data.stream_overlay_output_location + @"\in_game_report");
        }

        public static void assign_revenue(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);
            Dictionary<string, int> rewards = new Dictionary<string, int> { };
            
            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.match_start < time_cutoff)
                    continue;

                if (match.match_data.match_rewards.Count() == 0)
                    continue;

                foreach (KeyValuePair<string, int> value in match.match_data.match_rewards.Where(x => !x.Key.Contains("exp") && x.Key != "score"))
                {
                    if (rewards.ContainsKey(value.Key))
                        rewards[value.Key] += value.Value;
                    else
                        rewards.Add(value.Key, value.Value);
                }
            }
            if (rewards.Count > 0)
            {
                writer.addEmptyRow();
                writer.AddHeader("Resource Breakdown", "resource_breakdown");
                writer.AddHorizontalRow();

                foreach (KeyValuePair<string, int> value in rewards.OrderByDescending(x => x.Value))
                {
                    writer.AddLine(string.Format(@"{0,16} {1}", translate.translate_string(value.Key, session, translation), value.Value), "resource_breakdown reward");
                }
            }
        }

        public static void assign_stats(file_trace_managment.SessionStats Current_session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation, string game_mode)
        {
            file_trace_managment.Stats stats = file_trace_managment.new_stats();

            if (Current_session.twitch_settings.toggle_overview_time_ranges)
            {
                if (Current_session.twitch_settings.overview_time_range == 7.0)
                    Current_session.twitch_settings.overview_time_range = 31.0;
                else
                if (Current_session.twitch_settings.overview_time_range == 31.0)
                    Current_session.twitch_settings.overview_time_range = 365.0;
                else
                if (Current_session.twitch_settings.overview_time_range == 365.0)
                    Current_session.twitch_settings.overview_time_range = 1.0;
                else
                if (Current_session.twitch_settings.overview_time_range == 1.0)
                    Current_session.twitch_settings.overview_time_range = 7.0;
            }
            else
            {
                Current_session.twitch_settings.overview_time_range = Current_session.twitch_settings.default_time_range;
            }

            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.match_start < time_cutoff)
                    continue;

                if (match.match_data.match_type_desc != game_mode)
                    continue;

                stats = file_trace_managment.sum_stats(stats, match.match_data.local_player.stats);
            }

            if (stats.games > 0)
            {
                writer.AddHeader(string.Format(@"{0,3} Day Stats for {1}", Current_session.twitch_settings.overview_time_range, game_mode), "day_stats");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16} {1,8}", "Games", stats.games), "day_stats games");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:P1}", "W/L %", string.Format(@"{0,4}/{1,-4}", stats.wins, stats.losses), (double)stats.wins / (double)stats.games), "day_stats win_lose_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:N1}", "K/D  ", string.Format(@"{0,4}/{1,-4}", stats.kills, stats.deaths), (double)stats.kills / (double)stats.deaths), "day_stats kill_death_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:N1}", "K/G  ", string.Format(@"{0,4}/{1,-4}", stats.kills, stats.games), (double)stats.kills / (double)stats.games), "day_stats kill_game_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Dmg", stats.damage / (double)stats.rounds), "day_stats avg_dmg");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Dmg Rec", stats.damage_taken / (double)stats.rounds), "day_stats avg_dmg_rec");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Score", stats.score / (double)stats.rounds), "day_stats avg_score");
            }
        }

        public static void assign_current_match(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {

            if (!Current_session.in_match)
                return;

            file_trace_managment.MatchData current_match = Current_session.current_match;

            if (!current_match.player_records.ContainsKey(Current_session.local_user_uid))
                return;

            if (current_match == null)
                return;

            if (Current_session.twitch_settings.in_game_kad)
            {
                writer.AddHeader(string.Format(@"Current match on {0}", translate.translate_string(current_match.map_name, session, translation)), "current_match");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Kills", current_match.player_records[Current_session.local_user_uid].stats.kills), "current_match kills");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Assists", current_match.player_records[Current_session.local_user_uid].stats.assists), "current_match assists");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Deaths", current_match.player_records[Current_session.local_user_uid].stats.deaths), "current_match deaths");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Drone Kills", current_match.player_records[Current_session.local_user_uid].stats.drone_kills), "current_match drone_kils");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Score", current_match.player_records[Current_session.local_user_uid].stats.score), "current_match score");
            }

            if (Current_session.twitch_settings.in_game_dmg)
            {
                Dictionary<string, double> damage_breakdown = new Dictionary<string, double> { };

                if (current_match.player_records[Current_session.local_user_uid].stats.damage > 0)
                {
                    writer.addEmptyRow();
                    writer.AddHeader("Damage Breakdown", "damage_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.player_records[Current_session.local_user_uid].stats.damage), "damage_breakdown total");

                    foreach (file_trace_managment.DamageRecord record in Current_session.current_match.damage_record.Where(x => x.attacker == Current_session.local_user))
                    {
                        if (damage_breakdown.ContainsKey(record.weapon))
                            damage_breakdown[record.weapon] += record.damage;
                        else
                            damage_breakdown.Add(record.weapon, record.damage);
                    }

                    if (damage_breakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damage_breakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", translate.translate_string(record.Key, session, translation), record.Value), "damage_breakdown weapon");
                        }
                    }
                }

                if (current_match.player_records[Current_session.local_user_uid].stats.damage_taken > 0)
                {
                    damage_breakdown = new Dictionary<string, double> { };
                    writer.addEmptyRow();
                    writer.AddHeader("Damage Recieved Breakdown", "damage_recieved_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.player_records[Current_session.local_user_uid].stats.damage_taken), "damage_recieved_breakdown total");

                    foreach (file_trace_managment.DamageRecord record in Current_session.current_match.damage_record.Where(x => x.victim == Current_session.local_user))
                    {
                        if (damage_breakdown.ContainsKey(record.weapon))
                            damage_breakdown[record.weapon] += record.damage;
                        else
                            damage_breakdown.Add(record.weapon, record.damage);
                    }

                    if (damage_breakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damage_breakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", translate.translate_string(record.Key, session, translation), record.Value), "damage_recieved_breakdown weapon");
                        }
                    }
                }
            }

            if (Current_session.twitch_settings.in_game_victims && current_match.victims.Count > 0)
            {
                writer.addEmptyRow();
                writer.AddHeader("Victims", "victims");
                writer.AddHorizontalRow();
                foreach (string victim in current_match.victims)
                    writer.AddLine(string.Format(@"{0,16}", victim), "victims name");

                if (current_match.player_records[Current_session.local_user_uid].stats.kills - current_match.victims.Count == 1)
                    writer.AddLine(string.Format(@"{0,16}", "Bot"), "victims bot");
                else if (current_match.player_records[Current_session.local_user_uid].stats.kills - current_match.victims.Count > 1)
                    writer.AddLine(string.Format(@"{0,16}{1}", "Bots X", current_match.player_records[Current_session.local_user_uid].stats.kills - current_match.victims.Count), "victims bot");

            }

            if (Current_session.twitch_settings.in_game_killer && current_match.nemesis != "")
            {
                writer.addEmptyRow();
                writer.AddHeader("Killed by", "killed_by");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16}", current_match.nemesis), "killed_by name");
            }
        }

        public static void assign_nemesis_victim(file_trace_managment.SessionStats Current_session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);
            Dictionary<string, Opponent> opponent_dict = new Dictionary<string, Opponent> { };
            int count;

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.match_start < time_cutoff)
                    continue;

                if (match.match_data.match_classification == global_data.CUSTOM_CLASSIFICATION)
                    continue;

                if (match.match_data.nemesis != "")
                {
                    if (!opponent_dict.ContainsKey(match.match_data.nemesis))
                        opponent_dict.Add(match.match_data.nemesis, new Opponent { nickname = match.match_data.nemesis, been_killed = 1, killed = 0 });
                    else
                        opponent_dict[match.match_data.nemesis].been_killed += 1;
                }

                foreach (string victim in match.match_data.victims)
                {
                    if (!opponent_dict.ContainsKey(victim))
                        opponent_dict.Add(victim, new Opponent { nickname = victim, been_killed = 0, killed = 1 });
                    else
                        opponent_dict[victim].killed += 1;
                }
            }

            if (Current_session.twitch_settings.show_nemesis)
            {
                count = 0;
                writer.addEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Nemesis", Current_session.twitch_settings.nemeisis_count), "top_nemesis");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.OrderByDescending(x => x.Value.killed).ThenByDescending(x => x.Value.been_killed))
                {
                    if (count >= Current_session.twitch_settings.nemeisis_count)
                        break;

                    writer.AddLine(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.killed, nemesis.Value.been_killed), "top_nemesis entry"); //TODO add formatted input option for writer with divs for each entry
                    count += 1;
                }
            }

            if (Current_session.twitch_settings.show_victims)
            {
                count = 0;
                writer.addEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Victims", Current_session.twitch_settings.nemeisis_count), "top_victims");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.OrderByDescending(x => x.Value.been_killed).ThenByDescending(x => x.Value.killed))
                {
                    if (count >= Current_session.twitch_settings.nemeisis_count)
                        break;

                    writer.AddLine(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.killed, nemesis.Value.been_killed), "top_victims entry");
                    count += 1;
                }
            }
        }

        public static List<String> endorse_co_driver()
        {
            return new List<String> { "" };
        }

        public static void assign_teams(file_trace_managment.MatchData match, ref string blue_team, ref string red_team)
        {
            blue_team = "";
            Random random_number = new Random();

            if (match.match_classification == global_data.PVE_CLASSIFICATION)
                red_team = "A bunch of robots.";
            else
            if (match.match_classification == global_data.FREE_PLAY_CLASSIFICATION)
                red_team = "The elite of Bedlam.";
            else
                red_team = solo_queue_names[random_number.Next(solo_queue_names.Count())];

            Dictionary<int, List<string>> blue_teams = new Dictionary<int, List<string>> { };
            Dictionary<int, List<string>> red_teams = new Dictionary<int, List<string>> { };

            blue_teams.Add(match.local_player.party_id, new List<string> { match.local_player.nickname });

            foreach (KeyValuePair<int, file_trace_managment.Player> player in match.player_records.ToList())
            {
                if (player.Value.party_id == 0 || player.Value.nickname == match.local_player.nickname)
                    continue;

                if (player.Value.team != match.local_player.team)
                {
                    if (!red_teams.ContainsKey(player.Value.party_id))
                        red_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        red_teams[player.Value.party_id].Add(player.Value.nickname);
                }
                else
                {
                    if (!blue_teams.ContainsKey(player.Value.party_id))
                        blue_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        blue_teams[player.Value.party_id].Add(player.Value.nickname);
                }
            }

            foreach (KeyValuePair<int, List<string>> team in blue_teams)
                blue_team += string.Format("({0})", string.Join(",", team.Value));

            if (red_teams.Count > 0)
                red_team = "";

            foreach (KeyValuePair<int, List<string>> team in red_teams)
                red_team += string.Format("({0})", string.Join(",", team.Value));
        }

    }
}
