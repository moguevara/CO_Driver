namespace CO_Driver
{
    partial class UploadScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_upload_status_text = new System.Windows.Forms.Label();
            this.pb_upload_bar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cancel_upload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_view_profile = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_upload_progress = new System.Windows.Forms.TextBox();
            this.pb_upload = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_xostat_track = new System.Windows.Forms.Label();
            this.lb_xodb_track = new System.Windows.Forms.Label();
            this.bw_file_uploader = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload)).BeginInit();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel11, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.15152F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.57576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.070707F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lb_upload_status_text, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pb_upload_bar, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 542);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1189, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lb_upload_status_text
            // 
            this.lb_upload_status_text.AutoSize = true;
            this.lb_upload_status_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_upload_status_text.Location = new System.Drawing.Point(3, 0);
            this.lb_upload_status_text.Name = "lb_upload_status_text";
            this.lb_upload_status_text.Size = new System.Drawing.Size(1183, 16);
            this.lb_upload_status_text.TabIndex = 3;
            this.lb_upload_status_text.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pb_upload_bar
            // 
            this.pb_upload_bar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_upload_bar.ForeColor = System.Drawing.Color.Lime;
            this.pb_upload_bar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pb_upload_bar.Location = new System.Drawing.Point(3, 19);
            this.pb_upload_bar.MarqueeAnimationSpeed = 200;
            this.pb_upload_bar.Name = "pb_upload_bar";
            this.pb_upload_bar.Size = new System.Drawing.Size(1183, 34);
            this.pb_upload_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_upload_bar.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btn_cancel_upload, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_view_profile, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 500);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1189, 36);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // btn_cancel_upload
            // 
            this.btn_cancel_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel_upload.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_upload.Location = new System.Drawing.Point(716, 3);
            this.btn_cancel_upload.Name = "btn_cancel_upload";
            this.btn_cancel_upload.Size = new System.Drawing.Size(231, 30);
            this.btn_cancel_upload.TabIndex = 44;
            this.btn_cancel_upload.Text = "Cancel";
            this.btn_cancel_upload.UseVisualStyleBackColor = true;
            this.btn_cancel_upload.Click += new System.EventHandler(this.btn_upload_cancel_click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(707, 30);
            this.button1.TabIndex = 43;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_upload_matchs_Click);
            // 
            // btn_view_profile
            // 
            this.btn_view_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_view_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_profile.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_profile.Location = new System.Drawing.Point(953, 3);
            this.btn_view_profile.Name = "btn_view_profile";
            this.btn_view_profile.Size = new System.Drawing.Size(233, 30);
            this.btn_view_profile.TabIndex = 42;
            this.btn_view_profile.Text = "View Profile";
            this.btn_view_profile.UseVisualStyleBackColor = true;
            this.btn_view_profile.Click += new System.EventHandler(this.btn_view_profile_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.tb_upload_progress, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.pb_upload, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 154);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1189, 340);
            this.tableLayoutPanel11.TabIndex = 5;
            // 
            // tb_upload_progress
            // 
            this.tb_upload_progress.BackColor = System.Drawing.Color.Black;
            this.tb_upload_progress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_upload_progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_upload_progress.ForeColor = System.Drawing.Color.Lime;
            this.tb_upload_progress.Location = new System.Drawing.Point(3, 105);
            this.tb_upload_progress.Multiline = true;
            this.tb_upload_progress.Name = "tb_upload_progress";
            this.tb_upload_progress.ReadOnly = true;
            this.tb_upload_progress.Size = new System.Drawing.Size(1183, 232);
            this.tb_upload_progress.TabIndex = 5;
            this.tb_upload_progress.TabStop = false;
            this.tb_upload_progress.WordWrap = false;
            // 
            // pb_upload
            // 
            this.pb_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_upload.Location = new System.Drawing.Point(3, 3);
            this.pb_upload.Name = "pb_upload";
            this.pb_upload.Size = new System.Drawing.Size(1183, 96);
            this.pb_upload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_upload.TabIndex = 6;
            this.pb_upload.TabStop = false;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(1189, 54);
            this.tableLayoutPanel12.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1183, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Upload to crossoutdb/xostat is still in beta. Data uploaded is not guaranteed to " +
    "persist. Click \"View Profile\" to access profile.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1183, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "CrossoutDB/XOStat Upload (BETA)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1189, 85);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1183, 28);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(594, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(586, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "XOStat";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(585, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "CrossoutDB";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.lb_xostat_track, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lb_xodb_track, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 37);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1183, 45);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // lb_xostat_track
            // 
            this.lb_xostat_track.AutoSize = true;
            this.lb_xostat_track.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_xostat_track.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_xostat_track.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_xostat_track.Location = new System.Drawing.Point(594, 0);
            this.lb_xostat_track.Name = "lb_xostat_track";
            this.lb_xostat_track.Size = new System.Drawing.Size(586, 45);
            this.lb_xostat_track.TabIndex = 5;
            this.lb_xostat_track.Text = "0/0";
            this.lb_xostat_track.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_xodb_track
            // 
            this.lb_xodb_track.AutoSize = true;
            this.lb_xodb_track.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_xodb_track.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_xodb_track.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lb_xodb_track.Location = new System.Drawing.Point(3, 0);
            this.lb_xodb_track.Name = "lb_xodb_track";
            this.lb_xodb_track.Size = new System.Drawing.Size(585, 45);
            this.lb_xodb_track.TabIndex = 4;
            this.lb_xodb_track.Text = "0/0";
            this.lb_xodb_track.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bw_file_uploader
            // 
            this.bw_file_uploader.WorkerReportsProgress = true;
            this.bw_file_uploader.WorkerSupportsCancellation = true;
            this.bw_file_uploader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.upload_files);
            this.bw_file_uploader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.report_upload_status);
            this.bw_file_uploader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.finished_uploading);
            // 
            // upload_screen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "upload_screen";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Load += new System.EventHandler(this.upload_screen_Load);
            this.Resize += new System.EventHandler(this.upload_screen_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_upload)).EndInit();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lb_upload_status_text;
        private System.Windows.Forms.Button btn_view_profile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        public System.Windows.Forms.TextBox tb_upload_progress;
        public System.Windows.Forms.ProgressBar pb_upload_bar;
        private System.Windows.Forms.PictureBox pb_upload;
        private System.ComponentModel.BackgroundWorker bw_file_uploader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel_upload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lb_xostat_track;
        private System.Windows.Forms.Label lb_xodb_track;
    }
}
