namespace CO_Driver
{
    partial class TraceView
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
            this.bw_file_tracer = new System.ComponentModel.BackgroundWorker();
            this.lbl_trace_name = new System.Windows.Forms.Label();
            this.lbl_current_file_name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_trace_output = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bw_file_tracer
            // 
            this.bw_file_tracer.WorkerReportsProgress = true;
            this.bw_file_tracer.WorkerSupportsCancellation = true;
            this.bw_file_tracer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_trace_file);
            this.bw_file_tracer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_write_trace);
            this.bw_file_tracer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_work_complete);
            // 
            // lbl_trace_name
            // 
            this.lbl_trace_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_trace_name.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trace_name.Location = new System.Drawing.Point(3, 0);
            this.lbl_trace_name.Name = "lbl_trace_name";
            this.lbl_trace_name.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lbl_trace_name.Size = new System.Drawing.Size(1189, 42);
            this.lbl_trace_name.TabIndex = 0;
            this.lbl_trace_name.Text = "Combat.Log Trace";
            this.lbl_trace_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_current_file_name
            // 
            this.lbl_current_file_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_current_file_name.Location = new System.Drawing.Point(3, 42);
            this.lbl_current_file_name.Name = "lbl_current_file_name";
            this.lbl_current_file_name.Size = new System.Drawing.Size(1189, 30);
            this.lbl_current_file_name.TabIndex = 2;
            this.lbl_current_file_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tb_trace_output, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_current_file_name, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_trace_name, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 601);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tb_trace_output
            // 
            this.tb_trace_output.BackColor = System.Drawing.Color.Black;
            this.tb_trace_output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_trace_output.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_trace_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_trace_output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_trace_output.ForeColor = System.Drawing.Color.Lime;
            this.tb_trace_output.Location = new System.Drawing.Point(3, 75);
            this.tb_trace_output.Multiline = true;
            this.tb_trace_output.Name = "tb_trace_output";
            this.tb_trace_output.ReadOnly = true;
            this.tb_trace_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_trace_output.Size = new System.Drawing.Size(1189, 523);
            this.tb_trace_output.TabIndex = 0;
            this.tb_trace_output.WordWrap = false;
            // 
            // trace_view
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.MinimumSize = new System.Drawing.Size(1195, 601);
            this.Name = "trace_view";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Load += new System.EventHandler(this.trace_view_Load);
            this.Leave += new System.EventHandler(this.trace_view_Leave);
            this.Resize += new System.EventHandler(this.trace_view_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bw_file_tracer;
        private System.Windows.Forms.Label lbl_trace_name;
        private System.Windows.Forms.Label lbl_current_file_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tb_trace_output;
    }
}
