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
    public partial class user_settings : UserControl
    {
        log_file_managment log_file_manager = new log_file_managment();
        public log_file_managment.session_variables session;

        public user_settings()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txt_local_user_input.Text = session.local_user_name;
            txt_log_file_location.Text = session.log_file_location;
            txt_historic_log_location.Text = session.historic_file_location;
            cmb_language_drop_down.SelectedItem = "English";
            num_engineer_level.Value = session.engineer_level;
            num_lunatic_level.Value = session.lunatics_level;
            num_nomad_level.Value = session.nomads_level;
            num_scavenger_level.Value = session.scavengers_level;
            num_steppenwolf_level.Value = session.steppenwolfs_level;
            num_dawns_children_level.Value = session.dawns_children_level;
            num_firestarter_level.Value = session.firestarts_level;
            num_founders_level.Value = session.founders_level;
            chk_prestigue_parts.Checked = session.include_prestigue_parts;
            chk_twitch_mode.Checked = false;
        }

        private void save_user_settings(object sender, EventArgs e)
        {
            //session.local_user_name = this.txt_local_user_input.Text;
            //session.log_file_location = this.txt_log_file_location.Text;
            //session.historic_file_location = this.txt_historic_log_location.Text;
            //Settings.Default["language"] = this.cmb_language_drop_down.SelectedItem.ToString();
            session.engineer_level = Convert.ToInt32(this.num_engineer_level.Value);
            session.lunatics_level = Convert.ToInt32(this.num_lunatic_level.Value);
            session.nomads_level = Convert.ToInt32(this.num_nomad_level.Value);
            session.scavengers_level = Convert.ToInt32(this.num_scavenger_level.Value);
            session.steppenwolfs_level = Convert.ToInt32(this.num_steppenwolf_level.Value);
            session.dawns_children_level = Convert.ToInt32(this.num_dawns_children_level.Value);
            session.firestarts_level = Convert.ToInt32(this.num_firestarter_level.Value);
            session.founders_level = Convert.ToInt32(this.num_founders_level.Value);
            session.include_prestigue_parts = this.chk_prestigue_parts.Checked;
            session.include_prestigue_parts = this.chk_twitch_mode.Checked;
        }

        private void restore_default_settings(object sender, EventArgs e)
        {
            log_file_manager.find_log_file_path(session);
            log_file_manager.find_historic_file_path(session);
            log_file_manager.find_local_user_name(session);
            log_file_manager.get_live_file_location(session);

            session.engineer_level = 30;
            session.lunatics_level = 15;
            session.nomads_level = 15;
            session.scavengers_level = 15;
            session.steppenwolfs_level = 15;
            session.dawns_children_level = 15;
            session.firestarts_level = 15;
            session.founders_level = 75;
            session.include_prestigue_parts = true;

            txt_local_user_input.Text = session.local_user_name;
            txt_log_file_location.Text = session.log_file_location;
            txt_historic_log_location.Text = session.historic_file_location;
            cmb_language_drop_down.SelectedItem = "English";
            num_engineer_level.Value = session.engineer_level;
            num_lunatic_level.Value = session.lunatics_level;
            num_nomad_level.Value = session.nomads_level;
            num_scavenger_level.Value = session.scavengers_level;
            num_steppenwolf_level.Value = session.steppenwolfs_level;
            num_dawns_children_level.Value = session.dawns_children_level;
            num_firestarter_level.Value = session.firestarts_level;
            num_founders_level.Value = session.founders_level;
            chk_prestigue_parts.Checked = session.include_prestigue_parts;
            chk_twitch_mode.Checked = false;
        }

        private void chk_twitch_mode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void user_settings_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
