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

        public static void ResolveOverlayAction(FileTraceManagment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translation)
        {
            if (session.TwitchMode != true)
                return;

            if (currentSession.LiveTraceData != true)
                return;


            foreach (OverlayAction action in currentSession.OverlayActions)
            {
                bool draw;

                if (action.ClearConditions.Contains(currentSession.CurrentEvent))
                    draw = false;
                else if (action.DrawConditions.Contains(currentSession.CurrentEvent))
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

        public static void DrawStatCard(FileTraceManagment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(currentSession.TwitchSettings.OverlayFormat);
            if (draw)
            {
                if (currentSession.TwitchSettings.ShowStats)
                    AssignStats(currentSession, writer, translation, currentSession.MatchHistory.FirstOrDefault().MatchData.MatchTypeDesc);

                if (currentSession.TwitchSettings.ShowRevenue)
                    AssignRevenue(currentSession, session, writer, translation);

                if (currentSession.TwitchSettings.ShowNemesis || currentSession.TwitchSettings.ShowVictims)
                    AssignNemesisVictim(currentSession, writer, translation);

            }
            writer.WriteToFile(currentSession.FileData.StreamOverlayOutputLocation + @"\gamemode_recap_card");
        }

        public static void DrawTeamPreviewCard(FileTraceManagment.SessionStats currentSession, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translation, bool draw)
        {
            OverlayWriter writerBlue = new OverlayWriter(currentSession.TwitchSettings.OverlayFormat);
            OverlayWriter writerRed = new OverlayWriter(currentSession.TwitchSettings.OverlayFormat);

            if (draw && currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.PartyID != 0))
            {
                Random random_number = new Random();
                FileTraceManagment.MatchData current_match = currentSession.CurrentMatch;

                if (!current_match.PlayerRecords.ContainsKey(currentSession.LocalUserUID))
                    return;

                Dictionary<int, List<string>> blue_teams = new Dictionary<int, List<string>> { };
                Dictionary<int, List<string>> red_teams = new Dictionary<int, List<string>> { };

                blue_teams.Add(current_match.PlayerRecords[currentSession.LocalUserUID].PartyID, new List<string> { current_match.PlayerRecords[currentSession.LocalUserUID].Nickname });

                foreach (KeyValuePair<int, FileTraceManagment.Player> player in current_match.PlayerRecords.ToList())
                {
                    if (player.Value.PartyID == 0 || player.Value.Nickname == current_match.PlayerRecords[currentSession.LocalUserUID].Nickname)
                        continue;

                    if (player.Value.Team != current_match.PlayerRecords[currentSession.LocalUserUID].Team)
                    {
                        if (!red_teams.ContainsKey(player.Value.PartyID))
                            red_teams.Add(player.Value.PartyID, new List<string> { player.Value.Nickname });
                        else
                            red_teams[player.Value.PartyID].Add(player.Value.Nickname);
                    }
                    else
                    {
                        if (!blue_teams.ContainsKey(player.Value.PartyID))
                            blue_teams.Add(player.Value.PartyID, new List<string> { player.Value.Nickname });
                        else
                            blue_teams[player.Value.PartyID].Add(player.Value.Nickname);
                    }
                }

                //TODO separate methods for css purposes
                foreach (KeyValuePair<int, List<string>> team in blue_teams)
                    writerBlue.AddLine(string.Format("{0}", string.Join(",", team.Value)), "player blue_player");

                foreach (KeyValuePair<int, List<string>> team in red_teams)
                    writerRed.AddLine(string.Format("{0}", string.Join(",", team.Value)), "player red_player");

            }
            writerBlue.WriteToFile(currentSession.FileData.StreamOverlayOutputLocation + @"\blue_team_squads");
            writerRed.WriteToFile(currentSession.FileData.StreamOverlayOutputLocation + @"\red_team_squads");
        }

        public static void DrawInGameRecapCard(FileTraceManagment.SessionStats Current_session, LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translation, bool draw)
        {
            OverlayWriter writer = new OverlayWriter(Current_session.TwitchSettings.OverlayFormat);
            if (draw)
            {
                AssignCurrentMatch(Current_session, session, writer, translation);
            }
            writer.WriteToFile(Current_session.FileData.StreamOverlayOutputLocation + @"\in_game_report");
        }

        public static void AssignRevenue(FileTraceManagment.SessionStats Current_session, LogFileManagment.SessionVariables session, OverlayWriter writer, Dictionary<string, Dictionary<string, Translate.Translation>> translation)
        {
            DateTime time_cutoff = DateTime.Now.AddDays(Current_session.TwitchSettings.OverviewTimeRange * -1);
            Dictionary<string, int> rewards = new Dictionary<string, int> { };

            foreach (FileTraceManagment.MatchRecord match in Current_session.MatchHistory)
            {
                if (match.MatchData.MatchStart < time_cutoff)
                    continue;

                if (match.MatchData.MatchRewards.Count() == 0)
                    continue;

                foreach (KeyValuePair<string, int> value in match.MatchData.MatchRewards.Where(x => !x.Key.Contains("exp") && x.Key != "score"))
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
                    writer.AddLine(string.Format(@"{0,16} {1}", Translate.TranslateString(value.Key, session, translation), value.Value), "resource_breakdown reward");
                }
            }
        }

        public static void AssignStats(FileTraceManagment.SessionStats currentSession, OverlayWriter writer, Dictionary<string, Dictionary<string, Translate.Translation>> translation, string game_mode)
        {
            FileTraceManagment.Stats stats = FileTraceManagment.NewStats();

            if (currentSession.TwitchSettings.ToggleOverviewTimeRanges)
            {
                if (currentSession.TwitchSettings.OverviewTimeRange == 7.0)
                    currentSession.TwitchSettings.OverviewTimeRange = 31.0;
                else
                if (currentSession.TwitchSettings.OverviewTimeRange == 31.0)
                    currentSession.TwitchSettings.OverviewTimeRange = 365.0;
                else
                if (currentSession.TwitchSettings.OverviewTimeRange == 365.0)
                    currentSession.TwitchSettings.OverviewTimeRange = 1.0;
                else
                if (currentSession.TwitchSettings.OverviewTimeRange == 1.0)
                    currentSession.TwitchSettings.OverviewTimeRange = 7.0;
            }
            else
            {
                currentSession.TwitchSettings.OverviewTimeRange = currentSession.TwitchSettings.DefaultTimeRange;
            }

            DateTime timeCutoff = DateTime.Now.AddDays(currentSession.TwitchSettings.OverviewTimeRange * -1);

            foreach (FileTraceManagment.MatchRecord match in currentSession.MatchHistory)
            {
                if (match.MatchData.MatchStart < timeCutoff)
                    continue;

                if (match.MatchData.MatchTypeDesc != game_mode)
                    continue;

                stats = FileTraceManagment.SumStats(stats, match.MatchData.LocalPlayer.Stats);
            }

            if (stats.Games > 0)
            {
                writer.AddHeader(string.Format(@"{0,3} Day Stats for {1}", currentSession.TwitchSettings.OverviewTimeRange, game_mode), "day_stats");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16} {1,8}", "Games", stats.Games), "day_stats games");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:P1}", "W/L %", string.Format(@"{0,4}/{1,-4}", stats.Wins, stats.Losses), stats.Wins / (double)stats.Games), "day_stats win_lose_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:N1}", "K/D  ", string.Format(@"{0,4}/{1,-4}", stats.Kills, stats.Deaths), stats.Kills / (double)stats.Deaths), "day_stats kill_death_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8} {2:N1}", "K/G  ", string.Format(@"{0,4}/{1,-4}", stats.Kills, stats.Games), stats.Kills / (double)stats.Games), "day_stats kill_game_ratio");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Dmg", stats.Damage / stats.Rounds), "day_stats avg_dmg");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Dmg Rec", stats.DamageTaken / stats.Rounds), "day_stats avg_dmg_rec");
                writer.AddLine(string.Format(@"{0,16} {1,8:N1}", "Avg Score", stats.Score / (double)stats.Rounds), "day_stats avg_score");
            }
        }

        public static void AssignCurrentMatch(FileTraceManagment.SessionStats currentSession, LogFileManagment.SessionVariables session, OverlayWriter writer, Dictionary<string, Dictionary<string, Translate.Translation>> translation)
        {

            if (!currentSession.InMatch)
                return;

            FileTraceManagment.MatchData current_match = currentSession.CurrentMatch;

            if (!current_match.PlayerRecords.ContainsKey(currentSession.LocalUserUID))
                return;

            if (current_match == null)
                return;

            if (currentSession.TwitchSettings.InGameKD)
            {
                writer.AddHeader(string.Format(@"Current match on {0}", Translate.TranslateString(current_match.MapName, session, translation)), "current_match");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Kills", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Kills), "current_match kills");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Assists", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Assists), "current_match assists");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Deaths", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Deaths), "current_match deaths");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Drone Kills", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.DroneKills), "current_match drone_kils");
                writer.AddLine(string.Format(@"{0,16} {1:N0}", "Score", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Score), "current_match score");
            }

            if (currentSession.TwitchSettings.InGameDamage)
            {
                Dictionary<string, double> damageBreakdown = new Dictionary<string, double> { };

                if (current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Damage > 0)
                {
                    writer.AddEmptyRow();
                    writer.AddHeader("Damage Breakdown", "damage_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Damage), "damage_breakdown total");

                    foreach (FileTraceManagment.DamageRecord record in currentSession.CurrentMatch.DamageRecord.Where(x => x.Attacker == currentSession.LocalUser))
                    {
                        if (damageBreakdown.ContainsKey(record.Weapon))
                            damageBreakdown[record.Weapon] += record.Damage;
                        else
                            damageBreakdown.Add(record.Weapon, record.Damage);
                    }

                    if (damageBreakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damageBreakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", Translate.TranslateString(record.Key, session, translation), record.Value), "damage_breakdown weapon");
                        }
                    }
                }

                if (current_match.PlayerRecords[currentSession.LocalUserUID].Stats.DamageTaken > 0)
                {
                    damageBreakdown = new Dictionary<string, double> { };
                    writer.AddEmptyRow();
                    writer.AddHeader("Damage Recieved Breakdown", "damage_recieved_breakdown");
                    writer.AddHorizontalRow();
                    writer.AddLine(string.Format(@"{0,16} {1:N1}", "Total", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.DamageTaken), "damage_recieved_breakdown total");

                    foreach (FileTraceManagment.DamageRecord record in currentSession.CurrentMatch.DamageRecord.Where(x => x.Victim == currentSession.LocalUser))
                    {
                        if (damageBreakdown.ContainsKey(record.Weapon))
                            damageBreakdown[record.Weapon] += record.Damage;
                        else
                            damageBreakdown.Add(record.Weapon, record.Damage);
                    }

                    if (damageBreakdown.Count > 0)
                    {
                        foreach (KeyValuePair<string, double> record in damageBreakdown)
                        {
                            writer.AddLine(string.Format(@"{0,16} {1:N1}", Translate.TranslateString(record.Key, session, translation), record.Value), "damage_recieved_breakdown weapon");
                        }
                    }
                }
            }

            if (currentSession.TwitchSettings.InGameVictims && current_match.Victims.Count > 0)
            {
                writer.AddEmptyRow();
                writer.AddHeader("Victims", "victims");
                writer.AddHorizontalRow();
                foreach (string victim in current_match.Victims)
                    writer.AddLine(string.Format(@"{0,16}", victim), "victims name");

                if (current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Kills - current_match.Victims.Count == 1)
                    writer.AddLine(string.Format(@"{0,16}", "Bot"), "victims bot");
                else if (current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Kills - current_match.Victims.Count > 1)
                    writer.AddLine(string.Format(@"{0,16}{1}", "Bots X", current_match.PlayerRecords[currentSession.LocalUserUID].Stats.Kills - current_match.Victims.Count), "victims bot");

            }

            if (currentSession.TwitchSettings.InGameKiller && current_match.Nemesis != "")
            {
                writer.AddEmptyRow();
                writer.AddHeader("Killed by", "killed_by");
                writer.AddHorizontalRow();
                writer.AddLine(string.Format(@"{0,16}", current_match.Nemesis), "killed_by name");
            }
        }

        public static void AssignNemesisVictim(FileTraceManagment.SessionStats currentSession, OverlayWriter writer, Dictionary<string, Dictionary<string, Translate.Translation>> translation)
        {
            DateTime timeCutoff = DateTime.Now.AddDays(currentSession.TwitchSettings.OverviewTimeRange * -1);
            Dictionary<string, Opponent> opponentDictionary = new Dictionary<string, Opponent> { };
            int count;

            foreach (FileTraceManagment.MatchRecord match in currentSession.MatchHistory)
            {
                if (match.MatchData.MatchStart < timeCutoff)
                    continue;

                if (match.MatchData.MatchClassification == GlobalData.CUSTOM_CLASSIFICATION)
                    continue;

                if (match.MatchData.Nemesis != "")
                {
                    if (!opponentDictionary.ContainsKey(match.MatchData.Nemesis))
                        opponentDictionary.Add(match.MatchData.Nemesis, new Opponent { Nickname = match.MatchData.Nemesis, BeenKilled = 1, Killed = 0 });
                    else
                        opponentDictionary[match.MatchData.Nemesis].BeenKilled += 1;
                }

                foreach (string victim in match.MatchData.Victims)
                {
                    if (!opponentDictionary.ContainsKey(victim))
                        opponentDictionary.Add(victim, new Opponent { Nickname = victim, BeenKilled = 0, Killed = 1 });
                    else
                        opponentDictionary[victim].Killed += 1;
                }
            }

            if (currentSession.TwitchSettings.ShowNemesis)
            {
                count = 0;
                writer.AddEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Nemesis", currentSession.TwitchSettings.NemesisCount), "top_nemesis");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponentDictionary.OrderByDescending(x => x.Value.Killed).ThenByDescending(x => x.Value.BeenKilled))
                {
                    if (count >= currentSession.TwitchSettings.NemesisCount)
                        break;

                    writer.AddLine(string.Format(@"{0,16} {1,4}/{2,-4}", nemesis.Key, nemesis.Value.Killed, nemesis.Value.BeenKilled), "top_nemesis entry"); //TODO add formatted input option for writer with divs for each entry
                    count += 1;
                }
            }

            if (currentSession.TwitchSettings.ShowVictims)
            {
                count = 0;
                writer.AddEmptyRow();
                writer.AddHeader(string.Format(@"Top {0} Victims", currentSession.TwitchSettings.NemesisCount), "top_victims");
                writer.AddHorizontalRow();
                foreach (KeyValuePair<string, Opponent> nemesis in opponentDictionary.OrderByDescending(x => x.Value.BeenKilled).ThenByDescending(x => x.Value.Killed))
                {
                    if (count >= currentSession.TwitchSettings.NemesisCount)
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

        public static void AssignTeams(FileTraceManagment.MatchData match, ref string blueTeam, ref string redTeam)
        {
            blueTeam = "";
            Random randomNumber = new Random();

            if (match.MatchClassification == GlobalData.PVE_CLASSIFICATION)
                redTeam = "A bunch of robots.";
            else
            if (match.MatchClassification == GlobalData.FREE_PLAY_CLASSIFICATION)
                redTeam = "The elite of Bedlam.";
            else
                redTeam = SoloQueueNames[randomNumber.Next(SoloQueueNames.Count())];

            Dictionary<int, List<string>> blueTeams = new Dictionary<int, List<string>> { };
            Dictionary<int, List<string>> redTeams = new Dictionary<int, List<string>> { };

            blueTeams.Add(match.LocalPlayer.PartyID, new List<string> { match.LocalPlayer.Nickname });

            foreach (KeyValuePair<int, FileTraceManagment.Player> player in match.PlayerRecords.ToList())
            {
                if (player.Value.PartyID == 0 || player.Value.Nickname == match.LocalPlayer.Nickname)
                    continue;

                if (player.Value.Team != match.LocalPlayer.Team)
                {
                    if (!redTeams.ContainsKey(player.Value.PartyID))
                        redTeams.Add(player.Value.PartyID, new List<string> { player.Value.Nickname });
                    else
                        redTeams[player.Value.PartyID].Add(player.Value.Nickname);
                }
                else
                {
                    if (!blueTeams.ContainsKey(player.Value.PartyID))
                        blueTeams.Add(player.Value.PartyID, new List<string> { player.Value.Nickname });
                    else
                        blueTeams[player.Value.PartyID].Add(player.Value.Nickname);
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
