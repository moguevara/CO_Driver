using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class about_screen : UserControl
    {

        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public about_screen()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            version_label.Text = string.Format(@"CO_Driver v{0}", global_data.CURRENT_VERSION);
            //tb_thanks.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
        }
    }
}
