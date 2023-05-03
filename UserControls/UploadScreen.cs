using System;
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
        upload_status up_status = new upload_status();

        private class match_set
        {
            public int valid { get; set; }
            public int uploaded { get; set; }

            public match_set()
            {
                valid = 0;
                uploaded = 0;
            }
        }

        private class bw_status_update
        {
            public Upload.Site site { get; set; }
            public int ammount { get; set; }
            public string text_update { get; set; }

            public bw_status_update(Upload.Site s, int a, string text)
            {
                site = s;
                ammount = a;
                text_update = text;
            }
        }

        private class upload_status
        {
            public match_set total { get; set; }
            public match_set crossoutdb { get; set; }
            public match_set xostat { get; set; }
            public upload_status()
            {
                total = new match_set();
                crossoutdb = new match_set();
                xostat = new match_set();
            }

            public void calc_totals()
            {
                total.uploaded = crossoutdb.uploaded + xostat.uploaded;
                total.valid = crossoutdb.valid + xostat.valid;
            }

            public int percent()
            {
                return (int)(((double)crossoutdb.uploaded + (double)xostat.uploaded) / ((double)crossoutdb.valid + (double)xostat.valid));
            }
        }

        public UploadScreen()
        {
            InitializeComponent();
        }

        public void populate_upload_screen()
        {
            if (bw_file_uploader.IsBusy)
                return;

            tb_upload_progress.Clear();
            tb_upload_progress.AppendText(string.Format("Preparing matches for upload to Crossoutdb." + Environment.NewLine + Environment.NewLine));
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();

            Crossout.AspWeb.Models.API.v2.UploadReturn crossoutdb_upload_return = Upload.GetPreviousUploads(session.LocalUserID, Upload.Site.CrossoutDB);
            Crossout.AspWeb.Models.API.v2.UploadReturn xostat_upload_return = Upload.GetPreviousUploads(session.LocalUserID, Upload.Site.XOStat);
            List<Crossout.AspWeb.Models.API.v2.MatchEntry> upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };

            tb_upload_progress.AppendText(string.Format("Found {0} xostat.gg matches previously uploaded." + Environment.NewLine, xostat_upload_return.uploaded_matches.Count));

            up_status = new upload_status();

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (match.MatchData.ServerGUID == 0)
                {
                    continue;
                }

                if (match.MatchData.LocalPlayer.UID == 0)
                {
                    continue;
                }

                if (!match.MatchData.MatchRewards.Any())
                {
                    continue;
                }

                if (match.MatchData.PlayerRecords.Any(x => x.Value.UID == 0 && x.Value.Bot == 0))
                {
                    continue;
                }

                if (match.MatchData.WinningTeam == -1)
                {
                    continue;
                }

                if (match.MatchData.MatchType == GlobalData.TEST_SERVER_MATCH)
                    continue;

                if (match.MatchData.MatchType == GlobalData.CUSTOM_MATCH)
                    continue;

                up_status.crossoutdb.valid += 1;
                up_status.xostat.valid += 1;

                if (crossoutdb_upload_return.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    up_status.crossoutdb.uploaded += 1;

                if (xostat_upload_return.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    up_status.xostat.uploaded += 1;
            }

            up_status.calc_totals();

            tb_upload_progress.AppendText(string.Format("Found {0} total games." + Environment.NewLine, match_history.Count));

            lb_xodb_track.Text = string.Format("{0}/{1}", up_status.crossoutdb.uploaded, up_status.crossoutdb.valid);
            lb_xostat_track.Text = string.Format("{0}/{1}", up_status.xostat.uploaded, up_status.xostat.valid);
            //pb_upload_bar.Value = up_status.percent();

            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matches, Press <Upload> when ready" + Environment.NewLine, up_status.total.valid - up_status.total.uploaded);
        }

        public void btn_upload_matchs_Click(object sender, EventArgs e)
        {
            if (bw_file_uploader.IsBusy)
                return;

            up_status.calc_totals();
            tb_upload_progress.AppendText(string.Format("Starting background worker to upload. Feel free to use other screens during upload." + Environment.NewLine));
            //pb_upload_bar.Value = up_status.percent();
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent;
            pb_upload.Refresh();

            bw_file_uploader.RunWorkerAsync();
        }

        private void upload_files(object sender, DoWorkEventArgs e)
        {
            if (bw_file_uploader.CancellationPending)
                return;

            //bw_file_uploader.ReportProgress(0, new bw_status_update(Upload.Site.ALL, 0, "Starting Upload to CrossoutDB.com"));
            //upload_site(Upload.Site.CrossoutDB);

            bw_file_uploader.ReportProgress(0, new bw_status_update(Upload.Site.ALL, 0, "Starting Upload to XOStat.gg"));
            upload_matches_to_site_in_batches(Upload.Site.XOStat);

            bw_file_uploader.ReportProgress(0, new bw_status_update(Upload.Site.ALL, 0, "Upload Finished"));
        }

        private void upload_matches_to_site_in_batches(Upload.Site site)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn previous_uploads = Upload.GetPreviousUploads(session.LocalUserID, site);
            List<long> uploaded_matches = previous_uploads.uploaded_matches.ToList();
            List<string> uploaded_builds = new List<string> { };
            Crossout.AspWeb.Models.API.v2.UploadEntry batch = Upload.BuildNextBatchForUpload(site, session, match_history, build_records, translations, ref uploaded_matches, ref uploaded_builds);

            while (batch.match_list.Count > 0)
            {
                if (bw_file_uploader.CancellationPending)
                    return;

                Crossout.AspWeb.Models.API.v2.UploadReturn upload = Upload.UploadToSite(batch, site);

                bw_file_uploader.ReportProgress(0, new bw_status_update(site, batch.match_list.Count, string.Format("Uploaded {0} matches to {0}", batch.match_list.Count, site == Upload.Site.XOStat ? "XOStat.gg" : "CrossoutDB.com")));

                batch = Upload.BuildNextBatchForUpload(site, session, match_history, build_records, translations, ref uploaded_matches, ref uploaded_builds);
            }
        }

        private void report_upload_status(object sender, ProgressChangedEventArgs e)
        {
            bw_status_update s = e.UserState as bw_status_update;

            if (s.site == Upload.Site.CrossoutDB)
                up_status.crossoutdb.uploaded += s.ammount;

            if (s.site == Upload.Site.XOStat)
                up_status.xostat.uploaded += s.ammount;

            up_status.calc_totals();
            //pb_upload_bar.Value = up_status.percent();

            lb_xodb_track.Text = string.Format("{0}/{1}", up_status.crossoutdb.uploaded, up_status.crossoutdb.valid);
            lb_xostat_track.Text = string.Format("{0}/{1}", up_status.xostat.uploaded, up_status.xostat.valid);

            tb_upload_progress.AppendText(s.text_update + Environment.NewLine);
            lb_upload_status_text.Text = string.Format(s.text_update);
        }

        private void finished_uploading(object sender, RunWorkerCompletedEventArgs e)
        {
            tb_upload_progress.AppendText("Finished uploading." + Environment.NewLine);
            //pb_upload_bar.Value = 100;
            lb_upload_status_text.Text = string.Format("Standing by to upload matches, Press <Upload> when ready" + Environment.NewLine);
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();
        }

        private void btn_upload_cancel_click(object sender, EventArgs e)
        {
            if (!bw_file_uploader.IsBusy)
                return;

            bw_file_uploader.CancelAsync();
            lb_upload_status_text.Text = string.Format("Standing by to upload matches, Press <Upload> when ready" + Environment.NewLine);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
