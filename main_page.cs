using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using RFB_Tool_Suite.Properties;

namespace RFB_Tool_Suite
{
    public partial class frm_main_page : Form
    {
        public frm_main_page()
        {
            InitializeComponent();
        }
        private void rfb_tool_suite_load(object sender, EventArgs e)
        {
            find_log_file_path();
            find_historic_file_path();
            copy_historic_files();
            find_local_user_name();

            main_page_panel.Controls.Add(new welcome_page());
            this.Text = string.Format(@"Rot_Fish_Bandit Tool Suite v{0}", global_data.CURRENT_VERSION);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_user_profile_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_user_settings_click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new user_settings());
        }

        private void clear_main_page_panel()
        {
            foreach (Control ctrl in main_page_panel.Controls)
                ctrl.Dispose();
            main_page_panel.Controls.Clear();
        }

        private void menu_fusion_calculator(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new fusion_calculator());
        }

        private void chatToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inMatchDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Combat"));
        }

        private void gamelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Game"));
        }

        private void chatlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Chat"));
        }

        private void netlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Net"));
        }

        private void gfxlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Gfx"));
        }

        
        void find_log_file_path()
        {
            string log_file_path = Settings.Default["local_user_name"].ToString();

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

                    if (!File.Exists(destination_file_name))
                        File.Copy(file.FullName, destination_file_name);
                }
            }
        }

        void find_local_user_name()
        {
            if (Settings.Default["local_user_name"].ToString().Length > 0)
                return;

            FileInfo last_game_log = new DirectoryInfo(Settings.Default["historic_file_location"].ToString()).GetFiles("game*.*log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

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
                            return;
                        }
                    }
                }
            }
        }
    }
}
