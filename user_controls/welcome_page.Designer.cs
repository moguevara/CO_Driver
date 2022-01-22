namespace CO_Driver
{
    partial class welcome_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcome_page));
            this.lbl_welcome_main = new System.Windows.Forms.Label();
            this.pb_welcome_file_load = new System.Windows.Forms.ProgressBar();
            this.lb_load_status_text = new System.Windows.Forms.Label();
            this.tb_progress_tracking = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_welcome_main
            // 
            resources.ApplyResources(this.lbl_welcome_main, "lbl_welcome_main");
            this.lbl_welcome_main.Name = "lbl_welcome_main";
            // 
            // pb_welcome_file_load
            // 
            resources.ApplyResources(this.pb_welcome_file_load, "pb_welcome_file_load");
            this.pb_welcome_file_load.ForeColor = System.Drawing.Color.Lime;
            this.pb_welcome_file_load.MarqueeAnimationSpeed = 200;
            this.pb_welcome_file_load.Name = "pb_welcome_file_load";
            this.pb_welcome_file_load.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lb_load_status_text
            // 
            this.lb_load_status_text.AllowDrop = true;
            resources.ApplyResources(this.lb_load_status_text, "lb_load_status_text");
            this.lb_load_status_text.BackColor = System.Drawing.Color.Transparent;
            this.lb_load_status_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_load_status_text.Name = "lb_load_status_text";
            // 
            // tb_progress_tracking
            // 
            resources.ApplyResources(this.tb_progress_tracking, "tb_progress_tracking");
            this.tb_progress_tracking.BackColor = System.Drawing.Color.Black;
            this.tb_progress_tracking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_progress_tracking.ForeColor = System.Drawing.Color.Lime;
            this.tb_progress_tracking.Name = "tb_progress_tracking";
            this.tb_progress_tracking.ReadOnly = true;
            this.tb_progress_tracking.TabStop = false;
            // 
            // welcome_page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tb_progress_tracking);
            this.Controls.Add(this.lb_load_status_text);
            this.Controls.Add(this.pb_welcome_file_load);
            this.Controls.Add(this.lbl_welcome_main);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "welcome_page";
            this.Load += new System.EventHandler(this.welcome_page_Load);
            this.Resize += new System.EventHandler(this.welcome_page_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome_main;
        public System.Windows.Forms.ProgressBar pb_welcome_file_load;
        public System.Windows.Forms.Label lb_load_status_text;
        public System.Windows.Forms.TextBox tb_progress_tracking;
    }
}
