using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class frm_main_page : Form
    {
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations { get; set; } = new Dictionary<string, Dictionary<string, Translate.Translation>> { };
        public Market.MarketData crossoutdb_data = new Market.MarketData { };

        public List<FileTraceManagment.MatchRecord> match_history
        {
            get { return match_history.ToList(); }
            set { match_history = value; }
        }

        public LogFileManagment log_file_manager = new LogFileManagment();
        public FileTraceManagment file_trace_manager = new FileTraceManagment();
        public Theme theme_manager = new Theme { };
        public Upload uploader = new Upload { };
        public WelcomePage welcome_screen = new WelcomePage();
        public UserProfile user_profile_page = new UserProfile();
        public MatchHistory match_history_page = new MatchHistory();
        public ScheduleDisplay schedule_page = new ScheduleDisplay();
        public BuildView build_page = new BuildView();
        public ComparisonScreen comparison_page = new ComparisonScreen();
        public PartOptimizer part_page = new PartOptimizer();
        public PartView avail_part_page = new PartView();
        public MatchDetail match_detail_page = new MatchDetail();
        public GarageView garage_page = new GarageView();
        public FusionCalculator fusion_page = new FusionCalculator();
        public UserSettings settings_page = new UserSettings();
        public AboutScreen about_page = new AboutScreen();
        public MetaDetail meta_detail_page = new MetaDetail();
        public RevenueReview revenue_page = new RevenueReview();
        public UploadScreen upload_page = new UploadScreen();

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

            session = log_file_manager.LoadUserSession();

            if (session.LocalUserName == null)
            {
                MessageBox.Show("An error has occured while loading, please try restarting CO_Driver. If the problem persists please report to https://discord.gg/kKcnVXu2Xe. Thanks.");
                Application.Exit();
            }

            UITranslate.LoadUITranslate(ui_translations);
            Translate.PopulateTranslations(session, translations);

            reload_theme(this, EventArgs.Empty);
            Initial_screen_size = this.Size;
            strp_main_menu_strip.ShowItemToolTips = true;

            this.welcome_screen.tb_progress_tracking.AppendText("Loading market data from crossoutdb.com" + Environment.NewLine);
            crossoutdb_data = Market.PopulateCrossoutDBData(session);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading previously stored log data (if any)." + Environment.NewLine);

            load_static_screen_data();

            match_history_page.load_selected_match += new EventHandler<FileTraceManagment.MatchRecord>(load_match_details);
            match_detail_page.load_selected_match += new EventHandler<FileTraceManagment.MatchRecord>(load_match_details);
            match_history_page.load_selected_build += new EventHandler<string>(load_build_details);
            match_detail_page.load_selected_build += new EventHandler<string>(load_build_details);

            settings_page.reload_all_themes += new EventHandler(reload_theme);
            settings_page.enable_uploads += new EventHandler(enable_upload);

            garage_page.initialize_live_feed();
            comparison_page.initialize_comparison_screen();
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
            comparison_page.session = session;
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
            comparison_page.translations = translations;
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
            build_page.uiTranslations = ui_translations;
            comparison_page.ui_translations = ui_translations;
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
            translate_controls(comparison_page);
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
                ctrl.Text = UITranslate.Translate(ctrl.Text, session, ui_translations);

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
                item.Text = UITranslate.Translate(item.Text, session, ui_translations);
        }

        private void translate_text_box(TextBox text_box)
        {
            List<string> text_lines = new List<string> { };

            foreach (string line in text_box.Lines)
                text_lines.Add(UITranslate.Translate(line, session, ui_translations));

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

        private void append_combo_box_controls(string panel_name, ComboBox drop_down, StreamWriter sw)
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
            theme_manager.ApplyTheme(main_page_panel, session);
            theme_manager.ApplyTheme(welcome_screen, session);
            theme_manager.ApplyTheme(user_profile_page, session);
            theme_manager.ApplyTheme(match_history_page, session);
            theme_manager.ApplyTheme(schedule_page, session);
            theme_manager.ApplyTheme(build_page, session);
            theme_manager.ApplyTheme(comparison_page, session);
            theme_manager.ApplyTheme(part_page, session);
            theme_manager.ApplyTheme(avail_part_page, session);
            theme_manager.ApplyTheme(match_detail_page, session);
            theme_manager.ApplyTheme(garage_page, session);
            theme_manager.ApplyTheme(fusion_page, session);
            theme_manager.ApplyTheme(settings_page, session);
            theme_manager.ApplyTheme(about_page, session);
            theme_manager.ApplyTheme(meta_detail_page, session);
            theme_manager.ApplyTheme(revenue_page, session);
            theme_manager.ApplyTheme(upload_page, session);
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
            //foreach (Control ctrl in main_page_panel.Controls)
            //    ctrl.Dispose();

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
            FileTraceManagment.MatchRecord previous_match = match_detail_page.match_history.OrderByDescending(x => x.MatchData.MatchStart).FirstOrDefault();

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
            LogFileManagment.SessionVariables session_variables = (LogFileManagment.SessionVariables)e.Argument;

            FileTraceManagment.SessionStats Current_session = new FileTraceManagment.SessionStats { };
            FileTraceManagment ftm = new FileTraceManagment();
            ftm.InitializeSessionStats(Current_session, session_variables);
            load_precomipled_data(ftm, Current_session, session_variables);
            process_historic_files(ftm, Current_session, session_variables);
            populate_static_elements(Current_session);
            //populate_user_profile(Current_session);
            //populate_match_history(Current_session);
            //populate_build_records(Current_session);

            System.Threading.Thread.Sleep(1000); /* WEIRD SHIT IS HAPPENING HERE */
            process_live_files(ftm, Current_session);
        }
        void unlock_menu_strip(FileTraceManagment.SessionStats Current_session)
        {
            Current_session.LiveTraceData = true;
            add_last_match(Current_session);
            bw_file_feed.ReportProgress(GlobalData.UNLOCK_MENU_BAR_EVENT);
        }
        private void populate_match_history(FileTraceManagment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(GlobalData.POPULATE_MATCH_HISTORY_EVENT,
                    file_trace_manager.NewMatchHistoryList(Current_session.MatchHistory));
        }

        private void populate_static_elements(FileTraceManagment.SessionStats Current_session)
        {

            bw_file_feed.ReportProgress(GlobalData.POPULATE_STATIC_ELEMENTS_EVENT,
                    file_trace_manager.NewStaticElementResponse(Current_session.StaticRecords));
        }

        private void populate_build_records(FileTraceManagment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(GlobalData.BUILD_POPULATE_EVENT,
                    file_trace_manager.NewBuildRecordResponse(Current_session.PlayerBuildRecords));
        }

        private void populate_user_profile(FileTraceManagment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(GlobalData.POPULATE_USER_PROFILE_EVENT,
                file_trace_manager.NewUserProfile(
                    Current_session.MatchHistory,
                    Current_session.PlayerBuildRecords));
        }

        private void update_garage_view(FileTraceManagment.SessionStats Current_session)
        {
            if (!Current_session.LiveTraceData)
                return;

            if (Current_session.InMatch)
                return;

            if (!Current_session.InGarage)
                return;

            if (Current_session.GarageData.DamageRecord.Attacker != Current_session.LocalUser)
                return;

            bw_file_feed.ReportProgress(GlobalData.GARAGE_DAMAGE_EVENT, Current_session.GarageData.DamageRecord);
        }

        private void clear_current_test_drive_data()
        {
            bw_file_feed.ReportProgress(GlobalData.TEST_DRIVE_END_EVENT, null);
        }

        private void process_log_event(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == GlobalData.TRACE_EVENT_FILE_COMPLETE)
            {
                FileTraceManagment.FileCompleteResponse response = (FileTraceManagment.FileCompleteResponse)e.UserState;
                this.welcome_screen.pb_welcome_file_load.Value = (int)(response.HistoricPercentProcessed * 100) > 95 ? 95 : (int)(response.HistoricPercentProcessed * 100);
                this.welcome_screen.lb_load_status_text.Text = response.LoadDesc;
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(response.LoadDesc + Environment.NewLine));
            }
            else
            if (e.ProgressPercentage == GlobalData.UNLOCK_MENU_BAR_EVENT)
            {
                if (this.strp_main_menu_strip.Enabled == false)
                {
                    this.welcome_screen.tb_progress_tracking.AppendText(string.Format("Unlocking menu strip." + Environment.NewLine));
                    this.strp_main_menu_strip.Enabled = true;
                    this.welcome_screen.tb_progress_tracking.AppendText(string.Format("Complete." + Environment.NewLine));
                    this.welcome_screen.pb_welcome_file_load.Value = 95;
                    this.welcome_screen.lb_load_status_text.Text = "Complete.";

                    clear_main_page_panel();
                    main_page_panel.Controls.Add(user_profile_page);
                }
            }
            else
            if (e.ProgressPercentage == GlobalData.POPULATE_USER_PROFILE_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating User Profile" + Environment.NewLine));
                FileTraceManagment.UserProfileResponse response = (FileTraceManagment.UserProfileResponse)e.UserState;
                user_profile_page.match_history = response.MatchHistory;
                user_profile_page.build_records = response.BuildRecords;
                meta_detail_page.match_history = response.MatchHistory;
                meta_detail_page.build_records = response.BuildRecords;
                comparison_page.match_history = response.MatchHistory;
                comparison_page.build_records = response.BuildRecords;
                revenue_page.match_history = response.MatchHistory;
                upload_page.match_history = response.MatchHistory;
                match_detail_page.match_history = response.MatchHistory;
                revenue_page.build_records = response.BuildRecords;
                match_detail_page.build_records = response.BuildRecords;
                match_history_page.build_records = response.BuildRecords;
                upload_page.build_records = response.BuildRecords;
                user_profile_page.populate_user_profile_screen();
                revenue_page.populate_revenue_review_screen();
                meta_detail_page.populate_meta_detail_screen();
                comparison_page.populate_comparison_chart();
                upload_page.populate_upload_screen();
                if (session.UploadData)
                    upload_page.btn_upload_matchs_Click(this, EventArgs.Empty);
            }
            else
            if (e.ProgressPercentage == GlobalData.POPULATE_MATCH_HISTORY_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Match History" + Environment.NewLine));
                FileTraceManagment.MatchHistoryResponse response = (FileTraceManagment.MatchHistoryResponse)e.UserState;
                match_history_page.history = response.MatchHistory;
                build_page.matchHistory = response;
                match_history_page.refersh_history_table();
            }
            else
            if (e.ProgressPercentage == GlobalData.MATCH_END_POPULATE_EVENT)
            {
                FileTraceManagment.MatchEndResponse response = new FileTraceManagment.MatchEndResponse { };
                response = (FileTraceManagment.MatchEndResponse)e.UserState;
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Adding match from current session at {0}" + Environment.NewLine, response.LastMatch.MatchStart));
                match_detail_page.previous_match_data = response.LastMatch;
                match_detail_page.last_build_record = response.LastBuild;
                match_detail_page.populate_match();


            }
            else
            if (e.ProgressPercentage == GlobalData.BUILD_POPULATE_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Build Records" + Environment.NewLine));
                FileTraceManagment.BuildRecordResponse response = (FileTraceManagment.BuildRecordResponse)e.UserState;
                build_page.buildRecords = response.BuildRecords;
                build_page.PopulateBuildRecordTable();
            }
            else
            if (e.ProgressPercentage == GlobalData.POPULATE_STATIC_ELEMENTS_EVENT)
            {
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Configuring Build Optimization" + Environment.NewLine));
                FileTraceManagment.StaticRecordResponse response = (FileTraceManagment.StaticRecordResponse)e.UserState;
                part_page.master_part_list = response.MasterStaticRecords.GlobalPartsList;
                avail_part_page.master_part_list = response.MasterStaticRecords.GlobalPartsList;
                part_page.refresh_avail_parts();
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Loading Parts Based on Faction Levels" + Environment.NewLine));
                avail_part_page.populate_parts_list();
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Loading Clan War Schedule" + Environment.NewLine));
                schedule_page.event_times = response.MasterStaticRecords.GlobalEventTimes;
            }
            else
            if (e.ProgressPercentage == GlobalData.GARAGE_DAMAGE_EVENT)
            {
                FileTraceManagment.GarageDamageRecord response = (FileTraceManagment.GarageDamageRecord)e.UserState;
                garage_page.add_damage_record(response);
            }
            else
            if (e.ProgressPercentage == GlobalData.TEST_DRIVE_END_EVENT)
            {
                garage_page.reset_damage_records();
            }
            else
            if (e.ProgressPercentage == GlobalData.DEBUG_GIVE_LINE_UPDATE_EVENT)
            {
                FileTraceManagment.DebugResponse response = (FileTraceManagment.DebugResponse)e.UserState;
                welcome_screen.tb_progress_tracking.AppendText(string.Format(@"{0}{1}" + Environment.NewLine, response.EventType, response.Line));
            }
        }

        private void load_precomipled_data(FileTraceManagment ftm, FileTraceManagment.SessionStats Current_session, LogFileManagment.SessionVariables session_variables)
        {
            if (!File.Exists(session.DataFileLocation + @"\match_history.json"))
                return;

            if (!File.Exists(session.DataFileLocation + @"\build_records.json"))
                return;

            if (session_variables.ParsedLogs.Count() == 0)
                return;

            if (session_variables.ClientVersion != GlobalData.CURRENT_VERSION)
            {
                session_variables.ClientVersion = GlobalData.CURRENT_VERSION;
                session_variables.ParsedLogs = new List<string> { };
                log_file_manager.SaveSessionConfig(session_variables);
                return;
            }

            int file_count = Current_session.FileData.HistoricFileSessionList.Count();

            try
            {
                using (StreamReader file = File.OpenText(session.DataFileLocation + @"\match_history.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Current_session.MatchHistory = (List<FileTraceManagment.MatchRecord>)serializer.Deserialize(file, typeof(List<FileTraceManagment.MatchRecord>));
                }
            }
            catch (Exception)
            {
                Current_session.MatchHistory = new List<FileTraceManagment.MatchRecord> { };
                return;
            }

            try
            {
                using (StreamReader file = File.OpenText(session.DataFileLocation + @"\build_records.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Current_session.PlayerBuildRecords = (Dictionary<string, FileTraceManagment.BuildRecord>)serializer.Deserialize(file, typeof(Dictionary<string, FileTraceManagment.BuildRecord>));
                }
            }
            catch (Exception)
            {
                Current_session.MatchHistory = new List<FileTraceManagment.MatchRecord> { };
                Current_session.PlayerBuildRecords = new Dictionary<string, FileTraceManagment.BuildRecord> { };
                return;
            }

            bw_file_feed.ReportProgress(GlobalData.TRACE_EVENT_FILE_COMPLETE, ftm.NewWorkerResponse((double)session_variables.ParsedLogs.Count() / (double)file_count, string.Format(@"Processed {0} existing logs.", session_variables.ParsedLogs.Count())));
        }

        private void process_historic_files(FileTraceManagment ftm, FileTraceManagment.SessionStats Current_session, LogFileManagment.SessionVariables session_variables)
        {
            int file_count = Current_session.FileData.HistoricFileSessionList.Count();

            foreach (FileTraceManagment.LogSession session in Current_session.FileData.HistoricFileSessionList.OrderBy(x => DateTime.ParseExact(x.CombatLog.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture)))
            {
                if (!File.Exists(session.CombatLog.FullName))
                    continue;

                if (!File.Exists(session.GameLog.FullName))
                    continue;

                if (session_variables.ParsedLogs.Contains(session.CombatLog.FullName))
                    continue;

                if (session_variables.ParsedLogs.Contains(session.GameLog.FullName))
                    continue;

                Current_session.FileData.ProcessingCombatSessionFile = session.CombatLog;
                Current_session.FileData.ProcessingGameSessionFile = session.GameLog;
                Current_session.FileData.ProcessingCombatSessionFileDay = DateTime.ParseExact(session.CombatLog.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                Current_session.PreviousCombatLogTime = DateTime.MinValue;
                Current_session.PreviousGameLogTime = DateTime.MinValue;
                Current_session.CurrentCombatLogTime = DateTime.MinValue;
                Current_session.CurrentGameLogTime = DateTime.MinValue;
                Current_session.CurrentCombatLogDayOffset = 0;
                Current_session.CurrentGameLogDayOffset = 0;
                Current_session.InMatch = false;
                Current_session.InGarage = false;
                Current_session.QueueStartTime = DateTime.MinValue;

                //MessageBox.Show(string.Format(@"current file {0}, start day {1}", session.combat_log.Name, Current_session.file_data.processing_combat_session_file_day));

                bw_file_feed.ReportProgress(GlobalData.TRACE_EVENT_FILE_COMPLETE, ftm.NewWorkerResponse((double)(session_variables.ParsedLogs.Count() / 2) / (double)file_count, string.Format(@"Processing log files from {0,-19:MM-dd-yyyy hh:mm tt} ({1:N2}%)", DateTime.ParseExact(session.CombatLog.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture), (((double)(session_variables.ParsedLogs.Count() / 2) * 100) / (double)file_count))));

                using (FileStream game_stream = File.OpenRead(session.GameLog.FullName))
                using (FileStream combat_stream = File.OpenRead(session.CombatLog.FullName))
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
                                if (Current_session.CurrentCombatLogTime > Current_session.CurrentGameLogTime)
                                {
                                    game_log_event_handler(game_line, Current_session);
                                    game_line = game_reader.ReadLine();
                                }
                                else
                                if (Current_session.CurrentCombatLogTime < Current_session.CurrentGameLogTime)
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

                session.Processed = true;
                session_variables.ParsedLogs.Add(session.CombatLog.FullName);
                session_variables.ParsedLogs.Add(session.GameLog.FullName);
            }

            log_file_manager.SaveSessionConfig(session_variables);
            save_game_data(Current_session);
        }

        private void save_game_data(FileTraceManagment.SessionStats Current_session)
        {
            using (StreamWriter file = File.CreateText(session.DataFileLocation + @"\match_history.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Current_session.MatchHistory);
            }

            using (StreamWriter file = File.CreateText(session.DataFileLocation + @"\build_records.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Current_session.PlayerBuildRecords);
            }
        }

        private void process_live_files(FileTraceManagment ftm, FileTraceManagment.SessionStats Current_session)
        {
            bool found_new_file = false;

            FileInfo combat_trace_file = new DirectoryInfo(session.LogFileLocation).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            FileInfo game_trace_file = new DirectoryInfo(session.LogFileLocation).GetFiles("game.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

            Current_session.FileData.ProcessingCombatSessionFile = combat_trace_file;
            Current_session.FileData.ProcessingGameSessionFile = game_trace_file;
            Current_session.FileData.ProcessingCombatSessionFileDay = combat_trace_file.CreationTime;
            Current_session.PreviousCombatLogTime = DateTime.MinValue;
            Current_session.PreviousGameLogTime = DateTime.MinValue;
            Current_session.PreviousGameLogTime = DateTime.MinValue;
            Current_session.CurrentCombatLogTime = DateTime.MinValue;
            Current_session.CurrentCombatLogDayOffset = 0;
            Current_session.CurrentGameLogDayOffset = 0;
            Current_session.QueueStartTime = DateTime.MinValue;
            Current_session.InMatch = false;
            Current_session.InGarage = false;

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
            LookAheadStreamReader combat_reader = new LookAheadStreamReader(combat_file_stream);

            try
            {
                string game_line = game_reader.ReadLine();
                string combat_line = combat_reader.ReadLine();

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
                        if (Current_session.CurrentCombatLogTime > Current_session.CurrentGameLogTime)
                        {
                            if ((combat_line.Contains("| ====== starting level ") ||
                                combat_line.Contains("levels/maps/hangar") ||
                                combat_line.Contains("| ====== TestDrive finish ======") ||
                                combat_line.Contains("| ===== Gameplay finish")) &&
                                Current_session.LiveTraceData &&
                                combat_reader.PeekNextLine() == null)
                            {
                                MessageBox.Show($"{combat_line}\n\n\n{game_line}\n\n\n{combat_reader.PeekNextLine()}");

                                continue;
                            }

                            game_log_event_handler(game_line, Current_session);
                            game_line = game_reader.ReadLine();
                        }
                        else
                        if (Current_session.CurrentCombatLogTime < Current_session.CurrentGameLogTime)
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
                            if ((combat_line.Contains("| ====== starting level ") ||
                                combat_line.Contains("levels/maps/hangar") ||
                                combat_line.Contains("| ====== TestDrive finish ======") ||
                                combat_line.Contains("| ===== Gameplay finish")) &&
                                Current_session.LiveTraceData &&
                                combat_reader.PeekNextLine() == null)
                            {
                                continue;
                            }

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
                            if (combat_trace_file.FullName != new DirectoryInfo(session.LogFileLocation).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName ||
                                game_trace_file.FullName != new DirectoryInfo(session.LogFileLocation).GetFiles("game.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First().FullName)
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
        void game_log_event_handler(string line, FileTraceManagment.SessionStats Current_session)
        {
            FileTraceManagment.AssignCurrentGameEvent(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "g:"+line));

            FileTraceManagment.UpdateCurrentTime("g", line, Current_session);

            switch (Current_session.CurrentEvent)
            {
                case GlobalData.QUEUE_START_EVENT:
                    FileTraceManagment.QueueStartEvent(line, Current_session);
                    break;
                case GlobalData.QUEUE_UPDATE_EVENT:
                    FileTraceManagment.QueueUpdateEvent(line, Current_session);
                    break;
                case GlobalData.QUEUE_END_EVENT:
                    FileTraceManagment.QueueEndEvent(line, Current_session);
                    break;
                case GlobalData.GAME_PLAYER_LOAD_EVENT:
                    FileTraceManagment.LoadPlayerFromGameLog(line, Current_session);
                    break;
                case GlobalData.PLAYER_LEAVE_EVENT:
                    FileTraceManagment.PlayerLeaveEvent(line, Current_session);
                    break;
                case GlobalData.GUID_ASSIGN_EVENT:
                    FileTraceManagment.GuidAssignEvent(line, Current_session);
                    break;
                case GlobalData.ADD_OR_UPDATE_PLAYER_EVENT:
                    FileTraceManagment.AddOrUpdatePlayerFromGameLog(line, Current_session);
                    break;
                case GlobalData.GAME_PLAYER_SPAWN_EVENT:
                    FileTraceManagment.SpawnPlayerFromGameLog(line, Current_session);
                    break;
                case GlobalData.HOST_NAME_ASSIGN_EVENT:
                    FileTraceManagment.DedicatedServerConnectEvent(line, Current_session);
                    break;
                case GlobalData.CONNECTION_INIT_EVENT:
                    FileTraceManagment.ConnectionMadeEvent(line, Current_session);
                    break;
                case GlobalData.MATCH_REWARD_EVENT:
                    FileTraceManagment.MatchRewardEvent(line, Current_session);
                    if (Current_session.CurrentMatch.MatchTypeDesc != "")
                        add_last_match(Current_session);
                    break;
                case GlobalData.MATCH_PROPERTY_EVENT:
                    FileTraceManagment.AssignMatchProperty(line, Current_session);
                    break;
                case GlobalData.ADVENTURE_REWARD_EVENT:
                    FileTraceManagment.AssignAdventureRewardEvent(line, Current_session);
                    break;
                case GlobalData.QUEST_EVENT:
                    break;
                case GlobalData.LOOT_EVENT:
                    FileTraceManagment.AssignLootEvent(line, Current_session);
                    break;
                case GlobalData.ASSIGN_CLIENT_VERSION_EVENT:
                    FileTraceManagment.AssignClientVersionEvent(line, Current_session);
                    break;
            }
            FileTraceManagment.UpdatePreviousTime("g", line, Current_session);
            Current_session.PreviousGameEvent = Current_session.CurrentEvent;
        }
        void combat_log_event_handler(string line, FileTraceManagment.SessionStats Current_session)
        {
            FileTraceManagment.AssignCurrentCombatEvent(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "c:" + line));

            FileTraceManagment.UpdateCurrentTime("c", line, Current_session);

            switch (Current_session.CurrentEvent)
            {
                case GlobalData.MATCH_START_EVENT:
                    add_last_match(Current_session);
                    FileTraceManagment.MatchStartEvent(line, Current_session);
                    break;
                case GlobalData.GAME_PLAY_START_EVENT:
                    FileTraceManagment.GameplayStartEvent(line, Current_session);
                    break;
                case GlobalData.LOAD_PLAYER_EVENT:
                    FileTraceManagment.LoadPlayerEvent(line, Current_session);
                    break;
                case GlobalData.SPAWN_PLAYER_EVENT:
                    FileTraceManagment.SpawnPlayerEvent(line, Current_session);
                    break;
                case GlobalData.DAMAGE_EVENT:
                    FileTraceManagment.DamageEvent(line, Current_session);
                    update_garage_view(Current_session);
                    break;
                case GlobalData.STRIPE_EVENT:
                    FileTraceManagment.StripeEvent(line, Current_session);
                    break;
                case GlobalData.KILL_EVENT:
                    FileTraceManagment.KillEvent(line, Current_session);
                    break;
                case GlobalData.ASSIST_EVENT:
                    FileTraceManagment.KillAssistEvent(line, Current_session);
                    break;
                case GlobalData.SCORE_EVENT:
                    FileTraceManagment.ScoreEvent(line, Current_session);
                    break;
                case GlobalData.CW_ROUND_END_EVENT:
                    FileTraceManagment.ClanWarRoundEndEvent(line, Current_session);
                    break;
                case GlobalData.MAIN_MENU_EVENT:
                    FileTraceManagment.MainMenuEvent(line, Current_session);
                    //bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "c:" + line));
                    add_last_match(Current_session);
                    break;
                case GlobalData.TEST_DRIVE_EVENT:
                    FileTraceManagment.TestDriveEvent(line, Current_session);
                    //bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "c:" + line));
                    clear_current_test_drive_data();
                    break;
                case GlobalData.MATCH_END_EVENT:
                    FileTraceManagment.MatchEndEvent(line, Current_session);
                    add_last_match(Current_session);
                    break;
                case GlobalData.ADD_MOB_EVENT:
                    FileTraceManagment.AddMobEvent(line, Current_session);
                    break;
            }
            Overlay.ResolveOverlayAction(Current_session, session, translations);
            FileTraceManagment.UpdatePreviousTime("c", line, Current_session);
            Current_session.PreviousCombatEvent = Current_session.CurrentEvent;
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
            gr.DrawLine(new Pen(session.ForeColor, border_width * 2), new Point(0, 0), new Point(0, bmp.Height));
            gr.DrawLine(new Pen(session.ForeColor, border_width * 2), new Point(0, 0), new Point(bmp.Width, 0));
            gr.DrawLine(new Pen(session.ForeColor, border_width * 2), new Point(0, bmp.Height), new Point(bmp.Width, bmp.Height));
            gr.DrawLine(new Pen(session.ForeColor, border_width * 2), new Point(bmp.Width, 0), new Point(bmp.Width, bmp.Height));

            Clipboard.SetImage((Image)bmp);

            if (session.SaveCaptures)
            {
                try
                {
                    bmp.Save(string.Format(@"{0}\co_driver{1}.png", screenshot_directory, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Png);
                }
                catch (Exception)
                {

                }
            }

            bmp.Dispose();
            gr.Dispose();
        }

        void add_last_match(FileTraceManagment.SessionStats Current_session)
        {
            if (Current_session.LiveTraceData == false)
                return;

            FileTraceManagment.BuildRecord last_build_record = new FileTraceManagment.BuildRecord { };

            if (Current_session.PlayerBuildRecords.ContainsKey(Current_session.CurrentMatch.LocalPlayer.BuildHash))
                last_build_record = Current_session.PlayerBuildRecords[Current_session.CurrentMatch.LocalPlayer.BuildHash];

            bw_file_feed.ReportProgress(GlobalData.MATCH_END_POPULATE_EVENT, file_trace_manager.NewMatchEndResponse(Current_session.CurrentMatch, last_build_record));

            if (session.UploadPostMatch)
            {
                user_profile_page.force_refresh = true;
                build_page.forceRefresh = true;
                match_history_page.force_refresh = true;
                revenue_page.force_refresh = true;
                meta_detail_page.force_refresh = true;
                comparison_page.force_refresh = true;
            }
            populate_user_profile(Current_session);
            populate_match_history(Current_session);
            populate_build_records(Current_session);
        }

        public string get_current_version()
        {
            return GlobalData.CURRENT_VERSION;
        }

        private void load_match_details(object sender, FileTraceManagment.MatchRecord historic_match)
        {
            match_detail_page.historical_match_data = historic_match.MatchData;
            match_detail_page.show_last_match = false;
            match_detail_page.populate_match();
            clear_main_page_panel();
            main_page_panel.Controls.Add(match_detail_page);
        }

        private void load_build_details(object sender, string build_hash)
        {
            build_page.LoadBuildHash(build_hash);
            clear_main_page_panel();
            main_page_panel.Controls.Add(build_page);
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
            main_page_panel.Controls.Add(new TraceView("Combat", session));
            theme_manager.ApplyTheme(main_page_panel, session);
        }

        private void gamelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new TraceView("Game", session));
            theme_manager.ApplyTheme(main_page_panel, session);
        }

        private void chatlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new TraceView("Chat", session));
            theme_manager.ApplyTheme(main_page_panel, session);
        }

        private void netlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new TraceView("Net", session));
            theme_manager.ApplyTheme(main_page_panel, session);
        }

        private void gfxlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new TraceView("Gfx", session));
            theme_manager.ApplyTheme(main_page_panel, session);
        }

        private void buildReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(build_page);
        }

        private void performanceComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(comparison_page);
        }

        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.AllScreens.FirstOrDefault(x => x.DeviceName == session.PrimaryDisplay).Bounds;
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
