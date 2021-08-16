using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;

namespace CO_Driver
{
    public class log_file_managment
    {
        public class session_variables
        {
            public string local_user_name { get; set; }
            public int local_user_uid { get; set; }
            public string local_language { get; set; }
            public string log_file_location { get; set; }
            public string co_driver_location { get; set; }
            public string historic_file_location { get; set; }
            public string stream_file_location { get; set; }
            public string live_file_location { get; set; }
            public string config_file_location { get; set; }
            public string data_file_location { get; set; }
            public string screenshot_file_location { get; set; }
            public string market_data_file_location { get; set; }
            public string error_log_location { get; set; }
            public int engineer_level { get; set; }
            public int lunatics_level { get; set; }
            public int nomads_level { get; set; }
            public int scavengers_level { get; set; }
            public int steppenwolfs_level { get; set; }
            public int dawns_children_level { get; set; }
            public int firestarts_level { get; set; }
            public int founders_level { get; set; }
            public bool upload_data { get; set; }
            public bool include_prestigue_parts { get; set; }
            public bool save_captures { get; set; }
            public bool twitch_mode { get; set; }
            public bool bundle_ram_mode { get; set; }
            public string selected_theme { get; set; }
            public Color fore_color { get; set; }
            public Color back_color { get; set; }
            public string client_version { get; set; }
            public List<string> parsed_logs { get; set; }
            public Dictionary<string, int> valid_users { get; set; }
            
        }

        public session_variables new_session_variables()
        {
            return new session_variables
            {
                local_user_name = "",
                local_user_uid = 0,
                local_language = "English",
                log_file_location = "",
                co_driver_location = "",
                historic_file_location = "",
                live_file_location = "",
                stream_file_location = "",
                config_file_location = "",
                data_file_location = "",
                screenshot_file_location = "",
                market_data_file_location = "",
                error_log_location = "",
                engineer_level = 30,
                lunatics_level = 15,
                nomads_level = 15,
                scavengers_level = 15,
                steppenwolfs_level = 15,
                dawns_children_level = 15,
                firestarts_level = 15,
                founders_level = 75,
                upload_data = false,
                save_captures = true,
                twitch_mode = false,
                bundle_ram_mode = true,
                selected_theme = "Terminal",
                back_color = Color.Black,
                fore_color = Color.Lime,
                include_prestigue_parts = true,
                client_version = global_data.CURRENT_VERSION,
                parsed_logs = new List<string> { },
                valid_users = new Dictionary<string, int> { }
            };
        }

        public session_variables load_user_session()
        {
            session_variables session = new_session_variables();

            create_sub_directories(session);
            get_live_file_location(session);
            copy_historic_files(session);
            load_valid_user_list(session);

            session = load_previous_settings(session);

            create_sub_directories(session);
            
            if (!session.valid_users.ContainsKey(session.local_user_name))
                find_local_user_name(session);

            assign_user_theme(session);

            save_session_config(session);
            return session;
        }

