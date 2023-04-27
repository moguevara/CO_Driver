using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class user_settings : UserControl
    {
        public event EventHandler reload_all_themes;
        public event EventHandler enable_uploads;

        LogFileManagment log_file_manager = new LogFileManagment();
        public LogFileManagment.SessionVariables session;
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

        public user_settings()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            foreach (KeyValuePair<string, int> player in session.ValidUsers)
                cmb_user_names.Items.Add(player.Key);

            foreach (Theme.UITheme theme in Theme.themes)
                cmb_themes.Items.Add(theme.Name);

            foreach (Screen device in Screen.AllScreens)
                cmb_fullscreen_monitor.Items.Add(string.Format(@"{0}", device.DeviceName));

            cmb_user_names.SelectedItem = session.LocalUserName;
            txt_log_file_location.Text = session.LogFileLocation;
            txt_historic_log_location.Text = session.HistoricFileLocation;
            cmb_language_drop_down.SelectedItem = session.LocalLanguage;
            //cmb_fullscreen_monitor.SelectedItem = session.primary_display;
            cmb_fullscreen_monitor.SelectedIndex = cmb_fullscreen_monitor.Items.IndexOf(session.PrimaryDisplay);
            cmb_themes.SelectedItem = session.SelectedTheme;
            num_engineer_level.Value = session.EngineerLevel;
            num_lunatic_level.Value = session.LunaticsLevel;
            num_nomad_level.Value = session.NomadsLevel;
            num_scavenger_level.Value = session.ScavengersLevel;
            num_steppenwolf_level.Value = session.SteppenWolfLevel;
            num_dawns_children_level.Value = session.DawnsChildrenLevel;
            num_firestarter_level.Value = session.FireStartersLevel;
            num_founders_level.Value = session.FoundersLevel;
            chk_prestigue_parts.Checked = session.IncludePresitgueParts;
            chk_twitch_mode.Checked = session.TwitchMode;
            chk_group_ram.Checked = session.BundleRamMode;
            chk_save_screen_shots.Checked = session.SaveCaptures;
            chk_upload_post_match.Checked = session.UploadData;
            chk_update.Checked = session.UploadPostMatch;
        }

        private void save_user_settings(object sender, EventArgs e)
        {
            bool prompt_restart = false;
            bool upload_change = false;

            if (!Directory.Exists(txt_log_file_location.Text))
            {
                MessageBox.Show("Target log file location invalid. Aborting save." + Environment.NewLine + Environment.NewLine + txt_log_file_location.Text);
                session.LogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                txt_log_file_location.Text = session.LogFileLocation;
                return;
            }

            if (!Directory.EnumerateFiles(txt_log_file_location.Text, "*.log", SearchOption.AllDirectories).Any())
            {
                MessageBox.Show("Target log file location does not contain any crossout log files. Aborting save." + Environment.NewLine + Environment.NewLine + txt_log_file_location.Text);
                session.LogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
                txt_log_file_location.Text = session.LogFileLocation;
                return;
            }

            if (session.LocalUserName != cmb_user_names.Items[cmb_user_names.SelectedIndex].ToString())
            {
                DialogResult dialogResult = MessageBox.Show("Changing user name requires restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.ParsedLogs = new List<string> { };
            }

            if (session.LocalLanguage != cmb_language_drop_down.Items[cmb_language_drop_down.SelectedIndex].ToString())
            {
                DialogResult dialogResult = MessageBox.Show("Changing language requires restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
            }

            if (session.TwitchMode != chk_twitch_mode.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Supporting Twitch overlays requires restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
            }

            if (session.BundleRamMode != chk_group_ram.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.ParsedLogs = new List<string> { };
            }

            if (session.LogFileLocation != txt_log_file_location.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.ParsedLogs = new List<string> { };
            }

            if (session.UploadData != chk_upload_post_match.Checked)
                upload_change = true;

            session.LocalUserName = cmb_user_names.Items[cmb_user_names.SelectedIndex].ToString();
            session.LogFileLocation = txt_log_file_location.Text;
            session.LocalLanguage = cmb_language_drop_down.Items[cmb_language_drop_down.SelectedIndex].ToString();
            session.PrimaryDisplay = Screen.AllScreens.FirstOrDefault(x => x.DeviceName == cmb_fullscreen_monitor.Items[cmb_fullscreen_monitor.SelectedIndex].ToString()).DeviceName;
            session.EngineerLevel = Convert.ToInt32(num_engineer_level.Value);
            session.LunaticsLevel = Convert.ToInt32(num_lunatic_level.Value);
            session.NomadsLevel = Convert.ToInt32(num_nomad_level.Value);
            session.ScavengersLevel = Convert.ToInt32(num_scavenger_level.Value);
            session.SteppenWolfLevel = Convert.ToInt32(num_steppenwolf_level.Value);
            session.DawnsChildrenLevel = Convert.ToInt32(num_dawns_children_level.Value);
            session.FireStartersLevel = Convert.ToInt32(num_firestarter_level.Value);
            session.FoundersLevel = Convert.ToInt32(num_founders_level.Value);
            session.IncludePresitgueParts = chk_prestigue_parts.Checked;
            session.TwitchMode = chk_twitch_mode.Checked;
            session.BundleRamMode = chk_group_ram.Checked;
            session.SaveCaptures = chk_save_screen_shots.Checked;
            session.UploadData = chk_upload_post_match.Checked;
            session.UploadPostMatch = chk_update.Checked;

            string text = cmb_themes.Items[cmb_themes.SelectedIndex].ToString();
            foreach (Theme.UITheme theme in Theme.themes)
            {
                if (text == theme.Name)
                {
                    session.ForeColor = theme.ForeGround;
                    session.BackColor = theme.BackGround;
                    break;
                }
            }

            session.SelectedTheme = text;

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);

            if (session.UploadData && upload_change)
                enable_uploads(this, EventArgs.Empty);

            log_file_manager.SaveSessionConfig(session);

            if (prompt_restart)
            {
                Application.Restart();
            }
        }

        private void restore_default_settings(object sender, EventArgs e)
        {
            bool prompt_restart = false;

            if (session.LocalUserName != session.ValidUsers.Aggregate((l, r) => l.Value > r.Value ? l : r).Key)
            {
                DialogResult dialogResult = MessageBox.Show("Reseting will reset user name and require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.ParsedLogs = new List<string> { };
            }

            log_file_manager.FindLocalUserName(session);
            log_file_manager.GetLiveFileLocation(session);

            session.LogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games\Crossout\logs";
            session.LocalLanguage = "English";
            session.PrimaryDisplay = Screen.PrimaryScreen.DeviceName;
            session.EngineerLevel = 30;
            session.LunaticsLevel = 15;
            session.NomadsLevel = 15;
            session.ScavengersLevel = 15;
            session.SteppenWolfLevel = 15;
            session.DawnsChildrenLevel = 15;
            session.FireStartersLevel = 15;
            session.FoundersLevel = 75;
            session.IncludePresitgueParts = true;
            session.SelectedTheme = "Terminal";
            session.ForeColor = Color.Lime;
            session.BackColor = Color.Black;
            session.SaveCaptures = true;
            session.TwitchMode = false;
            session.BundleRamMode = true;
            session.UploadPostMatch = true;
            session.UploadData = false;
            session.ActionConfiguration = Overlay.DefaultOverlaySetup();
            session.TwitchSettings = Overlay.DefaultTwitchSettings();

            if (reload_all_themes != null)
                reload_all_themes(this, EventArgs.Empty);

            if (session.LogFileLocation != txt_log_file_location.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Some changes require restart. Continue?", "Save Settings", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                prompt_restart = true;
                session.ParsedLogs = new List<string> { };
            }

            log_file_manager.SaveSessionConfig(session);

            if (prompt_restart)
            {
                Application.Restart();
            }

            cmb_user_names.SelectedItem = session.LocalUserName;
            txt_log_file_location.Text = session.LogFileLocation;
            txt_historic_log_location.Text = session.HistoricFileLocation;
            cmb_language_drop_down.SelectedItem = session.LocalLanguage;
            cmb_fullscreen_monitor.SelectedItem = session.PrimaryDisplay;
            num_engineer_level.Value = session.EngineerLevel;
            num_lunatic_level.Value = session.LunaticsLevel;
            num_nomad_level.Value = session.NomadsLevel;
            num_scavenger_level.Value = session.ScavengersLevel;
            num_steppenwolf_level.Value = session.SteppenWolfLevel;
            num_dawns_children_level.Value = session.DawnsChildrenLevel;
            num_firestarter_level.Value = session.FireStartersLevel;
            num_founders_level.Value = session.FoundersLevel;
            chk_prestigue_parts.Checked = session.IncludePresitgueParts;
            cmb_themes.SelectedItem = "Terminal";
            chk_save_screen_shots.Checked = session.SaveCaptures;
            chk_upload_post_match.Checked = session.UploadData;
            chk_update.Checked = session.UploadPostMatch;
            cmb_themes.SelectedIndex = 0;
            cmb_fullscreen_monitor.SelectedIndex = cmb_fullscreen_monitor.Items.IndexOf(session.PrimaryDisplay);
            chk_twitch_mode.Checked = session.TwitchMode;
            chk_group_ram.Checked = session.BundleRamMode;
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
                foreach (Theme.UITheme theme in Theme.themes)
                {
                    if (text == theme.Name)
                    {
                        using (SolidBrush background_brush = new SolidBrush(theme.BackGround))
                            e.Graphics.FillRectangle(new SolidBrush(theme.BackGround), e.Bounds);

                        using (Brush text_brush = new SolidBrush(theme.ForeGround))
                            e.Graphics.DrawString(text, e.Font, text_brush, e.Bounds.Location);

                        break;
                    }
                }
            }
        }

        private void cmb_themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = cmb_themes.Items[cmb_themes.SelectedIndex].ToString();

            //if (text == "Terminal" || text == "Static" || global_data.supporters.Contains(session.local_user_name))
            //{
            tb_theme_warning.Text = "";
            //}
            //else
            //{
            //    tb_theme_warning.Text = "Themes are limited to supporters of CO_Driver." + Environment.NewLine +
            //                            "Please consider supporting CO_Driver to gain access to theme selection." + Environment.NewLine +
            //                            "This is the only restricted feature.";
            //}

            foreach (Theme.UITheme theme in Theme.themes)
            {
                if (text == theme.Name)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl.Name == cmb_themes.Name)
                            continue;

                        ctrl.ForeColor = theme.ForeGround;
                        ctrl.BackColor = theme.BackGround;
                    }
                    break;
                }
            }
        }

        private void recalculate_logs(object sender, EventArgs e)
        {
            session.ParsedLogs = new List<string> { };
            log_file_manager.SaveSessionConfig(session);
            Application.Restart();
        }

        private void user_settings_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void user_settings_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }

        private void chk_upload_post_match_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
