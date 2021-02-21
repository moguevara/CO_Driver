using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CO_Driver
{
    public class log_file_managment
    {
        public class session_variables
        {
            public string local_user_name { get; set; }
            public int local_user_uid { get; set; }
            public string document_location { get; set; }
            public string log_file_location { get; set; }
            public string historic_file_location { get; set; }
            public string stream_file_location { get; set; }
            public string live_file_location { get; set; }
            public int engineer_level { get; set; }
            public int lunatics_level { get; set; }
            public int nomads_level { get; set; }
            public int scavengers_level { get; set; }
            public int steppenwolfs_level { get; set; }
            public int dawns_children_level { get; set; }
            public int firestarts_level { get; set; }
            public int founders_level { get; set; }
            public bool include_prestigue_parts { get; set; }
        }

        public session_variables new_session_variables()
        {
            return new session_variables
            {
                local_user_name = "test",
                local_user_uid = 0,
                document_location = "",
                log_file_location = "",
                historic_file_location = "",
                live_file_location = "",
                stream_file_location = "",
                engineer_level = 30,
                lunatics_level = 15,
                nomads_level = 15,
                scavengers_level = 15,
                steppenwolfs_level = 15,
                dawns_children_level = 15,
                firestarts_level = 15,
                founders_level = 75,
                include_prestigue_parts = true
            };
        }


        //public void load_user_settings()
        //{
        //    session = new log_file_managment.session_variables { engineer_level = 30, lunatics_level = 15, dawns_children_level = 15, firestarts_level = 15, founders_level = 75, include_prestigue_parts = true, nomads_level = 15, scavengers_level = 15, steppenwolfs_level = 15 };

        //    log_file_manager.find_log_file_path(session);
        //    log_file_manager.find_historic_file_path(session);
        //    log_file_manager.find_local_user_name(session);

        //    this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found local user_name ""{0}""" + Environment.NewLine, session.local_user_name));
        //    this.welcome_screen.tb_progress_tracking.AppendText("Loading parts for optimizer." + Environment.NewLine);

        //    log_file_manager.copy_historic_files(session);

        //    this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Copying local files to ""{0}""" + Environment.NewLine, session.historic_file_location));

        //    log_file_manager.get_live_file_location(session);
        //    log_file_manager.create_stream_file_location(session);

        //    this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found live combat file to ""{0}""" + Environment.NewLine, session.live_file_location));
        //}

        //public void load_user_settings(session_variables session)
        //{
        //    session = new_session_variables();

        //    session.log_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
        //    session.historic_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\historic_logs";
        //    session.live_file_location = new DirectoryInfo(session.log_file_location).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName;

        //}


        //public bool user_configuration_exists(session_variables session)
        //{
        //    if ()


        //    return false;
        //}

        public void find_log_file_path(session_variables session)
        {
            string log_file_path = session.log_file_location;

            if (!Directory.Exists(log_file_path))
            {
                log_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                if (Directory.Exists(log_file_path))
                {
                    session.log_file_location = log_file_path;
                }
            }
        }
        public void find_historic_file_path(session_variables session)
        {
            string historic_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\historic_logs";

            if (!Directory.Exists(historic_file_path))
            {
                Directory.CreateDirectory(historic_file_path);
            }

            if (historic_file_path != session.historic_file_location)
            {
                session.historic_file_location = historic_file_path;
            }
        }

        public void copy_historic_files(session_variables session)
        {
            if (session.log_file_location.Length == 0)
                return;

            if (session.historic_file_location.Length == 0)
                return;

            bool first = true;
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
                if (first)
                {
                    first = false;
                }
                else
                {
                    String destination_file_name = string.Format("{0}{1}{2}{3}{4}{5}", session.historic_file_location, "\\", Path.GetFileNameWithoutExtension(file.Name), "_", file.CreationTime.ToString("yyyyMMddHHmmss"), ".log");

                    if (!File.Exists(destination_file_name))
                        File.Copy(file.FullName, destination_file_name);
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

        public void create_stream_file_location(session_variables session)
        {
            string stream_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\stream_templates";

            if (!Directory.Exists(stream_file_path))
            {
                Directory.CreateDirectory(stream_file_path);
            }

            if (stream_file_path != session.stream_file_location)
            {
                session.stream_file_location = stream_file_path;
            }
        }

        public void get_live_file_location(session_variables session)
        {
            if (session.log_file_location.Length == 0)
                return;

            session.live_file_location = new DirectoryInfo(session.log_file_location).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName;
        }

        public void find_local_user_name(session_variables session)
        {
            FileInfo last_game_log;
            try
            {
                last_game_log = new DirectoryInfo(session.historic_file_location).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            }
            catch (Exception ex)
            {
                return;
            }

            using (FileStream game_stream = File.OpenRead(last_game_log.FullName))
            {
                using (StreamReader game_reader = new StreamReader(game_stream))
                {
                    string game_line;
                    bool found = false;

                    game_line = game_reader.ReadLine();

                    while (game_line != null && !found)
                    {
                        while (game_line != null && (game_line.Length == 0 || game_line.Substring(0, 9) == "--- Date:"))
                            game_line = game_reader.ReadLine();

                        if (game_line.Contains(@"| TSConnectionManager: negotiation complete:"))
                        {
                            string local_player_name = Regex.Match(game_line, @", nickName '(.+?)',").Groups[1].Value.Replace(" ", "");
                            int local_player_uid = Int32.Parse(Regex.Match(game_line, @"complete: uid (.+?),").Groups[1].Value.Replace(" ", ""));
                            session.local_user_name = local_player_name;
                            session.local_user_uid = local_player_uid;
                            found = true;
                        }

                        if (game_line.Contains(@"| Steam initialized appId")) /* QuickSkinner bug fix */
                        {
                            string local_player_name = Regex.Match(game_line, @", userName '(.+?)'").Groups[1].Value.Replace(" ", "");
                            int local_player_uid = 0;
                            session.local_user_name = local_player_name;
                            session.local_user_uid = local_player_uid;
                        }

                        game_line = game_reader.ReadLine();
                    }
                }
            }
        }
    }
}
