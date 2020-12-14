namespace CO_Driver
{
    partial class schedule_display
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
            this.lbl_schedule_display_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_schedule_display_text
            // 
            this.lbl_schedule_display_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_schedule_display_text.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_schedule_display_text.Location = new System.Drawing.Point(0, 0);
            this.lbl_schedule_display_text.Name = "lbl_schedule_display_text";
            this.lbl_schedule_display_text.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_schedule_display_text.Size = new System.Drawing.Size(1169, 64);
            this.lbl_schedule_display_text.TabIndex = 0;
            this.lbl_schedule_display_text.Text = "CW Schedule";
            this.lbl_schedule_display_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // schedule_display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lbl_schedule_display_text);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "schedule_display";
            this.Size = new System.Drawing.Size(1169, 601);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_schedule_display_text;
    }
}
