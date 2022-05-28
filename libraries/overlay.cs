using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace CO_Driver
{
    public class Overlay
    {
        public const int STAT_CARD_OVERLAY = 1;
        public const int TEAM_PREVIEW_OVERLAY = 2;
        public const int IN_MATCH_OVERLAY = 3;

        public const string LineBreak = "-----------------------------------";
        public const string LineBreakLong = "-----------------------------------";

        public class OverlayAction
        {
            public int Overlay { get; set; }
            public List<int> DrawConditions { get; set; }
            public List<int> ClearConditions { get; set; }
        }

        public class TwitchSettings
        {
            public bool EndorseCODriver { get; set; }
            public double OverviewTimeRange { get; set; }
            public double DefaultTimeRange { get; set; }
            public bool ToggleOverviewTimeRanges { get; set; }
            public double DamageUpdateDelay { get; set; }
            public bool ShowStats { get; set; }
            public bool ShowRevenue { get; set; }
            public int NemesisCount { get; set; }
            public bool ShowNemesis { get; set; }
            public bool ShowVictims { get; set; }
            public bool InGameKD { get; set; }
            public bool InGameDamage { get; set; }
            public bool InGameScore { get; set; }
            public bool InGameVictims { get; set; }
            public bool InGameKiller { get; set; }
            public bool ToggleToLastGameMode { get; set; }
            public string ManualGameMode { get; set; }

            [System.ComponentModel.DefaultValue(OverlayWriter.OverlayFormat.txt)]
            public OverlayWriter.OverlayFormat OverlayFormat { get; set; }
        }
        private class Opponent
        {
            public string Nickname;
            public int Killed;
            public int BeenKilled;
        }
        public static List<string> SoloQueueNames = new List<string> { "A worthy collection of players.",
                                                                        "The elite of solo queue.",
                                                                        "Crossout's finest.",
                                                                        "Crossout's best and brightest.",
                                                                        "Worthy opponents" };


        public class OverlayWriter
        {
            public enum OverlayFormat
            {
                txt,
                html,
                md
            }

            public OverlayFormat Format { get; set; }
            public List<String> Lines { get; set; }

            public OverlayWriter(OverlayFormat format)
            {
                this.Format = format;
                Lines = new List<String>();
            }

            public void Clear()
            {
                Lines.Clear();
            }

            public void AddLine(String line, String htmlClass)
            {
                switch (Format)
                {
                    case OverlayFormat.txt:
                        Lines.Add(line);
                        break;
                    case OverlayFormat.html:
                        Lines.Add(string.Format("<p class = \"{1}\">{0}</p>", line, htmlClass));
                        break;
                    case OverlayFormat.md:
                        Lines.Add(line + '\\');// we neeed \ at the end of the line for a line break
                        break;
                }
            }

            public void AddHorizontalRow()
            {
                switch (Format)
                {
                    case OverlayFormat.txt:
                        Lines.Add("-----------------------------------");
                        break;
                    case OverlayFormat.html:
                        Lines.Add("<hr>");
                        break;
                    case OverlayFormat.md:
                        Lines.Add("---");
                        break;
                }
            }

            public void AddEmptyRow()
            {
                switch (Format)
                {
                    case OverlayFormat.txt:
                        Lines.Add("");
                        break;
                    case OverlayFormat.html:
                        Lines.Add("<br>");
                        break;
                    case OverlayFormat.md:
                        Lines.Add("\\");
                        break;
                }
            }

            public void AddHeader(String line, String htmlClass)
            {
                switch (Format)
                {
                    case OverlayFormat.txt:
                        Lines.Add(line);
                        break;
                    case OverlayFormat.html:
                        Lines.Add(string.Format("<h3 class = \"{1}\">{0}</h3>", line, htmlClass));
                        break;
                    case OverlayFormat.md:
                        Lines.Add("###" + line);
                        break;
                }
            }

            public void WriteToFile(String path)
            {
                List<String> result = new List<String>();
                switch (Format)
                {
                    case OverlayFormat.txt:
                        path = path + ".txt";
                        result = Lines;
                        break;
                    case OverlayFormat.md:
                        path = path + ".md";
                        result = Lines;
                        break;
                    case OverlayFormat.html:
                        result.Add("<!DOCTYPE html><html>");
                        result.Add("<head><meta http-equiv=\"refresh\" content=\"1\"><link rel=\"stylesheet\" href=\"" + path + ".css\"></head>");//TODO separate config for css file paths for users?
                        result.Add("<body>");
                        result.AddRange(Lines);
                        result.Add("</body></html>");

                        path = path + ".html";
                        break;
                }

                if (result.Count > 0)
                {
                    WithRetry(() => File.WriteAllLines(path, result));
                }
                else
                {
                    WithRetry(() => File.WriteAllText(path, String.Empty));
                }

            }
        }

        private static void WithRetry(Action action, int timeoutMs = 5000)
        {
            var time = Stopwatch.StartNew();
            while (time.ElapsedMilliseconds < timeoutMs)
            {
                try
                {
                    action();
                    return;
                }
                catch (IOException) { }
                catch (Exception)
                {
                    throw;
                }
                Thread.Sleep(10);
            }
            return;
        }

        public static string DefaultOverlaySetup()
        {
            return JsonConvert.SerializeObject(new List<OverlayAction> {
                new OverlayAction {
                    Overlay = STAT_CARD_OVERLAY,
                    DrawConditions = new List<int> {GlobalData.TEST_DRIVE_EVENT },
                    ClearConditions = new List<int> { GlobalData.MATCH_START_EVENT, GlobalData.MAIN_MENU_EVENT }
                },
                new OverlayAction {
                    Overlay = TEAM_PREVIEW_OVERLAY,
                    DrawConditions = new List<int> { GlobalData.PLAYER_LEAVE_EVENT, GlobalData.LOAD_PLAYER_EVENT },
                    ClearConditions = new List<int> { GlobalData.MAIN_MENU_EVENT }
                },
                new OverlayAction {
                    Overlay = IN_MATCH_OVERLAY,
                    DrawConditions = new List<int> { GlobalData.MATCH_START_EVENT, GlobalData.KILL_EVENT, GlobalData.ASSIST_EVENT, GlobalData.DAMAGE_EVENT, GlobalData.SCORE_EVENT, GlobalData.STRIPE_EVENT},
                    ClearConditions = new List<int> { GlobalData.TEST_DRIVE_EVENT }
                }
            });
        }

        public static string DefaultTwitchSettings()
        {
            return JsonConvert.SerializeObject(
                new TwitchSettings
                {
                    EndorseCODriver = false,
                    OverviewTimeRange = 7.0,
                    DefaultTimeRange = 7.0,
                    ToggleOverviewTimeRanges = true,
                    ShowStats = true,
                    NemesisCount = 5,
                    DamageUpdateDelay = 1.0,
                    ShowRevenue = true,
                    ShowNemesis = true,
                    ShowVictims = true,
                    InGameKD = true,
                    InGameDamage = true,
                    InGameScore = true,
                    InGameKiller = true,
                    InGameVictims = true,
                    ToggleToLastGameMode = true,
                    ManualGameMode = "8v8",
                    OverlayFormat = OverlayWriter.OverlayFormat.txt
                });
        }

        public static void ResolveOverlayAction(file_trace_managment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            if (session.TwitchMode != true)
                return;

            if (currentSession.live_trace_data != true)
                return;


            foreach (OverlayAction action in currentSession.overlay_actions)
            {
                bool draw;

                if (action.ClearConditions.Contains(currentSession.current_event))
                    draw = false;
                else if (action.DrawConditions.Contains(currentSession.current_event))
                    draw = true;
                else
                    continue;

                switch (action.Overlay)
                {
                    case IN_MATCH_OVERLAY:
                        DrawInGameRecapCard(currentSession, session, translation, draw);
                        break;
                    case STAT_CARD_OVERLAY:
                        DrawStatCard(currentSession, session, translation, draw);
                        break;
                    case TEAM_PREVIEW_OVERLAY:
                        DrawTeamPreviewCard(currentSession, session, translation, draw);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void DrawStatCard(file_trace_managment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(currentSession.twitch_settings.OverlayFormat);
            if (draw)
            {
                if (currentSession.twitch_settings.ShowStats)
                    AssignStats(currentSession, writer, translation, currentSession.match_history.FirstOrDefault().match_data.match_type_desc);

                if (currentSession.twitch_settings.ShowRevenue)
                    AssignRevenue(currentSession, session, writer, translation);

                if (currentSession.twitch_settings.ShowNemesis || currentSession.twitch_settings.ShowVictims)
                    AssignNemesisVictim(currentSession, writer, translation);

            }
            writer.WriteToFile(currentSession.file_data.stream_overlay_output_location + @"\gamemode_recap_card");
        }

        public static void DrawTeamPreviewCard(file_trace_managment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writerBlue = new OverlayWriter(currentSession.twitch_settings.OverlayFormat);
            OverlayWriter writerRed = new OverlayWriter(currentSession.twitch_settings.OverlayFormat);

            if (draw && currentSession.current_match.player_records.Any(x => x.Value.party_id != 0))
            {
                Random random_number = new Random();
                file_trace_managment.MatchData current_match = currentSession.current_match;

                if (!current_match.player_records.ContainsKey(currentSession.local_user_uid))
                    return;

                Dictionary<int, List<string>> blue_teams = new Dictionary<int, List<string>> { };
                Dictionary<int, List<string>> red_teams = new Dictionary<int, List<string>> { };

                blue_teams.Add(current_match.player_records[currentSession.local_user_uid].party_id, new List<string> { current_match.player_records[currentSession.local_user_uid].nickname });

                foreach (KeyValuePair<int, file_trace_managment.Player> player in current_match.player_records.ToList())
                {
                    if (player.Value.party_id == 0 || player.Value.nickname == current_match.player_records[currentSession.local_user_uid].nickname)
                        continue;

                    if (player.Value.team != current_match.player_records[currentSession.local_user_uid].team)
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
                    writerBlue.AddLine(string.Format("{0}", string.Join(",", team.Value)), "player blue_player");

                foreach (KeyValuePair<int, List<string>> team in red_teams)
                    writerRed.AddLine(string.Format("{0}", string.Join(",", team.Value)), "player red_player");

            }
            writerBlue.WriteToFile(currentSession.file_data.stream_overlay_output_location + @"\blue_team_squads");
            writerRed.WriteToFile(currentSession.file_data.stream_overlay_output_location + @"\red_team_squads");
        }

        public static void DrawInGameRecapCard(file_trace_managment.SessionStats Current_session, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(Current_session.twitch_settings.OverlayFormat);
            if (draw)
            {
                AssignCurrentMatch(Current_session, session, writer, translation);
            }
            writer.WriteToFile(Current_session.file_data.stream_overlay_output_location + @"\in_game_report");
        }

        public static void AssignRevenue(file_trace_managment.SessionStats Current_session, LogFileManagment.SessionVariables session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.twitch_settings.OverviewTimeRange * -1);
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
                writer.AddEmptyRow();
                writer.AddHeader("Resource Breakdown", "resource_breakdown");
                writer.AddHorizontalRow();

                foreach (KeyValuePair<string, int> value in rewards.OrderByDescending(x => x.Value))
                {
                    writer.AddLine(string.Format(@"{0,16} {1}", translate.translate_string(value.Key, session, translation), value.Value), "resource_breakdown reward");
                }
            }
        }

        public static void AssignStats(file_trace_managment.SessionStats currentSession, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation, string game_mode)
        {
            file_trace_managment.Stats stats = file_trace_managment.new_stats();

            if (currentSession.twitch_settings.ToggleOverviewTimeRanges)
            {
                if (currentSession.twitch_settings.OverviewTimeRange == 7.0)
                    currentSession.twitch_settings.OverviewTimeRange = 31.0;
                else
                if (currentSession.twitch_settings.OverviewTimeRange == 31.0)
                    currentSession.twitch_settings.OverviewTimeRange = 365.0;
                else
                if (currentSession.twitch_settings.OverviewTimeRange == 365.0)
                    currentSession.twitch_settings.OverviewTimeRange = 1.0;
                else
                if (currentSession.twitch_settings.OverviewTimeRange == 1.0)
                    currentSession.twitch_settings.OverviewTimeRange = 7.0;
            }
            else
            {
                currentSession.twitch_settings.OverviewTimeRange = currentSession.twitch_settings.DefaultTimeRange;
            }

            DateTime timeCutoff = DateTime.Now.AddDays(currentSession.twitch_settings.OverviewTimeRange * -1);

            foreach (file_trace_managment.MatchRecord match in currentSession.match_history)
            {
                if (match.match_data.match_start < timeCutoff)
                    continue;

                if (match.match_data.match_type_desc != game_mode)
                    continue;

                stats = file_trace_managment.sum_stats(stats, match.match_data.local_player.stats);
            }

            if (stats.games > 0)
            {
                writer.AddHeader(string.Format(@"{0,3} Day Stats for {1}", currentSession.twitch_settings.OverviewTimeRange, game_mode), "day_stats");
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

        public static void AssignCurrentMatch(file_trace_managment.SessionStats currentSession, LogFileManagment.SessionVariables session, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {

            if (!currentSession.in_match)
                return;

            file_trace_managment.MatchData current_match = currentSession.current_match;

            if (!current_match.player_records.ContainsKey(currentSession.local_user_uid))
                return;

            if (current_match == null)
                return;

            if (currentSession.twitch_settings.InGameKD)
            {
                writer.AddHeader(string.Format(@"Current match on {0}", translate.translate_string(current_match.map_name, session, translation)), "current_match");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Kills", current_match.player_records[currentSession.local_user_uid].stats.kills), "current_match kills");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Assists", current_match.player_records[currentSession.local_user_uid].stats.assists), "current_match assists");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Deaths", current_match.player_records[currentSession.local_user_uid].stats.deaths), "current_match deaths");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Drone Kills", current_match.player_records[currentSession.local_user_uid].stats.drone_kills), "current_match drone_kils");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Score", current_match.player_records[currentSession.local_user_uid].stats.score), "current_match score");
            }

            if (currentSession.twitch_settings.InGameDamage)
            {
                Dictionary<string, double> damageBreakdown = new Dictionary<string, double> { };

                if (current_match.player_records[currentSession.local_user_uid].stats.damage > 0)
                {
                    writer.AddEmptyRow();
                    writer.AddHeader("Damage Breakdown", "damage_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.player_records[currentSession.local_user_uid].stats.damage), "damage_breakdown total");

                    foreach (file_trace_managment.DamageRecord record in currentSession.current_match.damage_record.Where(x => x.attacker == currentSession.local_user))
                    {
                        if (damageBreakdown.ContainsKey(record.weapon))
                            damageBreakdown[record.weapon] += record.damage;
                        else
                            damageBreakdown.Add(record.weapon, record.damage);
                    }

                    if (damageBreakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damageBreakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", translate.translate_string(record.Key, session, translation), record.Value), "damage_breakdown weapon");
                        }
                    }
                }

                if (current_match.player_records[currentSession.local_user_uid].stats.damage_taken > 0)
                {
                    damageBreakdown = new Dictionary<string, double> { };
                    writer.AddEmptyRow();
                    writer.AddHeader("Damage Recieved Breakdown", "damage_recieved_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.player_records[currentSession.local_user_uid].stats.damage_taken), "damage_recieved_breakdown total");

                    foreach (file_trace_managment.DamageRecord record in currentSession.current_match.damage_record.Where(x => x.victim == currentSession.local_user))
                    {
                        if (damageBreakdown.ContainsKey(record.weapon))
                            damageBreakdown[record.weapon] += record.damage;
                        else
                            damageBreakdown.Add(record.weapon, record.damage);
                    }

                    if (damageBreakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damageBreakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", translate.translate_string(record.Key, session, translation), record.Value), "damage_recieved_breakdown weapon");
                        }
                    }
                }
            }

            if (currentSession.twitch_settings.InGameVictims && current_match.victims.Count > 0)
            {
                writer.AddEmptyRow();
                writer.AddHeader("Victims", "victims");
                writer.AddHorizontalRow();
                foreach (string victim in current_match.victims)
                    writer.AddLine(string.Format(@"{0,16}", victim), "victims name");

                if (current_match.player_records[currentSession.local_user_uid].stats.kills - current_match.victims.Count == 1)
                    writer.AddLine(string.Format(@"{0,16}", "Bot"), "victims bot");
                else if (current_match.player_records[currentSession.local_user_uid].stats.kills - current_match.victims.Count > 1)
                    writer.AddLine(string.Format(@"{0,16}{1}", "Bots X", current_match.player_records[currentSession.local_user_uid].stats.kills - current_match.victims.Count), "victims bot");

            }

            if (currentSession.twitch_settings.InGameKiller && current_match.nemesis != "")
            {
                writer.AddEmptyRow();
                writer.AddHeader("Killed by", "killed_by");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16}", current_match.nemesis), "killed_by name");
            }
        }

        public static void AssignNemesisVictim(file_trace_managment.SessionStats currentSession, OverlayWriter writer, Dictionary<string, Dictionary<string, translate.Translation>> translation)
        {
            DateTime timeCutoff = DateTime.Now.AddDays(currentSession.twitch_settings.OverviewTimeRange * -1);
            Dictionary<string, Opponent> opponentDictionary = new Dictionary<string, Opponent> { };
            int count;

            foreach (file_trace_managment.MatchRecord match in currentSession.match_history)
            {
                if (match.match_data.match_start < timeCutoff)
                    continue;

                if (match.match_data.match_classification == GlobalData.CUSTOM_CLASSIFICATION)
                    continue;

                if (match.match_data.nemesis != "")
                {
                    if (!opponentDictionary.ContainsKey(match.match_data.nemesis))
                        opponentDictionary.Add(match.match_data.nemesis, new Opponent { Nickname = match.match_data.nemesis, BeenKilled = 1, Killed = 0 });
                    else
                        opponentDictionary[match.match_data.nemesis].BeenKilled += 1;
                }

                foreach (string victim in match.match_data.victims)
                {
                    if (!opponentDictionary.ContainsKey(victim))
                        opponentDictionary.Add(victim, new Opponent { Nickname = victim, BeenKilled = 0, Killed = 1 });
                    else
                        opponentDictionary[victim].Killed += 1;
                }
            }

            if (currentSession.twitch_settings.ShowNemesis)
            {
                count = 0;
                writer.AddEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Nemesis", currentSession.twitch_settings.NemesisCount), "top_nemesis");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponentDictionary.OrderByDescending(x => x.Value.Killed).ThenByDescending(x => x.Value.BeenKilled))
                {
                    if (count >= currentSession.twitch_settings.NemesisCount)
                        break;

                    writer.AddLine(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.Killed, nemesis.Value.BeenKilled), "top_nemesis entry"); //TODO add formatted input option for writer with divs for each entry
                    count += 1;
                }
            }

            if (currentSession.twitch_settings.ShowVictims)
            {
                count = 0;
                writer.AddEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Victims", currentSession.twitch_settings.NemesisCount), "top_victims");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponentDictionary.OrderByDescending(x => x.Value.BeenKilled).ThenByDescending(x => x.Value.Killed))
                {
                    if (count >= currentSession.twitch_settings.NemesisCount)
                        break;

                    writer.AddLine(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.Killed, nemesis.Value.BeenKilled), "top_victims entry");
                    count += 1;
                }
            }
        }

        public static List<String> EndorseCODriver()
        {
            return new List<String> { "" };
        }

        public static void AssignTeams(file_trace_managment.MatchData match, ref string blueTeam, ref string redTeam)
        {
            blueTeam = "";
            Random randomNumber = new Random();

            if (match.match_classification == GlobalData.PVE_CLASSIFICATION)
                redTeam = "A bunch of robots.";
            else
            if (match.match_classification == GlobalData.FREE_PLAY_CLASSIFICATION)
                redTeam = "The elite of Bedlam.";
            else
                redTeam = SoloQueueNames[randomNumber.Next(SoloQueueNames.Count())];

            Dictionary<int, List<string>> blueTeams = new Dictionary<int, List<string>> { };
            Dictionary<int, List<string>> redTeams = new Dictionary<int, List<string>> { };

            blueTeams.Add(match.local_player.party_id, new List<string> { match.local_player.nickname });

            foreach (KeyValuePair<int, file_trace_managment.Player> player in match.player_records.ToList())
            {
                if (player.Value.party_id == 0 || player.Value.nickname == match.local_player.nickname)
                    continue;

                if (player.Value.team != match.local_player.team)
                {
                    if (!redTeams.ContainsKey(player.Value.party_id))
                        redTeams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        redTeams[player.Value.party_id].Add(player.Value.nickname);
                }
                else
                {
                    if (!blueTeams.ContainsKey(player.Value.party_id))
                        blueTeams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        blueTeams[player.Value.party_id].Add(player.Value.nickname);
                }
            }

            foreach (KeyValuePair<int, List<string>> team in blueTeams)
                blueTeam += string.Format("({0})", string.Join(",", team.Value));

            if (redTeams.Count > 0)
                redTeam = "";

            foreach (KeyValuePair<int, List<string>> team in redTeams)
                redTeam += string.Format("({0})", string.Join(",", team.Value));
        }

    }
}
