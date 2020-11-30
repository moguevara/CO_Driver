using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFB_Tool_Suite.Properties;
using System.IO;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace RFB_Tool_Suite
{
    public partial class welcome_page : UserControl
    {
        public welcome_page()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            initialize_screen_components();
            //find_log_file_path();
            //find_historic_file_path();
            //copy_historic_files();
            //find_local_user_name();

            unlock_menu_strip();
        }

        void find_local_user_name()
        {
            if (Settings.Default["local_user_name"].ToString().Length > 0)
                return;

            FileInfo last_game_log = new DirectoryInfo(Settings.Default["historic_file_location"].ToString()).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

            this.lb_load_status_text.Text = string.Format(@"Found ""{0}""", last_game_log.FullName);
            if (this.pb_welcome_file_load.Value < 11)
                this.pb_welcome_file_load.Value += 1;

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
                            Settings.Default["local_user_name"] = local_player_name;
                            Settings.Default.Save();
                            this.lbl_welcome_main.Text = string.Format(@"Welcome {0} to the Rot_Fish_Bandit Crossout Tool Suite V{1}", Settings.Default["local_user_name"].ToString(), global_data.CURRENT_VERSION);
                            this.lb_load_status_text.Text = string.Format(@"Found Player Name ""{0}""", local_player_name);
                            if (this.pb_welcome_file_load.Value < 12)
                                this.pb_welcome_file_load.Value += 1;
                            return;
                        }
                    }
                }
            }
        }

        FileInfo[] populate_files_list()
        {
            return new DirectoryInfo(Settings.Default["historic_file_location"].ToString()).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray();
        }

        void copy_historic_files()
        {
            bool first = true;
            FileInfo[] files = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles("*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray();

            foreach (FileInfo file in files)
            {
                if (first)
                    first = false;
                else
                {
                    String destination_file_name = string.Format("{0}{1}{2}{3}{4}{5}", Settings.Default["historic_file_location"].ToString(), "\\", Path.GetFileNameWithoutExtension(file.Name), "_", file.CreationTime.ToString("yyyyMMddHHmmss"), ".log");

                    this.lb_load_status_text.Text = string.Format(@"Copying ""{0}""", file.FullName);
                    if (this.pb_welcome_file_load.Value < 10)
                        this.pb_welcome_file_load.Value += 1;

                    if (!File.Exists(destination_file_name))
                        File.Copy(file.FullName, destination_file_name);
                }
            }
        }

        void find_historic_file_path()
        {
            string historic_file_path = Settings.Default["historic_file_location"].ToString();

            if (!Directory.Exists(historic_file_path))
            {
                historic_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RFB_Tool_Suite";
                Directory.CreateDirectory(historic_file_path);
            }

            if (historic_file_path != Settings.Default["historic_file_location"].ToString())
            {
                Settings.Default["historic_file_location"] = historic_file_path;
                Settings.Default.Save();
            }
        }

        void find_log_file_path()
        {
            string log_file_path = Settings.Default["local_user_name"].ToString();

            if (Directory.Exists(log_file_path))
            {
                this.lb_load_status_text.Text = string.Format(@"Using default file path ""{0}""", log_file_path);
                this.pb_welcome_file_load.Value += 1;
            }
            else
            {
                log_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                if (Directory.Exists(log_file_path))
                {
                    Settings.Default["log_file_location"] = log_file_path; 
                    Settings.Default.Save();
                    this.lb_load_status_text.Text = string.Format(@"Found ""{0}""", log_file_path);
                    this.pb_welcome_file_load.Value += 5;
                }
                else
                {
                    this.lb_load_status_text.Text = string.Format(@"Unable to find directory at ""{0}""", log_file_path);
                }
            }
        }

        void initialize_screen_components()
        {
            if (Settings.Default["local_user_name"].ToString().Length > 0)
                this.lbl_welcome_main.Text = string.Format(@"Welcome {0} to the Rot_Fish_Bandit Crossout Tool Suite V{1}", Settings.Default["local_user_name"].ToString(), global_data.CURRENT_VERSION);
        }

        void unlock_menu_strip ()
        {
            frm_main_page main = (frm_main_page)this.Parent.Parent;
            main.strp_main_menu_strip.Enabled = true;
        }
    }
}
