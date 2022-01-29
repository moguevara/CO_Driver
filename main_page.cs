using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using Newtonsoft.Json;

namespace CO_Driver
{
    public partial class frm_main_page : Form
    {
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations { get; set; } = new Dictionary<string, Dictionary<string, translate.Translation>> { };
        public market.market_data crossoutdb_data = new market.market_data { };

        public List<file_trace_managment.MatchRecord> match_history
        {
            get { return match_history.ToList(); }
            set { match_history = value; }
        }

        public log_file_managment log_file_manager = new log_file_managment();
        public file_trace_managment file_trace_manager = new file_trace_managment();
        public Theme theme_manager = new Theme { };
        public Upload uploader = new Upload { };
        public welcome_page welcome_screen = new welcome_page();
        public user_profile user_profile_page = new user_profile();
        public match_history match_history_page = new match_history();
        public schedule_display schedule_page = new schedule_display();
        public build_view build_page = new build_view();
        public part_optimizer part_page = new part_optimizer();
        public part_view avail_part_page = new part_view();
        public previous_match match_detail_page = new previous_match();
        public garage_view garage_page = new garage_view();
        public fusion_calculator fusion_page = new fusion_calculator();
        public user_settings settings_page = new user_settings();
        public about_screen about_page = new about_screen();
        public meta_detail meta_detail_page = new meta_detail();
        public revenue_review revenue_page = new revenue_review();
        public upload_screen upload_page = new upload_screen();

        public Size Initial_screen_size = new Size { };
        public Resize resize = new Resize { };

        public frm_main_page()
        {
            InitializeComponent();
        }
        private void CO_Driver_load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.welcome_screen.tb_progress_tracking.AppendText("Starting RFB Tool Suite." + Environment.NewLine);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading session variables." + Environment.NewLine);

            session = log_file_manager.load_user_session();

            if (session.local_user_name == null)
            {
                MessageBox.Show("An error has occured while loading, please try restarting CO_Driver. If the problem persists please report to https://discord.gg/kKcnVXu2Xe. Thanks.");
                Application.Exit();
            }

            ui_translate.load_ui_translate(ui_translations);
            translate.populate_translations(session, translations);

            reload_theme(this, EventArgs.Empty);
            Initial_screen_size = this.Size;
            strp_main_menu_strip.ShowItemToolTips = true;

            this.welcome_screen.tb_progress_tracking.AppendText("Loading market data from crossoutdb.com" + Environment.NewLine);
            crossoutdb_data = market.populate_crossoutdb_data(session);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading previously stored log data (if any)." + Environment.NewLine);

            load_static_screen_data();

            match_history_page.load_selected_match += new EventHandler<file_trace_managment.MatchRecord>(load_match_details);
            match_detail_page.load_selected_match += new EventHandler<file_trace_managment.MatchRecord>(load_match_details);

            settings_page.reload_all_themes += new EventHandler(reload_theme);
            settings_page.enable_uploads += new EventHandler(enable_upload);

            garage_page.initialize_live_feed();
            main_page_panel.Controls.Add(welcome_screen);

            this.Text = string.Format(@"CO_Driver v{0}", get_current_version());

            print_control_names();
            
