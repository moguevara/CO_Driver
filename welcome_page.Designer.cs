namespace RFB_Tool_Suite
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
            this.lbl_welcome_main = new System.Windows.Forms.Label();
            this.pb_welcome_file_load = new System.Windows.Forms.ProgressBar();
            this.lb_load_status_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_welcome_main
            // 
            this.lbl_welcome_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_welcome_main.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome_main.Location = new System.Drawing.Point(0, 0);
            this.lbl_welcome_main.Name = "lbl_welcome_main";
            this.lbl_welcome_main.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_welcome_main.Size = new System.Drawing.Size(1195, 39);
            this.lbl_welcome_main.TabIndex = 0;
            this.lbl_welcome_main.Text = "Welcome to the Rot_Fish_Bandit Tool Suite";
            this.lbl_welcome_main.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pb_welcome_file_load
            // 
            this.pb_welcome_file_load.ForeColor = System.Drawing.Color.Lime;
            this.pb_welcome_file_load.Location = new System.Drawing.Point(48, 558);
            this.pb_welcome_file_load.Name = "pb_welcome_file_load";
            this.pb_welcome_file_load.Size = new System.Drawing.Size(1100, 30);
            this.pb_welcome_file_load.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_welcome_file_load.TabIndex = 1;
            // 
            // lb_load_status_text
            // 
            this.lb_load_status_text.AllowDrop = true;
            this.lb_load_status_text.BackColor = System.Drawing.Color.Transparent;
            this.lb_load_status_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_load_status_text.Location = new System.Drawing.Point(48, 525);
            this.lb_load_status_text.Name = "lb_load_status_text";
            this.lb_load_status_text.Size = new System.Drawing.Size(1100, 30);
            this.lb_load_status_text.TabIndex = 2;
            this.lb_load_status_text.Text = "write status text here";
            this.lb_load_status_text.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // welcome_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lb_load_status_text);
            this.Controls.Add(this.pb_welcome_file_load);
            this.Controls.Add(this.lbl_welcome_main);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "welcome_page";
            this.Size = new System.Drawing.Size(1195, 601);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_welcome_main;
        private System.Windows.Forms.ProgressBar pb_welcome_file_load;
        private System.Windows.Forms.Label lb_load_status_text;
    }
}
