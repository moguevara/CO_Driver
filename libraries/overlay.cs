using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    public class overlay
    {
        public const int MATCH_END_CONDITION = 1;
        public const int MAIN_MENU_CONDITION = 2;
        public const int GARAGE_START_CONDITION = 3;
        public const int PLAYER_LOAD_CONDITION = 4;
        public const int DAMAGE_CONDITION = 5;
        public const int DAMAGE_REC_CONDITION = 6;
        public const int SCORE_CONDITION = 7;

        public const int STAT_CARD_OVERLAY = 1;
        public const int TEAM_PREVIEW_OVERLAY = 2;
        public const int IN_MATCH_OVERLAY = 3;
        public const int MATCH_RECAP_OVERLAY = 4;
        public const int GARAGE_DAMAGE_OVERLAY = 5;

        public class overlay_action
        {
            public int overlay { get; set; }
            public List<int> draw_conditions { get; set; }
            public List<int> clear_conditions { get; set; }
        }

        public class twitch_settings
        {
            public bool endorse_co_driver { get; set; }
            public double overview_time_range { get; set; }
            public bool show_stats { get; set; }
            public bool show_revenue { get; set; }
            public int nemeisis_count { get; set; }
            public bool show_nemesis { get; set; }
            public bool show_victims { get; set; }
            public bool toggle_to_last_gamemode { get; set; }
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
                                                                        "Worthy opponents"};

        public static string default_overlay_setup()
        {
            return JsonConvert.SerializeObject(new List<overlay_action> { new overlay_action { overlay = STAT_CARD_OVERLAY, draw_conditions = new List<int> { MATCH_END_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = TEAM_PREVIEW_OVERLAY, draw_conditions = new List<int> { PLAYER_LOAD_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = GARAGE_DAMAGE_OVERLAY, draw_conditions = new List<int> { GARAGE_START_CONDITION, DAMAGE_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = MATCH_RECAP_OVERLAY, draw_conditions = new List<int> { GARAGE_START_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = MATCH_RECAP_OVERLAY, draw_conditions = new List<int> { GARAGE_START_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } }
                                                                        });
        }

        public static string default_twitch_settings()
        {
            return JsonConvert.SerializeObject(new twitch_settings { endorse_co_driver = false,
                                                                     overview_time_range = 7.0,
                                                                     show_stats = true,
                                                                     nemeisis_count = 5,
                                                                     show_revenue = true,
                                                                     show_nemesis = true,
                                                                     show_victims = true,
                                                                     toggle_to_last_gamemode = true
                                                                    });
        }

        public void resolve_overlay_action(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, int condition)
        {
            if (session.twitch_mode != true)
                return;

            if (Current_session.live_trace_data != true)
                return;

            foreach (overlay_action action in Current_session.overlay_actions)
            {
                if (action.draw_conditions.Contains(condition))
                {
                    switch (condition)
                    {
                        case STAT_CARD_OVERLAY:
                            draw_stat_card(Current_session, session, true);
                            break;
                        case TEAM_PREVIEW_OVERLAY:
                            draw_team_preview_card(Current_session, session, true);
                            break;
                        case GARAGE_DAMAGE_OVERLAY:
                            draw_damage_record_card(Current_session, session, true);
                            break;
                        case MATCH_RECAP_OVERLAY:
                            draw_match_recap_card(Current_session, session, true);
                            break;
                        default:
                            break;
                    }
                }

                if (action.clear_conditions.Contains(condition))
                {
                    switch (condition)
                    {
                        case STAT_CARD_OVERLAY:
                            draw_stat_card(Current_session, session, false);
                            break;
                        case TEAM_PREVIEW_OVERLAY:
                            draw_team_preview_card(Current_session, session, false);
                            break;
                        case GARAGE_DAMAGE_OVERLAY:
                            draw_damage_record_card(Current_session, session, false);
                            break;
                        case MATCH_RECAP_OVERLAY:
                            draw_match_recap_card(Current_session, session, false);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void draw_stat_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {
                if (Current_session.twitch_settings.show_stats)
                    lines.AddRange(assign_stats(Current_session, Current_session.match_history.FirstOrDefault().match_data.gameplay_desc));

                if (Current_session.twitch_settings.show_revenue)
                    lines.AddRange(assign_revenue(Current_session));

                if (Current_session.twitch_settings.show_nemesis || Current_session.twitch_settings.show_victims)
                    lines.AddRange(assign_nemesis_victim(Current_session));
            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\gamemode_statistics_card.txt", lines);
        }

        public void draw_team_preview_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> blue_lines = new List<String> { };
            List<String> red_lines = new List<String> { };

            if (draw)
            {
                string blue_team = "";
                string red_team = "";

                assign_teams(Current_session.current_match, ref blue_team, ref red_team);
                blue_lines.Add(blue_team);
                red_lines.Add(red_team);
            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\blue_team_squads.txt", blue_lines);
            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\red_team_squads.txt", red_lines);
        }

        

        public void draw_damage_record_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {
                lines.Add(string.Format(@"Garage Feed"));
                lines.Add(string.Format(@"----------------------"));
            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\gamemode_statistics_card.txt", lines);
        }

        public void draw_match_recap_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {
                lines.AddRange(assign_post_match(Current_session));
            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\last_match_recap.txt", lines);
        }

        public void draw_in_game_recap_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {
                lines.Add(string.Format(@"In Game Feed"));
                lines.Add(string.Format(@"----------------------"));
            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\in_game_report.txt", lines);
        }

        public static List<String> assign_revenue(file_trace_managment.SessionStats Current_session)
        {
            List<String> lines = new List<String> { };
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);
            Dictionary<string, int> rewards = new Dictionary<string, int> { };
            

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.match_start < time_cutoff)
                    continue;

                if (match.match_data.match_rewards.Count() == 0)
                    continue;

                foreach (KeyValuePair<string, int> value in match.match_data.match_rewards)
                {
                    if (rewards.ContainsKey(value.Key))
                        rewards[value.Key] += value.Value;
                    else
                        rewards.Add(value.Key, value.Value);
                }
            }

            foreach (KeyValuePair<string, int> value in rewards.OrderByDescending(x => x.Value))
            {
                lines.Add(string.Format(@"{0,15} {1}", value.Key, value.Value));
            }

            return lines;
        }

        public static List<String> assign_stats(file_trace_managment.SessionStats Current_session, string game_mode)
        {
            List<String> lines = new List<String> { };
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);
            file_trace_managment.Stats stats = file_trace_managment.new_stats();


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
                lines.Add(string.Format(@"{0,3} Day Stats for {1}", Current_session.twitch_settings.overview_time_range, game_mode));
                lines.Add(string.Format(@"{0,16} {1}", "Games", stats.games));
                lines.Add(string.Format(@"{0,16} {1,4}/{2,-4} ({3:P1})", "W/L (%)", stats.wins, stats.losses, (double)stats.wins / (double)stats.losses));
                lines.Add(string.Format(@"{0,16} {1,4}/{2,-4} ({3:P1})", "K/D (%)", stats.kills, stats.deaths, (double)stats.kills / (double)stats.deaths));
                lines.Add(string.Format(@"{0,16} {1,4}/{2,-4} ({3:P1})", "K/G (%)", stats.kills, stats.games, (double)stats.kills / (double)stats.games));
                lines.Add(string.Format(@"{0,16} {1:N1}", "Avg Dmg", stats.damage / (double)stats.rounds));
                lines.Add(string.Format(@"{0,16} {1:N1}", "Avg Dmg Rec", stats.damage_taken / (double)stats.rounds));
                lines.Add(string.Format(@"{0,16} {1:N1}", "Avg Score", stats.score / (double)stats.rounds));
            }

            return lines;
        }

        public static List<String> assign_post_match(file_trace_managment.SessionStats Current_session)
        {
            List<String> lines = new List<String> { };
            file_trace_managment.MatchRecord last_match = Current_session.match_history.LastOrDefault();
            Dictionary<string, double> damage_breakdown = new Dictionary<string, double> { };

            if (last_match == null)
                return lines;

            lines.Add(string.Format(@"Last Match"));
            lines.Add(string.Format(@"{0} {1} at {2}", last_match.match_data.match_type_desc, last_match.match_data.game_result, last_match.match_data.match_start.ToString("g")));
            lines.Add(string.Format(@"{0,12} {1}", "Kills", last_match.match_data.local_player.stats.kills));
            lines.Add(string.Format(@"{0,12} {1}", "Assists", last_match.match_data.local_player.stats.assists));
            lines.Add(string.Format(@"{0,12} {1}", "Deaths", last_match.match_data.local_player.stats.deaths));
            lines.Add(string.Format(@"{0,12} {1}", "Drone Kills", last_match.match_data.local_player.stats.drone_kills));
            lines.Add(string.Format(@"{0,12} {1}", "Damage", last_match.match_data.local_player.stats.damage));
            lines.Add(string.Format(@"{0,12} {1}", "Damage Taken", last_match.match_data.local_player.stats.damage_taken));

            if (last_match.match_data.damage_record.Any(x => x.attacker == last_match.match_data.local_player.nickname))
            {
                lines.Add("");
                lines.Add("Weapon Breakdown");

                foreach (file_trace_managment.DamageRecord record in last_match.match_data.damage_record.Where(x => x.attacker == last_match.match_data.local_player.nickname))
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
                        lines.Add(string.Format(@"{0,12} {1:N1}", record.Key, record.Value));
                    }
                }
            }

            return lines;
        }

        public static List<String> assign_nemesis_victim(file_trace_managment.SessionStats Current_session)
        {
            List<String> lines = new List<String> { };
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.overview_time_range * -1);
            Dictionary<string, Opponent> opponent_dict = new Dictionary<string, Opponent> { };
            int count;

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.match_start < time_cutoff)
                    continue;

                if (match.match_data.match_classification != global_data.CUSTOM_CLASSIFICATION)
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
                foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.OrderByDescending(x => x.Value.killed).ThenByDescending(x => x.Value.been_killed))
                {
                    if (count >= Current_session.twitch_settings.nemeisis_count)
                        break;

                    lines.Add(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.killed, nemesis.Value.been_killed));
                }
            }

            if (Current_session.twitch_settings.show_victims)
            {
                count = 0;
                foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.OrderByDescending(x => x.Value.been_killed).ThenByDescending(x => x.Value.killed))
                {
                    if (count >= Current_session.twitch_settings.nemeisis_count)
                        break;

                    lines.Add(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.killed, nemesis.Value.been_killed));
                }
            }

            return lines;
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

            foreach (KeyValuePair<string, file_trace_managment.Player> player in match.player_records.ToList())
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
