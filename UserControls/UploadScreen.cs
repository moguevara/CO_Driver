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
        UploadStatus UpStatus = new UploadStatus();

        private class MatchSet
        {
            public int Valid { get; set; }
            public int Uploaded { get; set; }

            public MatchSet()
            {
                Valid = 0;
                Uploaded = 0;
            }
        }

        private class BackgroundWorkerStatusUpdate
        {
            public Upload.Domain Domain { get; set; }
            public int Ammount { get; set; }
            public string TextUpdate { get; set; }

            public BackgroundWorkerStatusUpdate(Upload.Domain d, int a, string text)
            {
                Domain = d;
                Ammount = a;
                TextUpdate = text;
            }
        }

        private class UploadStatus
        {
            public MatchSet Total { get; set; }
            public MatchSet CrossoutDB { get; set; }
            public MatchSet XOStat { get; set; }
            public UploadStatus()
            {
                Total = new MatchSet();
                CrossoutDB = new MatchSet();
                XOStat = new MatchSet();
            }

            public void CalcTotals()
            {
                Total.Uploaded = CrossoutDB.Uploaded + XOStat.Uploaded;
                Total.Valid = CrossoutDB.Valid + XOStat.Valid;
            }

            public int Percent()
            {
                return (int)(((double)CrossoutDB.Uploaded + (double)XOStat.Uploaded) / ((double)CrossoutDB.Valid + (double)XOStat.Valid));
            }
        }

        public UploadScreen()
        {
            InitializeComponent();
        }

        public void PopulateUploadScreen()
        {
            if (bw_file_uploader.IsBusy)
                return;

            tb_upload_progress.Clear();
            tb_upload_progress.AppendText(string.Format("Preparing matches for upload to Crossoutdb." + Environment.NewLine + Environment.NewLine));
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent_initial;
            pb_upload.Refresh();

            Crossout.AspWeb.Models.API.v2.UploadReturn crossoutdbUploadReturn = Upload.GetPreviousUploads(session.LocalUserID, Upload.Domain.CrossoutDB);
            Crossout.AspWeb.Models.API.v2.UploadReturn xostatUploadReturn = Upload.GetPreviousUploads(session.LocalUserID, Upload.Domain.XOStat);

            tb_upload_progress.AppendText(string.Format("Found {0} crossoutdb matches previously uploaded." + Environment.NewLine, crossoutdbUploadReturn.uploaded_matches.Count));
            tb_upload_progress.AppendText(string.Format("Found {0} xostat.gg matches previously uploaded." + Environment.NewLine, xostatUploadReturn.uploaded_matches.Count));

            UpStatus = new UploadStatus();

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (!Upload.ValidMatch(match))
                {
                    continue;
                }

                UpStatus.CrossoutDB.Valid += 1;
                UpStatus.XOStat.Valid += 1;

                if (crossoutdbUploadReturn.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    UpStatus.CrossoutDB.Uploaded += 1;

                if (xostatUploadReturn.uploaded_matches.Contains(match.MatchData.ServerGUID))
                    UpStatus.XOStat.Uploaded += 1;
            }

            UpStatus.CalcTotals();

            tb_upload_progress.AppendText(string.Format("Found {0} total games." + Environment.NewLine, match_history.Count));

            lb_xodb_track.Text = string.Format("{0}/{1}", UpStatus.CrossoutDB.Uploaded, UpStatus.CrossoutDB.Valid);
            lb_xostat_track.Text = string.Format("{0}/{1}", UpStatus.XOStat.Uploaded, UpStatus.XOStat.Valid);
            //pb_upload_bar.Value = up_status.percent();

            lb_upload_status_text.Text = string.Format("Standing by to upload {0} matches, Press <Upload> when ready" + Environment.NewLine, UpStatus.Total.Valid - UpStatus.Total.Uploaded);
        }

        public void btn_upload_matchs_Click(object sender, EventArgs e)
        {
            if (bw_file_uploader.IsBusy)
                return;

            UpStatus.CalcTotals();
            tb_upload_progress.AppendText(string.Format("Starting background worker to upload. Feel free to use other screens during upload." + Environment.NewLine));
            //pb_upload_bar.Value = up_status.percent();
            pb_upload.Image = CO_Driver.Properties.Resources.codriver_transparent;
            pb_upload.Refresh();

            bw_file_uploader.RunWorkerAsync();
        }

        private void UploadFiles(object sender, DoWorkEventArgs e)
        {
            if (bw_file_uploader.CancellationPending)
                return;

            //bw_file_uploader.ReportProgress(0, new bw_status_update(Upload.Site.ALL, 0, "Starting Upload to CrossoutDB.com"));
            //upload_site(Upload.Site.CrossoutDB);

            bw_file_uploader.ReportProgress(0, new BackgroundWorkerStatusUpdate(Upload.Domain.ALL, 0, "Starting Upload to XOStat.gg"));
            UploadToDomainInBatches(Upload.Domain.XOStat);

            bw_file_uploader.ReportProgress(0, new BackgroundWorkerStatusUpdate(Upload.Domain.ALL, 0, "Upload Finished"));
        }

        private void UploadToDomainInBatches(Upload.Domain domain)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn previousUploads = Upload.GetPreviousUploads(session.LocalUserID, domain);
            List<long> uploadedMatches = previousUploads.uploaded_matches.ToList();
            List<string> uploadedBuilds = new List<string> { };
            Crossout.AspWeb.Models.API.v2.UploadEntry batch = Upload.BuildNextBatchForUpload(domain, session, match_history, build_records, translations, ref uploadedMatches, ref uploadedBuilds);

            while (batch.match_list.Count > 0)
            {
                if (bw_file_uploader.CancellationPending)
                    return;

                Crossout.AspWeb.Models.API.v2.UploadReturn upload = Upload.UploadToDomain(batch, domain);
                uploadedMatches.AddRange(upload.uploaded_matches);

                bw_file_uploader.ReportProgress(0, new BackgroundWorkerStatusUpdate(domain, batch.match_list.Count, string.Format("Uploaded {0} matches to {0}", batch.match_list.Count, domain == Upload.Domain.XOStat ? "XOStat.gg" : "CrossoutDB.com")));

                batch = Upload.BuildNextBatchForUpload(domain, session, match_history, build_records, translations, ref uploadedMatches, ref uploadedBuilds);
            }
        }

        private void ReportUploadStatus(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorkerStatusUpdate s = e.UserState as BackgroundWorkerStatusUpdate;

            if (s.Domain == Upload.Domain.CrossoutDB)
                UpStatus.CrossoutDB.Uploaded += s.Ammount;

            if (s.Domain == Upload.Domain.XOStat)
                UpStatus.XOStat.Uploaded += s.Ammount;

            UpStatus.CalcTotals();
            //pb_upload_bar.Value = up_status.percent();

            lb_xodb_track.Text = string.Format("{0}/{1}", UpStatus.CrossoutDB.Uploaded, UpStatus.CrossoutDB.Valid);
            lb_xostat_track.Text = string.Format("{0}/{1}", UpStatus.XOStat.Uploaded, UpStatus.XOStat.Valid);

            tb_upload_progress.AppendText(s.TextUpdate + Environment.NewLine);
            lb_upload_status_text.Text = string.Format(s.TextUpdate);
        }

        private void FinishedUploading(object sender, RunWorkerCompletedEventArgs e)
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
