using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class welcome_page : UserControl
    {
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

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
            return GlobalData.CURRENT_VERSION;
        }

        private void welcome_page_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.record_initial_sizes(this);
        }

        private void welcome_page_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }
    }
}

