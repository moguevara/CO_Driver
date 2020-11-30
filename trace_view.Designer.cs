namespace RFB_Tool_Suite
{
    partial class trace_view
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
            this.lbl_trace_name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_trace_output = new System.Windows.Forms.TextBox();
            this.bw_file_tracer = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_trace_name
            // 
            this.lbl_trace_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_trace_name.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trace_name.Location = new System.Drawing.Point(0, 0);
            this.lbl_trace_name.Name = "lbl_trace_name";
            this.lbl_trace_name.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_trace_name.Size = new System.Drawing.Size(1195, 69);
            this.lbl_trace_name.TabIndex = 0;
            this.lbl_trace_name.Text = "Combat.Log Trace";
            this.lbl_trace_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_trace_output);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 532);
            this.panel1.TabIndex = 1;
            // 
            // tb_trace_output
            // 
            this.tb_trace_output.BackColor = System.Drawing.Color.Black;
            this.tb_trace_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_trace_output.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_trace_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_trace_output.ForeColor = System.Drawing.Color.Lime;
            this.tb_trace_output.Location = new System.Drawing.Point(0, 0);
            this.tb_trace_output.Multiline = true;
            this.tb_trace_output.Name = "tb_trace_output";
            this.tb_trace_output.ReadOnly = true;
            this.tb_trace_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_trace_output.Size = new System.Drawing.Size(1195, 532);
            this.tb_trace_output.TabIndex = 0;
            this.tb_trace_output.WordWrap = false;
            this.tb_trace_output.TextChanged += new System.EventHandler(this.tb_trace_output_TextChanged);
            // 
            // bw_file_tracer
            // 
            this.bw_file_tracer.WorkerReportsProgress = true;
            this.bw_file_tracer.WorkerSupportsCancellation = true;
            this.bw_file_tracer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_trace_file);
            this.bw_file_tracer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_write_trace);
            this.bw_file_tracer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_cancel_trace);
            // 
            // trace_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_trace_name);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "trace_view";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Leave += new System.EventHandler(this.trace_view_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_trace_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_trace_output;
        private System.ComponentModel.BackgroundWorker bw_file_tracer;
    }
}
