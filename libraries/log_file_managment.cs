using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

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
            public bool save_captures { get; set; }
            public Color fore_color { get; set; }
            public Color back_color { get; set; }
            public List<ui_theme> themes { get; set; }
        }

        public class ui_theme
        {
            public string name { get; set; }
            public Color fore_ground { get; set; }
            public Color back_ground { get; set; }
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
                save_captures = true,
                back_color = Color.Black,
                fore_color = Color.Lime,
                include_prestigue_parts = true,
                themes = populate_available_themes()
            };
        }
        
        public List<ui_theme> populate_available_themes()
        {
            List<ui_theme> themes = new List<ui_theme> { };
            themes.Add(new ui_theme { name = "Terminal", fore_ground = Color.Lime, back_ground = Color.Black });
            themes.Add(new ui_theme { name = "Static", fore_ground = Color.FromArgb(245,245,245), back_ground = Color.Black });
            themes.Add(new ui_theme { name = "Blabadon", fore_ground = Color.FromArgb(235, 117, 55), back_ground = Color.FromArgb(29,35,40)});
            themes.Add(new ui_theme { name = "Eris", fore_ground = Color.FromArgb(247, 247, 247), back_ground = Color.FromArgb(54, 57, 63) });
            themes.Add(new ui_theme { name = "Isotope", fore_ground = Color.FromArgb(198, 245, 165), back_ground = Color.Black });
            themes.Add(new ui_theme { name = "Mint Oreo", fore_ground = Color.FromArgb(154, 246, 189), back_ground = Color.FromArgb(31, 20, 11) });
            themes.Add(new ui_theme { name = "S C R O L L", fore_ground = Color.FromArgb(171, 171, 171), back_ground = Color.FromArgb(25, 25, 25) });
            themes.Add(new ui_theme { name = "Ravage", fore_ground = Color.FromArgb(245, 21, 118), back_ground = Color.FromArgb(12, 24, 14) });
            themes.Add(new ui_theme { name = "Yakuza", fore_ground = Color.FromArgb(245, 106, 246), back_ground = Color.FromArgb(0, 16, 36) });
            themes.Add(new ui_theme { name = "Foiu7dnfr", fore_ground = Color.FromArgb(246, 207, 70), back_ground = Color.FromArgb(18, 18, 18) });
            themes.Add(new ui_theme { name = "Step on Wolf", fore_ground = Color.FromArgb(234, 240, 207), back_ground = Color.FromArgb(37, 49, 14) });
            themes.Add(new ui_theme { name = "Don's Children", fore_ground = Color.FromArgb(36, 246, 236), back_ground = Color.FromArgb(31, 24, 6) });
            themes.Add(new ui_theme { name = "Arson", fore_ground = Color.FromArgb(246, 125, 35), back_ground = Color.FromArgb(27, 10, 10) });
            themes.Add(new ui_theme { name = "Trucker Cab Best Cab", fore_ground = Color.FromArgb(246, 195, 35), back_ground = Color.FromArgb(22, 20, 10) });
            themes.Add(new ui_theme { name = "Nomadic", fore_ground = Color.FromArgb(195, 191, 148), back_ground = Color.FromArgb(33, 37, 31) });

            return themes;
        }

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
