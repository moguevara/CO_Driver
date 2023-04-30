﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class UploadScreen : UserControl
    {
        public List<FileTraceManagment.MatchRecord> match_history = new List<FileTraceManagment.MatchRecord> { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

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
        int ready_to_upload_matchs = 0;
        int ready_to_upload_builds = 0;
        int matchs_uploaded = 0;
        int valid_builds = 0;
        int invalid_builds = 0;
        int builds_uploaded = 0;

        public UploadScreen()
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
            tb_upload_progress.AppendText(string.Format("Preparing matches for upload to Crossoutdb." + Environment.NewLine + Environment.NewLine));
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();

            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = Upload.GetPreviousUploads(session.LocalUserID);
            List<Crossout.AspWeb.Models.API.v2.MatchEntry> upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
            matchs_uploaded = upload_return.uploaded_matches.Count;
            builds_uploaded = upload_return.uploaded_builds;

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (match.MatchData.ServerGUID == 0)
                {
                    match_corruptions += 1;
                    continue;
                }

                if (match.MatchData.LocalPlayer.UID == 0)
                {
                    invalid_uid += 1;
                    continue;
                }

                if (!match.MatchData.MatchRewards.Any())
                {
                    match_corruptions += 1;
                    continue;
                }

                if (match.MatchData.PlayerRecords.Any(x => x.Value.UID == 0 && x.Value.Bot == 0))
                {
                    incomplete_matchs += 1;
                    continue;
                }

                if (match.MatchData.WinningTeam == -1)
                {
                    incomplete_matchs += 1;
                    continue;
                }

                if (match.MatchData.MatchType == GlobalData.TEST_SERVER_MATCH)
                    continue;

                if (match.MatchData.MatchType == GlobalData.CUSTOM_MATCH)
                    continue;

                valid_matchs += 1;

                if (upload_return.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    continue;

                ready_to_upload_matchs += 1;
            }

            foreach (KeyValuePair<string, FileTraceManagment.BuildRecord> build in build_records)
            {
                if (build.Value.Parts.Count == 0)
                    continue;

                if (build.Value.PowerScore == 0)
                {
                    invalid_builds += 1;
                    continue;
                }

                valid_builds += 1;
            }

            ready_to_upload_builds = valid_builds - builds_uploaded;

            tb_upload_progress.AppendText(string.Format("Found {0} previously uploaded matches." + Environment.NewLine, matchs_uploaded));
            tb_upload_progress.AppendText(string.Format("Found {0} previously uploaded builds." + Environment.NewLine, builds_uploaded));
            tb_upload_progress.AppendText(string.Format("Found {0} total games." + Environment.NewLine, match_history.Count));
            tb_upload_progress.AppendText(string.Format("Found {0} games with game.log corruptions." + Environment.NewLine, match_corruptions));
            tb_upload_progress.AppendText(string.Format("Found {0} games with incomplete uploader uid (including spectator matches)." + Environment.NewLine, invalid_uid));
            tb_upload_progress.AppendText(string.Format("Found {0} incomplete games." + Environment.NewLine, incomplete_matchs));
            tb_upload_progress.AppendText(string.Format("Found {0} valid matches for upload." + Environment.NewLine, valid_matchs));
            tb_upload_progress.AppendText(string.Format("Found {0} games ready to upload." + Environment.NewLine, ready_to_upload_matchs));
            tb_upload_progress.AppendText(string.Format("Found {0} builds with incomplete properties." + Environment.NewLine, invalid_builds));
            tb_upload_progress.AppendText(string.Format("Found {0} valid builds for upload." + Environment.NewLine, valid_builds));
            tb_upload_progress.AppendText(string.Format("Found {0} builds ready to upload." + Environment.NewLine + Environment.NewLine, ready_to_upload_builds));

            lb_ready_to_upload.Text = ready_to_upload_matchs.ToString();
            lb_uploaded_matchs.Text = matchs_uploaded.ToString();
            lb_uploaded_builds.Text = builds_uploaded.ToString();
            lb_valid_matchs.Text = valid_matchs.ToString();
            pb_upload_bar.Value = 100;

            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matches, Press <Upload> when ready" + Environment.NewLine, ready_to_upload_matchs);
        }

        public void btn_upload_matchs_Click(object sender, EventArgs e)
        {
            if (bw_file_uploader.IsBusy)
                return;

            int percent_uploaded = (int)(((double)matchs_uploaded / (double)valid_matchs) * 100);
            if (percent_uploaded > 100)
                percent_uploaded = 100;

            if (percent_uploaded < 0)
                percent_uploaded = 0;

            tb_upload_progress.AppendText(string.Format("Starting background worker to upload. Feel free to use other screens during upload." + Environment.NewLine));
            pb_upload_bar.Value = percent_uploaded;
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent;
            pb_upload.Refresh();

            bw_file_uploader.RunWorkerAsync();
        }

        private void upload_files(object sender, DoWorkEventArgs e)
        {
            if (bw_file_uploader.CancellationPending)
                return;

            bw_status_update status = new bw_status_update { };
            List<string> uploaded_builds = new List<string> { };

            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = Upload.GetPreviousUploads(session.LocalUserID);
            Crossout.AspWeb.Models.API.v2.UploadEntry upload_entry = new Crossout.AspWeb.Models.API.v2.UploadEntry { uploader_uid = session.LocalUserID, match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { }, build_list = new List<Crossout.AspWeb.Models.API.v2.BuildEntry> { } };
            Crossout.AspWeb.Models.API.v2.BuildEntry build_entry = new Crossout.AspWeb.Models.API.v2.BuildEntry { };
            upload_entry.uploader_uid = session.LocalUserID;
            upload_entry.match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
            upload_entry.build_list = new List<Crossout.AspWeb.Models.API.v2.BuildEntry> { };

            DateTime min_upload_date = DateTime.MaxValue;
            DateTime max_upload_date = DateTime.MinValue;
            int percent_upload = 0;

            upload_return = Upload.UploadToCrossoutDB(upload_entry);
            upload_entry = new Crossout.AspWeb.Models.API.v2.UploadEntry { uploader_uid = session.LocalUserID, match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { }, build_list = new List<Crossout.AspWeb.Models.API.v2.BuildEntry> { } };

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (bw_file_uploader.CancellationPending)
                    return;

                if (upload_return.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    continue;

                if (match.MatchData.ServerGUID == 0)
                    continue;

                if (match.MatchData.LocalPlayer.UID == 0)
                    continue;

                if (match.MatchData.PlayerRecords.Any(x => x.Value.UID == 0 && x.Value.Bot == 0))
                    continue;

                if (!match.MatchData.MatchRewards.Any())
                    continue;

                if (match.MatchData.WinningTeam == -1)
                    continue;

                if (match.MatchData.MatchType == GlobalData.TEST_SERVER_MATCH)
                    continue;

                if (match.MatchData.MatchType == GlobalData.CUSTOM_MATCH)
                    continue;

                if (match.MatchData.MatchStart < min_upload_date)
                    min_upload_date = match.MatchData.MatchStart;

                if (match.MatchData.MatchEnd > max_upload_date)
                    max_upload_date = match.MatchData.MatchEnd;

                foreach (FileTraceManagment.RoundRecord round in match.MatchData.RoundRecords)
                {
                    foreach (FileTraceManagment.Player player in round.Players)
                    {
                        if (bw_file_uploader.CancellationPending)
                            return;

                        if (!build_records.ContainsKey(player.BuildHash))
                            continue;

                        if (build_records[player.BuildHash].Parts.Count == 0)
                            continue;

                        if (build_records[player.BuildHash].PowerScore == 0)
                            continue;

                        if (uploaded_builds.Contains(player.BuildHash))
                            continue;

                        uploaded_builds.Add(player.BuildHash);
                        upload_entry.build_list.Add(Upload.PopulateBuildEntry(build_records[player.BuildHash]));
                    }
                }
                upload_entry.match_list.Add(Upload.PopulateMatchEntry(match, translations));

                if (upload_entry.match_list.Count >= GlobalData.UPLOAD_LIST_SIZE)
                {
                    percent_upload = percent_upload = get_percent_upload(upload_return.uploaded_matches.Count);
                    status.text_update = string.Format("Uploading {0} matches from {1} to {2}." + Environment.NewLine, upload_entry.match_list.Count, min_upload_date, max_upload_date);
                    status.text_update += string.Format("Uploading {0} builds." + Environment.NewLine, upload_entry.build_list.Count);
                    status.percent_upload = percent_upload;
                    status.matchs_uploaded = upload_return.uploaded_matches.Count;
                    status.builds_uploaded = upload_return.uploaded_builds;
                    bw_file_uploader.ReportProgress(0, status);

                    upload_return = Upload.UploadToCrossoutDB(upload_entry);
                    min_upload_date = DateTime.MaxValue;
                    max_upload_date = DateTime.MinValue;
                    upload_entry = new Crossout.AspWeb.Models.API.v2.UploadEntry { uploader_uid = session.LocalUserID, match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { }, build_list = new List<Crossout.AspWeb.Models.API.v2.BuildEntry> { } };
                }
            }

            status.text_update = string.Format("Uploading {0} matches from {1} to {2}." + Environment.NewLine, upload_entry.match_list.Count, min_upload_date, max_upload_date);
            status.percent_upload = percent_upload;
            status.matchs_uploaded = upload_return.uploaded_matches.Count;
            status.builds_uploaded = upload_return.uploaded_builds;
            bw_file_uploader.ReportProgress(0, status);

            upload_return = Upload.UploadToCrossoutDB(upload_entry);

            percent_upload = get_percent_upload(upload_return.uploaded_matches.Count);
            status.text_update = string.Format("Finished upload of {0} from {1} to {2}." + Environment.NewLine, upload_entry.match_list.Count, min_upload_date, max_upload_date);
            status.percent_upload = percent_upload;
            status.matchs_uploaded = upload_return.uploaded_matches.Count;
            status.builds_uploaded = upload_return.uploaded_builds;
            bw_file_uploader.ReportProgress(0, status);
        }


        private int get_percent_upload(int uploaded_matches)
        {
            return (int)(((double)(uploaded_matches) / (double)valid_matchs) * 100);
        }

        private void report_upload_status(object sender, ProgressChangedEventArgs e)
        {
            bw_status_update status = e.UserState as bw_status_update;

            int percent_uploaded = status.percent_upload;

            if (percent_uploaded > 100)
                percent_uploaded = 100;

            if (percent_uploaded < 0)
                percent_uploaded = 0;

            pb_upload_bar.Value = percent_uploaded;
            if (status.matchs_uploaded > 0)
                lb_uploaded_matchs.Text = status.matchs_uploaded.ToString();
            if (status.builds_uploaded > 0)
                lb_uploaded_builds.Text = status.builds_uploaded.ToString();
            lb_ready_to_upload.Text = (valid_matchs - status.matchs_uploaded).ToString();
            tb_upload_progress.AppendText(status.text_update);
            lb_upload_status_text.Text = string.Format(status.text_update);
        }

        private void finished_uploading(object sender, RunWorkerCompletedEventArgs e)
        {
            tb_upload_progress.AppendText("Finished uploading." + Environment.NewLine);
            pb_upload_bar.Value = 100;
            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matches, Press <Upload> when ready" + Environment.NewLine, lb_ready_to_upload.Text);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();
        }

        private void btn_upload_cancel_click(object sender, EventArgs e)
        {
            if (!bw_file_uploader.IsBusy)
                return;

            bw_file_uploader.CancelAsync();
            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matches, Press <Upload> when ready" + Environment.NewLine, lb_ready_to_upload.Text);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + session.LocalUserID.ToString());
        }

        private void btn_view_profile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + session.LocalUserID.ToString());
        }

        private void upload_screen_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void upload_screen_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}
