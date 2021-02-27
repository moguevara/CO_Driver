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
        public event EventHandler reload_all_themes;

        log_file_managment log_file_manager = new log_file_managment();
        public log_file_managment.session_variables session;

        List<string> supporters = new List<string> { "Rot_Fish_Bandit",
                                                     "QuickSkinner",
                                                     "Perqq",
                                                     "MayhemMotors",
                                                     "blab_",
                                                     "blorgus"};

        public user_settings()
        {
            InitializeComponent();

            foreach (var ctrl in Controls)
            {

            }

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (log_file_managment.ui_theme theme in session.themes)
            {
                cmb_themes.Items.Add(theme.name);
            }


            txt_local_user_input.Text = session.local_user_name;
            txt_log_file_location.Text = session.log_file_location;
            txt_historic_log_location.Text = session.historic_file_location;
            cmb_language_drop_down.SelectedItem = "English";
            cmb_themes.SelectedItem = session.themes.FirstOrDefault().name;
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
            chk_save_screen_shots.Checked = true;
        }

        private void save_user_settings(object sender, EventArgs e)
        {
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
            session.save_captures = this.chk_save_screen_shots.Checked;

            
            string text = cmb_themes.Items[cmb_themes.SelectedIndex].ToString();
            foreach (log_file_managment.ui_theme theme in session.themes)
            {
                if (text == theme.name)
                {
                    if (supporters.Contains(session.local_user_name) || text == "Terminal" || text == "Static")
                    {
                        session.fore_color = theme.fore_ground;
                        session.back_color = theme.back_ground;
                        break;
                    }
                }
            }

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);
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
            session.fore_color = Color.Lime;
            session.back_color = Color.Black;
            session.save_captures = true;

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
            cmb_themes.SelectedItem = "Terminal";
            chk_save_screen_shots.Checked = session.save_captures;
            
            chk_twitch_mode.Checked = false;

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);
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
                foreach (log_file_managment.ui_theme theme in session.themes)
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

            if (text == "Terminal" || text == "Static" || supporters.Contains(session.local_user_name))
            {
                tb_theme_warning.Text = "";
            }
            else
            {
                tb_theme_warning.Text = "Themes are limited to supporters of CO_Driver." + Environment.NewLine +
                                        "Please consider supporting CO_Driver to gain access to theme selection." + Environment.NewLine +
                                        "This is the only restricted feature.";
            }

            foreach (log_file_managment.ui_theme theme in session.themes)
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

    }
}
