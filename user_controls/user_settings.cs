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
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net;

namespace CO_Driver
{
    public partial class user_settings : UserControl
    {
        public event EventHandler reload_all_themes;

        log_file_managment log_file_manager = new log_file_managment();
        public log_file_managment.session_variables session;
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };



        public user_settings()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            foreach (KeyValuePair<string, int> player in session.valid_users)
                cmb_user_names.Items.Add(player.Key);

            foreach (theme.ui_theme theme in theme.themes)
                cmb_themes.Items.Add(theme.name);

            cmb_user_names.SelectedItem = session.local_user_name;
            txt_log_file_location.Text = session.log_file_location;
            txt_historic_log_location.Text = session.historic_file_location;
            cmb_language_drop_down.SelectedItem = session.local_language;
            cmb_themes.SelectedItem = session.selected_theme;
            num_engineer_level.Value = session.engineer_level;
            num_lunatic_level.Value = session.lunatics_level;
            num_nomad_level.Value = session.nomads_level;
            num_scavenger_level.Value = session.scavengers_level;
            num_steppenwolf_level.Value = session.steppenwolfs_level;
            num_dawns_children_level.Value = session.dawns_children_level;
            num_firestarter_level.Value = session.firestarts_level;
            num_founders_level.Value = session.founders_level;
            chk_prestigue_parts.Checked = session.include_prestigue_parts;
            chk_twitch_mode.Checked = session.twitch_mode;
            chk_group_ram.Checked = session.bundle_ram_mode;
            chk_save_screen_shots.Checked = session.save_captures;
        }

        private void save_user_settings(object sender, EventArgs e)
        {
            bool prompt_restart = false;

            if (!Directory.Exists(txt_log_file_location.Text))
            {
                MessageBox.Show("Target log file location invalid. Aborting save." + Environment.NewLine + Environment.NewLine + txt_log_file_location.Text);
                session.log_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                txt_log_file_location.Text = session.log_file_location;
                return;
            }

            if (!Directory.EnumerateFiles(txt_log_file_location.Text, "*.log", SearchOption.AllDirectories).Any())
            {
                MessageBox.Show("Target log file location does not contain any crossout log files. Aborting save." + Environment.NewLine + Environment.NewLine + txt_log_file_location.Text);
                session.log_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                txt_log_file_location.Text = session.log_file_location;
                return;
            }

            if (session.local_user_name != cmb_user_names.Items[cmb_user_names.SelectedIndex].ToString())
            {
                DialogResult dialogResult = MessageBox.Show("Changing user name requires restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.parsed_logs = new List<string> { };
            }

            if (session.local_language != cmb_language_drop_down.Items[cmb_language_drop_down.SelectedIndex].ToString())
            {
                DialogResult dialogResult = MessageBox.Show("Changing language requires restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
            }

            if (session.bundle_ram_mode != chk_group_ram.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.parsed_logs = new List<string> { };
            }

            if (session.log_file_location != txt_log_file_location.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.parsed_logs = new List<string> { };
            }

            session.local_user_name = cmb_user_names.Items[cmb_user_names.SelectedIndex].ToString();
            session.log_file_location = txt_log_file_location.Text;
            session.local_language = cmb_language_drop_down.Items[cmb_language_drop_down.SelectedIndex].ToString();
            session.engineer_level = Convert.ToInt32(num_engineer_level.Value);
            session.lunatics_level = Convert.ToInt32(num_lunatic_level.Value);
            session.nomads_level = Convert.ToInt32(num_nomad_level.Value);
            session.scavengers_level = Convert.ToInt32(num_scavenger_level.Value);
            session.steppenwolfs_level = Convert.ToInt32(num_steppenwolf_level.Value);
            session.dawns_children_level = Convert.ToInt32(num_dawns_children_level.Value);
            session.firestarts_level = Convert.ToInt32(num_firestarter_level.Value);
            session.founders_level = Convert.ToInt32(num_founders_level.Value);
            session.include_prestigue_parts = chk_prestigue_parts.Checked;
            session.twitch_mode = chk_twitch_mode.Checked;
            session.bundle_ram_mode = chk_group_ram.Checked;
            session.save_captures = chk_save_screen_shots.Checked;

            string text = cmb_themes.Items[cmb_themes.SelectedIndex].ToString();
            foreach (theme.ui_theme theme in theme.themes)
            {
                if (text == theme.name)
                {
                    if (global_data.supporters.Contains(session.local_user_name) || text == "Terminal" || text == "Static")
                    {
                        session.fore_color = theme.fore_ground;
                        session.back_color = theme.back_ground;
                        break;
                    }
                }
            }

            session.selected_theme = text;

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);

            log_file_manager.save_session_config(session);

            if (prompt_restart)
            {
                Application.Restart();
            }
        }

        private void restore_default_settings(object sender, EventArgs e)
        {
            bool prompt_restart = false;

            if (session.local_user_name != session.valid_users.Aggregate((l, r) => l.Value > r.Value ? l : r).Key)
            {
                DialogResult dialogResult = MessageBox.Show("Reseting will reset user name and require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.parsed_logs = new List<string> { };
            }

            log_file_manager.find_local_user_name(session);
            log_file_manager.get_live_file_location(session);

            session.log_file_location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
            session.local_language = "English";
            session.engineer_level = 30;
            session.lunatics_level = 15;
            session.nomads_level = 15;
            session.scavengers_level = 15;
            session.steppenwolfs_level = 15;
            session.dawns_children_level = 15;
            session.firestarts_level = 15;
            session.founders_level = 75;
            session.include_prestigue_parts = true;
            session.selected_theme = "Terminal";
            session.fore_color = Color.Lime;
            session.back_color = Color.Black;
            session.save_captures = true;
            session.twitch_mode = false;
            session.bundle_ram_mode = true;

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);

            if (session.log_file_location != txt_log_file_location.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.parsed_logs = new List<string> { };
            }

            log_file_manager.save_session_config(session);

            if (prompt_restart)
            {
                Application.Restart();
            }

            cmb_user_names.SelectedItem = session.local_user_name;
            txt_log_file_location.Text = session.log_file_location;
            txt_historic_log_location.Text = session.historic_file_location;
            cmb_language_drop_down.SelectedItem = session.local_language;
            num_engineer_level.Value = session.engineer_level;
            num_lunatic_level.Value = session.lunatics_level;
            num_nomad_level.Value = session.nomads_level;
            num_scavenger_level.Value = session.scavengers_level;
            num_steppenwolf_level.Value = session.steppenwolfs_level;
            num_dawns_children_level.Value = session.dawns_children_level;
            num_firestarter_level.Value = session.firestarts_level;
            num_founders_level.Value = session.founders_level;
            chk_prestigue_parts.Checked = session.include_prestigue_parts;
            cmb_themes.SelectedItem = "Terminal";
            chk_save_screen_shots.Checked = session.save_captures;
            cmb_themes.SelectedIndex = 0;
            chk_twitch_mode.Checked = session.twitch_mode;
            chk_group_ram.Checked = session.bundle_ram_mode;
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

        private void cmb_themes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                string text = cmb_themes.Items[e.Index].ToString();
                foreach (theme.ui_theme theme in theme.themes)
                {
                    if (text == theme.name)
                    {
                        using (SolidBrush background_brush = new SolidBrush(theme.back_ground))
                            e.Graphics.FillRectangle(new SolidBrush(theme.back_ground), e.Bounds);

                        using (Brush text_brush = new SolidBrush(theme.fore_ground))
                            e.Graphics.DrawString(text, e.Font, text_brush, e.Bounds.Location);

                        break;
                    }
                }
            }
        }

        private void cmb_themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = cmb_themes.Items[cmb_themes.SelectedIndex].ToString();

            if (text == "Terminal" || text == "Static" || global_data.supporters.Contains(session.local_user_name))
            {
                tb_theme_warning.Text = "";
            }
            else
            {
                tb_theme_warning.Text = "Themes are limited to supporters of CO_Driver." + Environment.NewLine +
                                        "Please consider supporting CO_Driver to gain access to theme selection." + Environment.NewLine +
                                        "This is the only restricted feature.";
            }

            foreach (theme.ui_theme theme in theme.themes)
            {
                if (text == theme.name)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl.Name == cmb_themes.Name)
                            continue;

                        ctrl.ForeColor = theme.fore_ground;
                        ctrl.BackColor = theme.back_ground;
                    }
                    break;
                }
            }
        }

        private void recalculate_logs(object sender, EventArgs e)
        {
            session.parsed_logs = new List<string> { };
            log_file_manager.save_session_config(session);
            Application.Restart();
        }
    }
}