            try
            {
                bw_file_feed.RunWorkerAsync(argument: session);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Background worker failed:" + ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void load_static_screen_data()
        {
            welcome_screen.session = session;
            part_page.session = session;
            avail_part_page.session = session;
            settings_page.session = session;
            about_page.session = session;
            user_profile_page.session = session;
            match_detail_page.session = session;
            garage_page.session = session;
            schedule_page.session = session;
            match_history_page.session = session;
            build_page.session = session;
            meta_detail_page.session = session;
            revenue_page.session = session;
            upload_page.session = session;

            welcome_screen.translations = translations;
            part_page.translations = translations;
            avail_part_page.translations = translations;
            settings_page.translations = translations;
            about_page.translations = translations;
            user_profile_page.translations = translations;
            match_detail_page.translations = translations;
            garage_page.translations = translations;
            schedule_page.translations = translations;
            match_history_page.translations = translations;
            meta_detail_page.translations = translations;
            build_page.translations = translations;
            revenue_page.translations = translations;
            upload_page.translations = translations;

            welcome_screen.ui_translations = ui_translations;
            part_page.ui_translations = ui_translations;
            avail_part_page.ui_translations = ui_translations;
            settings_page.ui_translations = ui_translations;
            about_page.ui_translations = ui_translations;
            user_profile_page.ui_translations = ui_translations;
            match_detail_page.ui_translations = ui_translations;
            garage_page.ui_translations = ui_translations;
            schedule_page.ui_translations = ui_translations;
            match_history_page.ui_translations = ui_translations;
            meta_detail_page.ui_translations = ui_translations;
            build_page.ui_translations = ui_translations;
            revenue_page.ui_translations = ui_translations;
            upload_page.ui_translations = ui_translations;

            revenue_page.crossoutdb_data = crossoutdb_data;
        }

        private void print_control_names()
        {
            translate_controls(strp_main_menu_strip);
            translate_controls(main_page_panel);
            translate_controls(welcome_screen);
            translate_controls(user_profile_page);
            translate_controls(match_history_page);
            translate_controls(schedule_page);
            translate_controls(build_page);
            translate_controls(part_page);
            translate_controls(avail_part_page);
            translate_controls(match_detail_page);
            translate_controls(garage_page);
            translate_controls(fusion_page);
            translate_controls(settings_page);
            translate_controls(about_page);
            translate_controls(meta_detail_page);
            translate_controls(revenue_page);
            translate_controls(upload_page);
        }

        private void translate_controls(Control current_control)
        {
            translate_text_elements(current_control);

            foreach (Control ctrl in current_control.Controls)
                translate_controls(ctrl);
        }

        private void translate_text_elements(Control ctrl)
        {
            if (ctrl.Text.Any(char.IsLetter))
            {
                ctrl.Text = ui_translate.translate(ctrl.Text, session, ui_translations);

                if (ctrl is Label)
                    scale_font(ctrl);
            }

            if (ctrl is MenuStrip)
                translate_menu_strip((MenuStrip)ctrl);

            if (ctrl is TextBox)
                translate_text_box((TextBox)ctrl);
        }

        private void translate_menu_strip(MenuStrip menu_strip)
        {
            foreach (ToolStripItem item in menu_strip.Items)
                item.Text = ui_translate.translate(item.Text, session, ui_translations);
        }

        private void translate_text_box(TextBox text_box)
        {
            List<string> text_lines = new List<string> { };

            foreach (string line in text_box.Lines)
                text_lines.Add(ui_translate.translate(line, session, ui_translations));

            text_box.Lines = text_lines.ToArray();
        }

        private void scale_font(Control lab)
        {
            SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);

            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            if (ratio > 1)
                return;

            lab.Font = new Font(lab.Font.FontFamily, lab.Font.Size * ratio, lab.Font.Style);
        }

        private void append_combo_box_controls (string panel_name, ComboBox drop_down, StreamWriter sw)
        {
            MessageBox.Show("Found drop down " + drop_down.Name);
            for (int i = 0; i < drop_down.Items.Count; i++)
            {
                string value = drop_down.GetItemText(drop_down.Items[i]);
                if (value.Any(char.IsLetter))
                    sw.WriteLine(string.Format("{0},{1},{2}", panel_name, drop_down.Name, value));
            }
        }

        private void enable_upload(object sender, EventArgs e)
        {
            upload_page.populate_upload_screen();
        }

        private void reload_theme(object sender, EventArgs e)
        {
            theme_manager.apply_theme(main_page_panel, session);
            theme_manager.apply_theme(welcome_screen, session);
            theme_manager.apply_theme(user_profile_page, session);
            theme_manager.apply_theme(match_history_page, session);
            theme_manager.apply_theme(schedule_page, session);
            theme_manager.apply_theme(build_page, session);
            theme_manager.apply_theme(part_page, session);
            theme_manager.apply_theme(avail_part_page, session);
            theme_manager.apply_theme(match_detail_page, session);
            theme_manager.apply_theme(garage_page, session);
            theme_manager.apply_theme(fusion_page, session);
            theme_manager.apply_theme(settings_page, session);
            theme_manager.apply_theme(about_page, session);
            theme_manager.apply_theme(meta_detail_page, session);
            theme_manager.apply_theme(revenue_page, session);
            theme_manager.apply_theme(upload_page, session);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_user_settings_click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(settings_page);
            
        }

        public void clear_main_page_panel()
        {
            /*
            foreach (Control ctrl in main_page_panel.Controls)
                ctrl.Dispose();
            */
            main_page_panel.Controls.Clear();
            
        }

