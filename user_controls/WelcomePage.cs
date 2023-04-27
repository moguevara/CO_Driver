using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class WelcomePage : UserControl
    {
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

        public WelcomePage()
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
            if (session.LocalUserName != null)
                this.lbl_welcome_main.Text = string.Format(@"Welcome {0} to the Crossout Omnitool Driver (CO-Driver) V{1}", session.LocalUserName, get_current_version());
        }

        public string get_current_version()
        {
            return GlobalData.CURRENT_VERSION;
        }

        private void welcome_page_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void welcome_page_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

