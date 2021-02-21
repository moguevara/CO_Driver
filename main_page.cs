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

namespace CO_Driver
{
    public partial class frm_main_page : Form
    {
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };

        public log_file_managment log_file_manager = new log_file_managment();
        public file_trace_managment file_trace_manager = new file_trace_managment();
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

        public frm_main_page()
        {
            InitializeComponent();
        }
        private void CO_Driver_load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");


            this.welcome_screen.tb_progress_tracking.AppendText("Starting RFB Tool Suite." + Environment.NewLine);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading session variables." + Environment.NewLine);

            load_user_settings();

            if (session.local_user_name == null)
            {
                MessageBox.Show("An error has occured while loading, please try restarting CO_Driver. If the problem persists please report to https://discord.gg/kKcnVXu2Xe. Thanks.");
                Application.Exit();
            }

            welcome_screen.session = session;
            part_page.session = session;
            avail_part_page.session = session;
            settings_page.session = session;
            about_page.session = session;

            match_history_page.load_selected_match += new EventHandler<file_trace_managment.MatchRecord>(load_match_details);

            garage_page.initialize_live_feed();
            main_page_panel.Controls.Add(welcome_screen);

            this.Text = string.Format(@"CO-Driver v{0}", get_current_version());

            try
            {
                bw_file_feed.RunWorkerAsync(argument: session);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Background worker failed:" + ex.Message + Environment.NewLine + ex.InnerException);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_user_profile_Click(object sender, EventArgs e)
        {

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

        private void chatToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inMatchDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void viewTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Combat", session));
        }

        private void gamelogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Game", session));
        }

