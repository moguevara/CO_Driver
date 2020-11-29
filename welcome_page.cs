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
            find_log_file_path();
            

            unlock_menu_strip();
        }

        void find_log_file_path()
        {
            string log_file_path = Settings.Default["local_user_name"].ToString();

            if (Directory.Exists(log_file_path))
            {
                this.lb_load_status_text.Text = string.Format(@"Using default file path ""{0}""", log_file_path);
                this.pb_welcome_file_load.Value += 5;
            }
            else
            {
                log_file_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                if (Directory.Exists(log_file_path))
                {
                    Settings.Default["log_file_location"] = log_file_path;
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
            else
                this.lbl_welcome_main.Text = string.Format(@"Welcome to the Rot_Fish_Bandit Crossout Tool Suite V{0}", global_data.CURRENT_VERSION);
        }

        void unlock_menu_strip ()
        {
            frm_main_page main = (frm_main_page)this.Parent.Parent;
            main.strp_main_menu_strip.Enabled = true;
        }
    }
}
