using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CO_Driver.Properties;
using System.IO;
using System.Text.RegularExpressions;

namespace CO_Driver
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
        }

        void initialize_screen_components()
        {
            if (Settings.Default["local_user_name"].ToString().Length > 0)
                this.lbl_welcome_main.Text = string.Format(@"Welcome {0} to the Crossout Omnitool Driver (CO-Driver) V{1}", Settings.Default["local_user_name"].ToString(), global_data.CURRENT_VERSION);
        }
    }
}