        public void load_valid_user_list(session_variables session)
        {
            session.valid_users = new Dictionary<string, int> { };
            List<FileInfo> last_game_logs;
            
            try
            {
                last_game_logs = new DirectoryInfo(session.historic_file_location).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToList();
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

                            if (game_line.Contains(@"| TSConnectionManager: negotiation complete:"))
                            {
                                string local_player_name = Regex.Match(game_line, @", nickName '(.+?)',").Groups[1].Value.Replace(" ", "");

                                if (session.valid_users.ContainsKey(local_player_name))
                                    session.valid_users[local_player_name] += 1;
                                else
                                    session.valid_users.Add(local_player_name, 1);
                            }

                            if (game_line.Contains(@"| Steam initialized appId"))
                            {
                                string local_player_name = Regex.Match(game_line, @", userName '(.+?)'").Groups[1].Value.Replace(" ", "");
                                if (session.valid_users.ContainsKey(local_player_name))
                                    session.valid_users[local_player_name] += 1;
                                //else
                                //    session.valid_users.Add(local_player_name, 1);
                            }

                            game_line = game_reader.ReadLine();
                        }
                    }
                }
            }
        }

        public void save_session_config(session_variables session)
        {
            if (!valid_user_session(session))
            {
                //MessageBox.Show("Configuration invalid, aborting save.");
                return;
            }

            using (StreamWriter file = File.CreateText(session.config_file_location + @"\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, session);
            }
        }

        public session_variables load_previous_settings(session_variables session)
        {
            if (!File.Exists(session.config_file_location + @"\config.json"))
                return session;
            
            session_variables loaded_session = new_session_variables();

            try
            {
                using (StreamReader file = File.OpenText(session.config_file_location + @"\config.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    loaded_session = (session_variables)serializer.Deserialize(file, typeof(session_variables));
                    loaded_session.valid_users = session.valid_users;
                    //loaded_session.log_file_location = session.log_file_location;

                    if (valid_user_session(loaded_session))
                        return loaded_session;
                }
            }
            catch (Exception ex)
            {

            }
            return session;
        }

        public bool valid_user_session(session_variables session)
        {
            bool valid = true;

            if (!session.valid_users.ContainsKey(session.local_user_name) && session.local_user_name != "")
                valid = false;

            if (!Directory.Exists(session.log_file_location))
                valid = false;

            if (!Directory.Exists(session.co_driver_location))
                valid = false;

            if (!Directory.Exists(session.historic_file_location))
                valid = false;

            if (!Directory.Exists(session.stream_file_location))
                valid = false;

            if (!Directory.Exists(session.screenshot_file_location))
                valid = false;

            if (!Directory.Exists(session.market_data_file_location))
                valid = false;

            if (!Directory.Exists(session.error_log_location))
                valid = false;

            if (session.engineer_level < 0 || session.engineer_level > 30)
                valid = false;

            if (session.lunatics_level < 0 || session.lunatics_level > 15)
                valid = false;

            if (session.nomads_level < 0 || session.nomads_level > 15)
                valid = false;

            if (session.scavengers_level < 0 || session.scavengers_level > 15)
                valid = false;

            if (session.steppenwolfs_level < 0 || session.steppenwolfs_level > 15)
                valid = false;

            if (session.dawns_children_level < 0 || session.dawns_children_level > 15)
                valid = false;

            if (session.firestarts_level < 0 || session.firestarts_level > 15)
                valid = false;

            if (session.founders_level < 0 || session.founders_level > 75)
                valid = false;

            //if (session.parsed_logs.Count() == 0)
            //    valid = false;

            if (session.client_version != global_data.CURRENT_VERSION)
                valid = false;

            if (session.local_language != "English" &&
                session.local_language != "Français" &&
                session.local_language != "Deutsch" &&
                session.local_language != "Polski" &&
                session.local_language != "Pусский" &&
                session.local_language != "हिन्दी" &&
                session.local_language != "한국어" &&
                session.local_language != "Ελληνικά" &&
                session.local_language != "Español")
                valid = false;

            return valid;
        }

        public void assign_user_theme(session_variables session)
        {
            bool valid_theme = false;

            //if (global_data.supporters.Contains(session.local_user_name))
            //{
                foreach(Theme.ui_theme theme in Theme.themes)
                {
                    if (session.selected_theme == theme.name)
                        valid_theme = true;
                }
            //}
            //else
            //{
            //    if (session.selected_theme == "Terminal" || session.selected_theme == "Static")
            //        valid_theme = true;
            //}

            if (!valid_theme)
            {
                session.selected_theme = "Terminal";
            }

            foreach (Theme.ui_theme theme in Theme.themes)
            {
                if (session.selected_theme == theme.name)
                {
                    session.fore_color = theme.fore_ground;
                    session.back_color = theme.back_ground;
                }
            }
        }

        public void create_sub_directories(session_variables session)
        {
            if (!Directory.Exists(session.log_file_location))
                session.log_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";

            if (!Directory.Exists(session.co_driver_location))
                session.co_driver_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver";

            if (!Directory.Exists(session.historic_file_location))
                session.historic_file_location = session.co_driver_location + @"\historic_logs";

            if (!Directory.Exists(session.stream_file_location))
                session.stream_file_location = session.co_driver_location + @"\stream_templates";

            if (!Directory.Exists(session.screenshot_file_location))
                session.screenshot_file_location = session.co_driver_location + @"\screenshots";

            if (!Directory.Exists(session.market_data_file_location))
                session.market_data_file_location = session.co_driver_location + @"\market_data";

            if (!Directory.Exists(session.config_file_location))
                session.config_file_location = session.co_driver_location + @"\config";

            if (!Directory.Exists(session.data_file_location))
                session.data_file_location = session.co_driver_location + @"\log_data";

            if (!Directory.Exists(session.error_log_location))
                session.error_log_location = session.co_driver_location + @"\error_logs";

            if (!Directory.Exists(session.co_driver_location))
                Directory.CreateDirectory(session.co_driver_location);

            if (!Directory.Exists(session.historic_file_location))
                Directory.CreateDirectory(session.historic_file_location);

            if (!Directory.Exists(session.stream_file_location))
                Directory.CreateDirectory(session.stream_file_location);

            if (!Directory.Exists(session.screenshot_file_location))
                Directory.CreateDirectory(session.screenshot_file_location);

            if (!Directory.Exists(session.market_data_file_location))
                Directory.CreateDirectory(session.market_data_file_location);

            if (!Directory.Exists(session.config_file_location))
                Directory.CreateDirectory(session.config_file_location);

            if (!Directory.Exists(session.data_file_location))
                Directory.CreateDirectory(session.data_file_location);

            if (!Directory.Exists(session.error_log_location))
                Directory.CreateDirectory(session.error_log_location);
        }


        public void find_session_file_path(session_variables session)
        {
            string configuration_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\config";
        }

        public void copy_historic_files(session_variables session)
        {
            if (session.log_file_location.Length == 0)
                return;

            if (session.historic_file_location.Length == 0)
                return;

            FileInfo[] files;

            try
            {
                files = new DirectoryInfo(session.log_file_location).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray();
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (FileInfo file in files)
            {
                if (file.CreationTime == files.Where(x => Path.GetFileNameWithoutExtension(x.Name) == Path.GetFileNameWithoutExtension(file.Name)).OrderByDescending(x => x.CreationTime).FirstOrDefault().CreationTime)
                    continue;
                    
                String destination_file_name = string.Format("{0}{1}{2}{3}{4}{5}", session.historic_file_location, "\\", Path.GetFileNameWithoutExtension(file.Name), "_", file.CreationTime.ToString("yyyyMMddHHmmss"), ".log");
                FileInfo existing_file;


                if (!File.Exists(destination_file_name))
                {
                    File.Copy(file.FullName, destination_file_name);
                    existing_file = file;
                }
                else
                    existing_file = new FileInfo(destination_file_name);

                if (file.Length != existing_file.Length)
                {
                    try
                    {
                        File.Delete(existing_file.FullName);
                        File.Copy(file.FullName, destination_file_name);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("An error has occurred while overriding corrupted log file");
                    }
                }
            }
            
            try
            {
                files = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver").GetFiles("*.log", SearchOption.TopDirectoryOnly).ToArray();
            }
            catch (Exception ex)
            {
                return;
            }

            foreach (FileInfo file in files)
            {
                String destination_file_name = string.Format("{0}{1}{2}{3}", session.historic_file_location, "\\", Path.GetFileNameWithoutExtension(file.Name), ".log");

                if (!File.Exists(destination_file_name))
                {
                    File.Copy(file.FullName, destination_file_name);
                }
                File.Delete(file.FullName);
            }
        }

        public void get_live_file_location(session_variables session)
        {
            session.live_file_location = new DirectoryInfo(session.log_file_location).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName;
        }

        public void find_local_user_name(session_variables session)
        {
            if (session.valid_users.Count() == 0)
            {
                MessageBox.Show("No valid user names were detected. Please try restarting CO_Driver. If problem persists after restart please contact Rot_Fish_Bandit at https://discord.gg/kKcnVXu2Xe");
                Application.Exit();
                return;
            }

            session.local_user_name = session.valid_users.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
