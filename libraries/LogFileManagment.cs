using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CO_Driver
{
    public class LogFileManagment
    {
        public class SessionVariables
        {
            public string LocalUserName { get; set; }
            public int LocalUserID { get; set; }
            public string LocalLanguage { get; set; }
            public string LogFileLocation { get; set; }
            public string CODriverLocation { get; set; }
            public string HistoricFileLocation { get; set; }
            public string StreamFileLocation { get; set; }
            public string LiveFileLocation { get; set; }
            public string ConfigFileLocation { get; set; }
            public string DataFileLocation { get; set; }
            public string ScreenshotFileLocation { get; set; }
            public string MarketDataLocation { get; set; }
            public string ErrorLogLocation { get; set; }
            public int EngineerLevel { get; set; }
            public int LunaticsLevel { get; set; }
            public int NomadsLevel { get; set; }
            public int ScavengersLevel { get; set; }
            public int SteppenWolfLevel { get; set; }
            public int DawnsChildrenLevel { get; set; }
            public int FireStartersLevel { get; set; }
            public int FoundersLevel { get; set; }
            public bool UploadData { get; set; }
            public bool IncludePresitgueParts { get; set; }
            public bool SaveCaptures { get; set; }
            public bool TwitchMode { get; set; }
            public bool EndorseCODriver { get; set; }
            public string ActionConfiguration { get; set; }
            public string TwitchSettings { get; set; }
            public bool BundleRamMode { get; set; }
            public bool UploadPostMatch { get; set; }
            public string SelectedTheme { get; set; }
            public Color ForeColor { get; set; }
            public Color BackColor { get; set; }
            public string ClientVersion { get; set; }
            public string PrimaryDisplay { get; set; }
            public List<string> ParsedLogs { get; set; }
            public Dictionary<string, int> UIDLookup { get; set; }
            public Dictionary<string, int> ValidUsers { get; set; }
        }

        public SessionVariables NewSessionVariables()
        {
            return new SessionVariables
            {
                LocalUserName = "",
                LocalUserID = 0,
                LocalLanguage = "English",
                LogFileLocation = "",
                CODriverLocation = "",
                HistoricFileLocation = "",
                LiveFileLocation = "",
                StreamFileLocation = "",
                ConfigFileLocation = "",
                DataFileLocation = "",
                ScreenshotFileLocation = "",
                MarketDataLocation = "",
                ErrorLogLocation = "",
                EngineerLevel = 30,
                LunaticsLevel = 15,
                NomadsLevel = 15,
                ScavengersLevel = 15,
                SteppenWolfLevel = 15,
                DawnsChildrenLevel = 15,
                FireStartersLevel = 15,
                FoundersLevel = 75,
                UploadData = false,
                SaveCaptures = true,
                TwitchMode = false,
                EndorseCODriver = true,
                ActionConfiguration = Overlay.default_overlay_setup(),
                TwitchSettings = Overlay.default_twitch_settings(),
                BundleRamMode = true,
                UploadPostMatch = true,
                SelectedTheme = "Terminal",
                BackColor = Color.Black,
                ForeColor = Color.Lime,
                IncludePresitgueParts = true,
                ClientVersion = GlobalData.CURRENT_VERSION,
                PrimaryDisplay = Screen.PrimaryScreen.DeviceName,
                ParsedLogs = new List<string> { },
                UIDLookup = new Dictionary<string, int> { },
                ValidUsers = new Dictionary<string, int> { }
            };
        }

        public SessionVariables LoadUserSession()
        {
            SessionVariables session = NewSessionVariables();

            CreateSubDirectories(session);
            GetLiveFileLocation(session);
            CopyHistoricFiles(session);
            LoadValidUserList(session);

            session = LoadPreviousSession(session);

            CreateSubDirectories(session);

            if (!session.ValidUsers.ContainsKey(session.LocalUserName) || !session.UIDLookup.ContainsKey(session.LocalUserName))
                FindLocalUserName(session);

            if (session.UIDLookup.ContainsKey(session.LocalUserName))
                session.LocalUserID = session.UIDLookup[session.LocalUserName];

            AssignUserTheme(session);

            SaveSessionConfig(session);
            return session;
        }

        public void LoadValidUserList(SessionVariables session)
        {
            session.ValidUsers = new Dictionary<string, int> { };
            List<FileInfo> last_game_logs;

            try
            {
                last_game_logs = new DirectoryInfo(session.HistoricFileLocation).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.Length).ToList();
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (FileInfo log in last_game_logs)
            {
                using (FileStream game_stream = File.OpenRead(log.FullName))
                {
                    using (StreamReader game_reader = new StreamReader(game_stream))
                    {
                        string game_line;

                        game_line = game_reader.ReadLine();

                        while (game_line != null)
                        {
                            while (game_line != null && (game_line.Length == 0 || game_line.Substring(0, 9) == "--- Date:"))
                                game_line = game_reader.ReadLine();

                            if (game_line.Contains(@"| TargemService:OnGoingOnline:"))
                            {
                                string local_player_name = Regex.Match(game_line, @", nickName '(.+?)',").Groups[1].Value.Replace(" ", "");
                                int uid = Convert.ToInt32(Regex.Match(game_line, @": uid (.+?), ").Groups[1].Value.Replace(" ", ""));

                                if (session.ValidUsers.ContainsKey(local_player_name))
                                    session.ValidUsers[local_player_name] += 1;
                                else
                                    session.ValidUsers.Add(local_player_name, 1);

                                if (!session.UIDLookup.ContainsKey(local_player_name))
                                    session.UIDLookup.Add(local_player_name, uid);
                            }

                            if (game_line.Contains(@"| TSConnectionManager: negotiation complete:"))
                            {
                                string local_player_name = Regex.Match(game_line, @", nickName '(.+?)',").Groups[1].Value.Replace(" ", "");
                                int uid = Convert.ToInt32(Regex.Match(game_line, @": uid (.+?), ").Groups[1].Value.Replace(" ", ""));

                                if (session.ValidUsers.ContainsKey(local_player_name))
                                    session.ValidUsers[local_player_name] += 1;
                                else
                                    session.ValidUsers.Add(local_player_name, 1);

                                if (!session.UIDLookup.ContainsKey(local_player_name))
                                    session.UIDLookup.Add(local_player_name, uid);
                            }

                            if (game_line.Contains(@"| Steam initialized appId"))
                            {
                                string local_player_name = Regex.Match(game_line, @", userName '(.+?)'").Groups[1].Value.Replace(" ", "");
                                if (session.ValidUsers.ContainsKey(local_player_name))
                                    session.ValidUsers[local_player_name] += 1;
                            }

                            game_line = game_reader.ReadLine();
                        }
                    }
                }
            }
        }

        public void SaveSessionConfig(SessionVariables session)
        {
            if (!ValidUserSession(session))
            {
                //MessageBox.Show("Configuration invalid, aborting save.");
                return;
            }

            using (StreamWriter file = File.CreateText(session.ConfigFileLocation + @"\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, session);
            }
        }

        public SessionVariables LoadPreviousSession(SessionVariables session)
        {
            if (!File.Exists(session.ConfigFileLocation + @"\config.json"))
                return session;

            SessionVariables loaded_session = NewSessionVariables();

            try
            {
                using (StreamReader file = File.OpenText(session.ConfigFileLocation + @"\config.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    loaded_session = (SessionVariables)serializer.Deserialize(file, typeof(SessionVariables));
                    loaded_session.ValidUsers = session.ValidUsers;

                    if (!Screen.AllScreens.Any(x => x.DeviceName == loaded_session.PrimaryDisplay))
                        loaded_session.PrimaryDisplay = session.PrimaryDisplay;

                    if (String.IsNullOrEmpty(loaded_session.ActionConfiguration))
                        loaded_session.ActionConfiguration = Overlay.default_overlay_setup();

                    if (String.IsNullOrEmpty(loaded_session.TwitchSettings))
                        loaded_session.TwitchSettings = Overlay.default_twitch_settings();

                    if (ValidUserSession(loaded_session))
                        return loaded_session;
                }
            }
            catch (Exception ex)
            {
            }
            return session;
        }

        public bool ValidUserSession(SessionVariables session)
        {
            bool valid = true;

            //if (session.client_version != global_data.CURRENT_VERSION)
            //    valid = false;

            if (!session.ValidUsers.ContainsKey(session.LocalUserName) && session.LocalUserName != "")
                valid = false;

            if (!Directory.Exists(session.LogFileLocation))
                valid = false;

            if (!Directory.Exists(session.CODriverLocation))
                valid = false;

            if (!Directory.Exists(session.HistoricFileLocation))
                valid = false;

            if (!Directory.Exists(session.StreamFileLocation))
                valid = false;

            if (!Directory.Exists(session.ScreenshotFileLocation))
                valid = false;

            if (!Directory.Exists(session.MarketDataLocation))
                valid = false;

            if (!Directory.Exists(session.ErrorLogLocation))
                valid = false;

            if (session.EngineerLevel < 0 || session.EngineerLevel > 30)
                valid = false;

            if (session.LunaticsLevel < 0 || session.LunaticsLevel > 15)
                valid = false;

            if (session.NomadsLevel < 0 || session.NomadsLevel > 15)
                valid = false;

            if (session.ScavengersLevel < 0 || session.ScavengersLevel > 15)
                valid = false;

            if (session.SteppenWolfLevel < 0 || session.SteppenWolfLevel > 15)
                valid = false;

            if (session.DawnsChildrenLevel < 0 || session.DawnsChildrenLevel > 15)
                valid = false;

            if (session.FireStartersLevel < 0 || session.FireStartersLevel > 15)
                valid = false;

            if (session.FoundersLevel < 0 || session.FoundersLevel > 75)
                valid = false;

            if (session.LocalLanguage != "English" &&
                session.LocalLanguage != "Français" &&
                session.LocalLanguage != "Deutsch" &&
                session.LocalLanguage != "Polski" &&
                session.LocalLanguage != "Pусский" &&
                session.LocalLanguage != "हिन्दी" &&
                session.LocalLanguage != "한국어" &&
                session.LocalLanguage != "Ελληνικά" &&
                session.LocalLanguage != "简体中文" &&
                session.LocalLanguage != "繁體中文" &&
                session.LocalLanguage != "Español")
                valid = false;

            return valid;
        }

        public void AssignUserTheme(SessionVariables session)
        {
            bool valid_theme = false;

            foreach (Theme.ui_theme theme in Theme.themes)
            {
                if (session.SelectedTheme == theme.name)
                    valid_theme = true;
            }

            if (!valid_theme)
            {
                session.SelectedTheme = "Terminal";
            }

            foreach (Theme.ui_theme theme in Theme.themes)
            {
                if (session.SelectedTheme == theme.name)
                {
                    session.ForeColor = theme.fore_ground;
                    session.BackColor = theme.back_ground;
                }
            }
        }

        public void CreateSubDirectories(SessionVariables session)
        {
            if (!Directory.Exists(session.LogFileLocation))
                session.LogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";

            if (!Directory.Exists(session.CODriverLocation))
                session.CODriverLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver";

            if (!Directory.Exists(session.HistoricFileLocation))
                session.HistoricFileLocation = session.CODriverLocation + @"\historic_logs";

            session.StreamFileLocation = session.CODriverLocation + @"\twitch_overlays";

            if (!Directory.Exists(session.ScreenshotFileLocation))
                session.ScreenshotFileLocation = session.CODriverLocation + @"\screenshots";

            if (!Directory.Exists(session.MarketDataLocation))
                session.MarketDataLocation = session.CODriverLocation + @"\market_data";

            if (!Directory.Exists(session.ConfigFileLocation))
                session.ConfigFileLocation = session.CODriverLocation + @"\config";

            if (!Directory.Exists(session.DataFileLocation))
                session.DataFileLocation = session.CODriverLocation + @"\log_data";

            if (!Directory.Exists(session.ErrorLogLocation))
                session.ErrorLogLocation = session.CODriverLocation + @"\error_logs";

            if (!Directory.Exists(session.CODriverLocation))
                Directory.CreateDirectory(session.CODriverLocation);

            if (!Directory.Exists(session.HistoricFileLocation))
                Directory.CreateDirectory(session.HistoricFileLocation);

            if (!Directory.Exists(session.StreamFileLocation))
                Directory.CreateDirectory(session.StreamFileLocation);

            if (!Directory.Exists(session.ScreenshotFileLocation))
                Directory.CreateDirectory(session.ScreenshotFileLocation);

            if (!Directory.Exists(session.MarketDataLocation))
                Directory.CreateDirectory(session.MarketDataLocation);

            if (!Directory.Exists(session.ConfigFileLocation))
                Directory.CreateDirectory(session.ConfigFileLocation);

            if (!Directory.Exists(session.DataFileLocation))
                Directory.CreateDirectory(session.DataFileLocation);

            if (!Directory.Exists(session.ErrorLogLocation))
                Directory.CreateDirectory(session.ErrorLogLocation);
        }

        public void CopyHistoricFiles(SessionVariables session)
        {
            if (session.LogFileLocation.Length == 0)
                return;

            if (session.HistoricFileLocation.Length == 0)
                return;

            FileInfo[] Files;

            try
            {
                Files = new DirectoryInfo(session.LogFileLocation).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray();
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (FileInfo HistoricFile in Files)
            {
                if (HistoricFile.CreationTime == Files.Where(x => Path.GetFileNameWithoutExtension(x.Name) == Path.GetFileNameWithoutExtension(HistoricFile.Name)).OrderByDescending(x => x.CreationTime).FirstOrDefault().CreationTime)
                    continue;

                String destination_file_name = string.Format("{0}{1}{2}{3}{4}{5}", session.HistoricFileLocation, "\\", Path.GetFileNameWithoutExtension(HistoricFile.Name), "_", HistoricFile.CreationTime.ToString("yyyyMMddHHmmss"), ".log");
                FileInfo existing_file;


                if (!File.Exists(destination_file_name))
                {
                    File.Copy(HistoricFile.FullName, destination_file_name);
                    existing_file = HistoricFile;
                }
                else
                    existing_file = new FileInfo(destination_file_name);

                if (HistoricFile.Length != existing_file.Length)
                {
                    try
                    {
                        File.Delete(existing_file.FullName);
                        File.Copy(HistoricFile.FullName, destination_file_name);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("An error has occurred while overriding corrupted log file");
                    }
                }
            }

            try
            {
                Files = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver").GetFiles("*.log", SearchOption.TopDirectoryOnly).ToArray();
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (FileInfo file in Files)
            {
                String destination_file_name = string.Format("{0}{1}{2}{3}", session.HistoricFileLocation, "\\", Path.GetFileNameWithoutExtension(file.Name), ".log");

                if (!File.Exists(destination_file_name))
                {
                    File.Copy(file.FullName, destination_file_name);
                }
                File.Delete(file.FullName);
            }
        }

        public void GetLiveFileLocation(SessionVariables session)
        {
            session.LiveFileLocation = new DirectoryInfo(session.LogFileLocation).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName;
        }

        public void FindLocalUserName(SessionVariables session)
        {
            if (session.ValidUsers.Count() == 0)
            {
                MessageBox.Show("No valid user names were detected. Please try restarting CO_Driver. If problem persists after restart please contact Rot_Fish_Bandit at https://discord.gg/kKcnVXu2Xe");
                Application.Exit();
                return;
            }

            session.LocalUserName = session.ValidUsers.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
