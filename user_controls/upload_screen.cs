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
using System.Reflection;

namespace CO_Driver
{
    public partial class upload_screen : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        

        private class bw_status_update
        {
            public int percent_upload { get; set; }
            public int matchs_uploaded { get; set; }
            public int builds_uploaded { get; set; }
            public string text_update { get; set; }

        }

        int valid_matchs = 0;
        int match_corruptions = 0;
        int invalid_uid = 0;
        int incomplete_matchs = 0;
        int ready_to_upload = 0;
        int matchs_uploaded = 0;
        int builds_uploaded = 0;

        public upload_screen()
        {
            InitializeComponent();
        }

        public void populate_upload_screen()
        {
            if (bw_file_uploader.IsBusy)
                return;

            valid_matchs = 0;
            match_corruptions = 0;
            invalid_uid = 0;
            incomplete_matchs = 0;
            matchs_uploaded = 0;
            builds_uploaded = 0;

            tb_upload_progress.Clear();
            tb_upload_progress.AppendText(string.Format("Preparing matchs for upload to Crossoutdb." + Environment.NewLine + Environment.NewLine));
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();

            if (!session.upload_data)
            {
                lb_ready_to_upload.Text = ready_to_upload.ToString();
                lb_uploaded_matchs.Text = matchs_uploaded.ToString();
                lb_uploaded_builds.Text = builds_uploaded.ToString();
                lb_valid_matchs.Text = valid_matchs.ToString();
                tb_upload_progress.AppendText(string.Format("Uploading to crossoutdb.com has been disabled. Please enable in settings." + Environment.NewLine + Environment.NewLine));
                pb_upload_bar.Value = 100;
                return;
            }

            List<Crossout.AspWeb.Models.API.v2.MatchEntry> upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
            List<long> previous_matchs = Upload.get_previously_uploaded_match_list(session.local_user_uid);

            matchs_uploaded = previous_matchs.Count;

            tb_upload_progress.AppendText(string.Format("Found {0} previously uploaded matchs." + Environment.NewLine, matchs_uploaded));

            foreach (file_trace_managment.MatchRecord match in match_history.ToList())
            {
                if (match.match_data.server_guid == 0)
                {
                    match_corruptions += 1;
                    continue;
                }

                if (match.match_data.local_player.uid == 0)
                {
                    invalid_uid += 1;
                    continue;
                }


                if (!match.match_data.match_rewards.Any())
                {
                    match_corruptions += 1;
                    continue;
                }

                if (match.match_data.winning_team == -1)
                {
                    incomplete_matchs += 1;
                    continue;
                }

                valid_matchs += 1;

                if (previous_matchs.Contains(match.match_data.server_guid))
                    continue;

                ready_to_upload += 1;   
            }

            tb_upload_progress.AppendText(string.Format("Found {0} total games." + Environment.NewLine, match_history.Count));
            tb_upload_progress.AppendText(string.Format("Found {0} games with game.log corruptions." + Environment.NewLine, match_corruptions));
            tb_upload_progress.AppendText(string.Format("Found {0} games with incomplete uploader uid (including spectator matchs)." + Environment.NewLine, invalid_uid));
            tb_upload_progress.AppendText(string.Format("Found {0} incomplete games." + Environment.NewLine, incomplete_matchs));
            tb_upload_progress.AppendText(string.Format("Found {0} valid matchs for upload." + Environment.NewLine, valid_matchs));
            tb_upload_progress.AppendText(string.Format("Found {0} games ready to upload." + Environment.NewLine + Environment.NewLine, ready_to_upload));

            lb_ready_to_upload.Text = ready_to_upload.ToString();
            lb_uploaded_matchs.Text = matchs_uploaded.ToString();
            lb_uploaded_builds.Text = builds_uploaded.ToString();
            lb_valid_matchs.Text = valid_matchs.ToString();
            pb_upload_bar.Value = 100;

            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matchs, Press <Upload> when ready" + Environment.NewLine, ready_to_upload);
        }

        private void btn_upload_matchs_Click(object sender, EventArgs e)
        {
            if (bw_file_uploader.IsBusy)
                return;

            tb_upload_progress.AppendText(string.Format("Starting background worker to upload. Feel free to use other screens during upload." + Environment.NewLine));
            pb_upload_bar.Value = (int)(((double)matchs_uploaded / (double)valid_matchs) * 100) > 100 ? 100 : (int)(((double)ready_to_upload / (double)valid_matchs) * 100);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent;
            pb_upload.Refresh();

            bw_file_uploader.RunWorkerAsync();
        }

