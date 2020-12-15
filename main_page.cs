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
using CO_Driver.Properties;
using System.Threading;

namespace CO_Driver
{
    public partial class frm_main_page : Form
    {
        log_file_managment log_file_manager = new log_file_managment();
        file_trace_managment file_trace_manager = new file_trace_managment();
        welcome_page welcome_screen = new welcome_page();
        user_profile user_profile_page = new user_profile();
        match_history match_history_page = new match_history();
        schedule_display schedule_page = new schedule_display();
        build_view build_page = new build_view();
        part_optimizer part_page = new part_optimizer();
        part_view avail_part_page = new part_view();

        public frm_main_page()
        {
            InitializeComponent();
        }
        private void CO_Driver_load(object sender, EventArgs e)
        {

            this.welcome_screen.tb_progress_tracking.AppendText("Starting RFB Tool Suite." + Environment.NewLine);
            this.welcome_screen.tb_progress_tracking.AppendText("Loading session variables." + Environment.NewLine);
            log_file_manager.find_log_file_path();
            log_file_manager.find_historic_file_path();
            log_file_manager.find_local_user_name();
            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found local user_name ""{0}""" + Environment.NewLine, Settings.Default["local_user_name"].ToString()));
            this.welcome_screen.tb_progress_tracking.AppendText("Loading parts for optimizer." + Environment.NewLine);
            log_file_manager.copy_historic_files();
            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Copying local files to ""{0}""" + Environment.NewLine, Settings.Default["historic_file_location"].ToString()));
            log_file_manager.get_live_file_location();
            this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Found live combat file to ""{0}""" + Environment.NewLine, Settings.Default["live_file_location"].ToString()));

            main_page_panel.Controls.Add(welcome_screen);

            this.Text = string.Format(@"CO-Driver v{0}", global_data.CURRENT_VERSION);
            System.Threading.Thread.Sleep(1000);
            bw_file_feed.RunWorkerAsync();
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
            main_page_panel.Controls.Add(new user_settings());
        }

        private void clear_main_page_panel()
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
            main_page_panel.Controls.Add(new fusion_calculator());
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
            main_page_panel.Controls.Add(new trace_view("Combat"));
        }

        private void gamelogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Game"));
        }

        private void chatlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Chat"));
        }

        private void netlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Net"));
        }

        private void gfxlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Gfx"));
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
        private void clanWarScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(schedule_page);
        }
        private void eventScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(schedule_page);
        }
        private void partOptimizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(part_page);
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(build_page);
        }

        private void partViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(avail_part_page);
        }

        private void process_log_files(object sender, DoWorkEventArgs e)
        {
            file_trace_managment.SessionStats Current_session = new file_trace_managment.SessionStats { };
            file_trace_managment ftm = new file_trace_managment();
            ftm.initialize_session_stats(Current_session);
            process_historic_files(ftm, Current_session);
            populate_user_profile(Current_session);
            populate_match_history(Current_session);
            populate_build_records(Current_session);
            populate_part_optimization(Current_session);
            System.Threading.Thread.Sleep(1000); /* WEIRD SHIT IS HAPPENING HERE */
            process_live_files(Settings.Default["live_file_location"].ToString(), ftm, Current_session);
        }
        void unlock_menu_strip()
        {
            bw_file_feed.ReportProgress(global_data.UNLOCK_MENU_BAR_EVENT);
        }
        private void populate_match_history(file_trace_managment.SessionStats Current_session)
        {
            bw_file_feed.ReportProgress(global_data.POPULATE_MATCH_HISTORY_EVENT,
                    file_trace_manager.new_match_history_list(Current_session.match_history));
        }

        private void populate_part_optimization(file_trace_managment.SessionStats Current_session)
        {
            
            bw_file_feed.ReportProgress(global_data.POPULATE_PART_OPT_EVENT,
                    file_trace_manager.new_part_opt_response(Current_session.global_parts_list));
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
                    Current_session.player_records[Current_session.local_user],
                    Current_session.match_history,
                    Current_session.player_build_records));
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
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating User Profile" + Environment.NewLine));
                file_trace_managment.UserProfileResponse response = (file_trace_managment.UserProfileResponse)e.UserState;
                this.user_profile_page.local_player_data = response.local_player_record;
                this.user_profile_page.match_history_data = response.match_history;
                this.user_profile_page.local_player_build_data = response.build_records;
                this.user_profile_page.populate_user_profile_screen(file_trace_manager);
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_MATCH_HISTORY_EVENT)
            {
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Match History" + Environment.NewLine));
                this.match_history_page.history_data = (file_trace_managment.MatchHistoryResponse)e.UserState;
                this.match_history_page.refersh_history_table(file_trace_manager);
            }
            else
            if (e.ProgressPercentage == global_data.MATCH_END_POPULATE_EVENT)
            {
                file_trace_managment.MatchEndResponse response = (file_trace_managment.MatchEndResponse)e.UserState;

                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Adding match from current session at {0}" + Environment.NewLine, response.last_match.start_time));

                this.match_history_page.last_match_data = response.last_match;
                this.match_history_page.add_last_match_to_table(file_trace_manager);
            }
            else 
            if (e.ProgressPercentage == global_data.BUILD_POPULATE_EVENT)
            {
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"Populating Build Records" + Environment.NewLine));
                file_trace_managment.BuildRecordResponse response = (file_trace_managment.BuildRecordResponse)e.UserState;
                this.build_page.build_records = response.build_records;
                this.build_page.populate_build_record_table();
            }
            else
            if (e.ProgressPercentage == global_data.POPULATE_PART_OPT_EVENT)
            {
                file_trace_managment.PartOptResponse response = (file_trace_managment.PartOptResponse)e.UserState;
                this.part_page.master_part_list = response.master_list;
                this.avail_part_page.master_part_list = response.master_list;
                this.part_page.refresh_avail_parts();
                this.avail_part_page.populate_parts_list();
            }
            else 
            if (e.ProgressPercentage == global_data.DEBUG_GIVE_LINE_UPDATE_EVENT)
            {
                file_trace_managment.DebugResponse response = (file_trace_managment.DebugResponse)e.UserState;
                this.welcome_screen.tb_progress_tracking.AppendText(string.Format(@"{0}:{1}" + Environment.NewLine, response.event_type, response.line));
            }
        }

        private void process_historic_files(file_trace_managment ftm, file_trace_managment.SessionStats Current_session)
        {
            int file_count = Current_session.file_data.historic_file_list.Count();
            int current_progress = 0;

            foreach (file_trace_managment.LogFile file in Current_session.file_data.historic_file_list)
            {
                Current_session.file_data.processing_session_file = file.log_file;
                Current_session.file_data.processing_session_file_day = file.log_file.CreationTime;
                if (file.log_file.Name.Contains("combat") && File.Exists(file.log_file.FullName))
                {
                    bw_file_feed.ReportProgress(global_data.TRACE_EVENT_FILE_COMPLETE, ftm.new_worker_response((double)current_progress / (double)file_count, string.Format(@"Processing File ""{0}"" ({1:N2}%)", file.log_file.FullName, (((double)current_progress * 100) / (double)file_count))));
                    string[] lines = File.ReadAllLines(file.log_file.FullName);

                    foreach (string line in lines)
                    {
                        if (line != null)
                            log_event_handler(line, Current_session);
                    }
                    current_progress++;
                    file.processed = true;
                    lines = Array.Empty<string>();
                }
            }
        }

        private void process_live_files(string trace_file_path, file_trace_managment ftm, file_trace_managment.SessionStats Current_session)
        {
            FileInfo trace_file = new FileInfo(trace_file_path);
            Current_session.live_trace_data = true;
            Current_session.file_data.processing_session_file = trace_file;

            AutoResetEvent wh = new AutoResetEvent(false);
            FileSystemWatcher fsw = new FileSystemWatcher(".");
            fsw.Filter = trace_file.FullName;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();
            long start_time = DateTime.Now.Ticks;
            bool found_new_file = false;
            FileInfo most_recent_trace_file = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            bool first = true;

            FileStream fs = new FileStream(trace_file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (found_new_file == false)
                {
                    string line = "";
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        log_event_handler(line, Current_session);
                        start_time = DateTime.Now.Ticks;
                    }
                    else
                    {
                        if (first == true)
                        {
                            first = false;
                            unlock_menu_strip();
                        }

                        if (new TimeSpan(DateTime.Now.Ticks - start_time).TotalSeconds > 30)
                        {
                            most_recent_trace_file = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles("combat.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
                            if (trace_file.FullName != most_recent_trace_file.FullName)
                            {
                                found_new_file = true;
                            }
                            start_time = DateTime.Now.Ticks;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            fs.Dispose();
            fsw.Dispose();
            wh.Dispose();

            process_live_files(most_recent_trace_file.FullName, ftm, Current_session);
        }

        void log_event_handler(string line, file_trace_managment.SessionStats Current_session)
        {
            file_trace_managment.assign_current_event(line, Current_session);
            //if (Current_session.live_trace_data == true)
            //    bw_file_feed.ReportProgress(global_data.DEBUG_GIVE_LINE_UPDATE_EVENT, file_trace_manager.new_debug_response(Current_session.current_event, line));
            switch (Current_session.current_event)
            {
                case global_data.MATCH_START_EVENT:
                    file_trace_managment.match_start_event(line, Current_session);
                    if (Current_session.live_trace_data == true && Current_session.add_match_to_record == true)
                        bw_file_feed.ReportProgress(global_data.MATCH_END_POPULATE_EVENT, file_trace_manager.new_match_end_response(Current_session.match_history[Current_session.match_history.Count() - 1]));
                    break;
                case global_data.LOAD_PLAYER_EVENT:
                    
                    file_trace_managment.load_player_event(line, Current_session);
                    break;
                case global_data.DAMAGE_EVENT:
                    file_trace_managment.damage_event(line, Current_session);
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
                case global_data.MATCH_END_EVENT:
                    file_trace_managment.match_end_event(line, Current_session);
                    if (Current_session.live_trace_data == true && Current_session.add_match_to_record == true)
                        bw_file_feed.ReportProgress(global_data.MATCH_END_POPULATE_EVENT, file_trace_manager.new_match_end_response(Current_session.match_history[Current_session.match_history.Count() - 1]));
                    break;
            }
        }

        private void matchAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