        private void menu_fusion_calculator(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(fusion_page);
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(upload_page);
        }
        
        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(user_profile_page);
        }
        private void matchHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(match_history_page);
        }
        private void partOptimizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(part_page);
        }

        private void partViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(avail_part_page);
        }

        private void previousMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file_trace_managment.MatchRecord previous_match = match_detail_page.match_history.OrderByDescending(x => x.match_data.match_start).FirstOrDefault();

            if (previous_match == null)
                return;

            load_match_details(this, previous_match);
            match_detail_page.show_last_match = true;
        }

        private void printCurrentWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capture_screen_shot();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(about_page);
        }

        private void process_log_files(object sender, DoWorkEventArgs e)
        {
            log_file_managment.session_variables session_variables = (log_file_managment.session_variables)e.Argument;

            file_trace_managment.SessionStats Current_session = new file_trace_managment.SessionStats { };
            file_trace_managment ftm = new file_trace_managment();
            ftm.initialize_session_stats(Current_session, session_variables);
            load_precomipled_data(ftm, Current_session, session_variables);
            process_historic_files(ftm, Current_session, session_variables);
            populate_static_elements(Current_session);
            //populate_user_profile(Current_session);
            //populate_match_history(Current_session);
            //populate_build_records(Current_session);

            System.Threading.Thread.Sleep(1000); /* WEIRD SHIT IS HAPPENING HERE */
            process_live_files(ftm, Current_session);
        }
        void unlock_menu_strip(file_trace_managment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(global_data.UNLOCK_MENU_BAR_EVENT);
            Current_session.live_trace_data = true;
            add_last_match(Current_session);
        }
        private void populate_match_history(file_trace_managment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(global_data.POPULATE_MATCH_HISTORY_EVENT,
                    file_trace_manager.new_match_history_list(Current_session.match_history));
        }

        private void populate_static_elements(file_trace_managment.SessionStats Current_session)
        {
            
            bw_file_feed.ReportProgress(global_data.POPULATE_STATIC_ELEMENTS_EVENT,
                    file_trace_manager.new_static_element_response(Current_session.static_records));
        }

        private void populate_build_records(file_trace_managment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(global_data.BUILD_POPULATE_EVENT,
                    file_trace_manager.new_build_record_response(Current_session.player_build_records));
        }

        private void populate_user_profile(file_trace_managment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(global_data.POPULATE_USER_PROFILE_EVENT, 
                file_trace_manager.new_user_profile(
                    Current_session.match_history,
                    Current_session.player_build_records));
        }

        private void update_garage_view(file_trace_managment.SessionStats Current_session)
        {
            if (!Current_session.live_trace_data)
                return;

            if (Current_session.in_match)
                return;

            if (!Current_session.in_garage)
                return;

            if (Current_session.garage_data.damage_record.attacker != Current_session.local_user)
                return;

            bw_file_feed.ReportProgress(global_data.GARAGE_DAMAGE_EVENT, Current_session.garage_data.damage_record);
        }

        private void clear_current_test_drive_data()
        {
            bw_file_feed.ReportProgress(global_data.TEST_DRIVE_END_EVENT, null);
        }

        private void process_log_event(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == global_data.TRACE_EVENT_FILE_COMPLETE)
            {
                file_trace_managment.FileCompleteResponse response = (file_trace_managment.FileCompleteResponse)e.UserState;
                this.welcome_screen.pb_welcome_file_load.Value = (int)(response.historic_percent_processed * 100) > 100 ? 100 : (int)(response.historic_percent_processed * 100);
                this.welcome_screen.lb_load_status_text.Text = response.load_desc;
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(response.load_desc + Environment.NewLine));
            }
            else
            if (e.ProgressPercentage == global_data.UNLOCK_MENU_BAR_EVENT)
            {
                if (this.strp_main_menu_strip.Enabled == false)
                {
                    this.welcome_screen.tb_progress_tracking.AppendText(string.Format("Unlocking menu strip." + Environment.NewLine));
                    this.strp_main_menu_strip.Enabled = true;
                    this.welcome_screen.tb_progress_tracking.AppendText(string.Format("Complete." + Environment.NewLine));
                    this.welcome_screen.pb_welcome_file_load.Value = 100;
                    this.welcome_screen.lb_load_status_text.Text = "Complete.";
                }
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_USER_PROFILE_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating User Profile" + Environment.NewLine));
                file_trace_managment.UserProfileResponse response = (file_trace_managment.UserProfileResponse)e.UserState;
                user_profile_page.match_history = response.match_history;
                user_profile_page.build_records = response.build_records;
                meta_detail_page.match_history = response.match_history;
                meta_detail_page.build_records = response.build_records;
                revenue_page.match_history = response.match_history;
                upload_page.match_history = response.match_history;
                match_detail_page.match_history = response.match_history;
                revenue_page.build_records = response.build_records;
                match_detail_page.build_records = response.build_records;
                match_history_page.build_records = response.build_records;
                upload_page.build_records = response.build_records;
                user_profile_page.populate_user_profile_screen();
                revenue_page.populate_revenue_review_screen();
                meta_detail_page.populate_meta_detail_screen();
                upload_page.populate_upload_screen();
                if (session.upload_data)
                    upload_page.btn_upload_matchs_Click(this, EventArgs.Empty);
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_MATCH_HISTORY_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Match History" + Environment.NewLine));
                file_trace_managment.MatchHistoryResponse response = (file_trace_managment.MatchHistoryResponse)e.UserState;
                match_history_page.history = response.match_history;
                build_page.match_history = response;
                match_history_page.refersh_history_table();
            }
            else
            if (e.ProgressPercentage == global_data.MATCH_END_POPULATE_EVENT)
            {
                file_trace_managment.MatchEndResponse response = new file_trace_managment.MatchEndResponse { };
                response = (file_trace_managment.MatchEndResponse)e.UserState;
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Adding match from current session at {0}" + Environment.NewLine, response.last_match.match_start));
                match_detail_page.previous_match_data = response.last_match;
                match_detail_page.last_build_record = response.last_build;
                match_detail_page.populate_match();
                

            }
            else 
            if (e.ProgressPercentage == global_data.BUILD_POPULATE_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Build Records" + Environment.NewLine));
                file_trace_managment.BuildRecordResponse response = (file_trace_managment.BuildRecordResponse)e.UserState;
                build_page.build_records = response.build_records;
                build_page.populate_build_record_table();
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_STATIC_ELEMENTS_EVENT)
            {
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Configuring Build Optimization" + Environment.NewLine));
                file_trace_managment.StaticRecordResponse response = (file_trace_managment.StaticRecordResponse)e.UserState;
                part_page.master_part_list = response.master_static_records.global_parts_list;
                avail_part_page.master_part_list = response.master_static_records.global_parts_list;
                part_page.refresh_avail_parts();
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Loading Parts Based on Faction Levels" + Environment.NewLine));
                avail_part_page.populate_parts_list();
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Loading Clan War Schedule" + Environment.NewLine));
                schedule_page.event_times = response.master_static_records.global_event_times;
            }
            else
            if (e.ProgressPercentage == global_data.GARAGE_DAMAGE_EVENT)
            {
                file_trace_managment.GarageDamageRecord response = (file_trace_managment.GarageDamageRecord)e.UserState;
                garage_page.add_damage_record(response);
            }
            else
            if (e.ProgressPercentage == global_data.TEST_DRIVE_END_EVENT)
            {
                garage_page.reset_damage_records();
            }
            else
            if (e.ProgressPercentage == global_data.DEBUG_GIVE_LINE_UPDATE_EVENT)
            {
                file_trace_managment.DebugResponse response = (file_trace_managment.DebugResponse)e.UserState;
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"{0}{1}" + Environment.NewLine, response.event_type, response.line));
            }
        }

        private void load_precomipled_data(file_trace_managment ftm, file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session_variables)
        {
            if (!File.Exists(session.data_file_location + @"\match_history.json"))
                return;

            if (!File.Exists(session.data_file_location + @"\build_records.json"))
                return;

            if (session_variables.parsed_logs.Count() == 0)
                return;

            if (session_variables.client_version != global_data.CURRENT_VERSION)
            {
                session_variables.client_version = global_data.CURRENT_VERSION;
                session_variables.parsed_logs = new List<string> { };
                log_file_manager.save_session_config(session_variables);
                return;
            }
            
            int file_count = Current_session.file_data.historic_file_session_list.Count();

            try
            {
                using (StreamReader file = File.OpenText(session.data_file_location + @"\match_history.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Current_session.match_history = (List<file_trace_managment.MatchRecord>)serializer.Deserialize(file, typeof(List<file_trace_managment.MatchRecord>));
                }
            }
            catch (Exception ex)
            {
                Current_session.match_history = new List<file_trace_managment.MatchRecord> { };
                return;
            }

            try
            {
                using (StreamReader file = File.OpenText(session.data_file_location + @"\build_records.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Current_session.player_build_records = (Dictionary<string, file_trace_managment.BuildRecord>)serializer.Deserialize(file, typeof(Dictionary<string, file_trace_managment.BuildRecord>));
                }
            }
            catch (Exception ex)
            {
                Current_session.match_history = new List<file_trace_managment.MatchRecord> { };
                Current_session.player_build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
                return;
            }

            bw_file_feed.ReportProgress(global_data.TRACE_EVENT_FILE_COMPLETE, ftm.new_worker_response((double)session_variables.parsed_logs.Count() / (double)file_count, string.Format(@"Processed {0} existing logs.", session_variables.parsed_logs.Count())));
        }

        private void process_historic_files(file_trace_managment ftm, file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session_variables)
        {
            int file_count = Current_session.file_data.historic_file_session_list.Count();

            foreach (file_trace_managment.LogSession session in Current_session.file_data.historic_file_session_list.OrderBy(x => DateTime.ParseExact(x.combat_log.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)))
            {
                if (!File.Exists(session.combat_log.FullName))
                    continue;

                if (!File.Exists(session.game_log.FullName))
                    continue;

                if (session_variables.parsed_logs.Contains(session.combat_log.FullName))
                    continue;

                if (session_variables.parsed_logs.Contains(session.game_log.FullName))
                    continue;

                Current_session.file_data.processing_combat_session_file = session.combat_log;
                Current_session.file_data.processing_game_session_file = session.game_log;
                Current_session.file_data.processing_combat_session_file_day = DateTime.ParseExact(session.combat_log.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                Current_session.previous_combat_log_time = DateTime.MinValue;
                Current_session.previous_game_log_time = DateTime.MinValue;
                Current_session.current_combat_log_time = DateTime.MinValue;
                Current_session.current_game_log_time = DateTime.MinValue;
                Current_session.current_combat_log_day_offset = 0;
                Current_session.current_game_log_day_offset = 0;
                Current_session.in_match = false;
                Current_session.in_garage = false;
                Current_session.queue_start_time = DateTime.MinValue;

                //MessageBox.Show(string.Format(@"current file {0}, start day {1}", session.combat_log.Name, Current_session.file_data.processing_combat_session_file_day));

                bw_file_feed.ReportProgress(global_data.TRACE_EVENT_FILE_COMPLETE, ftm.new_worker_response((double)(session_variables.parsed_logs.Count() / 2) / (double)file_count, string.Format(@"Processing log files from {0,-19:MM-dd-yyyy hh:mm tt} ({1:N2}%)", DateTime.ParseExact(session.combat_log.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture), (((double)(session_variables.parsed_logs.Count() / 2) * 100) / (double)file_count))));

                using (FileStream game_stream = File.OpenRead(session.game_log.FullName))
                using (FileStream combat_stream = File.OpenRead(session.combat_log.FullName))
                {
                    using (StreamReader game_reader = new StreamReader(game_stream))
                    using (StreamReader combat_reader = new StreamReader(combat_stream))
                    {
                        string game_line;
                        string combat_line;

                        game_line = game_reader.ReadLine();
                        combat_line = combat_reader.ReadLine();

                        while (combat_line != null || game_line != null)
                        {
                            if (combat_line != null && combat_line.Length < 13)
                            {
                                combat_line = combat_reader.ReadLine();
                            }
                            else
                            if (combat_line != null && combat_line[12] != '|')
                            {
                                combat_line = combat_reader.ReadLine();
                            }
                            else
                            if (game_line != null && game_line.Length < 22)
                            {
                                game_line = game_reader.ReadLine();
                            }
                            else
                            if (game_line != null && game_line == string.Empty)
                            {
                                game_line = game_reader.ReadLine();
                            }
                            else
                            if (game_line != null && game_line.StartsWith("--- Date:"))
                            {
                                game_line = game_reader.ReadLine();
                            }
                            else
                            if (game_line != null && game_line[21] != '|')
                            {
                                game_line = game_reader.ReadLine();
                            }
                            else
                            if (combat_line != null && game_line != null)
                            {
                                if (Current_session.current_combat_log_time > Current_session.current_game_log_time)
                                {
                                    game_log_event_handler(game_line, Current_session);
                                    game_line = game_reader.ReadLine();
                                }
                                else 
                                if (Current_session.current_combat_log_time < Current_session.current_game_log_time)
                                {
                                    combat_log_event_handler(combat_line, Current_session);
                                    combat_line = combat_reader.ReadLine();
                                }
                                else
                                if (string.Compare(combat_line.Substring(0, 12), game_line.Substring(0, 12)) < 0)
                                {
                                    combat_log_event_handler(combat_line, Current_session);
                                    combat_line = combat_reader.ReadLine();
                                }
                                else
                                {
                                    game_log_event_handler(game_line, Current_session);
                                    game_line = game_reader.ReadLine();
                                }
                            }
                            else
                            if (combat_line != null)
                            {
                                combat_log_event_handler(combat_line, Current_session);
                                combat_line = combat_reader.ReadLine();
                            }
                            else
                            if (game_line != null)
                            {
                                game_log_event_handler(game_line, Current_session);
                                game_line = game_reader.ReadLine();
                            }
                        }
                    }
                }

                session.processed = true;
                session_variables.parsed_logs.Add(session.combat_log.FullName);
                session_variables.parsed_logs.Add(session.game_log.FullName);
            }

            log_file_manager.save_session_config(session_variables);
            save_game_data(Current_session);
        }

        private void save_game_data(file_trace_managment.SessionStats Current_session)
        {
            using (StreamWriter file = File.CreateText(session.data_file_location + @"\match_history.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Current_session.match_history);
            }

            using (StreamWriter file = File.CreateText(session.data_file_location + @"\build_records.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Current_session.player_build_records);
            }
        }

        private void process_live_files(file_trace_managment ftm, file_trace_managment.SessionStats Current_session)
        {
            bool found_new_file = false;

            FileInfo combat_trace_file = new DirectoryInfo(session.log_file_location).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            FileInfo game_trace_file = new DirectoryInfo(session.log_file_location).GetFiles("game.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

            Current_session.file_data.processing_combat_session_file = combat_trace_file;
            Current_session.file_data.processing_game_session_file = game_trace_file;
            Current_session.file_data.processing_combat_session_file_day = combat_trace_file.CreationTime;
            Current_session.previous_combat_log_time = DateTime.MinValue;
            Current_session.previous_game_log_time = DateTime.MinValue;
            Current_session.previous_game_log_time = DateTime.MinValue;
            Current_session.current_combat_log_time = DateTime.MinValue;
            Current_session.current_combat_log_day_offset = 0;
            Current_session.current_game_log_day_offset = 0;
            Current_session.queue_start_time = DateTime.MinValue;
            Current_session.in_match = false;
            Current_session.in_garage = false;
            

            AutoResetEvent game_auto_reset = new AutoResetEvent(false);
            AutoResetEvent combat_auto_reset = new AutoResetEvent(false);
            FileSystemWatcher game_file_system_watcher = new FileSystemWatcher(".");
            FileSystemWatcher combat_file_system_watcher = new FileSystemWatcher(".");
            game_file_system_watcher.Filter = game_trace_file.FullName;
            combat_file_system_watcher.Filter = combat_trace_file.FullName;
            game_file_system_watcher.EnableRaisingEvents = true;
            combat_file_system_watcher.EnableRaisingEvents = true;
            game_file_system_watcher.Changed += (s, e) => game_auto_reset.Set();
            combat_file_system_watcher.Changed += (s, e) => combat_auto_reset.Set();

            long start_time = DateTime.Now.Ticks;
            bool first = true;
            FileStream game_file_stream = new FileStream(game_trace_file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream combat_file_stream = new FileStream(combat_trace_file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader game_reader = new StreamReader(game_file_stream);
            StreamReader combat_reader = new StreamReader(combat_file_stream);

            try
            {
                string game_line = game_reader.ReadLine();
                string combat_line = game_line = combat_reader.ReadLine();

                while (found_new_file == false)
                {
                    if (combat_line != null && combat_line.Length < 13)
                    {
                        combat_line = combat_reader.ReadLine();
                    }
                    else
                    if (game_line != null && game_line.Length < 22)
                    {
                        game_line = game_reader.ReadLine();
                    }
                    else
                    if (game_line != null && game_line[21] != '|')
                    {
                        game_line = game_reader.ReadLine();
                    }
                    else
                    if (combat_line != null && combat_line[12] != '|')
                    {
                        combat_line = combat_reader.ReadLine();
                    }
                    else
                    if (game_line != null && game_line.Substring(0, 9) == "--- Date:")
                    {
                        game_line = game_reader.ReadLine();
                    }
                    else
                    if (combat_line != null && game_line != null)
                    {
                        if (Current_session.current_combat_log_time > Current_session.current_game_log_time)
                        {
                            game_log_event_handler(game_line, Current_session);
                            game_line = game_reader.ReadLine();
                        }
                        else
                                if (Current_session.current_combat_log_time < Current_session.current_game_log_time)
                        {
                            combat_log_event_handler(combat_line, Current_session);
                            combat_line = combat_reader.ReadLine();
                        }
                        else
                        if (string.Compare(combat_line.Substring(0, 12), game_line.Substring(0, 12)) < 0)
                        {
                            combat_log_event_handler(combat_line, Current_session);
                            combat_line = combat_reader.ReadLine();
                        }
                        else
                        {
                            game_log_event_handler(game_line, Current_session);
                            game_line = game_reader.ReadLine();
                        }
                        start_time = DateTime.Now.Ticks;
                    }
                    else
                    if (combat_line != null)
                    {
                        combat_log_event_handler(combat_line, Current_session);
                        combat_line = combat_reader.ReadLine();
                        start_time = DateTime.Now.Ticks;
                    }
                    else
                    if (game_line != null)
                    {
                        game_log_event_handler(game_line, Current_session);
                        game_line = game_reader.ReadLine();
                        start_time = DateTime.Now.Ticks;
                    }
                    else
                    {
                        if (first == true)
                        {
                            first = false;
                            unlock_menu_strip(Current_session);
                        }

                        if (new TimeSpan(DateTime.Now.Ticks - start_time).TotalSeconds > 30)
                        {
                            if (combat_trace_file.FullName != new DirectoryInfo(session.log_file_location).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName ||
                                game_trace_file.FullName != new DirectoryInfo(session.log_file_location).GetFiles("game.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName)
                            {
                                found_new_file = true;
                            }
                            start_time = DateTime.Now.Ticks;
                        }

                        System.Threading.Thread.Sleep(100);
                        combat_line = combat_reader.ReadLine();
                        game_line = game_reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occured with the background task." + Environment.NewLine + ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace);
            }
            finally
            {
                game_auto_reset.Dispose();
                combat_auto_reset.Dispose();
                game_file_system_watcher.Dispose();
                combat_file_system_watcher.Dispose();
                game_file_stream.Dispose();
                combat_file_stream.Dispose();
                game_reader.Dispose();
                combat_reader.Dispose();
            }
            process_live_files(ftm, Current_session);
        }
        void game_log_event_handler(string line, file_trace_managment.SessionStats Current_session)
        {
            file_trace_managment.assign_current_game_event(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "g:"+line));

            file_trace_managment.update_current_time("g", line, Current_session);

            switch (Current_session.current_event)
            {
                case global_data.QUEUE_START_EVENT:
                    file_trace_managment.queue_start_event(line, Current_session);
                    break;
                case global_data.QUEUE_UPDATE_EVENT:
                    file_trace_managment.queue_update_event(line, Current_session);
                    break;
                case global_data.QUEUE_END_EVENT:
                    file_trace_managment.queue_end_event(line, Current_session);
                    break;
                case global_data.GAME_PLAYER_LOAD_EVENT:
                    file_trace_managment.load_player_from_game_log(line, Current_session);
                    break;
                case global_data.PLAYER_LEAVE_EVENT:
                    file_trace_managment.player_leave_event(line, Current_session);
                    break;
                case global_data.GUID_ASSIGN_EVENT:
                    file_trace_managment.guid_assign_event(line, Current_session);
                    break;
                case global_data.ADD_OR_UPDATE_PLAYER_EVENT:
                    file_trace_managment.add_or_update_player_from_game_log(line, Current_session);
                    break;
                case global_data.GAME_PLAYER_SPAWN_EVENT:
                    file_trace_managment.spawn_player_from_game_log(line, Current_session);
                    break;
                case global_data.HOST_NAME_ASSIGN_EVENT:
                    file_trace_managment.dedicated_server_connect_event(line, Current_session);
                    break;
                case global_data.CONNECTION_INIT_EVENT:
                    file_trace_managment.connection_made_event(line, Current_session);
                    break;
                case global_data.MATCH_REWARD_EVENT:
                    file_trace_managment.match_reward_event(line, Current_session);
                    if (Current_session.current_match.match_type_desc != "")
                        add_last_match(Current_session);
                    break;
                case global_data.MATCH_PROPERTY_EVENT:
                    file_trace_managment.assign_match_property(line, Current_session);
                    break;
                case global_data.ADVENTURE_REWARD_EVENT:
                    file_trace_managment.assign_adventure_reward_event(line, Current_session);
                    break;
                case global_data.QUEST_EVENT:
                    break;
                case global_data.LOOT_EVENT:
                    file_trace_managment.assign_loot_event(line, Current_session);
                    break;
                case global_data.ASSIGN_CLIENT_VERSION_EVENT:
                    file_trace_managment.assign_client_version_event(line, Current_session);
                    break;
            }
            file_trace_managment.update_previous_time("g", line, Current_session);
            Current_session.previous_game_event = Current_session.current_event;
        }
        void combat_log_event_handler(string line, file_trace_managment.SessionStats Current_session)
        {
            file_trace_managment.assign_current_combat_event(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "c:" + line));

            file_trace_managment.update_current_time("c", line, Current_session);

            switch (Current_session.current_event)
            {
                case global_data.MATCH_START_EVENT:
                    add_last_match(Current_session);
                    file_trace_managment.match_start_event(line, Current_session);
                    break;
                case global_data.GAME_PLAY_START_EVENT:
                    file_trace_managment.gameplay_start_event(line, Current_session);
                    break;
                case global_data.LOAD_PLAYER_EVENT:
                    file_trace_managment.load_player_event(line, Current_session);
                    break;
                case global_data.SPAWN_PLAYER_EVENT:
                    file_trace_managment.spawn_player_event(line, Current_session);
                    break;
                case global_data.DAMAGE_EVENT:
                    file_trace_managment.damage_event(line, Current_session);
                    update_garage_view(Current_session);
                    break;
                case global_data.STRIPE_EVENT:
                    file_trace_managment.stripe_event(line, Current_session);
                    break;
                case global_data.KILL_EVENT:
                    file_trace_managment.kill_event(line, Current_session);
                    break;
                case global_data.ASSIST_EVENT:
                    file_trace_managment.kill_assist_event(line, Current_session);
                    break;
                case global_data.SCORE_EVENT:
                    file_trace_managment.score_event(line, Current_session);
                    break;
                case global_data.CW_ROUND_END_EVENT:
                    file_trace_managment.clan_war_round_end_event(line, Current_session);
                    break;
                case global_data.MAIN_MENU_EVENT:
                    file_trace_managment.main_menu_event(line, Current_session);
                    add_last_match(Current_session);
                    break;
                case global_data.TEST_DRIVE_EVENT:
                    file_trace_managment.test_drive_event(line, Current_session);
                    clear_current_test_drive_data();
                    break;
                case global_data.MATCH_END_EVENT:
                    file_trace_managment.match_end_event(line, Current_session);
                    add_last_match(Current_session);
                    break;
                case global_data.ADD_MOB_EVENT:
                    file_trace_managment.add_mob_event(line, Current_session);
                    break;
            }
            file_trace_managment.update_previous_time("c", line, Current_session);
            overlay.resolve_overlay_action(Current_session, session, translations, Current_session.current_event);
            Current_session.previous_combat_event = Current_session.current_event;
        }
        private void capture_screen_shot()
        {
            string screenshot_directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + string.Format(@"\CO_Driver\screenshots");
            int border_width = 1;

            if (!Directory.Exists(screenshot_directory))
            {
                Directory.CreateDirectory(screenshot_directory);
            }

            Bitmap bmp = new Bitmap(main_page_panel.Width + border_width * 2, main_page_panel.Height + border_width * 2);
            main_page_panel.DrawToBitmap(bmp, new Rectangle(border_width, border_width, main_page_panel.Width + border_width, main_page_panel.Height + border_width));


            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            gr.DrawLine(new Pen(session.fore_color, border_width * 2), new Point(0,         0),          new Point(0,         bmp.Height));
            gr.DrawLine(new Pen(session.fore_color, border_width * 2), new Point(0,         0),          new Point(bmp.Width, 0));
            gr.DrawLine(new Pen(session.fore_color, border_width * 2), new Point(0,         bmp.Height), new Point(bmp.Width, bmp.Height));
            gr.DrawLine(new Pen(session.fore_color, border_width * 2), new Point(bmp.Width, 0),          new Point(bmp.Width, bmp.Height));

            Clipboard.SetImage((Image)bmp);

            if (session.save_captures)
            {
                try
                {
                    bmp.Save(string.Format(@"{0}\co_driver{1}.png", screenshot_directory, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Png);
                }
                catch (Exception ex)
                {

                }
            }

            bmp.Dispose();
            gr.Dispose();
        }

        void add_last_match(file_trace_managment.SessionStats Current_session)
        {
            if (Current_session.live_trace_data == false)
                return;

            file_trace_managment.BuildRecord last_build_record = new file_trace_managment.BuildRecord { };

            if (Current_session.player_build_records.ContainsKey(Current_session.current_match.local_player.build_hash))
                last_build_record = Current_session.player_build_records[Current_session.current_match.local_player.build_hash];

            bw_file_feed.ReportProgress(global_data.MATCH_END_POPULATE_EVENT, file_trace_manager.new_match_end_response(Current_session.current_match, last_build_record));

            if (session.update_postmatch)
            {
                user_profile_page.force_refresh = true;
                build_page.force_refresh = true;
                match_history_page.force_refresh = true;
                revenue_page.force_refresh = true;
                meta_detail_page.force_refresh = true;
            }
            populate_user_profile(Current_session);
            populate_match_history(Current_session);
            populate_build_records(Current_session);
        }

        public string get_current_version()
        {
            return global_data.CURRENT_VERSION;
        }

        private void load_match_details(object sender, file_trace_managment.MatchRecord historic_match)
        {
            match_detail_page.historical_match_data = historic_match.match_data;
            match_detail_page.show_last_match = false;
            match_detail_page.populate_match();
            clear_main_page_panel();
            main_page_panel.Controls.Add(match_detail_page);
        }

        private void buildToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void liveGarageChartingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(garage_page);
        }

        private void stateOfYourMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(meta_detail_page);
        }

        private void revenueAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(revenue_page);
        }

        private void clanWarScheduleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            schedule_page.populate_schedule_display("cw");
            main_page_panel.Controls.Add(schedule_page);
        }

        private void brawlScheduleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            schedule_page.populate_schedule_display("brawl");
            main_page_panel.Controls.Add(schedule_page);
        }

        private void combatlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Combat", session));
            theme_manager.apply_theme(main_page_panel, session);
        }

        private void gamelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Game", session));
            theme_manager.apply_theme(main_page_panel, session);
        }

        private void chatlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Chat", session));
            theme_manager.apply_theme(main_page_panel, session);
        }

        private void netlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Net", session));
            theme_manager.apply_theme(main_page_panel, session);
        }

        private void gfxlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Gfx", session));
            theme_manager.apply_theme(main_page_panel, session);
        }

        private void buildReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(build_page);
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.AllScreens.FirstOrDefault(x => x.DeviceName == session.primary_display).Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = Initial_screen_size;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
    }
}