        private void upload_files(object sender, DoWorkEventArgs e)
        {
            if (bw_file_uploader.CancellationPending)
                return;

            bw_status_update status = new bw_status_update { };

            List<Crossout.AspWeb.Models.API.v2.MatchEntry> upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
            List<long> previous_matchs = new List<long> { };
            DateTime min_upload_date = DateTime.MaxValue;
            DateTime max_upload_date = DateTime.MinValue;
            int percent_upload = 0;
            int upload_matchs = 0;

            upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
            previous_matchs = Upload.get_previously_uploaded_match_list(session.local_user_uid);

            foreach (file_trace_managment.MatchRecord match in match_history.ToList())
            {
                if (bw_file_uploader.CancellationPending)
                    return;

                if (previous_matchs.Contains(match.match_data.server_guid))
                    continue;

                if (match.match_data.server_guid == 0)
                    continue;

                if (match.match_data.local_player.uid == 0)
                    continue;

                if (!match.match_data.match_rewards.Any())
                    continue;

                if (match.match_data.winning_team == -1)
                    continue;

                if (match.match_data.match_start < min_upload_date)
                    min_upload_date = match.match_data.match_start;

                if (match.match_data.match_end > max_upload_date)
                    max_upload_date = match.match_data.match_end;

                upload_list.Add(Upload.populate_match_entry(match));

                if (upload_list.Count >= 50)
                {
                    percent_upload = (int)(((double)(upload_matchs) / (double)valid_matchs) * 100);
                    status.text_update = string.Format("Uploading {0} matchs from {1} to {2}." + Environment.NewLine, upload_list.Count, min_upload_date, max_upload_date);
                    status.percent_upload = percent_upload;
                    status.matchs_uploaded = upload_matchs;
                    bw_file_uploader.ReportProgress(0, status);

                    upload_matchs = Upload.upload_match_list_to_crossoutdb(upload_list);

                    if (upload_matchs == -1)
                    {
                        bw_file_uploader.CancelAsync();
                        return;
                    }

                    min_upload_date = DateTime.MaxValue;
                    max_upload_date = DateTime.MinValue;
                    upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
                }
            }

            status.text_update = string.Format("Uploading {0} matchs from {1} to {2}." + Environment.NewLine, upload_list.Count, min_upload_date, max_upload_date);
            status.percent_upload = percent_upload;
            bw_file_uploader.ReportProgress(0, status);

            upload_matchs = Upload.upload_match_list_to_crossoutdb(upload_list);

            if (upload_matchs == -1)
            {
                bw_file_uploader.CancelAsync();
                return;
            }

            percent_upload = (int)(((double)(valid_matchs - upload_matchs) / (double)valid_matchs) * 100);
            status.text_update = string.Format("Finished upload of {0} from {1} to {2}." + Environment.NewLine, upload_list.Count, min_upload_date, max_upload_date);
            status.percent_upload = percent_upload;
            status.matchs_uploaded = upload_matchs;
            bw_file_uploader.ReportProgress(0, status);
        }

        private void report_upload_status(object sender, ProgressChangedEventArgs e)
        {
            bw_status_update status = e.UserState as bw_status_update;
            pb_upload_bar.Value = status.percent_upload > 100 ? 100 : status.percent_upload;
            if (status.matchs_uploaded > Convert.ToInt32(lb_uploaded_matchs.Text))
                lb_uploaded_matchs.Text = status.matchs_uploaded.ToString();
            lb_ready_to_upload.Text = (valid_matchs - status.matchs_uploaded).ToString();
            tb_upload_progress.AppendText(status.text_update);
            lb_upload_status_text.Text = string.Format(status.text_update);
        }

        private void finished_uploading(object sender, RunWorkerCompletedEventArgs e)
        {
            tb_upload_progress.AppendText("Finished uploading." + Environment.NewLine);
            pb_upload_bar.Value = 100;
            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matchs, Press <Upload> when ready" + Environment.NewLine, lb_ready_to_upload.Text);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();
        }

        private void btn_upload_cancel_click(object sender, EventArgs e)
        {
            if (!bw_file_uploader.IsBusy)
                return;

            bw_file_uploader.CancelAsync();
            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matchs, Press <Upload> when ready" + Environment.NewLine, lb_ready_to_upload.Text);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();
        }
    }
}
