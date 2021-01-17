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

namespace CO_Driver
{
    public partial class user_settings : UserControl
    {
        log_file_managment log_file_manager = new log_file_managment();

        public user_settings()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txt_local_user_input.Text = Settings.Default["local_user_name"].ToString();
            this.txt_log_file_location.Text = Settings.Default["log_file_location"].ToString();
            this.chk_preserve_historical_data.Checked = Convert.ToBoolean(Settings.Default["preserve_historic_files"]);
            this.txt_historic_log_location.Text = Settings.Default["historic_file_location"].ToString();
            this.num_preserved_file_count.Value = Convert.ToInt32(Settings.Default["max_preserved_file_count"]);
            this.cmb_language_drop_down.SelectedItem = Settings.Default["language"].ToString();
            this.chk_beep_at_score.Checked = Convert.ToBoolean(Settings.Default["beep_at_in_game_score"]);
            this.num_min_beep_score.Value = Convert.ToInt32(Settings.Default["minimum_score_to_beep"]);
            this.num_engineer_level.Value = Convert.ToInt32(Settings.Default["engineer_level"]);
            this.num_lunatic_level.Value = Convert.ToInt32(Settings.Default["lunatics_level"]);
            this.num_nomad_level.Value = Convert.ToInt32(Settings.Default["nomads_level"]);
            this.num_scavenger_level.Value = Convert.ToInt32(Settings.Default["scavengers_level"]);
            this.num_steppenwolf_level.Value = Convert.ToInt32(Settings.Default["steppenwolfs_level"]);
            this.num_dawns_children_level.Value = Convert.ToInt32(Settings.Default["dawns_children_level"]);
            this.num_firestarter_level.Value = Convert.ToInt32(Settings.Default["firestarts_level"]);
            this.num_founders_level.Value = Convert.ToInt32(Settings.Default["founders_level"]);
            this.chk_prestigue_parts.Checked = Convert.ToBoolean(Settings.Default["include_prestigue_parts"]);
        }

        private void save_user_settings(object sender, EventArgs e)
        {
            Settings.Default["local_user_name"] = this.txt_local_user_input.Text;
            Settings.Default["log_file_location"] = this.txt_log_file_location.Text;
            Settings.Default["preserve_historic_files"] = this.chk_preserve_historical_data.Checked;
            Settings.Default["historic_file_location"] = this.txt_historic_log_location.Text;
            Settings.Default["max_preserved_file_count"] = Convert.ToInt32(this.num_preserved_file_count.Value);
            Settings.Default["language"] = this.cmb_language_drop_down.SelectedItem.ToString();
            Settings.Default["beep_at_in_game_score"] = this.chk_beep_at_score.Checked;
            Settings.Default["minimum_score_to_beep"] = Convert.ToInt32(this.num_min_beep_score.Value);
            Settings.Default["engineer_level"] = Convert.ToInt32(this.num_engineer_level.Value);
            Settings.Default["lunatics_level"] = Convert.ToInt32(this.num_lunatic_level.Value);
            Settings.Default["nomads_level"] = Convert.ToInt32(this.num_nomad_level.Value);
            Settings.Default["scavengers_level"] = Convert.ToInt32(this.num_scavenger_level.Value);
            Settings.Default["steppenwolfs_level"] = Convert.ToInt32(this.num_steppenwolf_level.Value);
            Settings.Default["dawns_children_level"] = Convert.ToInt32(this.num_dawns_children_level.Value);
            Settings.Default["firestarts_level"] = Convert.ToInt32(this.num_firestarter_level.Value);
            Settings.Default["founders_level"] = Convert.ToInt32(this.num_founders_level.Value);
            Settings.Default["include_prestigue_parts"] = this.chk_prestigue_parts.Checked;

            Settings.Default.Save();
        }

        private void restore_default_settings(object sender, EventArgs e)
        {
            Settings.Default["local_user_name"] = "";
            Settings.Default["local_user_uid"] = 0;
            Settings.Default["log_file_location"] = @"";
            Settings.Default["live_file_location"] = @"";
            Settings.Default["preserve_historic_files"] = true;
            Settings.Default["historic_file_location"] = @"";
            Settings.Default["max_preserved_file_count"] = 50;
            Settings.Default["language"] = "English";
            Settings.Default["beep_at_in_game_score"] = true;
            Settings.Default["minimum_score_to_beep"] = 50;
            Settings.Default["engineer_level"] = 30;
            Settings.Default["lunatics_level"] = 15;
            Settings.Default["nomads_level"] = 15;
            Settings.Default["scavengers_level"] = 15;
            Settings.Default["steppenwolfs_level"] = 15;
            Settings.Default["dawns_children_level"] = 15;
            Settings.Default["firestarts_level"] = 15;
            Settings.Default["founders_level"] = 75;
            Settings.Default["include_prestigue_parts"] = true;
            Settings.Default["fusion_item_cost"] = 300;
            Settings.Default["fusion_reliability_target"] = 1;
            Settings.Default["fusion_reliability_max"] = 3;
            Settings.Default["fusion_power_target"] = 0;
            Settings.Default["fusion_power_max"] = 3;
            Settings.Default["fusion_handling_target"] = 0;
            Settings.Default["fusion_handling_max"] = 3;

            Settings.Default.Save();

            log_file_manager.find_log_file_path();
            log_file_manager.find_historic_file_path();
            log_file_manager.find_local_user_name();
            log_file_manager.get_live_file_location();

            this.txt_local_user_input.Text = Settings.Default["local_user_name"].ToString();
            this.txt_log_file_location.Text = Settings.Default["log_file_location"].ToString();
            this.chk_preserve_historical_data.Checked = Convert.ToBoolean(Settings.Default["preserve_historic_files"]);
            this.txt_historic_log_location.Text = Settings.Default["historic_file_location"].ToString();
            this.num_preserved_file_count.Value = Convert.ToInt32(Settings.Default["max_preserved_file_count"]);
            this.cmb_language_drop_down.SelectedItem = Settings.Default["language"].ToString();
            this.chk_beep_at_score.Checked = Convert.ToBoolean(Settings.Default["beep_at_in_game_score"]);
            this.num_min_beep_score.Value = Convert.ToInt32(Settings.Default["minimum_score_to_beep"]);
            this.num_engineer_level.Value = Convert.ToInt32(Settings.Default["engineer_level"]);
            this.num_lunatic_level.Value = Convert.ToInt32(Settings.Default["lunatics_level"]);
            this.num_nomad_level.Value = Convert.ToInt32(Settings.Default["nomads_level"]);
            this.num_scavenger_level.Value = Convert.ToInt32(Settings.Default["scavengers_level"]);
            this.num_steppenwolf_level.Value = Convert.ToInt32(Settings.Default["steppenwolfs_level"]);
            this.num_dawns_children_level.Value = Convert.ToInt32(Settings.Default["dawns_children_level"]);
            this.num_firestarter_level.Value = Convert.ToInt32(Settings.Default["firestarts_level"]);
            this.num_founders_level.Value = Convert.ToInt32(Settings.Default["founders_level"]);
            this.chk_prestigue_parts.Checked = Convert.ToBoolean(Settings.Default["include_prestigue_parts"]);
        }
    }
}
