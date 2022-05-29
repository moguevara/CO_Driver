using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class AboutScreen : UserControl
    {

        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public AboutScreen()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            version_label.Text = string.Format(@"CO_Driver v{0}", GlobalData.CURRENT_VERSION);
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitch.tv/rotfishbandit");
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/?view=cm&fs=1&to=codriverdept116@gmail.com");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/CO_Driver");
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/kKcnVXu2Xe");
        }

        private void ll_website_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://codriver.dept116.com/");
        }

        private void about_screen_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void about_screen_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}