        private void chatlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Chat", session));
        }

        private void netlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Net", session));
        }

        private void gfxlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Gfx", session));
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

        private void matchAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(build_page);
        }

        private void previousMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            match_detail_page.show_last_match = true;
            match_detail_page.populate_match();
            clear_main_page_panel();
            main_page_panel.Controls.Add(match_detail_page);
        }

        private void printCurrentWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capture_screen_shot();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(schedule_page);
        }

        private void garageToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(garage_page);
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
            process_historic_files(ftm, Current_session);
            populate_static_elements(Current_session);
            populate_user_profile(Current_session);
            populate_match_history(Current_session);
            populate_build_records(Current_session);
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
                this.welcome_screen.pb_welcome_file_load.Value = (int)(response.historic_percent_processed * 100);
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
                user_profile_page.populate_user_profile_screen();
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_MATCH_HISTORY_EVENT)
            {
                //this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Match History" + Environment.NewLine));
                file_trace_managment.MatchHistoryResponse response = (file_trace_managment.MatchHistoryResponse)e.UserState;
                match_history_page.history = response.match_history;
                build_page.match_history = response;
                match_history_page.refersh_history_table();
                build_page.populate_build_record_table();
                //match_detail_page.populate_match();
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

        private void process_historic_files(file_trace_managment ftm, file_trace_managment.SessionStats Current_session)
        {
            int file_count = Current_session.file_data.historic_file_session_list.Count();
            int current_progress = 0;

            foreach (file_trace_managment.LogSession session in Current_session.file_data.historic_file_session_list)
            {
                if (!File.Exists(session.combat_log.FullName))
                    continue;

                if (!File.Exists(session.game_log.FullName))
                    continue;

                Current_session.file_data.processing_combat_session_file = session.combat_log;
                Current_session.file_data.processing_game_session_file = session.game_log;
                Current_session.file_data.processing_combat_session_file_day = DateTime.ParseExact(session.combat_log.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);

                //MessageBox.Show(string.Format(@"current file {0}, start day {1}", session.combat_log.Name, Current_session.file_data.processing_combat_session_file_day));

                bw_file_feed.ReportProgress(global_data.TRACE_EVENT_FILE_COMPLETE, ftm.new_worker_response((double)current_progress / (double)file_count, string.Format(@"Processing log files from {0,-19:MM-dd-yyyy hh:mm tt} ({1:N2}%)", DateTime.ParseExact(session.combat_log.Name.Substring(7, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture), (((double)current_progress * 100) / (double)file_count))));

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
                            while (combat_line != null && combat_line.Length == 0)
                                combat_line = combat_reader.ReadLine();

                            while (game_line != null && (game_line.Length == 0 || game_line.Substring(0, 9) == "--- Date:"))
                                game_line = game_reader.ReadLine();

                            if (combat_line != null && game_line != null)
                            {
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

                current_progress++;
                session.processed = true;
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
                    if (combat_line != null && combat_line.Length == 0)
                    {
                        combat_line = combat_reader.ReadLine();
                    }
                    else
                    if (game_line != null && game_line.Length == 0)
                    {
                        game_line = game_reader.ReadLine();
                    }
                    else
                    if (game_line != null && game_line.Substring(0, 9) == "--- Date:")
                    {
                        game_line = game_reader.ReadLine();
                    }
                    else
                    if (combat_line != null && game_line != null)
                    {
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
        switch (Current_session.current_event)
        {
            case global_data.MATCH_REWARD_EVENT:
                file_trace_managment.match_reward_event(line, Current_session);
                add_last_match(Current_session);
                break;
            case global_data.MATCH_PROPERTY_EVENT:
                file_trace_managment.assign_match_property(line, Current_session);
                break;
            case global_data.QUEST_EVENT:
                break;
            case global_data.ASSIGN_CLIENT_VERSION_EVENT:
                file_trace_managment.assign_client_version_event(line, Current_session);
                break;
        }
    }
        void combat_log_event_handler(string line, file_trace_managment.SessionStats Current_session)
        {
            file_trace_managment.assign_current_combat_event(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, "c:"+ Current_session.live_trace_data.ToString() + Current_session.in_match.ToString() + line));
            switch (Current_session.current_event)
            {
                case global_data.MATCH_START_EVENT:
                    add_last_match(Current_session);
                    file_trace_managment.match_start_event(line, Current_session);
                    break;
                case global_data.LOAD_PLAYER_EVENT:
                    file_trace_managment.load_player_event(line, Current_session);
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
            }
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
            gr.DrawLine(new Pen(Brushes.Lime, border_width * 2), new Point(0,         0),          new Point(0,         bmp.Height));
            gr.DrawLine(new Pen(Brushes.Lime, border_width * 2), new Point(0,         0),          new Point(bmp.Width, 0));
            gr.DrawLine(new Pen(Brushes.Lime, border_width * 2), new Point(0,         bmp.Height), new Point(bmp.Width, bmp.Height));
            gr.DrawLine(new Pen(Brushes.Lime, border_width * 2), new Point(bmp.Width, 0),          new Point(bmp.Width, bmp.Height));

            Clipboard.SetImage((Image)bmp);

            try
            {
                bmp.Save(string.Format(@"{0}\co_driver{1}.png", screenshot_directory, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Png);
            }
            catch (Exception ex)
            {

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

            user_profile_page.force_refresh = true;
            populate_user_profile(Current_session);
            populate_match_history(Current_session);
            populate_build_records(Current_session);
        }

        public string get_current_version()
        {
            return global_data.CURRENT_VERSION;
        }

        public void load_user_settings()
        {
            session = log_file_manager.new_session_variables();

            log_file_manager.find_log_file_path(session);
            log_file_manager.find_historic_file_path(session);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading parts for optimizer." + Environment.NewLine);

            log_file_manager.copy_historic_files(session);
            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Copying local files to ""{0}""" + Environment.NewLine, session.historic_file_location));

            log_file_manager.find_local_user_name(session);
            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found local user_name ""{0}""" + Environment.NewLine, session.local_user_name));

            

            log_file_manager.get_live_file_location(session);
            log_file_manager.create_stream_file_location(session);

            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found live combat file to ""{0}""" + Environment.NewLine, session.live_file_location));
        }
        

        private void load_match_details(object sender, file_trace_managment.MatchRecord historic_match)
        {
            match_detail_page.historical_match_data = historic_match.match_data;
            match_detail_page.show_last_match = false;
            match_detail_page.populate_match();
            clear_main_page_panel();
            main_page_panel.Controls.Add(match_detail_page);
        }

        
    }
}
