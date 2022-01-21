using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CO_Driver
{
    public partial class welcome_page : UserControl
    {
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };

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
            if (session.local_user_name != null)
                this.lbl_welcome_main.Text = string.Format(@"Welcome {0} to the Crossout Omnitool Driver (CO-Driver) V{1}", session.local_user_name, get_current_version());
        }

        public string get_current_version()
        {
            return global_data.CURRENT_VERSION;
            //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            //{
            //    Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            //    return string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
            //}
            //else
            //{
            //    var ver = Assembly.GetExecutingAssembly().GetName().Version;
            //    return string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
            //}
        }

        private void welcome_page_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}

