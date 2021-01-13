using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CO_Driver.Properties;
using System.IO;
using System.Text.RegularExpressions;

namespace CO_Driver
{
    class log_file_managment
    {
        public void find_log_file_path()
        {
            string log_file_path = Settings.Default["log_file_location"].ToString();

            if (!Directory.Exists(log_file_path))
            {
                log_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                if (Directory.Exists(log_file_path))
                {
                    Settings.Default["log_file_location"] = log_file_path;
                    Settings.Default.Save();
                }
            }
        }
        public void find_historic_file_path()
        {
            string historic_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\historic_logs";

            if (!Directory.Exists(historic_file_path))
            {
                Directory.CreateDirectory(historic_file_path);
            }

            if (historic_file_path != Settings.Default["historic_file_location"].ToString())
            {
                Settings.Default["historic_file_location"] = historic_file_path;
                Settings.Default.Save();
            }
        }

        public void copy_historic_files()
        {
            if (Settings.Default["log_file_location"].ToString().Length == 0)
                return;

            if (Settings.Default["historic_file_location"].ToString().Length == 0)
                return;

            bool first = true;
            FileInfo[] files;

            try
            {
                files = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray();
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
                    String destination_file_name = string.Format("{0}{1}{2}{3}{4}{5}", Settings.Default["historic_file_location"].ToString(), "\\", Path.GetFileNameWithoutExtension(file.Name), "_", file.CreationTime.ToString("yyyyMMddHHmmss"), ".log");

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
                String destination_file_name = string.Format("{0}{1}{2}{3}", Settings.Default["historic_file_location"].ToString(), "\\", Path.GetFileNameWithoutExtension(file.Name), ".log");

                if (!File.Exists(destination_file_name))
                {
                    File.Copy(file.FullName, destination_file_name);
                }
                File.Delete(file.FullName);
            }
        }

        public void create_stream_file_location()
        {
            string stream_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CO_Driver\stream_templates";

            if (!Directory.Exists(stream_file_path))
            {
                Directory.CreateDirectory(stream_file_path);
            }

            if (stream_file_path != Settings.Default["stream_file_location"].ToString())
            {
                Settings.Default["stream_file_location"] = stream_file_path;
                Settings.Default.Save();
            }
        }

        public void get_live_file_location()
        {
            if (Settings.Default["log_file_location"].ToString().Length == 0)
                return;

            Settings.Default["live_file_location"] = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName;
            Settings.Default.Save();
        }

        public void find_local_user_name()
        {
            if (Settings.Default["local_user_name"].ToString().Length > 0)
                return;

            FileInfo last_game_log;
            try
            {
                last_game_log = new DirectoryInfo(Settings.Default["historic_file_location"].ToString()).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            }
            catch (Exception ex)
            {
                return;
            }

            if (last_game_log.Name.Contains("game"))
            {
                string[] lines = File.ReadAllLines(last_game_log.FullName);

                foreach (string line in lines)
                {
                    if (line != null)
                    {
                        if (line.Contains("| TSConnectionManager: negotiation complete:"))
                        {
                            string local_player_name = Regex.Match(line, @", nickName '(.+?)',").Groups[1].Value.Replace(" ", "");
                            int local_player_uid = Int32.Parse(Regex.Match(line, @"complete: uid (.+?),").Groups[1].Value.Replace(" ", ""));
                            Settings.Default["local_user_name"] = local_player_name;
                            Settings.Default["local_user_uid"] = local_player_uid;
                            Settings.Default.Save();
                            return;
                        }
                    }
                }
            }
        }
    }
}
