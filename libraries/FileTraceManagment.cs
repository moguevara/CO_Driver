
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CO_Driver
{
    public class FileTraceManagment
    {
        #region response_classes
        public class FileCompleteResponse
        {
            public double HistoricPercentProcessed { get; set; }
            public string LoadDesc { get; set; }
        }
        public class UserProfileResponse
        {
            public List<MatchRecord> MatchHistory { get; set; }
            public Dictionary<string, BuildRecord> BuildRecords { get; set; }
        }

        public class MatchHistoryResponse
        {
            public List<MatchRecord> MatchHistory { get; set; }
        }

        public class MatchEndResponse
        {
            public MatchData LastMatch { get; set; }
            public BuildRecord LastBuild { get; set; }
        }
        public class BuildRecordResponse
        {
            public Dictionary<string, BuildRecord> BuildRecords { get; set; }
        }

        public class StaticRecordResponse
        {
            public StaticRecordDB MasterStaticRecords { get; set; }
        }

        public class DebugResponse
        {
            public int EventType { get; set; }
            public string Line { get; set; }
        }

        #endregion
        #region session_classes
        public class SessionStats
        {
            public bool LiveTraceData { get; set; }
            public bool InMatch { get; set; }
            public bool InGarage { get; set; }
            public string LocalUser { get; set; }
            public int LocalUserUID { get; set; }
            public int CurrentEvent { get; set; }
            public string ClientVersion { get; set; }
            public string ClientLanguage { get; set; }
            public bool CundleDamageIntoRamming { get; set; }
            public DateTime QueueStartTime { get; set; }
            public DateTime CurrentCombatLogTime { get; set; }
            public DateTime CurrentGameLogTime { get; set; }
            public DateTime PreviousCombatLogTime { get; set; }
            public DateTime PreviousGameLogTime { get; set; }
            public DateTime LastCombatLogTimeInMatch { get; set; }
            public DateTime LastDamageDraw { get; set; }
            public int CurrentCombatLogDayOffset { get; set; }
            public int CurrentGameLogDayOffset { get; set; }
            public int PreviousCombatEvent { get; set; }
            public int PreviousGameEvent { get; set; }
            public bool ReadyToAddRound { get; set; }
            public bool ReadyToFinalizeRound { get; set; }
            public List<Overlay.OverlayAction> OverlayActions { get; set; }
            public Overlay.TwitchSettings TwitchSettings { get; set; }
            public MatchData CurrentMatch { get; set; }
            public FileData FileData { get; set; }
            public GarageData GarageData { get; set; }
            public PendingMatchAttributes PendingAttributes { get; set; }
            public Dictionary<string, BuildRecord> PlayerBuildRecords { get; set; }
            public List<MatchRecord> MatchHistory { get; set; }
            public StaticRecordDB StaticRecords { get; set; }
        }

        public class PendingMatchAttributes
        {
            public long ServerGUID { get; set; }
            public long ClientGUID { get; set; }
            public string ServerIP { get; set; }
            public string ServerPort { get; set; }
            public string HostName { get; set; }
            public List<MatchAttribute> Attributes { get; set; }
        }
        public class MatchRecord
        {
            public string Team1 { get; set; }
            public string Team2 { get; set; }
            public MatchData MatchData { get; set; }
        }

        public class MatchData
        {
            public string MapName { get; set; }
            public string MapDesc { get; set; }
            public int MatchType { get; set; }
            public int MatchClassification { get; set; }
            public long ServerGUID { get; set; }
            public long ClientGUID { get; set; }
            public string ServerIP { get; set; }
            public string ServerPort { get; set; }
            public string HostName { get; set; }
            public string MatchTypeDesc { get; set; }
            public string GameplayDesc { get; set; }
            public int WinningTeam { get; set; }
            public string WinReason { get; set; }
            public string GameResult { get; set; }
            public string GamePlayValue { get; set; }
            public int RoundWinner { get; set; }
            public string RoundWinReason { get; set; }
            public DateTime RoundStartTime { get; set; }
            public DateTime RoundEndTime { get; set; }
            public int RoundCount { get; set; }
            public string ClientVersion { get; set; }
            public DateTime MatchStart { get; set; }
            public DateTime MatchEnd { get; set; }
            public DateTime QueueStart { get; set; }
            public DateTime QueueEnd { get; set; }
            public double MatchDurationSeconds { get; set; }
            public List<string> Victims { get; set; }
            public List<MatchAttribute> MatchAttributes { get; set; }
            public Dictionary<string, int> MatchRewards { get; set; }
            public bool PremiumReward { get; set; }
            public Player LocalPlayer { get; set; }
            public string Nemesis { get; set; }
            public AssistTracking AssistTracking { get; set; }
            public List<DamageRecord> DamageRecord { get; set; }
            public Dictionary<int, Player> PlayerRecords { get; set; }
            public List<RoundRecord> RoundRecords { get; set; }
        }

        public class RoundRecord
        {
            public int Round { get; set; }
            public int WinningTeam { get; set; }
            public string WinReason { get; set; }
            public DateTime RoundStart { get; set; }
            public DateTime RoundEnd { get; set; }
            public List<Player> Players { get; set; }
            public List<RoundDamageRecord> DamageRecords { get; set; }

        }

        public class AssistTracking
        {
            public string Killer { get; set; }
            public string Victim { get; set; }
            public List<string> Assisters { get; set; }
        }
        public class GarageData
        {
            public DateTime GarageStart { get; set; }
            public GarageDamageRecord DamageRecord { get; set; }
        }

        public class GarageDamageRecord
        {
            public string Attacker { get; set; }
            public DateTime Time { get; set; }
            public string Weapon { get; set; }
            public double Damage { get; set; }
            public string Flags { get; set; }
        }

        public class DamageRecord
        {
            public string Attacker { get; set; }
            public string Victim { get; set; }
            public string Weapon { get; set; }
            public double Damage { get; set; }
        }

        public class RoundDamageRecord
        {
            public string Attacker { get; set; }
            public string Weapon { get; set; }
            public double Damage { get; set; }
        }
        public class Player
        {
            public string Nickname { get; set; }
            public int UID { get; set; }
            public int PartyID { get; set; }
            public int SpawnPosition { get; set; }
            public int Round { get; set; }
            public string BuildHash { get; set; }
            public int PowerScore { get; set; }
            public int Bot { get; set; }
            public int Team { get; set; }
            public Stats Stats { get; set; }
            public List<Score> Scores { get; set; }
            public List<string> Stripes { get; set; }
        }

        public class Stats
        {
            public int Kills { get; set; }
            public int Assists { get; set; }
            public int Deaths { get; set; }
            public int DroneKills { get; set; }
            public int Score { get; set; }
            public double Damage { get; set; }
            public double DamageTaken { get; set; }
            public double CabinDamage { get; set; }
            public int Games { get; set; }
            public int Rounds { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }
        }
        public class Stripe
        {
            public string Description { get; set; }
            public int Count { get; set; }
        }

        public class Score
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Points { get; set; }
        }
        public class FileData
        {
            public string LogFileLocation { get; set; }
            public string HistoricFileLocation { get; set; }
            public string StreamOverlayOutputLocation { get; set; }
            public FileInfo ProcessingCombatSessionFile { get; set; }
            public FileInfo ProcessingGameSessionFile { get; set; }
            public DateTime ProcessingCombatSessionFileDay { get; set; }
            public List<LogSession> HistoricFileSessionList { get; set; }
        }
        public class LogSession
        {
            public bool Processed { get; set; }
            public FileInfo CombatLog { get; set; }
            public FileInfo GameLog { get; set; }
        }

        public class MatchAttribute
        {
            public string Attribute { get; set; }
            public string Value { get; set; }
        }
        public class BuildRecord
        {
            public string BuildHash { get; set; }
            public string FullDescription { get; set; }
            public string ShortDescription { get; set; }
            public string ArchetypeDescription { get; set; }
            public int PowerScore { get; set; }
            public PartLoader.Cabin Cabin { get; set; }
            public PartLoader.Engine Engine { get; set; }
            public List<PartLoader.Weapon> Weapons { get; set; }
            public List<PartLoader.Module> Modules { get; set; }
            public List<PartLoader.Explosive> Explosives { get; set; }
            public List<PartLoader.Movement> Movement { get; set; }
            public List<string> Parts { get; set; }
        }

        public class StaticRecordDB
        {
            public List<PartLoader.Part> GlobalPartsList { get; set; }
            public Dictionary<string, PartLoader.Weapon> GlobalWeaponDict { get; set; }
            public Dictionary<string, PartLoader.Cabin> GlobalCabinDict { get; set; }
            public Dictionary<string, PartLoader.Engine> GlobalEngineDict { get; set; }
            public Dictionary<string, PartLoader.Module> GlobalModuleDict { get; set; }
            public Dictionary<string, PartLoader.Explosive> GlobalExplosivesDict { get; set; }
            public Dictionary<string, PartLoader.Movement> GlobalMovementDict { get; set; }
            public Dictionary<string, PartLoader.Reward> GlobalRewardDict { get; set; }
            public List<PartLoader.EventTime> GlobalEventTimes { get; set; }
            public Dictionary<string, string> MapDict { get; set; }
            public Dictionary<string, string> ResourceDict { get; set; }
            public Dictionary<string, string> CKDict { get; set; }
        }
        #endregion
        #region session_managment
        public void InitializeSessionStats(SessionStats currentSession, LogFileManagment.SessionVariables localSessionVariables)
        {
            currentSession.LiveTraceData = false;
            currentSession.InMatch = false;
            currentSession.InGarage = false;
            currentSession.CurrentMatch = NewMatchData();
            currentSession.LocalUser = localSessionVariables.LocalUserName;
            currentSession.LocalUserUID = localSessionVariables.LocalUserID;
            currentSession.CurrentEvent = 0;
            currentSession.GarageData = new GarageData { };
            currentSession.GarageData.GarageStart = new DateTime { };
            currentSession.PendingAttributes = NewPendingAttributes();
            currentSession.FileData = new FileData { };
            currentSession.FileData.LogFileLocation = localSessionVariables.LogFileLocation;
            currentSession.FileData.HistoricFileLocation = localSessionVariables.HistoricFileLocation;
            currentSession.FileData.StreamOverlayOutputLocation = localSessionVariables.StreamFileLocation;
            currentSession.ClientLanguage = localSessionVariables.LocalLanguage;
            currentSession.CundleDamageIntoRamming = localSessionVariables.BundleRamMode;
            currentSession.QueueStartTime = DateTime.MinValue;
            currentSession.CurrentCombatLogTime = DateTime.MinValue;
            currentSession.CurrentGameLogTime = DateTime.MinValue;
            currentSession.PreviousCombatLogTime = DateTime.MinValue;
            currentSession.PreviousGameLogTime = DateTime.MinValue;
            currentSession.LastCombatLogTimeInMatch = DateTime.MinValue;
            currentSession.LastDamageDraw = DateTime.Now;
            currentSession.CurrentCombatLogDayOffset = 0;
            currentSession.CurrentGameLogDayOffset = 0;
            currentSession.PreviousCombatEvent = 0;
            currentSession.PreviousGameEvent = 0;
            currentSession.ReadyToAddRound = false;
            currentSession.ReadyToFinalizeRound = false;
            currentSession.FileData.HistoricFileSessionList = LoadHistoricFileList(localSessionVariables.HistoricFileLocation);
            currentSession.PlayerBuildRecords = new Dictionary<string, BuildRecord> { };
            currentSession.StaticRecords = new StaticRecordDB { };
            currentSession.StaticRecords.GlobalPartsList = new List<PartLoader.Part> { };
            currentSession.StaticRecords.GlobalCabinDict = new Dictionary<string, PartLoader.Cabin> { };
            currentSession.StaticRecords.GlobalEngineDict = new Dictionary<string, PartLoader.Engine> { };
            currentSession.StaticRecords.GlobalExplosivesDict = new Dictionary<string, PartLoader.Explosive> { };
            currentSession.StaticRecords.GlobalMovementDict = new Dictionary<string, PartLoader.Movement> { };
            currentSession.StaticRecords.GlobalModuleDict = new Dictionary<string, PartLoader.Module> { };
            currentSession.StaticRecords.GlobalWeaponDict = new Dictionary<string, PartLoader.Weapon> { };
            currentSession.StaticRecords.GlobalRewardDict = new Dictionary<string, PartLoader.Reward> { };
            currentSession.StaticRecords.GlobalEventTimes = new List<PartLoader.EventTime> { };
            currentSession.StaticRecords.MapDict = new Dictionary<string, string> { };
            currentSession.StaticRecords.ResourceDict = new Dictionary<string, string> { };
            currentSession.StaticRecords.CKDict = new Dictionary<string, string> { };
            currentSession.MatchHistory = new List<MatchRecord> { };

            try
            {
                currentSession.OverlayActions = JsonConvert.DeserializeObject<List<Overlay.OverlayAction>>(localSessionVariables.ActionConfiguration);
            }
            catch (Exception ex)
            {
                currentSession.OverlayActions = JsonConvert.DeserializeObject<List<Overlay.OverlayAction>>(Overlay.DefaultOverlaySetup());
            }

            try
            {
                currentSession.TwitchSettings = JsonConvert.DeserializeObject<Overlay.TwitchSettings>(localSessionVariables.TwitchSettings);
            }
            catch (Exception ex)
            {
                currentSession.TwitchSettings = JsonConvert.DeserializeObject<Overlay.TwitchSettings>(Overlay.DefaultTwitchSettings());
            }

            PartLoader.PopulateGlobalPartsList(currentSession);
            PartLoader.PopulateWeaponList(currentSession);
            PartLoader.PopulateModuleList(currentSession);
            PartLoader.PopulateCabinList(currentSession);
            PartLoader.PopulateEngineList(currentSession);
            PartLoader.PopulateExplosiveList(currentSession);
            PartLoader.PopulateMovementList(currentSession);
            PartLoader.PopulateRewardList(currentSession);
            PartLoader.LoadEventSchedule(currentSession);
            PartLoader.LoadMapDictionary(currentSession);
            PartLoader.LoadResourceDictionary(currentSession);
            PartLoader.LoadCKDictionary(currentSession);
        }


        private List<LogSession> LoadHistoricFileList(string historicFileLocation)
        {
            List<LogSession> temp_list = new List<LogSession> { };
            FileInfo[] files = new DirectoryInfo(historicFileLocation).GetFiles("*.*", SearchOption.AllDirectories).Where(s => (s.Name.StartsWith("combat") || s.Name.StartsWith("game")) && s.Name.EndsWith("log")).OrderByDescending(p => p.LastWriteTime).ToArray();

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
                                temp_list.Add(NewLogSession(file, files[i]));
                                break;
                            }
                        }
                    }

                }
            }

            return temp_list;
        }

        public static void AssignCurrentGameEvent(string line, SessionStats currentSession)
        {
            int event_id = 0;

            if (line.Contains("| StartMatchmaking:"))
                event_id = GlobalData.QUEUE_START_EVENT;
            else
            if (line.Contains("| Matchmaker_NotifyQueueState:"))
                event_id = GlobalData.QUEUE_UPDATE_EVENT;
            else
            if (line.Contains("| CL_MatchMaker::ConnectHandler:"))
                event_id = GlobalData.CONNECTION_INIT_EVENT;
            else
            if (line.Substring(0, 9) == "--- Date:")
                event_id = GlobalData.DATE_ASSIGNMENT_EVENT;
            else
            if (line.Contains("server guid"))
                event_id = GlobalData.GUID_ASSIGN_EVENT;
            else
            if (line.Contains("connected to dedicated server."))
                event_id = GlobalData.HOST_NAME_ASSIGN_EVENT;
            else
            if (line.Contains("expFactionTotal"))
                event_id = GlobalData.MATCH_REWARD_EVENT;
            else
            if (line.Contains("| PlayButton disabled"))
                event_id = GlobalData.QUEUE_END_EVENT;
            else
            if (line.Contains("\"queueTag\"") || line.Contains("\"minUR\"") || line.Contains("\"maxUR\"") || line.Contains("\"botlist\"") || line.Contains("\"custom_game\""))
                event_id = GlobalData.MATCH_PROPERTY_EVENT;
            else
            if (line.Contains("| client:") && line.Contains("_PLAYER "))
                event_id = GlobalData.ADD_OR_UPDATE_PLAYER_EVENT;
            else
            if (line.Contains("| Combat: Spawn player "))
                event_id = GlobalData.GAME_PLAYER_SPAWN_EVENT;
            else
            if (line.Contains("| Combat: 	player "))
                event_id = GlobalData.GAME_PLAYER_LOAD_EVENT;
            else
            if (line.Contains("| client: player "))
                event_id = GlobalData.PLAYER_LEAVE_EVENT;
            else
            if (line.Contains("         | // Build:"))
                event_id = GlobalData.ASSIGN_CLIENT_VERSION_EVENT;
            else
            if (line.Contains("|      quest "))
                event_id = GlobalData.QUEST_EVENT;
            else
            if (line.Contains("|      loot:"))
                event_id = GlobalData.LOOT_EVENT;
            else
            if (line.Contains("| ExplorationReward."))
                event_id = GlobalData.ADVENTURE_REWARD_EVENT;

            currentSession.CurrentEvent = event_id;
        }

        public static void AssignCurrentCombatEvent(string line, SessionStats currentSession)
        {
            int event_id = 0;

            if (line.Contains("| Damage."))
                event_id = GlobalData.DAMAGE_EVENT;
            else
            if (line.Contains("| Score:"))
                event_id = GlobalData.SCORE_EVENT;
            else
            if (line.Contains("| ====== starting level ") && !line.Contains("hangar") && !line.Contains("mainmenu"))
                event_id = GlobalData.MATCH_START_EVENT;
            else
            if (line.Contains("| ===== Gameplay '"))
                event_id = GlobalData.GAME_PLAY_START_EVENT;
            else
            if (line.Contains("| 	player"))
                event_id = GlobalData.LOAD_PLAYER_EVENT;
            else
            if (line.Contains("| Stripe "))
                event_id = GlobalData.STRIPE_EVENT;
            else
            if (line.Contains("| Kill."))
                event_id = GlobalData.KILL_EVENT;
            else
            if (line.Contains("| 	 assist by"))
                event_id = GlobalData.ASSIST_EVENT;
            else
            if (line.Contains("| Spawn player"))
                event_id = GlobalData.SPAWN_PLAYER_EVENT;
            else
            if (line.Contains("===== Gameplay finish"))
                event_id = GlobalData.MATCH_END_EVENT;
            else
            if (line.Contains("| ====== starting level ") || line.Contains("levels/maps/hangar") || line.Contains("| ====== TestDrive finish ======"))
                event_id = GlobalData.MAIN_MENU_EVENT;
            else
            if (line.Contains("| ====== TestDrive started ======"))
                event_id = GlobalData.TEST_DRIVE_EVENT;
            else
            if (line.Contains("| ===== Best Of N round"))
                event_id = GlobalData.CW_ROUND_END_EVENT;
            else
            if (line.Contains("| Spawn mob. def '"))
                event_id = GlobalData.ADD_MOB_EVENT;

            currentSession.CurrentEvent = event_id;
        }

        public static void MainMenuEvent(string line, SessionStats currentSession)
        {
            ClearInGameStats(currentSession);
            currentSession.InGarage = false;
            currentSession.PendingAttributes = NewPendingAttributes();
        }

        public static void TestDriveEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\|");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            currentSession.GarageData.GarageStart = currentSession.CurrentCombatLogTime;
            currentSession.InGarage = true;
        }
        public static void MatchStartEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| ====== starting level (?<match_counter>.+): 'levels/maps/(?<map_name>.+)' (?<gameplay_type>[^\s]+) ======$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string game_play = lineResults.Groups["gameplay_type"].Value.Replace(" ", "");
            string map_name = lineResults.Groups["map_name"].Value;

            if (game_play == null || game_play == "")
                return;

            ClearInGameStats(currentSession);
            currentSession.CurrentMatch = NewMatchData();

            currentSession.CurrentMatch.MapName = map_name;
            currentSession.CurrentMatch.MapDesc = map_name;
            currentSession.CurrentMatch.ClientVersion = currentSession.ClientVersion;
            currentSession.CurrentMatch.GamePlayValue = game_play;

            currentSession.CurrentMatch.MatchStart = currentSession.CurrentCombatLogTime;
            currentSession.CurrentMatch.MatchEnd = currentSession.CurrentCombatLogTime;
            currentSession.CurrentMatch.RoundStartTime = currentSession.CurrentCombatLogTime;
            currentSession.CurrentMatch.RoundEndTime = currentSession.CurrentCombatLogTime;

            currentSession.CurrentMatch.QueueStart = currentSession.QueueStartTime;
            currentSession.CurrentMatch.QueueEnd = currentSession.CurrentCombatLogTime;

            if (currentSession.CurrentMatch.QueueStart == DateTime.MinValue)
                currentSession.CurrentMatch.QueueStart = currentSession.CurrentCombatLogTime;

            if (currentSession.CurrentMatch.QueueStart >= currentSession.CurrentMatch.QueueEnd)
                currentSession.CurrentMatch.QueueEnd = currentSession.CurrentMatch.QueueStart.AddSeconds(4); /* don't judge me bro */

            AddRoundRecord(currentSession);

            currentSession.QueueStartTime = DateTime.MinValue;
            currentSession.InMatch = true;
            currentSession.InGarage = false;
            currentSession.CurrentMatch.MatchRewards = new Dictionary<string, int> { };
        }

        public static void GuidAssignEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| client: connected to (?<server_ip>.+)\|(?<server_port>.+), server guid '(?<server_guid>.+)', client guid '(?<client_guid>.+)', setting up session...$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            long server_guid = Convert.ToInt64(lineResults.Groups["server_guid"].Value.Replace(" ", ""));
            long client_guid = Convert.ToInt64(lineResults.Groups["client_guid"].Value.Replace(" ", ""));
            string server_ip = lineResults.Groups["server_ip"].Value.Replace(" ", "");
            string server_port = lineResults.Groups["server_port"].Value.Replace(" ", "");

            if (currentSession.InMatch)
            {
                currentSession.CurrentMatch.ServerGUID = server_guid;
                currentSession.CurrentMatch.ClientGUID = client_guid;
                currentSession.CurrentMatch.ServerIP = server_ip;
                currentSession.CurrentMatch.ServerPort = server_port;
            }
            else
            {
                currentSession.PendingAttributes.ServerGUID = server_guid;
                currentSession.PendingAttributes.ClientGUID = client_guid;
                currentSession.PendingAttributes.ServerIP = server_ip;
                currentSession.PendingAttributes.ServerPort = server_port;
            }
        }

        public static void DedicatedServerConnectEvent(string line, SessionStats currentSession)
        {
            //22:31:03.278         | client: connected to dedicated server. gsid: 446238260, hostname: 'wheel10lw-us.pxo'
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| client: connected to dedicated server. gsid: (?<gsid>.+), hostname: '(?<host_name>.+)'$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            long gsid = Convert.ToInt64(lineResults.Groups["gsid"].Value.Replace(" ", ""));
            string host_name = lineResults.Groups["host_name"].Value.Replace(" ", "");

            if (currentSession.InMatch)
            {
                currentSession.CurrentMatch.HostName = host_name;
            }
            else
            {
                currentSession.PendingAttributes.HostName = host_name;
            }
        }

        public static void ConnectionMadeEvent(string line, SessionStats currentSession)
        {
            //Current_session.queue_end_time = Current_session.current_game_log_time;
        }

        public static void QueueStartEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                currentSession.QueueStartTime = currentSession.CurrentGameLogTime;
        }

        public static void QueueUpdateEvent(string line, SessionStats currentSession)
        {
            //if (line.Contains("true") && Current_session.queue_start_time == DateTime.MinValue)
            //    Current_session.queue_start_time = Current_session.current_game_log_time;

            //if (line.Contains("true") && Current_session.previous_game_event != global_data.QUEUE_UPDATE_EVENT)
            //    Current_session.queue_start_time = Current_session.current_game_log_time;

            //if (line.Contains("false") && Current_session.queue_start_time != DateTime.MinValue)
            //    Current_session.queue_start_time = DateTime.MinValue;
        }

        public static void QueueEndEvent(string line, SessionStats currentSession)
        {
            //Current_session.queue_start_time = DateTime.MinValue;
        }

        public static void GameplayStartEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| ===== Gameplay '(?<gameplay_type>.+)' started, map '(?<map_name>.+)' ======$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            currentSession.CurrentMatch.MapName = lineResults.Groups["map_name"].Value;
            currentSession.CurrentMatch.MapDesc = lineResults.Groups["map_name"].Value;
            currentSession.CurrentMatch.ClientVersion = currentSession.ClientVersion;
            currentSession.CurrentMatch.GamePlayValue = lineResults.Groups["gameplay_type"].Value;
            //Current_session.current_match.match_start = Current_session.current_combat_log_time;

        }

        public static void ClanWarRoundEndEvent(string line, SessionStats currentSession)
        {
            //21:41:27.520| ===== Best Of N round 2 finish, reason: no_cars, winner team 2, win reason: MORE_CARS_LEFT, battle time: 190.2 sec =====
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| ===== Best Of N round (?<round_number>.+) finish, reason: (?<reason>.+), winner team (?<winning_team>.+), win reason: (?<win_reason>.+?), battle time: (?<battle_duration>.+?) sec =====$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }
            currentSession.CurrentMatch.RoundWinner = Int32.Parse(lineResults.Groups["winning_team"].Value);
            currentSession.CurrentMatch.RoundWinReason = lineResults.Groups["win_reason"].Value.Replace(" ", "");
            currentSession.CurrentMatch.RoundEndTime = currentSession.CurrentCombatLogTime;
            FinalizeRoundRecord(currentSession, currentSession.CurrentMatch.RoundWinner);
            currentSession.CurrentMatch.RoundStartTime = currentSession.CurrentCombatLogTime;
            currentSession.ReadyToAddRound = true;
        }

        public static void MatchEndEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| ===== Gameplay finish, reason: (?<gameplay_reason>.+), winner team (?<winning_team>[0-9]+), win reason: (?<win_reason>.+), battle time: (?<battle_time>.+?) sec =====$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            currentSession.CurrentMatch.WinningTeam = Int32.Parse(lineResults.Groups["winning_team"].Value);
            currentSession.CurrentMatch.MatchDurationSeconds = Convert.ToDouble(lineResults.Groups["battle_time"].Value);
            currentSession.CurrentMatch.WinReason = lineResults.Groups["win_reason"].Value.Replace(" ", "");

            ClearInGameStats(currentSession);
        }

        public static void MatchRewardEvent(string line, SessionStats currentSession)
        {
            string[] resources = line.Substring(23).Split(',');
            bool last_match_populated = false;

            if (currentSession.MatchHistory.LastOrDefault() == null)
                return;

            if (currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards.Count() > 0)
                last_match_populated = true;

            foreach (string resource in resources)
            {
                Match lineResults = Regex.Match(resource, @"(?<resource>[a-zA-Z].+) (?<ammount>.+)");
                string resource_name = lineResults.Groups["resource"].Value.Replace(" ", "");
                int ammount = (int)Convert.ToDouble(lineResults.Groups["ammount"].Value.Replace(" ", ""));

                if (currentSession.InMatch)
                {
                    if (currentSession.CurrentMatch.MatchRewards.ContainsKey(resource_name))
                        currentSession.CurrentMatch.MatchRewards[resource_name] += ammount;
                    else
                        currentSession.CurrentMatch.MatchRewards.Add(resource_name, ammount);
                }
                else
                {
                    if (currentSession.MatchHistory.Count > 1 && !last_match_populated)
                    {
                        if (currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards.ContainsKey(resource_name))
                            currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards[resource_name] += ammount;
                        else
                            currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards.Add(resource_name, ammount);
                    }
                }
            }


        }
        public static void AssignAdventureRewardEvent(string line, SessionStats currentSession)
        {
            //17:20:21.300         | ExplorationReward. Platinum. base 5, bonus 2, total 7
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| ExplorationReward. (?<reward>.+)\. base (?<base_ammount>.+), bonus (?<bonus_ammount>.+), total (?<total_ammount>.+)$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            if (currentSession.MatchHistory.LastOrDefault() == null)
                return;

            string resource_name = lineResults.Groups["reward"].Value.Replace(" ", "");
            int ammount = (int)Convert.ToDouble(lineResults.Groups["total_ammount"].Value.Replace(" ", ""));

            if (currentSession.InMatch)
            {
                if (currentSession.CurrentMatch.MatchRewards.ContainsKey(resource_name))
                    currentSession.CurrentMatch.MatchRewards[resource_name] += ammount;
                else
                    currentSession.CurrentMatch.MatchRewards.Add(resource_name, ammount);
            }
            else
            {
                //if (Current_session.match_history.Count > 1 && !last_match_populated)
                //{
                if (currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards.ContainsKey(resource_name))
                    currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards[resource_name] += ammount;
                else
                    currentSession.MatchHistory.LastOrDefault().MatchData.MatchRewards.Add(resource_name, ammount);
                //}
            }
        }

        public static void AssignLootEvent(string line, SessionStats currentSession)
        {
            if (line.Contains("ResourcePack_Gasoline10"))
            {
                if (currentSession.CurrentMatch.MatchRewards.ContainsKey("gasoline"))
                    currentSession.CurrentMatch.MatchRewards["gasoline"] += 10;
                else
                    currentSession.CurrentMatch.MatchRewards.Add("gasoline", 10);
            }

            if (line.Contains("ResourcePack_Gasoline5"))
            {
                if (currentSession.CurrentMatch.MatchRewards.ContainsKey("gasoline"))
                    currentSession.CurrentMatch.MatchRewards["gasoline"] += 5;
                else
                    currentSession.CurrentMatch.MatchRewards.Add("gasoline", 5);
            }

        }

        public static void UpdateCurrentTime(string logType, string line, SessionStats currentSession)
        {
            DateTime logTime;
            string hour = line.Substring(0, 2);
            string minute = line.Substring(3, 2);
            string second = line.Substring(6, 2);
            string millisecond = line.Substring(9, 3);

            if (currentSession.CurrentGameLogDayOffset > currentSession.CurrentCombatLogDayOffset && !currentSession.InMatch)
                currentSession.CurrentCombatLogDayOffset = currentSession.CurrentGameLogDayOffset;

            if (logType == "c")
            {
                try
                {
                    logTime = DateTime.ParseExact(string.Format("{0}{1}{2}{3}.{4}", currentSession.FileData.ProcessingCombatSessionFileDay.AddDays(currentSession.CurrentCombatLogDayOffset).ToString("yyyyMMdd", CultureInfo.CurrentCulture), hour, minute, second, millisecond), "yyyyMMddHHmmss.fff", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A valid date time was not found in the following line" + Environment.NewLine + line);
                    return;
                }

                if (logTime < currentSession.PreviousCombatLogTime)
                {
                    currentSession.CurrentCombatLogDayOffset += 1;
                    logTime = logTime.AddDays(1.0);

                    if (logTime < currentSession.PreviousCombatLogTime && currentSession.PreviousCombatLogTime != DateTime.MinValue)
                    {
                        MessageBox.Show(string.Format(@"The following error has occured in time calculation{0}current timestamp:{1}{0}previous timestamp:{2}{0}", Environment.NewLine, logTime.ToString(), currentSession.PreviousCombatLogTime.ToString()));
                    }
                }

                if (currentSession.InMatch)
                    currentSession.LastCombatLogTimeInMatch = logTime;

                currentSession.CurrentCombatLogTime = logTime;
            }
            else
            {
                try
                {
                    logTime = DateTime.ParseExact(string.Format("{0}{1}{2}{3}.{4}", currentSession.FileData.ProcessingCombatSessionFileDay.AddDays(currentSession.CurrentGameLogDayOffset).ToString("yyyyMMdd", CultureInfo.CurrentCulture), hour, minute, second, millisecond), "yyyyMMddHHmmss.fff", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A valid date time was not found in the following line" + Environment.NewLine + line);
                    return;
                }


                if (logTime < currentSession.PreviousGameLogTime)
                {
                    currentSession.CurrentGameLogDayOffset += 1;
                    logTime = logTime.AddDays(1.0);

                    if (logTime < currentSession.PreviousGameLogTime && currentSession.PreviousGameLogTime != DateTime.MinValue)
                    {
                        MessageBox.Show(string.Format(@"The following error has occured in time calculation{0}current timestamp:{1}{0}previous timestamp:{2}{0}", Environment.NewLine, logTime.ToString(), currentSession.PreviousGameLogTime.ToString()));
                    }
                }
                currentSession.CurrentGameLogTime = logTime;
            }
        }

        public static void UpdatePreviousTime(string logType, string line, SessionStats currentSession)
        {
            string hour = line.Substring(0, 2);
            string minute = line.Substring(3, 2);
            string second = line.Substring(6, 2);
            string millisecond = line.Substring(9, 3);

            if (logType == "c")
            {
                try
                {
                    currentSession.PreviousCombatLogTime = DateTime.ParseExact(string.Format("{0}{1}{2}{3}.{4}", currentSession.FileData.ProcessingCombatSessionFileDay.AddDays(currentSession.CurrentCombatLogDayOffset).ToString("yyyyMMdd", CultureInfo.CurrentCulture), hour, minute, second, millisecond), "yyyyMMddHHmmss.fff", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A valid date time was not found in the following line" + Environment.NewLine + line);
                    return;
                }
            }
            else
            {
                try
                {
                    currentSession.PreviousGameLogTime = DateTime.ParseExact(string.Format("{0}{1}{2}{3}.{4}", currentSession.FileData.ProcessingCombatSessionFileDay.AddDays(currentSession.CurrentGameLogDayOffset).ToString("yyyyMMdd", CultureInfo.CurrentCulture), hour, minute, second, millisecond), "yyyyMMddHHmmss.fff", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A valid date time was not found in the following line" + Environment.NewLine + line);
                    return;
                }
            }
        }

        private static void ClearInGameStats(SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                return;

            if (currentSession.InGarage)
                return;

            currentSession.InMatch = false;

            if (!currentSession.CurrentMatch.PlayerRecords.ContainsKey(currentSession.LocalUserUID))
                return;

            if (currentSession.CurrentMatch.ServerGUID == 0 && currentSession.PendingAttributes.ServerGUID != 0)
            {
                currentSession.CurrentMatch.ServerGUID = currentSession.PendingAttributes.ServerGUID;
                currentSession.CurrentMatch.ClientGUID = currentSession.PendingAttributes.ClientGUID;
                currentSession.CurrentMatch.ServerIP = currentSession.PendingAttributes.ServerIP;
                currentSession.CurrentMatch.ServerPort = currentSession.PendingAttributes.ServerPort;
                currentSession.CurrentMatch.HostName = currentSession.PendingAttributes.HostName;
            }

            if (!currentSession.CurrentMatch.MatchAttributes.Any() && currentSession.PendingAttributes.Attributes.Any())
                currentSession.CurrentMatch.MatchAttributes.AddRange(currentSession.PendingAttributes.Attributes);

            currentSession.PendingAttributes = NewPendingAttributes();

            AssignBuildParts(currentSession);
            ClassifyMatch(currentSession);
            ClassifyLocalUserBuild(currentSession);
            FinalizeRoundRecord(currentSession, currentSession.CurrentMatch.WinningTeam);

            currentSession.ReadyToAddRound = false;
            currentSession.ReadyToFinalizeRound = false;

            foreach (KeyValuePair<int, Player> entry in currentSession.CurrentMatch.PlayerRecords)
            {
                entry.Value.Stats.Games += 1;

                if (entry.Value.Team == currentSession.CurrentMatch.WinningTeam)
                    entry.Value.Stats.Wins += 1;
                else
                    entry.Value.Stats.Losses += 1;
            }

            FinalizeMatchRecord(currentSession);
        }

        private static void ClassifyMatch(SessionStats currentSession)
        {
            int player_count = 0;
            int highest_power_score = 0;
            currentSession.CurrentMatch.MatchType = GlobalData.UNDEFINED_MATCH;

            foreach (KeyValuePair<int, Player> entry in currentSession.CurrentMatch.PlayerRecords)
            {
                if (entry.Value.PowerScore > highest_power_score)
                    highest_power_score = entry.Value.PowerScore;
            }

            player_count = currentSession.CurrentMatch.PlayerRecords.Count();

            if ((currentSession.CurrentMatch.GamePlayValue.Contains("Conquer") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Domination") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Assault")))
                currentSession.CurrentMatch.MatchType = GlobalData.STANDARD_MATCH;

            if (currentSession.CurrentMatch.MatchAttributes.Where(x => x.Attribute.Contains("queueTag") && x.Value == "Default").Count() > 0 &&
                (currentSession.CurrentMatch.GamePlayValue.Contains("Conquer") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Domination") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Assault")))
                currentSession.CurrentMatch.MatchType = GlobalData.STANDARD_RESTRICTED_MATCH;

            if ((currentSession.CurrentMatch.GamePlayValue.Contains("ConquerCoopVsAi") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("DominationCoopVsAi") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("AssaultCoopVsAi")))
                currentSession.CurrentMatch.MatchType = GlobalData.PATROL_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("BestOf3"))
                currentSession.CurrentMatch.MatchType = GlobalData.STANDARD_CW_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_DroneBattle"))
                currentSession.CurrentMatch.MatchType = GlobalData.DRONE_BATTLE_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("BestOf3") && highest_power_score > 23000)
                currentSession.CurrentMatch.MatchType = GlobalData.LEVIATHIAN_CW_MATCH;

            if (currentSession.CurrentMatch.MapName.Contains("red_rocks_battle_royale"))
                currentSession.CurrentMatch.MatchType = GlobalData.BATTLE_ROYALE_MATCH;



            if (currentSession.CurrentMatch.GamePlayValue.Contains("Pve_Greatescape"))
                currentSession.CurrentMatch.MatchType = GlobalData.MED_RAID_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.ToLower().Contains("pve"))
            {
                foreach (KeyValuePair<int, Player> player in currentSession.CurrentMatch.PlayerRecords)
                {
                    if (player.Value.Team != 2)
                        continue;

                    if (player.Value.Bot != 1)
                        continue;

                    if (player.Value.Nickname.ToLower().Contains("hard"))
                        currentSession.CurrentMatch.MatchType = GlobalData.HARD_RAID_MATCH;

                    if (player.Value.Nickname.ToLower().Contains("medium") && currentSession.CurrentMatch.MatchType != GlobalData.HARD_RAID_MATCH)
                        currentSession.CurrentMatch.MatchType = GlobalData.MED_RAID_MATCH;

                    if (player.Value.Nickname.ToLower().Contains("easy") && currentSession.CurrentMatch.MatchType != GlobalData.HARD_RAID_MATCH && currentSession.CurrentMatch.MatchType != GlobalData.MED_RAID_MATCH)
                        currentSession.CurrentMatch.MatchType = GlobalData.EASY_RAID_MATCH;
                }
            }

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Pve_Leviathan"))
                currentSession.CurrentMatch.MatchType = GlobalData.INVASION_MATCH;

            if ((currentSession.CurrentMatch.GamePlayValue.Contains("Conquer") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Domination") ||
                 currentSession.CurrentMatch.GamePlayValue.Contains("Assault")) && player_count == 12)
                currentSession.CurrentMatch.MatchType = GlobalData.LEAGUE_6_v_6_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("FreePlay"))
                currentSession.CurrentMatch.MatchType = GlobalData.BEDLAM_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("InvRaceOnlyWheels"))
                currentSession.CurrentMatch.MatchType = GlobalData.RACE_WHEELS_ONLY_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("RaceOnlyWheels"))
                currentSession.CurrentMatch.MatchType = GlobalData.RACE_WHEELS_ONLY_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Exploration"))
                currentSession.CurrentMatch.MatchType = GlobalData.ADVENTURE_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_NewYear_Convoy"))
                currentSession.CurrentMatch.MatchType = GlobalData.PRESENT_HEIST_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_AssaultAllCannons"))
                currentSession.CurrentMatch.MatchType = GlobalData.CANNON_BRAWL_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_FieldBattle"))
                currentSession.CurrentMatch.MatchType = GlobalData.WINTER_MAYHAM_MATCH;

            if (currentSession.CurrentMatch.MapName.Contains("holes_halloween"))
                currentSession.CurrentMatch.MatchType = GlobalData.HALLOWEEN_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("DestructionDerbyLua"))
                currentSession.CurrentMatch.MatchType = GlobalData.STORMS_WARNING_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Deathmatch"))
                currentSession.CurrentMatch.MatchType = GlobalData.FREE_FOR_ALL_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_Football"))
                currentSession.CurrentMatch.MatchType = GlobalData.ROCKET_LEAGUE_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("FreePlay"))
                currentSession.CurrentMatch.MatchType = GlobalData.BEDLAM_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_BDCrossout"))
                currentSession.CurrentMatch.MatchType = GlobalData.CROSSOUT_DAY_BRAWL_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Pve_Foray"))
                currentSession.CurrentMatch.MatchType = GlobalData.GOZU_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_Flag"))
                currentSession.CurrentMatch.MatchType = GlobalData.WITCH_HUNT_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Bomb_Planting"))
                currentSession.CurrentMatch.MatchType = GlobalData.BOMB_PLANT_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_Crush"))
                currentSession.CurrentMatch.MatchType = GlobalData.BOARS_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_ZombieEscape"))
                currentSession.CurrentMatch.MatchType = GlobalData.OPERATION_RED_LIGHT_MATCH;

            if (currentSession.CurrentMatch.GamePlayValue.Contains("Brawl_Arena"))
                currentSession.CurrentMatch.MatchType = GlobalData.ARENA_RANKED_MATCH;

            if (currentSession.CurrentMatch.MatchAttributes.FirstOrDefault(x => x.Value.Contains("QBrawl_Arena_Casual")) != null)
                currentSession.CurrentMatch.MatchType = GlobalData.ARENA_CASUAL_MATCH;

            if (currentSession.CurrentMatch.MatchAttributes.FirstOrDefault(x => x.Attribute.Contains("custom_game")) != null)
                currentSession.CurrentMatch.MatchType = GlobalData.CUSTOM_MATCH;

            if (currentSession.CurrentMatch.MatchAttributes.FirstOrDefault(x => x.Attribute.Contains("NoobPvp")) != null)
                currentSession.CurrentMatch.MatchType = GlobalData.TEST_SERVER_MATCH;

            currentSession.CurrentMatch.MatchTypeDesc = DecodeMatchType(currentSession.CurrentMatch.MatchType);
            currentSession.CurrentMatch.GameplayDesc = currentSession.CurrentMatch.GamePlayValue;
            SetMatchClassification(currentSession);
        }

        public static void SetMatchClassification(SessionStats currentSession)
        {
            currentSession.CurrentMatch.MatchClassification = GlobalData.UNDEFINED_CLASSIFICATION;

            if (currentSession.CurrentMatch.MatchType == GlobalData.STANDARD_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.STANDARD_CW_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.LEVIATHIAN_CW_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.ARENA_RANKED_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.ARENA_CASUAL_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.LEAGUE_6_v_6_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.STANDARD_RESTRICTED_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.CANNON_BRAWL_MATCH)
                currentSession.CurrentMatch.MatchClassification = GlobalData.PVP_CLASSIFICATION;

            if (currentSession.CurrentMatch.MatchType == GlobalData.EASY_RAID_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.MED_RAID_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.HARD_RAID_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.ADVENTURE_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.PRESENT_HEIST_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.PATROL_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.INVASION_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.GOZU_MATCH)
                currentSession.CurrentMatch.MatchClassification = GlobalData.PVE_CLASSIFICATION;

            if (currentSession.CurrentMatch.MatchType == GlobalData.BATTLE_ROYALE_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.WINTER_MAYHAM_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.FREE_FOR_ALL_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.SCORPION_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.BOAR_FIGHT_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.BIG_BAD_BURNERS_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.RACE_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.STORMS_WARNING_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.HALLOWEEN_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.ROCKET_LEAGUE_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.DRONE_BATTLE_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.RACE_WHEELS_ONLY_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.OPERATION_RED_LIGHT_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.WITCH_HUNT_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.BOMB_PLANT_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.CROSSOUT_DAY_BRAWL_MATCH)
                currentSession.CurrentMatch.MatchClassification = GlobalData.BRAWL_CLASSIFICATION;

            if (currentSession.CurrentMatch.MatchType == GlobalData.BEDLAM_MATCH)
                currentSession.CurrentMatch.MatchClassification = GlobalData.FREE_PLAY_CLASSIFICATION;

            if (currentSession.CurrentMatch.MatchType == GlobalData.CUSTOM_MATCH ||
                currentSession.CurrentMatch.MatchType == GlobalData.TEST_SERVER_MATCH)
                currentSession.CurrentMatch.MatchClassification = GlobalData.CUSTOM_CLASSIFICATION;
        }

        private static void FinalizeMatchRecord(SessionStats currentSession)
        {
            MatchRecord match_record = NewMatchRecord();

            currentSession.CurrentMatch.LocalPlayer = currentSession.CurrentMatch.PlayerRecords[currentSession.LocalUserUID];

            if (currentSession.CurrentMatch.MatchType == GlobalData.BEDLAM_MATCH || currentSession.CurrentMatch.MatchType == GlobalData.ADVENTURE_MATCH)
            {
                currentSession.CurrentMatch.GameResult = "";
            }
            else if (currentSession.CurrentMatch.PlayerRecords[currentSession.LocalUserUID].Team == currentSession.CurrentMatch.WinningTeam)
            {
                currentSession.CurrentMatch.GameResult = "Win";
            }
            else if (currentSession.CurrentMatch.WinningTeam == -1)
            {
                currentSession.CurrentMatch.GameResult = "Unfinished";
            }
            else if (currentSession.CurrentMatch.WinningTeam == 0)
            {
                currentSession.CurrentMatch.GameResult = "Draw";
            }
            else
            {
                currentSession.CurrentMatch.GameResult = "Loss";
            }

            if (currentSession.CurrentMatch.MatchDurationSeconds > 0.1)
            {
                currentSession.CurrentMatch.MatchEnd = currentSession.CurrentMatch.MatchStart.AddSeconds(currentSession.CurrentMatch.MatchDurationSeconds);
            }
            else
            {
                currentSession.CurrentMatch.MatchEnd = currentSession.LastCombatLogTimeInMatch;
            }

            match_record.MatchData = currentSession.CurrentMatch;
            currentSession.MatchHistory.Add(match_record);
        }

        public static void AddRoundRecord(SessionStats currentSession)
        {
            RoundRecord round_record = new RoundRecord { };
            round_record.Players = new List<Player> { };
            round_record.DamageRecords = new List<RoundDamageRecord> { };
            round_record.Round = currentSession.CurrentMatch.RoundRecords.Count() + 1;
            currentSession.CurrentMatch.RoundStartTime = currentSession.CurrentCombatLogTime;
            currentSession.CurrentMatch.RoundRecords.Add(round_record);
            currentSession.ReadyToAddRound = false;
            currentSession.ReadyToFinalizeRound = true;
        }

        public static void FinalizeRoundRecord(SessionStats currentSession, int roundWinner)
        {
            if (!currentSession.ReadyToFinalizeRound)
                return;

            currentSession.CurrentMatch.RoundRecords.Last().WinningTeam = roundWinner;
            currentSession.CurrentMatch.RoundRecords.Last().WinReason = currentSession.CurrentMatch.RoundWinReason;
            currentSession.CurrentMatch.RoundRecords.Last().RoundStart = currentSession.CurrentMatch.RoundStartTime;
            currentSession.CurrentMatch.RoundRecords.Last().RoundEnd = currentSession.CurrentCombatLogTime;

            foreach (KeyValuePair<int, Player> player in currentSession.CurrentMatch.PlayerRecords)
            {
                Player current_player = NewPlayer();
                current_player.Nickname = player.Value.Nickname;
                current_player.UID = player.Value.UID;
                current_player.Bot = player.Value.Bot;
                current_player.PartyID = player.Value.PartyID;
                current_player.BuildHash = player.Value.BuildHash;
                current_player.PowerScore = player.Value.PowerScore;
                current_player.Team = player.Value.Team;
                current_player.Stats = SumStats(player.Value.Stats, current_player.Stats);
                current_player.Scores = player.Value.Scores;
                current_player.Stripes = player.Value.Stripes;

                for (int i = 0; i < currentSession.CurrentMatch.RoundRecords.Count(); i++)
                    if (currentSession.CurrentMatch.RoundRecords[i].Players.Any(x => x.UID == player.Key))
                        current_player.Stats = SubStats(current_player.Stats, currentSession.CurrentMatch.RoundRecords[i].Players.First(x => x.UID == player.Key).Stats);

                currentSession.CurrentMatch.RoundRecords.Last().Players.Add(current_player);
            }

            currentSession.ReadyToFinalizeRound = false;
        }
        private static void AssignBuildParts(SessionStats currentSession)
        {
            foreach (KeyValuePair<int, Player> player in currentSession.CurrentMatch.PlayerRecords)
            {
                if (!currentSession.PlayerBuildRecords.ContainsKey(player.Value.BuildHash))
                {
                    //MessageBox.Show("Can't find " + player.Value.nickname + ":" + player.Value.build_hash);
                    continue;
                }

                BuildRecord local_build = currentSession.PlayerBuildRecords[player.Value.BuildHash];

                foreach (string part in currentSession.PlayerBuildRecords[player.Value.BuildHash].Parts)
                {
                    if (currentSession.StaticRecords.GlobalCabinDict.ContainsKey(part))
                        local_build.Cabin = currentSession.StaticRecords.GlobalCabinDict[part];
                    else
                    if (currentSession.StaticRecords.GlobalEngineDict.ContainsKey(part))
                        local_build.Engine = currentSession.StaticRecords.GlobalEngineDict[part];
                    else
                    if (currentSession.StaticRecords.GlobalWeaponDict.ContainsKey(part) && local_build.Weapons.Where(x => x.Name == part).Count() == 0)
                        local_build.Weapons.Add(currentSession.StaticRecords.GlobalWeaponDict[part]);
                    else
                    if (currentSession.StaticRecords.GlobalMovementDict.ContainsKey(part) && local_build.Movement.Where(x => x.Name == part).Count() == 0)
                        local_build.Movement.Add(currentSession.StaticRecords.GlobalMovementDict[part]);
                    else
                    if (currentSession.StaticRecords.GlobalModuleDict.ContainsKey(part) && local_build.Modules.Where(x => x.Name == part).Count() == 0)
                        local_build.Modules.Add(currentSession.StaticRecords.GlobalModuleDict[part]);
                    else
                    if (currentSession.StaticRecords.GlobalExplosivesDict.ContainsKey(part) && local_build.Explosives.Where(x => x.Name == part).Count() == 0)
                        local_build.Explosives.Add(currentSession.StaticRecords.GlobalExplosivesDict[part]);
                }

                currentSession.PlayerBuildRecords[player.Value.BuildHash] = local_build;
            }
        }

        public static void AssignClientVersionEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"\| // Build: Crossout x(?<bit>[0-9]{2}) (?<client_version>.+)$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            currentSession.ClientVersion = lineResults.Groups["client_version"].Value;
        }

        public static void LoadPlayerEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| 	player (?<spawn_position>.+), uid (?<uid>[0-9]{8}), party (?<party_id>[0-9]{8}), nickname: (?<nickname>.+?), team: (?<team>[0-9]+), bot: (?<bot>[0-9]{1}), ur: (?<power_score>[0-9]+), mmHash: (?<build_hash>.{8})$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string player_name = lineResults.Groups["nickname"].Value.Replace(" ", "");
            int spawn_position = Int32.Parse(lineResults.Groups["spawn_position"].Value);
            string build_hash = lineResults.Groups["build_hash"].Value;
            int uid = Int32.Parse(lineResults.Groups["uid"].Value);
            int bot = Int32.Parse(lineResults.Groups["bot"].Value);
            int party_id = Int32.Parse(lineResults.Groups["party_id"].Value);
            int team = Int32.Parse(lineResults.Groups["team"].Value);
            int power_score = Int32.Parse(lineResults.Groups["power_score"].Value);

            if (uid == 0)
                bot = 1;

            if (bot == 1)
                uid = GlobalData.AssignBotUid(player_name);

            if (currentSession.CurrentMatch.PlayerRecords.ContainsKey(uid))
            {
                currentSession.CurrentMatch.PlayerRecords[uid].Nickname = player_name;
                currentSession.CurrentMatch.PlayerRecords[uid].UID = uid;
                currentSession.CurrentMatch.PlayerRecords[uid].SpawnPosition = spawn_position;
                currentSession.CurrentMatch.PlayerRecords[uid].Bot = bot;
                currentSession.CurrentMatch.PlayerRecords[uid].PartyID = party_id;
                currentSession.CurrentMatch.PlayerRecords[uid].PowerScore = power_score;
                currentSession.CurrentMatch.PlayerRecords[uid].Team = team;
                currentSession.CurrentMatch.PlayerRecords[uid].BuildHash = build_hash;
            }
            else
            {
                Player current_player = NewPlayer();
                int old_uid = Int32.MinValue;

                if (currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == player_name))
                {
                    current_player = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == player_name).Value;
                    old_uid = current_player.UID;
                }

                current_player.Nickname = player_name;
                current_player.SpawnPosition = spawn_position;
                current_player.UID = uid;
                current_player.Bot = bot;
                current_player.PartyID = party_id;
                current_player.PowerScore = power_score;
                current_player.Team = team;
                current_player.BuildHash = build_hash;
                currentSession.CurrentMatch.PlayerRecords.Add(uid, current_player);

                if (old_uid != Int32.MinValue)
                    currentSession.CurrentMatch.PlayerRecords.Remove(old_uid);
            }

            if (currentSession.PlayerBuildRecords.ContainsKey(build_hash))
            {
                if (power_score > currentSession.PlayerBuildRecords[build_hash].PowerScore)
                    currentSession.PlayerBuildRecords[build_hash].PowerScore = power_score;
            }
            else
            {
                BuildRecord new_build = NewBuildRecord();
                new_build.BuildHash = build_hash;
                new_build.PowerScore = power_score;
                currentSession.PlayerBuildRecords.Add(build_hash, new_build);
            }

            if (currentSession.ReadyToAddRound == true)
                AddRoundRecord(currentSession);
        }

        public static void SpawnPlayerEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Spawn player (?<spawn_position>[^\s]+) \[(?<nickname>.*)\], team (?<team>[^,]+), spawnCounter (?<spawn_counter>[^\s]+) , designHash: (?<build_hash>[^\.]+)\.$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string player_name = lineResults.Groups["nickname"].Value.Replace(" ", "");
            string build_hash = lineResults.Groups["build_hash"].Value;
            int team = Int32.Parse(lineResults.Groups["team"].Value);
            int spawn_position = Int32.Parse(lineResults.Groups["spawn_position"].Value.Replace(" ", ""));

            if (player_name == "" || player_name == null)
                return;

            if (team == 0)
                return;

            if (currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == player_name))
            {
                int uid = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == player_name).Key;

                currentSession.CurrentMatch.PlayerRecords[uid].BuildHash = build_hash;
                currentSession.CurrentMatch.PlayerRecords[uid].Team = team;
                currentSession.CurrentMatch.PlayerRecords[uid].SpawnPosition = spawn_position;
            }
            else
            {
                int uid = GlobalData.AssignTempUid(player_name);

                if (player_name == currentSession.LocalUser)
                    uid = currentSession.LocalUserUID;

                Player current_player = NewPlayer();
                current_player.Nickname = player_name;
                current_player.BuildHash = build_hash;
                current_player.SpawnPosition = spawn_position;
                current_player.UID = uid;
                current_player.Team = team;

                if (currentSession.PlayerBuildRecords.ContainsKey(build_hash))
                    current_player.PowerScore = currentSession.PlayerBuildRecords[build_hash].PowerScore;
                else
                    current_player.PowerScore = 0;

                currentSession.CurrentMatch.PlayerRecords.Add(uid, current_player);
            }

            if (!currentSession.PlayerBuildRecords.ContainsKey(build_hash))
            {
                BuildRecord new_build = NewBuildRecord();
                new_build.BuildHash = build_hash;
                currentSession.PlayerBuildRecords.Add(build_hash, new_build);
            }

            if (currentSession.ReadyToAddRound == true)
                AddRoundRecord(currentSession);
        }

        public static void AddOrUpdatePlayerFromGameLog(string line, SessionStats currentSession)
        {
            //| client: ADD_PLAYER  0   SmokinJoker420, uid 02097231 status   ACTIVE team 2
            //| client: UPDATE_PLAYER  4   BLU SKY3S@live, uid 10813925 status   ACTIVE team 1
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| client: (?<add_or_update>[^\s]+) [\s]{0,1}(?<spawn_position>[^\s]+) (?<nickname>[^,]+), uid (?<uid>[^\s]+) status (?<status>.*) team (?<team>.*)$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string status = lineResults.Groups["status"].Value.Replace(" ", "");
            string player_name = lineResults.Groups["nickname"].Value.Replace(" ", "");
            int uid = Int32.Parse(lineResults.Groups["uid"].Value);
            int spawn_position = spawn_position = Int32.Parse(lineResults.Groups["spawn_position"].Value.Replace(" ", ""));
            int team = Int32.Parse(lineResults.Groups["team"].Value);
            int bot = 0;

            if (status != "ACTIVE")
                return;

            if (team == 0)
                return;

            if (uid == 0)
            {
                bot = 1;
                uid = GlobalData.AssignBotUid(player_name);
            }


            if (currentSession.CurrentMatch.PlayerRecords.ContainsKey(uid))
            {
                currentSession.CurrentMatch.PlayerRecords[uid].Team = team;
                currentSession.CurrentMatch.PlayerRecords[uid].UID = uid;
                currentSession.CurrentMatch.PlayerRecords[uid].SpawnPosition = spawn_position;

                if (bot != 0)
                    currentSession.CurrentMatch.PlayerRecords[uid].Bot = bot;
            }
            else
            {
                Player current_player = NewPlayer();
                int old_uid = Int32.MinValue;

                if (currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == player_name))
                {
                    current_player = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == player_name).Value;
                    old_uid = current_player.UID;
                }

                current_player.Nickname = player_name;
                current_player.UID = uid;
                current_player.SpawnPosition = spawn_position;
                current_player.Team = team;

                if (bot != 0)
                    current_player.Bot = 1;

                currentSession.CurrentMatch.PlayerRecords.Add(uid, current_player);

                if (old_uid != Int32.MinValue)
                    currentSession.CurrentMatch.PlayerRecords.Remove(old_uid);
            }
        }
        public static void SpawnPlayerFromGameLog(string line, SessionStats currentSession)
        {
            //21:41:20.059         | Combat: Spawn player 1 [Charlie9204], team 1, spawnCounter 1 , designHash: 2bc161f.
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| Combat: Spawn player (?<spawn_position>[^\s]+) \[(?<nickname>.*)\], team (?<team>[^,]+), spawnCounter (?<spawn_counter>[^\s]+) , designHash: (?<build_hash>[^\.]+)\.$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string player_name = lineResults.Groups["nickname"].Value.Replace(" ", "");
            int spawn_position = Int32.Parse(lineResults.Groups["spawn_position"].Value.Replace(" ", ""));
            int team = Int32.Parse(lineResults.Groups["team"].Value);
            string build_hash = lineResults.Groups["build_hash"].Value;

            if (team == 0)
                return;

            if (currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == player_name))
            {
                int uid = currentSession.CurrentMatch.PlayerRecords.FirstOrDefault(x => x.Value.Nickname == player_name).Key;

                currentSession.CurrentMatch.PlayerRecords[uid].Team = team;
                currentSession.CurrentMatch.PlayerRecords[uid].BuildHash = build_hash;
                currentSession.CurrentMatch.PlayerRecords[uid].SpawnPosition = spawn_position;
            }

            if (!currentSession.PlayerBuildRecords.ContainsKey(build_hash))
            {
                BuildRecord new_build = NewBuildRecord();
                new_build.BuildHash = build_hash;
                currentSession.PlayerBuildRecords.Add(build_hash, new_build);
            }
        }

        public static void LoadPlayerFromGameLog(string line, SessionStats currentSession)
        {
            //08:14:48.699         | Combat: 	player  0, uid 09495729, party 00000000, nickname: Stiiin              , team: 2, bot: 0, ur: 8884, mmHash: 6e064b74
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| Combat: 	player (?<spawn_position>.+), uid (?<uid>[0-9]{8}), party (?<party_id>[0-9]{8}), nickname: (?<nickname>.+?), team: (?<team>[0-9]+), bot: (?<bot>[0-9]{1}), ur: (?<power_score>[0-9]+), mmHash: (?<build_hash>.{8})$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string playerName = lineResults.Groups["nickname"].Value.Replace(" ", "");
            string buildHash = lineResults.Groups["build_hash"].Value;
            int uid = Int32.Parse(lineResults.Groups["uid"].Value);
            int bot = Int32.Parse(lineResults.Groups["bot"].Value);
            int partyID = Int32.Parse(lineResults.Groups["party_id"].Value);
            int team = Int32.Parse(lineResults.Groups["team"].Value);
            int powerScore = Int32.Parse(lineResults.Groups["power_score"].Value);
            int spawnPosition = Int32.Parse(lineResults.Groups["spawn_position"].Value.Replace(" ", ""));

            if (bot != 0)
            {
                bot = 1;
                uid = GlobalData.AssignBotUid(playerName);
            }

            if (currentSession.CurrentMatch.PlayerRecords.ContainsKey(uid))
            {
                currentSession.CurrentMatch.PlayerRecords[uid].UID = uid;

                if (currentSession.CurrentMatch.PlayerRecords[uid].BuildHash == "")
                    currentSession.CurrentMatch.PlayerRecords[uid].BuildHash = buildHash;

                currentSession.CurrentMatch.PlayerRecords[uid].SpawnPosition = spawnPosition;
                currentSession.CurrentMatch.PlayerRecords[uid].Bot = bot;
                currentSession.CurrentMatch.PlayerRecords[uid].PartyID = partyID;
                currentSession.CurrentMatch.PlayerRecords[uid].PowerScore = powerScore;
                currentSession.CurrentMatch.PlayerRecords[uid].Team = team;
            }
            
            else
            {
                Player current_player = NewPlayer();
                int old_uid = Int32.MinValue;

                if (currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == playerName))
                {
                    current_player = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == playerName).Value;
                    old_uid = current_player.UID;
                }

                current_player.Nickname = playerName;
                current_player.SpawnPosition = spawnPosition;
                current_player.BuildHash = buildHash;
                current_player.UID = uid;
                current_player.Bot = bot;
                current_player.PartyID = partyID;
                current_player.PowerScore = powerScore;
                current_player.Team = team;
                currentSession.CurrentMatch.PlayerRecords.Add(uid, current_player);

                if (old_uid != Int32.MinValue)
                    currentSession.CurrentMatch.PlayerRecords.Remove(old_uid);
            }

            if (currentSession.CurrentMatch.PlayerRecords[uid].BuildHash == "")
                currentSession.CurrentMatch.PlayerRecords[uid].BuildHash = buildHash;

            if (currentSession.PlayerBuildRecords.ContainsKey(buildHash))
            {
                if (powerScore > currentSession.PlayerBuildRecords[buildHash].PowerScore)
                    currentSession.PlayerBuildRecords[buildHash].PowerScore = powerScore;
            }
            else
            {
                BuildRecord new_build = NewBuildRecord();
                new_build.BuildHash = buildHash;
                new_build.PowerScore = powerScore;
                currentSession.PlayerBuildRecords.Add(buildHash, new_build);
            }
        }

        public static void PlayerLeaveEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})         \| client: player (?<spawn_position>[^\s]+) leave game$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            int spawn_position = Int32.Parse(lineResults.Groups["spawn_position"].Value.Replace(" ", ""));
            int uid = currentSession.CurrentMatch.PlayerRecords.FirstOrDefault(x => x.Value.SpawnPosition == spawn_position).Key;


            //for (int i = 0; i < Current_session.current_match.player_records.Count; i++)
            //{
            //    Player player = Current_session.current_match.player_records[i];

            //    if (player.nickname == null)
            //        continue;

            //    if (player.spawn_position == spawn_position)
            //        Current_session.current_match.player_records.Remove(player.uid);
            //}

            //if (player_name == null) /* observer in custom game left */
            //    return;

            if (currentSession.CurrentMatch.PlayerRecords.ContainsKey(uid))
            {
                if (currentSession.CurrentMatch.PlayerRecords[uid].PowerScore == 0 &&
                    currentSession.CurrentMatch.PlayerRecords[uid].Stats.Damage == 0 &&
                    currentSession.CurrentMatch.PlayerRecords[uid].Stats.DamageTaken == 0)
                {
                    currentSession.CurrentMatch.PlayerRecords.Remove(uid);
                }

            }
        }

        public static void AddMobEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                return;

            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Spawn mob. def '(?<mob_name>[^']+)'");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string mob_name = lineResults.Groups["mob_name"].Value;
            int uid = GlobalData.AssignBotUid(mob_name);

            if (!currentSession.CurrentMatch.PlayerRecords.ContainsKey(uid))
            {
                Player current_player = NewPlayer();
                current_player.Nickname = mob_name;
                current_player.UID = uid;
                current_player.Bot = 1;
                current_player.Team = 2;
                currentSession.CurrentMatch.PlayerRecords.Add(uid, current_player);
            }
        }

        public static void StripeEvent(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Stripe '(?<stripe>[^']+)' value increased by (?<increment>[^\s]+) for player (?<player_number>[^\s]+) \[(?<player_name>.*)\]");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string stripe_desc = lineResults.Groups["stripe"].Value;
            int stripe_increment = Int32.Parse(lineResults.Groups["increment"].Value);
            string player_name = lineResults.Groups["player_name"].Value;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == player_name))
                return;

            int uid = currentSession.CurrentMatch.PlayerRecords.FirstOrDefault(x => x.Value.Nickname == player_name).Value.UID;

            if (stripe_desc == "PvpTurretKill")
            {
                currentSession.CurrentMatch.PlayerRecords[uid].Stats.DroneKills += 1;
            }
            currentSession.CurrentMatch.PlayerRecords[uid].Stripes.Add(stripe_desc);

        }
        public static void DamageEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch && !currentSession.LiveTraceData)
                return;

            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Damage\. Victim: (?<victim>[^,]+), attacker: (?<attacker>[^,]+), weapon '(?<weapon>[^']+)', damage: (?<damage>[^\s]+) (?<flags>.+)$");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string attacker = lineResults.Groups["attacker"].Value.Replace(" ", "");
            string victim = lineResults.Groups["victim"].Value.Replace(" ", "");
            double damage = Convert.ToDouble(lineResults.Groups["damage"].Value);
            string weapon = lineResults.Groups["weapon"].Value;
            string weapon_name = "";
            bool ram_damage = false;
            string flags = lineResults.Groups["flags"].Value;
            bool foundDamageRecord = false;
            double cabinDamage = flags.Contains("HUD_IMPORTANT") ? damage : 0.0;

            weapon = weapon.Substring(0, weapon.IndexOf(':') > 0 ? weapon.IndexOf(':') : weapon.Length);

            if (attacker.IndexOf(":") > 0)
                return;

            if (victim.IndexOf(":") > 0)
                return;

            if (currentSession.StaticRecords.CKDict.ContainsKey(weapon))
                weapon = currentSession.StaticRecords.CKDict[weapon].ToString();

            weapon_name = weapon;

            if (!currentSession.StaticRecords.GlobalWeaponDict.ContainsKey(weapon) &&
                !currentSession.StaticRecords.GlobalExplosivesDict.ContainsKey(weapon) &&
                weapon != "Cabin_Tribal_Hog" && weapon != "Cabin_InnateMelee")
                ram_damage = true;

            if (ram_damage && currentSession.CundleDamageIntoRamming)
                weapon_name = "Ramming";

            if (currentSession.InGarage)
            {
                currentSession.GarageData.DamageRecord = new GarageDamageRecord { Attacker = attacker, Time = currentSession.CurrentCombatLogTime, Weapon = weapon_name, Damage = damage, Flags = flags };
                return;
            }

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == attacker))
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == victim))
                return;

            int attackerUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == attacker).Value.UID;
            int victimUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == victim).Value.UID;

            if (attackerUID == currentSession.LocalUserUID || victimUID == currentSession.LocalUserUID)
            {
                foreach (DamageRecord record in currentSession.CurrentMatch.DamageRecord)
                {
                    if (attacker == record.Attacker && victim == record.Victim && weapon_name == record.Weapon)
                    {
                        foundDamageRecord = true;
                        record.Damage += damage;
                        break;
                    }
                }

                if (!foundDamageRecord)
                    currentSession.CurrentMatch.DamageRecord.Add(new DamageRecord { Attacker = attacker, Victim = victim, Weapon = weapon_name, Damage = damage });
            }

            foundDamageRecord = false;

            if (ram_damage)
                weapon_name = "Ramming";

            foreach (RoundDamageRecord record in currentSession.CurrentMatch.RoundRecords.Last().DamageRecords)
            {
                if (attacker == record.Attacker && weapon_name == record.Weapon)
                {
                    foundDamageRecord = true;
                    record.Damage += damage;
                    break;
                }
            }

            if (!foundDamageRecord)
                currentSession.CurrentMatch.RoundRecords.Last().DamageRecords.Add(new RoundDamageRecord { Attacker = attacker, Weapon = weapon_name, Damage = damage });

            if (attacker != victim)
            {
                if (currentSession.PlayerBuildRecords.ContainsKey(currentSession.CurrentMatch.PlayerRecords[attackerUID].BuildHash))
                {
                    if (!currentSession.PlayerBuildRecords[currentSession.CurrentMatch.PlayerRecords[attackerUID].BuildHash].Parts.Contains(weapon) &&
                        !currentSession.StaticRecords.GlobalExplosivesDict.ContainsKey(weapon))
                    {
                        currentSession.PlayerBuildRecords[currentSession.CurrentMatch.PlayerRecords[attackerUID].BuildHash].Parts.Add(weapon);
                    }
                }

                currentSession.CurrentMatch.PlayerRecords[attackerUID].Stats.Damage += damage;
                currentSession.CurrentMatch.PlayerRecords[attackerUID].Stats.CabinDamage += cabinDamage;
                currentSession.CurrentMatch.PlayerRecords[victimUID].Stats.DamageTaken += damage;
            }
        }
        public static void KillEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                return;

            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Kill. Victim: (?<victim>.+) killer: (?<killer>.+)");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string killer = lineResults.Groups["killer"].Value.Replace(" ", "");
            string victim = lineResults.Groups["victim"].Value.Replace(" ", "");

            currentSession.CurrentMatch.AssistTracking = new AssistTracking { Killer = killer, Victim = victim, Assisters = new List<string> { } };

            if (killer.IndexOf(":") > 0)
                return;
            if (victim.IndexOf(":") > 0)
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == killer))
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == victim))
                return;

            int killerUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == killer).Key;
            int victimUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == victim).Key;

            if (killerUID == currentSession.LocalUserUID && currentSession.CurrentMatch.PlayerRecords[victimUID].Bot == 0)
                currentSession.CurrentMatch.Victims.Add(victim);

            if (victimUID == currentSession.LocalUserUID && currentSession.CurrentMatch.PlayerRecords[killerUID].Bot == 0)
                currentSession.CurrentMatch.Nemesis = killer;

            currentSession.CurrentMatch.PlayerRecords[killerUID].Stats.Kills += 1;
            currentSession.CurrentMatch.PlayerRecords[victimUID].Stats.Deaths += 1;
        }

        public static void KillAssistEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                return;

            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| 	 assist by (?<assistant>.+?)weapon: ");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string assistant = lineResults.Groups["assistant"].Value.Replace(" ", "");

            if (assistant == null || assistant == "")
                return;

            if (assistant == currentSession.CurrentMatch.AssistTracking.Killer)
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == assistant))
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == currentSession.CurrentMatch.AssistTracking.Killer))
                return;

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == currentSession.CurrentMatch.AssistTracking.Victim))
                return;

            int assistantUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == assistant).Key;

            if (!currentSession.CurrentMatch.AssistTracking.Assisters.Contains(assistant))
            {
                currentSession.CurrentMatch.AssistTracking.Assisters.Add(assistant);
                currentSession.CurrentMatch.PlayerRecords[assistantUID].Stats.Assists += 1;
            }
        }

        public static void ScoreEvent(string line, SessionStats currentSession)
        {
            if (!currentSession.InMatch)
                return;

            Match lineResults = Regex.Match(line, @"^(?<hour>[0-9]{2}):(?<minute>[0-9]{2}):(?<second>[0-9]{2})\.(?<millisecond>[0-9]{3})\| Score:		player: (?<player_number>.+?),		nick:(?<nickname>.*),		Got:(?<score>.+?),		reason: (?<score_reason>.*)");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string scorer = lineResults.Groups["nickname"].Value.Replace(" ", "");
            string nickname = lineResults.Groups["nickname"].Value.Replace(" ", "");
            string scoreName = lineResults.Groups["score_reason"].Value.Replace(" ", "");
            int points = Int32.Parse(lineResults.Groups["score"].Value);

            if (!currentSession.CurrentMatch.PlayerRecords.Any(x => x.Value.Nickname == scorer))
                return;

            int scorerUID = currentSession.CurrentMatch.PlayerRecords.First(x => x.Value.Nickname == scorer).Key;

            currentSession.CurrentMatch.PlayerRecords[scorerUID].Stats.Score += points;

            if (currentSession.CurrentMatch.PlayerRecords[scorerUID].Scores.FirstOrDefault(x => x.Name == scoreName) == null)
            {
                currentSession.CurrentMatch.PlayerRecords[scorerUID].Scores.Add(new Score { Name = scoreName, Description = DecodeScoreType(scoreName), Points = points });
            }
            else
            {
                currentSession.CurrentMatch.PlayerRecords[scorerUID].Scores.FirstOrDefault(x => x.Name == scoreName).Points += points;
            }
        }

        public static void AssignMatchProperty(string line, SessionStats currentSession)
        {
            Match lineResults = Regex.Match(line, @"""(?<attribute_name>.+?)"": (?<attribute_value>.*?)");

            if (lineResults.Groups.Count < 2)
            {
                MessageBox.Show(string.Format(@"Error with line {0}", line));
                return;
            }

            string attribute_name = lineResults.Groups["attribute_name"].Value.Replace(" ", "");
            string attribute_value = lineResults.Groups["attribute_value"].Value.Replace(" ", "");

            if (!currentSession.InMatch)
                currentSession.PendingAttributes.Attributes.Add(NewMatchAttribute(attribute_name, attribute_value));
            else
                currentSession.CurrentMatch.MatchAttributes.Add(NewMatchAttribute(attribute_name, attribute_value));
        }

        public static string DecodeScoreType(string score)
        {
            switch (score)
            {
                case "INTERCEPT":
                    return "Intercept";
                case "FIRST_DAMAGE":
                    return "First Hit";
                case "PART_DETACH":
                    return "Part Detach";
                case "KILL":
                    return "Kill";
                case "OBJECTIVE":
                    return "Objective";
                case "POINT_CAPTURE":
                    return "Point Capture";
                case "SHIELD":
                    return "Shield";
                default:
                    return score;
            }
        }

        public static string DecodeMatchType(int matchType)
        {
            switch (matchType)
            {
                case GlobalData.STANDARD_MATCH:
                    return "8v8";
                case GlobalData.STANDARD_CW_MATCH:
                    return "CW";
                case GlobalData.LEVIATHIAN_CW_MATCH:
                    return "Levi CW";
                case GlobalData.BATTLE_ROYALE_MATCH:
                    return "Battle Royale";
                case GlobalData.LEAGUE_6_v_6_MATCH:
                    return "6v6";
                case GlobalData.ARENA_CASUAL_MATCH:
                    return "Arena (Casual)";
                case GlobalData.ARENA_RANKED_MATCH:
                    return "Arena (Ranked)";
                case GlobalData.EASY_RAID_MATCH:
                    return "Easy Raid";
                case GlobalData.MED_RAID_MATCH:
                    return "Medium Raid";
                case GlobalData.HARD_RAID_MATCH:
                    return "Hard Raid";
                case GlobalData.CUSTOM_MATCH:
                    return "Custom Game";
                case GlobalData.TEST_SERVER_MATCH:
                    return "Test Server";
                case GlobalData.BEDLAM_MATCH:
                    return "Bedlam";
                case GlobalData.PRESENT_HEIST_MATCH:
                    return "Present Heist";
                case GlobalData.ADVENTURE_MATCH:
                    return "Adventure";
                case GlobalData.PATROL_MATCH:
                    return "Patrol";
                case GlobalData.STANDARD_RESTRICTED_MATCH:
                    return "Restricted 8v8";
                case GlobalData.CANNON_BRAWL_MATCH:
                    return "Cannon Brawl";
                case GlobalData.WINTER_MAYHAM_MATCH:
                    return "Winter Mayhem";
                case GlobalData.FREE_FOR_ALL_MATCH:
                    return "FFA";
                case GlobalData.STORMS_WARNING_MATCH:
                    return "Storms Warning";
                case GlobalData.ROCKET_LEAGUE_MATCH:
                    return "Football";
                case GlobalData.SCORPION_MATCH:
                    return "BBS";
                case GlobalData.RACE_MATCH:
                    return "Race";
                case GlobalData.RACE_WHEELS_ONLY_MATCH:
                    return "Race: Only Wheels";
                case GlobalData.HALLOWEEN_MATCH:
                    return "Witch Hunt";
                case GlobalData.DRONE_BATTLE_MATCH:
                    return "Drone Battle";
                case GlobalData.CROSSOUT_DAY_BRAWL_MATCH:
                    return "Crossout Day Brawl";
                case GlobalData.GOZU_MATCH:
                    return "Gozu";
                case GlobalData.WITCH_HUNT_MATCH:
                    return "Witch Hunt";
                case GlobalData.BOMB_PLANT_MATCH:
                    return "Sabotage";
                case GlobalData.BOARS_MATCH:
                    return "Boars";
                case GlobalData.OPERATION_RED_LIGHT_MATCH:
                    return "Operation Red Light";
                case GlobalData.INVASION_MATCH:
                    return "Invasion";
                case GlobalData.UNDEFINED_MATCH:
                    return "Undefined";
                default:
                    return matchType.ToString();
            }
        }

        public string DecodeFactionName(int faction)
        {
            switch (faction)
            {
                case GlobalData.ENGINEER_FACTION:
                    return "Engineers";
                case GlobalData.LUNATICS_FACTION:
                    return "Lunatics";
                case GlobalData.NOMADS_FACTION:
                    return "Nomads";
                case GlobalData.SCAVENGERS_FACTION:
                    return "Scavengers";
                case GlobalData.STEPPENWOLFS_FACTION:
                    return "Steppenwolfs";
                case GlobalData.DAWNS_CHILDREN_FACTION:
                    return "Dawns Children";
                case GlobalData.FIRESTARTERS_FACTION:
                    return "Firestarters";
                case GlobalData.FOUNDERS_FACTION:
                    return "Founders";
                default:
                    return "Undefined";
            }
        }

        private static void ClassifyLocalUserBuild(SessionStats currentSession)
        {
            string long_description = "";
            string short_description = "";

            if (currentSession.CurrentMatch.PlayerRecords[currentSession.LocalUserUID].BuildHash == "")
                return;

            BuildRecord localBuild = currentSession.PlayerBuildRecords[currentSession.CurrentMatch.PlayerRecords[currentSession.LocalUserUID].BuildHash];

            //CABIN NAMING
            if (localBuild.Cabin.Description.Length > 0)
            {
                long_description += localBuild.Cabin.Description;
                long_description += " cabin ";
            }

            //WEAPON NAMING
            if (localBuild.Weapons.Count() == 0)
            {
                long_description += "weaponless build ";
                if (localBuild.Cabin.Description.Length > 0)
                {
                    short_description += localBuild.Cabin.Description;
                    short_description += " ";
                }
            }
            else
            if (localBuild.Weapons.Count() == 1)
            {
                long_description += string.Format(@"{0} ", localBuild.Weapons[0].Description);
                short_description += string.Format(@"{0} ", localBuild.Weapons[0].Description);
            }
            else
            {
                //determine if all weapons are of the same category
                string expected_category = localBuild.Weapons[0].WeaponClass;
                bool class_flag = false;
                foreach (PartLoader.Weapon weapon in localBuild.Weapons)
                {
                    if (weapon.WeaponClass != expected_category)
                        class_flag = true;
                }
                if (class_flag == false)
                {
                    List<PartLoader.Weapon> sorted_weapons = localBuild.Weapons.OrderByDescending(x => x.Rarity).ToList();
                    foreach (PartLoader.Weapon weapon in sorted_weapons)
                    {
                        long_description += string.Format(@"{0} ", weapon.Description);
                    }
                    short_description += string.Format(@"{0} ", localBuild.Weapons[0].WeaponClass);
                }
                else
                {
                    //order weapon names correctly for builds with mixed weapons
                    List<PartLoader.Weapon> sorted_weapons = localBuild.Weapons.OrderByDescending(x => x.Rarity).ToList();
                    List<PartLoader.Weapon> sorted_supports = new List<PartLoader.Weapon>();
                    foreach (PartLoader.Weapon weapon in sorted_weapons)
                    {
                        if (weapon.WeaponClass == "tesla emitter" || weapon.WeaponClass == "drone" || weapon.WeaponClass == "turret"
                            || weapon.WeaponClass == "harpoon" || weapon.WeaponClass == "explosive melee" || weapon.WeaponClass == "laser minigun")
                        {
                            sorted_supports.Add(weapon);
                        }
                        else
                        {
                            long_description += string.Format(@"{0} ", weapon.Description);
                            short_description += string.Format(@"{0} ", weapon.Description);
                        }
                    }
                    foreach (PartLoader.Weapon weapon in sorted_supports)
                    {
                        long_description += string.Format(@"{0} ", weapon.Description);
                    }
                }
            }

            //MOVEMENT PART NAMING
            if (localBuild.Movement.Count() == 0)
            {
                long_description += "";
            }
            else
            if (localBuild.Movement.Count() == 1)
            {
                long_description += string.Format(@"on {0}s ", localBuild.Movement[0].Description);
                short_description += string.Format(@"on {0}s ", localBuild.Movement[0].Description);
            }
            else
            {
                long_description += "on ";
                int movement_count = 1;
                foreach (PartLoader.Movement movement in localBuild.Movement) //long description stuff
                {
                    long_description += movement.Description;
                    if (movement_count < localBuild.Movement.Count() - 1)
                    {
                        long_description += ", ";
                    }
                    else
                    if (movement_count < localBuild.Movement.Count())
                    {
                        long_description += " and ";
                    }
                    else
                    {
                        long_description += " ";
                    }
                    movement_count++;
                }
                string expected_category = localBuild.Movement[0].Category; //short description stuff
                bool class_flag = false;
                foreach (PartLoader.Movement movement in localBuild.Movement)
                {
                    if (movement.Category != expected_category)
                    {
                        class_flag = true;
                    }
                }
                if (class_flag == false)
                {
                    short_description += localBuild.Movement[0].Category;
                }
                else
                {
                    string short_movement_desc = "";
                    if (localBuild.Movement.Select(x => x.Category.Contains("wheel")).Count() > 0)
                    {
                        short_movement_desc = "wheels";
                    }
                    if (localBuild.Movement.Select(x => x.Category.Contains("track")).Count() > 0)
                    {
                        short_movement_desc = "tracks";
                    }
                    if (localBuild.Movement.Select(x => x.Category == "auger").Count() > 0)
                    {
                        short_movement_desc = "augers";
                    }
                    if (localBuild.Movement.Select(x => x.Category == "hover").Count() > 0)
                    {
                        short_movement_desc = "hovers";
                    }
                    if (localBuild.Movement.Select(x => x.Description == "Bigram").Count() > 0)
                    {
                        if (localBuild.Movement.Select(x => x.Category.Contains("wheel")).Count() > 0)
                        {
                            short_movement_desc = "wheels";
                        }
                        else
                        {
                            short_movement_desc = "legs";
                        }
                    }
                    if (localBuild.Movement.Select(x => x.Description == "ML 200").Count() > 0)
                    {
                        short_movement_desc = "legs";
                    }
                    short_description += short_movement_desc;
                }

            }

            //MODULE NAMING
            if (localBuild.Modules.Count() == 0)
            {
                long_description += "";
            }
            else
            {
                long_description += "with ";
                int module_count = 1;
                foreach (PartLoader.Module module in localBuild.Modules)
                {
                    if (module.ModuleClass != "connector" && module.Name != "CarPart_ModuleRadio")
                    {
                        long_description += module.Description;
                        if (module_count < localBuild.Modules.Count() - 1)
                        {
                            long_description += ", ";
                        }
                        else
                        if (module_count < localBuild.Modules.Count())
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
            if (localBuild.Engine.Description == "")
            {
                long_description += "";
            }
            else
            {
                if (localBuild.Modules.Count() == 0)
                {
                    long_description += "with ";
                }
                else
                {
                    long_description += "and ";
                }
                long_description += localBuild.Engine.Description;
                long_description += " engine";
            }

            localBuild.ArchetypeDescription = "";
            localBuild.FullDescription = long_description;
            localBuild.ShortDescription = short_description;
            currentSession.PlayerBuildRecords[currentSession.CurrentMatch.PlayerRecords[currentSession.LocalUserUID].BuildHash] = localBuild;
        }

        public static void GenerateStatCard(SessionStats currentSession)
        {
            if (!currentSession.CurrentMatch.PlayerRecords.ContainsKey(currentSession.LocalUserUID))
                return;

            int game_mode = GlobalData.STANDARD_MATCH;
            int totalWins;
            int totalLosses;
            int totalGames;
            double totalDamage;
            int totalKills;
            int totalDeaths;

            totalWins = 0;
            totalLosses = 0;
            totalGames = 0;

            if (totalGames == 0)
                return;

            totalDamage = 0;
            totalKills = 0;
            totalDeaths = 0;

            List<String> lines = new List<String> { };

            lines.Add(String.Format(" {0} STATS", DecodeMatchType(game_mode)));
            lines.Add(String.Format("---------------------------------"));
            lines.Add(String.Format(" Games            {0,15}", totalGames));
            lines.Add(String.Format(" W/L (%)         {0,4}/{1,-4} ({2,4:N2})", totalWins, totalLosses, (double)totalWins / (double)totalGames));
            lines.Add(String.Format(" K/D (%)         {0,4}/{1,-4} ({2,4:N2})", totalKills, totalDeaths, (double)totalKills / (double)totalDeaths));
            lines.Add(String.Format(" K/G (%)         {0,4}/{1,-4} ({2,4:N2})", totalKills, totalGames, (double)totalKills / (double)totalGames));
            lines.Add(String.Format(" Avg Dmg          {0,15:N1}", totalDamage / totalGames));

            //File.WriteAllLines(Current_session.file_data.stat_card_file, lines);
        }



        #endregion
        #region class_managment
        private static Player NewPlayer()
        {
            Player player = new Player
            {
                Nickname = "",
                UID = 0,
                Bot = 0,
                PartyID = 0,
                SpawnPosition = -1,
                Round = 0,
                BuildHash = "",
                PowerScore = 0,
                Team = 0,
                Stats = NewStats(),
                Scores = new List<Score> { },
                Stripes = new List<string> { }
            };

            return player;
        }

        private static LogSession NewLogSession(FileInfo combat, FileInfo game)
        {
            return new LogSession
            {
                Processed = false,
                CombatLog = combat,
                GameLog = game
            };
        }

        public static Stats NewStats()
        {
            return new Stats
            {
                Kills = 0,
                Assists = 0,
                Deaths = 0,
                DroneKills = 0,
                Score = 0,
                Damage = 0.0,
                DamageTaken = 0.0,
                CabinDamage = 0.0,
                Games = 0,
                Rounds = 1,
                Wins = 0,
                Losses = 0
            };
        }

        public static Stats SumStats(Stats a, Stats b)
        {
            return new Stats
            {
                Games = a.Games + b.Games,
                Rounds = a.Rounds + b.Rounds,
                Kills = a.Kills + b.Kills,
                Assists = a.Assists + b.Assists,
                Deaths = a.Deaths + b.Deaths,
                DroneKills = a.DroneKills + b.DroneKills,
                Score = a.Score + b.Score,
                Damage = a.Damage + b.Damage,
                DamageTaken = a.DamageTaken + b.DamageTaken,
                CabinDamage = a.CabinDamage + b.CabinDamage,
                Wins = a.Wins + b.Wins,
                Losses = a.Losses + b.Losses
            };
        }

        public static Stats SubStats(Stats a, Stats b)
        {
            return new Stats
            {
                Games = a.Games - b.Games,
                Rounds = a.Rounds - b.Rounds,
                Kills = a.Kills - b.Kills,
                Assists = a.Assists - b.Assists,
                Deaths = a.Deaths - b.Deaths,
                DroneKills = a.DroneKills - b.DroneKills,
                Score = a.Score - b.Score,
                Damage = a.Damage - b.Damage,
                DamageTaken = a.DamageTaken - b.DamageTaken,
                CabinDamage = a.CabinDamage - b.CabinDamage,
                Wins = a.Wins - b.Wins,
                Losses = a.Losses + b.Losses
            };
        }

        private static MatchRecord NewMatchRecord()
        {
            return new MatchRecord
            {
                Team1 = "",
                Team2 = "",
                MatchData = NewMatchData()
            };
        }

        public static MatchData NewMatchData()
        {
            return new MatchData
            {
                MapName = "",
                MapDesc = "",
                MatchType = GlobalData.UNDEFINED_MATCH,
                MatchClassification = GlobalData.UNDEFINED_CLASSIFICATION,
                MatchTypeDesc = "",
                ServerGUID = 0,
                ClientGUID = 0,
                ServerIP = "",
                ServerPort = "",
                HostName = "",
                GameplayDesc = "",
                WinningTeam = -1,
                WinReason = "",
                RoundWinner = -1,
                RoundWinReason = "",
                RoundCount = 1,
                Nemesis = "",
                GameResult = "",
                GamePlayValue = "",
                ClientVersion = "UNDEFINED_CLIENT_VERSION",
                MatchStart = new DateTime { },
                MatchEnd = new DateTime { },
                QueueStart = new DateTime { },
                QueueEnd = new DateTime { },
                RoundEndTime = new DateTime { },
                RoundStartTime = new DateTime { },
                MatchDurationSeconds = 0.0,
                Victims = new List<string> { },
                MatchAttributes = new List<MatchAttribute> { },
                MatchRewards = new Dictionary<string, int> { },
                PremiumReward = false,
                LocalPlayer = NewPlayer(),
                AssistTracking = new AssistTracking { },
                DamageRecord = new List<DamageRecord> { },
                PlayerRecords = new Dictionary<int, Player> { },
                RoundRecords = new List<RoundRecord> { }
            };
        }

        public static BuildRecord NewBuildRecord()
        {
            BuildRecord build = new BuildRecord
            {
                BuildHash = "",
                FullDescription = "",
                ShortDescription = "",
                ArchetypeDescription = "",
                PowerScore = 0,
                Cabin = PartLoader.NewCabin(),
                Engine = PartLoader.NewEngine(),
                Weapons = new List<PartLoader.Weapon> { },
                Modules = new List<PartLoader.Module> { },
                Movement = new List<PartLoader.Movement> { },
                Explosives = new List<PartLoader.Explosive> { },
                Parts = new List<string> { }
            };

            return build;
        }

        public static PendingMatchAttributes NewPendingAttributes()
        {
            return new PendingMatchAttributes
            {
                ServerGUID = 0,
                ClientGUID = 0,
                ServerIP = "",
                ServerPort = "",
                HostName = "",
                Attributes = new List<MatchAttribute> { }
            };
        }

        public static MatchAttribute NewMatchAttribute(string attribute, string value)
        {
            return new MatchAttribute
            {
                Attribute = attribute,
                Value = value
            };
        }

        public static MatchAttribute NewMatchAttribute()
        {
            return new MatchAttribute
            {
                Attribute = "",
                Value = ""
            };
        }

        public FileCompleteResponse NewWorkerResponse()
        {
            return new FileCompleteResponse
            {
                HistoricPercentProcessed = 0.0,
                LoadDesc = ""
            };
        }
        public FileCompleteResponse NewWorkerResponse(double percent, string str)
        {
            return new FileCompleteResponse
            {
                HistoricPercentProcessed = percent,
                LoadDesc = str
            };
        }

        public UserProfileResponse NewUserProfile(List<MatchRecord> matches, Dictionary<string, BuildRecord> builds)
        {
            return new UserProfileResponse
            {
                MatchHistory = matches,
                BuildRecords = builds
            };
        }
        public MatchHistoryResponse NewMatchHistoryList(List<MatchRecord> matchHistory)
        {
            return new MatchHistoryResponse
            {
                MatchHistory = matchHistory
            };
        }

        public MatchEndResponse NewMatchEndResponse(MatchData lastMatch, BuildRecord lastBuild)
        {
            return new MatchEndResponse
            {
                LastMatch = lastMatch,
                LastBuild = lastBuild
            };
        }

        public BuildRecordResponse NewBuildRecordResponse(Dictionary<string, BuildRecord> buildDict)
        {
            return new BuildRecordResponse
            {
                BuildRecords = buildDict
            };
        }

        public StaticRecordResponse NewStaticElementResponse(StaticRecordDB partList)
        {
            return new StaticRecordResponse
            {
                MasterStaticRecords = partList
            };
        }

        public DebugResponse NewDebugResponse(int eventID, string line)
        {
            return new DebugResponse
            {
                EventType = eventID,
                Line = line
            };
        }

        #endregion
    }
}
